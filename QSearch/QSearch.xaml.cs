
using QSearch.Models;
using Application = Microsoft.Maui.Controls.Application;
using System.Text.RegularExpressions;
using SQLitePCL;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui;
using System;
using Microsoft.Maui.Devices;

#if ANDROID
using Android.Views;
#endif

namespace QSearch;
public partial class QSearch : ContentPage, IOnPageKeyDown
{
    QuranDB dB;
    //Options opt;
    OptionsData ret = new OptionsData();
    private string words_entered = string.Empty;
    private int firstItem = 0;
    Progress progress;
    List<Verse> Verses = new List<Verse>();
    /// <summary>
    /// by default show English translation only
    /// </summary>
    public int selectedLanguage = 1;
    /// <summary>
    /// check latest version
    /// </summary>
    /// <returns></returns>
    public QSearch(QuranDB qdb)
    {
        InitializeComponent();
        dB = qdb;
        Loaded += QSearch_Loaded;
        ret.option = string.Empty;
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
        {
#if ANDROID
            //handler.PlatformView.ShowSoftInputOnFocus = false;
            handler.PlatformView.KeyPress += PlatformView_KeyPress;
#endif
        });
        progress = new Progress(progInd);
        //Task.Run(async () => await CheckLatestVersion());
    }
#if ANDROID
    public bool OnPageKeyDown(Keycode keyCode, KeyEvent e)
    {
        switch (keyCode)
        {
            case Keycode.Enter:
                // Your code here
                // if (words_entered.Length == 0)
                // {
                //     DisplayAlert("Q-Search", "Please enter a word to search for!", "Ok");
                // }
                return true;

            default:
                return false;
        }
    }
    /// <summary>
    /// handle the blank enter action
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void PlatformView_KeyPress(object sender, Android.Views.View.KeyEventArgs e)
    {
        if (e.KeyCode == Android.Views.Keycode.Enter
            && words_entered.Length == 0)
        {
            e.Handled = true;
            await DisplayAlertAsync("Q-Search", "Please enter a word to search for!", "Ok");
            return;
        }
        else e.Handled = false;
    }
#endif
    /// <summary>
    /// when a text is entered
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void txtSearch_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        words_entered += e.NewTextValue;
    }
    private void QSearch_Loaded(object sender, EventArgs e)
    {
        txtSearch.Focus();
    }
    /// <summary>
    /// The search click button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void txtSearch_Completed(System.Object sender, System.EventArgs e)
    {
        Entry txt = (Entry)sender;
        var screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
        int wordcount = 0;

        if (txt.Text.Length == 0)
        {
            await DisplayAlertAsync("Q-Search", "Please enter a word to search for!", "Ok");
            return;
        }
        imgNotes.IsVisible = false;
        lstView.ItemsSource = null;

        Verses = new List<Verse>();
        string[] words = txt.Text.Trim().Split(' ');
        // if not any english alpah //
        string pattern = "^[a-zA-Z\"!]*$";
        // Regex rg = new Regex(pattern);
        Regex rg;

        // smart quotes to double quotes //
        if (words[0].IndexOf('\u201c') > -1)
        {
            words[0] = words[0].Replace('\u201c', '"');
        }
        if (words[0].IndexOf('\u201d') > -1)
        {
            words[0] = words[0].Replace('\u201d', '"');
        }
        var srch = "";
        string currentLanguage = "en";
#if MACCATALYST
        LangDetection lang = new LangDetection(txt.Text);
        currentLanguage = lang.LanguageDetected;
#else
        currentLanguage = new LangDetection().LanguageDetected;
#endif
        // if (currentLanguage == "en" && selectedLanguage != 1)
        // {
        //     await DisplayAlertAsync("Q-Search", "Please choose English translation for search!", "Ok");
        //     return;
        // }
        // else if (currentLanguage == "ur" && selectedLanguage != 2)
        // {
        //     await DisplayAlertAsync("Q-Search", "Please choose Urdu translation for search!", "Ok");
        //     return;
        // }
        
        selectedLanguage = currentLanguage == "en" ? 1 : 2;
        progress.ShowProgress();
        await Task.Delay(50);
        switch(currentLanguage)
        {
            case "en":
                pattern = "\"";
                rg = new Regex(pattern);
                if (words.Length == 1)
                {
                    srch = words[0];
                    if (rg.IsMatch(srch))
                    {
                        srch = words[0].Replace("\"", "");
                        Verses = await dB.GetVerseExactAsync(srch);
                    }
                    else
                    {
                        Verses = await dB.GetVerseAsync(srch);
                    }
                }
                else
                {
                    // multiple words, use OR query //
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (rg.IsMatch(words[i]))
                        {
                            words[i] = words[i].Replace("\"", "");
                        }
                    }
                    Verses = await dB.GetVerseAsync(words);
                }
                selectedLanguage = 1;
                break;
            case "ar":
                if (words.Length == 1)
                {
                    srch = words[0];
                    Verses = await dB.GetArabicVerseAsync(srch);
                }
                else
                {
                    // multiple words, use OR query //
                    for (int i = 0; i < words.Length; i++)
                    {
                        words[i] = words[i].Replace("\"", "");
                    }
                    Verses = await dB.GetArabicVerseAsync(words);
                }
                break;
            case "ur":
                if (words.Length == 1)
                {
                    srch = words[0];
                    Verses = await dB.GetUrduVerseAsync(srch);
                }
                else
                {
                    // multiple words, use OR query //
                    for (int i = 0; i < words.Length; i++)
                    {
                        words[i] = words[i].Replace("\"", "");
                    }
                    Verses = await dB.GetUrduVerseAsync(words);
                }
                selectedLanguage = 2;
                break;
            default:
                pattern = "^[a-zA-Z\"!]*$";
                selectedLanguage = 1;
                break;
        }
        result.IsVisible = false;
        // databinding the listview //
        foreach (var _v in Verses)
        {
            _v.font = Preferences.Default.Get<string>("Font", "NotoArabic");
            if (_v.verse_arabic.Contains("۩"))
            {
                _v.verse_arabic = _v.verse_arabic.Replace("۩", "");
                _v.verse_arabic_end = "۩ (Sujood)";    
            }
            // show translation based on user selection //
            switch(selectedLanguage)
            {
                case 1:
                    _v.showEnglish = true;
                    _v.showUrdu = false;
                    break;
                case 2:
                    _v.showUrdu = true;
                    _v.showEnglish = false;
                    break;
                default:
                    _v.showEnglish = true;
                    _v.showUrdu = false;
                    break;
            }
        }
        lstView.ItemsSource = Verses;
        if (Verses.Count() == 0)
        {
            await DisplayAlertAsync("Q-Search", "No search found!", "OK");
           progress.HideProgress();
        }
        else
        {
            result.IsVisible = true;
            total.Text = Verses.Count.ToString();
            lstView.HeightRequest = screenHeight - 250;

            switch(currentLanguage)
            {
                case "en":
                    for (int i = 0; i < words.Length; i++)
                    {
                        srch = words[i].Replace("\"", "");
                        foreach (Verse v in Verses)
                        {
                            if (words[i].Contains("\""))
                            {
                                // we want to search exact word and highlight that only //
                                if (!dB.prepositions.Contains(srch))
                                {
                                    int exactWordIndex = v.verse_english.IndexOf(srch, 0, StringComparison.OrdinalIgnoreCase);
                                    if (exactWordIndex > 0)
                                    {
                                        string exactWord = v.verse_english.Substring(exactWordIndex, srch.Length);
                                        v.verse_english = v.verse_english.Replace(" " + srch + " ", "<span style=\"background-color:yellow\">" + " " + exactWord + " " + "</span>", StringComparison.CurrentCultureIgnoreCase);
                                        v.verse_english = v.verse_english.Replace(" " + srch + ".", "<span style=\"background-color:yellow\">" + " " + exactWord + "." + "</span>", StringComparison.CurrentCultureIgnoreCase);
                                        v.verse_english = v.verse_english.Replace(" " + srch + "!", "<span style=\"background-color:yellow\">" + " " + exactWord + "!" + "</span>", StringComparison.CurrentCultureIgnoreCase);
                                        v.verse_english = v.verse_english.Replace(" " + srch + ",", "<span style=\"background-color:yellow\">" + " " + exactWord + "," + "</span>", StringComparison.CurrentCultureIgnoreCase);
                                    }
                                    else
                                        v.verse_english = v.verse_english.Replace(" " + srch + " ", "<span style=\"background-color:yellow\">" + " " + srch + "." + "</span>", StringComparison.CurrentCultureIgnoreCase);
                                }
                            }
                            else
                            {
                                if (!dB.prepositions.Contains(srch))
                                    v.verse_english = v.verse_english.Replace(srch, "<span style=\"background-color:yellow\">" + srch + "</span>", StringComparison.CurrentCultureIgnoreCase);
                            }
                            if (!v.verse_arabic.Contains("<p style=\"text-align:right;\">"))
                                v.verse_arabic = "<p style=\"text-align:right;\">" + v.verse_arabic + "</p>";
                            //// if we need to show urdu translation, on clicking the language, right align it//
                            if (!v.verse_urdu.Contains("<p style=\"text-align:right;\">"))
                                v.verse_urdu = "<p style=\"text-align:right;\">" + v.verse_urdu + "</p>";  
                        }
                    }
                    break;
                case "ar":
                // multiple words //
                        foreach (Verse v in Verses)
                        {
                           for (int i = 0; i < words.Length; i++)
                            {
                                srch = words[i].Trim();
                                var loc = v.verse_arabic_clean.IndexOf(srch);
                                var w = "";
                                if (loc >= 0)
                                {
                                    bool found = false;
                                    while (!found && (loc + srch.Length * 2) < v.verse_arabic.Length)
                                    {
                                        w = v.verse_arabic.Substring(loc, srch.Length + srch.Length / 2);
                                        if (w.Trim().StartsWith("<span style=\"background-color:yellow\"")
                                            ||
                                            w.Trim().StartsWith("<sp"))
                                        {
                                            loc += 38;
                                            continue;
                                        }
                                        else if (w.Trim().StartsWith("<p style")
                                                ||
                                                w.Trim().StartsWith("<p"))
                                        {
                                            loc += 30;
                                            continue;
                                        }
                                        else if (w.Trim().StartsWith("</p"))
                                        {
                                            loc += 4;
                                            continue;
                                        }
                                        else if (w.Trim().StartsWith("</sp"))
                                        {
                                            loc += 6;
                                            continue;
                                        }
                                        if (foundWord(srch, v.verse_arabic.Substring(loc, srch.Length + srch.Length / 2), 
                                                      v, words.Length, ref wordcount, loc, srch.Length + srch.Length / 2))
                                            found = true;
                                        else if (foundWord(srch, v.verse_arabic.Substring(loc, srch.Length + Convert.ToInt32(srch.Length / 1.5)), 
                                                            v, words.Length, ref wordcount, loc, srch.Length + Convert.ToInt32(srch.Length / 1.5)))
                                            {
                                                found = true;
                                                w = v.verse_arabic.Substring(loc, srch.Length + Convert.ToInt32(srch.Length / 1.5));
                                            }
                                        else if (foundWord(srch, v.verse_arabic.Substring(loc, srch.Length * 2), 
                                                            v, words.Length, ref wordcount, loc, srch.Length * 2))
                                            {
                                                found = true;
                                                w = v.verse_arabic.Substring(loc, srch.Length * 2);
                                            }
                                        else if (foundWord(srch, v.verse_arabic.Substring(loc, srch.Length * 2 + 1), 
                                                            v, words.Length, ref wordcount, loc, srch.Length * 2 + 1))
                                            {
                                                found = true;
                                                w = v.verse_arabic.Substring(loc, srch.Length * 2 + 1);
                                            }

                                        loc += 1;
                                    }
                                    // highlight only if found //
                                    if (found)
                                    {
                                        v.verse_arabic = v.verse_arabic.Replace(w, "<span style=\"background-color:yellow\">" + w + "</span>");
                                        found = false;
                                    }
                                    if (!v.verse_arabic.Contains("<p style=\"text-align:right;\">"))
                                    v.verse_arabic = "<p style=\"text-align:right;\">" + v.verse_arabic + "</p>";
                                    //// if we need to show urdu translation, on clicking the language, right align it//
                                    if (!v.verse_urdu.Contains("<p style=\"text-align:right;\">"))
                                        v.verse_urdu = "<p style=\"text-align:right;\">" + v.verse_urdu + "</p>";  
                                }
                            }
                        }
                    break;
                case "ur":
                    for (int i = 0; i < words.Length; i++)
                    {
                        srch = words[i].Trim();
                        foreach (Verse v in Verses)
                        {
                            if (v.verse_urdu.IndexOf(srch) >= 0)
                            {
                                v.verse_urdu = v.verse_urdu.Replace(srch, "<span style=\"background-color:yellow\"> " + srch + " </span>", StringComparison.CurrentCultureIgnoreCase);
                            }
                            if (!v.verse_urdu.Contains("<p style=\"text-align:right;\">"))
                                v.verse_urdu = "<p style=\"text-align:right;\">" + v.verse_urdu + "</p>"; 
                            if (!v.verse_arabic.Contains("<p style=\"text-align:right;\">"))
                                v.verse_arabic = "<p style=\"text-align:right;\">" + v.verse_arabic + "</p>";
                        }
                    }
                     break;
                default:
                    break;
            }
        }
        txt.SelectionLength = txt.Text.Length;
        lblWords.IsVisible = false;
        totalWords.IsVisible = false;
        if (words.Length == 1)
        {
            if (currentLanguage == "ar")
            {
                lblWords.IsVisible = true;
                totalWords.IsVisible = true;
                totalWords.Text = wordcount.ToString();
            }
        }
        progress.HideProgress();
    }
    /// <summary>
    /// search words with different lengths due to tashkeel, tatweel etc. and count them
    /// </summary>
    /// <param name="srch"></param>
    /// <param name="w"></param>
    /// <param name="v"></param>
    /// <param name="words_length"></param>
    /// <param name="wordcount"></param>
    /// <param name="loc"></param>
    /// <param name="wordLength"></param>
    /// <returns></returns>
    private bool foundWord(string srch, string w, Verse v, int words_length, ref int wordcount, int loc, int wordLength)
    {
        string w_normal = normalize(w);
        if ((w_normal.TrimStart() == srch + " ") || (w_normal.TrimStart() == srch)
                || (w_normal.TrimEnd() == srch))
        {                                            
            if (words_length == 1) 
            {
                wordcount++;
                CountWords(srch, v, loc, ref wordcount, wordLength);
            }
            return true;
        }
        return false;
    }
    /// <summary>
    /// cound words found if one arabic word is entered
    /// </summary>
    /// <param name="srch"></param>
    /// <param name="v"></param>
    /// <param name="loc"></param>
    /// <param name="wordcount"></param>
    private void CountWords(string srch, Verse v, int loc, ref int wordcount, int wordLength)
    {
        loc += srch.Length;
        while ((loc + wordLength) < v.verse_arabic.Length)
        {
            var w_next = v.verse_arabic.Substring(loc, wordLength);
            var w_normal = normalize(w_next);
            if ((w_normal.TrimStart() == srch + " ") || (w_normal.TrimStart() == srch))
            {
                wordcount++;
            }
            loc += 1;
        }
    }
    /// <summary>
    ///  for Arabic words highlighting
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private String normalize(string input)
    {

        //Remove honorific sign //
        input = input.Replace("\u0610", "");//ARABIC SIGN SALLALLAHOU ALAYHE WA SALLAM
        input = input.Replace("\u0611", "");//ARABIC SIGN ALAYHE ASSALLAM
        input = input.Replace("\u0612", "");//ARABIC SIGN RAHMATULLAH ALAYHE
        input = input.Replace("\u0613", "");//ARABIC SIGN RADI ALLAHOU ANHU
        input = input.Replace("\u0614", "");//ARABIC SIGN TAKHALLUS

        //Remove koranic anotation //
        input = input.Replace("\u0615", "");//ARABIC SMALL HIGH TAH
        input = input.Replace("\u0617", "");//ARABIC SMALL HIGH ZAIN
        input = input.Replace("\u0618", "");//ARABIC SMALL FATHA
        input = input.Replace("\u0619", "");//ARABIC SMALL DAMMA
        input = input.Replace("\u061A", "");//ARABIC SMALL KASRA
        input = input.Replace("\u06D6", "");//ARABIC SMALL HIGH LIGATURE SAD WITH LAM WITH ALEF MAKSURA
        input = input.Replace("\u06D7", "");//ARABIC SMALL HIGH LIGATURE QAF WITH LAM WITH ALEF MAKSURA
        input = input.Replace("\u06D8", "");//ARABIC SMALL HIGH MEEM INITIAL FORM
        input = input.Replace("\u06D9", "");//ARABIC SMALL HIGH LAM ALEF
        input = input.Replace("\u06DA", "");//ARABIC SMALL HIGH JEEM
        input = input.Replace("\u06DB", "");//ARABIC SMALL HIGH THREE DOTS
        input = input.Replace("\u06DC", "");//ARABIC SMALL HIGH SEEN
        input = input.Replace("\u06DD", "");//ARABIC END OF AYAH
        input = input.Replace("\u06DE", "");//ARABIC START OF RUB EL HIZB
        input = input.Replace("\u06DF", "");//ARABIC SMALL HIGH ROUNDED ZERO
        input = input.Replace("\u06E0", "");//ARABIC SMALL HIGH UPRIGHT RECTANGULAR ZERO
        input = input.Replace("\u06E1", "");//ARABIC SMALL HIGH DOTLESS HEAD OF KHAH
        input = input.Replace("\u06E2", "");//ARABIC SMALL HIGH MEEM ISOLATED FORM
        input = input.Replace("\u06E3", "");//ARABIC SMALL LOW SEEN
        input = input.Replace("\u06E4", "");//ARABIC SMALL HIGH MADDA
        input = input.Replace("\u06E5", "");//ARABIC SMALL WAW
        input = input.Replace("\u06E8", "");//ARABIC SMALL HIGH NOON
        input = input.Replace("\u06E9", "");//ARABIC PLACE OF SAJDAH
        input = input.Replace("\u06EA", "");//ARABIC EMPTY CENTRE LOW STOP
        input = input.Replace("\u06EB", "");//ARABIC EMPTY CENTRE HIGH STOP
        input = input.Replace("\u06EC", "");//ARABIC ROUNDED HIGH STOP WITH FILLED CENTRE
        input = input.Replace("\u06ED", "");//ARABIC SMALL LOW MEEM

        // Remove tatweel //
        input = input.Replace("\u0640", "");

        // Remove tashkeel //
        input = input.Replace("\u064B", "");//ARABIC FATHATAN
        input = input.Replace("\u064C", "");//ARABIC DAMMATAN
        input = input.Replace("\u064D", "");//ARABIC KASRATAN
        input = input.Replace("\u064E", "");//ARABIC FATHA
        input = input.Replace("\u064F", "");//ARABIC DAMMA
        input = input.Replace("\u0650", "");//ARABIC KASRA
        input = input.Replace("\u0651", "");//ARABIC SHADDA
        input = input.Replace("\u0652", "");//ARABIC SUKUN
        input = input.Replace("\u0653", "");//ARABIC MADDAH ABOVE
        input = input.Replace("\u0656", "");//ARABIC SUBSCRIPT ALEF
        input = input.Replace("\u0657", "");//ARABIC INVERTED DAMMA
        input = input.Replace("\u0658", "");//ARABIC MARK NOON GHUNNA
        input = input.Replace("\u0659", "");//ARABIC ZWARAKAY
        input = input.Replace("\u065A", "");//ARABIC VOWEL SIGN SMALL V ABOVE
        input = input.Replace("\u065B", "");//ARABIC VOWEL SIGN INVERTED SMALL V ABOVE
        input = input.Replace("\u065C", "");//ARABIC VOWEL SIGN DOT BELOW
        input = input.Replace("\u065D", "");//ARABIC REVERSED DAMMA
        input = input.Replace("\u065F", "");//ARABIC WAVY HAMZA BELOW
        input = input.Replace("\u0670", "");//ARABIC LETTER SUPERSCRIPT ALEF

        //Replace Waw Hamza Above by Waw
        input = input.Replace("\u0624", "\u0648");

        //Replace Ta Marbuta by Ha
        //input = input.Replace("\u0629", "\u0647");

        // Replace Alifs with Hamza Above/Below
        // and with Madda Above by Alif
        input = input.Replace("\u0622", "\u0627");
        input = input.Replace("\u0623", "\u0627");
        input = input.Replace("\u0625", "\u0627");

        return input;
    }
    /// <summary>
    /// on focus back
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();
        progress.HideProgress();
    }
    /// <summary>
    ///  font selection
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnFont_Clicked(object sender, EventArgs e)
    {
        ArabicFont fn = new ArabicFont();
        #if MACCATALYST
            await Navigation.PushAsync(fn);
        #else
            await Navigation.PushModalAsync(fn);
        #endif
        await fn.PopupDismissedTask;
        if (fn.ReturnValue.optionSelection == 0)
        {
            // refresh the collectionview //
            Verses = lstView.ItemsSource as List<Verse>;
            if (Verses != null)
            {
                foreach (var _v in Verses)
                    _v.font = Preferences.Default.Get<string>("Font", "NotoArabic");
                lstView.ItemsSource = null;
                progress.ShowProgress();
                lstView.ItemsSource = Verses;
                Dispatcher.Dispatch(() => lstView.ScrollTo(firstItem, position: ScrollToPosition.Center, animate: true));
                progress.HideProgress();
            }
        }
    }
    /// <summary>
    /// when scrolling is done
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void lstView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        firstItem = e.CenterItemIndex;
        
    }
    /// <summary>
    /// show translation option
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void showTranslation_Clicked(object sender, EventArgs e)
    {
        var popup = new TranslationOption();

        // The type parameter must match the type returned from the popup.
        IPopupResult<Int16> popupResult = await this.ShowPopupAsync<Int16>(popup, new PopupOptions
                {
                    PageOverlayColor = Colors.DarkSlateGray.WithAlpha(0.6f)
                }, CancellationToken.None);

        if (popupResult == null || popupResult.WasDismissedByTappingOutsideOfPopup)
        {
            return;
        }
        Verses = lstView.ItemsSource as List<Verse>;
        switch (popupResult.Result)
        {
            case 1:
                // English translation was tapped
                if (Verses != null)
                {
                    foreach (var _v in Verses)
                    {
                        _v.showEnglish = true;
                        _v.showUrdu = false;
                    }
                }
                selectedLanguage = 1;
                break;
            case 2:
                // Urdu translation was tapped
                if (Verses != null)
                {
                    foreach (var _v in Verses)
                    {
                        _v.showUrdu = true;
                        _v.showEnglish = false;
                    }
                }   
                selectedLanguage = 2;
                break;
        }
        if (Verses != null)
        {
            lstView.ItemsSource = null;
            progress.ShowProgress();
            lstView.ItemsSource = Verses;
            Dispatcher.Dispatch(() => lstView.ScrollTo(firstItem, position: ScrollToPosition.Center, animate: true));
            progress.HideProgress();
        }
    }
}

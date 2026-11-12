using System.Text.RegularExpressions;
using System.Web;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using QSearch.Models;

namespace QSearch;
[QueryProperty(nameof(chapter), "chapter")]
public partial class RSurah1 : ContentPage, IQueryAttributable
{
    QuranDB dB;
    int chapter_no = 0;
    //Options opt;
    OptionsData ret = new OptionsData();
    List<QuranicVerse> surahs = new List<QuranicVerse>();
    readonly List<GroupedVerse> groupedVerse = new List<GroupedVerse>();
    Surah surah_info = new Surah();
    public bool showTrans = false;
    int firstItem = 0;
    readonly Progress progress;
    public int chapter {get; set;}
    public int selectedLanguage = 1;
    public bool showSeparator = false;
     public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        chapter = Convert.ToInt32(HttpUtility.UrlDecode(query["chapter"].ToString()));
        chapter_no = chapter;
        // show tick mark if bookmarked //
        string bmSurahs = Preferences.Default.Get<string>("SURAH_NO_" + chapter_no.ToString(), null);
        if (bmSurahs != null)
        {
            FontImageSource fi = bmSurah.Source as FontImageSource;
            fi.Color = Colors.Green;
        }
        switch (chapter_no)
        {
            case 1:
                btnBack.BackgroundColor = Colors.DimGray;
                break;
            case 114:
                btnForward.BackgroundColor = Colors.DimGray;
                break;
            default:
                btnBack.BackgroundColor = Colors.LightSkyBlue;
                btnForward.BackgroundColor = Colors.LightSkyBlue;
                break;
        }           
        if (groupedVerse.Count == 0)
        {
            surah_info = await dB.GetSurahInfo(chapter_no);
            surahs = await dB.GetSurahByNumber(chapter_no);
            surah_info.para_name = surahs[0].para_name;
            surah_info.para_number = surahs[0].para_number;
            this.Title = "Recite Surah - " + surah_info.chapter_name_arabic;
            grdHeader.BindingContext = surah_info;
            progress.ShowProgress();

            ret.fontSize = Preferences.Default.Get<int>("FontSize", 28); 
            ret.optionColor = Preferences.Default.Get<string>("FontColor", "Black");
            MainThread.BeginInvokeOnMainThread(async () => await LinesByLines());
        }
    }
    //used by GoToAsync //
    public RSurah1(QuranDB qdb)
	{
		InitializeComponent();
        dB = qdb;
        progress = new Progress(progInd);
        lstView.ItemsSource = null;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        var screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
        lstView.IsVisible = true;
        lstView.HeightRequest = screenHeight - 270;
    }
    /// <summary>
    /// Lines by Lines
    /// </summary>
    private async Task LinesByLines()
    {
        progress.ShowProgress();
        await Task.Delay(10);
        int groupedVerseCount = 0;

        ReciteSurah _reciteSurah = new()
        {
            font = Preferences.Default.Get<string>("Font", "NotoArabic"),
            isTranslationVisible = showTrans,
            verse_arabic_lines = new string[10],
            verse_translation_lines = new string[10],
            translation_ref_lines = new string[10],
            ruku_lines = new bool[10],
            sujood_lines = new bool[10],
            verse_number = new int[10],
            showLine = new bool[10],
            fontColor = Color.Parse(Preferences.Default.Get<string>("FontColor", "Black")),
            fontSize = Preferences.Default.Get<int>("FontSize", 28),
            font_translation = selectedLanguage == 2 ? "Urdu" : "Tahoma"
        };
        for (int i = 0; i < surahs.Count; i++)
        {
            if ((i % 10 == 0) && (i > 0))
            {
                groupedVerse.Add(new GroupedVerse(surahs[i].chapter_name_english, new List<ReciteSurah> { _reciteSurah }));
                _reciteSurah = new()
                        {
                            font = Preferences.Default.Get<string>("Font", "NotoArabic"),
                            isTranslationVisible = showTrans,
                            verse_arabic_lines = new string[10],
                            verse_translation_lines = new string[10],
                            translation_ref_lines = new string[10],
                            ruku_lines = new bool[10],
                            sujood_lines = new bool[10],
                            verse_number = new int[10],
                            showLine = new bool[10],
                            fontColor = Color.Parse(Preferences.Default.Get<string>("FontColor", "Black")),
                            fontSize = Preferences.Default.Get<int>("FontSize", 28),
                            font_translation = selectedLanguage == 2 ? "Urdu" : "Tahoma"
                        };              
                groupedVerseCount = 0;
            }
            _reciteSurah.verse_arabic_lines[groupedVerseCount] = surahs[i].verse_arabic.Replace("[", string.Empty).Replace("]", string.Empty).Replace(Regex.Match(surahs[i].verse_arabic, @"\d+").Value.ToString(), string.Empty).Replace("۩", string.Empty);
            _reciteSurah.verse_number[groupedVerseCount] = surahs[i].verse_number;
            if (showTrans)
            {
                switch(selectedLanguage)
                {
                    case 1:
                        _reciteSurah.verse_translation_lines[groupedVerseCount] = surahs[i].verse_english;
                        _reciteSurah.translation_ref_lines[groupedVerseCount] = surahs[i].english_ref;
                        break;
                    case 2:
                        _reciteSurah.verse_translation_lines[groupedVerseCount] = surahs[i].verse_urdu;
                        _reciteSurah.translation_ref_lines[groupedVerseCount] = surahs[i].urdu_ref; 
                        break;
                    default:
                        _reciteSurah.verse_translation_lines[groupedVerseCount] = surahs[i].verse_english;
                        _reciteSurah.translation_ref_lines[groupedVerseCount] = surahs[i].english_ref;
                        break;
                }
            }
            else
            {
                _reciteSurah.verse_translation_lines[groupedVerseCount] = string.Empty;
                _reciteSurah.translation_ref_lines[groupedVerseCount] = string.Empty;
            }

            _reciteSurah.ruku_lines[groupedVerseCount] = surahs[i].ruku;
            _reciteSurah.sujood_lines[groupedVerseCount] = surahs[i].sujood;
            _reciteSurah.showLine[groupedVerseCount] = showSeparator;
            groupedVerseCount++;
        }
        /// if verse count is less than 10, then add to the group ////
        if (groupedVerseCount > 0)
        {
            groupedVerse.Add(new GroupedVerse(surahs[0].chapter_name_english, new List<ReciteSurah> { _reciteSurah }));
        }
        lstView.ItemsSource = groupedVerse;
        progress.HideProgress();
    }

    private void UpdateGroupedTranslations()
    {
        int verseIndex = 0;
        foreach (var group in groupedVerse)
        {
            foreach (var reciteSurah in group)
            {
                var translations = new string[10];
                var references = new string[10];
                for (int lineIndex = 0; lineIndex < 10 && verseIndex < surahs.Count; lineIndex++, verseIndex++)
                {
                    if (!showTrans)
                        continue;

                    switch (selectedLanguage)
                    {
                        case 1:
                            translations[lineIndex] = surahs[verseIndex].verse_english;
                            references[lineIndex] = surahs[verseIndex].english_ref;
                            break;
                        case 2:
                            translations[lineIndex] = surahs[verseIndex].verse_urdu;
                            references[lineIndex] = surahs[verseIndex].urdu_ref;
                            break;
                    }
                }

                reciteSurah.verse_translation_lines = translations;
                reciteSurah.translation_ref_lines = references;
                reciteSurah.NotifyBindingsChanged(nameof(ReciteSurah.verse_translation_lines));
                reciteSurah.NotifyBindingsChanged(nameof(ReciteSurah.translation_ref_lines));
                reciteSurah.font_translation = selectedLanguage == 2 ? "Urdu" : "Tahoma";
                reciteSurah.NotifyBindingsChanged(nameof(ReciteSurah.font_translation));
                reciteSurah.isTranslationVisible = showTrans && selectedLanguage is 1 or 2;
            }
        }
    }

    /// <summary>
    /// tool bar options clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        //await Shell.Current.Navigation.PopToRootAsync();
        await Shell.Current.GoToAsync("Search", false);
    }
    /// <summary>
    /// bookmarking this surah
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
     async void bmSurah_Clicked(System.Object sender, System.EventArgs e)
    {
        string bmSurahs = Preferences.Default.Get<string>("SURAH_NO_" + chapter_no.ToString(), null);
        if (bmSurahs != null)
        {
            bool answer = await DisplayAlertAsync("Q-Search", "Remove this bookmark?", "Yes", "No");
            if (answer)
            {
                Preferences.Default.Remove("SURAH_NO_" + chapter_no.ToString());
                FontImageSource fi = bmSurah.Source as FontImageSource;
                fi.Color = Colors.Black;
            }
        }
        else
        {
            Preferences.Default.Set<string>("SURAH_NO_" + chapter_no.ToString(), chapter_no.ToString());
            FontImageSource fi = bmSurah.Source as FontImageSource;
            fi.Color = Colors.Green;
        }
    }
    /// <summary>
    /// open a book mark list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void openBM_Clicked(System.Object sender, System.EventArgs e)
    {
        ret.option = string.Empty;
        SurahBM bm = new SurahBM(dB);
        #if MACCATALYST
            await Navigation.PushAsync(bm);
        #else
            await Navigation.PushModalAsync(bm);
        #endif
        
        ret = await bm.PopupDismissedTask;
    }
    /// <summary>
    /// show English translation or toggle it off
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void showTranslation_Clicked(object sender, EventArgs e)
    {
        var popup = new TranslationOption("SURAH");

        // The type parameter must match the type returned from the popup.
        IPopupResult<Int16> popupResult = await this.ShowPopupAsync<Int16>(popup, new PopupOptions
                {
                    PageOverlayColor = Colors.DarkSlateGray.WithAlpha(0.6f)
                }, CancellationToken.None);
        if (popupResult == null || popupResult.WasDismissedByTappingOutsideOfPopup)
        {
            return;
        }
        switch (popupResult.Result)
        {
            case 1:
                // English translation was tapped
                showTrans = true;
                selectedLanguage = 1;
                break;
            case 2:
                // Urdu translation was tapped
                showTrans = true;
                selectedLanguage = 2;
                break;
            default:
                showTrans = false;
                selectedLanguage = 3;
                break;
        }
        if (showTrans)
        {
            FontImageSource fi = showTranslation.Source as FontImageSource;
            fi.Color = Colors.Green;
        }
        else
        {
            FontImageSource fi = showTranslation.Source as FontImageSource;
            fi.Color = Colors.Black;
        }
        progress.ShowProgress();
        await Task.Delay(5);
        UpdateGroupedTranslations();
        //Dispatcher.Dispatch(() => lstView.ScrollTo(firstItem));
        progress.HideProgress();
    }
    /// <summary>
    /// font change
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
            progress.ShowProgress();
            await Task.Yield();
            var font = Preferences.Default.Get<string>("Font", "NotoArabic");
            foreach (var reciteSurah in groupedVerse.SelectMany(group => group))
            {
                reciteSurah.font = font;
                reciteSurah.NotifyBindingsChanged(nameof(ReciteSurah.font));
            }
            //Dispatcher.Dispatch(() => lstView.ScrollTo(firstItem));
            progress.HideProgress();
        }
    }
    /// <summary>
    /// on scroll
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void lstView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        firstItem = e.FirstVisibleItemIndex;
    }
    /// <summary>
    /// back button pressed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnBack_Clicked(object sender, EventArgs e)
    {
        if (chapter_no > 1)
        {
            chapter_no -= 1;
            await Shell.Current.GoToAsync($"Surah?chapter={chapter_no}", false);
        }
    }
    /// <summary>
    /// forward button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnForward_Clicked(object sender, EventArgs e)
    {
        if (chapter_no < 114)
        {
            chapter_no += 1;
            await Shell.Current.GoToAsync($"Surah?chapter={chapter_no}", false);
        }
    }
    /// <summary>
    /// Show lines
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnLine_Clicked(object sender, EventArgs e)
    {
        //lstView.ItemsSource = null;
        btnLine.IsEnabled = false;
        await Task.Delay(5);
        progress.ShowProgress();
        showSeparator = !showSeparator;
        if (showSeparator)
        {
            FontImageSource fi = btnLine.Source as FontImageSource;
            fi.Color = Colors.Green;
        }
        else
        {
            FontImageSource fi = btnLine.Source as FontImageSource;
            fi.Color = Colors.Black;
        }
        await Task.Yield();
        foreach (var reciteSurah in groupedVerse.SelectMany(group => group))
        {
            for (int i = 0; i < reciteSurah.showLine.Length; i++)
            {
               if(reciteSurah.verse_arabic_lines[i] != null && 
               reciteSurah.verse_arabic_lines[i].Length > 0) reciteSurah.showLine[i] = showSeparator ? true : false;
            }
            reciteSurah.NotifyBindingsChanged(nameof(ReciteSurah.showLine));
        }
        btnLine.IsEnabled = true;
        progress.HideProgress();
    }
    /// <summary>
    /// size and color of the font
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnOption_Clicked(object sender, EventArgs e)
    {
        MiscOption opt = new();
        #if MACCATALYST
            await Navigation.PushAsync(opt);
        #else
            await Navigation.PushModalAsync(opt);
        #endif
        await opt.PopupDismissedTask;
        if (opt.ReturnValue.optionSelection == 0)
        {
            await Task.Yield();
            foreach (var reciteSurah in groupedVerse.SelectMany(group => group))
            {
                reciteSurah.fontColor = Color.Parse(opt.ReturnValue.optionColor);
                reciteSurah.fontSize = opt.ReturnValue.fontSize;
                Preferences.Default.Set<string>("FontColor", opt.ReturnValue.optionColor);
                Preferences.Default.Set<int>("FontSize", opt.ReturnValue.fontSize);

                reciteSurah.NotifyBindingsChanged(nameof(ReciteSurah.fontColor));
                reciteSurah.NotifyBindingsChanged(nameof(ReciteSurah.fontSize));
            }
        }
    }
}
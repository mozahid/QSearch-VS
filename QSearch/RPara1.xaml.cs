using System.Text.RegularExpressions;
using System.Web;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using SQLitePCL;
namespace QSearch;

[QueryProperty(nameof(para), "para")]
public partial class RPara1 : ContentPage, IQueryAttributable
{
    QuranDB dB;
    int para_no = 0;
    List<QuranicVerse> surahs = new List<QuranicVerse>();
    List<GroupedVerse> groupedVerse = new List<GroupedVerse>();
    Surah surah_info = new Surah();
    Para para_info = new Para();
    public bool showTrans = false;
    int firstItem = 0;
    Progress progress;
    public int para {get; set;}
    public int selectedLanguage = 1;
    public bool showSeparator = false;
    public int current_chapter_number = 0;

    public RPara1(QuranDB qdb)
    {
        InitializeComponent();
        dB = qdb;
        progress = new Progress(progInd);
    }
    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        para = Convert.ToInt32(HttpUtility.UrlDecode(query["para"].ToString()));
        para_no = para;
        switch (para_no)
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

            para_info = await dB.GetParaInfo(para_no);
            current_chapter_number = para_info.surah_list.First().chapter_number;
            surahs = await dB.GetSurahByParaNumber(para_no, current_chapter_number);
            btnNextSurah.Text= para_info.surah_list.Where(_s => _s.chapter_number == (current_chapter_number + 1)).First().chapter_name_arabic;
            btnBackSurah.IsEnabled = false;
            this.Title = "Recite Para - " + surah_info.para_name;
            await RefreshSurah();
        }   
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
        lstView.IsVisible = true;
        lstView.HeightRequest = screenHeight - 300;
    }
    /// <summary>
    /// line by line
    /// </summary>
    /// <returns></returns>
  private async Task LinesByLines()
    {
        progress.ShowProgress();
        await Task.Delay(10);
        int groupedVerseCount = 0;

        ReciteSurah _reciteSurah = new()
        {
            showSeparator = "true",
            font = Preferences.Default.Get<string>("Font", "NotoArabic"),
            isTranslationVisible = showTrans,
            isSeparatorVisible = showSeparator,
            verse_arabic_lines = new string[10],
            verse_translation_lines = new string[10],
            translation_ref_lines = new string[10],
            ruku_lines = new bool[10],
            sujood_lines = new bool[10],
            verse_number = new int[10]
        };
        for (int i = 0; i < surahs.Count; i++)
        {
            if ((i % 10 == 0) && (i > 0))
            {
                groupedVerse.Add(new GroupedVerse(surahs[i].chapter_name_english, new List<ReciteSurah> { _reciteSurah }));
                _reciteSurah = new()
                        {
                            showSeparator = "true",
                            font = Preferences.Default.Get<string>("Font", "NotoArabic"),
                            isTranslationVisible = showTrans,
                            isSeparatorVisible = showSeparator,
                            verse_arabic_lines = new string[10],
                            verse_translation_lines = new string[10],
                            translation_ref_lines = new string[10],
                            ruku_lines = new bool[10],
                            sujood_lines = new bool[10],
                            verse_number = new int[10]
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
        //await Shell.Current.Navigation.PopToRootAsync(true);
        await Shell.Current.GoToAsync("Search", false);
    }
    /// <summary>
    /// show translation
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
    /// capture scroll index
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void lstView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        firstItem = e.FirstVisibleItemIndex;
    }
    /// <summary>
    /// back para
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnBack_Clicked(object sender, EventArgs e)
    {
        if(para_no > 1)
        {
            para_no -= 1;
            await Shell.Current.GoToAsync($"Para?para={para_no}", false);
        }
    }
    /// <summary>
    /// forward para
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnForward_Clicked(object sender, EventArgs e)
    {
        if (para_no < 30)
        {
            para_no += 1;
            await Shell.Current.GoToAsync($"Para?para={para_no}", false);
        }
    }
    /// <summary>
    ///  to show line
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
            reciteSurah.isSeparatorVisible = showSeparator;
        }
        btnLine.IsEnabled = true;
        progress.HideProgress();
    }
    /// <summary>
    /// back surah 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnBackSurah_Clicked(object sender, EventArgs e)
    {
        if (current_chapter_number > para_info.surah_list.Min(_s => _s.chapter_number))
        {
         
         btnNextSurah.Text = para_info.surah_list.Find(_s => _s.chapter_number == current_chapter_number).chapter_name_arabic;
         current_chapter_number--;
         if (current_chapter_number == para_info.surah_list.Min(_s => _s.chapter_number))
            {
                btnBackSurah.IsEnabled = false;
                btnBackSurah.Text = "";
            }
            else
            {
                btnBackSurah.Text = para_info.surah_list.Find(_s => _s.chapter_number == (current_chapter_number - 1)).chapter_name_arabic;  
            }
         surahs = await dB.GetSurahByParaNumber(para_no, current_chapter_number);
         btnNextSurah.IsEnabled = true;
         await RefreshSurah();
        }
        else btnBackSurah.IsEnabled =false;
    }
    /// <summary>
    /// next surah in the para
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnNextSurah_Clicked(object sender, EventArgs e)
    {
        if (current_chapter_number < para_info.surah_list.Max(_s => _s.chapter_number))
        {
         btnBackSurah.Text = para_info.surah_list.Find(_s => _s.chapter_number == current_chapter_number).chapter_name_arabic;   
         btnBackSurah.IsEnabled = true;
         current_chapter_number++;
         if (current_chapter_number == para_info.surah_list.Max(_s => _s.chapter_number))
            {
                btnNextSurah.IsEnabled = false;
                btnNextSurah.Text = "";
            }
            else
            {
                btnNextSurah.Text = para_info.surah_list.Find(_s => _s.chapter_number == (current_chapter_number + 1)).chapter_name_arabic;
            }
            surahs = await dB.GetSurahByParaNumber(para_no, current_chapter_number);
            await RefreshSurah();
        }
        else btnNextSurah.IsEnabled = false;
    }
    /// <summary>
    /// refresh and loads next or back surah
    /// </summary>
    /// <returns></returns>
    private async Task RefreshSurah()
    {
        surah_info = await dB.GetSurahInfo(current_chapter_number);
        surah_info.para_name = surahs[0].para_name;
        surah_info.para_number = surahs[0].para_number;
        surah_info.para_lines = para_info.total_lines;
        this.Title = "Recite Para - " + surah_info.para_name;
        grdHeader.BindingContext = surah_info;
        groupedVerse.Clear();
        lstView.ItemsSource = null;
        await LinesByLines();
    }
}

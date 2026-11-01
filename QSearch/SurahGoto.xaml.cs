using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using QSearch.Models;
namespace QSearch;

[QueryProperty(nameof(chapter), "chapter")]
[QueryProperty(nameof(chapterFrom), "chapterFrom")]
[QueryProperty(nameof(chapterTo), "chapterTo")]
public partial class SurahGoto : ContentPage, IQueryAttributable
{
	QuranDB dB;
    int chapter_no = 0;
    public List<GroupedSurah> groupedSurah { get; private set; } = new List<GroupedSurah>();
    List<QuranicVerse> surahs = new List<QuranicVerse>();
    public bool showTrans = false;
    int firstItem = 0;
    Progress progress;
	OptionsData ret = new OptionsData();
    public int chapter {get; set;}
	public int chapterFrom{get;set;}
	public int chapterTo{get;set;}
    public int selectedLanguage = 1;
    public bool showSeparator = false;
	public SurahGoto(QuranDB qdb)
	{
		InitializeComponent();
		dB = qdb;
        progress = new Progress(progInd);
	}
     public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        chapter = Convert.ToInt32(HttpUtility.UrlDecode(query["chapter"].ToString()));
		chapterFrom = Convert.ToInt32(HttpUtility.UrlDecode(query["chapterFrom"].ToString()));
		chapterTo = Convert.ToInt32(HttpUtility.UrlDecode(query["chapterTo"].ToString()));
        chapter_no = chapter;
        if (groupedSurah.Count == 0) 
        {
             MainThread.BeginInvokeOnMainThread(async () => await LoadDataAsync());
        }
    }
    private async Task LoadDataAsync()
    {
        try
        {
            surahs = await dB.GetSurahByNumberAndVerses(chapter_no, chapterFrom, chapterTo);
            await LinesByLines();
        }
        catch (OperationCanceledException ex)
        {
            // Safely log or handle if an explicit cancellation token was tripped
            var e = ex;
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
        lstView.IsVisible = true;
        lstView.HeightRequest = screenHeight - 200;
    }
    /// <summary>
    /// Lines by Lines
    /// </summary>
    private async Task LinesByLines()
    {
        progress.ShowProgress();
        await Task.Delay(10);

        ReciteSurah surah = CreateReciteSurah();
        
        int _lines = 0;
        int _pg = 1;

        foreach (QuranicVerse item in surahs)
        {
            surah.para_number = item.para_number;
            surah.para_name = item.para_name;
            surah.chapter_number = item.chapter_number;
            surah.chapter_name_arabic = item.chapter_name_arabic;
            surah.class_arabic = item.class_arabic;
            surah.total_verses = item.total_verses;
            surah.font = Preferences.Default.Get<string>("Font", "NotoArabic");
            surah.verse_number[_lines] = item.verse_number;
            surah.verse_arabic_lines[_lines] = item.verse_arabic.Replace("[", string.Empty).Replace("]", string.Empty).Replace(Regex.Match(item.verse_arabic, @"\d+").Value.ToString(), string.Empty).Replace("۩", string.Empty);
            surah.ruku_lines[_lines] = item.ruku;
            surah.sujood_lines[_lines] = item.sujood;
            surah.isSeparatorVisible = showSeparator;
            surah.isTranslationVisible = showTrans;
            if (showTrans) 
            {
                switch(selectedLanguage)
                {
                    case 1:
                        surah.verse_translation_lines[_lines] = item.verse_english;
                        surah.translation_ref_lines[_lines] = item.english_ref;
                        surah.font_translation = "Tahoma";
                        break;
                    case 2:
                        surah.verse_translation_lines[_lines] = item.verse_urdu;
                        surah.translation_ref_lines[_lines] = item.urdu_ref;
                        surah.font_translation = "Urdu";
                        break;
                }
                surah.showSeparator = "true";
            }
            else
            {
                surah.verse_translation_lines[_lines] = string.Empty;
                surah.translation_ref_lines[_lines] = string.Empty;
                surah.showSeparator = showSeparator ? "true" : "false";
            }
            surah.verse_arabic_lines_number[_lines] = Regex.Match(item.verse_arabic, @"\d+").Value;
            surah.verse_arabic_line_end[_lines] = item.verse_arabic.Contains("۩") ? "۩" : string.Empty;
            surah.showLine[_lines] = "true";
            _lines++;
            if (_lines == 25)
            {
                // now break it up in 25 lines //
                List<ReciteSurah> surahContent = new List<ReciteSurah>();
                surahContent.Add(surah);
                groupedSurah.Add(new GroupedSurah(surah.chapter_name_arabic, _pg, surahContent));
                _lines = 0;
                _pg++;
                surah = CreateReciteSurah();
            }
        }
        // any left over lines //
        if (_lines > 0)
        {
            List<ReciteSurah> surahContent = new List<ReciteSurah>();
            surahContent.Add(surah);
            groupedSurah.Add(new GroupedSurah(surah.chapter_name_arabic, _pg, surahContent));
        }
        if (surahs.Count > 0)
            this.Title = surahs[^1].chapter_name_arabic + " " + chapterTo + " - " + chapterFrom;
        //List<GroupedSurah> grp = new List<GroupedSurah>();
        //grp.Add(groupedSurah[0]);
        //lstView.ItemsSource = grp;
        lstView.ItemsSource = groupedSurah;
        UpdateGroupedTranslations();
        progress.HideProgress();
        }

    private ReciteSurah CreateReciteSurah()
    {
        var surah = new ReciteSurah
        {
            verse_number = new int[25],
            verse_arabic_lines = new string[25],
            verse_translation_lines = new string[25],
            verse_arabic_lines_number = new string[25],
            verse_arabic_line_end = new string[25],
            translation_ref_lines = new string[25],
            ruku_lines = new bool[25],
            sujood_lines = new bool[25],
            translationLineVisible = new bool[25],
            separatorLineVisible = new bool[25],
            font = Preferences.Default.Get<string>("Font", "NotoArabic"),
            font_translation = selectedLanguage == 2 ? "Urdu" : "Tahoma",
            isTranslationVisible = showTrans && selectedLanguage is 1 or 2,
            isSeparatorVisible = showSeparator
        };

        Array.Fill(surah.showLine, "false");
        return surah;
    }

    private void UpdateGroupedTranslations()
    {
        int verseIndex = 0;
        foreach (var group in groupedSurah)
        {
            foreach (var reciteSurah in group)
            {
                for (int lineIndex = 0; lineIndex < reciteSurah.showLine.Length; lineIndex++)
                {
                    bool lineIsVisible = reciteSurah.showLine[lineIndex] == "true";
                    reciteSurah.translationLineVisible[lineIndex] =
                        lineIsVisible && showTrans && selectedLanguage is 1 or 2;
                    reciteSurah.separatorLineVisible[lineIndex] =
                        lineIsVisible && showSeparator;
                    if (!lineIsVisible)
                        continue;

                    var verse = surahs[verseIndex++];
                    reciteSurah.verse_translation_lines[lineIndex] = !showTrans
                        ? string.Empty
                        : selectedLanguage switch
                        {
                            1 => verse.verse_english,
                            2 => verse.verse_urdu,
                            _ => string.Empty
                        };
                    reciteSurah.translation_ref_lines[lineIndex] = !showTrans
                        ? string.Empty
                        : selectedLanguage switch
                        {
                            1 => verse.english_ref,
                            2 => verse.urdu_ref,
                            _ => string.Empty
                        };
                }

                reciteSurah.font_translation = selectedLanguage == 2 ? "Urdu" : "Tahoma";
                reciteSurah.isTranslationVisible = showTrans && selectedLanguage is 1 or 2;
                reciteSurah.isSeparatorVisible = showSeparator;
                reciteSurah.NotifyBindingsChanged(nameof(ReciteSurah.translationLineVisible));
                reciteSurah.NotifyBindingsChanged(nameof(ReciteSurah.separatorLineVisible));
                reciteSurah.NotifyBindingsChanged(nameof(ReciteSurah.verse_translation_lines));
                reciteSurah.NotifyBindingsChanged(nameof(ReciteSurah.translation_ref_lines));
                reciteSurah.NotifyBindingsChanged(nameof(ReciteSurah.font_translation));
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
        await Shell.Current.GoToAsync("Search", false);
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
        var popup = new TranslationOption("GOTO");

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
        await Task.Delay(5);
        progress.ShowProgress();
        UpdateGroupedTranslations();
        Dispatcher.Dispatch(() => lstView.ScrollTo(firstItem));
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
            foreach (var r in groupedSurah.SelectMany(group => group))
            {
                r.font = font;
                r.NotifyBindingsChanged(nameof(ReciteSurah.font));
            }
            Dispatcher.Dispatch(() => lstView.ScrollTo(firstItem));
            progress.HideProgress();
            await Task.Yield();
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
    /// Turn on / off lines
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnLine_Clicked(object sender, EventArgs e)
    {
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
        UpdateGroupedTranslations();
        await Task.Yield();
        btnLine.IsEnabled = true;
        progress.HideProgress();
    }
}
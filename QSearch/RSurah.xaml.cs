using System.Text.RegularExpressions;
using System.Web;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using QSearch.Models;
namespace QSearch;

[QueryProperty(nameof(chapter), "chapter")]
public partial class RSurah : ContentPage, IQueryAttributable
{
    QuranDB dB;
    int chapter_no = 0;
    //Options opt;
    OptionsData ret = new OptionsData();
    public List<GroupedSurah> groupedSurah { get; private set; } = new List<GroupedSurah>();
    List<ReciteSurah> surahs = new List<ReciteSurah>();
    Boolean showTrans = false;
    int firstItem = 0;
    Progress progress;
    public int chapter {get; set;}
    public int selectedLanguage = 1;
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
        if (groupedSurah.Count == 0) 
        {
            surahs = await dB.GetSurahByNumber(chapter_no);
            await LinesByLines();
        }
    }
    //used by GoToAsync //
    public RSurah(QuranDB qdb)
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
        lstView.HeightRequest = screenHeight - 200;
    }
    /// <summary>
    /// Lines by Lines
    /// </summary>
    private async Task LinesByLines()
    {
        progress.ShowProgress();
        await Task.Delay(75);
        
        ReciteSurah surah = new ReciteSurah();
        for (int i = 0; i < 25; i++) surah.showLine[i] = "false";
        int _lines = 0;
        int _pg = 1;

        foreach (ReciteSurah item in surahs)
        {
            surah.para_number = item.para_number;
            surah.para_name = item.para_name;
            surah.chapter_number = item.chapter_number;
            surah.chapter_name_arabic = item.chapter_name_arabic;
            surah.class_arabic = item.class_arabic;
            surah.total_verses = item.total_verses;
            surah.font = Preferences.Default.Get<string>("Font", "NotoArabic");
            surah.verse_arabic_lines[_lines] = item.verse_arabic.Replace("[", string.Empty).Replace("]", string.Empty).Replace(Regex.Match(item.verse_arabic, @"\d+").Value.ToString(), string.Empty).Replace("۩", string.Empty);
            if (showTrans) 
            {
                switch(selectedLanguage)
                {
                    case 1:
                        surah.verse_translation_lines[_lines] = "\n" + item.verse_english;
                        surah.translation_ref_lines[_lines] = "\n" + item.english_ref;
                        surah.font_translation = "Tahoma";
                        break;
                    case 2:
                        surah.verse_translation_lines[_lines] = "\n" + item.verse_urdu;
                        surah.translation_ref_lines[_lines] = "\n" + item.urdu_ref;
                        surah.font_translation = "Urdu";
                        break;
                }
            }
            else
            {
                surah.verse_translation_lines[_lines] = string.Empty;
                surah.translation_ref_lines[_lines] = string.Empty;
            }
            surah.verse_arabic_lines_number[_lines] = "[" + Regex.Match(item.verse_arabic, @"\d+").Value + "]";
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
                surah = new ReciteSurah();
                for (int i = 0; i < 25; i++) surah.showLine[i] = "false";
            }
        }
        // any left over lines //
        if (_lines > 0)
        {
            List<ReciteSurah> surahContent = new List<ReciteSurah>();
            surahContent.Add(surah);
            groupedSurah.Add(new GroupedSurah(surah.chapter_name_arabic, _pg, surahContent));
        }
        this.Title = "Recite Surah - " + surah.chapter_name_arabic;
        lstView.ItemsSource = groupedSurah;
        progress.HideProgress();
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
            //bmSurah.ImageSource = "tick_mark1.png";
            //bmSurah.ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Right, 5);
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
        groupedSurah.Clear();
        lstView.ItemsSource = null;
        await LinesByLines();
        Dispatcher.Dispatch(() => lstView.ScrollTo(firstItem));
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
            lstView.ItemsSource = null;
            progress.ShowProgress();
            foreach (var s in groupedSurah)
            {
                List<ReciteSurah> reciteSurahs = s;
                foreach (var r in reciteSurahs)
                    r.font = Preferences.Default.Get<string>("Font", "NotoArabic");
            }
            lstView.ItemsSource = groupedSurah;
            await Task.Yield();
            Dispatcher.Dispatch(() => lstView.ScrollTo(firstItem));
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
}
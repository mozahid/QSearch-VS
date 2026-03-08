using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using CommunityToolkit.Maui.Converters;
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
    Boolean showTrans = false;
    int firstItem = 0;
    Progress progress;
    public int chapter {get; set;}

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
        if (groupedSurah.Count == 0) await LinesByLines();
    }
    //used by GoToAsync //
    public RSurah(QuranDB qdb)
	{
		InitializeComponent();
        dB = qdb;
        progress = new Progress(progInd);
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
        await Task.Yield();
        List<ReciteSurah> surahs = new List<ReciteSurah>();
        ReciteSurah surah = new ReciteSurah();
        for (int i = 0; i < 25; i++) surah.showLine[i] = "false";
        surahs = await dB.GetSurahByNumber(chapter_no);
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
            if (showTrans) surah.verse_english_lines[_lines] = "\n" + item.verse_english;
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
        if (showTrans)
        {
            showTrans = false;
            FontImageSource fi = showTranslation.Source as FontImageSource;
            fi.Color = Colors.Black;
        }
        else
        {
            showTrans = true;
            FontImageSource fi = showTranslation.Source as FontImageSource;
            fi.Color = Colors.Green;
        }
        groupedSurah.Clear();
        lstView.ItemsSource = null;
        await LinesByLines();
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
            lstView.ScrollTo(firstItem);
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
    // HTML lines //
    // private async Task SimpleHTML()
    // {
    //     List<ReciteSurah> surahs = new List<ReciteSurah>();
    //     progInd.IsRunning = true;
    //     surahs = await dB.GetSurahByNumber(chapter_no);
    //     string _s = String.Empty;
    //     string surah_name = string.Empty;
    //     int _lines = 0;
    //     int _pg = 1;

    //     foreach (ReciteSurah item in surahs)
    //     {
    //         surah_name = item.chapter_name_arabic;
    //         _s += "<span style=\"font-size: 64px;\">" + item.verse_arabic.TrimEnd().Replace("[", "<span style=\"color: green;\">[</span>").Replace("]", "<span style=\"color: green;\">]</span>").Replace("۩", "<span style='color:red; font-weight:bold'>^</span>") + "</span>";
    //         if (showTrans)
    //         {
    //         _s += "<div><span style=\"color: lightgray; font-size: 32px;font-family: Tahoma;\">" + item.verse_english + "</span></div>";
    //         }
    //         _lines++;
    //         if (_lines == 25)
    //         {
    //             /// now break it up
    //             ReciteSurah surah = new ReciteSurah();
    //             surah.para_number = surahs[0].para_number;
    //             surah.para_name = surahs[0].para_name;
    //             surah.chapter_name_arabic = surahs[0].chapter_name_arabic;
    //             surah.class_arabic = surahs[0].class_arabic;
    //             surah.total_verses = surahs[0].total_verses;
    //             surah.verse_arabic = "<p style=\"text-align: right;\">" + _s + "</p>";
    //             surah.verse_english = item.verse_english;
    //             surah.font = Preferences.Default.Get<string>("Font", "NotoArabic");
    //             List<ReciteSurah> surahContent = new List<ReciteSurah>();
    //             surahContent.Add(surah);
    //             groupedSurah.Add(new GroupedSurah(surahs[0].chapter_name_arabic, _pg, surahContent));
    //             _s = string.Empty;
    //             _lines = 0;
    //             _pg++;
    //         }
    //         else
    //         {
    //             _s += "<br/>";
 
    //         }
    //     }
    //     /// any left over
    //     if (_s.Length > 0)
    //     {
    //         ReciteSurah surah = new ReciteSurah();

    //         surah.para_number = surahs[0].para_number;
    //         surah.para_name = surahs[0].para_name;
    //         surah.chapter_name_arabic = surahs[0].chapter_name_arabic;
    //         surah.class_arabic = surahs[0].class_arabic;
    //         surah.total_verses = surahs[0].total_verses;
    //         surah.verse_arabic = "<p style=\"text-align: right\">" + _s + "</p>";
    //         surah.font = Preferences.Default.Get<string>("Font", "NotoArabic");
    //         List<ReciteSurah> surahContent = new List<ReciteSurah>();
    //         surahContent.Add(surah);
    //         groupedSurah.Add(new GroupedSurah(surahs[0].chapter_name_arabic, _pg, surahContent));
    //     }
    //     this.Title = "Recite Surah - " + surah_name;
    //     lstViewAndroid.ItemsSource = groupedSurah;
    // }
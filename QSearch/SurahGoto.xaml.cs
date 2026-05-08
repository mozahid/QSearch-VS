using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
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
    Boolean showTrans = false;
    int firstItem = 0;
    Progress progress;
	OptionsData ret = new OptionsData();
    public int chapter {get; set;}
	public int chapterFrom{get;set;}
	public int chapterTo{get;set;}
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
        if (groupedSurah.Count == 0) await LinesByLines();
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
        surahs = await dB.GetSurahByNumberAndVerses(chapter_no, chapterFrom, chapterTo);
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
                surah.verse_translation_lines[_lines] = "\n" + item.verse_english;
                surah.translation_ref_lines[_lines] = "\n" + item.english_ref;
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
        this.Title = surah.chapter_name_arabic + " " + chapterTo.ToString() + " - " + chapterFrom.ToString();
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
            await Task.Yield();
            foreach (var s in groupedSurah)
            {
                List<ReciteSurah> reciteSurahs = s;
                foreach (var r in reciteSurahs)
                    r.font = Preferences.Default.Get<string>("Font", "NotoArabic");
            }
            lstView.ItemsSource = groupedSurah;
            lstView.ScrollTo(firstItem);
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
}
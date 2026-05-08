using System.Text.RegularExpressions;
using System.Web;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
namespace QSearch;

[QueryProperty(nameof(para), "para")]
public partial class RPara : ContentPage, IQueryAttributable
{
    QuranDB dB;
    int para_no = 0;
    //Options opt;
    // OptionsData ret = new OptionsData();
    List<ReciteSurah> surahContent = new List<ReciteSurah>();
    List<GroupedSurah> groupedSurah = new List<GroupedSurah>();
    Boolean showTrans = false;
    int firstItem = 0;
    Progress progress;
    public int para {get; set;}
    public RPara(QuranDB qdb)
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
        if (groupedSurah.Count == 0) await LineByLine();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        var screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
        lstView.IsVisible = true;
        lstView.HeightRequest = screenHeight - 200;
    }
    /// <summary>
    /// line by line
    /// </summary>
    /// <returns></returns>
    private async Task LineByLine()
    {
        progress.ShowProgress();
        await Task.Yield();
        List<ReciteSurah> surahs = new List<ReciteSurah>();
        List<ReciteSurah> surahContent = new List<ReciteSurah>();
        ReciteSurah surah = new ReciteSurah();
        for (int i = 0; i < 25; i++) surah.showLine[i] = "false";
        int _no = 0;
        string para_name = string.Empty;

        surahs = await dB.GetParaByNumber(para_no);
        int _lines = 0;
        int _pg = 1;
        var _chap = surahs.GroupBy(s => s.chapter_number).Select(group => new {chapter = group.Key, total_verses = group.Count()}).ToList();
        int total_lines = _chap.Sum(v => v.total_verses);
        foreach (ReciteSurah item in surahs)
        {
            para_name = item.para_name;
            if (_no == 0)
            {
                _no = item.chapter_number;
            }
            if (_no != item.chapter_number)
            {
                if (_lines > 0)
                {
                    surahContent = new List<ReciteSurah>();
                    surahContent.Add(surah);
                    groupedSurah.Add(new GroupedSurah(surah.chapter_name_arabic, _pg, surahContent));
                    _pg++;
                }
                _lines = 0;
                surah = new ReciteSurah();
                for (int i = 0; i < 25; i++) surah.showLine[i] = "false";
                _no = item.chapter_number;
            }
            surah.para_number = item.para_number;
            surah.para_name = item.para_name;
            surah.chapter_name_arabic = item.chapter_name_arabic;
            surah.class_arabic = item.class_arabic;
            surah.total_verses = item.total_verses;
            surah.font = Preferences.Default.Get<string>("Font", "NotoArabic");
            surah.verse_arabic_lines[_lines] = item.verse_arabic.Replace("[", string.Empty).Replace("]", string.Empty).Replace(Regex.Match(item.verse_arabic, @"\d+").Value.ToString(), string.Empty).Replace("۩", string.Empty);
            if (showTrans) {
                surah.verse_translation_lines[_lines] = "\n" + item.verse_english;
                surah.translation_ref_lines[_lines] = "\n" + item.english_ref;
            }
            surah.verse_arabic_lines_number[_lines] = "[" + Regex.Match(item.verse_arabic, @"\d+").Value + "]";
            surah.verse_arabic_line_end[_lines] = item.verse_arabic.Contains("۩") ? "۩" : string.Empty;
            surah.total_verses_para = total_lines;
            surah.showLine[_lines] = "true";
            _lines++;
            // break up in 25 lines //
            if (_lines == 25)
            {
                surahContent = new List<ReciteSurah>();
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
            surahContent = new List<ReciteSurah>();
            surahContent.Add(surah);
            groupedSurah.Add(new GroupedSurah(surah.chapter_name_arabic, _pg, surahContent));
        }
        this.Title = "Recite Para - " + para_name;
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
        var popup = new TranslationOption();

        // The type parameter must match the type returned from the popup.
        IPopupResult<Int16> popupResult = await this.ShowPopupAsync<Int16>(popup, new PopupOptions
                {
                    PageOverlayColor = Colors.DarkSlateGray.WithAlpha(0.6f)
                }, CancellationToken.None);

        if (popupResult.WasDismissedByTappingOutsideOfPopup)
        {
            return;
        }
        switch (popupResult.Result)
        {
            case 1:
                // English translation was tapped
                break;
            case 2:
                // Urdu translation was tapped
                break;
        }
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
        await LineByLine();
    }
    /// <summary>
    /// font selected
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
}

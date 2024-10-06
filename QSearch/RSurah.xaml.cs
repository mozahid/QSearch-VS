using System.Text;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using QSearch.Models;
namespace QSearch;

public partial class RSurah : ContentPage
{
    QuranDB dB;
    int chapter_no = 0;
    Options opt;
    OptionsData ret = new OptionsData();
    public List<GroupedSurah> groupedSurah { get; private set; } = new List<GroupedSurah>();

    public RSurah(QuranDB qdb, int chapter_number)
	{
		InitializeComponent();
        dB = qdb;
        opt = new Options(dB);
        chapter_no = chapter_number;
        ret.option = string.Empty;
        Loaded += RSurah_Loaded;
    }
    /// <summary>
    /// when the form is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void RSurah_Loaded(object sender, EventArgs e)
    {
        var screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
        List<ReciteSurah> surahs = new List<ReciteSurah>();

        progInd.IsRunning = true;
        surahs = await dB.GetSurahByNumber(chapter_no);
        string _s = String.Empty;
        string surah_name = string.Empty;
        int _lines = 0;
        int _pg = 1;

        foreach (ReciteSurah item in surahs)
        {
            surah_name = item.chapter_name_arabic;
            _s += item.verse_arabic.TrimEnd();
            _s = _s.Replace("[", "<span style=\"color:green;\">[</span>");
            _s = _s.Replace("]", "<span style=\"color:green;\">]</span>");
            _s += "<br/>";
            _s += "<br/>";
            _lines++;
            if (_lines == 25)
            {
                /// now break it up
                ReciteSurah surah = new ReciteSurah();
                surah.para_number = surahs[0].para_number;
                surah.para_name = surahs[0].para_name;
                surah.chapter_name_arabic = surahs[0].chapter_name_arabic;
                surah.class_arabic = surahs[0].class_arabic;
                surah.total_verses = surahs[0].total_verses;
                surah.verse_arabic = "<p style=\"text-align:right;\">" + _s + "</p>";

                List<ReciteSurah> surahContent = new List<ReciteSurah>();
                surahContent.Add(surah);
                groupedSurah.Add(new GroupedSurah(surahs[0].chapter_name_arabic, _pg, surahContent));
                _s = string.Empty;
                _lines = 0;
                _pg++;
            }
        }
        /// any left over
        if (_s.Length > 0)
        {
            ReciteSurah surah = new ReciteSurah();

            surah.para_number = surahs[0].para_number;
            surah.para_name = surahs[0].para_name;
            surah.chapter_name_arabic = surahs[0].chapter_name_arabic;
            surah.class_arabic = surahs[0].class_arabic;
            surah.total_verses = surahs[0].total_verses;
            surah.verse_arabic = "<p style=\"text-align:right\">" + _s + "</p>";
            List<ReciteSurah> surahContent = new List<ReciteSurah>();
            surahContent.Add(surah);
            groupedSurah.Add(new GroupedSurah(surahs[0].chapter_name_arabic, _pg, surahContent));
        }
        this.Title = "Recite Surah - " + surah_name;
        lstView.ItemsSource = groupedSurah;
        lstView.HeightRequest = screenHeight - 180;
    }


    /// <summary>
    /// tool bar options clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        ret.option = string.Empty;
        await Navigation.PushModalAsync(opt);
        ret = await opt.PopupDismissedTask;
    }
    /// <summary>
    /// when the options is returned
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (ret.option != string.Empty)
        {
            var selectedOption = ret.option;
            if (selectedOption == "0")
            {
                Application.Current.MainPage = new NavigationPage(new QSearch(dB));
            }
            else if(selectedOption == "1")
            {
                Application.Current.MainPage = new NavigationPage(new RSurah(dB, ret.optionSelection));
            }
            else if (selectedOption == "2")
            {
                Application.Current.MainPage = new NavigationPage(new RPara(dB, ret.optionSelection));
            }
            else if (selectedOption == "3")
            {
                Application.Current.MainPage = new NavigationPage(new QStats(dB));
            }
            else if (selectedOption == "4")
            {
                Application.Current.MainPage = new NavigationPage(new About(dB));
            }
        }
    }

    /// <summary>
    /// when the page is displayed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void lstView_DescendantAdded(System.Object sender, Microsoft.Maui.Controls.ElementEventArgs e)
    {
        progInd.IsRunning = false;
    }
    void lstView_Scrolled(System.Object sender, Microsoft.Maui.Controls.ItemsViewScrolledEventArgs e)
    {
        progInd.IsRunning = false;
    }
}

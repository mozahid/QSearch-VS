using System.Text;
using Microsoft.Maui.Controls;
using QSearch.Models;
namespace QSearch;

public partial class RPara : ContentPage
{
    QuranDB dB;
    int para_no = 0;
    Options opt;
    OptionsData ret = new OptionsData();
    List<ReciteSurah> surahContent = new List<ReciteSurah>();
    List<GroupedSurah> groupedSurah = new List<GroupedSurah>();

    public RPara(QuranDB qdb, int para_number)
    {
        InitializeComponent();
        dB = qdb;
        opt = new Options(dB);
        para_no = para_number;
        Loaded += RPara_Loaded;
    }
    /// <summary>
    /// when the form is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void RPara_Loaded(object sender, EventArgs e)
    {
        var screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
        List<ReciteSurah> surahs = new List<ReciteSurah>();
        ReciteSurah surah;
        int _no = 0;
        string para_name = string.Empty;

        progInd.IsRunning = true;
        surahs = await dB.GetParaByNumber(para_no);
        string _s = String.Empty;
        int _lines = 0;
        int _pg = 1;
        foreach (ReciteSurah item in surahs)
        {
            para_name = item.para_name;
            if (_no == 0)
            {
                surahContent = new List<ReciteSurah>();
                surah = new ReciteSurah();

                surah.para_number = item.para_number;
                surah.para_name = item.para_name;
                surah.chapter_name_arabic = item.chapter_name_arabic;
                surah.class_arabic = item.class_arabic;
                surah.total_verses = item.total_verses;
                surah.verse_arabic = _s;
                surahContent.Add(surah);
                groupedSurah.Add(new GroupedSurah(item.chapter_name_arabic, _pg, surahContent));
                _no = item.chapter_number;
            }
            if (_no != item.chapter_number)
            {
                surahContent[0].verse_arabic = "<p style=\"text-align:right\">" + _s + "<br/>" + "</p>";
                surahContent = new List<ReciteSurah>();
                surah = new ReciteSurah();
                _s = string.Empty;
                _pg++;

                surah.para_number = item.para_number;
                surah.para_name = item.para_name;
                surah.chapter_name_arabic = item.chapter_name_arabic;
                surah.class_arabic = item.class_arabic;
                surah.total_verses = item.total_verses;
                surah.verse_arabic = string.Empty;
                surahContent.Add(surah);
                groupedSurah.Add(new GroupedSurah(item.chapter_name_arabic, _pg, surahContent));
                _no = item.chapter_number;
                _lines = 0;
            }
            _s += item.verse_arabic.TrimEnd();
            _s = _s.Replace("[", "<span style=\"color:green\">[</span>");
            _s = _s.Replace("]", "<span style=\"color:green\">]</span>");
            _s += "<br/>";
            _s += "<br/>";
            _lines++;
            /// break up
            if (_lines == 25)
            {
                surahContent[0].verse_arabic = "<p style=\"text-align:right\">" + _s + "<br/>" + "</p>";
                surahContent = new List<ReciteSurah>();
                surah = new ReciteSurah();
                _pg++;

                surah.para_number = item.para_number;
                surah.para_name = item.para_name;
                surah.chapter_name_arabic = item.chapter_name_arabic;
                surah.class_arabic = item.class_arabic;
                surah.total_verses = item.total_verses;
                surah.verse_arabic = string.Empty;
                surahContent.Add(surah);
                groupedSurah.Add(new GroupedSurah(item.chapter_name_arabic, _pg, surahContent));
                _no = item.chapter_number;
                _s = string.Empty;
                _lines = 0;
            }
        }
        /// any left over lines
        if (_s.Length > 0)
        {
            surahContent[0].verse_arabic = "<p style=\"text-align:right\">" + _s + "<br/>" + "</p>";
        }

        this.Title = "Recite Para - " + para_name;
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
            else if (selectedOption == "1")
            {
                Application.Current.MainPage = new NavigationPage(new RSurah(dB, ret.optionSelection));
            }
            else if(selectedOption == "2")
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

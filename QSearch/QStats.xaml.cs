using QSearch.Models;
namespace QSearch;

public partial class QStats : ContentPage
{
    QuranDB dB;
    Options opt;
    OptionsData ret = new OptionsData();


    public QStats(QuranDB qdb)
    {
        InitializeComponent();
        dB = qdb;
        opt = new Options(dB);
        Loaded += QStats_Loaded; ;
    }

    /// <summary>
    ///  get stats
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void QStats_Loaded(object sender, EventArgs e)
    {
        lTotalPara.Text = Convert.ToString(await dB.GetTotalPara());
        lTotalSurah.Text = Convert.ToString(await dB.GetTotalSurah());
        lTotalLines.Text = Convert.ToString(await dB.GetTotalLines());
        lTotalSujood.Text = Convert.ToString(await dB.GetTotalSujood());
        lTotalMakki.Text = Convert.ToString(await dB.GetTotalMakki());
        lTotalMadni.Text = Convert.ToString(await dB.GetTotalMadni());
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
            else if (selectedOption == "2")
            {
                Application.Current.MainPage = new NavigationPage(new RPara(dB, ret.optionSelection));
            }
            else if (selectedOption == "4")
            {
                Application.Current.MainPage = new NavigationPage(new About(dB));
            }
        }
    }
}

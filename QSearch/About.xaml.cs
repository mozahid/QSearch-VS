using QSearch.Models;

namespace QSearch;

public partial class About : ContentPage
{
    QuranDB dB;
    Options opt;
    OptionsData ret = new OptionsData();
    
    public About(QuranDB qdb)
    {
        InitializeComponent();
        dB = qdb;
        opt = new Options(dB);
        Loaded += About_Loaded;
    }
    /// <summary>
    ///  to allow the scroll of about text body, the height is adjusted for the grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void About_Loaded(object sender, EventArgs e)
    {
        //double screenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
        double screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
        ver.Text = AppInfo.Current.VersionString;
        if (OperatingSystem.IsOSPlatformVersionAtLeast("iOS", 12) || OperatingSystem.IsAndroidVersionAtLeast(21))
         {
            frame1.IsVisible = false;
            frame2.IsVisible = true;
            RowDefinition r = grid.RowDefinitions[0];
            r.Height = new GridLength(screenHeight - 140);
        }

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
            else if (selectedOption == "3")
            {
                Application.Current.MainPage = new NavigationPage(new QStats(dB));
            }
            
        }
    }
}

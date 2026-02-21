using QSearch.Models;

namespace QSearch;

public partial class About : ContentPage
{
    QuranDB dB;

    public About(QuranDB qdb)
    {
        InitializeComponent();
        dB = qdb;
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
        if (screenHeight <= 400)
        {
            frame2.HeightRequest = screenHeight - 100;
        }
    }
}

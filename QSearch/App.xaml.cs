

namespace QSearch;

public partial class App : Application
{
    /// <summary>
    ///  obsoleted in .NET 9
    /// </summary>
    //public App()
    //{
        //InitializeComponent();

        //MainPage = new AppShell();
        //Task.Run(async () => { await CopyFileToAppDataDirectory("quran.sqlite"); });
    //}
    public App()
    {
        InitializeComponent();
        var MainPage = Application.Current.Windows.FirstOrDefault()?.Page;
        Task.Run(async () => { await CopyFileToAppDataDirectory("quran.sqlite"); });
        Application.Current.UserAppTheme = AppTheme.Light;
        
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
    /// <summary>
    /// on startup
    /// </summary>
    protected override async void OnStart()
    {
        base.OnStart();
        if (DeviceInfo.Current.Platform == DevicePlatform.Android)
        {
            if (!OperatingSystem.IsAndroidVersionAtLeast(21))
            {
                await Application.Current.Windows[0].Page.DisplayAlertAsync("Q-Search", "Android 5 or later devices are supported only!", "Ok");
                Application.Current.Quit();
            }
        }
        else if (DeviceInfo.Current.Platform == DevicePlatform.iOS)
        {
            if (!OperatingSystem.IsIOSVersionAtLeast(15))
            {
                await Application.Current.Windows[0].Page.DisplayAlertAsync("Q-Search", "iOS 15 or later devices are supported only!", "Ok");
                Application.Current.Quit();
            }
        }
    }
    /// <summary>
    ///  copy sqlite to app data directory
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    public async Task CopyFileToAppDataDirectory(string filename)
    {
        // Open the source file
        using Stream inputStream = await FileSystem.Current.OpenAppPackageFileAsync(filename);

        // Create an output filename
        string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, filename);
        // delete the file first //
        if (File.Exists(targetFile))
        {
            File.Delete(targetFile);
        }
        // Copy the file to the AppDataDirectory
        using FileStream outputStream = File.Create(targetFile);
        await inputStream.CopyToAsync(outputStream);
    }

}


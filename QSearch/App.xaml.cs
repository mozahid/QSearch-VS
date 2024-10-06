namespace QSearch;

public partial class App : Application
{
	public App()
	{
        InitializeComponent();

		MainPage = new AppShell();
    
        Task.Run(async () => { await CopyFileToAppDataDirectory("quran.sqlite"); });
    }
    /// <summary>
    /// on startup
    /// </summary>
    protected override async void OnStart()
    {
        base.OnStart();
        if (DeviceInfo.Current.Platform == DevicePlatform.Android)
        {
            if (!OperatingSystem.IsAndroidVersionAtLeast(33))
            {
                await MainPage.DisplayAlert("Q-Search", "Android 13 or later devices are supported only!", "Ok");
                Application.Current.Quit();
            }
        }
        else if (DeviceInfo.Current.Platform == DevicePlatform.iOS)
        {
            if (!OperatingSystem.IsIOSVersionAtLeast(15))
            {
                await MainPage.DisplayAlert("Q-Search", "iOS 15 or later devices are supported only!", "Ok");
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
        /// delete the file first
        if (File.Exists(targetFile))
        {
            File.Delete(targetFile);
        }
        // Copy the file to the AppDataDirectory
        using FileStream outputStream = File.Create(targetFile);
        await inputStream.CopyToAsync(outputStream);
    }

}


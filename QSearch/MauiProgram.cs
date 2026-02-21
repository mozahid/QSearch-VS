using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
namespace QSearch;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Tahoma.ttf", "Tahoma");
                fonts.AddFont("MaterialIconsOutlined-Regular.otf", "MaterialIconsOutlined-Regular");
                fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons-Regular");
                fonts.AddFont("NotoNaskhArabic-Regular.ttf", "NotoArabic");
                fonts.AddFont("Lateef-Bold.ttf", "LateefR");
                fonts.AddFont("IndoPak.ttf", "IndoPak");
                fonts.AddFont("AlQalam.ttf", "AlQalam");
            })
        .UseSentry(options => {
      // The DSN is the only required setting.
                    options.Dsn = "https://789270b71bcf6ca9f85d6daaf83f02ca@o4510241708113920.ingest.us.sentry.io/4510241709621248";

                    // Use debug mode if you want to see what the SDK is doing.
                    // Debug messages are written to stdout with Console.Writeline,
                    // and are viewable in your IDE's debug console or with 'adb logcat', etc.
                    // This option is not recommended when deploying your application.
                    //options.Debug = true;
                    options.DiagnosticLevel = SentryLevel.Error;
                    options.SendDefaultPii = true;
    // This option is recommended. It enables Sentry's "Release Health" feature.
                    options.AutoSessionTracking = true;
    // Enabling this option is recommended for client applications only. It ensures all threads use the same global scope.
                    options.IsGlobalModeEnabled = false;
    // Example sample rate for your transactions: captures 10% of transactions
                    options.TracesSampleRate = 0.1;
                    // Other Sentry options can be set here.
                });
#if DEBUG
		builder.Logging.AddDebug();
#endif

        //builder.Services.AddTransient<QSearch>();
		builder.Services.AddSingleton<QuranDB>();
		return builder.Build();
	}
}


using Microsoft.Extensions.Logging;

namespace QSearch;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Tahoma.ttf", "Tahoma");
                fonts.AddFont("MaterialIconsOutlined-Regular.otf", "MaterialIconsOutlined-Regular");
                fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons-Regular");
				fonts.AddFont("NotoNaskhArabic-Regular.ttf", "NotoArabic");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddTransient<QSearch>();
		builder.Services.AddSingleton<QuranDB>();
		builder.Services.AddSingleton<RSurah>();
		return builder.Build();
	}
}


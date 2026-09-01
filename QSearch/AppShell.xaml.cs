using System.Diagnostics;
namespace QSearch;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;
        Routing.RegisterRoute("Search", typeof(QSearch));
        Routing.RegisterRoute("Surah", typeof(RSurah));
        Routing.RegisterRoute("Para", typeof(RPara));
        Routing.RegisterRoute("Stats", typeof(QStats));
        Routing.RegisterRoute("About", typeof(About));
        Routing.RegisterRoute("SurahGoto",typeof(SurahGoto));
        Routing.RegisterRoute("CommonSearch", typeof(CommonSearch));
    }
}


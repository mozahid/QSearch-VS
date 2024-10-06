using Foundation;
using Microsoft.Maui.Handlers;
using SQLitePCL;
using UIKit;

namespace QSearch;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp()
    {
        raw.SetProvider(new SQLite3Provider_sqlite3());
        return MauiProgram.CreateMauiApp();
    }
}


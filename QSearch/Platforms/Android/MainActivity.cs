using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.Core.View;

namespace QSearch;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public override void StartActivityForResult(Intent intent, int requestCode)
    {
        if (intent == null)
        {
            intent = new Intent();
        }
        base.StartActivityForResult(intent, requestCode);
    }
    public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
    {
        Page p = Shell.Current.CurrentPage;

        if (p is IOnPageKeyDown)
        {
            bool handled = (p as IOnPageKeyDown).OnPageKeyDown(keyCode, e);

            if (handled) return true;
            else return base.OnKeyDown(keyCode, e);
        }
        else return base.OnKeyDown(keyCode, e);

    }
    // In MainActivity.cs
#nullable enable
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
    }
#nullable disable
}


using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.Core.View;

namespace QSearch;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
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
#nullable disable
    // In MainActivity.cs

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
    }
#nullable enable
    // protected override void OnCreate(Bundle? savedInstanceState)
    // {
    //     base.OnCreate(savedInstanceState);
    //     var decorView = Window.DecorView;
    //     if (Build.VERSION.SdkInt >= BuildVersionCodes.R)
    //     {
    //         Window.SetDecorFitsSystemWindows(false);
    //         decorView.SetOnApplyWindowInsetsListener(new InsetsListener());
    //     }
    //     else
    //     {
    //         ViewCompat.SetOnApplyWindowInsetsListener(decorView, new InsetsListenerLowerAPI());
    //     }
    // }
    
    // public class InsetsListenerLowerAPI : Java.Lang.Object, 
    // AndroidX.Core.View.IOnApplyWindowInsetsListener
    // {
    //     public WindowInsetsCompat OnApplyWindowInsets(Android.Views.View v, WindowInsetsCompat insets)
    //     {
    //         var gestureInsets = insets.GetInsets(WindowInsetsCompat.Type.SystemGestures());
    //         v.SetPadding(gestureInsets.Left, gestureInsets.Top, gestureInsets.Right, gestureInsets.Bottom);
    //         return WindowInsetsCompat.Consumed;
    //     }
    // }
    // private class InsetsListener : Java.Lang.Object, Android.Views.View.IOnApplyWindowInsetsListener
    // {
    //     public WindowInsets OnApplyWindowInsets(Android.Views.View v, WindowInsets insets)
    //     {
    //         var sysBars = insets.GetInsetsIgnoringVisibility(WindowInsets.Type.SystemBars());
    //         v.SetPadding(sysBars.Left, sysBars.Top, sysBars.Right, sysBars.Bottom);
    //         return WindowInsets.Consumed;
    //     }
    // }
}


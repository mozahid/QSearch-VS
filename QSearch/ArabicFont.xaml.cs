using Microsoft.Maui.Platform;
using QSearch.Models;
namespace QSearch;

public partial class ArabicFont : ContentPage
{
    TaskCompletionSource<OptionsData> _taskCompletionSource;
    public Task<OptionsData> PopupDismissedTask => _taskCompletionSource.Task;
    public OptionsData ReturnValue { get; set; }
    string _font = string.Empty;
    public ArabicFont()
	{
        InitializeComponent();
        _font = Preferences.Default.Get<string>("Font", "NotoArabic");
            switch(_font)
        {
            case "NotoArabic":
                radNaksh.IsChecked = true;
                break;
            case "LateefR":
                radLateef.IsChecked = true;
                break;
            case "AlQalam":
                radAlQalam.IsChecked = true;
                break;
            case "IndoPak":
                radIndoPak.IsChecked = true;
                break;
        }
        _taskCompletionSource = new TaskCompletionSource<OptionsData>();
        ReturnValue = new OptionsData();
        ReturnValue.option = "";

    }
    /// <summary>
    /// initialize 
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();
#if ANDROID
        if (Platform.CurrentActivity.CurrentFocus != null)
            Platform.CurrentActivity.HideKeyboard(Platform.CurrentActivity.CurrentFocus);
#endif
    }
    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        _taskCompletionSource.TrySetResult(ReturnValue);
        await _taskCompletionSource.Task;
    }

    async void btnSelect_Clicked(System.Object sender, System.EventArgs e)
    {
        ReturnValue.optionSelection = 0;
        ReturnValue.option = "";
        Preferences.Default.Set<string>("Font", _font);
        #if MACCATALYST
            await Navigation.PopAsync();
        #else
             await Navigation.PopModalAsync(false);
        #endif
    }

    async void btnCancel_Clicked(System.Object sender, System.EventArgs e)
    {
        ReturnValue.optionSelection = -1;   
        #if MACCATALYST
            await Navigation.PopAsync();
        #else
            await Navigation.PopModalAsync(false);
        #endif
    }
    /// <summary>
    /// font selected
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void radFont_CheckedChanged(System.Object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
    {
        RadioButton rad = sender as RadioButton;
        if (e.Value)
        {
            Font1.BackgroundColor = Colors.Transparent;
            Font2.BackgroundColor = Colors.Transparent;
            Font3.BackgroundColor = Colors.Transparent;
            Font4.BackgroundColor = Colors.Transparent;
            radNaksh.BackgroundColor = Colors.Transparent;
            radLateef.BackgroundColor = Colors.Transparent;
            radAlQalam.BackgroundColor = Colors.Transparent;
            radIndoPak.BackgroundColor = Colors.Transparent;
            
            switch (rad.Value)
            {
                case "1":
                    _font = "NotoArabic";
                    radNaksh.BackgroundColor = Colors.LightSkyBlue;           
                    Font1.BackgroundColor = Colors.LightSkyBlue;
                    break;
                case "2":
                    _font = "LateefR";
                    radLateef.BackgroundColor = Colors.LightSkyBlue;
                    Font2.BackgroundColor = Colors.LightSkyBlue;
                    break;
                case "3":
                    _font = "AlQalam";
                    radAlQalam.BackgroundColor = Colors.LightSkyBlue;
                    Font3.BackgroundColor = Colors.LightSkyBlue;
                    break;
                case "4":
                    _font = "IndoPak";
                    radIndoPak.BackgroundColor = Colors.LightSkyBlue;
                    Font4.BackgroundColor = Colors.LightSkyBlue;
                    break;
            }
        }
    }
}

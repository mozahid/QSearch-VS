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
            case "Lateef":
                radLateef.IsChecked = true;
                break;
            case "Qalam":
                radAlQalam.IsChecked = true;
                break;
            case "IndoPak":
                radIndoPak.IsChecked = true;
                break;
            case "MeQuran":
                radMeQuran.IsChecked = true;
                break;
            case "Uthmani":
                radHafsQuran.IsChecked = true;
                break;
        }
        _taskCompletionSource = new TaskCompletionSource<OptionsData>();
        ReturnValue = new OptionsData
        {
            option = ""
        };

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
            switch (rad.Value)
            {
                case "1":
                    _font = "NotoArabic";
                    break;
                case "2":
                    _font = "Lateef";
                    break;
                case "3":
                    _font = "Qalam";
                    break;
                case "4":
                    _font = "IndoPak";
                    break;
                case "5":
                    _font = "MeQuran";
                    break;
                case "6":
                    _font = "Uthmani";
                    break;
            }
        }
    }
}

using QSearch.Models;
namespace QSearch;

public partial class MiscOption : ContentPage
{
	TaskCompletionSource<OptionsData> _taskCompletionSource;
    public Task<OptionsData> PopupDismissedTask => _taskCompletionSource.Task;
    public OptionsData ReturnValue { get; set; }
	public MiscOption()
	{
		InitializeComponent();
        _taskCompletionSource = new TaskCompletionSource<OptionsData>();
        ReturnValue = new OptionsData { option = "" };
		//retrieve the saved font size and color from preferences and set the slider and radio buttons accordingly
		Color savedColor = Color.Parse(Preferences.Default.Get<string>("FontColor", "Black"));
		if (savedColor == Colors.Black)
		{
			radBlack.IsChecked = true;
		}
		else if (savedColor == Colors.Green)
		{
			radGreen.IsChecked = true;
		}
		else if (savedColor == Colors.Blue)
		{
			radBlue.IsChecked = true;
		}
		else if (savedColor == Colors.Goldenrod)
		{
			radYellow.IsChecked = true;
		}
		sizeSlider.Value = Preferences.Default.Get<int>("FontSize", 32);
	}

	    protected override void OnAppearing()
    {
        base.OnAppearing();
#if ANDROID
        var currentFocus = Platform.CurrentActivity?.CurrentFocus;
        if (currentFocus != null)
        {
            var inputMethodManager = (Android.Views.InputMethods.InputMethodManager?)Platform.CurrentActivity?.GetSystemService(Android.Content.Context.InputMethodService);
            inputMethodManager?.HideSoftInputFromWindow(currentFocus.WindowToken, Android.Views.InputMethods.HideSoftInputFlags.None);
        }
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
		ReturnValue.optionColor = radBlack.IsChecked ? nameof(Colors.Black) :
						radGreen.IsChecked ? nameof(Colors.Green) :
						radBlue.IsChecked ? nameof(Colors.Blue) :
						radYellow.IsChecked ? nameof(Colors.Goldenrod) : nameof(Colors.Black);
		ReturnValue.fontSize = (int)sizeSlider.Value;
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
	/// slider value changed event handler to round the value to the nearest multiple of 4 and clamp it within the slider's minimum and maximum range.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private void sizeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		double steppedValue =
			Math.Round(e.NewValue / 4) * 4;
	   	Slider FontSlider = sender as Slider;
		steppedValue = Math.Clamp(
			steppedValue,
			FontSlider.Minimum,
			FontSlider.Maximum);

		if (FontSlider.Value != steppedValue)
			FontSlider.Value = steppedValue;
	}
}
using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;
using QSearch.Models;
namespace QSearch;

public partial class SurahBM : ContentPage
{
    QuranDB dB;
    Surah selectedBM = null;
    TaskCompletionSource<OptionsData> _taskCompletionSource;
    public Task<OptionsData> PopupDismissedTask => _taskCompletionSource.Task;
    public OptionsData ReturnValue { get; set; }
    public SurahBM(QuranDB qdb)
	{
		InitializeComponent();
        dB = qdb;
        _taskCompletionSource = new TaskCompletionSource<OptionsData>();
        ReturnValue = new OptionsData();
        ReturnValue.option = "";
    }
    /// <summary>
    /// initialize 
    /// </summary>
    protected override async void OnAppearing()
    {
        base.OnAppearing();
#if ANDROID
        if (Platform.CurrentActivity.CurrentFocus != null)
            Platform.CurrentActivity.HideKeyboard(Platform.CurrentActivity.CurrentFocus);
#endif
        List<Surah> surahs = await dB.GetSurahList();
        List<Surah> _bm = new List<Surah>();
        foreach (var _s in surahs)
        {
            if (Preferences.Default.Get<string>("SURAH_NO_" + _s.chapter_number.ToString(), null) != null)
            {
                _bm.Add(_s);
            }
        }
        lstBM.ItemsSource = _bm;
        if (_bm.Count == 0) btnSelect.IsEnabled = false;
        Application.Current.UserAppTheme = AppTheme.Light;
    }
    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        _taskCompletionSource.TrySetResult(ReturnValue);
        await _taskCompletionSource.Task;
    }

/// <summary>
/// to cancel
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
async void btnCancel_Clicked(System.Object sender, System.EventArgs e)
    {
        ReturnValue.option = "0";
        #if MACCATALYST
             await Navigation.PopAsync();
        #else
             await Navigation.PopModalAsync();
        #endif
       
    }
    /// <summary>
    /// to select the bookmark
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void btnSelect_Clicked(System.Object sender, System.EventArgs e)
    {
        if (selectedBM != null)
        {
            ReturnValue.optionSelection = selectedBM.chapter_number;
            ReturnValue.option = "1";
            #if MACCATALYST
                await Navigation.PopAsync();
            #else
                await Navigation.PopModalAsync();
            #endif
            
            await Shell.Current.GoToAsync($"Surah?chapter={ReturnValue.optionSelection }",false);
        }
    }
    private void lstBM_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        selectedBM = e.CurrentSelection.FirstOrDefault() as Surah;
    }
}

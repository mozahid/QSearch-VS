using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using QSearch.Models;
using Microsoft.Maui.Platform;

namespace QSearch;

public partial class Options : ContentPage
{
    TaskCompletionSource<OptionsData> _taskCompletionSource;
    public Task<OptionsData> PopupDismissedTask => _taskCompletionSource.Task;
    QuranDB dB;


    public OptionsData ReturnValue { get; set; }

    public Options(QuranDB qdb)
	{
        
        InitializeComponent();
        dB = qdb;
#if ANDROID
        radSrch.TextColor = Color.FromRgb(0, 0, 0);
        radSurah.TextColor = Color.FromRgb(0, 0, 0);
        radPara.TextColor = Color.FromRgb(0, 0, 0);
        radStat.TextColor = Color.FromRgb(0, 0, 0);
        radAbout.TextColor = Color.FromRgb(0, 0, 0);
#endif

    }
    /// <summary>
    /// on Ok clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (lstSurah.IsEnabled)
        {
            if (lstSurah.SelectedIndex == -1)
            {
                await DisplayAlert("Q-Search", "Please select a surah!", "Ok");
                return;
            }
            else
            {
                ReturnValue.optionSelection = (lstSurah.SelectedItem as Surah).chapter_number;
            }    
        }
        else if (lstPara.IsEnabled)
        {
            if (lstPara.SelectedIndex == -1)
            {
                await DisplayAlert("Q-Search", "Please select a para!", "Ok");
                return;
            }
            else
            {
                ReturnValue.optionSelection = (lstPara.SelectedItem as Para).para_number;
            }
        }
        await Navigation.PopModalAsync();
    }

    /// get list of surahs
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _taskCompletionSource = new TaskCompletionSource<OptionsData>();
        radSrch.IsChecked = true;
        ReturnValue = new OptionsData();
        ReturnValue.option = "0";

        List<Surah> surah_list = await dB.GetSurahList();
        lstSurah.ItemsSource = surah_list;
        List<Para> para_list = await dB.GetParaList();
        lstPara.ItemsSource = para_list;
#if ANDROID
        if (Platform.CurrentActivity.CurrentFocus != null)
            Platform.CurrentActivity.HideKeyboard(Platform.CurrentActivity.CurrentFocus);
#endif
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        _taskCompletionSource.SetResult(ReturnValue);
        await _taskCompletionSource.Task;
    }
    /// <summary>
    /// on option selection
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void RadioButton_CheckedChanged(System.Object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
    {
        RadioButton rad = sender as RadioButton;
        if (e.Value)
        {
            ReturnValue.option = rad.Value.ToString();
            switch(rad.Value)
            {
                case "1":
                    lstPara.IsEnabled = false;
                    lstSurah.IsEnabled = true;
                    lstSurah.Focus();
                    break;
                case "2":
                    lstPara.IsEnabled = true;
                    lstPara.Focus();
                    lstSurah.IsEnabled = false;
                    break;
                default:
                    lstSurah.IsEnabled = false;
                    lstPara.IsEnabled = false;
                    break;
            }
        }    
    }
}

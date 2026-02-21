using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Platform;

namespace QSearch;

public partial class Bookmark : ContentPage
{
	QuranDB dB;
    Surah selectedBM = null;
	public Bookmark(QuranDB qdb)
	{
		InitializeComponent();
		dB = qdb;
	}
    /// <summary>
    /// initialize 
    /// </summary>
    protected override async void OnAppearing()
    {

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
        else btnSelect.IsEnabled = true;
        Application.Current.UserAppTheme = AppTheme.Light;
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
			var chapter = selectedBM.chapter_number;
			//await Shell.Current.GoToAsync($"Surah?chapter={chapter}",true);
            await Shell.Current.GoToAsync($"Wait?pagename=surah&pagenumber={chapter}",false);
        }
    }
    private void lstBM_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        selectedBM = e.CurrentSelection.FirstOrDefault() as Surah;
    }
}
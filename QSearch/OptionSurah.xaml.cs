using Microsoft.Maui.Platform;
namespace QSearch;

public partial class OptionSurah : ContentPage
{
	 QuranDB dB;
	 Surah selectedSurah = null;
	 Progress progress;
	public OptionSurah(QuranDB qdb)
	{
		InitializeComponent();
		dB = qdb;
		progress = new Progress(progInd);
	}

    private async void btnSelect_Clicked(object sender, EventArgs e)
    {
		if (selectedSurah != null)
        {
			var chapter = selectedSurah.chapter_number;
            await Shell.Current.GoToAsync($"Surah?chapter={chapter}", false);
        }
    }

    private void lstSurah_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        selectedSurah = e.CurrentSelection.FirstOrDefault() as Surah;
    }
	//hide progress //
    private void lstSurah_DescendantAdded(object sender, ElementEventArgs e)
    {
        progress.HideProgress();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		List<Surah> s = lstSurah.ItemsSource as List<Surah>;
		if (s != null && s.Count > 0) progress.HideProgress();
		if (lstSurah.ItemsSource == null) progress.ShowProgress();
		 double screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
        List<Surah> surahs = await dB.GetSurahList();
		lstSurah.ItemsSource = surahs;
		lstSurah.HeightRequest = screenHeight - 220;
    }

}
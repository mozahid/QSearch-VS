using Microsoft.Maui.Platform;
namespace QSearch;

public partial class OptionSurah : ContentPage
{
	 QuranDB dB;
	 Surah selectedSurah = null;
	 Progress progress;
     List<Surah> surahs;
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
    private void Page_Tapped(Object sender, EventArgs e)
    {
        srchChapter.Unfocus();
    }

    private void lstSurah_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        selectedSurah = e.CurrentSelection.FirstOrDefault() as Surah;
        srchChapter.Unfocus();
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
        surahs = await dB.GetSurahList();
		lstSurah.ItemsSource = surahs;
		double screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
         if (screenHeight <= 400)
        {
            lstSurah.HeightRequest = screenHeight - 100;
        }
        else
        {
            lstSurah.HeightRequest = screenHeight - 300;
        }
        await Task.Delay(10);
    }
	/// <summary>
    /// on search bar button press
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void srchChapter_SearchButtonPressed(object sender, EventArgs e)
    {
        SearchBar bar = (SearchBar) sender;
        bool isNumeric = int.TryParse(bar.Text, out int numericQuery);
        if (isNumeric)
        {
            int result = Convert.ToInt32(bar.Text);
            var _list = surahs.Where(s => s.chapter_number == result).ToList();
            lstSurah.ItemsSource = _list;
        }
        else if (bar.Text.Length > 0)
        {
            var matchingSurahs = surahs.Where(p =>
                p.chapter_name_english.ToLower().Contains(bar.Text) ||
                p.chapter_name_arabic.Contains(bar.Text)).ToList();
            lstSurah.ItemsSource = matchingSurahs;
        }
        else
        {
            lstSurah.ItemsSource = surahs;
        }
    }
	/// <summary>
    /// on clearing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void srchChapter_TextChanged(object sender, TextChangedEventArgs e)
    {
        SearchBar bar = (SearchBar) sender;
		if (bar.Text.Length > 0)
		{
			lstSurah.ItemsSource = surahs;
		}
    }
        private void FilterList(string query)
    {
        // If query is empty, restore full list
        if (string.IsNullOrWhiteSpace(query))
        {
            lstSurah.ItemsSource = surahs;
            return;
        }

        string cleanQuery = query.Trim().ToLower();

        // Check if input is a valid number
        bool isNumeric = int.TryParse(cleanQuery, out int numericQuery);

        var matchingSurahs = surahs.Where(p =>
            p.chapter_name_english.ToLower().Contains(cleanQuery) ||
            p.chapter_name_arabic.Contains(query) ||    
            (isNumeric && p.chapter_number == numericQuery)       
        ).ToList();

        // Update the visible UI collection
        lstSurah.ItemsSource = matchingSurahs;
    }
}
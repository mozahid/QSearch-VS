
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core.Platform;

namespace QSearch;

public partial class OptionGoto : ContentPage
{
	 QuranDB dB;
	 Surah selectedSurah = null;
	 Progress progress;
	 List<Surah> surahs;
     int selectedChapter = 1;
	 int verse_count = 1;
    public OptionGoto(QuranDB qdb)
    {
        InitializeComponent();
        dB = qdb;
        progress = new Progress(progInd);
        chapterFrom.Keyboard = Keyboard.Numeric;
        chapterTo.Keyboard = Keyboard.Numeric;
        Loaded += Option_Loaded;
    }
    private async void Option_Loaded(Object sender, EventArgs e)
    {
        List<Surah> s = lstSurah.ItemsSource as List<Surah>;
		if (s != null && s.Count > 0) progress.HideProgress();
        		progress.ShowProgress();
		 double screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
         if (screenHeight <= 400)
        {
            lstSurah.HeightRequest = screenHeight - 100;
        }
        else
        {
            lstSurah.HeightRequest = screenHeight - 350;
        }
        await Task.Delay(10);
        surahs = await dB.GetSurahList();
		lstSurah.ItemsSource = surahs;
    }
    private void Page_Tapped(Object sender, EventArgs e)
    {
        srchChapter.Unfocus();
    }
    private void lstSurah_DescendantAdded(object sender, ElementEventArgs e)
    {
       progress.HideProgress(); 
    }
    private async void lstSurah_SelectionChanged1(object sender, SelectionChangedEventArgs e)
    {
        selectedSurah = e.CurrentSelection.FirstOrDefault() as Surah;
		verse_count = await dB.GetSurahVerseCount(selectedSurah.chapter_number);
		chapterTo.Text =  verse_count.ToString();
        selectedChapter = selectedSurah.chapter_number;
        srchChapter.Unfocus();
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
    /// <summary>
    /// show surah verses
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnSelect_Clicked(object sender, EventArgs e)
    {
        int from = Convert.ToInt32(chapterFrom.Text);
        int to = Convert.ToInt32(chapterTo.Text);
        if (from <= to)
        {
            await Shell.Current.GoToAsync($"SurahGoto?chapter={selectedChapter}&chapterFrom={chapterFrom.Text}&chapterTo={chapterTo.Text}", false);
        }
        else
        {
            // to swap From and To if they are entered in wrong order
            await Shell.Current.GoToAsync($"SurahGoto?chapter={selectedChapter}&chapterFrom={chapterTo.Text}&chapterTo={chapterFrom.Text}", false);
        }   
    }

    private async void chapterFrom_TextChanged(object sender, TextChangedEventArgs e)
    {
        int res;
		if (Int32.TryParse(chapterFrom.Text, out res))
        {
            if (res < 0)
            {
                chapterFrom.Text = "1";
            }
            else if (res > verse_count)
            {
                await DisplayAlertAsync("QSearch","This verse is invalid!", "Ok");
				chapterFrom.Text = "1";
				chapterFrom.Focus();
            }
        }
    }

    private async void chapterTo_TextChanged(object sender, TextChangedEventArgs e)
    {
        int res;
		if (Int32.TryParse(chapterTo.Text, out res))
        {
            if (res < 0)
            {
                chapterTo.Text = verse_count.ToString();
            }
            else if (res > verse_count)
            {
                await DisplayAlertAsync("QSearch","This verse is invalid!", "Ok");
				chapterTo.Text = verse_count.ToString();
				chapterTo.Focus();
            }
        }
    }
}
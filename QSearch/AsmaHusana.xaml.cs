
namespace QSearch;

public partial class AsmaHusana : ContentPage
{
	QuranDB dB;
	private int currentIndex = 0;
	List<Asma> asmaList;
	public AsmaHusana(QuranDB qdb)
	{
		InitializeComponent();
		dB = qdb;
		Loaded += async (s, e) =>
		{
			asmaList = await dB.GetAsmaHusana();
			double screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
			double screenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
			foreach (var asma in asmaList)
			{
				asma.size_arabic_width = screenWidth <= 400 ? 375 : screenWidth - 5;
				asma.size_arabic_height = (screenHeight - 100) * 0.80;

#if ANDROID
				asma.size_font = Math.Floor(screenWidth / 3.5);
				asma.size_font_meaning = Math.Floor(screenWidth / 32);
#elif MACCATALYST
				asma.size_font = Math.Floor(screenWidth / 8.5);
				asma.size_font_meaning = Math.Floor(screenWidth / 70);
#else
				asma.size_font = Math.Floor(screenWidth / 4.2);
				asma.size_font_meaning = Math.Floor(screenWidth / 35);
#endif
				asma.font_arabic = "IndoPak";
			}
			myCollectionView.ItemsSource = asmaList;
			myCollectionView.ScrollTo(0, animate: true);
		};
	}	
	private void OnBackClicked(object sender, EventArgs e)
	{
		if (currentIndex > 0)
		{
			currentIndex--;
			myCollectionView.ScrollTo(currentIndex, animate: true);
		}
	}

	private void OnForwardClicked(object sender, EventArgs e)
	{
		var collection = myCollectionView.ItemsSource as System.Collections.IList;
		if (collection != null && currentIndex < collection.Count - 1)
		{
			currentIndex++;
			myCollectionView.ScrollTo(currentIndex, animate: true);
		}
	}
}
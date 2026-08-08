
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
				asma.size_arabic = screenWidth <= 400 ? 375 : screenWidth - 5;
				asma.size_font = Math.Floor(screenWidth / 3.6);
				asma.font_arabic = "IndoPak";
			}
			//myGrid.WidthRequest = screenWidth - 5;
		#if ANDROID
			myGrid.HeightRequest = screenHeight - 100;
		#else
			//myGrid.HeightRequest = screenHeight - 75;
		#endif
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
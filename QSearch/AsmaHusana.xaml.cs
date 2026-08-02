
namespace QSearch;

public partial class AsmaHusana : ContentPage
{
	QuranDB dB;
	private int currentIndex = 0;
	public AsmaHusana(QuranDB qdb)
	{
		InitializeComponent();
		dB = qdb;
		Loaded += async (s, e) =>
		{
			var asmaList = await dB.GetAsmaHusana();
			double screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
			double screenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
			foreach (var asma in asmaList)
			{
				asma.size_arabic = screenHeight <= 400 ? 375 : screenWidth - 100;
				asma.size_font = Math.Floor(screenWidth / 3.5);
				asma.font_arabic = "IndoPak";
			}
			myGrid.WidthRequest = screenWidth - 100;
		#if ANDROID
			myGrid.HeightRequest = screenHeight - 125;
		#else
			myGrid.HeightRequest = screenHeight - 100;
		#endif
			myCollectionView.ItemsSource = asmaList;
			myCollectionView.ScrollTo(0, animate: true);
		};
	}	
	protected async override void OnAppearing()
	{
		base.OnAppearing();


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
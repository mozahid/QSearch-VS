namespace QSearch;

public partial class AsmaHusana : ContentPage
{
	QuranDB dB;
	private int currentIndex = 0;
	public AsmaHusana(QuranDB qdb)
	{
		InitializeComponent();
		dB = qdb;
		Loaded += AsmaHusana_Loaded;	
	}	
	private async void AsmaHusana_Loaded(object sender, EventArgs e)
	{
		var asmaList = await dB.GetAsmaHusana();
		double screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
		foreach (var asma in asmaList)
		{
			asma.size_arabic = screenHeight <= 400 ? 375 : 425;
			asma.font_arabic = "IndoPak";
		}
		myGrid.HeightRequest = screenHeight - 100;
		myCollectionView.ItemsSource = asmaList;
		myCollectionView.ScrollTo(0, animate: true);
	}
	protected override void OnAppearing()
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
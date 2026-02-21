using System.Diagnostics;

namespace QSearch;

public partial class OptionPara : ContentPage
{
	 QuranDB dB;
	 Para selectedPara = null;
	 Progress progress;

	public OptionPara(QuranDB qdb)
	{
		InitializeComponent();
		dB = qdb;
		progress = new Progress(progInd);
	}

    private async void btnSelect_Clicked(object sender, EventArgs e)
    {
		if (selectedPara != null)
        {
			var para = selectedPara.para_number;
			await Shell.Current.GoToAsync($"Wait?pagename=para&pagenumber={para}", false);
        }
    }

    private void lstPara_DescendantAdded(object sender, ElementEventArgs e)
    {
        progress.HideProgress();
    }

    private void lstPara_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
         selectedPara = e.CurrentSelection.FirstOrDefault() as Para;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		List<Para> p = lstPara.ItemsSource as List<Para>;
		if (p != null && p.Count > 0) progress.HideProgress();
	    if (lstPara.ItemsSource == null) progress.ShowProgress();
		double screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
  		List<Para> para_list = await dB.GetParaList();
        lstPara.ItemsSource = para_list;
		lstPara.HeightRequest = screenHeight - 220;
        Application.Current.UserAppTheme = AppTheme.Light;
    }
}
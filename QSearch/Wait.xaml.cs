using System.Web;

namespace QSearch;

[QueryProperty(nameof(pagename), "page")]
[QueryProperty(nameof(pagenumber),"number")]
public partial class Wait : ContentPage, IQueryAttributable
{
	public string pagename{get;set;}
	public int pagenumber{get;set;}
	Progress progress;
	public Wait()
	{
		InitializeComponent();
		Loaded += Wait_Loaded;
		progress = new Progress(progInd);
	}
	 private async void Wait_Loaded(object sender, EventArgs e)
    {
		progress.ShowProgress();
		Navigation.RemovePage(this);

    }
	    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        pagename = HttpUtility.UrlDecode(query["pagename"].ToString());
		pagenumber = Convert.ToInt32(HttpUtility.UrlDecode(query["pagenumber"].ToString()));
		switch(pagename)
        {
            case "para":
				await Shell.Current.GoToAsync($"Para?para={pagenumber}", false);
				break;
			case "surah":
				await Shell.Current.GoToAsync($"Surah?chapter={pagenumber}", false);
				break;
        }
    }
}
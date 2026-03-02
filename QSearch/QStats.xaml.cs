namespace QSearch;

public partial class QStats : ContentPage
{
    QuranDB dB;
    public QStats(QuranDB qdb)
    {
        InitializeComponent();
        dB = qdb;
        Loaded += QStats_Loaded; ;
    }

    /// <summary>
    ///  get stats
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void QStats_Loaded(object sender, EventArgs e)
    {
        lTotalPara.Text = Convert.ToString(await dB.GetTotalPara());
        lTotalSurah.Text = Convert.ToString(await dB.GetTotalSurah());
        lTotalLines.Text = Convert.ToString(await dB.GetTotalLines());
        lTotalSujood.Text = Convert.ToString(await dB.GetTotalSujood());
        lTotalMakki.Text = Convert.ToString(await dB.GetTotalMakki());
        lTotalMadni.Text = Convert.ToString(await dB.GetTotalMadni());
    }
}

using System.Collections.ObjectModel;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Handlers;
using static System.Net.Mime.MediaTypeNames;
using QSearch.Models;
using Application = Microsoft.Maui.Controls.Application;
using System.Text.RegularExpressions;
using Plugin.LatestVersionStore;

#if ANDROID
using Android.Views;
#endif
namespace QSearch;

public partial class QSearch : ContentPage, IOnPageKeyDown
{
    QuranDB dB;
    Options opt;
    OptionsData ret = new OptionsData();
    private string words_entered = string.Empty;

    /// <summary>
    /// check latest version
    /// </summary>
    /// <returns></returns>
    async Task CheckLatestVersion()
    {
        var isLatest = await CrossLatestVersion.Current.IsUsingLatestVersion();
        if (!isLatest)
        {
            await Application.Current.MainPage.DisplayAlert("Q-Search",
                  "New version available in the store.", "OK");
            await CrossLatestVersion.Current.OpenAppInStore();
        }
    }

    public QSearch(QuranDB qdb)
    {
        InitializeComponent();
        dB = qdb;
        opt = new Options(dB);
        Loaded += QSearch_Loaded;
        ret.option = string.Empty;
        Appearing += QSearch_Loaded;
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
        {
#if ANDROID
            //handler.PlatformView.ShowSoftInputOnFocus = false;
            handler.PlatformView.KeyPress += PlatformView_KeyPress;
#endif
        });

        Task.Run(async () => await CheckLatestVersion());
    }
#if ANDROID
    public bool OnPageKeyDown(Keycode keyCode, KeyEvent e)
    {
        switch (keyCode)
        {
            case Keycode.Enter:
                // Your code here
                if (words_entered.Length == 0)
                {
                    DisplayAlert("Q-Search", "Please enter a word to search for!", "Ok");
                }
                return true;

            default:
                return false;
        }
    }
    /// <summary>
    /// handle the blank enter action
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void PlatformView_KeyPress(object sender, Android.Views.View.KeyEventArgs e)
    {
        if (e.KeyCode == Android.Views.Keycode.Enter
            && words_entered.Length == 0)
        {
            e.Handled = true;
            await DisplayAlert("Q-Search", "Please enter a word to search for!", "Ok");
            return;
        }
        else e.Handled = false;
    }
#endif
    /// <summary>
    /// when a text is entered
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void txtSearch_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        words_entered += e.NewTextValue;
    }
    private void QSearch_Loaded(object sender, EventArgs e)
    {
        txtSearch.Focus();
    }
    /// <summary>
    /// The search click button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void txtSearch_Completed(System.Object sender, System.EventArgs e)
    {
        Entry txt = (Entry)sender;
        var screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;

        if (txt.Text.Length == 0)
        {
            await DisplayAlert("Q-Search", "Please enter a word to search for!", "Ok");
            return;
        }
        progInd.IsRunning = true;
        List<Verse> Verses = new List<Verse>();
        string[] words = txt.Text.Trim().Split(' ');
        /// if not any english alpah
        string pattern = "^[a-zA-Z0-9]*$";
        Regex rg = new Regex(pattern);
        if (rg.IsMatch(words[0]))
        {
            //// use english ///
            if (words.Length == 1)
            {
                Verses = await dB.GetVerseAsync(txt.Text);
            }
            else
            {
                //// multiple words, use OR query
                Verses = await dB.GetVerseAsync(words);
            }
        }
        else
        {
            /// arabic
            if (words.Length == 1)
            {
                Verses = await dB.GetArabicVerseAsync(txt.Text);
            }
            else
            {
                //// multiple words, use OR query
                Verses = await dB.GetArabicVerseAsync(words);
            }
        }

        result.IsVisible = false;
        // databinding the listview ////
        lstView.ItemsSource = Verses;
        if (Verses.Count() == 0)
        {
            await DisplayAlert("Q-Search", "No search found!", "OK");
            progInd.IsRunning = false;
        }
        else
        {
            result.IsVisible = true;
            total.Text = Verses.Count.ToString();
            lstView.HeightRequest = screenHeight - 250;
        }
        progInd.IsRunning = false;
    }
    /// <summary>
    /// hide activity 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void lstView_Focused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
        progInd.IsRunning = false;
    }
    void lstView_DescendantAdded(System.Object sender, Microsoft.Maui.Controls.ElementEventArgs e)
    {
        progInd.IsRunning = false;
    }
    void lstView_Scrolled(System.Object sender, Microsoft.Maui.Controls.ItemsViewScrolledEventArgs e)
    {
        progInd.IsRunning = false;
    }
    /// <summary>
    /// on clicking option toolbar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        ret.option = string.Empty;
        await Navigation.PushModalAsync(opt);
        ret = await opt.PopupDismissedTask;
    }

    /// <summary>
    /// on focus back
    /// </summary>
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        progInd.IsRunning = false;
        if (ret.option != string.Empty)
        {
            var selectedOption = ret.option;
            await Task.Delay(5);
            if (selectedOption == "1")
            {           
                Application.Current.MainPage = new NavigationPage(new RSurah(dB, ret.optionSelection));
            }
            else if (selectedOption == "2")
            {
                Application.Current.MainPage = new NavigationPage(new RPara(dB, ret.optionSelection));
            }
            else if (selectedOption == "3")
            {
                Application.Current.MainPage = new NavigationPage(new QStats(dB));
            }
            else if (selectedOption == "4")
            {
                Application.Current.MainPage = new NavigationPage(new About(dB));
            }
        }
    }


}

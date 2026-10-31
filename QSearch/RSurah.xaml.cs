using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Web;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using QSearch.Models;

namespace QSearch;
[QueryProperty(nameof(chapter), "chapter")]
public partial class RSurah : ContentPage, IQueryAttributable
{
    QuranDB dB;
    int chapter_no = 0;
    //Options opt;
    OptionsData ret = new OptionsData();
    Grid surahGrid = null;
    List<QuranicVerse> surahs = new List<QuranicVerse>();
    Surah surah_info = new Surah();
    public bool showTrans = false;
    int firstItem = 0;
    Progress progress;
    public int chapter {get; set;}
    public int selectedLanguage = 1;
    public bool showSeparator = false;
     public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        chapter = Convert.ToInt32(HttpUtility.UrlDecode(query["chapter"].ToString()));
        chapter_no = chapter;
        // show tick mark if bookmarked //
        string bmSurahs = Preferences.Default.Get<string>("SURAH_NO_" + chapter_no.ToString(), null);
        if (bmSurahs != null)
        {
            FontImageSource fi = bmSurah.Source as FontImageSource;
            fi.Color = Colors.Green;
        }
        switch (chapter_no)
        {
            case 1:
                btnBack.BackgroundColor = Colors.DimGray;
                break;
            case 114:
                btnForward.BackgroundColor = Colors.DimGray;
                break;
            default:
                btnBack.BackgroundColor = Colors.LightSkyBlue;
                btnForward.BackgroundColor = Colors.LightSkyBlue;
                break;
        }           
        if (surahGrid == null)
        {
            surah_info = await dB.GetSurahInfo(chapter_no);
            surahs = await dB.GetSurahByNumber(chapter_no);
            surah_info.para_name = surahs[0].para_name;
            surah_info.para_number = surahs[0].para_number;
            this.Title = "Recite Surah - " + surah_info.chapter_name_arabic;
            grdHeader.BindingContext = surah_info;
            progress.ShowProgress();
            await Task.Delay(10);
            await LinesByLines();
        }
    }
    //used by GoToAsync //
    public RSurah(QuranDB qdb)
	{
		InitializeComponent();
        dB = qdb;
        progress = new Progress(progInd);
        lstView.ItemsSource = null;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        var screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
        lstView.IsVisible = true;
        lstView.HeightRequest = screenHeight - 270;
    }
    /// <summary>
    /// Lines by Lines
    /// </summary>
    private async Task LinesByLines()
    {
        progress.ShowProgress();
        await Task.Delay(10);

        ReciteSurah _reciteSurah = new()
        {
            showSeparator = "true",
            verse_arabic_lines = new string[surahs.Count],
            verse_translation_lines = new string[surahs.Count],
            translation_ref_lines = new string[surahs.Count],
            ruku_lines = new bool[surahs.Count],
            sujood_lines = new bool[surahs.Count],
            verse_number = new int[surahs.Count],
        };
        for (int i = 0; i < surahs.Count; i++)
        {
            _reciteSurah.verse_arabic_lines[i] = surahs[i].verse_arabic.Replace("[", string.Empty).Replace("]", string.Empty).Replace(Regex.Match(surahs[i].verse_arabic, @"\d+").Value.ToString(), string.Empty).Replace("۩", string.Empty);
            _reciteSurah.verse_number[i] = surahs[i].verse_number;
            if (showTrans)
            {
                switch(selectedLanguage)
                {
                    case 1:
                        _reciteSurah.verse_translation_lines[i] = surahs[i].verse_english;
                        _reciteSurah.translation_ref_lines[i] = surahs[i].english_ref;
                        break;
                    case 2:
                        _reciteSurah.verse_translation_lines[i] = surahs[i].verse_urdu;
                        _reciteSurah.translation_ref_lines[i] = surahs[i].urdu_ref; 
                        break;
                    default:
                        _reciteSurah.verse_translation_lines[i] = surahs[i].verse_english;
                        _reciteSurah.translation_ref_lines[i] = surahs[i].english_ref;
                        break;
                }
            }
            else
            {
                _reciteSurah.verse_translation_lines[i] = string.Empty;
                _reciteSurah.translation_ref_lines[i] = string.Empty;
            }

            _reciteSurah.ruku_lines[i] = surahs[i].ruku;
            _reciteSurah.sujood_lines[i] = surahs[i].sujood;
        }
        lstView.ItemsSource = new[] { _reciteSurah };
        lstView.ItemTemplate = new DataTemplate(CreateVerseGrid);
        progress.HideProgress();
    }
   private Grid CreateVerseGrid()
    {
		int gridRow = 0;
        surahGrid = new Grid
        {
            RowSpacing = 3,
            ColumnDefinitions = { new ColumnDefinition { Width = GridLength.Star } },
        };

        for (var rowIndex = 0; rowIndex < surahs.Count; rowIndex++)
        {
            surahGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto});
			surahGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto});
			surahGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto});
            surahGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto});

            var verseTextView = new VerseTextView
            {
                FontName = Preferences.Default.Get<string>("Font", "NotoArabic"),
                FontSize = 28,
                HorizontalOptions = LayoutOptions.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                VerticalOptions = LayoutOptions.Start,
                VerseImage = "quranic_border_4.png",
            };
            verseTextView.SetBinding(VerseTextView.VerseTextProperty, $"verse_arabic_lines[{rowIndex}]", BindingMode.OneWay);
            verseTextView.SetBinding(VerseTextView.VerseNumberProperty, $"verse_number[{rowIndex}]", BindingMode.OneWay);
            verseTextView.SetBinding(VerseTextView.RukuProperty, $"ruku_lines[{rowIndex}]", BindingMode.OneWay);
            verseTextView.SetBinding(VerseTextView.SujoodProperty, $"sujood_lines[{rowIndex}]", BindingMode.OneWay);
            surahGrid.SetRow(verseTextView, gridRow++);
            surahGrid.Children.Add(verseTextView);
            
            var translationLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.End,
                TextColor = Colors.Gray,
                FontSize = 16.0,
                FontFamily = "Tahoma",
                IsVisible = false
            };
            translationLabel.SetBinding(Label.TextProperty, $"verse_translation_lines[{rowIndex}]", BindingMode.OneWay);
            surahGrid.SetRow(translationLabel, gridRow++);
            surahGrid.Children.Add(translationLabel);
            var refLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.End,
                TextColor = Colors.LightSteelBlue,
                FontSize = 10.0,
                IsVisible = false
            };
            refLabel.SetBinding(Label.TextProperty, $"translation_ref_lines[{rowIndex}]", BindingMode.OneWay);
            surahGrid.SetRow(refLabel, gridRow++);
            surahGrid.Children.Add(refLabel);
            if (showTrans)
            {
               switch(selectedLanguage)
               {
                   case 1:
                        translationLabel.FontFamily = "Tahoma";
                        refLabel.FontFamily = "Tahoma";
                       break;
                   case 2:
                       translationLabel.FontFamily = "Urdu";
                       refLabel.FontFamily = "Urdu";
                       break;
               }
            }   
            //// show separator between verses
            var separator = new BoxView
            {
                HeightRequest = 1,
                Color = Colors.Silver,
                HorizontalOptions = LayoutOptions.Fill,
                IsVisible = showSeparator
            };
            surahGrid.SetRow(separator, gridRow++);
            surahGrid.Children.Add(separator);
        }

        return surahGrid;
    }

    /// <summary>
    /// tool bar options clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        //await Shell.Current.Navigation.PopToRootAsync();
        await Shell.Current.GoToAsync("Search", false);
    }
    /// <summary>
    /// bookmarking this surah
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
     async void bmSurah_Clicked(System.Object sender, System.EventArgs e)
    {
        string bmSurahs = Preferences.Default.Get<string>("SURAH_NO_" + chapter_no.ToString(), null);
        if (bmSurahs != null)
        {
            bool answer = await DisplayAlertAsync("Q-Search", "Remove this bookmark?", "Yes", "No");
            if (answer)
            {
                Preferences.Default.Remove("SURAH_NO_" + chapter_no.ToString());
                FontImageSource fi = bmSurah.Source as FontImageSource;
                fi.Color = Colors.Black;
            }
        }
        else
        {
            Preferences.Default.Set<string>("SURAH_NO_" + chapter_no.ToString(), chapter_no.ToString());
            FontImageSource fi = bmSurah.Source as FontImageSource;
            fi.Color = Colors.Green;
        }
    }
    /// <summary>
    /// open a book mark list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void openBM_Clicked(System.Object sender, System.EventArgs e)
    {
        ret.option = string.Empty;
        SurahBM bm = new SurahBM(dB);
        #if MACCATALYST
            await Navigation.PushAsync(bm);
        #else
            await Navigation.PushModalAsync(bm);
        #endif
        
        ret = await bm.PopupDismissedTask;
    }
    /// <summary>
    /// show English translation or toggle it off
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void showTranslation_Clicked(object sender, EventArgs e)
    {
        var popup = new TranslationOption("SURAH");

        // The type parameter must match the type returned from the popup.
        IPopupResult<Int16> popupResult = await this.ShowPopupAsync<Int16>(popup, new PopupOptions
                {
                    PageOverlayColor = Colors.DarkSlateGray.WithAlpha(0.6f)
                }, CancellationToken.None);
        if (popupResult == null || popupResult.WasDismissedByTappingOutsideOfPopup)
        {
            return;
        }
        switch (popupResult.Result)
        {
            case 1:
                // English translation was tapped
                showTrans = true;
                selectedLanguage = 1;
                break;
            case 2:
                // Urdu translation was tapped
                showTrans = true;
                selectedLanguage = 2;
                break;
            default:
                showTrans = false;
                selectedLanguage = 3;
                break;
        }
        if (showTrans)
        {
            FontImageSource fi = showTranslation.Source as FontImageSource;
            fi.Color = Colors.Green;
        }
        else
        {
            FontImageSource fi = showTranslation.Source as FontImageSource;
            fi.Color = Colors.Black;
        }
        progress.ShowProgress();
        await Task.Delay(5);
        int n=0;
        for(int nRow=0; nRow < surahGrid.Children.Count; nRow += 4)
        {
            var childTranslation = surahGrid.Children[nRow + 1] as Label;
            var childRef = surahGrid.Children[nRow + 2] as Label;
            switch(showTrans)
            {
                case true:
                    switch(selectedLanguage)
                    {
                        case 1:
                            childTranslation.Text = surahs[n].verse_english;
                            childTranslation.FontFamily= "Tahoma";
                            childRef.Text = surahs[n].english_ref;
                            childRef.FontFamily = "Tahoma";
                            break;
                        case 2:
                            childTranslation.Text = surahs[n].verse_urdu;
                            childTranslation.FontFamily= "Urdu";
                            childRef.Text = surahs[n].urdu_ref;
                            childRef.FontFamily = "Urdu";
                            break;
                    }
                    break;
                case false:
                    childTranslation.Text = string.Empty;
                    childRef.Text = string.Empty;
                    break;
            }
            n++;
        }
        //Dispatcher.Dispatch(() => lstView.ScrollTo(firstItem));
        progress.HideProgress();
    }
    /// <summary>
    /// font change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnFont_Clicked(object sender, EventArgs e)
    {
        ArabicFont fn = new ArabicFont();

        #if MACCATALYST
            await Navigation.PushAsync(fn);
        #else
            await Navigation.PushModalAsync(fn);
        #endif

        await fn.PopupDismissedTask;
        if (fn.ReturnValue.optionSelection == 0)
        {
            progress.ShowProgress();
            await Task.Yield();
            for(int nRow=0; nRow < surahGrid.Children.Count; nRow += 4)
            {
                var child = surahGrid.Children[nRow] as VerseTextView;
                child.FontName = Preferences.Default.Get<string>("Font", "NotoArabic");
            }
            //Dispatcher.Dispatch(() => lstView.ScrollTo(firstItem));
            progress.HideProgress();
        }
    }
    /// <summary>
    /// on scroll
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void lstView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        firstItem = e.FirstVisibleItemIndex;
    }
    /// <summary>
    /// back button pressed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnBack_Clicked(object sender, EventArgs e)
    {
        if (chapter_no > 1)
        {
            chapter_no -= 1;
            await Shell.Current.GoToAsync($"Surah?chapter={chapter_no}", false);
        }
    }
    /// <summary>
    /// forward button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnForward_Clicked(object sender, EventArgs e)
    {
        if (chapter_no < 114)
        {
            chapter_no += 1;
            await Shell.Current.GoToAsync($"Surah?chapter={chapter_no}", false);
        }
    }
    /// <summary>
    /// Show lines
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnLine_Clicked(object sender, EventArgs e)
    {
        //lstView.ItemsSource = null;
        btnLine.IsEnabled = false;
        await Task.Delay(5);
        progress.ShowProgress();
        showSeparator = !showSeparator;
        if (showSeparator)
        {
            FontImageSource fi = btnLine.Source as FontImageSource;
            fi.Color = Colors.Green;
        }
        else
        {
            FontImageSource fi = btnLine.Source as FontImageSource;
            fi.Color = Colors.Black;
        }
        await Task.Yield();
        for(int nRow=0; nRow < surahGrid.Children.Count; nRow += 4)
        {
            if ((nRow + 3) <= surahGrid.Children.Count - 1)
            {
                var child = surahGrid.Children[nRow + 3] as BoxView;
                child.IsVisible = showSeparator; 
            }
        }
        btnLine.IsEnabled = true;
        progress.HideProgress();
    }
}
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;

namespace QSearch;

[QueryProperty(nameof(item), "item")]
public partial class CommonSearch : ContentPage
{
	public string item{get;set;}
	 QuranDB dB;
	 List<Verse> Verses = new List<Verse>();
    Progress progress;
	public int selectedLanguage = 1;
	public CommonSearch()
	{
		InitializeComponent();
		progress = new Progress(progInd);
		this.Loaded += 	Form_Loaded;
	}
	public CommonSearch(QuranDB qdb)
	{
		InitializeComponent();
		dB = qdb;
		progress = new Progress(progInd);
		this.Loaded += 	Form_Loaded;
	}   
	public static readonly BindableProperty ItemProperty = 
	BindableProperty.Create("Item", typeof(string), typeof(CommonSearch));

	public string Item
	{
		get => (string)GetValue(ItemProperty);
		set => SetValue(ItemProperty, value);
	}
    private async void Form_Loaded(object sender, EventArgs e)
    {
        await DisplayVerses();
    } 
	private async Task DisplayVerses()
	{
		var screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
        lstView.IsVisible = true;
		// if (screenHeight > 1000)
        // 	lstView.HeightRequest = screenHeight - 300; 
		// else
		// 	lstView.HeightRequest = screenHeight - 400;
		progress.ShowProgress();
		List<Verse> v = new List<Verse>();
		Verses = new List<Verse>();
		await Task.Delay(25);
		dB = new QuranDB();
		switch (Item)
		{
			case "Sujood":

				this.Title = "Sujood Verses";
				lblPreface.Text = "These verses are the ones where the Prophet Muhammad (SAW) and believers prostrated in worship to Allah. They are moments of deep humility, submission, and connection with the Divine, often revealed in response to profound events or messages.";

				Verses = await dB.GetSujoodVerses();
				foreach (var _v in Verses)
				{
					_v.font = Preferences.Default.Get<string>("Font", "NotoArabic");
					_v.verse_arabic = _v.verse_arabic.Replace("۩", "");
					_v.verse_arabic_end = "۩";
					switch(selectedLanguage)
					{
						case 1:
							_v.translation = _v.verse_english;
							_v.translation_ref = _v.english_ref;
							_v.font_translation = "Tahoma";
							_v.translation_alignment = TextAlignment.Start;
							break;
						case 2:
							_v.translation = _v.verse_urdu;
							_v.translation_ref = _v.urdu_ref;
							_v.font_translation = "Urdu";
							_v.translation_alignment = TextAlignment.End;
							break;
						default:
							_v.translation = _v.verse_english;
							_v.translation_ref = _v.english_ref;
							_v.font_translation = "Tahoma";
							_v.translation_alignment = TextAlignment.Start;
							break;
					}
					_v.tafsir = "";
					//_v.translation_ref = "";
					// height of header //
					_v.number = 110;
				}
				break;
			case "Dua":
	
				this.Title = "Prophet Duas in the Quran";
				lblPreface.Text = "These are the duas (supplications) made by the Prophets mentioned in the Quran. They cover a wide range of themes, including seeking forgiveness, asking for guidance, protection from harm, and expressing gratitude. Each dua reflects the unique circumstances and challenges faced by the Prophets, as well as their deep connection with Allah." ;
				var _duas = await dB.GetVerseRef("Dua");
				int _vcount = 0;
				foreach(var dua in _duas)
				{
					switch(selectedLanguage)
					{
						case 1:
							v = await dB.GetProphetDua(dua.title, dua.chapter_number, dua.verse_start, dua.verse_end, dua.background_title, dua.context_english, selectedLanguage);
							break;
						case 2:
							v = await dB.GetProphetDua(dua.title, dua.chapter_number, dua.verse_start, dua.verse_end, dua.background_title, dua.context_urdu, selectedLanguage);
							break;
					}
					_vcount = 1;
					foreach(var _v in v)
					{
						_v.font = Preferences.Default.Get<string>("Font", "NotoArabic");
						// height of header //
						_v.number = 124;
						if (_v.verse_arabic.Contains("۩"))
						{
							_v.verse_arabic = _v.verse_arabic.Replace("۩", "");
							_v.verse_arabic_end = "۩";
						}
						// combine multiple verses as one unit
						if (v.Count > 1)
						{
						    if (_vcount == 1) Verses.Add(_v);
							else
							{
								Verses[Verses.Count - 1].verse_arabic += "\n" + _v.verse_arabic;
								Verses[Verses.Count - 1].verse_english += "\n" + _v.verse_english;
								Verses[Verses.Count - 1].verse_arabic_end +=  _v.verse_arabic_end;
								switch(selectedLanguage)
								{
									case 1:
										Verses[Verses.Count - 1].translation += "\n" + _v.verse_english;
										Verses[Verses.Count - 1].translation_ref += "\n" + _v.english_ref;

										break;
									case 2:
										Verses[Verses.Count - 1].translation += "\n" + _v.verse_urdu.Trim();
										Verses[Verses.Count - 1].translation_ref += "\n" + _v.urdu_ref;

										break;
									default:
										Verses[Verses.Count - 1].translation += "\n" + _v.verse_english;
										Verses[Verses.Count - 1].translation_ref += "\n" + _v.english_ref;

										break;
								}
							}
							_vcount++;
						}
						else 
						{
							Verses.Add(_v);
						}
						switch(selectedLanguage)
						{
							case 1:
								Verses[Verses.Count - 1].translation_alignment = TextAlignment.Start;
								Verses[Verses.Count - 1].font_translation = "Tahoma";
								break;
							case 2:
								Verses[Verses.Count - 1].translation_alignment = TextAlignment.End;
								Verses[Verses.Count - 1].font_translation = "Urdu";
								break;
							default:
								Verses[Verses.Count - 1].translation_alignment = TextAlignment.Start;
								Verses[Verses.Count - 1].font_translation = "Tahoma";
								break;
						}
					}
				}
				break;
			case "Sakina":
				this.Title = "Tranquility Verses(Sakina)";
				lblPreface.Text = "These verses are the ones where Allah sent down tranquility (sakina) to calm the hearts of the believers during moments of extreme danger, tension, or uncertainty. They are powerful reminders of Allah’s support and presence in times of trial, showing that true peace and strength come from reliance on the Creator. Recite all of them after obligatory prayers to receive the benefits of sakina in your life.";	
				var _sakina = await dB.GetVerseRef("Sakina");
				foreach(var sakina in _sakina)
				{
					switch(selectedLanguage)
					{
						case 1:
							v = await dB.GetSakinaVerses(sakina.title, sakina.chapter_number, sakina.verse_start, sakina.verse_end, sakina.background_title, sakina.context_english);
						break;
						case 2:
							v = await dB.GetSakinaVerses(sakina.title, sakina.chapter_number, sakina.verse_start, sakina.verse_end, sakina.background_title, sakina.context_urdu);
						break;
					}
					
					foreach (var _v in v)
					{
						_v.font = Preferences.Default.Get<string>("Font", "NotoArabic");
						_v.translation_ref = "";
						switch(selectedLanguage)
						{
							case 1:
								_v.translation = _v.verse_english;
								_v.translation_ref = _v.english_ref;
								_v.font_translation = "Tahoma";
								_v.translation_alignment = TextAlignment.Start;
								break;
							case 2:
								_v.translation = _v.verse_urdu;
								_v.translation_ref = _v.urdu_ref;
								_v.font_translation = "Urdu";
								_v.translation_alignment = TextAlignment.End;
								break;
							default:
								_v.translation = _v.verse_english;
								_v.translation_ref = _v.english_ref;
								_v.font_translation = "Tahoma";
								_v.translation_alignment = TextAlignment.Start;
								break;
						}
						// height of header //
						_v.number = 124;
						Verses.Add(_v);
					}	
				}
				break;
		}
		lstView.ItemsSource = Verses;
		progress.HideProgress();
	}
	/// <summary>
	/// show translation options popup
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private async void showTranslation_Clicked(object sender, EventArgs e)
	{
		var popup = new TranslationOption();

        // The type parameter must match the type returned from the popup.
        IPopupResult<Int16> popupResult = await this.ShowPopupAsync<Int16>(popup, new PopupOptions
                {
                    PageOverlayColor = Colors.DarkSlateGray.WithAlpha(0.6f)
                }, CancellationToken.None);

        if (popupResult.WasDismissedByTappingOutsideOfPopup)
        {
            return;
        }
        switch (popupResult.Result)
        {
            case 1:
                // English translation was tapped
                selectedLanguage = 1;
                break;
            case 2:
                // Urdu translation was tapped
                selectedLanguage = 2;
                break;
        }
		await DisplayVerses();
		//Dispatcher.Dispatch(() => lstView.ScrollTo(firstItem, position: ScrollToPosition.Center, animate: true));
	}

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
			await DisplayVerses();
            progress.HideProgress();
        }
	}
}
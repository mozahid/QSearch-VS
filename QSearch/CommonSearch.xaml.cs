using System.Web;
namespace QSearch;

[QueryProperty(nameof(item), "item")]
public partial class CommonSearch : ContentPage, IQueryAttributable
{
	public string item{get;set;}
	 QuranDB dB;
	 List<Verse> Verses = new List<Verse>();
    Progress progress;
	string[,] duas = new string[23,5] {{"Adam","7","23","23", 
									  "<p style='color:blue;background-color:whitesmoke'><u>Dua for Forgiveness</u></p>When Adam (AS) and Hawwa (AS) disobeyed Allah by eating from the forbidden tree, they immediately repented with this heartfelt dua, showing humility, remorse, and recognition of Allah’s mercy."},
									  {"Nuh","11","41","41","<p style='color:blue;background-color:whitesmoke'><u>Dua for Traveling</u></p>When Nuh (AS) boarded the ship."},
									  {"Nuh","11","47","47","<p style='color:blue;background-color:whitesmoke'><u>Dua for Forgiveness</u></p>After asking Allah about saving his son from the flood, Allah reminded Nuh (AS) that his son was not among the righteous. Nuh (AS) immediately sought forgiveness, showing submission and repentance."},
									  {"Nuh","23","26","26","<p style='color:blue;background-color:whitesmoke'><u>Dua for Adversity</u></p>After tirelessly calling his people to Allah for centuries, Prophet Nuh (AS) faced persistent rejection, ridicule, and denial from his community. In this moment of despair, he turned to Allah alone for support and vindication, showing that true help comes only from the Creator when human efforts are exhausted."},
									  {"Nuh","23","29","29","<p style='color:blue;background-color:whitesmoke'><u>Dua for Traveling</u></p>After the flood, when the ark settled and the waters began to recede, Prophet Nuh (AS) made this dua, asking Allah for a safe and blessed place to disembark. It reflects gratitude, humility, and reliance on Allah after deliverance from a great trial."},
									  {"Nuh","54","10","10","<p style='color:blue;background-color:whitesmoke'><u>Dua for Help</u></p>When the opposition of his people became overwhelming, Nuh (AS) turned to Allah, admitting his weakness and asking for divine help. This dua reflects total reliance on Allah’s power when human means were exhausted."},
									  {"Nuh","71","28","28","<p style='color:blue;background-color:whitesmoke'><u>Dua for Forgiveness</u></p>After warning his people and being rejected, Nuh (AS) turned to Allah, asking for forgiveness for himself and the believers, showing the importance of including others in one’s prayers."},
									  {"Ibrahim","2","126","126","<p style='color:blue;background-color:whitesmoke'><u>Dua for Security and Prosperity</u></p>Concerned for the sustenance of his family and community in the barren valley of Makkah, Ibrahim (AS) made dua and sought both worldly protection and provision for its land and people. A powerful dua that Allah answered as today Makkah has peace, stability and prosperity, especially when compared to its barren days during the times of Prophet Ibrahim (AS)."},
									  {"Ibrahim","2","127","127","<p style='color:blue;background-color:whitesmoke'><u>Dua for Acceptance of Act</u></p>This dua was made by Prophet Ibrahim (AS) and his son Prophet Isma’il (AS) while raising the Ka'bah’s foundations by Allah’s command. Even in this moment of immense spiritual significance, they remained humble and prayerful."},
									  {"Ibrahim","2","128","128","<p style='color:blue;background-color:whitesmoke'><u>Dua for Humble Submission</u></p>This dua follows immediately after Prophet Ibrahim (AS) and Prophet Isma’il (AS) began constructing the Ka'bah. While performing this sacred task, they turned to Allah not only for acceptance but for continued guidance and spiritual legacy."},
									  {"Ibrahim","3","173","173","<p style='color:blue;background-color:whitesmoke'><u>Dua for Protection</u></p>This was said by Prophet Ibrahim (AS) when he was thrown into the fire by his people. Despite the extreme danger, he placed complete trust in Allah’s power and protection."},
									  {"Ibrahim","14","35","35","<p style='color:blue;background-color:whitesmoke'><u>Dua for Prosperity</u></p>nWhen Prophet Ibrahim (AS) returned to Makkah and found it an established, prosperous city, he prayed for its security and, more importantly, for protection from idol worship for himself and his children. His dua reflects foresight: recognizing that prosperity often leads people to arrogance, forgetfulness of Allah, and deviation from faith."},
									  {"Ibrahim","14","40","40","<p style='color:blue;background-color:whitesmoke'><u>Dua for Steadfastness</u></p>In this heartfelt prayer, Prophet Ibrahim (AS) asked Allah for three profound blessings: to remain steadfast in establishing salah, that his offspring also uphold salah, and that his duas be accepted."},
									  {"Ibrahim","14","41","41","<p style='color:blue;background-color:whitesmoke'><u>Dua for Forgiveness</u></p>Prophet Ibrahim (AS) sought Allah’s mercy for himself, his parents, and all believers, teaching that one’s concern in dua should extend beyond personal needs to the wider community or Ummah of believers."},
									  {"Ibrahim","26","83","85","<p style='color:blue;background-color:whitesmoke'><u>Dua for Wisdom and Knowledge</u></p>This supplication of Prophet Ibrahim (AS) shows his concern for both his life and legacy. He asked Allah for wisdom and knowledge, to be counted among the righteous, to be remembered with honor by future generations, and ultimately to be granted Paradise. "},
									  {"Ibrahim","37","100","100","<p style='color:blue;background-color:whitesmoke'><u>Dua for a Righteous Offspring</u></p>"},
									  {"Ibrahim","60","4","5","<p style='color:blue;background-color:whitesmoke'><u>Dua for Faith</u></p>These verses highlight Prophet Ibrahim (AS) and his followers as exemplars of unwavering faith in the midst of a society immersed in idolatry."},
									  {"Lut","26","169","169","<p style='color:blue;background-color:whitesmoke'><u>Dua for Protection</u></p>This dua is made by Prophet Lut (AS) during a moment of heightened desperation and danger. He had been warning his people against their persistent immoral acts and rebellion against Allah, but they continued to reject his message and even threatened to expel him."},
									  {"Lut","29","30","30","<p style='color:blue;background-color:whitesmoke'><u>Dua for Help against Evil</u></p>This dua is made by Prophet Lut (AS) as he faced extreme rejection, mockery, and moral corruption from the people of his town."},
									  {"Yaqub","12","86","86","<p style='color:blue;background-color:whitesmoke'><u>Dua to Deal with Grief</u></p>This dua was spoken by Prophet Yaqub (AS) after enduring years of grief over the loss of his beloved son, Yusuf (AS). Despite the passage of time and deep sorrow, he maintains faith in Allah, choosing to express his pain only to Him. In the end, Allah answered the dua and exceeded Prophet Yaqub’s expectations. "},
									  {"Yousuf","12","33","33","<p style='color:blue;background-color:whitesmoke'><u>Dua to Avoid Sin</u></p>This dua is made by Prophet Yusuf (AS) when he is being relentlessly tempted by the wife of the Egyptian minister (and other women) who tried to seduce him. Despite his physical beauty and isolation, he chooses to uphold his chastity and obedience to Allah over giving in to sin."},
									  {"Yousuf","12","101","101","<p style='color:blue;background-color:whitesmoke'><u>Dua for Protection, to die as a Muslim</u></p>This dua is made by Prophet Yusuf (AS) at the height of his success and authority in Egypt. After enduring years of hardship—being betrayed by his brothers, sold into slavery, wrongfully imprisoned—he was finally reunited with his family and recognized for his wisdom and leadership. Yet, instead of basking in worldly success, he turns to Allah with humility:"},
									  {"Ayub","21","83","83","<p style='color:blue;background-color:whitesmoke'><u>Dua for Suffering & Illness</u></p>This heartfelt dua was made by Prophet Ayyub (AS) after experiencing long years of intense suffering. He lost his wealth, health, and children, yet he remained patient and unwavering in his faith."}};
	public CommonSearch(QuranDB qdb)
	{
		InitializeComponent();
		dB = qdb;
		progress = new Progress(progInd);

	}
	    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        string item = HttpUtility.UrlDecode(query["item"].ToString());
        
		switch(item)
		{
			case "Sujood":
				this.Title = "Sujood Verses";
				progress.ShowProgress();
				Verses = await dB.GetSujoodVerses();
				foreach (var _v in Verses)
				{
					_v.font = Preferences.Default.Get<string>("Font", "NotoArabic");
					_v.verse_arabic = _v.verse_arabic.Replace("۩", "");
					_v.verse_arabic_end = "۩";
				}
				lstView.ItemsSource = Verses;
				progress.HideProgress();
			break;
			default:
				this.Title = "Prophet Duas in the Quran";
				progress.ShowProgress();
				for(int p=0; p < duas.GetLength(0); p++)
				{
					var v = await dB.GetProphetDua(duas[p,0], Convert.ToInt32(duas[p,1]), Convert.ToInt32(duas[p, 2]), Convert.ToInt32(duas[p, 3]), duas[p,4]);
					foreach(var _v in v)
					{
						_v.font = Preferences.Default.Get<string>("Font", "NotoArabic");
						if (_v.verse_arabic.Contains("۩"))
						{
							_v.verse_arabic = _v.verse_arabic.Replace("۩", "");
							_v.verse_arabic_end = "۩";
						}
						Verses.Add(_v);
					}
				}
				lstView.ItemsSource = Verses;
				progress.HideProgress();
			break;
		}
    }
	/// <summary>
	/// when the form loads
	/// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();
		var screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
        lstView.IsVisible = true;
        lstView.HeightRequest = screenHeight - 200;
    }
}
using System.Web;
namespace QSearch;

[QueryProperty(nameof(item), "item")]
public partial class CommonSearch : ContentPage
{
	public string item{get;set;}
	 QuranDB dB;
	 List<Verse> Verses = new List<Verse>();
    Progress progress;
	string[,] duas = new string[45,6] {{"Adam","7","23","23","Dua for Forgiveness","When Adam (AS) and Hawwa (AS) disobeyed Allah by eating from the forbidden tree, they immediately repented with this heartfelt dua, showing humility, remorse, and recognition of Allah’s mercy."},
									  {"Nuh","11","41","41","Dua for Traveling","When Nuh (AS) boarded the ship."},
									  {"Nuh","11","47","47","Dua for Forgiveness","After asking Allah about saving his son from the flood, Allah reminded Nuh (AS) that his son was not among the righteous. Nuh (AS) immediately sought forgiveness, showing submission and repentance."},
									  {"Nuh","23","26","26","Dua for Adversity","After tirelessly calling his people to Allah for centuries, Prophet Nuh (AS) faced persistent rejection, ridicule, and denial from his community. In this moment of despair, he turned to Allah alone for support and vindication, showing that true help comes only from the Creator when human efforts are exhausted."},
									  {"Nuh","23","29","29","Dua for Traveling","After the flood, when the ark settled and the waters began to recede, Prophet Nuh (AS) made this dua, asking Allah for a safe and blessed place to disembark. It reflects gratitude, humility, and reliance on Allah after deliverance from a great trial."},
									  {"Nuh","54","10","10","Dua for Help","When the opposition of his people became overwhelming, Nuh (AS) turned to Allah, admitting his weakness and asking for divine help. This dua reflects total reliance on Allah’s power when human means were exhausted."},
									  {"Nuh","71","28","28","Dua for Forgiveness","After warning his people and being rejected, Nuh (AS) turned to Allah, asking for forgiveness for himself and the believers, showing the importance of including others in one’s prayers."},
									  {"Ibrahim","2","126","126","Dua for Security and Prosperity","Concerned for the sustenance of his family and community in the barren valley of Makkah, Ibrahim (AS) made dua and sought both worldly protection and provision for its land and people. A powerful dua that Allah answered as today Makkah has peace, stability and prosperity, especially when compared to its barren days during the times of Prophet Ibrahim (AS)."},
									  {"Ibrahim","2","127","127","Dua for Acceptance of Act","This dua was made by Prophet Ibrahim (AS) and his son Prophet Isma’il (AS) while raising the Ka'bah’s foundations by Allah’s command. Even in this moment of immense spiritual significance, they remained humble and prayerful."},
									  {"Ibrahim","2","128","128","Dua for Humble Submission","This dua follows immediately after Prophet Ibrahim (AS) and Prophet Isma’il (AS) began constructing the Ka'bah. While performing this sacred task, they turned to Allah not only for acceptance but for continued guidance and spiritual legacy."},
									  {"Ibrahim","3","173","173","Dua for Protection","This was said by Prophet Ibrahim (AS) when he was thrown into the fire by his people. Despite the extreme danger, he placed complete trust in Allah’s power and protection."},
									  {"Ibrahim","14","35","35","Dua for Prosperity","When Prophet Ibrahim (AS) returned to Makkah and found it an established, prosperous city, he prayed for its security and, more importantly, for protection from idol worship for himself and his children. His dua reflects foresight: recognizing that prosperity often leads people to arrogance, forgetfulness of Allah, and deviation from faith."},
									  {"Ibrahim","14","40","40","Dua for Steadfastness","In this heartfelt prayer, Prophet Ibrahim (AS) asked Allah for three profound blessings: to remain steadfast in establishing salah, that his offspring also uphold salah, and that his duas be accepted."},
									  {"Ibrahim","14","41","41","Dua for Forgiveness","Prophet Ibrahim (AS) sought Allah’s mercy for himself, his parents, and all believers, teaching that one’s concern in dua should extend beyond personal needs to the wider community or Ummah of believers."},
									  {"Ibrahim","26","83","85","Dua for Wisdom and Knowledge","This supplication of Prophet Ibrahim (AS) shows his concern for both his life and legacy. He asked Allah for wisdom and knowledge, to be counted among the righteous, to be remembered with honor by future generations, and ultimately to be granted Paradise. "},
									  {"Ibrahim","37","100","100","Dua for a Righteous Offspring",""},
									  {"Ibrahim","60","4","5","Dua for Faith","These verses highlight Prophet Ibrahim (AS) and his followers as exemplars of unwavering faith in the midst of a society immersed in idolatry."},
									  {"Lut","26","169","169","Dua for Protection","This dua is made by Prophet Lut (AS) during a moment of heightened desperation and danger. He had been warning his people against their persistent immoral acts and rebellion against Allah, but they continued to reject his message and even threatened to expel him."},
									  {"Lut","29","30","30","Dua for Help against Evil","This dua is made by Prophet Lut (AS) as he faced extreme rejection, mockery, and moral corruption from the people of his town."},
									  {"Yaqub","12","86","86","Dua to Deal with Grief","This dua was spoken by Prophet Yaqub (AS) after enduring years of grief over the loss of his beloved son, Yusuf (AS). Despite the passage of time and deep sorrow, he maintains faith in Allah, choosing to express his pain only to Him. In the end, Allah answered the dua and exceeded Prophet Yaqub’s expectations. "},
									  {"Yousuf","12","33","33","Dua to Avoid Sin","This dua is made by Prophet Yusuf (AS) when he is being relentlessly tempted by the wife of the Egyptian minister (and other women) who tried to seduce him. Despite his physical beauty and isolation, he chooses to uphold his chastity and obedience to Allah over giving in to sin."},
									  {"Yousuf","12","101","101","Dua for Protection, to die as a Muslim","This dua is made by Prophet Yusuf (AS) at the height of his success and authority in Egypt. After enduring years of hardship—being betrayed by his brothers, sold into slavery, wrongfully imprisoned—he was finally reunited with his family and recognized for his wisdom and leadership. Yet, instead of basking in worldly success, he turns to Allah with humility:"},
									  {"Ayub","21","83","83","Dua for Suffering & Illness","This heartfelt dua was made by Prophet Ayyub (AS) after experiencing long years of intense suffering. He lost his wealth, health, and children, yet he remained patient and unwavering in his faith."},
									  {"Shoaib","7","89","89","Dua for Protection","This dua is made by Prophet Shuaib (AS) during his mission to the people of Madyan, who were corrupt in trade and denied his message. After reasoning with them extensively, the people threatened to expel him and his followers unless they returned to their old ways."},
									  {"Shoaib","11","88","88","Dua for Success and Guidance","This statement comes from Prophet Shuaib (AS) as he addresses his people, the people of Madyan, who were known for dishonest business practices and arrogance. After calling them to righteousness and fair dealings, he was mocked and rejected."},
									  {"Musa","20","25","28","Dua for Confidence","These verses capture the dua of Prophet Musa (AS) when he was commanded by Allah to confront Pharaoh, one of the most powerful and oppressive rulers of his time. Musa (AS) expressed humility and concern over the magnitude of the mission, especially given his speech difficulty."},
									  {"Musa","28","16","16","Dua for Forgiveness","This dua was made by Prophet Musa (AS) after he inadvertently struck an Egyptian man while trying to stop a fight between him and an Israelite. The man died as a result, and Musa (AS) recognized that he had made a grave mistake. Fearing the consequences of his actions, he immediately turned to Allah in repentance."},
									  {"Musa","28","21","21","Dua for Protection from Evil","This dua was made by Prophet Musa (AS) after he fled from Egypt to escape the wrath of Pharaoh’s soldiers. Having accidentally killed an Egyptian man while trying to stop a fight, Musa (AS) feared retribution and decided to leave the city. As he traveled, he sought refuge in a new land, and this dua was a plea for protection from the unjust and oppressive people."},
									  {"Musa","28","24","24","Dua for Goodness","After fleeing Egypt, exhausted and alone as a fugitive on the run in Madyan, Prophet Musa (AS) saw two women struggling at a well. He helped them — expecting nothing in return. Then, whilst under a tree, he made a simple, heartfelt dua to Allah — with no demands, no specifics. Allah answered that dua and gave Prophet Musa (AS) more than he asked for: Food, a home, marriage and family, a job and eventually prophethood."},
									  {"Musa","7","151","151","Dua for Forgiveness and Mercy","This dua was made by Prophet Musa (AS) after the Israelites worshiped the golden calf in his absence. Prophet Harun (AS) had tried to restrain the people but was overpowered and ignored. When Musa (AS) returned and witnessed the transgression, he became angry but later turned to Allah with humility and sought forgiveness—not only for himself but also for his brother, Prophet Harun (AS)."},
									  {"Musa","7","126","126","Dua for Patience and to Die as a Muslim","This dua was made by the magicians of Pharaoh's court after they witnessed the truth of Prophet Musa’s (AS) message and believed in Allah. Despite Pharaoh’s threats to crucify them for abandoning their loyalty to him, they remained resolute in faith, eventually dying as faithful martyrs."},
									  {"Musa","7","155","155","Dua for Protection, Forgiveness and Mercy","This dua was made by Prophet Musa (AS) in regards to his people, the Israelites, after they had repeatedly disobeyed Allah, even after receiving His signs and guidance. When they suffered from a series of calamities as a result of their transgressions, Musa (AS) interceded on their behalf, pleading for Allah’s forgiveness and mercy."},
									  {"Dawood","2","250","250","Dua for Patience and Victory","This du'a was recited by the faithful soldiers of King Talut (Saul) as they stood before the battle against Jalut (Goliath)and his forces. The army had been greatly reduced in number due to a divine test, and only the most sincere believers remained.\n Soon after this dua was made, Prophet Dawud (AS) — then a young man in the army — stepped forward to challenge Jalut (Goliath) and slew him by Allah’s will. This marked his rise as a divinely favored leader and prophet."},
									  {"Suleman","27","19","19","Dua for Gratitude","This dua was made by Prophet Sulaiman (AS) after witnessing an extraordinary event: he understood the speech of an ant warning its colony to avoid harm from his approaching army. This incident reminded him of Allah’s immense favors—the gift of understanding animals, prophetic wisdom, and kingship."},
									  {"Suleman","38","35","35","Dua for Power and Wealth","This dua was made by Prophet Sulaiman (AS) after he was tested and repented to Allah for an earlier shortcoming. Some narrations mention he became momentarily distracted from his worship due to his love of fine horses, and he turned to Allah seeking forgiveness.\n In this powerful moment, Prophet Sulaiman (AS) asked Allah not only for forgiveness, but also for a unique and unmatched kingdom, one that no one else would ever possess after him."},
									  {"Younus","21","87","87","Dua for Forgiveness","This heartfelt dua was made by Prophet Yunus (AS) while he was in the belly of the great fish. He had left his people prematurely, frustrated by their rejection of his message, and boarded a ship. When a storm hit, he was thrown overboard and swallowed by the fish as a consequence of his action.\nInside the darkness—of the sea, the night, and the creature—Prophet Yunus sincerely repented, recognizing his mistake."},
									  {"Zakariya","21","89","89","Dua for a Heir","This dua was made by Prophet Zakariya (AS) during his old age. He and his wife were childless, and he longed for a righteous heir to continue the legacy of prophethood and guide the Children of Israel. Despite his advanced age and his wife's barrenness, he turned to Allah with sincere hope and humility, recognizing that Allah alone has the power to grant life."},
									  {"Zakariya","3","38","38","Dua for Pious Offspring","This heartfelt prayer was made by Prophet Zakariya (AS) when he saw Maryam (AS) receiving provisions (fresh fruits) from Allah in her sanctuary without anyone bringing them. This sign deeply moved him and inspired hope in Allah’s unlimited mercy and power.\nDespite his old age and his wife’s barrenness, Zakariya (AS) turned to Allah with full trust, asking not just for a child, but for a righteous and blessed offspring."},
									  {"Isa","3","114","114","Dua for Provision","This dua was made by Prophet Isa (AS)at the request of his disciples, who asked for a miraculous table spread with food from the heavens as a sign of reassurance and divine support.\n Prophet Isa (AS) made this dua, asking Allah to send down the table as a sign, a source of celebration, and sustenance for all – both those present and those to come."},
									  {"Muhammad","2","201","201","Dua for Goodness",""},
									  {"Muhammad","3","173","173","Dua of Trust","It was famously recited by the prophet Muhammad (SAW) like his grandfather Ibrahim(AS)."},
									  {"Muhammad","20","114","114","Dua for Increased Knowledge",""},
									  {"Muhammad","23","118","118","Dua for Forgiveness",""},
									  {"Muhammad","113","1","1","Dua for Protection from Evil","When prophet Muhammad(SAW) was afflicted with magic, this was revealed to neautralize sorcery."},
									  {"Muhammad","114","1","1","Dua for Protection from Evil","When prophet Muhammad(SAW) was afflicted with magic, this was revealed to neautralize sorcery."}};
	public CommonSearch()
	{
		InitializeComponent();
		progress = new Progress(progInd);
	}
	public CommonSearch(QuranDB qdb)
	{
		InitializeComponent();
		dB = qdb;
		progress = new Progress(progInd);
	}   
	public static readonly BindableProperty ItemProperty = 
	BindableProperty.Create("Item", typeof(string), typeof(CommonSearch));

	public string Item
	{
		get => (string)GetValue(ItemProperty);
		set => SetValue(ItemProperty, value);
	}
	//     public async void ApplyQueryAttributes(IDictionary<string, object> query)
    // {
    //     string item = HttpUtility.UrlDecode(query["item"].ToString());
	// 	progress.ShowProgress();
    //     await Task.Delay(50);
	// 	switch(item)
	// 	{
	// 		case "Sujood":
	// 			this.Title = "Sujood Verses";
	// 			Verses = await dB.GetSujoodVerses();
	// 			foreach (var _v in Verses)
	// 			{
	// 				_v.font = Preferences.Default.Get<string>("Font", "NotoArabic");
	// 				_v.verse_arabic = _v.verse_arabic.Replace("۩", "");
	// 				_v.verse_arabic_end = "۩";
	// 				// height of header //
	// 				_v.number = 120;
	// 			}
	// 		break;
	// 		default:
	// 			this.Title = "Prophet Duas in the Quran";
	// 			progress.ShowProgress();
	// 			int _vcount = 0;
	// 			for(int p=0; p < duas.GetLength(0); p++)
	// 			{
	// 				var v = await dB.GetProphetDua(duas[p,0], Convert.ToInt32(duas[p,1]), Convert.ToInt32(duas[p, 2]), Convert.ToInt32(duas[p, 3]), duas[p,4], duas[p,5]);
	// 				_vcount = 1;
	// 				foreach(var _v in v)
	// 				{
	// 					_v.font = Preferences.Default.Get<string>("Font", "NotoArabic");
	// 					// height of header //
	// 					_v.number = 125;
	// 					if (_v.verse_arabic.Contains("۩"))
	// 					{
	// 						_v.verse_arabic = _v.verse_arabic.Replace("۩", "");
	// 						_v.verse_arabic_end = "۩";
	// 					}
	// 					// combine multiple verses as one unit
	// 					if (v.Count > 1)
	// 					{
	// 					    if (_vcount == 1) Verses.Add(_v);
	// 						else
	// 						{
	// 							Verses[Verses.Count - 1].verse_arabic += "\n" + _v.verse_arabic;
	// 							Verses[Verses.Count - 1].verse_english += "\n" + _v.verse_english;
	// 							Verses[Verses.Count - 1].verse_arabic_end +=  _v.verse_arabic_end;
	// 						}
	// 						_vcount++;
	// 					}
	// 					else 
	// 						Verses.Add(_v);
	// 				}
	// 			}
	// 		break;
	// 	}
	// 	lstView.ItemsSource = Verses;
	// 	progress.HideProgress();
    // }
	/// <summary>
	/// when the form loads
	/// </summary>
    protected override async void OnAppearing()
    {
        base.OnAppearing();
		var screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;
        lstView.IsVisible = true;
        lstView.HeightRequest = screenHeight - 200;
		progress.ShowProgress();
		if (Item == "Sujood")
		{
				await Task.Delay(100);
				this.Title = "Sujood Verses";
				dB = new QuranDB();
				Verses = await dB.GetSujoodVerses();
				foreach (var _v in Verses)
				{
					_v.font = Preferences.Default.Get<string>("Font", "NotoArabic");
					_v.verse_arabic = _v.verse_arabic.Replace("۩", "");
					_v.verse_arabic_end = "۩";
					// height of header //
					_v.number = 120;
				}	
				lstView.HeightRequest = screenHeight - 150;
		}
		else
		{
				await Task.Delay(25);
				this.Title = "Prophet Duas in the Quran";
				dB = new QuranDB();

				int _vcount = 0;
				for(int p=0; p < duas.GetLength(0); p++)
				{
					var v = await dB.GetProphetDua(duas[p,0], Convert.ToInt32(duas[p,1]), Convert.ToInt32(duas[p, 2]), Convert.ToInt32(duas[p, 3]), duas[p,4], duas[p,5]);
					_vcount = 1;
					foreach(var _v in v)
					{
						_v.font = Preferences.Default.Get<string>("Font", "NotoArabic");
						// height of header //
						_v.number = 125;
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
							}
							_vcount++;
						}
						else 
							Verses.Add(_v);
					}
				}
		}
		lstView.ItemsSource = Verses;
		progress.HideProgress();
    }
}
namespace QSearch
{
    /// <summary>
    /// quranic verse model
    /// </summary>
    public class Verse
    {

        public int number { get; set; }
        public int para_number { get; set; }
        public string para_name { get; set; }
        public int chapter_number { get; set; }
        public string verse_arabic { get; set; }
        public string verse_english { get; set; }
        public string verse_arabic_clean { get; set; }
        public string verse_urdu { get; set; }
        public string chapter_name_arabic { get; set; }
        public string chapter_name_english { get; set; }
        public string class_arabic { get; set; }
        public string class_english { get; set; }
        public string alternative_words { get; set; }
        public string font { get; set; }
        // for storing sujood mark ///
        public string verse_arabic_end { get; set;}
        public string prophet {get;set;}
        public string title {get;set;}
        public string tafsir {get;set; }
        public string translation_ref {get;set;}
        public string english_ref {get;set;}
        public string urdu_ref {get;set;}
        public bool showEnglish { get; set; }
        public bool showUrdu { get; set; }
    }
    /// <summary>
    /// picking the surah
    /// </summary>
    public class Surah
    {
        public int chapter_number { get; set; }
        public string chapter_name_arabic { get; set; }
        public string chapter_name_english { get; set; }
        public int total_verses {get;set;}
    }
    /// <summary>
    /// picking the para
    /// </summary>
    public class Para
    {
        public int para_number { get; set; }
        public string para_name { get; set; }
    }

    /// <summary>
    /// a class to return a surah
    /// </summary>
    public class ReciteSurah
    {
        public int para_number { get; set; }
        public string para_name { get; set; }
        public string verse_arabic { get; set; }

        public string verse_english { get; set; }
        public string english_ref { get; set; }
        public string verse_urdu { get; set; }
        public string urdu_ref { get; set; }

        public string[] verse_arabic_lines { get; set; } = new string[25];
        public string[] verse_translation_lines { get; set; } = new string[25];
        public string[] verse_arabic_lines_number { get; set; } = new string[25];
        public string[] verse_arabic_line_end { get; set; } = new string[25];
        public string[] translation_ref_lines { get; set; } = new string[25];
        public int chapter_number { get; set; }
        public string chapter_name_arabic { get; set; }
        public string class_arabic { get; set; }
        public int total_verses { get; set; }
        public int total_verses_para { get; set; }
        public string font { get; set; }
        public string[] showLine { get; set; } = new string[25];
    }
    /// <summary>
    /// Class for grouping by surahs for a para
    /// </summary>
    public class GroupedSurah : List<ReciteSurah>
    {
        public int page_no { get; set; }

        public int chapter_number{ get; set; }
        public string chapter_name { get; set; }
        public int para_no { get; set; }
        public string para_name { get; set; }
        public string chapter_class { get; set; }
        public int total_verses { get; set; }
        public int total_verses_para { get; set; }
        public GroupedSurah(string name, int pg, IList<ReciteSurah> surahs) : base(surahs)
        {
            page_no = pg;
            chapter_name = name;
            chapter_number = surahs[0].chapter_number;
            para_no = surahs[0].para_number;
            para_name = surahs[0].para_name;
            chapter_class = surahs[0].class_arabic;
            total_verses = surahs[0].total_verses;
            total_verses_para = surahs[0].total_verses_para;
        }
    }
}

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
        public string chapter_name_arabic { get; set; }
        public string chapter_name_english { get; set; }
        public string class_arabic { get; set; }
        public string class_english { get; set; }
        public string alternative_words { get; set; }
    }
    /// <summary>
    /// picking the surah
    /// </summary>
    public class Surah
    {
        public int chapter_number { get; set; }
        public string chapter_name_arabic { get; set; }
        public string chapter_name_english { get; set; }
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
        public int chapter_number { get; set; }
        public string chapter_name_arabic { get; set; }
        public string class_arabic { get; set; }
        public int total_verses { get; set; }
    }
    /// <summary>
    /// Class for grouping by surahs for a para
    /// </summary>
    public class GroupedSurah : List<ReciteSurah>
    {
        public int page_no { get; set; }
        public string chapter_name { get; set; }
        public int para_no { get; set; }
        public string para_name { get; set; }
        public string chapter_class { get; set; }
        public int total_verses { get; set; }
        public GroupedSurah(string name, int pg, List<ReciteSurah> surahs) :base(surahs)
        {
            page_no = pg;
            chapter_name = name;
            if (surahs.Count > 0)
            {
                para_no = surahs[0].para_number;
                para_name = surahs[0].para_name;
                chapter_class = surahs[0].class_arabic;
                total_verses = surahs[0].total_verses;
            }
        }
    }
}

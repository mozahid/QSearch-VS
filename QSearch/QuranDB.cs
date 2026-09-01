
using SQLite;

namespace QSearch
{
	public class QuranDB
	{
        SQLiteAsyncConnection QDB;
        public string[] prepositions = { "of", "in", "at", "by", "on" };
		public QuranDB()
		{
            if (QDB is not null)
                return;
            QDB = new SQLiteAsyncConnection(DBConstants.DatabasePath, DBConstants.Flags);
            // var options = new SQLiteConnectionString(DBConstants.DatabasePath, true, "S@la@m", postKeyAction: c => 
            //     {
            //         c.Execute("PRAGMA cipher_compatibility = 3");
            //         c.Execute("PRAGMA cipher_page_size = 4096");
            //     }
            // );
            //QDB = new SQLiteAsyncConnection(options);
        }
        /// <summary>
        ///  re-init the DB connection
        /// </summary>
        /// <returns></returns>
        public SQLiteAsyncConnection Init()
        {
            if (QDB is not null)
                return QDB;

            QDB = new SQLiteAsyncConnection(DBConstants.DatabasePath, DBConstants.Flags);
            // var options = new SQLiteConnectionString(DBConstants.DatabasePath, true, "S@la@m", postKeyAction: c => 
            //     {
            //         c.Execute("PRAGMA cipher_compatibility = 3");
            //         c.Execute("PRAGMA cipher_page_size = 4096");
            //     }
            // );
            //QDB = new SQLiteAsyncConnection(options);
            return QDB;
        }
        /// <summary>
        /// retrieve the whole verses
        /// </summary>
        /// <returns></returns>
        public async Task<List<Verse>> GetVersesAsync()
        {
            Init();
            List<Verse> rset = await QDB.QueryAsync<Verse>("SELECT * FROM verses");
            return rset;
        }
        /// <summary>
        /// search a verse by number
        /// </summary>
        /// <param name="verseNumber"></param>
        /// <returns></returns>
        public async Task<Verse> GetVerseAsync(int verseNumber)
        {
            Init();
            object[] p = { verseNumber };
            string query = "with QS as (SELECT number, verse_english, english_ref,verse_urdu,urdu_ref FROM QSearch WHERE number == ?) ";
            query += "SELECT verses.*,verse_english,english_ref FROM verses inner join QS on verses.number = CAST(QS.number AS INTEGER) ORDER BY verses.number";
            List<Verse> rset = await QDB.QueryAsync<Verse>(query, p);
            return rset.FirstOrDefault();
        }
        /// <summary>
        /// search a verse by a search string
        /// </summary>
        /// <param name="srch"></param>
        /// <returns></returns>
        public async Task<List<Verse>> GetVerseAsync(string srch)
        {
            Init();
            // using full text search //
            object[] p = { srch + "*"};
            string query = "with QS as (SELECT number, verse_english, english_ref,verse_urdu,urdu_ref FROM QSearch WHERE QSearch match ?) ";
            query += "SELECT verses.*,verse_english,english_ref,verse_urdu,urdu_ref FROM verses inner join QS on verses.number = CAST(QS.number AS INTEGER) ORDER BY verses.number";
            List<Verse> rset = await QDB.QueryAsync<Verse>(query, p);
            return rset;
        }
        /// <summary>
        /// search a verse by a search string
        /// </summary>
        /// <param name="srch"></param>
        /// <returns></returns>
        public async Task<List<Verse>> GetVerseExactAsync(string srch)
        {
            Init();
            object[] p = { srch};
            string query = "with QS as (SELECT number, verse_english, english_ref,verse_urdu,urdu_ref FROM QSearch WHERE QSearch match ?) ";
            query += "SELECT verses.*,verse_english,english_ref,verse_urdu,urdu_ref FROM verses inner join QS on verses.number = CAST(QS.number AS INTEGER) ORDER BY verses.number";
            List<Verse> rset = await QDB.QueryAsync<Verse>(query, p);
          
            return rset;
        }
        /// <summary>
        /// if arabic input search
        /// </summary>
        /// <param name="srch"></param>
        /// <returns></returns>
        public async Task<List<Verse>> GetArabicVerseAsync(string srch)
        {
            Init();
            // use full text search
            object[] p = {"*" + srch + "*"};
            string query = "with QS as (SELECT number, verse_english, verse_arabic_clean, english_ref,verse_urdu,urdu_ref FROM QSearch WHERE verse_arabic_clean GLOB ?) ";
            query += "SELECT verses.*, verse_english, verse_arabic_clean, english_ref, verse_urdu, urdu_ref FROM verses inner join QS on verses.number = CAST(QS.number AS INTEGER) ORDER BY verses.number";
            List<Verse> rset = await QDB.QueryAsync<Verse>(query, p);

            return rset;
        }
        /// <summary>
        /// Urdu search for a verse by a search string
        /// </summary>
        /// <param name="srch"></param>
        /// <returns></returns>
        public async Task<List<Verse>> GetUrduVerseAsync(string srch)
        {
            Init();
            // use full text search
            object[] p = {"*" + srch + "*"};
            string query = "with QS as (SELECT number, verse_english, verse_arabic_clean, english_ref,verse_urdu,urdu_ref FROM QSearch WHERE verse_urdu GLOB ?) ";
            query += "SELECT verses.*, verse_english, verse_arabic_clean, english_ref, verse_urdu, urdu_ref FROM verses inner join QS on verses.number = CAST(QS.number AS INTEGER) ORDER BY verses.number";
            List<Verse> rset = await QDB.QueryAsync<Verse>(query, p);

            return rset;
        }
        /// <summary>
        /// retrieve all sujood verses only
        /// </summary>
        /// <returns></returns>
        public async Task<List<Verse>> GetSujoodVerses()
        {
            Init();
            object[] p = {"*" +  "۩" + "*"};
            List<Verse> rset = await QDB.QueryAsync<Verse>("SELECT verses.*, QSearch.verse_english, QSearch.english_ref,QSearch.verse_urdu,QSearch.urdu_ref FROM verses inner join QSearch on CAST(QSearch.number AS INTEGER) = verses.number WHERE verses.verse_arabic GLOB ? ", p);

            return rset;
        }
        /// <summary>
        /// used for duas, sakina verses
        /// </summary>
        /// <param name="ref_type"></param>
        /// <returns></returns>
        public async Task<List<Verse_Ref>> GetVerseRef(string ref_type)
        {
            Init();
            object[] p = { ref_type};

            string query = "SELECT * from verse_ref WHERE ref_type = ? ";
            query += "ORDER BY id, chapter_number, verse_start";
            List<Verse_Ref> rset = await QDB.QueryAsync<Verse_Ref>(query, p);
            return rset;
        }
        /// <summary>
        /// Prophet dua in a given chapter 
        /// </summary>
        /// <param name="chapter"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public async Task<List<Verse>> GetProphetDua(string prophet,int chapter, int from, int to,string title, string tafsir, int selectedLanguage)
        {
            Init();
            object[] p = { chapter, from, to };
            string query = "SELECT verses.*, QSearch.verse_english, QSearch.english_ref,QSearch.verse_urdu,QSearch.urdu_ref FROM verses inner join QSearch on CAST(QSearch.number AS INTEGER) = verses.number ";
            query += "WHERE verses.chapter_number = ? and verses.verse_number between ? and ? ";

            List<Verse> rset = await QDB.QueryAsync<Verse>(query, p);
            foreach(Verse v in rset)
            {
                v.header = "Dua of " + prophet + (prophet == "Muhammad" ? " (SAW)" : " (AS)");
                v.title = title;
                switch(selectedLanguage)
                {
                    case 1:
                        v.translation = v.verse_english;
                        v.translation_ref = v.english_ref;
                        v.font_translation = "Tahoma";
                        break;
                    case 2:
                        v.translation = v.verse_urdu;
                        v.translation_ref = v.urdu_ref;
                        v.font_translation = "Urdu";
                        break;  
                }
                v.tafsir = tafsir;
                //v.translation_ref = prophet == "Muhammad" ? "" : "duasofprophets.com";
            }
                
            return rset;
  
        }
        /// <summary>
        /// Sakina verses for tranquility and mental peace
        /// </summary>
        ///     
        /// <returns></returns>
        public async Task<List<Verse>> GetSakinaVerses(string header, int chapter, int from, int to, string title, string tafsir)
        {
            Init();
            object[] p = { chapter, from, to };
            string query = "SELECT verses.*, QSearch.verse_english, QSearch.english_ref,QSearch.verse_urdu,QSearch.urdu_ref FROM verses inner join QSearch on CAST(QSearch.number AS INTEGER) = verses.number ";
            query += "WHERE verses.chapter_number = ? and verses.verse_number between ? and ? ";

            List<Verse> rset = await QDB.QueryAsync<Verse>(query, p);
            foreach(Verse v in rset)
            {
                v.header = header;
                v.title = title;
                v.tafsir = tafsir;
            }
                
            return rset;
  
        }
        /// <summary>
        /// multiple word search in english translation, excluding prepositions
        /// </summary>
        /// <param name="srch"></param>
        /// <returns></returns>
        public async Task<List<Verse>> GetVerseAsync(string[] srch)
        {
            Init();
            int word_count = 0;
            for (int i = 0; i < srch.Length; i++)
                if (!prepositions.Contains(srch[i]))
                    word_count += 1;
            object[] p = new object[1 + word_count];
            word_count = 0;
            string query = "SELECT verses.*, QSearch.verse_english, QSearch.english_ref,QSearch.verse_urdu,QSearch.urdu_ref FROM verses inner join QSearch on CAST(QSearch.number AS INTEGER) = verses.number WHERE verses.number in ";
            query += "(SELECT number from QSearch WHERE verse_english match ? ";
            for (int i = 0; i < srch.Length; i++)
            {
                // exclude prepositions from search //
                if (!prepositions.Contains(srch[i]))
                {
                    p[0] += srch[i] + " ";
                    p[word_count + 1] += srch[i];
                    query += "OR alternative_words match ? ";
                    word_count += 1;
                }
            }
            query += ") ";
            List<Verse> rset = await QDB.QueryAsync<Verse>(query, p);
            return rset;
        }
        /// <summary>
        /// arabic search for multiple words
        /// </summary>
        /// <param name="srch"></param>
        /// <returns></returns>
         public async Task<List<Verse>> GetArabicVerseAsync(string[] srch, string option)
        {
            Init();
            object[] p = new object[1];
            string query = String.Empty;
            switch(option)
            {
                case "Single":
                        p[0] = "";
                        query = "SELECT verses.*, verse_english, verse_arabic_clean, english_ref,verse_urdu,urdu_ref FROM verses inner join QSearch on verses.number = QSearch.number WHERE QSearch.verse_arabic_clean match ? ";
                        for (int i=0; i < srch.Length; i++)
                            p[0] += srch[i] + " "; 
                        break;
                case "Multiple":
                        // if search for all words in a multiple words ////
                        p = new object[srch.Length];
                        p[0] = "";
                        query = "SELECT verses.*, verse_english, verse_arabic_clean, english_ref,verse_urdu,urdu_ref FROM verses inner join QSearch on CAST(QSearch.number AS INTEGER) = verses.number WHERE verses.number in (SELECT number FROM QSearch WHERE  ";
                        for (int i=0; i < srch.Length; i++)
                        {
                            query += "verse_arabic_clean match ? ";
                            p[i] = srch[i];
                            if (i < srch.Length - 1)
                                query += "OR ";
                        }
                        query += ") ";
                    break;
                default:
                    break;
            }
            List<Verse> rset = await QDB.QueryAsync<Verse>(query, p);
            return rset;
        }
        /// <summary>
        /// multiple word search in urdu translation
        /// </summary>
        /// <param name="srch"></param>
        /// <returns></returns>
        public async Task<List<Verse>> GetUrduVerseAsync(string[] srch)
        {
            Init();
            //  search FTS //
            object[] p = new object[1];
            p[0] = "";
            string query = "SELECT verses.*, verse_english, verse_arabic_clean, english_ref,verse_urdu,urdu_ref FROM verses inner join QSearch on CAST(QSearch.number AS INTEGER) = verses.number WHERE verses.number in (SELECT number FROM QSearch WHERE verse_urdu match ?) ";
            for (int i=0; i < srch.Length; i++)
                p[0] += srch[i] + " "; 
            List<Verse> rset = await QDB.QueryAsync<Verse>(query, p);
            return rset;
        }
        /// <summary>
        /// list of all surahs
        /// </summary>
        /// <returns></returns>
        public async Task<List<Surah>> GetSurahList()
        {
            Init();
            object[] p = { };
            List<Surah> surahs = await QDB.QueryAsync<Surah>("SELECT chapter_number, chapter_name_arabic, chapter_name_english, total_verses FROM verses GROUP BY chapter_number, chapter_name_arabic, chapter_name_english, total_verses ORDER BY chapter_number", p);
            foreach(var s in surahs)
            {
                s.chapter_name_arabic = s.chapter_name_arabic + " (" + s.chapter_name_english + ")";
            }    
            return surahs;
        }

        /// <summary>
        /// list of all para
        /// </summary>
        /// <returns></returns>
        public async Task<List<Para>> GetParaList()
        {
            Init();
            object[] p = { };
            List<Para> parahs = await QDB.QueryAsync<Para>("SELECT para_number, para_name FROM verses GROUP BY para_number, para_name ORDER BY para_number", p);  
            return parahs;
        }
        /// <summary>
        /// return total verses in a chapter
        /// </summary>
        /// <param name="chapter_number"></param>
        /// <returns></returns>
        public async Task<int> GetSurahVerseCount(int chapter_number)
        {
            Init();
            object[] p = { chapter_number};
            return await QDB.ExecuteScalarAsync<int>("SELECT total_verses FROM verses WHERE chapter_number = ?", p);
        }                                  
        /// <summary>
        /// search a a surah by number
        /// </summary>
        /// <param name="chapter_number"></param>
        /// <returns></returns>
        public async Task<List<QuranicVerse>> GetSurahByNumber(int chapter_number)
        {
            Init();
            object[] p = { chapter_number };
            string query = "SELECT verses.para_number, verses.para_name, verses.number, verses.chapter_name_arabic, verses.verse_arabic, QSearch.verse_english, QSearch.verse_urdu, verses.class_arabic, verses.total_verses, verses.chapter_number, QSearch.english_ref,QSearch.urdu_ref FROM verses ";
            query += "inner join QSearch on CAST(QSearch.number AS INTEGER) = verses.number ";
            query += "WHERE verses.chapter_number = ? ";
            query += "GROUP BY verses.para_number, verses.para_name, verses.chapter_name_arabic, verses.number, verses.verse_arabic, QSearch.verse_english, QSearch.verse_urdu, verses.class_arabic, verses.total_verses, verses.chapter_number, QSearch.english_ref,QSearch.urdu_ref ";
            query += "ORDER BY verses.para_number, verses.number";

            List<QuranicVerse> rset = await QDB.QueryAsync<QuranicVerse>(query, p);
            return rset;
        }
        /// <summary>
        /// get surah from and to verses
        /// </summary>
        /// <param name="chapter_number"></param>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <returns></returns>
        public async Task<List<QuranicVerse>> GetSurahByNumberAndVerses(int chapter_number, int From, int To)
        {
            Init();
            object[] p = { chapter_number, From, To };
            string query = "SELECT verses.para_number, verses.para_name, verses.number, verses.chapter_name_arabic, verses.verse_arabic, QSearch.verse_english, QSearch.verse_urdu, verses.class_arabic, verses.total_verses, verses.chapter_number, QSearch.english_ref,QSearch.urdu_ref FROM verses ";
            query += "inner join QSearch on CAST(QSearch.number AS INTEGER) = verses.number ";
            query += "WHERE verses.chapter_number = ? and verses.verse_number between ? and ? ";
            query += "GROUP BY verses.para_number, verses.para_name, verses.number, verses.chapter_name_arabic, verses.verse_arabic, QSearch.verse_english, QSearch.verse_urdu, verses.class_arabic, verses.total_verses, verses.chapter_number, QSearch.english_ref,QSearch.urdu_ref ";
            query += "ORDER BY verses.para_number, verses.number";

            List<QuranicVerse> rset = await QDB.QueryAsync<QuranicVerse>(query, p);
            return rset;
        }
        /// <summary>
        /// search a a para by number
        /// </summary>
        /// <param name="para_number"></param>
        /// <returns></returns>
        public async Task<List<QuranicVerse>> GetParaByNumber(int para_number)
        {
            Init();
            object[] p = { para_number };
            string query = "SELECT verses.para_number, verses.para_name, verses.number, verses.chapter_number, verses.chapter_name_arabic, verses.verse_arabic, QSearch.verse_english, QSearch.verse_urdu, verses.class_arabic, verses.total_verses, QSearch.english_ref,QSearch.urdu_ref FROM verses ";
            query += "inner join QSearch on CAST(QSearch.number AS INTEGER) = verses.number ";
            query += "WHERE verses.para_number = ? ";
            query += "GROUP BY verses.para_number, verses.para_name, verses.number, verses.chapter_number, verses.chapter_name_arabic, verses.verse_arabic, QSearch.verse_english, QSearch.verse_urdu, verses.class_arabic, verses.total_verses, QSearch.english_ref,QSearch.urdu_ref ";
            query += "ORDER BY verses.number, verses.para_number, verses.chapter_number";

            List<QuranicVerse> rset = await QDB.QueryAsync<QuranicVerse>(query, p);
            return rset;
        }

        ///////// Quran Statistics //////
        public async Task<int> GetTotalPara()
        {
            Init();
            object[] p = {};
            string query = "SELECT COUNT(*) FROM verses ";
            query += "GROUP BY para_number ";

            var _t = await QDB.QueryScalarsAsync<int>(query, p);
            return _t.Count();
        }

        public async Task<int> GetTotalSurah()
        {
            Init();
            object[] p = { };
            string query = "SELECT COUNT(*) FROM verses ";
            query += "GROUP BY chapter_number ";

            var _t = await QDB.QueryScalarsAsync<int>(query, p);
            return _t.Count();
        }

        public async Task<int> GetTotalLines()
        {
            Init();
            object[] p = { };
            string query = "SELECT COUNT(*) FROM verses ";

            var _t = await QDB.ExecuteScalarAsync<int>(query, p);
            return _t;
        }

        public async Task<int> GetTotalSujood()
        {
            Init();
            object[] p = { };
            string query = "SELECT COUNT(*) FROM verses ";
            query += "WHERE verse_arabic LIKE '%۩%'";

            var _t = await QDB.ExecuteScalarAsync<int>(query, p);
            return _t;
        }

        public async Task<int> GetTotalMakki()
        {
            Init();
            object[] p = { };
            string query = "SELECT COUNT(chapter_number) FROM verses ";
            query += "WHERE class_english = 'Makki'";
            query += "GROUP BY chapter_number";

            var _t = await QDB.QueryScalarsAsync<int>(query, p);
            return _t.Count();
        }

        public async Task<int> GetTotalMadni()
        {
            Init();
            object[] p = { };
            string query = "SELECT COUNT(chapter_number) FROM verses ";
            query += "WHERE class_english = 'Madni'";
            query += "GROUP BY chapter_number";

            var _t = await QDB.QueryScalarsAsync<int>(query, p);
            return _t.Count();
        }
        /// <summary>
        /// total words in the quran, excluding prepositions
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTotalWords()
        {
            Init();
            object[] p = { };
            string query = "SELECT SUM(total_words_arabic) FROM verses ";

            var _t = await QDB.ExecuteScalarAsync<int>(query, p);
            return _t;
        }
        /// <summary>
        /// Total Ruku which are cycles
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTotalRuku()
        {
            Init();
            object[] p = { };
            string query = "SELECT SUM(ruku_count) FROM verse_stat ";

            var _t = await QDB.ExecuteScalarAsync<int>(query, p);
            return _t;
        }

        ///////////////// QURAN STATISTICS/////////////////////
        /// <!--Get Asma Husana-->
        /// <returns></returns>
        public async Task<List<Asma>> GetAsmaHusana()
        {
            Init();
            object[] p = { };
            string query = "SELECT * FROM asma ORDER BY number";
            List<Asma> rset = await QDB.QueryAsync<Asma>(query, p);
            return rset;    
        }
    }
}


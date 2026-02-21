using System;
using SQLite;
using System.Data;
using System.Security.Cryptography.X509Certificates;

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
            List<Verse> rset = await QDB.QueryAsync<Verse>("SELECT * FROM verses WHERE NUMBER == ?", p);
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
            //object[] p = {"%" + srch + "%", "%" + srch + "%" };
            //List<Verse> rset = await QDB.QueryAsync<Verse>("SELECT * FROM verses WHERE verse_english LIKE ? OR alternative_words LIKE ?", p);
            // using full text search //
            object[] p = { srch + "*", srch + "*"};
            List<Verse> rset = await QDB.QueryAsync<Verse>("SELECT * FROM verses where number in (SELECT number FROM QSearch WHERE verse_english match ? OR alternative_words match ?)", p);
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
            //object[] p = {"% " + srch + " %" };
            //List<Verse> rset = await QDB.QueryAsync<Verse>("SELECT * FROM verses WHERE verse_english LIKE ?", p);
            object[] p = { srch, srch};
            List<Verse> rset = await QDB.QueryAsync<Verse>("SELECT * FROM verses where number in (SELECT number FROM QSearch WHERE verse_english match ? OR alternative_words match ?)", p);
          
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
            //var b = System.Text.Encoding.Default.GetBytes(srch);
            //object[] p = { "*" + srch + "*"};
            //List<Verse> rset = await QDB.QueryAsync<Verse>("SELECT * FROM verses WHERE verse_arabic_clean GLOB ?", p);
            // use full text search
            object[] p = {"*" + srch + "*"};
            List<Verse> rset = await QDB.QueryAsync<Verse>("SELECT verses.*, verse_arabic_clean FROM verses inner join QSearch on verses.number = QSearch.number WHERE QSearch.verse_arabic_clean GLOB ? ", p);

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
            List<Verse> rset = await QDB.QueryAsync<Verse>("SELECT * FROM verses WHERE verse_arabic GLOB ?", p);

            return rset;
        }
        /// <summary>
        /// Prophet dua in a given chapter 
        /// </summary>
        /// <param name="chapter"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public async Task<List<Verse>> GetProphetDua(string prophet, int chapter, int from, int to, string tafsir)
        {
            Init();
            object[] p = { chapter, from, to };
            string query = "SELECT * FROM verses ";
            query += "WHERE chapter_number = ? and verse_number between ? and ? ";

            List<Verse> rset = await QDB.QueryAsync<Verse>(query, p);
            foreach(Verse v in rset)
            {
                v.prophet = "Dua of " + prophet + " (AS)";
                v.tafsir = tafsir;
            }
                
            return rset;
  
        }
        /// <summary>
        /// search a verse by a search string having multiple words
        /// </summary>
        /// <param name="srch"></param>
        /// <returns></returns>
        // public async Task<List<Verse>> GetVerseAsync(string[] srch)
        // {
        //     Init();
        //     object[] p = new object[srch.Length * 2];
        //     string query = "SELECT * FROM verses WHERE verse_english ";
        //     query += "LIKE ";
        //     for (int i = 0; i < srch.Length; i++)
        //     {
        //         query += "? ";
        //         p[i] = "%" + srch[i] + "%";
        //         if (i < srch.Length - 1)
        //         {
        //             query += " OR verse_english LIKE ";
        //         }
        //     }

        //     query += " OR alternative_words LIKE ";
        //     for (int i = srch.Length; i < srch.Length * 2; i++)
        //     {
        //         query += "? ";
        //         p[i] = "%" + srch[i - srch.Length] + " %";
        //         if (i < (srch.Length * 2 - 1))
        //         {
        //             query += " OR alternative_words LIKE ";
        //         }
        //     }
        //     query += " ";
        //     List<Verse> rset = await QDB.QueryAsync<Verse>(query, p);
        //     return rset;
        // }
        public async Task<List<Verse>> GetVerseAsync(string[] srch)
        {
            Init();
            int word_count = 0;
            for (int i = 0; i < srch.Length; i++)
                if (!prepositions.Contains(srch[i]))
                    word_count += 1;
            object[] p = new object[1 + word_count];
            word_count = 0;
            string query = "SELECT * FROM verses WHERE number in ";
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
         public async Task<List<Verse>> GetArabicVerseAsync(string[] srch)
        {
            Init();
            // object[] p = new object[srch.Length];
            // string query = "SELECT * FROM verses WHERE verse_arabic_clean ";
            // query += "GLOB ";
            // for (int i = 0; i < srch.Length; i++)
            // {
            //     query += "? ";
            //     p[i] = "*" + srch[i] + "*";
            //     if (i < srch.Length - 1)
            //     {
            //         query += " OR verse_arabic_clean GLOB ";
            //     }
            // }
            //  search FTS //
            object[] p = new object[1];
            p[0] = "";
            string query = "SELECT verses.*, verse_arabic_clean FROM verses inner join QSearch on verses.number = QSearch.number WHERE QSearch.verse_arabic_clean match ? ";
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
            //foreach(var _p in parahs)
            //{
                //_p.para_name = _p.para_name + " (" + _p.para_number.ToString() + ")";
                //_p.para_name = _p.para_name;
            //}    
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
        public async Task<List<ReciteSurah>> GetSurahByNumber(int chapter_number)
        {
            Init();
            object[] p = { chapter_number };
            string query = "SELECT para_number, para_name, chapter_name_arabic, verse_arabic, verse_english, class_arabic, total_verses, chapter_number FROM verses ";
            query += "WHERE chapter_number = ? ";
            query += "GROUP BY para_number, para_name, chapter_name_arabic, verse_arabic, verse_english, class_arabic, total_verses, chapter_number ";
            query += "ORDER BY para_number, number";

            List<ReciteSurah> rset = await QDB.QueryAsync<ReciteSurah>(query, p);
            return rset;
        }
        /// <summary>
        /// get surah from and to verses
        /// </summary>
        /// <param name="chapter_number"></param>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <returns></returns>
        public async Task<List<ReciteSurah>> GetSurahByNumberAndVerses(int chapter_number, int From, int To)
        {
            Init();
            object[] p = { chapter_number, From, To };
            string query = "SELECT para_number, para_name, chapter_name_arabic, verse_arabic, verse_english, class_arabic, total_verses, chapter_number FROM verses ";
            query += "WHERE chapter_number = ? and verse_number between ? and ? ";
            query += "GROUP BY para_number, para_name, chapter_name_arabic, verse_arabic, verse_english, class_arabic, total_verses, chapter_number, verse_number ";
            query += "ORDER BY para_number, number";

            List<ReciteSurah> rset = await QDB.QueryAsync<ReciteSurah>(query, p);
            return rset;
        }
        /// <summary>
        /// search a a para by number
        /// </summary>
        /// <param name="para_number"></param>
        /// <returns></returns>
        public async Task<List<ReciteSurah>> GetParaByNumber(int para_number)
        {
            Init();
            object[] p = { para_number };
            string query = "SELECT para_number, para_name,chapter_number, chapter_name_arabic, verse_arabic, verse_english, class_arabic, total_verses FROM verses ";
            query += "WHERE para_number = ? ";
            query += "GROUP BY para_number, para_name, chapter_number, chapter_name_arabic, verse_arabic, verse_english, class_arabic, total_verses ";
            query += "ORDER BY number, para_number, chapter_number";

            List<ReciteSurah> rset = await QDB.QueryAsync<ReciteSurah>(query, p);
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
        ///////////////// QURAN STATISTICS/////////////////////

    }
}


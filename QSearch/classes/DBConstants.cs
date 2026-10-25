using System;
namespace QSearch
{
	public static class DBConstants
	{
        public const string DatabaseFilename = "quran.sqlite";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            //SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            //SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.ReadOnly |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}


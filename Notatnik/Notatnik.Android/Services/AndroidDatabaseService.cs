using System;
using System.IO;
using Notatnik.Core.Services;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

namespace Notatnik.Android.Services
{
    public class AndroidDatabaseService : IDatabaseService
    {
        private SQLiteConnection connection;
        public SQLiteConnection Connection // Składnik specyficzny dla danej platformy 
        {
            get
            {
                if (connection == null)
                {
                    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "notesDb.sqlite");
                    connection = new SQLiteConnection(new SQLitePlatformAndroid(), path);
                }

                return connection;
            }
        }
    }
}
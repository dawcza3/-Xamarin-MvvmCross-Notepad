using System;
using System.IO;
using Notatnik.Core.Services;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;

namespace Notatnik.iOS.Services
{
    public class IphoneDatabaseService : IDatabaseService
    {
        private SQLiteConnection connection;
        public SQLiteConnection Connection 
        {
            get
            {
                if (connection == null)
                {
                    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "notesDb.sqlite");
                    connection = new SQLiteConnection(new SQLitePlatformIOS(), path);
                }

                return connection;
            }
        }
    }
}
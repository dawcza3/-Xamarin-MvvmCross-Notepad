using Notatnik.Core.Services;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System.IO;
using Windows.Storage;

namespace Notatnik.Uwp.Services
{
    public class UwpDatabaseService :IDatabaseService
    {
        private SQLiteConnection connection;
        public SQLiteConnection Connection // Składnik specyficzny dla danej platformy 
        {
            get
            {
                if (connection == null)
                {
                    var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "notesDb.sqlite");
                    connection = new SQLiteConnection(new SQLitePlatformWinRT(), path);
                }

                return connection;
            }
        }
    }
}

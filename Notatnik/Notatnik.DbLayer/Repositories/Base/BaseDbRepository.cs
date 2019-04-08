using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik.DbLayer.Repositories.Base
{
    public class BaseDbRepository
    {
        protected static object databaseLock = new object(); // zagniezdzenie watkow unikamy podczas dostepu do bazy

        protected SQLiteConnection DbConnection { get; set; }

        public BaseDbRepository(SQLiteConnection dbConnection)
        {
            DbConnection = dbConnection;
        }
    }
}

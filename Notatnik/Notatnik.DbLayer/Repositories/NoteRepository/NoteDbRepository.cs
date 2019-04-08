using Notatnik.DbLayer.Entities;
using Notatnik.DbLayer.Repositories.Base;
using SQLite.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notatnik.DbLayer.Repositories.NoteRepository
{
    // bazujemy na repozytoriach zeby móc łatwo zmieniać kontekst aplikacji w zależności od środowiska uruchomieniowego
    public class NoteDbRepository :BaseDbRepository, INoteRepository
    {
        public NoteDbRepository(SQLiteConnection dbConnection) :base (dbConnection)
        {
            
        }

        public Task Add(NoteEntity note)
        {
            return Task.Run(() =>
            {
                lock (databaseLock)
                {
                    DbConnection.Insert(note);
                }
            });
        }

        public Task Delete(int id)
        {
            return Task.Run(() =>
            {
                lock (databaseLock)
                {
                    DbConnection.Delete<NoteEntity>(id);
                }
            });
        }

        public Task<List<NoteEntity>> GetAll()
        {
            return Task.Run(() =>
            {
                lock (databaseLock)
                {
                    return DbConnection.Table<NoteEntity>().ToList();
                }
            });
        }

        public Task Update(NoteEntity note)
        {
            return Task.Run(() =>
            {
                lock (databaseLock)
                {
                    DbConnection.Update(note);
                }
            });
        }
    }

    public interface INoteRepository
    {
        Task Add(NoteEntity note);

        Task Delete(int id);

        Task Update(NoteEntity note);

        Task<List<NoteEntity>> GetAll();
    }


}

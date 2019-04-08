using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Notatnik.DbLayer.Entities;

namespace Notatnik.Core.Models
{
    public class Note :NoteEntity
    {
        public Note(NoteEntity noteEntity)
            : base(noteEntity.Title, noteEntity.Content, noteEntity.Date)
        {
            Id = noteEntity.Id;
        }

        public string CreateDate { get => "Ostatnia modyfikacja: " + Date.ToString("dd.MM.yyyy HH:mm:ss"); }
    }
}

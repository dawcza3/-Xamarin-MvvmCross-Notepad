using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik.DbLayer.Entities
{
    public class NoteEntity
    {
        public NoteEntity()
        {

        }

        public NoteEntity(string title, string content, DateTime date)
        {
            Title = title;
            Content = content;
            Date = date;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(15)]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }
    }
}

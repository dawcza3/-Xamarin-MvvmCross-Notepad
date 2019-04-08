using MvvmCross.Plugins.Messenger;
using Notatnik.DbLayer.Entities;

namespace Notatnik.Core.Messages
{
    public class CreateNoteMessage : MvxMessage
    {
        public NoteEntity Note { get; set; }

        public bool IsEditMode { get; set; }

        public CreateNoteMessage(object sender, NoteEntity note) : base(sender)
        {
            Note = note;
        }
    }
}

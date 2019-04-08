using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using Notatnik.Core.Messages;
using Notatnik.Core.Models;
using Notatnik.DbLayer.Entities;
using System;

namespace Notatnik.Core.ViewModels
{
    public class CreateNoteViewModel : MvxViewModel<Note>
    {
        private readonly IMvxMessenger _messanger;
        private Note _note;
        private bool _isEditMode = false;

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                RaisePropertyChanged("Content");
            }
        }

        public CreateNoteViewModel(IMvxMessenger messanger)
        {
            _messanger = messanger;
        }

        public IMvxCommand CreateNoteCommand => new MvxCommand(() => CreateNote());

        private void CreateNote()
        {
            NoteEntity noteEntity = new NoteEntity(Title, Content, DateTime.UtcNow);
            if (_isEditMode) noteEntity.Id = _note.Id;

            var noteMessage = new CreateNoteMessage(this, noteEntity);
            noteMessage.IsEditMode = _isEditMode;
            _messanger.Publish(noteMessage);
            Close(this);
        }

        public override void Prepare(Note parameter)
        {
            _note = parameter;
            _isEditMode = true;
            Title = parameter.Title;
            Content = parameter.Content;
        }

    }
}

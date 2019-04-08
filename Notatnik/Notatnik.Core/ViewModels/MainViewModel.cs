using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using Notatnik.Core.Messages;
using Notatnik.Core.Models;
using Notatnik.DbLayer.Repositories.NoteRepository;

namespace Notatnik.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IMvxMessenger _messanger;
        private readonly INoteRepository _noteRepository;
        private readonly IMvxNavigationService _mvxNavigationService;

        private ObservableCollection<Note> notes;

        public ObservableCollection<Note> Notes
        {
            get { return notes; }
            set
            {
                SetProperty(ref notes, value);
                RaisePropertyChanged(() => this.Notes);
            }
        }

        public MainViewModel(IMvxMessenger messanger,
            INoteRepository noteRepository, IMvxNavigationService mvxNavigationService)
        {
            _messanger = messanger;
            _noteRepository = noteRepository;
            _mvxNavigationService = mvxNavigationService;

            _messanger.Subscribe<CreateNoteMessage>(async x =>
            {
                if(x.IsEditMode)
                    await _noteRepository.Update(x.Note);
                else
                    await _noteRepository.Add(x.Note);

            }, MvxReference.Strong);
        }

        public IMvxCommand CreateNoteCommand => new MvxCommand(() => { _mvxNavigationService.Navigate<CreateNoteViewModel>(); });

        private MvxCommand<Note> _itemClickedCommand;
        public IMvxCommand ItemClickedCommand
        {
            get
            {
                return _itemClickedCommand = _itemClickedCommand ??
                    new MvxCommand<Note>(item =>
                    {
                        if(item!=null)
                            _mvxNavigationService.Navigate<CreateNoteViewModel, Note>(item);
                    });
            }
        }

        public async void OnResume()
        {
            try
            {
                Notes = new ObservableCollection<Note>();

                var dbNotes = await _noteRepository.GetAll();

                foreach (var noteEntity in dbNotes)
                {
                    Notes.Add(new Note(noteEntity));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
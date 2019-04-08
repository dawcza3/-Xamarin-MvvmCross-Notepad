using System.Collections.ObjectModel;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using Notatnik.Core.Models;
using Notatnik.Core.ViewModels;
using UIKit;

namespace Notatnik.iOS.Views
{
    public class NoteTableViewSource : MvxTableViewSource
    {
        private readonly MainViewModel _parentViewModel;

        public NoteTableViewSource(UITableView table,MainViewModel parentViewModel) : base (table) 
        {
            table.RegisterNibForCellReuse(NoteTableViewCell.Nib, NoteTableViewCell.Key);
            _parentViewModel = parentViewModel;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return tableView.DequeueReusableCell(NoteTableViewCell.Key, indexPath);
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var item = (ItemsSource as ObservableCollection<Note>)[indexPath.Row];
            _parentViewModel.ItemClickedCommand.Execute(item);
        }
    }
}
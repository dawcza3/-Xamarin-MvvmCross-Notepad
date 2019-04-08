using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using Notatnik.Core.ViewModels;

namespace Notatnik.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class MainView : MvxViewController
    {
        public MainView() : base("MainView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<MainView, Core.ViewModels.MainViewModel>();
            set.Bind(addButton).To(vm => vm.CreateNoteCommand);

            var source = new NoteTableViewSource(noteList,ViewModel as MainViewModel);
            noteList.Source = source;
            set.Bind(source).For(x => x.ItemsSource).To(vm => vm.Notes);

            set.Apply();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            (ViewModel as MainViewModel).OnResume();
        }
    }
}

using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using Notatnik.Core.ViewModels;
using System;

using UIKit;

namespace Notatnik.iOS.Views
{
    public partial class CreateNoteView : MvxViewController
    {
        public CreateNoteView() : base("CreateNoteView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var set = this.CreateBindingSet<CreateNoteView,CreateNoteViewModel>();
            set.Bind(titleText).To(vm => vm.Title);
            set.Bind(contentText).To(vm => vm.Content);
            set.Bind(addNote).To(vm => vm.CreateNoteCommand);
            set.Apply();
        }
    }
}
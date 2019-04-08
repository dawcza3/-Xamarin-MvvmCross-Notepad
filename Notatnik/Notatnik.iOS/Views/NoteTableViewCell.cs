using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using Notatnik.Core.Models;
using UIKit;

namespace Notatnik.iOS.Views
{
    public partial class NoteTableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("NoteTableViewCell");
        public static readonly UINib Nib;

        static NoteTableViewCell()
        {
            Nib = UINib.FromName("NoteTableViewCell", NSBundle.MainBundle);
        }

        protected NoteTableViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<NoteTableViewCell,Note>();
                set.Bind(titleLabel).To(vm => vm.Title);
                set.Bind(dateLabel).To(vm => vm.CreateDate);
                set.Apply();
            });
        }
    }
}

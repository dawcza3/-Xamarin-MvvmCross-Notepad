// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Notatnik.iOS.Views
{
    [Register ("CreateNoteView")]
    partial class CreateNoteView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton addNote { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField contentText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField titleText { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (addNote != null) {
                addNote.Dispose ();
                addNote = null;
            }

            if (contentText != null) {
                contentText.Dispose ();
                contentText = null;
            }

            if (titleText != null) {
                titleText.Dispose ();
                titleText = null;
            }
        }
    }
}
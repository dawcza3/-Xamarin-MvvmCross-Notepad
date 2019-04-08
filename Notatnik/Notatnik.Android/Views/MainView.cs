using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using Notatnik.Core.ViewModels;

namespace Notatnik.Android.Views
{
    [Activity(Label = "Notatki")]
    public class MainView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.main_view);
        }

        protected override void OnResume()
        {
            base.OnResume();

            (ViewModel as MainViewModel).OnResume();
        }
    }
}

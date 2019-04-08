using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform.Platform;
using Android.Content;
using MvvmCross.Platform;
using Notatnik.Core.Services;
using Notatnik.Android.Services;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Core.Platform;

namespace Notatnik.Android
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {

        }

        protected override IMvxApplication CreateApp() => new Core.App();

        protected override IMvxTrace CreateDebugTrace() => new DebugTrace();

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
            Mvx.RegisterType<IDatabaseService, AndroidDatabaseService>();
        }
    }
}

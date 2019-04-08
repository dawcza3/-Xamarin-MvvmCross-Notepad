using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Notatnik.Core.Services;
using Notatnik.Core.ViewModels;
using Notatnik.DbLayer.Entities;
using Notatnik.DbLayer.Repositories.NoteRepository;

namespace Notatnik.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterNavigationServiceAppStart<MainViewModel>();
            DbConfiguration();
        }

        private void DbConfiguration()
        {
            var databaseService = Mvx.Resolve<IDatabaseService>();
            databaseService.Connection.CreateTable<NoteEntity>();
            Mvx.RegisterType<INoteRepository>(() => new NoteDbRepository(databaseService.Connection));
        }
    }
}

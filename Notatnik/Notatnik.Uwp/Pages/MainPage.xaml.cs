using Notatnik.Core.Models;
using Notatnik.Core.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace Notatnik.Uwp.Pages
{
    public sealed partial class MainPage : BasePage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            (ViewModel as MainViewModel).OnResume();
        }

        private void ListView_ItemClick(object sender, Windows.UI.Xaml.Controls.ItemClickEventArgs e)
        {
            (ViewModel as MainViewModel).ItemClickedCommand.Execute(e.ClickedItem);
        }
    }
}

using System.Windows;
using TelekomNevaSvyazWpfApp.Views.Pages;

namespace TelekomNevaSvyazWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            NavigationView navigationView = new NavigationView
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
            };
            navigationView.Show();
            navigationView.NavigationFrame.Navigate(
                new LoginView());
        }
    }
}

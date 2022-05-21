using System.Windows;
using TelekomNevaSvyazWpfApp.Services;
using TelekomNevaSvyazWpfApp.Views.Pages;

namespace TelekomNevaSvyazWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Ioc.Register<MessageBoxService>();
            Ioc.Register<WindowService>();

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

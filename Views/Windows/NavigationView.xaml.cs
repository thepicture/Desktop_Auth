using System;
using System.Windows;
using System.Windows.Navigation;
using TelekomNevaSvyazWpfApp.Views.Pages;

namespace TelekomNevaSvyazWpfApp
{
    /// <summary>
    /// Interaction logic for NavigationView.xaml
    /// </summary>
    public partial class NavigationView : Window
    {
        public NavigationView()
        {
            InitializeComponent();
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            Width = ((dynamic)e.Content).MinWidth;
            Height = ((dynamic)e.Content).MinHeight;
            Left = (SystemParameters.WorkArea.Width - Width) / 2;
            Top = (SystemParameters.WorkArea.Height - Height) / 2;
        }
    }
}

using System;
using System.Windows;

namespace TelekomNevaSvyazWpfApp.Services
{
    public class WindowService : IWindowService
    {
        public object Open<T>()
        {
            string nameOfWindow = typeof(T).Name.Replace("ViewModel", "View");
            Type windowType = Type.GetType("TelekomNevaSvyazWpfApp.Views.Windows." + nameOfWindow);
            Window window = (Window)Activator.CreateInstance(windowType);
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
            return window.DataContext;
        }
    }
}

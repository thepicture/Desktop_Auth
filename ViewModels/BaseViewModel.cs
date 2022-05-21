using TelekomNevaSvyazWpfApp.Models;
using TelekomNevaSvyazWpfApp.Services;

namespace TelekomNevaSvyazWpfApp.ViewModels
{
    public abstract class BaseViewModel : ObservableObject
    {
        public IMessageBoxService MessageBoxService => Ioc.Get<IMessageBoxService>();
        public IWindowService WindowService => Ioc.Get<IWindowService>();
    }
}

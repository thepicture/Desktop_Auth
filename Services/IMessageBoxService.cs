using System.Threading.Tasks;
using System.Windows;

namespace TelekomNevaSvyazWpfApp.Services
{
    public interface IMessageBoxService
    {
        Task<MessageBoxResult> InformAsync(object message);
        Task<MessageBoxResult> WarnAsync(object message);
        Task<bool> AskAsync(object message);
        Task<MessageBoxResult> InformErrorAsync(object message);
    }
}

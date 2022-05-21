using System.Threading.Tasks;
using System.Windows;

namespace TelekomNevaSvyazWpfApp.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public async Task<bool> AskAsync(object message)
        {
            return await Task.Run(() =>
            {
                return MessageBox.Show(
                    message.ToString(),
                    "Вопрос",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes;
            });
        }

        public async Task<MessageBoxResult> InformAsync(object message)
        {
            return await Task.Run(() =>
            {
                return MessageBox.Show(
                    message.ToString(),
                    "Информация",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            });
        }

        public async Task<MessageBoxResult> InformErrorAsync(object message)
        {
            return await Task.Run(() =>
            {
                return MessageBox.Show(
                    message.ToString(),
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            });
        }

        public async Task<MessageBoxResult> WarnAsync(object message)
        {
            return await Task.Run(() =>
            {
                return MessageBox.Show(
                    message.ToString(),
                    "Предупреждение",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            });
        }
    }
}

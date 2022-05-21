using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TelekomNevaSvyazWpfApp.Commands;
using TelekomNevaSvyazWpfApp.Models.Entities;

namespace TelekomNevaSvyazWpfApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private Command clearAllFieldsCommand;

        public ICommand ClearAllFieldsCommand
        {
            get
            {
                if (clearAllFieldsCommand == null)
                {
                    clearAllFieldsCommand = new Command(ClearAllFields);
                }

                return clearAllFieldsCommand;
            }
        }

        private void ClearAllFields(object commandParameter)
        {
            Phone = null;
            Password = null;
            SmsCode = null;
        }

        private Command signInCommand;

        public ICommand SignInCommand
        {
            get
            {
                if (signInCommand == null)
                {
                    signInCommand = new Command(SignInAsync);
                }

                return signInCommand;
            }
        }

        private async void SignInAsync(object commandParameter)
        {
            using (TelekomNevaSvyazBaseEntities entities = new TelekomNevaSvyazBaseEntities())
            {
                if (entities.Employees.FirstOrDefault(e =>
                        e.Phone == Phone && e.Password == Password) is Employee currentEmployee)
                {
                    await MessageBoxService.InformAsync($"Вы авторизованы с ролью {currentEmployee.EmployeeRole.Title}");
                }
                else
                {
                    await MessageBoxService.InformErrorAsync("Вы ввели неправильный пароль");
                }
            }
        }


        private string smsCode;

        public string SmsCode { get => smsCode; set => SetProperty(ref smsCode, value); }

        private string phone;

        public string Phone { get => phone; set => SetProperty(ref phone, value); }

        private string password;

        public string Password { get => password; set => SetProperty(ref password, value); }

        private bool isPhoneCorrect;

        public bool IsPhoneCorrect { get => isPhoneCorrect; set => SetProperty(ref isPhoneCorrect, value); }

        private bool isSmsCodeSent;

        public bool IsSmsCodeSent { get => isSmsCodeSent; set => SetProperty(ref isSmsCodeSent, value); }

        private Command checkEmployeePhoneCommand;

        public ICommand CheckEmployeePhoneCommand
        {
            get
            {
                if (checkEmployeePhoneCommand == null)
                {
                    checkEmployeePhoneCommand = new Command(CheckEmployeePhoneAsync);
                }

                return checkEmployeePhoneCommand;
            }
        }

        private async void CheckEmployeePhoneAsync(object commandParameter)
        {
            using (TelekomNevaSvyazBaseEntities entities = new TelekomNevaSvyazBaseEntities())
            {
                if (entities.Employees.Any(e => e.Phone == Phone))
                {
                    IsPhoneCorrect = true;
                }
                else
                {
                    await MessageBoxService.InformErrorAsync("Номер сотрудника в базе отсутствует");
                }
            }
        }

        private Command executePasswordCommand;

        public ICommand ExecutePasswordCommand
        {
            get
            {
                if (executePasswordCommand == null)
                {
                    executePasswordCommand = new Command(ExecutePasswordAsync);
                }

                return executePasswordCommand;
            }
        }

        private async void ExecutePasswordAsync(object commandParameter)
        {
            if (IsSmsCodeSent)
            {
                return;
            }
            using (TelekomNevaSvyazBaseEntities entities = new TelekomNevaSvyazBaseEntities())
            {
                if (entities.Employees.Any(e => e.Phone == Phone && e.Password == Password))
                {
                    object result = WindowService.Open<SmsCodeViewModel>();
                    CurrentGeneratedCode = ((dynamic)result).GeneratedCode;
                    StartTimerAsync();
                    IsSmsCodeSent = true;
                }
                else
                {
                    await MessageBoxService.InformErrorAsync("Вы ввели неправильный пароль");
                }
            }
        }

        private async void StartTimerAsync()
        {
            IsCanRegenerateSmsCode = false;
            await Task.Delay(
                TimeSpan.FromSeconds(10));
            IsSmsCodeSent = false;
            IsCanSignIn = false;
            IsCanRegenerateSmsCode = true;
        }

        private Command enterCodeCommand;

        public ICommand EnterCodeCommand
        {
            get
            {
                if (enterCodeCommand == null)
                {
                    enterCodeCommand = new Command(EnterCodeAsync);
                }

                return enterCodeCommand;
            }
        }

        private async void EnterCodeAsync(object commandParameter)
        {
            if (CurrentGeneratedCode == SmsCode)
            {
                IsCanSignIn = true;
            }
            else
            {
                await MessageBoxService.InformErrorAsync("Вы ввели неправильный код");
            }
        }

        private bool isCanSignIn;
        private dynamic currentGeneratedCode;
        private bool isCanRegenerateSmsCode;

        public bool IsCanSignIn
        {
            get => isCanSignIn;
            set => SetProperty(ref isCanSignIn, value);
        }
        public dynamic CurrentGeneratedCode
        {
            get => currentGeneratedCode;
            set => SetProperty(ref currentGeneratedCode, value);
        }
        public bool IsCanRegenerateSmsCode
        {
            get => isCanRegenerateSmsCode;
            set => SetProperty(ref isCanRegenerateSmsCode, value);
        }
    }
}
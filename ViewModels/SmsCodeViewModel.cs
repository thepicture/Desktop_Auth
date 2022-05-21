using System;
using System.Text;

namespace TelekomNevaSvyazWpfApp.ViewModels
{
    public class SmsCodeViewModel : BaseViewModel
    {

        private string generatedCode;

        public SmsCodeViewModel()
        {
            GenerateCode();
        }

        private void GenerateCode()
        {
            Random random = new Random();
            StringBuilder codeBuilder = new StringBuilder(8);
            string specSymbols = "@#$%^&";
            for (int i = 0; i < 4; i++)
            {
                codeBuilder.Append(
                    (char)random.Next(65, 90 + 1));
            }
            codeBuilder
                .Append(
                    ((char)random.Next(65, 90 + 1))
                        .ToString()
                        .ToUpper());
            codeBuilder
                .Append(
                    ((char)random
                        .Next(65, 90 + 1))
                        .ToString()
                        .ToLower());
            codeBuilder.Append(
                specSymbols[random.Next(specSymbols.Length)]);
            codeBuilder.Append(
                random.Next(10));
            GeneratedCode = codeBuilder.ToString();
        }

        public string GeneratedCode
        {
            get => generatedCode;
            set => SetProperty(ref generatedCode, value);
        }
    }
}
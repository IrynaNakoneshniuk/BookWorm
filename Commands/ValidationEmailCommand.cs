using BookWorm.ViewModel;
using System;
using System.Threading.Tasks;
using BookWorm.Services;
using System.Windows;
using System.Text.RegularExpressions;
using BookWorm.DataAccess;

namespace BookWorm.Commands
{
    public class ValidationEmailCommand : AsyncCommandBase
    {
        private readonly IValidatioinEmailVM _validationVM;
        public ValidationEmailCommand(IValidatioinEmailVM validationVM)
        {
            this._validationVM = validationVM;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                UserAccountManager manager = new UserAccountManager();

                if (await manager.IsEmailExist(_validationVM.Email))
                {
                    _validationVM.Message = "Електронна пошта вже використовується!";
                    _validationVM.Email = null;
                    return;
                }
                else if (!EmailRegex(_validationVM.Email))
                {
                    _validationVM.Message = "Некоректнo введена електронна адреса!";
                    _validationVM.Email = null;
                    return;
                }
                else
                {
                    EmailSender emailSenderemail = new EmailSender();
                    string Message = $"Для підтвердження електронної пошти введіть код {DigitCodeGenerator.Generate()} ";
                    await emailSenderemail.SendAsync(_validationVM.Email, "Підтвердження електронної пошти", Message);
                    _validationVM.IsFieldVisible = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool EmailRegex(string email)
        {
            Regex emailRegex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
            + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            if (emailRegex.IsMatch(email)) return true;
            return false;
        }
    }
}

using BookWorm.ViewModel;
using System.Threading.Tasks;
using BookWorm.Services;
using BookWorm.DataAccess;
using System.Windows;
using System;
using Microsoft.IdentityModel.Tokens;

namespace BookWorm.Commands
{
    public class PasswordRecoveryCommand : AsyncCommandBase
    {
        private IBase _mainSelectorVm;
        private static bool IsSendRecoveryCode { get; set; } = false;

        public PasswordRecoveryCommand(IBase mainSelectorVm)
        {
            this._mainSelectorVm = mainSelectorVm;
        }
        protected override async Task ExecuteAsync(object? parameter)
        {
            var inputCode = this._mainSelectorVm.RecoveryPasswordVM.RecoveryCode;

            if (!IsSendRecoveryCode)
            {
                await SendRecoveryCode();
                this._mainSelectorVm.RecoveryPasswordVM.IsCodeFieldEnable = true;
                IsSendRecoveryCode = true;
            }
            if (inputCode != null)
            {
                if (inputCode == DigitCodeGenerator.ConfirmCode)
                {
                   await ChangePassword();
                }
                else
                {
                    this._mainSelectorVm.RecoveryPasswordVM.ErrorMessage = "Невірно введено код підтвердження!";
                    this._mainSelectorVm.RecoveryPasswordVM.RecoveryCode = null;
                }
            }
        }


        private async Task SendRecoveryCode()
        {
            try
            {
                UserAccountManager manager = new UserAccountManager();
                var recoveryCode = DigitCodeGenerator.Generate();
                string? userEmail = _mainSelectorVm.RecoveryPasswordVM.Email;

                if (await manager?.IsEmailExist(userEmail))
                {
                    EmailSender emailSenderemail = new EmailSender();
                    string message = $"Для відновлення паролю введіть код: {recoveryCode}";
                    await emailSenderemail.SendAsync(userEmail, "Відновлення паролю", message);
                }
                else
                {
                    _mainSelectorVm.RecoveryPasswordVM.ErrorMessage = "Невірно введено електронну адресу!";
                    _mainSelectorVm.RecoveryPasswordVM.Email = null;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public async Task ChangePassword()
        {
            try
            {
                UserAccountManager userAccountManager = new UserAccountManager();
                var password = this._mainSelectorVm.RecoveryPasswordVM.Password;
                var repassword = this._mainSelectorVm.RecoveryPasswordVM.Repassword;
                string? userEmail = _mainSelectorVm.RecoveryPasswordVM.Email;

                this._mainSelectorVm.RecoveryPasswordVM.IsPasswordFieldEnable = true;

                if (!password.IsNullOrEmpty() && !repassword.IsNullOrEmpty())
                {
                    if (password == repassword)
                    {
                        await userAccountManager.ChangePassword(userEmail, password);
                        this._mainSelectorVm.SelectView = new UserLoginVM();
                        this._mainSelectorVm.RecoveryPasswordVM.IsFormVisibil = false;
                    }
                    else
                    {
                        this._mainSelectorVm.RecoveryPasswordVM.ErrorMessage = "Невірно введено код підтвердження!";
                        this._mainSelectorVm.RecoveryPasswordVM.Password = null;
                        this._mainSelectorVm.RecoveryPasswordVM.Repassword = null;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

using BookWorm.DataAccess;
using BookWorm.ModelDB;
using BookWorm.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace BookWorm.Commands
{
    public class RegistrationCommand : AsyncCommandBase
    {
        private readonly RegistrationVM _registrationVM;

        public RegistrationCommand(RegistrationVM registrationVM)
        {
            this._registrationVM = registrationVM;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                if(_registrationVM.Password== _registrationVM.Repassword)
                {
                    UserAccountManager manager = new UserAccountManager();
                    await manager.RegistrationUserAsync(new Users(_registrationVM.Email, _registrationVM.Password,
                        _registrationVM.Name, _registrationVM.Surname));
                }
                else
                {
                    MessageBox.Show("Не співпадають введені паролі!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

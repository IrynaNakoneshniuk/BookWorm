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
        private readonly MainVM _mainSelectorView;

        public RegistrationCommand(MainVM registrationVM)
        {
            this._mainSelectorView = registrationVM;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                if(_mainSelectorView.Registration.Password== _mainSelectorView.Registration.Repassword)
                {
                    UserAccountManager manager = new UserAccountManager();
                    _mainSelectorView.User = new Users(CurrentSession.Email, _mainSelectorView.Registration.Password,
                       _mainSelectorView.Registration.Name, _mainSelectorView.Registration.Surname);
                   await manager.RegistrationUserAsync(_mainSelectorView.User);
                    _mainSelectorView.Name= _mainSelectorView.Registration.Name;
                    _mainSelectorView.SelectView = _mainSelectorView.Library;
                    _mainSelectorView.Registration.IsFormVisibil = false;
                }
                else
                {
                    _mainSelectorView.Registration.Repassword = null;
                    _mainSelectorView.Registration.Password = null;

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

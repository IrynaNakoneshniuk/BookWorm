using BookWorm.DataAccess;
using BookWorm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookWorm.ModelDB;
using System.Windows;

namespace BookWorm.Commands
{
    public class LogginCommand : AsyncCommandBase
    {
        private readonly MainVM _mainSelectorView;

        public LogginCommand(MainVM mainSelectorView)
        {
            this._mainSelectorView = mainSelectorView;
        }
        protected override async Task ExecuteAsync(object? parameter)
        {
            UserAccountManager userAccount= new UserAccountManager();

            try
            {
                _mainSelectorView.User = await userAccount.SigInUserAsync(_mainSelectorView.LogginUser.UserEmail);

                if (_mainSelectorView.User == null)
                {
                    _mainSelectorView.LogginUser.Error = "Користувача не знайдено!";
                    return;
                }
                else
                {
                    if(_mainSelectorView.User.Password!= _mainSelectorView.LogginUser.Password)
                    {
                        _mainSelectorView.LogginUser.Error = "Невірно введено пароль!";
                        _mainSelectorView.LogginUser.Password = null;
                        return;
                    }
                    else
                    {
                        _mainSelectorView.Name = _mainSelectorView.User.Name;
                        _mainSelectorView.SelectView = _mainSelectorView.Library;
                        _mainSelectorView.LogginUser.IsFieldVisibil = false;

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

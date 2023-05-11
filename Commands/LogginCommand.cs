using BookWorm.DataAccess;
using BookWorm.ViewModel;
using System;
using System.Threading.Tasks;
using BookWorm.ModelDB;
using System.Windows;
using BookWorm.Api;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;

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
            UserAccountManager userAccount = new UserAccountManager();

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
                    if (_mainSelectorView.User.Password != _mainSelectorView.LogginUser.Password)
                    {
                        _mainSelectorView.LogginUser.Error = "Невірно введено пароль!";
                        _mainSelectorView.LogginUser.Password = null;
                        return;
                    }
                    else
                    {
                        var list = await ApisClient.GetListBookAsync();
                        foreach (var book in list)
                        {
                            string url = (from i in book.Formats
                                          where i.Key == "image/jpeg"
                                          select i.Value).FirstOrDefault();
                            _mainSelectorView.Library.BooksLibrary.Add(new BookLibrary(book.Id, book.Title, book.Authors, url));
                        }
                        CurrentView.Bookslibrary = _mainSelectorView.Library.BooksLibrary;
                        _mainSelectorView.SelectView = _mainSelectorView.Library;
                        _mainSelectorView.LogginUser.IsFieldVisibil = false;
                        _mainSelectorView.Library.Name = _mainSelectorView.User.Name;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}


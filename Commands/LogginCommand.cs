using BookWorm.DataAccess;
using BookWorm.ViewModel;
using System;
using System.Threading.Tasks;
using BookWorm.ModelDB;
using System.Windows;
using BookWorm.Api;
using System.Linq;
using System.Collections.Generic;
using Autofac;

namespace BookWorm.Commands
{
    public class LogginCommand : AsyncCommandBase
    {
        private readonly IBase _mainSelectorView;
        public LogginCommand(IBase mainSelectorView) 
        {
            this._mainSelectorView = mainSelectorView;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            UserAccountManager userAccount = new UserAccountManager();
            Users user = new Users(null,null,null,null);
            try
            {
                user = await userAccount.SigInUserAsync(this._mainSelectorView.LogginUser.UserEmail);
                this._mainSelectorView.User=user;

                if (this._mainSelectorView.User == null)
                {
                    this._mainSelectorView.LogginUser.Error = "Користувача не знайдено!";
                    return;
                }
                else
                {
                    if (this._mainSelectorView.User.Password != this._mainSelectorView.LogginUser.Password)
                    {
                        this._mainSelectorView.LogginUser.Error = "Невірно введено пароль!";
                        this._mainSelectorView.LogginUser.Password = null;
                        return;
                    }
                    else
                    {
                       await GetLibraryAsync();
                        this._mainSelectorView.SelectView = this._mainSelectorView.Library;
                        this._mainSelectorView.LogginUser.IsFieldVisibil = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        protected async Task GetLibraryAsync()
        {
            List<BookLibrary> bookLibrary = new List<BookLibrary>();
            try
            {
                var list = await ApisClient.GetListBookAsync();
                foreach (var book in list)
                {
                    string ?url = (from i in book.Formats
                                  where i.Key == "image/jpeg"
                                  select i.Value).FirstOrDefault();
                   bookLibrary.Add(new BookLibrary(book.Id, book.Title,
                        book.Authors, url));
                }
                this._mainSelectorView.Library.BooksLibrary = bookLibrary;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}


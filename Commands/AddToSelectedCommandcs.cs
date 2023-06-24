using BookWorm.DataAccess;
using BookWorm.ModelDB;
using BookWorm.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BookWorm.Commands
{
    public class AddToSelectedCommand : AsyncCommandBase
    {
        private IBase _mainSelectedVm;
        public AddToSelectedCommand(IBase mainSelectedVm) { 

            this._mainSelectedVm= mainSelectedVm;
        }
        protected override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                var selectedBook = parameter as ListViewItem;
                BookLibrary? bookLibrary = selectedBook.Content as BookLibrary;
                BooksDatabaseManager booksDatabaseManager = new BooksDatabaseManager();
     
                var book = new Books(bookLibrary.Id.ToString(),
                        bookLibrary.Author.ToString(), bookLibrary.Url, bookLibrary.Title,
                        null, _mainSelectedVm.User.Id);
            
                if (book != null)
                {
                    await booksDatabaseManager.AddBookAsync(book);
                    await booksDatabaseManager.AddFavouriteBook(book);
                }
                MessageBox.Show("Книгу додано до книжкової полички");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

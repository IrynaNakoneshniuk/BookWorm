using BookWorm.DataAccess;
using BookWorm.ModelDB;
using BookWorm.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;

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
            BooksDatabaseManager booksDatabaseManager = new BooksDatabaseManager();
            var selectedBook = _mainSelectedVm.DescriptionBooKVm.SelectedBook;
            var book = new Books(selectedBook.Id.ToString(),
                        selectedBook.Author.ToString(), selectedBook.Url, selectedBook.Title,
                        null, _mainSelectedVm.User.Id);
            try
            {
                if (selectedBook != null)
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

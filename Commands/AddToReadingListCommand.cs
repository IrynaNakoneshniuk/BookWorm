using BookWorm.DataAccess;
using BookWorm.ModelDB;
using BookWorm.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BookWorm.Commands
{
    public class AddToReadingListCommand : AsyncCommandBase
    {
        private IBase _mainSelectorVm;

        public AddToReadingListCommand(IBase mainSelectorVm)
        {
            this._mainSelectorVm = mainSelectorVm;
        }
        protected async override Task ExecuteAsync(object? parameter)
        {
            try
            {
                var selectedBook = parameter as ListViewItem;
                Books? book = selectedBook.Content as Books;
                if (book != null)
                {
                    BooksDatabaseManager booksDatabaseManager = new BooksDatabaseManager(); 
                    var idBook= book.Id;

                    await  booksDatabaseManager.AddReadingBook(book);
                    await booksDatabaseManager.DeleteBookFromFavorite((int)idBook);

                    this._mainSelectorVm.BookShelfVM.ReadingBooksList.Add(book);
                    this._mainSelectorVm.BookShelfVM.SelectedBooksList.Remove(book);

                    this._mainSelectorVm.SelectView = this._mainSelectorVm.BookShelfVM;
                    MessageBox.Show("Книгу додано в список для прочитання!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

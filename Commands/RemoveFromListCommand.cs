using BookWorm.DataAccess;
using BookWorm.ModelDB;
using BookWorm.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BookWorm.Commands
{
    public class RemoveFromListCommand : AsyncCommandBase
    {
        private IBase _mainSelectorVm;
        public RemoveFromListCommand(IBase mainSelectorVm) { 

            this._mainSelectorVm = mainSelectorVm;
        }
        protected async override Task ExecuteAsync(object? parameter)
        {
            try
            {
                BooksDatabaseManager booksDatabaseManager = new BooksDatabaseManager();
                var selectedBook = parameter as ListViewItem;
                Books? book = selectedBook.Content as Books;
                var idBook = book.Id;

                if (book != null)
                {
                    await booksDatabaseManager.DeleteBookById((int)idBook);
                    if (this._mainSelectorVm.BookShelfVM.ReadingBooksList.Contains(book))
                    {
                        this._mainSelectorVm.BookShelfVM.ReadingBooksList.Remove(book);
                    }
                    if (this._mainSelectorVm.BookShelfVM.SelectedBooksList.Contains(book))
                    {
                        this._mainSelectorVm.BookShelfVM.SelectedBooksList.Remove(book);
                    }
 
                    this._mainSelectorVm.SelectView = this._mainSelectorVm.BookShelfVM;
                    MessageBox.Show("Книгу видалено зі списку");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

using BookWorm.DataAccess;
using BookWorm.ModelDB;
using BookWorm.ViewModel;
using System;
using System.Collections.Generic;
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
                Books? book = selectedBook?.Content as Books;
                var idBook = book.Id;

                if (book != null)
                {
                    await booksDatabaseManager.DeleteBookById((int)idBook);
                    if (this._mainSelectorVm.BookShelfVM.ReadingBooksList.Contains(book))
                    {
                        var list = new List<Books>();
                        this._mainSelectorVm.BookShelfVM.ReadingBooksList.ForEach(book => list.Add(book));
                        list.Remove(book);
                        this._mainSelectorVm.BookShelfVM.ReadingBooksList.Clear();
                        this._mainSelectorVm.BookShelfVM.ReadingBooksList = list;
                    }
                    if (this._mainSelectorVm.BookShelfVM.SelectedBooksList.Contains(book))
                    {
                        var list = new List<Books>();
                        this._mainSelectorVm.BookShelfVM.SelectedBooksList.ForEach(book => list.Add(book));
                        list.Remove(book);
                        this._mainSelectorVm.BookShelfVM.SelectedBooksList.Clear();
                        this._mainSelectorVm.BookShelfVM.SelectedBooksList = list;
                    }

                    this._mainSelectorVm.SelectView = null;
                    MessageBox.Show("Книгу видалено зі списку");
                    this._mainSelectorVm.SelectView = new BookShelfVM();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

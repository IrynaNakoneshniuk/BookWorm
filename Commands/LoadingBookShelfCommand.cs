using BookWorm.DataAccess;
using BookWorm.ModelDB;
using BookWorm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BookWorm.Commands
{
    public class LoadingBookShelfCommand : AsyncCommandBase
    {
        private IBase _mainSelectorVm;

        private List<Books> _listOfUsersBooks;

        private BooksDatabaseManager _booksDatabaseManager;

        public LoadingBookShelfCommand(IBase mainSelectorVm) { 

            this._mainSelectorVm = mainSelectorVm;
            this._listOfUsersBooks= new List<Books>();
            this._booksDatabaseManager= new BooksDatabaseManager();
        }
        protected async override Task ExecuteAsync(object? parameter)
        {
            try
            {
                if (this._mainSelectorVm.User != null)
                {
                    var userId = this._mainSelectorVm.User.Id;
                    this._listOfUsersBooks = await _booksDatabaseManager.GetListBooksByIdUser(userId);

                    if (_listOfUsersBooks.Count > 0)
                    {
                        await LoadingFavoriteBooks();
                        await LoadingReadingBooks();
                    }

                    this._mainSelectorVm.SelectView = this._mainSelectorVm.BookShelfVM;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async  Task LoadingFavoriteBooks ()
        {
            try
            {
                List<Books> listBooks = new List<Books>();

                var userId = _mainSelectorVm.User.Id;
                List<FavoriteBooks> favoriteBooks =
                    await _booksDatabaseManager.GetFavoriteBooksByIdUser(userId);

                if (favoriteBooks.Count > 0)
                {
                    foreach (var favoriteBook in favoriteBooks)
                    {
                        var book = (from books in this._listOfUsersBooks
                                    where books.Id == favoriteBook.BookId
                                    select books).FirstOrDefault();
                        listBooks.Add(book);
                    }
                    this._mainSelectorVm.BookShelfVM.SelectedBooksList = listBooks;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }

        public async Task LoadingReadingBooks()
        {
            try
            {
                List<Books> listBooks = new List<Books>();

                var userId = this._mainSelectorVm.User.Id;
                List<ReadingBooks> readingBooks =
                    await this._booksDatabaseManager.GetReadingBooksByIdUser(userId);

                if (readingBooks.Count > 0)
                {
                    foreach (var readingBook in readingBooks)
                    {
                        var book = (from books in this._listOfUsersBooks
                                    where books.Id == readingBook.BookId
                                    select books).FirstOrDefault();
                        listBooks.Add(book);
                    }
                    this._mainSelectorVm.BookShelfVM.ReadingBooksList = listBooks;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

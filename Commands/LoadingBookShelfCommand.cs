using BookWorm.DataAccess;
using BookWorm.ModelDB;
using BookWorm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var userId = _mainSelectorVm.User.Id;
            _listOfUsersBooks = await _booksDatabaseManager.GetListBooksByIdUser(userId);

            if(_listOfUsersBooks.Count > 0)
            {
                await LoadingFavoriteBooks();
                await LoadingReadingBooks();
            }

            _mainSelectorVm.SelectView = _mainSelectorVm.BookShelfVM;
        }

        public async  Task LoadingFavoriteBooks ()
        {
            List <Books> listBooks= new List<Books>();

            var userId = _mainSelectorVm.User.Id;
            List<FavoriteBooks> favoriteBooks =
                await _booksDatabaseManager.GetFavoriteBooksByIdUser(userId);

            if(favoriteBooks.Count > 0)
            {
                foreach(var favoriteBook in favoriteBooks)
                {
                    var book = (from books in _listOfUsersBooks
                                    where books.Id == favoriteBook.BookId
                                    select books).FirstOrDefault();
                    listBooks.Add(book);
                }
                _mainSelectorVm.BookShelfVM.SelectedBooksList = listBooks;
            }
        }

        public async Task LoadingReadingBooks()
        {
            List<Books> listBooks = new List<Books>();

            var userId = _mainSelectorVm.User.Id;
            List<ReadingBooks> readingBooks =
                await _booksDatabaseManager.GetReadingBooksByIdUser(userId);

            if (readingBooks.Count > 0)
            {
                foreach (var readingBook in readingBooks)
                {
                    var book = (from books in _listOfUsersBooks
                                where books.Id == readingBook.BookId
                                select books).FirstOrDefault();
                    listBooks.Add(book);
                }
                _mainSelectorVm.BookShelfVM.ReadingBooksList = listBooks;
            }
        }
    }
}

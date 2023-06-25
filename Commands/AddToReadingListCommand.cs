using BookWorm.DataAccess;
using BookWorm.ModelDB;
using BookWorm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BookWorm.Commands
{
    public class AddToReadingListCommand : AsyncCommandBase
    {
        private IBase _mainSelectorVm;

        private List<Books> _listOfUsersBooks;

        private BooksDatabaseManager _booksDatabaseManager;

        public AddToReadingListCommand(IBase mainSelectorVm)
        {
            this._mainSelectorVm = mainSelectorVm;
            this._listOfUsersBooks = new List<Books>();
            this._booksDatabaseManager = new BooksDatabaseManager();
        }
        protected async override Task ExecuteAsync(object? parameter)
        {
            try
            {
                var selectedBook = parameter as ListViewItem;
                Books? book = selectedBook?.Content as Books;

                if (book != null && this._mainSelectorVm.User != null)
                {
                    BooksDatabaseManager booksDatabaseManager = new BooksDatabaseManager(); 
                    var idBook= book.Id;
                
                    await  booksDatabaseManager.AddReadingBook(book);

                    this._mainSelectorVm.BookShelfVM.ReadingBooksList?.Clear();

                    var userId = this._mainSelectorVm.User.Id;
                    this._listOfUsersBooks = await _booksDatabaseManager.GetListBooksByIdUser(userId);

                    if (this._listOfUsersBooks.Count > 0)
                    {
                        await LoadingReadingBooks();
                    }

                    this._mainSelectorVm.SelectView = new BookShelfVM();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public async Task LoadingReadingBooks()
        {
            List<Books> listBooks = new List<Books>();

            var userId = this._mainSelectorVm.User.Id;
            List<ReadingBooks> readingBooks =
                await _booksDatabaseManager.GetReadingBooksByIdUser(userId);

            if (readingBooks.Count > 0)
            {
                foreach (var readingBook in readingBooks)
                {
                    var book = (from books in this._listOfUsersBooks
                                where books.Id == readingBook.BookId
                                select books).FirstOrDefault();
                    if (book != null)
                    listBooks.Add(book);
                }
                this._mainSelectorVm.BookShelfVM.ReadingBooksList = listBooks;
            }
        }
    }
}

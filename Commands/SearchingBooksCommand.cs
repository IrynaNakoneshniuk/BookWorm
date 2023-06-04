using BookWorm.Api;
using BookWorm.DataAccess;
using BookWorm.DTO;
using BookWorm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace BookWorm.Commands
{
    public class SearchingBooksCommand : AsyncCommandBase
    {
        private readonly IBase _mainselectorVM;

        private static List<BookLibrary> _booksLibraryTmp = new List<BookLibrary>();

        private static bool _isChangeValue = false;

        public SearchingBooksCommand(IBase mainselectorVM)
        {
            this._mainselectorVM = mainselectorVM;
        }
        protected override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                if (this._mainselectorVM.Library.SearchRequest != null && this._mainselectorVM.Library.SearchRequest != "")
                {
                    _booksLibraryTmp = this._mainselectorVM.Library.BooksLibrary;
                    _isChangeValue = true;
                    string query = this._mainselectorVM.Library.SearchRequest;
                    await GetResultSearching(query);
                }
                else
                {
                    if (_isChangeValue)
                    {
                        _mainselectorVM.Library.BooksLibrary = _booksLibraryTmp;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected async Task GetResultSearching(string ?query)
        {
            try
            {
                List<BookLibrary> books = new List<BookLibrary>();
                this._mainselectorVM.Library.LibraryList = await ApisClient.SearchBookAsync(query);

                if (_mainselectorVM.Library.LibraryList.Count > 0)
                {
                    this._mainselectorVM.Library.BooksLibrary = null;
                    foreach (BookDto book in _mainselectorVM.Library.LibraryList)
                    {
                        string? url = (from i in book.Formats
                                       where i.Key == "image/jpeg"
                                       select i.Value).FirstOrDefault();
                        books.Add(new BookLibrary(book.Id, book.Title, book.Authors, url));
                    }
                    this._mainselectorVM.Library.BooksLibrary = books;
                }
                else
                {
                    MessageBox.Show("Немає результатів пошуку!");
                    this._mainselectorVM.Library.BooksLibrary = _booksLibraryTmp;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

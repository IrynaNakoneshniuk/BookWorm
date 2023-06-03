using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookWorm.Api;
using BookWorm.DataAccess;
using BookWorm.DTO;
using BookWorm.ViewModel;


namespace BookWorm.Commands
{
    public class LoadedLibraryCommad : AsyncCommandBase
    {
        private readonly IBase _mainSelectorView;

        public LoadedLibraryCommad(IBase mainSelectorView)
        {
           this._mainSelectorView = mainSelectorView;
        }
        protected override async Task ExecuteAsync(object? parameter)
        {
            _mainSelectorView.Library.LibraryList = await ApisClient.GetListBookAsync();
            foreach (BookDto book in _mainSelectorView.Library.LibraryList)
            {
                IEnumerable<string> url = from i in book.Formats
                                          where i.Key == "image/jpeg"
                                          select i.Value;
                _mainSelectorView.Library.BooksLibrary.Add(new BookLibrary(book.Id, book.Title, book.Authors, url.ToString()));
            }
        }
    }
}

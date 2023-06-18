using System.Collections.Generic;
using BookWorm.DTO;
using BookWorm.DataAccess;
using System.Windows.Input;

namespace BookWorm.ViewModel
{
    public class LibraryVM : BaseVM, ILibrary
    {
        public ICommand LoadLibrary { get; set; }
        public ICommand SearchingBooksCommand { get; set; }
        public ICommand ViewBookCommand { get; set; }

        private bool _isFieldVisibil = true;

        private static bool _isSearchingByLanguage;

        public bool IsSearchingByLanguage
        {
            get
            {
                return _isSearchingByLanguage;
            }
            set
            {
                _isSearchingByLanguage = value;
                OnPropertyChanged(nameof(IsSearchingByLanguage));
            }
        }

        public bool IsFieldVisibil
        {
            get { return _isFieldVisibil; }

            set
            {
                _isFieldVisibil = value;
                OnPropertyChanged(nameof(IsFieldVisibil));
            }
        }

        private static BookLibrary _selectedBook;

        private static string _searchRequest;

        private string _name;

        private static List<BookLibrary>? _bookslibrary;

        private IEnumerable<string?> _listOfImage;

        private List<BookDto> _libraryList;
        public BookLibrary SelectedBook {
            get
            {
                return _selectedBook;
            }
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        public string SearchRequest
        {
            get { return _searchRequest; }
            set {
                _searchRequest = value; 
                OnPropertyChanged(nameof(SearchRequest));
            }
        }
        public List<BookLibrary> BooksLibrary
        {
            get { return _bookslibrary; }
            set
            {
                _bookslibrary = value;
                OnPropertyChanged(nameof(BooksLibrary));
            }
        }
        public IEnumerable<string> ListOfImage
        {
            get { return _listOfImage; }

            set
            {
                _listOfImage = value;
                OnPropertyChanged(nameof(ListOfImage));
            }
        }
        public List<BookDto> LibraryList
        {
            get { return _libraryList; }

            set
            {
                _libraryList = value;
                OnPropertyChanged(nameof(LibraryList));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public LibraryVM()
        {
            this._libraryList = new List<BookDto>();
            this._listOfImage = new List<string>();
        }
    }
}

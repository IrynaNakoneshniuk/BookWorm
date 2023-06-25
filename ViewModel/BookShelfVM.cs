using BookWorm.ModelDB;
using System.Collections.Generic;
using System.Windows.Input;

namespace BookWorm.ViewModel
{
    public class BookShelfVM : BaseVM, IBookShelfVM
    {
        private static List<Books> ?_selectedBooksList;

        private static List<Books> ? _readingBooksList;

        private static Books ? _selectedBook;

        private bool _isVisibil = true;
        public ICommand ? ReadingModeCommand { get; set; }
        public ICommand ? RemoveFromListCommand { get; set; }
        public ICommand ? AddToReadingListCommand { get; set; }
        public ICommand ? EditCommentCommand { get; set; }

        public bool IsVisibil
        {
            get { return _isVisibil; }

            set { _isVisibil = value;
                OnPropertyChanged(nameof(IsVisibil));
            }
        }

        public  Books SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;

                OnPropertyChanged(nameof(SelectedBook));
            }
        }

       
        public List<Books> SelectedBooksList
        {
            get { return _selectedBooksList; }
            set
            {
                _selectedBooksList = value;
                OnPropertyChanged(nameof(SelectedBooksList));
            }
        }

        public List<Books> ReadingBooksList
        {
            get { return _readingBooksList; }
            set
            {
                _readingBooksList = value;
                OnPropertyChanged(nameof(ReadingBooksList));
            }
        }
    }
}

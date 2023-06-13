using BookWorm.DataAccess;
using BookWorm.ModelDB;
using System.Collections.Generic;

namespace BookWorm.ViewModel
{
    public class BookShelfVM : BaseVM, IBookShelfVM
    {
        private static List<Books> _selectedBooksList;
        private static List<Books> _readingBooksList;
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

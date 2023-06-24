using BookWorm.DataAccess;
using System.Windows.Input;

namespace BookWorm.ViewModel
{
    public class DescriptionBooKVM : BaseVM, IDescriptionBooKVM
    {

        private static string _descriptionOfBook;
        private static BookLibrary _selectedBook;

        public string DescriptionOfBook
        {
            get { return _descriptionOfBook; }
            set
            {
                _descriptionOfBook = value;
                OnPropertyChanged(nameof(DescriptionOfBook));
            }
        }

        public  BookLibrary SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }
    }
}

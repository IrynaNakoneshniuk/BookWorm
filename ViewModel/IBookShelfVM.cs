using BookWorm.ModelDB;
using System.Collections.Generic;
using System.Windows.Input;

namespace BookWorm.ViewModel
{
    public interface IBookShelfVM: IBaseVM
    {
        List<Books> ReadingBooksList { get; set; }
        List<Books> SelectedBooksList { get; set; }
        ICommand ReadingModeCommand { get; set; }
        Books SelectedBook { get; set; }
        bool IsVisibil { get; set; }
        ICommand RemoveFromListCommand { get; set; }
        ICommand AddToReadingListCommand { get; set; }
        ICommand EditCommentCommand { get; set; }
    }
}
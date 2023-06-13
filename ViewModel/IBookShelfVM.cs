using BookWorm.DataAccess;
using BookWorm.ModelDB;
using System.Collections.Generic;

namespace BookWorm.ViewModel
{
    public interface IBookShelfVM: IBaseVM
    {
        List<Books> ReadingBooksList { get; set; }
        List<Books> SelectedBooksList { get; set; }
    }
}
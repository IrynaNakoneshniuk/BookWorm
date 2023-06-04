using BookWorm.DataAccess;
using BookWorm.DTO;
using System.Collections.Generic;
using System.Windows.Input;

namespace BookWorm.ViewModel
{
    public interface ILibrary:IBaseVM
    {
        List<BookLibrary> BooksLibrary { get; set; }
        List<BookDto> LibraryList { get; set; }
        IEnumerable<string> ListOfImage { get; set; }
        ICommand LoadLibrary { get; set; }
        ICommand SearchingBooksCommand { get; set; }
        string Name { get; set; }
        string SearchRequest { get; set; }
    }
}
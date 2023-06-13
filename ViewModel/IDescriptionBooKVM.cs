using BookWorm.DataAccess;
using System.Windows.Input;

namespace BookWorm.ViewModel
{
    public interface IDescriptionBooKVM: IBaseVM
    {
        string DescriptionOfBook { get; set; }
        public BookLibrary SelectedBook { get; set; }
        ICommand AddToSelectedCommand { get; set; }
    }
}
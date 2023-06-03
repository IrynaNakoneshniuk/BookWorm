using System.ComponentModel;

namespace BookWorm.ViewModel
{
    public interface IBaseVM
    {
        event PropertyChangedEventHandler PropertyChanged;
    }
}
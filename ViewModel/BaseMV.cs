using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BookWorm.ViewModel
{
    public class BaseVM : INotifyPropertyChanged, IBaseVM
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

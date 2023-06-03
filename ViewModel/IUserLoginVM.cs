using System.Windows.Input;

namespace BookWorm.ViewModel
{
    public interface IUserLoginVM: IBaseVM
    {
        string Error { get; set; }
        bool IsFieldVisibil { get; set; }
        string? Password { get; set; }
        string? UserEmail { get; set; }
        public ICommand ValidationCommand { get; set; }
        public ICommand Loggin { get; set; }
    }
}
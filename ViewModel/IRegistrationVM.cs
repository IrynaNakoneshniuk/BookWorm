using System.Windows.Input;

namespace BookWorm.ViewModel
{
    public interface IRegistrationVM: IBaseVM
    {
        string Email { get; set; }
        bool IsFormVisibil { get; set; }
        string Login { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        string Repassword { get; set; }
        string Surname { get; set; }
        public ICommand RegistrationUserCommand { get; set; }
    }
}
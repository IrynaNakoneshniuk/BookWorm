using System.Windows.Input;

namespace BookWorm.ViewModel
{
    public class UserLoginVM : BaseVM, IUserLoginVM
    {
        public ICommand? ValidationCommand { get; set; }
        public ICommand? Loggin { get; set; }
        private string? _userEmail;

        private string? _password;

        private bool _isFieldVisibil = true;

        private string ?_error;

        public string Error
        {
            get { return _error; }
            set
            {
                _error = value;
                OnPropertyChanged(nameof(Error));
            }
        }
        public bool IsFieldVisibil
        {
            get { return _isFieldVisibil; }

            set
            {
                _isFieldVisibil = value;
                OnPropertyChanged(nameof(IsFieldVisibil));
            }
        }
        public string? UserEmail
        {
            get { return _userEmail; }
            set
            {
                _userEmail = value;
                OnPropertyChanged(nameof(UserEmail));

            }
        }

        public string? Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
    }
}

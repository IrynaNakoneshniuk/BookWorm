using System.Windows.Input;

namespace BookWorm.ViewModel
{
    public class RecoveryPasswordVM : BaseVM, IRecoveryPasswordVM
    {
        private string _errorMessage;

        private static int? _recoveryCode;

        private static bool _isFormVisibil = true;

        private string _email;

        private string _password;

        private string _repassword;

        private bool _isCodeFieldEnable=false;

        private bool _isPasswordFieldEnable=false;
        public ICommand RecoveryPasswordCommand { get; set; }

        public bool IsFormVisibil
        {
            get { return _isFormVisibil; }
            set
            {
                _isFormVisibil = value;
                OnPropertyChanged(nameof(IsFormVisibil));
            }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public int? RecoveryCode
        {
            get { return _recoveryCode; }
            set
            {
                _recoveryCode = value;
                OnPropertyChanged(nameof(RecoveryCode));
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Repassword
        {
            get { return _repassword; }
            set
            {
                _repassword = value;
                OnPropertyChanged(nameof(Repassword));
            }
        }

        public bool IsCodeFieldEnable
        {
            get { return _isCodeFieldEnable; }
            set
            {
                _isCodeFieldEnable = value;
                OnPropertyChanged(nameof(IsCodeFieldEnable));
            }
        }

        public bool IsPasswordFieldEnable
        {
            get { return _isPasswordFieldEnable; }
            set
            {
                _isPasswordFieldEnable = value;
                OnPropertyChanged(nameof(IsPasswordFieldEnable));
            }
        }
    }
}

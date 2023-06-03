using System.Windows.Input;
using BookWorm.Commands;

namespace BookWorm.ViewModel
{
    public class ValidationEmailVM : BaseVM, IValidatioinEmailVM
    {
        public ICommand ValidationCommand { get; set; }

        private static string _email;

        private string _code;

        private string _message;

        private bool _isFieldVisibility = false;
        public ValidationEmailVM()
        {
            this.ValidationCommand = new ValidationEmailCommand(this);
        }

        public bool IsFieldVisible
        {
            get
            {
                return _isFieldVisibility;
            }
            set
            {
                _isFieldVisibility = value;
                OnPropertyChanged(nameof(IsFieldVisible));
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

        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                OnPropertyChanged(nameof(Code));
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
    }
}

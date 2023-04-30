using System.Windows.Input;
using BookWorm.Commands;
using BookWorm.ModelDB;

namespace BookWorm.ViewModel
{
    public class MainVM : BaseVM
    {
        public ICommand SelectViewCommand { get; set; }

        public ICommand ValidationCommand { get; set; }

        public ICommand RegistrationUserCommand { get; set; }

        public ICommand Loggin { get; set; }

        private bool _isControlVisibility = true;

        private BaseVM _baseVM;

        private ValidationEmailVM _validationVM;

        private RegistrationVM _registrationVM;

        private LibraryVM _library;

        private UserLoginVM _userLogin;

        private Users _users;

        public Users User
        {
            get { return _users; }

            set
            {
                _users = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private string _email;

        private string _name;

        public UserLoginVM LogginUser {

            get { return _userLogin; }

            set
            {
                _userLogin = value;
                OnPropertyChanged(nameof(LogginUser));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = _validationVM.Email;
                OnPropertyChanged(nameof(Email));
            }
        }

        public BaseVM SelectView 
        {  
            get { return _baseVM; }

           set
           {
               _baseVM = value;
               OnPropertyChanged(nameof(SelectView));
           }
        }

        public LibraryVM Library
        {
            get
            {
                return _library;
            }
            set
            {
                _library = value;
                OnPropertyChanged(nameof(Library));
            }
        }

        public RegistrationVM Registration
        {
            get { return _registrationVM; }
            set
            {
                _registrationVM = value;
                OnPropertyChanged(nameof(Registration));
            }
        }


        public ValidationEmailVM ValidationVM
        {
            get { return _validationVM; }
            set
            {
                _validationVM = value;
                OnPropertyChanged(nameof(ValidationVM));
            }
        }

        public MainVM() {

            this._baseVM = this;
            this._validationVM =new ValidationEmailVM();
            this._registrationVM = new RegistrationVM();
            this._library = new LibraryVM();
            this._userLogin = new UserLoginVM();
            this.Loggin = new LogginCommand(this);
            this.SelectViewCommand = new SelectViewCommand(this);
            this.ValidationCommand = new ValidationEmailCommand(_validationVM);
            this.RegistrationUserCommand = new RegistrationCommand(this);
        }

        public bool IsControlAVisible
        {
            get { return _isControlVisibility; }
            set
            {
                _isControlVisibility = value;
                OnPropertyChanged(nameof(IsControlAVisible));
            }
        }
    }
}


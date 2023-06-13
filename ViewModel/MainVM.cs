using System.Windows.Input;
using BookWorm.ModelDB;

namespace BookWorm.ViewModel
{
    public class MainVM : BaseVM, IBase
    {
        public ICommand SelectViewCommand { get; set; }
        public IBase Base { get; set; }

        private bool _isControlVisibility = true;

        private IBaseVM _baseVM;

        private IValidatioinEmailVM _validationVM;

        private IRegistrationVM _registrationVM;

        private ILibrary _library;

        private IUserLoginVM _userLogin;

        private IDescriptionBooKVM _descriptionBooKVm;

        private static Users _users;

        public IDescriptionBooKVM DescriptionBooKVm
        {
            get { return _descriptionBooKVm; }
            set
            {
                _descriptionBooKVm=value;
                OnPropertyChanged(nameof(DescriptionBooKVm));
            }
        }

        public Users User
        {
            get { return _users; }

            set
            {
                _users = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public IUserLoginVM LogginUser
        {

            get { return _userLogin; }

            set
            {
                _userLogin = value;
                OnPropertyChanged(nameof(LogginUser));
            }
        }

        public IBaseVM? SelectView
        {
            get { return _baseVM; }

            set
            {
                _baseVM = value;
                OnPropertyChanged(nameof(SelectView));
            }
        }

        public ILibrary Library
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

        public IRegistrationVM Registration
        {
            get { return _registrationVM; }
            set
            {
                _registrationVM = value;
                OnPropertyChanged(nameof(Registration));
            }
        }


        public IValidatioinEmailVM ValidationVM
        {
            get { return _validationVM; }
            set
            {
                _validationVM = value;
                OnPropertyChanged(nameof(ValidationVM));
            }
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

        public MainVM(IUserLoginVM userLoginVM, ILibrary libraryVM, IRegistrationVM registrationVM,
            IValidatioinEmailVM validatioinEmailVM,IDescriptionBooKVM descriptionBooKVm)
        {
            this._baseVM = this;
            this._descriptionBooKVm= descriptionBooKVm;
            this._validationVM = validatioinEmailVM;
            this._registrationVM = registrationVM;
            this._library = libraryVM;
            this._userLogin = userLoginVM;
        }
    }
}


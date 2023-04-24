
using System.Windows.Input;
using BookWorm.Commands;

namespace BookWorm.ViewModel
{
    public class MainVM: BaseVM
    {
      public ICommand SelectViewCommand { get; set; }

      public ICommand ValidationCommand { get; set; }

      public ICommand RegistrationUserCommand { get; set; }

        private bool _isControlVisibility=true;

      private BaseVM _baseVM;

      private ValidationEmailVM _validationVM;

      private RegistrationVM _registrationVM;

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {

                _email = value;
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

        public RegistrationVM Registration
        {
            get { return _registrationVM; }
            set
            {
                _registrationVM = value;
                OnPropertyChanged(nameof(RegistrationVM));
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
            this.SelectViewCommand = new SelectViewCommand(this);
            this.ValidationCommand = new ValidationEmailCommand(_validationVM);
            this.RegistrationUserCommand = new RegistrationCommand(_registrationVM);
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


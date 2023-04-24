
using System;
using System.Windows.Input;
using BookWorm.Commands;

namespace BookWorm.ViewModel
{
    public class ValidationEmailVM:BaseVM
    {
        public ICommand ValidationCommand { get; set; }


        private string _email;

        private string _code;

        private string _message;

        public ValidationEmailVM()
        {
            this.ValidationCommand = new ValidationEmailCommand(this);
        }


        public string Email
        {
            get { return _email; }
            set { 
                
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

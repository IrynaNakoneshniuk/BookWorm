using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.ViewModel
{
   public class RegistrationVM:BaseVM
    {
        private string _name;
        private string _surname;
        private string _login;
        private string _password;
        private string _repassword;
        private string _email;
        private bool _isFormVisibil = true;

        public bool IsFormVisibil
        {
            get { return _isFormVisibil; }
            set
            {
                _isFormVisibil = value;
                OnPropertyChanged(nameof(IsFormVisibil));
            }
        }


        public string Email
        {
            get { return _email; }
            set { 
                
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }


        public string Repassword
        {
            get { return _repassword; }
            set { 

                _repassword = value;
                OnPropertyChanged(nameof(Repassword));
            }
        }
        public string Login
        {
            get { return _login; }
            set { 
              _login = value; 
              OnPropertyChanged(nameof(Login));
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

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
    }
}

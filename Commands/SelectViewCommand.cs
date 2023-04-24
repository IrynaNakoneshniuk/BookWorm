using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BookWorm.Services;
using BookWorm.ViewModel;


namespace BookWorm.Commands
{
    public class SelectViewCommand : AsyncCommandBase
    {
        private readonly MainVM _mainSelectorView;


        public SelectViewCommand(MainVM mainSelectorView)
        {
            _mainSelectorView = mainSelectorView;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                if (parameter.ToString() == "Registration")
                {
                   
                    if (_mainSelectorView.ValidationVM.Code == DigitCodeGenerator.ConfirmCode.ToString())
                    {
                        _mainSelectorView.IsControlAVisible = false;
                        _mainSelectorView.SelectView = new RegistrationVM();
                        _mainSelectorView.Email= _mainSelectorView.ValidationVM.Email;
                    }
                    else
                    {
                        _mainSelectorView.ValidationVM.Message = "Не вірно вказаний код!";
                        _mainSelectorView.ValidationVM.Code = null;
                    }
            
                }
                else if (parameter.ToString() == "Login")
                {
                    _mainSelectorView.SelectView = new UserLoginVM();
                }
                else if (parameter.ToString() == "Shelf")
                {
                    _mainSelectorView.SelectView = new BookShelfVM();
                }
                else if (parameter.ToString() == "Library")
                {
                    _mainSelectorView.SelectView = new LibraryVM();
                }
                else if(parameter.ToString() == "Validation")
                {
                    _mainSelectorView.SelectView = new ValidationEmailVM();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}

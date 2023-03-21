using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BookWorm.ViewModel;


namespace BookWorm.Commands
{
    public class SelectViewCommand : AsyncCommandBase
    {
        private readonly MainVM _mainSelectorView;

        public SelectViewCommand(MainVM mainVM, Action<Exception> ex):base(ex)
        {
            _mainSelectorView = mainVM;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                if (parameter.ToString() == "Registration")
                {
                    _mainSelectorView.SelectView = new RegistrationVM();
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
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}

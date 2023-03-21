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
    public class SelectViewCommand : ICommand
    {
        private MainVM mainSelectorView;
        public SelectViewCommand(MainVM mainVM) {
            mainSelectorView = mainVM;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public  void Execute(object? parameter)
        {
            try
            {
                if (parameter.ToString() == "Registration")
                {
                    mainSelectorView.SelectView = new RegistrationVM();
                }
                else if(parameter.ToString()== "Login")
                {
                    mainSelectorView.SelectView= new UserLoginVM();
                }
                else if(parameter.ToString()== "Shelf")
                {
                    mainSelectorView.SelectView =new BookShelfVM();
                }
                else if(parameter.ToString()=="Library")
                {
                    mainSelectorView.SelectView = new LibraryVM();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }

}

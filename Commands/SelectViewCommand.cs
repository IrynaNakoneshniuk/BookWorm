using System;
using System.Threading.Tasks;
using System.Windows;
using BookWorm.Services;
using BookWorm.ViewModel;


namespace BookWorm.Commands
{
    public class SelectViewCommand : AsyncCommandBase
    {
        private readonly IBase _mainSelectorView;

        public SelectViewCommand(IBase mainSelectorView)
        {
            _mainSelectorView = mainSelectorView;
        }

        protected override  async Task ExecuteAsync(object? parameter)
        {
            await Task.Run(() =>
            {
                try
                {
                    if (parameter.ToString() == "Registration")
                    {
                        if (_mainSelectorView.ValidationVM.Code == DigitCodeGenerator.ConfirmCode.ToString())
                        {
                            _mainSelectorView.IsControlAVisible = false;
                            _mainSelectorView.SelectView = _mainSelectorView.Registration;

                        }
                        else
                        {
                            _mainSelectorView.ValidationVM.Message = "Не вірно вказаний код!";
                            _mainSelectorView.ValidationVM.Code = null;
                        }

                    }
                    else if (parameter.ToString() == "Login")
                    {
                        _mainSelectorView.SelectView = _mainSelectorView.LogginUser;
                    }
                    else if (parameter.ToString() == "Shelf")
                    {
                        if (_mainSelectorView.User != null)
                        {
                            _mainSelectorView.SelectView = new BookShelfVM();
                        }
                    }
                    else if (parameter.ToString() == "Library")
                    {
                        if(_mainSelectorView.User != null)
                        {
                            _mainSelectorView.SelectView = _mainSelectorView.Library;
                        }
                    }
                    else if (parameter.ToString() == "Validation")
                    {
                        _mainSelectorView.SelectView = _mainSelectorView.ValidationVM;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }
    }
}

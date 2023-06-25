using BookWorm.ViewModel;
using System.Threading.Tasks;
using System.Windows;
using System;

namespace BookWorm.Commands
{
    public class ExitCommand : AsyncCommandBase
    {
        private IBase _mainSelectroVM;
        public ExitCommand(IBase mainSelectroVM)
        {
            this._mainSelectroVM = mainSelectroVM;
        }
        protected override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                await Task.Run(() => {

                    this._mainSelectroVM.User = null;
                    this._mainSelectroVM.Library.BooksLibrary?.Clear();
                    this._mainSelectroVM.BookShelfVM.ReadingBooksList?.Clear();
                    this._mainSelectroVM.BookShelfVM.SelectedBooksList?.Clear();
                    this._mainSelectroVM.SelectView = null;

                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

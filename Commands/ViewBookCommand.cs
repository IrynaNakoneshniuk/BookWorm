using BookWorm.Api;
using BookWorm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookWorm.Commands
{
    public class ViewBookCommand : AsyncCommandBase
    {
        private IBase _mainSelelectorVm;

        public ViewBookCommand(IBase mainSelelectorVm)
        {
            this._mainSelelectorVm = mainSelelectorVm;  
        }
        protected override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                if (this._mainSelelectorVm.Library.SelectedBook != null)
                {
                    this._mainSelelectorVm.DescriptionBooKVm.SelectedBook =
                   this._mainSelelectorVm.Library.SelectedBook;
                    this._mainSelelectorVm.DescriptionBooKVm.DescriptionOfBook =
                        await ApisClient.GetBookTextAsync(this._mainSelelectorVm.DescriptionBooKVm.SelectedBook.Id.ToString());
                    this._mainSelelectorVm.Library.IsFieldVisibil = false;
                    this._mainSelelectorVm.SelectView = this._mainSelelectorVm.DescriptionBooKVm;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

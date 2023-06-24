using BookWorm.Api;
using BookWorm.DataAccess;
using BookWorm.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
                var selectedBook = parameter as ListViewItem;
                BookLibrary bookLibrary = selectedBook.Content as BookLibrary;
                

                if (bookLibrary != null)
                {
                    this._mainSelelectorVm.DescriptionBooKVm.SelectedBook = bookLibrary;    
                    string ? bookText = await ApisClient.GetBookTextAsync(bookLibrary.Id.ToString());
                    if (bookText.Split("CONTENTS").Length > 1)
                    {
                        this._mainSelelectorVm.DescriptionBooKVm.DescriptionOfBook = bookText.Split("CONTENTS")[1];
                    }
                    else
                    {
                        this._mainSelelectorVm.DescriptionBooKVm.DescriptionOfBook = bookText;
                    }
                    
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

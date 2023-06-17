using BookWorm.DataAccess;
using BookWorm.ModelDB;
using BookWorm.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BookWorm.Commands
{
    public class EditСommentСommand : AsyncCommandBase
    {
        private IBase _mainselectorVm;

        public EditСommentСommand(IBase mainselectorVm)
        {
            this._mainselectorVm = mainselectorVm;
        }
        protected async override Task ExecuteAsync(object? parameter)
        {
            try
            {
                var selectedBook = parameter as ListViewItem;
                Books? book = selectedBook.Content as Books;
                if (book!= null)
                {
                    BooksDatabaseManager booksDatabaseManager = new BooksDatabaseManager();
                    await booksDatabaseManager.EditCommentByBookId((int)book.Id, book.Comment);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }
    }
}

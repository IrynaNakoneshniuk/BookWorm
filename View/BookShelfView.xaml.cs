using Autofac;
using BookWorm.Commands;
using BookWorm.Services;
using BookWorm.ViewModel;
using System.Windows.Controls;


namespace BookWorm.View
{
    /// <summary>
    /// Interaction logic for BookShelfView.xaml
    /// </summary>
    public partial class BookShelfView : UserControl
    {
        private readonly IBase _mainselectorVm;
        public BookShelfView()
        {
            var container = AutofacModule.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                this._mainselectorVm = scope.Resolve<IBase>();
                this._mainselectorVm.BookShelfVM.ReadingModeCommand=scope.Resolve<ReadingModeCommand>();
                this._mainselectorVm.BookShelfVM.RemoveFromListCommand=scope.Resolve<RemoveFromListCommand>();  
                this._mainselectorVm.BookShelfVM.AddToReadingListCommand=scope.Resolve<AddToReadingListCommand>();
                this._mainselectorVm.BookShelfVM.EditCommentCommand = scope.Resolve<EditСommentСommand>();
                InitializeComponent();
                this.DataContext = this._mainselectorVm;
            }
        }
    }
}

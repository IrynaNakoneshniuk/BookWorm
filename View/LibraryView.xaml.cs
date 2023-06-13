using Autofac;
using BookWorm.Commands;
using BookWorm.DataAccess;
using BookWorm.Services;
using BookWorm.ViewModel;
using CommonServiceLocator;
using System.Windows.Controls;
using System.Windows.Input;

namespace BookWorm.View
{
    /// <summary>
    /// Interaction logic for LibraryView.xaml
    /// </summary>
    public partial class LibraryView : UserControl
    {
        private readonly IBase _mainselectorVm;
        public static KeyGesture KeyCommandAction1 { get { return new KeyGesture(Key.Enter); } }
        public LibraryView()
        {
            var container = AutofacModule.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                this._mainselectorVm = scope.Resolve<IBase>();
                this._mainselectorVm.Library.LoadLibrary = scope.Resolve<LoadedLibraryCommad>();
                this._mainselectorVm.Library.SearchingBooksCommand = scope.Resolve<SearchingBooksCommand>();
                this._mainselectorVm.Library.ViewBookCommand= scope.Resolve<ViewBookCommand>();

                InitializeComponent();
                this.DataContext = this._mainselectorVm;
            }
        }
    }
}

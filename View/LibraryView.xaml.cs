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
        private readonly IBase mainselectorVm;
        public static KeyGesture KeyCommandAction1 { get { return new KeyGesture(Key.Enter); } }
        public LibraryView()
        {
            var container = AutofacModule.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                this.mainselectorVm = scope.Resolve<IBase>();
                this.mainselectorVm.Library.LoadLibrary = scope.Resolve<LoadedLibraryCommad>();
                this.mainselectorVm.Library.SearchingBooksCommand = scope.Resolve<SearchingBooksCommand>();
                this.mainselectorVm.Library.ViewBookCommand= scope.Resolve<ViewBookCommand>();
                this.mainselectorVm.Library.AddToSelectedCommand= scope.Resolve<AddToSelectedCommand>();

                InitializeComponent();
                this.DataContext = this.mainselectorVm;
            }
        }
    }
}

using Autofac;
using BookWorm.Commands;
using BookWorm.Services;
using BookWorm.ViewModel;
using CommonServiceLocator;
using System.Windows.Controls;

namespace BookWorm.View
{
    /// <summary>
    /// Interaction logic for LibraryView.xaml
    /// </summary>
    public partial class LibraryView : UserControl
    {
        private readonly IBase _mainselectorVm;
        public LibraryView()
        {
            var container = AutofacModule.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                this._mainselectorVm = scope.Resolve<IBase>();
                this._mainselectorVm.Library.LoadLibrary = scope.Resolve<LoadedLibraryCommad>();
            }

            InitializeComponent();
            this.DataContext = this._mainselectorVm;
        }
    }
}

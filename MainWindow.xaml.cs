using BookWorm.ViewModel;
using System.Windows;
using BookWorm.Commands;
using BookWorm.Services;
using Autofac;

namespace BookWorm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IBase _mainselectorVm;
        public MainWindow()
        {
            var container = AutofacModule.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                this._mainselectorVm = scope.Resolve<IBase>();
                this._mainselectorVm.SelectViewCommand= new SelectViewCommand(this._mainselectorVm);
                this._mainselectorVm.LoadingShelfCommand = scope.Resolve<LoadingBookShelfCommand>();
                this._mainselectorVm.ExitCommand=scope.Resolve<ExitCommand>();
            }

            InitializeComponent();
            this.DataContext = this._mainselectorVm;
        }
    }
}

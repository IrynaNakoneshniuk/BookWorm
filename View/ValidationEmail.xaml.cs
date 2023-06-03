using System.Windows.Controls;
using BookWorm.ViewModel;
using Autofac;
using BookWorm.Services;
using BookWorm.Commands;

namespace BookWorm.View
{
    /// <summary>
    /// Interaction logic for ValidationEmail.xaml
    /// </summary>
    public partial class ValidationEmail : UserControl
    {
        private readonly IBase _mainselectorVm;
        public ValidationEmail()
        {
            var container = AutofacModule.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                this._mainselectorVm = scope.Resolve<IBase>();
                _mainselectorVm.LogginUser= scope.Resolve<IUserLoginVM>();
                _mainselectorVm.LogginUser.ValidationCommand = scope.Resolve<ValidationEmailCommand>();
            }

            InitializeComponent();
            this.DataContext = this._mainselectorVm;
        }
    }
}

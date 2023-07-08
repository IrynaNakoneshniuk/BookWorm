using Autofac;
using BookWorm.Services;
using BookWorm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookWorm.Commands;
using CommonServiceLocator;

namespace BookWorm.View
{
    /// <summary>
    /// Interaction logic for UserLoginView.xaml
    /// </summary>
    public partial class UserLoginView : UserControl
    {
        private readonly IBase _mainselectorVm;
        public UserLoginView()
        {
            var container = AutofacModule.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                this._mainselectorVm= scope.Resolve<IBase>();
                this._mainselectorVm.LogginUser.ValidationCommand = scope.Resolve<ValidationEmailCommand>();
                this._mainselectorVm.SelectViewCommand = new SelectViewCommand(this._mainselectorVm);
                this._mainselectorVm.LogginUser.Loggin = scope.Resolve<LogginCommand>();
            }

            InitializeComponent();
            this.DataContext = this._mainselectorVm;
        }
    }
}

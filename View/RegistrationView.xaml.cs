using BookWorm.ViewModel;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
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
using BookWorm.DataAccess;
using BookWorm.Commands;
using Autofac;
using BookWorm.Services;

namespace BookWorm.View
{
    /// <summary>
    /// Interaction logic for RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : UserControl
    {
        private readonly IBase _mainselectorVm;
        public RegistrationView()
        {
            var container = AutofacModule.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                this._mainselectorVm = scope.Resolve<IBase>();
                this._mainselectorVm.Registration.RegistrationUserCommand = 
                    scope.Resolve<RegistrationCommand>();
            }

            InitializeComponent();
            this.DataContext = this._mainselectorVm;
        }
    }
}

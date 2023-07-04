using Autofac;
using BookWorm.Commands;
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

namespace BookWorm.View
{
    /// <summary>
    /// Interaction logic for RecoveryPasswordView.xaml
    /// </summary>
    public partial class RecoveryPasswordView : UserControl
    {
        private readonly IBase mainselectorVm;
        public RecoveryPasswordView()
        {
            var container = AutofacModule.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                this.mainselectorVm = scope.Resolve<IBase>();
                this.mainselectorVm.RecoveryPasswordVM.RecoveryPasswordCommand=scope.Resolve<PasswordRecoveryCommand>();    
                InitializeComponent();
                this.DataContext = this.mainselectorVm;
            }
        }
    }
}

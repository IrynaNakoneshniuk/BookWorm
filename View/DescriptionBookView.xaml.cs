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

namespace BookWorm.View
{
    /// <summary>
    /// Interaction logic for DescriptionBookView.xaml
    /// </summary>
    public partial class DescriptionBookView : UserControl
    {
        private readonly IBase _mainselectorVm;
        public DescriptionBookView()
        {
            var container = AutofacModule.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                this._mainselectorVm = scope.Resolve<IBase>();
                this._mainselectorVm.DescriptionBooKVm.AddToSelectedCommand=scope.Resolve<AddToSelectedCommand>();  
                InitializeComponent();
                this.DataContext = this._mainselectorVm;
            }
        }
    }
}

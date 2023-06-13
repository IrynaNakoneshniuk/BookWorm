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
                InitializeComponent();
                this.DataContext = this._mainselectorVm;
            }
        }
    }
}

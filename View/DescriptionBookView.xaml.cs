using Autofac;
using BookWorm.Services;
using BookWorm.ViewModel;

using System.Windows.Controls;

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
                InitializeComponent();
                this.DataContext = this._mainselectorVm;
            }
        }
    }
}

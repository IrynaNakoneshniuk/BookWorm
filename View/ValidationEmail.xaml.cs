
using System.Windows.Controls;
using BookWorm.ViewModel;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using BookWorm.DataAccess;

namespace BookWorm.View
{
    /// <summary>
    /// Interaction logic for ValidationEmail.xaml
    /// </summary>
    public partial class ValidationEmail : UserControl
    {
        private readonly MainVM mainVM;
        public ValidationEmail()
        {
            InitializeComponent();
            mainVM = new MainVM();
            this.DataContext = mainVM;
        }
    }
}

using Autofac;
using BookWorm.Commands;
using BookWorm.Services;
using BookWorm.ViewModel;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls;



namespace BookWorm.View
{
    /// <summary>
    /// Interaction logic for ReadingModeView.xaml
    /// </summary>
    public partial class ReadingModeView : UserControl
    {
        private  IBase _mainselectorVm;
        private List<string> langauges;
        public ReadingModeView()
        {
            var container = AutofacModule.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                this._mainselectorVm = scope.Resolve<IBase>();
                this._mainselectorVm.ReadingModeVM.TranslateWordCommand = scope.Resolve<TranslateWordCommand>();
                langauges = new List<string> { "lzh", "hr", "da", "cs", "fr", "en", "ka", "de", "uk", "tr" };
                
                InitializeComponent();

                this.toLn.ItemsSource = langauges;
                this.fromLn.ItemsSource = langauges;
                this.DataContext = this._mainselectorVm;
            }
        }
    }
}

using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BookWorm.Commands;

namespace BookWorm.ViewModel
{
    public class MainVM: BaseVM
    {
      public ICommand SelectViewCommand { get; set; }

      private BaseVM _baseVM;

      public BaseVM SelectView {

       get { return _baseVM; }

       set
       {
            _baseVM = value;
            OnPropertyChanged(nameof(SelectView));
       }
      }


      public MainVM() {
            _baseVM = this;
            SelectViewCommand = new SelectViewCommand(this, (ex)=>new Exception());
      }
    }
}

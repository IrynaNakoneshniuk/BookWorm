using BookWorm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.Commands
{
    public class AddToSelectedCommand : AsyncCommandBase
    {
        private IBase _mainSelectedVm;
        public AddToSelectedCommand(IBase mainSelectedVm) { 

            this._mainSelectedVm= mainSelectedVm;
        }
        protected override Task ExecuteAsync(object? parameter)
        {
            throw new NotImplementedException();
        }


    }
}

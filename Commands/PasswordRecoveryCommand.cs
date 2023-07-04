using BookWorm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.Commands
{
    public class PasswordRecoveryCommand : AsyncCommandBase
    {
        private IBase _mainSelectorVm;

        public PasswordRecoveryCommand(IBase mainSelectorVm)
        {
            this._mainSelectorVm = mainSelectorVm;
        }
        protected override Task ExecuteAsync(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}

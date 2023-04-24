using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BookWorm.Commands
{
    public abstract class AsyncCommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private bool _isExecuting;

        private readonly Action<Exception> _onException;


        public bool IsExecuting
        {
            get { return _isExecuting; }
            set
            {
                _isExecuting = value;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }


        public bool CanExecute(object? parameter)
        {
            return !IsExecuting;
        }


        public async void Execute(object? parameter)
        {
            IsExecuting = true;
            try
            {
                await ExecuteAsync(parameter);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            IsExecuting= false;
        }
        protected abstract Task ExecuteAsync(object? parameter);
    }
}

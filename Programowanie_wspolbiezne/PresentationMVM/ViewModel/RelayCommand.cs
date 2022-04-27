using System.Windows.Input;

namespace PresentationMVM.ViewModel.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler? CanExecuteChanged;
        public RelayCommand(Action execute) : this(execute, null) { }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }



        public bool CanExecute(object parameter)
        {
            if (_canExecute == null) return true;
            if (parameter == null) return _canExecute();

            return _canExecute();
        }

        public virtual void Execute(object parameter)
        {
            this._execute();
        }

        internal void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

﻿using System;
using System.Windows.Input;

namespace PresentationModelViewModel.ViewModel
{
    public class RelayCommand : ICommand
    {
        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/>  class that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic encapsulated by the <paramref name="execute"/> delegate. </param>
        /// <exception cref="T:System.ArgumentNullException">If the <paramref name="execute"/> argument is null.</exception>
        public RelayCommand(Action execute) : this(execute, null) { }
        /// <summary>
        /// Initializes a new instance of the RelayCommand class.
        /// </summary>
        /// <param name="canExecute">The execution status logic encapsulated by the <paramref name="canExecute"/> delegate.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">If the execute argument is null.</exception>
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            this.mExecute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.mCanExecute = canExecute;
        }
        #endregion

        #region ICommand
        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command. Because the command does not require data 
        /// to be passed, this parameter is always ignored</param>
        /// <returns><c>true</c> if this command can be executed; otherwise, <c>false</c>.</returns>
        public bool CanExecute(object parameter)
        {
            if (this.mCanExecute == null)
                return true;
            if (parameter == null)
                return this.mCanExecute();
            return this.mCanExecute();
        }
        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. Because the command does not require data 
        /// to be passed, this parameter is always ignored</param>
        public virtual void Execute(object parameter)
        {
            this.mExecute();
        }
        /// <summary>
        /// Occurs when changes occur that affect whether the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;
        #endregion

        #region API
        /// <summary>
        /// Raises the <see cref="CanExecuteChanged" /> event.
        /// </summary>
        internal void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region private
        private readonly Action mExecute;
        private readonly Func<bool> mCanExecute;
        #endregion
    }
}

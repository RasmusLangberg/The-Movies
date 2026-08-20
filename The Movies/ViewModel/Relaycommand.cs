using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using The_Movies.Model.Repository;
using The_Movies.Model;
using The_Movies.ViewModel;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace The_Movies.ViewModel
{
    public class RelayCommand : ICommand
    {

        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;

        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }


        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}

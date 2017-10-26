using System;
using System.Windows.Input;

namespace FileComparer {
    class Command : ICommand {
        public Command(Action action, Func<bool> canExecute) {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        readonly Action action;
        readonly Func<bool> canExecute;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) {
            return canExecute();
        }

        public void Execute(object parameter) {
            action();
        }
    }
}
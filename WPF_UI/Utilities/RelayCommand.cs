using System.Windows.Input;

namespace WPF.Utilities
{
    /// <summary>
    /// Implementierung des ICommand-Interfaces für die Verwendung von Befehlen in der Benutzeroberfläche.
    /// </summary>
    class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;          // Aktion, die bei Ausführung des Befehls durchgeführt wird
        private readonly Func<object, bool> _canExecute;    // Funktion zur Überprüfung, ob der Befehl ausgeführt werden kann

        /// Ereignis, das ausgelöst wird, wenn sich die Ausführbarkeit des Befehls ändert.
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }     // Fügt den Delegaten dem RequerySuggested-Ereignis des CommandManagers hinzu
            remove { CommandManager.RequerySuggested -= value; }  // Entfernt den Delegaten vom RequerySuggested-Ereignis des CommandManagers
        }

        // Konstruktor für den RelayCommand.
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute; //Aktion, die bei Ausführung des Befehls durchgeführt wird
            _canExecute = canExecute; //Funktion zur Überprüfung, ob der Befehl ausgeführt werden kann
        }

        // Überprüft, ob der Befehl ausgeführt werden kann.
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter); //True, wenn der Befehl ausgeführt werden kann; andernfalls False.

        /// Führt den Befehl aus.
        public void Execute(object parameter) => _execute(parameter);
    }
}

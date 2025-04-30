using System;
using System.Windows.Input;

namespace GymFlash
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> ejecutar;
        private readonly Func<object, bool> puedeEjecutar;

        public RelayCommand(Action<object> ejecutar, Func<object, bool> puedeEjecutar = null)
        {
            this.ejecutar = ejecutar;
            this.puedeEjecutar = puedeEjecutar;
        }

        public bool CanExecute(object parametro) => puedeEjecutar == null || puedeEjecutar(parametro);

        public void Execute(object parametro) => ejecutar(parametro);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}

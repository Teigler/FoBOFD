using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExplorerTree.Utils
{
    /// <summary>
    /// Open Source Klassse -> oopbase.de/wpf-relaycommmand
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RelayCommand<T> : ICommand
    {
        /// <summary>
        /// Die Aktion zum Ausführen
        /// </summary>
        private readonly Action<T> execute;

        /// <summary>
        /// Aussage ob Kommando ausgeführt werden kann
        /// </summary>
        private readonly Predicate<T> canExecute;

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Instanziieren der Klasse 
        /// </summary>
        /// <param name="execute"></param>
        public RelayCommand(Action<T> execute) : this(execute, (Predicate<T>)null)
        {
        }

        /// <summary>
        /// Instanziieren der Klassse
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute");
            this.canExecute = canExecute;
        }


        public void RaiseCanExecuteChanged()
        {
            // ISSUE: reference to a compiler-generated field
            EventHandler eventHandler = this.CanExecuteChanged;
            if (eventHandler == null)
            {
                return;
            }
            EventArgs e = EventArgs.Empty;
            eventHandler((object)this, e);
        }
        public bool CanExecute(object parameter)
        {
            if (this.canExecute != null)
            {
                return this.canExecute((T)parameter);
            }
            return true;
        }
        public void Execute(object parameter)
        {
            this.execute((T)parameter);
        }
    }
}

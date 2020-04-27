using ExplorerTree.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoBOFD.PresentationLogic.DialogUserInteraction
{
    public class DialogControllingViewModel : BaseViewModel
    {


        public DialogControllingViewModel()
        {
            this.InitializeCommands();
        }

        private void InitializeCommands()
        {
            this.AcceptSelectionSelectedCommand = new RelayCommand<object>(this.AcceptSelectionSelected);
            this.CancleSelectionSelectedCommand = new RelayCommand<object>(this.CancleSelectionSelected);
        }


        /// <summary>
        /// Method for Command <see cref="CancleSelectionSelectedCommand"/>
        /// </summary>
        public void AcceptSelectionSelected(object obj)
        {

        }


        /// <summary>
        /// Method for Command <see cref="CancleSelectionSelectedCommand"/>
        /// </summary>
        public void CancleSelectionSelected(object obj)
        {

        }

      

        /// <summary>
        /// Command for <see cref="CancleSelectionSelected(object)"/>
        /// </summary>
        public ICommand AcceptSelectionSelectedCommand { get; protected set; }


        /// <summary>
        /// Command for <see cref="CancleSelectionSelected(object)"/>
        /// </summary>
        public ICommand CancleSelectionSelectedCommand { get; protected set; }




    }  
}

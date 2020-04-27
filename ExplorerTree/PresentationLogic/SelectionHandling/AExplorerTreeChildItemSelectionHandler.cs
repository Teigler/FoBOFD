using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.PresentationLogic.SelectionHandling
{
    internal abstract class AExplorerTreeChildItemSelectionHandler : AExplorerTreeItemSelectionHandler
    {
        /// <summary>
        /// For tests only
        /// </summary>
        public AExplorerTreeChildItemSelectionHandler( ) : base()
        {

        }
        public AExplorerTreeChildItemSelectionHandler(SelectedExplorerTreeItemHandler selectedItemHandler) : base(selectedItemHandler)
        {

        }


       
        protected virtual bool IsEnsuredOnlyDirectoriesAndFilesAreNowSelectableByMultiselect()
        {
            if (this.SelectedItemHandler.SelectedDrives.Count > 0)
            {
                return false;
            }
            return true;
        }

    }
}

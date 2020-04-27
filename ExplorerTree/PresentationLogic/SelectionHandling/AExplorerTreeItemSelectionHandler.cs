using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExplorerTree.PresentationLogic.SelectionHandling
{
    public abstract class AExplorerTreeItemSelectionHandler
    {
        /// <summary>
        /// For tests only!!
        /// </summary>
        internal AExplorerTreeItemSelectionHandler()
        {

        }

        internal AExplorerTreeItemSelectionHandler(ISelectedExplorerTreeItemHandler selectedItemHandler)
        {
            this.SelectedItemHandler = selectedItemHandler;
        }


        internal abstract bool IsSelectedHasChanged(bool isSelected, IExplorerTreeItemViewModel driveVM);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">If Calling Thread is not STA-Thread</exception>
        protected virtual bool IsMultiselectActive()
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl) ||
                Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// for "global" management of the selected items.
        /// </summary>
        internal virtual ISelectedExplorerTreeItemHandler SelectedItemHandler { get; set; }
    }
}

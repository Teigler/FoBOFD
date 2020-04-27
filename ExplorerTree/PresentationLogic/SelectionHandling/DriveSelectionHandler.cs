using ExplorerTree.API.Configuration.SelectionConfiguration;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExplorerTree.PresentationLogic.SelectionHandling
{
    internal class DriveSelectionHandler : AExplorerTreeItemSelectionHandler
    {
        internal DriveSelectionHandler(SelectedExplorerTreeItemHandler selectedItemHandler, SelectionConfiguration selectionConfiguration) : base(selectedItemHandler)
        {
            this.SelectionConfiguration = selectionConfiguration;
        }

        /// <summary>
        /// Not testable, because <see cref="IsMultiselectActive()"/> throws thread exception  (STA-Thread Exception)
        /// if the calling thrad is not the STA-Thread
        /// </summary>
        internal override bool IsSelectedHasChanged(bool isSelected, IExplorerTreeItemViewModel driveVM)
        {
            var drive = driveVM as DriveItemViewModel;

            if (IsMultiselectActive())
            {
                isSelected = this.MultiselectDesicions(isSelected, drive);
            }
            else
            {
                this.AddOrRemoveDriveAccordingToIsSelected(isSelected, drive);
            }
            return isSelected;
        }


        /// <summary>
        /// 
        /// <para>
        /// If the order of the if-queries is changed, 
        /// the documentation in <see cref="ExplorerTree.API.Configuration.SelectionConfiguration.SelectionConfiguration"/> 
        /// has to be adapted
        /// </para>
        /// </summary>
        /// <param name="isSelected"></param>
        /// <param name="drive"></param>
        /// <returns></returns>
        internal bool MultiselectDesicions(bool isSelected, DriveItemViewModel drive)
        {
            if (SelectionConfiguration.IsMultiselectCombinationAllTypesAllowed)
            {
                this.AddOrRemoveDriveAccordingToIsSelected(isSelected, drive);
            }
            else if (SelectionConfiguration.IsMultiselectCombinationDirectoriesAndFilesAllowed)
            {
                isSelected = false;
            }
            else
            {
                isSelected = MultiselectDrivesOnly(isSelected, drive);
            }
            return isSelected;
        }


        private bool MultiselectDrivesOnly(bool isSelected, DriveItemViewModel drive)
        {
            if (IsEnsuredOnlyDrivesAreNowSelectableByMultiselect())
            {
                AddOrRemoveDriveAccordingToIsSelected(isSelected, drive);
            }
            else
            {
                isSelected = false;
            }

            return isSelected;
        }

        /// <summary>
        /// if another type has already been selected, only this other type can be selected with multiselect.
        /// </summary>
        /// <returns></returns>
        private bool IsEnsuredOnlyDrivesAreNowSelectableByMultiselect()
        {
            if (this.SelectedItemHandler.SelectedFiles.Count > 0 || this.SelectedItemHandler.SelectedDirectories.Count > 0)
            {
                return false;
            }
            return true;
        }






        internal void AddOrRemoveDriveAccordingToIsSelected(bool isSelected, DriveItemViewModel driveItemVM)
        {
            if (isSelected)
            {
                this.SelectedItemHandler.AddDriveToSelectedItems(driveItemVM);
            }
            else
            {
                this.SelectedItemHandler.RemoveDriveFromSelectedItems(driveItemVM);
            }
        }

       

        public SelectionConfiguration SelectionConfiguration { get; }

    }
}

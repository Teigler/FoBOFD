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
    internal class DirectorySelectionHandler : AExplorerTreeChildItemSelectionHandler
    {

        internal DirectorySelectionHandler() : base()
        {
            
        }

        internal DirectorySelectionHandler(SelectedExplorerTreeItemHandler selectedItemHandler, SelectionConfiguration selectionConfiguration) : base(selectedItemHandler)
        {
            this.SelectionConfiguration = selectionConfiguration;
        }




        /// <summary>
        /// Not testable, because <see cref="IsMultiselectActive()"/> throws thread exception  (STA-Thread Exception)
        /// if the calling thrad is not the STA-Thread
        /// </summary>
        internal override bool IsSelectedHasChanged(bool isSelected, IExplorerTreeItemViewModel directoryVM)
        {
            var directory = directoryVM as DirectoryItemViewModel;

            if (IsMultiselectActive())
            {
               isSelected = this.MultiselectDesicions(isSelected, directory);
            }
            else
            {
                this.AddOrRemoveDirectoryAccordingToIsSelected(isSelected, directory);
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
        /// <param name="directory"></param>
        /// <returns></returns>
        internal bool MultiselectDesicions(bool isSelected, DirectoryItemViewModel directory)
        {
            if (SelectionConfiguration.IsMultiselectCombinationAllTypesAllowed)
            {
                this.AddOrRemoveDirectoryAccordingToIsSelected(isSelected, directory);
            }
            else if (SelectionConfiguration.IsMultiselectCombinationDirectoriesAndFilesAllowed)
            {
                isSelected = MultiselectDirectoriesAndFiles(isSelected, directory);
            }
            else
            {
                isSelected = MultiselectDirectoriesOnly(isSelected, directory);
            }
            return isSelected;
        }

        private bool MultiselectDirectoriesAndFiles(bool isSelected, DirectoryItemViewModel directory)
        {
            if (IsEnsuredOnlyDirectoriesAndFilesAreNowSelectableByMultiselect())
            {
                AddOrRemoveDirectoryAccordingToIsSelected(isSelected, directory);
            }
            else
            {
                isSelected = false;
            }

            return isSelected;
        }

        private bool MultiselectDirectoriesOnly(bool isSelected, DirectoryItemViewModel directory)
        {
            if (IsEnsuredOnlyDirectoriesAreNowSelectableByMultiselect())
            {
                AddOrRemoveDirectoryAccordingToIsSelected(isSelected, directory);
            }
            else
            {
                isSelected = false;
            }

            return isSelected;
        }


        ///// <summary>
        ///// if a drive has already been selected, only this type and files can be selected with multiselect.
        ///// </summary>
        ///// <returns></returns>
        //private bool IsEnsuredOnlyDirectoriesAndFilesAreNowSelectableByMultiselect()
        //{
        //    if (this.SelectedItemHandler.SelectedDrives.Count > 0)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        /// <summary>
        /// if another type has already been selected, only this type can be selected with multiselect.
        /// </summary>
        /// <returns></returns>
        private bool IsEnsuredOnlyDirectoriesAreNowSelectableByMultiselect()
        {
            if (this.SelectedItemHandler.SelectedDrives.Count > 0 || this.SelectedItemHandler.SelectedFiles.Count > 0)
            {
                return false;
            }
            return true;
        }





        internal void AddOrRemoveDirectoryAccordingToIsSelected(bool isSelected, DirectoryItemViewModel directoryItemVM)
        {
            if (isSelected)
            {
                this.SelectedItemHandler.AddDirectoryToSelectedItems(directoryItemVM);
            }
            else
            {
                this.SelectedItemHandler.RemoveDirectoryFromSelectedItems(directoryItemVM);
            }
        }




       

        public SelectionConfiguration SelectionConfiguration { get; }

    }
}

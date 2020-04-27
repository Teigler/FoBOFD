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
    internal class FileSelectionHandler : AExplorerTreeChildItemSelectionHandler
    {
        internal FileSelectionHandler(SelectedExplorerTreeItemHandler selectedItemHandler, SelectionConfiguration selectionConfiguration) : base(selectedItemHandler)
        {
            this.SelectionConfiguration = selectionConfiguration;
        }

        /// <summary>
        /// Not testable, because <see cref="IsMultiselectActive()"/> throws thread exception  (STA-Thread Exception)
        /// if the calling thrad is not the STA-Thread
        /// </summary>
        internal override bool IsSelectedHasChanged(bool isSelected, IExplorerTreeItemViewModel fileVM)
        {
            var file = fileVM as FileItemViewModel;

            if (IsMultiselectActive())
            {
                isSelected = this.MultiselectDesicions(isSelected, file);
            }
            else
            {
                this.AddOrRemoveFileAccordingToIsSelected(isSelected, file);
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
        /// <param name="file"></param>
        /// <returns></returns>
        internal bool MultiselectDesicions(bool isSelected, FileItemViewModel file)
        {
            // If the order of the if-queries is changed, the documentation in SelectionConfiguration has to be adapted
            if (SelectionConfiguration.IsMultiselectCombinationAllTypesAllowed)
            {
                this.AddOrRemoveFileAccordingToIsSelected(isSelected, file);
            }
            else if (SelectionConfiguration.IsMultiselectCombinationDirectoriesAndFilesAllowed)
            {
                if (IsEnsuredOnlyDirectoriesAndFilesAreNowSelectableByMultiselect())
                {
                    AddOrRemoveFileAccordingToIsSelected(isSelected, file);
                }
                else
                {
                    isSelected = false;
                }
            }
            else
            {
                if (IsEnsuredOnlyFilesAreNowSelectableByMultiselect())
                {
                    AddOrRemoveFileAccordingToIsSelected(isSelected, file);
                }
                else
                {
                    isSelected = false;
                }
            }
            return isSelected;
        }


        internal void AddOrRemoveFileAccordingToIsSelected(bool isSelected, FileItemViewModel fileItemVM)
        {
            if (isSelected)
            {
                this.SelectedItemHandler.AddFileToSelectedItems(fileItemVM);
            }
            else
            {
                this.SelectedItemHandler.RemoveFileFromSelectedItems(fileItemVM);
            }
        }

        /// <summary>
        /// if another type has already been selected, only this type can be selected with multiselect.
        /// </summary>
        /// <returns></returns>
        private bool IsEnsuredOnlyFilesAreNowSelectableByMultiselect()
        {
            if (this.SelectedItemHandler.SelectedDrives.Count > 0 || this.SelectedItemHandler.SelectedDirectories.Count > 0)
            {
                return false;
            }
            return true;
        }

        ///// <summary>
        ///// if a drive has already been selected, only this type and directories can be selected with multiselect.
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
        /// if a drive has already been selected, only this type and files can be selected with multiselect.
        /// </summary>
        /// <returns></returns>
        public SelectionConfiguration SelectionConfiguration { get; }

    }
}

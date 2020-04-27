using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.PresentationLogic
{
    public interface IExplorerTreeItemModelViewModelParser
    {
        /// <summary>
        /// For loading the roots.
        /// </summary>
        /// <returns>Collection with all current available drives represented as <see cref="DriveItemViewModel"/></returns>
        ObservableCollection<DriveItemViewModel> LoadAllDriveItemViewModels();

        /// <summary>
        /// Loads the child elements (directories and files) of the <paramref name="driveItemVM"/>
        /// </summary>
        /// <param name="driveItemVM">The <see cref="DriveItemViewModel"/> whose children should be parsed.</param>
        /// <returns>The <see cref="DriveItemViewModel"/> with new <see cref="DriveItemViewModel.ChildTreeItemVMs"/></returns>
        DriveItemViewModel LoadChildDirectoryAndFileViewModels(DriveItemViewModel driveItemVM);


        /// <summary>
        /// Loads the child elements (directories and files) of the <paramref name="directoryItemVM"/>
        /// </summary>
        /// <param name="directoryItemVM">The <see cref="DirectoryItemViewModel"/> whose children should be parsed.</param>
        /// <returns>The <see cref="DirectoryItemViewModel"/> with new <see cref="DirectoryItemViewModel.ChildTreeItemVMs"/></returns>
        DirectoryItemViewModel LoadChildDirectoryAndFileViewModels(DirectoryItemViewModel directoryItemVM);


    

    }
}

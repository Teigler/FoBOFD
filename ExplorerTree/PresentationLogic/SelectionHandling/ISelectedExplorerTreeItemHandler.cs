using ExplorerTree.API.Configuration.SelectionConfiguration;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.PresentationLogic.SelectionHandling
{
    public interface ISelectedExplorerTreeItemHandler
    {


        void AddDirectoryToSelectedItems(DirectoryItemViewModel directoryItemVM);

        void RemoveDirectoryFromSelectedItems(DirectoryItemViewModel directoryItemVM);



        void AddDriveToSelectedItems(DriveItemViewModel driveItemVM);

        void RemoveDriveFromSelectedItems(DriveItemViewModel driveItemVM);



        void AddFileToSelectedItems(FileItemViewModel fileItemVM);

        void RemoveFileFromSelectedItems(FileItemViewModel fileItemVM);


        void RemoveAllItemsFromSelectedItems();

        /// <summary>
        /// Contains all currently selected Items of the ExplorerTree!
        /// <para>
        ///     Attention: use the add methods to add items, 
        ///                 as they always have to be added 
        ///                 to the general collection: 
        ///                 <see cref="SelectedExplorerTreeItems"/> AND 
        ///                 to the specific collection. 
        ///                 The same applies to removal. Use the remove methods here!
        ///                 See example:
        /// </para>
        /// <para>
        ///     Example: Directory should be added
        ///        than this must be added to <see cref="SelectedExplorerTreeItems"/> AND
        ///        to: <see cref="SelectedDirectories"/>!
        /// </para>
        /// </summary>
        ObservableCollection<IExplorerTreeItemViewModel> SelectedExplorerTreeItems { get; set; }


        /// <summary>
        /// Contains all currently selected <see cref="DirectoryItemViewModel"/> of the ExplorerTree!
        /// <para>
        ///     Attention: use the add methods to add items, 
        ///                 as they always have to be added 
        ///                 to the general collection: 
        ///                 <see cref="SelectedExplorerTreeItems"/> AND 
        ///                 to the specific collection. 
        ///                 The same applies to removal. Use the remove methods here!
        ///                 See example:
        /// </para>
        /// <para>
        ///     Example: Directory should be added
        ///        than this must be added to <see cref="SelectedExplorerTreeItems"/> AND
        ///        to: <see cref="SelectedDirectories"/>!
        /// </para>
        /// </summary>
        ObservableCollection<DirectoryItemViewModel> SelectedDirectories { get; }

        /// <summary>
        /// Contains all currently selected <see cref="DriveItemViewModel"/> of the ExplorerTree!
        /// <para>
        ///     Attention: use the add methods to add items, 
        ///                 as they always have to be added 
        ///                 to the general collection: 
        ///                 <see cref="SelectedExplorerTreeItems"/> AND 
        ///                 to the specific collection. 
        ///                 The same applies to removal. Use the remove methods here!
        ///                 See example:
        /// </para>
        /// <para>
        ///     Example: Directory should be added
        ///        than this must be added to <see cref="SelectedExplorerTreeItems"/> AND
        ///        to: <see cref="SelectedDirectories"/>!
        /// </para>
        /// </summary>
        ObservableCollection<DriveItemViewModel> SelectedDrives { get; }

        /// <summary>
        /// Contains all currently selected <see cref="FileItemViewModel"/> of the ExplorerTree!
        /// <para>
        ///     Attention: use the add methods to add items, 
        ///                 as they always have to be added 
        ///                 to the general collection: 
        ///                 <see cref="SelectedExplorerTreeItems"/> AND 
        ///                 to the specific collection. 
        ///                 The same applies to removal. Use the remove methods here!
        ///                 See example:
        /// </para>
        /// <para>
        ///     Example: Directory should be added
        ///        than this must be added to <see cref="SelectedExplorerTreeItems"/> AND
        ///        to: <see cref="SelectedDirectories"/>!
        /// </para>
        /// </summary>
        ObservableCollection<FileItemViewModel> SelectedFiles { get; }



        AExplorerTreeItemSelectionHandler DirectorySelectionHandler { get; set; }
        AExplorerTreeItemSelectionHandler DriveSelectionHandler { get; set; }
        AExplorerTreeItemSelectionHandler FileSelectionHandler { get; set; }
        SelectionConfiguration SelectionConfiguration { get; }
    }
}

using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.API
{
   
    public interface ISelectedExplorerTreeItemAPI
    {

        /// <summary>
        /// Returns ALL currently selected ExplorerTreeItems.
        /// </summary>
        ObservableCollection<IExplorerTreeItemViewModel> GetSelectedExplorerTreeItems();

        /// <summary>
        /// Returns the Selected Directory-ExplorerTreeItems.
        /// </summary>
        ObservableCollection<DirectoryItemViewModel> GetSelectedDirectories();

        /// <summary>
        /// Returns the Selected Drive-ExplorerTreeItems.
        /// </summary>
        ObservableCollection<DriveItemViewModel> GetSelectedDrives();

        /// <summary>
        /// Returns the Selected File-ExplorerTreeItems.
        /// </summary>
        ObservableCollection<FileItemViewModel> GetSelectedFiles();
    }
}

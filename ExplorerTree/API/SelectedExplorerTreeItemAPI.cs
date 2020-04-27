using ExplorerTree.PresentationLogic;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.API
{
    /// <summary>
    /// Todo unit tests for this class!!!    
    /// </summary>
    public class SelectedExplorerTreeItemAPI : ISelectedExplorerTreeItemAPI
    {

        internal SelectedExplorerTreeItemAPI(ExplorerTreeViewModel explorerTreeVM)
        {
            this.ExplorerTreeVM = explorerTreeVM;
        }

        public ObservableCollection<IExplorerTreeItemViewModel> GetSelectedExplorerTreeItems()
        {
            return this.ExplorerTreeVM.SelectedItemHandler.SelectedExplorerTreeItems;
        }

        public ObservableCollection<DirectoryItemViewModel> GetSelectedDirectories()
        {
            return this.ExplorerTreeVM.SelectedItemHandler.SelectedDirectories;
        }

        public ObservableCollection<DriveItemViewModel> GetSelectedDrives()
        {
            return this.ExplorerTreeVM.SelectedItemHandler.SelectedDrives;
        }

        public ObservableCollection<FileItemViewModel> GetSelectedFiles()
        {
            return this.ExplorerTreeVM.SelectedItemHandler.SelectedFiles;
        }

        private ExplorerTreeViewModel ExplorerTreeVM { get; set; }
    }
}

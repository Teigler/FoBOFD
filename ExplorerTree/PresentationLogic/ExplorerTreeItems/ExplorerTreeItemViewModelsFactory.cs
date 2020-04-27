using ExplorerTree.API.Configuration;
using ExplorerTree.Model.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.PresentationLogic.ExplorerTreeItems
{
    /// <summary>
    /// Exclusively use this class to instantiate the elements in 
    /// <see cref="ExplorerTree.PresentationLogic.ExplorerTreeItems"/>
    /// </summary>
    internal static class ExplorerTreeItemViewModelsFactory
    {

        /// <summary>
        /// For Dummy-Member instantiation
        /// </summary>
        /// <returns></returns>
        internal static DirectoryItemViewModel CreateDummyDirectoryItemVM()
        {
            return new DirectoryItemViewModel();
        }

        internal static DirectoryItemViewModel CreateDirectoryItemVM
            (DirectoryItemModel directoryItemModel,
            IExplorerTreeItemModelViewModelParser explorerTreeItemModelViewModelParser,
            IConfiguration configuration,
            IExplorerTreeItemViewModel parentItemVM)
        {
            return new DirectoryItemViewModel(directoryItemModel, explorerTreeItemModelViewModelParser, configuration, parentItemVM);
        }

        internal static DriveItemViewModel CreateDriveItemVM
            (DriveItemModel driveItemModel, 
            IExplorerTreeItemModelViewModelParser explorerTreeItemModelViewModelParser,
            IConfiguration configuration)
        {
            return new DriveItemViewModel(driveItemModel, explorerTreeItemModelViewModelParser, configuration);
        }

        internal static FileItemViewModel CreateFileItemVM(FileItemModel fileItemModel, 
            IExplorerTreeItemModelViewModelParser explorerTreeItemModelViewModelParser,
            IConfiguration configuration,
            IExplorerTreeItemViewModel parentItemVM)
        {
            return new FileItemViewModel(fileItemModel, explorerTreeItemModelViewModelParser, configuration, parentItemVM);
        }
    }
}

using ExplorerTree.PresentationLogic;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.API.Configuration.IconConfiguration
{
    public class FileIconConfiguration : AExplorerTreeChildItemIconConfiguration
    {
        public FileIconConfiguration(ExplorerTreeViewModel explorerTreeVM) : base(explorerTreeVM)
        {
        }

        protected override void ForeachDriveUpdateChildsWithLargeIcon()
        {
            foreach (var drive in this.ExplorerTreeVM.Drives)
            {
                if (drive.Name != "DummyChild")
                {
                    this.UpdateDirectoriesAndFilesWithLargeIcon(drive.ChildTreeItemVMs);
                }
            }
        }

        protected override void UpdateDirectoriesAndFilesWithLargeIcon(ObservableCollection<AExplorerTreeChildItemViewModel> explorerTreeChildItemVMs)
        {
            foreach (var directoryOrFile in explorerTreeChildItemVMs)
            {
                if (directoryOrFile.Name != "DummyChild")
                {
                    if (directoryOrFile is FileItemViewModel)
                    {
                        directoryOrFile.IconVM.SetLargeImageSourceToActiveImageSource();
                    }
                    this.UpdateDirectoriesAndFilesWithLargeIcon(directoryOrFile.ChildTreeItemVMs);
                }
            }
        }








        protected override void ForeachDriveUpdateChildsWithSmallIcon()
        {
            foreach (var drive in this.ExplorerTreeVM.Drives)
            {
                if (drive.Name != "DummyChild")
                {
                    this.UpdateDirectoriesAndFilesWithSmallIcon(drive.ChildTreeItemVMs);
                }
            }
        }

        protected override void UpdateDirectoriesAndFilesWithSmallIcon(ObservableCollection<AExplorerTreeChildItemViewModel> explorerTreeChildItemVMs)
        {
            foreach (var directoryOrFile in explorerTreeChildItemVMs)
            {
                if (directoryOrFile.Name != "DummyChild")
                {
                    if (directoryOrFile is FileItemViewModel)
                    {
                        directoryOrFile.IconVM.SetSmallImageSourceToActiveImageSource();
                    }
                    this.UpdateDirectoriesAndFilesWithSmallIcon(directoryOrFile.ChildTreeItemVMs);
                }
            }
        }

    }
}

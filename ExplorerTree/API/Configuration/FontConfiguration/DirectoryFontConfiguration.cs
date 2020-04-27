using ExplorerTree.PresentationLogic;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.API.Configuration.FontConfiguration
{
    public class DirectoryFontConfiguration : AExplorerTreeChildItemFontConfiguration
    {
        public DirectoryFontConfiguration(ExplorerTreeViewModel explorerTreeVM) : base(explorerTreeVM)
        {
        }

        internal override void ForeachDriveUpdateChilds()
        {
            foreach (var drive in this.ExplorerTreeVM.Drives)
            {
                if (drive.Name != "DummyChild")
                {
                    this.UpdateDirectoriesAndFiles(drive.ChildTreeItemVMs);
                }
            }
        }


        protected override void UpdateDirectoriesAndFiles(ObservableCollection<AExplorerTreeChildItemViewModel> explorerTreeChildItemVMs)
        {
            foreach (var directoryOrFile in explorerTreeChildItemVMs)
            {
                if (directoryOrFile.Name != "DummyChild" && (directoryOrFile is DirectoryItemViewModel))
                {
                    this.UpdateFontVMCompletelyWithThisFontConfiguration(directoryOrFile.FontVM);
                    this.UpdateDirectoriesAndFiles(directoryOrFile.ChildTreeItemVMs);
                }
            }
        }

        public override void UpdateFontVMCompletelyWithThisFontConfiguration(FontViewModel fontVM)
        {
            fontVM.Update(this);
        }

    }
}

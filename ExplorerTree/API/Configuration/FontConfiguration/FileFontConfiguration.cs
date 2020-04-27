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
    public class FileFontConfiguration : AExplorerTreeChildItemFontConfiguration
    {
        public FileFontConfiguration(ExplorerTreeViewModel explorerTreeVM) : base(explorerTreeVM)
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
                if (directoryOrFile.Name != "DummyChild")
                {
                    if(directoryOrFile is FileItemViewModel)
                    {
                        this.UpdateFontVMCompletelyWithThisFontConfiguration(directoryOrFile.FontVM);
                    }
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

using ExplorerTree.Model.ExplorerTreeItems;
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
    public class DriveIconConfiguration : IExplorerTreeItemIconConfiguration
    {
        public DriveIconConfiguration(ExplorerTreeViewModel explorerTreeVM)
        {
            this.ExplorerTreeVM = explorerTreeVM;
            this.ActiveIconState = IconStates.SmallIcon;
        }


        public virtual void SetLargeIconToActiveIcon()
        {
            this.ActiveIconState = IconStates.LargeIcon;
            this.UpdateDrivesWithLargeIcon();
        }

        private void UpdateDrivesWithLargeIcon()
        {
            foreach (var drive in this.ExplorerTreeVM.Drives)
            {
                if (drive.Name != "DummyChild")
                {
                    drive.IconVM.SetLargeImageSourceToActiveImageSource();
                }
            }
        }






        public virtual void SetSmallIconToActiveIcon()
        {
            this.ActiveIconState = IconStates.SmallIcon;
            this.UpdateDrivesWithSmallIcon();
        }

        private void UpdateDrivesWithSmallIcon()
        {
            foreach (var drive in this.ExplorerTreeVM.Drives)
            {
                if (drive.Name != "DummyChild")
                {
                    drive.IconVM.SetSmallImageSourceToActiveImageSource();
                }
            }
        }


        /// <summary>
        /// Documentation see: <see cref="IExplorerTreeItemIconConfiguration.ActiveIconState"/>
        /// </summary>
        public IconStates ActiveIconState { get; set; }

        internal ExplorerTreeViewModel ExplorerTreeVM { get; set; }

    }

}

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
    public abstract class AExplorerTreeChildItemIconConfiguration : IExplorerTreeItemIconConfiguration
    {
        protected AExplorerTreeChildItemIconConfiguration(ExplorerTreeViewModel explorerTreeVM)
        {
            this.ActiveIconState = IconStates.SmallIcon;
            this.ExplorerTreeVM = explorerTreeVM;
        }


        ///<inheritdoc/>
        public virtual void SetLargeIconToActiveIcon()
        {
            this.ActiveIconState = IconStates.LargeIcon;
            this.ForeachDriveUpdateChildsWithLargeIcon();
        }

        protected abstract void ForeachDriveUpdateChildsWithLargeIcon();


        protected abstract void UpdateDirectoriesAndFilesWithLargeIcon(ObservableCollection<AExplorerTreeChildItemViewModel> explorerTreeChildItemVMs);


        ///<inheritdoc/>
        public virtual void SetSmallIconToActiveIcon()
        {
            this.ActiveIconState = IconStates.SmallIcon;
            this.ForeachDriveUpdateChildsWithSmallIcon();
        }

        protected abstract void ForeachDriveUpdateChildsWithSmallIcon();

        protected abstract void UpdateDirectoriesAndFilesWithSmallIcon(ObservableCollection<AExplorerTreeChildItemViewModel> explorerTreeChildItemVMs);


        ///<inheritdoc/>
        public IconStates ActiveIconState { get; set; }

        internal ExplorerTreeViewModel ExplorerTreeVM { get; set; }

    }
}

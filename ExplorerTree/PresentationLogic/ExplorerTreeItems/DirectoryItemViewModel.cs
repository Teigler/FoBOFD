using ExplorerTree.API.Configuration;
using ExplorerTree.Data.FileSystem;
using ExplorerTree.Model.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ExplorerTree.PresentationLogic.ExplorerTreeItems
{
    /// <summary>
    /// 
    /// <para>
    /// Exclusively use <see cref="ExplorerTreeItemViewModelsFactory"/>
    /// to instantiate this class.
    /// -> Except for test purposes. 
    /// </para>
    /// </summary>
    public class DirectoryItemViewModel : AExplorerTreeChildItemViewModel
    {
        private bool isExpanded;
        private bool isSelected;

        /// <summary>
        /// Default for Dummy-Member instantiation
        /// <para>
        /// Exclusively use <see cref="ExplorerTreeItemViewModelsFactory"/>
        /// to instantiate this class.
        /// -> Except for test purposes. 
        /// </para>
        /// </summary>
        internal DirectoryItemViewModel() : base()
        {
            this.DirectoryItemModel = null;
        }

        /// <summary>
        /// 
        /// <para>
        /// Exclusively use <see cref="ExplorerTreeItemViewModelsFactory"/>
        /// to instantiate this class.
        /// -> Except for test purposes. 
        /// </para>
        /// </summary>
        internal DirectoryItemViewModel
            (DirectoryItemModel directoryItemModel,
            IExplorerTreeItemModelViewModelParser explorerTreeItemModelViewModelParser,
            IConfiguration configuration,
            IExplorerTreeItemViewModel parentItemVM) : base()
        {
            this.Configuration = configuration;
            this.ChildTreeItemVMs = new ObservableCollection<AExplorerTreeChildItemViewModel>();
            this.DirectoryItemModel = directoryItemModel;
            this.ExplorerTreeItemModelViewModelParser = explorerTreeItemModelViewModelParser;
            this.ExplorerTreeVM = configuration.ExplorerTreeVM;
            this.FontVM = new FontViewModel(configuration.Directory.Font);
            this.FullName = directoryItemModel.FullName;
            this.IsExpanded = false;
            this.IsSelected = false;
            this.IsHidden = directoryItemModel.IsHidden;
            this.IconVM = new IconViewModel(directoryItemModel.IconModel, configuration.Directory.Icon);
            this.Name = directoryItemModel.Name;
            this.ParentItem = parentItemVM;
            this.AddDummyTreeViewItemToBeExpandable();
            this.SetVisibilityAccordingToConfigruation(configuration.HiddenOverall);
        }

      

        private void IsExpandedHasChanged(bool isExpanded)
        {
            if (isExpanded)
            {
                this.ExplorerTreeItemModelViewModelParser.LoadChildDirectoryAndFileViewModels(this);
            }
        }

        /// <summary>
        /// The Model of this ViewModel
        /// </summary>
        internal DirectoryItemModel DirectoryItemModel { get; private set; }

        /// <inheritdoc/>
        public override bool IsExpanded
        {
            get => isExpanded;
            set
            {
                if (isExpanded == value)
                    return;
                this.IsExpandedHasChanged(value);
                isExpanded = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc/>
        public override bool IsSelected
        {
            get => isSelected;
            set
            {
                if (isSelected == value)
                    return;
                isSelected = this.ExplorerTreeVM.SelectedItemHandler.DirectorySelectionHandler.IsSelectedHasChanged(value, this);
                OnPropertyChanged();
            }
        }
    }
}

using ExplorerTree.API.Configuration;
using ExplorerTree.Model.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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
    public class FileItemViewModel : AExplorerTreeChildItemViewModel
    {
        private bool isSelected;


        internal FileItemViewModel() : base()
        {
            this.FileItemModel = null;
        }

        /// <summary>
        /// 
        /// <para>
        /// Exclusively use <see cref="ExplorerTreeItemViewModelsFactory"/>
        /// to instantiate this class.
        /// -> Except for test purposes. 
        /// </para>
        /// </summary>
        internal FileItemViewModel(FileItemModel fileItemModel,
            IExplorerTreeItemModelViewModelParser explorerTreeItemModelViewModelParser,
            IConfiguration configuration,
            IExplorerTreeItemViewModel parentItemVM) : base()
        {
            this.Configuration = configuration;
            this.ChildTreeItemVMs = new ObservableCollection<AExplorerTreeChildItemViewModel>();
            this.ExplorerTreeItemModelViewModelParser = explorerTreeItemModelViewModelParser;
            this.ExplorerTreeVM = configuration.ExplorerTreeVM;
            this.FileItemModel = fileItemModel;
            this.FontVM = new FontViewModel(this.Configuration.File.Font);
            this.FullName = fileItemModel.FullName;
            this.IsExpanded = false;
            this.IsSelected = false;
            this.IsHidden = fileItemModel.IsHidden;
            this.IconVM = new IconViewModel(fileItemModel.IconModel, this.Configuration.File.Icon);
            this.Name = fileItemModel.Name;
            this.ParentItem = parentItemVM;
            this.SetVisibilityAccordingToConfigruation(configuration.HiddenOverall);
        }

       

        protected override void AddDummyTreeViewItemToBeExpandable()
        {
            // todo: not implementet because it must be specified when a fileItem-VM is expandable
            //       -> .zip e.g.
        }

        /// <summary>
        /// The Model of this ViewModel
        /// </summary>
        internal FileItemModel FileItemModel { get; private set; }

        /// <inheritdoc/>
        public override bool IsSelected
        {
            get => isSelected;
            set
            {
                if (isSelected == value)
                    return;
                isSelected = this.ExplorerTreeVM.SelectedItemHandler.FileSelectionHandler.IsSelectedHasChanged(value, this);
                OnPropertyChanged();
            }
        }

      
    }
}

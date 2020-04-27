using ExplorerTree.API.Configuration;
using ExplorerTree.API.Configuration.AvailabilityConfiguration;
using ExplorerTree.API.Configuration.ExplorerTreeItemConfiguration;
using ExplorerTree.Model.ExplorerTreeItems;
using ExplorerTree.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
    public class DriveItemViewModel : ExplorerTreeBaseViewModel, IExplorerTreeItemViewModel
    {
        private ObservableCollection<AExplorerTreeChildItemViewModel> childTreeItemVMs;
        private DriveItemModel driveItemModel;
        private FontViewModel fontVM;
        private bool isExpanded;
        private bool isSelected;
        private IconViewModel iconVM;
        private string name;
        private Visibility visibility;

        internal DriveItemViewModel()
        {
            this.Configuration = null;
            this.ChildTreeItemVMs = new ObservableCollection<AExplorerTreeChildItemViewModel>();
            this.DriveType = DriveType.Unknown;
            this.DriveItemModel = null;
            this.ExplorerTreeItemModelViewModelParser = null;
            this.ExplorerTreeVM = null;
            this.FontVM = null;
            this.IsExpanded = false;
            this.IsSelected = false;
            this.IconVM = null;
            this.Name = "init";
            this.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// 
        /// <para>
        /// Exclusively use <see cref="ExplorerTreeItemViewModelsFactory"/>
        /// to instantiate this class.
        /// -> Except for test purposes. 
        /// </para>
        /// </summary>
        internal DriveItemViewModel(DriveItemModel driveItemModel,
            IExplorerTreeItemModelViewModelParser explorerTreeItemModelViewModelParser,
            IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.ChildTreeItemVMs = new ObservableCollection<AExplorerTreeChildItemViewModel>();
            this.DriveType = driveItemModel.DriveType;
            this.DriveItemModel = driveItemModel;
            this.ExplorerTreeItemModelViewModelParser = explorerTreeItemModelViewModelParser;
            this.ExplorerTreeVM = configuration.ExplorerTreeVM;
            this.FontVM = new FontViewModel(this.Configuration.Drive.Font);
            this.IsExpanded = false;
            this.IsSelected = false;
            this.IconVM = new IconViewModel(this.DriveItemModel.IconModel, this.Configuration.Drive.Icon);
            this.Name = this.DriveItemModel.Name;
            this.AddDummyTreeViewItemToBeExpandable();
            this.InitVisibilityAccordingToConfiguration();
        }

        /// <summary>
        /// To get a expandable <see cref="IExplorerTreeItemViewModel"/> 
        /// we add a dummy child.
        /// </summary>
        private void AddDummyTreeViewItemToBeExpandable()
        {
            DirectoryItemViewModel directoryItemVM = ExplorerTreeItemViewModelsFactory.CreateDummyDirectoryItemVM();
            directoryItemVM.Name = "DummyChild";
            this.ChildTreeItemVMs.Add(directoryItemVM);
        }

        private void InitVisibilityAccordingToConfiguration()
        {
            foreach (var activatableDriveType in this.Configuration.Drive.Availability.ActivatableDriveTypes)
            {
                if (this.DriveType == activatableDriveType.DriveType)
                {
                    this.SetVisibleOrCollapsedAccordingToIsActiveFrom(activatableDriveType);
                }
            }
        }

        internal void SetVisibleOrCollapsedAccordingToIsActiveFrom(ActivatableDriveType activatableDriveType)
        {
            this.Visibility = activatableDriveType.IsActive ? Visibility.Visible : Visibility.Collapsed;
        }
      
        private void IsExpandedHasChanged(bool isExpanded)
        {
            if (isExpanded)
            {
                this.ExplorerTreeItemModelViewModelParser.LoadChildDirectoryAndFileViewModels(this);
            }
        }

        /// <inheritdoc/>
        public ObservableCollection<AExplorerTreeChildItemViewModel> ChildTreeItemVMs
        {
            get => childTreeItemVMs;
            set
            {
                if (childTreeItemVMs == value)
                    return;
                childTreeItemVMs = value;
                OnPropertyChanged();
            }
        }

        internal IConfiguration Configuration { get; set; }

        internal DriveType DriveType { get; set; }

        /// <inheritdoc/>
        public ExplorerTreeViewModel ExplorerTreeVM { get; set; }

        /// <inheritdoc/>
        public IExplorerTreeItemModelViewModelParser ExplorerTreeItemModelViewModelParser { get; private set; }

        /// <summary>
        /// The Model of this ViewModel
        /// </summary>
        internal DriveItemModel DriveItemModel { get; set; }

        /// <inheritdoc/>
        public FontViewModel FontVM
        {
            get => fontVM;
            set
            {
                if (fontVM == value)
                    return;
                fontVM = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc/>
        public bool IsExpanded
        {
            get => isExpanded;
            set
            {
                if (isExpanded == value)
                    return;
                isExpanded = value;
                this.IsExpandedHasChanged(value);
                OnPropertyChanged();
            }
        }

        /// <inheritdoc/>>
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (isSelected == value)
                    return;

                isSelected = this.ExplorerTreeVM.SelectedItemHandler.DriveSelectionHandler.IsSelectedHasChanged(value, this);
                OnPropertyChanged();
            }
        }

        /// <inheritdoc/>
        public IconViewModel IconVM
        {
            get => iconVM;
            set
            {
                if (iconVM == value)
                    return;
                iconVM = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc/>
        public string Name
        {
            get => name;
            set
            {
                if (name == value)
                    return;
                name = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// <para>
        ///     To set visiblity because drive-Type changed use -> 
        /// </para>
        /// </summary>
        public Visibility Visibility
        {
            get => visibility;
            set
            {
                if (visibility == value)
                    return;
                visibility = value;
                OnPropertyChanged();
            }
        }

        

    }
}

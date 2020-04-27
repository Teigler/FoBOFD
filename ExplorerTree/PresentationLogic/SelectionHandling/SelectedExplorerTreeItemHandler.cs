using ExplorerTree.API.Configuration.SelectionConfiguration;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.PresentationLogic.SelectionHandling
{
    /// <summary>
    /// Currently, multiselect is only allowed within one type. 
    /// Only either drives, directories or files can be selected.
    /// This can still be improved/extended. 
    /// How exactly it is desired is not yet clear.
    /// </summary>
    internal class SelectedExplorerTreeItemHandler : ExplorerTreeBaseViewModel, ISelectedExplorerTreeItemHandler
    {
        private ObservableCollection<IExplorerTreeItemViewModel> selectedExplorerTreeItems;

        internal SelectedExplorerTreeItemHandler()
        {
            this.SelectedExplorerTreeItems = new ObservableCollection<IExplorerTreeItemViewModel>();
            this.SelectedDirectories = new ObservableCollection<DirectoryItemViewModel>();
            this.SelectedDrives = new ObservableCollection<DriveItemViewModel>();
            this.SelectedFiles = new ObservableCollection<FileItemViewModel>();

            this.DirectorySelectionHandler = null;
            this.DriveSelectionHandler = null;
            this.FileSelectionHandler = null;
            this.SelectionConfiguration = null;
        }

        internal SelectedExplorerTreeItemHandler(SelectionConfiguration selectionConfiguration)
        {
            this.SelectedExplorerTreeItems = new ObservableCollection<IExplorerTreeItemViewModel>();
            this.SelectedDirectories = new ObservableCollection<DirectoryItemViewModel>();
            this.SelectedDrives = new ObservableCollection<DriveItemViewModel>();
            this.SelectedFiles = new ObservableCollection<FileItemViewModel>();

            this.DirectorySelectionHandler = new DirectorySelectionHandler(this, selectionConfiguration);
            this.DriveSelectionHandler = new DriveSelectionHandler(this, selectionConfiguration);
            this.FileSelectionHandler = new FileSelectionHandler(this, selectionConfiguration);
            this.SelectionConfiguration = selectionConfiguration;
        }





        public virtual void AddDirectoryToSelectedItems(DirectoryItemViewModel directoryItemVM)
        {
            this.SelectedExplorerTreeItems.Add(directoryItemVM);
            this.SelectedDirectories.Add(directoryItemVM);
        }

        public virtual void RemoveDirectoryFromSelectedItems(DirectoryItemViewModel directoryItemVM)
        {
            this.SelectedExplorerTreeItems.Remove(directoryItemVM);
            this.SelectedDirectories.Remove(directoryItemVM);
        }



        public virtual void AddDriveToSelectedItems(DriveItemViewModel driveItemVM)
        {
            this.SelectedExplorerTreeItems.Add(driveItemVM);
            this.SelectedDrives.Add(driveItemVM);
        }

        public virtual void RemoveDriveFromSelectedItems(DriveItemViewModel driveItemVM)
        {
            this.SelectedExplorerTreeItems.Remove(driveItemVM);
            this.SelectedDrives.Remove(driveItemVM);
        }



        public virtual void AddFileToSelectedItems(FileItemViewModel fileItemVM)
        {
            this.SelectedExplorerTreeItems.Add(fileItemVM);
            this.SelectedFiles.Add(fileItemVM);
        }

        public virtual void RemoveFileFromSelectedItems(FileItemViewModel fileItemVM)
        {
            this.SelectedExplorerTreeItems.Remove(fileItemVM);
            this.SelectedFiles.Remove(fileItemVM);
        }


        public virtual void RemoveAllItemsFromSelectedItems()
        {
            this.SelectedExplorerTreeItems.Clear();
            this.SelectedDirectories.Clear();
            this.SelectedDrives.Clear();
            this.SelectedFiles.Clear();
        }

        ///<inheritdoc/>
        public virtual ObservableCollection<IExplorerTreeItemViewModel> SelectedExplorerTreeItems
        {
            get => selectedExplorerTreeItems;
            set
            {
                if (selectedExplorerTreeItems == value)
                    return;
                selectedExplorerTreeItems = value;
                OnPropertyChanged();
            }
        }


        ///<inheritdoc/>
        public virtual ObservableCollection<DirectoryItemViewModel> SelectedDirectories { get;  }

        ///<inheritdoc/>
        public virtual ObservableCollection<DriveItemViewModel> SelectedDrives { get;  }

        ///<inheritdoc/>
        public virtual ObservableCollection<FileItemViewModel> SelectedFiles { get;  }



        public virtual AExplorerTreeItemSelectionHandler DirectorySelectionHandler { get; set; }
        public virtual AExplorerTreeItemSelectionHandler DriveSelectionHandler { get; set; }
        public virtual AExplorerTreeItemSelectionHandler FileSelectionHandler { get; set; }
        public virtual SelectionConfiguration SelectionConfiguration { get; }
    }
}

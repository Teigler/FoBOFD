using ExplorerTree.PresentationLogic;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.API.Configuration
{
    /// <summary>
    /// Specifies whether the hidden elements are displayed.
    /// 
    /// <para>
    ///     Only Directories and Files can be configured. But not Drives.
    ///     -> Because Drives can't be hidden.
    ///     -> But you can configure the availability 
    ///        e. g. of drive typs: 
    ///        <see cref="AvailabilityConfiguration.DriveAvailabilityConfiguration"/>
    /// </para>
    /// <para>
    ///     In this case the hidden elements are those that are
    ///     hidden (not visible) in the file system of the 
    ///     operating system (e.g. windows).
    /// </para>
    /// <para>
    ///     Currently this is the only way to configure the 
    ///     visibility of the hidden elements.
    ///     For later use the directories and files 
    ///     could be controlled individually.
    ///     But only if it makes sense to adjust the visibility
    ///     of the hidden elements individually.
    /// </para>
    /// </summary>
    public class HiddenOverallConfiguration
    {
        private bool showHiddenElements;

        /// <summary>
        /// For tests only!
        /// </summary>
        public HiddenOverallConfiguration()
        {
            this.ExplorerTreeVM = null;
            this.ShowHiddenElements = false;
        }

        internal HiddenOverallConfiguration(ExplorerTreeViewModel explorerTreeVM)
        {
            this.ExplorerTreeVM = explorerTreeVM;
            this.ShowHiddenElements = false;
        }


        /// <summary>
        /// To enable a configuration at runtime, the already loaded directories and fiels must be updated. 
        /// First the directories and fiels of the drives are updated. Then the directories and files of the directories 
        /// and so on.
        /// </summary>
        private void UpdateCurrentlyLoadedDirectoriesAndFilesOfTheExplorerTree()
        {
            UpdateDrives();
        }


        
        private void UpdateDrives()
        {
            foreach(var drive in this.ExplorerTreeVM.Drives)
            {
                if(drive.Name != "DummyChild")
                {
                    this.UpdateDirectoriesAndFiles(drive.ChildTreeItemVMs);
                }
            }
        }

        private void UpdateDirectoriesAndFiles(ObservableCollection<AExplorerTreeChildItemViewModel> directoriesAndFiles)
        {
            foreach (var item in directoriesAndFiles)
            {
                if(item.Name != "DummyChild")
                {
                    item.SetVisibilityAccordingToConfigruation(this);
                    this.UpdateDirectoriesAndFiles(item.ChildTreeItemVMs);
                }
               
            }
        }

        /// <summary>
        /// To specify whether hidden elements should be displayed.
        /// <para>
        /// <see langword="true"/> for display. <see langword="false"/> for hide.
        /// </para>
        /// <para>
        ///     Default: <see langword="false"/>
        /// </para>
        /// </summary>
        public virtual bool ShowHiddenElements 
        {
            get => showHiddenElements;
            set
            {
                if (showHiddenElements == value)
                    return;
                showHiddenElements = value;
                this.UpdateCurrentlyLoadedDirectoriesAndFilesOfTheExplorerTree();
            }
        }

        internal ExplorerTreeViewModel ExplorerTreeVM { get; set; }
    }
}

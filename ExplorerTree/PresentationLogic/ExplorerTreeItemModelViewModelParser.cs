using ExplorerTree.API.Configuration;
using ExplorerTree.Model.ExplorerTreeItems;
using ExplorerTree.PresentationLogic.API;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.PresentationLogic
{

    /// <summary>
    /// Parser for <see cref="Data.Model.ExplorerTreeItems"/>- and 
    /// <see cref="PresentationLogic.ExplorerTreeItems"/>-Elements.
    /// </summary>
    internal class ExplorerTreeItemModelViewModelParser : IExplorerTreeItemModelViewModelParser
    {

        internal ExplorerTreeItemModelViewModelParser(IPresentationLogic presentationLogic, IConfiguration configuration)
        {
            this.PresentationLogic = presentationLogic;
            this.Configuration = configuration;
        }

        /// <inheritdoc/>
        public ObservableCollection<DriveItemViewModel> LoadAllDriveItemViewModels()
        {
            var driveItemModels = this.PresentationLogic.LoadAllDriveItemModels();
            return ConvertDriveItemModelsInDriveItemVMs(driveItemModels);
        }


        private ObservableCollection<DriveItemViewModel> ConvertDriveItemModelsInDriveItemVMs(List<DriveItemModel> driveItemModels)
        {
            var driveItemVMs = new ObservableCollection<DriveItemViewModel>();
            foreach (var driveItemModel in driveItemModels)
            {
                var driveItemViewModel = ExplorerTreeItemViewModelsFactory.CreateDriveItemVM(driveItemModel, this, this.Configuration);
                driveItemVMs.Add(driveItemViewModel);
            }
            return driveItemVMs;
        }

        /// <inheritdoc/>
        public DriveItemViewModel LoadChildDirectoryAndFileViewModels(DriveItemViewModel driveItemVM)
        {
            var driveItemModel = this.PresentationLogic.LoadChildDirectoriesAndFiles(driveItemVM.DriveItemModel);
            driveItemVM.ChildTreeItemVMs = ConvertExplorerTreeChildItemModelsInExplorerTreeChildItemVMs(driveItemVM, driveItemModel.Childs);
            return driveItemVM;
        }


        /// <inheritdoc/>
        public DirectoryItemViewModel LoadChildDirectoryAndFileViewModels(DirectoryItemViewModel directoryItemVM)
        {
            var directoryItemModel = this.PresentationLogic.LoadChildDirectoriesAndFiles(directoryItemVM.DirectoryItemModel);
            directoryItemVM.ChildTreeItemVMs = ConvertExplorerTreeChildItemModelsInExplorerTreeChildItemVMs(directoryItemVM, directoryItemModel.Childs);
            return directoryItemVM;
        }






        private ObservableCollection<AExplorerTreeChildItemViewModel> ConvertExplorerTreeChildItemModelsInExplorerTreeChildItemVMs
            (IExplorerTreeItemViewModel parentItemVM,
            List<AExplorerTreeChildItemModel> explorerTreeChildItemModels)
        {
            parentItemVM.ChildTreeItemVMs.Clear(); // first clear. because: in case of refresh and to delete the dummy-Items.
            foreach (var child in explorerTreeChildItemModels)
            {
                if (child is DirectoryItemModel)
                {
                    var directoryItemVM = ExplorerTreeItemViewModelsFactory.CreateDirectoryItemVM(
                        child as DirectoryItemModel, this, this.Configuration, parentItemVM);
                    parentItemVM.ChildTreeItemVMs.Add(directoryItemVM);
                }
                else if (child is FileItemModel)
                {
                    var fileItemVM = ExplorerTreeItemViewModelsFactory.CreateFileItemVM(
                        child as FileItemModel, this, this.Configuration, parentItemVM);
                    parentItemVM.ChildTreeItemVMs.Add(fileItemVM);
                }
            }

            return parentItemVM.ChildTreeItemVMs;
        }


        /// <summary>
        /// For communication with other components/layers, like: <see cref="BusinessLogic"/>
        /// </summary>
        internal IPresentationLogic PresentationLogic { get; private set; }


        /// <summary>
        /// For example: those who realize the interface <see cref="IExplorerTreeItemViewModel"/>  need it e.g. 
        /// for quirying states. 
        ///     For example: To init the <see cref="IconViewModel"/> the current <see cref="IconStates"/> 
        ///     is needed. The <see cref="IconOverallConfigurationOLD"/> holds the <see cref="IconStates"/>
        /// </summary>
        internal IConfiguration Configuration { get; private set; }
    }
}

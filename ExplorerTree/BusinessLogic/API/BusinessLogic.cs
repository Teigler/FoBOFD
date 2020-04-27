using ExplorerTree.Data.API;
using ExplorerTree.Model.ExplorerTreeItems;
using ExplorerTree.PresentationLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.BusinessLogic.API
{
    internal class BusinessLogic : IBusinessLogic
    {

        internal BusinessLogic(IData data)
        {
            this.Data = data;
        }

        /// <inheritdoc/>
        public List<DriveItemModel> LoadAllDriveItemModels()
        {
            return this.Data.LoadAllDriveItemModels();
        }

        /// <inheritdoc/>
        public DriveItemModel LoadChildDirectoriesAndFiles(DriveItemModel driveItemModel)
        {
            return this.Data.LoadChildDirectoriesAndFiles(driveItemModel);
        }


        /// <inheritdoc/>
        public DirectoryItemModel LoadChildDirectoriesAndFiles(DirectoryItemModel directoryItemModel)
        {
            return this.Data.LoadChildDirectoriesAndFiles(directoryItemModel);
        }

        internal IData Data { get; private set; }
    }
}

using ExplorerTree.API.Configuration;
using ExplorerTree.BusinessLogic.API;
using ExplorerTree.Model.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.PresentationLogic.API
{
    /// <summary>
    /// Mainly responsible for communication with other componenents 
    /// </summary>
    internal class PresentationLogic : IPresentationLogic
    {
        internal PresentationLogic(IConfiguration configuration, IBusinessLogic businessLogic)
        {
            this.BusinessLogic = businessLogic;
            this.Configuration = configuration;
            this.ExplorerTreeVM = null;
        }



        /// <inheritdoc/>
        public List<DriveItemModel> LoadAllDriveItemModels()
        {
            return this.BusinessLogic.LoadAllDriveItemModels();
        }

        /// <inheritdoc/>
        public DriveItemModel LoadChildDirectoriesAndFiles(DriveItemModel driveItemModel)
        {
            return this.BusinessLogic.LoadChildDirectoriesAndFiles(driveItemModel);
        }

        /// <inheritdoc/>
        public DirectoryItemModel LoadChildDirectoriesAndFiles(DirectoryItemModel directoryItemModel)
        {
            return this.BusinessLogic.LoadChildDirectoriesAndFiles(directoryItemModel);
        }


        /// <inheritdoc/>
        public IBusinessLogic BusinessLogic { get; }

        /// <inheritdoc/>
        public IConfiguration Configuration { get; }

        /// <inheritdoc/>
        public ExplorerTreeViewModel ExplorerTreeVM { get; set; }
    }
}

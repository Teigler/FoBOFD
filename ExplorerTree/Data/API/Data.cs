using ExplorerTree.BusinessLogic.API;
using ExplorerTree.Data.FileSystem;
using ExplorerTree.Model;
using ExplorerTree.Model.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.Data.API
{
    /// <summary>
    /// For main communication with the <see cref="Data"/>-Component.
    /// </summary>
    internal class Data : IData
    {
        
        internal Data(IFileSystemHandler fileSystemHandler = null)
        {
            this.FileSystemHandler = fileSystemHandler ?? new FileSystemHandler();
        }

        /// <inheritdoc/>
        public List<DriveItemModel> LoadAllDriveItemModels()
        {
            return this.FileSystemHandler.LoadAllDriveItemModels();
        }

        /// <inheritdoc/>
        public DriveItemModel LoadChildDirectoriesAndFiles(DriveItemModel driveItemModel)
        {
            return this.FileSystemHandler.LoadChildDirectoriesAndFiles(driveItemModel);
        }

        /// <inheritdoc/>
        public DirectoryItemModel LoadChildDirectoriesAndFiles(DirectoryItemModel directoryItemModel)
        {
            return this.FileSystemHandler.LoadChildDirectoriesAndFiles(directoryItemModel);
        }



        internal IFileSystemHandler FileSystemHandler { get; private set; }
    }
}

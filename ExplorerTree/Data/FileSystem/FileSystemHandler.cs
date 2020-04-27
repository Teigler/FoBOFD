using ExplorerTree.Data.FileSystem.Parser;
using ExplorerTree.Model.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.Data.FileSystem
{
    /// <summary>
    /// Coordinates parsing and accessing of the Filesystem-Elements
    /// </summary>
    internal class FileSystemHandler : IFileSystemHandler
    {
        internal FileSystemHandler()
        {
            this.DirectoryParser = new DirectoryParser();
            this.DriveParser = new DriveParser();
            this.FileParser = new FileParser();
            this.FileSystemAccess = new FileSystemAccess();
        }




        /// <inheritdoc/>
        public List<DriveItemModel> LoadAllDriveItemModels()
        {
            //todo exception handling
            List<DriveInfo> allDrives = this.FileSystemAccess.GetDrives();
            return this.DriveParser.ParseDrivesToDriveItemModel(allDrives);
        }






        /// <inheritdoc/>
        public DriveItemModel LoadChildDirectoriesAndFiles(DriveItemModel driveItemModel)
        {
            driveItemModel = this.LoadChildDirectoriesForDrive(driveItemModel);
            driveItemModel = this.LoadChildFilesForDrive(driveItemModel);
            return driveItemModel;
        }

        private DriveItemModel LoadChildDirectoriesForDrive(DriveItemModel driveItemModel)
        {
            List<string> directories = this.FileSystemAccess.GetDirectories(driveItemModel.Name);
            driveItemModel.Childs.AddRange(this.DirectoryParser.DirectoriesToDirectoryItemModel(directories, driveItemModel));
            return driveItemModel;
        }

        private DriveItemModel LoadChildFilesForDrive(DriveItemModel driveItemModel)
        {
            List<string> files = this.FileSystemAccess.GetFiles(driveItemModel.Name);
            driveItemModel.Childs.AddRange(this.FileParser.FilesToFileItemModel(files, driveItemModel)); ;
            return driveItemModel;
        }




        /// <inheritdoc/>
        public DirectoryItemModel LoadChildDirectoriesAndFiles(DirectoryItemModel directoryItemModel)
        {
            directoryItemModel = this.LoadChildDirectoriesForDirectory(directoryItemModel);
            directoryItemModel = this.LoadChildFilesForDirectory(directoryItemModel);
            return directoryItemModel;
        }

        private DirectoryItemModel LoadChildDirectoriesForDirectory(DirectoryItemModel directoryItemModel)
        {
            List<string> directories = this.FileSystemAccess.GetDirectories(directoryItemModel.FullName);
            directoryItemModel.Childs.AddRange(this.DirectoryParser.DirectoriesToDirectoryItemModel(directories, directoryItemModel));
            return directoryItemModel;
        }

        private DirectoryItemModel LoadChildFilesForDirectory(DirectoryItemModel directoryItemModel)
        {
            List<string> files = this.FileSystemAccess.GetFiles(directoryItemModel.FullName);
            directoryItemModel.Childs.AddRange(this.FileParser.FilesToFileItemModel(files, directoryItemModel));
            return directoryItemModel;
        }





        internal IDirectoryParser DirectoryParser { get; set; }

        internal IDriveParser DriveParser { get; set; }

        internal IFileParser FileParser { get;  set; }

        internal IFileSystemAccess FileSystemAccess { get; set; }

    }
}

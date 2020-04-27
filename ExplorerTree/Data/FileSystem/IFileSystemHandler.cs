using ExplorerTree.Model.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.Data.FileSystem
{
    internal interface IFileSystemHandler
    {

        /// <summary>
        /// For loading the roots.
        /// </summary>
        /// <returns>Collection with all current available drives represented as <see cref="DriveItemModel"/></returns>
        List<DriveItemModel> LoadAllDriveItemModels();


        /// <summary>
        /// Loads the child elements (directories and files) of the <paramref name="driveItemModel"/>
        /// </summary>
        /// <param name="driveItemModel">The <see cref="DriveItemModel"/> whose children should be parsed.</param>
        /// <returns>The <see cref="DriveItemModel"/> with new <see cref="DriveItemModel.Childs"/></returns>
        DriveItemModel LoadChildDirectoriesAndFiles(DriveItemModel driveItemModel);


        /// <summary>
        /// Loads the child elements (directories and files) of the <paramref name="directoryItemModel"/>
        /// </summary>
        /// <param name="directoryItemModel">The <see cref="DirectoryItemModel"/> whose children should be parsed.</param>
        /// <returns>The <see cref="DirectoryItemModel"/> with new <see cref="DirectoryItemModel.Childs"/></returns>
        DirectoryItemModel LoadChildDirectoriesAndFiles(DirectoryItemModel directoryItemModel);
    }
}

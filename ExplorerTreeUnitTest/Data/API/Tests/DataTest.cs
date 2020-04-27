using ExplorerTree.Data.FileSystem;
using ExplorerTree.Model.ExplorerTreeItems;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeUnitTest.Data.API.Tests
{
    [TestFixture]
    public class DataTest
    {

        private ExplorerTree.Data.API.Data CreateData(IFileSystemHandler fileSystemHandler = null)
        {
            fileSystemHandler = fileSystemHandler ?? Substitute.For<IFileSystemHandler>();
            return new ExplorerTree.Data.API.Data(fileSystemHandler);
        }


        [Test]
        public void Data_DefaultInitialisation_PropertyFileSystemHandlerIsInitialised()
        {
            var mockFileSystemHandler = Substitute.For<IFileSystemHandler>();

            var data = CreateData(mockFileSystemHandler);

            Assert.AreEqual(mockFileSystemHandler, data.FileSystemHandler);
        }

        [Test]
        public void LoadAllDriveItemModels_GetCollectionFromFileSystemHandler_CollectionReturned()
        {
            var data = CreateData();
            var expected = new List<DriveItemModel>();
            expected.Add(Substitute.For<IExplorerTreeItemModel>() as DriveItemModel);
            data.FileSystemHandler.LoadAllDriveItemModels().Returns(expected);

            var returnCollection = data.LoadAllDriveItemModels();

            Assert.AreEqual(expected, returnCollection);
        }


        [Test]
        public void LoadChildDirectoriesAndFiles_CallFileSystemHandlerWithDriveItemModelParameter_ReturnValue()
        {
            var data = CreateData();
            var mockDriveItemModel = Substitute.For<IExplorerTreeItemModel>() as DriveItemModel;
            data.FileSystemHandler.LoadChildDirectoriesAndFiles(Arg.Is(mockDriveItemModel)).Returns(mockDriveItemModel);

            var returnValue = data.LoadChildDirectoriesAndFiles(mockDriveItemModel);

            Assert.AreEqual(mockDriveItemModel, returnValue);
        }


        [Test]
        public void LoadChildDirectoriesAndFiles_CallFileSystemHandlerWithDirectoryItemModelParameter_ReturnValue()
        {
            var data = CreateData();
            var mockDirectoryItemModel = Substitute.For<IExplorerTreeItemModel>() as DirectoryItemModel;
            data.FileSystemHandler.LoadChildDirectoriesAndFiles(Arg.Is(mockDirectoryItemModel)).Returns(mockDirectoryItemModel);

            var returnValue = data.LoadChildDirectoriesAndFiles(mockDirectoryItemModel);

            Assert.AreEqual(mockDirectoryItemModel, returnValue);
        }


    }
}

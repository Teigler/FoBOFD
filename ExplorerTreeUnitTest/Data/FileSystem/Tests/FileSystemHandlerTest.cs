using ExplorerTree.Data.FileSystem;
using ExplorerTree.Data.FileSystem.Parser;
using ExplorerTree.Model.ExplorerTreeItems;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeUnitTest.Data.FileSystem.Tests
{
    [TestFixture]
    public class FileSystemHandlerTest
    {
        private FileSystemHandler CreateFileSystemHandler()
        {
            var fileSystemHandler = new FileSystemHandler();
            fileSystemHandler.FileSystemAccess = Substitute.For<IFileSystemAccess>();
            fileSystemHandler.FileSystemAccess.GetDirectories(Arg.Any<string>()).Returns(GetDirectoriesPathCollection());
            fileSystemHandler.FileSystemAccess.GetFiles(Arg.Any<string>()).Returns(GetFilesPathCollection());

            var directoryParser = Substitute.For<IDirectoryParser>();
            var driveParser = Substitute.For<IDriveParser>();
            var fileParser = Substitute.For<IFileParser>();

            fileSystemHandler.DirectoryParser = directoryParser;
            fileSystemHandler.DriveParser = driveParser;
            fileSystemHandler.FileParser = fileParser;
            return fileSystemHandler;
        }

        private List<string> GetDirectoriesPathCollection()
        {
            var collection = new List<string>();
            collection.Add("Directory1");
            collection.Add("Directory2");
            collection.Add("Directory3");
            return collection;
        }

        private List<string> GetFilesPathCollection()
        {
            var collection = new List<string>();
            collection.Add("File1");
            collection.Add("File2");
            collection.Add("File3");
            return collection;
        }


        private List<AExplorerTreeChildItemModel> GetDirectoriesAExplorerTreeChildItemModelCollection()
        {
            var collection = new List<AExplorerTreeChildItemModel>();
            collection.Add(Substitute.For<DirectoryItemModel>());
            collection.Add(Substitute.For<DirectoryItemModel>());
            collection.Add(Substitute.For<DirectoryItemModel>());
            return collection;
        }

        private List<AExplorerTreeChildItemModel> GetFilesAExplorerTreeChildItemModelCollection()
        {
            var collection = new List<AExplorerTreeChildItemModel>();
            collection.Add(Substitute.For<FileItemModel>());
            collection.Add(Substitute.For<FileItemModel>());
            collection.Add(Substitute.For<FileItemModel>());
            return collection;
        }


        [Test]
        public void FileSystemHandler_DefaultInitialisation_AllPropertiesAreInitialised()
        {
            var fileSystemHandler = CreateFileSystemHandler();

            Assert.NotNull(fileSystemHandler.DirectoryParser, "Property: \"" + nameof(fileSystemHandler.DirectoryParser) + "\" was null!");
            Assert.NotNull(fileSystemHandler.DriveParser, "Property: \"" + nameof(fileSystemHandler.DriveParser) + "\" was null!");
            Assert.NotNull(fileSystemHandler.FileParser, "Property: \"" + nameof(fileSystemHandler.FileParser) + "\" was null!");
            Assert.NotNull(fileSystemHandler.FileSystemAccess, "Property: \"" + nameof(fileSystemHandler.FileSystemAccess) + "\" was null!");
        }

        // todo finish this test -> JIRA FOB-8
        //[Test]
        //public void LoadAllDriveItemModels_ParseTheDriveInfosToDriveITemModel_ReturnDriveItemModelCollection()
        //{
        //    var fileSystemHandler = CreateFileSystemHandler();
        //    var fakeFileSystemAccess = Substitute.For<IFileSystemAccess>();
        //    var expected = new List<DriveInfo>();
        //    expected.Add(Substitute.For<DriveInfo>());
        //    fakeFileSystemAccess.GetDrives().Returns(expected);
        //}



        [Test]
        public void LoadChildDirectoriesAndFiles_DriveItemModel_LoadedDirectoriesAndFilesAreInDriveItemModel()
        {
            var fileSystemHandler = CreateFileSystemHandler();
            var mockDriveItemModel = Substitute.For<DriveItemModel>();
            mockDriveItemModel.Name.Returns("Teschterei");
            mockDriveItemModel.Childs.Returns(new List<AExplorerTreeChildItemModel>());

            var returnDirectories = GetDirectoriesAExplorerTreeChildItemModelCollection();
            var returnFiles = GetFilesAExplorerTreeChildItemModelCollection();
            var expectedCollection = new List<AExplorerTreeChildItemModel>();
            expectedCollection.AddRange(returnDirectories);
            expectedCollection.AddRange(returnFiles);

            fileSystemHandler.DirectoryParser.DirectoriesToDirectoryItemModel(Arg.Any<List<string>>(), mockDriveItemModel)
                .Returns(returnDirectories);
            fileSystemHandler.FileParser.FilesToFileItemModel(Arg.Any<List<string>>(), mockDriveItemModel)
                .Returns(returnFiles);


            mockDriveItemModel = fileSystemHandler.LoadChildDirectoriesAndFiles(mockDriveItemModel);

            Assert.AreEqual(expectedCollection, mockDriveItemModel.Childs);
        }



        [Test]
        public void LoadChildDirectoriesAndFiles_DirectoryItemModel_LoadedDirectoriesAndFilesAreInDirectoryItemModel()
        {
            var fileSystemHandler = CreateFileSystemHandler();
            var mockDirectoryItemModel = Substitute.For<DirectoryItemModel>();
            mockDirectoryItemModel.FullName.Returns("Teschterei");
            mockDirectoryItemModel.Childs.Returns(new List<AExplorerTreeChildItemModel>());

            var returnDirectories = GetDirectoriesAExplorerTreeChildItemModelCollection();
            var returnFiles = GetFilesAExplorerTreeChildItemModelCollection();
            var expectedCollection = new List<AExplorerTreeChildItemModel>();
            expectedCollection.AddRange(returnDirectories);
            expectedCollection.AddRange(returnFiles);

            fileSystemHandler.DirectoryParser.DirectoriesToDirectoryItemModel(Arg.Any<List<string>>(), mockDirectoryItemModel)
                .Returns(returnDirectories);
            fileSystemHandler.FileParser.FilesToFileItemModel(Arg.Any<List<string>>(), mockDirectoryItemModel)
                .Returns(returnFiles);


            mockDirectoryItemModel = fileSystemHandler.LoadChildDirectoriesAndFiles(mockDirectoryItemModel);

            Assert.AreEqual(expectedCollection, mockDirectoryItemModel.Childs);
        }





        [Test]
        public void DirectoryParser_SetGet_ReturnValue()
        {
            var fileSystemHandler = CreateFileSystemHandler();

            var expected = Substitute.For<IDirectoryParser>();
            fileSystemHandler.DirectoryParser = expected;

            Assert.AreEqual(expected, fileSystemHandler.DirectoryParser);
        }

        [Test]
        public void DriveParser_SetGet_ReturnValue()
        {
            var fileSystemHandler = CreateFileSystemHandler();

            var expected = Substitute.For<IDriveParser>();
            fileSystemHandler.DriveParser = expected;

            Assert.AreEqual(expected, fileSystemHandler.DriveParser);
        }


        [Test]
        public void FileyParser_SetGet_ReturnValue()
        {
            var fileSystemHandler = CreateFileSystemHandler();

            var expected = Substitute.For<IFileParser>();
            fileSystemHandler.FileParser = expected;

            Assert.AreEqual(expected, fileSystemHandler.FileParser);
        }


        [Test]
        public void FileSystemAccess_SetGet_ReturnValue()
        {
            var fileSystemHandler = CreateFileSystemHandler();

            var expected = Substitute.For<IFileSystemAccess>();
            fileSystemHandler.FileSystemAccess = expected;

            Assert.AreEqual(expected, fileSystemHandler.FileSystemAccess);
        }


    }
}

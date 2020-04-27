using ExplorerTree.BusinessLogic.API;
using ExplorerTree.Model.ExplorerTreeItems;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeUnitTest.BusinessLogic.API.Tests
{
    [TestFixture]
    public class BusinessLogicTest
    {
        private ExplorerTree.BusinessLogic.API.BusinessLogic CreateBusinessLogic(IData fakeData = null)
        {
            fakeData = fakeData ?? Substitute.For<IData>();
            return new ExplorerTree.BusinessLogic.API.BusinessLogic(fakeData);
        }

      
        [Test]
        public void BusinessLogic_DefaultInitialisaton_AllPropertiesAreInitialised()
        {
            var mockData = Substitute.For<IData>();
            var businessLogik = CreateBusinessLogic(mockData);

            Assert.AreEqual(mockData, businessLogik.Data);
        }


        [Test]
        public void LoadAllDriveItemModels_ReturnCollectionFromData_CollectionReturned()
        {
            var businessLogic = CreateBusinessLogic();
            var expected = new List<DriveItemModel>();
            expected.Add(Substitute.For<IExplorerTreeItemModel>() as DriveItemModel);
            businessLogic.Data.LoadAllDriveItemModels().Returns(expected);
            var returnValue = businessLogic.LoadAllDriveItemModels();

            Assert.AreEqual(expected, returnValue);
        }


        [Test]
        public void LoadChildDirectoriesAndFiles_CallDataWithDriveItemModelParameter_ReturnValue()
        {
            var businessLogic = CreateBusinessLogic();
            var mockDriveItemModel = Substitute.For<IExplorerTreeItemModel>() as DriveItemModel;
            businessLogic.Data.LoadChildDirectoriesAndFiles(Arg.Is(mockDriveItemModel)).Returns(mockDriveItemModel);
            var returnValue = businessLogic.LoadAllDriveItemModels();

            Assert.AreEqual(mockDriveItemModel, returnValue);
        }



        [Test]
        public void LoadChildDirectoriesAndFiles_CallDataWithDirectoryItemModelParameter_ReturnValue()
        {
            var businessLogic = CreateBusinessLogic();
            var mockDirectoryItemModel = Substitute.For<IExplorerTreeItemModel>() as DirectoryItemModel;
            businessLogic.Data.LoadChildDirectoriesAndFiles(Arg.Is(mockDirectoryItemModel)).Returns(mockDirectoryItemModel);
            var returnValue = businessLogic.LoadAllDriveItemModels();

            Assert.AreEqual(mockDirectoryItemModel, returnValue);
        }
    }
}

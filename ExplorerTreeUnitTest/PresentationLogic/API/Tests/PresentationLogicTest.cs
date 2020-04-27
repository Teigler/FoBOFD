using ExplorerTree.API.Configuration;
using ExplorerTree.Model.ExplorerTreeItems;
using ExplorerTree.PresentationLogic.API;
using ExplorerTreeUnitTest.PresentationLogic.Fakes;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeUnitTest.PresentationLogic.API.Tests
{
    [TestFixture]
    public class PresentationLogicTest
    {
        private static ExplorerTree.PresentationLogic.API.PresentationLogic CreatePresentationLogic(IBusinessLogic businessLogic = null)
        {
            IConfiguration fakeConfiguration = Substitute.For<IConfiguration>();
            return  CreatePresentationLogic(fakeConfiguration, businessLogic);
        }

        private static ExplorerTree.PresentationLogic.API.PresentationLogic CreatePresentationLogic(IConfiguration FakeConfiguration, IBusinessLogic fakeBusinessLogic = null)
        {
            fakeBusinessLogic = fakeBusinessLogic ?? Substitute.For<IBusinessLogic>();
            return new ExplorerTree.PresentationLogic.API.PresentationLogic(FakeConfiguration, fakeBusinessLogic);
        }




        [Test] 
        public void PresentationLogic_DefaultInitialisation_PropertyBusinessLogicIsInitialised()
        {
            IBusinessLogic mockBusinessLogic = Substitute.For<IBusinessLogic>();
            var presentationLogic = CreatePresentationLogic(mockBusinessLogic);

            Assert.AreEqual(mockBusinessLogic, presentationLogic.BusinessLogic);
        }

        [Test]
        public void PresentationLogic_DefaultInitialisation_PropertyConfigurationIsInitialised()
        {
            IConfiguration mockConfiguration = Substitute.For<IConfiguration>();
            var presentationLogic = CreatePresentationLogic(mockConfiguration);

            Assert.AreEqual(mockConfiguration, presentationLogic.Configuration);
        }

        [Test]
        public void PresentationLogic_DefaultInitialisation_PropertyExplorerTreeVMIsNull()
        {
            var presentationLogic = CreatePresentationLogic();

            Assert.AreEqual(null, presentationLogic.ExplorerTreeVM);
        }




        [Test]
        public void LoadAllDriveItemModels_ReturnCollectionFromBusinessLogic_CollectionReturned()
        {
            var mockBusinessLogic = Substitute.For<IBusinessLogic>();
            var mockDriveItemModels = new List<DriveItemModel>();
            var stubDriveItemModel = Substitute.For<IExplorerTreeItemModel>();
            mockDriveItemModels.Add(stubDriveItemModel as DriveItemModel);
            mockBusinessLogic.LoadAllDriveItemModels().Returns(mockDriveItemModels);
            IPresentationLogic presentationLogic = CreatePresentationLogic(mockBusinessLogic);

            var returnValue = presentationLogic.LoadAllDriveItemModels();

            Assert.AreEqual(mockDriveItemModels, returnValue);
        }



        [Test]
        public void LoadChildDirectoriesAndFiles_CallBusinessLogicWithDriveItemModelParameter_ReturnValue()
        {
            var mockBusinessLogic = Substitute.For<IBusinessLogic>();
            var mockDriveItemModel = Substitute.For<IExplorerTreeItemModel>() as DriveItemModel;
            mockBusinessLogic.LoadChildDirectoriesAndFiles(Arg.Is(mockDriveItemModel)).Returns(mockDriveItemModel); ;
            var presentationLogic = CreatePresentationLogic(mockBusinessLogic);

            var returnValue = presentationLogic.LoadChildDirectoriesAndFiles(mockDriveItemModel);

            Assert.AreEqual(mockDriveItemModel as DriveItemModel, returnValue);
        }



        [Test]
        public void LoadChildDirectoriesAndFiles_CallBusinessLogicWitDirectoryItemModelParameter_ReturnValue()
        {
            var mockBusinessLogic = Substitute.For<IBusinessLogic>();
            var mockDirectoryItemModel = Substitute.For<IExplorerTreeItemModel>() as DirectoryItemModel;
            mockBusinessLogic.LoadChildDirectoriesAndFiles(Arg.Is(mockDirectoryItemModel)).Returns(mockDirectoryItemModel); ;
            var presentationLogic = CreatePresentationLogic(mockBusinessLogic);

            var returnValue = presentationLogic.LoadChildDirectoriesAndFiles(mockDirectoryItemModel);

            Assert.AreEqual(mockDirectoryItemModel as DirectoryItemModel, returnValue);
        }



        [Test]
        public void ExplorerTreeVM_SetGet_ReturnsSetValue()
        {
            IConfiguration fakeConfiguration = Substitute.For<IConfiguration>();
            IPresentationLogic fakePresentationLogic = Substitute.For<IPresentationLogic>();
            var expected = new FakeExplorerTreeViewModel(fakeConfiguration, fakePresentationLogic);
            var presentationLogic = CreatePresentationLogic();

            presentationLogic.ExplorerTreeVM = expected;

            Assert.AreEqual(expected, presentationLogic.ExplorerTreeVM);
        }




    }

}

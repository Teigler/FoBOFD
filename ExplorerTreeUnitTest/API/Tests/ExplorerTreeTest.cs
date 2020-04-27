using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExplorerTree.API;
using NSubstitute;
using ExplorerTreeUnitTest.PresentationLogic.Fakes;
using ExplorerTree.PresentationLogic.API;
using ExplorerTree.API.Configuration;

namespace ExplorerTreeUnitTest.API.Tests
{
    [TestFixture]
    public class ExplorerTreeTest
    {

        private ExplorerTree.API.ExplorerTree CreateExplorerTree()
        {
            IConfiguration fakeConfiguration = Substitute.For<IConfiguration>();
            IPresentationLogic fakePresentationLogic = Substitute.For<IPresentationLogic>();
            ISelectedExplorerTreeItemAPI fakeSelectedExplorerTreeItemAPI = Substitute.For<ISelectedExplorerTreeItemAPI>();
            FakeExplorerTreeViewModel fakeExplorerTreeVM = new FakeExplorerTreeViewModel(fakeConfiguration, fakePresentationLogic);

            return new ExplorerTree.API.ExplorerTree(fakeConfiguration, fakeExplorerTreeVM, fakePresentationLogic, fakeSelectedExplorerTreeItemAPI);
        }

        [Test]
        public void ExplorerTree_DefaultInitialisation_AllPropertiesAreInitialised()
        {
            IConfiguration fakeConfiguration = Substitute.For<IConfiguration>();
            IPresentationLogic fakePresentationLogic = Substitute.For<IPresentationLogic>();
            ISelectedExplorerTreeItemAPI fakeSelectedExplorerTreeItemAPI = Substitute.For<ISelectedExplorerTreeItemAPI>();
            FakeExplorerTreeViewModel fakeExplorerTreeVM = new FakeExplorerTreeViewModel(fakeConfiguration, fakePresentationLogic);

            IExplorerTree explorerTree = new ExplorerTree.API.ExplorerTree(fakeConfiguration, fakeExplorerTreeVM, fakePresentationLogic, fakeSelectedExplorerTreeItemAPI);

            Assert.AreEqual(fakeConfiguration, explorerTree.Configuration, "Property: \"" + nameof(explorerTree.Configuration) + "\" was Not initialised correctly!");
            Assert.AreEqual(fakePresentationLogic, (explorerTree as ExplorerTree.API.ExplorerTree).PresentationLogic, "Property: \"" + "PresentationLogic" + "\" was Not initialised correctly!");
            Assert.AreEqual(fakeSelectedExplorerTreeItemAPI, explorerTree.SelectedItemAPI, "Property: \"" + nameof(explorerTree.SelectedItemAPI) + "\" was Not initialised correctly!");
            Assert.AreEqual(fakeExplorerTreeVM, explorerTree.ExplorerTreeVM, "Property: \"" + nameof(explorerTree.ExplorerTreeVM) + "\" was Not initialised correctly!");
        }


        [Test]
        public void ExplorerTree_DefaultInitialisation_PresentationLogicPropertyExplorerTreeVMIsInitialised()
        {
            IConfiguration fakeConfiguration = Substitute.For<IConfiguration>();
            IPresentationLogic fakePresentationLogic = Substitute.For<IPresentationLogic>();
            ISelectedExplorerTreeItemAPI fakeSelectedExplorerTreeItemAPI = Substitute.For<ISelectedExplorerTreeItemAPI>();
            FakeExplorerTreeViewModel fakeExplorerTreeVM = new FakeExplorerTreeViewModel(fakeConfiguration, fakePresentationLogic);

            IExplorerTree explorerTree = new ExplorerTree.API.ExplorerTree(fakeConfiguration, fakeExplorerTreeVM, fakePresentationLogic, fakeSelectedExplorerTreeItemAPI);

            Assert.AreEqual(fakePresentationLogic.ExplorerTreeVM, (explorerTree as ExplorerTree.API.ExplorerTree).PresentationLogic.ExplorerTreeVM);
        }

        [Test]
        public void ExplorerTree_DefaultInitialisation_CofigurationMethodInitialisationWasCalledWithExplorerTreeVM()
        {
            IConfiguration fakeConfiguration = Substitute.For<IConfiguration>();
            IPresentationLogic fakePresentationLogic = Substitute.For<IPresentationLogic>();
            ISelectedExplorerTreeItemAPI fakeSelectedExplorerTreeItemAPI = Substitute.For<ISelectedExplorerTreeItemAPI>();
            FakeExplorerTreeViewModel fakeExplorerTreeVM = new FakeExplorerTreeViewModel(fakeConfiguration, fakePresentationLogic);

            IExplorerTree explorerTree = new ExplorerTree.API.ExplorerTree(fakeConfiguration, fakeExplorerTreeVM, fakePresentationLogic, fakeSelectedExplorerTreeItemAPI);

            fakeConfiguration.Received().Initialisation(fakeExplorerTreeVM);
        }


        [Test]
        public void ExplorerTree_DefaultInitialisation_ExplorerTreeMethodLoadAllDriveItemViewModelsWasCalled()
        {
            IConfiguration fakeConfiguration = Substitute.For<IConfiguration>();
            IPresentationLogic fakePresentationLogic = Substitute.For<IPresentationLogic>();
            ISelectedExplorerTreeItemAPI fakeSelectedExplorerTreeItemAPI = Substitute.For<ISelectedExplorerTreeItemAPI>();
            FakeExplorerTreeViewModel fakeExplorerTreeVM = new FakeExplorerTreeViewModel(fakeConfiguration, fakePresentationLogic);

            IExplorerTree explorerTree = new ExplorerTree.API.ExplorerTree(fakeConfiguration, fakeExplorerTreeVM, fakePresentationLogic, fakeSelectedExplorerTreeItemAPI);

            Assert.AreEqual(true, fakeExplorerTreeVM.LoadAllDriveItemViewModelsWasCalled);
        }


    }
}

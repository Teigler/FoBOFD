using ExplorerTree.API.Configuration;
using ExplorerTree.PresentationLogic;
using ExplorerTree.PresentationLogic.API;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using ExplorerTree.PresentationLogic.SelectionHandling;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeUnitTest.PresentationLogic.Tests
{
    [TestFixture]
    public class ExplorerTreeViewModelTest
    {

        private ExplorerTreeViewModel CreateExplorerTreeItemModelViewModelParser(IConfiguration fakeConfiguration = null, IPresentationLogic fakePresentationLogic = null)
        {
            fakePresentationLogic = fakePresentationLogic ?? CreateFakePresentationLogic();
            fakeConfiguration = fakeConfiguration ?? CreateFakeConfiguration();
            return new ExplorerTreeViewModel(fakeConfiguration, fakePresentationLogic);
        }

        private ExplorerTreeViewModel CreateExplorerTreeItemModelViewModelParser()
        {
            return new ExplorerTreeViewModel();
        }


        private IPresentationLogic CreateFakePresentationLogic()
        {
            return Substitute.For<IPresentationLogic>();
        }

        private IConfiguration CreateFakeConfiguration()
        {
            return Substitute.For<IConfiguration>();
        }

        private ObservableCollection<DriveItemViewModel> CreateFakeCollectionWithOneItem()
        {
            var collection = new ObservableCollection<DriveItemViewModel>();
            collection.Add(Substitute.For<DriveItemViewModel>());
            return collection;
        }

        [Test]
        public void ExplorerTreeViewModel_DefaultInitialisation_AllPropertiesAreInitialised()
        {
            var explorerTreeVM = CreateExplorerTreeItemModelViewModelParser();

            Assert.AreEqual(null, explorerTreeVM.Configuration, "Property: \"" + nameof(explorerTreeVM.Configuration) + "\" was NOT null");
            Assert.NotNull(explorerTreeVM.Drives, "Property: \"" + nameof(explorerTreeVM.Drives) + "\" was null");
            Assert.AreEqual(null, explorerTreeVM.ExplorerTreeItemModelViewModelParser, "Property: \"" + nameof(explorerTreeVM.ExplorerTreeItemModelViewModelParser) + "\" is NOT null");
            Assert.AreEqual(null, explorerTreeVM.PresentationLogic, "Property: \"" + nameof(explorerTreeVM.PresentationLogic) + "\" was NOT null");
            Assert.AreEqual(null, explorerTreeVM.SelectedItemHandler, "Property: \"" + nameof(explorerTreeVM.SelectedItemHandler) + "\" was NOT null");
        }

        [Test]
        public void ExplorerTreeViewModel_Initialisation_PropertyConfigurationIsInitialised()
        {
            var mockConfiguration = CreateFakeConfiguration();

            var explorerTreeVM = CreateExplorerTreeItemModelViewModelParser(mockConfiguration, null);

            Assert.AreEqual(mockConfiguration, explorerTreeVM.Configuration);
        }

        [Test]
        public void ExplorerTreeViewModel_Initialisation_PropertyDrivesIsInitialised()
        {
            var explorerTreeVM = CreateExplorerTreeItemModelViewModelParser(null, null);

            Assert.NotNull(explorerTreeVM.Drives);

        }

        [Test]
        public void ExplorerTreeViewModel_Initialisation_PropertyExplorerTreeItemModelViewModelParserIsInitialised()
        {
            var explorerTreeVM = CreateExplorerTreeItemModelViewModelParser(null, null);

            Assert.NotNull(explorerTreeVM.ExplorerTreeItemModelViewModelParser);
        }

        [Test]
        public void ExplorerTreeViewModel_Initialisation_PropertyPresentationLogicIsInitialised()
        {
            var mockPresentationLogic = CreateFakePresentationLogic();

            var explorerTreeVM = CreateExplorerTreeItemModelViewModelParser(null, mockPresentationLogic);

            Assert.AreEqual(mockPresentationLogic, explorerTreeVM.PresentationLogic);
        }

        [Test]
        public void ExplorerTreeViewModel_Initialisation_PropertySelectedItemHandlerIsInitialised()
        {
            var explorerTreeVM = CreateExplorerTreeItemModelViewModelParser(null, null);

            Assert.NotNull(explorerTreeVM.SelectedItemHandler);
        }





        [Test]
        public void LoadAllDriveItemViewModels_LoadFromPresentationLogic_LoadedDrivesAreReturned()
        {
            var explorerTreeVM = CreateExplorerTreeItemModelViewModelParser(null, null);
            explorerTreeVM.ExplorerTreeItemModelViewModelParser = Substitute.For<IExplorerTreeItemModelViewModelParser>();
            var expected = CreateFakeCollectionWithOneItem();
            explorerTreeVM.ExplorerTreeItemModelViewModelParser.LoadAllDriveItemViewModels().Returns(expected);

            explorerTreeVM.LoadAllDriveItemViewModels();

            Assert.AreEqual(expected, explorerTreeVM.Drives);
        }


        [Test]
        public void Drives_SetGet_ReturnSetValue()
        {
            var explorerTreeVM = CreateExplorerTreeItemModelViewModelParser(null, null);

            var expected = CreateFakeCollectionWithOneItem();
            explorerTreeVM.Drives = expected;

            Assert.AreEqual(expected, explorerTreeVM.Drives);
        }


        [Test]
        public void Drives_OnPropertyChanged_FiredPropertyChanged()
        {
            var explorerTreeVM = CreateExplorerTreeItemModelViewModelParser(null, null);
            bool propertyChangedFired = false;
            explorerTreeVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = CreateFakeCollectionWithOneItem();

            explorerTreeVM.Drives = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void Drives_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var explorerTreeVM = CreateExplorerTreeItemModelViewModelParser(null, null);
            bool propertyChangedFired = false;
            explorerTreeVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            explorerTreeVM.Drives = explorerTreeVM.Drives;

            Assert.IsFalse(propertyChangedFired);
        }






        [Test]
        public void ExplorerTreeItemModelViewModelParser_SetGet_ReturnSetValue()
        {
            var explorerTreeVM = CreateExplorerTreeItemModelViewModelParser(null, null);

            var expected = Substitute.For<IExplorerTreeItemModelViewModelParser>();
            explorerTreeVM.ExplorerTreeItemModelViewModelParser = expected;

            Assert.AreEqual(expected, explorerTreeVM.ExplorerTreeItemModelViewModelParser);
        }





        [Test]
        public void SelectedItemHandler_SetGet_ReturnSetValue()
        {
            var explorerTreeVM = CreateExplorerTreeItemModelViewModelParser(null, null);

            var expected = Substitute.For<ISelectedExplorerTreeItemHandler>();
            explorerTreeVM.SelectedItemHandler = expected;

            Assert.AreEqual(expected, explorerTreeVM.SelectedItemHandler);
        }


        [Test]
        public void SelectedItemHandler_OnPropertyChanged_FiredPropertyChanged()
        {
            var explorerTreeVM = CreateExplorerTreeItemModelViewModelParser(null, null);
            bool propertyChangedFired = false;
            explorerTreeVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = Substitute.For<ISelectedExplorerTreeItemHandler>();
            explorerTreeVM.SelectedItemHandler = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void SelectedItemHandler_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var explorerTreeVM = CreateExplorerTreeItemModelViewModelParser(null, null);
            bool propertyChangedFired = false;
            explorerTreeVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            explorerTreeVM.SelectedItemHandler = explorerTreeVM.SelectedItemHandler;

            Assert.IsFalse(propertyChangedFired);
        }

    }
}

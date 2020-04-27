using ExplorerTree.API.Configuration;
using ExplorerTree.API.Configuration.AvailabilityConfiguration;
using ExplorerTree.API.Configuration.ExplorerTreeItemConfiguration;
using ExplorerTree.API.Configuration.FontConfiguration;
using ExplorerTree.API.Configuration.IconConfiguration;
using ExplorerTree.Model.ExplorerTreeItems;
using ExplorerTree.PresentationLogic;
using ExplorerTree.PresentationLogic.API;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using ExplorerTree.PresentationLogic.SelectionHandling;
using ExplorerTreeUnitTest.Model.ExplorerTreeItems.Fakes;
using ExplorerTreeUnitTest.PresentationLogic.ExplorerTreeItems.Fakes;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExplorerTreeUnitTest.PresentationLogic.ExplorerTreeItems.Tests
{
    [TestFixture]
    public class DriveItemViewModelTest
    {
        private static DriveItemViewModel CreateDriveItemViewModel(
                   FakeDriveItemModel fakeDriveItemModel = null,
                   IExplorerTreeItemModelViewModelParser fakeExplorerTreeItemModelViewModelParser = null,
                   IConfiguration fakeConfiguration = null,
                   IExplorerTreeItemViewModel fakeParentItem = null)
        {
            fakeDriveItemModel = fakeDriveItemModel ?? new FakeDriveItemModel();
            fakeExplorerTreeItemModelViewModelParser = fakeExplorerTreeItemModelViewModelParser ?? Substitute.For<IExplorerTreeItemModelViewModelParser>();
            fakeConfiguration = fakeConfiguration ?? CreateConfiguration();
            return new DriveItemViewModel(fakeDriveItemModel, fakeExplorerTreeItemModelViewModelParser, fakeConfiguration);

        }

        private static ExplorerTreeViewModel CreateFakeExplorerTreeVMWithSelectedItemHandler(IConfiguration configuration)
        {
            IPresentationLogic presentationLogic = Substitute.For<IPresentationLogic>();
            var explorerTreeVM = Substitute.For<ExplorerTreeViewModel>(configuration, presentationLogic);
            var selectedItemHandler = Substitute.For<ISelectedExplorerTreeItemHandler>();
            var directorySelectionHandler = Substitute.For<AExplorerTreeItemSelectionHandler>();
            selectedItemHandler.DriveSelectionHandler.Returns(directorySelectionHandler);
            selectedItemHandler.DriveSelectionHandler.IsSelectedHasChanged(default, default).ReturnsForAnyArgs(true);
            explorerTreeVM.SelectedItemHandler.Returns(selectedItemHandler);
            return explorerTreeVM;
        }

        private static IConfiguration CreateConfiguration()
        {
            IConfiguration configuration = new Configuration();
            configuration.ExplorerTreeVM = CreateFakeExplorerTreeVMWithSelectedItemHandler(configuration);


            configuration.Drive = new DriveConfiguration();
            configuration.Drive.Font = Substitute.For<IExplorerTreeItemFontConfiguration>();
            configuration.Drive.Icon = Substitute.For<IExplorerTreeItemIconConfiguration>();

            //configuration.Drive.Availability = new DriveAvailabilityConfiguration(configuration.ExplorerTreeVM);
            configuration.Drive.Availability = Substitute.For<DriveAvailabilityConfiguration>();
            var activatableDriveTypes = new List<ActivatableDriveType>();
            ActivatableDriveType activatableDriveType = Substitute.For<ActivatableDriveType>();
            activatableDriveType.DriveType.Returns(DriveType.Removable);
            activatableDriveType.IsActive.Returns(true);
            activatableDriveTypes.Add(activatableDriveType);
            configuration.Drive.Availability.ActivatableDriveTypes.Returns(activatableDriveTypes);

            configuration.Directory = new DirectoryConfiguration();
            configuration.Directory.Font = Substitute.For<IExplorerTreeItemFontConfiguration>();
            configuration.Directory.Icon = Substitute.For<IExplorerTreeItemIconConfiguration>();

            configuration.File = new FileConfiguration();
            configuration.File.Font = Substitute.For<IExplorerTreeItemFontConfiguration>();
            configuration.File.Icon = Substitute.For<IExplorerTreeItemIconConfiguration>();

            configuration.HiddenOverall = Substitute.For<HiddenOverallConfiguration>();

            return configuration;
        }



        [Test]
        public void DirectoryItemViewModel_DefaultInitialisation_IsInitialised()
        {
            var driveItemVM = new DriveItemViewModel();

            Assert.AreEqual(null, driveItemVM.Configuration, "Property: \"" + nameof(driveItemVM.Configuration) + "\" was NOT null");
            Assert.NotNull(driveItemVM.ChildTreeItemVMs, "Property: \"" + nameof(driveItemVM.ChildTreeItemVMs) + "\" was null");
            Assert.AreEqual(DriveType.Unknown, driveItemVM.DriveType, "Property: \"" + nameof(driveItemVM.DriveType) + "\" was NOT initialised correctly");
            Assert.AreEqual(null, driveItemVM.DriveItemModel, "Property: \"" + nameof(driveItemVM.DriveItemModel) + "\" was NOT null");
            Assert.AreEqual(null, driveItemVM.ExplorerTreeItemModelViewModelParser, "Property: \"" + nameof(driveItemVM.ExplorerTreeItemModelViewModelParser) + "\" was NOT null");
            Assert.AreEqual(null, driveItemVM.ExplorerTreeVM, "Property: \"" + nameof(driveItemVM.ExplorerTreeVM) + "\" was NOT null");
            Assert.AreEqual(null, driveItemVM.FontVM, "Property: \"" + nameof(driveItemVM.FontVM) + "\" was NOT null");
            Assert.AreEqual(false, driveItemVM.IsExpanded, "Property: \"" + nameof(driveItemVM.IsExpanded) + "\" was NOT initialised correctly.");
            Assert.AreEqual(false, driveItemVM.IsSelected, "Property: \"" + nameof(driveItemVM.IsSelected) + "\" was NOT initialised correctly.");
            Assert.AreEqual(null, driveItemVM.IconVM, "Property: \"" + nameof(driveItemVM.IconVM) + "\" was NOT null");
            Assert.AreEqual("init", driveItemVM.Name, "Property: \"" + nameof(driveItemVM.Name) + "\" was NOT initialised correctly.");
            Assert.AreEqual(Visibility.Visible, driveItemVM.Visibility, "Property: \"" + nameof(driveItemVM.Visibility) + "\" was NOT initialised correctly");
        }

        [Test]
        public void DriveItemViewModel_Initialisation_PropertyConfigurationIsInitialised()
        {
            var mockConfiguration = CreateConfiguration();
            var driveItemVM = CreateDriveItemViewModel(null, null, mockConfiguration, null);

            Assert.AreEqual(mockConfiguration, driveItemVM.Configuration);
        }

        [Test]
        public void DriveItemViewModel_Initialisation_PropertyChildTreeItemVMsIsInitialised()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            Assert.NotNull(driveItemVM.ChildTreeItemVMs);
        }

        [Test]
        public void DriveItemViewModel_Initialisation_PropertyDriveTypeIsInitialised()
        {
            var mockDriveItemModel = new FakeDriveItemModel();
            mockDriveItemModel.DriveType = DriveType.CDRom;
            var driveItemVM = CreateDriveItemViewModel(mockDriveItemModel, null, null, null);

            Assert.AreEqual(mockDriveItemModel.DriveType, driveItemVM.DriveType);
        }

        [Test]
        public void DriveItemViewModel_Initialisation_PropertyDriveItemModelIsInitialised()
        {
            var mockDriveItemModel = new FakeDriveItemModel();
            var driveItemVM = CreateDriveItemViewModel(mockDriveItemModel, null, null, null);

            Assert.AreEqual(mockDriveItemModel, driveItemVM.DriveItemModel);
        }

        [Test]
        public void DriveItemViewModel_Initialisation_PropertyExplorerTreeItemModelViewModelParserIsInitialised()
        {
            var mockExplorerTreeItemModelViewModelParser = Substitute.For<IExplorerTreeItemModelViewModelParser>();
            var driveItemVM = CreateDriveItemViewModel(null, mockExplorerTreeItemModelViewModelParser, null, null);

            Assert.AreEqual(mockExplorerTreeItemModelViewModelParser, driveItemVM.ExplorerTreeItemModelViewModelParser);
        }

        [Test]
        public void DriveItemViewModel_Initialisation_PropertyExplorerTreeVMIsInitialised()
        {
            var stubConfiguration = CreateConfiguration();
            var mockExplorerTreeVM = CreateFakeExplorerTreeVMWithSelectedItemHandler(stubConfiguration);
            stubConfiguration.ExplorerTreeVM = mockExplorerTreeVM;
            var driveItemVM = CreateDriveItemViewModel(null, null, stubConfiguration, null);


            Assert.AreEqual(mockExplorerTreeVM, driveItemVM.ExplorerTreeVM);
        }

        [Test]
        public void DriveItemViewModel_Initialisation_PropertyFontVMIsNotNull()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            Assert.NotNull(driveItemVM.FontVM);
        }

        [Test]
        public void DriveItemViewModel_Initialisation_PropertyIsExpandedIsInitialised()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            Assert.IsFalse(driveItemVM.IsExpanded);
        }

        [Test]
        public void DriveItemViewModel_Initialisation_PropertyIsSelectedIsInitialised()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            Assert.IsFalse(driveItemVM.IsSelected);
        }

        [Test]
        public void DriveItemViewModel_Initialisation_PropertyIconVMIsNotNull()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            Assert.NotNull(driveItemVM.IconVM);
        }
        
        [Test]
        public void DriveItemViewModel_Initialisation_PropertyNameIsInitialised()
        {
            var mockDriveItemModel = new FakeDriveItemModel();
            mockDriveItemModel.Name = "TestTestTest";
            var driveItemVM = CreateDriveItemViewModel(mockDriveItemModel, null, null, null);

            Assert.AreEqual(driveItemVM.Name, driveItemVM.Name);
        }

        [Test]
        public void DriveItemViewModel_Initialisation_DummyTreeViewItemAddedToBeExpandable()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            Assert.AreEqual(1, driveItemVM.ChildTreeItemVMs.Count);
            Assert.AreEqual("DummyChild", driveItemVM.ChildTreeItemVMs.First().Name);
        }

        [Test]
        public void DriveItemViewModel_Initialisation_VisibilityWasSetAccordingToConfigurationVisible()
        {
            var stubConfiguration = CreateConfiguration();
            var mockDriveItemModel = new FakeDriveItemModel();
            mockDriveItemModel.DriveType = DriveType.Removable;

            var driveItemVM = CreateDriveItemViewModel(mockDriveItemModel, null, stubConfiguration, null);

            Assert.AreEqual(Visibility.Visible, driveItemVM.Visibility);
        }

        [Test]
        public void DriveItemViewModel_Initialisation_VisibilityWasSetAccordingToConfigurationCollapsed()
        {
            var stubConfiguration = CreateConfiguration();
            var mockDriveItemModel = new FakeDriveItemModel();
            mockDriveItemModel.DriveType = DriveType.Removable;

            var activatableDriveType = stubConfiguration.Drive.Availability.ActivatableDriveTypes.First();
            activatableDriveType.IsActive.Returns(false);

            var driveItemVM = CreateDriveItemViewModel(mockDriveItemModel, null, stubConfiguration, null);

            Assert.AreEqual(Visibility.Collapsed, driveItemVM.Visibility);
        }

        [Test]
        public void SetVisibleOrCollapsedAccordingToIsActiveFrom_SetVisible_IsVisible()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);
            var activatableDriveType = Substitute.For<ActivatableDriveType>();
            activatableDriveType.IsActive.Returns(true);

            driveItemVM.SetVisibleOrCollapsedAccordingToIsActiveFrom(activatableDriveType);

            Assert.AreEqual(Visibility.Visible, driveItemVM.Visibility);
        }

        [Test]
        public void SetVisibleOrCollapsedAccordingToIsActiveFrom_SetCollapsed_IsCollapsed()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);
            var activatableDriveType = Substitute.For<ActivatableDriveType>();
            activatableDriveType.IsActive.Returns(false);

            driveItemVM.SetVisibleOrCollapsedAccordingToIsActiveFrom(activatableDriveType);

            Assert.AreEqual(Visibility.Collapsed, driveItemVM.Visibility);
        }





        [Test]
        public void ChildTreeItemVMs_SetGet_ReturnSetValue()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            var expected = new ObservableCollection<AExplorerTreeChildItemViewModel>();
            expected.Add(Substitute.For<DirectoryItemViewModel>());
            expected.Add(Substitute.For<DirectoryItemViewModel>());
            driveItemVM.ChildTreeItemVMs = expected;

            Assert.AreEqual(expected, driveItemVM.ChildTreeItemVMs);
        }

        [Test]
        public void ChildTreeItemVMs_OnPropertyChanged_FiredPropertyChanged()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            driveItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = new ObservableCollection<AExplorerTreeChildItemViewModel>();
            expected.Add(Substitute.For<DirectoryItemViewModel>());
            expected.Add(Substitute.For<DirectoryItemViewModel>());
            driveItemVM.ChildTreeItemVMs = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void ChildTreeItemVMs_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            driveItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            driveItemVM.ChildTreeItemVMs = driveItemVM.ChildTreeItemVMs;

            Assert.IsFalse(propertyChangedFired);
        }






        [Test]
        public void Configuration_SetGet_ReturnSetValue()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            var expected = Substitute.For<IConfiguration>();
            driveItemVM.Configuration = expected;

            Assert.AreEqual(expected, driveItemVM.Configuration);
        }


        [Test]
        public void DriveType_SetGet_ReturnSetValue()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            var expected = DriveType.Network;
            driveItemVM.DriveType = expected;

            Assert.AreEqual(expected, driveItemVM.DriveType);
        }


        [Test]
        public void ExplorerTreeVM_SetGet_ReturnSetValue()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            var expected = Substitute.For<ExplorerTreeViewModel>();
            driveItemVM.ExplorerTreeVM = expected;

            Assert.AreEqual(expected, driveItemVM.ExplorerTreeVM);
        }


        [Test]
        public void DriveItemModel_SetGet_ReturnSetValue()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            var expected = new FakeDriveItemModel();
            driveItemVM.DriveItemModel = expected;

            Assert.AreEqual(expected, driveItemVM.DriveItemModel);
        }






        [Test]
        public void FontVM_SetGet_ReturnSetValue()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            var expected = new FakeFontViewModel();
            driveItemVM.FontVM = expected;

            Assert.AreEqual(expected, driveItemVM.FontVM);
        }

        [Test]
        public void FontVM_OnPropertyChanged_FiredPropertyChanged()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            driveItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = new FakeFontViewModel();
            driveItemVM.FontVM = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void FontVM_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            driveItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            driveItemVM.FontVM = driveItemVM.FontVM;

            Assert.IsFalse(propertyChangedFired);
        }




        [Test]
        public void IsExpanded_SetGet_ReturnsSetValue()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            var expected = true;
            driveItemVM.IsExpanded = expected;

            Assert.AreEqual(expected, driveItemVM.IsExpanded);
        }

        [Test]
        public void IsExpanded_IsExpandedHasChanged_LoadChildDirectoryAndFileViewModelsWasCalled()
        {
            var mockExplorerTreeItemModelViewModelParser = Substitute.For<IExplorerTreeItemModelViewModelParser>();
            var driveItemVM = CreateDriveItemViewModel(null, mockExplorerTreeItemModelViewModelParser, null, null);

            driveItemVM.IsExpanded = true;

            mockExplorerTreeItemModelViewModelParser.Received().LoadChildDirectoryAndFileViewModels(Arg.Is(driveItemVM));
        }

        [Test]
        public void IsExpanded_SetSameValueAgain_LoadChildDirectoryAndFileViewModelsWasNotCalled()
        {
            var mockExplorerTreeItemModelViewModelParser = Substitute.For<IExplorerTreeItemModelViewModelParser>();
            var driveItemVM = CreateDriveItemViewModel(null, mockExplorerTreeItemModelViewModelParser, null, null);

            driveItemVM.IsExpanded = driveItemVM.IsExpanded;

            mockExplorerTreeItemModelViewModelParser.DidNotReceiveWithAnyArgs().LoadChildDirectoryAndFileViewModels(Arg.Is(driveItemVM));
        }

        [Test]
        public void IsExpanded_OnPropertyChanged_FiredPropertyChanged()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            driveItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            driveItemVM.IsExpanded = true;

            Assert.IsTrue(propertyChangedFired);
        }





        [Test]
        public void IsSelected_SetGet_ReturnsSetValue()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            var expected = true;
            driveItemVM.IsSelected = expected;

            Assert.AreEqual(expected, driveItemVM.IsSelected);
        }

        [Test]
        public void IsSelected_IsSelectedHasChanged_IsSelectedHasChangedWasCalled()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            driveItemVM.IsSelected = true;

            driveItemVM.ExplorerTreeVM.SelectedItemHandler.DriveSelectionHandler.Received().IsSelectedHasChanged(true, driveItemVM);
        }

        [Test]
        public void IsSelected_SetSameValueAgain_IsSelectedHasChangedWasNotCalled()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            driveItemVM.IsSelected = driveItemVM.IsSelected;

            driveItemVM.ExplorerTreeVM.SelectedItemHandler.DriveSelectionHandler.DidNotReceiveWithAnyArgs().IsSelectedHasChanged(default, default);
        }

        [Test]
        public void IsSelected_OnPropertyChanged_FiredPropertyChanged()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            driveItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            driveItemVM.IsSelected = true;

            Assert.IsTrue(propertyChangedFired);
        }






        [Test]
        public void IconVM_SetGet_ReturnSetValue()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            var expected = new FakeIconViewModel();
            driveItemVM.IconVM = expected;

            Assert.AreEqual(expected, driveItemVM.IconVM);
        }

        [Test]
        public void IconVM_OnPropertyChanged_FiredPropertyChanged()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            driveItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = new FakeIconViewModel();
            driveItemVM.IconVM = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void IconVM_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            driveItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            driveItemVM.IconVM = driveItemVM.IconVM;

            Assert.IsFalse(propertyChangedFired);
        }






        [Test]
        public void Name_SetGet_ReturnSetValue()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            var expected = "NEwTeschT";
            driveItemVM.Name = expected;

            Assert.AreEqual(expected, driveItemVM.Name);
        }

        [Test]
        public void Name_OnPropertyChanged_FiredPropertyChanged()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            driveItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = "NEwTeschT";
            driveItemVM.Name = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void Name_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            driveItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            driveItemVM.Name = driveItemVM.Name;

            Assert.IsFalse(propertyChangedFired);
        }




        [Test]
        public void Visibility_SetGet_ReturnSetValue()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);

            var expected = Visibility.Collapsed;
            driveItemVM.Visibility = expected;

            Assert.AreEqual(expected, driveItemVM.Visibility);
        }

        [Test]
        public void Visibility_OnPropertyChanged_FiredPropertyChanged()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            driveItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = Visibility.Collapsed;
            driveItemVM.Visibility = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void Visibility_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var driveItemVM = CreateDriveItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            driveItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            driveItemVM.Visibility = driveItemVM.Visibility;

            Assert.IsFalse(propertyChangedFired);
        }
    }
}


using ExplorerTree.API.Configuration;
using ExplorerTree.API.Configuration.ExplorerTreeItemConfiguration;
using ExplorerTree.API.Configuration.FontConfiguration;
using ExplorerTree.API.Configuration.IconConfiguration;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExplorerTreeUnitTest.PresentationLogic.ExplorerTreeItems.Tests
{
    [TestFixture]
    public class DirectoryItemViewModelTest
    {
        

        private static DirectoryItemViewModel CreateDirectoryItemViewModel(
            FakeDirectoryItemModel fakeDirectoryItemModel = null, 
            IExplorerTreeItemModelViewModelParser fakeExplorerTreeItemModelViewModelParser = null,
            IConfiguration fakeConfiguration = null, 
            IExplorerTreeItemViewModel fakeParentItem = null)
        {
            fakeDirectoryItemModel = fakeDirectoryItemModel ?? new FakeDirectoryItemModel();
            fakeExplorerTreeItemModelViewModelParser = fakeExplorerTreeItemModelViewModelParser ?? Substitute.For<IExplorerTreeItemModelViewModelParser>();
            fakeConfiguration = fakeConfiguration ?? CreateConfiguration();
            fakeParentItem = fakeParentItem ?? Substitute.For<IExplorerTreeItemViewModel>();
            return new DirectoryItemViewModel(fakeDirectoryItemModel, fakeExplorerTreeItemModelViewModelParser, fakeConfiguration, fakeParentItem);

        }

        private static ExplorerTreeViewModel CreateFakeExplorerTreeVMWithSelectedItemHandler(IConfiguration configuration)
        {
            IPresentationLogic presentationLogic = Substitute.For<IPresentationLogic>();
            var explorerTreeVM = Substitute.For<ExplorerTreeViewModel>(configuration, presentationLogic);
            var selectedItemHandler = Substitute.For<ISelectedExplorerTreeItemHandler>();
            var directorySelectionHandler = Substitute.For<AExplorerTreeItemSelectionHandler>();
            selectedItemHandler.DirectorySelectionHandler.Returns(directorySelectionHandler);
            selectedItemHandler.DirectorySelectionHandler.IsSelectedHasChanged(default, default).ReturnsForAnyArgs(true);
            explorerTreeVM.SelectedItemHandler.Returns(selectedItemHandler);
            return explorerTreeVM;
        }

        private static IConfiguration CreateConfiguration()
        {
            IConfiguration configuration = new Configuration();


            configuration.Drive = new DriveConfiguration();
            configuration.Drive.Font = Substitute.For<IExplorerTreeItemFontConfiguration>();
            configuration.Drive.Icon = Substitute.For<IExplorerTreeItemIconConfiguration>();

            configuration.Directory = new DirectoryConfiguration();
            configuration.Directory.Font = Substitute.For<IExplorerTreeItemFontConfiguration>();
            configuration.Directory.Icon = Substitute.For<IExplorerTreeItemIconConfiguration>();

            configuration.File = new FileConfiguration();
            configuration.File.Font = Substitute.For<IExplorerTreeItemFontConfiguration>();
            configuration.File.Icon = Substitute.For<IExplorerTreeItemIconConfiguration>();

            configuration.ExplorerTreeVM = CreateFakeExplorerTreeVMWithSelectedItemHandler(configuration);
            configuration.HiddenOverall = Substitute.For<HiddenOverallConfiguration>();

            return configuration;
        }

        [Test]
        public void DirectoryItemViewModel_DefaultInitialisation_IsInitialised()
        {
            var directoryItemVM = new DirectoryItemViewModel();

            Assert.AreEqual(null, directoryItemVM.Configuration, "Property: \"" + nameof(directoryItemVM.Configuration) + "\" was NOT null");
            Assert.NotNull(directoryItemVM.ChildTreeItemVMs, "Property: \"" + nameof(directoryItemVM.ChildTreeItemVMs) + "\" was null");
            Assert.AreEqual(null, directoryItemVM.DirectoryItemModel, "Property: \"" + nameof(directoryItemVM.DirectoryItemModel) + "\" was NOT null");
            Assert.AreEqual(null, directoryItemVM.ExplorerTreeItemModelViewModelParser, "Property: \"" + nameof(directoryItemVM.ExplorerTreeItemModelViewModelParser) + "\" was NOT null");
            Assert.AreEqual(null, directoryItemVM.ExplorerTreeVM, "Property: \"" + nameof(directoryItemVM.ExplorerTreeVM) + "\" was NOT null");
            Assert.AreEqual(null, directoryItemVM.FontVM, "Property: \"" + nameof(directoryItemVM.FontVM) + "\" was NOT null");
            Assert.AreEqual("init", directoryItemVM.FullName, "Property: \"" + nameof(directoryItemVM.FullName) + "\" was NOT initialised correctly.");
            Assert.AreEqual(false, directoryItemVM.IsExpanded, "Property: \"" + nameof(directoryItemVM.IsExpanded) + "\" was NOT initialised correctly.");
            Assert.AreEqual(false, directoryItemVM.IsSelected, "Property: \"" + nameof(directoryItemVM.IsSelected) + "\" was NOT initialised correctly.");
            Assert.AreEqual(false, directoryItemVM.IsHidden, "Property: \"" + nameof(directoryItemVM.IsHidden) + "\" was NOT initialised correctly.");
            Assert.AreEqual(null, directoryItemVM.IconVM, "Property: \"" + nameof(directoryItemVM.IconVM) + "\" was NOT null");
            Assert.AreEqual("init", directoryItemVM.Name, "Property: \"" + nameof(directoryItemVM.Name) + "\" was NOT initialised correctly.");
            Assert.AreEqual(null, directoryItemVM.ParentItem, "Property: \"" + nameof(directoryItemVM.ParentItem) + "\" was NOT null");
            Assert.AreEqual(Visibility.Visible, directoryItemVM.Visibility, "Property: \"" + nameof(directoryItemVM.Visibility) + "\" was NOT initialised correctly");
        }

        

        [Test]
        public void DirectoryItemViewModel_Initialisation_PropertyConfigurationIsInitialised()
        {
            var mockConfiguration = CreateConfiguration();
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, mockConfiguration, null);

            Assert.AreEqual(mockConfiguration, directoryItemVM.Configuration);
        }

        [Test]
        public void DriveItemViewModel_Initialisation_PropertyChildTreeItemVMsIsInitialised()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            Assert.NotNull(directoryItemVM.ChildTreeItemVMs);
        }

        [Test]
        public void DirectoryItemViewModel_Initialisation_PropertyDirectoryItemModelIsInitialised()
        {
            var mockDirectoryItemModel = new FakeDirectoryItemModel();
            var directoryItemVM = CreateDirectoryItemViewModel(mockDirectoryItemModel, null, null, null);

            Assert.AreEqual(mockDirectoryItemModel, directoryItemVM.DirectoryItemModel);
        }

        [Test]
        public void DirectoryItemViewModel_Initialisation_PropertyExplorerTreeItemModelViewModelParserIsInitialised()
        {
            var mockExplorerTreeItemModelViewModelParser = Substitute.For<IExplorerTreeItemModelViewModelParser>();
            var directoryItemVM = CreateDirectoryItemViewModel(null, mockExplorerTreeItemModelViewModelParser, null, null);

            Assert.AreEqual(mockExplorerTreeItemModelViewModelParser, directoryItemVM.ExplorerTreeItemModelViewModelParser);
        }

        [Test]
        public void DirectoryItemViewModel_Initialisation_PropertyExplorerTreeVMIsInitialised()
        {
            var stubConfiguration = CreateConfiguration();
            var mockExplorerTreeVM = CreateFakeExplorerTreeVMWithSelectedItemHandler(stubConfiguration);
            stubConfiguration.ExplorerTreeVM = mockExplorerTreeVM;
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, stubConfiguration, null);


            Assert.AreEqual(mockExplorerTreeVM, directoryItemVM.ExplorerTreeVM);
        }

        [Test]
        public void DirectoryItemViewModel_Initialisation_PropertyFontVMIsNotNull()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            Assert.NotNull(directoryItemVM.FontVM);
        }

        [Test]
        public void DirectoryItemViewModel_Initialisation_PropertyFullNameIsInitialised()
        {
            var mockDirectoryItemModel = new FakeDirectoryItemModel();
            mockDirectoryItemModel.FullName = "TestTestTest";
            var directoryItemVM = CreateDirectoryItemViewModel(mockDirectoryItemModel, null, null, null);

            Assert.AreEqual(mockDirectoryItemModel.FullName, directoryItemVM.FullName);
        }

        [Test]
        public void DirectoryItemViewModel_Initialisation_PropertyIsExpandedIsInitialised()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            Assert.IsFalse(directoryItemVM.IsExpanded);
        }

        [Test]
        public void DirectoryItemViewModel_Initialisation_PropertyIsSelectedIsInitialised()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            Assert.IsFalse(directoryItemVM.IsSelected);
        }

        [Test]
        public void DirectoryItemViewModel_Initialisation_PropertyIsHiddenIsInitialised()
        {
            var mockDirectoryItemModel = new FakeDirectoryItemModel();
            mockDirectoryItemModel.IsHidden = true;
            var directoryItemVM = CreateDirectoryItemViewModel(mockDirectoryItemModel, null, null, null);

            Assert.AreEqual(mockDirectoryItemModel.IsHidden, directoryItemVM.IsHidden);
        }

        [Test]
        public void DirectoryItemViewModel_Initialisation_PropertyIconVMIsNotNull()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            Assert.NotNull(directoryItemVM.IconVM);
        }

        [Test]
        public void DirectoryItemViewModel_Initialisation_PropertyNameIsInitialised()
        {
            var mockDirectoryItemModel = new FakeDirectoryItemModel();
            mockDirectoryItemModel.Name = "TestTestTest";
            var directoryItemVM = CreateDirectoryItemViewModel(mockDirectoryItemModel, null, null, null);

            Assert.AreEqual(mockDirectoryItemModel.Name, directoryItemVM.Name);
        }

        [Test]
        public void DirectoryItemViewModel_Initialisation_PropertyParentItemIsInitialised()
        {
            var mockParantItem = Substitute.For<IExplorerTreeItemViewModel>();
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, mockParantItem);

            Assert.AreEqual(mockParantItem, directoryItemVM.ParentItem);
        }

        [Test]
        public void DirectoryItemViewModel_Initialisation_DummyTreeViewItemAddedToBeExpandable()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            Assert.AreEqual(1, directoryItemVM.ChildTreeItemVMs.Count);
            Assert.AreEqual("DummyChild", directoryItemVM.ChildTreeItemVMs.First().Name);
        }

        [Test]
        public void DirectoryItemViewModel_Initialisation_VisibilityWasSetAccordingToConfigurationVisible()
        {
            var stubDirectoryItemModel = new FakeDirectoryItemModel();
            stubDirectoryItemModel.IsHidden = true;
            var stubConfiguration = CreateConfiguration();
            stubConfiguration.HiddenOverall.ShowHiddenElements.Returns(true);

            var directoryItemVM = CreateDirectoryItemViewModel(stubDirectoryItemModel, null, stubConfiguration, null);

            Assert.AreEqual(Visibility.Visible, directoryItemVM.Visibility);
        }

        [Test]
        public void DirectoryItemViewModel_Initialisation_VisibilityWasSetAccordingToConfigurationCollapsed()
        {
            var stubDirectoryItemModel = new FakeDirectoryItemModel();
            stubDirectoryItemModel.IsHidden = true;
            var stubConfiguration = CreateConfiguration();
            stubConfiguration.HiddenOverall.ShowHiddenElements.Returns(false);

            var directoryItemVM = CreateDirectoryItemViewModel(stubDirectoryItemModel, null, stubConfiguration, null);

            Assert.AreEqual(Visibility.Collapsed, directoryItemVM.Visibility);
        }





        [Test]
        public void SetVisibilityAccordingToConfiguration_IsHiddenIsTrueAndShowHiddenElementsIsTrue_VisibilitySetToVisible()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);
            var fakeHiddenOverallConfiguration = Substitute.For<HiddenOverallConfiguration>();
            directoryItemVM.IsHidden = true;
            fakeHiddenOverallConfiguration.ShowHiddenElements = true;

            directoryItemVM.SetVisibilityAccordingToConfigruation(fakeHiddenOverallConfiguration);

            Assert.AreEqual(Visibility.Visible, directoryItemVM.Visibility);
        }

        [Test]
        public void SetVisibilityAccordingToConfiguration_IsHiddenIsTrueAndShowHiddenElementsIsFalse_VisibilitySetToCollapsed()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);
            var fakeHiddenOverallConfiguration = Substitute.For<HiddenOverallConfiguration>();
            directoryItemVM.IsHidden = true;
            fakeHiddenOverallConfiguration.ShowHiddenElements = false;

            directoryItemVM.SetVisibilityAccordingToConfigruation(fakeHiddenOverallConfiguration);

            Assert.AreEqual(Visibility.Collapsed, directoryItemVM.Visibility);
        }

        [Test]
        public void SetVisibilityAccordingToConfiguration_IsHiddenIsFalse_VisibilitySetToVisibleEvenIfShowHiddenElementsIsTrue()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);
            var fakeHiddenOverallConfiguration = Substitute.For<HiddenOverallConfiguration>();
            directoryItemVM.IsHidden = false; 
            fakeHiddenOverallConfiguration.ShowHiddenElements = true;

            directoryItemVM.SetVisibilityAccordingToConfigruation(fakeHiddenOverallConfiguration);

            Assert.AreEqual(Visibility.Visible, directoryItemVM.Visibility);
        }






        [Test]
        public void ChildTreeItemVMs_SetGet_ReturnSetValue()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            var expected = new ObservableCollection<AExplorerTreeChildItemViewModel>();
            expected.Add(Substitute.For<DirectoryItemViewModel>());
            expected.Add(Substitute.For<DirectoryItemViewModel>());
            directoryItemVM.ChildTreeItemVMs = expected;

            Assert.AreEqual(expected, directoryItemVM.ChildTreeItemVMs);
        }

        [Test]
        public void ChildTreeItemVMs_OnPropertyChanged_FiredPropertyChanged()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            directoryItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = new ObservableCollection<AExplorerTreeChildItemViewModel>();
            expected.Add(Substitute.For<DirectoryItemViewModel>());
            expected.Add(Substitute.For<DirectoryItemViewModel>());
            directoryItemVM.ChildTreeItemVMs = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void ChildTreeItemVMs_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            directoryItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };
           
            directoryItemVM.ChildTreeItemVMs = directoryItemVM.ChildTreeItemVMs;

            Assert.IsFalse(propertyChangedFired);
        }





        [Test]
        public void Configuration_SetGet_ReturnSetValue()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            var expected = Substitute.For<IConfiguration>();
            directoryItemVM.Configuration = expected;

            Assert.AreEqual(expected, directoryItemVM.Configuration);
        }


        [Test]
        public void ExplorerTreeVM_SetGet_ReturnSetValue()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            var expected = Substitute.For<ExplorerTreeViewModel>();
            directoryItemVM.ExplorerTreeVM = expected;

            Assert.AreEqual(expected, directoryItemVM.ExplorerTreeVM);
        }




        [Test]
        public void FontVM_SetGet_ReturnSetValue()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            var expected = new FakeFontViewModel();
            directoryItemVM.FontVM = expected;

            Assert.AreEqual(expected, directoryItemVM.FontVM);
        }

        [Test]
        public void FontVM_OnPropertyChanged_FiredPropertyChanged()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            directoryItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = new FakeFontViewModel();
            directoryItemVM.FontVM = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void FontVM_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            directoryItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            directoryItemVM.FontVM = directoryItemVM.FontVM;

            Assert.IsFalse(propertyChangedFired);
        }






        [Test]
        public void FullName_SetGet_ReturnSetValue()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            var expected = "newTescht";
            directoryItemVM.FullName = expected;

            Assert.AreEqual(expected, directoryItemVM.FullName);
        }

        [Test]
        public void FullName_OnPropertyChanged_FiredPropertyChanged()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            directoryItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = "newTescht";
            directoryItemVM.FullName = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void FullName_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            directoryItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            directoryItemVM.FullName = directoryItemVM.FullName;

            Assert.IsFalse(propertyChangedFired);
        }








        [Test]
        public void IsExpanded_SetGet_ReturnsSetValue()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            var expected = true;
            directoryItemVM.IsExpanded = expected;
          
            Assert.AreEqual(expected, directoryItemVM.IsExpanded);
        }

        [Test]
        public void IsExpanded_IsExpandedHasChanged_LoadChildDirectoryAndFileViewModelsWasCalled()
        {
            var mockExplorerTreeItemModelViewModelParser = Substitute.For<IExplorerTreeItemModelViewModelParser>();
            var directoryItemVM = CreateDirectoryItemViewModel(null, mockExplorerTreeItemModelViewModelParser, null, null);

            directoryItemVM.IsExpanded = true;

            mockExplorerTreeItemModelViewModelParser.Received().LoadChildDirectoryAndFileViewModels(Arg.Is(directoryItemVM));
        }

        [Test]
        public void IsExpanded_SetSameValueAgain_LoadChildDirectoryAndFileViewModelsWasNotCalled()
        {
            var mockExplorerTreeItemModelViewModelParser = Substitute.For<IExplorerTreeItemModelViewModelParser>();
            var directoryItemVM = CreateDirectoryItemViewModel(null, mockExplorerTreeItemModelViewModelParser, null, null);
           
            directoryItemVM.IsExpanded = directoryItemVM.IsExpanded;

            mockExplorerTreeItemModelViewModelParser.DidNotReceiveWithAnyArgs().LoadChildDirectoryAndFileViewModels(Arg.Is(directoryItemVM));
        }

        [Test]
        public void IsExpanded_OnPropertyChanged_FiredPropertyChanged()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            directoryItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            directoryItemVM.IsExpanded = true;

            Assert.IsTrue(propertyChangedFired);
        }




        [Test]
        public void IsSelected_SetGet_ReturnsSetValue()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            var expected = true;
            directoryItemVM.IsSelected = expected;

            Assert.AreEqual(expected, directoryItemVM.IsSelected);
        }

        [Test]
        public void IsSelected_IsSelectedHasChanged_IsSelectedHasChangedWasCalled()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            directoryItemVM.IsSelected = true;

            directoryItemVM.ExplorerTreeVM.SelectedItemHandler.DirectorySelectionHandler.Received().IsSelectedHasChanged(true, directoryItemVM);
        }

        [Test]
        public void IsSelected_SetSameValueAgain_IsSelectedHasChangedWasNotCalled()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            directoryItemVM.IsSelected = directoryItemVM.IsSelected;

            directoryItemVM.ExplorerTreeVM.SelectedItemHandler.DirectorySelectionHandler.DidNotReceiveWithAnyArgs().IsSelectedHasChanged(default, default);
        }

        [Test]
        public void IsSelected_OnPropertyChanged_FiredPropertyChanged()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            bool propertyChangedFired = false;
            directoryItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            directoryItemVM.IsSelected = true;

            Assert.IsTrue(propertyChangedFired);
        }








        [Test]
        public void IsHidden_SetGet_ReturnSetValue()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            var expected = true;
            directoryItemVM.IsHidden = expected;

            Assert.AreEqual(expected, directoryItemVM.IsHidden);
        }

        [Test]
        public void IsHidden_OnPropertyChanged_FiredPropertyChanged()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            directoryItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = true;
            directoryItemVM.IsHidden = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void IsHidden_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            directoryItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };


            directoryItemVM.IsHidden = directoryItemVM.IsHidden;

            Assert.IsFalse(propertyChangedFired);
        }





        [Test]
        public void IconVM_SetGet_ReturnSetValue()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            var expected = new FakeIconViewModel();
            directoryItemVM.IconVM = expected;

            Assert.AreEqual(expected, directoryItemVM.IconVM);
        }

        [Test]
        public void IconVM_OnPropertyChanged_FiredPropertyChanged()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            directoryItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = new FakeIconViewModel();
            directoryItemVM.IconVM = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void IconVM_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            directoryItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            directoryItemVM.IconVM = directoryItemVM.IconVM;

            Assert.IsFalse(propertyChangedFired);
        }






        [Test]
        public void Name_SetGet_ReturnSetValue()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            var expected = "NEwTeschT";
            directoryItemVM.Name = expected;

            Assert.AreEqual(expected, directoryItemVM.Name);
        }

        [Test]
        public void Name_OnPropertyChanged_FiredPropertyChanged()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            directoryItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = "NEwTeschT";
            directoryItemVM.Name = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void Name_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            directoryItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            directoryItemVM.Name = directoryItemVM.Name;

            Assert.IsFalse(propertyChangedFired);
        }








        [Test]
        public void ParentItem_SetGet_ReturnSetValue()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            var expected = Substitute.For<IExplorerTreeItemViewModel>();
            directoryItemVM.ParentItem = expected;

            Assert.AreEqual(expected, directoryItemVM.ParentItem);
        }







        [Test]
        public void Visibility_SetGet_ReturnSetValue()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);

            var expected = Visibility.Collapsed;
            directoryItemVM.Visibility = expected;

            Assert.AreEqual(expected, directoryItemVM.Visibility);
        }

        [Test]
        public void Visibility_OnPropertyChanged_FiredPropertyChanged()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            directoryItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = Visibility.Collapsed;
            directoryItemVM.Visibility = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void Visibility_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var directoryItemVM = CreateDirectoryItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            directoryItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            directoryItemVM.Visibility = directoryItemVM.Visibility;

            Assert.IsFalse(propertyChangedFired);
        }

    }
}


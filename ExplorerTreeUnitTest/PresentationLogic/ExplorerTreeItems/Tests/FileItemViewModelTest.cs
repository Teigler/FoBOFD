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
    public class FileItemViewModelTest
    {

        private static FileItemViewModel CreateFileItemViewModel(
         FakeFileItemModel fakeFileItemModel = null,
         IExplorerTreeItemModelViewModelParser fakeExplorerTreeItemModelViewModelParser = null,
         IConfiguration fakeConfiguration = null,
         IExplorerTreeItemViewModel fakeParentItem = null)
        {
            fakeFileItemModel = fakeFileItemModel ?? new FakeFileItemModel();
            fakeExplorerTreeItemModelViewModelParser = fakeExplorerTreeItemModelViewModelParser ?? Substitute.For<IExplorerTreeItemModelViewModelParser>();
            fakeConfiguration = fakeConfiguration ?? CreateConfiguration();
            fakeParentItem = fakeParentItem ?? Substitute.For<IExplorerTreeItemViewModel>();
            return new FileItemViewModel(fakeFileItemModel, fakeExplorerTreeItemModelViewModelParser, fakeConfiguration, fakeParentItem);

        }

        private static ExplorerTreeViewModel CreateFakeExplorerTreeVMWithSelectedItemHandler(IConfiguration configuration)
        {
            IPresentationLogic presentationLogic = Substitute.For<IPresentationLogic>();
            var explorerTreeVM = Substitute.For<ExplorerTreeViewModel>(configuration, presentationLogic);
            var selectedItemHandler = Substitute.For<ISelectedExplorerTreeItemHandler>();
            var fileSelectionHandler = Substitute.For<AExplorerTreeItemSelectionHandler>();
            selectedItemHandler.FileSelectionHandler.Returns(fileSelectionHandler);
            selectedItemHandler.FileSelectionHandler.IsSelectedHasChanged(default, default).ReturnsForAnyArgs(true);
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
        public void FileItemViewModel_DefaultInitialisation_IsInitialised()
        {
            var fileItemVM = new FileItemViewModel();

            Assert.AreEqual(null, fileItemVM.Configuration, "Property: \"" + nameof(fileItemVM.Configuration) + "\" was NOT null");
            Assert.NotNull(fileItemVM.ChildTreeItemVMs, "Property: \"" + nameof(fileItemVM.ChildTreeItemVMs) + "\" was null");
            Assert.AreEqual(null, fileItemVM.ExplorerTreeItemModelViewModelParser, "Property: \"" + nameof(fileItemVM.ExplorerTreeItemModelViewModelParser) + "\" was NOT null");
            Assert.AreEqual(null, fileItemVM.ExplorerTreeVM, "Property: \"" + nameof(fileItemVM.ExplorerTreeVM) + "\" was NOT null");
            Assert.AreEqual(null, fileItemVM.FileItemModel, "Property: \"" + nameof(fileItemVM.FileItemModel) + "\" was NOT null");
            Assert.AreEqual(null, fileItemVM.FontVM, "Property: \"" + nameof(fileItemVM.FontVM) + "\" was NOT null");
            Assert.AreEqual("init", fileItemVM.FullName, "Property: \"" + nameof(fileItemVM.FullName) + "\" was NOT initialised correctly.");
            Assert.AreEqual(false, fileItemVM.IsExpanded, "Property: \"" + nameof(fileItemVM.IsExpanded) + "\" was NOT initialised correctly.");
            Assert.AreEqual(false, fileItemVM.IsSelected, "Property: \"" + nameof(fileItemVM.IsSelected) + "\" was NOT initialised correctly.");
            Assert.AreEqual(false, fileItemVM.IsHidden, "Property: \"" + nameof(fileItemVM.IsHidden) + "\" was NOT initialised correctly.");
            Assert.AreEqual(null, fileItemVM.IconVM, "Property: \"" + nameof(fileItemVM.IconVM) + "\" was NOT null");
            Assert.AreEqual("init", fileItemVM.Name, "Property: \"" + nameof(fileItemVM.Name) + "\" was NOT initialised correctly.");
            Assert.AreEqual(null, fileItemVM.ParentItem, "Property: \"" + nameof(fileItemVM.ParentItem) + "\" was NOT null");
            Assert.AreEqual(Visibility.Visible, fileItemVM.Visibility, "Property: \"" + nameof(fileItemVM.Visibility) + "\" was NOT initialised correctly");
        }

        [Test]
        public void FileItemViewModel_Initialisation_PropertyConfigurationIsInitialised()
        {
            var mockConfiguration = CreateConfiguration();
            var fileItemVM = CreateFileItemViewModel(null, null, mockConfiguration, null);

            Assert.AreEqual(mockConfiguration, fileItemVM.Configuration);
        }

        [Test]
        public void DriveItemViewModel_Initialisation_PropertyChildTreeItemVMsIsInitialised()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            Assert.NotNull(fileItemVM.ChildTreeItemVMs);
        }

        [Test]
        public void FileyItemViewModel_Initialisation_PropertyExplorerTreeItemModelViewModelParserIsInitialised()
        {
            var mockExplorerTreeItemModelViewModelParser = Substitute.For<IExplorerTreeItemModelViewModelParser>();
            var fileItemVM = CreateFileItemViewModel(null, mockExplorerTreeItemModelViewModelParser, null, null);

            Assert.AreEqual(mockExplorerTreeItemModelViewModelParser, fileItemVM.ExplorerTreeItemModelViewModelParser);
        }

        [Test]
        public void FileItemViewModel_Initialisation_PropertyExplorerTreeVMIsInitialised()
        {
            var stubConfiguration = CreateConfiguration();
            var mockExplorerTreeVM = CreateFakeExplorerTreeVMWithSelectedItemHandler(stubConfiguration);
            stubConfiguration.ExplorerTreeVM = mockExplorerTreeVM;
            var fileItemVM = CreateFileItemViewModel(null, null, stubConfiguration, null);


            Assert.AreEqual(mockExplorerTreeVM, fileItemVM.ExplorerTreeVM);
        }

        [Test]
        public void FileItemViewModel_Initialisation_PropertyFileItemModelIsInitialised()
        {
            var mockFileItemModel = new FakeFileItemModel();
            var fileItemVM = CreateFileItemViewModel(mockFileItemModel, null, null, null);

            Assert.AreEqual(mockFileItemModel, fileItemVM.FileItemModel);
        }

        [Test]
        public void FileItemViewModel_Initialisation_PropertyFontVMIsNotNull()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            Assert.NotNull(fileItemVM.FontVM);
        }

        [Test]
        public void FileItemViewModel_Initialisation_PropertyFullNameIsInitialised()
        {
            var mockFileItemModel = new FakeFileItemModel();
            mockFileItemModel.FullName = "TestTestTest";
            var fileItemVM = CreateFileItemViewModel(mockFileItemModel, null, null, null);

            Assert.AreEqual(mockFileItemModel.FullName, fileItemVM.FullName);
        }

        [Test]
        public void FileItemViewModel_Initialisation_PropertyIsExpandedIsInitialised()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            Assert.IsFalse(fileItemVM.IsExpanded);
        }

        [Test]
        public void FileItemViewModel_Initialisation_PropertyIsSelectedIsInitialised()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            Assert.IsFalse(fileItemVM.IsSelected);
        }

        [Test]
        public void FileItemViewModel_Initialisation_PropertyIsHiddenIsInitialised()
        {
            var mockFileItemModel = new FakeFileItemModel();
            mockFileItemModel.IsHidden = true;
            var fileItemVM = CreateFileItemViewModel(mockFileItemModel, null, null, null);

            Assert.AreEqual(mockFileItemModel.IsHidden, fileItemVM.IsHidden);
        }

        [Test]
        public void FileItemViewModel_Initialisation_PropertyIconVMIsNotNull()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            Assert.NotNull(fileItemVM.IconVM);
        }

        [Test]
        public void FileItemViewModel_Initialisation_PropertyNameIsInitialised()
        {
            var mockFileItemModel = new FakeFileItemModel();
            mockFileItemModel.Name = "TestTestTest";
            var fileItemVM = CreateFileItemViewModel(mockFileItemModel, null, null, null);

            Assert.AreEqual(mockFileItemModel.Name, fileItemVM.Name);
        }

        [Test]
        public void FileItemViewModel_Initialisation_PropertyParentItemIsInitialised()
        {
            var mockParantItem = Substitute.For<IExplorerTreeItemViewModel>();
            var fileItemVM = CreateFileItemViewModel(null, null, null, mockParantItem);

            Assert.AreEqual(mockParantItem, fileItemVM.ParentItem);
        }

        [Test]
        public void FileItemViewModel_Initialisation_VisibilityWasSetAccordingToConfigurationVisible()
        {
            var stubFileItemModel = new FakeFileItemModel();
            stubFileItemModel.IsHidden = true;
            var stubConfiguration = CreateConfiguration();
            stubConfiguration.HiddenOverall.ShowHiddenElements.Returns(true);

            var fileItemVM = CreateFileItemViewModel(stubFileItemModel, null, stubConfiguration, null);

            Assert.AreEqual(Visibility.Visible, fileItemVM.Visibility);
        }

        [Test]
        public void FileItemViewModel_Initialisation_VisibilityWasSetAccordingToConfigurationCollapsed()
        {
            var stubFileItemModel = new FakeFileItemModel();
            stubFileItemModel.IsHidden = true;
            var stubConfiguration = CreateConfiguration();
            stubConfiguration.HiddenOverall.ShowHiddenElements.Returns(false);

            var fileItemVM = CreateFileItemViewModel(stubFileItemModel, null, stubConfiguration, null);

            Assert.AreEqual(Visibility.Collapsed, fileItemVM.Visibility);
        }





        [Test]
        public void SetVisibilityAccordingToConfiguration_IsHiddenIsTrueAndShowHiddenElementsIsTrue_VisibilitySetToVisible()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            var fakeHiddenOverallConfiguration = Substitute.For<HiddenOverallConfiguration>();
            fileItemVM.IsHidden = true;
            fakeHiddenOverallConfiguration.ShowHiddenElements = true;

            fileItemVM.SetVisibilityAccordingToConfigruation(fakeHiddenOverallConfiguration);

            Assert.AreEqual(Visibility.Visible, fileItemVM.Visibility);
        }

        [Test]
        public void SetVisibilityAccordingToConfiguration_IsHiddenIsTrueAndShowHiddenElementsIsFalse_VisibilitySetToCollapsed()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            var fakeHiddenOverallConfiguration = Substitute.For<HiddenOverallConfiguration>();
            fileItemVM.IsHidden = true;
            fakeHiddenOverallConfiguration.ShowHiddenElements = false;

            fileItemVM.SetVisibilityAccordingToConfigruation(fakeHiddenOverallConfiguration);

            Assert.AreEqual(Visibility.Collapsed, fileItemVM.Visibility);
        }

        [Test]
        public void SetVisibilityAccordingToConfiguration_IsHiddenIsFalse_VisibilitySetToVisibleEvenIfShowHiddenElementsIsTrue()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            var fakeHiddenOverallConfiguration = Substitute.For<HiddenOverallConfiguration>();
            fileItemVM.IsHidden = false;
            fakeHiddenOverallConfiguration.ShowHiddenElements = true;

            fileItemVM.SetVisibilityAccordingToConfigruation(fakeHiddenOverallConfiguration);

            Assert.AreEqual(Visibility.Visible, fileItemVM.Visibility);
        }





        [Test]
        public void ChildTreeItemVMs_SetGet_ReturnSetValue()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            var expected = new ObservableCollection<AExplorerTreeChildItemViewModel>();
            expected.Add(Substitute.For<DirectoryItemViewModel>());
            expected.Add(Substitute.For<DirectoryItemViewModel>());
            fileItemVM.ChildTreeItemVMs = expected;

            Assert.AreEqual(expected, fileItemVM.ChildTreeItemVMs);
        }

        [Test]
        public void ChildTreeItemVMs_OnPropertyChanged_FiredPropertyChanged()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            fileItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = new ObservableCollection<AExplorerTreeChildItemViewModel>();
            expected.Add(Substitute.For<DirectoryItemViewModel>());
            expected.Add(Substitute.For<DirectoryItemViewModel>());
            fileItemVM.ChildTreeItemVMs = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void ChildTreeItemVMs_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            fileItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            fileItemVM.ChildTreeItemVMs = fileItemVM.ChildTreeItemVMs;

            Assert.IsFalse(propertyChangedFired);
        }




        [Test]
        public void Configuration_SetGet_ReturnSetValue()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            var expected = Substitute.For<IConfiguration>();
            fileItemVM.Configuration = expected;

            Assert.AreEqual(expected, fileItemVM.Configuration);
        }


        [Test]
        public void ExplorerTreeVM_SetGet_ReturnSetValue()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            var expected = Substitute.For<ExplorerTreeViewModel>();
            fileItemVM.ExplorerTreeVM = expected;

            Assert.AreEqual(expected, fileItemVM.ExplorerTreeVM);
        }





        [Test]
        public void FontVM_SetGet_ReturnSetValue()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            var expected = new FakeFontViewModel();
            fileItemVM.FontVM = expected;

            Assert.AreEqual(expected, fileItemVM.FontVM);
        }

        [Test]
        public void FontVM_OnPropertyChanged_FiredPropertyChanged()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            fileItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = new FakeFontViewModel();
            fileItemVM.FontVM = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void FontVM_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            fileItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            fileItemVM.FontVM = fileItemVM.FontVM;

            Assert.IsFalse(propertyChangedFired);
        }




        [Test]
        public void FullName_SetGet_ReturnSetValue()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            var expected = "newTescht";
            fileItemVM.FullName = expected;

            Assert.AreEqual(expected, fileItemVM.FullName);
        }

        [Test]
        public void FullName_OnPropertyChanged_FiredPropertyChanged()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            fileItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = "newTescht";
            fileItemVM.FullName = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void FullName_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            fileItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            fileItemVM.FullName = fileItemVM.FullName;

            Assert.IsFalse(propertyChangedFired);
        }





        [Test]
        public void IsExpanded_SetGet_ReturnsSetValue()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            var expected = true;
            fileItemVM.IsExpanded = expected;

            Assert.AreEqual(expected, fileItemVM.IsExpanded);
        }

        [Test]
        public void IsExpanded_OnPropertyChanged_FiredPropertyChanged()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            fileItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            fileItemVM.IsExpanded = true;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void IsExpanded_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            fileItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            fileItemVM.IsExpanded = fileItemVM.IsExpanded;

            Assert.IsFalse(propertyChangedFired);
        }





        [Test]
        public void IsSelected_SetGet_ReturnsSetValue()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            var expected = true;
            fileItemVM.IsSelected = expected;

            Assert.AreEqual(expected, fileItemVM.IsSelected);
        }

        [Test]
        public void IsSelected_IsSelectedHasChanged_IsSelectedHasChangedWasCalled()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            fileItemVM.IsSelected = true;

            fileItemVM.ExplorerTreeVM.SelectedItemHandler.FileSelectionHandler.Received().IsSelectedHasChanged(true, fileItemVM);
        }

        [Test]
        public void IsSelected_SetSameValueAgain_IsSelectedHasChangedWasNotCalled()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            fileItemVM.IsSelected = fileItemVM.IsSelected;

            fileItemVM.ExplorerTreeVM.SelectedItemHandler.FileSelectionHandler.DidNotReceiveWithAnyArgs().IsSelectedHasChanged(default, default);
        }

        [Test]
        public void IsSelected_OnPropertyChanged_FiredPropertyChanged()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            bool propertyChangedFired = false;
            fileItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            fileItemVM.IsSelected = true;

            Assert.IsTrue(propertyChangedFired);
        }





        [Test]
        public void IsHidden_SetGet_ReturnSetValue()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            var expected = true;
            fileItemVM.IsHidden = expected;

            Assert.AreEqual(expected, fileItemVM.IsHidden);
        }

        [Test]
        public void IsHidden_OnPropertyChanged_FiredPropertyChanged()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            fileItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = true;
            fileItemVM.IsHidden = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void IsHidden_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            fileItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            fileItemVM.IsHidden = fileItemVM.IsHidden;

            Assert.IsFalse(propertyChangedFired);
        }








        [Test]
        public void IconVM_SetGet_ReturnSetValue()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            var expected = new FakeIconViewModel();
            fileItemVM.IconVM = expected;

            Assert.AreEqual(expected, fileItemVM.IconVM);
        }

        [Test]
        public void IconVM_OnPropertyChanged_FiredPropertyChanged()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            fileItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = new FakeIconViewModel();
            fileItemVM.IconVM = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void IconVM_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            fileItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            fileItemVM.IconVM = fileItemVM.IconVM;

            Assert.IsFalse(propertyChangedFired);
        }






        [Test]
        public void Name_SetGet_ReturnSetValue()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            var expected = "NEwTeschT";
            fileItemVM.Name = expected;

            Assert.AreEqual(expected, fileItemVM.Name);
        }

        [Test]
        public void Name_OnPropertyChanged_FiredPropertyChanged()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            fileItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = "NEwTeschT";
            fileItemVM.Name = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void Name_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            fileItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            fileItemVM.Name = fileItemVM.Name;

            Assert.IsFalse(propertyChangedFired);
        }



        [Test]
        public void ParentItem_SetGet_ReturnSetValue()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            var expected = Substitute.For<IExplorerTreeItemViewModel>();
            fileItemVM.ParentItem = expected;

            Assert.AreEqual(expected, fileItemVM.ParentItem);
        }




        [Test]
        public void Visibility_SetGet_ReturnSetValue()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);

            var expected = Visibility.Collapsed;
            fileItemVM.Visibility = expected;

            Assert.AreEqual(expected, fileItemVM.Visibility);
        }

        [Test]
        public void Visibility_OnPropertyChanged_FiredPropertyChanged()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            fileItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = Visibility.Collapsed;
            fileItemVM.Visibility = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void Visibility_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var fileItemVM = CreateFileItemViewModel(null, null, null, null);
            bool propertyChangedFired = false;
            fileItemVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };


            fileItemVM.Visibility = fileItemVM.Visibility;

            Assert.IsFalse(propertyChangedFired);
        }
    }
}

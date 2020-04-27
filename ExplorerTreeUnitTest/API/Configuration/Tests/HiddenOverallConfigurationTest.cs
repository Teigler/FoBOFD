using ExplorerTree.API.Configuration;
using ExplorerTree.PresentationLogic.API;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using ExplorerTreeUnitTest.PresentationLogic.ExplorerTreeItems.Fakes;
using ExplorerTreeUnitTest.PresentationLogic.Fakes;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeUnitTest.API.Configuration.Tests
{
    [TestFixture]
    public class HiddenOverallConfigurationTest
    {
        private static HiddenOverallConfiguration CreateDefaultHiddenOverallConfiguration()
        {
            return new HiddenOverallConfiguration();
        }

        private HiddenOverallConfiguration CreateHiddenOverallConfiguration(FakeExplorerTreeViewModel fakeExplorerTreeVM = null)
        {
            fakeExplorerTreeVM = fakeExplorerTreeVM == null ? CreateFakeExplorerTreeVM() : fakeExplorerTreeVM;
            return new HiddenOverallConfiguration(fakeExplorerTreeVM);
        }

        private static FakeExplorerTreeViewModel CreateFakeExplorerTreeVM()
        {
            IConfiguration configuration = Substitute.For<IConfiguration>();
            IPresentationLogic fakePresentationLogic = Substitute.For<IPresentationLogic>();
            return new FakeExplorerTreeViewModel(configuration, fakePresentationLogic);
        }




        [Test]
        public void HiddenOverallConfiguration_DefaultInitialisation_PropertyExplorerTreeVmIsNull()
        {
            HiddenOverallConfiguration hiddenOverallConfiguration = CreateDefaultHiddenOverallConfiguration();

            Assert.AreEqual(null, hiddenOverallConfiguration.ExplorerTreeVM);
        }

        [Test]
        public void HiddenOverallConfiguration_DefaultInitialisation_PropertyShowHiddenElementsIsInitialised()
        {
            HiddenOverallConfiguration hiddenOverallConfiguration = CreateDefaultHiddenOverallConfiguration();

            Assert.IsFalse(hiddenOverallConfiguration.ShowHiddenElements);
        }



        [Test]
        public void HiddenOverallConfiguration_Initialisation_PropertyExplorerTreeVmIsInitialised()
        {
            FakeExplorerTreeViewModel fakeExplorerTreeVM = CreateFakeExplorerTreeVM();
            HiddenOverallConfiguration hiddenOverallConfiguration = CreateHiddenOverallConfiguration(fakeExplorerTreeVM);

            Assert.AreEqual(fakeExplorerTreeVM, hiddenOverallConfiguration.ExplorerTreeVM);
        }

        [Test]
        public void HiddenOverallConfiguration_Initialisation_PropertyShowHiddenElementsIsInitialised()
        {
            HiddenOverallConfiguration hiddenOverallConfiguration = CreateHiddenOverallConfiguration();

            Assert.AreEqual(false, hiddenOverallConfiguration.ShowHiddenElements);
        }


        [Test]
        public void ExplorerTreeVM_SetGet_ReturnSetValue()
        {
            FakeExplorerTreeViewModel fakeExplorerTreeViewModel = CreateFakeExplorerTreeVM();
            HiddenOverallConfiguration hiddenOverallConfiguration = new HiddenOverallConfiguration();

            hiddenOverallConfiguration.ExplorerTreeVM = fakeExplorerTreeViewModel;

            Assert.AreEqual(fakeExplorerTreeViewModel, hiddenOverallConfiguration.ExplorerTreeVM);
        }



        [Test]
        public void ShowHiddenElements_SetGet_ReturnSetValue()
        {
            HiddenOverallConfiguration hiddenOverallConfiguration = CreateHiddenOverallConfiguration();

            hiddenOverallConfiguration.ShowHiddenElements = true;

            Assert.AreEqual(true, hiddenOverallConfiguration.ShowHiddenElements);
        }


        [Test]
        public void ShowHiddenElements_UpdateCurrentlyLoadedDirectoriesAndFilesOfTheExplorerTree_DirectoriesAndFilesAreUpdated()
        {
            HiddenOverallConfiguration hiddenOverallConfiguration = CreateHiddenOverallConfiguration();
            var fakeDirectories = (hiddenOverallConfiguration.ExplorerTreeVM as FakeExplorerTreeViewModel).GetAllFakeDirectories();
            var fakeFiles = (hiddenOverallConfiguration.ExplorerTreeVM as FakeExplorerTreeViewModel).GetAllFakeFiles();
            List<AExplorerTreeChildItemViewModel> allFakeDirectoriesAndFiles = new List<AExplorerTreeChildItemViewModel>();
            allFakeDirectoriesAndFiles.AddRange(fakeDirectories);
            allFakeDirectoriesAndFiles.AddRange(fakeFiles);

            hiddenOverallConfiguration.ShowHiddenElements = true;

            foreach (var directoryOrFile in allFakeDirectoriesAndFiles)
            {
                if (directoryOrFile is FakeDirectoryItemViewModel)
                {
                    Assert.AreEqual(true, (directoryOrFile as FakeDirectoryItemViewModel).SetVisibilityAccordingToConfigurationWasCalled,
                                          "The fakePath of the item whose " + nameof(directoryOrFile.SetVisibilityAccordingToConfigruation) + "-Method was not called is: " +
                                           directoryOrFile.FullName);
                }
                else if (directoryOrFile is FakeFileItemViewModel)
                {
                    Assert.AreEqual(true, (directoryOrFile as FakeFileItemViewModel).SetVisibilityAccordingToConfigurationWasCalled,
                                          "The fakePath of the item whose " + nameof(directoryOrFile.SetVisibilityAccordingToConfigruation) + "-Method was not called is: " +
                                           directoryOrFile.FullName);
                }

            }
        }




        [Test]
        public void ShowHiddenElements_SetSameValueAgain_DirectoriesAndFilesAreNotUpdated()
        {

            HiddenOverallConfiguration hiddenOverallConfiguration = CreateHiddenOverallConfiguration();
            var fakeDirectories = (hiddenOverallConfiguration.ExplorerTreeVM as FakeExplorerTreeViewModel).GetAllFakeDirectories();
            var fakeFiles = (hiddenOverallConfiguration.ExplorerTreeVM as FakeExplorerTreeViewModel).GetAllFakeFiles();
            List<AExplorerTreeChildItemViewModel> allFakeDirectoriesAndFiles = new List<AExplorerTreeChildItemViewModel>();
            allFakeDirectoriesAndFiles.AddRange(fakeDirectories);
            allFakeDirectoriesAndFiles.AddRange(fakeFiles);

            Assert.AreEqual(false, hiddenOverallConfiguration.ShowHiddenElements, "Initial value should be false but was true!");
            hiddenOverallConfiguration.ShowHiddenElements = false;

            foreach(var directoryOrFile in allFakeDirectoriesAndFiles)
            {
                if (directoryOrFile is FakeDirectoryItemViewModel)
                {
                    Assert.AreEqual(false, (directoryOrFile as FakeDirectoryItemViewModel).SetVisibilityAccordingToConfigurationWasCalled,
                        "The fakePath of the item whose " + nameof(directoryOrFile.SetVisibilityAccordingToConfigruation) + "-Method was called is: " +
                                           directoryOrFile.FullName);
                }
                else if (directoryOrFile is FakeFileItemViewModel)
                {
                    Assert.AreEqual(false, (directoryOrFile as FakeFileItemViewModel).SetVisibilityAccordingToConfigurationWasCalled,
                        "The fakePath of the item whose " + nameof(directoryOrFile.SetVisibilityAccordingToConfigruation) + "-Method was called is: " +
                                           directoryOrFile.FullName);
                }
            
            }
        }


        [Test]
        public void ShowHiddenElements_DrivePropertyNameIsDummyChild_DirectoriesAndFilesAreNotUpdated()
        {
            FakeExplorerTreeViewModel fakeExplorerTreeVM = CreateFakeExplorerTreeVM();
            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.Name = "DummyChild";
            mockDriveItemVM.CreateAddAndGetFakeDirectory("FakeDirectory");
            fakeExplorerTreeVM.Drives.Clear();
            fakeExplorerTreeVM.Drives.Add(mockDriveItemVM);
            HiddenOverallConfiguration hiddenOverallConfiguration = CreateHiddenOverallConfiguration(fakeExplorerTreeVM);

            Assert.AreEqual(false, hiddenOverallConfiguration.ShowHiddenElements, "Initial value should be false but was true!");
            hiddenOverallConfiguration.ShowHiddenElements = true;

            Assert.AreEqual(false, (mockDriveItemVM.ChildTreeItemVMs.First() as FakeDirectoryItemViewModel).SetVisibilityAccordingToConfigurationWasCalled);
        }


        [Test]
        public void ShowHiddenElements_DirectoryPropertyNameIsDummyChild_DirectoriesAndFilesAreNotUpdated()
        {
            FakeExplorerTreeViewModel fakeExplorerTreeVM = CreateFakeExplorerTreeVM();
            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.CreateAddAndGetFakeDirectory("FakeDirectory").Name = "DummyChild";
            fakeExplorerTreeVM.Drives.Clear();
            fakeExplorerTreeVM.Drives.Add(mockDriveItemVM);
            HiddenOverallConfiguration hiddenOverallConfiguration = CreateHiddenOverallConfiguration(fakeExplorerTreeVM);

            Assert.AreEqual(false, hiddenOverallConfiguration.ShowHiddenElements, "Initial value should be false but was true!");
            hiddenOverallConfiguration.ShowHiddenElements = true;

            Assert.AreEqual(false, (mockDriveItemVM.ChildTreeItemVMs.First() as FakeDirectoryItemViewModel).SetVisibilityAccordingToConfigurationWasCalled);
        }

        [Test]
        public void ShowHiddenElements_FilePropertyNameIsDummyChild_DirectoriesAndFilesAreNotUpdated()
        {
            FakeExplorerTreeViewModel fakeExplorerTreeVM = CreateFakeExplorerTreeVM();
            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.CreateAddAndGetFakeFile("FakeFile").Name = "DummyChild";
            fakeExplorerTreeVM.Drives.Clear();
            fakeExplorerTreeVM.Drives.Add(mockDriveItemVM);
            HiddenOverallConfiguration hiddenOverallConfiguration = CreateHiddenOverallConfiguration(fakeExplorerTreeVM);

            Assert.AreEqual(false, hiddenOverallConfiguration.ShowHiddenElements, "Initial value should be false but was true!");
            hiddenOverallConfiguration.ShowHiddenElements = true;

            Assert.AreEqual(false, (mockDriveItemVM.ChildTreeItemVMs.First() as FakeFileItemViewModel).SetVisibilityAccordingToConfigurationWasCalled);
        }
    }
}

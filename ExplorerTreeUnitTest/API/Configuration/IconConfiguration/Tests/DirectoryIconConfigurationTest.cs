using ExplorerTree.API.Configuration;
using ExplorerTree.API.Configuration.IconConfiguration;
using ExplorerTree.Model.ExplorerTreeItems;
using ExplorerTree.PresentationLogic;
using ExplorerTree.PresentationLogic.API;
using ExplorerTreeUnitTest.PresentationLogic.ExplorerTreeItems.Fakes;
using ExplorerTreeUnitTest.PresentationLogic.Fakes;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeUnitTest.API.Configuration.IconConfiguration.Tests
{

    [TestFixture]
    public class DirectoryIconConfigurationTest
    {

        private static DirectoryIconConfiguration CreateDirectoryIconConfigurationWithVariableExplorerTreeVM(FakeExplorerTreeViewModel fakeExplorerTreeViewModel)
        {
            return new DirectoryIconConfiguration(fakeExplorerTreeViewModel);
        }

        private static DirectoryIconConfiguration CreateDefaultDirectoryIconConfiguration()
        {
            return new DirectoryIconConfiguration(CreateFakeExplorerTreeVM());
        }


        private static FakeExplorerTreeViewModel CreateFakeExplorerTreeVM()
        {
            IConfiguration stubConfiguration = Substitute.For<IConfiguration>();
            IPresentationLogic stubPresentationLogic = Substitute.For<IPresentationLogic>();
            return new FakeExplorerTreeViewModel(stubConfiguration, stubPresentationLogic);
        }




        [Test]
        public void DirectoryIconConfiguration_DefaultInitialisation_PropertyActiveIconStateIsInitialised()
        {
            DirectoryIconConfiguration directoryIconConfiguration = new DirectoryIconConfiguration(CreateFakeExplorerTreeVM());

            Assert.AreEqual(IconStates.SmallIcon, directoryIconConfiguration.ActiveIconState);
        }

        [Test]
        public void DirectoryIconConfiguration_DefaultInitialisation_PropertyExplorerTreeVMIsInitialised()
        {
            ExplorerTreeViewModel mockExplorerTreeVM = CreateFakeExplorerTreeVM();
            DirectoryIconConfiguration directoryIconConfiguration = new DirectoryIconConfiguration(mockExplorerTreeVM);

            Assert.AreEqual(mockExplorerTreeVM, directoryIconConfiguration.ExplorerTreeVM);
        }




        [Test]
        public void SetLargeIconToActiveIcon_SetPropertyActiveIconStateToLargeIcon_ReturnsSetValue()
        {
            DirectoryIconConfiguration directoryIconConfiguration = CreateDefaultDirectoryIconConfiguration();

            directoryIconConfiguration.SetLargeIconToActiveIcon();

            Assert.AreEqual(IconStates.LargeIcon, directoryIconConfiguration.ActiveIconState);
        }


        [Test]
        public void SetLargeIconToActiveIcon_ForeachDriveUpdateChildsWithLargeIcon_ForeachDirectorySetLargeImageSourceToActiveImageSourceWasCalled()
        {
            DirectoryIconConfiguration directoryIconConfiguration = CreateDefaultDirectoryIconConfiguration();

            directoryIconConfiguration.SetLargeIconToActiveIcon();

            List<FakeDirectoryItemViewModel> fakeDirectoryItemVMs = (directoryIconConfiguration.ExplorerTreeVM as FakeExplorerTreeViewModel).GetAllFakeDirectories();
            foreach(var mockDirectory in fakeDirectoryItemVMs)
            {
                Assert.AreEqual(true, (mockDirectory.IconVM as FakeIconViewModel).ActiveImageSourceWasSetToLargeImageSource,
                                  "The fakePath of the item whose " + nameof(mockDirectory.IconVM.SetLargeImageSourceToActiveImageSource) + "-Method was not called is: " +
                                  mockDirectory.FullName);
            }
        }

        [Test]
        public void SetLargeIconToActiveIcon_DrivePropertyNameIsDummyChild_ForeachDirectorySetLargeImageSourceToActiveImageSourceWasNotCalled()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();

            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.Name = "DummyChild";
            mockDriveItemVM.CreateAddAndGetFakeDirectory("FakeDirectory");
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);

            DirectoryIconConfiguration directoryIconConfiguration = CreateDirectoryIconConfigurationWithVariableExplorerTreeVM(stubExplorerTreeVM);



            directoryIconConfiguration.SetLargeIconToActiveIcon();


            
            foreach (var mockDrive in stubExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().IconVM as FakeIconViewModel).ActiveImageSourceWasSetToLargeImageSource);
            }
        }

        [Test]
        public void SetLargeIconToActiveIcon_DirectoryPropertyNameIsDummyChild_ForeachDirectorySetLargeImageSourceToActiveImageSourceWasNotCalled()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();

            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.CreateAddAndGetFakeDirectory("FakeDirectory").Name = "DummyChild";
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);

            DirectoryIconConfiguration directoryIconConfiguration = CreateDirectoryIconConfigurationWithVariableExplorerTreeVM(stubExplorerTreeVM);



            directoryIconConfiguration.SetLargeIconToActiveIcon();



            foreach (var mockDrive in stubExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().IconVM as FakeIconViewModel).ActiveImageSourceWasSetToLargeImageSource);
            }
        }


        [Test]
        public void SetLargeIconToActiveIcon_FileInsteadOfDirectory_ForeachDirectorySetLargeImageSourceToActiveImageSourceWasNotCalled()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();

            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.CreateAddAndGetFakeFile("FakeFile");
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);

            DirectoryIconConfiguration directoryIconConfiguration = CreateDirectoryIconConfigurationWithVariableExplorerTreeVM(stubExplorerTreeVM);



            directoryIconConfiguration.SetLargeIconToActiveIcon();



            foreach (var mockDrive in stubExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().IconVM as FakeIconViewModel).ActiveImageSourceWasSetToLargeImageSource);
            }
        }






        [Test]
        public void SetSmallIconToActiveIcon_SetPropertyActiveIconStateToSmallIcon_ReturnsSetValue()
        {
            DirectoryIconConfiguration directoryIconConfiguration = CreateDefaultDirectoryIconConfiguration();

            directoryIconConfiguration.SetSmallIconToActiveIcon();

            Assert.AreEqual(IconStates.SmallIcon, directoryIconConfiguration.ActiveIconState);
        }


        [Test]
        public void SetSmallIconToActiveIcon_ForeachDriveUpdateChildsWithSmallIcon_ForeachDirectorySetSmallImageSourceToActiveImageSourceWasCalled()
        {
            DirectoryIconConfiguration directoryIconConfiguration = CreateDefaultDirectoryIconConfiguration();

            directoryIconConfiguration.SetSmallIconToActiveIcon();

            List<FakeDirectoryItemViewModel> fakeDirectoryItemVMs = (directoryIconConfiguration.ExplorerTreeVM as FakeExplorerTreeViewModel).GetAllFakeDirectories();
            foreach (var mockDirectory in fakeDirectoryItemVMs)
            {
                Assert.AreEqual(true, (mockDirectory.IconVM as FakeIconViewModel).ActiveImageSourceWasSetToSmallImageSource,
                                  "The fakePath of the item whose " + nameof(mockDirectory.IconVM.SetLargeImageSourceToActiveImageSource) + "-Method was not called is: " +
                                  mockDirectory.FullName);
            }
        }

        [Test]
        public void SetSmallIconToActiveIcon_DrivePropertyNameIsDummyChild_ForeachDirectorySetSmallImageSourceToActiveImageSourceWasNotCalled()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();

            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.Name = "DummyChild";
            mockDriveItemVM.CreateAddAndGetFakeDirectory("FakeDirectory");
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);

            DirectoryIconConfiguration directoryIconConfiguration = CreateDirectoryIconConfigurationWithVariableExplorerTreeVM(stubExplorerTreeVM);



            directoryIconConfiguration.SetSmallIconToActiveIcon();



            foreach (var mockDrive in stubExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().IconVM as FakeIconViewModel).ActiveImageSourceWasSetToSmallImageSource);
            }
        }

        [Test]
        public void SetSmallIconToActiveIcon_DirectoryPropertyNameIsDummyChild_ForeachDirectorySetSmallImageSourceToActiveImageSourceWasNotCalled()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();

            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.CreateAddAndGetFakeDirectory("FakeDirectory").Name = "DummyChild";
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);

            DirectoryIconConfiguration directoryIconConfiguration = CreateDirectoryIconConfigurationWithVariableExplorerTreeVM(stubExplorerTreeVM);



            directoryIconConfiguration.SetSmallIconToActiveIcon();



            foreach (var mockDrive in stubExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().IconVM as FakeIconViewModel).ActiveImageSourceWasSetToSmallImageSource);
            }
        }


        [Test]
        public void SetSmallIconToActiveIcon_FileInsteadOfDirectory_ForeachDirectorySetSmallImageSourceToActiveImageSourceWasNotCalled()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();

            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.CreateAddAndGetFakeFile("FakeFile");
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);

            DirectoryIconConfiguration directoryIconConfiguration = CreateDirectoryIconConfigurationWithVariableExplorerTreeVM(stubExplorerTreeVM);



            directoryIconConfiguration.SetSmallIconToActiveIcon();



            foreach (var mockDrive in stubExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().IconVM as FakeIconViewModel).ActiveImageSourceWasSetToSmallImageSource);
            }
        }
    }
}

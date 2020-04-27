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
    class FileIconConfigurationTest
    {

        private static FileIconConfiguration CreateFileIconConfigurationWithVariableExplorerTreeVM(FakeExplorerTreeViewModel fakeExplorerTreeViewModel)
        {
            return new FileIconConfiguration(fakeExplorerTreeViewModel);
        }

        private static FileIconConfiguration CreateDefaultFileIconConfiguration()
        {
            return new FileIconConfiguration(CreateFakeExplorerTreeVM());
        }


        private static FakeExplorerTreeViewModel CreateFakeExplorerTreeVM()
        {
            IConfiguration stubConfiguration = Substitute.For<IConfiguration>();
            IPresentationLogic stubPresentationLogic = Substitute.For<IPresentationLogic>();
            return new FakeExplorerTreeViewModel(stubConfiguration, stubPresentationLogic);
        }




        [Test]
        public void FileIconConfiguration_DefaultInitialisation_PropertyActiveIconStateIsInitialised()
        {
            FileIconConfiguration fileIconConfiguration = new FileIconConfiguration(CreateFakeExplorerTreeVM());

            Assert.AreEqual(IconStates.SmallIcon, fileIconConfiguration.ActiveIconState);
        }

        [Test]
        public void FileIconConfiguration_DefaultInitialisation_PropertyExplorerTreeVMIsInitialised()
        {
            ExplorerTreeViewModel mockExplorerTreeVM = CreateFakeExplorerTreeVM();
            FileIconConfiguration fileIconConfiguration = new FileIconConfiguration(mockExplorerTreeVM);

            Assert.AreEqual(mockExplorerTreeVM, fileIconConfiguration.ExplorerTreeVM);
        }








        [Test]
        public void SetLargeIconToActiveIcon_SetPropertyActiveIconStateToLargeIcon_ReturnsSetValue()
        {
            FileIconConfiguration fileIconConfiguration = CreateDefaultFileIconConfiguration();

            fileIconConfiguration.SetLargeIconToActiveIcon();

            Assert.AreEqual(IconStates.LargeIcon, fileIconConfiguration.ActiveIconState);
        }

        [Test]
        public void SetLargeIconToActiveIcon_ForeachDriveUpdateChildsWithLargeIcon_ForeachFileSetLargeImageSourceToActiveImageSourceWasCalled()
        {
            FileIconConfiguration fileIconConfiguration = CreateDefaultFileIconConfiguration();

            fileIconConfiguration.SetLargeIconToActiveIcon();

            var fakeFileItemVMs = (fileIconConfiguration.ExplorerTreeVM as FakeExplorerTreeViewModel).GetAllFakeFiles();
            foreach (var mockFile in fakeFileItemVMs)
            {
                Assert.AreEqual(true, (mockFile.IconVM as FakeIconViewModel).ActiveImageSourceWasSetToLargeImageSource,
                                  "The fakePath of the item whose " + nameof(mockFile.IconVM.SetLargeImageSourceToActiveImageSource) + "-Method was not called is: " +
                                  mockFile.FullName);
            }
        }

        [Test]
        public void SetLargeIconToActiveIcon_NoDirectoryIsUpdated_SetLargeImageSourceToActiveImageSourceWasNotCalled()
        {
            FileIconConfiguration fileIconConfiguration = CreateDefaultFileIconConfiguration();

            fileIconConfiguration.SetLargeIconToActiveIcon();

            var fakeDirectoryVMs = (fileIconConfiguration.ExplorerTreeVM as FakeExplorerTreeViewModel).GetAllFakeDirectories();
            foreach (var mockDirectory in fakeDirectoryVMs)
            {
                Assert.AreEqual(false, (mockDirectory.IconVM as FakeIconViewModel).ActiveImageSourceWasSetToLargeImageSource,
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
            mockDriveItemVM.CreateAddAndGetFakeFile("FakeFile");
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);
            FileIconConfiguration fileIconConfiguration = CreateFileIconConfigurationWithVariableExplorerTreeVM(stubExplorerTreeVM);


            fileIconConfiguration.SetLargeIconToActiveIcon();


            foreach (var mockDrive in stubExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().IconVM as FakeIconViewModel).ActiveImageSourceWasSetToLargeImageSource);
            }
        }

        [Test]
        public void SetLargeIconToActiveIcon_FilePropertyNameIsDummyChild_ForeachDirectorySetLargeImageSourceToActiveImageSourceWasNotCalled()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.CreateAddAndGetFakeFile("FakeFile").Name = "DummyChild";
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);
            FileIconConfiguration fileIconConfiguration = CreateFileIconConfigurationWithVariableExplorerTreeVM(stubExplorerTreeVM);


            fileIconConfiguration.SetLargeIconToActiveIcon();


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
            var fakeDirectory1 = mockDriveItemVM.CreateAddAndGetFakeDirectory("FakeDirectory");
            fakeDirectory1.Name = "DummyChild";
            fakeDirectory1.CreateAddAndGetFakeFile("FakeFile");
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);
            FileIconConfiguration fileIconConfiguration = CreateFileIconConfigurationWithVariableExplorerTreeVM(stubExplorerTreeVM);


            fileIconConfiguration.SetLargeIconToActiveIcon();


            foreach (var mockDrive in stubExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().ChildTreeItemVMs.First().IconVM as FakeIconViewModel).ActiveImageSourceWasSetToLargeImageSource);
            }
        }











        [Test]
        public void SetSmallIconToActiveIcon_SetPropertyActiveIconStateToLargeIcon_ReturnsSetValue()
        {
            FileIconConfiguration fileIconConfiguration = CreateDefaultFileIconConfiguration();

            fileIconConfiguration.SetSmallIconToActiveIcon();

            Assert.AreEqual(IconStates.SmallIcon, fileIconConfiguration.ActiveIconState);
        }

        [Test]
        public void SetSmallIconToActiveIcon_ForeachDriveUpdateChildsWithSmallIcon_ForeachDirectorySetSmallImageSourceToActiveImageSourceWasCalled()
        {
            FileIconConfiguration fileIconConfiguration = CreateDefaultFileIconConfiguration();

            fileIconConfiguration.SetSmallIconToActiveIcon();

            var fakeFileItemVMs = (fileIconConfiguration.ExplorerTreeVM as FakeExplorerTreeViewModel).GetAllFakeFiles();
            foreach (var mockFile in fakeFileItemVMs)
            {
                Assert.AreEqual(true, (mockFile.IconVM as FakeIconViewModel).ActiveImageSourceWasSetToSmallImageSource,
                                  "The fakePath of the item whose " + nameof(mockFile.IconVM.SetSmallImageSourceToActiveImageSource) + "-Method was not called is: " +
                                  mockFile.FullName);
            }
        }

        [Test]
        public void SetSmallIconToActiveIcon_NoDirectoryIsUpdated_SetSmallImageSourceToActiveImageSourceWasNotCalled()
        {
            FileIconConfiguration fileIconConfiguration = CreateDefaultFileIconConfiguration();

            fileIconConfiguration.SetSmallIconToActiveIcon();

            var fakeDirectoryVMs = (fileIconConfiguration.ExplorerTreeVM as FakeExplorerTreeViewModel).GetAllFakeDirectories();
            foreach (var mockDirectory in fakeDirectoryVMs)
            {
                Assert.AreEqual(false, (mockDirectory.IconVM as FakeIconViewModel).ActiveImageSourceWasSetToLargeImageSource,
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
            mockDriveItemVM.CreateAddAndGetFakeFile("FakeFile");
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);
            FileIconConfiguration fileIconConfiguration = CreateFileIconConfigurationWithVariableExplorerTreeVM(stubExplorerTreeVM);


            fileIconConfiguration.SetSmallIconToActiveIcon();


            foreach (var mockDrive in stubExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().IconVM as FakeIconViewModel).ActiveImageSourceWasSetToSmallImageSource);
            }
        }

        [Test]
        public void SetSmallIconToActiveIcon_FilePropertyNameIsDummyChild_ForeachDirectorySetSmallImageSourceToActiveImageSourceWasNotCalled()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.CreateAddAndGetFakeFile("FakeFile").Name = "DummyChild";
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);
            FileIconConfiguration fileIconConfiguration = CreateFileIconConfigurationWithVariableExplorerTreeVM(stubExplorerTreeVM);


            fileIconConfiguration.SetSmallIconToActiveIcon();


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
            var fakeDirectory1 = mockDriveItemVM.CreateAddAndGetFakeDirectory("FakeDirectory");
            fakeDirectory1.Name = "DummyChild";
            fakeDirectory1.CreateAddAndGetFakeFile("FakeFile");
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);
            FileIconConfiguration fileIconConfiguration = CreateFileIconConfigurationWithVariableExplorerTreeVM(stubExplorerTreeVM);


            fileIconConfiguration.SetSmallIconToActiveIcon();


            foreach (var mockDrive in stubExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().ChildTreeItemVMs.First().IconVM as FakeIconViewModel).ActiveImageSourceWasSetToSmallImageSource);
            }
        }
    }
}

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
    public class DriveIconConfigurationTest
    {
        private static DriveIconConfiguration CreateDriveIconConfigurationWithVariableExplorerTreeVM(FakeExplorerTreeViewModel fakeExplorerTreeViewModel)
        {
            return new DriveIconConfiguration(fakeExplorerTreeViewModel);
        }

        private static DriveIconConfiguration CreateDefaultDriveIconConfiguration()
        {
            return new DriveIconConfiguration(CreateFakeExplorerTreeVM());
        }


        private static FakeExplorerTreeViewModel CreateFakeExplorerTreeVM()
        {
            IConfiguration stubConfiguration = Substitute.For<IConfiguration>();
            IPresentationLogic stubPresentationLogic = Substitute.For<IPresentationLogic>();
            return new FakeExplorerTreeViewModel(stubConfiguration, stubPresentationLogic);
        }




        [Test]
        public void DriveIconConfiguration_DefaultInitialisation_PropertyActiveIconStateIsInitialised()
        {
            DriveIconConfiguration driveIconConfiguration = new DriveIconConfiguration(CreateFakeExplorerTreeVM());

            Assert.AreEqual(IconStates.SmallIcon, driveIconConfiguration.ActiveIconState);
        }

        [Test]
        public void DriveIconConfiguration_DefaultInitialisation_PropertyExplorerTreeVMIsInitialised()
        {
            ExplorerTreeViewModel mockExplorerTreeVM = CreateFakeExplorerTreeVM();
            DriveIconConfiguration driveIconConfiguration = new DriveIconConfiguration(mockExplorerTreeVM);

            Assert.AreEqual(mockExplorerTreeVM, driveIconConfiguration.ExplorerTreeVM);
        }







        [Test]
        public void SetLargeIconToActiveIcon_SetPropertyActiveIconStateToLargeIcon_ReturnsSetValue()
        {
            DriveIconConfiguration driveIconConfiguration = CreateDefaultDriveIconConfiguration();

            driveIconConfiguration.SetLargeIconToActiveIcon();

            Assert.AreEqual(IconStates.LargeIcon, driveIconConfiguration.ActiveIconState);
        }

        [Test]
        public void SetLargeIconToActiveIcon_ForeachDriveUpdateChildsWithLargeIcon_ForeachDirectorySetLargeImageSourceToActiveImageSourceWasCalled()
        {
            DriveIconConfiguration driveIconConfiguration = CreateDefaultDriveIconConfiguration();

            driveIconConfiguration.SetLargeIconToActiveIcon();

            foreach (var mockDrive in driveIconConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(true, (mockDrive.IconVM as FakeIconViewModel).ActiveImageSourceWasSetToLargeImageSource,
                                  "The fakePath of the item whose " + nameof(mockDrive.IconVM.SetLargeImageSourceToActiveImageSource) + "-Method was not called is: " +
                                  mockDrive.Name);
            }
        }

        [Test]
        public void SetLargeIconToActiveIcon_DrivePropertyNameIsDummyChild_ForeachDirectorySetLargeImageSourceToActiveImageSourceWasNotCalled()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();

            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.Name = "DummyChild";
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);

            DriveIconConfiguration driveIconConfiguration = CreateDriveIconConfigurationWithVariableExplorerTreeVM(stubExplorerTreeVM);



            driveIconConfiguration.SetLargeIconToActiveIcon();



            foreach (var mockDrive in stubExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.IconVM as FakeIconViewModel).ActiveImageSourceWasSetToLargeImageSource);
            }
        }





        [Test]
        public void SetSmallIconToActiveIcon_SetPropertyActiveIconStateToLargeIcon_ReturnsSetValue()
        {
            DriveIconConfiguration driveIconConfiguration = CreateDefaultDriveIconConfiguration();

            driveIconConfiguration.SetSmallIconToActiveIcon();

            Assert.AreEqual(IconStates.SmallIcon, driveIconConfiguration.ActiveIconState);
        }

        [Test]
        public void SetSmallIconToActiveIcon_ForeachDriveUpdateChildsWithLargeIcon_ForeachDirectorySetSmallImageSourceToActiveImageSourceWasCalled()
        {
            DriveIconConfiguration driveIconConfiguration = CreateDefaultDriveIconConfiguration();

            driveIconConfiguration.SetSmallIconToActiveIcon();

            foreach (var mockDrive in driveIconConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(true, (mockDrive.IconVM as FakeIconViewModel).ActiveImageSourceWasSetToSmallImageSource,
                                  "The fakePath of the item whose " + nameof(mockDrive.IconVM.SetSmallImageSourceToActiveImageSource) + "-Method was not called is: " +
                                  mockDrive.Name);
            }
        }

        [Test]
        public void SetSmallIconToActiveIcon_DrivePropertyNameIsDummyChild_ForeachDirectorySetSmallImageSourceToActiveImageSourceWasNotCalled()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();

            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.Name = "DummyChild";
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);

            DriveIconConfiguration driveIconConfiguration = CreateDriveIconConfigurationWithVariableExplorerTreeVM(stubExplorerTreeVM);



            driveIconConfiguration.SetSmallIconToActiveIcon();



            foreach (var mockDrive in stubExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.IconVM as FakeIconViewModel).ActiveImageSourceWasSetToSmallImageSource);
            }
        }


    }
}

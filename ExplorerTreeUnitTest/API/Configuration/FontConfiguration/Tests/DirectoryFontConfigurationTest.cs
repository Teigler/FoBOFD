using ExplorerTree.API.Configuration;
using ExplorerTree.API.Configuration.FontConfiguration;
using ExplorerTree.PresentationLogic.API;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using ExplorerTreeUnitTest.PresentationLogic.ExplorerTreeItems.Fakes;
using ExplorerTreeUnitTest.PresentationLogic.Fakes;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExplorerTreeUnitTest.API.Configuration.FontConfiguration.Tests
{
    [TestFixture]
    public class DirectoryFontConfigurationTest
    {


        private static FakeExplorerTreeViewModel CreateFakeExplorerTreeVM()
        {
            IConfiguration stubConfiguration = Substitute.For<IConfiguration>();
            IPresentationLogic stubPresentationLogic = Substitute.For<IPresentationLogic>();
            return new FakeExplorerTreeViewModel(stubConfiguration, stubPresentationLogic);
        }


        [Test]
        public void DirectoryFontConfiguration_DefaultInitialisation_PropertyExplorerTreeVMIsInstantiated()
        {
            FakeExplorerTreeViewModel mockExplorerTreeVM = CreateFakeExplorerTreeVM();
            DirectoryFontConfiguration directoryFontConfiguration = new DirectoryFontConfiguration(mockExplorerTreeVM);

            Assert.AreEqual(mockExplorerTreeVM, directoryFontConfiguration.ExplorerTreeVM);
        }

        [Test]
        public void DirectoryFontConfiguration_DefaultInitialisation_PropertyFontFamilyIsInstantiated()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DirectoryFontConfiguration directoryFontConfiguration = new DirectoryFontConfiguration(stubExplorerTreeVM);

            Assert.AreEqual(new System.Windows.Media.FontFamily("Times New Roman"), directoryFontConfiguration.FontFamily);
        }

        [Test]
        public void DirectoryFontConfiguration_DefaultInitialisation_PropertyFontSizeIsInitilised()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DirectoryFontConfiguration directoryFontConfiguration = new DirectoryFontConfiguration(stubExplorerTreeVM);

            Assert.AreEqual(12, directoryFontConfiguration.FontSize);
        }

        [Test]
        public void DirectoryFontConfiguration_DefaultInitialisation_PropertyFontStretchIsInitilised()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DirectoryFontConfiguration directoryFontConfiguration = new DirectoryFontConfiguration(stubExplorerTreeVM);

            Assert.AreEqual(FontStretches.Normal, directoryFontConfiguration.FontStretch);
        }

        [Test]
        public void DirectoryFontConfiguration_DefaultInitialisation_PropertyFontStyleIsInitilised()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DirectoryFontConfiguration directoryFontConfiguration = new DirectoryFontConfiguration(stubExplorerTreeVM);

            Assert.AreEqual(FontStyles.Normal, directoryFontConfiguration.FontStyle);
        }

        [Test]
        public void DirectoryFontConfiguration_DefaultInitialisation_PropertyFontWeightIsInitilised()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DirectoryFontConfiguration directoryFontConfiguration = new DirectoryFontConfiguration(stubExplorerTreeVM);

            Assert.AreEqual(FontWeights.Normal, directoryFontConfiguration.FontWeight);
        }

        [Test]
        public void ForeachDriveUpdateChilds_UpdateForechDirectory_FontVmUpdateWasCalled()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DirectoryFontConfiguration directoryFontConfiguration = new DirectoryFontConfiguration(stubExplorerTreeVM);

            directoryFontConfiguration.ForeachDriveUpdateChilds();

            var allFakeDirectories = stubExplorerTreeVM.GetAllFakeDirectories();
            foreach(var mockDirectory in allFakeDirectories)
            {
                Assert.AreEqual(true, (mockDirectory.FontVM as FakeFontViewModel).UpdateWasCalled,
                           "The fakePath of the item whose " + nameof(mockDirectory.FontVM.Update) + "-Method was not called is: " +
                            mockDirectory.FullName);
            }
        }

        [Test]
        public void ForeachDriveUpdateChilds_DrivePropertyNameIsDummyChild_FontVmUpdateWasNotCalled()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();

            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.Name = "DummyChild";
            mockDriveItemVM.CreateAddAndGetFakeDirectory("FakeDirectory");
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);

            DirectoryFontConfiguration directoryFontConfiguration = new DirectoryFontConfiguration(stubExplorerTreeVM);


            directoryFontConfiguration.ForeachDriveUpdateChilds();


            foreach(var mockDrive in stubExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }

        [Test]
        public void ForeachDriveUpdateChilds_DirectoryPropertyNameIsDummyChild_FontVmUpdateWasNotCalled()
        {
            FakeExplorerTreeViewModel mockExplorerTreeVM = CreateFakeExplorerTreeVM();

            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.CreateAddAndGetFakeDirectory("FakeDirectory").Name = "DummyChild";
            mockExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            mockExplorerTreeVM.Drives.Add(mockDriveItemVM);

            DirectoryFontConfiguration directoryFontConfiguration = new DirectoryFontConfiguration(mockExplorerTreeVM);


            directoryFontConfiguration.ForeachDriveUpdateChilds();


            foreach (var mockDrive in mockExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }

        [Test]
        public void ForeachDriveUpdateChilds_FileInsteadOfDirectory_FontVmUpdateWasNotCalled()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();

            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.CreateAddAndGetFakeFile("FakeFile");
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);

            DirectoryFontConfiguration directoryFontConfiguration = new DirectoryFontConfiguration(stubExplorerTreeVM);


            directoryFontConfiguration.ForeachDriveUpdateChilds();


            foreach (var mockDrive in stubExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }





        private static DirectoryFontConfiguration CreateDirectoryFontConfigurationOneDirectoryDepthExplorerTree()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();

            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.CreateAddAndGetFakeDirectory("FakeDirectory");
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this tests we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);

            return new DirectoryFontConfiguration(stubExplorerTreeVM);
        }


        [Test]
        public void FontFamily_SetGet_ReturnsSetValue()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DirectoryFontConfiguration directoryFontConfiguration = new DirectoryFontConfiguration(stubExplorerTreeVM);

            directoryFontConfiguration.FontFamily = new System.Windows.Media.FontFamily("Arial");

            Assert.AreEqual(new System.Windows.Media.FontFamily("Arial"), directoryFontConfiguration.FontFamily);
        }

        [Test]
        public void FontFamily_SetSameValueAgain_FontVMUpdateWasNotCalled()
        {
            DirectoryFontConfiguration directoryFontConfiguration = CreateDirectoryFontConfigurationOneDirectoryDepthExplorerTree();

            directoryFontConfiguration.FontFamily = directoryFontConfiguration.FontFamily;

            foreach (var mockDrive in directoryFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }


        [Test]
        public void FontFamily_ForeachDriveUpdateChilds_FontVMUpdateWasCalled()
        {
            DirectoryFontConfiguration directoryFontConfiguration = CreateDirectoryFontConfigurationOneDirectoryDepthExplorerTree();

            directoryFontConfiguration.FontFamily = new System.Windows.Media.FontFamily("Arial");

            foreach (var mockDrive in directoryFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(true, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }




        [Test]
        public void FontSize_SetGet_ReturnsSetValue()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DirectoryFontConfiguration directoryFontConfiguration = new DirectoryFontConfiguration(stubExplorerTreeVM);

            directoryFontConfiguration.FontSize = 500;

            Assert.AreEqual(500, directoryFontConfiguration.FontSize);
        }

        [Test]
        public void FontSize_SetSameValueAgain_FontVMUpdateWasNotCalled()
        {
            DirectoryFontConfiguration directoryFontConfiguration = CreateDirectoryFontConfigurationOneDirectoryDepthExplorerTree();

            directoryFontConfiguration.FontSize = directoryFontConfiguration.FontSize;

            foreach (var mockDrive in directoryFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }

        [Test]
        public void FontSize_ForeachDriveUpdateChilds_FontVMUpdateWasCalled()
        {
            DirectoryFontConfiguration directoryFontConfiguration = CreateDirectoryFontConfigurationOneDirectoryDepthExplorerTree();

            directoryFontConfiguration.FontSize = 500;

            foreach (var mockDrive in directoryFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(true, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }



        [Test]
        public void FontStretch_SetGet_ReturnsSetValue()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DirectoryFontConfiguration directoryFontConfiguration = new DirectoryFontConfiguration(stubExplorerTreeVM);

            directoryFontConfiguration.FontStretch = FontStretches.Expanded;

            Assert.AreEqual(FontStretches.Expanded, directoryFontConfiguration.FontStretch);
        }

        [Test]
        public void FontStretch_SetSameValueAgain_FontVMUpdateWasNotCalled()
        {
            DirectoryFontConfiguration directoryFontConfiguration = CreateDirectoryFontConfigurationOneDirectoryDepthExplorerTree();

            directoryFontConfiguration.FontStretch = directoryFontConfiguration.FontStretch;

            foreach (var mockDrive in directoryFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }

        [Test]
        public void FontStretch_ForeachDriveUpdateChilds_FontVMUpdateWasCalled()
        {
            DirectoryFontConfiguration directoryFontConfiguration = CreateDirectoryFontConfigurationOneDirectoryDepthExplorerTree();

            directoryFontConfiguration.FontStretch = FontStretches.Expanded;

            foreach (var mockDrive in directoryFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(true, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }



        [Test]
        public void FontStyle_SetGet_ReturnsSetValue()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DirectoryFontConfiguration directoryFontConfiguration = new DirectoryFontConfiguration(stubExplorerTreeVM);

            directoryFontConfiguration.FontStyle = FontStyles.Oblique;

            Assert.AreEqual(FontStyles.Oblique, directoryFontConfiguration.FontStyle);
        }

        [Test]
        public void FontStyle_SetSameValueAgain_FontVMUpdateWasNotCalled()
        {
            DirectoryFontConfiguration directoryFontConfiguration = CreateDirectoryFontConfigurationOneDirectoryDepthExplorerTree();

            directoryFontConfiguration.FontStyle = directoryFontConfiguration.FontStyle;

            foreach (var mockDrive in directoryFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }

        [Test]
        public void FontStyle_ForeachDriveUpdateChilds_FontVMUpdateWasCalled()
        {
            DirectoryFontConfiguration directoryFontConfiguration = CreateDirectoryFontConfigurationOneDirectoryDepthExplorerTree();

            directoryFontConfiguration.FontStyle = FontStyles.Oblique;

            foreach (var mockDrive in directoryFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(true, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }


        [Test]
        public void FontWeight_SetGet_ReturnsSetValue()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DirectoryFontConfiguration directoryFontConfiguration = new DirectoryFontConfiguration(stubExplorerTreeVM);

            directoryFontConfiguration.FontWeight = FontWeights.Black;

            Assert.AreEqual(FontWeights.Black, directoryFontConfiguration.FontWeight);
        }

        [Test]
        public void FontWeight_SetSameValueAgain_FontVMUpdateWasNotCalled()
        {
            DirectoryFontConfiguration directoryFontConfiguration = CreateDirectoryFontConfigurationOneDirectoryDepthExplorerTree();

            directoryFontConfiguration.FontWeight = directoryFontConfiguration.FontWeight;

            foreach (var mockDrive in directoryFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }

        [Test]
        public void FontWeight_ForeachDriveUpdateChilds_FontVMUpdateWasCalled()
        {
            DirectoryFontConfiguration directoryFontConfiguration = CreateDirectoryFontConfigurationOneDirectoryDepthExplorerTree();

            directoryFontConfiguration.FontWeight = FontWeights.Black;

            foreach (var mockDrive in directoryFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(true, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }
    }
}

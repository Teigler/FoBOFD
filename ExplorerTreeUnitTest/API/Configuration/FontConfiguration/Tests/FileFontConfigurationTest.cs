using ExplorerTree.API.Configuration;
using ExplorerTree.API.Configuration.FontConfiguration;
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
using System.Windows;

namespace ExplorerTreeUnitTest.API.Configuration.FontConfiguration.Tests
{
    [TestFixture]
    public class FileFontConfigurationTest
    {

        private static FakeExplorerTreeViewModel CreateFakeExplorerTreeVM()
        {
            IConfiguration stubConfiguration = Substitute.For<IConfiguration>();
            IPresentationLogic stubPresentationLogic = Substitute.For<IPresentationLogic>();
            return new FakeExplorerTreeViewModel(stubConfiguration, stubPresentationLogic);
        }


        [Test]
        public void FileFontConfiguration_DefaultInitialisation_PropertyExplorerTreeVMIsInstantiated()
        {
            FakeExplorerTreeViewModel mockExplorerTreeVM = CreateFakeExplorerTreeVM();
            FileFontConfiguration fileFontConfiguration = new FileFontConfiguration(mockExplorerTreeVM);

            Assert.AreEqual(mockExplorerTreeVM, fileFontConfiguration.ExplorerTreeVM);
        }

        [Test]
        public void FileFontConfiguration_DefaultInitialisation_PropertyFontFamilyIsInstantiated()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            FileFontConfiguration fileFontConfiguration = new FileFontConfiguration(stubExplorerTreeVM);

            Assert.AreEqual(new System.Windows.Media.FontFamily("Times New Roman"), fileFontConfiguration.FontFamily);
        }

        [Test]
        public void FileFontConfiguration_DefaultInitialisation_PropertyFontSizeIsInitilised()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            FileFontConfiguration fileFontConfiguration = new FileFontConfiguration(stubExplorerTreeVM);

            Assert.AreEqual(12, fileFontConfiguration.FontSize);
        }

        [Test]
        public void FileFontConfiguration_DefaultInitialisation_PropertyFontStretchIsInitilised()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            FileFontConfiguration fileFontConfiguration = new FileFontConfiguration(stubExplorerTreeVM);

            Assert.AreEqual(FontStretches.Normal, fileFontConfiguration.FontStretch);
        }

        [Test]
        public void FileFontConfiguration_DefaultInitialisation_PropertyFontStyleIsInitilised()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            FileFontConfiguration fileFontConfiguration = new FileFontConfiguration(stubExplorerTreeVM);

            Assert.AreEqual(FontStyles.Normal, fileFontConfiguration.FontStyle);
        }

        [Test]
        public void FileFontConfiguration_DefaultInitialisation_PropertyFontWeightIsInitilised()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            FileFontConfiguration fileFontConfiguration = new FileFontConfiguration(stubExplorerTreeVM);

            Assert.AreEqual(FontWeights.Normal, fileFontConfiguration.FontWeight);
        }

        [Test]
        public void ForeachDriveUpdateChilds_UpdateAllFiles_FontVmUpdateWasCalled()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            FileFontConfiguration fileFontConfiguration = new FileFontConfiguration(stubExplorerTreeVM);

            fileFontConfiguration.ForeachDriveUpdateChilds();

            var allFakeFiles = stubExplorerTreeVM.GetAllFakeFiles();
            foreach(var mockFile in allFakeFiles)
            {
                Assert.AreEqual(true, (mockFile.FontVM as FakeFontViewModel).UpdateWasCalled,
                                                "The fakePath of the item whose " + nameof(mockFile.FontVM.Update) + "-Method was not called is: " +
                                                 mockFile.FullName);
            }

        }



        [Test] 
        public void ForeachDriveUpdateChilds_NoDirectoryIsUpdated_FontVmUpdateWasNotCalled()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            FileFontConfiguration fileFontConfiguration = new FileFontConfiguration(stubExplorerTreeVM);

            fileFontConfiguration.ForeachDriveUpdateChilds();

            var allFakeDirectories = stubExplorerTreeVM.GetAllFakeDirectories();
            foreach (var mockDirectory in allFakeDirectories)
            {
                Assert.AreEqual(false, (mockDirectory.FontVM as FakeFontViewModel).UpdateWasCalled,
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
            mockDriveItemVM.CreateAddAndGetFakeFile("FakeFile");
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);
            FileFontConfiguration fileFontConfiguration = new FileFontConfiguration(stubExplorerTreeVM);


            fileFontConfiguration.ForeachDriveUpdateChilds();


            foreach (var mockDrive in stubExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }

        [Test]
        public void ForeachDriveUpdateChilds_FilePropertyNameIsDummyChild_FontVmUpdateWasNotCalled()
        {
            FakeExplorerTreeViewModel mockExplorerTreeVM = CreateFakeExplorerTreeVM();

            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.CreateAddAndGetFakeFile("FakeFile").Name = "DummyChild";
            mockExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            mockExplorerTreeVM.Drives.Add(mockDriveItemVM);

            FileFontConfiguration fileFontConfiguration = new FileFontConfiguration(mockExplorerTreeVM);


            fileFontConfiguration.ForeachDriveUpdateChilds();


            foreach (var mockDrive in mockExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }

        [Test]
        public void ForeachDriveUpdateChilds_DirectoryPropertyNameIsDummyChild_FontVmUpdateWasNotCalled()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();

            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            var fakeDirectory1 = mockDriveItemVM.CreateAddAndGetFakeDirectory("FakeDirectory");
            fakeDirectory1.Name = "DummyChild";
            fakeDirectory1.CreateAddAndGetFakeFile("FakeFile");
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);

            FileFontConfiguration fileFontConfiguration = new FileFontConfiguration(stubExplorerTreeVM);


            fileFontConfiguration.ForeachDriveUpdateChilds();


            foreach (var mockDrive in stubExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }





        private static FileFontConfiguration CreateFileFontConfigurationOnlyDriveWithFile()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();

            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.CreateAddAndGetFakeFile("FakeFile");
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this tests we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);

            return new FileFontConfiguration(stubExplorerTreeVM);
        }


        [Test]
        public void FontFamily_SetGet_ReturnsSetValue()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            FileFontConfiguration fileFontConfiguration = new FileFontConfiguration(stubExplorerTreeVM);

            fileFontConfiguration.FontFamily = new System.Windows.Media.FontFamily("Arial");

            Assert.AreEqual(new System.Windows.Media.FontFamily("Arial"), fileFontConfiguration.FontFamily);
        }

        [Test]
        public void FontFamily_SetSameValueAgain_FontVMUpdateWasNotCalled()
        {
            FileFontConfiguration fileFontConfiguration = CreateFileFontConfigurationOnlyDriveWithFile();

            fileFontConfiguration.FontFamily = fileFontConfiguration.FontFamily;

            foreach (var mockDrive in fileFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }


        [Test]
        public void FontFamily_ForeachDriveUpdateChilds_FontVMUpdateWasCalled()
        {
            FileFontConfiguration fileFontConfiguration = CreateFileFontConfigurationOnlyDriveWithFile();

            fileFontConfiguration.FontFamily = new System.Windows.Media.FontFamily("Arial");

            foreach (var mockDrive in fileFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(true, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }




        [Test]
        public void FontSize_SetGet_ReturnsSetValue()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            FileFontConfiguration fileFontConfiguration = new FileFontConfiguration(stubExplorerTreeVM);

            fileFontConfiguration.FontSize = 500;

            Assert.AreEqual(500, fileFontConfiguration.FontSize);
        }

        [Test]
        public void FontSize_SetSameValueAgain_FontVMUpdateWasNotCalled()
        {
            FileFontConfiguration fileFontConfiguration = CreateFileFontConfigurationOnlyDriveWithFile();

            fileFontConfiguration.FontSize = fileFontConfiguration.FontSize;

            foreach (var mockDrive in fileFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }

        [Test]
        public void FontSize_ForeachDriveUpdateChilds_FontVMUpdateWasCalled()
        {
            FileFontConfiguration fileFontConfiguration = CreateFileFontConfigurationOnlyDriveWithFile();

            fileFontConfiguration.FontSize = 500;

            foreach (var mockDrive in fileFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(true, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }



        [Test]
        public void FontStretch_SetGet_ReturnsSetValue()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            FileFontConfiguration fileFontConfiguration = new FileFontConfiguration(stubExplorerTreeVM);

            fileFontConfiguration.FontStretch = FontStretches.Expanded;

            Assert.AreEqual(FontStretches.Expanded, fileFontConfiguration.FontStretch);
        }

        [Test]
        public void FontStretch_SetSameValueAgain_FontVMUpdateWasNotCalled()
        {
            FileFontConfiguration fileFontConfiguration = CreateFileFontConfigurationOnlyDriveWithFile();

            fileFontConfiguration.FontStretch = fileFontConfiguration.FontStretch;

            foreach (var mockDrive in fileFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }

        [Test]
        public void FontStretch_ForeachDriveUpdateChilds_FontVMUpdateWasCalled()
        {
            FileFontConfiguration fileFontConfiguration = CreateFileFontConfigurationOnlyDriveWithFile();

            fileFontConfiguration.FontStretch = FontStretches.Expanded;

            foreach (var mockDrive in fileFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(true, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }



        [Test]
        public void FontStyle_SetGet_ReturnsSetValue()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            FileFontConfiguration fileFontConfiguration = new FileFontConfiguration(stubExplorerTreeVM);

            fileFontConfiguration.FontStyle = FontStyles.Oblique;

            Assert.AreEqual(FontStyles.Oblique, fileFontConfiguration.FontStyle);
        }

        [Test]
        public void FontStyle_SetSameValueAgain_FontVMUpdateWasNotCalled()
        {
            FileFontConfiguration fileFontConfiguration = CreateFileFontConfigurationOnlyDriveWithFile();

            fileFontConfiguration.FontStyle = fileFontConfiguration.FontStyle;

            foreach (var mockDrive in fileFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }

        [Test]
        public void FontStyle_ForeachDriveUpdateChilds_FontVMUpdateWasCalled()
        {
            FileFontConfiguration fileFontConfiguration = CreateFileFontConfigurationOnlyDriveWithFile();

            fileFontConfiguration.FontStyle = FontStyles.Oblique;

            foreach (var mockDrive in fileFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(true, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }


        [Test]
        public void FontWeight_SetGet_ReturnsSetValue()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            FileFontConfiguration fileFontConfiguration = new FileFontConfiguration(stubExplorerTreeVM);

            fileFontConfiguration.FontWeight = FontWeights.Black;

            Assert.AreEqual(FontWeights.Black, fileFontConfiguration.FontWeight);
        }

        [Test]
        public void FontWeight_SetSameValueAgain_FontVMUpdateWasNotCalled()
        {
            FileFontConfiguration fileFontConfiguration = CreateFileFontConfigurationOnlyDriveWithFile();

            fileFontConfiguration.FontWeight = fileFontConfiguration.FontWeight;

            foreach (var mockDrive in fileFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }

        [Test]
        public void FontWeight_ForeachDriveUpdateChilds_FontVMUpdateWasCalled()
        {
            FileFontConfiguration fileFontConfiguration = CreateFileFontConfigurationOnlyDriveWithFile();

            fileFontConfiguration.FontWeight = FontWeights.Black;

            foreach (var mockDrive in fileFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(true, (mockDrive.ChildTreeItemVMs.First().FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }
    }
}

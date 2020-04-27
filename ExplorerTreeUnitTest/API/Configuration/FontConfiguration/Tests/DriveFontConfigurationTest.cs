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
    public class DriveFontConfigurationTest
    {
        private static FakeExplorerTreeViewModel CreateFakeExplorerTreeVM()
        {
            IConfiguration stubConfiguration = Substitute.For<IConfiguration>();
            IPresentationLogic stubPresentationLogic = Substitute.For<IPresentationLogic>();
            return new FakeExplorerTreeViewModel(stubConfiguration, stubPresentationLogic);
        }


        [Test]
        public void DriveFontConfiguration_DefaultInitialisation_PropertyExplorerTreeVMIsInstantiated()
        {
            FakeExplorerTreeViewModel mockExplorerTreeVM = CreateFakeExplorerTreeVM();
            DriveFontConfiguration driveFontConfiguration = new DriveFontConfiguration(mockExplorerTreeVM);

            Assert.AreEqual(mockExplorerTreeVM, driveFontConfiguration.ExplorerTreeVM);
        }

        [Test]
        public void DriveFontConfiguration_DefaultInitialisation_PropertyFontFamilyIsInstantiated()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DriveFontConfiguration driveFontConfiguration = new DriveFontConfiguration(stubExplorerTreeVM);

            Assert.AreEqual(new System.Windows.Media.FontFamily("Times New Roman"), driveFontConfiguration.FontFamily);
        }

        [Test]
        public void DriveFontConfiguration_DefaultInitialisation_PropertyFontSizeIsInitilised()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DriveFontConfiguration driveFontConfiguration = new DriveFontConfiguration(stubExplorerTreeVM);

            Assert.AreEqual(12, driveFontConfiguration.FontSize);
        }

        [Test]
        public void DriveFontConfiguration_DefaultInitialisation_PropertyFontStretchIsInitilised()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DriveFontConfiguration driveFontConfiguration = new DriveFontConfiguration(stubExplorerTreeVM);

            Assert.AreEqual(FontStretches.Normal, driveFontConfiguration.FontStretch);
        }

        [Test]
        public void DriveFontConfiguration_DefaultInitialisation_PropertyFontStyleIsInitilised()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DriveFontConfiguration driveFontConfiguration = new DriveFontConfiguration(stubExplorerTreeVM);

            Assert.AreEqual(FontStyles.Normal, driveFontConfiguration.FontStyle);
        }

        [Test]
        public void DriveFontConfiguration_DefaultInitialisation_PropertyFontWeightIsInitilised()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DriveFontConfiguration driveFontConfiguration = new DriveFontConfiguration(stubExplorerTreeVM);

            Assert.AreEqual(FontWeights.Normal, driveFontConfiguration.FontWeight);
        }








        [Test]
        public void UpdateDrives_UpdateForeachDrive_FontVmUpdateWasCalled()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DriveFontConfiguration driveFontConfiguration = new DriveFontConfiguration(stubExplorerTreeVM);

            driveFontConfiguration.UpdateDrives();

            foreach (var mockDrive in stubExplorerTreeVM.Drives)
            {
                Assert.AreEqual(true, (mockDrive.FontVM as FakeFontViewModel).UpdateWasCalled,
                       "The fakePath of the item whose " + nameof(mockDrive.FontVM.Update) + "-Method was not called is: " +
                        mockDrive.Name);
            }

        }

        [Test]
        public void UpdateDrives_DrivePropertyNameIsDummyChild_FontVmUpdateWasNotCalled()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();

            FakeDriveItemViewModel mockDriveItemVM = new FakeDriveItemViewModel();
            mockDriveItemVM.Name = "DummyChild";
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this test we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(mockDriveItemVM);

            DriveFontConfiguration driveFontConfiguration = new DriveFontConfiguration(stubExplorerTreeVM);


            driveFontConfiguration.UpdateDrives();


            foreach (var mockDrive in stubExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }

   

        





        private static DriveFontConfiguration CreateDriveFontConfigurationOnlyDriveWithFile()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();

            FakeDriveItemViewModel fakeDriveItemVM = new FakeDriveItemViewModel();
            stubExplorerTreeVM.Drives.Clear(); // cleare because for this tests we need special fakeExplorerTree.
            stubExplorerTreeVM.Drives.Add(fakeDriveItemVM);

            return new DriveFontConfiguration(stubExplorerTreeVM);
        }


        [Test]
        public void FontFamily_SetGet_ReturnsSetValue()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DriveFontConfiguration driveFontConfiguration = new DriveFontConfiguration(stubExplorerTreeVM);

            driveFontConfiguration.FontFamily = new System.Windows.Media.FontFamily("Arial");

            Assert.AreEqual(new System.Windows.Media.FontFamily("Arial"), driveFontConfiguration.FontFamily);
        }

        [Test]
        public void FontFamily_SetSameValueAgain_FontVMUpdateWasNotCalled()
        {
            DriveFontConfiguration driveFontConfiguration = CreateDriveFontConfigurationOnlyDriveWithFile();

            driveFontConfiguration.FontFamily = driveFontConfiguration.FontFamily;

            foreach (var mockDrive in driveFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }


        [Test]
        public void FontFamily_ForeachDriveUpdateChilds_FontVMUpdateWasCalled()
        {
            DriveFontConfiguration driveFontConfiguration = CreateDriveFontConfigurationOnlyDriveWithFile();

            driveFontConfiguration.FontFamily = new System.Windows.Media.FontFamily("Arial");

            foreach (var mockDrive in driveFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(true, (mockDrive.FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }




        [Test]
        public void FontSize_SetGet_ReturnsSetValue()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DriveFontConfiguration driveFontConfiguration = new DriveFontConfiguration(stubExplorerTreeVM);

            driveFontConfiguration.FontSize = 500;

            Assert.AreEqual(500, driveFontConfiguration.FontSize);
        }

        [Test]
        public void FontSize_SetSameValueAgain_FontVMUpdateWasNotCalled()
        {
            DriveFontConfiguration driveFontConfiguration = CreateDriveFontConfigurationOnlyDriveWithFile();

            driveFontConfiguration.FontSize = driveFontConfiguration.FontSize;

            foreach (var mockDrive in driveFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }

        [Test]
        public void FontSize_ForeachDriveUpdateChilds_FontVMUpdateWasCalled()
        {
            DriveFontConfiguration driveFontConfiguration = CreateDriveFontConfigurationOnlyDriveWithFile();

            driveFontConfiguration.FontSize = 500;

            foreach (var mockDrive in driveFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(true, (mockDrive.FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }



        [Test]
        public void FontStretch_SetGet_ReturnsSetValue()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DriveFontConfiguration driveFontConfiguration = new DriveFontConfiguration(stubExplorerTreeVM);

            driveFontConfiguration.FontStretch = FontStretches.Expanded;

            Assert.AreEqual(FontStretches.Expanded, driveFontConfiguration.FontStretch);
        }

        [Test]
        public void FontStretch_SetSameValueAgain_FontVMUpdateWasNotCalled()
        {
            DriveFontConfiguration driveFontConfiguration = CreateDriveFontConfigurationOnlyDriveWithFile();

            driveFontConfiguration.FontStretch = driveFontConfiguration.FontStretch;

            foreach (var mockDrive in driveFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }

        [Test]
        public void FontStretch_ForeachDriveUpdateChilds_FontVMUpdateWasCalled()
        {
            DriveFontConfiguration driveFontConfiguration = CreateDriveFontConfigurationOnlyDriveWithFile();

            driveFontConfiguration.FontStretch = FontStretches.Expanded;

            foreach (var mockDrive in driveFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(true, (mockDrive.FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }



        [Test]
        public void FontStyle_SetGet_ReturnsSetValue()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DriveFontConfiguration driveFontConfiguration = new DriveFontConfiguration(stubExplorerTreeVM);

            driveFontConfiguration.FontStyle = FontStyles.Oblique;

            Assert.AreEqual(FontStyles.Oblique, driveFontConfiguration.FontStyle);
        }

        [Test]
        public void FontStyle_SetSameValueAgain_FontVMUpdateWasNotCalled()
        {
            DriveFontConfiguration driveFontConfiguration = CreateDriveFontConfigurationOnlyDriveWithFile();

            driveFontConfiguration.FontStyle = driveFontConfiguration.FontStyle;

            foreach (var mockDrive in driveFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }

        [Test]
        public void FontStyle_ForeachDriveUpdateChilds_FontVMUpdateWasCalled()
        {
            DriveFontConfiguration driveFontConfiguration = CreateDriveFontConfigurationOnlyDriveWithFile();

            driveFontConfiguration.FontStyle = FontStyles.Oblique;

            foreach (var mockDrive in driveFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(true, (mockDrive.FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }



        [Test]
        public void FontWeight_SetGet_ReturnsSetValue()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            DriveFontConfiguration driveFontConfiguration = new DriveFontConfiguration(stubExplorerTreeVM);

            driveFontConfiguration.FontWeight = FontWeights.Black;

            Assert.AreEqual(FontWeights.Black, driveFontConfiguration.FontWeight);
        }

        [Test]
        public void FontWeight_SetSameValueAgain_FontVMUpdateWasNotCalled()
        {
            DriveFontConfiguration driveFontConfiguration = CreateDriveFontConfigurationOnlyDriveWithFile();

            driveFontConfiguration.FontWeight = driveFontConfiguration.FontWeight;

            foreach (var mockDrive in driveFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(false, (mockDrive.FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }

        [Test]
        public void FontWeight_ForeachDriveUpdateChilds_FontVMUpdateWasCalled()
        {
            DriveFontConfiguration driveFontConfiguration = CreateDriveFontConfigurationOnlyDriveWithFile();

            driveFontConfiguration.FontWeight = FontWeights.Black;

            foreach (var mockDrive in driveFontConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(true, (mockDrive.FontVM as FakeFontViewModel).UpdateWasCalled);
            }
        }
    }
}

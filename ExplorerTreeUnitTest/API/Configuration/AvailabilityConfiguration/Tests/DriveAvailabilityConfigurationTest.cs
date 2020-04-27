using ExplorerTree.API.Configuration;
using ExplorerTree.API.Configuration.AvailabilityConfiguration;
using ExplorerTree.PresentationLogic;
using ExplorerTree.PresentationLogic.API;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using ExplorerTreeUnitTest.PresentationLogic.Fakes;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExplorerTreeUnitTest.API.Configuration.AvailabilityConfiguration.Tests
{
    [TestFixture]
    public class DriveAvailabilityConfigurationTest
    {
        private static DriveAvailabilityConfiguration CreateDriveAvailabilityConfiguration()
        {
            FakeExplorerTreeViewModel stubExplorerTreeVM = CreateFakeExplorerTreeVM();
            return new DriveAvailabilityConfiguration(stubExplorerTreeVM);
        }

        private static FakeExplorerTreeViewModel CreateFakeExplorerTreeVM()
        {
            IConfiguration stubConfiguration = Substitute.For<IConfiguration>();
            IPresentationLogic stubPresentationLogic = Substitute.For<IPresentationLogic>();
            return new FakeExplorerTreeViewModel(stubConfiguration, stubPresentationLogic);
        }



        [Test]
        public void DriveAvailabilityConfiguration_DefaultInitialisation_ExplorerTreeVMPropertyIsNull()
        {
            DriveAvailabilityConfiguration driveAvailabilityConfiguration = new DriveAvailabilityConfiguration();

            Assert.AreEqual(null, driveAvailabilityConfiguration.ExplorerTreeVM);
        }

        [Test]
        public void DriveAvailabilityConfiguration_DefaultInitialisation_ActivatableDriveTypesPropertyIsNotNull()
        {
            DriveAvailabilityConfiguration driveAvailabilityConfiguration = new DriveAvailabilityConfiguration();

            Assert.NotNull(driveAvailabilityConfiguration.ActivatableDriveTypes);
        }

        [Test]
        public void DriveAvailabilityConfiguration_Initialisation_ExplorerTreeVMPropertyIsInstantiated()
        {
            FakeExplorerTreeViewModel mockExplorerTreeVM = CreateFakeExplorerTreeVM();

            DriveAvailabilityConfiguration driveAvailabilityConfiguration = new DriveAvailabilityConfiguration(mockExplorerTreeVM);

            Assert.AreEqual(mockExplorerTreeVM, driveAvailabilityConfiguration.ExplorerTreeVM);
        }

        [Test]
        public void DriveAvailabilityConfiguration_Initialisation_ActivatableDriveTypesAreInitialised()
        {
            DriveAvailabilityConfiguration driveAvailabilityConfiguration = CreateDriveAvailabilityConfiguration();

            List<string> expected = Enum.GetNames(typeof(DriveType)).ToList();
            List<string> actual = new List<string>();
            foreach (var activatableDriveType in driveAvailabilityConfiguration.ActivatableDriveTypes)
            {
                actual.Add(activatableDriveType.DriveType.ToString());
            }

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void SetALLDrivesDisabled_SetPropertyIsActiveFalse_PropertyIsActiveIsFalse()
        {
            DriveAvailabilityConfiguration driveAvailabilityConfiguration = CreateDriveAvailabilityConfiguration();

            driveAvailabilityConfiguration.SetAllDrivesDisabled();

            foreach (var activatableDriveType in driveAvailabilityConfiguration.ActivatableDriveTypes)
            {
                Assert.AreEqual(false, activatableDriveType.IsActive,
                    "The DriveType whose " + nameof(activatableDriveType.IsActive) + " property was wrong: " +
                    activatableDriveType.DriveType.ToString());
                    
            }
        }



        [Test]
        public void SetALLDrivesDisabled_SetPropertyVisibilityCollapsed_PropertyVisibilityIsCollapsed()
        {
            DriveAvailabilityConfiguration driveAvailabilityConfiguration = CreateDriveAvailabilityConfiguration();

            driveAvailabilityConfiguration.SetAllDrivesDisabled();

            foreach (var mockDrive in driveAvailabilityConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(Visibility.Collapsed, mockDrive.Visibility,
                         "The DriveType whose  " + nameof(mockDrive.Visibility) + " property was wrong: " +
                         mockDrive.DriveType.ToString());
            }
        }


        [Test]
        public void SetALLDrivesEnabled_SetPropertyIsActiveTrue_PropertyIsActiveIsTrue()
        {
            DriveAvailabilityConfiguration driveAvailabilityConfiguration = CreateDriveAvailabilityConfiguration();
            driveAvailabilityConfiguration.SetAllDrivesDisabled(); // because default the IsActive Properties are true.

            driveAvailabilityConfiguration.SetAllDrivesEnabled();

            foreach (var activatableDriveType in driveAvailabilityConfiguration.ActivatableDriveTypes)
            {
                Assert.AreEqual(true, activatableDriveType.IsActive,
                    "The DriveType whose " + nameof(activatableDriveType.IsActive) + " property was wrong: " +
                    activatableDriveType.DriveType.ToString());
            }
        }



        [Test]
        public void SetALLDrivesEnabled_SetPropertyVisibilityVisible_PropertyVisibilityIsVisible()
        {
            DriveAvailabilityConfiguration driveAvailabilityConfiguration = CreateDriveAvailabilityConfiguration();
            driveAvailabilityConfiguration.SetAllDrivesDisabled(); // because default the Visibility Properties are Visible.

            driveAvailabilityConfiguration.SetAllDrivesEnabled();

            foreach (var mockDrive in driveAvailabilityConfiguration.ExplorerTreeVM.Drives)
            {
                Assert.AreEqual(Visibility.Visible, mockDrive.Visibility,
                         "The DriveType whose  " + nameof(mockDrive.Visibility) + " property was wrong: " +
                         (mockDrive as DriveItemViewModel).DriveType.ToString());
            }
        }



      
    }
}

using ExplorerTree.API.Configuration;
using ExplorerTree.API.Configuration.AvailabilityConfiguration;
using ExplorerTree.API.Configuration.ExplorerTreeItemConfiguration;
using ExplorerTree.API.Configuration.FontConfiguration;
using ExplorerTree.API.Configuration.IconConfiguration;
using ExplorerTree.PresentationLogic.API;
using ExplorerTreeUnitTest.PresentationLogic.Fakes;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeUnitTest.API.Configuration.ExplorerTreeItemConfiguration.Tests
{
    [TestFixture]
    public class DriveConfigurationTest
    {

        private static DriveConfiguration CreateDriveConfiguration()
        {
            return new DriveConfiguration(CreateFakeExplorerTreeVM());
        }


        private static FakeExplorerTreeViewModel CreateFakeExplorerTreeVM()
        {
            IConfiguration stubConfiguration = Substitute.For<IConfiguration>();
            IPresentationLogic stubPresentationLogic = Substitute.For<IPresentationLogic>();
            return new FakeExplorerTreeViewModel(stubConfiguration, stubPresentationLogic);
        }




        [Test]
        public void DriveConfiguration_DefaultInitialisation_PropertyAvailabilityIsNull()
        {
            DriveConfiguration driveConfiguration = new DriveConfiguration();
            Assert.AreEqual(null, driveConfiguration.Availability);
        }

        [Test]
        public void DriveConfiguration_DefaultInitialisation_PropertyFontIsNull()
        {
            DriveConfiguration driveConfiguration = new DriveConfiguration();
            Assert.AreEqual(null, driveConfiguration.Font);
        }

        [Test]
        public void DriveConfiguration_DefaultInitialisation_PropertyIconIsNull()
        {
            DriveConfiguration driveConfiguration = new DriveConfiguration();
            Assert.AreEqual(null, driveConfiguration.Icon);
        }




        [Test]
        public void DriveConfiguration_Initialisation_PropertyAvailabilityIsInitialised()
        {
            DriveConfiguration driveConfiguration = CreateDriveConfiguration();
            Assert.AreEqual(true, driveConfiguration.Availability is DriveAvailabilityConfiguration);
        }

        [Test]
        public void DriveConfiguration_Initialisation_PropertyFontIsInitialised()
        {
            DriveConfiguration driveConfiguration = CreateDriveConfiguration();
            Assert.AreEqual(true, driveConfiguration.Font is DriveFontConfiguration);
        }

        [Test]
        public void DriveConfiguration_Initialisation_PropertyIconIsInitialised()
        {
            DriveConfiguration driveConfiguration = CreateDriveConfiguration();
            Assert.AreEqual(true, driveConfiguration.Icon is DriveIconConfiguration);
        }





        [Test]
        public void Availability_SetGet_ReturnsSetValue()
        {
            DriveConfiguration driveConfiguration = CreateDriveConfiguration();

            var expectedMockAvailabilityConfiguration = Substitute.For<IDriveAvailabilityConfiguration>();
            driveConfiguration.Availability = expectedMockAvailabilityConfiguration;

            Assert.AreEqual(expectedMockAvailabilityConfiguration, driveConfiguration.Availability);
        }

        [Test]
        public void Font_SetGet_ReturnsSetValue()
        {
            DriveConfiguration driveConfiguration = CreateDriveConfiguration();

            var expectedMockFontConfiguration = Substitute.For<IExplorerTreeItemFontConfiguration>();
            driveConfiguration.Font = expectedMockFontConfiguration;

            Assert.AreEqual(expectedMockFontConfiguration, driveConfiguration.Font);
        }


        [Test]
        public void Icon_SetGet_ReturnsSetValue()
        {
            DriveConfiguration driveConfiguration = CreateDriveConfiguration();

            var expectedMockIconConfiguration = Substitute.For<IExplorerTreeItemIconConfiguration>();
            driveConfiguration.Icon = expectedMockIconConfiguration;

            Assert.AreEqual(expectedMockIconConfiguration, driveConfiguration.Icon);
        }

    }
}

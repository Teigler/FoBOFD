using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExplorerTree.API.Configuration;
using ExplorerTreeUnitTest.PresentationLogic.Fakes;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using NSubstitute;
using System.Collections.ObjectModel;
using ExplorerTreeUnitTest.PresentationLogic.ExplorerTreeItems.Fakes;
using ExplorerTree.PresentationLogic.API;
using ExplorerTree.API.Configuration.ExplorerTreeItemConfiguration;
using ExplorerTree.API.Configuration.FontConfiguration;
using ExplorerTree.API.Configuration.IconConfiguration;

namespace ExplorerTreeUnitTest.API.Configuration.Tests
{

    
    [TestFixture]
    public class IconOverallConfigurationTest
    {


        private static IconOverallConfiguration CreateDefaultIconOverallConfiguration()
        {
            return new IconOverallConfiguration();
        }

        private IconOverallConfiguration CreateIconOverallConfiguration(IConfiguration configuration = null, FakeExplorerTreeViewModel fakeExplorerTreeVM = null)
        {
            configuration = configuration ?? CreateConfiguration();
            fakeExplorerTreeVM = fakeExplorerTreeVM ?? CreateFakeExplorerTreeVM(configuration);
            return new IconOverallConfiguration(fakeExplorerTreeVM, configuration);
        }

        private FakeExplorerTreeViewModel CreateFakeExplorerTreeVM(IConfiguration configuration = null)
        {
            configuration = configuration ?? CreateConfiguration();
            IPresentationLogic fakePresentationLogic = Substitute.For<IPresentationLogic>();
            return new FakeExplorerTreeViewModel(configuration, fakePresentationLogic);
        }


        private static IConfiguration CreateConfiguration()
        {
            IConfiguration configuration = new ExplorerTree.API.Configuration.Configuration();
            configuration.Drive = new DriveConfiguration();
            configuration.Drive.Icon = Substitute.For<IExplorerTreeItemIconConfiguration>();

            configuration.Directory = new DirectoryConfiguration();
            configuration.Directory.Icon = Substitute.For<IExplorerTreeItemIconConfiguration>();

            configuration.File = new FileConfiguration();
            configuration.File.Icon = Substitute.For<IExplorerTreeItemIconConfiguration>();
            return configuration;
        }

        [Test]
        public void IconOverallConfiguration_DefaultInitialisation_AllPropertiesAreNull()
        {
            IconOverallConfiguration iconOverallConfiguration = CreateDefaultIconOverallConfiguration();

            Assert.AreEqual(null, iconOverallConfiguration.ExplorerTreeVM, 
                "Property: \"" + nameof(iconOverallConfiguration.ExplorerTreeVM) + "\" was NOT null");

            Assert.AreEqual(null, iconOverallConfiguration.DriveIconConfiguration, 
                "Property: \"" + nameof(iconOverallConfiguration.DriveIconConfiguration) + "\" was NOT null");

            Assert.AreEqual(null, iconOverallConfiguration.DirectoryIconConfiguration, 
                "Property: \"" + nameof(iconOverallConfiguration.DirectoryIconConfiguration) + "\" was NOT null");

            Assert.AreEqual(null, iconOverallConfiguration.FileIconConfiguration, 
                "Property: \"" + nameof(iconOverallConfiguration.FileIconConfiguration) + "\" was NOT null");
        }


        [Test]
        public void IconOverallConfiguration_Initialisation_ExplorerTreeVmIsInitialised()
        {
            IConfiguration configuration = CreateConfiguration();
            FakeExplorerTreeViewModel fakeExplorerTreeVM = CreateFakeExplorerTreeVM(configuration);
            IconOverallConfiguration iconOverallConfiguration = CreateIconOverallConfiguration(configuration, fakeExplorerTreeVM);


            Assert.AreEqual(fakeExplorerTreeVM, iconOverallConfiguration.ExplorerTreeVM);
        }

        [Test]
        public void IconOverallConfiguration_Initialisation_DriveDirectoryAndFileIconConfigurationsAreInitialised()
        {
            IConfiguration configuration = new ExplorerTree.API.Configuration.Configuration();
            configuration.Drive = new DriveConfiguration();
            configuration.Drive.Icon = Substitute.For<IExplorerTreeItemIconConfiguration>();

            configuration.Directory = new DirectoryConfiguration();
            configuration.Directory.Icon = Substitute.For<IExplorerTreeItemIconConfiguration>();

            configuration.File = new FileConfiguration();
            configuration.File.Icon = Substitute.For<IExplorerTreeItemIconConfiguration>();

            FakeExplorerTreeViewModel fakeExplorerTreeVM = CreateFakeExplorerTreeVM(configuration);
            IconOverallConfiguration iconOverallConfiguration = CreateIconOverallConfiguration(configuration, fakeExplorerTreeVM);


            Assert.AreEqual(configuration.Drive.Icon, iconOverallConfiguration.DriveIconConfiguration,
                "Property: \"" + nameof(iconOverallConfiguration.DriveIconConfiguration) + "\" was NOT initialised correctly");

            Assert.AreEqual(configuration.Directory.Icon, iconOverallConfiguration.DirectoryIconConfiguration, 
                "Property: \"" + nameof(iconOverallConfiguration.DirectoryIconConfiguration) + "\" was NOT initialised correctly");

            Assert.AreEqual(configuration.File.Icon, iconOverallConfiguration.FileIconConfiguration, 
                "Property: \"" + nameof(iconOverallConfiguration.FileIconConfiguration) + "\" was NOT initialised correctly");
        }





        [Test]
        public void SetSmallIconToActiveIcon()
        {
            IConfiguration configuration = new ExplorerTree.API.Configuration.Configuration();
            configuration.Drive = new DriveConfiguration();
            configuration.Drive.Icon = Substitute.For<IExplorerTreeItemIconConfiguration>();

            configuration.Directory = new DirectoryConfiguration();
            configuration.Directory.Icon = Substitute.For<IExplorerTreeItemIconConfiguration>();

            configuration.File = new FileConfiguration();
            configuration.File.Icon = Substitute.For<IExplorerTreeItemIconConfiguration>();

            FakeExplorerTreeViewModel fakeExplorerTreeVM = CreateFakeExplorerTreeVM(configuration);
            IconOverallConfiguration iconOverallConfiguration = CreateIconOverallConfiguration(configuration, fakeExplorerTreeVM);

            iconOverallConfiguration.SetSmallIconToActiveIcon();

            configuration.Drive.Icon.Received().SetSmallIconToActiveIcon();
            configuration.Directory.Icon.Received().SetSmallIconToActiveIcon();
            configuration.File.Icon.Received().SetSmallIconToActiveIcon();
        }

        [Test]
        public void SetLargeIconToActiveIcon()
        {
            IConfiguration configuration = new ExplorerTree.API.Configuration.Configuration();
            configuration.Drive = new DriveConfiguration();
            configuration.Drive.Icon = Substitute.For<IExplorerTreeItemIconConfiguration>();

            configuration.Directory = new DirectoryConfiguration();
            configuration.Directory.Icon = Substitute.For<IExplorerTreeItemIconConfiguration>();

            configuration.File = new FileConfiguration();
            configuration.File.Icon = Substitute.For<IExplorerTreeItemIconConfiguration>();

            FakeExplorerTreeViewModel fakeExplorerTreeVM = CreateFakeExplorerTreeVM(configuration);
            IconOverallConfiguration iconOverallConfiguration = CreateIconOverallConfiguration(configuration, fakeExplorerTreeVM);

            iconOverallConfiguration.SetLargeIconToActiveIcon();

            configuration.Drive.Icon.Received().SetLargeIconToActiveIcon();
            configuration.Directory.Icon.Received().SetLargeIconToActiveIcon();
            configuration.File.Icon.Received().SetLargeIconToActiveIcon();
        }

    }
}

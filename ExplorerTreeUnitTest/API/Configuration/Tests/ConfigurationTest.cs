using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExplorerTree.API.Configuration;
using ExplorerTree.PresentationLogic.API;
using ExplorerTreeUnitTest.PresentationLogic.Fakes;
using NSubstitute;
using ExplorerTree.API.Configuration.ExplorerTreeItemConfiguration;

namespace ExplorerTreeUnitTest.API.Configuration.Tests
{
    [TestFixture]
    public class ConfigurationTest
    {

        private static ExplorerTree.API.Configuration.Configuration CreateDefaultConfiguration()
        {
            return new ExplorerTree.API.Configuration.Configuration();
        }

        private static ExplorerTree.API.Configuration.Configuration CreateConfigurationWithExplorerTreeVm()
        {
            return new ExplorerTree.API.Configuration.Configuration(CreateFakeExplorerTreeVM());
        }

        private static FakeExplorerTreeViewModel CreateFakeExplorerTreeVM()
        {
            IConfiguration stubConfiguration = Substitute.For<IConfiguration>();
            IPresentationLogic stubPresentationLogic = Substitute.For<IPresentationLogic>();
            return new FakeExplorerTreeViewModel(stubConfiguration, stubPresentationLogic);
        }



        [Test]
        public void Configuration_DefaultInitialisation_AllPropertiesSetAndInstaniated()
        {
            var configuration = CreateDefaultConfiguration();

            Assert.AreEqual(null, configuration.ExplorerTreeVM, "Property: \"" + nameof(configuration.ExplorerTreeVM) + "\" was NOT null");
            Assert.NotNull(configuration.Directory, "Property: \"" + nameof(configuration.Directory) + "\" was null");
            Assert.NotNull(configuration.Drive, "Property: \"" + nameof(configuration.Drive) + "\" was null");
            Assert.NotNull(configuration.File, "Property: \"" + nameof(configuration.File) + "\" was null");
            Assert.NotNull(configuration.FontOverall, "Property: \"" + nameof(configuration.FontOverall) + "\" was null");
            Assert.NotNull(configuration.IconOverall, "Property: \"" + nameof(configuration.IconOverall) + "\" was null");
            Assert.NotNull(configuration.HiddenOverall, "Property: \"" + nameof(configuration.HiddenOverall) + "\" was null");
            Assert.NotNull(configuration.SelectionConfiguration, "Property: \"" + nameof(configuration.SelectionConfiguration) + "\" was null");
        }


        [Test]
        public void Configuration_InitialisationWithExplorerTreeVM_AllPropertiesSetAndInstaniated()
        {
            var configuration = CreateConfigurationWithExplorerTreeVm();

            Assert.NotNull(configuration.ExplorerTreeVM, "Property: \"" + nameof(configuration.ExplorerTreeVM) + "\" was null");
            Assert.NotNull(configuration.Directory, "Property: \"" + nameof(configuration.Directory) + "\" was null");
            Assert.NotNull(configuration.Drive, "Property: \"" + nameof(configuration.Drive) + "\" was null");
            Assert.NotNull(configuration.File, "Property: \"" + nameof(configuration.File) + "\" was null");
            Assert.NotNull(configuration.FontOverall, "Property: \"" + nameof(configuration.FontOverall) + "\" was null");
            Assert.NotNull(configuration.IconOverall, "Property: \"" + nameof(configuration.IconOverall) + "\" was null");
            Assert.NotNull(configuration.HiddenOverall, "Property: \"" + nameof(configuration.HiddenOverall) + "\" was null");
            Assert.NotNull(configuration.SelectionConfiguration, "Property: \"" + nameof(configuration.SelectionConfiguration) + "\" was null");
        }


        [Test]
        public void Initialisation_InitialisationWithExplorerTreeVM_AllPropertiesSetAndInstaniated()
        {
            var configuration = CreateDefaultConfiguration();

            configuration.Initialisation(CreateFakeExplorerTreeVM());

            Assert.NotNull(configuration.ExplorerTreeVM, "Property: \"" + nameof(configuration.ExplorerTreeVM) + "\" was null");
            Assert.NotNull(configuration.Directory, "Property: \"" + nameof(configuration.Directory) + "\" was null");
            Assert.NotNull(configuration.Drive, "Property: \"" + nameof(configuration.Drive) + "\" was null");
            Assert.NotNull(configuration.File, "Property: \"" + nameof(configuration.File) + "\" was null");
            Assert.NotNull(configuration.FontOverall, "Property: \"" + nameof(configuration.FontOverall) + "\" was null");
            Assert.NotNull(configuration.IconOverall, "Property: \"" + nameof(configuration.IconOverall) + "\" was null");
            Assert.NotNull(configuration.HiddenOverall, "Property: \"" + nameof(configuration.HiddenOverall) + "\" was null");
            Assert.NotNull(configuration.SelectionConfiguration, "Property: \"" + nameof(configuration.SelectionConfiguration) + "\" was null");
        }

        [Test]
        public void ExplorerTreeVM_SetGet_ReturnSetValue()
        {
            var configuration = CreateDefaultConfiguration();

            var expected = CreateFakeExplorerTreeVM();
            configuration.ExplorerTreeVM = expected;

            Assert.AreEqual(expected, configuration.ExplorerTreeVM);
        }

        [Test]
        public void DirectoryConfiguration_SetGet_ReturnSetValue()
        {
            var configuration = CreateDefaultConfiguration();

            var expected = Substitute.For<DirectoryConfiguration>();
            configuration.Directory = expected;

            Assert.AreEqual(expected, configuration.Directory);
        }


        [Test]
        public void DriveConfiguration_SetGet_ReturnSetValue()
        {
            var configuration = CreateDefaultConfiguration();

            var expected = Substitute.For<DriveConfiguration>();
            configuration.Drive = expected;

            Assert.AreEqual(expected, configuration.Drive);
        }


        [Test]
        public void FileConfiguration_SetGet_ReturnSetValue()
        {
            var configuration = CreateDefaultConfiguration();

            var expected = Substitute.For<FileConfiguration>();
            configuration.File = expected;

            Assert.AreEqual(expected, configuration.File);
        }







        [Test]
        public void FontOverallConfiguration_SetGet_ReturnSetValue()
        {
            var configuration = CreateDefaultConfiguration();

            var expected = Substitute.For<FontOverallConfiguration>(); 
            configuration.FontOverall = expected;

            Assert.AreEqual(expected, configuration.FontOverall);
        }

        [Test]
        public void IconOverallConfiguration_SetGet_ReturnSetValue()
        {
            var configuration = CreateDefaultConfiguration();

            var expected = Substitute.For<IconOverallConfiguration>();
            configuration.IconOverall = expected;

            Assert.AreEqual(expected, configuration.IconOverall);
        }

        [Test]
        public void HiddenOverallConfiguration_SetGet_ReturnSetValue()
        {
            var configuration = CreateDefaultConfiguration();

            var expected = Substitute.For<HiddenOverallConfiguration>();
            configuration.HiddenOverall = expected;

            Assert.AreEqual(expected, configuration.HiddenOverall);
        }




        [Test]
        public void SelectionConfiguration_SetGet_ReturnSetValue()
        {
            var configuration = CreateDefaultConfiguration();

            var expected = Substitute.For<ExplorerTree.API.Configuration.SelectionConfiguration.SelectionConfiguration>();
            configuration.SelectionConfiguration = expected;

            Assert.AreEqual(expected, configuration.SelectionConfiguration);
        }


    }
}

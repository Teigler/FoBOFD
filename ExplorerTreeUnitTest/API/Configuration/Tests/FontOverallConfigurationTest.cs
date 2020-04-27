using ExplorerTree.API.Configuration;
using ExplorerTree.API.Configuration.ExplorerTreeItemConfiguration;
using ExplorerTree.API.Configuration.FontConfiguration;
using ExplorerTree.PresentationLogic.API;
using ExplorerTreeUnitTest.PresentationLogic.Fakes;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExplorerTreeUnitTest.API.Configuration.Tests
{
    [TestFixture]
    public class FontOverallConfigurationTest
    {

        private static FontOverallConfiguration CreateDefaultFontOverallConfiguration()
        {
            return new FontOverallConfiguration();
        }

        private FontOverallConfiguration CreateFontOverallConfiguration(IConfiguration configuration = null, FakeExplorerTreeViewModel fakeExplorerTreeVM = null)
        {
            configuration = configuration ?? CreateConfiguration();
            fakeExplorerTreeVM = fakeExplorerTreeVM ?? CreateFakeExplorerTreeVM(configuration);
            return new FontOverallConfiguration(fakeExplorerTreeVM, configuration);
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
            configuration.Drive.Font = Substitute.For<IExplorerTreeItemFontConfiguration>();

            configuration.Directory = new DirectoryConfiguration();
            configuration.Directory.Font = Substitute.For<IExplorerTreeItemFontConfiguration>();

            configuration.File = new FileConfiguration();
            configuration.File.Font = Substitute.For<IExplorerTreeItemFontConfiguration>();
            return configuration;
        }


        [Test]
        public void FontOverallConfiguration_DefaultInitialisation_PropertyExplorerTreeVmIsNull()
        {
            FontOverallConfiguration fontOverallConfiguration = CreateDefaultFontOverallConfiguration();

            Assert.AreEqual(null, fontOverallConfiguration.ExplorerTreeVM);
        }

        [Test]
        public void FontOverallConfiguration_DefaultInitialisation_PropertyDriveFontConfigurationIsNull()
        {
            FontOverallConfiguration fontOverallConfiguration = CreateDefaultFontOverallConfiguration();

            Assert.AreEqual(null, fontOverallConfiguration.DriveFontConfiguration);
        }

        [Test]
        public void FontOverallConfiguration_DefaultInitialisation_PropertyDirectoryFontConfigurationIsNull()
        {
            FontOverallConfiguration fontOverallConfiguration = CreateDefaultFontOverallConfiguration();

            Assert.AreEqual(null, fontOverallConfiguration.DirectoryFontConfiguration);
        }

        [Test]
        public void FontOverallConfiguration_DefaultInitialisation_PropertyFileFontConfigurationIsNull()
        {
            FontOverallConfiguration fontOverallConfiguration = CreateDefaultFontOverallConfiguration();

            Assert.AreEqual(null, fontOverallConfiguration.FileFontConfiguration);
        }




        [Test]
        public void FontOverallConfiguration_Initialisation_PropertyExplorerTreeVmIsInitialised()
        {
            IConfiguration configuration = CreateConfiguration();
            FakeExplorerTreeViewModel fakeExplorerTreeVM = CreateFakeExplorerTreeVM(configuration);
            FontOverallConfiguration fontOverallConfiguration = CreateFontOverallConfiguration(configuration, fakeExplorerTreeVM);


            Assert.AreEqual(fakeExplorerTreeVM, fontOverallConfiguration.ExplorerTreeVM);
        }



        [Test]
        public void FontOverallConfiguration_Initialisation_DriveDirectoryAndFileFontConfigurationsAreInitialised()
        {
            IConfiguration configuration = new ExplorerTree.API.Configuration.Configuration();
            configuration.Drive = new DriveConfiguration();
            configuration.Drive.Font = Substitute.For<IExplorerTreeItemFontConfiguration>();

            configuration.Directory = new DirectoryConfiguration();
            configuration.Directory.Font = Substitute.For<IExplorerTreeItemFontConfiguration>();

            configuration.File = new FileConfiguration();
            configuration.File.Font = Substitute.For<IExplorerTreeItemFontConfiguration>();

            FakeExplorerTreeViewModel fakeExplorerTreeVM = CreateFakeExplorerTreeVM(configuration);
            FontOverallConfiguration fontOverallConfiguration = CreateFontOverallConfiguration(configuration, fakeExplorerTreeVM);


            Assert.AreEqual(configuration.Drive.Font, fontOverallConfiguration.DriveFontConfiguration,
                "Property: \"" + nameof(fontOverallConfiguration.DriveFontConfiguration) + "\" was NOT initialised correctly");

            Assert.AreEqual(configuration.Directory.Font, fontOverallConfiguration.DirectoryFontConfiguration,
                "Property: \"" + nameof(fontOverallConfiguration.DirectoryFontConfiguration) + "\" was NOT initialised correctly");

            Assert.AreEqual(configuration.File.Font, fontOverallConfiguration.FileFontConfiguration,
                "Property: \"" + nameof(fontOverallConfiguration.FileFontConfiguration) + "\" was NOT initialised correctly");
        }




        [Test]
        public void SetFontFamily()
        {
            FontOverallConfiguration fontOverallConfiguration = CreateFontOverallConfiguration();

            var expected = new System.Windows.Media.FontFamily("Arial");
            fontOverallConfiguration.SetFontFamily(expected);

            Assert.AreEqual(expected, fontOverallConfiguration.DriveFontConfiguration.FontFamily,
                nameof(DriveFontConfiguration) + " Property \"" + nameof(DriveFontConfiguration.FontFamily) + "\" is wrong.");

            Assert.AreEqual(expected, fontOverallConfiguration.DirectoryFontConfiguration.FontFamily,
                nameof(DirectoryFontConfiguration) + " Property \"" + nameof(DirectoryFontConfiguration.FontFamily) + "\" is wrong.");

            Assert.AreEqual(expected, fontOverallConfiguration.FileFontConfiguration.FontFamily,
                nameof(FileFontConfiguration) + " Property \"" + nameof(FileFontConfiguration.FontFamily) + "\" is wrong.");
        }



        [Test]
        public void SetFontStretch()
        {
            FontOverallConfiguration fontOverallConfiguration = CreateFontOverallConfiguration();

            var expected = FontStretches.Medium;
            fontOverallConfiguration.SetFontStrech(expected);

            Assert.AreEqual(expected, fontOverallConfiguration.DriveFontConfiguration.FontStretch,
                nameof(DriveFontConfiguration) + " Property \"" + nameof(DriveFontConfiguration.FontStretch) + "\" is wrong.");

            Assert.AreEqual(expected, fontOverallConfiguration.DirectoryFontConfiguration.FontStretch,
                nameof(DirectoryFontConfiguration) + " Property \"" + nameof(DirectoryFontConfiguration.FontStretch) + "\" is wrong.");

            Assert.AreEqual(expected, fontOverallConfiguration.FileFontConfiguration.FontStretch,
                nameof(FileFontConfiguration) + " Property \"" + nameof(FileFontConfiguration.FontStretch) + "\" is wrong.");
        }



        [Test]
        public void SetFontSize()
        {
            FontOverallConfiguration fontOverallConfiguration = CreateFontOverallConfiguration();

            var expected = 7800;
            fontOverallConfiguration.SetFontSize(expected);

            Assert.AreEqual(expected, fontOverallConfiguration.DriveFontConfiguration.FontSize,
                nameof(DriveFontConfiguration) + " Property \"" + nameof(DriveFontConfiguration.FontSize) + "\" is wrong.");

            Assert.AreEqual(expected, fontOverallConfiguration.DirectoryFontConfiguration.FontSize,
                nameof(DirectoryFontConfiguration) + " Property \"" + nameof(DirectoryFontConfiguration.FontSize) + "\" is wrong.");

            Assert.AreEqual(expected, fontOverallConfiguration.FileFontConfiguration.FontSize,
                nameof(FileFontConfiguration) + " Property \"" + nameof(FileFontConfiguration.FontSize) + "\" is wrong.");
        }



        [Test]
        public void SetFontStyle()
        {
            FontOverallConfiguration fontOverallConfiguration = CreateFontOverallConfiguration();

            var expected = FontStyles.Italic;
            fontOverallConfiguration.SetFontStyle(expected);

            Assert.AreEqual(expected, fontOverallConfiguration.DriveFontConfiguration.FontStyle,
                nameof(DriveFontConfiguration) + " Property \"" + nameof(DriveFontConfiguration.FontStyle) + "\" is wrong.");

            Assert.AreEqual(expected, fontOverallConfiguration.DirectoryFontConfiguration.FontStyle,
                nameof(DirectoryFontConfiguration) + " Property \"" + nameof(DirectoryFontConfiguration.FontStyle) + "\" is wrong.");

            Assert.AreEqual(expected, fontOverallConfiguration.FileFontConfiguration.FontStyle,
                nameof(FileFontConfiguration) + " Property \"" + nameof(FileFontConfiguration.FontStyle) + "\" is wrong.");
        }



        [Test]
        public void SetFontWeight()
        {
            FontOverallConfiguration fontOverallConfiguration = CreateFontOverallConfiguration();

            var expected = FontWeights.UltraBold;
            fontOverallConfiguration.SetFontWeight(expected);

            Assert.AreEqual(expected, fontOverallConfiguration.DriveFontConfiguration.FontWeight,
                nameof(DriveFontConfiguration) + " Property \"" + nameof(DriveFontConfiguration.FontWeight) + "\" is wrong.");

            Assert.AreEqual(expected, fontOverallConfiguration.DirectoryFontConfiguration.FontWeight,
                nameof(DirectoryFontConfiguration) + " Property \"" + nameof(DirectoryFontConfiguration.FontWeight) + "\" is wrong.");

            Assert.AreEqual(expected, fontOverallConfiguration.FileFontConfiguration.FontWeight,
                nameof(FileFontConfiguration) + " Property \"" + nameof(FileFontConfiguration.FontWeight) + "\" is wrong.");
        }




     
      
    }
}

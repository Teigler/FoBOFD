using ExplorerTree.API.Configuration;
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
    class FileConfigurationTest
    {

        private static FileConfiguration CreateFileConfiguration()
        {
            return new FileConfiguration(CreateFakeExplorerTreeVM());
        }


        private static FakeExplorerTreeViewModel CreateFakeExplorerTreeVM()
        {
            IConfiguration stubConfiguration = Substitute.For<IConfiguration>();
            IPresentationLogic stubPresentationLogic = Substitute.For<IPresentationLogic>();
            return new FakeExplorerTreeViewModel(stubConfiguration, stubPresentationLogic);
        }



        [Test]
        public void FileConfiguration_DefaultInitialisation_PropertyFontIsNull()
        {
            FileConfiguration fileConfiguration = new FileConfiguration();
            Assert.AreEqual(null, fileConfiguration.Font);
        }

        [Test]
        public void FileConfiguration_DefaultInitialisation_PropertyIconIsNull()
        {
            FileConfiguration fileConfiguration = new FileConfiguration();
            Assert.AreEqual(null, fileConfiguration.Icon);
        }



        [Test]
        public void FileConfiguration_Initialisation_PropertyFontIsInitialised()
        {
            FileConfiguration fileConfiguration = CreateFileConfiguration();
            Assert.AreEqual(true, fileConfiguration.Font is FileFontConfiguration);
        }

        [Test]
        public void FileConfiguration_Initialisation_PropertyIconIsInitialised()
        {
            FileConfiguration fileConfiguration = CreateFileConfiguration();
            Assert.AreEqual(true, fileConfiguration.Icon is FileIconConfiguration);
        }



        [Test]
        public void Font_SetGet_ReturnsSetValue()
        {
            FileConfiguration fileConfiguration = CreateFileConfiguration();

            var expectedMockFontConfiguration = Substitute.For<IExplorerTreeItemFontConfiguration>();
            fileConfiguration.Font = expectedMockFontConfiguration;

            Assert.AreEqual(expectedMockFontConfiguration, fileConfiguration.Font);
        }


        [Test]
        public void Icon_SetGet_ReturnsSetValue()
        {
            FileConfiguration fileConfiguration = CreateFileConfiguration();

            var expectedMockIconConfiguration = Substitute.For<IExplorerTreeItemIconConfiguration>();
            fileConfiguration.Icon = expectedMockIconConfiguration;

            Assert.AreEqual(expectedMockIconConfiguration, fileConfiguration.Icon);
        }

    }
}

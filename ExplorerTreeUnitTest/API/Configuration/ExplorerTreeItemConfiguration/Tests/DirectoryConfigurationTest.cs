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
    public class DirectoryConfigurationTest
    {


        private static DirectoryConfiguration CreateDirectoryConfiguration()
        {
            return new DirectoryConfiguration(CreateFakeExplorerTreeVM());
        }


        private static FakeExplorerTreeViewModel CreateFakeExplorerTreeVM()
        {
            IConfiguration stubConfiguration = Substitute.For<IConfiguration>();
            IPresentationLogic stubPresentationLogic = Substitute.For<IPresentationLogic>();
            return new FakeExplorerTreeViewModel(stubConfiguration, stubPresentationLogic);
        }


        [Test]
        public void DirectoryConfiguration_DefaultInitialisation_PropertyFontIsNull()
        {
            DirectoryConfiguration directoryConfiguration = new DirectoryConfiguration();
            Assert.AreEqual(null, directoryConfiguration.Font);
        }


        [Test]
        public void DirectoryConfiguration_DefaultInitialisation_PropertyIconIsNull()
        {
            DirectoryConfiguration directoryConfiguration = new DirectoryConfiguration();
            Assert.AreEqual(null, directoryConfiguration.Icon);
        }




        [Test]
        public void DirectoryConfiguration_Initialisation_PropertyFontIsInitialised()
        {
            DirectoryConfiguration directoryConfiguration = CreateDirectoryConfiguration();
            Assert.AreEqual(true, directoryConfiguration.Font is DirectoryFontConfiguration);
        }


        [Test]
        public void DirectoryConfiguration_Initialisation_PropertyIconIsInitialised()
        {
            DirectoryConfiguration directoryConfiguration = CreateDirectoryConfiguration();
            Assert.AreEqual(true, directoryConfiguration.Icon is DirectoryIconConfiguration);
        }




        [Test]
        public void Font_SetGet_ReturnsSetValue()
        {
            DirectoryConfiguration directoryConfiguration = CreateDirectoryConfiguration();

            var expectedMockFontConfiguration = Substitute.For<IExplorerTreeItemFontConfiguration>();
            directoryConfiguration.Font = expectedMockFontConfiguration;

            Assert.AreEqual(expectedMockFontConfiguration, directoryConfiguration.Font);
        }


        [Test]
        public void Icon_SetGet_ReturnsSetValue()
        {
            DirectoryConfiguration directoryConfiguration = CreateDirectoryConfiguration();

            var expectedMockIconConfiguration = Substitute.For<IExplorerTreeItemIconConfiguration>();
            directoryConfiguration.Icon = expectedMockIconConfiguration;

            Assert.AreEqual(expectedMockIconConfiguration, directoryConfiguration.Icon);
        }

    }
}

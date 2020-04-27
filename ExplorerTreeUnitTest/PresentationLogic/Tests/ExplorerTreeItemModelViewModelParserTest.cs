using ExplorerTree.API.Configuration;
using ExplorerTree.Model.ExplorerTreeItems;
using ExplorerTree.PresentationLogic;
using ExplorerTree.PresentationLogic.API;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeUnitTest.PresentationLogic.Tests
{
    [TestFixture]
    public class ExplorerTreeItemModelViewModelParserTest
    {

        private ExplorerTreeItemModelViewModelParser CreateExplorerTreeItemModelViewModelParser(IPresentationLogic fakePresentationLogic = null, IConfiguration fakeConfiguration = null)
        {
            fakePresentationLogic = fakePresentationLogic ?? CreateFakePresentationLogic();
            fakeConfiguration = fakeConfiguration ?? CreateFakeConfiguration();
            return new ExplorerTreeItemModelViewModelParser(fakePresentationLogic, fakeConfiguration);
        }


        private IPresentationLogic CreateFakePresentationLogic()
        {
            return Substitute.For<IPresentationLogic>();
        }

        private IConfiguration CreateFakeConfiguration()
        {
            return Substitute.For<IConfiguration>();
        }


        [Test]
        public void ExplorerTreeItemModelViewModelParser_DefaultInitialisation_PropertyPresentationLogicIsInitiallised()
        {
            var mockPresentationLogic =  CreateFakePresentationLogic();
            
            var explorerTreeItemModelViewModelParser = CreateExplorerTreeItemModelViewModelParser(mockPresentationLogic, null);

            Assert.AreEqual(mockPresentationLogic, explorerTreeItemModelViewModelParser.PresentationLogic);
        }

        [Test]
        public void ExplorerTreeItemModelViewModelParser_DefaultInitialisation_PropertyConfigurationIsInitiallised()
        {
            var mockConfiguration = CreateFakeConfiguration();

            var explorerTreeItemModelViewModelParser = CreateExplorerTreeItemModelViewModelParser(null, mockConfiguration);

            Assert.AreEqual(mockConfiguration, explorerTreeItemModelViewModelParser.Configuration);
        }


        // todo -> Jira FOB-12
        //[Test]
        //public void LoadAllDriveItemViewModels()
        //{

       
        //    var mockPresentationLogic = CreateFakePresentationLogic();
        //    var returnList = new List<DriveItemModel>();
        //    returnList.Add(Substitute.For<DriveItemModel>());
        //    mockPresentationLogic.LoadAllDriveItemModels().Returns(returnList);
        //    var explorerTreeItemModelViewModelParser = CreateExplorerTreeItemModelViewModelParser(mockPresentationLogic, null);

        //    explorerTreeItemModelViewModelParser.LoadAllDriveItemViewModels();
        //}

    }
}

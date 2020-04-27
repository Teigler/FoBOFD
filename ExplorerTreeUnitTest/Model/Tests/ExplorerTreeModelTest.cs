using ExplorerTree.Model;
using ExplorerTree.Model.ExplorerTreeItems;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeUnitTest.Model.Tests
{
    [TestFixture]
    public class ExplorerTreeModelTest
    {
        private ExplorerTreeModel CreateExplorerTreeModel()
        {
            return new ExplorerTreeModel();
        }



        [Test]
        public void ExplorerTreeModel_DefaultInitialisation_AllPropertiesAreInitialised()
        {
            var explorerTreeModel = CreateExplorerTreeModel();

            Assert.NotNull(explorerTreeModel.Drives, "Property: \"" + nameof(explorerTreeModel.Drives) + "\" was null!");
        }



        [Test]
        public void Drives_SetGet_ReturnSetValue()
        {
            var explorerTreeModel = CreateExplorerTreeModel();

            var expected = new List<DriveItemModel>();
            expected.Add(Substitute.For<DriveItemModel>());
            explorerTreeModel.Drives = expected;

            Assert.AreEqual(expected, explorerTreeModel.Drives);
        }
    }
}

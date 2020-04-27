using ExplorerTree.Model.ExplorerTreeItems;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeUnitTest.Model.ExplorerTreeItems.Tests
{
    [TestFixture]
    public class DirectoryItemModelTest
    {

        private DirectoryItemModel CreateDirectoryItemModel()
        {
            return new DirectoryItemModel();
        }

        [Test]
        public void DirectoryItemModel_DefaultInitialisation_AllPropertiesAreInitialised()
        {
            var directoryItemModel = CreateDirectoryItemModel();

            Assert.NotNull(directoryItemModel.Childs, "Property: \"" + nameof(directoryItemModel.Childs) + "\" was NOT initialised correctly!");
            Assert.AreEqual(null, directoryItemModel.DirectoryInfo, "Property: \"" + nameof(directoryItemModel.DirectoryInfo) + "\" was NOT null!");
            Assert.AreEqual("init", directoryItemModel.FullName, "Property: \"" + nameof(directoryItemModel.FullName) + "\" was NOT initialised correctly!");
            Assert.AreEqual(false, directoryItemModel.IsHidden, "Property: \"" + nameof(directoryItemModel.IsHidden) + "\" was NOT initialised correctly!");
            Assert.NotNull(directoryItemModel.IconModel, "Property: \"" + nameof(directoryItemModel.IconModel) + "\" was NOT initialised correctly!");
            Assert.AreEqual("init", directoryItemModel.Name, "Property: \"" + nameof(directoryItemModel.Name) + "\" was NOT initialised correctly!");
            Assert.AreEqual(null, directoryItemModel.ParentItem, "Property: \"" + nameof(directoryItemModel.ParentItem) + "\" was NOT null!");
        }



        [Test]
        public void Childs_SetGet_ReturnSetValue()
        {
            var directoryItemModel = CreateDirectoryItemModel();

            var expected = new List<AExplorerTreeChildItemModel>();
            expected.Add(Substitute.For<AExplorerTreeChildItemModel>());
            directoryItemModel.Childs = expected;

            Assert.AreEqual(expected, directoryItemModel.Childs);
        }

        [Test]
        public void FullName_SetGet_ReturnSetValue()
        {
            var directoryItemModel = CreateDirectoryItemModel();

            var expected = "TeschtenIschTroll";
            directoryItemModel.FullName = expected;

            Assert.AreEqual(expected, directoryItemModel.FullName);
        }

        [Test]
        public void IconModel_SetGet_ReturnSetValue()
        {
            var directoryItemModel = CreateDirectoryItemModel();

            var expected = Substitute.For<IconModel>(); ;
            directoryItemModel.IconModel = expected;

            Assert.AreEqual(expected, directoryItemModel.IconModel);
        }

        [Test]
        public void IsHidden_SetGet_ReturnSetValue()
        {
            var directoryItemModel = CreateDirectoryItemModel();

            var expected = true;
            directoryItemModel.IsHidden = expected;

            Assert.AreEqual(expected, directoryItemModel.IsHidden);
        }
        
        [Test]
        public void Name_SetGet_ReturnSetValue()
        {
            var directoryItemModel = CreateDirectoryItemModel();

            var expected = "TeschtenIschTroll";
            directoryItemModel.Name = expected;

            Assert.AreEqual(expected, directoryItemModel.Name);
        }

        [Test]
        public void ParentItem_SetGet_ReturnSetValue()
        {
            var directoryItemModel = CreateDirectoryItemModel();

            var expected = Substitute.For<AExplorerTreeChildItemModel>();
            directoryItemModel.ParentItem = expected;

            Assert.AreEqual(expected, directoryItemModel.ParentItem);
        }

    }
}

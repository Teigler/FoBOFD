using ExplorerTree.Model.ExplorerTreeItems;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeUnitTest.Model.ExplorerTreeItems.Tests
{
    [TestFixture]
    public class FileItemModelTest
    {

        private FileItemModel CreateFileItemModel()
        {
            return new FileItemModel();
        }

        [Test]
        public void FileItemModel_DefaultInitialisation_AllPropertiesAreInitialised()
        {
            var fileItemModel = CreateFileItemModel();

            Assert.NotNull(fileItemModel.Childs, "Property: \"" + nameof(fileItemModel.Childs) + "\" was NOT initialised correctly!");
            Assert.AreEqual(null, fileItemModel.FileInfo, "Property: \"" + nameof(fileItemModel.FileInfo) + "\" was NOT null!");
            Assert.AreEqual("init", fileItemModel.FullName, "Property: \"" + nameof(fileItemModel.FullName) + "\" was NOT initialised correctly!");
            Assert.AreEqual(false, fileItemModel.IsHidden, "Property: \"" + nameof(fileItemModel.IsHidden) + "\" was NOT initialised correctly!");
            Assert.NotNull(fileItemModel.IconModel, "Property: \"" + nameof(fileItemModel.IconModel) + "\" was NOT initialised correctly!");
            Assert.AreEqual("init", fileItemModel.Name, "Property: \"" + nameof(fileItemModel.Name) + "\" was NOT initialised correctly!");
            Assert.AreEqual(null, fileItemModel.ParentItem, "Property: \"" + nameof(fileItemModel.ParentItem) + "\" was NOT null!");
        }



        [Test]
        public void Childs_SetGet_ReturnSetValue()
        {
            var fileItemModel = CreateFileItemModel();

            var expected = new List<AExplorerTreeChildItemModel>();
            expected.Add(Substitute.For<AExplorerTreeChildItemModel>());
            fileItemModel.Childs = expected;

            Assert.AreEqual(expected, fileItemModel.Childs);
        }

        [Test]
        public void FullName_SetGet_ReturnSetValue()
        {
            var fileItemModel = CreateFileItemModel();

            var expected = "TeschtenIschTroll";
            fileItemModel.FullName = expected;

            Assert.AreEqual(expected, fileItemModel.FullName);
        }

        [Test]
        public void IconModel_SetGet_ReturnSetValue()
        {
            var fileItemModel = CreateFileItemModel();

            var expected = Substitute.For<IconModel>(); ;
            fileItemModel.IconModel = expected;

            Assert.AreEqual(expected, fileItemModel.IconModel);
        }

        [Test]
        public void IsHidden_SetGet_ReturnSetValue()
        {
            var fileItemModel = CreateFileItemModel();

            var expected = true;
            fileItemModel.IsHidden = expected;

            Assert.AreEqual(expected, fileItemModel.IsHidden);
        }

        [Test]
        public void Name_SetGet_ReturnSetValue()
        {
            var fileItemModel = CreateFileItemModel();

            var expected = "TeschtenIschTroll";
            fileItemModel.Name = expected;

            Assert.AreEqual(expected, fileItemModel.Name);
        }

        [Test]
        public void ParentItem_SetGet_ReturnSetValue()
        {
            var fileItemModel = CreateFileItemModel();

            var expected = Substitute.For<AExplorerTreeChildItemModel>();
            fileItemModel.ParentItem = expected;

            Assert.AreEqual(expected, fileItemModel.ParentItem);
        }

    }
}

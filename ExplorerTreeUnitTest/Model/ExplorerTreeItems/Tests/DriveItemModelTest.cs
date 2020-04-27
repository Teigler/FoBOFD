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
    public class DriveItemModelTest
    {
        private DriveItemModel CreateDriveItemModel()
        {
            return new DriveItemModel();
        }

        [Test]
        public void DriveItemModel_DefaultInitialisation_AllPropertiesAreInitialised()
        {
            var driveItemModel = CreateDriveItemModel();

            Assert.NotNull(driveItemModel.Childs, "Property: \"" + nameof(driveItemModel.Childs) + "\" was NOT initialised correctly!");
            Assert.AreEqual(null, driveItemModel.DriveInfo, "Property: \"" + nameof(driveItemModel.DriveInfo) + "\" was NOT null!");
            Assert.AreEqual(DriveType.Unknown, driveItemModel.DriveType, "Property: \"" + nameof(driveItemModel.DriveType) + "\" was NOT initialised correctly!");
            Assert.NotNull(driveItemModel.IconModel, "Property: \"" + nameof(driveItemModel.IconModel) + "\" was NOT initialised correctly!");
            Assert.AreEqual("init", driveItemModel.Name, "Property: \"" + nameof(driveItemModel.Name) + "\" was NOT initialised correctly!");
        }



        [Test]
        public void Childs_SetGet_ReturnSetValue()
        {
            var driveItemModel = CreateDriveItemModel();

            var expected = new List<AExplorerTreeChildItemModel>();
            expected.Add(Substitute.For<AExplorerTreeChildItemModel>());
            driveItemModel.Childs = expected;

            Assert.AreEqual(expected, driveItemModel.Childs);
        }

        [Test]
        public void DriveType_SetGet_ReturnSetValue()
        {
            var driveItemModel = CreateDriveItemModel();

            var expected = DriveType.NoRootDirectory;
            driveItemModel.DriveType = expected;

            Assert.AreEqual(expected, driveItemModel.DriveType);
        }

        [Test]
        public void IconModel_SetGet_ReturnSetValue()
        {
            var driveItemModel = CreateDriveItemModel();

            var expected = Substitute.For<IconModel>(); ;
            driveItemModel.IconModel = expected;

            Assert.AreEqual(expected, driveItemModel.IconModel);
        }

        [Test]
        public void Name_SetGet_ReturnSetValue()
        {
            var driveItemModel = CreateDriveItemModel();

            var expected = "TeschtenIschTroll";
            driveItemModel.Name = expected;

            Assert.AreEqual(expected, driveItemModel.Name);
        }
    }
}

using ExplorerTree.API.Configuration.AvailabilityConfiguration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeUnitTest.API.Configuration.AvailabilityConfiguration.Tests
{
    [TestFixture]
    public class ActivatableDriveTypeTest
    {
        private ActivatableDriveType CreateDefaultActivatableDriveType()
        {
            return new ActivatableDriveType();
        }

        [Test]
        public void ActivatableDriveType_DefaultInitialisation_DriveTypeIsUnknown()
        {
            ActivatableDriveType activatableDriveType = CreateDefaultActivatableDriveType();
            Assert.AreEqual(DriveType.Unknown, activatableDriveType.DriveType);
        }

        [Test]
        public void ActivatableDriveType_DefaultInitialisation_IsActiveIsTrue()
        {
            ActivatableDriveType activatableDriveType = CreateDefaultActivatableDriveType();
            Assert.AreEqual(true, activatableDriveType.IsActive);
        }

        [Test]
        public void DriveType_SetGet_ReturnsTheSetValue()
        {
            ActivatableDriveType activatableDriveType = CreateDefaultActivatableDriveType();
            activatableDriveType.DriveType = DriveType.CDRom;
            Assert.AreEqual(DriveType.CDRom, activatableDriveType.DriveType);
        }

        [Test]
        public void IsActive_SetGet_ReturnsTheSetValue()
        {
            ActivatableDriveType activatableDriveType = CreateDefaultActivatableDriveType();
            activatableDriveType.IsActive = false;
            Assert.AreEqual(false, activatableDriveType.IsActive);
        }



    }
}

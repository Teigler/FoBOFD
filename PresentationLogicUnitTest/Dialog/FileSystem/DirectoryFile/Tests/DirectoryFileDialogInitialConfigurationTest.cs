using ExplorerTree.API.Configuration;
using FoBOFD.PresentationLogic.Dialog.FileSystem.DirectoryFile;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLogicUnitTest.Dialog.Operation.Tests
{
    [TestFixture]
    public class DirectoryFileDialogInitialConfigurationTest
    {
        private DirectoryFileDialogInitialConfiguration DirectoryFileDialogConfigurator()
        {
            var fakeConfiguration = Substitute.For<IConfiguration>();
            return new DirectoryFileDialogInitialConfiguration(fakeConfiguration);
        }



        [Test]
        public void DirectoryFileDialogConfigurator_DefaultInitialisation_AllePropertiesAreInitiallised()
        {

        }
    }
}

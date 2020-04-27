using ExplorerTree.API;
using FoBOFD.PresentationLogic.Dialog.FileSystem.DirectoryFile;
using FoBOFD.PresentationLogic.Dialog.Operation;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PresentationLogicUnitTest.Dialog.FileSystem.DirectoryFile.Tests
{
    [TestFixture]
    public class DirectoryFileDialogViewModelTest
    {
        private DirectoryFileDialogOperationPanelViewModel mockOperationPanel;

        private DirectoryFileDialogViewModel CreateStandardDirectoryFileDialogViewModel()
        {
            return new DirectoryFileDialogViewModel(null, null, null);
        }

        private DirectoryFileDialogViewModel CreateTestableDirectoryFileDialogViewModel(
            DirectoryFileDialogOperationPanelViewModel fakeOperationPanel = null,
            IExplorerTree fakeExplorerTree = null,
            IDirectoryFileDialogConfiguration fakeInitialConfiguration = null)
        {
            var dialogOperationVM = new DefaultDialogOperationViewModel();
            fakeOperationPanel = fakeOperationPanel ?? Substitute.For<DirectoryFileDialogOperationPanelViewModel>(dialogOperationVM);
            fakeExplorerTree = fakeExplorerTree ?? Substitute.For<IExplorerTree >();
            fakeInitialConfiguration = fakeInitialConfiguration ?? Substitute.For<IDirectoryFileDialogConfiguration>();
            return new DirectoryFileDialogViewModel(fakeOperationPanel, fakeExplorerTree, fakeInitialConfiguration);
        }





        [Test]
        public void DirectoryFileDialogViewModel_StandardInitialisation_AllPropertiesAreInitialised()
        {
            var directoryFileDialogVM = CreateStandardDirectoryFileDialogViewModel();


            Assert.NotNull(directoryFileDialogVM.OperationPanel,
                "Property: \"" + nameof(directoryFileDialogVM.OperationPanel) + "\" was NOT null");
            Assert.NotNull(directoryFileDialogVM.ExplorerTree,
                "Property: \"" + nameof(directoryFileDialogVM.ExplorerTree) + "\" was NOT null!");
            Assert.NotNull(directoryFileDialogVM.ExplorerTreeVM,
                "Property: \"" + nameof(directoryFileDialogVM.ExplorerTreeVM) + "\" was NOT null!");
            Assert.NotNull(directoryFileDialogVM.DirectoryFileDialogConfigurator,
                "Property: \"" + nameof(directoryFileDialogVM.DirectoryFileDialogConfigurator) + "\" was NOT null!");
            Assert.AreEqual(Visibility.Collapsed, directoryFileDialogVM.Visibility,
                "Property: \"" + nameof(directoryFileDialogVM.Visibility) + "\" was NOT initialised correctly!");
        }



        [Test]
        public void DirectoryFileDialogViewModel_TestableInitialisation_PropertyOperationPanelIsInitialised()
        {
            var dialogOperationVM = new DefaultDialogOperationViewModel();
            mockOperationPanel = Substitute.For<DirectoryFileDialogOperationPanelViewModel>(dialogOperationVM);
            
            var directoryFileDialogVM = CreateTestableDirectoryFileDialogViewModel(mockOperationPanel, null, null);


            Assert.AreEqual(mockOperationPanel, directoryFileDialogVM.OperationPanel);
        }


        [Test]
        public void DirectoryFileDialogViewModel_TestableInitialisation_PropertyExplorerTreeIsInitialised()
        {
            var mockExplorerTree = Substitute.For<IExplorerTree>();
            
            var directoryFileDialogVM = CreateTestableDirectoryFileDialogViewModel(null, mockExplorerTree, null);


            Assert.AreEqual(mockExplorerTree, directoryFileDialogVM.ExplorerTree);
        }

        [Test]
        public void DirectoryFileDialogViewModel_TestableInitialisation_PropertyDirectoryFileDialogConfiguratorIsInitialised()
        {
            var mockInitialConfiguration = Substitute.For<IDirectoryFileDialogConfiguration>();

            var directoryFileDialogVM = CreateTestableDirectoryFileDialogViewModel(null, null, mockInitialConfiguration);


            Assert.AreEqual(mockInitialConfiguration, directoryFileDialogVM.DirectoryFileDialogConfigurator);
        }





        [Test]
        public void Visibility_SetGet_ReturnSetValue()
        {
            var directoryFileDialogVM = CreateTestableDirectoryFileDialogViewModel();

            var expected = Visibility.Hidden;
            directoryFileDialogVM.Visibility = expected;

            Assert.AreEqual(expected, directoryFileDialogVM.Visibility);
        }

        [Test]
        public void Visibility_OnPropertyChanged_FiredPropertyChanged()
        {
            var directoryFileDialogVM = CreateTestableDirectoryFileDialogViewModel();
            bool propertyChangedWasFired = false;
            directoryFileDialogVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            var expected = Visibility.Hidden;
            directoryFileDialogVM.Visibility = expected;

            Assert.IsTrue(propertyChangedWasFired);
        }

        [Test]
        public void Visibility_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var directoryFileDialogVM = CreateTestableDirectoryFileDialogViewModel();
            bool propertyChangedWasFired = false;
            directoryFileDialogVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            directoryFileDialogVM.Visibility = directoryFileDialogVM.Visibility;

            Assert.IsFalse(propertyChangedWasFired);
        }
    }
}

using FoBOFD.PresentationLogic.Dialog.Operation;
using FoBOFD.PresentationLogic.GeneralControls.SelectionControls.Button;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PresentationLogicUnitTest.Dialog.Operation.Tests
{
    [TestFixture]
    public class DirectoryFileDialogOperationPanelViewModelTest
    {

        private DirectoryFileDialogOperationPanelViewModel CreateDirectoryFileDialogOperationPanelVM()
        {
            return new DirectoryFileDialogOperationPanelViewModel();
        }

        private DirectoryFileDialogOperationPanelViewModel CreateTestableDirectoryFileDialogOperationPanelVM(
            DefaultDialogOperationViewModel fakeDefaultDialogOperationVM = null)
        {
            fakeDefaultDialogOperationVM = fakeDefaultDialogOperationVM ?? CreateFakeDefaultDialogOperationVM();
            return new DirectoryFileDialogOperationPanelViewModel(fakeDefaultDialogOperationVM);
        }


        private DefaultDialogOperationViewModel CreateFakeDefaultDialogOperationVM()
        {
            var fakeDefaultDialogOperationVM = Substitute.For<DefaultDialogOperationViewModel>();

            var fakeAgreeSelectionField = Substitute.For<ButtonViewModel>();
            fakeDefaultDialogOperationVM.AgreeSelectionField.Returns(fakeAgreeSelectionField);

            var fakeDisagreeSelectionField = Substitute.For<ButtonViewModel>();
            fakeDefaultDialogOperationVM.DisagreeSelectionField.Returns(fakeDisagreeSelectionField);

            var fakeNewDirectorySelectionField = Substitute.For<ButtonViewModel>();
            fakeDefaultDialogOperationVM.NewDirectorySelectionField.Returns(fakeNewDirectorySelectionField);

            return fakeDefaultDialogOperationVM;
        }


        [Test]
        public void DirectoryFileDialogOperationPanelViewModel_DefaultInitialisation_DefaultDialogOperationIsNotNull()
        {
            var directorFileDialogOperationPanelVM = CreateDirectoryFileDialogOperationPanelVM();


            Assert.NotNull(directorFileDialogOperationPanelVM.DefaultDialogOperation,
                "Property: " + nameof(directorFileDialogOperationPanelVM.DefaultDialogOperation) + "\" was null.");
        }



        [Test]
        public void DirectoryFileDialogOperationPanelViewModel_Initialisation_DefaultDialogOperationIsNotNull()
        {
            var mockDefaultDialogOperationVM = CreateFakeDefaultDialogOperationVM();

            var directorFileDialogOperationPanelVM = CreateTestableDirectoryFileDialogOperationPanelVM(mockDefaultDialogOperationVM);


            Assert.AreEqual(mockDefaultDialogOperationVM, directorFileDialogOperationPanelVM.DefaultDialogOperation);
        }


        [Test]
        public void DirectoryFileDialogOperationPanelViewModel_Initialisation_DefaultDialogOperationAgreeSelectionFieldPropertyContentIsInitiallised()
        {
            var stubDefaultDialogOperationVM = CreateFakeDefaultDialogOperationVM();

            var directorFileDialogOperationPanelVM = CreateTestableDirectoryFileDialogOperationPanelVM(stubDefaultDialogOperationVM);

            directorFileDialogOperationPanelVM.DefaultDialogOperation.AgreeSelectionField.Received().Content = "OK";
        }


        [Test]
        public void DirectoryFileDialogOperationPanelViewModel_Initialisation_DefaultDialogOperationDisgreeSelectionFieldPropertyContentIsInitiallised()
        {
            var stubDefaultDialogOperationVM = CreateFakeDefaultDialogOperationVM();

            var directorFileDialogOperationPanelVM = CreateTestableDirectoryFileDialogOperationPanelVM(stubDefaultDialogOperationVM);

            directorFileDialogOperationPanelVM.DefaultDialogOperation.DisagreeSelectionField.Received().Content = "Cancel";
        }


        [Test]
        public void DirectoryFileDialogOperationPanelViewModel_Initialisation_DefaultDialogOperationNewDirectorySelectionFieldPropertyContentIsInitiallised()
        {
            var stubDefaultDialogOperationVM = CreateFakeDefaultDialogOperationVM();

            var directorFileDialogOperationPanelVM = CreateTestableDirectoryFileDialogOperationPanelVM(stubDefaultDialogOperationVM);

            directorFileDialogOperationPanelVM.DefaultDialogOperation.NewDirectorySelectionField.Received().Content = "New Folder";
        }



        [Test]
        public void DirectoryFileDialogOperationPanelViewModel_Initialisation_DefaultDialogOperationNewDirectorySelectionFieldPropertyVisibilityIsInitiallised()
        {
            var stubDefaultDialogOperationVM = CreateFakeDefaultDialogOperationVM();

            var directorFileDialogOperationPanelVM = CreateTestableDirectoryFileDialogOperationPanelVM(stubDefaultDialogOperationVM);

            directorFileDialogOperationPanelVM.DefaultDialogOperation.NewDirectorySelectionField.Received().Visibility = Visibility.Collapsed;
        }




        [Test]
        public void NewFolderSelectionFieldSelected_NotImplemented_ThrowsException()
        {

            var directorFileDialogOperationPanelVM = CreateTestableDirectoryFileDialogOperationPanelVM(null);

            Assert.Throws<NotImplementedException>(() => directorFileDialogOperationPanelVM.NewFolderSelectionFieldSelected(new object()));
        }



        [Test]
        public void DefaultDialogOperation_SetGet_ReturnSetValue()
        {
            var directorFileDialogOperationPanelVM = CreateTestableDirectoryFileDialogOperationPanelVM(null);

            var expected = Substitute.For<DefaultDialogOperationViewModel>();
            directorFileDialogOperationPanelVM.DefaultDialogOperation = expected;

            Assert.AreEqual(expected, directorFileDialogOperationPanelVM.DefaultDialogOperation);
        }

        [Test]
        public void DefaultDialogOperation_OnPropertyChanged_FiredPropertyChanged()
        {
            var directorFileDialogOperationPanelVM = CreateTestableDirectoryFileDialogOperationPanelVM(null);
            bool propertyChangedWasFired = false;
            directorFileDialogOperationPanelVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            var expected = Substitute.For<DefaultDialogOperationViewModel>();
            directorFileDialogOperationPanelVM.DefaultDialogOperation = expected;

            Assert.IsTrue(propertyChangedWasFired);
        }

        [Test]
        public void DefaultDialogOperation_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var directorFileDialogOperationPanelVM = CreateTestableDirectoryFileDialogOperationPanelVM(null);
            bool propertyChangedWasFired = false;
            directorFileDialogOperationPanelVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            directorFileDialogOperationPanelVM.DefaultDialogOperation = directorFileDialogOperationPanelVM.DefaultDialogOperation;

            Assert.IsFalse(propertyChangedWasFired);
        }



    }
}

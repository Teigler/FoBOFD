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
    public class FileDialogOperationPanelViewModelTest
    {

        private FileDialogOperationPanelViewModel CreateFileDialogOperationPanelVM()
        {
            return new FileDialogOperationPanelViewModel();
        }

        private FileDialogOperationPanelViewModel CreateTestableFileDialogOperationPanelVM(
            DefaultDialogOperationViewModel fakeDefaultDialogOperationVM = null)
        {
            fakeDefaultDialogOperationVM = fakeDefaultDialogOperationVM ?? CreateFakeDefaultDialogOperationVM();
            return new FileDialogOperationPanelViewModel(fakeDefaultDialogOperationVM);
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
        public void FileDialogOperationPanelViewModel_DefaultInitialisation_DefaultDialogOperationIsNotNull()
        {
            var fileDialogOperationPanelVM = CreateFileDialogOperationPanelVM();


            Assert.NotNull(fileDialogOperationPanelVM.DefaultDialogOperation,
                "Property: " + nameof(fileDialogOperationPanelVM.DefaultDialogOperation) + "\" was null.");
        }



        [Test]
        public void FileDialogOperationPanelViewModel_Initialisation_DefaultDialogOperationIsNotNull()
        {
            var mockDefaultDialogOperationVM = CreateFakeDefaultDialogOperationVM();

            var fileDialogOperationPanelVM = CreateTestableFileDialogOperationPanelVM(mockDefaultDialogOperationVM);


            Assert.AreEqual(mockDefaultDialogOperationVM, fileDialogOperationPanelVM.DefaultDialogOperation);
        }


        [Test]
        public void FileDialogOperationPanelViewModel_Initialisation_DefaultDialogOperationAgreeSelectionFieldPropertyContentIsInitiallised()
        {
            var stubDefaultDialogOperationVM = CreateFakeDefaultDialogOperationVM();

            var fileDialogOperationPanelVM = CreateTestableFileDialogOperationPanelVM(stubDefaultDialogOperationVM);

            fileDialogOperationPanelVM.DefaultDialogOperation.AgreeSelectionField.Received().Content = "OK";
        }


        [Test]
        public void FileDialogOperationPanelViewModel_Initialisation_DefaultDialogOperationDisgreeSelectionFieldPropertyContentIsInitiallised()
        {
            var stubDefaultDialogOperationVM = CreateFakeDefaultDialogOperationVM();

            var fileDialogOperationPanelVM = CreateTestableFileDialogOperationPanelVM(stubDefaultDialogOperationVM);

            fileDialogOperationPanelVM.DefaultDialogOperation.DisagreeSelectionField.Received().Content = "Cancel";
        }


        [Test]
        public void FileDialogOperationPanelViewModel_Initialisation_DefaultDialogOperationNewDirectorySelectionFieldPropertyContentIsInitiallised()
        {
            var stubDefaultDialogOperationVM = CreateFakeDefaultDialogOperationVM();

            var fileDialogOperationPanelVM = CreateTestableFileDialogOperationPanelVM(stubDefaultDialogOperationVM);

            fileDialogOperationPanelVM.DefaultDialogOperation.NewDirectorySelectionField.Received().Content = "New Folder";
        }



        [Test]
        public void FileDialogOperationPanelViewModel_Initialisation_DefaultDialogOperationNewDirectorySelectionFieldPropertyVisibilityIsInitiallised()
        {
            var stubDefaultDialogOperationVM = CreateFakeDefaultDialogOperationVM();

            var fileDialogOperationPanelVM = CreateTestableFileDialogOperationPanelVM(stubDefaultDialogOperationVM);

            fileDialogOperationPanelVM.DefaultDialogOperation.NewDirectorySelectionField.Received().Visibility = Visibility.Collapsed;
        }




        [Test]
        public void NewFolderSelectionFieldSelected_NotImplemented_ThrowsException()
        {

            var fileDialogOperationPanelVM = CreateTestableFileDialogOperationPanelVM(null);

            Assert.Throws<NotImplementedException>(() => fileDialogOperationPanelVM.NewFolderSelectionFieldSelected(new object()));
        }



        [Test]
        public void DefaultDialogOperation_SetGet_ReturnSetValue()
        {
            var fileDialogOperationPanelVM = CreateTestableFileDialogOperationPanelVM(null);

            var expected = Substitute.For<DefaultDialogOperationViewModel>();
            fileDialogOperationPanelVM.DefaultDialogOperation = expected;

            Assert.AreEqual(expected, fileDialogOperationPanelVM.DefaultDialogOperation);
        }

        [Test]
        public void DefaultDialogOperation_OnPropertyChanged_FiredPropertyChanged()
        {
            var fileDialogOperationPanelVM = CreateTestableFileDialogOperationPanelVM(null);
            bool propertyChangedWasFired = false;
            fileDialogOperationPanelVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            var expected = Substitute.For<DefaultDialogOperationViewModel>();
            fileDialogOperationPanelVM.DefaultDialogOperation = expected;

            Assert.IsTrue(propertyChangedWasFired);
        }

        [Test]
        public void DefaultDialogOperation_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var fileDialogOperationPanelVM = CreateTestableFileDialogOperationPanelVM(null);
            bool propertyChangedWasFired = false;
            fileDialogOperationPanelVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            fileDialogOperationPanelVM.DefaultDialogOperation = fileDialogOperationPanelVM.DefaultDialogOperation;

            Assert.IsFalse(propertyChangedWasFired);
        }
    }
}

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
    public class DirectoryDialogOperationPanelViewModelTest
    {
        private DirectoryDialogOperationPanelViewModel CreateDirectoryDialogOperationPanelVM()
        {
            return new DirectoryDialogOperationPanelViewModel();
        }

        private DirectoryDialogOperationPanelViewModel CreateTestableDirectoryDialogOperationPanelVM(
            DefaultDialogOperationViewModel fakeDefaultDialogOperationVM = null)
        {
            fakeDefaultDialogOperationVM = fakeDefaultDialogOperationVM ?? CreateFakeDefaultDialogOperationVM();
            return new DirectoryDialogOperationPanelViewModel(fakeDefaultDialogOperationVM);
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
        public void DirectoryDialogOperationPanelViewModel_DefaultInitialisation_DefaultDialogOperationIsNotNull()
        {
            var directorDialogOperationPanelVM = CreateDirectoryDialogOperationPanelVM();


            Assert.NotNull(directorDialogOperationPanelVM.DefaultDialogOperation,
                "Property: " + nameof(directorDialogOperationPanelVM.DefaultDialogOperation) + "\" was null.");
        }



        [Test]
        public void DirectoryDialogOperationPanelViewModel_Initialisation_DefaultDialogOperationIsNotNull()
        {
            var mockDefaultDialogOperationVM = CreateFakeDefaultDialogOperationVM();

            var directorDialogOperationPanelVM = CreateTestableDirectoryDialogOperationPanelVM(mockDefaultDialogOperationVM);


            Assert.AreEqual(mockDefaultDialogOperationVM, directorDialogOperationPanelVM.DefaultDialogOperation);
        }


        [Test]
        public void DirectoryDialogOperationPanelViewModel_Initialisation_DefaultDialogOperationAgreeSelectionFieldPropertyContentIsInitiallised()
        {
            var stubDefaultDialogOperationVM = CreateFakeDefaultDialogOperationVM();

            var directorDialogOperationPanelVM = CreateTestableDirectoryDialogOperationPanelVM(stubDefaultDialogOperationVM);

            directorDialogOperationPanelVM.DefaultDialogOperation.AgreeSelectionField.Received().Content = "OK";
        }


        [Test]
        public void DirectoryDialogOperationPanelViewModel_Initialisation_DefaultDialogOperationDisgreeSelectionFieldPropertyContentIsInitiallised()
        {
            var stubDefaultDialogOperationVM = CreateFakeDefaultDialogOperationVM();

            var directorDialogOperationPanelVM = CreateTestableDirectoryDialogOperationPanelVM(stubDefaultDialogOperationVM);

            directorDialogOperationPanelVM.DefaultDialogOperation.DisagreeSelectionField.Received().Content = "Cancel";
        }


        [Test]
        public void DirectoryDialogOperationPanelViewModel_Initialisation_DefaultDialogOperationNewDirectorySelectionFieldPropertyContentIsInitiallised()
        {
            var stubDefaultDialogOperationVM = CreateFakeDefaultDialogOperationVM();

            var directorDialogOperationPanelVM = CreateTestableDirectoryDialogOperationPanelVM(stubDefaultDialogOperationVM);

            directorDialogOperationPanelVM.DefaultDialogOperation.NewDirectorySelectionField.Received().Content = "New Folder";
        }



        [Test]
        public void DirectoryDialogOperationPanelViewModel_Initialisation_DefaultDialogOperationNewDirectorySelectionFieldPropertyVisibilityIsInitiallised()
        {
            var stubDefaultDialogOperationVM = CreateFakeDefaultDialogOperationVM();

            var directorDialogOperationPanelVM = CreateTestableDirectoryDialogOperationPanelVM(stubDefaultDialogOperationVM);

            directorDialogOperationPanelVM.DefaultDialogOperation.NewDirectorySelectionField.Received().Visibility = Visibility.Collapsed;
        }




        [Test]
        public void NewFolderSelectionFieldSelected_NotImplemented_ThrowsException()
        {

            var directorDialogOperationPanelVM = CreateTestableDirectoryDialogOperationPanelVM(null);

            Assert.Throws<NotImplementedException>( () => directorDialogOperationPanelVM.NewFolderSelectionFieldSelected(new object()));
        }



        [Test]
        public void DefaultDialogOperation_SetGet_ReturnSetValue()
        {
            var directorDialogOperationPanelVM = CreateTestableDirectoryDialogOperationPanelVM(null);

            var expected = Substitute.For<DefaultDialogOperationViewModel>();
            directorDialogOperationPanelVM.DefaultDialogOperation = expected;

            Assert.AreEqual(expected, directorDialogOperationPanelVM.DefaultDialogOperation);
        }

        [Test]
        public void DefaultDialogOperation_OnPropertyChanged_FiredPropertyChanged()
        {
            var directorDialogOperationPanelVM = CreateTestableDirectoryDialogOperationPanelVM(null);
            bool propertyChangedWasFired = false;
            directorDialogOperationPanelVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            var expected = Substitute.For<DefaultDialogOperationViewModel>();
            directorDialogOperationPanelVM.DefaultDialogOperation = expected;

            Assert.IsTrue(propertyChangedWasFired);
        }

        [Test]
        public void DefaultDialogOperation_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var directorDialogOperationPanelVM = CreateTestableDirectoryDialogOperationPanelVM(null);
            bool propertyChangedWasFired = false;
            directorDialogOperationPanelVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            directorDialogOperationPanelVM.DefaultDialogOperation = directorDialogOperationPanelVM.DefaultDialogOperation;

            Assert.IsFalse(propertyChangedWasFired);
        }





    }
}

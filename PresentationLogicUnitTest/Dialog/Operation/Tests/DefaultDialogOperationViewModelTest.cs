using FoBOFD.PresentationLogic.Dialog.Operation;
using FoBOFD.PresentationLogic.GeneralControls.SelectionControls.Button;
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
    public class DefaultDialogOperationViewModelTest
    {

        private DefaultDialogOperationViewModel CreateTestDialogOperationVM(ButtonViewModel fakeButtonViewModel = null)
        {
            fakeButtonViewModel = fakeButtonViewModel ?? Substitute.For<ButtonViewModel>();
            return new DefaultDialogOperationViewModel(fakeButtonViewModel);
        }

        private DefaultDialogOperationViewModel CreateDialogOperationsVM()
        {
            return new DefaultDialogOperationViewModel();
        }



        [Test]
        public void DefaultDialogOperationViewModel_TestInitialisation_AllPropertiesAreInitialised()
        {
            var fakeButtonViewModel = Substitute.For<ButtonViewModel>();
            var defaultDialogOperationVM = CreateTestDialogOperationVM(fakeButtonViewModel);

            Assert.AreEqual(fakeButtonViewModel, defaultDialogOperationVM.AgreeSelectionField,
                "Property: " + nameof(defaultDialogOperationVM.AgreeSelectionField) + "\" was NOT initialised correctly.");
            Assert.AreEqual(fakeButtonViewModel, defaultDialogOperationVM.DisagreeSelectionField,
                "Property: " + nameof(defaultDialogOperationVM.DisagreeSelectionField) + "\" was NOT initialised correctly.");
            Assert.AreEqual(fakeButtonViewModel, defaultDialogOperationVM.NewDirectorySelectionField,
                "Property: " + nameof(defaultDialogOperationVM.NewDirectorySelectionField) + "\" was NOT initialised correctly.");
        }


        [Test]
        public void DefaultDialogOperationViewModel_DefaultInitialisation_AllPropertiesAreInitialised()
        {
            var defaultDialogOperationVM = CreateDialogOperationsVM();

            Assert.NotNull(defaultDialogOperationVM.AgreeSelectionField,
                "Property: " + nameof(defaultDialogOperationVM.AgreeSelectionField) + "\" was null.");
            Assert.NotNull(defaultDialogOperationVM.DisagreeSelectionField,
                "Property: " + nameof(defaultDialogOperationVM.DisagreeSelectionField) + "\" was null.");
            Assert.NotNull(defaultDialogOperationVM.NewDirectorySelectionField, 
                "Property: " + nameof(defaultDialogOperationVM.NewDirectorySelectionField) + "\" was null.");
        }





        [Test]
        public void AgreeSelectionField_SetGet_ReturnSetValue()
        {
            var defaultDialogOperationsVM = CreateTestDialogOperationVM();

            var expected = Substitute.For<ButtonViewModel>();
            defaultDialogOperationsVM.AgreeSelectionField = expected;

            Assert.AreEqual(expected, defaultDialogOperationsVM.AgreeSelectionField);
        }

        [Test]
        public void AgreeSelectionField_OnPropertyChanged_FiredPropertyChanged()
        {
            var defaultDialogOperationsVM = CreateTestDialogOperationVM();
            bool propertyChangedWasFired = false;
            defaultDialogOperationsVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            var expected = Substitute.For<ButtonViewModel>();
            defaultDialogOperationsVM.AgreeSelectionField = expected;

            Assert.IsTrue(propertyChangedWasFired);
        }

        [Test]
        public void AgreeSelectionField_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var defaultDialogOperationsVM = CreateTestDialogOperationVM();
            bool propertyChangedWasFired = false;
            defaultDialogOperationsVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            defaultDialogOperationsVM.AgreeSelectionField = defaultDialogOperationsVM.AgreeSelectionField;

            Assert.IsFalse(propertyChangedWasFired);
        }





        [Test]
        public void DisagreeSelectionField_SetGet_ReturnSetValue()
        {
            var defaultDialogOperationsVM = CreateTestDialogOperationVM();

            var expected = Substitute.For<ButtonViewModel>();
            defaultDialogOperationsVM.DisagreeSelectionField = expected;

            Assert.AreEqual(expected, defaultDialogOperationsVM.DisagreeSelectionField);
        }

        [Test]
        public void DisagreeSelectionField_OnPropertyChanged_FiredPropertyChanged()
        {
            var defaultDialogOperationsVM = CreateTestDialogOperationVM();
            bool propertyChangedWasFired = false;
            defaultDialogOperationsVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            var expected = Substitute.For<ButtonViewModel>();
            defaultDialogOperationsVM.DisagreeSelectionField = expected;

            Assert.IsTrue(propertyChangedWasFired);
        }

        [Test]
        public void DisagreeSelectionField_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var defaultDialogOperationsVM = CreateTestDialogOperationVM();
            bool propertyChangedWasFired = false;
            defaultDialogOperationsVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            defaultDialogOperationsVM.DisagreeSelectionField = defaultDialogOperationsVM.DisagreeSelectionField;

            Assert.IsFalse(propertyChangedWasFired);
        }







        [Test]
        public void NewDirectorySelectionField_SetGet_ReturnSetValue()
        {
            var defaultDialogOperationsVM = CreateTestDialogOperationVM();

            var expected = Substitute.For<ButtonViewModel>();
            defaultDialogOperationsVM.NewDirectorySelectionField = expected;

            Assert.AreEqual(expected, defaultDialogOperationsVM.NewDirectorySelectionField);
        }

        [Test]
        public void NewDirectorySelectionField_OnPropertyChanged_FiredPropertyChanged()
        {
            var defaultDialogOperationsVM = CreateTestDialogOperationVM();
            bool propertyChangedWasFired = false;
            defaultDialogOperationsVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            var expected = Substitute.For<ButtonViewModel>();
            defaultDialogOperationsVM.NewDirectorySelectionField = expected;

            Assert.IsTrue(propertyChangedWasFired);
        }

        [Test]
        public void NewDirectorySelectionField_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var defaultDialogOperationsVM = CreateTestDialogOperationVM();
            bool propertyChangedWasFired = false;
            defaultDialogOperationsVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            defaultDialogOperationsVM.NewDirectorySelectionField = defaultDialogOperationsVM.NewDirectorySelectionField;

            Assert.IsFalse(propertyChangedWasFired);
        }
    }
}

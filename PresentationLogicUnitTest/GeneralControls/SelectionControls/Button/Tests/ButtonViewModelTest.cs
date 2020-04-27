using ExplorerTree.Utils;
using FoBOFD.PresentationLogic.GeneralControls.SelectionControls.Button;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PresentationLogicUnitTest.GeneralControls.SelectionControls.Button.Tests
{
    [TestFixture]
    public class ButtonViewModelTest
    {

        private ButtonViewModel CreateButtonViewModel()
        {
            return new ButtonViewModel();
        }

        [Test]
        public void ButtonViewModel_DefaultInitialisation_AllPropertiesAreInitialised()
        {
            var buttonVM = CreateButtonViewModel();

            Assert.AreEqual("init", buttonVM.Content, "Property: " + nameof(buttonVM.Content) + "\" was NOT initialised correctly.");
            Assert.AreEqual(null, buttonVM.SelectedCommand, "Property: " + nameof(buttonVM.SelectedCommand) + "\" was NOT null.");
            Assert.AreEqual(Visibility.Visible, buttonVM.Visibility, "Property: " + nameof(buttonVM.Visibility) + "\" was NOT Visible.");
        }



        [Test]
        public void Content_SetGet_ReturnSetValue()
        {
            var buttonVM = CreateButtonViewModel();

            var expected = "Burger";
            buttonVM.Content = expected;

            Assert.AreEqual(expected, buttonVM.Content);
        }

        [Test]
        public void Content_OnPropertyChanged_FiredPropertyChanged()
        {
            var buttonVM = CreateButtonViewModel();
            bool propertyChangedWasFired = false;
            buttonVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            var expected = "Burger";
            buttonVM.Content = expected;

            Assert.IsTrue(propertyChangedWasFired);
        }

        [Test]
        public void Content_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var buttonVM = CreateButtonViewModel();
            bool propertyChangedWasFired = false;
            buttonVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            buttonVM.Content = buttonVM.Content;

            Assert.IsFalse(propertyChangedWasFired);
        }






        [Test]
        public void SelectedCommand_SetGet_ReturnSetValue()
        {
            var buttonVM = CreateButtonViewModel();

            var expected = new RelayCommand<object>(this.CommanTestMethod);
            buttonVM.SelectedCommand = expected;

            Assert.AreEqual(expected, buttonVM.SelectedCommand);
        }

        public void CommanTestMethod(object obj)
        {

        }





        [Test]
        public void Visibility_SetGet_ReturnSetValue()
        {
            var buttonVM = CreateButtonViewModel();

            var expected = Visibility.Collapsed;
            buttonVM.Visibility = expected;

            Assert.AreEqual(expected, buttonVM.Visibility);
        }

        [Test]
        public void Visibility_OnPropertyChanged_FiredPropertyChanged()
        {
            var buttonVM = CreateButtonViewModel();
            bool propertyChangedWasFired = false;
            buttonVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            var expected = Visibility.Collapsed;
            buttonVM.Visibility = expected;

            Assert.IsTrue(propertyChangedWasFired);
        }

        [Test]
        public void Visibility_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var buttonVM = CreateButtonViewModel();
            bool propertyChangedWasFired = false;
            buttonVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            buttonVM.Visibility = buttonVM.Visibility;

            Assert.IsFalse(propertyChangedWasFired);
        }

    }
}

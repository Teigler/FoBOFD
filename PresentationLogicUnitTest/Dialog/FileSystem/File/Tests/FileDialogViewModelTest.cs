using FoBOFD.PresentationLogic.Dialog.FileSystem.File;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PresentationLogicUnitTest.Dialog.FileSystem.File.Tests
{
    [TestFixture]
    public class FileDialogViewModelTest
    {

        private FileDialogViewModel CreateStandardFileDialogViewModel()
        {
            return new FileDialogViewModel();
        }

        [Test]
        public void FileDialogViewModel_StandardInitialisation_AllPropertiesAreInitialised()
        {
            var fileDialogVM = CreateStandardFileDialogViewModel();

            Assert.AreEqual(Visibility.Visible, fileDialogVM.Visibility,
                "Property: \"" + nameof(fileDialogVM.Visibility) + "\" was NOT initialised correctly!");
        }





        [Test]
        public void Visibility_SetGet_ReturnSetValue()
        {
            var fileDialogVM = CreateStandardFileDialogViewModel();

            var expected = Visibility.Hidden;
            fileDialogVM.Visibility = expected;

            Assert.AreEqual(expected, fileDialogVM.Visibility);
        }

        [Test]
        public void Visibility_OnPropertyChanged_FiredPropertyChanged()
        {
            var fileDialogVM = CreateStandardFileDialogViewModel();
            bool propertyChangedWasFired = false;
            fileDialogVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            var expected = Visibility.Hidden;
            fileDialogVM.Visibility = expected;

            Assert.IsTrue(propertyChangedWasFired);
        }

        [Test]
        public void Visibility_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var fileDialogVM = CreateStandardFileDialogViewModel();
            bool propertyChangedWasFired = false;
            fileDialogVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            fileDialogVM.Visibility = fileDialogVM.Visibility;

            Assert.IsFalse(propertyChangedWasFired);
        }
    }
}

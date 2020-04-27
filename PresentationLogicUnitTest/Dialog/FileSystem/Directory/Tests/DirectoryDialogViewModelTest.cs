using FoBOFD.PresentationLogic.Dialog.FileSystem.Directory;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PresentationLogicUnitTest.Dialog.FileSystem.Directory.Tests
{
    [TestFixture]
    public class DirectoryDialogViewModelTest
    {


        private DirectoryDialogViewModel CreateStandardDirectoryDialogViewModel()
        {
            return new DirectoryDialogViewModel();
        }

        [Test]
        public void DirectoryDialogViewModel_StandardInitialisation_AllPropertiesAreInitialised()
        {
            var directoryDialogVM = CreateStandardDirectoryDialogViewModel();

            Assert.AreEqual(Visibility.Visible, directoryDialogVM.Visibility,
                "Property: \"" + nameof(directoryDialogVM.Visibility) + "\" was NOT initialised correctly!");
        }




        [Test]
        public void Visibility_SetGet_ReturnSetValue()
        {
            var directoryDialogVM = CreateStandardDirectoryDialogViewModel();

            var expected = Visibility.Hidden;
            directoryDialogVM.Visibility = expected;

            Assert.AreEqual(expected, directoryDialogVM.Visibility);
        }

        [Test]
        public void Visibility_OnPropertyChanged_FiredPropertyChanged()
        {
            var directoryDialogVM = CreateStandardDirectoryDialogViewModel();
            bool propertyChangedWasFired = false;
            directoryDialogVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            var expected = Visibility.Hidden;
            directoryDialogVM.Visibility = expected;

            Assert.IsTrue(propertyChangedWasFired);
        }

        [Test]
        public void Visibility_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var directoryDialogVM = CreateStandardDirectoryDialogViewModel();
            bool propertyChangedWasFired = false;
            directoryDialogVM.PropertyChanged += delegate
            {
                propertyChangedWasFired = true;
            };
            directoryDialogVM.Visibility = directoryDialogVM.Visibility;

            Assert.IsFalse(propertyChangedWasFired);

        }
    }
}

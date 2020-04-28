using ExplorerTree.API.Configuration.FontConfiguration;
using ExplorerTree.API.Configuration.IconConfiguration;
using ExplorerTree.Model.ExplorerTreeItems;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows.Media;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ExplorerTreeUnitTest.PresentationLogic.ExplorerTreeItems.Tests
{
    [TestFixture]
    public class IconViewModelTest
    {
        private IconViewModel CreateIconVM()
        {
            return new IconViewModel();
        }

        private IconViewModel CreateIconVM(IconModel iconModel, IExplorerTreeItemIconConfiguration iconConfiguration)
        {
            return new IconViewModel(iconModel, iconConfiguration);
        }


        private IconModel CreateFakeIconModel()
        {
            var fakeIconModel = Substitute.For<IconModel>();
            Icon fakeIcon1 = new Icon(SystemIcons.Exclamation, 40, 40);
            fakeIconModel.LargeImageSource.Returns(Imaging.CreateBitmapSourceFromHIcon(fakeIcon1.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()));

            Icon fakeIcon2 = new Icon(SystemIcons.Exclamation, 20, 20);
            fakeIconModel.SmallImageSource.Returns(Imaging.CreateBitmapSourceFromHIcon(fakeIcon2.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()));
            return fakeIconModel;
        }

       
        private IExplorerTreeItemIconConfiguration CreateFakeIconConfiguration()
        {
            var fakeIconConfiguration = Substitute.For<IExplorerTreeItemIconConfiguration>();
            fakeIconConfiguration.ActiveIconState = IconStates.None;
            return fakeIconConfiguration;
        }



        [Test]
        public void IconViewModel_DefaultInitialisation_AllPropertiesAreInitiallised()
        {
            var iconVM = CreateIconVM();

            Assert.AreEqual(null, iconVM.ActiveImageSource, "Property: \"" + nameof(iconVM.ActiveImageSource) + "\" was NOT null.");
            Assert.AreEqual(null, iconVM.IconConfiguration, "Property: \"" + nameof(iconVM.IconConfiguration) + "\" was NOT null.");
            Assert.AreEqual(null, iconVM.IconModel, "Property: \"" + nameof(iconVM.IconModel) + "\" was NOT null.");
            Assert.AreEqual(null, iconVM.LargeImageSource, "Property: \"" + nameof(iconVM.LargeImageSource) + "\" was NOT null.");
            Assert.AreEqual(null, iconVM.SmallImageSource, "Property: \"" + nameof(iconVM.SmallImageSource) + "\" was NOT null.");
        }


        [Test]
        public void IconViewModel_Initialisation_PropertyLargeImageSourceIsInitiallised()
        {
            var mockIconModel = CreateFakeIconModel();
            var stubIconConfiguration = CreateFakeIconConfiguration();
            
            var iconVM = CreateIconVM(mockIconModel, stubIconConfiguration);

            Assert.AreEqual(mockIconModel.LargeImageSource, iconVM.LargeImageSource);
        }

        [Test]
        public void IconViewModel_Initialisation_PropertySmallImageSourceIsInitiallised()
        {
            var mockIconModel = CreateFakeIconModel();
            var stubIconConfiguration = CreateFakeIconConfiguration();
            
            var iconVM = CreateIconVM(mockIconModel, stubIconConfiguration);

            Assert.AreEqual(mockIconModel.SmallImageSource, iconVM.SmallImageSource);
        }

        [Test]
        public void IconViewModel_Initialisation_PropertyIconConfigurationIsInitiallised()
        {
            var stubIconModel = CreateFakeIconModel();
            var mockIconConfiguration = CreateFakeIconConfiguration();
            
            var iconVM = CreateIconVM(stubIconModel, mockIconConfiguration);

            Assert.AreEqual(mockIconConfiguration, iconVM.IconConfiguration);
        }

        [Test]
        public void IconViewModel_Initialisation_PropertyIconModelIsInitiallised()
        {
            var mockIconModel = CreateFakeIconModel();
            var stubIconConfiguration = CreateFakeIconConfiguration();
            
            var iconVM = CreateIconVM(mockIconModel, stubIconConfiguration);

            Assert.AreEqual(mockIconModel, iconVM.IconModel);
        }

        [Test]
        public void IconViewModel_InitActiveImageSourceWithIconStateIsSmallIcon_PropertyActiveImageSourceIsSmallImageSource()
        {
            var stubIconModel = CreateFakeIconModel();
            var stubIconConfiguration = CreateFakeIconConfiguration();
            stubIconConfiguration.ActiveIconState = IconStates.SmallIcon;
            
            var iconVM = CreateIconVM(stubIconModel, stubIconConfiguration);

            Assert.AreEqual(iconVM.SmallImageSource, iconVM.ActiveImageSource);
        }

        [Test]
        public void IconViewModel_InitActiveImageSourceWithIconStateIsLargeIcon_PropertyActiveImageSourceIsLargeImageSource()
        {
            var stubIconModel = CreateFakeIconModel();
            var stubIconConfiguration = CreateFakeIconConfiguration();
            stubIconConfiguration.ActiveIconState = IconStates.LargeIcon;
            
            var iconVM = CreateIconVM(stubIconModel, stubIconConfiguration);

            Assert.AreEqual(iconVM.LargeImageSource, iconVM.ActiveImageSource);
        }

        [Test]
        public void IconViewModel_InitActiveImageSourceWithIconStateIsNoneIcon_PropertyActiveImageSourceIsNull()
        {
            var stubIconModel = CreateFakeIconModel();
            var stubIconConfiguration = CreateFakeIconConfiguration();
            stubIconConfiguration.ActiveIconState = IconStates.None;
            
            var iconVM = CreateIconVM(stubIconModel, stubIconConfiguration);

            Assert.AreEqual(null, iconVM.ActiveImageSource);
        }





        [Test]
        public void SetSmallImageSourceToActiveImageSource()
        {
            var stubIconModel = CreateFakeIconModel();
            var stubIconConfiguration = CreateFakeIconConfiguration();
            stubIconConfiguration.ActiveIconState = IconStates.LargeIcon;
            var iconVM = CreateIconVM(stubIconModel, stubIconConfiguration);
            Assert.AreEqual(iconVM.LargeImageSource, iconVM.ActiveImageSource, nameof(iconVM.ActiveImageSource) +" start value was not correct");
           
            iconVM.SetSmallImageSourceToActiveImageSource();

            Assert.AreEqual(iconVM.SmallImageSource, iconVM.ActiveImageSource);
        }

        [Test]
        public void SetLargeImageSourceToActiveImageSource()
        {
            var stubIconModel = CreateFakeIconModel();
            var stubIconConfiguration = CreateFakeIconConfiguration();
            stubIconConfiguration.ActiveIconState = IconStates.SmallIcon;
            var iconVM = CreateIconVM(stubIconModel, stubIconConfiguration);
            Assert.AreEqual(iconVM.SmallImageSource, iconVM.ActiveImageSource, nameof(iconVM.ActiveImageSource) + " start value was not correct");
            
            iconVM.SetLargeImageSourceToActiveImageSource();

            Assert.AreEqual(iconVM.LargeImageSource, iconVM.ActiveImageSource);
        }



        [Test]
        public void ActiveImageSource_SetGet_ReturnSetValue()
        {
            var stubIconModel = CreateFakeIconModel();
            var stubIconConfiguration = CreateFakeIconConfiguration();
            var iconVM = CreateIconVM(stubIconModel, stubIconConfiguration);

            Icon fakeIcon = new Icon(SystemIcons.Exclamation, 20, 20);
            var expected = Imaging.CreateBitmapSourceFromHIcon(fakeIcon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            iconVM.ActiveImageSource = expected;

            Assert.AreEqual(expected, iconVM.ActiveImageSource);
        }

        [Test]
        public void ActiveImageSource_SetTheModelProperty_ModelPropertyReturnSetValue()
        {
            var mockIconModel = CreateFakeIconModel();
            var stubIconConfiguration = CreateFakeIconConfiguration();
            var iconVM = CreateIconVM(mockIconModel, stubIconConfiguration);

            Icon fakeIcon = new Icon(SystemIcons.Exclamation, 20, 20);
            var expected = Imaging.CreateBitmapSourceFromHIcon(fakeIcon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            iconVM.ActiveImageSource = expected;

            _ = mockIconModel.Received().ActiveImageSource = expected;
        }

        [Test]
        public void ActiveImageSource_OnPropertyChanged_FiredPropertyChanged()
        {
            var mockIconModel = CreateFakeIconModel();
            var stubIconConfiguration = CreateFakeIconConfiguration();
            var iconVM = CreateIconVM(mockIconModel, stubIconConfiguration);
            bool propertyChangedFired = false;
            iconVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            Icon fakeIcon = new Icon(SystemIcons.Exclamation, 20, 20);
            var expected = Imaging.CreateBitmapSourceFromHIcon(fakeIcon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            iconVM.ActiveImageSource = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void ActiveImageSource_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var mockIconModel = CreateFakeIconModel();
            var stubIconConfiguration = CreateFakeIconConfiguration();
            var iconVM = CreateIconVM(mockIconModel, stubIconConfiguration);
            bool propertyChangedFired = false;
            iconVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            iconVM.ActiveImageSource = iconVM.ActiveImageSource;

            Assert.IsFalse(propertyChangedFired);
        }





    }
}

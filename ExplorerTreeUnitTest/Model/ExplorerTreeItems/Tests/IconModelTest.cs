using ExplorerTree.Model.ExplorerTreeItems;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ExplorerTreeUnitTest.Model.ExplorerTreeItems.Tests
{
    [TestFixture]
    public class IconModelTest
    {
        private IconModel CreateIconModel()
        {
            return new IconModel();
        }


        private ImageSource CreateImageSource()
        {
            Icon fakeIcon = new Icon(SystemIcons.Exclamation, 40, 40);
            return Imaging.CreateBitmapSourceFromHIcon(fakeIcon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        [Test]
        public void IconModel_DefaultInitialisation_AllPropertiesAreInitialised()
        {
            var iconModel = CreateIconModel();

            Assert.AreEqual(null, iconModel.ActiveImageSource, "Property: \"" + nameof(iconModel.ActiveImageSource) + "\" was NOT null!");
            Assert.AreEqual(null, iconModel.LargeImageSource, "Property: \"" + nameof(iconModel.LargeImageSource) + "\" was NOT null!");
            Assert.AreEqual(null, iconModel.SmallImageSource, "Property: \"" + nameof(iconModel.SmallImageSource) + "\" was NOT null!");
        }



        [Test]
        public void ActiveImageSource_SetGet_ReturnSetValue()
        {
            var iconModel = CreateIconModel();

            var expected = CreateImageSource();
            iconModel.ActiveImageSource = expected;

            Assert.AreEqual(expected, iconModel.ActiveImageSource);
        }

        [Test]
        public void LargeImageSource_SetGet_ReturnSetValue()
        {
            var iconModel = CreateIconModel();

            var expected = CreateImageSource();
            iconModel.LargeImageSource = expected;

            Assert.AreEqual(expected, iconModel.LargeImageSource);
        }

        [Test]
        public void SmallImageSource_SetGet_ReturnSetValue()
        {
            var iconModel = CreateIconModel();

            var expected = CreateImageSource();
            iconModel.SmallImageSource = expected;

            Assert.AreEqual(expected, iconModel.SmallImageSource);
        }

    }
}

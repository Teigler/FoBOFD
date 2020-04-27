using ExplorerTree.API.Configuration.FontConfiguration;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExplorerTreeUnitTest.PresentationLogic.ExplorerTreeItems.Tests
{
    [TestFixture]
    public class FontViewModelTest
    {

        private FontViewModel CreateFontVM()
        {
            return new FontViewModel();
        }

        private FontViewModel CreateFontVM(IExplorerTreeItemFontConfiguration fontConfiguration)
        {
            return new FontViewModel(fontConfiguration);
        }

        private IExplorerTreeItemFontConfiguration CreateFakeFontConfiguration()
        {
            var fakeFontConfiguration = Substitute.For<IExplorerTreeItemFontConfiguration>();
            fakeFontConfiguration.FontFamily.Returns(new System.Windows.Media.FontFamily("Arial"));
            fakeFontConfiguration.FontSize.Returns(6000);
            fakeFontConfiguration.FontStretch.Returns(FontStretches.ExtraCondensed);
            fakeFontConfiguration.FontStyle.Returns(FontStyles.Oblique);
            fakeFontConfiguration.FontWeight.Returns(FontWeights.UltraBold);
            return fakeFontConfiguration;
        }

        [Test]
        public void FontViewModel_DefaultInitialisation_AllPropertiesAreInitiallised()
        {
            var fontVM = CreateFontVM();

            Assert.AreEqual(null, fontVM.FontFamily, "Property: \"" + nameof(fontVM.FontFamily) + "\" was NOT null.");
            Assert.AreEqual(12, fontVM.FontSize, "Property: \"" + nameof(fontVM.FontFamily) + "\" was NOT zero (\"0\").");
            Assert.AreEqual(FontStretches.Normal, fontVM.FontStretch, "Property: \"" + nameof(fontVM.FontStretch) + "\" was NOT initiallised correctly.");
            Assert.AreEqual(FontStyles.Normal, fontVM.FontStyle, "Property: \"" + nameof(fontVM.FontStyle) + "\" was NOT initiallised correctly.");
            Assert.AreEqual(FontWeights.Normal, fontVM.FontWeight, "Property: \"" + nameof(fontVM.FontWeight) + "\" was NOT initiallised correctly.");
            Assert.AreEqual(null, fontVM.FontConfiguration, "Property: \"" + nameof(fontVM.FontConfiguration) + "\" was NOT null.");
        }


        [Test]
        public void FontViewModel_Initialisation_PropertyFontFamilyIsInitiallised()
        {
            var mockFontConfiguration = CreateFakeFontConfiguration();
           
            var fontVM = CreateFontVM(mockFontConfiguration);
            
            Assert.AreEqual(mockFontConfiguration.FontFamily, fontVM.FontFamily);
        }

        [Test]
        public void FontViewModel_Initialisation_PropertyFontSizeIsInitiallised()
        {
            var mockFontConfiguration = CreateFakeFontConfiguration();

            var fontVM = CreateFontVM(mockFontConfiguration);

            Assert.AreEqual(mockFontConfiguration.FontSize, fontVM.FontSize);
        }

        [Test]
        public void FontViewModel_Initialisation_PropertyFontStretchIsInitiallised()
        {
            var mockFontConfiguration = CreateFakeFontConfiguration();

            var fontVM = CreateFontVM(mockFontConfiguration);

            Assert.AreEqual(mockFontConfiguration.FontStretch, fontVM.FontStretch);
        }

        [Test]
        public void FontViewModel_Initialisation_PropertyFontStyleIsInitiallised()
        {
            var mockFontConfiguration = CreateFakeFontConfiguration();

            var fontVM = CreateFontVM(mockFontConfiguration);

            Assert.AreEqual(mockFontConfiguration.FontStyle, fontVM.FontStyle);
        }

        [Test]
        public void FontViewModel_Initialisation_PropertyFontWeightIsInitiallised()
        {
            var mockFontConfiguration = CreateFakeFontConfiguration();

            var fontVM = CreateFontVM(mockFontConfiguration);

            Assert.AreEqual(mockFontConfiguration.FontWeight, fontVM.FontWeight);
        }

        [Test]
        public void FontViewModel_Initialisation_PropertyFontConfigurationIsInitiallised()
        {
            var mockFontConfiguration = CreateFakeFontConfiguration();

            var fontVM = CreateFontVM(mockFontConfiguration);

            Assert.AreEqual(mockFontConfiguration, fontVM.FontConfiguration);
        }






        [Test]
        public void FontFamily_SetGet_ReturnSetValue()
        {
            var fontVM = CreateFontVM();

            var expected = new System.Windows.Media.FontFamily("Arial");
            fontVM.FontFamily = expected;

            Assert.AreEqual(expected, fontVM.FontFamily);
        }

        [Test]
        public void FontFamily_OnPropertyChanged_FiredPropertyChanged()
        {
            var fontVM = CreateFontVM();
            bool propertyChangedFired = false;
            fontVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = new System.Windows.Media.FontFamily("Arial");
            fontVM.FontFamily = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void FontFamily_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var fontVM = CreateFontVM();
            bool propertyChangedFired = false;
            fontVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            fontVM.FontFamily = fontVM.FontFamily;

            Assert.IsFalse(propertyChangedFired);
        }





        [Test]
        public void FontSize_SetGet_ReturnSetValue()
        {
            var fontVM = CreateFontVM();

            var expected = 6800;
            fontVM.FontSize = expected;

            Assert.AreEqual(expected, fontVM.FontSize);
        }

        [Test]
        public void FontSize_OnPropertyChanged_FiredPropertyChanged()
        {
            var fontVM = CreateFontVM();
            bool propertyChangedFired = false;
            fontVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = 6800;
            fontVM.FontSize = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void FontSize_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var fontVM = CreateFontVM();
            bool propertyChangedFired = false;
            fontVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            fontVM.FontSize = fontVM.FontSize;

            Assert.IsFalse(propertyChangedFired);
        }





        [Test]
        public void FontStretch_SetGet_ReturnSetValue()
        {
            var fontVM = CreateFontVM();

            var expected = FontStretches.Expanded;
            fontVM.FontStretch = expected;

            Assert.AreEqual(expected, fontVM.FontStretch);
        }

        [Test]
        public void FontStretch_OnPropertyChanged_FiredPropertyChanged()
        {
            var fontVM = CreateFontVM();
            bool propertyChangedFired = false;
            fontVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = FontStretches.Expanded;
            fontVM.FontStretch = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void FontStretch_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var fontVM = CreateFontVM();
            bool propertyChangedFired = false;
            fontVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            fontVM.FontStretch = fontVM.FontStretch;

            Assert.IsFalse(propertyChangedFired);
        }





        [Test]
        public void FontStyle_SetGet_ReturnSetValue()
        {
            var fontVM = CreateFontVM();

            var expected = FontStyles.Italic;
            fontVM.FontStyle = expected;

            Assert.AreEqual(expected, fontVM.FontStyle);
        }

        [Test]
        public void FontStyle_OnPropertyChanged_FiredPropertyChanged()
        {
            var fontVM = CreateFontVM();
            bool propertyChangedFired = false;
            fontVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = FontStyles.Italic;
            fontVM.FontStyle = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void FontStyle_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var fontVM = CreateFontVM();
            bool propertyChangedFired = false;
            fontVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            fontVM.FontStyle = fontVM.FontStyle;

            Assert.IsFalse(propertyChangedFired);
        }




        [Test]
        public void FontWeight_SetGet_ReturnSetValue()
        {
            var fontVM = CreateFontVM();

            var expected = FontWeights.SemiBold;
            fontVM.FontWeight = expected;

            Assert.AreEqual(expected, fontVM.FontWeight);
        }

        [Test]
        public void FontWeight_OnPropertyChanged_FiredPropertyChanged()
        {
            var fontVM = CreateFontVM();
            bool propertyChangedFired = false;
            fontVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            var expected = FontWeights.SemiBold;
            fontVM.FontWeight = expected;

            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void FontWeight_SetSameValueAgain_NotFiredPropertyChanged()
        {
            var fontVM = CreateFontVM();
            bool propertyChangedFired = false;
            fontVM.PropertyChanged += delegate
            {
                propertyChangedFired = true;
            };

            fontVM.FontWeight = fontVM.FontWeight;

            Assert.IsFalse(propertyChangedFired);
        }
    }
}

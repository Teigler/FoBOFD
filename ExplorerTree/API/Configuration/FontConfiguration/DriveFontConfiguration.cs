using ExplorerTree.PresentationLogic;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExplorerTree.API.Configuration.FontConfiguration
{
    public class DriveFontConfiguration : IExplorerTreeItemFontConfiguration
    {

        private System.Windows.Media.FontFamily fontFamily;
        private double fontSize;
        private FontStretch fontStrech;
        private System.Windows.FontStyle fontStyle;
        private FontWeight fontWeight;

        public DriveFontConfiguration(ExplorerTreeViewModel explorerTreeVM)
        {
            this.ExplorerTreeVM = explorerTreeVM;
            this.fontFamily = new System.Windows.Media.FontFamily("Times New Roman");
            this.fontSize = 12;
            this.fontStrech = FontStretches.Normal;
            this.fontStyle = FontStyles.Normal;
            this.fontWeight = FontWeights.Normal;
        }

        /// <summary>
        /// All currently loaded drives will be updated
        /// </summary>
        internal void UpdateDrives()
        {
            foreach (var drive in this.ExplorerTreeVM.Drives)
            {
                if (drive.Name != "DummyChild")
                {
                    this.UpdateFontVMCompletelyWithThisFontConfiguration(drive.FontVM);
                }
            }
        }


        public void UpdateFontVMCompletelyWithThisFontConfiguration(FontViewModel fontVM)
        {
            fontVM.Update(this);
        }


        /// <summary>
        /// Documentation see: <see cref="IExplorerTreeItemFontConfiguration.FontFamily"/>
        /// </summary>
        public System.Windows.Media.FontFamily FontFamily
        {
            get => fontFamily;
            set
            {
                if (fontFamily == value)
                    return;
                fontFamily = value;
                this.UpdateDrives();
            }
        }

        /// <summary>
        /// Documentation see: <see cref="IExplorerTreeItemFontConfiguration.FontSize"/>
        /// </summary>
        public double FontSize
        {
            get => fontSize;
            set
            {
                if (fontSize == value)
                    return;
                fontSize = value;
                this.UpdateDrives();
            }
        }

        /// <summary>
        /// Documentation see: <see cref="IExplorerTreeItemFontConfiguration.FontStretch"/>
        /// </summary>
        public FontStretch FontStretch
        {
            get => fontStrech;
            set
            {
                if (fontStrech == value)
                    return;
                fontStrech = value;
                this.UpdateDrives();
            }
        }

        /// <summary>
        /// Documentation see: <see cref="IExplorerTreeItemFontConfiguration.FontStyle"/>
        /// </summary>
        public System.Windows.FontStyle FontStyle
        {
            get => fontStyle;
            set
            {
                if (fontStyle == value)
                    return;
                fontStyle = value;
                this.UpdateDrives();
            }
        }

        /// <summary>
        /// Documentation see: <see cref="IExplorerTreeItemFontConfiguration.FontWeight"/>
        /// </summary>
        public FontWeight FontWeight
        {
            get => fontWeight;
            set
            {
                if (fontWeight == value)
                    return;
                fontWeight = value;
                this.UpdateDrives();
            }
        }

        internal ExplorerTreeViewModel ExplorerTreeVM { get; set; }

    }
}

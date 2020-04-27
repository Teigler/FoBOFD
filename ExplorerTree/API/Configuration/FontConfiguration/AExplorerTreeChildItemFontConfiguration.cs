using ExplorerTree.PresentationLogic;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System.Collections.ObjectModel;
using System.Windows;

namespace ExplorerTree.API.Configuration.FontConfiguration
{
    public abstract class AExplorerTreeChildItemFontConfiguration : IExplorerTreeItemFontConfiguration
    {

        private System.Windows.Media.FontFamily fontFamily;
        private double fontSize;
        private FontStretch fontStrech;
        private System.Windows.FontStyle fontStyle;
        private FontWeight fontWeight;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="explorerTreeVM"></param>
        protected AExplorerTreeChildItemFontConfiguration(ExplorerTreeViewModel explorerTreeVM)
        {
            this.ExplorerTreeVM = explorerTreeVM;



            // don't use property for initialisation!!!
            // because property calls -> UpdateCurrentlyLoadedFontVMsOfTheExplorerTree() 
            // and this uses ExplorerTreeVM -> and this could be null!!!!
            // I did not want a zero check, because for these no reasonable error
            // handling would be possible. Or would a log make sense here?
            this.fontFamily = new System.Windows.Media.FontFamily("Times New Roman");
            this.fontSize = 12;
            this.fontStrech = FontStretches.Normal;
            this.fontStyle = FontStyles.Normal;
            this.fontWeight = FontWeights.Normal;
        }



        internal abstract void ForeachDriveUpdateChilds();

        protected abstract void UpdateDirectoriesAndFiles(ObservableCollection<AExplorerTreeChildItemViewModel> explorerTreeChildItemVMs);

        public abstract void UpdateFontVMCompletelyWithThisFontConfiguration(FontViewModel fontVM);



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
                this.ForeachDriveUpdateChilds();
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
                this.ForeachDriveUpdateChilds();
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
                this.ForeachDriveUpdateChilds();
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
                this.ForeachDriveUpdateChilds();
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
                this.ForeachDriveUpdateChilds();
            }
        }

        internal ExplorerTreeViewModel ExplorerTreeVM { get; set; }

    }
}

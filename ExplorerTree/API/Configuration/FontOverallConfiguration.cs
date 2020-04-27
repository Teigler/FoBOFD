using ExplorerTree.API.Configuration.FontConfiguration;
using ExplorerTree.PresentationLogic;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExplorerTree.API.Configuration
{
    /// <summary>
    /// Set the font properties of all ExplorerTreeItem-Categories (drives, directories ...)
    /// <para>
    ///     with the ..OverallConfiguration you can change the values for all ExplorerTreeItem-Categories with one function call.
    /// </para>
    /// </summary>
    public class FontOverallConfiguration
    {
        /// <summary>
        /// For tests only!
        /// </summary>
        public FontOverallConfiguration()
        {
            
        }

        internal FontOverallConfiguration(ExplorerTreeViewModel explorerTreeVM, IConfiguration configuration)
        {
            this.ExplorerTreeVM = explorerTreeVM;
            this.DriveFontConfiguration = configuration.Drive.Font;
            this.DirectoryFontConfiguration = configuration.Directory.Font;
            this.FileFontConfiguration = configuration.File.Font;
  
        }


        /// <summary>
        /// Configure the <see cref="System.Windows.Media.FontFamily"/> of the <see cref="IExplorerTreeItemViewModel"/>
        /// </summary>
        public void SetFontFamily(System.Windows.Media.FontFamily fontFamily)
        {
            this.DriveFontConfiguration.FontFamily = fontFamily;
            this.DirectoryFontConfiguration.FontFamily = fontFamily;
            this.FileFontConfiguration.FontFamily = fontFamily;
        }


        /// <summary>
        /// Configure the <see cref="System.Windows.FontStretch"/> of the <see cref="IExplorerTreeItemViewModel"/>
        /// </summary>
        public void SetFontStrech(FontStretch fontStretch)
        {
            this.DriveFontConfiguration.FontStretch = fontStretch;
            this.DirectoryFontConfiguration.FontStretch =  fontStretch;
            this.FileFontConfiguration.FontStretch = fontStretch;
        }

        /// <summary>
        /// Configure the <see cref="System.Windows.Controls.FontSize"/> of the <see cref="IExplorerTreeItemViewModel"/>
        /// </summary>
        public void SetFontSize(double fontSize)
        {
            this.DriveFontConfiguration.FontSize = fontSize;
            this.DirectoryFontConfiguration.FontSize = fontSize;
            this.FileFontConfiguration.FontSize = fontSize;
        }


        /// <summary>
        /// Configure the <see cref="System.Windows.FontStyle"/> of the <see cref="IExplorerTreeItemViewModel"/>
        /// </summary>
        public void SetFontStyle(System.Windows.FontStyle fontStyle)
        {
            this.DriveFontConfiguration.FontStyle = fontStyle;
            this.DirectoryFontConfiguration.FontStyle = fontStyle;
            this.FileFontConfiguration.FontStyle = fontStyle;
        }

        /// <summary>
        /// Configure the <see cref="System.Windows.FontWeight"/> of the <see cref="IExplorerTreeItemViewModel"/>
        /// </summary>
        public void SetFontWeight(FontWeight fontWeight)
        {
            this.DriveFontConfiguration.FontWeight = fontWeight;
            this.DirectoryFontConfiguration.FontWeight = fontWeight;
            this.FileFontConfiguration.FontWeight = fontWeight;
        }

        internal ExplorerTreeViewModel ExplorerTreeVM { get; private set; }
        internal IExplorerTreeItemFontConfiguration DriveFontConfiguration { get; private set; }
        internal IExplorerTreeItemFontConfiguration DirectoryFontConfiguration { get; private set; }
        internal IExplorerTreeItemFontConfiguration FileFontConfiguration { get; private set; }
    }
}

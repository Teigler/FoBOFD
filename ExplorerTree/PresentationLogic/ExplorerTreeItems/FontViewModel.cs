using ExplorerTree.API.Configuration;
using ExplorerTree.API.Configuration.FontConfiguration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExplorerTree.PresentationLogic.ExplorerTreeItems
{
    /// <summary>
    /// A ViewModel to hold the Font-Propertys.
    /// </summary>
    /// <remarks>
    ///     Currently no Model is needed for this ViewModel.
    /// </remarks>
    public class FontViewModel : ExplorerTreeBaseViewModel
    {

        private System.Windows.Media.FontFamily fontFamily;
        private double fontSize;
        private FontStretch fontStrech;
        private System.Windows.FontStyle fontStyle;
        private FontWeight fontWeight;
        
        /// <summary>
        /// For tests only!
        /// </summary>
        internal FontViewModel()
        {
            this.FontFamily = null;
            this.FontSize = 12;
            this.FontStretch = FontStretches.Normal;
            this.FontStyle = FontStyles.Normal;
            this.FontWeight = FontWeights.Normal;
            this.FontConfiguration = null;
        }

        internal FontViewModel(IExplorerTreeItemFontConfiguration fontConfiguration)
        {
            this.Init(fontConfiguration);
        }


        private void Init(IExplorerTreeItemFontConfiguration fontConfiguration)
        {
            this.FontFamily = fontConfiguration.FontFamily;
            this.FontSize = fontConfiguration.FontSize;
            this.FontStretch = fontConfiguration.FontStretch;
            this.FontStyle = fontConfiguration.FontStyle;
            this.FontWeight = fontConfiguration.FontWeight;
            this.FontConfiguration = fontConfiguration;
        }

        internal virtual void Update(IExplorerTreeItemFontConfiguration fontConfiguration)
        {
            this.Init(fontConfiguration);
        }


        /// <summary>
        /// 
        /// <para>
        ///     Default: <see cref="IExplorerTreeItemFontConfiguration.FontFamily"/>
        /// </para>
        /// </summary>
        public virtual System.Windows.Media.FontFamily FontFamily
        {
            get => fontFamily;
            set
            {
                if (fontFamily == value)
                    return;
                fontFamily = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 
        /// <para>
        ///     Default: <see cref="IExplorerTreeItemFontConfiguration.FontSize"/>
        /// </para>
        /// </summary>
        public virtual double FontSize
        {
            get => fontSize;
            set
            {
                if (fontSize == value)
                    return;
                fontSize = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 
        /// <para>
        ///     Default: <see cref="IExplorerTreeItemFontConfiguration.FontStretch"/>
        /// </para>
        /// </summary>
        public virtual FontStretch FontStretch
        {
            get => fontStrech;
            set
            {
                if (fontStrech == value)
                    return;
                fontStrech = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 
        /// <para>
        ///     Default: <see cref="IExplorerTreeItemFontConfiguration.FontStyle"/>
        /// </para>
        /// </summary>
        public virtual System.Windows.FontStyle FontStyle
        {
            get => fontStyle;
            set
            {
                if (fontStyle == value)
                    return;
                fontStyle = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 
        /// <para>
        ///     Default: <see cref="IExplorerTreeItemFontConfiguration.FontWeight"/>
        /// </para>
        /// </summary>
        public virtual FontWeight FontWeight
        {
            get => fontWeight;
            set
            {
                if (fontWeight == value)
                    return;
                fontWeight = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The Configuration of this ViewModel.
        /// </summary>
        internal virtual IExplorerTreeItemFontConfiguration FontConfiguration { get; private set; }
    }
}

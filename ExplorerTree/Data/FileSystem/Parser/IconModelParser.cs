using ExplorerTree.Data.ShellElements.Pack1;
using ExplorerTree.Model.ExplorerTreeItems;
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

namespace ExplorerTree.Data.FileSystem.Parser
{
    internal class IconModelParser
    {
        internal IconModelParser(ShellIcon shellIcon = null)
        {

            this.ShellIcon = shellIcon ?? new ShellIcon();
        }

        private ImageSource ConvertIconToImageSource(Icon icon)
        {
            ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            return imageSource;
        }

        public IconModel ParseIconModel(IconModel iconModel, string sourePath)
        {
            iconModel.ActiveImageSource = ConvertIconToImageSource(this.ShellIcon.GetSmallIcon(sourePath));
            iconModel.SmallImageSource = iconModel.ActiveImageSource;
            iconModel.LargeImageSource = ConvertIconToImageSource(this.ShellIcon.GetLargeIcon(sourePath));
            return iconModel;
        }


        /// <summary>
        /// For communication with Shell -> get icons
        /// </summary>
        private ShellIcon ShellIcon { get; set; }
    }
}

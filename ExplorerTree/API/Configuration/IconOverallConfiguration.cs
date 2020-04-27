using ExplorerTree.API.Configuration.IconConfiguration;
using ExplorerTree.PresentationLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.API.Configuration
{
    /// <summary>
    /// Set the icon properties of all ExplorerTreeItem-Categories (drives, directories ...)
    /// <para>
    ///     with the ..OverallConfiguration you can change the values for all ExplorerTreeItem-Categories with one function call.
    /// </para>
    /// </summary>
    public class IconOverallConfiguration
    {

        /// <summary>
        /// For tests only!
        /// </summary>
        public IconOverallConfiguration()
        {

        }

        internal IconOverallConfiguration(ExplorerTreeViewModel explorerTreeViewModel, IConfiguration configuration)
        {
            this.ExplorerTreeVM = explorerTreeViewModel;
            this.DriveIconConfiguration = configuration.Drive.Icon;
            this.DirectoryIconConfiguration = configuration.Directory.Icon;
            this.FileIconConfiguration = configuration.File.Icon;
        }

        public void SetSmallIconToActiveIcon()
        {
            this.DriveIconConfiguration.SetSmallIconToActiveIcon();
            this.DirectoryIconConfiguration.SetSmallIconToActiveIcon();
            this.FileIconConfiguration.SetSmallIconToActiveIcon();
        }

        public void SetLargeIconToActiveIcon()
        {
            this.DriveIconConfiguration.SetLargeIconToActiveIcon();
            this.DirectoryIconConfiguration.SetLargeIconToActiveIcon();
            this.FileIconConfiguration.SetLargeIconToActiveIcon();
        }

        internal ExplorerTreeViewModel ExplorerTreeVM { get; private set; }
        internal IExplorerTreeItemIconConfiguration DriveIconConfiguration { get; private set; }
        internal IExplorerTreeItemIconConfiguration DirectoryIconConfiguration { get; private set; }
        internal IExplorerTreeItemIconConfiguration FileIconConfiguration { get; private set; }
    }
}

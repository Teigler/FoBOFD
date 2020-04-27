using ExplorerTree.API.Configuration.ExplorerTreeItemConfiguration;
using ExplorerTree.PresentationLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.API.Configuration
{
    public class Configuration : IConfiguration
    {
        internal Configuration()
        {
            this.Init(null);
        }

        internal Configuration(ExplorerTreeViewModel explorerTreeVM)
        {
            this.Init(explorerTreeVM);
        }

        public void Initialisation(ExplorerTreeViewModel explorerTreeVM)
        {
            this.Init(explorerTreeVM);
        }

        private void Init(ExplorerTreeViewModel explorerTreeVM)
        {
            this.ExplorerTreeVM = explorerTreeVM;
            
            this.Directory = new DirectoryConfiguration(this.ExplorerTreeVM);
            this.Drive = new DriveConfiguration(this.ExplorerTreeVM);
            this.File = new FileConfiguration(this.ExplorerTreeVM);

            this.FontOverall = new FontOverallConfiguration(this.ExplorerTreeVM, this);
            this.IconOverall = new IconOverallConfiguration(this.ExplorerTreeVM, this);
            this.HiddenOverall = new HiddenOverallConfiguration(this.ExplorerTreeVM);
            this.SelectionConfiguration = new SelectionConfiguration.SelectionConfiguration();
        }

        /// <summary>
        /// To manipulate the current status and behavior 
        /// of the <see cref="ExplorerTree"/>-Component.
        /// </summary>
        public ExplorerTreeViewModel ExplorerTreeVM { get; set; }

        /// <inheritdoc/>
        public FontOverallConfiguration FontOverall { get; set; }

        /// <inheritdoc/>
        public IconOverallConfiguration IconOverall { get; set; }

        /// <inheritdoc/>
        public DriveConfiguration Drive { get; set; }

        /// <inheritdoc/>
        public AExplorerTreeChildItemConfiguration Directory { get; set; }

        /// <inheritdoc/>
        public AExplorerTreeChildItemConfiguration File { get; set; }

        /// <inheritdoc/>
        public HiddenOverallConfiguration HiddenOverall { get; set; }

        /// <inheritdoc/>
        public SelectionConfiguration.SelectionConfiguration SelectionConfiguration { get; set; }
    }
}

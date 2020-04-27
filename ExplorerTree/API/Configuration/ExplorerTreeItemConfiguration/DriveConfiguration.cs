using ExplorerTree.API.Configuration.AvailabilityConfiguration;
using ExplorerTree.API.Configuration.FontConfiguration;
using ExplorerTree.API.Configuration.IconConfiguration;
using ExplorerTree.PresentationLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.API.Configuration.ExplorerTreeItemConfiguration
{
    /// <summary>
    /// To configure all drive items 
    /// </summary>
    /// <remarks>
    ///   The term "item" is deliberately omitted from the name.  
    ///   -> Because this is the API
    /// </remarks>
    public class DriveConfiguration : IExplorerTreeItemConfiguration
    {

        /// <summary>
        /// For tests only!
        /// </summary>
        public DriveConfiguration()
        {
            this.Availability = null;
            this.Font = null;
            this.Icon = null;
        }


        public DriveConfiguration(ExplorerTreeViewModel explorerTreeVM)
        {
            this.Availability = new DriveAvailabilityConfiguration(explorerTreeVM);
            this.Font = new DriveFontConfiguration(explorerTreeVM);
            this.Icon = new DriveIconConfiguration(explorerTreeVM);
        }




        public IDriveAvailabilityConfiguration Availability { get; set; }

        public IExplorerTreeItemFontConfiguration Font { get; set; }

        public IExplorerTreeItemIconConfiguration Icon { get; set; }
    }
}

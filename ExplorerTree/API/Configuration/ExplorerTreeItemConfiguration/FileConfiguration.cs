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
    /// To configure all file items
    /// </summary>
    /// <remarks>
    ///   The term "item" is deliberately omitted from the name.  
    ///   -> Because this is the API
    /// </remarks>
    public class FileConfiguration : AExplorerTreeChildItemConfiguration
    {

        /// <summary>
        /// For tests only!
        /// </summary>
        public FileConfiguration()
        {
            this.Font = null;
            this.Icon = null;
        }

        public FileConfiguration(ExplorerTreeViewModel explorerTreeVM)
        {
            this.Font = new FileFontConfiguration(explorerTreeVM);
            this.Icon = new FileIconConfiguration(explorerTreeVM);

        }

    }
}

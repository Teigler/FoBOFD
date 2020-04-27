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
    /// To configure all directory items
    /// </summary>
    /// <remarks>
    ///   The term "item" is deliberately omitted from the name.  
    ///   -> Because this is the API
    /// </remarks>
    public class DirectoryConfiguration : AExplorerTreeChildItemConfiguration
    {

        /// <summary>
        /// For tests only!
        /// </summary>
        public DirectoryConfiguration()
        {
            this.Font = null;
            this.Icon = null;
        }


        public DirectoryConfiguration(ExplorerTreeViewModel explorerTreeVM)
        {
            this.Font = new DirectoryFontConfiguration(explorerTreeVM);
            this.Icon = new DirectoryIconConfiguration(explorerTreeVM);
        }



    }
}

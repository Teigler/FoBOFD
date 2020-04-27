using ExplorerTree.API.Configuration.FontConfiguration;
using ExplorerTree.API.Configuration.IconConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.API.Configuration.ExplorerTreeItemConfiguration
{
    public abstract class AExplorerTreeChildItemConfiguration : IExplorerTreeItemConfiguration
    {
        protected AExplorerTreeChildItemConfiguration()
        {
            this.Font = null;
            this.Icon = null;
        }


        public IExplorerTreeItemFontConfiguration Font { get; set; }


        public IExplorerTreeItemIconConfiguration Icon { get; set; }
    }
}

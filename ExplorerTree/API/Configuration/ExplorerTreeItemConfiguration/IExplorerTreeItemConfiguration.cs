using ExplorerTree.API.Configuration.FontConfiguration;
using ExplorerTree.API.Configuration.IconConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.API.Configuration.ExplorerTreeItemConfiguration
{
    public interface IExplorerTreeItemConfiguration
    {

        IExplorerTreeItemFontConfiguration Font { get; set; }

        IExplorerTreeItemIconConfiguration Icon { get; set; }
    }
}

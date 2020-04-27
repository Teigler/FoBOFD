using ExplorerTree.Model.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.Data.FileSystem.Parser
{
    internal interface IDirectoryParser
    {

        List<AExplorerTreeChildItemModel> DirectoriesToDirectoryItemModel(List<string> directories, IExplorerTreeItemModel parentItem);
    }
}

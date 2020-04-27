using ExplorerTree.Model.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.Model
{
    interface IExplorerTreeModel
    {

        List<DriveItemModel> Drives { get; set; }
    }
}

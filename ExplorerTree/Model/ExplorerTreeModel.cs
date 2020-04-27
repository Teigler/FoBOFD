using ExplorerTree.Model.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.Model
{
    internal class ExplorerTreeModel : IExplorerTreeModel
    {
        internal ExplorerTreeModel()
        {
            Drives = new List<DriveItemModel>();
        }


        public List<DriveItemModel> Drives { get; set; }
    }
}

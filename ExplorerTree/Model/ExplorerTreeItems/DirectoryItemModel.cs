using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.Model.ExplorerTreeItems
{
    public class DirectoryItemModel : AExplorerTreeChildItemModel
    {


        internal DirectoryItemModel() : base()
        {
            DirectoryInfo = null;
        }


        internal virtual DirectoryInfo DirectoryInfo { get; set; }
    }
}

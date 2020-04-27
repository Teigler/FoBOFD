using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.Model.ExplorerTreeItems
{
    public class FileItemModel : AExplorerTreeChildItemModel
    {


        internal FileItemModel() : base()
        {
            FileInfo = null;
        }

        internal virtual FileInfo FileInfo { get; set; }

    }
}

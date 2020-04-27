using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ExplorerTree.Model.ExplorerTreeItems
{
    public class DriveItemModel : IExplorerTreeItemModel
    {


        public DriveItemModel()
        {
            Childs = new List<AExplorerTreeChildItemModel>();
            DriveInfo = null;
            DriveType = DriveType.Unknown;
            Name = "init";
            IconModel = new IconModel();
        }

        /// <inheritdoc/>
        public virtual List<AExplorerTreeChildItemModel> Childs { get; set; }


        internal virtual DriveInfo DriveInfo { get; set; }

        internal virtual DriveType DriveType { get; set; }

        /// <inheritdoc/>
        public virtual IconModel IconModel { get; set; }

        /// <inheritdoc/>
        public virtual string Name { get; set; }

      
    }
}

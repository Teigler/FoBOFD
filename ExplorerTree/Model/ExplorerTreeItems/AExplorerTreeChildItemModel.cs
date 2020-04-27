using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ExplorerTree.Model.ExplorerTreeItems
{
    public abstract class AExplorerTreeChildItemModel : IExplorerTreeItemModel
    {

        protected AExplorerTreeChildItemModel()
        {
            Childs = new List<AExplorerTreeChildItemModel>();
            FullName = "init";
            IsHidden = false;
            IconModel = new IconModel();
            Name = "init";
            ParentItem = null;
        }

        /// <summary>
        /// The items or elements of this <see cref="IExplorerTreeItemModel"/>
        /// </summary>
        public virtual List<AExplorerTreeChildItemModel> Childs { get; set; }

        /// <summary>
        /// FullName is the whole path.
        /// <para>
        ///     Default value: "init"
        /// </para>
        /// </summary>
        public virtual string FullName { get; set; }

        /// <summary>
        /// <see cref="IExplorerTreeItemModel.ImageSource"/>
        /// </summary>
        public virtual IconModel IconModel { get; set; }

        /// <summary>
        /// Specifies whether the directory (or file) referenced by this <see cref="AExplorerTreeChildItemModel"/> 
        /// is a hidden direcotry (or file).
        /// <para>
        ///     Refers to the <see cref="System.IO.FileAttributes.Hidden"/>
        /// </para>
        /// <para>
        ///     Default: <see langword="false"/>
        /// </para>
        /// </summary>
        public virtual bool IsHidden { get; set; }

        /// <summary>
        /// <see cref="IExplorerTreeItemModel.Name"/>
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        ///  the item this one belongs to.
        /// <para>
        ///     Default <see langword="null"/>    
        /// </para>
        /// </summary>
        public virtual IExplorerTreeItemModel ParentItem { get; set; }
    }
}

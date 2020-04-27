using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ExplorerTree.Model.ExplorerTreeItems
{
    public interface IExplorerTreeItemModel
    {
        /// <summary>
        /// The items or elements of this <see cref="IExplorerTreeItemModel"/>
        /// </summary>
        List<AExplorerTreeChildItemModel> Childs { get; set; }

        /// <summary>
        /// The Name means the last part of the path.
        /// <para>
        ///     Default value: "init"
        /// </para>
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The <see cref="IconModel"/> of this <see cref="IExplorerTreeItemModel"/>
        /// -> contains the possible icon sizes
        /// </summary>
        IconModel IconModel { get; set; }
    }
}

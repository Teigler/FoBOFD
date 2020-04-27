using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ExplorerTree.Model.ExplorerTreeItems
{
    /// <summary>
    /// Contains modelinformations abaut the Icons for <see cref="IExplorerTreeItemModel"/>
    /// </summary>
    public class IconModel
    {

        internal IconModel()
        {
            ActiveImageSource = null;
            LargeImageSource = null;
            SmallImageSource = null;
        }

        /// <summary>
        ///  The image (icon) of the <see cref="IExplorerTreeModel"/> that is currently displayed.
        /// <para>
        ///     ActiveImageSource in Model is needed because maybe one time is a resone to know 
        ///     the ActiveImageSource in a lower layer.
        /// </para>
        /// <para>
        ///     Default: <see langword="null"/>
        /// </para>
        /// </summary>
        internal virtual ImageSource ActiveImageSource { get; set; }

        /// <summary>
        /// todo documentation:
        /// <para>
        ///     Default: <see langword="null"/>
        /// </para>
        /// </summary>
        internal virtual ImageSource LargeImageSource { get; set; }

        /// <summary>
        /// todo documentation:
        /// <para>
        ///     Default: <see langword="null"/>
        /// </para>
        /// </summary>
        internal virtual ImageSource SmallImageSource { get; set; }
    }
}

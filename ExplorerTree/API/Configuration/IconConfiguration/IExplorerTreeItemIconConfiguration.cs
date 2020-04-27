using ExplorerTree.Model.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.API.Configuration.IconConfiguration
{
    public interface IExplorerTreeItemIconConfiguration
    {


        /// <summary>
        /// Sets the icons of the ExplorerTree-Items to the large one.
        /// Sets the icons of all currently loaded icons and those that are not yet visible.
        /// 
        /// <para>
        /// All currently loaded icons must be updated so that the icons can be adjusted at runtime. 
        /// To update all currently loaded icons, the child elements of all currently loaded drives and directories must be updated.
        /// </para> 
        /// </summary>
        void SetLargeIconToActiveIcon();




        /// <summary>
        /// Sets the icons of the ExplorerTree-Items to the small one.
        /// Sets the icons of all currently loaded icons and those that are not yet visible.
        /// <para>
        /// All currently loaded icons must be updated so that the icons can be adjusted at runtime. 
        /// To update all currently loaded icons, the child elements of all currently loaded drives and directories must be updated.
        /// </para>
        /// </summary>
        void SetSmallIconToActiveIcon();




        /// <summary>
        /// Specifies which icon size should be currently set.
        /// <para>
        ///     Default: <see cref="IconStates.SmallIcon"/>
        /// </para>
        /// </summary>
        IconStates ActiveIconState { get; set; }

    }
}

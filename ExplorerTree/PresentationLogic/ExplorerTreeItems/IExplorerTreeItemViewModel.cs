using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ExplorerTree.PresentationLogic.ExplorerTreeItems
{
    public interface IExplorerTreeItemViewModel 
    {
        /// <summary>
        /// Collection for binding the Child-Tree-Items 
        /// of this <see cref="IExplorerTreeItemViewModel"/>
        /// </summary>
        ObservableCollection<AExplorerTreeChildItemViewModel> ChildTreeItemVMs { get; set; }

        /// <summary>
        /// For communication via <see cref="PresentationLogic"/>
        /// and Parsing the Model-Data
        /// </summary>
        IExplorerTreeItemModelViewModelParser ExplorerTreeItemModelViewModelParser { get; }

        /// <summary>
        /// To updated the main ViewModel
        /// </summary>
        ExplorerTreeViewModel ExplorerTreeVM { get; set; }

        /// <summary>
        /// The font settings of this <see cref="IExplorerTreeItemViewModel"/>
        /// </summary>
        FontViewModel FontVM { get; set; }

        /// <summary>
        /// Specifies whether the <see cref="IExplorerTreeItemViewModel"/> 
        /// is expanded or not.
        /// If expanded equals <see langword="true"/> 
        /// then the child elements are visible otherwise they are collapsed.
        /// <para>
        ///     Default: <see langword="false"/>
        /// </para>
        /// </summary>
        bool IsExpanded { get; set; }

        /// <summary>
        /// Specifies whether the <see cref="IExplorerTreeItemViewModel"/> 
        /// is selected or not.
        /// <para>
        ///     none or any number of <see cref="IExplorerTreeItemViewModel"/> 
        ///     can be selected.
        /// </para>
        /// <para>
        ///     Default: <see langword="false"/>
        /// </para>
        /// </summary>
        bool IsSelected { get; set; }

        /// <summary>
        /// The icon of this <see cref="IExplorerTreeItemViewModel"/>
        /// -> contains the possible icon sizes
        /// </summary>
        IconViewModel IconVM { get; set; }

        /// <summary>
        /// The name or discription of this <see cref="IExplorerTreeItemViewModel"/>
        /// displayed in the tree-view.
        /// The directory- or file-name...
        /// <para>
        ///     Default: "init"
        /// </para>
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The <see cref="System.Windows.Visibility"/> of this: <see cref="IExplorerTreeItemViewModel"/>
        /// <para>
        ///     Default: <see cref="Visibility.Visible"/>
        /// </para>
        /// </summary>
        Visibility Visibility { get; set; }
    }
}

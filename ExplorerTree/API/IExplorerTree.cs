using ExplorerTree.API.Configuration;
using ExplorerTree.PresentationLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.API
{
    public interface IExplorerTree
    {
        /// <summary>
        /// To configure the <see cref="ExplorerTree"/>-Component.
        /// </summary>
        IConfiguration Configuration { get; }

        /// <summary>
        /// The main ViewModel of the <see cref="ExplorerTree"/>-Component
        /// </summary>
        ExplorerTreeViewModel ExplorerTreeVM { get; }


        /// <summary>
        /// The main ViewModel of the <see cref="ExplorerTree"/>-Component
        /// </summary>
        ISelectedExplorerTreeItemAPI SelectedItemAPI { get; }


    }
}

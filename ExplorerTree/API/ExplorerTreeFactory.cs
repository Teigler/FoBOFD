using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.API
{
    /// <summary>
    /// Instantiats the <see cref="API"/>-Elements
    /// </summary>
    public static class ExplorerTreeFactory
    {
        public static IExplorerTree CreateExplorerTree()
        {
            return new ExplorerTree();
        }
    }
}

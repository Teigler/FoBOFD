using ExplorerTree.BusinessLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.Data.API
{
    internal static class DataFactory
    {
        internal static IData CreateData()
        {
            return new Data();
        }
    }
}

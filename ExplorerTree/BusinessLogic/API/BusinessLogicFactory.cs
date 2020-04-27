using ExplorerTree.Data.API;
using ExplorerTree.PresentationLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.BusinessLogic.API
{
    internal static class BusinessLogicFactory
    {
        internal static IBusinessLogic CreateBusinessLogic()
        {
            var data = DataFactory.CreateData();
            return new BusinessLogic(data);
        }
    }
}

using ExplorerTree.API.Configuration;
using ExplorerTree.BusinessLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.PresentationLogic.API
{
    internal static class PresentationLogicFactory
    {
        internal static IPresentationLogic CreatePresentationLogic(IConfiguration configuration)
        {
            var businessLogic = BusinessLogicFactory.CreateBusinessLogic();
            return new PresentationLogic(configuration, businessLogic);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoBOFD.PresentationLogic.API
{
    public static class PresentationLogicFactory
    {
        public static IPresentationLogic CreatePresentationLogic()
        {
            return new PresentationLogic();
        }
    }
}

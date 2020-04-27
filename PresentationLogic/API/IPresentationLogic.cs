using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoBOFD.PresentationLogic.API
{
    /// <summary>
    /// The type for componentens who want to "hold" this component.
    /// </summary>
    public interface IPresentationLogic
    {
       
        MainWindowViewModel MainWindowVM { get; set; }
    }
}

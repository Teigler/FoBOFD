using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoBOFD.PresentationLogic.API
{
    /// <summary>
    /// Mainly responsible for communication with other componenents (.dll) 
    /// </summary>
    public class PresentationLogic : IPresentationLogic
    {
        private MainWindowViewModel mainWindowVM;


        internal PresentationLogic()
        {

            this.MainWindowVM = new MainWindowViewModel();
        }


        public MainWindowViewModel MainWindowVM { get => mainWindowVM;  set => mainWindowVM = value; }

  
    }
}

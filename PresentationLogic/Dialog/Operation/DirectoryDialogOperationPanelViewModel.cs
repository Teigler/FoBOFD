using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoBOFD.PresentationLogic.Dialog.Operation
{
    public class DirectoryDialogOperationPanelViewModel : ADialogOperationPanelViewModel
    {

      
        public DirectoryDialogOperationPanelViewModel(DefaultDialogOperationViewModel defaultDialogOperationVM = null) : 
            base(defaultDialogOperationVM)
        {

            this.InitialiseAgreeSelectionField();
            this.InitialiseDisagreeSelectionField();
            this.InitialiseNewDirectorySelectionField();
        }


        public override void NewFolderSelectionFieldSelected(object obj)
        {
            throw new NotImplementedException();
        }
    }
}

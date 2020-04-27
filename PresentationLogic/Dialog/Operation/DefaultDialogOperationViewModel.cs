using FoBOFD.PresentationLogic.GeneralControls.SelectionControls.Button;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoBOFD.PresentationLogic.Dialog.Operation
{

    /// <summary>
    /// The default operations a dialog can have.
    /// 
    /// </summary>
    public class DefaultDialogOperationViewModel : BaseViewModel
    {


        private ButtonViewModel agreeSelectionField;
        private ButtonViewModel disagreeSelectionField;
        private ButtonViewModel newFolderSelectionField;

        /// <summary>
        /// for tests only!!!
        /// </summary>
        public DefaultDialogOperationViewModel(ButtonViewModel buttonViewModel)
        {
            this.AgreeSelectionField = buttonViewModel;
            this.DisagreeSelectionField = buttonViewModel;
            this.NewDirectorySelectionField = buttonViewModel;
        }


        public DefaultDialogOperationViewModel()
        {
            this.AgreeSelectionField = new ButtonViewModel();
            this.DisagreeSelectionField = new ButtonViewModel();
            this.NewDirectorySelectionField = new ButtonViewModel();
        }




        /// <summary>
        /// e. g. OK-Button.
        /// </summary>
        public virtual ButtonViewModel AgreeSelectionField
        {
            get => this.agreeSelectionField;
            set
            {
                if (this.agreeSelectionField == value)
                    return;
                this.agreeSelectionField = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// e. g. Cancel-Button
        /// </summary>
        public virtual ButtonViewModel DisagreeSelectionField
        {
            get => this.disagreeSelectionField;
            set
            {
                if (this.disagreeSelectionField == value)
                    return;
                this.disagreeSelectionField = value;
                this.OnPropertyChanged();
            }
        }


        /// <summary>
        /// e. g. NewFolder-Button
        /// </summary>
        public virtual ButtonViewModel NewDirectorySelectionField

        {
            get => this.newFolderSelectionField;
            set
            {
                if (this.newFolderSelectionField == value)
                    return;
                this.newFolderSelectionField = value;
                this.OnPropertyChanged();
            }
        }
    }
}

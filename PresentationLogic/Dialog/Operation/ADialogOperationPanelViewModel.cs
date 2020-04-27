using ExplorerTree.Utils;
using JetBrains.ReSharper.Daemon.CSharp.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FoBOFD.PresentationLogic.Dialog.Operation
{
    /// <summary>
    /// The DialogOperationPanel is a ribbon on the bottom of the dialog.
    /// This ribbon contains dialog specific operations like OK-Button or NewFolder-Button.
    /// </summary>
    public abstract class ADialogOperationPanelViewModel : BaseViewModel
    {
        private DefaultDialogOperationViewModel defaultDialogOperation;


      

        protected ADialogOperationPanelViewModel(DefaultDialogOperationViewModel defaultDialogOperationVM = null)
        {
            this.DefaultDialogOperation = defaultDialogOperationVM ?? new DefaultDialogOperationViewModel();
    
            this.DefaultDialogOperation.NewDirectorySelectionField.SelectedCommand = new RelayCommand<object>(this.NewFolderSelectionFieldSelected);
        }


        public virtual void InitialiseAgreeSelectionField()
        {
            this.DefaultDialogOperation.AgreeSelectionField.Content = "OK";
        }
        public virtual void InitialiseDisagreeSelectionField()
        {
            this.DefaultDialogOperation.DisagreeSelectionField.Content = "Cancel";
        }

        public virtual void InitialiseNewDirectorySelectionField()
        {
            this.DefaultDialogOperation.NewDirectorySelectionField.Content = "New Folder";
            this.DefaultDialogOperation.NewDirectorySelectionField.Visibility = Visibility.Collapsed;
        }




        public abstract void NewFolderSelectionFieldSelected(object obj);









        public DefaultDialogOperationViewModel DefaultDialogOperation
        {
            get => this.defaultDialogOperation;
            set
            {
                if (this.defaultDialogOperation == value)
                    return;
                this.defaultDialogOperation = value;
                this.OnPropertyChanged();
            }
        }
    }
}

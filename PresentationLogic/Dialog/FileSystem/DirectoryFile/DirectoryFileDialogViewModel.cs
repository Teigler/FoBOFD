using ExplorerTree.API;
using ExplorerTree.PresentationLogic;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using ExplorerTree.Utils;
using FoBOFD.PresentationLogic.Dialog.Operation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FoBOFD.PresentationLogic.Dialog.FileSystem.DirectoryFile
{
    public class DirectoryFileDialogViewModel : AFileSystemDialogViewModel
    {

        private DirectoryFileDialogOperationPanelViewModel operationPanel;
        private ExplorerTreeViewModel explorerTreeVM;



        public DirectoryFileDialogViewModel(
            DirectoryFileDialogOperationPanelViewModel operationPanel = null,
            IExplorerTree explorerTree = null,
            IDirectoryFileDialogConfiguration initialConfiguration = null)
        {
            this.OperationPanel = operationPanel ?? new DirectoryFileDialogOperationPanelViewModel();
            this.ExplorerTree = explorerTree ?? ExplorerTreeFactory.CreateExplorerTree();
            this.ExplorerTreeVM = ExplorerTree.ExplorerTreeVM;
            this.DirectoryFileDialogConfigurator = initialConfiguration ?? 
                new DirectoryFileDialogInitialConfiguration(ExplorerTree.Configuration);
            this.Visibility = Visibility.Collapsed;
        }



        public void SetAgreeSelectionFieldCommandMethod(Action<object> execute)
        {
            this.OperationPanel.DefaultDialogOperation.AgreeSelectionField.SelectedCommand = new RelayCommand<object>(execute);
        }

        public void SetDisagreeSelectionFieldCommandMethod(Action<object> execute)
        {
            this.OperationPanel.DefaultDialogOperation.DisagreeSelectionField.SelectedCommand = new RelayCommand<object>(execute);
        }







        public ObservableCollection<DirectoryItemViewModel> GetSelectedDirectories()
        {
            return ExplorerTree.SelectedItemAPI.GetSelectedDirectories();
        }

        public ObservableCollection<FileItemViewModel> GetSelectedFiles()
        {
            return ExplorerTree.SelectedItemAPI.GetSelectedFiles();
        }



        public DirectoryFileDialogOperationPanelViewModel OperationPanel
        {
            get => this.operationPanel;
            set
            {
                if (this.operationPanel == value)
                    return;
                this.operationPanel = value;
                this.OnPropertyChanged();
            }
        }
        internal IDirectoryFileDialogConfiguration DirectoryFileDialogConfigurator {get; private set;}
        public ExplorerTreeViewModel ExplorerTreeVM
        {
            get => this.explorerTreeVM;
            set
            {
                if (this.explorerTreeVM == value)
                    return;
                this.explorerTreeVM = value;
                this.OnPropertyChanged();
            }
        }
        public IExplorerTree ExplorerTree { get; private set; }



    }
}

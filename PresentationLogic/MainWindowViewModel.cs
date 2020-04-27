using ExplorerTree.Utils;
using FoBOFD.PresentationLogic.Dialog.FileSystem;
using FoBOFD.PresentationLogic.Dialog.FileSystem.Directory;
using FoBOFD.PresentationLogic.Dialog.FileSystem.DirectoryFile;
using FoBOFD.PresentationLogic.Dialog.FileSystem.File;
using FoBOFD.PresentationLogic.GeneralControls.SelectionControls.Button;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FoBOFD.PresentationLogic
{
    public class MainWindowViewModel : BaseViewModel
    {

        private ButtonViewModel openDirectoryFileDialogSelectionField;

        private DirectoryDialogViewModel directoryDialogVM;
        private DirectoryFileDialogViewModel directoryFileDialogVM;
        private FileDialogViewModel fileDialogVM;


        public MainWindowViewModel()
        {
           

            this.OpenDirectoryFileDialogSelectionField = new ButtonViewModel();
            this.OpenDirectoryFileDialogSelectionField.SelectedCommand = new RelayCommand<object>(this.OpenDirectoryFileDialogSelectionFieldSelected);
            this.OpenDirectoryFileDialogSelectionField.Content = "Open DirectoryFile-Dialog";


            this.DirectoryDialogVM = null;
            this.DirectoryFileDialogVM = new DirectoryFileDialogViewModel();
            this.FileDialogVM = null;


            this.DirectoryFileDialogVM.SetAgreeSelectionFieldCommandMethod(this.DirectoryFileDialogAgreeSelectionFieldSelected);
            this.DirectoryFileDialogVM.SetDisagreeSelectionFieldCommandMethod(this.DirectoryFileDialogDisagreeSelectionFieldSelected);
        }



       


        public void OpenDirectoryFileDialogSelectionFieldSelected(object obj)
        {
            this.DirectoryFileDialogVM.Visibility = Visibility.Visible;
            this.OpenDirectoryFileDialogSelectionField.Visibility = Visibility.Collapsed;

           
        }





       
        public void DirectoryFileDialogAgreeSelectionFieldSelected(object obj)
        {
            this.DirectoryFileDialogVM.Visibility = Visibility.Collapsed;
            this.OpenDirectoryFileDialogSelectionField.Visibility = Visibility.Visible;

            var directories = this.DirectoryFileDialogVM.GetSelectedDirectories();
            var files = this.DirectoryFileDialogVM.GetSelectedFiles();

        }


       
        public void DirectoryFileDialogDisagreeSelectionFieldSelected(object obj)
        {
           
        }




        public ButtonViewModel OpenDirectoryFileDialogSelectionField
        {
            get => this.openDirectoryFileDialogSelectionField;
            set
            {
                if (this.openDirectoryFileDialogSelectionField == value)
                    return;
                this.openDirectoryFileDialogSelectionField = value;
                this.OnPropertyChanged();
            }
        }



        public DirectoryDialogViewModel DirectoryDialogVM
        {
            get => this.directoryDialogVM;
            set
            {
                if (this.directoryDialogVM == value)
                    return;
                this.directoryDialogVM = value;
                this.OnPropertyChanged();
            }
        }

        public DirectoryFileDialogViewModel DirectoryFileDialogVM
        {
            get => this.directoryFileDialogVM;
            set
            {
                if (this.directoryFileDialogVM == value)
                    return;
                this.directoryFileDialogVM = value;
                this.OnPropertyChanged();
            }
        }

        public FileDialogViewModel FileDialogVM
        {
            get => this.fileDialogVM;
            set
            {
                if (this.fileDialogVM == value)
                    return;
                this.fileDialogVM = value;
                this.OnPropertyChanged();
            }
        }

    
        
    }
}

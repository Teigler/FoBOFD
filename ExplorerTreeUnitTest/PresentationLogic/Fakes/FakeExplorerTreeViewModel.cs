using ExplorerTree.API.Configuration;
using ExplorerTree.PresentationLogic;
using ExplorerTree.PresentationLogic.API;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using ExplorerTree.PresentationLogic.SelectionHandling;
using ExplorerTreeUnitTest.PresentationLogic.ExplorerTreeItems.Fakes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using System.IO;

namespace ExplorerTreeUnitTest.PresentationLogic.Fakes
{
    public class FakeExplorerTreeViewModel : ExplorerTreeViewModel
    {

        private ObservableCollection<DriveItemViewModel> drives;
        public FakeExplorerTreeViewModel(
            IConfiguration configuration,
            IPresentationLogic presentationLogic)
            : base(configuration, presentationLogic)
        {
            this.Drives = new ObservableCollection<DriveItemViewModel>();
            this.CreateDefaultFakeExplorerTree();
            this.LoadAllDriveItemViewModelsWasCalled = false;
        }


        /// <summary>
        /// I deliberately implemented the getAllFake ...Directory and ...File methods
        /// only in the <see cref="FakeExplorerTreeViewModel"/>,
        /// because I think that this kind of method is only useful 
        /// for small ExplorerTrees, because you have to run through 
        /// all directories or files twice. 
        /// Todo: check if these methods are still useful in the "real" ExplorerTree
        ///       -> in the: <see cref="ExplorerTreeViewModel"/>
        /// </summary>
        public List<FakeDirectoryItemViewModel> GetAllFakeDirectories()
        {
            List<FakeDirectoryItemViewModel> returnList = new List<FakeDirectoryItemViewModel>();

            foreach(var drive in Drives)
            {
                if (drive.Name != "DummyChild")
                {
                    returnList = this.GetAllFakeDirectoriesForeachDriveOrDirectoryRekursiv(drive.ChildTreeItemVMs.ToList(), returnList);
                }
            }


            return returnList;
        }

        private List<FakeDirectoryItemViewModel> GetAllFakeDirectoriesForeachDriveOrDirectoryRekursiv(List<AExplorerTreeChildItemViewModel> explorerTreeChildItemVMs, List<FakeDirectoryItemViewModel> returnList)
        {
            foreach(var directoryOrFile in explorerTreeChildItemVMs)
            {
                if (directoryOrFile.Name != "DummyChild" && (directoryOrFile is FakeDirectoryItemViewModel))
                {
                    returnList.Add(directoryOrFile as FakeDirectoryItemViewModel);
                    returnList = this.GetAllFakeDirectoriesForeachDriveOrDirectoryRekursiv(directoryOrFile.ChildTreeItemVMs.ToList(), returnList);
                }
            }

            return returnList;
        }



        /// <summary>
        /// I deliberately implemented the getAllFake ...Directory and ...File methods
        /// only in the <see cref="FakeExplorerTreeViewModel"/>,
        /// because I think that this kind of method is only useful 
        /// for small ExplorerTrees, because you have to run through 
        /// all directories or files twice. 
        /// Todo: check if these methods are still useful in the "real" ExplorerTree
        ///       -> in the: <see cref="ExplorerTreeViewModel"/>
        /// </summary>
        public List<FakeFileItemViewModel> GetAllFakeFiles()
        {
            List<FakeFileItemViewModel> returnList = new List<FakeFileItemViewModel>();

            foreach (var drive in Drives)
            {
                if (drive.Name != "DummyChild")
                {
                    returnList = this.GetAllFakeFilesForeachDriveOrDirectoryRekursiv(drive.ChildTreeItemVMs.ToList(), returnList);
                }
            }


            return returnList;
        }

        private List<FakeFileItemViewModel> GetAllFakeFilesForeachDriveOrDirectoryRekursiv(List<AExplorerTreeChildItemViewModel> explorerTreeChildItemVMs, List<FakeFileItemViewModel> returnList)
        {
            foreach (var directoryOrFile in explorerTreeChildItemVMs)
            {
                if (directoryOrFile.Name != "DummyChild" )
                {
                    if(directoryOrFile is FakeFileItemViewModel)
                    {
                        returnList.Add(directoryOrFile as FakeFileItemViewModel);
                    }
                    returnList = GetAllFakeFilesForeachDriveOrDirectoryRekursiv(directoryOrFile.ChildTreeItemVMs.ToList(), returnList);
                }
               
            }

            return returnList;
        }







        /// <summary>
        /// For loading the FAKE roots with Fake Explorer Tree View.
        /// </summary>
        internal override void LoadAllDriveItemViewModels()
        {
            this.LoadAllDriveItemViewModelsWasCalled = true;
            this.CreateDefaultFakeExplorerTree();
        }



        /// <summary>
        /// Create an Fake Explorer Tree -> Fake Drives, Directories and Files.
        /// </summary>
        /// <remarks>
        ///     Example for one drive (only with directories):
        ///     
        ///     FakeDrive_1\FakeDirectory_1\FakeDirectory_1\
        ///     FakeDrive_1\FakeDirectory_2\FakeDirectory_1\
        ///     
        /// 
        ///     with directories and files:
        ///     FakeDrive_1\FakeDirectory_1\FakeDirectory_1\FakeFile_1
        ///     FakeDrive_1\FakeDirectory_1\FakeFile_1
        ///     FakeDrive_1\FakeDirectory_2\FakeDirectory_1\FakeFile_1
        ///     FakeDrive_1\FakeDirectory_2\FakeFile_1
        ///     FakeDrive_1\FakeFile_1
        ///     FakeDrive_1\FakeFile_2
        ///     FakeDrive_1\FakeFile_3
        ///     FakeDrive_1\FakeZipFile_0\FakeDirectory_0
        ///     FakeDrive_1\FakeZipFile_1\FakeFile_0
        /// </remarks>
        internal void CreateDefaultFakeExplorerTree()
        {
            this.Create7FakeDrives();
            this.Create2FakeDirectoriesForeachDrive();
            this.Create3FakeFilesForeachDrive();

            this.Create1FakeDirectoryForeachDirectoryInEachDrive();
            this.Create1FakeFileForeachDirectory();

            this.CreateFakeZipFilesForeachDrive();
        }

        private void Create7FakeDrives()
        {
            for (int i = 0; i < 7; i++)
            {
                DriveItemViewModel drive = new FakeDriveItemViewModel();
                drive.IconVM = new FakeIconViewModel();
                SetDriveTypeAccordingToEnumDriveTypeAndTheLocalVariable_i(i, drive);
                drive.Name = "FakeDrive_" + i.ToString() + ":\\";

                this.Drives.Add(drive);
            }
        }

        /// <summary>
        /// To generate a drive foreach drive Type from Enum: <see cref="DriveType"/>
        /// </summary>
        private static void SetDriveTypeAccordingToEnumDriveTypeAndTheLocalVariable_i(int i, DriveItemViewModel drive)
        {
            string[] driveTyps = Enum.GetNames(typeof(DriveType));
            drive.DriveType = (DriveType)Enum.Parse(typeof(DriveType), driveTyps.ElementAt(i));
        }


        /// <summary>
        /// Warning: Please don't use <see cref="GetAllFakeDirectories"></see> or <see cref="GetAllFakeFiles"/>
        ///          so that the same methods are not used for the unit tests
        /// </summary>
        private void Create2FakeDirectoriesForeachDrive()
        {
            foreach (var drive in this.Drives)
            {
                for (int i = 1; i < 3; i++)
                {
                    (drive as FakeDriveItemViewModel).CreateAddAndGetFakeDirectory(
                        drive.Name + "FakeDirectory_" + i.ToString() + "\\");
                }
            }
        }

        /// <summary>
        /// Warning: Please don't use <see cref="GetAllFakeDirectories"></see> or <see cref="GetAllFakeFiles"/>
        ///          so that the same methods are not used for the unit tests
        /// </summary>
        private void Create3FakeFilesForeachDrive()
        {
            foreach (var drive in this.Drives)
            {
                for (int i = 0; i < 3; i++)
                {
                    (drive as FakeDriveItemViewModel).CreateAddAndGetFakeFile(
                        drive.Name + "FakeFile_" + i.ToString() + "\\");
                }
            }
        }

        /// <summary>
        /// Warning: Please don't use <see cref="GetAllFakeDirectories"></see> or <see cref="GetAllFakeFiles"/>
        ///          so that the same methods are not used for the unit tests
        /// </summary>
        private void CreateFakeZipFilesForeachDrive()
        {
            foreach (var drive in this.Drives)
            {
                
                 (drive as FakeDriveItemViewModel).CreateAddAndGetFakeFile(drive.Name + "FakeZipFile_0\\").CreateAddAndGetFakeDirectory(drive.Name + "FakeZipFile_0\\FakeDirectory_0\\");
                 (drive as FakeDriveItemViewModel).CreateAddAndGetFakeFile(drive.Name + "FakeZipFile_1\\").CreateAddAndGetFakeFile(drive.Name + "FakeZipFile_1\\FakeFile_0\\");
                
            }
        }


        /// <summary>
        /// Warning: Please don't use <see cref="GetAllFakeDirectories"></see> or <see cref="GetAllFakeFiles"/>
        ///          so that the same methods are not used for the unit tests
        /// </summary>
        private void Create1FakeDirectoryForeachDirectoryInEachDrive()
        {
            foreach (var drive in this.Drives)
            {
                foreach (var item in drive.ChildTreeItemVMs)
                {
                    if (item is FakeDirectoryItemViewModel)
                    {
                        (item as FakeDirectoryItemViewModel).CreateAddAndGetFakeDirectory(
                           item.FullName + "FakeDirectory_1\\");
                    }
                }
            }
        }



        /// <summary>
        /// Warning: Please don't use <see cref="GetAllFakeDirectories"></see> or <see cref="GetAllFakeFiles"/>
        ///          so that the same methods are not used for the unit tests
        /// </summary>
        private void Create1FakeFileForeachDirectory()
        {
            foreach (var drive in this.Drives)
            {
                this.ForEachDirectoryCreate1FileRecursivly(drive);
            }
        }


        /// <summary>
        /// Warning: Please don't use <see cref="GetAllFakeDirectories"></see> or <see cref="GetAllFakeFiles"/>
        ///          so that the same methods are not used for the unit tests
        /// </summary>
        private void ForEachDirectoryCreate1FileRecursivly(IExplorerTreeItemViewModel driveOrDirectory)
        {
            foreach (var item in driveOrDirectory.ChildTreeItemVMs)
            {
                if (item is FakeDirectoryItemViewModel)
                {
                    (item as FakeDirectoryItemViewModel).CreateAddAndGetFakeFile(
                        item.FullName + "FakeFile_1");
                }
                this.ForEachDirectoryCreate1FileRecursivly(item);
            }
        }



        public override ObservableCollection<DriveItemViewModel> Drives
        {
            get => drives;
            set
            {
                if (drives == value)
                    return;
                drives = value;
                OnPropertyChanged();
            }
        }

        internal override IConfiguration Configuration { get => null; }


        /// <summary>
        /// For parsing <see cref="Data.Model.ExplorerTreeItems"/>- and 
        /// <see cref="PresentationLogic.ExplorerTreeItems"/>-Elements.
        /// </summary>
        internal override IExplorerTreeItemModelViewModelParser ExplorerTreeItemModelViewModelParser { get => null; }

        /// <summary>
        /// For communication with other components/layers, like: <see cref="BusinessLogic"/>
        /// </summary>
        internal override IPresentationLogic PresentationLogic { get => null; }

        /// <summary>
        /// Responsible for the SelectedItems in this ExplorerTree.
        /// </summary>
        internal override ISelectedExplorerTreeItemHandler SelectedItemHandler
        {
            get => null;

        }



        internal bool LoadAllDriveItemViewModelsWasCalled { get; private set; }

    }
}


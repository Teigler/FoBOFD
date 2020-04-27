using ExplorerTree.API.Configuration;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeUnitTest.PresentationLogic.ExplorerTreeItems.Fakes
{
    public class FakeDirectoryItemViewModel : DirectoryItemViewModel
    {
        internal FakeDirectoryItemViewModel()
        {
            this.ChildTreeItemVMs = new ObservableCollection<AExplorerTreeChildItemViewModel>();
            this.FontVM = new FakeFontViewModel();
            this.IconVM = new FakeIconViewModel();
            this.SetVisibilityAccordingToConfigurationWasCalled = false;
        }

        public FakeDirectoryItemViewModel CreateAddAndGetFakeDirectory(string fakeDirectoryPath)
        {
            FakeDirectoryItemViewModel fakeDirectoryItemVM = new FakeDirectoryItemViewModel();
            fakeDirectoryItemVM.FullName = fakeDirectoryPath;
            this.ChildTreeItemVMs.Add(fakeDirectoryItemVM);
            return fakeDirectoryItemVM;
        }

        public FakeFileItemViewModel CreateAddAndGetFakeFile(string fakeFilePath)
        {
            FakeFileItemViewModel fakeFileItemVM = new FakeFileItemViewModel();
            fakeFileItemVM.FullName = fakeFilePath;
            this.ChildTreeItemVMs.Add(fakeFileItemVM);
            return fakeFileItemVM;
        }





        internal override void SetVisibilityAccordingToConfigruation(HiddenOverallConfiguration hiddenOverallConfiguration)
        {
            this.SetVisibilityAccordingToConfigurationWasCalled = true;

        }



        internal bool SetVisibilityAccordingToConfigurationWasCalled { get; set; }
    }
}

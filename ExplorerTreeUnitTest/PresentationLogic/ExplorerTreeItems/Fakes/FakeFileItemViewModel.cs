using ExplorerTree.API.Configuration;
using ExplorerTree.PresentationLogic;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeUnitTest.PresentationLogic.ExplorerTreeItems.Fakes
{
    public class FakeFileItemViewModel : FileItemViewModel
    {

        internal FakeFileItemViewModel()
        {
            this.FontVM = new FakeFontViewModel();
            this.IconVM = new FakeIconViewModel();
            this.SetVisibilityAccordingToConfigurationWasCalled = false;
        }



        internal override void SetVisibilityAccordingToConfigruation(HiddenOverallConfiguration hiddenOverallConfiguration)
        {
            this.SetVisibilityAccordingToConfigurationWasCalled = true;

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


        internal bool SetVisibilityAccordingToConfigurationWasCalled { get; set; }
    }
}

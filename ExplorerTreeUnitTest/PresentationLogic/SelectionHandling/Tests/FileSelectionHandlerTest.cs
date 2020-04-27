using ExplorerTree.API.Configuration.SelectionConfiguration;
using ExplorerTree.PresentationLogic.SelectionHandling;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System.Threading;

namespace ExplorerTreeUnitTest.PresentationLogic.SelectionHandling.Tests
{
    [TestFixture]
    public class FileSelectionHandlerTest
    {






        [Test]
        public void MultiselectDesicions_IsMultiselectCombinationAllTypesAllowedTrue_FileVMIsInListSelectedExplorerTreeItems()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            selectionConfiguration.IsMultiselectCombinationAllTypesAllowed = true;

            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            FileSelectionHandler fileSelectionHandler = new FileSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            FileItemViewModel fileItemVM = new FileItemViewModel();


            fileSelectionHandler.MultiselectDesicions(true, fileItemVM);

            Assert.AreEqual(fileItemVM, selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.First());
        }

        [Test]
        public void MultiselectDesicions_IsMultiselectCombinationAllTypesAllowedTrue_FileVMIsInListSelectedFiles()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            selectionConfiguration.IsMultiselectCombinationAllTypesAllowed = true;

            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            FileSelectionHandler fileSelectionHandler = new FileSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            FileItemViewModel fileItemVM = new FileItemViewModel();


            bool result = fileSelectionHandler.MultiselectDesicions(true, fileItemVM);

            Assert.AreEqual(fileItemVM, selectedExplorerTreeItemHandler.SelectedFiles.First());
        }

        [Test]
        public void MultiselectDesicions_IsMultiselectCombinationAllTypesAllowedTrue_ReturnsTrue()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            selectionConfiguration.IsMultiselectCombinationAllTypesAllowed = true;

            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            FileSelectionHandler fileSelectionHandler = new FileSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            FileItemViewModel fileItemVM = new FileItemViewModel();


            bool result = fileSelectionHandler.MultiselectDesicions(true, fileItemVM);

            Assert.AreEqual(true, result);
        }




        [Test]
        public void MultiselectDesicions__IsMultiselectCombinationDirectoriesAndFilesAllowedTrue_AndIsEnsuredOnlyDirectoriesAndFilesAreNowSelectableByMultiselectTrue__FileVMIsInListSelectedExplorerTreeItems()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            selectionConfiguration.IsMultiselectCombinationDirectoriesAndFilesAllowed = true;

            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            FileSelectionHandler fileSelectionHandler = new FileSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            FileItemViewModel fileItemVM = new FileItemViewModel();


            fileSelectionHandler.MultiselectDesicions(true, fileItemVM);

            Assert.AreEqual(fileItemVM, selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.First());
        }

        [Test]
        public void MultiselectDesicions__IsMultiselectCombinationDirectoriesAndFilesAllowedTrue_AndIsEnsuredOnlyDirectoriesAndFilesAreNowSelectableByMultiselectTrue__FileVMIsInListSelectedFiles()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            selectionConfiguration.IsMultiselectCombinationDirectoriesAndFilesAllowed = true;

            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            FileSelectionHandler fileSelectionHandler = new FileSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            FileItemViewModel fileItemVM = new FileItemViewModel();


            bool result = fileSelectionHandler.MultiselectDesicions(true, fileItemVM);

            Assert.AreEqual(fileItemVM, selectedExplorerTreeItemHandler.SelectedFiles.First());
        }

        [Test]
        public void MultiselectDesicions__IsMultiselectCombinationDirectoriesAndFilesAllowedTrue_AndIsEnsuredOnlyDirectoriesAndFilesAreNowSelectableByMultiselectTrue__ReturnsTrue()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            selectionConfiguration.IsMultiselectCombinationDirectoriesAndFilesAllowed = true;

            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            FileSelectionHandler fileSelectionHandler = new FileSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            FileItemViewModel fileItemVM = new FileItemViewModel();


            bool result = fileSelectionHandler.MultiselectDesicions(true, fileItemVM);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void MultiselectDesicions__IsMultiselectCombinationDirectoriesAndFilesAllowedTrue_AndIsEnsuredOnlyDirectoriesAndFilesAreNowSelectableByMultiselectFalseBecauseDriveWasSelectedFirst__ReturnsFalse()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            selectionConfiguration.IsMultiselectCombinationDirectoriesAndFilesAllowed = true;

            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            selectedExplorerTreeItemHandler.SelectedDrives.Add(new DriveItemViewModel());
            FileSelectionHandler fileSelectionHandler = new FileSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            FileItemViewModel fileItemVM = new FileItemViewModel();


            bool result = fileSelectionHandler.MultiselectDesicions(true, fileItemVM);

            Assert.AreEqual(false, result);
        }




        [Test]
        public void MultiselectDesicions_IsEnsuredOnlyFilesAreNowSelectableByMultiselectTrue_FileVMIsInListSelectedExplorerTreeItems()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            FileSelectionHandler fileSelectionHandler = new FileSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            FileItemViewModel fileItemVM = new FileItemViewModel();

            fileSelectionHandler.MultiselectDesicions(true, fileItemVM);

            Assert.AreEqual(fileItemVM, selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.First());

        }

        [Test]
        public void MultiselectDesicions_IsEnsuredOnlyFilesAreNowSelectableByMultiselectTrue_FileVMIsInListSelectedFiles()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            FileSelectionHandler fileSelectionHandler = new FileSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            FileItemViewModel fileItemVM = new FileItemViewModel();

            fileSelectionHandler.MultiselectDesicions(true, fileItemVM);

            Assert.AreEqual(fileItemVM, selectedExplorerTreeItemHandler.SelectedFiles.First());
        }

        [Test]
        public void MultiselectDesicions_IsEnsuredOnlyFilesAreNowSelectableByMultiselectTrue_ReturnsTrue()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            FileSelectionHandler fileSelectionHandler = new FileSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            FileItemViewModel fileItemVM = new FileItemViewModel();

            bool result = fileSelectionHandler.MultiselectDesicions(true, fileItemVM);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void MultiselectDesicions_IsEnsuredOnlyFilesAreNowSelectableByMultiselectFalseBecauseDriveWasSelectedFirst_ReturnsFalse()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            selectedExplorerTreeItemHandler.SelectedDrives.Add(new DriveItemViewModel());
            FileSelectionHandler fileSelectionHandler = new FileSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            FileItemViewModel fileItemVM = new FileItemViewModel();

            bool result = fileSelectionHandler.MultiselectDesicions(true, fileItemVM);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void MultiselectDesicions_IsEnsuredOnlyFilesAreNowSelectableByMultiselectFalseBecauseDirectoryWasSelectedFirst_ReturnsFalse()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            selectedExplorerTreeItemHandler.SelectedDirectories.Add(new DirectoryItemViewModel());
            FileSelectionHandler fileSelectionHandler = new FileSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            FileItemViewModel fileItemVM = new FileItemViewModel();

            bool result = fileSelectionHandler.MultiselectDesicions(true, fileItemVM);

            Assert.AreEqual(false, result);
        }




        [Test]
        public void AddOrRemoveFileAccordingToIsSelected_Add_FileVMIsInListSelectedExplorerTreeItems()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            FileSelectionHandler fileSelectionHandler = new FileSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            FileItemViewModel fileItemVM = new FileItemViewModel();

            fileSelectionHandler.AddOrRemoveFileAccordingToIsSelected(true, fileItemVM);

            Assert.AreEqual(fileItemVM, selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.First());
        }

        [Test]
        public void AddOrRemoveFileAccordingToIsSelected_Add_FileVMIsInListSelectedFiles()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            FileSelectionHandler fileSelectionHandler = new FileSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            FileItemViewModel fileItemVM = new FileItemViewModel();

            fileSelectionHandler.AddOrRemoveFileAccordingToIsSelected(true, fileItemVM);

            Assert.AreEqual(fileItemVM, selectedExplorerTreeItemHandler.SelectedFiles.First());
        }



        [Test]
        public void AddOrRemoveFileAccordingToIsSelected_Remove_FileVMIsInListSelectedExplorerTreeItems()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);

            FileSelectionHandler fileSelectionHandler = new FileSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            FileItemViewModel fileItemVM = new FileItemViewModel();

            selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.Add(new FileItemViewModel());
            selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.Add(fileItemVM);
            selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.Add(new FileItemViewModel());
            selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.Add(new FileItemViewModel());


            fileSelectionHandler.AddOrRemoveFileAccordingToIsSelected(false, fileItemVM);

            Assert.AreEqual(-1, selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.IndexOf(fileItemVM));
        }

        [Test]
        public void AddOrRemoveFileAccordingToIsSelected_Remove_FileVMIsInListSelectedFiles()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);

            FileSelectionHandler fileSelectionHandler = new FileSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            FileItemViewModel fileItemVM = new FileItemViewModel();

            selectedExplorerTreeItemHandler.SelectedFiles.Add(new FileItemViewModel());
            selectedExplorerTreeItemHandler.SelectedFiles.Add(fileItemVM);
            selectedExplorerTreeItemHandler.SelectedFiles.Add(new FileItemViewModel());
            selectedExplorerTreeItemHandler.SelectedFiles.Add(new FileItemViewModel());


            fileSelectionHandler.AddOrRemoveFileAccordingToIsSelected(false, fileItemVM);

            Assert.AreEqual(-1, selectedExplorerTreeItemHandler.SelectedFiles.IndexOf(fileItemVM));
        }

    }
}

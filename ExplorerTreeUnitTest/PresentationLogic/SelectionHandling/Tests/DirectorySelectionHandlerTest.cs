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
    public class DirectorySelectionHandlerTest
    {




        [Test]
        public void MultiselectDesicions_IsMultiselectCombinationAllTypesAllowedTrue_DirectoryVMIsInListSelectedExplorerTreeItems()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            selectionConfiguration.IsMultiselectCombinationAllTypesAllowed = true;

            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DirectorySelectionHandler directorySelectionHandler = new DirectorySelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DirectoryItemViewModel directoryItemVM = new DirectoryItemViewModel();


            directorySelectionHandler.MultiselectDesicions(true, directoryItemVM);

            Assert.AreEqual(directoryItemVM, selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.First());
        }

        [Test]
        public void MultiselectDesicions_IsMultiselectCombinationAllTypesAllowedTrue_DirectoryVMIsInListSelectedDirectories()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            selectionConfiguration.IsMultiselectCombinationAllTypesAllowed = true;

            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DirectorySelectionHandler directorySelectionHandler = new DirectorySelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DirectoryItemViewModel directoryItemVM = new DirectoryItemViewModel();


            bool result = directorySelectionHandler.MultiselectDesicions(true, directoryItemVM);

            Assert.AreEqual(directoryItemVM, selectedExplorerTreeItemHandler.SelectedDirectories.First());
        }

        [Test]
        public void MultiselectDesicions_IsMultiselectCombinationAllTypesAllowedTrue_ReturnsTrue()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            selectionConfiguration.IsMultiselectCombinationAllTypesAllowed = true;

            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DirectorySelectionHandler directorySelectionHandler = new DirectorySelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DirectoryItemViewModel directoryItemVM = new DirectoryItemViewModel();


            bool result = directorySelectionHandler.MultiselectDesicions(true, directoryItemVM);

            Assert.AreEqual(true, result);
        }




        [Test]
        public void MultiselectDesicions__IsMultiselectCombinationDirectoriesAndFilesAllowedTrue_AndIsEnsuredOnlyDirectoriesAndFilesAreNowSelectableByMultiselectTrue__DirectoryVMIsInListSelectedExplorerTreeItems()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            selectionConfiguration.IsMultiselectCombinationDirectoriesAndFilesAllowed = true;

            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DirectorySelectionHandler directorySelectionHandler = new DirectorySelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DirectoryItemViewModel directoryItemVM = new DirectoryItemViewModel();


            directorySelectionHandler.MultiselectDesicions(true, directoryItemVM);

            Assert.AreEqual(directoryItemVM, selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.First());
        }

        [Test]
        public void MultiselectDesicions__IsMultiselectCombinationDirectoriesAndFilesAllowedTrue_AndIsEnsuredOnlyDirectoriesAndFilesAreNowSelectableByMultiselectTrue__DirectoryVMIsInListSelectedDirectories()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            selectionConfiguration.IsMultiselectCombinationDirectoriesAndFilesAllowed = true;

            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DirectorySelectionHandler directorySelectionHandler = new DirectorySelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DirectoryItemViewModel directoryItemVM = new DirectoryItemViewModel();


            bool result = directorySelectionHandler.MultiselectDesicions(true, directoryItemVM);

            Assert.AreEqual(directoryItemVM, selectedExplorerTreeItemHandler.SelectedDirectories.First());
        }

        [Test]
        public void MultiselectDesicions__IsMultiselectCombinationDirectoriesAndFilesAllowedTrue_AndIsEnsuredOnlyDirectoriesAndFilesAreNowSelectableByMultiselectTrue__ReturnsTrue()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            selectionConfiguration.IsMultiselectCombinationDirectoriesAndFilesAllowed = true;

            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DirectorySelectionHandler directorySelectionHandler = new DirectorySelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DirectoryItemViewModel directoryItemVM = new DirectoryItemViewModel();


            bool result = directorySelectionHandler.MultiselectDesicions(true, directoryItemVM);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void MultiselectDesicions__IsMultiselectCombinationDirectoriesAndFilesAllowedTrue_AndIsEnsuredOnlyDirectoriesAndFilesAreNowSelectableByMultiselectFalseBecauseDriveWasSelectedFirst__ReturnsFalse()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            selectionConfiguration.IsMultiselectCombinationDirectoriesAndFilesAllowed = true;

            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            selectedExplorerTreeItemHandler.SelectedDrives.Add(new DriveItemViewModel());
            DirectorySelectionHandler directorySelectionHandler = new DirectorySelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DirectoryItemViewModel directoryItemVM = new DirectoryItemViewModel();


            bool result = directorySelectionHandler.MultiselectDesicions(true, directoryItemVM);

            Assert.AreEqual(false, result);
        }




        [Test]
        public void MultiselectDesicions_IsEnsuredOnlyDirectoriesAreNowSelectableByMultiselectTrue_DirectoryVMIsInListSelectedExplorerTreeItems()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DirectorySelectionHandler directorySelectionHandler = new DirectorySelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DirectoryItemViewModel directoryItemVM = new DirectoryItemViewModel();

            directorySelectionHandler.MultiselectDesicions(true, directoryItemVM);

            Assert.AreEqual(directoryItemVM, selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.First());

        }

        [Test]
        public void MultiselectDesicions_IsEnsuredOnlyDirectoriesAreNowSelectableByMultiselectTrue_DirectoryVMIsInListSelectedDirectories()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DirectorySelectionHandler directorySelectionHandler = new DirectorySelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DirectoryItemViewModel directoryItemVM = new DirectoryItemViewModel();

            directorySelectionHandler.MultiselectDesicions(true, directoryItemVM);

            Assert.AreEqual(directoryItemVM, selectedExplorerTreeItemHandler.SelectedDirectories.First());
        }

        [Test]
        public void MultiselectDesicions_IsEnsuredOnlyDirectoriesAreNowSelectableByMultiselectTrue_ReturnsTrue()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DirectorySelectionHandler directorySelectionHandler = new DirectorySelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DirectoryItemViewModel directoryItemVM = new DirectoryItemViewModel();

            bool result = directorySelectionHandler.MultiselectDesicions(true, directoryItemVM);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void MultiselectDesicions_IsEnsuredOnlyDirectoriesAreNowSelectableByMultiselectFalseBecauseDriveWasSelectedFirst_ReturnsFalse()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            selectedExplorerTreeItemHandler.SelectedDrives.Add(new DriveItemViewModel());
            DirectorySelectionHandler directorySelectionHandler = new DirectorySelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DirectoryItemViewModel directoryItemVM = new DirectoryItemViewModel();

            bool result = directorySelectionHandler.MultiselectDesicions(true, directoryItemVM);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void MultiselectDesicions_IsEnsuredOnlyDirectoriesAreNowSelectableByMultiselectFalseBecauseFileWasSelectedFirst_ReturnsFalse()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            selectedExplorerTreeItemHandler.SelectedFiles.Add(new FileItemViewModel());
            DirectorySelectionHandler directorySelectionHandler = new DirectorySelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DirectoryItemViewModel directoryItemVM = new DirectoryItemViewModel();

            bool result = directorySelectionHandler.MultiselectDesicions(true, directoryItemVM);

            Assert.AreEqual(false, result);
        }




        [Test]
        public void AddOrRemoveDirectoryAccordingToIsSelected_Add_DirectoryVMIsInListSelectedExplorerTreeItems()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DirectorySelectionHandler directorySelectionHandler = new DirectorySelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DirectoryItemViewModel directoryItemVM = new DirectoryItemViewModel();

            directorySelectionHandler.AddOrRemoveDirectoryAccordingToIsSelected(true, directoryItemVM);

            Assert.AreEqual(directoryItemVM, selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.First());
        }

        [Test]
        public void AddOrRemoveDirectoryAccordingToIsSelected_Add_DirectoryVMIsInListSelectedDirectories()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DirectorySelectionHandler directorySelectionHandler = new DirectorySelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DirectoryItemViewModel directoryItemVM = new DirectoryItemViewModel();

            directorySelectionHandler.AddOrRemoveDirectoryAccordingToIsSelected(true, directoryItemVM);

            Assert.AreEqual(directoryItemVM, selectedExplorerTreeItemHandler.SelectedDirectories.First());
        }



        [Test]
        public void AddOrRemoveDirectoryAccordingToIsSelected_Remove_DirectoryVMIsInListSelectedExplorerTreeItems()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);

            DirectorySelectionHandler directorySelectionHandler = new DirectorySelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DirectoryItemViewModel directoryItemVM = new DirectoryItemViewModel();

            selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.Add(new DirectoryItemViewModel());
            selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.Add(directoryItemVM);
            selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.Add(new DirectoryItemViewModel());
            selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.Add(new DirectoryItemViewModel());


            directorySelectionHandler.AddOrRemoveDirectoryAccordingToIsSelected(false, directoryItemVM);

            Assert.AreEqual(-1, selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.IndexOf(directoryItemVM));
        }

        [Test]
        public void AddOrRemoveDirectoryAccordingToIsSelected_Remove_DirectoryVMIsInListSelectedDirectories()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);

            DirectorySelectionHandler directorySelectionHandler = new DirectorySelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DirectoryItemViewModel directoryItemVM = new DirectoryItemViewModel();

            selectedExplorerTreeItemHandler.SelectedDirectories.Add(new DirectoryItemViewModel());
            selectedExplorerTreeItemHandler.SelectedDirectories.Add(directoryItemVM);
            selectedExplorerTreeItemHandler.SelectedDirectories.Add(new DirectoryItemViewModel());
            selectedExplorerTreeItemHandler.SelectedDirectories.Add(new DirectoryItemViewModel());


            directorySelectionHandler.AddOrRemoveDirectoryAccordingToIsSelected(false, directoryItemVM);

            Assert.AreEqual(-1, selectedExplorerTreeItemHandler.SelectedDirectories.IndexOf(directoryItemVM));
        }

    }
}

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
    public class DriveSelectionHandlerTest
    {





        [Test]
        public void MultiselectDesicions_IsMultiselectCombinationAllTypesAllowedTrue_DriveVMIsInListSelectedExplorerTreeItems()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            selectionConfiguration.IsMultiselectCombinationAllTypesAllowed = true;

            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DriveSelectionHandler driveSelectionHandler = new DriveSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DriveItemViewModel driveItemVM = new DriveItemViewModel();


            driveSelectionHandler.MultiselectDesicions(true, driveItemVM);

            Assert.AreEqual(driveItemVM, selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.First());
        }

        [Test]
        public void MultiselectDesicions_IsMultiselectCombinationAllTypesAllowedTrue_DriveVMIsInListSelectedDirectories()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            selectionConfiguration.IsMultiselectCombinationAllTypesAllowed = true;

            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DriveSelectionHandler driveSelectionHandler = new DriveSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DriveItemViewModel driveItemVM = new DriveItemViewModel();


            driveSelectionHandler.MultiselectDesicions(true, driveItemVM);

            Assert.AreEqual(driveItemVM, selectedExplorerTreeItemHandler.SelectedDrives.First());
        }

        [Test]
        public void MultiselectDesicions_IsMultiselectCombinationAllTypesAllowedTrue_ReturnsTrue()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            selectionConfiguration.IsMultiselectCombinationAllTypesAllowed = true;

            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DriveSelectionHandler driveSelectionHandler = new DriveSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DriveItemViewModel driveItemVM = new DriveItemViewModel();


            bool result = driveSelectionHandler.MultiselectDesicions(true, driveItemVM);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void MultiselectDesicions_IsMultiselectCombinationDirectoriesAndFilesAllowedTrue_ReturnsFalse()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            selectionConfiguration.IsMultiselectCombinationDirectoriesAndFilesAllowed = true;

            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DriveSelectionHandler driveSelectionHandler = new DriveSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DriveItemViewModel driveItemVM = new DriveItemViewModel();


            bool result = driveSelectionHandler.MultiselectDesicions(true, driveItemVM);

            Assert.AreEqual(false, result);
        }

      




        [Test]
        public void MultiselectDesicions_IsEnsuredOnlyDrivesAreNowSelectableByMultiselectTrue_DirveVMIsInListSelectedExplorerTreeItems()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DriveSelectionHandler driveSelectionHandler = new DriveSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DriveItemViewModel driveItemVM = new DriveItemViewModel();

            driveSelectionHandler.MultiselectDesicions(true, driveItemVM);

            Assert.AreEqual(driveItemVM, selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.First());
        }

        [Test]
        public void MultiselectDesicions_IsEnsuredOnlyDrivesAreNowSelectableByMultiselectTrue_DriveVMIsInListSelectedDrives()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DriveSelectionHandler driveSelectionHandler = new DriveSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DriveItemViewModel driveItemVM = new DriveItemViewModel();

            driveSelectionHandler.MultiselectDesicions(true, driveItemVM);

            Assert.AreEqual(driveItemVM, selectedExplorerTreeItemHandler.SelectedDrives.First());
        }

        [Test]
        public void MultiselectDesicions_IsEnsuredOnlyDrivesAreNowSelectableByMultiselectTrue_ReturnsTrue()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DriveSelectionHandler driveSelectionHandler = new DriveSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DriveItemViewModel driveItemVM = new DriveItemViewModel();

            bool result = driveSelectionHandler.MultiselectDesicions(true, driveItemVM);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void MultiselectDesicions_IsEnsuredOnlyDrivesAreNowSelectableByMultiselectFalseBecauseDirectoriesWasSelectedFirst_ReturnsFalse()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            selectedExplorerTreeItemHandler.SelectedDirectories.Add(new DirectoryItemViewModel());
            DriveSelectionHandler driveSelectionHandler = new DriveSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DriveItemViewModel driveItemVM = new DriveItemViewModel();

            bool result = driveSelectionHandler.MultiselectDesicions(true, driveItemVM);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void MultiselectDesicions_IsEnsuredOnlyDrivesAreNowSelectableByMultiselectFalseBecauseFileWasSelectedFirst_ReturnsFalse()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            selectedExplorerTreeItemHandler.SelectedFiles.Add(new FileItemViewModel());
            DriveSelectionHandler driveSelectionHandler = new DriveSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DriveItemViewModel driveItemVM = new DriveItemViewModel();

            bool result = driveSelectionHandler.MultiselectDesicions(true, driveItemVM);

            Assert.AreEqual(false, result);
        }




        [Test]
        public void AddOrRemoveDriveAccordingToIsSelected_Add_DriveVMIsInListSelectedExplorerTreeItems()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DriveSelectionHandler driveSelectionHandler = new DriveSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DriveItemViewModel driveItemVM = new DriveItemViewModel();

            driveSelectionHandler.AddOrRemoveDriveAccordingToIsSelected(true, driveItemVM);

            Assert.AreEqual(driveItemVM, selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.First());
        }

        [Test]
        public void AddOrRemoveDriveAccordingToIsSelected_Add_DriveVMIsInListSelectedDirectories()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);
            DriveSelectionHandler driveSelectionHandler = new DriveSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DriveItemViewModel driveItemVM = new DriveItemViewModel();

            driveSelectionHandler.AddOrRemoveDriveAccordingToIsSelected(true, driveItemVM);

            Assert.AreEqual(driveItemVM, selectedExplorerTreeItemHandler.SelectedDrives.First());
        }



        [Test]
        public void AddOrRemoveDriveAccordingToIsSelected_Remove_DriveVMIsInListSelectedExplorerTreeItems()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);

            DriveSelectionHandler driveSelectionHandler = new DriveSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DriveItemViewModel driveItemVM = new DriveItemViewModel();

            selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.Add(new DriveItemViewModel());
            selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.Add(driveItemVM);
            selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.Add(new DriveItemViewModel());
            selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.Add(new DriveItemViewModel());


            driveSelectionHandler.AddOrRemoveDriveAccordingToIsSelected(false, driveItemVM);

            Assert.AreEqual(-1, selectedExplorerTreeItemHandler.SelectedExplorerTreeItems.IndexOf(driveItemVM));
        }

        [Test]
        public void AddOrRemoveDriveAccordingToIsSelected_Remove_DriveVMIsInListSelectedDirectories()
        {
            SelectionConfiguration selectionConfiguration = new SelectionConfiguration();
            SelectedExplorerTreeItemHandler selectedExplorerTreeItemHandler = new SelectedExplorerTreeItemHandler(selectionConfiguration);

            DriveSelectionHandler driveSelectionHandler = new DriveSelectionHandler(selectedExplorerTreeItemHandler, selectionConfiguration);
            DriveItemViewModel driveItemVM = new DriveItemViewModel();

            selectedExplorerTreeItemHandler.SelectedDrives.Add(new DriveItemViewModel());
            selectedExplorerTreeItemHandler.SelectedDrives.Add(driveItemVM);
            selectedExplorerTreeItemHandler.SelectedDrives.Add(new DriveItemViewModel());
            selectedExplorerTreeItemHandler.SelectedDrives.Add(new DriveItemViewModel());


            driveSelectionHandler.AddOrRemoveDriveAccordingToIsSelected(false, driveItemVM);

            Assert.AreEqual(-1, selectedExplorerTreeItemHandler.SelectedDrives.IndexOf(driveItemVM));
        }

    }
}

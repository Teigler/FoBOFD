using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExplorerTree.API.Configuration.SelectionConfiguration;

namespace ExplorerTreeUnitTest.API.Configuration.SelectionConfiguration.Tests
{
    [TestFixture]
    public class SelectionConfigurationTest
    {


        private static ExplorerTree.API.Configuration.SelectionConfiguration.SelectionConfiguration CreateSelectionConfiguration()
        {
            return new ExplorerTree.API.Configuration.SelectionConfiguration.SelectionConfiguration();
        }

        [Test]
        public void SelectionConfiguration_DefaultInitialisation_PropertyIsMultiselectCombinationDirectoriesAndFilesAllowedIsInitialised()
        {
            var selectionConfiguration = CreateSelectionConfiguration();

            Assert.AreEqual(false, selectionConfiguration.IsMultiselectCombinationDirectoriesAndFilesAllowed);
        }

        [Test]
        public void SelectionConfiguration_DefaultInitialisation_PropertyIsMultiselectCombinationAllTypesAllowedIsInitialised()
        {
            var selectionConfiguration = CreateSelectionConfiguration();

            Assert.AreEqual(false, selectionConfiguration.IsMultiselectCombinationAllTypesAllowed);
        }

        [Test]
        public void IsMultiselectCombinationDirectoriesAndFilesAllowed_GetSet_ReturnSetValue()
        {
            var selectionConfiguration = CreateSelectionConfiguration();

            selectionConfiguration.IsMultiselectCombinationDirectoriesAndFilesAllowed = true;

            Assert.AreEqual(true, selectionConfiguration.IsMultiselectCombinationDirectoriesAndFilesAllowed);
        }

        [Test]
        public void IsMultiselectCombinationAllTypesAllowed_GetSet_ReturnSetValue()
        {
            var selectionConfiguration = CreateSelectionConfiguration();

            selectionConfiguration.IsMultiselectCombinationAllTypesAllowed = true;

            Assert.AreEqual(true, selectionConfiguration.IsMultiselectCombinationAllTypesAllowed);
        }
    }
}

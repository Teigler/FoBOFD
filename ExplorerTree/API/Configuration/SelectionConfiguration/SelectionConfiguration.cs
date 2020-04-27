using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.API.Configuration.SelectionConfiguration
{
    /// <summary>
    /// 
    /// </summary>
    public class SelectionConfiguration
    {
        public SelectionConfiguration()
        {
            this.IsMultiselectCombinationDirectoriesAndFilesAllowed = false;
            this.IsMultiselectCombinationAllTypesAllowed = false;
        }

        /// <summary>
        /// Specifies whether files and directories can be selected 
        /// combined in a multiselect selection.
        /// <para>
        ///     Attention:  if both <see cref="IsMultiselectCombinationDirectoriesAndFilesAllowed"/> 
        ///                 and <see cref="IsMultiselectCombinationAllTypesAllowed"/> are <see langword="true"/>,
        ///                 then <see cref="IsMultiselectCombinationAllTypesAllowed"/>  dominates!!!
        ///                 <see cref="IsMultiselectCombinationDirectoriesAndFilesAllowed"/>  is then no longer 
        ///                 considered. 
        ///                 For the exact implementation see: 
        ///                 <see cref="PresentationLogic.SelectionHandling.DirectorySelectionHandler"/>
        ///                 <see cref="PresentationLogic.SelectionHandling.DriveSelectionHandler"/>
        ///                 <see cref="PresentationLogic.SelectionHandling.FileSelectionHandler"/>
        /// </para>
        /// <para>
        ///     Default: <see langword="false"/>
        /// </para>
        /// </summary>
        public bool IsMultiselectCombinationDirectoriesAndFilesAllowed { get; set; }

        /// <summary>
        /// Specifies whether all types, e.g. files, directories and drives 
        /// can be selected in combination in a multiselect selection.
        /// <para>
        ///     Attention:  if both <see cref="IsMultiselectCombinationDirectoriesAndFilesAllowed"/> 
        ///                 and <see cref="IsMultiselectCombinationAllTypesAllowed"/> are <see langword="true"/>,
        ///                 then <see cref="IsMultiselectCombinationAllTypesAllowed"/>  dominates!!!
        ///                 <see cref="IsMultiselectCombinationDirectoriesAndFilesAllowed"/>  is then no longer 
        ///                 considered. 
        ///                 For the exact implementation see: 
        ///                 <see cref="PresentationLogic.SelectionHandling.DirectorySelectionHandler"/>
        ///                 <see cref="PresentationLogic.SelectionHandling.DriveSelectionHandler"/>
        ///                 <see cref="PresentationLogic.SelectionHandling.FileSelectionHandler"/>
        /// </para>
        /// <para>
        ///     Default: <see langword="false"/>
        /// </para> 
        /// </summary>
        public bool IsMultiselectCombinationAllTypesAllowed { get; set; }
    }
}

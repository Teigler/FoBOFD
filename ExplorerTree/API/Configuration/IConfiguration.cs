using ExplorerTree.API.Configuration.ExplorerTreeItemConfiguration;
using ExplorerTree.PresentationLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.API.Configuration
{
    public interface IConfiguration
    {
        /// <summary>
        /// Configuration initialisation.
        /// </summary>
        /// <param name="explorerTreeVM"></param>
        void Initialisation(ExplorerTreeViewModel explorerTreeVM = null);

        /// <summary>
        /// To manipulate the current status and behavior 
        /// of the <see cref="ExplorerTree"/>-Component.
        /// </summary>
        ExplorerTreeViewModel ExplorerTreeVM { get; set; }

        /// <summary>
        /// Configure the Font-Elements of the ExplorerTree.
        /// </summary>
        FontOverallConfiguration FontOverall { get; set; }

        /// <summary>
        /// Configure the Icons of the ExplorerTree.
        /// </summary>
        IconOverallConfiguration IconOverall { get; set; }

        /// <summary>
        /// Configuration only for Drive-Elements.
        /// </summary>
        DriveConfiguration Drive { get; set; }

        /// <summary>
        /// Configuration only for Directory-Elements.
        /// </summary>
        AExplorerTreeChildItemConfiguration Directory { get; set; }

        /// <summary>
        /// Configuration only for File-Elements.
        /// </summary>
        AExplorerTreeChildItemConfiguration File { get; set; }

        /// <summary>
        /// To configure the visibility of Hidden-Elements.
        /// <para>
        ///     Currently this is the only way to configure the 
        ///     visibility of the hidden elements.
        ///     For later use the drives, directories and files could be controlled individually.
        ///     But only if it makes sense to adjust the visibility of the hidden elements individually.
        /// </para>
        /// </summary>
        HiddenOverallConfiguration HiddenOverall { get; set; }

        /// <summary>
        /// To configure the selection elements and methodes
        /// </summary>
        SelectionConfiguration.SelectionConfiguration SelectionConfiguration { get; set; }
    }
}

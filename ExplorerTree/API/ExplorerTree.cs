using ExplorerTree.API.Configuration;
using ExplorerTree.PresentationLogic;
using ExplorerTree.PresentationLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.API
{
    /// <summary>
    /// Mainly responsible for communication with other components, like projects which use the ExplorerTree
    /// </summary>
    public class ExplorerTree : IExplorerTree
    {
        private IPresentationLogic presentationLogic;
        private IConfiguration configuration;
        private ExplorerTreeViewModel explorerTreeVM;
        private ISelectedExplorerTreeItemAPI selectedItemAPI;

        

        internal ExplorerTree(IConfiguration configuration = null, ExplorerTreeViewModel explorerTreeViewModel = null,
            IPresentationLogic presentationLogic = null, ISelectedExplorerTreeItemAPI selectedExplorerTreeItemAPI = null)
        {
            this.configuration = configuration ?? new Configuration.Configuration();
            this.PresentationLogic = presentationLogic ?? PresentationLogicFactory.CreatePresentationLogic(configuration);
            this.explorerTreeVM = explorerTreeViewModel ?? new ExplorerTreeViewModel((this as IExplorerTree).Configuration, this.PresentationLogic);
            this.PresentationLogic.ExplorerTreeVM = this.explorerTreeVM;
            (this as IExplorerTree).Configuration.Initialisation((this as IExplorerTree).ExplorerTreeVM);
            this.selectedItemAPI = selectedExplorerTreeItemAPI ?? new SelectedExplorerTreeItemAPI(this.explorerTreeVM);
            this.explorerTreeVM.LoadAllDriveItemViewModels();
        }


        /// <inheritdoc/>
        IConfiguration IExplorerTree.Configuration { get => configuration; }

        /// <inheritdoc/>
        ExplorerTreeViewModel IExplorerTree.ExplorerTreeVM { get => explorerTreeVM; }

        /// <summary>
        /// For communication with other components/layers, like: <see cref="BusinessLogic"/> or <see cref="Data"/>
        /// </summary>
        internal IPresentationLogic PresentationLogic { get => presentationLogic; private set => presentationLogic = value; }

        /// <inheritdoc/>
        ISelectedExplorerTreeItemAPI IExplorerTree.SelectedItemAPI { get => selectedItemAPI; }
    }
}

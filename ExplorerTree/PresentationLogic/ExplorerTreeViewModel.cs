using ExplorerTree.API.Configuration;
using ExplorerTree.Model.ExplorerTreeItems;
using ExplorerTree.PresentationLogic.API;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using ExplorerTree.PresentationLogic.SelectionHandling;
using ExplorerTree.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExplorerTree.PresentationLogic
{
    /// <summary>
    /// The <see cref="ExplorerTreeViewModel"/> is the main ViewModel for the 
    /// <see cref="ExplorerTree"/>-Component.
    /// </summary>
    public class ExplorerTreeViewModel : ExplorerTreeBaseViewModel
    {
        private ObservableCollection<DriveItemViewModel> drives;
        private ISelectedExplorerTreeItemHandler selectedItemHandler;


        internal ExplorerTreeViewModel()
        {
            this.Configuration = null;
            this.Drives = new ObservableCollection<DriveItemViewModel>();
            this.ExplorerTreeItemModelViewModelParser = null;
            this.PresentationLogic = null;
            this.SelectedItemHandler = null;
        }


        internal ExplorerTreeViewModel(IConfiguration configuration, IPresentationLogic presentationLogic)
        {
            this.Configuration = configuration;
            this.Drives = new ObservableCollection<DriveItemViewModel>();
            this.ExplorerTreeItemModelViewModelParser = new ExplorerTreeItemModelViewModelParser(presentationLogic, configuration);
            this.PresentationLogic = presentationLogic;
            this.SelectedItemHandler = new SelectedExplorerTreeItemHandler(configuration.SelectionConfiguration);


        }

        /// <summary>
        /// For loading the roots.
        /// </summary>
        /// <returns>Collection with all current available drives represented as <see cref="DriveItemModel"/></returns>
        internal virtual void LoadAllDriveItemViewModels()
        {
            this.Drives = this.ExplorerTreeItemModelViewModelParser.LoadAllDriveItemViewModels();
        }

      

        internal virtual IConfiguration Configuration { get; private set; }

        /// <summary>
        /// Collection for Binding the Tree-Items of this ExplorerTree.
        /// <para>
        ///     Decided to use the type <see cref="DriveItemViewModel"/> instead of <see cref="IExplorerTreeItemViewModel"/>
        ///     because I think its better in this case.
        ///     And other programmers cannot make mistakes like: 
        ///     add a element from type <see cref="DirectoryItemViewModel"/> to <see cref="Drives"/>-Property.
        ///     
        ///     If you disagree, please write to me!
        /// </para>
        /// </summary>
        public virtual ObservableCollection<DriveItemViewModel> Drives
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

        /// <summary>
        /// For parsing <see cref="Data.Model.ExplorerTreeItems"/>- and 
        /// <see cref="PresentationLogic.ExplorerTreeItems"/>-Elements.
        /// </summary>
        internal virtual IExplorerTreeItemModelViewModelParser ExplorerTreeItemModelViewModelParser { get; set; }

        /// <summary>
        /// For communication with other components/layers, like: <see cref="BusinessLogic"/>
        /// </summary>
        internal virtual IPresentationLogic PresentationLogic { get; private set; }

        /// <summary>
        /// Responsible for the SelectedItems in this ExplorerTree.
        /// </summary>
        internal virtual ISelectedExplorerTreeItemHandler SelectedItemHandler
        {
            get => selectedItemHandler;
            set
            {
                if (selectedItemHandler == value)
                    return;
                selectedItemHandler = value;
                OnPropertyChanged();
            }
        }
    }
}

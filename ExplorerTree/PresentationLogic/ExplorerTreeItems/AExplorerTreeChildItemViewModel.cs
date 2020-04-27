using ExplorerTree.API.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ExplorerTree.PresentationLogic.ExplorerTreeItems
{

    public abstract class AExplorerTreeChildItemViewModel : ExplorerTreeBaseViewModel, IExplorerTreeItemViewModel
    {
        private ObservableCollection<AExplorerTreeChildItemViewModel> childTreeItemVMs;
        private string fullName;
        private FontViewModel fontVM;
        private bool isExpanded;
        private bool isSelected;
        private bool isHidden;
        private IconViewModel iconVM;
        private string name;
        private Visibility visibility;


        public AExplorerTreeChildItemViewModel()
        {
            this.Configuration = null;
            this.ChildTreeItemVMs = new ObservableCollection<AExplorerTreeChildItemViewModel>();
            this.ExplorerTreeItemModelViewModelParser = null;
            this.ExplorerTreeVM = null;
            this.FullName = "init";
            this.FontVM = null;
            this.IsExpanded = false;
            this.IsSelected = false;
            this.IsHidden = false;
            this.IconVM = null;
            this.Name = "init";
            this.ParentItem = null;
            this.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// To get a expandable <see cref="IExplorerTreeItemViewModel"/> 
        /// we add a dummy child.
        /// </summary>
        protected virtual void AddDummyTreeViewItemToBeExpandable()
        {
            DirectoryItemViewModel directoryItemVM = ExplorerTreeItemViewModelsFactory.CreateDummyDirectoryItemVM();
            directoryItemVM.Name = "DummyChild";
            this.ChildTreeItemVMs.Add(directoryItemVM);
        }

        internal virtual void SetVisibilityAccordingToConfigruation(HiddenOverallConfiguration hiddenOverallConfiguration)
        {
            if(this.IsHidden)
            {
                this.Visibility = hiddenOverallConfiguration.ShowHiddenElements ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                this.Visibility = Visibility.Visible;
            }

        }





        /// <inheritdoc/>
        public virtual ObservableCollection<AExplorerTreeChildItemViewModel> ChildTreeItemVMs
        {
            get => childTreeItemVMs;
            set
            {
                if (childTreeItemVMs == value)
                    return;
                childTreeItemVMs = value;
                OnPropertyChanged();
            }
        }

        internal virtual IConfiguration Configuration { get; set; }

        /// <inheritdoc/>
        public IExplorerTreeItemModelViewModelParser ExplorerTreeItemModelViewModelParser { get; protected set; }

        /// <inheritdoc/>
        public ExplorerTreeViewModel ExplorerTreeVM { get; set; }

        /// <inheritdoc/>
        public virtual FontViewModel FontVM
        {
            get => fontVM;
            set
            {
                if (fontVM == value)
                    return;
                fontVM = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// FullName is the whole path.
        /// <para>
        ///     Default value: "init"
        /// </para>
        /// </summary>
        public virtual string FullName
        {
            get => fullName;
            set
            {
                if (fullName == value)
                    return;
                fullName = value;
                OnPropertyChanged();
            }
        }



        /// <inheritdoc/>
        public virtual bool IsExpanded
        {
            get => isExpanded;
            set
            {
                if (isExpanded == value)
                    return;
                isExpanded = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc/>
        public virtual bool IsSelected
        {
            get => isSelected;
            set
            {
                if (isSelected == value)
                    return;
                isSelected = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Specifies whether the directory (or file) referenced by this <see cref="AExplorerTreeChildItemModel"/> 
        /// is a hidden direcotry (or file).
        /// <para>
        ///     Refers to the <see cref="System.IO.FileAttributes.Hidden"/>
        /// </para>
        /// <para>
        ///     Default: <see langword="false"/>
        /// </para>
        /// </summary>
        public virtual bool IsHidden
        {
            get => isHidden;
            set
            {
                if (isHidden == value)
                    return;
                isHidden = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc/>
        public virtual IconViewModel IconVM
        {
            get => iconVM;
            set
            {
                if (iconVM == value)
                    return;
                iconVM = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc/>
        public virtual string Name
        {
            get => name;
            set
            {
                if (name == value)
                    return;
                name = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///  the item this one belongs to.
        /// </summary>
        public IExplorerTreeItemViewModel ParentItem { get; set; }

        /// <inheritdoc/>
        public virtual Visibility Visibility
        {
            get => visibility;
            set
            {
                if (visibility == value)
                    return;
                visibility = value;
                OnPropertyChanged();
            }
        }

       
    }
}

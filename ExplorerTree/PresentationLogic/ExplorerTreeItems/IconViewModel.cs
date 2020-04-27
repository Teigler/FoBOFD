using ExplorerTree.API.Configuration;
using ExplorerTree.API.Configuration.IconConfiguration;
using ExplorerTree.Model.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ExplorerTree.PresentationLogic.ExplorerTreeItems
{
    public class IconViewModel : ExplorerTreeBaseViewModel
    {
        private ImageSource activeImageSource;


        /// <summary>
        /// this constructor for test purposes only
        /// </summary>
        internal IconViewModel()
        {
            this.ActiveImageSource = null;
            this.IconConfiguration = null;
            this.IconModel = null;
            this.LargeImageSource = null;
            this.SmallImageSource = null;
        }

        internal IconViewModel(IconModel iconModel, IExplorerTreeItemIconConfiguration iconConfiguration)
        {
            this.LargeImageSource = iconModel.LargeImageSource;
            this.SmallImageSource = iconModel.SmallImageSource;
            this.IconConfiguration = iconConfiguration;
            this.IconModel = iconModel;
            this.InitActiveImageSource(iconConfiguration.ActiveIconState);
        }

        /// <summary>
        ///  
        /// <para>
        /// todo: maybe it's a bad idea to set <see cref="ActiveImageSource"/> 
        ///       to <see langword="null"/> if  <see cref="IconStates.None"/>.
        ///  but: maybe it's a good idea to do this.
        ///  
        /// What do you mean???
        /// </para>
        /// </summary>
        /// <param name="activeIconState"></param>
        private void InitActiveImageSource(IconStates activeIconState)
        {
            if (activeIconState == IconStates.SmallIcon)
            {
                this.ActiveImageSource = this.SmallImageSource;
            }
            else if (activeIconState == IconStates.LargeIcon)
            {
                this.ActiveImageSource = this.LargeImageSource;
            }
            else if (activeIconState == IconStates.None)
            {
                this.ActiveImageSource = null;
            }
        }

        protected internal virtual void SetSmallImageSourceToActiveImageSource()
        {
            this.ActiveImageSource = this.SmallImageSource;
        }

        protected internal virtual void SetLargeImageSourceToActiveImageSource()
        {
            this.ActiveImageSource = this.LargeImageSource;
        }

        /// <summary>
        /// The image (icon) of the <see cref="IExplorerTreeItemViewModel"/> that is currently displayed.
        /// <para>
        ///     Also sets the model value -> <see cref="IconModel.ActiveImageSource"/>.
        /// </para>
        /// <para>
        ///     Default: <see langword="null"/>
        /// </para>
        /// </summary>
        public virtual ImageSource ActiveImageSource
        {
            get => activeImageSource;
            set
            {
                if (activeImageSource == value)
                    return;
                this.IconModel.ActiveImageSource = value;
                activeImageSource = value;
                OnPropertyChanged();
            }
        }

        internal IconModel IconModel { get; private set; }


        internal IExplorerTreeItemIconConfiguration IconConfiguration { get; private set; }


        /// <summary>
        /// todo documentation:
        /// <para>
        ///     Default: <see langword="null"/>
        /// </para>
        /// </summary>
        internal virtual ImageSource LargeImageSource { get; private set; }

        /// <summary>
        /// todo documentation:
        /// <para>
        ///     Default: <see langword="null"/>
        /// </para>
        /// </summary>
        internal virtual ImageSource SmallImageSource { get; private set; }
    }
}

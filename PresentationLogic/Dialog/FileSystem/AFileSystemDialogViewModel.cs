using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FoBOFD.PresentationLogic.Dialog.FileSystem
{
    public abstract class AFileSystemDialogViewModel : BaseViewModel
    {

        private Visibility visibility;


        protected AFileSystemDialogViewModel()
        {
        }



        /// <summary>
        /// 
        /// <para>
        ///     Default: <see cref="Visibility.Collapsed"/>
        /// </para>
        /// </summary>
        public Visibility Visibility
        {
            get => this.visibility;
            set
            {
                if (this.visibility == value)
                    return;
                this.visibility = value;
                this.OnPropertyChanged();
            }
        }
    }
}

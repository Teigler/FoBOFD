using ExplorerTree.Utils;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FoBOFD.PresentationLogic.GeneralControls.SelectionControls.Button
{
    public class ButtonViewModel : BaseViewModel
    {

        private string content;
        private Visibility visibility;

        public ButtonViewModel()
        {
            this.Content = "init";
            this.SelectedCommand =null;
            this.Visibility = Visibility.Visible;
        }



     
        /// <summary>
        /// The Button text.
        /// </summary>
        public virtual string Content
        {
            get => this.content;
            set
            {
                if (this.content == value)
                    return;
                this.content = value;
                this.OnPropertyChanged();
            }
        }


        /// <summary>
        /// Command for <see cref="Selected(object)"/>
        /// </summary>
        public virtual ICommand SelectedCommand { get; set; }
       
        
        /// <summary>
        /// 
        /// <para>
        ///     Default: <see cref="Visibility.Visible"/>
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

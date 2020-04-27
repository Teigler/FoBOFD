using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ExplorerTreeUnitTest.PresentationLogic.ExplorerTreeItems.Fakes
{
    public class FakeIconViewModel : IconViewModel
    {

        private ImageSource activeImageSource;
        private ImageSource largeImageSource;
        private ImageSource smallImageSource;


        internal FakeIconViewModel()
        {
            this.ActiveImageSourceWasSetToSmallImageSource = false;
            this.ActiveImageSourceWasSetToLargeImageSource = false;
            
        }

        protected internal override void SetSmallImageSourceToActiveImageSource()
        {
            this.ActiveImageSourceWasSetToSmallImageSource = true;
        }

        protected internal override void SetLargeImageSourceToActiveImageSource()
        {
            this.ActiveImageSourceWasSetToLargeImageSource = true;
        }

        /// <summary>
        /// Default: false
        /// </summary>
        public bool ActiveImageSourceWasSetToSmallImageSource { get; set; }

        /// <summary>
        /// Default: false
        /// </summary>
        public bool ActiveImageSourceWasSetToLargeImageSource { get; set; }

    }
}

using ExplorerTree.API.Configuration.FontConfiguration;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExplorerTreeUnitTest.PresentationLogic.ExplorerTreeItems.Fakes
{
    public class FakeFontViewModel : FontViewModel
    {
        internal FakeFontViewModel() : base()
        {
            this.FontFamily = new System.Windows.Media.FontFamily("Times New Roman");
            this.UpdateWasCalled = false;
        }


        internal override void Update(IExplorerTreeItemFontConfiguration fontConfiguration)
        {
            this.UpdateWasCalled = true;
        }


        /// <summary>
        /// 
        /// <para>
        ///     Default: <see langword="false"/>
        /// </para>
        /// </summary>
        public bool UpdateWasCalled { get; private set; }
    }
}

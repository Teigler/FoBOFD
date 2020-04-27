using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExplorerTree.API.Configuration.FontConfiguration
{

    /// <summary>
    /// 
    /// 
    /// To enable a configuration at runtime, the already loaded FontVM must be updated. 
    /// First the FontVM of the drives are updated. Then the fontvm of the directories and files
    /// </summary>
    public interface IExplorerTreeItemFontConfiguration
    {


        /// <summary>
        /// Calls the FontVM for this FontConfiguration to update
        /// </summary>
        void UpdateFontVMCompletelyWithThisFontConfiguration(FontViewModel fontVM);


        /// <summary>
        /// Configure the <see cref="System.Windows.Media.FontFamily"/> of the <see cref="IExplorerTreeItemViewModel"/>
        /// <para>
        ///     Default: "Times New Roman"
        /// </para>
        /// </summary>
        System.Windows.Media.FontFamily FontFamily { get; set; }
     

        /// <summary>
        /// Configure the <see cref="System.Windows.Controls.FontSize"/> of the <see cref="IExplorerTreeItemViewModel"/>
        /// <para>
        ///     Default: 12
        /// </para>
        /// </summary>
        double FontSize { get; set; }

        /// <summary>
        /// Configure the <see cref="System.Windows.FontStretch"/> of the <see cref="IExplorerTreeItemViewModel"/>
        /// <para>
        ///     Default: <see cref="FontStretches.Normal"/>
        /// </para>
        /// </summary>
        FontStretch FontStretch { get; set; }

        /// <summary>
        /// Configure the <see cref="System.Windows.FontStyle"/> of the <see cref="IExplorerTreeItemViewModel"/>
        /// <para>
        ///     Default: <see cref="FontStyles.Normal"/>
        /// </para>
        /// </summary>
        System.Windows.FontStyle FontStyle { get; set; }

        /// <summary>
        /// Configure the <see cref="System.Windows.FontWeight"/> of the <see cref="IExplorerTreeItemViewModel"/>
        /// <para>
        ///     Default: <see cref="FontWeights.Normal"/>
        /// </para>
        /// </summary>
        FontWeight FontWeight { get; set; }
    }
}

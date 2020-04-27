using ExplorerTree.PresentationLogic;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExplorerTree.View
{
    /// <summary>
    /// Interaktionslogik für ExplorerTree.xaml
    /// </summary>
    public partial class ExplorerTreeView : UserControl
    {
        public ExplorerTreeView()
        {
            InitializeComponent();
        }

        private void MultiSelectTreeView_PreviewSelectionChanged(object sender, PreviewSelectionChangedEventArgs e)
        {
            // multiSelectTreeView.sele
            var vm = (ExplorerTreeViewModel)this.DataContext;
        }

        //    private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        //    {

        //    }

        //    private void TreeView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //    {

        //    }
        //}
    }
}

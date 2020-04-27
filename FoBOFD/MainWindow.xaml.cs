using FoBOFD.PresentationLogic;
using FoBOFD.PresentationLogic.API;
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

namespace FoBOFD
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPresentationLogic presentationLogic;
        public MainWindow()
        {
            InitializeComponent();
            this.presentationLogic = PresentationLogicFactory.CreatePresentationLogic();
            this.DataContext = presentationLogic.MainWindowVM;
        }
    }
}

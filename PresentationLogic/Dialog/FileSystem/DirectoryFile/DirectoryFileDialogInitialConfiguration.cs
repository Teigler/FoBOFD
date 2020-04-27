using ExplorerTree.API.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoBOFD.PresentationLogic.Dialog.FileSystem.DirectoryFile
{
    public class DirectoryFileDialogInitialConfiguration : IDirectoryFileDialogConfiguration
    {
        internal DirectoryFileDialogInitialConfiguration(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }


        public void Configurate()
        {
            this.Configuration.FontOverall.SetFontSize(22);
            this.Configuration.File.Icon.SetSmallIconToActiveIcon();
        }

        internal IConfiguration Configuration { get; private set; }

    }
}

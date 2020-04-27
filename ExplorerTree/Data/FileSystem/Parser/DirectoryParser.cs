using ExplorerTree.Model.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.Data.FileSystem.Parser
{
    internal class DirectoryParser : IDirectoryParser
    {
        internal DirectoryParser(IconModelParser iconModelParser = null)
        {
            this.IconModelParser = iconModelParser ?? new IconModelParser();
        }


        public List<AExplorerTreeChildItemModel> DirectoriesToDirectoryItemModel(List<string> directories, IExplorerTreeItemModel parentItem)
        {
            List<AExplorerTreeChildItemModel> returnList = new List<AExplorerTreeChildItemModel>();
            foreach (var directory in directories)
            {
                DirectoryItemModel directoryItemModel = new DirectoryItemModel();
                directoryItemModel.DirectoryInfo = new DirectoryInfo(directory);
                directoryItemModel.IsHidden = this.CheckIfFileOrDirectoryIsHidden(directoryItemModel.DirectoryInfo.Attributes);
                directoryItemModel.FullName = directory;
                directoryItemModel.Name = Path.GetFileName(directory);
                directoryItemModel.IconModel = IconModelParser.ParseIconModel(directoryItemModel.IconModel, directory);
                directoryItemModel.ParentItem = parentItem;
                returnList.Add(directoryItemModel);
            }
            return returnList;
        }

        private bool CheckIfFileOrDirectoryIsHidden(FileAttributes attributes)
        {
            if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
            {
                return true;
            }
            return false;
        }


        private IconModelParser IconModelParser { get; set; }
    }
}

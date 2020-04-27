using ExplorerTree.Model.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.Data.FileSystem.Parser
{
    internal class FileParser : IFileParser
    {
        internal FileParser(IconModelParser iconModelParser = null)
        {
            this.IconModelParser = iconModelParser ?? new IconModelParser();
        }


        public List<AExplorerTreeChildItemModel> FilesToFileItemModel(List<string> files, IExplorerTreeItemModel parentItem)
        {
            List<AExplorerTreeChildItemModel> returnList = new List<AExplorerTreeChildItemModel>();
            foreach (var file in files)
            {
                FileItemModel fileItemModel = new FileItemModel();
                fileItemModel.FileInfo = new FileInfo(file);
                fileItemModel.IsHidden = this.CheckIfFileOrDirectoryIsHidden(fileItemModel.FileInfo.Attributes);
                fileItemModel.FullName = file;
                fileItemModel.Name = Path.GetFileName(file);
                fileItemModel.IconModel = IconModelParser.ParseIconModel(fileItemModel.IconModel, file);
                fileItemModel.ParentItem = parentItem;
                returnList.Add(fileItemModel);
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

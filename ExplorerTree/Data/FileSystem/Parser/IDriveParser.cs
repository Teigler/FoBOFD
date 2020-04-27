using ExplorerTree.Model.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.Data.FileSystem.Parser
{
    internal interface IDriveParser
    {


        List<DriveItemModel> ParseDrivesToDriveItemModel(List<DriveInfo> drives);
    }
}

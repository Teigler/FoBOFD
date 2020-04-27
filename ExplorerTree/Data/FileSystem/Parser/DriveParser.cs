using ExplorerTree.Model.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.Data.FileSystem.Parser
{
    internal class DriveParser : IDriveParser
    {
        public DriveParser(IconModelParser iconModelParser = null)
        {
            this.IconModelParser = iconModelParser ?? new IconModelParser();
        }

        public List<DriveItemModel> ParseDrivesToDriveItemModel(List<DriveInfo> drives)
        {
            List<DriveItemModel> returnList = new List<DriveItemModel>();
            foreach (var drive in drives)
            {
                var driveItem = new DriveItemModel();

                driveItem.DriveInfo = drive;
                driveItem.Name = drive.Name;
                driveItem.DriveType = drive.DriveType;
                driveItem.IconModel = this.IconModelParser.ParseIconModel(driveItem.IconModel, drive.Name);
                returnList.Add(driveItem);
            }
            return returnList;
        }

        private IconModelParser IconModelParser { get; set; }

    }
}

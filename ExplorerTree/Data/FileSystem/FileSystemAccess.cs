using ExplorerTree.Model.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.Data.FileSystem
{
    /// <summary>
    /// todo: documentation exceptions and think about exceptionhandling concept 
    /// </summary>
    internal class FileSystemAccess : IFileSystemAccess
    {
        internal FileSystemAccess()
        {
        }


        /// <inheritdoc/>
        public List<DriveInfo> GetDrives()
        {
            return DriveInfo.GetDrives().ToList();
        }

        /// <inheritdoc/>
        public List<string> GetDirectories(string path)
        {
            return Directory.GetDirectories(path).ToList();
        }

        /// <inheritdoc/>
        public List<string> GetFiles(string path)
        {
            return Directory.GetFiles(path).ToList();
        }
    }
}

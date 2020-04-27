using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.Data.FileSystem
{
    internal interface IFileSystemAccess
    {
        /// <summary>
        /// Returns all drives of the computer
        /// </summary>
        /// <returns></returns>
        List<DriveInfo> GetDrives();

        /// <summary>
        /// Returns all directories of the given path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        List<string> GetDirectories(string path);

        /// <summary>
        /// Returns all files of the given path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        List<string> GetFiles(string path);
    }
}

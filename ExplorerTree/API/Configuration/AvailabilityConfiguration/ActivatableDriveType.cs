using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.API.Configuration.AvailabilityConfiguration
{
    /// <summary>
    /// A normal <see cref="System.IO.DriveType"/> with the
    /// ability to set as Active with <see cref="IsActive"/>
    /// <para>
    ///  I didn't want to use a dictionary because I think a class is more flexible for the future. 
    /// </para>
    /// </summary>
    public class ActivatableDriveType
    {
        internal ActivatableDriveType()
        {
            this.DriveType = DriveType.Unknown;
            this.IsActive = true;
        }

        /// <summary>
        /// the DriveType of this <see cref="ActivatableDriveType"/>
        /// <para>
        ///     Default: <see cref="DriveType.Unknown"/>
        /// </para>
        /// </summary>
        internal virtual DriveType DriveType { get; set; }

        /// <summary>
        /// This  <see cref="ActivatableDriveType"/> is active and shown in the
        /// ExplorerTree.
        /// <para>
        ///     Default <see langword="true"/>
        /// </para>
        /// </summary>
        internal virtual bool IsActive { get; set; }
    }
}

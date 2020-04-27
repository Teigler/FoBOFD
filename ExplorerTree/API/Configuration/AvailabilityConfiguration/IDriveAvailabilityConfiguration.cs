using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExplorerTree.API.Configuration.AvailabilityConfiguration
{

    /// <summary>
    /// 
    /// 
    /// <para>
    ///     In the componente <see cref="AvailabilityConfiguration"/> is not the same inharitance structure 
    ///     as in the other ...Configurations like <see cref="ExplorerTreeItemConfiguration"/>.
    ///     Bacause the Availability for Drives or Directories and Files are too individual.
    ///     -> Maybe Directories and Files can inharit from the same base class 
    ///             -> As soon as their AvailabilityConfiguration classes are implemented. 
    ///     todo: Maybe find a better solution after all.
    /// </para>
    /// </summary>
    /// 
    public interface IDriveAvailabilityConfiguration
    {

        /// <summary>
        /// Ensures that drives of ALL types from Enum: <see cref="DriveType" be 
        /// used by users. So NO drives are visible to the users./> 
        /// can be used by the users. So they are visible for the users.
        /// </summary>
        void SetAllDrivesEnabled();

        /// <summary>
        /// Ensures that drives of all types from Enum: <see cref="DriveType"/> cannot
        /// </summary>
        void SetAllDrivesDisabled();



        /// <summary>
        /// Ensures that drives of the type <see cref="DriveType.CDRom"/> 
        /// can be used by the users. So they are visible for the users.
        /// </summary>
        /// 
        void SetCDRomDrivesEnabled();

        /// <summary>
        /// Ensures that <see cref="DriveType.CDRom"/> drives cannot be 
        /// used by users.So these drives are not visible to the users.
        /// </summary>
        void SetCDRomDrivesDisabled();



        /// <summary>
        /// Ensures that drives of the type <see cref="DriveType.Fixed"/> 
        /// can be used by the users. So they are visible for the users.
        /// </summary>
        void SetFixedDrivesEnabled();

        /// <summary>
        /// Ensures that <see cref="DriveType.Fixed"/> drives cannot be 
        /// used by users.So these drives are not visible to the users.
        /// </summary>
        void SetFixedDrivesDisabled();



        /// <summary>
        /// Ensures that drives of the type <see cref="DriveType.Network"/>
        /// can be used by the users. So they are visible for the users.
        /// </summary>
        void SetNetworkDrivesEnabled();

        /// <summary>
        /// Ensures that <see cref="DriveType.Network"/> drives cannot be 
        /// used by users.So these drives are not visible to the users.
        /// </summary>
        void SetNetworkDrivesDisabled();



        /// <summary>
        /// Ensures that drives of the type <see cref="DriveType.NoRootDirectory"/> 
        /// can be used by the users. So they are visible for the users.
        /// </summary>
        void SetNoRootDirectoryDrivesEnabled();

        /// <summary>
        /// Ensures that <see cref="DriveType.NoRootDirectory"/> drives cannot be 
        /// used by users.So these drives are not visible to the users.
        /// </summary>
        void SetNoRootDirectoryDrivesDisabled();



        /// <summary>
        /// Ensures that drives of the type <see cref="DriveType.Ram"/> 
        /// can be used by the users. So they are visible for the users.
        /// </summary>
        void SetRamDrivesEnabled();


        /// <summary>
        /// Ensures that <see cref="DriveType.Ram"/> drives cannot be 
        /// used by users.So these drives are not visible to the users.
        /// </summary>
        void SetRamDrivesDisabled();



        /// <summary>
        /// Ensures that drives of the type <see cref="DriveType.Removable"/> 
        /// can be used by the users. So they are visible for the users.
        /// </summary>
        void SetRemovableDrivesEnabled();


        /// <summary>
        /// Ensures that <see cref="DriveType.Removable"/> drives cannot be 
        /// used by users.So these drives are not visible to the users.
        /// </summary>
        void SetRemovableDrivesDisabled();



        /// <summary>
        /// Ensures that drives of the type <see cref="DriveType.Unknown"/> 
        /// can be used by the users. So they are visible for the users.
        /// </summary>
        void SetUnknownDrivesEnabled();

        /// <summary>
        /// Ensures that <see cref="DriveType.Unknown"/> drives cannot be 
        /// used by users.So these drives are not visible to the users.
        /// </summary>
        void SetUnknownDrivesDisabled();





        /// <summary>
        /// All possible Drive-Types.
        /// <para>
        ///     TODO: Check if there is a watchdog or something necessary
        ///           to ensure that the list contains only the elements 
        ///           that are valid in the <see cref="DriveType"/>-Enum.
        ///           -> Maybe with the List-Changed event. 
        ///              Or an ObservableCollection with Collection-Changed.
        /// </para>
        /// </summary>
        List<ActivatableDriveType> ActivatableDriveTypes { get;  }

    }
}

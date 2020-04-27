using ExplorerTree.PresentationLogic;
using ExplorerTree.PresentationLogic.ExplorerTreeItems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.API.Configuration.AvailabilityConfiguration
{
    /// <summary>
    /// Controls which drives or drive typs are enabled/visible or disabled/collapsed.
    /// This can be set at runtime.
    /// <para>
    ///     More features for the future:
    ///         - maybe activate and deactivate drives by name 
    ///         -...
    /// </para>
    /// </summary>
    /// 
    public class DriveAvailabilityConfiguration : IDriveAvailabilityConfiguration
    {

        internal DriveAvailabilityConfiguration()
        {
            this.ExplorerTreeVM = null;
            this.ActivatableDriveTypes = new List<ActivatableDriveType>();
        }

        internal DriveAvailabilityConfiguration(ExplorerTreeViewModel explorerTreeVM)
        {
            this.ExplorerTreeVM = explorerTreeVM;
            this.InitActivatableDriveTypes();
        }

        private void InitActivatableDriveTypes()
        {
            this.ActivatableDriveTypes = new List<ActivatableDriveType>();

            foreach (string driveType in Enum.GetNames(typeof(DriveType)))
            {
                ActivatableDriveType activatableDriveType = new ActivatableDriveType();
                activatableDriveType.DriveType = (DriveType)Enum.Parse(typeof(DriveType), driveType);
                this.ActivatableDriveTypes.Add(activatableDriveType);
            }
        }



        /// <inheritdoc/>
        public void SetAllDrivesEnabled()
        {
            this.SetCDRomDrivesEnabled();
            this.SetFixedDrivesEnabled();
            this.SetNetworkDrivesEnabled();
            this.SetNoRootDirectoryDrivesEnabled();
            this.SetRamDrivesEnabled();
            this.SetRemovableDrivesEnabled();
            this.SetUnknownDrivesEnabled();
        }

        /// <inheritdoc/>
        public void SetAllDrivesDisabled()
        {
            this.SetCDRomDrivesDisabled();
            this.SetFixedDrivesDisabled();
            this.SetNetworkDrivesDisabled();
            this.SetNoRootDirectoryDrivesDisabled();
            this.SetRamDrivesDisabled();
            this.SetRemovableDrivesDisabled();
            this.SetUnknownDrivesDisabled();
        }

        /// <inheritdoc/>
        public virtual void SetCDRomDrivesEnabled()
        {
            ActivatableDriveType driveTypeCDRom = this.GetActivatableDriveTypeByDriveType(DriveType.CDRom);
            driveTypeCDRom.IsActive = true;
            this.UpdateDrivesVisibility(DriveType.CDRom, driveTypeCDRom);
        }

        /// <inheritdoc/>
        public virtual void SetCDRomDrivesDisabled()
        {
            ActivatableDriveType driveTypeCDRom = this.GetActivatableDriveTypeByDriveType(DriveType.CDRom);
            driveTypeCDRom.IsActive = false;
            this.UpdateDrivesVisibility(DriveType.CDRom, driveTypeCDRom);
        }


        /// <inheritdoc/>
        public virtual void SetFixedDrivesEnabled()
        {
            ActivatableDriveType driveTypeFixed = this.GetActivatableDriveTypeByDriveType(DriveType.Fixed);
            driveTypeFixed.IsActive = true;
            this.UpdateDrivesVisibility(DriveType.Fixed, driveTypeFixed);
        }

        /// <inheritdoc/>
        public virtual void SetFixedDrivesDisabled()
        {
            ActivatableDriveType driveTypeFixed = this.GetActivatableDriveTypeByDriveType(DriveType.Fixed);
            driveTypeFixed.IsActive = false;
            this.UpdateDrivesVisibility(DriveType.Fixed, driveTypeFixed);
        }


        /// <inheritdoc/>
        public virtual void SetNetworkDrivesEnabled()
        {
            ActivatableDriveType driveTypeNetwork = this.GetActivatableDriveTypeByDriveType(DriveType.Network);
            driveTypeNetwork.IsActive = true;
            this.UpdateDrivesVisibility(DriveType.Network, driveTypeNetwork);
        }

        /// <inheritdoc/>
        public virtual void SetNetworkDrivesDisabled()
        {
            ActivatableDriveType driveTypeNetwork = this.GetActivatableDriveTypeByDriveType(DriveType.Network);
            driveTypeNetwork.IsActive = false;
            this.UpdateDrivesVisibility(DriveType.Network, driveTypeNetwork);
        }


        /// <inheritdoc/>
        public virtual void SetNoRootDirectoryDrivesEnabled()
        {
            ActivatableDriveType driveTypeNoRootDirectory = this.GetActivatableDriveTypeByDriveType(DriveType.NoRootDirectory);
            driveTypeNoRootDirectory.IsActive = true;
            this.UpdateDrivesVisibility(DriveType.NoRootDirectory, driveTypeNoRootDirectory);
        }

        /// <inheritdoc/>
        public virtual void SetNoRootDirectoryDrivesDisabled()
        {
            ActivatableDriveType driveTypeNoRootDirectory = this.GetActivatableDriveTypeByDriveType(DriveType.NoRootDirectory);
            driveTypeNoRootDirectory.IsActive = false;
            this.UpdateDrivesVisibility(DriveType.NoRootDirectory, driveTypeNoRootDirectory);
        }


        /// <inheritdoc/>
        public virtual void SetRamDrivesEnabled()
        {
            ActivatableDriveType driveTypeRam = this.GetActivatableDriveTypeByDriveType(DriveType.Ram);
            driveTypeRam.IsActive = true;
            this.UpdateDrivesVisibility(DriveType.Ram, driveTypeRam);
        }

        /// <inheritdoc/>
        public virtual void SetRamDrivesDisabled()
        {
            ActivatableDriveType driveTypeRam = this.GetActivatableDriveTypeByDriveType(DriveType.Ram);
            driveTypeRam.IsActive = false;
            this.UpdateDrivesVisibility(DriveType.Ram, driveTypeRam);
        }


        /// <inheritdoc/>
        public virtual void SetRemovableDrivesEnabled()
        {
            ActivatableDriveType driveTypeRemovable = this.GetActivatableDriveTypeByDriveType(DriveType.Removable);
            driveTypeRemovable.IsActive = true;
            this.UpdateDrivesVisibility(DriveType.Removable, driveTypeRemovable);
        }

        /// <inheritdoc/>
        public virtual void SetRemovableDrivesDisabled()
        {
            ActivatableDriveType driveTypeRemovable = this.GetActivatableDriveTypeByDriveType(DriveType.Removable);
            driveTypeRemovable.IsActive = false;
            this.UpdateDrivesVisibility(DriveType.Removable, driveTypeRemovable);
        }


        /// <inheritdoc/>
        public virtual void SetUnknownDrivesEnabled()
        {
            ActivatableDriveType driveTypeUnknown = this.GetActivatableDriveTypeByDriveType(DriveType.Unknown);
            driveTypeUnknown.IsActive = true;
            this.UpdateDrivesVisibility(DriveType.Unknown, driveTypeUnknown);
        }

        /// <inheritdoc/>
        public virtual void SetUnknownDrivesDisabled()
        {
            ActivatableDriveType driveTypeUnknown = this.GetActivatableDriveTypeByDriveType(DriveType.Unknown);
            driveTypeUnknown.IsActive = false;
            this.UpdateDrivesVisibility(DriveType.Unknown, driveTypeUnknown);
        }




        /// <summary>
        /// Find the <see cref="ActivatableDriveType"/> with the help of <see cref="DriveType"/> in the
        /// collection <see cref="ActivatableDriveTypes"/>.
        /// <para>
        ///     No excaption handling is required because the constructor 
        ///     of this class: <see cref="DriveAvailabilityConfiguration(ExplorerTreeViewModel)"/>
        ///     ensures that the <see cref="ActivatableDriveTypes"/>-collection never can be null or empty.
        /// </para>
        /// </summary>
        /// <param name="searchedDriveType">
        ///     This is the <see cref="DriveType"/> you need to find <see cref="ActivatableDriveType"/>
        /// </param>
        /// <returns>
        ///     The <see cref="ActivatableDriveType"/> you are looking for.
        /// </returns>
        private ActivatableDriveType GetActivatableDriveTypeByDriveType(DriveType searchedDriveType)
        {
            return this.ActivatableDriveTypes.Where(ActivatableDriveType => ActivatableDriveType.DriveType == searchedDriveType).First();
        }



        private void UpdateDrivesVisibility(DriveType driveType, ActivatableDriveType activatableDriveType)
        {
            foreach (var drive in this.ExplorerTreeVM.Drives)
            {
                if (drive.DriveType == driveType)
                {
                    drive.SetVisibleOrCollapsedAccordingToIsActiveFrom(activatableDriveType);
                }
            }
        }



        /// <inheritdoc/>
        public virtual List<ActivatableDriveType> ActivatableDriveTypes { get; private set; }

        internal virtual ExplorerTreeViewModel ExplorerTreeVM { get; set; }
    }
}

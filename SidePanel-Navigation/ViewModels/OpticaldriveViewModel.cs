using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.ViewModels
{
    public class OpticaldriveViewModel : ViewModelBase
    {
        string _opticalDriveName;
        string _opticalDriveConfigManUserConfig;
        string _opticalDriveConfigManErrCode;
        string _opticalDriveVolume;
        string _opticalDriveMediaLoaded;
        string _opticalDriveSCSIbus;
        string _opticalDriveSCSILogicalUnit;
        string _opticalDriveSCSIport;
        string _opticalDriveSCSItargetId;
        string _opticalDriveStatus;

        public string OpticalDriveName
        {
            get => PcInfoViewModel.OpticalDriveName;
            set
            {
                _opticalDriveName = value;
            }
        }

        public string OpticalDriveConfigManUserConfig
        {
            get => PcInfoViewModel.OpticalDriveConfigManUserConfig;
            set
            {
                _opticalDriveConfigManUserConfig = value;
            }
        }

        public string OpticalDriveConfigManErrCode
        {
            get => PcInfoViewModel.OpticalDriveConfigManErrCode;
            set
            {
                _opticalDriveConfigManErrCode = value;
            }
        }

        public string OpticalDriveVolume
        {
            get => PcInfoViewModel.OpticalDriveVolume;
            set
            {
                _opticalDriveVolume = value;
            }
        }

        public string OpticalDriveMediaLoaded
        {
            get => PcInfoViewModel.OpticalDriveMediaLoaded;
            set
            {
                _opticalDriveMediaLoaded = value;
            }
        }

        public string OpticalDriveSCSIbus
        {
            get => PcInfoViewModel.OpticalDriveSCSIbus;
            set
            {
                _opticalDriveSCSIbus = value;
            }
        }

        public string OpticalDriveSCSILogicalUnit
        {
            get => PcInfoViewModel.OpticalDriveSCSILogicalUnit;
            set 
            {
                _opticalDriveSCSILogicalUnit = value;
            }
        }

        public string OpticalDriveSCSIport
        {
            get => PcInfoViewModel.OpticalDriveSCSIport;
            set
            {
                _opticalDriveSCSIport = value;
            }
        }

        public string OpticalDriveSCSItargetId
        {
            get => PcInfoViewModel.OpticalDriveSCSItargetId;
            set
            {
                _opticalDriveSCSItargetId = value;
            }
        }

        public string OpticalDriveStatus
        {
            get => PcInfoViewModel.OpticalDriveStatus;
            set
            {
                _opticalDriveStatus = value;
            }
        }
    }
}

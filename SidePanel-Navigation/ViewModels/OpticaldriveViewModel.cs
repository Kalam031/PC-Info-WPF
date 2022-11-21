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
                OnPropertyChanged(nameof(OpticalDriveName));
            }
        }

        public string OpticalDriveConfigManUserConfig
        {
            get => PcInfoViewModel.OpticalDriveConfigManUserConfig;
            set
            {
                _opticalDriveConfigManUserConfig = value;
                OnPropertyChanged(nameof(OpticalDriveConfigManUserConfig));
            }
        }

        public string OpticalDriveConfigManErrCode
        {
            get => PcInfoViewModel.OpticalDriveConfigManErrCode;
            set
            {
                _opticalDriveConfigManErrCode = value;
                OnPropertyChanged(nameof(OpticalDriveConfigManErrCode));
            }
        }

        public string OpticalDriveVolume
        {
            get => PcInfoViewModel.OpticalDriveVolume;
            set
            {
                _opticalDriveVolume = value;
                OnPropertyChanged(nameof(OpticalDriveVolume));
            }
        }

        public string OpticalDriveMediaLoaded
        {
            get => PcInfoViewModel.OpticalDriveMediaLoaded;
            set
            {
                _opticalDriveMediaLoaded = value;
                OnPropertyChanged(nameof(OpticalDriveMediaLoaded));
            }
        }

        public string OpticalDriveSCSIbus
        {
            get => PcInfoViewModel.OpticalDriveSCSIbus;
            set
            {
                _opticalDriveSCSIbus = value;
                OnPropertyChanged(nameof(OpticalDriveSCSIbus));
            }
        }

        public string OpticalDriveSCSILogicalUnit
        {
            get => PcInfoViewModel.OpticalDriveSCSILogicalUnit;
            set 
            {
                _opticalDriveSCSILogicalUnit = value;
                OnPropertyChanged(nameof(OpticalDriveSCSILogicalUnit));
            }
        }

        public string OpticalDriveSCSIport
        {
            get => PcInfoViewModel.OpticalDriveSCSIport;
            set
            {
                _opticalDriveSCSIport = value;
                OnPropertyChanged(nameof(OpticalDriveSCSIport));
            }
        }

        public string OpticalDriveSCSItargetId
        {
            get => PcInfoViewModel.OpticalDriveSCSItargetId;
            set
            {
                _opticalDriveSCSItargetId = value;
                OnPropertyChanged(nameof(OpticalDriveSCSItargetId));
            }
        }

        public string OpticalDriveStatus
        {
            get => PcInfoViewModel.OpticalDriveStatus;
            set
            {
                _opticalDriveStatus = value;
                OnPropertyChanged(nameof(OpticalDriveStatus));
            }
        }
    }
}

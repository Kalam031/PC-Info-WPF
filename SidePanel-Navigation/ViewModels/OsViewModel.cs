using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace SidePanel_Navigation.ViewModels
{
    public class OsViewModel : ViewModelBase
    {
        string _operatingSystemName;
        string _operatingSystemInstallDate;
        string _operatingSystemVersion;
        string _operatingSystemSerial;
        string _operatingSystemLanguage;
        string _operatingSystemBuild;
        string _operatingSystemTimeZone;
        string _operatingSystemDateFormat;
        string _operatingSystemTimeFormat;
        string _operatingSystemLocation;
        string _operatingSystemAntivirus;
        string _operatingSystemLastBootTime;
        string _internetExplorer;
        string _powerShell;
        string _userProfile;
        string _systemProfile;

        public string OperatingSystem
        {
            get => PcInfoViewModel.OperatingSystemName;
            set
            {
                _operatingSystemName = value;
                OnPropertyChanged(nameof(OperatingSystem));
            }
        }

        public string OperatingSystemInstallDate
        {
            get => PcInfoViewModel.OperatingSystemInstallDate;
            set
            {
                _operatingSystemInstallDate = value;
                OnPropertyChanged(nameof(OperatingSystemInstallDate));
            }
        }

        public string OperatingSystemVersion
        {
            get => PcInfoViewModel.OperatingSystemVersion;
            set
            {
                _operatingSystemVersion = value;
                OnPropertyChanged(nameof(OperatingSystemVersion));
            }
        }

        public string OperatingSystemSerial
        {
            get => PcInfoViewModel.OperatingSystemSerial;
            set
            {
                _operatingSystemSerial = value;
                OnPropertyChanged(nameof(OperatingSystemSerial));
            }
        }

        public string OperatingSystemLanguage
        {
            get => PcInfoViewModel.OperatingSystemLanguage;
            set
            {
                _operatingSystemLanguage = value;
                OnPropertyChanged(nameof(OperatingSystemLanguage));
            }
        }

        public string OperatingSystemBuild
        {
            get => PcInfoViewModel.OperatingSystembuild;
            set
            {
                _operatingSystemBuild = value;
                OnPropertyChanged(nameof(OperatingSystemBuild));
            }
        }

        public string OperatingSystemTimeZone
        {
            get => PcInfoViewModel.OperatingSystemTimeZone;
            set
            {
                _operatingSystemTimeZone = value;
                OnPropertyChanged(nameof(OperatingSystemTimeZone));
            }
        }

        public string OperatingSystemDateFormat
        {
            get => PcInfoViewModel.OperatingSystemDateFormat;
            set
            {
                _operatingSystemDateFormat = value;
                OnPropertyChanged(nameof(OperatingSystemDateFormat));
            }
        }

        public string OperatingSystemTimeFormat
        { 
            get => PcInfoViewModel.OperatingSystemTimeFormat;
            set
            {
                _operatingSystemTimeFormat = value;
                OnPropertyChanged(nameof(OperatingSystemTimeFormat));
            }
        }

        public string OperatingSystemLocation
        {
            get => PcInfoViewModel.OperatingSystemLocation;
            set
            {
                _operatingSystemLocation = value;
                OnPropertyChanged(nameof(OperatingSystemLocation));
            }
        }

        public string OperatingSystemAntivirus
        {
            get => PcInfoViewModel.OperatingSystemAntivirus;
            set
            {
                _operatingSystemAntivirus = value;
                OnPropertyChanged(nameof(OperatingSystemAntivirus));
            }
        }

        public string OperatingSystemLastBootTime
        {
            get => PcInfoViewModel.OperatingSystemLastBootTime;
            set
            {
                _operatingSystemLastBootTime = value;
                OnPropertyChanged(nameof(OperatingSystemLastBootTime));
            }
        }

        public string InternetExplorer
        {
            get => PcInfoViewModel.InternetExplorer;
            set
            {
                _internetExplorer = value;
                OnPropertyChanged(nameof(InternetExplorer));
            }
        }

        public string PowerShell
        { 
            get => PcInfoViewModel.PowerShell;
            set
            {
                _powerShell = value;
                OnPropertyChanged(nameof(PowerShell));
            }
        }

        public string UserProfile
        {
            get => PcInfoViewModel.UserProfile;
            set
            {
                _userProfile = value;
                OnPropertyChanged(nameof(UserProfile));
            }
        }

        public string SystemProfile
        {
            get => _systemProfile;
            set
            {
                _systemProfile = value;
                OnPropertyChanged(nameof(SystemProfile));
            }
        }

    }
}

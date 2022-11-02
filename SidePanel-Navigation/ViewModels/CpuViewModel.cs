using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.ViewModels
{
    public class CpuViewModel : ViewModelBase
    {
        string _cpuModel;
        string _cpuId;
        string _cpuManufacturer;
        string _cpuName;
        string _cpuCore;
        string _cpuThread;
        string _cpuFamily;
        string _cpuStepping;
        string _cpuArchitecture;
        string _cpuVersion;
        string _cpuAddressWidth;
        string _cpuSocketDesignation;
        string _cpuStatus;
        string _cpuType;
        string _cpuMaxClockSpeed;
        string _cpuPowerManagementSupport;
        string _cpuBusSpeed;
        string _cpuL1CacheSize;
        string _cpuL2CacheSize;
        string _cpuL3CacheSize;

        public string CpuModel
        {
            get => PcInfoViewModel.CpuModel;
            set
            {
                _cpuModel = value;
                OnPropertyChanged(nameof(CpuModel));
            }
        }

        public string CpuId
        { 
            get => PcInfoViewModel.CpuId;
            set
            {
                _cpuId = value;
                OnPropertyChanged(nameof(CpuId));
            }
        }

        public string CpuManufacturer
        {
            get => PcInfoViewModel.CpuManufacturer;
            set
            {
                _cpuManufacturer = value;
                OnPropertyChanged(nameof(CpuManufacturer));
            }
        }

        public string CpuName
        {
            get => PcInfoViewModel.CpuName;
            set
            {
                _cpuName = value;
                OnPropertyChanged(nameof(CpuName));
            }
        }

        public string CpuCore
        {
            get => PcInfoViewModel.CpuCore;
            set
            {
                _cpuCore = value;
                OnPropertyChanged(nameof(CpuCore));
            }
        }

        public string CpuThread
        {
            get => PcInfoViewModel.CpuThread;
            set 
            {
                _cpuThread = value;
                OnPropertyChanged(nameof(CpuThread));
            }
        }

        public string CpuFamily
        {
            get => PcInfoViewModel.CpuFamily;
            set
            {
                _cpuFamily = value;
                OnPropertyChanged(nameof(CpuFamily));
            }
        }

        public string CpuStepping
        {
            get => PcInfoViewModel.CpuStepping;
            set
            {
                _cpuStepping = value;
                OnPropertyChanged(nameof(CpuStepping));
            }
        }

        public string CpuArchitecture
        {
            get => PcInfoViewModel.CpuArchitecture;
            set
            {
                _cpuArchitecture = value;
                OnPropertyChanged(nameof(CpuArchitecture));
            }
        }

        public string CpuVersion
        {
            get => PcInfoViewModel.CpuVersion;
            set
            {
                _cpuVersion = value;
                OnPropertyChanged(nameof(CpuVersion));
            }
        }

        public string CpuAddressWidth
        {
            get => PcInfoViewModel.CpuAddressWidth;
            set
            {
                _cpuAddressWidth = value;
                OnPropertyChanged(nameof(CpuAddressWidth));
            }
        }

        public string CpuSocketDesignation
        {
            get => PcInfoViewModel.CpuSocketDesignation;
            set
            {
                _cpuSocketDesignation = value;
                OnPropertyChanged(nameof(CpuSocketDesignation));
            }
        }

        public string CpuStatus
        {
            get => PcInfoViewModel.CpuStatus;
            set
            {
                _cpuStatus = value;
                OnPropertyChanged(nameof(CpuStatus));
            }
        }

        public string CpuType
        {
            get => PcInfoViewModel.CpuType;
            set
            {
                _cpuType = value;
                OnPropertyChanged(nameof(CpuType));
            }
        }

        public string CpuMaxClockSpeed
        {
            get => PcInfoViewModel.CpuMaxClockSpeed;
            set 
            {
                _cpuMaxClockSpeed = value;
                OnPropertyChanged(nameof(CpuMaxClockSpeed));
            }
        }

        public string CpuPowerManagementSupport
        {
            get => PcInfoViewModel.CpuPowerManagementSupport;
            set
            {
                _cpuPowerManagementSupport = value;
                OnPropertyChanged(nameof(CpuPowerManagementSupport));
            }
        }

        public string CpuBusSpeed
        {
            get => PcInfoViewModel.CpuBusSpeed;
            set
            {
                _cpuBusSpeed = value;
                OnPropertyChanged(nameof(CpuBusSpeed));
            }
        }

        public string CpuL2CacheSize
        {
            get => PcInfoViewModel.CpuL2CacheSize;
            set
            {
                _cpuL2CacheSize = value;
                OnPropertyChanged(nameof(CpuL2CacheSize));
            }
        }

        public string CpuL3CacheSize
        {
            get => PcInfoViewModel.CpuL3CacheSize;
            set
            {
                _cpuL3CacheSize = value;
                OnPropertyChanged(nameof(CpuL3CacheSize));
            }
        }

        public string CpuL1CacheSize
        {
            get => PcInfoViewModel.CpuL1CacheSize;
            set
            {
                _cpuL1CacheSize = value;
                OnPropertyChanged(nameof(CpuL1CacheSize));
            }
        }
    }
}

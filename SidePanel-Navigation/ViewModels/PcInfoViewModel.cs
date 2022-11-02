using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SidePanel_Navigation.ViewModels
{
    public class PcInfoViewModel : ViewModelBase
    {
        //Operating System

        static string operatingSystemName;
        static string operatingSystemInstallDate;
        static string operatingSystemLanguage;
        static string operatingSystemVersion;
        static string operatingSystemSerial;
        static string operatingSystembuild;
        static string operatingSystemTimeZone;
        static string operatingSystemDateFormat;
        static string operatingSystemTimeFormat;
        static string operatingSystemLocation;
        static string operatingSystemAntivirus;
        static string operatingSystemCurrentUptime;
        static string operatingSystemCurrentTime;
        static string operatingSystemLastBootTime;
        static string internetExplorer;
        static string powerShell;
        static string userProfile;
        static string systemProfile;

        //CPU
        static string cpuId;
        static string cpuManufacturer;
        static string cpuName;
        static string cpuCore;
        static string cpuThread;
        static string cpuFamily;
        static string cpuModel;
        static string cpuStepping;
        static string cpuArchitecture;
        static string cpuVersion;
        static string cpuAddressWidth;
        static string cpuSocketDesignation;
        static string cpuStatus;
        static string cpuType;
        static string cpuMaxClockSpeed;
        static string cpuBusSpeed;
        static string cpuPowerManagementSupport;
        static string cpuL1CacheSize;
        static string cpuL2CacheSize;
        static string cpuL3CacheSize;


        //static string computerType;
        //static string installationDate;
        //static string osSerialNo;

        //static string userAccountControl;
        //static string notifyLevel;
        //static string firewallStatus;

        //static string windowsDefenderStatus;

        //static string antivirusStatus;
        //static string antivirusName;

        //static string cpumodel;
        //static string threads;
        //static string virtualization;
        //static string hyperthreading;

        //static string memorySlots;
        //static string memoryType;
        //static string memorySize;
        //static string memoryChannel;

        //static string motherboardManufacturer;
        //static string motherboardModel;
        //static string biosBrand;

        //static string monitorName;
        //static string currentResolution;
        //static string monitorFrequency;
        //static string graphicsManufacturer;
        //static string graphicsModel;
        //static string graphicId;

        //static string hardDiskManufacturer;

        //Operating System
        public static string OperatingSystemName { get => operatingSystemName; set => operatingSystemName = value; }
        public static string OperatingSystemInstallDate { get => operatingSystemInstallDate; set => operatingSystemInstallDate = value; }
        public static string OperatingSystemLanguage { get => operatingSystemLanguage; set => operatingSystemLanguage = value; }
        public static string OperatingSystemVersion { get => operatingSystemVersion; set => operatingSystemVersion = value; }
        public static string OperatingSystemSerial { get => operatingSystemSerial; set => operatingSystemSerial = value; }
        public static string OperatingSystembuild { get => operatingSystembuild; set => operatingSystembuild = value; }
        public static string OperatingSystemTimeZone { get => operatingSystemTimeZone; set => operatingSystemTimeZone = value; }
        public static string OperatingSystemDateFormat { get => operatingSystemDateFormat; set => operatingSystemDateFormat = value; }
        public static string OperatingSystemTimeFormat { get => operatingSystemTimeFormat; set => operatingSystemTimeFormat = value; }
        public static string OperatingSystemLocation { get => operatingSystemLocation; set => operatingSystemLocation = value; }
        public static string OperatingSystemAntivirus { get => operatingSystemAntivirus; set => operatingSystemAntivirus = value; }
        public static string OperatingSystemCurrentUptime { get => operatingSystemCurrentUptime; set => operatingSystemCurrentUptime = value; }
        public static string OperatingSystemCurrentTime { get => operatingSystemCurrentTime; set => operatingSystemCurrentTime = value; }
        public static string OperatingSystemLastBootTime { get => operatingSystemLastBootTime; set => operatingSystemLastBootTime = value; }
        public static string InternetExplorer { get => internetExplorer; set => internetExplorer = value; }
        public static string PowerShell { get => powerShell; set => powerShell = value; }
        public static string UserProfile { get => userProfile; set => userProfile = value; }
        public static string SystemProfile { get => systemProfile; set => systemProfile = value; }

        //CPU
        public static string CpuId { get => cpuId; set => cpuId = value; }
        public static string CpuManufacturer { get => cpuManufacturer; set => cpuManufacturer = value; }
        public static string CpuName { get => cpuName; set => cpuName = value; }
        public static string CpuCore { get => cpuCore; set => cpuCore = value; }
        public static string CpuThread { get => cpuThread; set => cpuThread = value; }
        public static string CpuFamily { get => cpuFamily; set => cpuFamily = value; }
        public static string CpuModel { get => cpuModel; set => cpuModel = value; }
        public static string CpuStepping { get => cpuStepping; set => cpuStepping = value; }
        public static string CpuArchitecture { get => cpuArchitecture; set => cpuArchitecture = value; }
        public static string CpuVersion { get => cpuVersion; set => cpuVersion = value; }
        public static string CpuAddressWidth { get => cpuAddressWidth; set => cpuAddressWidth = value; }
        public static string CpuSocketDesignation { get => cpuSocketDesignation; set => cpuSocketDesignation = value; }
        public static string CpuStatus { get => cpuStatus; set => cpuStatus = value; }
        public static string CpuType { get => cpuType; set => cpuType = value; }
        public static string CpuMaxClockSpeed { get => cpuMaxClockSpeed; set => cpuMaxClockSpeed = value; }
        public static string CpuPowerManagementSupport { get => cpuPowerManagementSupport; set => cpuPowerManagementSupport = value; }
        public static string CpuBusSpeed { get => cpuBusSpeed; set => cpuBusSpeed = value; }
        public static string CpuL2CacheSize { get => cpuL2CacheSize; set => cpuL2CacheSize = value; }
        public static string CpuL3CacheSize { get => cpuL3CacheSize; set => cpuL3CacheSize = value; }
        public static string CpuL1CacheSize { get => cpuL1CacheSize; set => cpuL1CacheSize = value; }
    }
}

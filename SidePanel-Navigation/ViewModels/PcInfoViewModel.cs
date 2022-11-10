using SidePanel_Navigation.Models;
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
        static string cpuUsed;
        static string cpuUnused;


        //Ram
        static string memorySlots;
        static string memoryType;
        static string memoryUsage;
        static string memoryTotal;
        static string memoryAvailable;
        static List<MemInfoModel> listMemInfo;

        //Motherboard
        static string motherboardManufacturer;
        static string motherboardSerial;
        static string motherboardModel;
        static string motherboardVersion;
        static string biosVersion;
        static string biosDate;
        static string biosSerialNumber;

        //Graphics
        static string monitorWidth;
        static string monitorHeight;
        static string monitorResolution;
        static string monitorBitsPerPixel;
        static string monitorFrequency;
        static string monitorCurrentFrequency;

        static string internalGraphicsName;
        static string internalGraphicsDriverVersion;
        static string internalGraphicsDate;
        static string internalGraphicsManufacturer;
        static string internalGraphicsModel;

        //Storage
        static List<DiskDriveModel> listDiskDriveInfo;


        //Optical Drives
        static string opticalDriveName;
        static string opticalDriveConfigManUserConfig;
        static string opticalDriveConfigManErrCode;
        static string opticalDriveVolume;
        static string opticalDriveMediaLoaded;
        static string opticalDriveSCSIbus; 
        static string opticalDriveSCSILogicalUnit;  
        static string opticalDriveSCSIport;
        static string opticalDriveSCSItargetId;
        static string opticalDriveStatus;

        //Audio
        static string soundDeviceName;
        static string soundDeviceManufacturer;
        static string soundPlaybackDevices;
        static string soundConfigManUserConfig;
        static string soundDriveConfigManErrCode;

        //Peripherals

        //Network

        //static string computerType;
        //static string installationDate;
        //static string osSerialNo;

        //static string userAccountControl;
        //static string notifyLevel;
        //static string firewallStatus;

        //static string windowsDefenderStatus;

        //static string antivirusStatus;
        //static string antivirusName;

        //static string virtualization;
        //static string hyperthreading;

        //static string monitorName;

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
        public static string CpuUsed { get => cpuUsed; set => cpuUsed = value; }
        public static string CpuUnused { get => cpuUnused; set => cpuUnused = value; }

        //Ram

        public static string MemorySlots { get => memorySlots; set => memorySlots = value; }
        public static string MemoryType { get => memoryType; set => memoryType = value; }
        public static string MemoryUsage { get => memoryUsage; set => memoryUsage = value; }
        public static string MemoryTotal { get => memoryTotal; set => memoryTotal = value; }
        public static string MemoryAvailable { get => memoryAvailable; set => memoryAvailable = value; }
        public static List<MemInfoModel> ListMemInfo { get => listMemInfo; set => listMemInfo = value; }

        //Motherboard

        public static string MotherboardManufacturer { get => motherboardManufacturer; set => motherboardManufacturer = value; }
        public static string MotherboardSerial { get => motherboardSerial; set => motherboardSerial = value; }
        public static string MotherboardModel { get => motherboardModel; set => motherboardModel = value; }
        public static string MotherboardVersion { get => motherboardVersion; set => motherboardVersion = value; }
        public static string BiosVersion { get => biosVersion; set => biosVersion = value; }
        public static string BiosDate { get => biosDate; set => biosDate = value; }
        public static string BiosSerialNumber { get => biosSerialNumber; set => biosSerialNumber = value; }

        //Graphics

        public static string MonitorWidth { get => monitorWidth; set => monitorWidth = value; }
        public static string MonitorHeight { get => monitorHeight; set => monitorHeight = value; }
        public static string MonitorResolution { get => monitorResolution; set => monitorResolution = value; }
        public static string MonitorBitsPerPixel { get => monitorBitsPerPixel; set => monitorBitsPerPixel = value; }
        public static string MonitorFrequency { get => monitorFrequency; set => monitorFrequency = value; }
        public static string MonitorCurrentFrequency { get => monitorCurrentFrequency; set => monitorCurrentFrequency = value; }
        public static string InternalGraphicsName { get => internalGraphicsName; set => internalGraphicsName = value; }
        public static string InternalGraphicsDriverVersion { get => internalGraphicsDriverVersion; set => internalGraphicsDriverVersion = value; }
        public static string InternalGraphicsDate { get => internalGraphicsDate; set => internalGraphicsDate = value; }
        public static string InternalGraphicsManufacturer { get => internalGraphicsManufacturer; set => internalGraphicsManufacturer = value; }
        public static string InternalGraphicsModel { get => internalGraphicsModel; set => internalGraphicsModel = value; }

        //Optical Drive

        public static string OpticalDriveName { get => opticalDriveName; set => opticalDriveName = value; }
        public static string OpticalDriveConfigManUserConfig { get => opticalDriveConfigManUserConfig; set => opticalDriveConfigManUserConfig = value; }
        public static string OpticalDriveConfigManErrCode { get => opticalDriveConfigManErrCode; set => opticalDriveConfigManErrCode = value; }
        public static string OpticalDriveVolume { get => opticalDriveVolume; set => opticalDriveVolume = value; }
        public static string OpticalDriveMediaLoaded { get => opticalDriveMediaLoaded; set => opticalDriveMediaLoaded = value; }
        public static string OpticalDriveSCSIbus { get => opticalDriveSCSIbus; set => opticalDriveSCSIbus = value; }
        public static string OpticalDriveSCSILogicalUnit { get => opticalDriveSCSILogicalUnit; set => opticalDriveSCSILogicalUnit = value; }
        public static string OpticalDriveSCSIport { get => opticalDriveSCSIport; set => opticalDriveSCSIport = value; }
        public static string OpticalDriveSCSItargetId { get => opticalDriveSCSItargetId; set => opticalDriveSCSItargetId = value; }
        public static string OpticalDriveStatus { get => opticalDriveStatus; set => opticalDriveStatus = value; }

        //Storage

        public static List<DiskDriveModel> ListDiskDriveInfo { get => listDiskDriveInfo; set => listDiskDriveInfo = value; }
    }
}

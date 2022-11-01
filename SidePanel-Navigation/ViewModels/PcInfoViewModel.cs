using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.ViewModels
{
    public class PcInfoViewModel : ViewModelBase
    {
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
    }
}

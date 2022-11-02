using SidePanel_Navigation.Log;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SidePanel_Navigation.ViewModels;
using Microsoft.Win32;
using System.Collections;
using OSVersionExt;
using OSVersionExtension;
using System.Globalization;
using System.Windows.Controls;
using TaskScheduler;
using System.Runtime.InteropServices;

namespace SidePanel_Navigation.Controls
{
    public class GetPcInfoClass
    {
        BackgroundWorker backgroundWorker = new BackgroundWorker();

        SelectQuery Sq = new SelectQuery("Win32_DesktopMonitor");

        public GetPcInfoClass()
        {
            backgroundWorker.WorkerSupportsCancellation = true;
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(Sq);
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
        }

        public void GetInfo()
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }

            backgroundWorker.DoWork += Bg_DoWork;
            backgroundWorker.RunWorkerCompleted += Bg_RunWorkerCompleted;
        }

        private void Bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker bg = (BackgroundWorker)sender;


        }

        private void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bg = (BackgroundWorker)sender;

            if (!bg.CancellationPending)
            {
                try
                {
                    //Operating System

                    ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
                    foreach (ManagementObject wmi in mos.Get())
                    {
                        try
                        {
                            if (wmi["Caption"] != null)
                            {
                                string bitcheck = "";
                                if (Environment.Is64BitOperatingSystem) bitcheck = " 64-bit";
                                else bitcheck = " 32-bit";

                                PcInfoViewModel.OperatingSystemName = wmi["Caption"].ToString() + bitcheck;
                            }

                            if (wmi["InstallDate"] != null)
                            {
                                PcInfoViewModel.OperatingSystemInstallDate = ManagementDateTimeConverter.ToDateTime(wmi["InstallDate"].ToString()).ToString("dd-MMM-yyyy HH:mm:ss");
                            }

                            if (wmi["LastBootUpTime"] != null)
                            {
                                PcInfoViewModel.OperatingSystemLastBootTime = ManagementDateTimeConverter.ToDateTime(wmi["LastBootUpTime"].ToString()).ToString("dd-MMM-yyyy HH:mm:ss");
                            }

                            CultureInfo ci = CultureInfo.InstalledUICulture;
                            PcInfoViewModel.OperatingSystemLanguage = ci.EnglishName;

                            PcInfoViewModel.OperatingSystemVersion = OSVersion.MajorVersion10Properties().DisplayVersion.ToString() ?? "(Unable to detect)";
                            PcInfoViewModel.OperatingSystembuild = OSVersion.GetOSVersion().Version.Build.ToString();

                            RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
                            RegistryKey windowsNTKey = localMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion");
                            object productID = windowsNTKey.GetValue("ProductId");

                            PcInfoViewModel.OperatingSystemSerial = productID.ToString();

                            TimeZone localZone = TimeZone.CurrentTimeZone;
                            TimeZoneInfo localtimeZone = TimeZoneInfo.Local;
                            string sysDateFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                            string sysTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;

                            PcInfoViewModel.OperatingSystemTimeZone = TimeZoneInfo.Local.DisplayName;
                            PcInfoViewModel.OperatingSystemDateFormat = sysDateFormat;
                            PcInfoViewModel.OperatingSystemTimeFormat = sysTimeFormat;
                            PcInfoViewModel.OperatingSystemLocation = localtimeZone.Id.Split(' ')[0];

                            using (mos = new ManagementObjectSearcher(@"\\" + Environment.MachineName + @"\root\SecurityCenter2", "SELECT * FROM AntivirusProduct"))
                            {
                                var searcherInstance = mos.Get();
                                foreach (var instance in searcherInstance)
                                {
                                    PcInfoViewModel.OperatingSystemAntivirus = instance["displayName"].ToString();
                                }
                            }

                            Console.WriteLine(PcInfoViewModel.OperatingSystemName);
                            Console.WriteLine(PcInfoViewModel.OperatingSystemInstallDate);
                            Console.WriteLine(PcInfoViewModel.OperatingSystemLanguage);
                            Console.WriteLine(PcInfoViewModel.OperatingSystemVersion);
                            Console.WriteLine(PcInfoViewModel.OperatingSystembuild);
                            Console.WriteLine(PcInfoViewModel.OperatingSystemSerial);
                            Console.WriteLine(PcInfoViewModel.OperatingSystemTimeZone);
                            Console.WriteLine(PcInfoViewModel.OperatingSystemDateFormat);
                            Console.WriteLine(PcInfoViewModel.OperatingSystemTimeFormat);
                            Console.WriteLine(PcInfoViewModel.OperatingSystemLocation);
                            Console.WriteLine(PcInfoViewModel.OperatingSystemAntivirus);
                        }
                        catch (Exception exp)
                        {
                            Console.WriteLine(exp.Message);
                            Console.WriteLine(exp.StackTrace);
                            LogClass.LogWrite($"========== Get Operating System Name Exception ==========");
                            LogClass.LogWrite($"{exp.Message}");
                            LogClass.LogWrite($"{exp.StackTrace}");
                            LogClass.LogWrite($"========== Get Operating System Name Exception ==========");
                        }
                    }
                    PcInfoViewModel.InternetExplorer = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Internet Explorer").GetValue("Version").ToString();

                    PcInfoViewModel.PowerShell = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\PowerShell\3\PowerShellEngine").GetValue("PowerShellVersion").ToString();

                    PcInfoViewModel.UserProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    PcInfoViewModel.SystemProfile = Environment.GetFolderPath(Environment.SpecialFolder.Windows);

                    //CPU

                    mos = new ManagementObjectSearcher("select * from Win32_Processor");
                    foreach (ManagementObject wmi in mos.Get())
                    {
                        try
                        {
                            if (wmi["Name"] != null)
                            {
                                PcInfoViewModel.CpuName = wmi["Name"].ToString();
                            }

                            if (wmi["ProcessorID"] != null)
                            {
                                PcInfoViewModel.CpuId = wmi["ProcessorID"].ToString();
                            }

                            if (wmi["Manufacturer"] != null)
                            {
                                PcInfoViewModel.CpuManufacturer = wmi["Manufacturer"].ToString();
                            }

                            if (wmi["AddressWidth"] != null)
                            {
                                PcInfoViewModel.CpuAddressWidth = wmi["AddressWidth"].ToString();
                            }

                            if (wmi["Architecture"] != null)
                            {
                                PcInfoViewModel.CpuArchitecture = wmi["Architecture"].ToString();
                            }

                            if (wmi["Caption"] != null)
                            {
                                string val = wmi["Caption"].ToString();

                                if (val.Contains("Family"))
                                {
                                    PcInfoViewModel.CpuFamily = val.Substring(val.LastIndexOf("Family") + 7, 1);
                                    PcInfoViewModel.CpuStepping = val.Substring(val.LastIndexOf("Stepping") + 9, 1);
                                }
                            }

                            if (wmi["CpuStatus"] != null)
                            {
                                PcInfoViewModel.CpuStatus = wmi["CpuStatus"].ToString();
                            }

                            if (wmi["MaxClockSpeed"] != null)
                            {
                                PcInfoViewModel.CpuMaxClockSpeed = $"{wmi["MaxClockSpeed"]} MHz";
                            }

                            if (wmi["ExtClock"] != null)
                            {
                                PcInfoViewModel.CpuBusSpeed = $"{wmi["ExtClock"]} MHz";
                            }

                            if (wmi["NumberOfCores"] != null)
                            {
                                PcInfoViewModel.CpuCore = wmi["NumberOfCores"].ToString();
                            }

                            if (wmi["NumberOfLogicalProcessors"] != null)
                            {
                                PcInfoViewModel.CpuThread = wmi["NumberOfLogicalProcessors"].ToString();
                            }

                            if (wmi["SocketDesignation"] != null)
                            {
                                PcInfoViewModel.CpuSocketDesignation = wmi["SocketDesignation"].ToString();
                            }

                            if (wmi["Version"] != null)
                            {
                                PcInfoViewModel.CpuVersion = wmi["Version"].ToString();
                            }

                            if (wmi["PowerManagementSupported"] != null)
                            {
                                PcInfoViewModel.CpuPowerManagementSupport = wmi["PowerManagementSupported"].ToString();
                            }

                            long l1, l2, l3;

                            GetPerCoreCacheSizes(out l1, out l2, out l3);

                            PcInfoViewModel.CpuL1CacheSize = $"{l1/1024} Kbytes";
                            PcInfoViewModel.CpuL2CacheSize = $"{l2/1024} Kbytes";
                            PcInfoViewModel.CpuL3CacheSize = $"{l3/1024} Kbytes";

                        }
                        catch (Exception exp)
                        {
                            Console.WriteLine(exp.Message);
                            Console.WriteLine(exp.StackTrace);
                            LogClass.LogWrite($"========== Get CPU Exception ==========");
                            LogClass.LogWrite($"{exp.Message}");
                            LogClass.LogWrite($"{exp.StackTrace}");
                            LogClass.LogWrite($"========== Get CPU Exception ==========");
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogClass.LogWrite($"========== Background Worker Exception ==========");
                    LogClass.LogWrite($"{ex.Message}");
                    LogClass.LogWrite($"{ex.StackTrace}");
                    LogClass.LogWrite($"========== Background Worker Exception ==========");
                }
            }
        }

        public static void GetPerCoreCacheSizes(out Int64 L1, out Int64 L2, out Int64 L3)
        {
            L1 = 0;
            L2 = 0;
            L3 = 0;

            var info = Processor.LogicalProcessorInformation;
            foreach (var entry in info)
            {
                if (entry.Relationship != Processor.LOGICAL_PROCESSOR_RELATIONSHIP.RelationCache)
                    continue;
                Int64 mask = (Int64)entry.ProcessorMask;
                if ((mask & (Int64)1) == 0)
                    continue;
                var cache = entry.ProcessorInformation.Cache;
                switch (cache.Level)
                {
                    case 1: L1 = L1 + cache.Size; break;
                    case 2: L2 = L2 + cache.Size; break;
                    case 3: L3 = L3 + cache.Size; break;
                    default:
                        break;
                }
            }

            //private Dictionary<string,string> UserEnvVariable()
            //{
            //    Dictionary<string, string> userVariable = new Dictionary<string, string>();
            //    using (RegistryKey root = Registry.CurrentUser)
            //    {
            //        string myKey = "Environment";
            //        userVariable = SearchSubKeys(root, myKey);
            //    }
            //    return userVariable;
            //}

            //private Dictionary<string,string> SearchSubKeys(RegistryKey root, String searchKey)
            //{
            //    Dictionary<string,string> uservaribale = new Dictionary<string,string>();
            //    foreach (string keyname in root.GetSubKeyNames())
            //    {
            //        try
            //        {
            //            using (RegistryKey key = root.OpenSubKey(keyname))
            //            {
            //                if (keyname == searchKey)
            //                {
            //                    foreach (string valuename in key.GetValueNames())
            //                    {
            //                        if (key.GetValue(valuename) is String)
            //                        {
            //                            uservaribale.Add(valuename, (string)key.GetValue(valuename));
            //                            //Console.WriteLine("{0} = {1}",
            //                            //    valuename, key.GetValue(valuename));
            //                        }
            //                    }
            //                }
            //                SearchSubKeys(key, searchKey);
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine(ex.Message);
            //            Console.WriteLine(ex.StackTrace);
            //        }
            //    }
            //    return uservaribale;
            //}
        }

        class Processor
        {
            [DllImport("kernel32.dll")]
            public static extern int GetCurrentThreadId();

            //[DllImport("kernel32.dll")]
            //public static extern int GetCurrentProcessorNumber();

            [StructLayout(LayoutKind.Sequential, Pack = 4)]
            private struct GROUP_AFFINITY
            {
                public UIntPtr Mask;

                [MarshalAs(UnmanagedType.U2)]
                public ushort Group;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.U2)]
                public ushort[] Reserved;
            }

            [DllImport("kernel32", SetLastError = true)]
            private static extern Boolean SetThreadGroupAffinity(IntPtr hThread, ref GROUP_AFFINITY GroupAffinity, ref GROUP_AFFINITY PreviousGroupAffinity);

            [StructLayout(LayoutKind.Sequential)]
            public struct PROCESSORCORE
            {
                public byte Flags;
            };

            [StructLayout(LayoutKind.Sequential)]
            public struct NUMANODE
            {
                public uint NodeNumber;
            }

            public enum PROCESSOR_CACHE_TYPE
            {
                CacheUnified,
                CacheInstruction,
                CacheData,
                CacheTrace
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct CACHE_DESCRIPTOR
            {
                public byte Level;
                public byte Associativity;
                public ushort LineSize;
                public uint Size;
                public PROCESSOR_CACHE_TYPE Type;
            }

            [StructLayout(LayoutKind.Explicit)]
            public struct SYSTEM_LOGICAL_PROCESSOR_INFORMATION_UNION
            {
                [FieldOffset(0)]
                public PROCESSORCORE ProcessorCore;
                [FieldOffset(0)]
                public NUMANODE NumaNode;
                [FieldOffset(0)]
                public CACHE_DESCRIPTOR Cache;
                [FieldOffset(0)]
                private UInt64 Reserved1;
                [FieldOffset(8)]
                private UInt64 Reserved2;
            }

            public enum LOGICAL_PROCESSOR_RELATIONSHIP
            {
                RelationProcessorCore,
                RelationNumaNode,
                RelationCache,
                RelationProcessorPackage,
                RelationGroup,
                RelationAll = 0xffff
            }

            public struct SYSTEM_LOGICAL_PROCESSOR_INFORMATION
            {
#pragma warning disable 0649
                public UIntPtr ProcessorMask;
                public LOGICAL_PROCESSOR_RELATIONSHIP Relationship;
                public SYSTEM_LOGICAL_PROCESSOR_INFORMATION_UNION ProcessorInformation;
#pragma warning restore 0649
            }

            [DllImport(@"kernel32.dll", SetLastError = true)]
            public static extern bool GetLogicalProcessorInformation(IntPtr Buffer, ref uint ReturnLength);

            private const int ERROR_INSUFFICIENT_BUFFER = 122;

            private static SYSTEM_LOGICAL_PROCESSOR_INFORMATION[] _logicalProcessorInformation = null;

            public static SYSTEM_LOGICAL_PROCESSOR_INFORMATION[] LogicalProcessorInformation
            {
                get
                {
                    if (_logicalProcessorInformation != null)
                        return _logicalProcessorInformation;

                    uint ReturnLength = 0;

                    GetLogicalProcessorInformation(IntPtr.Zero, ref ReturnLength);

                    if (Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_BUFFER)
                    {
                        IntPtr Ptr = Marshal.AllocHGlobal((int)ReturnLength);
                        try
                        {
                            if (GetLogicalProcessorInformation(Ptr, ref ReturnLength))
                            {
                                int size = Marshal.SizeOf(typeof(SYSTEM_LOGICAL_PROCESSOR_INFORMATION));
                                int len = (int)ReturnLength / size;
                                _logicalProcessorInformation = new SYSTEM_LOGICAL_PROCESSOR_INFORMATION[len];
                                IntPtr Item = Ptr;

                                for (int i = 0; i < len; i++)
                                {
                                    _logicalProcessorInformation[i] = (SYSTEM_LOGICAL_PROCESSOR_INFORMATION)Marshal.PtrToStructure(Item, typeof(SYSTEM_LOGICAL_PROCESSOR_INFORMATION));
                                    Item += size;
                                }

                                return _logicalProcessorInformation;
                            }
                        }
                        finally
                        {
                            Marshal.FreeHGlobal(Ptr);
                        }
                    }
                    return null;
                }
            }
        }
    }
}

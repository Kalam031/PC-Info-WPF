using Microsoft.Win32;
using OSVersionExtension;
using SidePanel_Navigation.Log;
using SidePanel_Navigation.Models;
using SidePanel_Navigation.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Xml.Linq;
using SidePanel_Navigation.DB;
using System.Data.SQLite;

namespace SidePanel_Navigation.Controls
{
    public class GetPcInfoClass
    {
        DispatcherTimer dispatcherTimer;
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        PerformanceCounter _cpuCounter = new PerformanceCounter();
        PerformanceCounter _memoryCounter = new PerformanceCounter();
        List<MemInfoModel> listMemInfo = new List<MemInfoModel>();
        List<DiskDriveModel> listDiskInfo = new List<DiskDriveModel>();
        List<DiskDrivePartitionModel> listDiskPartitionInfo = new List<DiskDrivePartitionModel>();
        List<NetworkAdapterModel> listNetWorkInfo = new List<NetworkAdapterModel>();
        List<string> listconnecteddns = new List<string>();
        List<string> listdnsserver = new List<string>();
        List<InputDeviceModel> listMouse = new List<InputDeviceModel>();
        List<InputDeviceModel> listKeyboard = new List<InputDeviceModel>();
        List<PrinterModel> listPrinter = new List<PrinterModel>();
        List<AudioModel> listAudioDevice = new List<AudioModel>();

        public string dbpath = Directory.GetParent(Assembly.GetExecutingAssembly().Location) + "\\hardwareinfo.db";
        SqliteDbClass sqliteDbClass = new SqliteDbClass();
        SQLiteConnection sqlConnection;

        LocalDbModel genericModel = new LocalDbModel();

        List<LocalDbModel> osInfoList = new List<LocalDbModel>();
        List<LocalDbModel> cpuInfoList = new List<LocalDbModel>();
        List<LocalDbModel> ramInfoList = new List<LocalDbModel>();
        List<LocalDbModel> motherboardInfoList = new List<LocalDbModel>();
        List<LocalDbModel> monitorInfoList = new List<LocalDbModel>();
        List<LocalDbModel> harddiskInfoList = new List<LocalDbModel>();
        List<LocalDbModel> mouseInfoList = new List<LocalDbModel>();
        List<LocalDbModel> keyboardInfoList = new List<LocalDbModel>();
        Dictionary<string,string> cpuPropertyInfoDict = new Dictionary<string, string>();
        Dictionary<string,string> ramPropertyInfoDict = new Dictionary<string, string>();
        Dictionary<string, string> harddiskPropertyInfoDict = new Dictionary<string, string>();
        //List<LocalSummaryDbModel> summaryInfoList = new List<LocalSummaryDbModel>();

        SelectQuery Sq = new SelectQuery("Win32_DesktopMonitor");

        public GetPcInfoClass()
        {
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(Sq);
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();

            backgroundWorker.DoWork += Bg_DoWork;
            backgroundWorker.RunWorkerCompleted += Bg_RunWorkerCompleted;

            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            GetRealtimeInfo();
        }

        public void GetRealtimeInfo()
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
            }
            else if (e.Cancelled)
            {
            }
            else if (e.Error != null)
            {
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!backgroundWorker1.CancellationPending)
            {
                //CPU
                double used = GetProcessorData();
                double unused = 100 - used;

                PcInfoViewModel.CpuUsed = used.ToString("F") + " %";
                PcInfoViewModel.CpuUnused = unused.ToString("F") + " %";

                string formattedTimeSpan = string.Format("{0:D2} d, {1:D2} h, {2:D2} m , {3:D3} s", GetUpTime().Days, GetUpTime().Hours, GetUpTime().Minutes, GetUpTime().Seconds.ToString().Substring(0));
                PcInfoViewModel.OperatingSystemCurrentUptime = formattedTimeSpan;

                //Ram

                string s = _QueryComputerSystem("totalphysicalmemory");
                double totalphysicalmemory = Convert.ToDouble(s);
                double d = _GetCounterValue(_memoryCounter, "Memory", "Available Bytes", null);

                string trunctotal = Regex.Replace(FormatBytes(totalphysicalmemory), "[^0-9.]", "");
                string truncused = Regex.Replace(FormatBytes(totalphysicalmemory - d), "[^0-9.]", "");

                double mused = double.Parse(truncused) / double.Parse(trunctotal) * 100;

                PcInfoViewModel.MemoryTotal = FormatBytes(totalphysicalmemory);
                PcInfoViewModel.MemoryAvailable = FormatBytes(totalphysicalmemory - (totalphysicalmemory - d));

                PcInfoViewModel.MemoryUsage = mused.ToString("F") + " %";
            }
            else
            {
                e.Cancel = true;
            }
        }

        public double GetProcessorData()
        {
            return _GetCounterValue(_cpuCounter, "Processor", "% Processor Time", "_Total");
        }

        double _GetCounterValue(PerformanceCounter pc, string categoryName, string counterName, string instanceName)
        {
            pc.CategoryName = categoryName;
            pc.CounterName = counterName;
            pc.InstanceName = instanceName;
            pc.NextValue();
            System.Threading.Thread.Sleep(1000);
            return pc.NextValue();
        }

        public TimeSpan GetUpTime()
        {
            return TimeSpan.FromMilliseconds(GetTickCount64());
        }

        [DllImport("kernel32")]
        extern static UInt64 GetTickCount64();

        public void GetInfo()
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void Bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!backgroundWorker.CancellationPending)
            {
                try
                {
                    VendorClass.vendorData();

                    //sqlConnection = sqliteDbClass.OpenConnection(dbpath);

                    string s = _QueryComputerSystem("totalphysicalmemory");
                    double totalphysicalmemory = Convert.ToDouble(s);

                    int unit = 0;
                    while (totalphysicalmemory > 1024)
                    {
                        totalphysicalmemory /= 1024;
                        ++unit;
                    }

                    //genericExtModel.cpu

                    PcInfoViewModel.SummaryMemoryTotal = Math.Ceiling(totalphysicalmemory).ToString("F") + " " + ((Unit)unit).ToString();
                    //localsummarymodel.RAM = Math.Ceiling(totalphysicalmemory).ToString("F") + " " + ((Unit)unit).ToString();

                    //Operating System

                    ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem");

                    foreach (ManagementObject wmi in mos.Get())
                    {
                        try
                        {
                            LocalDbModel geModel = new LocalDbModel();

                            if (wmi["Caption"] != null)
                            {
                                string bitcheck = "";
                                if (Environment.Is64BitOperatingSystem) bitcheck = " 64-bit";
                                else bitcheck = " 32-bit";

                                PcInfoViewModel.OperatingSystemName = wmi["Caption"].ToString() + bitcheck;
                                //localsummarymodel.OperatingSystem = wmi["Caption"].ToString() + bitcheck;

                                geModel.Manufacturer = wmi["Caption"].ToString().Split(' ')[0];
                                int lg = wmi["Caption"].ToString().Split(' ')[0].Length;
                                geModel.Model = wmi["Caption"].ToString().Substring(lg);
                                //Console.WriteLine(wmi["Caption"].ToString());
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

                            geModel.Version = OSVersion.MajorVersion10Properties().DisplayVersion.ToString() ?? "(Unable to detect)";
                            //Console.WriteLine(OSVersion.MajorVersion10Properties().DisplayVersion.ToString() ?? "(Unable to detect)");

                            PcInfoViewModel.OperatingSystembuild = OSVersion.GetOSVersion().Version.Build.ToString();

                            RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
                            RegistryKey windowsNTKey = localMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion");
                            object productID = windowsNTKey.GetValue("ProductId");

                            PcInfoViewModel.OperatingSystemSerial = productID.ToString();

                            geModel.ID = productID.ToString();

                            TimeZone localZone = TimeZone.CurrentTimeZone;
                            TimeZoneInfo localtimeZone = TimeZoneInfo.Local;
                            string sysDateFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                            string sysTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;

                            PcInfoViewModel.OperatingSystemTimeZone = TimeZoneInfo.Local.DisplayName;
                            PcInfoViewModel.OperatingSystemDateFormat = sysDateFormat;
                            PcInfoViewModel.OperatingSystemTimeFormat = sysTimeFormat;
                            PcInfoViewModel.OperatingSystemLocation = localtimeZone.Id.Split(' ')[0];

                            osInfoList.Add(geModel);

                            using (mos = new ManagementObjectSearcher(@"\\" + Environment.MachineName + @"\root\SecurityCenter2", "SELECT * FROM AntivirusProduct"))
                            {
                                var searcherInstance = mos.Get();
                                foreach (var instance in searcherInstance)
                                {
                                    PcInfoViewModel.OperatingSystemAntivirus = instance["displayName"].ToString();
                                }
                            }

                            //Console.WriteLine(PcInfoViewModel.OperatingSystemName);
                            //Console.WriteLine(PcInfoViewModel.OperatingSystemInstallDate);
                            //Console.WriteLine(PcInfoViewModel.OperatingSystemLanguage);
                            //Console.WriteLine(PcInfoViewModel.OperatingSystemVersion);
                            //Console.WriteLine(PcInfoViewModel.OperatingSystembuild);
                            //Console.WriteLine(PcInfoViewModel.OperatingSystemSerial);
                            //Console.WriteLine(PcInfoViewModel.OperatingSystemTimeZone);
                            //Console.WriteLine(PcInfoViewModel.OperatingSystemDateFormat);
                            //Console.WriteLine(PcInfoViewModel.OperatingSystemTimeFormat);
                            //Console.WriteLine(PcInfoViewModel.OperatingSystemLocation);
                            //Console.WriteLine(PcInfoViewModel.OperatingSystemAntivirus);
                        }
                        catch (Exception exp)
                        {
                            //Console.WriteLine(exp.Message);
                            //Console.WriteLine(exp.StackTrace);
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

                    mos = new ManagementObjectSearcher("root\\CIMV2", "select * from Win32_Processor");

                    foreach (ManagementObject wmi in mos.Get())
                    {
                        try
                        {
                            LocalDbModel genercModel = new LocalDbModel();

                            if (wmi["Name"] != null)
                            {
                                PcInfoViewModel.CpuName = wmi["Name"].ToString();
                                genercModel.Model = wmi["Name"].ToString();
                                //localsummarymodel.CPU = wmi["Name"].ToString();
                            }

                            if (wmi["ProcessorID"] != null)
                            {
                                PcInfoViewModel.CpuId = wmi["ProcessorID"].ToString();
                                genercModel.ID = wmi["ProcessorID"].ToString();
                            }

                            if (wmi["Manufacturer"] != null)
                            {
                                PcInfoViewModel.CpuManufacturer = wmi["Manufacturer"].ToString();
                                genercModel.Manufacturer = wmi["Manufacturer"].ToString();
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
                                cpuPropertyInfoDict.Add("CPU_ClockSpeed", $"{wmi["MaxClockSpeed"]} MHz");
                            }

                            if (wmi["ExtClock"] != null)
                            {
                                PcInfoViewModel.CpuBusSpeed = $"{wmi["ExtClock"]} MHz";
                            }

                            if (wmi["NumberOfCores"] != null)
                            {
                                PcInfoViewModel.CpuCore = wmi["NumberOfCores"].ToString();
                                cpuPropertyInfoDict.Add("CPU_Core", wmi["NumberOfCores"].ToString());
                            }

                            if (wmi["NumberOfLogicalProcessors"] != null)
                            {
                                PcInfoViewModel.CpuThread = wmi["NumberOfLogicalProcessors"].ToString();
                                cpuPropertyInfoDict.Add("CPU_Thread", wmi["NumberOfLogicalProcessors"].ToString());
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

                            PcInfoViewModel.CpuL1CacheSize = $"{l1 / 1024} Kbytes";
                            PcInfoViewModel.CpuL2CacheSize = $"{l2 / 1024} Kbytes";
                            PcInfoViewModel.CpuL3CacheSize = $"{l3 / 1024} Kbytes";

                            genercModel.Version = "";
                            cpuInfoList.Add(genercModel);

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

                    //Physical Memory
                    mos = new ManagementObjectSearcher("root\\CIMV2", "select * from Win32_PhysicalMemory");

                    string s1 = _QueryComputerSystem("totalphysicalmemory");
                    double totalphysicalmemory1 = Convert.ToDouble(s1);

                    ramPropertyInfoDict.Add("RAM_Size", FormatBytes(totalphysicalmemory1));

                    double trunctotal = double.Parse(Regex.Replace(FormatBytes(totalphysicalmemory1), "[^0-9.]", ""));

                    foreach (ManagementObject wmi in mos.Get())
                    {
                        LocalDbModel genModel = new LocalDbModel();
                        PcInfoViewModel.MemoryType = GetMemoryType(int.Parse(wmi["MemoryType"].ToString()));
                        MemInfoModel memoryInfoModel = new MemInfoModel();

                        memoryInfoModel.Type = GetMemoryType(int.Parse(wmi["MemoryType"].ToString()));

                        genModel.Model = GetMemoryType(int.Parse(wmi["MemoryType"].ToString()));

                        memoryInfoModel.Size = Math.Ceiling(trunctotal / 2.0) + " GB";

                        try
                        {
                            int result = 0;
                            bool flag = int.TryParse(wmi["Manufacturer"].ToString(), out result);

                            if (flag == true)
                            {
                                memoryInfoModel.Manufacturer = VendorClass.vendorInfo[wmi["Manufacturer"].ToString()];
                                genModel.Manufacturer = VendorClass.vendorInfo[wmi["Manufacturer"].ToString()];
                            }
                            else
                            {
                                memoryInfoModel.Manufacturer = wmi["Manufacturer"].ToString();
                                genModel.Manufacturer = wmi["Manufacturer"].ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            //Console.WriteLine(ex.Message);
                            //Console.WriteLine(ex.StackTrace);
                        }

                        memoryInfoModel.SerialNo = wmi["SerialNumber"].ToString();

                        genModel.ID = wmi["SerialNumber"].ToString();

                        memoryInfoModel.Speed = wmi["Speed"].ToString() + " MHz";

                        if (!ramPropertyInfoDict.ContainsKey("RAM_Speed"))
                        {
                            ramPropertyInfoDict.Add("RAM_Speed", wmi["Speed"].ToString() + " MHz");
                        }

                        //Console.WriteLine(memoryInfoModel.Type);
                        //Console.WriteLine(memoryInfoModel.Size);
                        //Console.WriteLine(memoryInfoModel.Manufacturer);
                        //Console.WriteLine(memoryInfoModel.SerialNo);
                        //Console.WriteLine(memoryInfoModel.Speed);

                        listMemInfo.Add(memoryInfoModel);
                        genModel.Version = "";
                        ramInfoList.Add(genModel);
                    }

                    PcInfoViewModel.ListMemInfo = listMemInfo;

                    //Mother board

                    mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

                    foreach (ManagementObject wmi in mos.Get())
                    {
                        LocalDbModel gModel = new LocalDbModel();
                        PcInfoViewModel.MotherboardManufacturer = wmi["Manufacturer"].ToString();
                        PcInfoViewModel.MotherboardSerial = Regex.Replace(wmi["SerialNumber"].ToString(),'/'.ToString(),string.Empty);
                        PcInfoViewModel.MotherboardModel = wmi["Product"].ToString();
                        PcInfoViewModel.MotherboardVersion = wmi["Version"].ToString();

                        gModel.Version = wmi["Version"].ToString();

                        //Console.WriteLine(wmi["Version"].ToString());

                        gModel.Manufacturer = wmi["Manufacturer"].ToString();
                        gModel.Model = wmi["Product"].ToString();
                        gModel.ID = Regex.Replace(wmi["SerialNumber"].ToString(), '/'.ToString(), string.Empty);

                        //localsummarymodel.Motherboard = $"{wmi["Manufacturer"].ToString()} {wmi["Product"].ToString()}";
                        motherboardInfoList.Add(gModel);
                    }

                    mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

                    foreach (ManagementObject wmi in mos.Get())
                    {
                        PcInfoViewModel.BiosDate = ManagementDateTimeConverter.ToDateTime(wmi["ReleaseDate"].ToString()).ToString("dd-MMM-yyyy");
                        PcInfoViewModel.BiosVersion = wmi["SMBIOSBIOSVersion"].ToString();
                        PcInfoViewModel.BiosSerialNumber = wmi["SerialNumber"].ToString();
                    }

                    //Graphics

                    PcInfoViewModel.MonitorName = Screen.PrimaryScreen.DeviceFriendlyName();

                    LocalDbModel genericModel = new LocalDbModel();
                    //localsummarymodel.Graphics = Screen.PrimaryScreen.DeviceFriendlyName();
                    genericModel.Manufacturer = Screen.PrimaryScreen.DeviceFriendlyName().Split(' ')[0];
                    //Console.WriteLine(Screen.PrimaryScreen.DeviceFriendlyName().Split(' ')[0]);
                    int length = Screen.PrimaryScreen.DeviceFriendlyName().Split(' ')[0].Length;
                    genericModel.Model = Screen.PrimaryScreen.DeviceFriendlyName().Substring(length + 1);
                    genericModel.ID = "";
                    genericModel.Version = "";

                    monitorInfoList.Add(genericModel);
                    //Console.WriteLine(length);
                    //Console.WriteLine(Screen.PrimaryScreen.DeviceFriendlyName().Substring(length+1));


                    //mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM DisplayMonitor");

                    //foreach (ManagementObject wmi in mos.Get())
                    //{
                    //    Console.WriteLine(wmi["DeviceId"]);
                    //}

                    mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");

                    foreach (ManagementObject wmi in mos.Get())
                    {
                        PcInfoViewModel.MonitorWidth = wmi["CurrentHorizontalResolution"].ToString();
                        PcInfoViewModel.MonitorHeight = wmi["CurrentVerticalResolution"].ToString();
                        PcInfoViewModel.MonitorResolution = $"{PcInfoViewModel.MonitorWidth} x {PcInfoViewModel.MonitorHeight}";
                        PcInfoViewModel.MonitorCurrentFrequency = wmi["CurrentRefreshRate"].ToString() + " Hz";
                        PcInfoViewModel.MonitorFrequency = wmi["MaxRefreshRate"].ToString() + " Hz";
                        PcInfoViewModel.MonitorBitsPerPixel = wmi["CurrentBitsPerPixel"].ToString() + " bits per pixel";

                        PcInfoViewModel.InternalGraphicsName = wmi["Name"].ToString();
                        PcInfoViewModel.InternalGraphicsDriverVersion = wmi["DriverVersion"].ToString();
                        PcInfoViewModel.InternalGraphicsDate = ManagementDateTimeConverter.ToDateTime(wmi["DriverDate"].ToString()).ToString("dd-MMM-yyyy");

                        string[] val = wmi["Name"].ToString().Split(' ');
                        string manufac = val[0];
                        string modelName = "";

                        for (int j= 1; j< val.Count(); j++)
                        {
                            modelName += $"{(val[j])} ";
                        }

                        PcInfoViewModel.InternalGraphicsManufacturer = manufac;
                        PcInfoViewModel.InternalGraphicsModel = modelName;
                    }

                    //Optical Drive

                    mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_CDROMDrive");

                    foreach (ManagementObject wmi in mos.Get())
                    {
                        PcInfoViewModel.OpticalDriveName = wmi["Name"].ToString();

                        //localsummarymodel.OpticalDrive = wmi["Name"].ToString();

                        PcInfoViewModel.OpticalDriveConfigManErrCode = wmi["ConfigManagerErrorCode"].ToString();
                        PcInfoViewModel.OpticalDriveConfigManUserConfig = wmi["ConfigManagerUserConfig"].ToString() == "False" ? "False" : "True";
                        PcInfoViewModel.OpticalDriveVolume = wmi["Drive"].ToString();
                        PcInfoViewModel.OpticalDriveMediaLoaded = wmi["MediaLoaded"].ToString();
                        PcInfoViewModel.OpticalDriveSCSIbus = wmi["SCSIBus"].ToString();
                        PcInfoViewModel.OpticalDriveSCSILogicalUnit = wmi["SCSILogicalUnit"].ToString();
                        PcInfoViewModel.OpticalDriveSCSIport = wmi["SCSIPort"].ToString();
                        PcInfoViewModel.OpticalDriveSCSItargetId = wmi["SCSITargetId"].ToString();
                        PcInfoViewModel.OpticalDriveStatus = wmi["Status"].ToString();
                    }

                    //Storage

                    mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive");

                    double hsize = 0;
                    string totalHsize = "";
                    foreach (ManagementObject wmi in mos.Get())
                    {
                        genericModel = new LocalDbModel();
                        DiskDriveModel diskDriveModel = new DiskDriveModel();

                        diskDriveModel.DiskName = wmi["Caption"].ToString();
                        diskDriveModel.DiskManufacturer = wmi["Caption"].ToString().Split(' ')[0];

                        genericModel.Manufacturer = wmi["Caption"].ToString().Split(' ')[0];

                        int lngth = wmi["Caption"].ToString().Split(' ')[0].Length;

                        genericModel.Model = wmi["Caption"].ToString().Substring(lngth + 1);
                        //Console.WriteLine(wmi["Caption"].ToString().Substring(lngth + 1));

                        diskDriveModel.Heads = wmi["TotalHeads"].ToString();
                        diskDriveModel.Cylinders = wmi["TotalCylinders"].ToString();
                        diskDriveModel.Tracks = wmi["TotalTracks"].ToString();
                        diskDriveModel.Sectors = wmi["TotalSectors"].ToString();
                        diskDriveModel.Serial = wmi["SerialNumber"].ToString().Trim();

                        genericModel.ID = wmi["SerialNumber"].ToString().Trim();
                        genericModel.Version = "";

                        hsize += double.Parse(wmi["Size"].ToString());
                        diskDriveModel.Capacity = FormatBytes(double.Parse(wmi["Size"].ToString()));
                        diskDriveModel.RealSize = wmi["Size"].ToString();

                        //localsummarymodel.Storage = FormatBytes(double.Parse(wmi["Size"].ToString()));

                        diskDriveModel.Status = wmi["Status"].ToString();

                        listDiskInfo.Add(diskDriveModel);
                        harddiskInfoList.Add(genericModel);
                    }
                    totalHsize = FormatBytes(hsize);
                    PcInfoViewModel.ListDiskDriveInfo = listDiskInfo;

                    harddiskPropertyInfoDict.Add("Harddisk_Size", totalHsize);

                    String DiskName = "";
                    String PartState = "";
                    String PartName = "";
                    String PartFree = "";
                    Int16 ObjCount = 0;

                    ManagementObjectSearcher hdd = new ManagementObjectSearcher("Select * from Win32_DiskDrive");
                    foreach (ManagementObject objhdd in hdd.Get())
                    {
                        PartState = "";
                        //DiskName = "Disk " + objhdd["Index"].ToString() + " : " + objhdd["Caption"].ToString().Replace(" ATA Device", "") +
                        //    " (" + Math.Round(Convert.ToDouble(objhdd["Size"]) / 1073741824, 1) + " GB)";

                        ObjCount = Convert.ToInt16(objhdd["Partitions"]);
                        ManagementObjectSearcher partitions = new ManagementObjectSearcher(
                            "Select * From Win32_DiskPartition Where DiskIndex='" + objhdd["Index"].ToString() + "'");
                        foreach (ManagementObject part in partitions.Get())
                        {
                            DiskDrivePartitionModel diskDrivePartitionModel = new DiskDrivePartitionModel();

                            PartName = part["DeviceID"].ToString();
                            if (part["Bootable"].ToString() == "True" && part["BootPartition"].ToString() == "True")
                            {
                                PartState = FormatBytes(Convert.ToDouble(part["Size"].ToString()));
                            }
                            else
                            {
                                //ManagementObjectSearcher getdisks = new ManagementObjectSearcher
                                //    ("Select * From Win32_LogicalDiskToPartition Where  ");
                                PartState = GetPartName(PartName);
                                PartFree = GetUsedSpace(PartState);
                                PartState = "Local Disk (" + PartState + ")";
                            }

                            if (!string.IsNullOrEmpty(PartState))
                            {
                                diskDrivePartitionModel.PartitionName = part["Index"].ToString();
                                diskDrivePartitionModel.DriveName = PartState;
                                diskDrivePartitionModel.TotalStorage = FormatBytes(Convert.ToDouble(part["Size"].ToString()));
                                string[] val = PartFree.Split('*');

                                if (!string.IsNullOrEmpty(val[0]))
                                {
                                    diskDrivePartitionModel.UsedSpace = val[0];
                                }

                                if (!string.IsNullOrEmpty(val[0]))
                                {
                                    diskDrivePartitionModel.FreeSpace = val[1];
                                }
                            }
                            else
                            {
                                diskDrivePartitionModel.PartitionName = part["Index"].ToString();
                                diskDrivePartitionModel.TotalStorage = PartState;
                            }

                            listDiskPartitionInfo.Add(diskDrivePartitionModel);
                        }

                        PcInfoViewModel.ListDiskDrivePartitionInfo = listDiskPartitionInfo;
                    }

                    //Audio

                    mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_SoundDevice");

                    foreach (ManagementObject wmi in mos.Get())
                    {
                        AudioModel audioModel = new AudioModel();

                        audioModel.DeviceName = wmi["Caption"].ToString();

                        //localsummarymodel.Audio = wmi["Caption"].ToString();

                        listAudioDevice.Add(audioModel);
                        //Console.WriteLine(wmi["Caption"]);
                    }
                    PcInfoViewModel.ListsoundDeviceInfo = listAudioDevice;

                    //Peripherals

                    mos = new ManagementObjectSearcher("root\\CIMV2", "select * from win32_pnpentity where PNPClass = 'Mouse'");

                    foreach (ManagementObject wmi in mos.Get())
                    {
                        LocalDbModel genecModel = new LocalDbModel();
                        InputDeviceModel inputDeviceModel = new InputDeviceModel();

                        inputDeviceModel.DeviceType = "Mouse";
                        inputDeviceModel.DeviceName = wmi["Name"].ToString();
                        inputDeviceModel.DeviceVendor = VendorClass.vendorInfo[wmi["DeviceID"].ToString().Split('&')[0].ToString().Split('_')[1]];

                        genecModel.Manufacturer = VendorClass.vendorInfo[wmi["DeviceID"].ToString().Split('&')[0].ToString().Split('_')[1]];
                        genecModel.Model = "";
                        genecModel.ID = "";
                        genecModel.Version = "";
                        mouseInfoList.Add(genecModel);

                        //Console.WriteLine("Type: Mouse");
                        //Console.WriteLine(VendorClass.vendorInfo[wmi["DeviceID"].ToString().Split('&')[0].ToString().Split('_')[1]]);
                        //Console.WriteLine(wmi["DeviceID"]);
                        //Console.WriteLine(wmi["Manufacturer"]);
                        listMouse.Add(inputDeviceModel);
                    }
                    PcInfoViewModel.Mouse = listMouse;

                    mos = new ManagementObjectSearcher("root\\CIMV2", "select * from win32_pnpentity where PNPClass = 'Keyboard'");

                    foreach (ManagementObject wmi in mos.Get())
                    {
                        InputDeviceModel inputDeviceModel = new InputDeviceModel();
                        LocalDbModel gnModel = new LocalDbModel();

                        inputDeviceModel.DeviceType = "Keyboard";
                        inputDeviceModel.DeviceName = wmi["Name"].ToString();
                        inputDeviceModel.DeviceVendor = VendorClass.vendorInfo[wmi["DeviceID"].ToString().Split('&')[0].ToString().Split('_')[1]];

                        gnModel.Manufacturer = VendorClass.vendorInfo[wmi["DeviceID"].ToString().Split('&')[0].ToString().Split('_')[1]];
                        gnModel.Model = "";
                        gnModel.ID = "";
                        gnModel.Version = "";

                        keyboardInfoList.Add(gnModel);

                        //Console.WriteLine("Type: Mouse");
                        //Console.WriteLine(wmi["Name"]);
                        //Console.WriteLine(VendorClass.vendorInfo[wmi["DeviceID"].ToString().Split('&')[0].ToString().Split('_')[1]]);
                        //Console.WriteLine(wmi["DeviceID"]);
                        //Console.WriteLine(wmi["Manufacturer"]);
                        listKeyboard.Add(inputDeviceModel);
                    }
                    PcInfoViewModel.Keyboard = listKeyboard;

                    mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Printer");

                    foreach (ManagementObject wmi in mos.Get())
                    {
                        PrinterModel printerModel = new PrinterModel();

                        printerModel.PrinterName = wmi["Name"].ToString();
                        printerModel.PrinterPort = wmi["PortName"].ToString();
                        printerModel.PrintProcessor = wmi["PrintProcessor"].ToString();
                        printerModel.Priority = wmi["Priority"].ToString();
                        printerModel.PrintQuality = $"{wmi["HorizontalResolution"]} * {wmi["VerticalResolution"]}";
                        printerModel.Status = wmi["Status"].ToString();
                        printerModel.DriverName = wmi["DriverName"].ToString();
                        printerModel.SpoolEnabled = wmi["SpoolEnabled"].ToString();
                        printerModel.WorkOffline = wmi["WorkOffline"].ToString();

                        //Console.WriteLine(wmi["Name"]);
                        //Console.WriteLine(wmi["PortName"]);
                        //Console.WriteLine(wmi["PrintProcessor"]);
                        //Console.WriteLine(wmi["Priority"]);
                        //Console.WriteLine(wmi["HorizontalResolution"]);
                        //Console.WriteLine(wmi["VerticalResolution"]);
                        //Console.WriteLine(wmi["Status"]);
                        //Console.WriteLine(wmi["DriverName"]);
                        //Console.WriteLine(wmi["SpoolEnabled"]);
                        //Console.WriteLine(wmi["WorkOffline"]);

                        listPrinter.Add(printerModel);
                    }
                    //foreach (var v in listPrinter)
                    //{
                    //    Console.WriteLine(v.PrinterName);
                    //}

                    PcInfoViewModel.Printer = listPrinter;

                    //Network

                    //mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_NetworkAdapter WHERE NetEnabled = True");

                    //foreach (ManagementObject wmi in mos.Get())
                    //{
                    //    Console.WriteLine(wmi["Name"]);

                    //}

                    string localIP = "";
                    IPAddress dnsip = null;
                    try
                    {
                        using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                        {
                            socket.Connect("8.8.8.8", 65530);
                            IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                            localIP = endPoint.Address.ToString();
                            PcInfoViewModel.Userip = localIP;
                        }
                    }
                    catch (Exception ex)
                    {
                        localIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
                        PcInfoViewModel.Userip = localIP;
                    }

                    PcInfoViewModel.Usersubnetmask = GetSubnetMask(IPAddress.Parse(localIP)).ToString();
                    PcInfoViewModel.Usergateway = GetDefaultGateway().ToString();

                    foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                    {
                        if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                        {
                            foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                            {
                                if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                {
                                    NetworkAdapterModel networkAdapterModel = new NetworkAdapterModel();
                                    networkAdapterModel.nicName = ni.Name;
                                    networkAdapterModel.ip = ip.Address.ToString();
                                    networkAdapterModel.macAddress = ni.GetPhysicalAddress().ToString();
                                    networkAdapterModel.subnetmask = ip.IPv4Mask.ToString();
                                    networkAdapterModel.gateway = GetDefaultGateway().ToString();

                                    //foreach (GatewayIPAddressInformation d in ni.GetIPProperties().GatewayAddresses)
                                    //{
                                    //    Console.WriteLine(d.Address);
                                    //}

                                    foreach (IPAddress d in ni.GetIPProperties().DnsAddresses)
                                    {
                                        listdnsserver.Add(d.ToString());

                                        if (!d.ToString().Contains("::"))
                                        {
                                            listconnecteddns.Add(d.ToString());
                                        }
                                    }
                                    PcInfoViewModel.Userdnsserver = listconnecteddns;
                                    networkAdapterModel.listdnsserver = listconnecteddns;
                                    listNetWorkInfo.Add(networkAdapterModel);
                                }
                                PcInfoViewModel.ListNetworkInformation = listNetWorkInfo;
                            }
                        }
                    }

                    //summaryInfoList.Add(localsummarymodel);

                    sqliteDbClass.OpenConnection(dbpath);
                    sqlConnection = sqliteDbClass.OpenConnection(dbpath);

                    if (osInfoList != null && osInfoList.Count() > 0)
                    {
                        sqliteDbClass.InsertHardwareInfoData(sqlConnection, osInfoList, 1);
                    }

                    if (cpuInfoList != null && cpuInfoList.Count() > 0)
                    {
                        sqliteDbClass.InsertHardwareInfoData(sqlConnection, cpuInfoList, 2);
                    }
                    if (ramInfoList != null && ramInfoList.Count() > 0)
                    {
                        //sqliteDbClass.ReadHardwareInfoData(sqlConnection, 2);
                        sqliteDbClass.InsertHardwareInfoData(sqlConnection, ramInfoList, 3);
                    }
                    if (motherboardInfoList != null && motherboardInfoList.Count() > 0)
                    {
                        sqliteDbClass.InsertHardwareInfoData(sqlConnection, motherboardInfoList, 4);
                    }
                    if (monitorInfoList != null && monitorInfoList.Count() > 0)
                    {
                        sqliteDbClass.InsertHardwareInfoData(sqlConnection, monitorInfoList, 5);
                    }
                    if (harddiskInfoList != null && harddiskInfoList.Count() > 0)
                    {
                        sqliteDbClass.InsertHardwareInfoData(sqlConnection, harddiskInfoList, 6);
                    }
                    if (mouseInfoList != null && mouseInfoList.Count() > 0)
                    {
                        sqliteDbClass.InsertHardwareInfoData(sqlConnection, mouseInfoList, 7);
                    }
                    if (keyboardInfoList != null && keyboardInfoList.Count() > 0)
                    {
                        sqliteDbClass.InsertHardwareInfoData(sqlConnection, keyboardInfoList, 8);
                    }

                    if (cpuPropertyInfoDict != null)
                    {
                        sqliteDbClass.InsertExtendInfoData(sqlConnection, cpuPropertyInfoDict, 2);
                    }

                    if (ramPropertyInfoDict != null)
                    {
                        sqliteDbClass.InsertExtendInfoData(sqlConnection, ramPropertyInfoDict, 3);
                    }

                    if (harddiskPropertyInfoDict != null)
                    {
                        sqliteDbClass.InsertExtendInfoData(sqlConnection, harddiskPropertyInfoDict, 6);
                    }

                    //if (summaryInfoList != null && summaryInfoList.Count() > 0)
                    //{
                    //    sqliteDbClass.InsertHardwareSummaryData(sqlConnection, summaryInfoList);
                    //}
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    LogClass.LogWrite($"========== Background Worker Exception ==========");
                    LogClass.LogWrite($"{ex.Message}");
                    LogClass.LogWrite($"{ex.StackTrace}");
                    LogClass.LogWrite($"========== Background Worker Exception ==========");
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private String GetUsedSpace(String inp)
        {
            String totalspace = "", freespace = "", freepercent1 = "", freepercent2 = "", freepercent = "";
            Double sFree = 0, sTotal = 0, sEq1 = 0, sEq2 = 0, sUsed = 0;
            ManagementObjectSearcher getspace = new ManagementObjectSearcher("Select * from Win32_LogicalDisk Where DeviceID='" + inp + "'");
            foreach (ManagementObject drive in getspace.Get())
            {
                if (drive["DeviceID"].ToString() == inp)
                {
                    freespace = drive["FreeSpace"].ToString();
                    totalspace = drive["Size"].ToString();
                    sFree = Convert.ToDouble(freespace);
                    sTotal = Convert.ToDouble(totalspace);
                    sUsed = sTotal - sFree;
                    sEq1 = sFree * 100 / sTotal;
                    sEq2 = sUsed * 100 / sTotal;
                    freepercent1 = (Math.Round((sTotal - sFree) / 1073741824, 2)).ToString() + " (" + Math.Round(sEq2, 0).ToString() + " %)";
                    freepercent2 = (Math.Round((sTotal - sUsed) / 1073741824, 2)).ToString() + " (" + Math.Round(sEq1, 0).ToString() + " %)";
                    freepercent = $"{freepercent1}*{freepercent2}";
                    return freepercent;
                }
            }
            return "";
        }
        private String GetPartName(String inp)
        {
            //MessageBox.Show(inp);
            String Dependent = "", ret = "";
            ManagementObjectSearcher LogicalDisk = new ManagementObjectSearcher("Select * from Win32_LogicalDiskToPartition");
            foreach (ManagementObject drive in LogicalDisk.Get())
            {
                if (drive["Antecedent"].ToString().Contains(inp))
                {
                    Dependent = drive["Dependent"].ToString();
                    ret = Dependent.Substring(Dependent.Length - 3, 2);
                    break;
                }

            }
            return ret;

        }

        public static IPAddress GetSubnetMask(IPAddress address)
        {
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (address.Equals(unicastIPAddressInformation.Address))
                        {
                            return unicastIPAddressInformation.IPv4Mask;
                        }
                    }
                }
            }
            throw new ArgumentException(string.Format("Can't find subnetmask for IP address '{0}'", address));
        }

        public static IPAddress GetDefaultGateway()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                .Select(g => g?.Address)
                .Where(a => a != null)
                // .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                // .Where(a => Array.FindIndex(a.GetAddressBytes(), b => b != 0) >= 0)
                .FirstOrDefault();
        }

        public string GetMemoryType(int MemoryType)
        {
            switch (MemoryType)
            {
                case 20:
                    return "DDR";
                case 21:
                    return "DDR-2";
                default:
                    if (MemoryType == 0 || MemoryType > 22)
                        return "DDR-3";
                    else
                        return "Other";
            }
        }

        string _QueryComputerSystem(string type)
        {
            string str = null;
            ManagementObjectSearcher objCS = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            foreach (ManagementObject objMgmt in objCS.Get())
            {
                str = objMgmt[type].ToString();
            }
            return str;
        }

        enum Unit { B, KB, MB, GB, TB, ER }
        string FormatBytes(double bytes)
        {
            int unit = 0;
            while (bytes > 1024)
            {
                bytes /= 1024;
                ++unit;
            }

            return bytes.ToString("F") + " " + ((Unit)unit).ToString();
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

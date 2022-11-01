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
                                PcInfoViewModel.CpuModel = wmi["Name"].ToString();
                            }

                            if (wmi["ProcessorID"] != null)
                            {
                                PcInfoViewModel.CpuId = wmi["ProcessorID"].ToString();
                            }

                            if (wmi["Manufacturer"] != null)
                            {
                                PcInfoViewModel.CpuManufacturer = wmi["Manufacturer"].ToString();
                            }
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


    }
}

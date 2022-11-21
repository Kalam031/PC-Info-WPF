using SidePanel_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.ViewModels
{
    public class SummaryViewModel : ViewModelBase
    {
        string _operatingSystemName;
        string _cpuName;
        string _ramInfo;
        string _motherboardInfo;
        string _opticalDrive;
        List<DiskDriveModel> liststorage;
        List<AudioModel> listaudio;
        string _display;
        string _graphics;

        public string OperatingSystem
        {
            get => PcInfoViewModel.OperatingSystemName;
            set
            {
                _operatingSystemName = value;
                OnPropertyChanged(nameof(OperatingSystem));
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

        public string RamInfo
        {
            get => $"{PcInfoViewModel.SummaryMemoryTotal} {PcInfoViewModel.MemoryType} ";
            set
            {
                _ramInfo = value;
                OnPropertyChanged(nameof(RamInfo));
            }
        }

        public string MotherboardInfo
        {
            get => $"{PcInfoViewModel.MotherboardManufacturer} {PcInfoViewModel.MotherboardModel}";
            set
            {
                _motherboardInfo = value;
                OnPropertyChanged(nameof(MotherboardInfo));
            }
        }

        public string OpticalDrive
        {
            get => PcInfoViewModel.OpticalDriveName;
            set
            {
                _opticalDrive = value;
                OnPropertyChanged(nameof(OpticalDrive));
            }
        }

        public List<DiskDriveModel> Liststorage
        {
            get => PcInfoViewModel.ListDiskDriveInfo;
            set
            {
                liststorage = value;
                OnPropertyChanged(nameof(Liststorage));
            }
        }

        public List<AudioModel> Listaudio
        {
            get => PcInfoViewModel.ListsoundDeviceInfo;
            set
            {
                listaudio = value;
                OnPropertyChanged(nameof(Listaudio));
            }
        }

        public string Display
        {
            get => $"{PcInfoViewModel.MonitorResolution} @ {PcInfoViewModel.MonitorFrequency}";
            set
            {
                _display = value;
                OnPropertyChanged(nameof(Display));
            }
        }

        public string Graphics
        {
            get => PcInfoViewModel.InternalGraphicsName;
            set
            {
                _graphics = value;
                OnPropertyChanged(nameof(Graphics));
            }
        }
    }
}

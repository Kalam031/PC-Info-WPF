using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.ViewModels
{
    public class GraphicsViewModel : ViewModelBase
    {
        string _monitorName;
        string _monitorWidth;
        string _monitorHeight;
        string _monitorResolution;
        string _monitorBitsPerPixel;
        string _monitorFrequency;
        string _monitorCurrentFrequency;

        string _internalGraphicsName;
        string _internalGraphicsDriverVersion;
        string _internalGraphicsDate;
        string _internalGraphicsManufacturer;
        string _internalGraphicsModel;

        public string MonitorWidth
        {
            get => PcInfoViewModel.MonitorWidth;
            set 
            {
                _monitorWidth = value;
                OnPropertyChanged(nameof(MonitorWidth));
            }
        }

        public string MonitorHeight
        {
            get => PcInfoViewModel.MonitorHeight;
            set
            {
                _monitorHeight = value;
                OnPropertyChanged(nameof(MonitorHeight));
            }
        }

        public string MonitorResolution
        {
            get => PcInfoViewModel.MonitorResolution;
            set
            {
                _monitorResolution = value;
                OnPropertyChanged(nameof(MonitorResolution));
            }
        }

        public string MonitorBitsPerPixel
        {
            get => PcInfoViewModel.MonitorBitsPerPixel;
            set 
            {
                _monitorBitsPerPixel = value;
                OnPropertyChanged(nameof(MonitorBitsPerPixel));
            }
        }

        public string MonitorFrequency
        {
            get => PcInfoViewModel.MonitorFrequency;
            set
            {
                _monitorFrequency = value;
                OnPropertyChanged(nameof(MonitorFrequency));
            }
        }

        public string MonitorCurrentFrequency
        {
            get => PcInfoViewModel.MonitorCurrentFrequency;
            set
            {
                _monitorCurrentFrequency = value;
                OnPropertyChanged(nameof(MonitorCurrentFrequency));
            }
        }

        public string InternalGraphicsName
        {
            get => PcInfoViewModel.InternalGraphicsName;
            set
            {
                _internalGraphicsName = value;
                OnPropertyChanged(nameof(InternalGraphicsName));
            }
        }

        public string InternalGraphicsDriverVersion
        {
            get => PcInfoViewModel.InternalGraphicsDriverVersion;
            set
            {
                _internalGraphicsDriverVersion = value;
                OnPropertyChanged(nameof(InternalGraphicsDriverVersion));
            }
        }

        public string InternalGraphicsDate
        {
            get => PcInfoViewModel.InternalGraphicsDate;
            set 
            {
                _internalGraphicsDate = value;
                OnPropertyChanged(nameof(InternalGraphicsDate));
            }
        }

        public string InternalGraphicsManufacturer
        {
            get => PcInfoViewModel.InternalGraphicsManufacturer;
            set 
            {
                _internalGraphicsManufacturer = value;
                OnPropertyChanged(nameof(InternalGraphicsManufacturer));
            }
        }

        public string InternalGraphicsModel
        {
            get => PcInfoViewModel.InternalGraphicsModel;
            set 
            {
                _internalGraphicsModel = value;
                OnPropertyChanged(nameof(InternalGraphicsModel));
            }
        }

        public string MonitorName
        {
            get => PcInfoViewModel.MonitorName;
            set
            {
                _monitorName = value;
                OnPropertyChanged(nameof(MonitorName));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.ViewModels
{
    public class GraphicsViewModel : ViewModelBase
    {
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
            }
        }

        public string MonitorHeight
        {
            get => PcInfoViewModel.MonitorHeight;
            set
            {
                _monitorHeight = value;
            }
        }

        public string MonitorResolution
        {
            get => PcInfoViewModel.MonitorResolution;
            set
            {
                _monitorResolution = value;
            }
        }

        public string MonitorBitsPerPixel
        {
            get => PcInfoViewModel.MonitorBitsPerPixel;
            set 
            {
                _monitorBitsPerPixel = value;
            }
        }

        public string MonitorFrequency
        {
            get => PcInfoViewModel.MonitorFrequency;
            set
            {
                _monitorFrequency = value;
            }
        }

        public string MonitorCurrentFrequency
        {
            get => PcInfoViewModel.MonitorCurrentFrequency;
            set
            {
                _monitorCurrentFrequency = value;
            }
        }

        public string InternalGraphicsName
        {
            get => PcInfoViewModel.InternalGraphicsName;
            set
            {
                _internalGraphicsName = value;
            }
        }

        public string InternalGraphicsDriverVersion
        {
            get => PcInfoViewModel.InternalGraphicsDriverVersion;
            set
            {
                _internalGraphicsDriverVersion = value;
            }
        }

        public string InternalGraphicsDate
        {
            get => PcInfoViewModel.InternalGraphicsDate;
            set 
            {
                _internalGraphicsDate = value;
            }
        }

        public string InternalGraphicsManufacturer
        {
            get => PcInfoViewModel.InternalGraphicsManufacturer;
            set 
            {
                _internalGraphicsManufacturer = value;
            }
        }

        public string InternalGraphicsModel
        {
            get => PcInfoViewModel.InternalGraphicsModel;
            set 
            {
                _internalGraphicsModel = value;
            }
        }
    }
}

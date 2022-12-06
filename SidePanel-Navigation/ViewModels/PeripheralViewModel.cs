using SidePanel_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.ViewModels
{
    public class PeripheralViewModel : ViewModelBase
    {
        List<InputDeviceModel> mouse;
        List<InputDeviceModel> keyboard;
        List<InputDeviceModel> cameraDevice;
        List<PrinterModel> printer;

        public List<InputDeviceModel> Mouse
        {
            get => PcInfoViewModel.Mouse;
            set
            {
                mouse = value;
                OnPropertyChanged(nameof(Mouse));
            }
        }

        public List<InputDeviceModel> Keyboard
        {
            get => PcInfoViewModel.Keyboard;
            set
            {
                keyboard = value;
                OnPropertyChanged(nameof(Keyboard));
            }
        }

        public List<PrinterModel> Printer
        {
            get => PcInfoViewModel.Printer;
            set
            {
                printer = value;
                OnPropertyChanged(nameof(Printer));
            }
        }

        public List<InputDeviceModel> CameraDevice
        {
            get => PcInfoViewModel.CameraDevice;
            set
            {
                cameraDevice = value;
                OnPropertyChanged(nameof(CameraDevice));
            }
        }
    }
}

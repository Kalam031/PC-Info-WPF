using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SidePanel_Navigation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        public ViewModelBase CurrentChildView
        {
            get => _currentChildView;
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        public ICommand SummaryViewCommand { get; }
        public ICommand OsViewCommand { get; }
        public ICommand CpuViewCommand { get; }
        public ICommand RamViewCommand { get; }
        public ICommand MotherboardViewCommand { get; }
        public ICommand GraphicsViewCommand { get; }
        public ICommand StorageViewCommand { get; }
        public ICommand OpticaldriveViewCommand { get; }
        public ICommand AudioViewCommand { get; }
        public ICommand PeripheralViewCommand { get; }
        public ICommand NetworkViewCommand { get; }

        public MainViewModel()
        {
            SummaryViewCommand = new ViewModelCommand(ExecuteSummaryViewCommand);
            OsViewCommand = new ViewModelCommand(ExecuteOsViewCommand);
            CpuViewCommand = new ViewModelCommand(ExecuteCpuViewCommand);
            RamViewCommand = new ViewModelCommand(ExecuteRamViewCommand);
            MotherboardViewCommand = new ViewModelCommand(ExecuteMotherboardViewCommand);
            GraphicsViewCommand = new ViewModelCommand(ExecuteGraphicsViewCommand);
            StorageViewCommand = new ViewModelCommand(ExecuteStorageViewCommand);
            OpticaldriveViewCommand = new ViewModelCommand(ExecuteOpticaldriveViewCommand);
            AudioViewCommand = new ViewModelCommand(ExecuteAudioViewCommand);
            PeripheralViewCommand = new ViewModelCommand(ExecutePeripheralViewCommand);
            NetworkViewCommand = new ViewModelCommand(ExecuteNetworkViewCommand);

            ExecuteSummaryViewCommand(null);
        }

        private void ExecuteNetworkViewCommand(object obj)
        {
            CurrentChildView = new NetworkViewModel();
            Caption = "Network";
            Icon = IconChar.Wifi3;
        }

        private void ExecutePeripheralViewCommand(object obj)
        {
            CurrentChildView = new PeripheralViewModel();
            Caption = "Peripheral";
            Icon = IconChar.ComputerMouse;
        }

        private void ExecuteAudioViewCommand(object obj)
        {
            CurrentChildView = new AudioViewModel();
            Caption = "Audio";
            Icon = IconChar.VolumeHigh;
        }

        private void ExecuteOpticaldriveViewCommand(object obj)
        {
            CurrentChildView = new OpticaldriveViewModel();
            Caption = "Optical Drive";
            Icon = IconChar.CompactDisc;
        }

        private void ExecuteStorageViewCommand(object obj)
        {
            CurrentChildView = new StorageViewModel();
            Caption = "Storage";
            Icon = IconChar.HardDrive;
        }

        private void ExecuteGraphicsViewCommand(object obj)
        {
            CurrentChildView = new GraphicsViewModel();
            Caption = "Graphics";
            Icon = IconChar.Desktop;
        }

        private void ExecuteMotherboardViewCommand(object obj)
        {
            CurrentChildView = new MotherboardViewModel();
            Caption = "Mother Board";
            Icon = IconChar.Keyboard;
        }

        private void ExecuteRamViewCommand(object obj)
        {
            CurrentChildView = new RamViewModel();
            Caption = "Ram";
            Icon = IconChar.Memory;
        }

        private void ExecuteCpuViewCommand(object obj)
        {
            CurrentChildView = new CpuViewModel();
            Caption = "CPU";
            Icon = IconChar.Microchip;
        }

        private void ExecuteOsViewCommand(object obj)
        {
            CurrentChildView = new OsViewModel();
            Caption = "Operating System";
            Icon = IconChar.Windows;
        }

        private void ExecuteSummaryViewCommand(object obj)
        {
            CurrentChildView = new SummaryViewModel();
            Caption = "Summary";
            Icon = IconChar.ClipboardList;
        }
    }
}

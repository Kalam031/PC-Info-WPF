using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.ViewModels
{
    public class MotherboardViewModel : ViewModelBase
    {
        string _motherboardManufacturer;
        string _motherboardSerial;
        string _motherboardModel;
        string _motherbaordVersion;
        string _biosVersion;
        string _biosDate;
        string _biosSerial;

        public string MotherboardManufacturer
        {
            get => PcInfoViewModel.MotherboardManufacturer;
            set
            {
                _motherboardManufacturer = value;
                OnPropertyChanged(nameof(MotherboardManufacturer));
            }
        }

        public string MotherboardSerial
        {
            get => PcInfoViewModel.MotherboardSerial;
            set
            {
                _motherboardSerial = value;
                OnPropertyChanged(nameof(MotherboardSerial));
            }
        }

        public string MotherboardModel
        {
            get => PcInfoViewModel.MotherboardModel;
            set
            {
                _motherboardModel = value;
                OnPropertyChanged(nameof(MotherboardModel));
            }
        }

        public string MotherbaordVersion
        {
            get => PcInfoViewModel.MotherboardVersion;
            set
            {
                _motherbaordVersion = value;
                OnPropertyChanged(nameof(MotherbaordVersion));
            }
        }

        public string BiosVersion
        {
            get => PcInfoViewModel.BiosVersion;
            set
            {
                _biosVersion = value;
                OnPropertyChanged(nameof(BiosVersion));
            }
        }

        public string BiosDate
        {
            get => PcInfoViewModel.BiosDate;
            set
            {
                _biosDate = value;
                OnPropertyChanged(nameof(BiosDate));
            }
        }

        public string BiosSerial
        {
            get => PcInfoViewModel.BiosSerialNumber;
            set
            {
                _biosSerial = value;
                OnPropertyChanged(nameof(BiosSerial));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.ViewModels
{
    public class CpuViewModel : ViewModelBase
    {
        string _cpuModel;
        string _cpuId;
        string _cpuManufacturer;

        public string CpuModel
        {
            get => PcInfoViewModel.CpuModel;
            set
            {
                _cpuModel = value;
                OnPropertyChanged(nameof(CpuModel));
            }
        }

        public string CpuId
        { 
            get => PcInfoViewModel.CpuId;
            set
            {
                _cpuId = value;
                OnPropertyChanged(nameof(CpuId));
            }
        }

        public string CpuManufacturer
        {
            get => PcInfoViewModel.CpuManufacturer;
            set
            {
                _cpuManufacturer = value;
                OnPropertyChanged(nameof(CpuManufacturer));
            }
        }
    }
}

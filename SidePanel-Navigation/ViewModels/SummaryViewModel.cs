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

        public string OperatingSystem
        {
            get => PcInfoViewModel.OperatingSystemName;
            set
            {
                _operatingSystemName = value;
                OnPropertyChanged(nameof(OperatingSystem));
            }
        }
    }
}

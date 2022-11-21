using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.ViewModels
{
    public class RamViewModel : ViewModelBase
    {
        string _ramType;

        public string RamType
        {
            get => PcInfoViewModel.MemoryType;
            set
            {
                _ramType = value;
                OnPropertyChanged(nameof(RamType));
            }
        }
    }
}

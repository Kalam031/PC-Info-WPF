using SidePanel_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.ViewModels
{
    public class AudioViewModel : ViewModelBase
    {
        List<AudioModel> listAudioDevice;

        public List<AudioModel> ListAudioDevice
        {
            get => PcInfoViewModel.ListsoundDeviceInfo;
            set
            {
                listAudioDevice = value;
                OnPropertyChanged(nameof(ListAudioDevice));
            }
        }
    }
}

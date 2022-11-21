using SidePanel_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.ViewModels
{
    public class NetworkViewModel : ViewModelBase
    {
        string userip;
        string usersubnetmask;
        string usergateway;
        List<string> userdnsserver;
        List<NetworkAdapterModel> listNetworkInformation;

        public string Userip
        {
            get => PcInfoViewModel.Userip;
            set
            {
                userip = value;
                OnPropertyChanged(nameof(Userip));
            }
        }

        public string Usersubnetmask
        {
            get => PcInfoViewModel.Usersubnetmask;
            set 
            {
                usersubnetmask = value;
                OnPropertyChanged(nameof(Usersubnetmask));
            }
        }

        public string Usergateway
        {
            get => PcInfoViewModel.Usergateway;
            set
            {
                usergateway = value;
                OnPropertyChanged(nameof(Usergateway));
            }
        }

        public List<string> Userdnsserver
        {
            get => PcInfoViewModel.Userdnsserver;
            set
            {
                userdnsserver = value;
                OnPropertyChanged(nameof(Userdnsserver));
            }
        }

        public List<NetworkAdapterModel> ListNetworkInformation
        {
            get => PcInfoViewModel.ListNetworkInformation;
            set
            {
                listNetworkInformation = value;
                OnPropertyChanged(nameof(ListNetworkInformation));
            }
        }
    }
}

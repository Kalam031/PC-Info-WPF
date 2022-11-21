using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.Models
{
    public class NetworkAdapterModel
    {
        public string nicName { get; set; }
        public string macAddress { get; set; }
        public string ip { get; set; }
        public string subnetmask { get; set; }
        public string gateway { get; set; }
        public List<string> listdnsserver { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.Models
{
    public class PrinterModel
    {
        public string PrinterName { get; set; }
        public string PrinterPort { get; set; }
        public string PrintProcessor { get; set; }
        public string Priority { get; set; }
        public string PrintQuality { get; set; }
        public string Status { get; set; }
        public string DriverName { get; set; }
        public string WorkOffline { get; set; }
        public string SpoolEnabled { get; set; }
    }
}

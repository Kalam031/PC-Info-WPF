using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.Models
{
    public class DiskDriveModel
    {
        public string DiskName { get; set; }
        public string DiskManufacturer { get; set; }
        public string Heads { get; set; }
        public string Cylinders { get; set; }
        public string Tracks { get; set; }
        public string Sectors { get; set; }
        public string Serial { get; set; }
        public string Capacity { get; set; }
        public string RealSize { get; set; }
        public string Status { get; set; }
    }
}

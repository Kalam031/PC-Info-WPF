using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.Models
{
    public class DiskDrivePartitionModel
    {
        public string PartitionName { get; set; }
        public string DriveName { get; set; }
        public string UsedSpace { get; set; }
        public string FreeSpace { get; set; }
        public string TotalStorage { get; set; }
    }
}

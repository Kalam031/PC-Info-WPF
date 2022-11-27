using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.Models
{
    public class LocalDbModel
    {
        public string cpuModel { get; set; } //col1
        public string cpuID { get; set; } //col2
        public string ramManufacturer1 { get; set; } //col3 //col5
        public string ramSerial1 { get; set; } //col4 //col6
        public string ramManufacturer2 { get; set; } //col3 //col5
        public string ramSerial2 { get; set; } //col4 //col6
        public string motherboardManufacturer { get; set; } //col7
        public string motherboardSerial { get; set; } //col8
        public string monitorModel { get; set; } //col9
        public string harddiskModel1 { get; set; } //col10 // col12
        public string harddiskSerial1 { get; set; } //col11 //col13
        public string harddiskModel2 { get; set; } //col10 // col12
        public string harddiskSerial2 { get; set; } //col11 //col13
        public string mouseVendor { get; set; } //col14
        public string keyboardVendor { get; set; } //col15
    }
}

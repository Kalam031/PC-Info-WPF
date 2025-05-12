using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidePanel_Navigation.Log
{
    public static class LogClass
    {
        public static void LogWrite(string Message)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + DateTime.Now.Date.ToShortDateString().Replace('/', '-') + ".txt";
                if (!File.Exists(filepath))
                {
                    // Create a file to write to.   
                    using (StreamWriter sw = File.CreateText(filepath))
                    {
                        sw.WriteLine($"{DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt")} {Message}");
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        sw.WriteLine($"{DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt")} {Message}");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}

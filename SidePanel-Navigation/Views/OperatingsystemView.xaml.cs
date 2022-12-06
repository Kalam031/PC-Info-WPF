using Microsoft.Win32;
using SidePanel_Navigation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using SidePanel_Navigation.Models;
using System.Windows.Forms;
using Binding = System.Windows.Data.Binding;
using UserControl = System.Windows.Controls.UserControl;
using System.ComponentModel;
using SidePanel_Navigation.Log;

namespace SidePanel_Navigation.Views
{
    /// <summary>
    /// Interaction logic for OperatingsystemView.xaml
    /// </summary>
    public partial class OperatingsystemView : UserControl
    {
        DispatcherTimer dispatcherTimer;

        public OperatingsystemView()
        {
            InitializeComponent();

            osCurrentTime.Text = $"Current Time:    processing....";
            osCurrentUptime.Text = $"Current Uptime:    processing....";

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                osCurrentTime.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
                {
                    osCurrentTime.Text = $"{DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")}";
                }));

                osCurrentUptime.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
                {
                    osCurrentUptime.Text = PcInfoViewModel.OperatingSystemCurrentUptime;
                }));
            }
            catch (Exception ex)
            {
                LogClass.LogWrite("--- OS current time and current uptime calculation exception ---");
                LogClass.LogWrite(ex.Message);
                LogClass.LogWrite(ex.StackTrace);
                LogClass.LogWrite("--- OS current time and current uptime calculation exception ---");
            }
        }

    }
}

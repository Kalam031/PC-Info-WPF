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

namespace SidePanel_Navigation.Views
{
    /// <summary>
    /// Interaction logic for OperatingsystemView.xaml
    /// </summary>
    public partial class OperatingsystemView : UserControl
    {
        DispatcherTimer dispatcherTimer;
        BackgroundWorker backgroundWorker = new BackgroundWorker();

        public OperatingsystemView()
        {
            InitializeComponent();
            backgroundWorker.WorkerSupportsCancellation = true;

            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

            osCurrentTime.Text = $"Current Time:    processing....";
            osCurrentUptime.Text = $"Current Uptime:    processing....";

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                //Console.WriteLine("Os background worker running");
            }
            else if (e.Cancelled)
            {
            }
            else if (e.Error != null)
            {
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!backgroundWorker.CancellationPending)
            {
                osCurrentTime.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
                {
                    osCurrentTime.Text = $"{DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")}";
                }));

                string formattedTimeSpan = string.Format("{0:D2} d, {1:D2} h, {2:D2} m , {3:D3} s", GetUpTime().Days, GetUpTime().Hours, GetUpTime().Minutes, GetUpTime().Seconds.ToString().Substring(0));

                osCurrentUptime.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
                {
                    osCurrentUptime.Text = $"{formattedTimeSpan}";
                }));
            }
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            RunBackgroundTask();
        }

        public void RunBackgroundTask()
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        public TimeSpan GetUpTime()
        {
            return TimeSpan.FromMilliseconds(GetTickCount64());
        }

        [DllImport("kernel32")]
        extern static UInt64 GetTickCount64();
    }
}

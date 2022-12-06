using SidePanel_Navigation.Log;
using SidePanel_Navigation.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
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

namespace SidePanel_Navigation.Views
{
    /// <summary>
    /// Interaction logic for CpuView.xaml
    /// </summary>
    public partial class CpuView : UserControl
    {
        DispatcherTimer dispatcherTimer;
        CpuViewModel cpuViewModel = new CpuViewModel();
        //PerformanceCounter _cpuCounter = new PerformanceCounter();
        //BackgroundWorker backgroundWorker = new BackgroundWorker();

        public CpuView()
        {
            InitializeComponent();
            //backgroundWorker.WorkerSupportsCancellation = true;

            cpuUsedRate.Text = "Processing..";
            cpuUnusedRate.Text = "Processing..";
            //cpuUnusedRate.Text = "Processing..";

            //backgroundWorker.DoWork += BackgroundWorker_DoWork;
            //backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick; ;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        //private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if (!e.Cancelled && e.Error == null)
        //    {
        //    }
        //    else if (e.Cancelled)
        //    {
        //    }
        //    else if (e.Error != null)
        //    {
        //    }
        //}

        //private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    if (!backgroundWorker.CancellationPending)
        //    {
        //        double tempval = GetProcessorData();
        //        string used = tempval.ToString("F") + "%";
        //        string unused = (100.0 - tempval).ToString("F") + "%";

        //        cpuUsedRate.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
        //        {
        //            cpuUsedRate.Text = used;
        //        }));

        //        cpuUnusedRate.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
        //        {
        //            cpuUnusedRate.Text = unused;
        //        }));
        //    }
        //}

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                cpuUsedRate.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
                {
                    cpuUsedRate.Text = PcInfoViewModel.CpuUsed;
                }));

                cpuUnusedRate.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
                {
                    cpuUnusedRate.Text = PcInfoViewModel.CpuUnused;
                }));
            }
            catch (Exception ex)
            {
                LogClass.LogWrite("--- CPU Rate data calculation exception ---");
                LogClass.LogWrite(ex.Message);
                LogClass.LogWrite(ex.StackTrace);
                LogClass.LogWrite("--- CPU Rate data calculation exception ---");
            }
        }

        //public void RunBackgroundTask()
        //{
        //    if (!backgroundWorker.IsBusy)
        //    {
        //        backgroundWorker.RunWorkerAsync();
        //    }
        //}

        //public double GetProcessorData()
        //{
        //    return _GetCounterValue(_cpuCounter, "Processor", "% Processor Time", "_Total");
        //}

        //double _GetCounterValue(PerformanceCounter pc, string categoryName, string counterName, string instanceName)
        //{
        //    pc.CategoryName = categoryName;
        //    pc.CounterName = counterName;
        //    pc.InstanceName = instanceName;
        //    pc.NextValue();
        //    System.Threading.Thread.Sleep(1000);
        //    return pc.NextValue();
        //}
    }
}

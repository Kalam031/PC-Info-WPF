using SidePanel_Navigation.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for RamView.xaml
    /// </summary>
    public partial class RamView : UserControl
    {
        DispatcherTimer dispatcherTimer;

        public RamView()
        {
            InitializeComponent();

            memUsage.Text = "Processing..";
            memAvailable.Text = "Processing..";
            memSize.Text = "Processing..";

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            int count = 0;
            if (PcInfoViewModel.ListMemInfo != null)
            {
                foreach (var v in PcInfoViewModel.ListMemInfo)
                {
                    CreateControl($"slot-{++count}", v.Type, v.Size, v.Manufacturer, v.SerialNo, v.Speed);
                }
            }
        }

        private void CreateControl(string title, string type, string size, string manufacturer, string serialNo, string speed)
        {
            Expander memExpander = new Expander();
            memExpander.Name = "memExpand";
            memExpander.Margin = new Thickness(25,0,0,0);
            memExpander.IsExpanded = true;
            memExpander.Foreground = new SolidColorBrush(Color.FromRgb(188, 190, 224));
            memExpander.Header = $"{title}";
            stpanelMemSlotInto.Children.Add(memExpander);

            Grid grid = new Grid();
            grid.Margin = new Thickness(25,0,0,0);
            memExpander.Content = grid;

            ColumnDefinition colDef1 = new ColumnDefinition();
            colDef1.Width = new GridLength(100);
            ColumnDefinition colDef2 = new ColumnDefinition();
            colDef2.Width = new GridLength(200);
            grid.ColumnDefinitions.Add(colDef1);
            grid.ColumnDefinitions.Add(colDef2);

            RowDefinition rowDef1 = new RowDefinition();
            rowDef1.Height = new GridLength(20);
            RowDefinition rowDef2 = new RowDefinition();
            rowDef2.Height = new GridLength(20);
            RowDefinition rowDef3 = new RowDefinition();
            rowDef3.Height = new GridLength(20);
            RowDefinition rowDef4 = new RowDefinition();
            rowDef4.Height = new GridLength(20);
            RowDefinition rowDef5 = new RowDefinition();
            rowDef5.Height = new GridLength(20);

            grid.RowDefinitions.Add(rowDef1);
            grid.RowDefinitions.Add(rowDef2);
            grid.RowDefinitions.Add(rowDef3);
            grid.RowDefinitions.Add(rowDef4);
            grid.RowDefinitions.Add(rowDef5);

            TextBlock textblocktype = new TextBlock();
            textblocktype.Foreground = new SolidColorBrush(Colors.White);
            textblocktype.Text = "Type";
            Grid.SetColumn(textblocktype, 0);
            Grid.SetRow(textblocktype, 0);

            TextBlock textblocktypeval = new TextBlock();
            textblocktypeval.Foreground = new SolidColorBrush(Colors.White);
            textblocktypeval.Text = type;
            Grid.SetColumn(textblocktypeval, 1);
            Grid.SetRow(textblocktypeval, 0);

            TextBlock textblocksize = new TextBlock();
            textblocksize.Foreground = new SolidColorBrush(Colors.White);
            textblocksize.Text = "Size";
            Grid.SetColumn(textblocksize, 0);
            Grid.SetRow(textblocksize, 1);

            TextBlock textblocksizeval = new TextBlock();
            textblocksizeval.Foreground = new SolidColorBrush(Colors.White);
            textblocksizeval.Text = size;
            Grid.SetColumn(textblocksizeval, 1);
            Grid.SetRow(textblocksizeval, 1);

            TextBlock textblockmanufacturer = new TextBlock();
            textblockmanufacturer.Foreground = new SolidColorBrush(Colors.White);
            textblockmanufacturer.Text = "Manufacturer";
            Grid.SetColumn(textblockmanufacturer, 0);
            Grid.SetRow(textblockmanufacturer, 2);

            TextBlock textblockmanufacturerval = new TextBlock();
            textblockmanufacturerval.Foreground = new SolidColorBrush(Colors.White);
            textblockmanufacturerval.Text = manufacturer;
            Grid.SetColumn(textblockmanufacturerval, 1);
            Grid.SetRow(textblockmanufacturerval, 2);

            TextBlock textblockSerial = new TextBlock();
            textblockSerial.Foreground = new SolidColorBrush(Colors.White);
            textblockSerial.Text = "Serial";
            Grid.SetColumn(textblockSerial, 0);
            Grid.SetRow(textblockSerial, 3);

            TextBlock textblockSerialval = new TextBlock();
            textblockSerialval.Foreground = new SolidColorBrush(Colors.White);
            textblockSerialval.Text = serialNo;
            Grid.SetColumn(textblockSerialval, 1);
            Grid.SetRow(textblockSerialval, 3);

            TextBlock textblockSpeed = new TextBlock();
            textblockSpeed.Foreground = new SolidColorBrush(Colors.White);
            textblockSpeed.Text = "Speed";
            Grid.SetColumn(textblockSpeed, 0);
            Grid.SetRow(textblockSpeed, 4);

            TextBlock textblockSpeedval = new TextBlock();
            textblockSpeedval.Foreground = new SolidColorBrush(Colors.White);
            textblockSpeedval.Text = speed;
            Grid.SetColumn(textblockSpeedval, 1);
            Grid.SetRow(textblockSpeedval, 4);

            grid.Children.Add(textblocktype);
            grid.Children.Add(textblocktypeval);
            grid.Children.Add(textblocksize);
            grid.Children.Add(textblocksizeval);
            grid.Children.Add(textblockmanufacturer);
            grid.Children.Add(textblockmanufacturerval);
            grid.Children.Add(textblockSerial);
            grid.Children.Add(textblockSerialval);
            grid.Children.Add(textblockSpeed);
            grid.Children.Add(textblockSpeedval);
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            memSize.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
            {
                memSize.Text = PcInfoViewModel.MemoryTotal;
            }));

            memAvailable.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
            {
                memAvailable.Text = PcInfoViewModel.MemoryAvailable;
            }));

            memUsage.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
            {
                memUsage.Text = PcInfoViewModel.MemoryUsage;
            }));
        }
    }
}

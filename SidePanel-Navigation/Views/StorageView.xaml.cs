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

namespace SidePanel_Navigation.Views
{
    /// <summary>
    /// Interaction logic for StorageView.xaml
    /// </summary>
    public partial class StorageView : UserControl
    {
        public StorageView()
        {
            InitializeComponent();

            foreach (var v in PcInfoViewModel.ListDiskDriveInfo)
            {
                CreateControl(v.DiskName, v.DiskManufacturer, v.Heads, v.Cylinders, v.Tracks, v.Sectors, v.Serial, v.Capacity, v.RealSize, v.Status);
            }
        }

        private void CreateControl(string title, string manufacturer, string heads, string cylinders, string tracks, string sectors, string serial, string capacity,  string realSize, string status)
        {
            Expander memExpander = new Expander();
            memExpander.Name = "memExpand";
            memExpander.Margin = new Thickness(25, 0, 0, 0);
            memExpander.IsExpanded = true;
            memExpander.Foreground = Brushes.White;
            memExpander.Header = title;
            mainStoragePanel.Children.Add(memExpander);

            Grid grid = new Grid();
            grid.Margin = new Thickness(25, 0, 0, 0);
            memExpander.Content = grid;

            ColumnDefinition colDef1 = new ColumnDefinition();
            colDef1.Width = new GridLength(160);
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
            RowDefinition rowDef6 = new RowDefinition();
            rowDef6.Height = new GridLength(20);
            RowDefinition rowDef7 = new RowDefinition();
            rowDef7.Height = new GridLength(20);
            RowDefinition rowDef8 = new RowDefinition();
            rowDef8.Height = new GridLength(20);
            RowDefinition rowDef9 = new RowDefinition();
            rowDef9.Height = new GridLength(20);

            grid.RowDefinitions.Add(rowDef1);
            grid.RowDefinitions.Add(rowDef2);
            grid.RowDefinitions.Add(rowDef3);
            grid.RowDefinitions.Add(rowDef4);
            grid.RowDefinitions.Add(rowDef5);
            grid.RowDefinitions.Add(rowDef6);
            grid.RowDefinitions.Add(rowDef7);
            grid.RowDefinitions.Add(rowDef8);
            grid.RowDefinitions.Add(rowDef9);

            TextBlock textblockmanufacturer = new TextBlock();
            textblockmanufacturer.Text = "Manufacuter";
            Grid.SetColumn(textblockmanufacturer, 0);
            Grid.SetRow(textblockmanufacturer, 0);

            TextBlock textblockmanufacturerval = new TextBlock();
            textblockmanufacturerval.Text = manufacturer;
            Grid.SetColumn(textblockmanufacturerval, 1);
            Grid.SetRow(textblockmanufacturerval, 0);

            TextBlock textblockheads = new TextBlock();
            textblockheads.Text = "Heads";
            Grid.SetColumn(textblockheads, 0);
            Grid.SetRow(textblockheads, 1);

            TextBlock textblockheadsval = new TextBlock();
            textblockheadsval.Text = heads;
            Grid.SetColumn(textblockheadsval, 1);
            Grid.SetRow(textblockheadsval, 1);

            TextBlock textblockcylinders = new TextBlock();
            textblockcylinders.Text = "Cylinders";
            Grid.SetColumn(textblockcylinders, 0);
            Grid.SetRow(textblockcylinders, 2);

            TextBlock textblockcylindersval = new TextBlock();
            textblockcylindersval.Text = cylinders;
            Grid.SetColumn(textblockcylindersval, 1);
            Grid.SetRow(textblockcylindersval, 2);

            TextBlock textblocktracks = new TextBlock();
            textblocktracks.Text = "Tracks";
            Grid.SetColumn(textblocktracks, 0);
            Grid.SetRow(textblocktracks, 3);

            TextBlock textblocktracksval = new TextBlock();
            textblocktracksval.Text = tracks;
            Grid.SetColumn(textblocktracksval, 1);
            Grid.SetRow(textblocktracksval, 3);

            TextBlock textblocksectors = new TextBlock();
            textblocksectors.Text = "Sectors";
            Grid.SetColumn(textblocksectors, 0);
            Grid.SetRow(textblocksectors, 4);

            TextBlock textblocksectorsval = new TextBlock();
            textblocksectorsval.Text = sectors;
            Grid.SetColumn(textblocksectorsval, 1);
            Grid.SetRow(textblocksectorsval, 4);

            TextBlock textblockserial = new TextBlock();
            textblockserial.Text = "Serial";
            Grid.SetColumn(textblockserial, 0);
            Grid.SetRow(textblockserial, 5);

            TextBlock textblockserialval = new TextBlock();
            textblockserialval.Text = serial;
            Grid.SetColumn(textblockserialval, 1);
            Grid.SetRow(textblockserialval, 5);

            TextBlock textblockcapacity = new TextBlock();
            textblockcapacity.Text = "Capacity";
            Grid.SetColumn(textblockcapacity, 0);
            Grid.SetRow(textblockcapacity, 6);

            TextBlock textblockcapacityval = new TextBlock();
            textblockcapacityval.Text = capacity;
            Grid.SetColumn(textblockcapacityval, 1);
            Grid.SetRow(textblockcapacityval, 6);

            TextBlock textblockrealsize = new TextBlock();
            textblockrealsize.Text = "Real Size";
            Grid.SetColumn(textblockrealsize, 0);
            Grid.SetRow(textblockrealsize, 7);

            TextBlock textblockrealsizeval = new TextBlock();
            textblockrealsizeval.Text = realSize + "bytes";
            Grid.SetColumn(textblockrealsizeval, 1);
            Grid.SetRow(textblockrealsizeval, 7);

            TextBlock textblockstatus = new TextBlock();
            textblockstatus.Text = "Status";
            Grid.SetColumn(textblockstatus, 0);
            Grid.SetRow(textblockstatus, 8);

            TextBlock textblockstatusval = new TextBlock();
            textblockstatusval.Text = status;
            Grid.SetColumn(textblockstatusval, 1);
            Grid.SetRow(textblockstatusval, 8);

            grid.Children.Add(textblockmanufacturer);
            grid.Children.Add(textblockmanufacturerval);
            grid.Children.Add(textblockheads);
            grid.Children.Add(textblockheadsval);
            grid.Children.Add(textblockcylinders);
            grid.Children.Add(textblockcylindersval);
            grid.Children.Add(textblocktracks);
            grid.Children.Add(textblocktracksval);
            grid.Children.Add(textblocksectors);
            grid.Children.Add(textblocksectorsval);
            grid.Children.Add(textblockserial);
            grid.Children.Add(textblockserialval);
            grid.Children.Add(textblockcapacity);
            grid.Children.Add(textblockcapacityval);
            grid.Children.Add(textblockrealsize);
            grid.Children.Add(textblockrealsizeval);
            grid.Children.Add(textblockstatus);
            grid.Children.Add(textblockstatusval);
        }
    }
}

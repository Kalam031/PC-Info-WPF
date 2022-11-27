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
        StorageViewModel storageViewModel = new StorageViewModel();
        public StorageView()
        {
            InitializeComponent();

            if (storageViewModel.ListDiskDriveInfo != null)
            {
                foreach (var v in storageViewModel.ListDiskDriveInfo)
                {
                    CreateControl(v.DiskName, v.DiskManufacturer, v.Heads, v.Cylinders, v.Tracks, v.Sectors, v.Serial, v.Capacity, v.RealSize, v.Status);
                }
            }
            else
            {
                CreateControl("Processing..", "Processing..", "Processing..", "Processing..", "Processing..", "Processing..", "Processing..", "Processing..", "Processing..", "Processing..");
            }
        }

        private void CreateControl(string title, string manufacturer, string heads, string cylinders, string tracks, string sectors, string serial, string capacity,  string realSize, string status)
        {
            Expander hardExpander = new Expander();
            hardExpander.Name = "hardExpand";
            hardExpander.Margin = new Thickness(25, 0, 0, 0);
            hardExpander.IsExpanded = true;
            hardExpander.Foreground = new SolidColorBrush(Color.FromRgb(188, 190, 224));
            hardExpander.Header = title;
            mainStoragePanel.Children.Add(hardExpander);

            StackPanel stackPanel = new StackPanel();
            stackPanel.Name = "inExpandPanel";
            stackPanel.Width = double.NaN;
            stackPanel.Height = double.NaN;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Left;
            hardExpander.Content = stackPanel;

            Grid grid = new Grid();
            grid.Margin = new Thickness(25, 0, 0, 0);
            stackPanel.Children.Add(grid);

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
            textblockmanufacturer.Foreground = new SolidColorBrush(Colors.White);
            textblockmanufacturer.Text = "Manufacuter";
            Grid.SetColumn(textblockmanufacturer, 0);
            Grid.SetRow(textblockmanufacturer, 0);

            TextBlock textblockmanufacturerval = new TextBlock();
            textblockmanufacturerval.Foreground = new SolidColorBrush(Colors.White);
            textblockmanufacturerval.Text = manufacturer;
            Grid.SetColumn(textblockmanufacturerval, 1);
            Grid.SetRow(textblockmanufacturerval, 0);

            TextBlock textblockheads = new TextBlock();
            textblockheads.Foreground = new SolidColorBrush(Colors.White);
            textblockheads.Text = "Heads";
            Grid.SetColumn(textblockheads, 0);
            Grid.SetRow(textblockheads, 1);

            TextBlock textblockheadsval = new TextBlock();
            textblockheadsval.Foreground = new SolidColorBrush(Colors.White);
            textblockheadsval.Text = heads;
            Grid.SetColumn(textblockheadsval, 1);
            Grid.SetRow(textblockheadsval, 1);

            TextBlock textblockcylinders = new TextBlock();
            textblockcylinders.Foreground = new SolidColorBrush(Colors.White);
            textblockcylinders.Text = "Cylinders";
            Grid.SetColumn(textblockcylinders, 0);
            Grid.SetRow(textblockcylinders, 2);

            TextBlock textblockcylindersval = new TextBlock();
            textblockcylindersval.Foreground = new SolidColorBrush(Colors.White);
            textblockcylindersval.Text = cylinders;
            Grid.SetColumn(textblockcylindersval, 1);
            Grid.SetRow(textblockcylindersval, 2);

            TextBlock textblocktracks = new TextBlock();
            textblocktracks.Foreground = new SolidColorBrush(Colors.White);
            textblocktracks.Text = "Tracks";
            Grid.SetColumn(textblocktracks, 0);
            Grid.SetRow(textblocktracks, 3);

            TextBlock textblocktracksval = new TextBlock();
            textblocktracksval.Foreground = new SolidColorBrush(Colors.White);
            textblocktracksval.Text = tracks;
            Grid.SetColumn(textblocktracksval, 1);
            Grid.SetRow(textblocktracksval, 3);

            TextBlock textblocksectors = new TextBlock();
            textblocksectors.Foreground = new SolidColorBrush(Colors.White);
            textblocksectors.Text = "Sectors";
            Grid.SetColumn(textblocksectors, 0);
            Grid.SetRow(textblocksectors, 4);

            TextBlock textblocksectorsval = new TextBlock();
            textblocksectorsval.Foreground = new SolidColorBrush(Colors.White);
            textblocksectorsval.Text = sectors;
            Grid.SetColumn(textblocksectorsval, 1);
            Grid.SetRow(textblocksectorsval, 4);

            TextBlock textblockserial = new TextBlock();
            textblockserial.Foreground = new SolidColorBrush(Colors.White);
            textblockserial.Text = "Serial";
            Grid.SetColumn(textblockserial, 0);
            Grid.SetRow(textblockserial, 5);

            TextBlock textblockserialval = new TextBlock();
            textblockserialval.Foreground = new SolidColorBrush(Colors.White);
            textblockserialval.Text = serial;
            Grid.SetColumn(textblockserialval, 1);
            Grid.SetRow(textblockserialval, 5);

            TextBlock textblockcapacity = new TextBlock();
            textblockcapacity.Foreground = new SolidColorBrush(Colors.White);
            textblockcapacity.Text = "Capacity";
            Grid.SetColumn(textblockcapacity, 0);
            Grid.SetRow(textblockcapacity, 6);

            TextBlock textblockcapacityval = new TextBlock();
            textblockcapacityval.Foreground = new SolidColorBrush(Colors.White);
            textblockcapacityval.Text = capacity;
            Grid.SetColumn(textblockcapacityval, 1);
            Grid.SetRow(textblockcapacityval, 6);

            TextBlock textblockrealsize = new TextBlock();
            textblockrealsize.Foreground = new SolidColorBrush(Colors.White);
            textblockrealsize.Text = "Real Size";
            Grid.SetColumn(textblockrealsize, 0);
            Grid.SetRow(textblockrealsize, 7);

            TextBlock textblockrealsizeval = new TextBlock();
            textblockrealsizeval.Foreground = new SolidColorBrush(Colors.White);
            textblockrealsizeval.Text = realSize + " bytes";
            Grid.SetColumn(textblockrealsizeval, 1);
            Grid.SetRow(textblockrealsizeval, 7);

            TextBlock textblockstatus = new TextBlock();
            textblockstatus.Foreground = new SolidColorBrush(Colors.White);
            textblockstatus.Text = "Status";
            Grid.SetColumn(textblockstatus, 0);
            Grid.SetRow(textblockstatus, 8);

            TextBlock textblockstatusval = new TextBlock();
            textblockstatusval.Foreground = new SolidColorBrush(Colors.White);
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

            Expander hardSubExpander = new Expander();
            hardSubExpander.Name = "hardSubExpand";
            hardSubExpander.Margin = new Thickness(25, 0, 0, 0);
            hardSubExpander.IsExpanded = true;
            hardSubExpander.Foreground = new SolidColorBrush(Color.FromRgb(188, 190, 224));
            hardSubExpander.Header = "Partition";
            stackPanel.Children.Add(hardSubExpander);

            StackPanel stackPanel2 = new StackPanel();
            stackPanel2.Name = "insubExpandPanel";
            stackPanel2.Width = double.NaN;
            stackPanel2.Height = double.NaN;
            stackPanel2.HorizontalAlignment = HorizontalAlignment.Left;
            hardSubExpander.Content = stackPanel2;

            if (storageViewModel.ListDiskPartionInfo != null)
            {
                foreach (var v in storageViewModel.ListDiskPartionInfo)
                {
                    if (v.PartitionName.Contains("0"))
                    {
                        Expander hardSubExpander1 = new Expander();
                        hardSubExpander1.Name = "hardSubExpand";
                        hardSubExpander1.Margin = new Thickness(25, 0, 0, 0);
                        hardSubExpander1.IsExpanded = true;
                        hardSubExpander1.Foreground = new SolidColorBrush(Color.FromRgb(188, 190, 224));
                        hardSubExpander1.Header = $"Partition {v.PartitionName}";
                        stackPanel2.Children.Add(hardSubExpander1);

                        Grid grid1 = new Grid();
                        grid1.Margin = new Thickness(25, 0, 0, 0);
                        hardSubExpander1.Content = grid1;

                        ColumnDefinition colDef201 = new ColumnDefinition();
                        colDef201.Width = new GridLength(90);
                        ColumnDefinition colDef202 = new ColumnDefinition();
                        colDef202.Width = new GridLength(200);

                        grid1.ColumnDefinitions.Add(colDef201);
                        grid1.ColumnDefinitions.Add(colDef202);

                        RowDefinition rowDef201 = new RowDefinition();
                        rowDef201.Height = new GridLength(20);

                        grid1.RowDefinitions.Add(rowDef201);

                        TextBlock textblockbootPartitionName = new TextBlock();
                        textblockbootPartitionName.Foreground = new SolidColorBrush(Colors.White);
                        textblockbootPartitionName.Text = "Size";
                        Grid.SetColumn(textblockbootPartitionName, 0);
                        Grid.SetRow(textblockbootPartitionName, 0);

                        TextBlock textblockbootPartitionNameval = new TextBlock();
                        textblockbootPartitionNameval.Foreground = new SolidColorBrush(Colors.White);
                        textblockbootPartitionNameval.Text = v.TotalStorage;
                        Grid.SetColumn(textblockbootPartitionNameval, 1);
                        Grid.SetRow(textblockbootPartitionNameval, 0);

                        grid1.Children.Add(textblockbootPartitionName);
                        grid1.Children.Add(textblockbootPartitionNameval);
                    }
                    else
                    {
                        Expander hardSubExpander2 = new Expander();
                        hardSubExpander2.Name = "hardSubExpand";
                        hardSubExpander2.Margin = new Thickness(25, 0, 0, 0);
                        hardSubExpander2.IsExpanded = true;
                        hardSubExpander2.Foreground = new SolidColorBrush(Color.FromRgb(188, 190, 224));
                        hardSubExpander2.Header = $"Partition {v.PartitionName}";
                        stackPanel2.Children.Add(hardSubExpander2);

                        Grid grid2 = new Grid();
                        grid2.Margin = new Thickness(25, 0, 0, 0);
                        hardSubExpander2.Content = grid2;

                        ColumnDefinition colDef301 = new ColumnDefinition();
                        colDef301.Width = new GridLength(90);
                        ColumnDefinition colDef302 = new ColumnDefinition();
                        colDef302.Width = new GridLength(200);

                        grid2.ColumnDefinitions.Add(colDef301);
                        grid2.ColumnDefinitions.Add(colDef302);

                        RowDefinition rowDef301 = new RowDefinition();
                        rowDef301.Height = new GridLength(20);
                        RowDefinition rowDef302 = new RowDefinition();
                        rowDef302.Height = new GridLength(20);
                        RowDefinition rowDef303 = new RowDefinition();
                        rowDef303.Height = new GridLength(20);
                        RowDefinition rowDef304 = new RowDefinition();
                        rowDef304.Height = new GridLength(20);

                        grid2.RowDefinitions.Add(rowDef301);
                        grid2.RowDefinitions.Add(rowDef302);
                        grid2.RowDefinitions.Add(rowDef303);
                        grid2.RowDefinitions.Add(rowDef304);

                        TextBlock textblockbootPartitionDriveName = new TextBlock();
                        textblockbootPartitionDriveName.Foreground = new SolidColorBrush(Colors.White);
                        textblockbootPartitionDriveName.Text = "Drive";
                        Grid.SetColumn(textblockbootPartitionDriveName, 0);
                        Grid.SetRow(textblockbootPartitionDriveName, 0);

                        TextBlock textblockbootPartitionDriveval = new TextBlock();
                        textblockbootPartitionDriveval.Foreground = new SolidColorBrush(Colors.White);
                        textblockbootPartitionDriveval.Text = v.DriveName;
                        Grid.SetColumn(textblockbootPartitionDriveval, 1);
                        Grid.SetRow(textblockbootPartitionDriveval, 0);

                        TextBlock textblockbootPartitionSize = new TextBlock();
                        textblockbootPartitionSize.Foreground = new SolidColorBrush(Colors.White);
                        textblockbootPartitionSize.Text = "Size";
                        Grid.SetColumn(textblockbootPartitionSize, 0);
                        Grid.SetRow(textblockbootPartitionSize, 1);

                        TextBlock textblockbootPartitionSizeval = new TextBlock();
                        textblockbootPartitionSizeval.Foreground = new SolidColorBrush(Colors.White);
                        textblockbootPartitionSizeval.Text = v.TotalStorage;
                        Grid.SetColumn(textblockbootPartitionSizeval, 1);
                        Grid.SetRow(textblockbootPartitionSizeval, 1);

                        TextBlock textblockbootPartitionUsedSpace = new TextBlock();
                        textblockbootPartitionUsedSpace.Foreground = new SolidColorBrush(Colors.White);
                        textblockbootPartitionUsedSpace.Text = "Used Space";
                        Grid.SetColumn(textblockbootPartitionUsedSpace, 0);
                        Grid.SetRow(textblockbootPartitionUsedSpace, 2);

                        TextBlock textblockbootPartitionUsedSpaceval = new TextBlock();
                        textblockbootPartitionUsedSpaceval.Foreground = new SolidColorBrush(Colors.White);
                        textblockbootPartitionUsedSpaceval.Text = v.UsedSpace;
                        Grid.SetColumn(textblockbootPartitionUsedSpaceval, 1);
                        Grid.SetRow(textblockbootPartitionUsedSpaceval, 2);

                        TextBlock textblockbootPartitionFreeSpace = new TextBlock();
                        textblockbootPartitionFreeSpace.Foreground = new SolidColorBrush(Colors.White);
                        textblockbootPartitionFreeSpace.Text = "Free Space";
                        Grid.SetColumn(textblockbootPartitionFreeSpace, 0);
                        Grid.SetRow(textblockbootPartitionFreeSpace, 3);

                        TextBlock textblockbootPartitionFreeSpaceval = new TextBlock();
                        textblockbootPartitionFreeSpaceval.Foreground = new SolidColorBrush(Colors.White);
                        textblockbootPartitionFreeSpaceval.Text = v.FreeSpace;
                        Grid.SetColumn(textblockbootPartitionFreeSpaceval, 1);
                        Grid.SetRow(textblockbootPartitionFreeSpaceval, 3);

                        grid2.Children.Add(textblockbootPartitionDriveName);
                        grid2.Children.Add(textblockbootPartitionDriveval);
                        grid2.Children.Add(textblockbootPartitionSize);
                        grid2.Children.Add(textblockbootPartitionSizeval);
                        grid2.Children.Add(textblockbootPartitionUsedSpace);
                        grid2.Children.Add(textblockbootPartitionUsedSpaceval);
                        grid2.Children.Add(textblockbootPartitionFreeSpace);
                        grid2.Children.Add(textblockbootPartitionFreeSpaceval);
                    }
                }
            }
        }
    }
}

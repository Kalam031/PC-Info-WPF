using SidePanel_Navigation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SidePanel_Navigation.Views
{
    /// <summary>
    /// Interaction logic for PeripheralView.xaml
    /// </summary>
    public partial class PeripheralView : UserControl
    {
        PeripheralViewModel peripheralViewModel = new PeripheralViewModel();

        public PeripheralView()
        {
            InitializeComponent();

            if (peripheralViewModel.Mouse != null)
            {
                foreach (var v in peripheralViewModel.Mouse)
                {
                    Expander newExpander = new Expander();
                    newExpander.Name = "newExpand1";
                    newExpander.Margin = new Thickness(25, 0, 0, 0);
                    newExpander.IsExpanded = true;
                    newExpander.Foreground = Brushes.White;
                    newExpander.Header = v.DeviceName;
                    mainPeripheralPanel.Children.Add(newExpander);

                    Grid gridmouse = new Grid();
                    gridmouse.Margin = new Thickness(25, 0, 0, 0);
                    newExpander.Content = gridmouse;

                    ColumnDefinition colDefm1 = new ColumnDefinition();
                    colDefm1.Width = new GridLength(100);
                    ColumnDefinition colDefm2 = new ColumnDefinition();
                    colDefm2.Width = new GridLength(200);

                    gridmouse.ColumnDefinitions.Add(colDefm1);
                    gridmouse.ColumnDefinitions.Add(colDefm2);

                    RowDefinition rowDefm1 = new RowDefinition();
                    rowDefm1.Height = new GridLength(20);
                    RowDefinition rowDefm2 = new RowDefinition();
                    rowDefm2.Height = new GridLength(20);
                    RowDefinition rowDefm3 = new RowDefinition();
                    rowDefm3.Height = new GridLength(20);

                    gridmouse.RowDefinitions.Add(rowDefm1);
                    gridmouse.RowDefinitions.Add(rowDefm2);
                    gridmouse.RowDefinitions.Add(rowDefm3);

                    TextBlock textblockmtype = new TextBlock();
                    textblockmtype.Text = "Device Type";
                    Grid.SetColumn(textblockmtype, 0);
                    Grid.SetRow(textblockmtype, 0);

                    TextBlock textblockmtypeval = new TextBlock();
                    textblockmtypeval.Text = v.DeviceType;
                    Grid.SetColumn(textblockmtypeval, 1);
                    Grid.SetRow(textblockmtypeval, 0);

                    TextBlock textblockmname = new TextBlock();
                    textblockmname.Text = "Device Name";
                    Grid.SetColumn(textblockmname, 0);
                    Grid.SetRow(textblockmname, 1);

                    TextBlock textblockmnameval = new TextBlock();
                    textblockmnameval.Text = v.DeviceName;
                    Grid.SetColumn(textblockmnameval, 1);
                    Grid.SetRow(textblockmnameval, 1);

                    TextBlock textblockmvvendor = new TextBlock();
                    textblockmvvendor.Text = "Vendor Name";
                    Grid.SetColumn(textblockmvvendor, 0);
                    Grid.SetRow(textblockmvvendor, 2);

                    TextBlock textblockmvvendorval = new TextBlock();
                    textblockmvvendorval.Text = v.DeviceVendor;
                    Grid.SetColumn(textblockmvvendorval, 1);
                    Grid.SetRow(textblockmvvendorval, 2);

                    gridmouse.Children.Add(textblockmtype);
                    gridmouse.Children.Add(textblockmtypeval);
                    gridmouse.Children.Add(textblockmname);
                    gridmouse.Children.Add(textblockmnameval);
                    gridmouse.Children.Add(textblockmvvendor);
                    gridmouse.Children.Add(textblockmvvendorval);
                }
            }

            if (peripheralViewModel.Keyboard != null)
            {
                foreach (var v in peripheralViewModel.Keyboard)
                {
                    Expander newExpander = new Expander();
                    newExpander.Name = "newExpand2";
                    newExpander.Margin = new Thickness(25, 0, 0, 0);
                    newExpander.IsExpanded = true;
                    newExpander.Foreground = Brushes.White;
                    newExpander.Header = v.DeviceName;
                    mainPeripheralPanel.Children.Add(newExpander);

                    Grid gridkeyboard = new Grid();
                    gridkeyboard.Margin = new Thickness(25, 0, 0, 0);
                    newExpander.Content = gridkeyboard;

                    ColumnDefinition colDefm1 = new ColumnDefinition();
                    colDefm1.Width = new GridLength(100);
                    ColumnDefinition colDefm2 = new ColumnDefinition();
                    colDefm2.Width = new GridLength(200);

                    gridkeyboard.ColumnDefinitions.Add(colDefm1);
                    gridkeyboard.ColumnDefinitions.Add(colDefm2);

                    RowDefinition rowDefm1 = new RowDefinition();
                    rowDefm1.Height = new GridLength(20);
                    RowDefinition rowDefm2 = new RowDefinition();
                    rowDefm2.Height = new GridLength(20);
                    RowDefinition rowDefm3 = new RowDefinition();
                    rowDefm3.Height = new GridLength(20);

                    gridkeyboard.RowDefinitions.Add(rowDefm1);
                    gridkeyboard.RowDefinitions.Add(rowDefm2);
                    gridkeyboard.RowDefinitions.Add(rowDefm3);

                    TextBlock textblockmtype = new TextBlock();
                    textblockmtype.Text = "Device Type";
                    Grid.SetColumn(textblockmtype, 0);
                    Grid.SetRow(textblockmtype, 0);

                    TextBlock textblockmtypeval = new TextBlock();
                    textblockmtypeval.Text = v.DeviceType;
                    Grid.SetColumn(textblockmtypeval, 1);
                    Grid.SetRow(textblockmtypeval, 0);

                    TextBlock textblockmname = new TextBlock();
                    textblockmname.Text = "Device Name";
                    Grid.SetColumn(textblockmname, 0);
                    Grid.SetRow(textblockmname, 1);

                    TextBlock textblockmnameval = new TextBlock();
                    textblockmnameval.Text = v.DeviceName;
                    Grid.SetColumn(textblockmnameval, 1);
                    Grid.SetRow(textblockmnameval, 1);


                    TextBlock textblockmvendor = new TextBlock();
                    textblockmvendor.Text = "Vendor Name";
                    Grid.SetColumn(textblockmvendor, 0);
                    Grid.SetRow(textblockmvendor, 2);

                    TextBlock textblockmvendorval = new TextBlock();
                    textblockmvendorval.Text = v.DeviceVendor;
                    Grid.SetColumn(textblockmvendorval, 1);
                    Grid.SetRow(textblockmvendorval, 2);

                    gridkeyboard.Children.Add(textblockmtype);
                    gridkeyboard.Children.Add(textblockmtypeval);
                    gridkeyboard.Children.Add(textblockmname);
                    gridkeyboard.Children.Add(textblockmnameval);
                    gridkeyboard.Children.Add(textblockmvendor);
                    gridkeyboard.Children.Add(textblockmvendorval);
                }
            }

            if (peripheralViewModel.Printer != null)
            {
                Expander newExpander = new Expander();
                newExpander.Name = "newExpand3";
                newExpander.Margin = new Thickness(25, 0, 0, 0);
                newExpander.IsExpanded = true;
                newExpander.Foreground = Brushes.White;
                newExpander.Header = "Printers";
                mainPeripheralPanel.Children.Add(newExpander);

                StackPanel stackPanel = new StackPanel();
                stackPanel.Name = "innewExpandPanel1";
                stackPanel.Width = double.NaN;
                stackPanel.Height = double.NaN;
                stackPanel.HorizontalAlignment = HorizontalAlignment.Left;
                newExpander.Content = stackPanel;

                foreach (var v in peripheralViewModel.Printer)
                {
                    Expander newExpandersub = new Expander();
                    newExpandersub.Name = "newExpand4";
                    newExpandersub.Margin = new Thickness(25, 0, 0, 0);
                    newExpandersub.IsExpanded = true;
                    newExpandersub.Foreground = Brushes.White;
                    newExpandersub.Header = v.PrinterName;
                    stackPanel.Children.Add(newExpandersub);

                    StackPanel stackPanel1 = new StackPanel();
                    stackPanel1.Name = "innewExpandPanel2";
                    stackPanel1.Width = double.NaN;
                    stackPanel1.Height = double.NaN;
                    stackPanel1.HorizontalAlignment = HorizontalAlignment.Left;
                    newExpandersub.Content = stackPanel1;

                    Grid grid = new Grid();
                    grid.Margin = new Thickness(25, 0, 0, 0);
                    stackPanel1.Children.Add(grid);

                    Expander newExpandergridsub = new Expander();
                    newExpandergridsub.Name = "newExpand5";
                    newExpandergridsub.Margin = new Thickness(25, 0, 0, 0);
                    newExpandergridsub.IsExpanded = true;
                    newExpandergridsub.Foreground = Brushes.White;
                    newExpandergridsub.Header = "Driver";
                    stackPanel1.Children.Add(newExpandergridsub);

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

                    TextBlock textblockprinterport = new TextBlock();
                    textblockprinterport.Text = "Printer Port";
                    Grid.SetColumn(textblockprinterport, 0);
                    Grid.SetRow(textblockprinterport, 0);

                    TextBlock textblockprinterportval = new TextBlock();
                    textblockprinterportval.Text = v.PrinterPort;
                    Grid.SetColumn(textblockprinterportval, 1);
                    Grid.SetRow(textblockprinterportval, 0);

                    TextBlock textblockprintprocessor = new TextBlock();
                    textblockprintprocessor.Text = "Print Processor";
                    Grid.SetColumn(textblockprintprocessor, 0);
                    Grid.SetRow(textblockprintprocessor, 1);

                    TextBlock textblockprintprocessorval = new TextBlock();
                    textblockprintprocessorval.Text = v.PrintProcessor;
                    Grid.SetColumn(textblockprintprocessorval, 1);
                    Grid.SetRow(textblockprintprocessorval, 1);

                    TextBlock textblockpriority = new TextBlock();
                    textblockpriority.Text = "Priority";
                    Grid.SetColumn(textblockpriority, 0);
                    Grid.SetRow(textblockpriority, 2);

                    TextBlock textblockpriorityval = new TextBlock();
                    textblockpriorityval.Text = v.Priority;
                    Grid.SetColumn(textblockpriorityval, 1);
                    Grid.SetRow(textblockpriorityval, 2);

                    TextBlock textblockprintquality = new TextBlock();
                    textblockprintquality.Text = "Print Quality";
                    Grid.SetColumn(textblockprintquality, 0);
                    Grid.SetRow(textblockprintquality, 3);

                    TextBlock textblockprintqualityval = new TextBlock();
                    textblockprintqualityval.Text = v.PrintQuality;
                    Grid.SetColumn(textblockprintqualityval, 1);
                    Grid.SetRow(textblockprintqualityval, 3);

                    TextBlock textblockstatus = new TextBlock();
                    textblockstatus.Text = "Status";
                    Grid.SetColumn(textblockstatus, 0);
                    Grid.SetRow(textblockstatus, 4);

                    TextBlock textblockstatusval = new TextBlock();
                    textblockstatusval.Text = v.Status;
                    Grid.SetColumn(textblockstatusval, 1);
                    Grid.SetRow(textblockstatusval, 4);

                    grid.Children.Add(textblockprinterport);
                    grid.Children.Add(textblockprinterportval);
                    grid.Children.Add(textblockprintprocessor);
                    grid.Children.Add(textblockprintprocessorval);
                    grid.Children.Add(textblockpriority);
                    grid.Children.Add(textblockpriorityval);
                    grid.Children.Add(textblockprintquality);
                    grid.Children.Add(textblockprintqualityval);
                    grid.Children.Add(textblockstatus);
                    grid.Children.Add(textblockstatusval);

                    Grid grid1 = new Grid();
                    grid1.Margin = new Thickness(25, 0, 0, 0);
                    newExpandergridsub.Content = grid1;

                    ColumnDefinition colDef101 = new ColumnDefinition();
                    colDef101.Width = new GridLength(100);
                    ColumnDefinition colDef201 = new ColumnDefinition();
                    colDef201.Width = new GridLength(200);

                    grid1.ColumnDefinitions.Add(colDef101);
                    grid1.ColumnDefinitions.Add(colDef201);

                    RowDefinition rowDef101 = new RowDefinition();
                    rowDef101.Height = new GridLength(20);

                    grid1.RowDefinitions.Add(rowDef101);

                    TextBlock textblockprintdrivername = new TextBlock();
                    textblockprintdrivername.Text = "Driver Name";
                    Grid.SetColumn(textblockprintdrivername, 0);
                    Grid.SetRow(textblockprintdrivername, 0);

                    TextBlock textblockprintdrivernameval = new TextBlock();
                    textblockprintdrivernameval.Text = v.DriverName;
                    Grid.SetColumn(textblockprintdrivernameval, 1);
                    Grid.SetRow(textblockprintdrivernameval, 0);

                    grid1.Children.Add(textblockprintdrivername);
                    grid1.Children.Add(textblockprintdrivernameval);
                }
            }
        }
    }
}

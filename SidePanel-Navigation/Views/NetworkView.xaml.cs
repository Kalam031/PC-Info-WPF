using SidePanel_Navigation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Interaction logic for NetworkView.xaml
    /// </summary>
    public partial class NetworkView : UserControl
    {
        NetworkViewModel networkViewModel = new NetworkViewModel();
        Expander adapterlistExpander = new Expander();
        StackPanel stackPanel = new StackPanel();

        public NetworkView()
        {
            InitializeComponent();

            RowDefinition rowDef101 = new RowDefinition();
            rowDef101.Height = new GridLength(20);
            RowDefinition rowDef201 = new RowDefinition();
            rowDef201.Height = new GridLength(20);

            mainnetpanelfirstgrid.RowDefinitions.Add(rowDef101);
            mainnetpanelfirstgrid.RowDefinitions.Add(rowDef201);

            if (PcInfoViewModel.Userdnsserver != null)
            {
                TextBlock textblockdns3 = new TextBlock();
                textblockdns3.TextAlignment = TextAlignment.Center;
                textblockdns3.Foreground = new SolidColorBrush(Colors.White);
                textblockdns3.Text = "Preferred DNS Server";
                Grid.SetColumn(textblockdns3, 0);
                Grid.SetRow(textblockdns3, 3);

                TextBlock textblockdns3val = new TextBlock();
                textblockdns3val.Margin = new Thickness(20,3,0,0);
                textblockdns3val.Foreground = new SolidColorBrush(Colors.White);
                textblockdns3val.Text = PcInfoViewModel.Userdnsserver[0];
                Grid.SetColumn(textblockdns3val, 1);
                Grid.SetRow(textblockdns3val, 3);

                TextBlock textblockdns4 = new TextBlock();
                textblockdns4.TextAlignment = TextAlignment.Center;
                textblockdns4.Foreground = new SolidColorBrush(Colors.White);
                textblockdns4.Text = "Alternate DNS Server";
                Grid.SetColumn(textblockdns4, 0);
                Grid.SetRow(textblockdns4, 5);

                TextBlock textblockdns4val = new TextBlock();
                textblockdns4val.Margin = new Thickness(20, 3, 0, 0);
                textblockdns4val.Foreground = new SolidColorBrush(Colors.White);
                textblockdns4val.Text = PcInfoViewModel.Userdnsserver[1];
                Grid.SetColumn(textblockdns4val, 1);
                Grid.SetRow(textblockdns4val, 5);

                mainnetpanelfirstgrid.Children.Add(textblockdns3);
                mainnetpanelfirstgrid.Children.Add(textblockdns3val);
                mainnetpanelfirstgrid.Children.Add(textblockdns4);
                mainnetpanelfirstgrid.Children.Add(textblockdns4val);
            }

            if (networkViewModel.ListNetworkInformation != null)
            {
                adapterlistExpander.Name = "adapterlistExpand";
                adapterlistExpander.Margin = new Thickness(25, 0, 0, 0);
                adapterlistExpander.IsExpanded = true;
                adapterlistExpander.Foreground = new SolidColorBrush(Color.FromRgb(188,190,224));
                adapterlistExpander.Header = "Adapter List";
                mainNetworkPanel.Children.Add(adapterlistExpander);

                stackPanel.Name = "inExpandPanel";
                stackPanel.Width = double.NaN;
                stackPanel.Height = double.NaN;
                stackPanel.HorizontalAlignment = HorizontalAlignment.Left;
                adapterlistExpander.Content = stackPanel;

                for (int i=0; i< networkViewModel.ListNetworkInformation.Count(); i++)
                {
                    if (!networkViewModel.ListNetworkInformation[i].nicName.Contains("vEthernet (Default Switch)"))
                    {
                        CreateControl(networkViewModel.ListNetworkInformation[i].nicName, networkViewModel.ListNetworkInformation[i].macAddress, networkViewModel.ListNetworkInformation[i].ip, networkViewModel.ListNetworkInformation[i].subnetmask, networkViewModel.ListNetworkInformation[i].gateway, networkViewModel.ListNetworkInformation[i].listdnsserver, 0);
                    }
                    else
                    {
                        CreateControl(networkViewModel.ListNetworkInformation[i].nicName, networkViewModel.ListNetworkInformation[i].macAddress, networkViewModel.ListNetworkInformation[i].ip, networkViewModel.ListNetworkInformation[i].subnetmask, "", networkViewModel.ListNetworkInformation[i].listdnsserver = null, 1);
                    }
                }
            }
            else
            {
                List<string> listdummy = new List<string>();
                listdummy.Add("Processing..");
                listdummy.Add("Processing..");
                //CreateControl("Processing..", "Processing..", "Processing..", "Processing..", listdummy);
            }
        }

        private void CreateControl(string nicname, string macaddress, string ip, string subnetmask, string gateway, List<string> lstdnsserver, int flag)
        {
            Expander newExpander = new Expander();
            newExpander.Name = "newExpand";
            newExpander.Margin = new Thickness(25, 0, 0, 0);
            newExpander.IsExpanded = true;
            newExpander.Foreground = new SolidColorBrush(Color.FromRgb(188, 190, 224));
            newExpander.Header = nicname;
            stackPanel.Children.Add(newExpander);

            Grid grid = new Grid();
            grid.Margin = new Thickness(25, 0, 0, 0);
            newExpander.Content = grid;

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
            //RowDefinition rowDef7 = new RowDefinition();
            //rowDef7.Height = new GridLength(20);
            //RowDefinition rowDef8 = new RowDefinition();

            grid.RowDefinitions.Add(rowDef1);
            grid.RowDefinitions.Add(rowDef2);
            grid.RowDefinitions.Add(rowDef3);

            //grid.RowDefinitions.Add(rowDef7);
            //grid.RowDefinitions.Add(rowDef8);

            TextBlock textblockmac = new TextBlock();
            textblockmac.Foreground = new SolidColorBrush(Colors.White);
            textblockmac.Text = "Mac Address";
            Grid.SetColumn(textblockmac, 0);
            Grid.SetRow(textblockmac, 0);

            TextBlock textblockmacval = new TextBlock();
            textblockmacval.Foreground = new SolidColorBrush(Colors.White);
            textblockmacval.Text = macaddress;
            Grid.SetColumn(textblockmacval, 1);
            Grid.SetRow(textblockmacval, 0);

            TextBlock textblockip = new TextBlock();
            textblockip.Foreground = new SolidColorBrush(Colors.White);
            textblockip.Text = "IP";
            Grid.SetColumn(textblockip, 0);
            Grid.SetRow(textblockip, 1);

            TextBlock textblockipval = new TextBlock();
            textblockipval.Foreground = new SolidColorBrush(Colors.White);
            textblockipval.Text = ip;
            Grid.SetColumn(textblockipval, 1);
            Grid.SetRow(textblockipval, 1);

            TextBlock textblocksubnetmask = new TextBlock();
            textblocksubnetmask.Foreground = new SolidColorBrush(Colors.White);
            textblocksubnetmask.Text = "Subnet";
            Grid.SetColumn(textblocksubnetmask, 0);
            Grid.SetRow(textblocksubnetmask, 2);

            TextBlock textblocksubnetmaskval = new TextBlock();
            textblocksubnetmaskval.Foreground = new SolidColorBrush(Colors.White);
            textblocksubnetmaskval.Text = subnetmask;
            Grid.SetColumn(textblocksubnetmaskval, 1);
            Grid.SetRow(textblocksubnetmaskval, 2);

            if (flag ==0)
            {
                RowDefinition rowDef4 = new RowDefinition();
                rowDef4.Height = new GridLength(20);

                grid.RowDefinitions.Add(rowDef4);

                TextBlock textblockgateway = new TextBlock();
                textblockgateway.Foreground = new SolidColorBrush(Colors.White);
                textblockgateway.Text = "Gateway";
                Grid.SetColumn(textblockgateway, 0);
                Grid.SetRow(textblockgateway, 3);

                TextBlock textblockgatewayval = new TextBlock();
                textblockgatewayval.Foreground = new SolidColorBrush(Colors.White);
                textblockgatewayval.Text = gateway;
                Grid.SetColumn(textblockgatewayval, 1);
                Grid.SetRow(textblockgatewayval, 3);

                grid.Children.Add(textblockgateway);
                grid.Children.Add(textblockgatewayval);
            }

            if (flag == 0)
            {
                RowDefinition rowDef5 = new RowDefinition();
                rowDef5.Height = new GridLength(20);
                RowDefinition rowDef6 = new RowDefinition();
                rowDef6.Height = new GridLength(20);

                grid.RowDefinitions.Add(rowDef5);
                grid.RowDefinitions.Add(rowDef6);

                TextBlock textblockdns1 = new TextBlock();
                textblockdns1.Foreground = new SolidColorBrush(Colors.White);
                textblockdns1.Text = "Dns server";
                Grid.SetColumn(textblockdns1, 0);
                Grid.SetRow(textblockdns1, 4);

                TextBlock textblockdns1val = new TextBlock();
                textblockdns1val.Foreground = new SolidColorBrush(Colors.White);
                textblockdns1val.Text = lstdnsserver[0];
                Grid.SetColumn(textblockdns1val, 1);
                Grid.SetRow(textblockdns1val, 4);

                TextBlock textblockdns2 = new TextBlock();
                textblockdns2.Foreground = new SolidColorBrush(Colors.White);
                textblockdns2.Text = "";
                Grid.SetColumn(textblockdns2, 0);
                Grid.SetRow(textblockdns2, 5);

                TextBlock textblockdns2val = new TextBlock();
                textblockdns2val.Foreground = new SolidColorBrush(Colors.White);
                textblockdns2val.Text = lstdnsserver[1];
                Grid.SetColumn(textblockdns2val, 1);
                Grid.SetRow(textblockdns2val, 5);

                grid.Children.Add(textblockdns1);
                grid.Children.Add(textblockdns1val);
                grid.Children.Add(textblockdns2);
                grid.Children.Add(textblockdns2val);
            }

            grid.Children.Add(textblockmac);
            grid.Children.Add(textblockmacval);
            grid.Children.Add(textblockip);
            grid.Children.Add(textblockipval);
            grid.Children.Add(textblocksubnetmask);
            grid.Children.Add(textblocksubnetmaskval);
        }
    }
}

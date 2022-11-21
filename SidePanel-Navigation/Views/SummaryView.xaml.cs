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
    /// Interaction logic for SummaryView.xaml
    /// </summary>
    public partial class SummaryView : UserControl
    {
        SummaryViewModel summaryViewModel = new SummaryViewModel();

        public SummaryView()
        {
            InitializeComponent();

            if (summaryViewModel.Liststorage != null)
            {
                foreach (var v in summaryViewModel.Liststorage)
                {
                    TextBlock textblockstorage = new TextBlock();
                    textblockstorage.Text = $"{v.Capacity} {v.DiskName}";
                    textblockstorage.Margin = new Thickness(80,2,0,0);
                    textblockstorage.Foreground = new SolidColorBrush(Color.FromArgb(255,214,209,245));

                    storageStackPanel.Children.Add(textblockstorage);
                }
            }

            if (summaryViewModel.Listaudio != null)
            {
                foreach (var v in summaryViewModel.Listaudio)
                {
                    TextBlock textblockaudio = new TextBlock();
                    textblockaudio.Text = $"{v.DeviceName}";
                    textblockaudio.Margin = new Thickness(80, 2, 0, 0);
                    textblockaudio.Foreground = new SolidColorBrush(Color.FromArgb(255, 214, 209, 245));

                    audioStackPanel.Children.Add(textblockaudio);
                }
            }

            if (summaryViewModel.Display != null)
            {
                TextBlock textblockdisplay = new TextBlock();
                textblockdisplay.Text = $"Monitor ({summaryViewModel.Display})";
                textblockdisplay.Margin = new Thickness(80, 2, 0, 0);
                textblockdisplay.Foreground = new SolidColorBrush(Color.FromArgb(255, 214, 209, 245));

                graphicsStackPanel.Children.Add(textblockdisplay);
            }

            if (summaryViewModel.Graphics != null)
            {
                TextBlock textblockgraphics = new TextBlock();
                textblockgraphics.Text = $"{summaryViewModel.Graphics}";
                textblockgraphics.Margin = new Thickness(80, 2, 0, 0);
                textblockgraphics.Foreground = new SolidColorBrush(Color.FromArgb(255, 214, 209, 245));

                graphicsStackPanel.Children.Add(textblockgraphics);
            }
        }
    }
}

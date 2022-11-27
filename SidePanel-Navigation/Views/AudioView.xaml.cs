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
    /// Interaction logic for AudioView.xaml
    /// </summary>
    public partial class AudioView : UserControl
    {
        AudioViewModel audioViewModel = new AudioViewModel();

        public AudioView()
        {
            InitializeComponent();

            if (audioViewModel.ListAudioDevice != null)
            {
                foreach (var v in audioViewModel.ListAudioDevice)
                {
                    Expander newExpander = new Expander();
                    newExpander.Name = "newExpand3";
                    newExpander.Margin = new Thickness(25, 0, 0, 0);
                    newExpander.IsExpanded = true;
                    newExpander.Foreground = new SolidColorBrush(Color.FromRgb(188,190,224));
                    newExpander.Header = "Sound Card";
                    mainAudioPanel.Children.Add(newExpander);

                    Grid grid = new Grid();
                    grid.Margin = new Thickness(25, 0, 0, 0);
                    newExpander.Content = grid;

                    ColumnDefinition colDef1 = new ColumnDefinition();
                    colDef1.Width = new GridLength(160);

                    grid.ColumnDefinitions.Add(colDef1);

                    RowDefinition rowDef1 = new RowDefinition();
                    rowDef1.Height = new GridLength(20);

                    grid.RowDefinitions.Add(rowDef1);

                    TextBlock textblockprinterport = new TextBlock();
                    textblockprinterport.Foreground = Brushes.White;
                    textblockprinterport.Text = v.DeviceName;
                    Grid.SetColumn(textblockprinterport, 0);
                    Grid.SetRow(textblockprinterport, 0);

                    grid.Children.Add(textblockprinterport);
                }
            }
        }
    }
}

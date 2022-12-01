using SidePanel_Navigation.Controls;
using SidePanel_Navigation.DB;
using SidePanel_Navigation.Models;
using SidePanel_Navigation.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SidePanel_Navigation.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public string dbpath = Directory.GetParent(Assembly.GetExecutingAssembly().Location) + "\\hardwareinfo.db" ;
        SqliteDbClass sqliteDbClass = new SqliteDbClass();
        SQLiteConnection sqlConnection;

        public MainView()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            //Console.WriteLine(dbpath);

            sqliteDbClass.OpenConnection(dbpath);
            sqlConnection = sqliteDbClass.OpenConnection(dbpath);

            if (!sqliteDbClass.CheckIfTableExists(sqlConnection, "Component_Title"))
            {
                sqliteDbClass.CreateComponentTitleTable(sqlConnection);

                try
                {
                    SQLiteCommand sqlite_cmd;
                    sqlite_cmd = sqlConnection.CreateCommand();
                    sqlite_cmd.CommandText = $"INSERT OR IGNORE INTO COMPONENT_TITLE(ID, COMPONENT)\r\nVALUES (1,'OS'), (2,'CPU'), (3,'RAM'), (4,'MOTHERBOARD'), (5, 'MONITOR'), (6, 'HARDDISK'), (7, 'MOUSE'), (8, 'KEYBOARD');";
                    sqlite_cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
            else
            {
                try
                {
                    SQLiteCommand sqlite_cmd;
                    sqlite_cmd = sqlConnection.CreateCommand();
                    sqlite_cmd.CommandText = $"INSERT OR IGNORE INTO COMPONENT_TITLE(ID, COMPONENT)\r\nVALUES (1,'OS'), (2,'CPU'), (3,'RAM'), (4,'MOTHERBOARD'), (5, 'MONITOR'), (6, 'HARDDISK'), (7, 'MOUSE'), (8, 'KEYBOARD');";
                    sqlite_cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }

            if (!sqliteDbClass.CheckIfTableExists(sqlConnection, "Component"))
            {
                sqliteDbClass.CreateComponentTable(sqlConnection);
            }

            if (!sqliteDbClass.CheckIfTableExists(sqlConnection, "Component_Extend"))
            {
                sqliteDbClass.CreateComponentExtendTable(sqlConnection);
            }

            //if (!sqliteDbClass.CheckIfTableExists(sqlConnection, "Summary"))
            //{
            //    sqliteDbClass.CreateSummaryTable(sqlConnection);
            //}

            sqlConnection.Close();

            GetPcInfoClass getPcInfoClass = new GetPcInfoClass();
            getPcInfoClass.GetInfo();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, (IntPtr)2, (IntPtr)0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal) this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}

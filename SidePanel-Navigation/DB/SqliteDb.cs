using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using
using System.Data.SQLite;
using SidePanel_Navigation.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Windows.Markup;
using System.Xml.Linq;

namespace SidePanel_Navigation.DB
{
    public class SqliteDb : IDisposable
    {
        bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~SqliteDb()
        {
            Dispose(false);
        }

        public bool CheckIfTableExists(SQLiteConnection conn, string tableName)
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
                cmd.CommandText = $"SELECT count(*) FROM sqlite_master WHERE type='table' AND name='{tableName}';";
                object result = cmd.ExecuteScalar();
                int resultCount = Convert.ToInt32(result);
                if (resultCount > 0)
                    return true;

            }
            return false;
        }

        public SQLiteConnection OpenConnection(string dbpath)
        {
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=" + dbpath);
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }

        public void CloseConnection(SQLiteConnection conn)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public void CreateHardwareInfoTable(SQLiteConnection conn)
        {

            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE HITable (Col1 Text, Col2 Text, Col3 Text, Col4 Text, Col5 Text, Col6 Text, Col7 Text, Col8 Text, Col9 Text, Col10 Text, Col11 Text, Col12 Text, Col13 Text, Col14 Text, Col15 Text)";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();

        }

        public void InsertHardwareInfoData(SQLiteConnection conn, List<LocalDbModel> hardwareList)
        {
            try
            {
                foreach (var v in hardwareList)
                {
                    SQLiteCommand sqlite_cmd;
                    sqlite_cmd = conn.CreateCommand();
                    sqlite_cmd.CommandText = $"INSERT INTO HTable (Col1, Col2, Col3, Col4, Col5, Col6, Col7, Col8, Col9, Col10, Col11, Col12, Col13, Col14, Col15) VALUES('{v.cpuModel}', '{v.cpuID}', '{v.ramManufacturer1}', '{v.ramSerial1}', '{v.ramManufacturer2}', '{v.ramSerial2}', '{v.motherboardManufacturer}', '{v.motherboardSerial}', '{v.harddiskModel1}', '{v.harddiskSerial1}', '{v.harddiskModel2}', '{v.harddiskSerial2}', '{v.monitorModel}', '{v.mouseVendor}', '{v.keyboardVendor}')";
                    sqlite_cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        //public void ReadHistoryData(SQLiteConnection conn)
        //{
        //    SQLiteDataReader sqlite_datareader;
        //    SQLiteCommand sqlite_cmd;
        //    sqlite_cmd = conn.CreateCommand();
        //    sqlite_cmd.CommandText = "SELECT * FROM HTable";

        //    sqlite_datareader = sqlite_cmd.ExecuteReader();
        //    while (sqlite_datareader.Read())
        //    {
        //        string myreader = sqlite_datareader.GetString(0);
        //        string myreader2 = sqlite_datareader.GetString(1);
        //        string myreader3 = sqlite_datareader.GetString(2);
        //    }
        //    sqlite_datareader.Close();
        //    conn.Close();
        //}

        //public void CreateUnsendTable(SQLiteConnection conn)
        //{
        //    SQLiteCommand sqlite_cmd;
        //    string Createsql = "CREATE TABLE UMTable (Col1 Text, Col2 Text)";
        //    sqlite_cmd = conn.CreateCommand();
        //    sqlite_cmd.CommandText = Createsql;
        //    sqlite_cmd.ExecuteNonQuery();

        //}

        //public void InsertUnsendData(SQLiteConnection conn, string name, string data)
        //{
        //    try
        //    {
        //        SQLiteCommand sqlite_cmd;
        //        sqlite_cmd = conn.CreateCommand();
        //        sqlite_cmd.CommandText = $"INSERT INTO UMTable (Col1, Col2) VALUES('{name}','{data}')";
        //        sqlite_cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        ////Console.WriteLine(ex.Message);
        //        ////Console.WriteLine(ex.StackTrace);
        //    }
        //}

        //public void ReadUnsendData(SQLiteConnection conn)
        //{
        //    SQLiteDataReader sqlite_datareader;
        //    SQLiteCommand sqlite_cmd;
        //    sqlite_cmd = conn.CreateCommand();
        //    sqlite_cmd.CommandText = "SELECT * FROM UMTable";

        //    sqlite_datareader = sqlite_cmd.ExecuteReader();
        //    while (sqlite_datareader.Read())
        //    {
        //        string id = sqlite_datareader.GetString(0);
        //        string message = sqlite_datareader.GetString(1);
        //        string ip = "";
        //        EasyTcpClient cl = new EasyTcpClient();

        //        foreach (var i in Form1.ClientuserIDdict)
        //        {
        //            if (i.Value == id)
        //            {
        //                ////Console.WriteLine(i.Value + " " + id);
        //                ip = i.Key;
        //                break;
        //            }
        //        }

        //        foreach (var j in Form1.Clientdict)
        //        {
        //            if (j.Key == ip)
        //            {
        //                ////Console.WriteLine(j.Key + " " + ip);
        //                cl = j.Value;
        //                break;
        //            }
        //        }

        //        if (cl != null)
        //        {
        //            if (cl.IsConnected())
        //            {
        //                cl.Send(message);
        //                ////Console.WriteLine(message);
        //                DeleteUnsendData(conn, id, message);
        //                ////Console.WriteLine(id + " : " + message);
        //            }
        //        }
        //    }
        //}

        //public void DeleteUnsendData(SQLiteConnection conn, string id, string data)
        //{
        //    SQLiteCommand sqlite_cmd;
        //    sqlite_cmd = conn.CreateCommand();
        //    ////Console.WriteLine(data);
        //    sqlite_cmd.CommandText = $"DELETE FROM UMTable WHERE Col1 = '{id}' AND Col2 = '{data}'";
        //    sqlite_cmd.ExecuteNonQuery();
        //}
    }
}

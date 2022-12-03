using SidePanel_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SidePanel_Navigation.DB
{
    public class SqliteDbClass : IDisposable
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

        ~SqliteDbClass()
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

        public void CreateComponentTitleTable(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE \"Component_Title\" (\r\n\t\"ID\"\tINTEGER,\r\n\t\"Component\"\tTEXT,\r\n\tCONSTRAINT \"component_sum_unique\" UNIQUE(\"Component\"),\r\n\tPRIMARY KEY(\"ID\")\r\n)";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            Console.WriteLine(sqlite_cmd.CommandText);
            sqlite_cmd.ExecuteNonQuery();
        }

        public void CreateComponentTable(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE \"Component\" (\r\n\t\"INDEX\"\tINTEGER,\r\n\t\"TYPE_ID\"\tINTEGER,\r\n\t\"MANUFACTURER\"\tTEXT,\r\n\t\"MODEL\"\tTEXT,\r\n\t\"VERSION\"\tTEXT,\r\n\t\"SERIAL\"\tTEXT,\r\n\t\"CTIME\"\tTEXT,\r\n\tFOREIGN KEY(\"TYPE_ID\") REFERENCES \"Component_Title\"(\"ID\"),\r\n\tCONSTRAINT \"PROPERTY_UNIQUE\" UNIQUE(\"SERIAL\",\"MANUFACTURER\",\"MODEL\"),\r\n\tPRIMARY KEY(\"INDEX\" AUTOINCREMENT)\r\n)";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            Console.WriteLine(sqlite_cmd.CommandText);
            sqlite_cmd.ExecuteNonQuery();
        }

        public void CreateComponentExtendTable(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE \"Component_Extend\" (\r\n\t\"TYPE_ID\"\tINTEGER,\r\n\t\"PROPERTY_NAME\"\tTEXT,\r\n\t\"PROPERTY_VALUE\"\tTEXT,\r\n\tCONSTRAINT \"PROPERTY_NAME_VALUE_UNIQUE\" UNIQUE(\"PROPERTY_NAME\",\"PROPERTY_VALUE\")\r\n)";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            Console.WriteLine(sqlite_cmd.CommandText);
            sqlite_cmd.ExecuteNonQuery();
        }

        public void CreateSummaryTable(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE \"Summary\" (\r\n\t\"OPERATING_SYSTEM\"\tTEXT,\r\n\t\"CPU\"\tTEXT,\r\n\t\"RAM\"\tTEXT,\r\n\t\"MOTHERBOARD\"\tTEXT,\r\n\t\"GRAPHICS\"\tTEXT,\r\n\t\"STORAGE\"\tTEXT,\r\n\t\"OPTICAL_DRIVE\"\tTEXT,\r\n\t\"AUDIO\"\tTEXT,\r\n\t\"CTIME\"\tTEXT,\r\n\tCONSTRAINT \"SUMMARY_ALL_UNIQUE\" UNIQUE(\"OPERATING_SYSTEM\",\"CPU\",\"RAM\",\"MOTHERBOARD\",\"GRAPHICS\",\"STORAGE\",\"OPTICAL_DRIVE\",\"AUDIO\")\r\n)";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            Console.WriteLine(sqlite_cmd.CommandText);
            sqlite_cmd.ExecuteNonQuery();
        }

        //public void CreateHardwareInfoTable(SQLiteConnection conn)
        //{

        //    SQLiteCommand sqlite_cmd;
        //    string Createsql = "CREATE TABLE \"HITable\" (\r\n\t\"INDEX\"\tINTEGER,\r\n\t\"CPU_MODEL\"\tText,\r\n\t\"CPU_ID\"\tText,\r\n\t\"RAM_MAN_1\"\tText,\r\n\t\"RAM_SERIAL_1\"\tText,\r\n\t\"RAM_MAN_2\"\tText,\r\n\t\"RAM_SERIAL_2\"\tText,\r\n\t\"MBOARD_MAN\"\tText,\r\n\t\"MBOARD_SERIAL\"\tText,\r\n\t\"MONITOR_MODEL\"\tText,\r\n\t\"HDMODEL1\"\tText,\r\n\t\"HDSERIAL_1\"\tText,\r\n\t\"HDMODEL2\"\tText,\r\n\t\"HDSERIAL_2\"\tText,\r\n\t\"MOUSE_VENDOR\"\tText,\r\n\t\"KEYBOARD_VENDOR\"\tText,\r\n\t\"C_TIME\"\tTEXT,\r\n\tPRIMARY KEY(\"INDEX\" AUTOINCREMENT),\r\n\tCONSTRAINT \"ALL_UNIQUE\" UNIQUE(\"CPU_MODEL\",\"CPU_ID\",\"RAM_MAN_1\",\"RAM_SERIAL_1\",\"RAM_MAN_2\",\"RAM_SERIAL_2\",\"MBOARD_MAN\",\"MBOARD_SERIAL\",\"MONITOR_MODEL\",\"HDMODEL1\",\"HDSERIAL_1\",\"HDMODEL2\",\"HDSERIAL_2\",\"MOUSE_VENDOR\",\"KEYBOARD_VENDOR\")\r\n)";
        //    sqlite_cmd = conn.CreateCommand();
        //    sqlite_cmd.CommandText = Createsql;
        //    Console.WriteLine(sqlite_cmd.CommandText);
        //    sqlite_cmd.ExecuteNonQuery();

        //}

        //public void CheckHardwareInfoData(SQLiteConnection conn, List<LocalDbModel> hardwareList)
        //{
        //    foreach (var v in hardwareList)
        //    {
        //        SQLiteCommand sqlite_cmd;
        //        sqlite_cmd = conn.CreateCommand();
        //        sqlite_cmd.CommandText = $"";
        //        sqlite_cmd.ExecuteNonQuery();
        //    }
        //}

        public void InsertHardwareInfoData(SQLiteConnection conn, List<LocalDbModel> hardwareList, int index)
        {
            try
            {
                foreach (var v in hardwareList)
                {
                    //Console.WriteLine($"{index} {v.Manufacturer} {v.Model} {v.ID}");

                    SQLiteCommand sqlite_cmd;
                    sqlite_cmd = conn.CreateCommand();
                    sqlite_cmd.CommandText = $"INSERT OR IGNORE INTO Component(TYPE_ID, MANUFACTURER, MODEL, VERSION, SERIAL, CTIME)\r\nVALUES('{index}','{v.Manufacturer}','{v.Model}', '{v.Version}','{v.ID}', '{DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")}')";
                    sqlite_cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void InsertExtendInfoData(SQLiteConnection conn, Dictionary<string, string> extenedInfo, int index)
        {
            try
            {
                foreach (var v in extenedInfo)
                {
                    //Console.WriteLine($"{index} {v.Manufacturer} {v.Model} {v.ID}");

                    SQLiteCommand sqlite_cmd;
                    sqlite_cmd = conn.CreateCommand();
                    sqlite_cmd.CommandText = $"INSERT OR IGNORE INTO Component_Extend(TYPE_ID, PROPERTY_NAME, PROPERTY_VALUE)\r\nVALUES('{index}','{v.Key}','{v.Value}')";
                    sqlite_cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        //public void InsertHardwareSummaryData(SQLiteConnection conn, List<LocalSummaryDbModel> hardwareList)
        //{
        //    try
        //    {
        //        foreach (var v in hardwareList)
        //        {
        //            //Console.WriteLine($"{index} {v.Manufacturer} {v.Model} {v.ID}");

        //            SQLiteCommand sqlite_cmd;
        //            sqlite_cmd = conn.CreateCommand();
        //            sqlite_cmd.CommandText = $"INSERT OR IGNORE INTO Summary(OPERATING_SYSTEM, CPU, RAM, MOTHERBOARD, GRAPHICS, STORAGE, OPTICAL_DRIVE, AUDIO, CTIME)\r\nVALUES('{v.OperatingSystem}','{v.CPU}','{v.RAM}','{v.Motherboard}', '{v.Graphics}', '{v.Storage}', '{v.OpticalDrive}', '{v.Audio}', '{DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")}')";
        //            sqlite_cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        Console.WriteLine(ex.StackTrace);
        //    }
        //}

        //public void ReadHardwareInfoData(SQLiteConnection conn, int typeid)
        //{
        //    try
        //    {
        //        SQLiteDataReader sqlite_datareader;
        //        SQLiteCommand sqlite_cmd;
        //        sqlite_cmd = conn.CreateCommand();
        //        sqlite_cmd.CommandText = "SELECT * FROM Component WHERE TYPE_ID = " + typeid;

        //        sqlite_datareader = sqlite_cmd.ExecuteReader();
        //        while (sqlite_datareader.Read())
        //        {
        //            string Manufacturer = sqlite_datareader.GetString(2);
        //            string Model = sqlite_datareader.GetString(3);
        //            string Id = sqlite_datareader.GetString(4);
        //            DateTime dt = DateTime.Parse(sqlite_datareader.GetString(5));

        //            //Console.WriteLine($"{Manufacturer} {Model} {Id} {dt}");
        //        }
        //        sqlite_datareader.Close();
        //        //conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        Console.WriteLine(ex.StackTrace);
        //    }
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
//using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;
using ParkingMangement.Utils;
using ParkingMangement.DAO;
using ParkingMangement.Model;
using System.IO;
using System.Xml.Serialization;

namespace ParkingMangement
{
    class Database
    {
        //protected static String _connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ParkingManagement.accdb";
        //protected static String _connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ParkingManagement.mdb;Mode=Share Deny None";

        //static OleDbConnection connection;
        static SqlConnection mySqlConnection;
        //static Config config;

        public static SqlConnection GetDBConnection()
        {
            string datasource = Util.getConfigFile().sqlDataSource + @"," + Util.getConfigFile().sqlPort;
            string database = "ParkingManagement";
            string username = Util.getConfigFile().sqlUsername;
            string password = Util.getConfigFile().sqlPassword;

            return GetDBConnection(datasource, database, username, password);
        }
        public static SqlConnection GetDBConnection(string datasource, string database, string username, string password)
        {
            // Connection String.
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Integrated Security=False;Network Library=dbmssocn;Connect Timeout=30;User Instance=False;User ID=" + username + ";Password=" + password;
            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }

        public static void OpenConnection()
        {
            mySqlConnection = GetDBConnection();

            try
            {
                if (mySqlConnection.State == ConnectionState.Closed)
                {
                    mySqlConnection.Open();
                }
            }
            catch (Exception e)
            {
                
            }

            Console.Read();
        }

        public static void CloseConnection()
        {
            // Đóng kết nối.
            if (mySqlConnection.State == ConnectionState.Open)
            {
                mySqlConnection.Close();
            }
            // Tiêu hủy đối tượng, giải phóng tài nguyên.
            mySqlConnection.Dispose();
        }

        public static int ExcuValueQuery(string sql)
        {
            try
            {
                OpenConnection();
                DataTable dt = new DataTable();
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandText = sql;
                int value = Convert.ToInt32(command.ExecuteScalar());
                CloseConnection();
                return value;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public static DataTable ExcuQuery(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandText = sql;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(dt);
                CloseConnection();
            } catch (Exception Ex)
            {
                //MessageBox.Show(Constant.sMessageCommonError);
                MessageBox.Show(Ex.Message + "_sql: " + sql);
            }
            return dt;
        }
        public static bool ExcuNonQuery(string sql)
        {
            try
            {
                int result = 0;
                OpenConnection();
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandText = sql;
                result = command.ExecuteNonQuery();
                CloseConnection();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                if (Ex.ErrorCode == -2147467259)
                {
                    //This code happens ONLY when trying to add duplicated values to the primary key in the database, 
                    // in this case just do nothing and continue loading the other no duplicated values
                    MessageBox.Show(Constant.sMessageDuplicateDataError);
                } else
                {
                    MessageBox.Show(Ex.Message + "_sql: " + sql);
                }
                return false;
            }
        }

        public static bool ExcuNonQueryNoErrorMessage(string sql)
        {
            try
            {
                OpenConnection();
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandText = sql;
                int result = command.ExecuteNonQuery();
                CloseConnection();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                return false;
            }
        }
    }
}

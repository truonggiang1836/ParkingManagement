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
        private SqlConnection mySqlConnection;
        //static Config config;

        public SqlConnection GetDBConnection()
        {
            string datasource = Util.getConfigFile().sqlDataSource + @"," + Util.getConfigFile().sqlPort;
            string database = "ParkingManagement";
            string username = Util.getConfigFile().sqlUsername;
            string password = Util.getConfigFile().sqlPassword;

            return GetDBConnection(datasource, database, username, password);
        }
        public SqlConnection GetDBConnection(string datasource, string database, string username, string password)
        {
            // Connection String.
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Integrated Security=False;Network Library=dbmssocn;Connect Timeout=30;User Instance=False;User ID=" + username + ";Password=" + password;
            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }

        public void OpenConnection()
        {
            Program.sCountConnection++;

            mySqlConnection = GetDBConnection();

            try
            {
                if (mySqlConnection.State != ConnectionState.Open)
                {
                    mySqlConnection.Open();
                }
            }
            catch (Exception e)
            {

            }

            Console.Read();
        }

        public void CloseConnection()
        {
            Program.sCountConnection--;

            // Đóng kết nối.
            if (mySqlConnection.State != ConnectionState.Closed)
            {
                mySqlConnection.Close();
            }
            // Tiêu hủy đối tượng, giải phóng tài nguyên.
            //mySqlConnection.Dispose();
        }

        public int ExcuValueQuery(string sql)
        {
            try
            {
                mySqlConnection = GetDBConnection();
                DataTable dt = new DataTable();
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandText = sql;
                mySqlConnection.Open();
                int value = Convert.ToInt32(command.ExecuteScalar());
                return value;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                if (mySqlConnection != null)
                {
                    mySqlConnection.Dispose();
                }
            }
        }

        public DataTable ExcuQuery(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                mySqlConnection = GetDBConnection();
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandText = sql;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                mySqlConnection.Open();
                adapter.Fill(dt);
            }
            catch (Exception Ex)
            {
                //MessageBox.Show(Constant.sMessageCommonError);
                MessageBox.Show(Ex.Message + "_sql: " + sql);
            }
            finally
            {
                if (mySqlConnection != null)
                {
                    mySqlConnection.Dispose();
                }
            }
            return dt;
        }

        public DataTable ExcuQueryNoErrorMessage(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                mySqlConnection = GetDBConnection();
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandText = sql;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                mySqlConnection.Open();
                adapter.Fill(dt);
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                if (mySqlConnection != null)
                {
                    mySqlConnection.Dispose();
                }
            }
            return dt;
        }

        public bool ExcuNonQuery(string sql)
        {
            try
            {
                int result = 0;
                mySqlConnection = GetDBConnection();
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandText = sql;
                mySqlConnection.Open();
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
                }
                else
                {
                    MessageBox.Show(Ex.Message + "_sql: " + sql);
                }
                return false;
            }
            finally
            {
                if (mySqlConnection != null)
                {
                    mySqlConnection.Dispose();
                }
            }
        }

        public bool ExcuNonQueryNoErrorMessage(string sql)
        {
            try
            {
                mySqlConnection = GetDBConnection();
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandText = sql;
                mySqlConnection.Open();
                int result = command.ExecuteNonQuery();
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
            finally
            {
                if (mySqlConnection != null)
                {
                    mySqlConnection.Dispose();
                }
            }
        }
    }
}

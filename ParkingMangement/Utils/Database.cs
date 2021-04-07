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

        public void GetDBConnection()
        {
            string datasource = Util.getConfigFile().sqlDataSource + @"," + Util.getConfigFile().sqlPort;
            string database = "ParkingManagement";
            string username = Util.getConfigFile().sqlUsername;
            string password = Util.getConfigFile().sqlPassword;

            GetDBConnection(datasource, database, username, password);
        }
        public void GetDBConnection(string datasource, string database, string username, string password)
        {
            // Connection String.
            string connStringPool = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Integrated Security=False;Min Pool Size=5;Max Pool Size=60;Connect Timeout=2;User Instance=False;User ID=" + username + ";Password=" + password;
            string connStringNoPool = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Integrated Security=False;Pooling=false;Connect Timeout=45;User Instance=False;User ID=" + username + ";Password=" + password;

            mySqlConnection = new SqlConnection();
            try
            {
                mySqlConnection.ConnectionString = connStringPool;
                mySqlConnection.Open();
            }
            catch (Exception)
            {

                if (mySqlConnection.State != ConnectionState.Closed)
                {
                    mySqlConnection.Close();
                }
                mySqlConnection.ConnectionString = connStringNoPool;
                mySqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            Program.sCountConnection--;

            // Đóng kết nối.
            try
            {
                mySqlConnection.Close();
            }
            catch (Exception e)
            {

            }
        }

        public int ExcuValueQuery(string sql)
        {
            try
            {
                int value = 0;
                GetDBConnection();
                DataTable dt = new DataTable();
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandTimeout = 60;
                command.CommandText = sql;
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    value = Convert.ToInt32(command.ExecuteScalar());
                }
                command.Dispose();
                return value;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                CloseConnection();
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
                GetDBConnection();
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandTimeout = 60;
                command.CommandText = sql;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    adapter.Fill(dt);
                }
                command.Dispose();
            }
            catch (Exception Ex)
            {
                //MessageBox.Show(Constant.sMessageCommonError);
                MessageBox.Show(Ex.Message + "_sql: " + sql);
            }
            finally
            {
                CloseConnection();
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
                GetDBConnection();
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandTimeout = 60;
                command.CommandText = sql;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    adapter.Fill(dt);
                }
                command.Dispose();
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                CloseConnection();
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
                GetDBConnection();
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandTimeout = 60;
                command.CommandText = sql;
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    result = command.ExecuteNonQuery();
                }
                command.Dispose();
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
                CloseConnection();
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
                int result = 0;
                GetDBConnection();
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandTimeout = 60;
                command.CommandText = sql;
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    result = command.ExecuteNonQuery();
                }
                command.Dispose();
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
                CloseConnection();
                if (mySqlConnection != null)
                {
                    mySqlConnection.Dispose();
                }
            }
        }

        static public void UpdateDB()
        {
            try
            {
                string sql = "ALTER TABLE Config ADD NoticeFeeContent nvarchar(MAX);";
                (new Database()).ExcuQueryNoErrorMessage(sql);

                sql = "ALTER TABLE Config ADD IsUseCostDeposit int NOT NULL DEFAULT(1);";
                (new Database()).ExcuQueryNoErrorMessage(sql);
            } catch (Exception)
            {

            }
        }
    }
}

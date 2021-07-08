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
        //private SqlConnection mySqlConnection;
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
                        + database + ";Integrated Security=false;Connection Timeout=10;User Instance=False;User ID=" + username + ";Password=" + password;

            return new SqlConnection(connString);
        }

        public void OpenConnection()
        {
            Program.sCountConnection++;

            SqlConnection mySqlConnection = GetDBConnection();

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

        public int ExcuValueQuery(string sql)
        {
            SqlConnection mySqlConnection = GetDBConnection();
            try
            {       
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
                    mySqlConnection.Close();
                    mySqlConnection.Dispose();
                }
            }
        }

        public DataTable ExcuQuery(string sql)
        {
            DataTable dt = new DataTable();
            SqlConnection mySqlConnection = GetDBConnection();
            try
            {
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandText = sql;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                mySqlConnection.Open();
                adapter.Fill(dt);
            }
            catch (SqlException Ex)
            {
                if (Ex.Number == 1205)
                {
                    // Deadlock 
                }
                else
                {
                    MessageBox.Show(Ex.Message + "_sql: " + sql);
                }
            }
            finally
            {
                if (mySqlConnection != null)
                {
                    mySqlConnection.Close();
                    mySqlConnection.Dispose();
                }
            }
            return dt;
        }

        public DataTable ExcuQueryWithTimeOut(string sql)
        {
            DataTable dt = new DataTable();
            SqlConnection mySqlConnection = GetDBConnection();
            try
            {
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandText = sql;
                command.CommandTimeout = 3;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                mySqlConnection.Open();
                adapter.Fill(dt);
            }
            catch (SqlException Ex)
            {
                if (Ex.Number == 1205)
                {
                    // Deadlock 
                }
                else if (Ex.Number == -2)
                {
                    // Time out
                    return null;
                }
                else
                {
                    MessageBox.Show(Ex.Message + "_sql: " + sql);
                }
            }
            finally
            {
                if (mySqlConnection != null)
                {
                    mySqlConnection.Close();
                    mySqlConnection.Dispose();
                }
            }
            return dt;
        }

        public DataTable ExcuQueryNoErrorMessage(string sql)
        {
            DataTable dt = new DataTable();
            SqlConnection mySqlConnection = GetDBConnection();
            try
            {
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
                    mySqlConnection.Close();
                    mySqlConnection.Dispose();
                }
            }
            return dt;
        }

        public bool ExcuNonQuery(string sql)
        {
            SqlConnection mySqlConnection = GetDBConnection();
            try
            {
                int result = 0;
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandText = sql;
                mySqlConnection.Open();
                result = command.ExecuteNonQuery();
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
                } else if (Ex.Number == 1205)
                {
                    // Deadlock 
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
                    mySqlConnection.Close();
                    mySqlConnection.Dispose();
                }
            }
        }

        public bool ExcuNonQueryWithTimeOut(string sql)
        {
            SqlConnection mySqlConnection = GetDBConnection();
            try
            {
                int result = 0;
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandText = sql;
                command.CommandTimeout = 3;  // seconds
                mySqlConnection.Open();
                result = command.ExecuteNonQuery();
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
                else if (Ex.Number == 1205)
                {
                    // Deadlock 
                }
                else if (Ex.Number == -2)
                {
                    // Time out
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
                    mySqlConnection.Close();
                    mySqlConnection.Dispose();
                }
            }
        }

        public bool ExcuNonQueryNoErrorMessage(string sql)
        {
            SqlConnection mySqlConnection = GetDBConnection();
            try
            {
                SqlCommand command = mySqlConnection.CreateCommand();
                command.Connection = mySqlConnection;
                command.CommandText = sql;
                mySqlConnection.Open();
                int result = command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException Ex)
            {
                return false;
            }
            finally
            {
                if (mySqlConnection != null)
                {
                    mySqlConnection.Close();
                    mySqlConnection.Dispose();
                }
            }
        }

        public void UpdateDB()
        {
            try
            {
                string sql = "ALTER TABLE Config ADD NoticeFeeContent nvarchar(MAX);";
                (new Database()).ExcuQueryNoErrorMessage(sql);

                sql = "ALTER TABLE Config ADD IsUseCostDeposit int NOT NULL DEFAULT(1);";
                (new Database()).ExcuQueryNoErrorMessage(sql);

                sql = "ALTER TABLE Config ADD StartHourNightShift int NOT NULL DEFAULT(19),"
                    + "EndHourNightShift int NOT NULL DEFAULT(7);";
                (new Database()).ExcuQueryNoErrorMessage(sql);

                sql = "CREATE TABLE Revenue (RevenueId nvarchar(50) NOT NULL, StartDateTimeString nvarchar(50) NOT NULL,"
                    + " UserId nvarchar(50) NOT NULL, JsonBody nvarchar(MAX), IsSync int NOT NULL DEFAULT(0)," 
                    + "CONSTRAINT PK_Revenue PRIMARY KEY (StartDateTimeString, UserId));";
                (new Database()).ExcuQueryNoErrorMessage(sql);

                sql = "ALTER TABLE Config ADD NoticeToBeExpireDate int NOT NULL DEFAULT(20);";
                (new Database()).ExcuQueryNoErrorMessage(sql);

                sql = "ALTER TABLE Config ADD IsUpdateLostAvailable int NOT NULL DEFAULT(1);";
                (new Database()).ExcuQueryNoErrorMessage(sql);
            }
            catch (Exception)
            {

            }
        }

        public void backupDB()
        {
            try
            {
                string fileName = "ParkingManagement" + DateTime.Now.ToString("_yyyy.MM.dd_HH.mm") + ".bak";
                string runningPath = Util.getFolderPath("BACKUP_PARKING_DB");
                Util.CreateFolderIfMissing(runningPath);
                backupDB(runningPath, fileName);

                string localFilePath = runningPath + fileName;
                string systemPath = "C:\\BACKUP_PARKING_DB\\";
                string systemFilePath = systemPath + fileName;

                Util.CreateFolderIfMissing(systemPath);
                if (Directory.Exists(systemPath))
                {
                    Util.deleteAllFileOnDirectory(systemPath);
                    File.Copy(localFilePath, systemFilePath, true);
                }

                if (Util.getConfigFile().backupComputerName.Length > 0)
                {
                    string sharedFolderPath = @"\\" + Util.getConfigFile().backupComputerName + @"\BACKUP_PARKING_DB" + @"\";
                    string sharedFilePath = sharedFolderPath + fileName;              

                    if (Directory.Exists(sharedFolderPath))
                    {
                        Util.deleteAllFileOnDirectory(sharedFolderPath);
                        File.Copy(localFilePath, sharedFilePath, true);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        public void backupDB(string folderPath, string fileName)
        {           
            DirectoryInfo di = new DirectoryInfo(folderPath);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            string filePath = folderPath + fileName;
            string sql = "BACKUP DATABASE ParkingManagement TO DISK = '" + filePath + "'";
            (new Database()).ExcuQueryNoErrorMessage(sql);
        }
    }
}
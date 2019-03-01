﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;
using ParkingMangement.Utils;
using ParkingMangement.DAO;
using ParkingMangement.Model;
using System.IO;
using System.Xml.Serialization;
using MySql.Data.MySqlClient;

namespace ParkingMangement
{
    class Database
    {
        //protected static String _connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ParkingManagement.accdb";
        protected static String _connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ParkingManagement.mdb;Mode=Share Deny None";

        //static OleDbConnection connection;
        static MySqlConnection mySqlConnection;
        //static Config config;

        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "movedb";
            string username = "root";
            string password = "root";

            return GetDBConnection(host, port, database, username, password);
        }
        public static MySqlConnection GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }

        public static void OpenConnection()
        {
            Console.WriteLine("Getting Connection ...");
            if (mySqlConnection == null)
            {
                mySqlConnection = GetDBConnection();
            }

            try
            {
                Console.WriteLine("Openning Connection ...");

                mySqlConnection.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();
        }

        public static void CloseConnection()
        {
            // Đóng kết nối.
            mySqlConnection.Close();
            // Tiêu hủy đối tượng, giải phóng tài nguyên.
            mySqlConnection.Dispose();
        }

        public static int ExcuValueQuery(string sql)
        {
            try
            {
                OpenConnection();
                DataTable dt = new DataTable();
                MySqlCommand command = mySqlConnection.CreateCommand();
                command.CommandText = sql;
                return Convert.ToInt32(command.ExecuteScalar());
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
                MySqlCommand command = mySqlConnection.CreateCommand();
                command.CommandText = sql;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(dt);
                CloseConnection();
            } catch (Exception e)
            {
                //MessageBox.Show(Constant.sMessageCommonError);
                MessageBox.Show(e.Message);
            }
            return dt;
        }
        public static bool ExcuNonQuery(string sql)
        {
            try
            {
                int result = 0;
                OpenConnection();
                MySqlCommand command = mySqlConnection.CreateCommand();
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
            catch (OleDbException Ex)
            {
                if (Ex.ErrorCode == -2147467259)
                {
                    //This code happens ONLY when trying to add duplicated values to the primary key in the database, 
                    // in this case just do nothing and continue loading the other no duplicated values
                    MessageBox.Show(Constant.sMessageDuplicateDataError);
                } else
                {
                    MessageBox.Show(Constant.sMessageCommonError);
                }
                return false;
            }
        }

        public static bool ExcuNonQueryNoErrorMessage(string sql)
        {
            try
            {
                OpenConnection();
                MySqlCommand command = mySqlConnection.CreateCommand();
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
            catch (OleDbException Ex)
            {
                return false;
            }
        }
    }
}

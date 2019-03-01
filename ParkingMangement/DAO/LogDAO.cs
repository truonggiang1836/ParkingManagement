using ParkingMangement.DTO;
using ParkingMangement.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DAO
{
    class LogDAO
    {
        private static string sqlGetAllData = "select Log.Identify, LogType.LogTypeName, Log.ProcessDate, UserCar.NameUser, Log.LogNote, Log.Computer from Log, LogType, UserCar where Log.LogTypeID = LogType.LogTypeID and Log.Account = UserCar.Account";
        private static string sqlOrderByIdentify = " order by Log.Identify asc";
        public static DataTable GetAllData()
        {
            string sql = sqlGetAllData;
            sql += sqlOrderByIdentify;
            return Database.ExcuQuery(sql);
        }

        public static void Insert(LogDTO logDTO)
        {
            string sql = "insert into Log(LogTypeID, LogNote, Account, ProcessDate, Computer) values (" + logDTO.LogTypeID + ", '" + logDTO.Note + "', '" + logDTO.Account + "', '" + logDTO.ProcessDate + "', '" + logDTO.Computer + "')";
            Database.ExcuNonQuery(sql);
        }

        public static DataTable SearchData(string key, string logTypeID, DateTime startTime, DateTime endTime)
        {
            string sql = sqlGetAllData;
            if (!string.IsNullOrEmpty(key))
            {
                sql += " and UserCar.NameUser like '%" + key + "%' or Log.LogNote like '%" + key + "%'";
            }
            if (!string.IsNullOrEmpty(logTypeID))
            {
                sql += " and Log.LogTypeID like '" + logTypeID + "'";
            }
            sql += " and Log.ProcessDate >= #" + startTime.ToString(Constant.sDateTimeFormatForQuery) + "# and Log.ProcessDate <= #" + endTime.ToString(Constant.sDateTimeFormatForQuery) + "#";
            sql += sqlOrderByIdentify;
            return Database.ExcuQuery(sql);
        }
    }
}

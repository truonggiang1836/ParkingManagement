using Newtonsoft.Json.Linq;
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
    class RevenueDAO
    {
        public static DataTable GetAllDataIsNotSync()
        {
            string sql = "select * from Revenue where IsSync = 0";
            return (new Database()).ExcuQuery(sql);
        }

        public static string GetRevenueId(string startDateTimeString, string userId)
        {
            string sql = "select RevenueId from Revenue where StartDateTimeString = '" + startDateTimeString + "' and UserId = '" + userId + "'";
            DataTable dt = (new Database()).ExcuQueryNoErrorMessage(sql);
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<string>("RevenueId");
            }
            else
            {
                return null;
            }
        }

        public static void UpdateIsSync(string revenueId)
        {
            string sql = "update Revenue set IsSync = 1 where RevenueId = '" + revenueId + "'";
            (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static string getInsertSql(RevenueDTO revenueDTO)
        {
            string sql = "insert into Revenue(RevenueId, StartDateTimeString, UserId, JsonBody, IsSync) values ('" + revenueDTO.RevenueId 
                + "', '" + revenueDTO.StartDateTimeString + "', '" + revenueDTO.UserId + "', '" + revenueDTO.JsonBody + "', " + revenueDTO.IsSync + ")";
            return sql;
        }

        public static string getUpdateSql(RevenueDTO revenueDTO)
        {
            string sql = "update Revenue set JsonBody = '" + revenueDTO.JsonBody + "', IsSync = '" + revenueDTO.IsSync + "' where StartDateTimeString = '" 
                + revenueDTO.StartDateTimeString + "' and UserId = '" + revenueDTO.UserId + "'";
            return sql;
        }

        public static bool InsertNoErrorMessage(RevenueDTO revenueDTO)
        {
            string sql = getInsertSql(revenueDTO);
            return (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static bool UpdateNoErrorMessage(RevenueDTO revenueDTO)
        {
            string sql = getUpdateSql(revenueDTO);
            return (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static void InsertOrUpdate(RevenueDTO revenueDTO)
        {
            if (!InsertNoErrorMessage(revenueDTO))
            {
                UpdateNoErrorMessage(revenueDTO);
            }
        }
    }
}

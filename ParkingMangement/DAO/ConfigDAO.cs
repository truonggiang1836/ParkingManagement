using ParkingMangement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DAO
{
    class ConfigDAO
    {

        public static DataTable GetConfig()
        {
            string sql = "select * from [Config]";
            return Database.ExcuQuery(sql);
        }

        public static int GetTotalSpace()
        {
            DataTable dt = GetConfig();
            if (dt != null)
            {
                return dt.Rows[0].Field<int>("TotalSpace");
            }
            else
            {
                return -1;
            }
        }

        public static int GetTicketMonthSpace()
        {
            DataTable dt = GetConfig();
            if (dt != null)
            {
                return dt.Rows[0].Field<int>("TicketSpace");
            }
            else
            {
                return -1;
            }
        }

        public static int GetTicketMonthLimit()
        {
            DataTable dt = GetConfig();
            if (dt != null)
            {
                return dt.Rows[0].Field<int>("TicketLimitDay");
            }
            else
            {
                return -1;
            }
        }

        public static int GetNightLimit()
        {
            DataTable dt = GetConfig();
            if (dt != null)
            {
                return dt.Rows[0].Field<int>("NightLimit");
            }
            else
            {
                return -1;
            }
        }

        public static void Update(ConfigDTO configDTO)
        {
            string sql = "update [Config] set TotalSpace =" + configDTO.TotalSpace + ", TicketSpace =" + configDTO.TicketSpace
                + ", TicketLimitDay =" + configDTO.TicketLimitDay + ", NightLimit =" + configDTO.NightLimit;
            Database.ExcuNonQuery(sql);
        }
    }
}

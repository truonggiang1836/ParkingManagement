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
            string sql = "select * from Config";
            return Database.ExcuQuery(sql);
        }

        public static int GetLostCard()
        {
            DataTable dt = GetConfig();
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("LostCard");
            }
            else
            {
                return -1;
            }
        }

        public static int GetBikeSpace()
        {
            DataTable dt = GetConfig();
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("BikeSpace");
            }
            else
            {
                return -1;
            }
        }

        public static int GetCarSpace()
        {
            DataTable dt = GetConfig();
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("CarSpace");
            }
            else
            {
                return -1;
            }
        }

        public static int GetTicketMonthLimit()
        {
            DataTable dt = GetConfig();
            if (dt != null & dt.Rows.Count > 0)
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
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("NightLimit");
            }
            else
            {
                return -1;
            }
        }

        public static int GetParkingTypeID()
        {
            DataTable dt = GetConfig();
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("ParkingTypeID");
            }
            else
            {
                return -1;
            }
        }

        public static int GetExpiredTicketMonthTypeID()
        {
            DataTable dt = GetConfig();
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("ExpiredTicketMonthTypeID");
            }
            else
            {
                return -1;
            }
        }

        public static string GetParkingName()
        {
            DataTable dt = GetConfig();
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<string>("ParkingName");
            }
            else
            {
                return "";
            }
        }

        public static bool UpdateCauHinhHienThi(ConfigDTO configDTO)
        {
            string sql = "update Config set LostCard =" + configDTO.LostCard + ", BikeSpace =" + configDTO.BikeSpace + ", CarSpace =" + configDTO.CarSpace
                + ", TicketLimitDay =" + configDTO.TicketLimitDay + ", NightLimit =" + configDTO.NightLimit + ", ParkingTypeID =" + configDTO.ParkingTypeId
                + ", ExpiredTicketMonthTypeID =" + configDTO.ExpiredTicketMonthTypeID + ", ParkingName = '" + configDTO.ParkingName + "'";
            return Database.ExcuNonQuery(sql);
        }

        public static bool UpdateCauHinhKetNoi(ConfigDTO configDTO)
        {
            string sql = "update Config set Camera1 = '" + configDTO.Camera1 + "', Camera2 = '" + configDTO.Camera2 +
                "', Camera3 = '" + configDTO.Camera3 + "', Camera4 = '" + configDTO.Camera4 + "', RFID1 = '" + configDTO.Rfid1 +
                "', RFID2 = '" + configDTO.Rfid2 + "'";
            return Database.ExcuNonQuery(sql);
        }
    }
}

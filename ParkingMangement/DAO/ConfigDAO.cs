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
            return (new Database()).ExcuQuery(sql);
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

        public static int GetLockCardDate()
        {
            DataTable dt = GetConfig();
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("LockCardDate");
            }
            else
            {
                return -1;
            }
        }

        public static int GetNoticeExpiredDate()
        {
            DataTable dt = GetConfig();
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("NoticeExpiredDate");
            }
            else
            {
                return -1;
            }
        }

        public static int GetIsAutoLockCard()
        {
            DataTable dt = GetConfig();
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("IsAutoLockCard");
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

        public static int GetCalculationTicketMonth()
        {
            DataTable dt = GetConfig();
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("CalculationTicketMonth");
            }
            else
            {
                return -1;
            }
        }

        public static bool UpdateCauHinhHienThi(ConfigDTO configDTO)
        {
            string sql = "update Config set LostCard =" + configDTO.LostCard + ", BikeSpace =" + configDTO.BikeSpace + ", CarSpace =" + configDTO.CarSpace
                + ", TicketLimitDay =" + configDTO.TicketLimitDay + ", NightLimit =" + configDTO.NightLimit + ", ParkingTypeID =" + configDTO.ParkingTypeId
                + ", ExpiredTicketMonthTypeID =" + configDTO.ExpiredTicketMonthTypeID + ", ParkingName = '" + configDTO.ParkingName + "', CalculationTicketMonth = " + configDTO.CalculationTicketMonth
                + ", IsAutoLockCard = " + configDTO.IsAutoLockCard + ", LockCardDate = " + configDTO.LockCardDate + ", NoticeExpiredDate = " + configDTO.NoticeExpiredDate;
            return (new Database()).ExcuNonQuery(sql);
        }
    }
}

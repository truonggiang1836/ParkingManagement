using Newtonsoft.Json.Linq;
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

        public static int GetLostCard(DataTable dt)
        {
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("LostCard");
            }
            else
            {
                return 0;
            }
        }

        public static int GetBikeSpace(DataTable dt)
        {
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("BikeSpace");
            }
            else
            {
                return -1;
            }
        }

        public static int GetCarSpace(DataTable dt)
        {
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("CarSpace");
            }
            else
            {
                return -1;
            }
        }

        public static int GetTicketMonthLimit(DataTable dt)
        {
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("TicketLimitDay");
            }
            else
            {
                return -1;
            }
        }

        public static int GetNightLimit(DataTable dt)
        {
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("NightLimit");
            }
            else
            {
                return -1;
            }
        }

        public static int GetParkingTypeID(DataTable dt)
        {
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("ParkingTypeID");
            }
            else
            {
                return -1;
            }
        }

        public static int GetExpiredTicketMonthTypeID(DataTable dt)
        {
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("ExpiredTicketMonthTypeID");
            }
            else
            {
                return -1;
            }
        }

        public static int GetLockCardDate(DataTable dt)
        {
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("LockCardDate");
            }
            else
            {
                return -1;
            }
        }

        public static int GetNoticeExpiredDate(DataTable dt)
        {
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("NoticeExpiredDate");
            }
            else
            {
                return -1;
            }
        }

        public static int GetNoticeToBeExpireDate(DataTable dt)
        {
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("NoticeToBeExpireDate");
            }
            else
            {
                return -1;
            }
        }  
        public static int GetIsUpdateLostAvailable(DataTable dt)
        {
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("IsUpdateLostAvailable");
            }
            else
            {
                return -1;
            }
        }

        public static int GetIsAutoLockCard(DataTable dt)
        {
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("IsAutoLockCard");
            }
            else
            {
                return -1;
            }
        }

        public static int GetIsUseCostDeposit(DataTable dt)
        {
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("IsUseCostDeposit");
            }
            else
            {
                return -1;
            }
        }

        public static string GetParkingName(DataTable dt)
        {
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<string>("ParkingName");
            }
            else
            {
                return "";
            }
        }

        public static string GetNoticeFeeContent(DataTable dt)
        {
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<string>("NoticeFeeContent");
            }
            else
            {
                return "";
            }
        }

        public static int GetCalculationTicketMonth(DataTable dt)
        {
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("CalculationTicketMonth");
            }
            else
            {
                return -1;
            }
        }

        public static int GetStartHourNightShift(DataTable dt)
        {
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("StartHourNightShift");
            }
            else
            {
                return 0;
            }
        }

        public static int GetEndHourNightShift(DataTable dt)
        {
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("EndHourNightShift");
            }
            else
            {
                return 0;
            }
        }

        public static string getUpdateSql(ConfigDTO configDTO)
        {
            string sql = "update Config set LostCard =" + configDTO.LostCard + ", BikeSpace =" + configDTO.BikeSpace + ", CarSpace =" + configDTO.CarSpace
                + ", TicketLimitDay =" + configDTO.TicketLimitDay + ", NightLimit =" + configDTO.NightLimit + ", ParkingTypeID =" + configDTO.ParkingTypeId
                + ", ExpiredTicketMonthTypeID =" + configDTO.ExpiredTicketMonthTypeID + ", ParkingName = '" + configDTO.ParkingName + "', CalculationTicketMonth = " + configDTO.CalculationTicketMonth
                + ", IsAutoLockCard = " + configDTO.IsAutoLockCard + ", IsUseCostDeposit = " + configDTO.IsUseCostDeposit + ", LockCardDate = " + configDTO.LockCardDate + ", NoticeExpiredDate = " + configDTO.NoticeExpiredDate
                + ", NoticeToBeExpireDate = " + configDTO.NoticeToBeExpireDate + ", NoticeFeeContent = N'" + configDTO.NoticeFeeContent + "'";
            return sql;
        }

        public static bool UpdateCauHinhHienThi(ConfigDTO configDTO)
        {
            string sql = getUpdateSql(configDTO);
            return (new Database()).ExcuNonQuery(sql);
        }

        public static bool UpdateXeTon(ConfigDTO configDTO)
        {
            string sql = "update Config set BikeSpace =" + configDTO.BikeSpace + ", CarSpace =" + configDTO.CarSpace;
            return (new Database()).ExcuNonQuery(sql);
        }

        public static bool UpdateNoticeFeeContent(string noticeFeeContent)
        {
            string sql = "update Config set NoticeFeeContent =" + noticeFeeContent;
            return (new Database()).ExcuNonQuery(sql);
        }

        public static bool UpdateIsUpdateLostAvailable(int isUpdateLostAvailable)
        {
            string sql = "update Config set IsUpdateLostAvailable = " + isUpdateLostAvailable;
            return (new Database()).ExcuNonQuery(sql);
        }

        public static bool UpdateNoErrorMessage(ConfigDTO configDTO)
        {
            string sql = getUpdateSql(configDTO);
            return (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static void syncFromJson(string json)
        {
            JArray jArray = JArray.Parse(json);
            foreach (JObject jObject in jArray)
            {
                ConfigDTO configDTO = new ConfigDTO();
                configDTO.LostCard = (int)jObject.SelectToken("lostCard");
                configDTO.BikeSpace = (int)jObject.SelectToken("bikeSpace");
                configDTO.CarSpace = (int)jObject.SelectToken("carSpace");
                configDTO.TicketLimitDay = (int)jObject.SelectToken("ticketLimitDay");
                configDTO.NightLimit = (int)jObject.SelectToken("nightLimit");
                configDTO.ParkingTypeId = (int)jObject.SelectToken("parkingTypeId");
                configDTO.ExpiredTicketMonthTypeID = (int)jObject.SelectToken("expiredTicketMonthTypeID");
                configDTO.ParkingName = (string)jObject.SelectToken("parkingName");
                configDTO.CalculationTicketMonth = (int)jObject.SelectToken("calculationTicketMonth");
                configDTO.IsAutoLockCard = (int)jObject.SelectToken("isAutoLockCard");
                configDTO.LockCardDate = (int)jObject.SelectToken("lockCardDate");

                UpdateNoErrorMessage(configDTO);
            }
        }
    }
}

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

        public static int GetLostCard()
        {
            DataTable dt = GetConfig();
            if (dt != null)
            {
                return dt.Rows[0].Field<int>("LostCard");
            }
            else
            {
                return -1;
            }
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

        public static int GetParkingTypeID()
        {
            DataTable dt = GetConfig();
            if (dt != null)
            {
                return dt.Rows[0].Field<int>("ParkingTypeID");
            }
            else
            {
                return -1;
            }
        }

        public static string GetCamera1()
        {
            DataTable dt = GetConfig();
            if (dt != null)
            {
                return dt.Rows[0].Field<string>("Camera1");
            }
            else
            {
                return "";
            }
        }

        public static string GetCamera2()
        {
            DataTable dt = GetConfig();
            if (dt != null)
            {
                return dt.Rows[0].Field<string>("Camera2");
            }
            else
            {
                return "";
            }
        }

        public static string GetCamera3()
        {
            DataTable dt = GetConfig();
            if (dt != null)
            {
                return dt.Rows[0].Field<string>("Camera3");
            }
            else
            {
                return "";
            }
        }

        public static string GetCamera4()
        {
            DataTable dt = GetConfig();
            if (dt != null)
            {
                return dt.Rows[0].Field<string>("Camera4");
            }
            else
            {
                return "";
            }
        }

        public static string GetRFID1()
        {
            DataTable dt = GetConfig();
            if (dt != null)
            {
                return dt.Rows[0].Field<string>("RFID1");
            }
            else
            {
                return "";
            }
        }

        public static string GetRFID2()
        {
            DataTable dt = GetConfig();
            if (dt != null)
            {
                return dt.Rows[0].Field<string>("RFID2");
            }
            else
            {
                return "";
            }
        }

        public static int GetInOutType()
        {
            DataTable dt = GetConfig();
            if (dt != null)
            {
                return dt.Rows[0].Field<int>("InOutType");
            }
            else
            {
                return -1;
            }
        }

        public static bool UpdateCauHinhHienThi(ConfigDTO configDTO)
        {
            string sql = "update [Config] set LostCard =" + configDTO.LostCard + ", TotalSpace =" + configDTO.TotalSpace + ", TicketSpace =" + configDTO.TicketSpace
                + ", TicketLimitDay =" + configDTO.TicketLimitDay + ", NightLimit =" + configDTO.NightLimit + ", ParkingTypeID =" 
                + configDTO.ParkingTypeId;
            return Database.ExcuNonQuery(sql);
        }

        public static bool UpdateCauHinhKetNoi(ConfigDTO configDTO)
        {
            string sql = "update [Config] set Camera1 = '" + configDTO.Camera1 + "', Camera2 = '" + configDTO.Camera2 +
                "', Camera3 = '" + configDTO.Camera3 + "', Camera4 = '" + configDTO.Camera4 + "', RFID1 = '" + configDTO.Rfid1 + "', RFID2 = '" + configDTO.Rfid2 + "'";
            return Database.ExcuNonQuery(sql);
        }

        public static bool SetInOutType(int inOutType)
        {
            string sql = "update [Config] set InOutType = " + inOutType;
            return Database.ExcuNonQuery(sql);
        }
    }
}

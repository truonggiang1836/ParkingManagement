using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DAO
{
    class SexDAO
    {
        static public DataTable GetAllData()
        {
            string sql = "select * from [Sex]";
            return Database.ExcuQuery(sql);
        }

        public static DataTable GetSexByID(int sexID)
        {
            string sql = "select * from [Sex] where SexID = " + sexID;
            return Database.ExcuQuery(sql);
        }

        public static string GetSexNameByID(int sexID)
        {
            DataTable dt = GetSexByID(sexID);
            if (dt != null)
            {
                return dt.Rows[0].Field<string>("SexName");
            }
            else
            {
                return "";
            }
        }
    }
}

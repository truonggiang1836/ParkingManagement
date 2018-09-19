using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DAO
{
    class FunctionalDAO
    {
        static public DataTable GetAllData()
        {
            string sql = "select * from [Functional]";
            return Database.ExcuQuery(sql);
        }

        static public DataTable GetAllDataWithoutAdmin()
        {
            string sql = "select * from [Functional] where FunctionID <> 'Ad'";
            return Database.ExcuQuery(sql);
        }

        public static bool UpdateFunctionSec(string functionSec, string functionID)
        {
            string sql = "update [Functional] set FunctionSec ='" + functionSec + "' where FunctionID ='" + functionID + "'";
            return Database.ExcuNonQuery(sql);
        }

        public static DataTable GetFunctionByID(string functionID)
        {
            string sql = "select * from [Functional] where FunctionID = '" + functionID + "'";
            return Database.ExcuQuery(sql);
        }

        public static string GetFunctionSecByID(string functionID)
        {
            DataTable dt = GetFunctionByID(functionID);
            if (dt != null)
            {
                return dt.Rows[0].Field<string>("FunctionSec");
            }
            else
            {
                return "";
            }
        }
    }
}

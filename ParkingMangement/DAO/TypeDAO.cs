using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DAO
{
    class TypeDAO
    {
        public static DataTable GetAllData()
        {
            string sql = "select * from [Type]";
            return Database.ExcuQuery(sql);
        }

        public static string GetTypeNameByTypeID(string typeID)
        {
            string sql = "select * from [Type] where TypeID = '" + typeID + "'";
            DataTable data = Database.ExcuQuery(sql);
            if (data != null)
            {
                return data.Rows[0].Field<string>("TypeName");
            }
            return "";
        }
    }
}

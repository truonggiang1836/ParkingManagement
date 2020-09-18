using ParkingMangement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DAO
{
    class WaitSyncCarInDAO
    {
        public static DataTable GetAllData()
        {
            string sql = "select * from WaitSyncCarIn";
            DataTable data = Database.ExcuQuery(sql);
            return data;
        }

        public static void Insert(int carIdentify)
        {
            string sql = "insert into WaitSyncCarIn(Identify) values (" + carIdentify + ")";
            Database.ExcuNonQueryNoErrorMessage(sql);
        }

        public static void DeleteAll()
        {
            string sql = "delete from WaitSyncCarIn";
            Database.ExcuNonQuery(sql);
        }

        public static void DeleteWhereListId(string id)
        {
            string sql = "delete from WaitSyncCarIn where Identify in " + id;
            Database.ExcuNonQuery(sql);
        }

        public static bool UpdateMessage(long identify, string message)
        {
            string sql = "update WaitSyncCarIn set Message ='" + message + "' where Identify =" + identify;
            return Database.ExcuNonQueryNoErrorMessage(sql);
        }
    }
}

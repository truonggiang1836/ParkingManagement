using ParkingMangement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DAO
{
    class WaitSyncCarOutDAO
    {
        public static DataTable GetAllData()
        {
            string sql = "select * from WaitSyncCarOut";
            DataTable data = Database.ExcuQuery(sql);
            return data;
        }

        public static void Insert(int carIdentify)
        {
            string sql = "insert into WaitSyncCarOut(Identify) values (" + carIdentify + ")";
            Database.ExcuNonQueryNoErrorMessage(sql);
        }

        public static void DeleteAll()
        {
            string sql = "delete from WaitSyncCarOut";
            Database.ExcuNonQuery(sql);
        }

        public static void DeleteWhereListId(string id)
        {
            string sql = "delete from WaitSyncCarOut where Identify in " + id;
            Database.ExcuNonQuery(sql);
        }

        public static bool UpdateMessage(long identify, string message)
        {
            string sql = "update WaitSyncCarOut set Message ='" + message + "' where Identify =" + identify;
            return Database.ExcuNonQueryNoErrorMessage(sql);
        }
    }
}

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
            DataTable data = (new Database()).ExcuQuery(sql);
            return data;
        }

        public static void Insert(int carIdentify)
        {
            string sql = "insert into WaitSyncCarIn(Identify) values (" + carIdentify + ")";
            (new Database()).ExcuNonQuery(sql);
        }

        public static void DeleteAll()
        {
            string sql = "delete from WaitSyncCarIn";
            (new Database()).ExcuNonQuery(sql);
        }

        public static void DeleteWhereListId(string id)
        {
            string sql = "delete from WaitSyncCarIn where Identify in " + id;
            (new Database()).ExcuNonQuery(sql);
        }
    }
}

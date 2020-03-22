using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DAO
{
    class BlackCarDAO
    {
        public static DataTable GetAllData()
        {
            string sql = "select * from BlackCar order by Identify asc";
            return (new Database()).ExcuQuery(sql);
        }

        public static void Insert(string blackCarDigit)
        {
            string sql = "insert into BlackCar(Digit) values ('" + blackCarDigit + "')";
            (new Database()).ExcuNonQuery(sql);
        }

        public static void Delete(int identify)
        {
            string sql = "delete from BlackCar where Identify =" + identify;
            (new Database()).ExcuNonQuery(sql);
        }
    }
}

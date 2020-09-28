using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DAO
{
    class LogTypeDAO
    {
        public static DataTable GetAllData()
        {
            string sql = "select * from LogType";
            return (new Database()).ExcuQuery(sql);
        }

        public static DataTable GetTicketLog()
        {
            string sql = "select * from LogType where IsTicketLog = '1'";
            return (new Database()).ExcuQuery(sql);
        }
    }
}

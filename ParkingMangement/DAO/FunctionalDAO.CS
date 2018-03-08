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
    }
}

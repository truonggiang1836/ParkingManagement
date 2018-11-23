using ParkingMangement.DTO;
using ParkingMangement.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DAO
{
    class WorkDAO
    {
        public static DataTable GetAllData()
        {
            string sql = "select WorkAssign.Identify, UserCar.NameUser, WorkAssign.TimeStart, WorkAssign.TimeEnd, WorkAssign.Computer from [UserCar], [WorkAssign] " +
                "where UserCar.UserID = WorkAssign.UserID order by WorkAssign.Identify asc";
            DataTable data = Database.ExcuQuery(sql);
            setTotalTime(data);
            return data;
        }

        public static DataTable GetDataByMultiDate(DateTime startDate, DateTime endDate)
        {
            //string sql = "select WorkAssign.Identify, UserCar.NameUser, WorkAssign.TimeStart, WorkAssign.TimeEnd, WorkAssign.Computer from [UserCar], [WorkAssign] " +
            //    "where UserCar.UserID = WorkAssign.UserID and TimeStart >= #" + startDate + "# and TimeEnd <= #" + endDate + "#";
            string sql = "select WorkAssign.Identify, UserCar.NameUser, WorkAssign.TimeStart, WorkAssign.TimeEnd, WorkAssign.Computer from [UserCar], [WorkAssign] " +
                "where UserCar.UserID = WorkAssign.UserID and TimeStart Between #" + startDate.ToString(Constant.sDateTimeFormatForQuery) + "# and TimeEnd and TimeEnd Between TimeStart and #" + endDate.ToString(Constant.sDateTimeFormatForQuery) + "#";
            DataTable data = Database.ExcuQuery(sql);
            setTotalTime(data);
            return data;
        }

        private static void setTotalTime(DataTable data)
        {
            data.Columns.Add("TotalTime", typeof(System.Double)).SetOrdinal(5);
            for (int row = 0; row < data.Rows.Count; row++)
            {
                DateTime timeStart = data.Rows[row].Field<DateTime>("TimeStart");
                DateTime timeEnd = data.Rows[row].Field<DateTime>("TimeEnd");
                TimeSpan duration = timeEnd - timeStart;
                double totalHours = Math.Round(duration.TotalHours, 2);
                data.Rows[row].SetField("TotalTime", totalHours);
            }
        }

        public static void Insert(WorkDTO workDTO)
        {
            string sql = "insert into WorkAssign(UserID, TimeStart, TimeEnd, Computer) values ('" + workDTO.UserID + "', '" + workDTO.TimeStart + "', '" +
                workDTO.TimeEnd + "', '" + workDTO.Computer + "')";
            Database.ExcuNonQuery(sql);
        }
    }
}

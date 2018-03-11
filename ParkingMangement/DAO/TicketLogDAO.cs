using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DAO
{
    class TicketLogDAO
    {
        private static string sqlGetAllData = "select TicketLog.Identify, TicketLog.ProcessDate, LogType.LogTypeName, UserCar.NameUser, TicketMonth.Identify as TicketMonthIdentify" +
                ", TicketMonth.ID as TicketMonthID, TicketMonth.Digit, TicketMonth.CustomerName, TicketMonth.CMND, TicketMonth.Email, " +
                "TicketMonth.Address, TicketMonth.CarKind, Part.PartName, TicketMonth.RegistrationDate, TicketMonth.ExpirationDate from" +
                " [TicketLog], [LogType], [TicketMonth], [Part], [UserCar] where TicketMonth.IDPart = Part.PartID and TicketLog.LogTypeID = LogType.LogTypeID" +
                " and TicketLog.TicketMonthID = TicketMonth.ID and UserCar.UserID = TicketLog.Account";
        private static string sqlOrderByIdentify = " order by TicketLog.Identify asc";

        public static DataTable GetAllData()
        {
            string sql = sqlGetAllData + sqlOrderByIdentify;
            return Database.ExcuQuery(sql);
        }

        public static DataTable searchData(string key, string ticketLogID, string partID, DateTime registrationDate, DateTime expirationDate)
        {
            string sql = sqlGetAllData;
            sql += " and TicketMonth.RegistrationDate >= #" + registrationDate + "# and TicketMonth.ExpirationDate <= #" + expirationDate + "#";
            if (!string.IsNullOrEmpty(key))
            {
                sql += " and (UserCar.NameUser like '%" + key + "%' or TicketMonth.Identify like '%" + key + "%' or TicketMonth.ID like '%" + key + "%' or TicketMonth.Digit like '%" + key
                    + "%' or TicketMonth.CustomerName like '%" + key + "%' or TicketMonth.CMND like '%" + key + "%' or TicketMonth.Email like '%"
                    + key + "%' or TicketMonth.Address like '%" + key + "%' or TicketMonth.CarKind like '%" + key + "%')";
            }
            if (!string.IsNullOrEmpty(ticketLogID))
            {
                sql += " and LogType.LogTypeID like '" + ticketLogID + "'";
            }
            if (!string.IsNullOrEmpty(partID))
            {
                sql += " and Part.PartID like '" + partID + "'";
            }
            sql += sqlOrderByIdentify;
            return Database.ExcuQuery(sql);
        }
    }
}

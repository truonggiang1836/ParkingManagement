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
        public static DataTable GetAllData()
        {
            string sql = "select TicketLog.Identify, TicketLog.ProcessDate, LogType.LogTypeName, UserCar.NameUser, TicketMonth.Identify as TicketMonthIdentify" +
                ", TicketMonth.ID as TicketMonthID, TicketMonth.Digit, TicketMonth.CustomerName, TicketMonth.CMND, TicketMonth.Email, " +
                "TicketMonth.Address, TicketMonth.CarKind, Part.PartName, TicketMonth.RegistrationDate, TicketMonth.ExpirationDate from" +
                " [TicketLog], [LogType], [TicketMonth], [Part], [UserCar] where TicketMonth.IDPart = Part.PartID and TicketLog.LogTypeID = LogType.LogTypeID" +
                " and TicketLog.TicketMonthID = TicketMonth.ID and UserCar.UserID = TicketLog.Account order by TicketLog.Identify asc";
            return Database.ExcuQuery(sql);
        }
    }
}

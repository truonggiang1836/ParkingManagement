using ParkingMangement.DTO;
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
        private static string sqlGetAllData = "select TicketLog.Identify, TicketLog.ProcessDate, LogType.LogTypeName, UserCar.NameUser, TicketLog.TicketMonthIdentify" +
                ", TicketLog.TicketMonthID, TicketLog.Digit, TicketLog.CustomerName, TicketLog.CMND, TicketLog.Email, " +
                "TicketLog.Address, TicketLog.CarKind, Part.PartName, TicketLog.RegistrationDate, TicketLog.ExpirationDate from" +
                " [TicketLog], [LogType], [Part], [UserCar] where TicketLog.IDPart = Part.PartID and TicketLog.LogTypeID = LogType.LogTypeID and UserCar.UserID = TicketLog.Account";
        private static string sqlOrderByIdentify = " order by TicketLog.Identify asc";

        public static DataTable GetAllData()
        {
            string sql = sqlGetAllData + sqlOrderByIdentify;
            return Database.ExcuQuery(sql);
        }

        public static DataTable searchData(string key, string ticketLogID, string partID, DateTime registrationDate, DateTime expirationDate)
        {
            string sql = sqlGetAllData;
            sql += " and TicketLog.RegistrationDate >= #" + registrationDate + "# and TicketLog.ExpirationDate <= #" + expirationDate + "#";
            if (!string.IsNullOrEmpty(key))
            {
                sql += " and (UserCar.NameUser like '%" + key + "%' or TicketLog.TicketMonthIdentify like '%" + key + "%' or TicketLog.TicketMonthID like '%" + key + "%' or TicketLog.Digit like '%" + key
                    + "%' or TicketLog.CustomerName like '%" + key + "%' or TicketLog.CMND like '%" + key + "%' or TicketLog.Email like '%"
                    + key + "%' or TicketLog.Address like '%" + key + "%' or TicketLog.CarKind like '%" + key + "%')";
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

        public static void Insert(TicketLogDTO ticketLogDTO)
        {
            TicketMonthDTO ticketMonthDTO = ticketLogDTO.TicketMonthDTO;
            string sql = "insert into TicketLog(LogTypeID, TicketMonthID, TicketMonthIdentify, ProcessDate, Digit, CustomerName, CMND, Company, Email, Address, CarKind, RegistrationDate, ExpirationDate" +
                ", ChargesAmount, IDPart, Account) values (" + ticketLogDTO.LogTypeID + ", '" + ticketMonthDTO.Id + "', " + ticketMonthDTO.Identify + ", '" + ticketMonthDTO.ProcessDate + "', '" + ticketMonthDTO.Digit + "', '" +
                ticketMonthDTO.CustomerName + "', '" + ticketMonthDTO.Cmnd + "', '" + ticketMonthDTO.Company + "', '" + ticketMonthDTO.Email + "', '" +
                ticketMonthDTO.Address + "', '" + ticketMonthDTO.CarKind + "', '" + ticketMonthDTO.RegistrationDate + "', '" + ticketMonthDTO.ExpirationDate +
                "', '" + ticketMonthDTO.ChargesAmount + "', '" + ticketMonthDTO.IdPart + "', '" + ticketMonthDTO.Account + "')";
            Database.ExcuNonQuery(sql);
        }
    }
}

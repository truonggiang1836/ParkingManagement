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
    class TicketLogDAO
    {
        private static string sqlGetAllData = "select TicketLog.ProcessDate, LogType.LogTypeName, UserCar.NameUser, SmartCard.Identify" +
                ", TicketLog.TicketMonthID, TicketLog.Digit, TicketLog.CustomerName, TicketLog.CMND, TicketLog.Email, " +
                "TicketLog.Address, TicketLog.CarKind, Part.PartName, TicketLog.RegistrationDate, TicketLog.ExpirationDate from" +
                " TicketLog left join LogType on TicketLog.LogTypeID = LogType.LogTypeID left join Part on TicketLog.IDPart = Part.ID" +
            " left join UserCar on UserCar.UserID = TicketLog.Account left join SmartCard on TicketLog.TicketMonthID = SmartCard.ID where 0 = 0 ";
        private static string sqlOrderByIdentify = " order by TicketLog.Identify desc";

        public static DataTable GetAllData()
        {
            string sql = sqlGetAllData;
            return Database.ExcuQuery(sql);
        }

        public static DataTable searchData(string key, string ticketLogID, string partID, DateTime startDate, DateTime endDate)
        {
            string sql = sqlGetAllData;
            sql += " and TicketLog.ProcessDate between '" + startDate.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + endDate.ToString(Constant.sDateTimeFormatForQuery) + "'";
            if (!string.IsNullOrEmpty(key))
            {
                sql += " and (UserCar.NameUser like '%" + key + "%' or SmartCard.Identify like '%" + key + "%' or TicketLog.TicketMonthID like '%" + key + "%' or TicketLog.Digit like '%" + key
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
            return Database.ExcuQuery(sql);
        }

        public static void Insert(TicketLogDTO ticketLogDTO)
        {
            TicketMonthDTO ticketMonthDTO = ticketLogDTO.TicketMonthDTO;
            string sql = "insert into TicketLog(LogTypeID, TicketMonthID, TicketMonthIdentify, ProcessDate, Digit, CustomerName, CMND, Company, Email, Address, CarKind, RegistrationDate, ExpirationDate" +
                ", ChargesAmount, IDPart, Account) values (" + ticketLogDTO.LogTypeID + ", '" + ticketMonthDTO.Id + "', '" + ticketMonthDTO.CardIdentify + "', '" + ticketMonthDTO.ProcessDate?.ToString(Constant.sDateTimeFormatForQuery) + "', N'" + ticketMonthDTO.Digit + "', N'" +
                ticketMonthDTO.CustomerName + "', N'" + ticketMonthDTO.Cmnd + "', N'" + ticketMonthDTO.Company + "', N'" + ticketMonthDTO.Email + "', N'" +
                ticketMonthDTO.Address + "', N'" + ticketMonthDTO.CarKind + "', '" + ticketMonthDTO.RegistrationDate?.ToString(Constant.sDateTimeFormatForQuery) + "', '" + ticketMonthDTO.ExpirationDate?.ToString(Constant.sDateTimeFormatForQuery) +
                "', '" + ticketMonthDTO.ChargesAmount + "', '" + ticketMonthDTO.IdPart + "', '" + ticketMonthDTO.Account + "')";
            Database.ExcuNonQuery(sql);
        }
    }
}

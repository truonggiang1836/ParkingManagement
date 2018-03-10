using ParkingMangement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DAO
{
    class TicketMonthDAO
    {
        public static DataTable GetAllData()
        {
            string sql = "select TicketLog.Identify, TicketLog.ProcessDate, LogType.LogTypeName, TicketMonth.Identify, TicketMonth.ID, TicketMonth.Digit, TicketMonth.CustomerName, TicketMonth.CMND," +
                " TicketMonth.Company, TicketMonth.Email, TicketMonth.Address, TicketMonth.CarKind, TicketMonth.ChargesAmount, Part.PartName," +
                " TicketMonth.RegistrationDate, TicketMonth.ExpirationDate, TicketMonth.Images from [TicketMonth], [Part] where TicketMonth.IDPart = Part.PartID order by TicketMonth.Identify asc";
            return Database.ExcuQuery(sql);
        }

        public static void Insert(TicketMonthDTO ticketMonthDTO)
        {
            string sql = "insert into TicketMonth(ID, ProcessDate, Digit, CustomerName, CMND, Company, Email, Address, CarKind, RegistrationDate, ExpirationDate" +
                ", ChargesAmount, IDPart) values ('" + ticketMonthDTO.Id + "', '" + ticketMonthDTO.ProcessDate + "', '" + ticketMonthDTO.Digit + "', '" + 
                ticketMonthDTO.CustomerName + "', '" + ticketMonthDTO.Cmnd + "', '" + ticketMonthDTO.Company + "', '" + ticketMonthDTO.Email + "', '" + 
                ticketMonthDTO.Address + "', '" + ticketMonthDTO.CarKind + "', '" + ticketMonthDTO.RegistrationDate + "', '" + ticketMonthDTO.ExpirationDate + 
                "', '" + ticketMonthDTO.ChargesAmount + "', '" + ticketMonthDTO.IdPart + "')";
            Database.ExcuNonQuery(sql);
        }

        public static void Update(TicketMonthDTO ticketMonthDTO)
        {
            string sql = "update [TicketMonth] set ProcessDate ='" + ticketMonthDTO.ProcessDate + "', Digit ='" + ticketMonthDTO.Digit + "', CustomerName ='"
                + ticketMonthDTO.CustomerName + "', CMND ='" + ticketMonthDTO.Cmnd + "', Company ='" + ticketMonthDTO.Company + "', Email ='" + ticketMonthDTO.Email + "', Address ='" + ticketMonthDTO.Address + "', CarKind ='"
                + ticketMonthDTO.CarKind + "', RegistrationDate ='" + ticketMonthDTO.RegistrationDate + "', ExpirationDate ='" + ticketMonthDTO.ExpirationDate + "', IdPart ='" + ticketMonthDTO.IdPart + "', ChargesAmount ='" + ticketMonthDTO.ChargesAmount + "' where Identify =" + ticketMonthDTO.Identify;
            Database.ExcuNonQuery(sql);
        }

        public static void Delete(int identify)
        {
            string sql = "delete from [TicketMonth] where Identify =" + identify;
            Database.ExcuNonQuery(sql);
        }
    }
}

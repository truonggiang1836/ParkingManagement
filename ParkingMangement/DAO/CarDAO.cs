using ParkingMangement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DAO
{
    class CarDAO
    {
        private static string sqlGetAllData = "select Car.Identify, SmartCard.Identify as SmartCardIdentify, Car.ID, Car.TimeStart, Car.TimeEnd, " +
            "Car.Digit, Car.IDIn, Car.IDOut, Car.IDTicketMonth, Car.IsLostCard, Car.Cost, Part.PartName, Part.Sign, Car.Computer, Car.Account, " +
            "Car.DateUpdate from [Car], [Part], [SmartCard] where Car.IDPart = Part.PartID and SmartCard.ID = Car.ID";

        private static string sqlGetAllTicketMonthData = "select Car.Identify, Car.ID, Car.TimeStart, Car.TimeEnd, " +
            "Car.Digit, Part.PartName, TicketMonth.Company, TicketMonth.CustomerName from [Car], [Part], [TicketMonth] " +
            "where Car.IDPart = Part.PartID and TicketMonth.ID = Car.IDTicketMonth";

        private static string sqlQueryTicketMonth = " and Car.IDTicketMonth is not null ";
        private static string sqlOrderByIdentify = " order by Car.Identify asc";

        public static DataTable GetAllTicketDayData()
        {
            string sql = sqlGetAllData + sqlOrderByIdentify;
            DataTable data = Database.ExcuQuery(sql);
            setUserNameForDataTable(data);
            return data;
        }

        public static DataTable GetAllTicketMonthData()
        {
            string sql = sqlGetAllTicketMonthData + sqlQueryTicketMonth + sqlOrderByIdentify;
            DataTable data = Database.ExcuQuery(sql);
            return data;
        }

        public static DataTable searchTicketDayData(CarDTO carDTO)
        {
            string sql = sqlGetAllData;
            sql += " and Car.TimeStart >= #" + carDTO.TimeStart + "# and Car.TimeEnd <= #" + carDTO.TimeEnd + "#";
            if (!string.IsNullOrEmpty(carDTO.IdPart))
            {
                sql += " and Car.IDPart like '" + carDTO.IdPart + "'";
            }
            if (carDTO.Identify != -1)
            {
                sql += " and Car.Identify like '%" + carDTO.Identify + "%'";
            }
            if (!string.IsNullOrEmpty(carDTO.Digit))
            {
                sql += " and Car.Digit like '%" + carDTO.Digit + "%'";
            }
            if (!string.IsNullOrEmpty(carDTO.Id))
            {
                sql += " and SmartCard.ID like '%" + carDTO.Id + "%'";
            }
            if (!string.IsNullOrEmpty(carDTO.IdIn))
            {
                sql += " and Car.IDIn like '" + carDTO.IdIn + "'";
            }
            if (!string.IsNullOrEmpty(carDTO.IdOut))
            {
                sql += " and Car.IDOut like '" + carDTO.IdOut + "'";
            }
            sql += sqlOrderByIdentify;

            DataTable data = Database.ExcuQuery(sql);
            if (data != null)
            {
                setUserNameForDataTable(data);
            }
            return data;
        }

        public static DataTable searchTicketMonthData(CarDTO carDTO, TicketMonthDTO ticketMonthDTO)
        {
            string sql = sqlGetAllTicketMonthData + sqlQueryTicketMonth;
            sql += " and Car.TimeStart >= #" + carDTO.TimeStart + "# and Car.TimeEnd <= #" + carDTO.TimeEnd + "#";
            if (!string.IsNullOrEmpty(ticketMonthDTO.CustomerName))
            {
                sql += " and TicketMonth.CustomerName like '%" + ticketMonthDTO.CustomerName + "%'";
            }
            if (!string.IsNullOrEmpty(ticketMonthDTO.Company))
            {
                sql += " and TicketMonth.Company like '%" + ticketMonthDTO.Company + "%'";
            }         
            sql += sqlOrderByIdentify;

            DataTable data = Database.ExcuQuery(sql);
            return data;
        }

        private static void setUserNameForDataTable(DataTable data)
        {
            for (int row = 0; row < data.Rows.Count; row++)
            {
                string userIdIn = data.Rows[row].Field<string>("IDIn");
                string userIdOut = data.Rows[row].Field<string>("IDOut");
                string userNameIn = UserDAO.GetUserNameByID(userIdIn);
                string userNameOut = UserDAO.GetUserNameByID(userIdOut);
                data.Rows[row].SetField("IDIn", userNameIn);
                data.Rows[row].SetField("IDOut", userNameOut);
            }
        }
    }
}

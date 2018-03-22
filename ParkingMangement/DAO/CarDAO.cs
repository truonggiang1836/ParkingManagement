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
            "Car.DateUpdate, Car.Images, Car.Images2, Car.Images3, Car.Images4 from [Car], [Part], [SmartCard] where Car.IDPart = Part.PartID and SmartCard.ID = Car.ID";

        private static string sqlGetAllTicketMonthData = "select Car.Identify, Car.ID, Car.TimeStart, Car.TimeEnd, " +
            "Car.Digit, Part.PartName, TicketMonth.Company, TicketMonth.CustomerName from [Car], [Part], [TicketMonth] " +
            "where Car.IDPart = Part.PartID and TicketMonth.ID = Car.IDTicketMonth";

        private static string sqlGetDataForCashManagement = "select Car.ID, Car.TimeStart, Car.TimeEnd, Car.Digit, Car.Cost, Car.CostBefore, " +
            "Car.IsLostCard, Car.Computer, UserCar.NameUser from [Car], [UserCar] where Car.Account = UserCar.UserID";

        private static string sqlQueryTicketMonth = " and Car.IDTicketMonth is not null ";
        private static string sqlOrderByIdentify = " order by Car.Identify asc";

        public static DataTable GetAllData()
        {
            string sql = sqlGetAllData + sqlOrderByIdentify;
            DataTable data = Database.ExcuQuery(sql);
            setUserNameForDataTable(data);
            return data;
        }

        public static DataTable GetAllDataForCashManagement()
        {
            string sql = sqlGetDataForCashManagement + sqlOrderByIdentify;
            DataTable data = Database.ExcuQuery(sql);
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

        public static void updateLostCard(string id, DateTime dateLostCard)
        {
            string sql = "update [Car] set IsLostCard = 1 and DateLostCard = '" + dateLostCard + "' where ID = '" + id+ "'";
            Database.ExcuNonQuery(sql);
        }

        public static void updateImage()
        {
            string base64 = "";
            string sql = "update [Car] set Images =('" + base64 + "') where Identify = 1";
            Database.ExcuNonQuery(sql);
        }

        public static DataTable GetTotalCommonCostCarGroupByType(DateTime? startTime, DateTime? endTime)
        {
            string sql = "select Car.IDPart, sum(Car.Cost) as SumCost from [Car], [Part] where (Car.IDPart = Part.PartID and IDTicketMonth is not null) group by Car.IDPart";
            if (startTime != null && endTime != null)
            {
                sql = "select Car.IDPart, sum(Car.Cost) as SumCost from [Car], [Part] where Car.IDPart = Part.PartID and IDTicketMonth is not null and Car.TimeStart >= #" + startTime + "# and Car.TimeEnd <= #" + endTime + "# group by Car.IDPart";
            }
            DataTable data = Database.ExcuQuery(sql);
            if (data != null)
            {
                data.Columns.Add("PartName", typeof(string));
                data.Columns.Add("CountCarIn", typeof(int));
                data.Columns.Add("CountCarOut", typeof(int));
                for (int row = 0; row < data.Rows.Count; row++)
                {
                    string partID = data.Rows[row].Field<string>("IDPart");
                    string partName = PartDAO.GetPartNameByPartID(partID);
                    data.Rows[row].SetField("PartName", partName);
                    int countCarIn = GetCountCarInByPartAndDate(startTime, endTime, partID, true);
                    data.Rows[row].SetField("CountCarIn", countCarIn);
                    int countCarOut = GetCountCarOutByPartAndDate(startTime, endTime, partID, true);
                    data.Rows[row].SetField("CountCarOut", countCarOut);
                }
            }
            
            return data;
        }    

        public static int GetCountCarInByPartAndDate(DateTime? startTime, DateTime? endTime, string partID, bool isTicketMonth)
        {
            string sql = "select * from [Car] where Car.TimeStart is not null and IDTicketMonth is null and IDPart = '" + partID + "'";
            if (isTicketMonth)
            {
                sql = "select * from [Car] where Car.TimeStart is not null and IDTicketMonth is not null and IDPart = '" + partID + "'";
            }
            if (startTime != null && endTime != null)
            {
                sql += " and Car.TimeStart >= #" + startTime + "# and Car.TimeStart <= #" + endTime + "#";
            }

            DataTable data = Database.ExcuQuery(sql);
            if (data == null)
            {
                return 0;
            }
            return data.Rows.Count;
        }

        public static int GetCountCarOutByPartAndDate(DateTime? startTime, DateTime? endTime, string partID, bool isTicketMonth)
        {
            string sql = "select * from [Car] where Car.TimeEnd is not null and IDTicketMonth is null and IDPart = '" + partID + "'";
            if (isTicketMonth)
            {
                sql = "select * from [Car] where Car.TimeEnd is not null and IDTicketMonth is not null and IDPart = '" + partID + "'";
            }
            if (startTime != null && endTime != null)
            {
                sql += " and Car.TimeEnd >= #" + startTime + "# and Car.TimeEnd <= #" + endTime + "#";
            }

            DataTable data = Database.ExcuQuery(sql);
            return data.Rows.Count;
        }
    }
}

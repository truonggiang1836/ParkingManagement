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
        private static string sqlGetAllData = "select DISTINCT SmartCard.Identify, TicketMonth.ID, TicketMonth.Digit, TicketMonth.CustomerName, TicketMonth.CMND," +
                " TicketMonth.Company, TicketMonth.Email, TicketMonth.Address, TicketMonth.CarKind, TicketMonth.ChargesAmount, Part.PartName," +
                " TicketMonth.RegistrationDate, TicketMonth.ExpirationDate, TicketMonth.Images from TicketMonth, Part, SmartCard where TicketMonth.IDPart = Part.ID and TicketMonth.ID = SmartCard.ID";

        private static string sqlGetAllNearExpiredTicketData = "select DISTINCT Part.PartName, SmartCard.Identify, TicketMonth.ID, TicketMonth.Digit, TicketMonth.CustomerName, TicketMonth.Address, TicketMonth.ChargesAmount," +
                " TicketMonth.RegistrationDate, TicketMonth.ExpirationDate from TicketMonth, Part, SmartCard where TicketMonth.IDPart = Part.ID and TicketMonth.ID = SmartCard.ID";

        private static string sqlGetAllLostTicketData = "select DISTINCT TicketMonth.Identify as TicketMonthIdentify, SmartCard.Identify, TicketMonth.ID, TicketMonth.Digit, TicketMonth.CustomerName, TicketMonth.Address," +
            " Part.PartName, TicketMonth.RegistrationDate, TicketMonth.ExpirationDate, SmartCard.DayUnlimit, TicketMonth.Note, TicketMonth.ProcessDate from " +
            "TicketMonth, Part, UserCar, SmartCard where TicketMonth.ID = SmartCard.ID and TicketMonth.IDPart = Part.ID and TicketMonth.ID = SmartCard.ID";

        private static string sqlGetAllActiveTicketData = "select SmartCard.Identify, TicketMonth.ID, TicketMonth.Digit, TicketMonth.CustomerName, TicketMonth.Company, TicketMonth.Address, " +
            "TicketMonth.RegistrationDate, TicketMonth.ExpirationDate, SmartCard.DayUnlimit from TicketMonth, SmartCard where TicketMonth.ID = SmartCard.ID and SmartCard.IsUsing = '0'";

        private static string sqlOrderByIdentify = " order by SmartCard.Identify asc";
        public static DataTable GetAllData()
        {
            string sql = sqlGetAllData + sqlOrderByIdentify;
            return Database.ExcuQuery(sql);
        }

        public static bool Insert(TicketMonthDTO ticketMonthDTO)
        {
            string sql = "insert into TicketMonth(ID, ProcessDate, Digit, CustomerName, CMND, Company, Email, Address, CarKind, RegistrationDate, ExpirationDate" +
                ", ChargesAmount, IDPart, Account) values ('" + ticketMonthDTO.Id + "', '" + ticketMonthDTO.ProcessDate + "', '" + ticketMonthDTO.Digit + "', '" + 
                ticketMonthDTO.CustomerName + "', '" + ticketMonthDTO.Cmnd + "', '" + ticketMonthDTO.Company + "', '" + ticketMonthDTO.Email + "', '" + 
                ticketMonthDTO.Address + "', '" + ticketMonthDTO.CarKind + "', '" + ticketMonthDTO.RegistrationDate + "', '" + ticketMonthDTO.ExpirationDate + 
                "', '" + ticketMonthDTO.ChargesAmount + "', '" + ticketMonthDTO.IdPart + "', '" + ticketMonthDTO.Account + "')";
            return Database.ExcuNonQuery(sql);
        }

        public static void Update(TicketMonthDTO ticketMonthDTO)
        {
            string sql = "update TicketMonth set ProcessDate ='" + ticketMonthDTO.ProcessDate + "', Digit ='" + ticketMonthDTO.Digit + "', CustomerName ='"
                + ticketMonthDTO.CustomerName + "', CMND ='" + ticketMonthDTO.Cmnd + "', Company ='" + ticketMonthDTO.Company + "', Email ='" + ticketMonthDTO.Email + "', Address ='" + ticketMonthDTO.Address + "', CarKind ='"
                + ticketMonthDTO.CarKind + "', RegistrationDate ='" + ticketMonthDTO.RegistrationDate + "', ExpirationDate ='" + ticketMonthDTO.ExpirationDate + "', IdPart ='" + ticketMonthDTO.IdPart + "', ChargesAmount ='" + ticketMonthDTO.ChargesAmount + "' where ID ='" + ticketMonthDTO.Id + "'";
            Database.ExcuNonQuery(sql);
        }

        public static bool Delete(string id)
        {
            string sql = "delete from TicketMonth where ID ='" + id + "'";
            return Database.ExcuNonQuery(sql);
        }

        public static DataTable searchData(string key)
        {
            string sql = sqlGetAllData;
            if (!string.IsNullOrEmpty(key))
            {
                sql += " and (SmartCard.Identify like '%" + key + "%' or TicketMonth.ID like '%" + key + "%' or TicketMonth.Digit like '%" + key
                    + "%' or TicketMonth.CustomerName like '%" + key + "%' or TicketMonth.CMND like '%" + key + "%' or TicketMonth.Email like '%"
                    + key + "%' or TicketMonth.Company like '%" + key + "%' or TicketMonth.Address like '%" + key + "%' or TicketMonth.CarKind like '%"
                    + key + "%' or TicketMonth.ChargesAmount like '%" + key + "%' or Part.PartName like '%" + key + "%')";
            }
            sql += sqlOrderByIdentify;
            return Database.ExcuQuery(sql);
        }

        public static DataTable GetAllNearExpiredTicketData(DateTime currentDate)
        {
            string sql = sqlGetAllNearExpiredTicketData;
            sql += sqlOrderByIdentify;
            DataTable data = Database.ExcuQuery(sql);

            data.Columns.Add("DaysRemaining", typeof(System.Int32));
            for (int row = 0; row < data.Rows.Count; row++)
            {
                DateTime expirationDate = data.Rows[row].Field<DateTime>("ExpirationDate");
                int daysRemaining = Convert.ToInt32((expirationDate - currentDate).TotalDays);
                //if (daysRemaining >= 0)
                //{
                //    data.Rows[row].SetField("DaysRemaining", daysRemaining);
                //}
                //else
                //{
                //    data.Rows[row].Delete();
                //}
                data.Rows[row].SetField("DaysRemaining", daysRemaining);
            }
            return data;
        }

        public static DataTable searchNearExpiredTicketData(string key, int? daysRemaining)
        {
            string sql = sqlGetAllNearExpiredTicketData;
            if (!string.IsNullOrEmpty(key))
            {
                sql += " and (SmartCard.Identify like '%" + key + "%' or TicketMonth.Digit like '%" + key
                    + "%' or TicketMonth.CustomerName like '%" + key + "%' or TicketMonth.Address like '%" + key + "%')";
            }
            sql += sqlOrderByIdentify;
            DataTable data = Database.ExcuQuery(sql);

            DateTime currentDate = DateTime.Now;
            data.Columns.Add("DaysRemaining", typeof(System.Int32));
            for (int row = 0; row < data.Rows.Count; row++)
            {
                DateTime expirationDate = data.Rows[row].Field<DateTime>("ExpirationDate");
                int daysRemainingInDB = Convert.ToInt32((expirationDate - currentDate).TotalDays);
                //if (daysRemainingInDB >= 0)
                //{
                //    data.Rows[row].SetField("DaysRemaining", daysRemainingInDB);
                //}
                //else
                //{
                //    data.Rows[row].Delete();
                //}
                data.Rows[row].SetField("DaysRemaining", daysRemainingInDB);
                if (daysRemaining != null && daysRemaining.GetValueOrDefault() != daysRemainingInDB)
                {
                    data.Rows[row].Delete();
                }
            }

            return data;
        }

        public static void updateTicketByExpirationDate(DateTime expirationDate, string id)
        {
            string sql = "update TicketMonth set ExpirationDate = '" + expirationDate + "'  where ID ='" + id + "'";
            Database.ExcuNonQuery(sql);
        }

        public static DataTable GetAllLostTicketData()
        {
            string sql = sqlGetAllLostTicketData;
            sql += sqlOrderByIdentify;
            DataTable data = Database.ExcuQuery(sql);

            addDaysRemainingToTicketData(data);
            return data;
        }

        private static void addDaysRemainingToTicketData(DataTable data)
        {
            DateTime currentDate = DateTime.Now;
            data.Columns.Add("DaysRemaining", typeof(System.Int32));
            for (int row = 0; row < data.Rows.Count; row++)
            {
                DateTime expirationDate = data.Rows[row].Field<DateTime>("ExpirationDate");
                int daysRemainingInDB = Convert.ToInt32((expirationDate - currentDate).TotalDays);
                data.Rows[row].SetField("DaysRemaining", daysRemainingInDB);
            }
        }

        public static DataTable searchLostTicketData(string key)
        {
            string sql = sqlGetAllLostTicketData;
            if (!string.IsNullOrEmpty(key))
            {
                sql += " and (TicketMonth.ID like '%" + key + "%' or TicketMonth.Digit like '%" + key
                    + "%' or TicketMonth.CustomerName like '%" + key + "%' or TicketMonth.Address like '%" + key + "%')";
            }
            sql += sqlOrderByIdentify;
            DataTable data = Database.ExcuQuery(sql);

            addDaysRemainingToTicketData(data);
            return data;
        }

        public static DataTable searchActiveTicketData(string key)
        {
            string sql = sqlGetAllActiveTicketData;
            if (!string.IsNullOrEmpty(key))
            {
                sql += " and (SmartCard.Identify like '%" + key + "%' or TicketMonth.ID like '%" + key + "%' or TicketMonth.Digit like '%" + key
                    + "%' or TicketMonth.CustomerName like '%" + key + "%' or TicketMonth.Address like '%" + key + "%')";
            }
            sql += sqlOrderByIdentify;
            DataTable data = Database.ExcuQuery(sql);

            addDaysRemainingToTicketData(data);
            return data;
        }

        public static void updateTicketByID(string id, int identify)
        {
            string sql = "update TicketMonth set ID = '" + id + "' where Identify = " + identify;
            Database.ExcuNonQuery(sql);
        }

        public static DataTable GetSearchData()
        {
            string sql = sqlGetAllData + sqlOrderByIdentify;
            return Database.ExcuQuery(sql);
        }

        public static DataTable GetDataByID(string id)
        {
            string sql = "select * from TicketMonth where ID = '" + id + "'";
            return Database.ExcuQuery(sql);
        }

        public static DataTable GetDataByDigit(string digit)
        {
            string sql = "select * from TicketMonth where Digit = '" + digit + "'";
            return Database.ExcuQuery(sql);
        }

        public static DataTable GetDataByIdentify(string cardIdentify)
        {
            string sql = "select * from TicketMonth left join SmartCard on TicketMonth.ID = SmartCard.ID where SmartCard.Identify = '" + cardIdentify + "'";
            return Database.ExcuQuery(sql);
        }

        public static string GetDigitByID(string id)
        {
            DataTable dt = GetDataByID(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<string>("Digit");
            }
            else
            {
                return "";
            }
        }

        public static DateTime? GetExpirationDateByID(string id)
        {
            DataTable dt = GetDataByID(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<DateTime?>("ExpirationDate");
            }
            else
            {
                return DateTime.Now;
            }
        }
        public static string GetCustomerNameByID(string id)
        {
            DataTable dt = GetDataByID(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<string>("CustomerName");
            }
            else
            {
                return "";
            }
        }

        public static TicketMonthDTO getTicketMonthFromDataRow(DataRow dataRow)
        {
            TicketMonthDTO ticketMonthDTO = new TicketMonthDTO();
            ticketMonthDTO.CardIdentify = dataRow.Field<String>("CardIdentify");
            ticketMonthDTO.Id = dataRow.Field<String>("ID");
            ticketMonthDTO.Digit = dataRow.Field<String>("Digit");
            ticketMonthDTO.CustomerName = dataRow.Field<String>("CustomerName");
            ticketMonthDTO.Cmnd = dataRow.Field<String>("CMND");
            ticketMonthDTO.Company = dataRow.Field<String>("Company");
            ticketMonthDTO.Email = dataRow.Field<String>("Email");
            ticketMonthDTO.Address = dataRow.Field<String>("Address");
            ticketMonthDTO.CarKind = dataRow.Field<String>("CarKind");
            String registrationDateString = dataRow.Field<String>("RegistrationDate");
            DateTime registrationDate = DateTime.FromOADate(double.Parse(registrationDateString));
            ticketMonthDTO.RegistrationDate = registrationDate;
            String expirationDateString = dataRow.Field<String>("ExpirationDate");
            DateTime expirationDate = DateTime.FromOADate(double.Parse(expirationDateString));
            ticketMonthDTO.ExpirationDate = expirationDate;
            ticketMonthDTO.ChargesAmount = dataRow.Field<String>("ChargesAmount");
            return ticketMonthDTO;
        }
    }
}

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
    class CarDAO
    {
        public static int ALL_TICKET = 0;
        public static int COMMON_TICKET = 1;
        public static int MONTH_TICKET = 2;

        private static string sqlGetAllData = "select Car.Identify, SmartCard.Identify as SmartCardIdentify, Car.ID, Car.TimeStart, Car.TimeEnd, " +
            "Car.Digit, Car.IDIn, Car.IDOut, Car.IDTicketMonth, Car.IsLostCard, Car.Cost, Part.PartName, Part.Sign, Car.Computer, Car.Account, " +
            "Car.DateUpdate, Car.Images, Car.Images2, Car.Images3, Car.Images4 from [Car], [Part], [SmartCard] where Car.IDPart = Part.PartID and SmartCard.ID = Car.ID";


        private static string sqlGetAllTicketMonthData = "select Car.Identify, Car.ID, Car.TimeStart, Car.TimeEnd, " +
            "Car.Digit, Part.PartName, TicketMonth.Company, TicketMonth.CustomerName from [Car], [Part], [TicketMonth] " +
            "where Car.IDPart = Part.PartID and TicketMonth.ID = Car.IDTicketMonth";

        private static string sqlGetDataForCashManagement = "select Car.ID, Car.TimeStart, Car.TimeEnd, Car.Digit, Car.Cost, Car.CostBefore, " +
            "Car.IsLostCard, Car.Computer, UserCar.NameUser from [Car], [UserCar] where Car.Account = UserCar.UserID";

        private static string sqlQueryTicketMonth = " and Car.IDTicketMonth <> '' ";
        private static string sqlQueryTicketCommon= " and Car.IDTicketMonth = '' ";
        private static string sqlQueryXeTon = " and Car.IDOut = '' ";
        private static string sqlQueryMatThe = " and Car.IsLostCard > " + 0 + "";
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

        public static string sqlSearchData(CarDTO carDTO)
        {
            string sql = sqlGetAllData;
            sql += " and Car.TimeStart >= #" + carDTO.TimeStart.ToString(Constant.sDateTimeFormatForQuery) + "# and Car.TimeEnd <= #" + carDTO.TimeEnd.ToString(Constant.sDateTimeFormatForQuery) + "#";
            if (!string.IsNullOrEmpty(carDTO.IdPart))
            {
                sql += " and Car.IDPart like '" + carDTO.IdPart + "'";
            }
            if (carDTO.CardIdentify != -1)
            {
                sql += " and SmartCard.Identify like '%" + carDTO.CardIdentify + "%'";
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
            return sql;
        }

        public static DataTable searchAllData(CarDTO carDTO)
        {
            string sql = sqlSearchData(carDTO);
            sql += sqlOrderByIdentify;

            DataTable data = Database.ExcuQuery(sql);
            if (data != null)
            {
                setUserNameForDataTable(data);
            }
            return data;
        }

        public static DataTable searchXeTon(CarDTO carDTO)
        {
            string sql = sqlSearchData(carDTO);
            sql += sqlQueryXeTon + sqlOrderByIdentify;

            DataTable data = Database.ExcuQuery(sql);
            if (data != null)
            {
                setUserNameForDataTable(data);
            }
            return data;
        }

        public static DataTable searchMatThe(CarDTO carDTO)
        {
            string sql = sqlSearchData(carDTO);
            sql += sqlQueryMatThe + sqlOrderByIdentify;

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
            sql += " and Car.TimeStart >= #" + carDTO.TimeStart.ToString(Constant.sDateTimeFormatForQuery) + "# and Car.TimeEnd <= #" + carDTO.TimeEnd.ToString(Constant.sDateTimeFormatForQuery) + "#";
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

        public static void updateImage()
        {
            string base64 = "";
            string sql = "update [Car] set Images =('" + base64 + "') where Identify = 1";
            Database.ExcuNonQuery(sql);
        }

        public static DataTable GetTotalCost(DateTime? startTime, DateTime? endTime, string userID, int ticketType)
        {
            DataTable data = new DataTable();
            DataTable commonData = GetTotalCostByType(startTime, endTime, false, userID);
            DataTable ticketData = GetTotalCostByType(startTime, endTime, true, userID);
            if (ticketType == ALL_TICKET || ticketType == COMMON_TICKET) {
                data.Merge(commonData);
            }
            if (ticketType == ALL_TICKET || ticketType == MONTH_TICKET)
            {
                data.Merge(ticketData);
            }


            if (ticketType == ALL_TICKET)
            {
                // Tổng cộng

                DataRow dataRow = data.NewRow();
                dataRow.SetField("PartName", "____Tổng cộng");

                int countAllCarIn = GetCountCarInByPartAndDate(startTime, endTime, null, false, userID) + GetCountCarInByPartAndDate(startTime, endTime, null, true, userID);
                dataRow.SetField("CountCarIn", countAllCarIn);

                int countAllCarOut = GetCountCarOutByPartAndDate(startTime, endTime, null, false, userID) + GetCountCarOutByPartAndDate(startTime, endTime, null, true, userID);
                dataRow.SetField("CountCarOut", countAllCarOut);

                int countAllCarSurvive = GetCountCarSurvive(null);
                dataRow.SetField("CountCarSurvive", countAllCarSurvive);

                int sumCost = GetCountCost(startTime, endTime, false, userID) + GetCountCost(startTime, endTime, true, userID);
                dataRow.SetField("SumCost", sumCost);
                data.Rows.Add(dataRow);
            }

            return data;
        }

        public static DataTable GetTotalCostByType(DateTime? startTime, DateTime? endTime, bool isTicketMonth, string userID)
        {
            string groupBySql = " group by Car.IDPart";
            string sql = "select Car.IDPart, sum(Car.Cost) as SumCost from [Car], [Part] where Car.IDPart = Part.PartID";
            if (!isTicketMonth)
            {
                sql += sqlQueryTicketCommon;
                
            } else
            {
                sql += sqlQueryTicketMonth;
            }
            if (startTime != null && endTime != null)
            {
                DateTime startTime1 = startTime ?? DateTime.Now;
                DateTime endTime1 = endTime ?? DateTime.Now;
                sql += " and Car.TimeStart >= #" + startTime1.ToString(Constant.sDateTimeFormatForQuery) + "# and Car.TimeEnd <= #" + endTime1.ToString(Constant.sDateTimeFormatForQuery) + "#";
            }
            if (userID != null)
            {
                sql += " and (Car.IDIn = '" + userID + "' or Car.IDOut = '" + userID + "')";
            }
            sql += groupBySql;

            DataTable data = Database.ExcuQuery(sql);
            if (data != null)
            {
                data.Columns.Add("PartName", typeof(string));
                data.Columns["PartName"].SetOrdinal(0);
                data.Columns.Add("CountCarIn", typeof(int));
                data.Columns["CountCarIn"].SetOrdinal(1);
                data.Columns.Add("CountCarOut", typeof(int));
                data.Columns["CountCarOut"].SetOrdinal(2);
                data.Columns.Add("CountCarSurvive", typeof(int));
                data.Columns["CountCarSurvive"].SetOrdinal(3);
                for (int row = 0; row < data.Rows.Count; row++)
                {
                    string partID = data.Rows[row].Field<string>("IDPart");
                    string partName = PartDAO.GetPartNameByPartID(partID);
                    data.Rows[row].SetField("PartName", partName);
                    int countCarIn = GetCountCarInByPartAndDate(startTime, endTime, partID, isTicketMonth, userID);
                    data.Rows[row].SetField("CountCarIn", countCarIn);
                    int countCarOut = GetCountCarOutByPartAndDate(startTime, endTime, partID, isTicketMonth, userID);
                    data.Rows[row].SetField("CountCarOut", countCarOut);
                    int countCarSurvive = GetCountCarSurvive(partID, isTicketMonth);
                    data.Rows[row].SetField("CountCarSurvive", countCarSurvive);
                }
            }


            // Tổng xe thường/tháng

            DataRow dataRow = data.NewRow();
            if (!isTicketMonth)
            {
                dataRow.SetField("PartName", "___Tổng xe thường");
            } else
            {
                dataRow.SetField("PartName", "___Tổng xe tháng");
            }

            int countAllCarIn = GetCountCarInByPartAndDate(startTime, endTime, null, isTicketMonth, userID);
            dataRow.SetField("CountCarIn", countAllCarIn);

            int countAllCarOut = GetCountCarOutByPartAndDate(startTime, endTime, null, isTicketMonth, userID);
            dataRow.SetField("CountCarOut", countAllCarOut);

            int countAllCarSurvive = GetCountCarSurvive(null, isTicketMonth);
            dataRow.SetField("CountCarSurvive", countAllCarSurvive);

            int sumCost = GetCountCost(startTime, endTime, isTicketMonth, userID);
            string sumCostString = Util.formatNumberAsMoney(sumCost);
            dataRow.SetField("SumCost", sumCostString);
            data.Rows.Add(dataRow);

            return data;
        }

        public static DataTable GetListCarSurvive()
        {
            string groupBySql = " group by Car.IDPart";
            string sql = "select Car.IDPart from [Car]";
            sql += groupBySql;
            DataTable data = Database.ExcuQuery(sql);
            if (data != null)
            {
                data.Columns.Add("PartName", typeof(string));
                data.Columns["PartName"].SetOrdinal(0);
                data.Columns.Add("CountCarSurvive", typeof(int));
                data.Columns["CountCarSurvive"].SetOrdinal(1);
                data.Columns.Add("Status", typeof(string));
                data.Columns["Status"].SetOrdinal(2);
                for (int row = 0; row < data.Rows.Count; row++)
                {
                    string partID = data.Rows[row].Field<string>("IDPart");
                    string partName = PartDAO.GetPartNameByPartID(partID);
                    data.Rows[row].SetField("PartName", partName);
                    int countCarSurvive = GetCountCarSurvive(partID);
                    data.Rows[row].SetField("CountCarSurvive", countCarSurvive);
                    string status = "Còn trống";
                    data.Rows[row].SetField("Status", status);
                }
            }
            return data;
        }

        public static int GetCountCost(DateTime? startTime, DateTime? endTime, bool isTicketMonth, string userID)
        {
            string sql = "select sum(Car.Cost) as SumCost from [Car] where Car.IDTicketMonth = ''";
            if (isTicketMonth)
            {
                sql = "select sum(Car.Cost) as SumCost from [Car] where Car.IDTicketMonth <> ''";
            }
            if (startTime != null && endTime != null)
            {
                DateTime startTime1 = startTime ?? DateTime.Now;
                DateTime endTime1 = endTime ?? DateTime.Now;
                sql += " and Car.TimeStart >= #" + startTime1.ToString(Constant.sDateTimeFormatForQuery) + "# and Car.TimeEnd <= #" + endTime1.ToString(Constant.sDateTimeFormatForQuery) + "#";
            }
            if (userID != null)
            {
                sql += " and (Car.IDIn = '" + userID + "' or Car.IDOut = '" + userID + "')";
            }

            return Database.ExcuValueQuery(sql);
        }

        public static int GetCountCarInByPartAndDate(DateTime? startTime, DateTime? endTime, string partID, bool isTicketMonth, string userID)
        {
            string sql = "select * from [Car] where Car.IDIn is not null " + sqlQueryTicketCommon;
            if (isTicketMonth)
            {
                sql = "select * from [Car] where Car.IDIn is not null " + sqlQueryTicketMonth;
            }
            if (partID != null)
            {
                sql += " and IDPart = '" + partID + "'";
            }
            if (startTime != null && endTime != null)
            {
                DateTime startTime1 = startTime ?? DateTime.Now;
                DateTime endTime1 = endTime ?? DateTime.Now;
                sql += " and Car.TimeStart >= #" + startTime1.ToString(Constant.sDateTimeFormatForQuery) + "# and Car.TimeStart <= #" + endTime1.ToString(Constant.sDateTimeFormatForQuery) + "#";
            }
            if (userID != null)
            {
                sql += " and (Car.IDIn = '" + userID + "' or Car.IDOut = '" + userID + "')";
            }

            DataTable data = Database.ExcuQuery(sql);
            if (data == null)
            {
                return 0;
            }
            return data.Rows.Count;
        }

        public static int GetCountCarOutByPartAndDate(DateTime? startTime, DateTime? endTime, string partID, bool isTicketMonth, string userID)
        {
            string sql = "select * from [Car] where Car.IDOut is not null " + sqlQueryTicketCommon;
            if (isTicketMonth)
            {
                sql = "select * from [Car] where Car.IDOut is not null " + sqlQueryTicketMonth;
            }
            if (partID != null)
            {
                sql += " and IDPart = '" + partID + "'";
            }
            if (startTime != null && endTime != null)
            {
                DateTime startTime1 = startTime ?? DateTime.Now;
                DateTime endTime1 = endTime ?? DateTime.Now;
                sql += " and Car.TimeEnd >= #" + startTime1.ToString(Constant.sDateTimeFormatForQuery) + "# and Car.TimeEnd <= #" + endTime1.ToString(Constant.sDateTimeFormatForQuery) + "#";
            }
            if (userID != null)
            {
                sql += " and (Car.IDIn = '" + userID + "' or Car.IDOut = '" + userID + "')";
            }

            DataTable data = Database.ExcuQuery(sql);
            return data.Rows.Count;
        }

        public static int GetCountCarSurvive(string partID)
        {
            string sql = "select * from [Car] where Car.IDIn is not null and Car.IDOut = '' ";
            if (partID != null)
            {
                sql += " and IDPart = '" + partID + "'";
            }

            DataTable data = Database.ExcuQuery(sql);
            return data.Rows.Count;
        }

        public static int GetCountCarSurvive(string partID, bool isTicketMonth)
        {
            string sql = "select * from [Car] where Car.IDIn is not null and Car.IDOut = '' " + sqlQueryTicketCommon;
            if (isTicketMonth)
            {
                sql = "select * from [Car] where Car.IDIn is not null and Car.IDOut = '' " + sqlQueryTicketMonth;
            }
            if (partID != null)
            {
                sql += " and IDPart = '" + partID + "'";
            }

            DataTable data = Database.ExcuQuery(sql);
            return data.Rows.Count;
        }

        public static DataTable GetCarByID(string id)
        {
            string sql = "select * from [Car] where ID = '" + id + "'" + " order by Identify desc";
            return Database.ExcuQuery(sql);
        }

        public static DataTable GetCarByIdentify(int identify)
        {
            string sql = "select * from [Car] where Identify = " + identify + " order by Identify desc";
            return Database.ExcuQuery(sql);
        }

        public static int GetLastIdentifyByID(string id)
        {
            string sql = "select * from [Car] where ID = '" + id + "'" + " order by Identify desc";
            DataTable dt = Database.ExcuQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                int identify = dt.Rows[0].Field<int>("Identify");
                return identify;
            }
            return 0;
        }

        public static DataTable GetLastCarByID(string id)
        {
            string sql = "select * from [Car] where ID = '" + id + "'" + " order by Identify desc";
            return Database.ExcuQuery(sql);
        }

        public static string GetLastCardID()
        {
            string sql = "select * from [Car] order by Identify desc";
            DataTable dt = Database.ExcuQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                string cardId = dt.Rows[0].Field<string>("ID");
                return cardId;
            }
            return "";
        }

        //public static void Insert(CarDTO carDTO)
        //{
        //    string sql = "insert into Car(ID, TimeStart, TimeEnd, Digit, IDIn, IDOut, Cost, IDTicketMonth, IDPart, Images, Images2, Images3," +
        //        " Images4, IsLostCard, Computer, Account, CostBefore, DateUpdate, DateLostCard) values ('" + carDTO.Id + "', '" + carDTO.TimeStart
        //        + "', '" + carDTO.TimeEnd + "', '" + carDTO.Digit + "', '" + carDTO.IdIn + "', '" + carDTO.IdOut + "', " + carDTO.Cost + ", '" +
        //        carDTO.IdTicketMonth + "', '" + carDTO.IdPart + "', '" + carDTO.Images + "', '" + carDTO.Images2 + "', '" + carDTO.Images3 + "', '" +
        //        carDTO.Images4 + "', " + carDTO.IsLostCard + ", '" + carDTO.Computer + "', '" + carDTO.Account + "', " +
        //        carDTO.CostBefore + ", '" + carDTO.DateUpdate + "', '" + carDTO.DateLostCard + "')";
        //    Database.ExcuNonQuery(sql);
        //}

        public static void Insert(CarDTO carDTO)
        {
            string sql = "insert into Car(ID, TimeStart, Digit, IDIn, IDOut, IDTicketMonth, IDPart, Images, Images2, Computer, Account, DateUpdate) values ('" + carDTO.Id + "', '" + carDTO.TimeStart + "', '" + carDTO.Digit
                + "', '" + carDTO.IdIn + "', '" + carDTO.IdOut + "', '" + carDTO.IdTicketMonth + "', '" + carDTO.IdPart + "', '" + carDTO.Images + "', '" + carDTO.Images2 + "', '" + carDTO.Computer + "', '" + carDTO.Account + "', '" + carDTO.DateUpdate + "')";
            Database.ExcuNonQuery(sql);
        }

        public static void UpdateCarIn(CarDTO carDTO)
        {
            string sql = "update [Car] set TimeStart ='" + carDTO.TimeStart + "', IDIn ='" + carDTO.IdIn + "', Digit ='" + carDTO.Digit + "', Images ='" + carDTO.Images + "', Images2 ='" + carDTO.Images2 + "', Computer ='" + carDTO.Computer + "', Account ='" + carDTO.Account + 
                "', DateUpdate ='" + carDTO.DateUpdate + "' where Identify =" + carDTO.Identify;
            Database.ExcuNonQuery(sql);
        }

        public static void UpdateCarOut(CarDTO carDTO)
        {
            string sql = "update [Car] set TimeEnd ='" + carDTO.TimeEnd + "', IDOut ='" + carDTO.IdOut + "', Cost =" + carDTO.Cost + ", Images3 ='" + carDTO.Images3 + "', Images4 ='" + carDTO.Images4 + "', DateUpdate ='" + carDTO.DateUpdate + "' where Identify =" + carDTO.Identify;
            Database.ExcuNonQuery(sql);
        }

        public static bool UpdateLostCard(CarDTO carDTO)
        {
            string sql = "update [Car] set TimeEnd ='" + carDTO.TimeEnd + "', IDOut ='" + carDTO.IdOut + "', Cost =" + carDTO.Cost + ", IsLostCard =" + carDTO.IsLostCard + ", DateUpdate ='" + carDTO.DateUpdate + "', DateLostCard ='" + carDTO.DateLostCard + "' where Identify =" + carDTO.Identify;
            string cardId = getIdByIdentify(carDTO.Identify);
            if (cardId != null)
            {
                CardDAO.UpdateIsUsing("0", cardId);
                CardDAO.UpdateDayUnlimit(carDTO.DateLostCard, cardId);
            }
            return Database.ExcuNonQuery(sql);
        }

        public static void UpdateDigit(string id, String digit, String image1, String image2)
        {
            int identify = GetLastIdentifyByID(id);
            if (identify != 0)
            {
                string sql = "update [Car] set Digit ='" + digit + "', Images ='" + image1 + "', Images2 ='" + image2 + "' where Identify =" + identify;
                Database.ExcuNonQuery(sql);
            }
        }

        public static bool DeleteLostCard(string cardId)
        {
            string sql = "delete from [Car] where ID = '" + cardId + "' and IsLostCard > 0";
            return Database.ExcuNonQuery(sql);
        }

        public static bool isCarIn(string id)
        {
            DataTable dt = GetCarByID(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                string IDOut = dt.Rows[0].Field<string>("IDOut");
                if (string.IsNullOrEmpty(IDOut)) {
                    return false;
                }
            }
            return true;
        }

        public static bool isCarOutByIdentify(int identify)
        {
            DataTable dt = GetCarByIdentify(identify);
            if (dt != null && dt.Rows.Count > 0)
            {
                string IDOut = dt.Rows[0].Field<string>("IDOut");
                if (!string.IsNullOrEmpty(IDOut))
                {
                    return true;
                }
            }
            return false;
        }

        public static string getIdByIdentify(int identify)
        {
            DataTable dt = GetCarByIdentify(identify);
            if (dt != null && dt.Rows.Count > 0)
            {
                string id = dt.Rows[0].Field<string>("ID");
                return id;
            }
            return null;
        }

        public static string GetDigitByID(string id)
        {
            DataTable dt = GetLastCarByID(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<string>("Digit");
            }
            else
            {
                return "";
            }
        }
    }
}

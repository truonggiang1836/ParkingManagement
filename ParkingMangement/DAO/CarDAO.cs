﻿using ParkingMangement.DTO;
using ParkingMangement.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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

        private static string sqlGetAllData = "select DISTINCT Car.Identify, SmartCard.Identify as SmartCardIdentify, Car.ID, Car.TimeStart, Car.TimeEnd, " +
            "Car.Digit, Car.IDIn, Car.IDOut, Car.IDTicketMonth, Car.IsLostCard, Car.Cost, Part.ID as PartID, Part.PartName, Part.Sign, Car.Computer, Car.Account, " +
            "Car.DateUpdate, Car.Images, Car.Images2, Car.Images3, Car.Images4 from [Car], [Part], [SmartCard] where Car.IDPart = Part.ID and SmartCard.ID = Car.ID";


        private static string sqlGetAllTicketMonthData = "select DISTINCT Car.Identify, SmartCard.Identify as SmartCardIdentify, Car.ID, Car.TimeStart, Car.TimeEnd, " +
            "Car.Digit, Part.PartName, TicketMonth.Company, TicketMonth.CustomerName from [Car], [Part], [TicketMonth], [SmartCard] " +
            "where Car.IDPart = Part.ID and TicketMonth.ID = Car.IDTicketMonth and SmartCard.ID = Car.ID";

        private static string sqlGetDataForCashManagement = "select Car.ID, Car.TimeStart, Car.TimeEnd, Car.Digit, Car.Cost, Car.CostBefore, " +
            "Car.IsLostCard, Car.Computer, UserCar.NameUser from [Car], [UserCar] where Car.Account = UserCar.UserID";

        private static string sqlQueryTicketMonth = " and Car.IDTicketMonth <> '' ";
        private static string sqlQueryTicketCommon= " and Car.IDTicketMonth = '' ";
        private static string sqlQueryXeTon = " and Car.IDOut = '' ";
        private static string sqlQueryMatThe = " and Car.IsLostCard > " + 0 + "";
        private static string sqlOrderByIdentifyDesc = " order by Car.Identify desc";
        private static string sqlOrderByIdentifyAsc = " order by Car.Identify asc";

        public static DataTable GetAllData()
        {
            string sql = sqlGetAllData + sqlOrderByIdentifyDesc;
            DataTable data = Database.ExcuQuery(sql);
            setUserNameForDataTable(data);
            return data;
        }

        public static DataTable GetDataRecently(int identify)
        {
            string sql = "select * from [Car] where Car.Identify > " + identify + sqlOrderByIdentifyAsc;
            DataTable data = Database.ExcuQuery(sql);
            return data;
        }

        public static DataTable GetAllDataForCashManagement()
        {
            string sql = sqlGetDataForCashManagement + sqlOrderByIdentifyDesc;
            DataTable data = Database.ExcuQuery(sql);
            return data;
        }

        public static DataTable GetAllTicketMonthData()
        {
            string sql = sqlGetAllTicketMonthData + sqlQueryTicketMonth + sqlOrderByIdentifyDesc;
            DataTable data = Database.ExcuQuery(sql);
            return data;
        }

        public static string sqlSearchData(CarDTO carDTO)
        {
            string sql = sqlGetAllData;
            sql += " and Car.TimeStart >= #" + carDTO.TimeStart.ToString(Constant.sDateTimeFormatForQuery) + "# and ((Car.TimeEnd <= #" + carDTO.TimeEnd.ToString(Constant.sDateTimeFormatForQuery) + "# and Car.IDOut <> '') or Car.IDOut = '')";
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
            sql += sqlOrderByIdentifyDesc;

            DataTable data = Database.ExcuQuery(sql);
            if (data != null)
            {
                setUserNameForDataTable(data);
            }
            return data;
        }

        public static DataTable searchAllDataWithoutSetUserName(CarDTO carDTO)
        {
            string sql = sqlSearchData(carDTO);
            sql += sqlOrderByIdentifyDesc;

            DataTable data = Database.ExcuQuery(sql);
            return data;
        }

        public static DataTable searchXeTon(CarDTO carDTO)
        {
            string sql = sqlSearchData(carDTO);
            sql += sqlQueryXeTon + sqlOrderByIdentifyDesc;

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
            sql += sqlQueryMatThe + sqlOrderByIdentifyDesc;

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
            sql += sqlOrderByIdentifyDesc;

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
                dataRow.SetField("TypeName", "____Tổng cộng");

                int countAllCarIn = GetCountCarInByTypeAndDate(startTime, endTime, null, false, userID) + GetCountCarInByTypeAndDate(startTime, endTime, null, true, userID);
                dataRow.SetField("CountCarIn", countAllCarIn);

                int countAllCarOut = GetCountCarOutByTypeAndDate(startTime, endTime, null, false, userID) + GetCountCarOutByTypeAndDate(startTime, endTime, null, true, userID);
                dataRow.SetField("CountCarOut", countAllCarOut);

                int countAllCarSurvive = countAllCarIn - countAllCarOut;
                dataRow.SetField("CountCarSurvive", countAllCarSurvive);

                int sumCost = GetCountCost(startTime, endTime, false, userID) + GetCountCost(startTime, endTime, true, userID);
                dataRow.SetField("SumCost", sumCost);
                data.Rows.Add(dataRow);
            }

            return data;
        }

        public static DataTable GetTotalCostByType(DateTime? startTime, DateTime? endTime, bool isTicketMonth, string userID)
        {
            string groupBySql = " group by Part.TypeID";
            string sql = "select Part.TypeID, sum(Car.Cost) as SumCost from [Car], [Part] where Car.IDPart = Part.ID";
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
                data.Columns.Add("TypeName", typeof(string));
                data.Columns["TypeName"].SetOrdinal(0);
                data.Columns.Add("CountCarIn", typeof(int));
                data.Columns["CountCarIn"].SetOrdinal(1);
                data.Columns.Add("CountCarOut", typeof(int));
                data.Columns["CountCarOut"].SetOrdinal(2);
                data.Columns.Add("CountCarSurvive", typeof(int));
                data.Columns["CountCarSurvive"].SetOrdinal(3);
                for (int row = 0; row < data.Rows.Count; row++)
                {
                    string typeID = data.Rows[row].Field<string>("TypeID");
                    string typeName = TypeDAO.GetTypeNameByTypeID(typeID);
                    data.Rows[row].SetField("TypeName", typeName);
                    int countCarIn = GetCountCarInByTypeAndDate(startTime, endTime, typeID, isTicketMonth, userID);
                    data.Rows[row].SetField("CountCarIn", countCarIn);
                    int countCarOut = GetCountCarOutByTypeAndDate(startTime, endTime, typeID, isTicketMonth, userID);
                    data.Rows[row].SetField("CountCarOut", countCarOut);
                    int countCarSurvive = countCarIn - countCarOut;
                    data.Rows[row].SetField("CountCarSurvive", countCarSurvive);
                }
            }


            // Tổng xe thường/tháng

            DataRow dataRow = data.NewRow();
            if (!isTicketMonth)
            {
                dataRow.SetField("TypeName", "___Tổng xe thường");
            } else
            {
                dataRow.SetField("TypeName", "___Tổng xe tháng");
            }

            int countAllCarIn = GetCountCarInByTypeAndDate(startTime, endTime, null, isTicketMonth, userID);
            dataRow.SetField("CountCarIn", countAllCarIn);

            int countAllCarOut = GetCountCarOutByTypeAndDate(startTime, endTime, null, isTicketMonth, userID);
            dataRow.SetField("CountCarOut", countAllCarOut);

            int countAllCarSurvive = countAllCarIn - countAllCarOut;
            dataRow.SetField("CountCarSurvive", countAllCarSurvive);

            int sumCost = GetCountCost(startTime, endTime, isTicketMonth, userID);
            string sumCostString = Util.formatNumberAsMoney(sumCost);
            dataRow.SetField("SumCost", sumCostString);
            data.Rows.Add(dataRow);

            return data;
        }

        public static DataTable GetListCarSurvive()
        {
            string groupBySql = " group by Part.TypeID";
            string sql = "select Part.TypeID from [Car], [Part] where Car.IDPart = Part.ID";
            sql += groupBySql;
            DataTable data = Database.ExcuQuery(sql);
            if (data != null)
            {
                data.Columns.Add("TypeName", typeof(Bitmap));
                data.Columns["TypeName"].SetOrdinal(0);
                data.Columns.Add("CountCarSurvive", typeof(int));
                data.Columns["CountCarSurvive"].SetOrdinal(1);
                data.Columns.Add("CountCarEmpty", typeof(string));
                data.Columns["CountCarEmpty"].SetOrdinal(2);
                for (int row = 0; row < data.Rows.Count; row++)
                {
                    string typeID = data.Rows[row].Field<string>("TypeID");
                    int countCarSurvive = GetCountCarSurvive(typeID);
                    data.Rows[row].SetField("CountCarSurvive", countCarSurvive);
                    Bitmap bitmap = new Bitmap(Properties.Resources.ic_bike_icon);
                    int countCarEmpty = 0;
                    if (typeID == TypeDTO.TYPE_BIKE)
                    {
                        bitmap = new Bitmap(Properties.Resources.ic_bike_icon);
                        countCarEmpty = ConfigDAO.GetBikeSpace() - countCarSurvive;
                    }
                    else
                    {
                        bitmap = new Bitmap(Properties.Resources.ic_car_icon);
                        countCarEmpty = ConfigDAO.GetCarSpace() - countCarSurvive;
                    }
                    data.Rows[row].SetField("TypeName", bitmap);
                    data.Rows[row].SetField("CountCarEmpty", countCarEmpty);
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

        public static int GetCountCarInByTypeAndDate(DateTime? startTime, DateTime? endTime, string typeID, bool isTicketMonth, string userID)
        {
            string sql = "select * from [Car], [Part] where Car.IDIn <> '' and Car.IDPart = Part.ID " + sqlQueryTicketCommon;
            if (isTicketMonth)
            {
                sql = "select * from [Car], [Part] where Car.IDIn <> '' and Car.IDPart = Part.ID " + sqlQueryTicketMonth;
            }
            if (typeID != null)
            {
                sql += " and Part.TypeID = '" + typeID + "'";
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

        public static int GetCountCarOutByTypeAndDate(DateTime? startTime, DateTime? endTime, string typeID, bool isTicketMonth, string userID)
        {
            string sql = "select * from [Car], [Part] where Car.IDOut <> '' and Car.IDPart = Part.ID " + sqlQueryTicketCommon;
            if (isTicketMonth)
            {
                sql = "select * from [Car], [Part] where Car.IDOut <> '' and Car.IDPart = Part.ID " + sqlQueryTicketMonth;
            }
            if (typeID != null)
            {
                sql += " and Part.TypeID = '" + typeID + "'";
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

        public static int GetCountCarSurvive(string typeID)
        {
            string sql = "select * from [Car], [Part] where Car.IDIn <> '' and Car.IDOut = '' and Car.IDPart = Part.ID ";
            if (typeID != null)
            {
                sql += " and Part.TypeID = '" + typeID + "'";
            }

            DataTable data = Database.ExcuQuery(sql);
            return data.Rows.Count;
        }

        public static int GetCountCarSurvive(string typeID, bool isTicketMonth)
        {
            string sql = "select * from[Car], [Part] where Car.IDIn <> '' and Car.IDOut = '' and Car.IDPart = Part.ID " + sqlQueryTicketCommon;
            if (isTicketMonth)
            {
                sql = "select * from[Car], [Part] where Car.IDIn <> '' and Car.IDOut = '' and Car.IDPart = Part.ID " + sqlQueryTicketMonth;
            }
            if (typeID != null)
            {
                sql += " and Part.TypeID = '" + typeID + "'";
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

        public static int GetLastIdentify()
        {
            string sql = "select * from [Car] order by Identify desc";
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

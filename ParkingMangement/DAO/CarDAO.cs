using ParkingMangement.DTO;
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

        private static string sqlGetAllData = "select Car.Identify, SmartCard.Identify as SmartCardIdentify, Car.ID, Car.TimeStart, Car.TimeEnd, Car.Digit, userA.NameUser as UserIn, " +
            "userB.NameUser as UserOut, Car.IDTicketMonth, Car.IsLostCard, Car.Cost, Part.ID as PartID, Part.PartName, Part.Sign, Car.Computer, userC.NameUser as Account, " +
            "Car.DateUpdate, Car.Images, Car.Images2, Car.Images3, Car.Images4 from Car left join Part on Car.IDPart = Part.ID left join SmartCard on SmartCard.ID = Car.ID " +
            "left join UserCar userA on Car.IDIn = userA.UserID left join UserCar userB on Car.IDOut = userB.UserID left join UserCar userC on Car.Account = userC.UserID where '0' = '0'";

        //private static string sqlGetAllDataForCallAPI = "select car.*, userA.NameUser as UserIn, " +
        //    "userB.NameUser as UserOut, Part.PartName, Part.Sign, userC.NameUser as Account " +
        //    " from Car car left join Part on car.IDPart = Part.ID " +
        //    "left join UserCar userA on car.IDIn = userA.UserID left join UserCar userB on car.IDOut = userB.UserID left join UserCar userC on car.Account = userC.UserID where '0' = '0'";

        private static string sqlGetAllDataInForCallAPI = "select car.*, SmartCard.Identify as SmartCardIdentify, userA.NameUser as UserIn, " +
            "userB.NameUser as UserOut, Part.PartName, Part.Sign, userC.NameUser as Account " +
            " from Car car left join Part on car.IDPart = Part.ID left join SmartCard on SmartCard.ID = car.ID " +
            "left join UserCar userA on car.IDIn = userA.UserID left join UserCar userB on car.IDOut = userB.UserID " +
            "left join UserCar userC on car.Account = userC.UserID right join WaitSyncCarIn on car.Identify = WaitSyncCarIn.Identify where '0' = '0'";

        private static string sqlGetAllDataOutForCallAPI = "select car.*, SmartCard.Identify as SmartCardIdentify, userA.NameUser as UserIn, " +
            "userB.NameUser as UserOut, Part.PartName, Part.Sign, userC.NameUser as Account " +
            " from Car car left join Part on car.IDPart = Part.ID left join SmartCard on SmartCard.ID = car.ID " +
            "left join UserCar userA on car.IDIn = userA.UserID left join UserCar userB on car.IDOut = userB.UserID " +
            "left join UserCar userC on car.Account = userC.UserID right join WaitSyncCarOut on car.Identify = WaitSyncCarOut.Identify where '0' = '0'";

        //private static string sqlGetFirstDataForCallAPI = "select top 1 car.*, userA.NameUser as UserIn, " +
        //    "userB.NameUser as UserOut, Part.PartName, Part.Sign, userC.NameUser as Account " +
        //    " from Car car left join Part on car.IDPart = Part.ID " +
        //    "left join UserCar userA on car.IDIn = userA.UserID left join UserCar userB on car.IDOut = userB.UserID left join UserCar userC on car.Account = userC.UserID where '0' = '0'";

        private static string sqlGetAllTicketMonthData = "select Car.Identify, SmartCard.Identify as SmartCardIdentify, Car.ID, Car.TimeStart, Car.TimeEnd, " +
            "Car.Digit, Part.PartName, TicketMonth.Company, TicketMonth.CustomerName from Car, Part, TicketMonth, SmartCard " +
            "where Car.IDPart = Part.ID and TicketMonth.ID = Car.IDTicketMonth and SmartCard.ID = Car.ID";

        private static string sqlGetDataForCashManagement = "select Car.ID, Car.TimeStart, Car.TimeEnd, Car.Digit, Car.Cost, Car.CostBefore, " +
            "Car.IsLostCard, Car.Computer, UserCar.NameUser from Car left join UserCar on Car.Account = UserCar.UserID where 0 = 0";

        private static string sqlQueryTicketMonth = " and Part.CardTypeID = " + CardTypeDTO.CARD_TYPE_TICKET_MONTH;
        private static string sqlQueryTicketCommon = " and Part.CardTypeID = " + CardTypeDTO.CARD_TYPE_TICKET_COMMON;
        private static string sqlQueryXeTon = " and Car.IDOut = '' ";
        private static string sqlQueryMatThe = " and Car.IsLostCard > " + 0 + "";
        private static string sqlOrderByIdentifyDesc = " order by Car.Identify desc";
        private static string sqlOrderByIdentifyAsc = " order by Car.Identify asc";

        public static DataTable GetAllData()
        {
            string sql = sqlGetAllData + sqlOrderByIdentifyDesc;
            DataTable data = Database.ExcuQuery(sql);
            return data;
        }

        public static DataTable GetDataInRecently()
        {
            string sql = sqlGetAllDataInForCallAPI + " order by car.Identify asc";
            DataTable data = Database.ExcuQuery(sql);
            return data;
        }

        public static DataTable GetDataOutRecently()
        {
            string sql = sqlGetAllDataOutForCallAPI + " order by car.Identify asc";
            DataTable data = Database.ExcuQuery(sql);
            return data;
        }

        //public static DataTable GetDataByIdentifyForAPI(int identify)
        //{
        //    string sql = sqlGetAllDataForCallAPI + " and car.Identify = " + identify;
        //    DataTable data = Database.ExcuQuery(sql);
        //    return data;
        //}

        //public static DataTable GetLastDataByIdForAPI(string id)
        //{
        //    string sql = sqlGetFirstDataForCallAPI + " and car.ID = '" + id + "' order by car.Identify desc";
        //    DataTable data = Database.ExcuQuery(sql);
        //    return data;
        //}

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
            sql += " and ((Car.TimeStart between '" + carDTO.TimeStart.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + carDTO.TimeEnd.ToString(Constant.sDateTimeFormatForQuery) + "')"
                + " or (Car.TimeEnd between '" + carDTO.TimeStart.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + carDTO.TimeEnd.ToString(Constant.sDateTimeFormatForQuery) + "' and Car.IDOut <> ''))";
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
            return data;
        }

        public static DataTable searchAllData(CarDTO carDTO, string userID, int ticketType)
        {
            string sql = sqlSearchData(carDTO);
            if (userID != null)
            {
                sql += " and (Car.IDIn = '" + userID + "' or Car.IDOut = '" + userID + "')";
            }
            if (ticketType == COMMON_TICKET)
            {
                sql += sqlQueryTicketCommon;
            } else if (ticketType == MONTH_TICKET)
            {
                sql += sqlQueryTicketMonth;
            }
            sql += sqlOrderByIdentifyDesc;

            DataTable data = Database.ExcuQuery(sql);
            return data;
        }

        public static DataTable searchXeTon(CarDTO carDTO)
        {
            string sql = sqlSearchData(carDTO);
            sql += sqlQueryXeTon + sqlOrderByIdentifyDesc;

            DataTable data = Database.ExcuQuery(sql);
            return data;
        }

        public static DataTable searchMatThe(CarDTO carDTO)
        {
            string sql = sqlSearchData(carDTO);
            sql += sqlQueryMatThe + sqlOrderByIdentifyDesc;

            DataTable data = Database.ExcuQuery(sql);
            return data;
        }

        public static DataTable searchTicketMonthData(CarDTO carDTO, TicketMonthDTO ticketMonthDTO)
        {
            string sql = sqlGetAllTicketMonthData + sqlQueryTicketMonth;
            sql += " and ((Car.TimeStart between '" + carDTO.TimeStart.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + carDTO.TimeEnd.ToString(Constant.sDateTimeFormatForQuery) + "')"
                + " or (Car.TimeEnd between '" + carDTO.TimeStart.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + carDTO.TimeEnd.ToString(Constant.sDateTimeFormatForQuery) + "' and Car.IDOut <> ''))";
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

        public static void updateImage()
        {
            string base64 = "";
            string sql = "update Car set Images =('" + base64 + "') where Identify = 1";
            Database.ExcuNonQuery(sql);
        }

        public static DataTable GetTotalCost(DateTime? startTime, DateTime? endTime, string userID, int ticketType)
        {
            DataTable data = new DataTable();
            DataTable commonData = GetTotalCostByType(startTime, endTime, false, userID);
            DataTable ticketData = GetTotalCostByType(startTime, endTime, true, userID);
            if (ticketType == ALL_TICKET || ticketType == COMMON_TICKET)
            {
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

                long countAllCarIn = 0;
                if (commonData.Rows.Count > 0)
                {
                    long countCarInCommonData = long.Parse(commonData.Rows[commonData.Rows.Count - 1]["CountCarIn"].ToString());
                    countAllCarIn += countCarInCommonData;
                }
                if (ticketData.Rows.Count > 0)
                {
                    long countCarInTicketData = long.Parse(ticketData.Rows[ticketData.Rows.Count - 1]["CountCarIn"].ToString());
                    countAllCarIn += countCarInTicketData;
                }
                dataRow.SetField("CountCarIn", countAllCarIn);


                long countAllCarOut = 0;
                if (commonData.Rows.Count > 0)
                {
                    long countCarOutCommonData = long.Parse(commonData.Rows[commonData.Rows.Count - 1]["CountCarOut"].ToString());
                    countAllCarOut += countCarOutCommonData;
                }
                if (ticketData.Rows.Count > 0)
                {
                    long countCarOutTicketData = long.Parse(ticketData.Rows[ticketData.Rows.Count - 1]["CountCarOut"].ToString());
                    countAllCarOut += countCarOutTicketData;
                }
                dataRow.SetField("CountCarOut", countAllCarOut);

                long countAllCarSurvive = countAllCarIn - countAllCarOut;
                dataRow.SetField("CountCarSurvive", countAllCarSurvive);

                long sumCost = 0;
                if (commonData.Rows.Count > 0)
                {
                    long sumCostCommonData = long.Parse(commonData.Rows[commonData.Rows.Count - 1]["SumCost"].ToString());
                    sumCost += sumCostCommonData;
                }
                if (ticketData.Rows.Count > 0)
                {
                    long sumCostTicketData = long.Parse(ticketData.Rows[ticketData.Rows.Count - 1]["SumCost"].ToString());
                    sumCost += sumCostTicketData;
                }
                dataRow.SetField("SumCost", sumCost);
                data.Rows.Add(dataRow);
            }

            return data;
        }

        public static DataTable GetTotalCostByType(DateTime? startTime, DateTime? endTime, bool isTicketMonth, string userID)
        {
            string groupBySql = " group by Car.IDPart";
            string sql = "select Car.IDPart, sum(cast(Car.Cost as bigint)) as SumCost from Car join Part on Car.IDPart = Part.ID";
            if (!isTicketMonth)
            {
                sql += sqlQueryTicketCommon;
            }
            else
            {
                sql += sqlQueryTicketMonth;
            }
            sql += "  where 0 = 0";

            if (startTime != null && endTime != null)
            {
                DateTime startTime1 = startTime ?? DateTime.Now;
                DateTime endTime1 = endTime ?? DateTime.Now;
                sql += " and ((Car.TimeStart between '" + startTime1.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + endTime1.ToString(Constant.sDateTimeFormatForQuery) + "')"
                + " or (Car.TimeEnd between '" + startTime1.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + endTime1.ToString(Constant.sDateTimeFormatForQuery) + "' and Car.IDOut <> ''))";
            }
            if (userID != null)
            {
                sql += " and (Car.IDIn = '" + userID + "' or Car.IDOut = '" + userID + "')";
            }
            sql += groupBySql;

            long countAllCarIn = 0;
            long countAllCarOut = 0;
            long sumCost = 0;
            DataTable data = Database.ExcuQuery(sql);
            if (data != null)
            {
                data.Columns.Add("PartName", typeof(string));
                data.Columns["PartName"].SetOrdinal(0);
                data.Columns.Add("CountCarIn", typeof(long));
                data.Columns["CountCarIn"].SetOrdinal(1);
                data.Columns.Add("CountCarOut", typeof(long));
                data.Columns["CountCarOut"].SetOrdinal(2);
                data.Columns.Add("CountCarSurvive", typeof(long));
                data.Columns["CountCarSurvive"].SetOrdinal(3);
                for (int row = 0; row < data.Rows.Count; row++)
                {
                    string partID = data.Rows[row].Field<string>("IDPart");
                    string partName = PartDAO.GetPartNameByPartID(partID);
                    data.Rows[row].SetField("PartName", partName);
                    long countCarIn = GetCountCarInByTypeAndDate(startTime, endTime, partID, isTicketMonth, userID);
                    data.Rows[row].SetField("CountCarIn", countCarIn);
                    long countCarOut = GetCountCarOutByTypeAndDate(startTime, endTime, partID, isTicketMonth, userID);
                    data.Rows[row].SetField("CountCarOut", countCarOut);
                    long countCarSurvive = countCarIn - countCarOut;
                    data.Rows[row].SetField("CountCarSurvive", countCarSurvive);
                    countAllCarIn += countCarIn;
                    countAllCarOut += countCarOut;
                    long cost = long.Parse(data.Rows[row]["SumCost"].ToString());
                    sumCost += cost;
                }
            }


            // Tổng xe thường/tháng

            DataRow dataRow = data.NewRow();
            if (!isTicketMonth)
            {
                dataRow.SetField("PartName", "___Tổng xe thường");
            }
            else
            {
                dataRow.SetField("PartName", "___Tổng xe tháng");
            }

            dataRow.SetField("CountCarIn", countAllCarIn);
            dataRow.SetField("CountCarOut", countAllCarOut);

            long countAllCarSurvive = countAllCarIn - countAllCarOut;
            dataRow.SetField("CountCarSurvive", countAllCarSurvive);

            //string sumCostString = Util.formatNumberAsMoney(sumCost);
            dataRow.SetField("SumCost", sumCost);
            data.Rows.Add(dataRow);

            return data;
        }

        public static DataTable GetListCarSurvive()
        {
            string groupBySql = " group by Part.TypeID";
            string sql = "select Part.TypeID from Car, Part where Car.IDPart = Part.ID";
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
            string sql = "select sum(Car.Cost) as SumCost from Car where Car.IDTicketMonth = ''";
            if (isTicketMonth)
            {
                sql = "select sum(Car.Cost) as SumCost from Car where Car.IDTicketMonth <> ''";
            }
            if (startTime != null && endTime != null)
            {
                DateTime startTime1 = startTime ?? DateTime.Now;
                DateTime endTime1 = endTime ?? DateTime.Now;
                sql += " and Car.TimeStart >= '" + startTime1.ToString(Constant.sDateTimeFormatForQuery) + "' and Car.TimeEnd <= '" + endTime1.ToString(Constant.sDateTimeFormatForQuery) + "'";
            }
            if (userID != null)
            {
                sql += " and (Car.IDIn = '" + userID + "' or Car.IDOut = '" + userID + "')";
            }

            return Database.ExcuValueQuery(sql);
        }

        public static long GetCountCarInByTypeAndDate(DateTime? startTime, DateTime? endTime, string partID, bool isTicketMonth, string userID)
        {
            string sql = "select count(Car.IDIn) from Car join Part on Car.IDPart = Part.ID";
            if (!isTicketMonth)
            {
                sql += sqlQueryTicketCommon;
            }
            else
            {
                sql += sqlQueryTicketMonth;
            }
            sql += " where Car.IDIn <> ''";
            if (partID != null)
            {
                sql += " and Car.IDPart = '" + partID + "'";
            }
            if (startTime != null && endTime != null)
            {
                DateTime startTime1 = startTime ?? DateTime.Now;
                DateTime endTime1 = endTime ?? DateTime.Now;
                sql += " and Car.TimeStart between '" + startTime1.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + endTime1.ToString(Constant.sDateTimeFormatForQuery) + "'";
            }
            if (userID != null)
            {
                sql += " and (Car.IDIn = '" + userID + "' or Car.IDOut = '" + userID + "')";
            }

            return Database.ExcuValueQuery(sql);
        }

        public static long GetCountCarOutByTypeAndDate(DateTime? startTime, DateTime? endTime, string partID, bool isTicketMonth, string userID)
        {
            string sql = "select count(Car.IDOut) from Car join Part on Car.IDPart = Part.ID";
            if (!isTicketMonth)
            {
                sql += sqlQueryTicketCommon;
            }
            else
            {
                sql += sqlQueryTicketMonth;
            }
            sql += " where Car.IDOut <> ''";
            if (partID != null)
            {
                sql += " and Car.IDPart = '" + partID + "'";
            }
            if (startTime != null && endTime != null)
            {
                DateTime startTime1 = startTime ?? DateTime.Now;
                DateTime endTime1 = endTime ?? DateTime.Now;
                sql += " and Car.TimeEnd between '" + startTime1.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + endTime1.ToString(Constant.sDateTimeFormatForQuery) + "'";
            }
            if (userID != null)
            {
                sql += " and (Car.IDIn = '" + userID + "' or Car.IDOut = '" + userID + "')";
            }

            return Database.ExcuValueQuery(sql);
        }

        public static int GetCountCarSurvive(string typeID)
        {
            string sql = "select count(Car.ID) from Car, Part where Car.IDIn <> '' and Car.IDOut = '' and Car.IDPart = Part.ID ";
            if (typeID != null)
            {
                sql += " and Part.TypeID = '" + typeID + "'";
            }

            return Database.ExcuValueQuery(sql);
        }

        public static int GetCountCarSurvive(string typeID, bool isTicketMonth)
        {
            string sql = "select count(Car.ID) fromCar, Part where Car.IDIn <> '' and Car.IDOut = '' and Car.IDPart = Part.ID " + sqlQueryTicketCommon;
            if (isTicketMonth)
            {
                sql = "select count(Car.ID) fromCar, Part where Car.IDIn <> '' and Car.IDOut = '' and Car.IDPart = Part.ID " + sqlQueryTicketMonth;
            }
            if (typeID != null)
            {
                sql += " and Part.TypeID = '" + typeID + "'";
            }

            return Database.ExcuValueQuery(sql);
        }

        public static DataTable GetCarByIdentify(int identify)
        {
            string sql = "select * from Car where Identify = " + identify + sqlOrderByIdentifyDesc;
            return Database.ExcuQuery(sql);
        }

        public static DataTable GetLastCarByID(string id)
        {
            string sql = "select top 1 * from Car where ID = '" + id + "'" + sqlOrderByIdentifyDesc;
            return Database.ExcuQuery(sql);
        }

        public static string GetLastCardID()
        {
            string sql = "select ID from Car order by Identify desc";
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
            string sql = "update Car set TimeStart ='" + carDTO.TimeStart + "', IDIn ='" + carDTO.IdIn + "', Digit ='" + carDTO.Digit + "', Images ='" + carDTO.Images + "', Images2 ='" + carDTO.Images2 + "', Computer ='" + carDTO.Computer + "', Account ='" + carDTO.Account +
                "', DateUpdate ='" + carDTO.DateUpdate + "' where Identify =" + carDTO.Identify;
            Database.ExcuNonQuery(sql);
        }

        public static void UpdateCarOut(CarDTO carDTO)
        {
            string sql = "update Car set TimeEnd ='" + carDTO.TimeEnd + "', IDOut ='" + carDTO.IdOut + "', Cost =" + carDTO.Cost + ", Images3 ='" + carDTO.Images3 + "', Images4 ='" + carDTO.Images4 + "', DateUpdate ='" + carDTO.DateUpdate + "' where Identify =" + carDTO.Identify;
            Database.ExcuNonQuery(sql);
        }

        public static bool UpdateLostCard(CarDTO carDTO)
        {
            string sql = "update Car set TimeEnd ='" + carDTO.TimeEnd + "', IDOut ='" + carDTO.IdOut + "', Cost =" + carDTO.Cost + ", IsLostCard =" + carDTO.IsLostCard + ", DateUpdate ='" + carDTO.DateUpdate + "', DateLostCard ='" + carDTO.DateLostCard + "' where Identify =" + carDTO.Identify;
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
                string sql = "update Car set Digit ='" + digit + "', Images ='" + image1 + "', Images2 ='" + image2 + "' where Identify =" + identify;
                Database.ExcuNonQuery(sql);
            }
        }

        public static bool DeleteLostCard(string cardId)
        {
            string sql = "delete from Car where ID = '" + cardId + "' and IsLostCard > 0";
            return Database.ExcuNonQuery(sql);
        }

        public static bool isCarIn(string id)
        {
            string sql = "select count(Car.ID) from Car where ID = '" + id + "'" + " and IDOut != ''";
            return Database.ExcuValueQuery(sql) == 0;
        }

        public static bool isCarOutByIdentify(int identify)
        {
            string sql = "select count(Car.ID) from Car where Identify = " + identify + " and IDOut != ''";
            return Database.ExcuValueQuery(sql) > 0;
        }

        public static string getIdByIdentify(int identify)
        {
            string sql = "select ID from Car where Identify = " + identify + " order by Identify desc";
            DataTable dt = Database.ExcuQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                string id = dt.Rows[0].Field<string>("ID");
                return id;
            }
            return null;
        }

        public static string GetDigitByID(string id)
        {
            string sql = "select Digit from Car where ID = '" + id + "'" + " order by Identify desc";
            DataTable dt = Database.ExcuQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<string>("Digit");
            }
            else
            {
                return "";
            }
        }

        public static int GetLastIdentifyByID(string id)
        {
            string sql = "select Identify from Car where ID = '" + id + "'" + " order by Identify desc";
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
            string sql = "select Identify from Car order by Identify desc";
            DataTable dt = Database.ExcuQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                int identify = dt.Rows[0].Field<int>("Identify");
                return identify;
            }
            return 0;
        }
    }
}

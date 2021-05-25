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
        public static Bitmap sBitmapBikeIcon;
        public static Bitmap sBitmapCarIcon;

        private static string sqlGetAllData = "select Car.Identify, SmartCard.Identify as SmartCardIdentify, Car.ID, Car.DigitIn, Car.DigitOut, Car.Digit, Part.ID as PartID, Part.PartName, Car.TimeStart, Car.TimeEnd, Car.Cost, userA.NameUser as UserIn, " +
            "userB.NameUser as UserOut, Car.IDTicketMonth, Car.IsLostCard, Car.Computer, userC.NameUser as Account, " +
            "Car.DateUpdate, Car.Images, Car.Images2, Car.Images3, Car.Images4 from Car left join Part on Car.IDPart = Part.ID inner join SmartCard on SmartCard.ID = Car.ID " +
            "left join UserCar userA on Car.IDIn = userA.UserID left join UserCar userB on Car.IDOut = userB.UserID left join UserCar userC on Car.Account = userC.UserID where '0' = '0'";

        //private static string sqlGetAllDataForCallAPI = "select car.*, userA.NameUser as UserIn, " +
        //    "userB.NameUser as UserOut, Part.PartName, Part.Sign, userC.NameUser as Account " +
        //    " from Car car left join Part on car.IDPart = Part.ID " +
        //    "left join UserCar userA on car.IDIn = userA.UserID left join UserCar userB on car.IDOut = userB.UserID left join UserCar userC on car.Account = userC.UserID where '0' = '0'";

        private static string sqlGetAllDataInForCallAPI = "select top 1 car.*, SmartCard.Identify as SmartCardIdentify, userA.NameUser as UserIn, " +
            "userB.NameUser as UserOut, Part.PartName, Part.Sign, userC.NameUser as Account " +
            " from Car car left join Part on car.IDPart = Part.ID inner join SmartCard on SmartCard.ID = car.ID " +
            "left join UserCar userA on car.IDIn = userA.UserID left join UserCar userB on car.IDOut = userB.UserID " +
            "left join UserCar userC on car.Account = userC.UserID join WaitSyncCarIn on car.Identify = WaitSyncCarIn.Identify where 0 = 0 ";

        private static string sqlGetAllDataOutForCallAPI = "select top 1 car.*, SmartCard.Identify as SmartCardIdentify, userA.NameUser as UserIn, " +
            "userB.NameUser as UserOut, Part.PartName, Part.Sign, userC.NameUser as Account " +
            " from Car car left join Part on car.IDPart = Part.ID inner join SmartCard on SmartCard.ID = car.ID " +
            "left join UserCar userA on car.IDIn = userA.UserID left join UserCar userB on car.IDOut = userB.UserID " +
            "left join UserCar userC on car.Account = userC.UserID join WaitSyncCarOut on car.Identify = WaitSyncCarOut.Identify where 0 = 0 ";

        private static string sqlGetAllDataForCallAPI = "select top 50 car.*, SmartCard.Identify as SmartCardIdentify, userA.NameUser as UserIn, " +
            "userB.NameUser as UserOut, Part.PartName, Part.Sign, userC.NameUser as Account " +
            " from Car car left join Part on car.IDPart = Part.ID inner join SmartCard on SmartCard.ID = car.ID " +
            "left join UserCar userA on car.IDIn = userA.UserID left join UserCar userB on car.IDOut = userB.UserID " +
            "left join UserCar userC on car.Account = userC.UserID where IsSync = 0";

        private static string sqlGetAllOldDataForCallAPI = "select top 50 car.*, SmartCard.Identify as SmartCardIdentify, userA.NameUser as UserIn, " +
            "userB.NameUser as UserOut, Part.PartName, Part.Sign, userC.NameUser as Account " +
            " from Car car left join Part on car.IDPart = Part.ID inner join SmartCard on SmartCard.ID = car.ID " +
            "left join UserCar userA on car.IDIn = userA.UserID left join UserCar userB on car.IDOut = userB.UserID " +
            "left join UserCar userC on car.Account = userC.UserID where IsSync = 0";

        //private static string sqlGetFirstDataForCallAPI = "select top 1 car.*, userA.NameUser as UserIn, " +
        //    "userB.NameUser as UserOut, Part.PartName, Part.Sign, userC.NameUser as Account " +
        //    " from Car car left join Part on car.IDPart = Part.ID " +
        //    "left join UserCar userA on car.IDIn = userA.UserID left join UserCar userB on car.IDOut = userB.UserID left join UserCar userC on car.Account = userC.UserID where '0' = '0'";

        private static string sqlGetAllTicketMonthData = "select Car.Identify, SmartCard.Identify as SmartCardIdentify, Car.ID, Car.TimeStart, Car.TimeEnd, " +
            "Car.Digit, Part.PartName, TicketMonth.Company, TicketMonth.Address, Car.Cost, TicketMonth.CustomerName from Car left join Part on Car.IDPart = Part.ID" +
            " inner join TicketMonth on TicketMonth.ID = Car.IDTicketMonth inner join SmartCard on SmartCard.ID = Car.ID where 0 = 0";

        private static string sqlGetDataForCashManagement = "select Car.ID, Car.TimeStart, Car.TimeEnd, Car.Digit, Car.Cost, Car.CostBefore, " +
            "Car.IsLostCard, Car.Computer, UserCar.NameUser from Car left join UserCar on Car.Account = UserCar.UserID where 0 = 0";

        private static string sqlQueryTicketMonth = " and Part.CardTypeID = " + CardTypeDTO.CARD_TYPE_TICKET_MONTH;
        private static string sqlQueryTicketCommon = " and Part.CardTypeID = " + CardTypeDTO.CARD_TYPE_TICKET_COMMON;
        private static string sqlQueryXeTon = " and Car.IDOut = '' ";
        private static string sqlQueryMatThe = " and Car.IsLostCard > " + 0 + "";
        private static string sqlOrderByIdentifyDesc = " order by Car.Identify desc";
        private static string sqlOrderTimeStartDesc = " order by Car.TimeStart desc";

        public static DataTable GetAllData()
        {
            string sql = sqlGetAllData + sqlOrderTimeStartDesc;
            DataTable data = (new Database()).ExcuQuery(sql);
            return data;
        }

        public static DataTable GetAllDataForSync()
        {
            string sql = sqlGetAllDataForCallAPI;
            return (new Database()).ExcuQueryNoErrorMessage(sql);
        }

        public static void UpdateIsSync(string listIdentify)
        {
            string sql = "update Car set IsSync = 1 where Identify in " + listIdentify;
            (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static DataTable GetDataInRecentlyForSync()
        {
            string sql = sqlGetAllDataInForCallAPI + " order by car.Identify asc";
            DataTable data = (new Database()).ExcuQueryNoErrorMessage(sql);
            return data;
        }

        public static DataTable GetDataOutRecentlyForSync()
        {
            string sql = sqlGetAllDataOutForCallAPI + " order by car.Identify asc";
            DataTable data = (new Database()).ExcuQueryNoErrorMessage(sql);
            return data;
        }

        public static DataTable GetDataForSync()
        {
            string sql = sqlGetAllOldDataForCallAPI + " order by car.Identify asc";
            DataTable data = (new Database()).ExcuQuery(sql);
            return data;
        }

        //public static DataTable GetDataByIdentifyForAPI(int identify)
        //{
        //    string sql = sqlGetAllDataForCallAPI + " and car.Identify = " + identify;
        //    DataTable data = (new Database()).ExcuQuery(sql);
        //    return data;
        //}

        //public static DataTable GetLastDataByIdForAPI(string id)
        //{
        //    string sql = sqlGetFirstDataForCallAPI + " and car.ID = '" + id + "' order by car.Identify desc";
        //    DataTable data = (new Database()).ExcuQuery(sql);
        //    return data;
        //}

        public static DataTable GetAllDataForCashManagement()
        {
            string sql = sqlGetDataForCashManagement + sqlOrderTimeStartDesc;
            DataTable data = (new Database()).ExcuQuery(sql);
            return data;
        }

        public static DataTable GetAllTicketMonthData()
        {
            string sql = sqlGetAllTicketMonthData + sqlQueryTicketMonth + sqlOrderByIdentifyDesc;
            DataTable data = (new Database()).ExcuQuery(sql);
            return data;
        }

        public static string sqlSearchData(CarDTO carDTO)
        {
            string sql = sqlGetAllData;
            if (carDTO != null)
            {
                sql += " and (((Car.TimeStart between '" + carDTO.TimeStart.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + carDTO.TimeEnd.ToString(Constant.sDateTimeFormatForQuery) + "') and Car.IDOut = '')"
                + " or (Car.TimeEnd between '" + carDTO.TimeStart.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + carDTO.TimeEnd.ToString(Constant.sDateTimeFormatForQuery) + "'))";
                if (!string.IsNullOrEmpty(carDTO.IdPart))
                {
                    sql += " and Car.IDPart like '" + carDTO.IdPart + "'";
                }
                if (carDTO.CardIdentify != "")
                {
                    sql += " and SmartCard.Identify like '%" + carDTO.CardIdentify + "%'";
                }
                if (!string.IsNullOrEmpty(carDTO.Digit))
                {
                    sql += " and Car.Digit like '%" + carDTO.Digit + "%' or Car.DigitIn like '%" + carDTO.Digit + "%' or Car.DigitOut like '%" + carDTO.Digit + "%'";
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
            }
            
            return sql;
        }

        public static string sqlSearchDataThongKeDoanhThu(CarDTO carDTO)
        {
            string sql = sqlGetAllData;
            sql += " and (Car.TimeEnd between '" + carDTO.TimeStart.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + carDTO.TimeEnd.ToString(Constant.sDateTimeFormatForQuery) + "' and Car.IDOut <> '')";
            if (!string.IsNullOrEmpty(carDTO.IdPart))
            {
                sql += " and Car.IDPart like '" + carDTO.IdPart + "'";
            }
            if (carDTO.CardIdentify != "")
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
            sql += sqlOrderTimeStartDesc;

            DataTable data = (new Database()).ExcuQuery(sql);
            return data;
        }

        public static DataTable searchAllData(CarDTO carDTO, string userInId, string userOutId, int ticketType)
        {
            string sql = sqlSearchData(carDTO);
            if (userInId != null)
            {
                sql += " and Car.IDIn = '" + userInId + "'";
            }
            if (userOutId != null)
            {
                sql += " and Car.IDOut = '" + userOutId + "'";
            }
            if (ticketType == COMMON_TICKET)
            {
                sql += sqlQueryTicketCommon;
            } else if (ticketType == MONTH_TICKET)
            {
                sql += sqlQueryTicketMonth;
            }
            sql += sqlOrderTimeStartDesc;

            DataTable data = (new Database()).ExcuQuery(sql);
            return data;
        }

        public static DataTable searchAllDataThongKeDoanhThu(CarDTO carDTO, string userInId, string userOutId, int ticketType)
        {
            string sql = sqlSearchDataThongKeDoanhThu(carDTO);
            if (userInId != null)
            {
                sql += " and Car.IDIn = '" + userInId + "'";
            }
            if (userOutId != null)
            {
                sql += " and Car.IDOut = '" + userOutId + "'";
            }
            if (ticketType == COMMON_TICKET)
            {
                sql += sqlQueryTicketCommon;
            }
            else if (ticketType == MONTH_TICKET)
            {
                sql += sqlQueryTicketMonth;
            }
            sql += sqlOrderByIdentifyDesc;

            DataTable data = (new Database()).ExcuQuery(sql);
            return data;
        }

        public static DataTable searchDataThongKeDoanhThu(CarDTO carDTO, string userID, int ticketType)
        {
            string sql = sqlSearchData(carDTO);
            if (userID != null)
            {
                sql += " and (Car.IDIn = '" + userID + "' or Car.IDOut = '" + userID + "')";
            }
            if (ticketType == COMMON_TICKET)
            {
                sql += sqlQueryTicketCommon;
            }
            else if (ticketType == MONTH_TICKET)
            {
                sql += sqlQueryTicketMonth;
            }
            sql += sqlOrderByIdentifyDesc;

            DataTable data = (new Database()).ExcuQuery(sql);
            return data;
        }

        public static DataTable searchXeTon(CarDTO carDTO)
        {
            string sql = sqlSearchData(carDTO);
            sql += sqlQueryXeTon + sqlOrderTimeStartDesc;

            DataTable data = (new Database()).ExcuQuery(sql);
            return data;
        }

        public static DataTable searchMatThe(CarDTO carDTO)
        {
            string sql = sqlSearchData(carDTO);
            sql += sqlQueryMatThe + sqlOrderTimeStartDesc;

            DataTable data = (new Database()).ExcuQuery(sql);
            return data;
        }

        public static DataTable searchTicketMonthData(CarDTO carDTO, TicketMonthDTO ticketMonthDTO)
        {
            string sql = sqlGetAllTicketMonthData + sqlQueryTicketMonth;
            sql += " and ((Car.TimeStart between '" + carDTO.TimeStart.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + carDTO.TimeEnd.ToString(Constant.sDateTimeFormatForQuery) + "' and Car.IDOut = '')"
                + " or (Car.TimeEnd between '" + carDTO.TimeStart.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + carDTO.TimeEnd.ToString(Constant.sDateTimeFormatForQuery) + "'))";
            if (!string.IsNullOrEmpty(ticketMonthDTO.CustomerName))
            {
                sql += " and TicketMonth.CustomerName like '%" + ticketMonthDTO.CustomerName + "%'";
            }
            if (!string.IsNullOrEmpty(ticketMonthDTO.Company))
            {
                sql += " and TicketMonth.Company like '%" + ticketMonthDTO.Company + "%'";
            }
            sql += sqlOrderByIdentifyDesc;

            DataTable data = (new Database()).ExcuQuery(sql);
            return data;
        }

        public static void updateImage()
        {
            string base64 = "";
            string sql = "update Car set Images =('" + base64 + "') where Identify = 1";
            (new Database()).ExcuNonQuery(sql);
        }

        public static DataTable GetTotalCost(DateTime? startTime, DateTime? endTime, string userInID, string userOutID, int ticketType)
        {
            DataTable data = new DataTable();
            DataTable commonData = GetTotalCostByType(startTime, endTime, false, userInID, userOutID);
            DataTable ticketData = GetTotalCostByType(startTime, endTime, true, userInID, userOutID);
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
                    long countCarInCommonData = 0;
                    long.TryParse(commonData.Rows[commonData.Rows.Count - 1]["CountCarIn"].ToString(), out countCarInCommonData);
                    countAllCarIn += countCarInCommonData;
                }
                if (ticketData.Rows.Count > 0)
                {
                    long countCarInTicketData = 0;
                    long.TryParse(ticketData.Rows[ticketData.Rows.Count - 1]["CountCarIn"].ToString(), out countCarInTicketData);
                    countAllCarIn += countCarInTicketData;
                }
                dataRow.SetField("CountCarIn", countAllCarIn);


                long countAllCarOut = 0;
                if (commonData.Rows.Count > 0)
                {
                    long countCarOutCommonData = 0;
                    long.TryParse(commonData.Rows[commonData.Rows.Count - 1]["CountCarOut"].ToString(), out countCarOutCommonData);
                    countAllCarOut += countCarOutCommonData;
                }
                if (ticketData.Rows.Count > 0)
                {
                    long countCarOutTicketData = 0;
                    long.TryParse(ticketData.Rows[ticketData.Rows.Count - 1]["CountCarOut"].ToString(), out countCarOutTicketData);
                    countAllCarOut += countCarOutTicketData;
                }
                dataRow.SetField("CountCarOut", countAllCarOut);

                long countAllCarSurvive = 0;
                if (commonData.Rows.Count > 0)
                {
                    long countCarSurviveCommonData = 0;
                    long.TryParse(commonData.Rows[commonData.Rows.Count - 1]["CountCarSurvive"].ToString(), out countCarSurviveCommonData);
                    countAllCarSurvive += countCarSurviveCommonData;
                }
                if (ticketData.Rows.Count > 0)
                {
                    long countCarSurviveTicketData = 0;
                    long.TryParse(ticketData.Rows[ticketData.Rows.Count - 1]["CountCarSurvive"].ToString(), out countCarSurviveTicketData);
                    countAllCarSurvive += countCarSurviveTicketData;
                }
                dataRow.SetField("CountCarSurvive", countAllCarSurvive);

                long countAllCar = 0;
                if (commonData.Rows.Count > 0)
                {
                    long countCarCommonData = 0;
                    long.TryParse(commonData.Rows[commonData.Rows.Count - 1]["CountCar"].ToString(), out countCarCommonData);
                    countAllCar += countCarCommonData;
                }
                if (ticketData.Rows.Count > 0)
                {
                    long countCarTicketData = 0;
                    long.TryParse(ticketData.Rows[ticketData.Rows.Count - 1]["CountCar"].ToString(), out countCarTicketData);
                    countAllCar += countCarTicketData;
                }
                dataRow.SetField("CountCar", countAllCar);

                long sumCost = 0;
                if (commonData.Rows.Count > 0)
                {
                    long sumCostCommonData = 0;
                    long.TryParse(commonData.Rows[commonData.Rows.Count - 1]["SumCost"].ToString().Replace(".", ""), out sumCostCommonData);
                    sumCost += sumCostCommonData;
                }
                if (ticketData.Rows.Count > 0)
                {
                    long sumCostTicketData = 0;
                    long.TryParse(ticketData.Rows[ticketData.Rows.Count - 1]["SumCost"].ToString().Replace(".", ""), out sumCostTicketData);
                    sumCost += sumCostTicketData;
                }
                dataRow.SetField("SumCost", Util.formatNumberAsMoney(sumCost));
                data.Rows.Add(dataRow);
            }

            return data;
        }

        public static DataTable GetTotalCostByType(DateTime? startTime, DateTime? endTime, bool isTicketMonth, string userInID, string userOutID)
        {
            string sql = "select Part.ID as IDPart from Part where 0 = 0";
            if (isTicketMonth)
            {
                sql += " and Part.CardTypeID = 2";
            } else
            {
                sql += " and Part.CardTypeID = 1";
            }
            long countAllCarIn = 0;
            long countAllCarOut = 0;
            long countAllCarSurvive = 0;
            long countAllCar = 0;
            long sumCost = 0;
            DataTable data = (new Database()).ExcuQuery(sql);
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
                data.Columns.Add("CountCar", typeof(long));
                data.Columns["CountCar"].SetOrdinal(4);
                data.Columns.Add("SumCost", typeof(string));
                data.Columns["SumCost"].SetOrdinal(5);
                for (int row = 0; row < data.Rows.Count; row++)
                {
                    string partID = data.Rows[row].Field<string>("IDPart");
                    string partName = PartDAO.GetPartNameByPartID(partID);
                    data.Rows[row].SetField("PartName", partName);
                    long countCarIn = GetCountCarInByTypeAndDate(startTime, endTime, partID, isTicketMonth, userInID);
                    data.Rows[row].SetField("CountCarIn", countCarIn);
                    long countCarOut = GetCountCarOutByTypeAndDate(startTime, endTime, partID, isTicketMonth, userOutID);
                    data.Rows[row].SetField("CountCarOut", countCarOut);
                    long countCarSurvive = GetCountCarSurviveByTypeAndDate(startTime, endTime, partID, isTicketMonth, userInID);
                    data.Rows[row].SetField("CountCarSurvive", countCarSurvive);
                    long countCar = GetCountTicketMonthCarByTypeAndDate(startTime, endTime, partID);
                    data.Rows[row].SetField("CountCar", countCar);
                    long countCost = GetCountCostByTypeAndDate(startTime, endTime, partID, isTicketMonth, userInID, userOutID);
                    countCost += GetCountTicketMonthCostByTypeAndDate(startTime, endTime, partID);
                    data.Rows[row].SetField("SumCost", Util.formatNumberAsMoney(countCost));
                    countAllCarIn += countCarIn;
                    countAllCarOut += countCarOut;
                    countAllCarSurvive += countCarSurvive;
                    countAllCar += countCar;
                    sumCost += countCost;
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
            dataRow.SetField("CountCarSurvive", countAllCarSurvive);
            dataRow.SetField("CountCar", countAllCar);

            dataRow.SetField("SumCost", Util.formatNumberAsMoney(sumCost));
            data.Rows.Add(dataRow);

            return data;
        }

        public static DataTable GetTotalCostForSyncToWeb(DateTime? startTime, DateTime? endTime, string userOutID)
        {
            DataTable data = new DataTable();
            DataTable commonData = GetTotalCostByTypeForSyncToWeb(startTime, endTime, false, userOutID);
            DataTable ticketData = GetTotalCostByTypeForSyncToWeb(startTime, endTime, true, userOutID);
            data.Merge(commonData);
            data.Merge(ticketData);

            // Tổng xe

            long countAllCarIn = 0;
            if (commonData.Rows.Count > 0)
            {
                long countCarInCommonData = 0;
                long.TryParse(commonData.Rows[commonData.Rows.Count - 1]["CountCarIn"].ToString(), out countCarInCommonData);
                countAllCarIn += countCarInCommonData;
            }
            if (ticketData.Rows.Count > 0)
            {
                long countCarInTicketData = 0;
                long.TryParse(ticketData.Rows[ticketData.Rows.Count - 1]["CountCarIn"].ToString(), out countCarInTicketData);
                countAllCarIn += countCarInTicketData;
            }

            long countAllCarOut = 0;
            if (commonData.Rows.Count > 0)
            {
                long countCarOutCommonData = 0;
                long.TryParse(commonData.Rows[commonData.Rows.Count - 1]["CountCarOut"].ToString(), out countCarOutCommonData);
                countAllCarOut += countCarOutCommonData;
            }
            if (ticketData.Rows.Count > 0)
            {
                long countCarOutTicketData = 0;
                long.TryParse(ticketData.Rows[ticketData.Rows.Count - 1]["CountCarOut"].ToString(), out countCarOutTicketData);
                countAllCarOut += countCarOutTicketData;
            }

            long countAllCarSurvive = 0;
            if (commonData.Rows.Count > 0)
            {
                long countCarSurviveCommonData = 0;
                long.TryParse(commonData.Rows[commonData.Rows.Count - 1]["CountCarSurvive"].ToString(), out countCarSurviveCommonData);
                countAllCarSurvive += countCarSurviveCommonData;
            }
            if (ticketData.Rows.Count > 0)
            {
                long countCarSurviveTicketData = 0;
                long.TryParse(ticketData.Rows[ticketData.Rows.Count - 1]["CountCarSurvive"].ToString(), out countCarSurviveTicketData);
                countAllCarSurvive += countCarSurviveTicketData;
            }

            long sumCost = 0;
            if (commonData.Rows.Count > 0)
            {
                long sumCostCommonData = 0;
                long.TryParse(commonData.Rows[commonData.Rows.Count - 1]["SumCost"].ToString().Replace(".", ""), out sumCostCommonData);
                sumCost += sumCostCommonData;
            }
            if (ticketData.Rows.Count > 0)
            {
                long sumCostTicketData = 0;
                long.TryParse(ticketData.Rows[ticketData.Rows.Count - 1]["SumCost"].ToString().Replace(".", ""), out sumCostTicketData);
                sumCost += sumCostTicketData;
            }

            DataRow dataRow = data.NewRow();
            dataRow.SetField("PartSign", "TotalData");
            dataRow.SetField("CountCarIn", countAllCarIn);
            dataRow.SetField("CountCarOut", countAllCarOut);
            dataRow.SetField("CountCarSurvive", countAllCarSurvive);

            dataRow.SetField("SumCost", sumCost);
            data.Rows.Add(dataRow);

            return data;
        }

        public static DataTable GetTotalCostByTypeForSyncToWeb(DateTime? startTime, DateTime? endTime, bool isTicketMonth, string userID)
        {
            string sql = "select Part.ID as IDPart from Part where 0 = 0";
            if (isTicketMonth)
            {
                sql += " and Part.CardTypeID = 2";
            }
            else
            {
                sql += " and Part.CardTypeID = 1";
            }
            long countAllCarIn = 0;
            long countAllCarOut = 0;
            long countAllCarSurvive = 0;
            long sumCost = 0;
            DataTable data = (new Database()).ExcuQuery(sql);
            if (data != null)
            {
                data.Columns.Add("PartSign", typeof(string));
                data.Columns["PartSign"].SetOrdinal(0);
                data.Columns.Add("CountCarIn", typeof(long));
                data.Columns["CountCarIn"].SetOrdinal(1);
                data.Columns.Add("CountCarOut", typeof(long));
                data.Columns["CountCarOut"].SetOrdinal(2);
                data.Columns.Add("CountCarSurvive", typeof(long));
                data.Columns["CountCarSurvive"].SetOrdinal(3);
                data.Columns.Add("SumCost", typeof(long));
                data.Columns["SumCost"].SetOrdinal(4);
                for (int row = 0; row < data.Rows.Count; row++)
                {
                    string partID = data.Rows[row].Field<string>("IDPart");
                    string partSign = PartDAO.GetPartSignByPartID(partID);
                    data.Rows[row].SetField("PartSign", partSign);
                    long countCarIn = GetCountCarInByTypeAndDate(startTime, endTime, partID, isTicketMonth, userID);
                    data.Rows[row].SetField("CountCarIn", countCarIn);
                    long countCarOut = GetCountCarOutByTypeAndDate(startTime, endTime, partID, isTicketMonth, userID);
                    data.Rows[row].SetField("CountCarOut", countCarOut);
                    long countCarSurvive = GetCountCarSurviveByTypeAndDate(startTime, endTime, partID, isTicketMonth, userID);
                    data.Rows[row].SetField("CountCarSurvive", countCarSurvive);
                    long countCost = GetCountCostByTypeAndDate(startTime, endTime, partID, isTicketMonth, null, userID);
                    countCost += GetCountTicketMonthCostByTypeAndDate(startTime, endTime, partID);
                    data.Rows[row].SetField("SumCost", countCost);
                    countAllCarIn += countCarIn;
                    countAllCarOut += countCarOut;
                    countAllCarSurvive += countCarSurvive;
                    sumCost += countCost;
                }
            }

            // Tổng xe thường/tháng

            DataRow dataRow = data.NewRow();
            if (!isTicketMonth)
            {
                dataRow.SetField("PartSign", "___Tong xe luot");
            }
            else
            {
                dataRow.SetField("PartSign", "___Tong xe thang");
            }

            dataRow.SetField("CountCarIn", countAllCarIn);
            dataRow.SetField("CountCarOut", countAllCarOut);
            dataRow.SetField("CountCarSurvive", countAllCarSurvive);

            dataRow.SetField("SumCost", sumCost);
            data.Rows.Add(dataRow);          

            return data;
        }



        public static DataTable GetListCarSurvive()
        {
            string groupBySql = " group by Part.TypeID";
            string sql = "select Part.TypeID from Part inner join Car on Car.IDPart = Part.ID where 0 = 0";
            sql += groupBySql;
            DataTable data = (new Database()).ExcuQueryNoErrorMessage(sql);
            if (data != null)
            {
                data.Columns.Add("TypeName", typeof(Bitmap));
                data.Columns["TypeName"].SetOrdinal(0);
                data.Columns.Add("CountCarSurvive", typeof(int));
                data.Columns["CountCarSurvive"].SetOrdinal(1);
                data.Columns.Add("CountCarEmpty", typeof(string));
                data.Columns["CountCarEmpty"].SetOrdinal(2);

                if (sBitmapBikeIcon == null)
                {
                    sBitmapBikeIcon = new Bitmap(Properties.Resources.ic_bike_icon);
                }
                if (sBitmapCarIcon == null)
                {
                    sBitmapCarIcon = new Bitmap(Properties.Resources.ic_car_icon);
                }
                for (int row = 0; row < data.Rows.Count; row++)
                {
                    string typeID = data.Rows[row].Field<string>("TypeID");
                    int countCarSurvive;
                    int countCarEmpty;
                    Bitmap bitmap;
                    string exceptPartSign = null;

                    if (typeID == TypeDTO.TYPE_BIKE)
                    {
                        bitmap = sBitmapBikeIcon;                      
                        if (Util.getConfigFile().projectId.Equals(Constant.API_KEY_GREEN_HILLS))
                        {
                            exceptPartSign = "XeMayLuotTrenG";
                        }

                        countCarSurvive = GetCountCarSurvive(typeID, exceptPartSign);
                        countCarEmpty = ConfigDAO.GetBikeSpace(ConfigDAO.GetConfig()) - countCarSurvive;
                    }
                    else
                    {
                        bitmap = sBitmapCarIcon;
                        if (Util.getConfigFile().projectId.Equals(Constant.API_KEY_GREEN_HILLS))
                        {
                            exceptPartSign = "OTOLuotTrenG";
                        }

                        countCarSurvive = GetCountCarSurvive(typeID, exceptPartSign);
                        countCarEmpty = ConfigDAO.GetCarSpace(ConfigDAO.GetConfig()) - countCarSurvive;
                    }
                    if (countCarEmpty < 0)
                    {
                        countCarEmpty = 0;
                    }
                    data.Rows[row].SetField("TypeName", bitmap);                   
                    data.Rows[row].SetField("CountCarSurvive", countCarSurvive);
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

            return (new Database()).ExcuValueQuery(sql);
        }

        public static long GetCountCostByTypeAndDate(DateTime? startTime, DateTime? endTime, string partID, bool? isTicketMonth, string userInID, string userOutID)
        {
            string sql = "select sum(cast(Car.Cost as bigint)) as SumCost from Car join Part on Car.IDPart = Part.ID";
            if (isTicketMonth == false)
            {
                sql += sqlQueryTicketCommon;
            }
            else if (isTicketMonth == true)
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
                sql += " and Car.TimeEnd between '" + startTime1.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + endTime1.ToString(Constant.sDateTimeFormatForQuery) + "'";
            }
            if (userInID != null)
            {
                sql += " and Car.IDIn = '" + userInID + "'";
            }
            if (userOutID != null)
            {
                sql += " and Car.IDOut = '" + userOutID + "'";
            }

            return (new Database()).ExcuValueQuery(sql);
        }

        public static long GetCountTicketMonthCostByTypeAndDate(DateTime? startTime, DateTime? endTime, string partID)
        {
            string sql = "select sum(cast(ReceiptLogDetail.Cost as bigint)) as SumCost from ReceiptLogDetail join Part on ReceiptLogDetail.PartID = Part.ID";
            sql += sqlQueryTicketMonth;
            
            if (partID != null)
            {
                sql += " and ReceiptLogDetail.PartID = '" + partID + "'";
            }
            if (startTime != null && endTime != null)
            {
                DateTime startTime1 = startTime ?? DateTime.Now;
                DateTime endTime1 = endTime ?? DateTime.Now;
                sql += " and ReceiptLogDetail.PrintDate between '" + startTime1.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + endTime1.ToString(Constant.sDateTimeFormatForQuery) + "'";
            }

            return (new Database()).ExcuValueQuery(sql);
        }

        public static long GetCountTicketMonthCarByTypeAndDate(DateTime? startTime, DateTime? endTime, string partID)
        {
            string sql = "select COUNT(DISTINCT ReceiptLogDetail.CardID) as CountCar from ReceiptLogDetail join Part on ReceiptLogDetail.PartID = Part.ID";
            sql += sqlQueryTicketMonth;

            if (partID != null)
            {
                sql += " and ReceiptLogDetail.PartID = '" + partID + "'";
            }
            if (startTime != null && endTime != null)
            {
                DateTime startTime1 = startTime ?? DateTime.Now;
                DateTime endTime1 = endTime ?? DateTime.Now;
                sql += " and ReceiptLogDetail.PrintDate between '" + startTime1.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + endTime1.ToString(Constant.sDateTimeFormatForQuery) + "'";
            }

            return (new Database()).ExcuValueQuery(sql);
        }

        public static long GetCountCarInByTypeAndDate(DateTime? startTime, DateTime? endTime, string partID, bool? isTicketMonth, string userInID)
        {
            string sql = "select count(Car.IDIn) from Car join Part on Car.IDPart = Part.ID";
            if (isTicketMonth == false)
            {
                sql += sqlQueryTicketCommon;
            }
            else if (isTicketMonth == true)
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
            if (userInID != null)
            {
                sql += " and Car.IDIn = '" + userInID + "'";
            }

            return (new Database()).ExcuValueQuery(sql);
        }

        public static long GetCountCarOutByTypeAndDate(DateTime? startTime, DateTime? endTime, string partID, bool? isTicketMonth, string userOutID)
        {
            string sql = "select count(Car.IDOut) from Car join Part on Car.IDPart = Part.ID";
            if (isTicketMonth == false)
            {
                sql += sqlQueryTicketCommon;
            }
            else if (isTicketMonth == true)
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
            if (userOutID != null)
            {
                sql += " and Car.IDOut = '" + userOutID + "'";
            }

            return (new Database()).ExcuValueQuery(sql);
        }

        public static long GetCountCarSurviveByTypeAndDate(DateTime? startTime, DateTime? endTime, string partID, bool? isTicketMonth, string userInID)
        {
            string sql = "select count(DISTINCT(Car.ID)) from Car join Part on Car.IDPart = Part.ID inner join SmartCard on SmartCard.ID = Car.ID";
            if (isTicketMonth == false)
            {
                sql += sqlQueryTicketCommon;
            }
            else if (isTicketMonth == true)
            {
                sql += sqlQueryTicketMonth;
            }
            if (startTime != null && endTime != null)
            {
                DateTime startTime1 = startTime ?? DateTime.Now;
                DateTime endTime1 = endTime ?? DateTime.Now;
                sql += " where (Car.TimeStart <= '" + endTime1.ToString(Constant.sDateTimeFormatForQuery) + "' and (Car.IDOut = '' or Car.TimeEnd > '" + endTime1.ToString(Constant.sDateTimeFormatForQuery) + "'))";
            }
            else
            {
                sql += " where Car.IDOut = ''";
            }
            if (partID != null)
            {
                sql += " and Car.IDPart = '" + partID + "'";
            }
            if (userInID != null)
            {
                sql += " and Car.IDIn = '" + userInID + "'";
            }

            return (new Database()).ExcuValueQuery(sql);
        }

        public static int GetCountCarSurvive(string typeID, string exceptPartSign)
        {
            string sql = "select count(DISTINCT(Car.ID)) from Part inner join Car on Car.IDPart = Part.ID inner join SmartCard on SmartCard.ID = Car.ID where Car.IDIn <> '' and Car.IDOut = '' ";
            if (typeID != null)
            {
                sql += " and Part.TypeID = '" + typeID + "'";
            }
            if (exceptPartSign != null)
            {
                sql += " and Part.Sign <> '" + exceptPartSign + "'";
            }

            return (new Database()).ExcuValueQuery(sql);
        }

        public static DataTable GetCarByIdentify(int identify)
        {
            string sql = "select top 1 * from Car where Identify = " + identify + sqlOrderByIdentifyDesc;
            return (new Database()).ExcuQuery(sql);
        }

        public static DataTable GetLastCarByID(string id)
        {
            string sql = "select top 1 Identify, ID, TimeStart, TimeEnd, Digit, DigitIn, Images, Images2, Cost from Car where ID = '" + id + "' order by TimeStart desc, Identify desc";
            return (new Database()).ExcuQuery(sql);
        }

        public static DataTable GetCarGoOut(int month)
        {
            string sql = "select top 50 Images, Images2, Images3, Images4 from Car where DATEDIFF(MONTH, TimeStart, getdate()) > " + month + " and IDOut <> ''";
            return (new Database()).ExcuQuery(sql);
        }

        public static string GetLastCardID()
        {
            string sql = "select ID from Car order by Identify desc";
            DataTable dt = (new Database()).ExcuQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                string cardId = dt.Rows[0].Field<string>("ID");
                return cardId;
            }
            return "";
        }

        public static bool Insert(CarDTO carDTO)
        {
            string sql = "insert into Car(ID, TimeStart, Digit, DigitIn, IDIn, IDOut, IDTicketMonth, IDPart, Images, Images2, Computer, Account, DateUpdate) values ('" + carDTO.Id + "', '" + carDTO.TimeStart.ToString(Constant.sDateTimeFormatForQuery) + "', '" + carDTO.Digit + "', '" + carDTO.DigitIn
                + "', '" + carDTO.IdIn + "', '" + carDTO.IdOut + "', '" + carDTO.IdTicketMonth + "', '" + carDTO.IdPart + "', '" + carDTO.Images + "', '" + carDTO.Images2 + "', '" + carDTO.Computer + "', '" + carDTO.Account + "', '" + carDTO.DateUpdate.ToString(Constant.sDateTimeFormatForQuery) + "')";
            return (new Database()).ExcuNonQuery(sql);
        }

        public static bool UpdateCarIn(CarDTO carDTO)
        {
            string sql = "update Car set TimeStart ='" + carDTO.TimeStart.ToString(Constant.sDateTimeFormatForQuery) + "', IDIn ='" + carDTO.IdIn + "', DigitIn ='" + carDTO.DigitIn + "', Images ='" + carDTO.Images + "', Images2 ='" + carDTO.Images2 + "', Computer ='" + carDTO.Computer + "', Account ='" + carDTO.Account +
                "', DateUpdate ='" + carDTO.DateUpdate.ToString(Constant.sDateTimeFormatForQuery) + "' where Identify =" + carDTO.Identify;
            return (new Database()).ExcuNonQuery(sql);
        }

        public static bool UpdateCarOut(CarDTO carDTO)
        {
            string sql = "update Car set DigitOut = '" + carDTO.DigitOut + "', TimeEnd ='" + carDTO.TimeEnd.ToString(Constant.sDateTimeFormatForQuery) + "', IDOut ='" + carDTO.IdOut + "', Cost =" + carDTO.Cost + ", Images3 ='" + carDTO.Images3 + "', Images4 ='" + carDTO.Images4 + "', DateUpdate ='" + carDTO.DateUpdate.ToString(Constant.sDateTimeFormatForQuery) + "' where Identify =" + carDTO.Identify;
            return (new Database()).ExcuNonQuery(sql);
        }

        public static bool UpdateLostCard(CarDTO carDTO)
        {
            string sql = "update Car set TimeEnd ='" + carDTO.TimeEnd.ToString(Constant.sDateTimeFormatForQuery) + "', IDOut ='" + carDTO.IdOut + "', Cost =" + carDTO.Cost + ", IsLostCard =" + carDTO.IsLostCard + ", DateUpdate ='" + carDTO.DateUpdate.ToString(Constant.sDateTimeFormatForQuery) + "', DateLostCard ='" + carDTO.DateLostCard.ToString(Constant.sDateTimeFormatForQuery) + "' where Identify =" + carDTO.Identify;
            string cardId = getIdByIdentify(carDTO.Identify);
            if (cardId != null)
            {
                CardDAO.UpdateIsUsing("0", cardId);
                CardDAO.UpdateDayUnlimit(carDTO.DateLostCard, cardId);
            }
            return (new Database()).ExcuNonQuery(sql);
        }

        public static void UpdateDigitIn(string id, String digit)
        {
            int identify = GetLastIdentifyByID(id);
            if (identify != 0)
            {
                string sql = "update Car set DigitIn ='" + digit + "' where Identify =" + identify;
                (new Database()).ExcuNonQuery(sql);
            }
        }

        public static void UpdateDigitOut(string id, String digit)
        {
            int identify = GetLastIdentifyByID(id);
            if (identify != 0)
            {
                string sql = "update Car set DigitOut ='" + digit + "' where Identify =" + identify;
                (new Database()).ExcuNonQuery(sql);
            }
        }

        public static bool DeleteLostCard(string cardId)
        {
            string sql = "delete from Car where ID = '" + cardId + "' and IsLostCard > 0";
            return (new Database()).ExcuNonQuery(sql);
        }

        public static bool DeleteCarNotOut(string cardId)
        {
            string sql = "delete from Car where ID = '" + cardId + "' and IDOut = ''";
            return (new Database()).ExcuNonQuery(sql);
        }

        public static bool DeleteCar(string identify)
        {
            string sql = "delete from Car where Identify = " + identify; ;
            return (new Database()).ExcuNonQuery(sql);
        }

        public static bool isCarIn(string id)
        {
            string sql = "select count(Car.ID) from Car where ID = '" + id + "'" + " and IDOut != ''";
            return (new Database()).ExcuValueQuery(sql) == 0;
        }

        public static bool isCarOutByIdentify(int identify)
        {
            string sql = "select count(Car.ID) from Car where Identify = " + identify + " and IDOut != ''";
            return (new Database()).ExcuValueQuery(sql) > 0;
        }

        public static string getIdByIdentify(int identify)
        {
            string sql = "select top 1 ID from Car where Identify = " + identify + " order by Identify desc";
            DataTable dt = (new Database()).ExcuQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                string id = dt.Rows[0].Field<string>("ID");
                return id;
            }
            return null;
        }

        public static int GetLastIdentifyByID(string id)
        {
            string sql = "select top 1 Identify from Car where ID = '" + id + "'" + " order by Identify desc";
            DataTable dt = (new Database()).ExcuQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                int identify = dt.Rows[0].Field<int>("Identify");
                return identify;
            }
            return 0;
        }
    }
}

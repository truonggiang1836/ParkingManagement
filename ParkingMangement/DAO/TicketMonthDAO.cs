using Newtonsoft.Json.Linq;
using ParkingMangement.DTO;
using ParkingMangement.Utils;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingMangement.DAO
{
    class TicketMonthDAO
    {
        private static string sqlGetAllData = "select DISTINCT SmartCard.Identify, TicketMonth.ID, TicketMonth.Digit, TicketMonth.CustomerName, TicketMonth.CMND," +
                " TicketMonth.Company, TicketMonth.Email, TicketMonth.Phone, TicketMonth.Address, TicketMonth.CarKind, TicketMonth.ChargesAmount, Part.PartName," +
                " TicketMonth.RegistrationDate, TicketMonth.ExpirationDate, SmartCard.IsUsing, TicketMonth.Images, TicketMonth.Note from TicketMonth left join Part on TicketMonth.IDPart = Part.ID inner join SmartCard on TicketMonth.ID = SmartCard.ID where TicketMonth.IsDeleted = '0' and SmartCard.IsDeleted = '0'";

        private static string sqlGetAllNearExpiredTicketData = "select DISTINCT Part.PartName, SmartCard.Identify, TicketMonth.ID, TicketMonth.Digit, TicketMonth.CustomerName, TicketMonth.Company, TicketMonth.Address, TicketMonth.ChargesAmount," +
                " TicketMonth.RegistrationDate, TicketMonth.ExpirationDate, SmartCard.IsUsing from TicketMonth left join Part on TicketMonth.IDPart = Part.ID inner join SmartCard on TicketMonth.ID = SmartCard.ID where TicketMonth.IsDeleted = '0'";

        private static string sqlGetAllPrintReceiptData = "select DISTINCT Part.PartName, TicketMonth.IDPart, SmartCard.Identify, TicketMonth.ID, TicketMonth.Digit, TicketMonth.CustomerName, TicketMonth.Company, TicketMonth.Address, TicketMonth.ChargesAmount," +
                " TicketMonth.RegistrationDate, TicketMonth.ExpirationDate, SmartCard.IsUsing from TicketMonth left join Part on TicketMonth.IDPart = Part.ID inner join SmartCard on TicketMonth.ID = SmartCard.ID where TicketMonth.IsDeleted = '0'";

        private static string sqlGetAllLostTicketData = "select DISTINCT TicketMonth.Identify as TicketMonthIdentify, SmartCard.Identify, TicketMonth.ID, TicketMonth.Digit, TicketMonth.CustomerName, TicketMonth.Address," +
            " Part.PartName, TicketMonth.RegistrationDate, TicketMonth.ExpirationDate, SmartCard.DayUnlimit, TicketMonth.Note, TicketMonth.ProcessDate from " +
            "TicketMonth left join Part on TicketMonth.IDPart = Part.ID inner join SmartCard on TicketMonth.ID = SmartCard.ID where TicketMonth.IsDeleted = '0'";

        private static string sqlGetAllActiveTicketData = "select DISTINCT SmartCard.Identify, TicketMonth.ID, TicketMonth.Digit, TicketMonth.CustomerName, TicketMonth.Company, TicketMonth.Address, " +
            "TicketMonth.RegistrationDate, TicketMonth.ExpirationDate from TicketMonth inner join SmartCard on TicketMonth.ID = SmartCard.ID where SmartCard.IsUsing = '0' and TicketMonth.IsDeleted = '0'";

        private static string sqlGetAllBlockTicketData = "select DISTINCT SmartCard.Identify, TicketMonth.ID, TicketMonth.Digit, TicketMonth.CustomerName, TicketMonth.Company, TicketMonth.Address, " +
            "TicketMonth.RegistrationDate, TicketMonth.ExpirationDate from TicketMonth inner join SmartCard on TicketMonth.ID = SmartCard.ID where SmartCard.IsUsing = '1' and TicketMonth.IsDeleted = '0'";

        private static string sqlOrderByIdentify = " order by SmartCard.Identify asc";
        private static string sqlOrderByExpirationDate = " order by TicketMonth.ExpirationDate asc"; 
        public static DataTable GetAllData()
        {
            string sql = sqlGetAllData + sqlOrderByIdentify;
            DataTable data = (new Database()).ExcuQuery(sql);

            for (int row = 0; row < data.Rows.Count; row++)
            {
                if (data.Rows[row].Field<string>("IsUsing") == "1")
                {
                    data.Rows[row].SetField("IsUsing", Constant.sLabelCardUsing);
                }
                else
                {
                    data.Rows[row].SetField("IsUsing", Constant.sLabelCardNotUsing);
                }
            }
            return data;
        }

        public static DataTable GetAllDataForSync()
        {
            string sql = "select top 50 * from TicketMonth where IsSync = 0 order by TicketMonth.Identify asc";
            return (new Database()).ExcuQuery(sql);
        }

        public static void UpdateIsSync(string id)
        {
            string sql = "update TicketMonth set IsSync = 1 where ID in " + id;
            (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static string getInsertSql(TicketMonthDTO ticketMonthDTO)
        {
            string sql = "insert into TicketMonth(ID, ProcessDate, Digit, CustomerName, CMND, Company, Email, Phone, Address, CarKind, RegistrationDate, ExpirationDate" +
                ", ChargesAmount, IDPart, Account, Note, IsSync, IsDeleted) values ('" + ticketMonthDTO.Id + "', '" + ticketMonthDTO.ProcessDate?.ToString(Constant.sDateTimeFormatForQuery) + "', N'" + ticketMonthDTO.Digit + "', N'" +
                ticketMonthDTO.CustomerName + "', N'" + ticketMonthDTO.Cmnd + "', N'" + ticketMonthDTO.Company + "', N'" + ticketMonthDTO.Email + "', N'" + ticketMonthDTO.Phone + "', N'" +
                ticketMonthDTO.Address + "', N'" + ticketMonthDTO.CarKind + "', '" + ticketMonthDTO.RegistrationDate?.ToString(Constant.sDateTimeFormatForQuery) + "', '" + ticketMonthDTO.ExpirationDate?.ToString(Constant.sDateTimeFormatForQuery) +
                "', '" + ticketMonthDTO.ChargesAmount + "', '" + ticketMonthDTO.IdPart + "', '" + ticketMonthDTO.Account + "', N'" + ticketMonthDTO.Note + "', '" + ticketMonthDTO.IsSync + "', '" + ticketMonthDTO.IsDeleted + "')";
            return sql;
        }

        public static bool Insert(TicketMonthDTO ticketMonthDTO)
        {
            HardDeleteIfCardBeDeleted(ticketMonthDTO.Id);

            string sql = getInsertSql(ticketMonthDTO); 
            return (new Database()).ExcuNonQuery(sql);
        }

        public static bool InsertNoErrorMessage(TicketMonthDTO ticketMonthDTO)
        {
            string sql = getInsertSql(ticketMonthDTO); 
            return (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static string getUpdateSql(TicketMonthDTO ticketMonthDTO)
        {
            string sql = "update TicketMonth set ProcessDate ='" + ticketMonthDTO.ProcessDate?.ToString(Constant.sDateTimeFormatForQuery) + "', Digit =N'" + ticketMonthDTO.Digit + "', CustomerName =N'"
                + ticketMonthDTO.CustomerName + "', CMND =N'" + ticketMonthDTO.Cmnd + "', Company =N'" + ticketMonthDTO.Company + "', Email =N'" + ticketMonthDTO.Email + "', Phone = N'" + ticketMonthDTO.Phone + "', Address =N'" + ticketMonthDTO.Address + "', CarKind =N'"
                + ticketMonthDTO.CarKind + "', RegistrationDate ='" + ticketMonthDTO.RegistrationDate?.ToString(Constant.sDateTimeFormatForQuery) + "', ExpirationDate ='" + ticketMonthDTO.ExpirationDate?.ToString(Constant.sDateTimeFormatForQuery) + "', IdPart ='" + ticketMonthDTO.IdPart + "', ChargesAmount =N'" + ticketMonthDTO.ChargesAmount 
                + "', IsSync =('" + ticketMonthDTO.IsSync + "'), IsDeleted =('" + ticketMonthDTO.IsDeleted + "'), Note =N'" + ticketMonthDTO.Note + "' where ID ='" + ticketMonthDTO.Id + "'";
            return sql;
        }

        public static string getUpdateSyncSPMSql(TicketMonthDTO ticketMonthDTO)
        {
            string sql = "update TicketMonth set ProcessDate ='" + ticketMonthDTO.ProcessDate?.ToString(Constant.sDateTimeFormatForQuery) + "', Digit =N'" + ticketMonthDTO.Digit + "', CustomerName =N'"
                + ticketMonthDTO.CustomerName + "', Company =N'" + ticketMonthDTO.Company + "', RegistrationDate ='" + ticketMonthDTO.RegistrationDate?.ToString(Constant.sDateTimeFormatForQuery) + "', ExpirationDate ='" + ticketMonthDTO.ExpirationDate?.ToString(Constant.sDateTimeFormatForQuery) + "', IdPart ='" + ticketMonthDTO.IdPart 
                + "', IsSync ='" + ticketMonthDTO.IsSync + "', IsDeleted ='" + ticketMonthDTO.IsDeleted + "', ChargesAmount =N'" + ticketMonthDTO.ChargesAmount + "', Phone =N'" + ticketMonthDTO.Phone + "' where ID ='" + ticketMonthDTO.Id + "'";
            return sql;
        }

        public static string getUpdateSyncPiHomeSql(TicketMonthDTO ticketMonthDTO)
        {
            string sql = "update TicketMonth set ProcessDate ='" + ticketMonthDTO.ProcessDate?.ToString(Constant.sDateTimeFormatForQuery) + "', CustomerName =N'"
                + ticketMonthDTO.CustomerName + "', Company =N'" + ticketMonthDTO.Company + "', RegistrationDate ='" + ticketMonthDTO.RegistrationDate?.ToString(Constant.sDateTimeFormatForQuery) + "', ExpirationDate ='" + ticketMonthDTO.ExpirationDate?.ToString(Constant.sDateTimeFormatForQuery) + "', IdPart ='" + ticketMonthDTO.IdPart
                + "', IsSync ='" + ticketMonthDTO.IsSync + "', IsDeleted ='" + ticketMonthDTO.IsDeleted + "', ChargesAmount =N'" + ticketMonthDTO.ChargesAmount + "', Phone =N'" + ticketMonthDTO.Phone + "' where Digit ='" + ticketMonthDTO.Digit + "'";
            return sql;
        }

        public static bool Update(TicketMonthDTO ticketMonthDTO)
        {
            string sql = getUpdateSql(ticketMonthDTO);
            return (new Database()).ExcuNonQuery(sql);
        }

        public static bool Update(string digit, DateTime? expirationDate, string chargesAmount)
        {
            string sql = "update TicketMonth set ExpirationDate ='" + expirationDate?.ToString(Constant.sDateTimeFormatForQuery) + "', ChargesAmount ='" + chargesAmount
                + "' where Digit ='" + digit + "'";
            return (new Database()).ExcuNonQuery(sql);
        }

        public static bool Update(string digit, string phone)
        {
            string sql = "update TicketMonth set TicketMonth.Phone = '" + phone + "' where Digit ='" + digit + "' and TicketMonth.Phone = ''";
            return (new Database()).ExcuNonQuery(sql);
        }

        public static void UpdateSyncSPMNoErrorMessage(TicketMonthDTO ticketMonthDTO)
        {
            string sql = getUpdateSyncSPMSql(ticketMonthDTO);
            (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static void UpdateSyncPiHomeNoErrorMessage(TicketMonthDTO ticketMonthDTO)
        {
            string sql = getUpdateSyncPiHomeSql(ticketMonthDTO);
            (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static bool Delete(string id)
        {
            //string sql = "delete from TicketMonth where ID ='" + id + "'";
            string sql = "update TicketMonth set IsDeleted = 1, IsSync = 0 where ID ='" + id + "'";
            return (new Database()).ExcuNonQuery(sql);
        }

        public static bool DeleteNoErrorMessage(string id)
        {
            //string sql = "delete from TicketMonth where ID ='" + id + "'";
            string sql = "update TicketMonth set IsDeleted = 1, IsSync = 0 where ID ='" + id + "'";
            return (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static bool HardDeleteIfCardBeDeleted(string id)
        {
            string sql = "delete from TicketMonth where ID ='" + id + "' and IsDeleted = 1";
            return (new Database()).ExcuNonQuery(sql);
        }

        public static DataTable searchData(string key)
        {
            string sql = sqlGetAllData;
            if (!string.IsNullOrEmpty(key))
            {
                sql += " and (SmartCard.Identify like '%" + key + "%' or TicketMonth.ID like '%" + key + "%' or TicketMonth.Digit like '%" + key
                    + "%' or TicketMonth.CustomerName like '%" + key + "%' or TicketMonth.CMND like '%" + key + "%' or TicketMonth.Email like '%"
                    + key + "%' or TicketMonth.Company like '%" + key + "%' or TicketMonth.Address like '%" + key + "%' or TicketMonth.CarKind like '%"
                    + key + "%' or TicketMonth.ChargesAmount like '%" + key + "%' or Part.PartName like '%" + key + "%' or TicketMonth.Phone like '%" + key + "%')";
            }
            sql += sqlOrderByIdentify;
            DataTable data = (new Database()).ExcuQuery(sql);

            for (int row = 0; row < data.Rows.Count; row++)
            {
                if (data.Rows[row].Field<string>("IsUsing") == "1")
                {
                    data.Rows[row].SetField("IsUsing", Constant.sLabelCardUsing);
                }
                else
                {
                    data.Rows[row].SetField("IsUsing", Constant.sLabelCardNotUsing);
                }
            }
            return data;
        }

        public static DataTable searchNearExpiredTicketData(string key, int? daysRemaining)
        {
            string sql = sqlGetAllNearExpiredTicketData;
            if (!string.IsNullOrEmpty(key))
            {
                sql += " and (SmartCard.Identify like '%" + key + "%' or TicketMonth.ID like '%" + key + "%' or TicketMonth.Digit like '%" + key
                    + "%' or TicketMonth.CustomerName like '%" + key + "%' or TicketMonth.CMND like '%" + key + "%' or TicketMonth.Email like '%"
                    + key + "%' or TicketMonth.Company like '%" + key + "%' or TicketMonth.Address like '%" + key + "%' or TicketMonth.CarKind like '%"
                    + key + "%' or TicketMonth.ChargesAmount like '%" + key + "%' or Part.PartName like '%" + key + "%' or TicketMonth.Phone like '%" + key + "%')";
            }
            sql += sqlOrderByExpirationDate;
            DataTable data = (new Database()).ExcuQuery(sql);

            DateTime currentDate = DateTime.Now;
            data.Columns.Add("DaysRemaining", typeof(System.Int32));
            for (int row = 0; row < data.Rows.Count; row++)
            {
                DateTime expirationDate = data.Rows[row].Field<DateTime>("ExpirationDate");
                int daysRemainingInDB = (expirationDate.Date - currentDate.Date).Days;

                data.Rows[row].SetField("DaysRemaining", daysRemainingInDB);              

                if (data.Rows[row].Field<string>("IsUsing") == "1")
                {
                    data.Rows[row].SetField("IsUsing", Constant.sLabelCardUsing);
                }
                else
                {
                    data.Rows[row].SetField("IsUsing", Constant.sLabelCardNotUsing);
                }

                if (daysRemaining != null && daysRemaining.GetValueOrDefault() < daysRemainingInDB)
                {
                    data.Rows[row].Delete();
                }
            }
            return data;
        }

        public async static Task<DataTable> SearchDebtReportTicketData(string key, int? daysRemaining)
        {
            DataTable data = new DataTable();
            await Task.Run(() => {
                string sql = sqlGetAllNearExpiredTicketData;
                if (!string.IsNullOrEmpty(key))
                {
                    sql += " and (SmartCard.Identify like '%" + key + "%' or TicketMonth.ID like '%" + key + "%' or TicketMonth.Digit like '%" + key
                        + "%' or TicketMonth.CustomerName like '%" + key + "%' or TicketMonth.CMND like '%" + key + "%' or TicketMonth.Email like '%"
                        + key + "%' or TicketMonth.Company like '%" + key + "%' or TicketMonth.Address like '%" + key + "%' or TicketMonth.CarKind like '%"
                        + key + "%' or TicketMonth.ChargesAmount like '%" + key + "%' or Part.PartName like '%" + key + "%' or TicketMonth.Phone like '%" + key + "%')";
                }
                sql += sqlOrderByExpirationDate;
                data = (new Database()).ExcuQuery(sql);

                DateTime currentDate = DateTime.Now;
                data.Columns.Add("PreviousCharge", typeof(string));
                data.Columns.Add("CurrentCharge", typeof(string));
                data.Columns.Add("DaysRemaining", typeof(System.Int32));
                for (int row = 0; row < data.Rows.Count; row++)
                {
                    DateTime expirationDate = data.Rows[row].Field<DateTime>("ExpirationDate");
                    string chargesAmount = data.Rows[row].Field<string>("ChargesAmount");

                    DateTime newExpirationDate = Util.getLastDateOfCurrentMonth();
                    string monthlyCostString = chargesAmount.Replace(".", "").Replace(",", "");

                    int monthlyCost = 0;
                    try
                    {
                        monthlyCost = Convert.ToInt32(monthlyCostString);
                    }
                    catch (Exception)
                    {

                    }
                    int extendCardCost = Util.getCostExtendCard(expirationDate, newExpirationDate, monthlyCostString);
                    extendCardCost = Util.roundUpVND(extendCardCost);
                    if (extendCardCost < 0)
                    {
                        extendCardCost = 0;
                    }
                    int previousCharge = 0;
                    int currentCharge = extendCardCost;
                    if (extendCardCost > monthlyCost)
                    {
                        previousCharge = extendCardCost - monthlyCost;
                        currentCharge = monthlyCost;
                    }

                    data.Rows[row].SetField("PreviousCharge", Util.formatNumberAsMoney(previousCharge));
                    data.Rows[row].SetField("CurrentCharge", Util.formatNumberAsMoney(currentCharge));

                    int daysRemainingInDB = (expirationDate.Date - currentDate.Date).Days;
                    data.Rows[row].SetField("DaysRemaining", daysRemainingInDB);

                    if (data.Rows[row].Field<string>("IsUsing") == "1")
                    {
                        data.Rows[row].SetField("IsUsing", Constant.sLabelCardUsing);
                    }
                    else
                    {
                        data.Rows[row].SetField("IsUsing", Constant.sLabelCardNotUsing);
                    }

                    if (daysRemaining != null && daysRemaining.GetValueOrDefault() < daysRemainingInDB)
                    {
                        data.Rows[row].Delete();
                    }
                }
            });

            return data;
        }

        public static DataTable searchPrintReceiptData(string key)
        {
            string sql = sqlGetAllPrintReceiptData;
            if (!string.IsNullOrEmpty(key))
            {
                sql += " and (SmartCard.Identify like '%" + key + "%' or TicketMonth.ID = '" + key + "' or TicketMonth.Digit like '%" + key + "%'"
                    + " or TicketMonth.CustomerName like '%" + key + "%' or TicketMonth.Company like '%" + key + "%' or TicketMonth.Address like '%" + key + "%' or TicketMonth.Phone = '" + key + "')";
            }
            sql += sqlOrderByExpirationDate;
            DataTable data = (new Database()).ExcuQuery(sql);

            data.Columns.Add("NewExpirationDate", typeof(System.DateTime));
            data.Columns.Add("Cost", typeof(System.Int32));            
            for (int row = 0; row < data.Rows.Count; row++)
            {
                if (data.Rows[row].Field<string>("IsUsing") == "1")
                {
                    data.Rows[row].SetField("IsUsing", Constant.sLabelCardUsing);
                }
                else
                {
                    data.Rows[row].SetField("IsUsing", Constant.sLabelCardNotUsing);
                }

                data.Rows[row].SetField("NewExpirationDate", Util.getLastDateOfCurrentMonth());
                data.Rows[row].SetField("Cost", 0);
            }
            return data;
        }

        public static void updateTicketByExpirationDate(DateTime expirationDate, string id)
        {
            string sql = "update TicketMonth set ExpirationDate = '" + expirationDate.ToString(Constant.sDateTimeFormatForQuery) + "', TicketMonth.IsSync = 0 where ID ='" + id + "'";
            (new Database()).ExcuNonQuery(sql);
            int monthCount = Util.MonthDifference(DateTime.Now, expirationDate);
            if (monthCount <= 1)
            {
                CardDAO.UpdateIsUsing("1", id);
            }         
        }  

        public static DataTable GetAllLostTicketData()
        {
            string sql = sqlGetAllLostTicketData;
            sql += sqlOrderByIdentify;
            DataTable data = (new Database()).ExcuQuery(sql);

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
                sql += " and (SmartCard.Identify like '%" + key + "%' or TicketMonth.ID like '%" + key + "%' or TicketMonth.Digit like '%" + key
                    + "%' or TicketMonth.CustomerName like '%" + key + "%' or TicketMonth.CMND like '%" + key + "%' or TicketMonth.Email like '%"
                    + key + "%' or TicketMonth.Company like '%" + key + "%' or TicketMonth.Address like '%" + key + "%' or TicketMonth.CarKind like '%"
                    + key + "%' or TicketMonth.ChargesAmount like '%" + key + "%' or Part.PartName like '%" + key + "%' or TicketMonth.Phone like '%" + key + "%')";
            }
            sql += sqlOrderByIdentify;
            DataTable data = (new Database()).ExcuQuery(sql);

            addDaysRemainingToTicketData(data);
            return data;
        }

        public static DataTable searchActiveTicketData(string key, int? daysRemaining)
        {
            string sql = sqlGetAllActiveTicketData;
            if (!string.IsNullOrEmpty(key))
            {
                sql += " and (SmartCard.Identify like '%" + key + "%' or TicketMonth.ID like '%" + key + "%' or TicketMonth.Digit like '%" + key
                    + "%' or TicketMonth.CustomerName like '%" + key + "%' or TicketMonth.CMND like '%" + key + "%' or TicketMonth.Email like '%"
                    + key + "%' or TicketMonth.Company like '%" + key + "%' or TicketMonth.Address like '%" + key + "%' or TicketMonth.CarKind like '%"
                    + key + "%' or TicketMonth.ChargesAmount like '%" + key + "%' or TicketMonth.Phone like '%" + key + "%')";
            }
            sql += sqlOrderByIdentify;
            DataTable data = (new Database()).ExcuQuery(sql);

            addDaysRemainingToTicketData(data);

            DateTime currentDate = DateTime.Now;
            for (int row = 0; row < data.Rows.Count; row++)
            {
                DateTime expirationDate = data.Rows[row].Field<DateTime>("ExpirationDate");
                int daysRemainingInDB = Convert.ToInt32((expirationDate - currentDate).TotalDays);

                if (daysRemaining != null && daysRemaining.GetValueOrDefault() < daysRemainingInDB)
                {
                    data.Rows[row].Delete();
                }
            }
            return data;
        }

        public static DataTable searchBlockTicketData(string key, int? daysRemaining)
        {
            string sql = sqlGetAllBlockTicketData;
            if (!string.IsNullOrEmpty(key))
            {
                sql += " and (SmartCard.Identify like '%" + key + "%' or TicketMonth.ID like '%" + key + "%' or TicketMonth.Digit like '%" + key
                    + "%' or TicketMonth.CustomerName like '%" + key + "%' or TicketMonth.CMND like '%" + key + "%' or TicketMonth.Email like '%"
                    + key + "%' or TicketMonth.Company like '%" + key + "%' or TicketMonth.Address like '%" + key + "%' or TicketMonth.CarKind like '%"
                    + key + "%' or TicketMonth.ChargesAmount like '%" + key + "%' or TicketMonth.Phone like '%" + key + "%')";
            }
            sql += sqlOrderByIdentify;
            DataTable data = (new Database()).ExcuQuery(sql);

            addDaysRemainingToTicketData(data);

            DateTime currentDate = DateTime.Now;
            for (int row = 0; row < data.Rows.Count; row++)
            {
                DateTime expirationDate = data.Rows[row].Field<DateTime>("ExpirationDate");
                int daysRemainingInDB = Convert.ToInt32((expirationDate - currentDate).TotalDays);

                if (daysRemaining != null && daysRemaining.GetValueOrDefault() < daysRemainingInDB)
                {
                    data.Rows[row].Delete();
                }
            }
            return data;
        }

        public static bool updateTicketByID(string id, int identify)
        {
            HardDeleteIfCardBeDeleted(id);

            string sql = "update TicketMonth set ID = '" + id + "', TicketMonth.IsSync = 0 where Identify = " + identify;
            return (new Database()).ExcuNonQuery(sql);
        }

        public static DataTable GetDataByID(string id)
        {
            string sql = "select top 1 * from TicketMonth where ID = '" + id + "' and TicketMonth.IsDeleted = '0'";
            return (new Database()).ExcuQuery(sql);
        }

        public static TicketMonthDTO GetDTODataByID(string id)
        {
            string sql = "select top 1 * from TicketMonth where ID = '" + id + "' and TicketMonth.IsDeleted = '0'";
            DataTable dt = (new Database()).ExcuQuery(sql);
            TicketMonthDTO ticketMonthDTO = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                ticketMonthDTO = new TicketMonthDTO();

                ticketMonthDTO.CardIdentify = dt.Rows[0].Field<Int32>("Identify").ToString();
                ticketMonthDTO.Id = dt.Rows[0].Field<string>("Id");
                ticketMonthDTO.ProcessDate = dt.Rows[0].Field<DateTime?>("ProcessDate");
                ticketMonthDTO.Digit = dt.Rows[0].Field<string>("Digit");
                ticketMonthDTO.CustomerName = dt.Rows[0].Field<string>("CustomerName");
                ticketMonthDTO.Cmnd = dt.Rows[0].Field<string>("Cmnd");
                ticketMonthDTO.Company = dt.Rows[0].Field<string>("Company");
                ticketMonthDTO.Email = dt.Rows[0].Field<string>("Email");
                ticketMonthDTO.Address = dt.Rows[0].Field<string>("Address");
                ticketMonthDTO.CarKind = dt.Rows[0].Field<string>("CarKind");
                ticketMonthDTO.IdPart = dt.Rows[0].Field<string>("IdPart");
                ticketMonthDTO.RegistrationDate = dt.Rows[0].Field<DateTime?>("RegistrationDate");
                ticketMonthDTO.ExpirationDate = dt.Rows[0].Field<DateTime?>("ExpirationDate");
                ticketMonthDTO.Note = dt.Rows[0].Field<string>("Note");
                ticketMonthDTO.ChargesAmount = dt.Rows[0].Field<string>("ChargesAmount");
                ticketMonthDTO.Status = dt.Rows[0].Field<Int32>("Status");
                ticketMonthDTO.Account = dt.Rows[0].Field<string>("Account");
                ticketMonthDTO.Images = dt.Rows[0].Field<string>("Images");
                ticketMonthDTO.DayUnlimit = dt.Rows[0].Field<DateTime?>("DayUnlimit");
                ticketMonthDTO.Phone = dt.Rows[0].Field<string>("Phone");
                ticketMonthDTO.IsSync = dt.Rows[0].Field<Int32>("IsSync").ToString();
                ticketMonthDTO.IsDeleted = dt.Rows[0].Field<Int32>("IsDeleted").ToString();
            }
            return ticketMonthDTO;
        }

        public static DataTable GetDataByDigit(string digit)
        {
            string sql = "select * from TicketMonth where Digit = '" + digit + "' and TicketMonth.IsDeleted = '0'";
            return (new Database()).ExcuQuery(sql);
        }

        public static DataTable GetDataByIdentify(string cardIdentify)
        {
            string sql = "select * from TicketMonth inner join SmartCard on TicketMonth.ID = SmartCard.ID where SmartCard.Identify = '" + cardIdentify + "' and TicketMonth.IsDeleted = '0'";
            return (new Database()).ExcuQuery(sql);
        }

        public static string GetDigitByID(string id)
        {
            string sql = "select top 1 Digit from TicketMonth where ID = '" + id + "' and TicketMonth.IsDeleted = '0'";
            DataTable dt = (new Database()).ExcuQuery(sql);

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
            ticketMonthDTO.Phone = dataRow.Field<String>("Phone");
            ticketMonthDTO.Address = dataRow.Field<String>("Address");
            ticketMonthDTO.CarKind = dataRow.Field<String>("CarKind");
            String registrationDateString = dataRow.Field<String>("RegistrationDate");
            DateTime registrationDate = DateTime.ParseExact(registrationDateString, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            ticketMonthDTO.RegistrationDate = registrationDate;
            String expirationDateString = dataRow.Field<String>("ExpirationDate");
            DateTime expirationDate = DateTime.ParseExact(expirationDateString, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            ticketMonthDTO.ExpirationDate = expirationDate;
            ticketMonthDTO.ChargesAmount = dataRow.Field<String>("ChargesAmount");

            return ticketMonthDTO;
        }

        public static void syncFromJson(string json)
        {
            //JArray jArray = JArray.Parse(json);
            //foreach (JObject jObject in jArray)
            //{
            //    TicketMonthDTO ticketMonthDTO = new TicketMonthDTO();
            //    ticketMonthDTO.Address = jObject.GetValue("address").ToString();
            //    ticketMonthDTO.Account = jObject.GetValue("admin_id").ToString();
            //    ticketMonthDTO.Digit = jObject.GetValue("car_number").ToString();
            //    ticketMonthDTO.Company = jObject.GetValue("company").ToString();
            //    ticketMonthDTO.CustomerName = jObject.GetValue("customer_name").ToString();
            //    ticketMonthDTO.Email = jObject.GetValue("email").ToString();
            //    ticketMonthDTO.RegistrationDate = Util.MillisecondToDateTime((long)jObject.SelectToken("start_date"));
            //    ticketMonthDTO.ExpirationDate = Util.MillisecondToDateTime((long)jObject.SelectToken("end_date"));
            //    ticketMonthDTO.ProcessDate = Util.MillisecondToDateTime((long)jObject.SelectToken("updated"));
            //    ticketMonthDTO.DayUnlimit = ticketMonthDTO.ProcessDate;
            //    ticketMonthDTO.Id = jObject.GetValue("card_code").ToString();
            //    ticketMonthDTO.Cmnd = jObject.GetValue("id_number").ToString();
            //    ticketMonthDTO.ChargesAmount = jObject.GetValue("parking_fee").ToString();
            //    ticketMonthDTO.IdPart = jObject.GetValue("vehicle_id").ToString();
            //    ticketMonthDTO.IsDeleted = (bool)jObject.SelectToken("deleted") ? "1" : "0";
            //    ticketMonthDTO.IsSync = "1";

            //    InsertOrUpdateSPMNoErrorMessage(ticketMonthDTO);
            //}
        }

        public static void syncFromSPMJson(string json)
        {
            JObject jParentObject = JObject.Parse(json);
            JArray jArray = (JArray)jParentObject.GetValue("data");
            int index = 0;
            foreach (JObject jObject in jArray)
            {
                string id = jObject.GetValue("maThe").ToString();
                string soThe = jObject.GetValue("soThe").ToString();
                string bienSo = jObject.GetValue("bienSo").ToString();
                string trangThai = jObject.GetValue("trangThai").ToString();
                string isUsing = trangThai.Equals("BiKhoa") ? "0" : "1";

                string sign = jObject.GetValue("loaiThe").ToString();
                DataTable data = PartDAO.GetPartIDAndAmountBySign(sign);
                string partId = "";
                if (data != null && data.Rows.Count > 0)
                {
                    partId = data.Rows[0].Field<string>("ID");
                }

                TicketMonthDTO ticketMonthDTO = GetDTODataByID(id);
                if (ticketMonthDTO == null)
                {
                    ticketMonthDTO = new TicketMonthDTO();
                }
                ticketMonthDTO.Account = Program.CurrentUserID;
                ticketMonthDTO.Digit = bienSo;
                ticketMonthDTO.Company = jObject.GetValue("soPhong").ToString();
                ticketMonthDTO.CustomerName = jObject.GetValue("chuXe").ToString();
                try
                {
                    ticketMonthDTO.RegistrationDate = DateTime.Parse(jObject.GetValue("ngayBatDau").ToString());
                    ticketMonthDTO.ExpirationDate = DateTime.Parse(jObject.GetValue("ngayHetHan").ToString());
                }
                catch
                {
                    Exception e;
                }
                ticketMonthDTO.ProcessDate = DateTime.Now;
                ticketMonthDTO.DayUnlimit = DateTime.Now;
                ticketMonthDTO.Id = id;

                if (!partId.Equals(""))
                {
                    ticketMonthDTO.IdPart = partId;
                }
                ticketMonthDTO.ChargesAmount = jObject.GetValue("phiThang").ToString();
                ticketMonthDTO.Phone = jObject.GetValue("dienThoai").ToString();
                ticketMonthDTO.IsDeleted = "0";
                ticketMonthDTO.IsSync = "1";

                if (trangThai.Equals("BiXoa"))
                {
                    DeleteNoErrorMessage(id);
                    CardDAO.DeleteNoErrorMessage(id);
                }
                else
                {
                    if (id.Length > 0)
                    {
                        CardDTO cardDTO = new CardDTO();
                        cardDTO.SystemId = id;
                        cardDTO.Id = id;
                        cardDTO.IsUsing = isUsing;
                        cardDTO.IsDeleted = "0";
                        cardDTO.Identify = soThe;
                        cardDTO.Type = partId;
                        cardDTO.DayUnlimit = DateTime.Now;
                        cardDTO.IsSync = "1";

                        CardDAO.InsertOrUpdate(cardDTO);

                        if (ticketMonthDTO.CustomerName.Equals("") && bienSo.Equals("")
                        && ticketMonthDTO.Company.Equals("") && ticketMonthDTO.Phone.Equals(""))
                        {
                            DeleteNoErrorMessage(id);
                        }
                        else
                        {
                            InsertOrUpdateSPMNoErrorMessage(ticketMonthDTO);
                        }
                    }
                }

                Util.setSyncDoneMonthlyCardListToSPMServer(soThe);
                //break;

                Console.WriteLine("Sync API doing: " + index);

                index++;

                if (index % 100 == 0)
                {
                    Thread.Sleep(3000);
                }
            }
            Console.WriteLine("Sync API done!");
        }

        public static void syncFromPiHomeJson(string json)
        {
            JObject jParentObject = JObject.Parse(json);
            JObject jDataObject = (JObject)jParentObject.GetValue("data");
            JArray jArray = (JArray)jDataObject.GetValue("data");
            int index = 0;
            foreach (JObject jObject in jArray)
            {
                string id = jObject.GetValue("card_code").ToString();
                string soThe = jObject.GetValue("card_number").ToString();
                string bienSo = jObject.GetValue("license_plate").ToString();
                string trangThai = jObject.GetValue("status").ToString();
                string isUsing = trangThai.Equals("BiKhoa") ? "0" : "1";

                string sign = jObject.GetValue("type").ToString();
                DataTable data = PartDAO.GetPartIDAndAmountBySign(sign);
                string partId = "";
                if (data != null && data.Rows.Count > 0)
                {
                    partId = data.Rows[0].Field<string>("ID");
                }

                TicketMonthDTO ticketMonthDTO = GetDTODataByID(id);
                if (ticketMonthDTO == null)
                {
                    ticketMonthDTO = new TicketMonthDTO();
                }
                ticketMonthDTO.Account = Program.CurrentUserID;
                ticketMonthDTO.Digit = bienSo;
                ticketMonthDTO.Company = jObject.GetValue("apartment").ToString();
                ticketMonthDTO.CustomerName = jObject.GetValue("customer_name").ToString();
                try
                {
                    ticketMonthDTO.RegistrationDate = DateTime.Parse(jObject.GetValue("from_date").ToString());
                    ticketMonthDTO.ExpirationDate = DateTime.Parse(jObject.GetValue("to_date").ToString());
                }
                catch
                {
                    Exception e;
                }
                ticketMonthDTO.ProcessDate = DateTime.Now;
                ticketMonthDTO.DayUnlimit = DateTime.Now;
                ticketMonthDTO.Id = id;

                if (!partId.Equals(""))
                {
                    partId = data.Rows[0].Field<string>("ID");
                    ticketMonthDTO.IdPart = partId;
                }
                ticketMonthDTO.ChargesAmount = jObject.GetValue("fee").ToString();
                ticketMonthDTO.Phone = jObject.GetValue("phone").ToString();
                ticketMonthDTO.IsDeleted = "0";
                ticketMonthDTO.IsSync = "1";

                if (trangThai.Equals("BiXoa"))
                {
                    DeleteNoErrorMessage(id);
                    CardDAO.DeleteNoErrorMessage(id);
                }
                else
                {
                    if (id.Length > 0)
                    {
                        CardDTO cardDTO = new CardDTO();
                        cardDTO.SystemId = id;
                        cardDTO.Id = id;
                        cardDTO.IsUsing = isUsing;
                        cardDTO.IsDeleted = "0";
                        cardDTO.Identify = soThe;
                        cardDTO.Type = partId;
                        cardDTO.DayUnlimit = DateTime.Now;
                        cardDTO.IsSync = "1";

                        CardDAO.InsertOrUpdate(cardDTO);

                        if (ticketMonthDTO.CustomerName.Equals("") && bienSo.Equals("")
                        && ticketMonthDTO.Company.Equals("") && ticketMonthDTO.Phone.Equals(""))
                        {
                            DeleteNoErrorMessage(id);
                        }
                        else if (!bienSo.Equals(""))
                        {
                            InsertOrUpdatePiHomeNoErrorMessage(ticketMonthDTO);
                        }
                    }
                }

                Util.setSyncDoneMonthlyCardListToPiHomeServer(id);
                break;

                Console.WriteLine("Sync API doing: " + index);

                index++;

                if (index % 100 == 0)
                {
                    Thread.Sleep(3000);
                }
            }
            Console.WriteLine("Sync API done!");
        }

        public static void InsertOrUpdateSPMNoErrorMessage(TicketMonthDTO ticketMonthDTO)
        {
            if (!InsertNoErrorMessage(ticketMonthDTO))
            {
                UpdateSyncSPMNoErrorMessage(ticketMonthDTO);
                Console.WriteLine("Update Sync API");
            } else
            {
                Console.WriteLine("Insert Sync API");
            }
        }

        public static void InsertOrUpdatePiHomeNoErrorMessage(TicketMonthDTO ticketMonthDTO)
        {
            if (!InsertNoErrorMessage(ticketMonthDTO))
            {
                UpdateSyncSPMNoErrorMessage(ticketMonthDTO);
                Console.WriteLine("Update Sync API");
            }
            else
            {
                Console.WriteLine("Insert Sync API");
            }
        }
    }
}

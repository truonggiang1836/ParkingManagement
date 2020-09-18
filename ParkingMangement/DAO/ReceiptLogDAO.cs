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
    class ReceiptLogDAO
    {
        private static string sqlGetAllData = "select ReceiptType.ReceiptTypeName, ReceiptLog.ReceiptType, ReceiptLog.CustomerName, ReceiptLog.Address, ReceiptLog.Reason, ReceiptLog.Cost, ReceiptLog.ReceiptNumber, ReceiptLog.PrintDate, ReceiptLog.CostExtendCard," +
                " ReceiptLog.CostCreateCard, ReceiptLog.CostDepositCard, ReceiptLog.ID from ReceiptLog, ReceiptType where ReceiptType.ReceiptTypeID = ReceiptLog.ReceiptType" + sqlOrderByIdDesc;
        private static string sqlOrderByIdDesc = " order by ID desc";

        public static DataTable GetAllData()
        {
            return Database.ExcuQuery(sqlGetAllData);
        }

        public static DataTable GetDataByReceiptType(int receiptType)
        {
            string sql = "select * from ReceiptLog where ReceiptType = " + receiptType + sqlOrderByIdDesc;
            return Database.ExcuQuery(sql);
        }

        public static int GetLastReceiptNumberByReceiptType(int receiptType)
        {
            string sql = "select * from ReceiptLog where ReceiptType = " + receiptType + sqlOrderByIdDesc;
            DataTable dt = Database.ExcuQuery(sql);

            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<int>("ReceiptNumber");
            }
            else
            {
                return 0;
            }
        }

        public static DateTime GetLastPrintDate()
        {
            DataTable dt = GetAllData();
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<DateTime>("PrintDate");
            }
            else
            {
                return DateTime.Now;
            }
        }

        public static Int64? GetLastReceiptLogID()
        {
            string sql = "select ReceiptLog.ID from ReceiptLog" + sqlOrderByIdDesc;
            DataTable dt = Database.ExcuQuery(sql);
            if (dt != null & dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<Int64>("ID");
            }
            else
            {
                return null;
            }
        }

        public static bool Insert(ReceiptLogDTO receiptLogDTO)
        {
            string sql = "insert into ReceiptLog(ReceiptType, CustomerName, Address, Reason, Cost, ReceiptNumber, PrintDate, CostExtendCard, CostCreateCard, CostDepositCard) values ("
                + receiptLogDTO.ReceiptType + ", N'" + receiptLogDTO.CustomerName + "', N'" + receiptLogDTO.Address + "', N'" + receiptLogDTO.Reason + "', " + 
                receiptLogDTO.Cost + ", " + receiptLogDTO.ReceiptNumber + ", '" + receiptLogDTO.PrintDate.ToString(Constant.sDateTimeFormatForQuery) + "', " +
                receiptLogDTO.IsCostExtendCard + ", " + receiptLogDTO.IsCostCreateCard + ", " + receiptLogDTO.IsCostDepositCard + ")";

            return Database.ExcuNonQuery(sql);
        }

        public static string sqlSearchData(ReceiptLogDTO receiptLogDTO)
        {
            string sql = sqlGetAllData;
            if (receiptLogDTO != null)
            {
                if (receiptLogDTO.TimeStart != null && receiptLogDTO.TimeEnd != null)
                {
                    sql += " and ReceiptLog.PrintDate between '" + receiptLogDTO.TimeStart?.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + receiptLogDTO.TimeEnd?.ToString(Constant.sDateTimeFormatForQuery) + "'";
                }

                if (receiptLogDTO.ReceiptBook != null)
                {
                    DateTime timeStart = Util.getFirstDateOfCurrentMonth((DateTime) receiptLogDTO.ReceiptBook);
                    DateTime timeEnd = Util.getLastDateOfCurrentMonth((DateTime)receiptLogDTO.ReceiptBook);
                    sql += " and ReceiptLog.PrintDate between '" + timeStart.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + timeEnd.ToString(Constant.sDateTimeFormatForQuery) + "'";
                }
                if (receiptLogDTO.ReceiptType != null)
                {
                    sql += " and ReceiptLog.ReceiptType = " + receiptLogDTO.ReceiptType;
                }
                if (!string.IsNullOrEmpty(receiptLogDTO.CustomerName))
                {
                    sql += " and ReceiptLog.CustomerName like '%" + receiptLogDTO.CustomerName + "%'";
                }
                if (receiptLogDTO.ReceiptNumber != null)
                {
                    sql += " and ReceiptLog.ReceiptNumber = " + receiptLogDTO.ReceiptNumber;
                }
                if (!string.IsNullOrEmpty(receiptLogDTO.Address))
                {
                    sql += " and ReceiptLog.Address like '%" + receiptLogDTO.Address + "%'";
                }
                if (receiptLogDTO.IsCostCreateCard == 1)
                {
                    sql += " and ReceiptLog.CostCreateCard = 1";
                }
                if (receiptLogDTO.IsCostExtendCard == 1)
                {
                    sql += " and ReceiptLog.CostExtendCard = 1";
                }
                if (receiptLogDTO.IsCostDepositCard == 1)
                {
                    sql += " and ReceiptLog.CostDepositCard = 1";
                }
            }

            return sql;
        }

        public static DataTable searchAllData(ReceiptLogDTO receiptLogDTO)
        {
            string sql = sqlSearchData(receiptLogDTO);
            sql += sqlOrderByIdDesc;

            DataTable data = Database.ExcuQuery(sql);
            return data;
        }
    }
}

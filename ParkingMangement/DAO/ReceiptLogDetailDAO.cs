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
    class ReceiptLogDetailDAO
    {
        private static string sqlGetAllData = "select ReceiptLogDetail.CardIdentify, ReceiptLogDetail.CardID, ReceiptLogDetail.Digit, ReceiptLogDetail.CustomerName, ReceiptLogDetail.Cost, " +
            "ReceiptLogDetail.ExpirationDate, ReceiptLogDetail.PrintDate, ReceiptLogDetail.Company, ReceiptLogDetail.Address, Part.PartName, ReceiptLog.Reason from ReceiptLogDetail, ReceiptLog, Part where " +
            "ReceiptLogDetail.ReceiptLogID = ReceiptLog.ID and ReceiptLogDetail.PartID = Part.ID";
        private static string sqlOrderByIdDesc = " order by ReceiptLogDetail.ID desc";

        public static DataTable GetAllData()
        {
            return (new Database()).ExcuQuery(sqlGetAllData);
        }

        public static bool Insert(ReceiptLogDetailDTO receiptLogDetailDTO)
        {
            string sql = "insert into ReceiptLogDetail(ReceiptLogID, CardIdentify, CardID, Digit, PartID, CustomerName, Cost, ExpirationDate, PrintDate, Company, Address) values ("
                + receiptLogDetailDTO.ReceiptLogID + ", N'" + receiptLogDetailDTO.CardIdentify + "', N'" + receiptLogDetailDTO.CardID + "', N'" + receiptLogDetailDTO.Digit + "', N'" +
                receiptLogDetailDTO.PartID + "', N'" + receiptLogDetailDTO.CustomerName + "', " + receiptLogDetailDTO.Cost + ", '" +
                receiptLogDetailDTO.ExpirationDate.ToString(Constant.sDateTimeFormatForQuery) + "','" + receiptLogDetailDTO.PrintDate.ToString(Constant.sDateTimeFormatForQuery) +
                "', N'" + receiptLogDetailDTO.Company + "', N'" + receiptLogDetailDTO.Address + "')";

            return (new Database()).ExcuNonQuery(sql);
        }

        public static string sqlSearchData(ReceiptLogDetailDTO receiptLogDetailDTO)
        {
            string sql = sqlGetAllData;
            if (receiptLogDetailDTO != null)
            {
                if (receiptLogDetailDTO.TimeStart != null && receiptLogDetailDTO.TimeEnd != null)
                {
                    sql += " and ReceiptLogDetail.PrintDate between '" + receiptLogDetailDTO.TimeStart?.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + receiptLogDetailDTO.TimeEnd?.ToString(Constant.sDateTimeFormatForQuery) + "'";
                }

                if (receiptLogDetailDTO.ReceiptBook != null)
                {
                    DateTime timeStart = Util.getFirstDateOfCurrentMonth((DateTime) receiptLogDetailDTO.ReceiptBook);
                    DateTime timeEnd = Util.getLastDateOfCurrentMonth((DateTime)receiptLogDetailDTO.ReceiptBook);
                    sql += " and ReceiptLogDetail.PrintDate between '" + timeStart.ToString(Constant.sDateTimeFormatForQuery) + "' and '" + timeEnd.ToString(Constant.sDateTimeFormatForQuery) + "'";
                }       
                if (!string.IsNullOrEmpty(receiptLogDetailDTO.CustomerName))
                {
                    sql += " and ReceiptLogDetail.CustomerName like '%" + receiptLogDetailDTO.CustomerName + "%'";
                }
                if (!string.IsNullOrEmpty(receiptLogDetailDTO.Address))
                {
                    sql += " and ReceiptLogDetail.Address like '%" + receiptLogDetailDTO.Address + "%'";
                }
                if (!string.IsNullOrEmpty(receiptLogDetailDTO.Company))
                {
                    sql += " and ReceiptLogDetail.Company like '%" + receiptLogDetailDTO.Address + "%'";
                }
                if (!string.IsNullOrEmpty(receiptLogDetailDTO.CardIdentify))
                {
                    sql += " and ReceiptLogDetail.CardIdentify like '%" + receiptLogDetailDTO.CardIdentify + "%'";
                }
                if (!string.IsNullOrEmpty(receiptLogDetailDTO.CardID))
                {
                    sql += " and ReceiptLogDetail.CardID like '%" + receiptLogDetailDTO.CardID + "%'";
                }
                if (!string.IsNullOrEmpty(receiptLogDetailDTO.Digit))
                {
                    sql += " and ReceiptLogDetail.Digit like '%" + receiptLogDetailDTO.Digit + "%'";
                }

                if (receiptLogDetailDTO.PartID != null)
                {
                    sql += " and ReceiptLogDetail.PartID = " + receiptLogDetailDTO.PartID;
                }

                if (receiptLogDetailDTO.ReceiptLogID != null)
                {
                    sql += " and ReceiptLogDetail.ReceiptLogID = " + receiptLogDetailDTO.ReceiptLogID;
                }

                if (receiptLogDetailDTO.IsCostCreateCard == 1)
                {
                    sql += " and ReceiptLog.CostCreateCard = 1";
                }
                if (receiptLogDetailDTO.IsCostExtendCard == 1)
                {
                    sql += " and ReceiptLog.CostExtendCard = 1";
                }
                if (receiptLogDetailDTO.IsCostDepositCard == 1)
                {
                    sql += " and ReceiptLog.CostDepositCard = 1";
                }
            }

            return sql;
        }

        public static DataTable searchAllData(ReceiptLogDetailDTO receiptLogDetailDTO)
        {
            string sql = sqlSearchData(receiptLogDetailDTO);
            sql += sqlOrderByIdDesc;

            DataTable data = (new Database()).ExcuQuery(sql);
            return data;
        }
    }
}

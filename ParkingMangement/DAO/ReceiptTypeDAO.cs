using Newtonsoft.Json.Linq;
using ParkingMangement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.DAO
{
    class ReceiptTypeDAO
    {
        public static DataTable GetAllData()
        {
            string sql = "select * from ReceiptType";
            return (new Database()).ExcuQuery(sql);
        }

        public static string GetTypeNameByTypeID(string receiptTypeID)
        {
            string sql = "select ReceiptTypeName from ReceiptType where ReceiptTypeID = '" + receiptTypeID + "'";
            DataTable data = (new Database()).ExcuQuery(sql);
            if (data != null)
            {
                return data.Rows[0].Field<string>("ReceiptTypeName");
            }
            return "";
        }
    }
}

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
    class FunctionalDAO
    {
        static public DataTable GetAllData()
        {
            string sql = "select * from Functional";
            return (new Database()).ExcuQuery(sql);
        }

        public static DataTable GetAllDataForSync()
        {
            string sql = "select * from Functional where IsSync = 0";
            return (new Database()).ExcuQuery(sql);
        }

        public static void UpdateIsSync(string listId)
        {
            string sql = "update Functional set IsSync = 1 where FunctionID in " + listId;
            (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static bool InsertNoErrorMessage(FunctionDTO functionDTO)
        {
            string sql = "insert into Function(FunctionID, FunctionName, FunctionSec, IsSync, IsDeleted) values ('" + functionDTO.ID + "', '" + functionDTO.Name + "', '" +
                functionDTO.Sec + "', " + functionDTO.IsSync + ", " + functionDTO.IsDeleted + ")";

            return (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static bool UpdateNoErrorMessage(FunctionDTO functionDTO)
        {
            string sql = "update Function set FunctionName =('" + functionDTO.Name + "'), FunctionSec =('" + functionDTO.Sec + "'), IsSync =(" + functionDTO.IsSync + "), IsDeleted =(" + functionDTO.IsDeleted + ") where FunctionID = '" + functionDTO.ID + "'";

            return (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        static public DataTable GetAllDataWithoutAdmin()
        {
            string sql = "select * from Functional where FunctionID <> 'Ad'";
            return (new Database()).ExcuQuery(sql);
        }

        public static bool UpdateFunctionSec(string functionSec, string functionID)
        {
            string sql = "update Functional set FunctionSec ='" + functionSec + "' where FunctionID ='" + functionID + "'";
            return (new Database()).ExcuNonQuery(sql);
        }

        public static DataTable GetFunctionByID(string functionID)
        {
            string sql = "select * from Functional where FunctionID = '" + functionID + "'";
            return (new Database()).ExcuQuery(sql);
        }

        public static string GetFunctionSecByID(string functionID)
        {
            DataTable dt = GetFunctionByID(functionID);
            if (dt != null)
            {
                return dt.Rows[0].Field<string>("FunctionSec");
            }
            else
            {
                return "";
            }
        }

        public static string GetFunctionNameByID(string functionID)
        {
            DataTable dt = GetFunctionByID(functionID);
            if (dt != null)
            {
                return dt.Rows[0].Field<string>("FunctionName");
            }
            else
            {
                return "";
            }
        }

        public static void syncFromJson(string json)
        {
            JArray jArray = JArray.Parse(json);
            foreach (JObject jObject in jArray)
            {
                FunctionDTO functionDTO = new FunctionDTO();
                functionDTO.ID = (string)jObject.SelectToken("functionId");
                functionDTO.Name = (string)jObject.SelectToken("functionName");
                functionDTO.Sec = (string)jObject.SelectToken("functionSec");                
                functionDTO.IsSync = "1";
                functionDTO.IsDeleted = (bool)jObject.SelectToken("deleted") ? "1" : "0";

                InsertOrUpdate(functionDTO);
            }
        }

        public static void InsertOrUpdate(FunctionDTO functionDTO)
        {
            if (!InsertNoErrorMessage(functionDTO))
            {
                UpdateNoErrorMessage(functionDTO);
            }
        }
    }
}

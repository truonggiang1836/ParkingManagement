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
    class BlackCarDAO
    {
        public static DataTable GetAllData()
        {
            string sql = "select * from BlackCar order by Identify asc";
            return (new Database()).ExcuQuery(sql);
        }

        public static void Insert(string blackCarDigit)
        {
            string sql = "insert into BlackCar(Digit) values ('" + blackCarDigit + "')";
            (new Database()).ExcuNonQuery(sql);
        }

        public static bool InsertNoErrorMessage(BlackCarDTO blackCarDTO)
        {
            string sql = "insert into BlackCar(Digit, IsSync, IsDeleted) values ('" + blackCarDTO.Digit + "', " + blackCarDTO.IsSync + ", " + blackCarDTO.IsDeleted + ")";

            return (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static bool UpdateNoErrorMessage(BlackCarDTO blackCarDTO)
        {
            string sql = "update BlackCar set IsSync =(" + blackCarDTO.IsSync + "), IsDeleted =(" + blackCarDTO.IsDeleted + ") where Digit = '" + blackCarDTO.Digit + "'";

            return (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static void Delete(int identify)
        {
            string sql = "delete from BlackCar where Identify =" + identify;
            (new Database()).ExcuNonQuery(sql);
        }

        public static void UpdateIsSync(string listId)
        {
            string sql = "update BlackCar set IsSync = 1 where Digit in " + listId;
            (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static void syncFromJson(string json)
        {
            JArray jArray = JArray.Parse(json);
            foreach (JObject jObject in jArray)
            {
                BlackCarDTO blackCarDTO = new BlackCarDTO();
                blackCarDTO.Digit = (string)jObject.SelectToken("digit");
                blackCarDTO.IsSync = "1";
                blackCarDTO.IsDeleted = (bool)jObject.SelectToken("deleted") ? "1" : "0";

                InsertOrUpdate(blackCarDTO);
            }
        }

        public static void InsertOrUpdate(BlackCarDTO blackCarDTO)
        {
            if (!InsertNoErrorMessage(blackCarDTO))
            {
                UpdateNoErrorMessage(blackCarDTO);
            }
        }
    }
}

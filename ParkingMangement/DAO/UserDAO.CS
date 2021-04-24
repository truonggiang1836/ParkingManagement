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
    class UserDAO
    {
        public static DataTable GetAllData()
        {
            string sql = "select UserCar.UserID, UserCar.Account, UserCar.Pass, UserCar.NameUser, Sex.SexName, Functional.FunctionName from UserCar, Functional, Sex " +
                "where Functional.FunctionID = UserCar.IDFunct and Sex.SexID = UserCar.SexID order by UserCar.UserID asc";
            return (new Database()).ExcuQuery(sql);
        }

        public static DataTable GetAllDataForSync()
        {
            string sql = "select * from UserCar where IsSync = 0";
            return (new Database()).ExcuQuery(sql);
        }

        public static DataTable GetAllStaftForSyncRevenue()
        {
            string sql = "select UserId, NameUser from UserCar where IDFunct = 'Nh'";
            return (new Database()).ExcuQueryNoErrorMessage(sql);
        }

        public static void UpdateIsSync(string listId)
        {
            string sql = "update UserCar set IsSync = 1 where UserID in " + listId;
            (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static DataTable GetID_Name_Function()
        {
            string sql = "select UserCar.UserID, UserCar.NameUser, Functional.FunctionName from UserCar, Functional " +
                "where Functional.FunctionID = UserCar.IDFunct";
            return (new Database()).ExcuQuery(sql);
        }

        public static string getInsertSql(UserDTO userDTO)
        {
            string sql = "insert into UserCar(UserID, Account, Pass, NameUser, SexID, IDFunct, RememberMe, IsSync, IsDeleted) values ('" + userDTO.Id + "', N'" + userDTO.Account + "', N'" +
                userDTO.Password + "', N'" + userDTO.Name + "', " + userDTO.SexId + ", '" + userDTO.FunctionId + "', " + 0 + ", " + userDTO.IsSync + ", " + userDTO.IsDeleted + ")";
            return sql;
        }

        public static string getUpdateSql(UserDTO userDTO)
        {
            string sql = "update UserCar set Account =N'" + userDTO.Account + "', Pass =N'" + userDTO.Password + "', NameUser =N'" + userDTO.Name + "', SexID ="
                + userDTO.SexId + ", IDFunct ='" + userDTO.FunctionId + "', IsSync =" + userDTO.IsSync + ", IsDeleted =" + userDTO.IsDeleted + " where UserID ='" + userDTO.Id + "'";
            return sql;
        }

        public static void Insert(UserDTO userDTO)
        {
            string sql = getInsertSql(userDTO);
            (new Database()).ExcuNonQuery(sql);
        }

        public static void Update(UserDTO userDTO)
        {
            string sql = getUpdateSql(userDTO);
            (new Database()).ExcuNonQuery(sql);
        }

        public static bool InsertNoErrorMessage(UserDTO userDTO)
        {
            string sql = getInsertSql(userDTO);
            return (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static bool UpdateNoErrorMessage(UserDTO userDTO)
        {
            string sql = getUpdateSql(userDTO);
            return (new Database()).ExcuNonQueryNoErrorMessage(sql);
        }

        public static bool UpdatePassword(string password, string account)
        {
            string sql = "update UserCar set Pass =N'" + password + "' where Account =N'" + account + "'";
            return (new Database()).ExcuNonQuery(sql);
        }

        public static bool UpdateRememberMe(int isRemember, string account)
        {
            string sql = "update UserCar set RememberMe =" + isRemember + " where Account ='" + account + "'";
            return (new Database()).ExcuNonQuery(sql);
        }

        public static DataTable GetUserByAccount(string account)
        {
            string sql = "select * from UserCar where UserCar.Account = '" + account + "'";
            return (new Database()).ExcuQuery(sql);
        }

        public static DataTable GetUserByID(string id)
        {
            string sql = "select * from UserCar where UserCar.UserID = '" + id + "'";
            return (new Database()).ExcuQuery(sql);
        }

        public static UserDTO GetUserModelByID(string id)
        {
            UserDTO userDTO = new UserDTO();
            DataTable dt = GetUserByID(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                userDTO.Id = dt.Rows[0].Field<string>("UserID");
                userDTO.Account = dt.Rows[0].Field<string>("Account");
                userDTO.Password = dt.Rows[0].Field<string>("Pass");
                userDTO.Name = dt.Rows[0].Field<string>("NameUser");
                userDTO.SexId = dt.Rows[0].Field<int>("SexID");
                userDTO.FunctionId = dt.Rows[0].Field<string>("IDFunct");
            }
            return userDTO;
        }

        public static string GetUserNameByID(string id)
        {
            DataTable dt = GetUserByID(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<string>("NameUser");
            } else
            {
                return "";
            }
        }

        public static string GetAccountByID(string id)
        {
            DataTable dt = GetUserByID(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<string>("Account");
            }
            else
            {
                return "";
            }
        }

        public static string GetPasswordByAccount(string account)
        {
            DataTable dt = GetUserByAccount(account);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<string>("Pass");
            }
            else
            {
                return "";
            }
        }

        public static int GetRememberByAccount(string account)
        {
            DataTable dt = GetUserByAccount(account);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<Int32>("RememberMe");
            }
            else
            {
                return 0;
            }
        }

        public static string GetFunctionIDByUserID(string id)
        {
            DataTable dt = GetUserByID(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0].Field<string>("IDFunct");
            }
            else
            {
                return "";
            }
        }

        public static void Delete(string userID)
        {
            string sql = "delete from UserCar where UserID = '" + userID + "'";
            (new Database()).ExcuNonQuery(sql);
        }

        public static void syncFromJson(string json)
        {
            JArray jArray = JArray.Parse(json);
            foreach (JObject jObject in jArray)
            {
                UserDTO userDTO = new UserDTO();
                userDTO.Id = (string)jObject.SelectToken("employee_code");
                userDTO.Account = (string)jObject.SelectToken("user_name");
                userDTO.Password = (string)jObject.SelectToken("pass");
                userDTO.Name = (string)jObject.SelectToken("name");              
                int sexID = 1;
                try
                {
                    Int32.TryParse((string)jObject.SelectToken("sex"), out sexID);
                }
                catch (Exception)
                {

                }
                userDTO.SexId = sexID;
                userDTO.FunctionId = (string)jObject.SelectToken("position");

                userDTO.IsSync = "1";
                userDTO.IsDeleted = (bool)jObject.SelectToken("deleted") ? "1" : "0";

                InsertOrUpdate(userDTO);
            }
        }

        public static void InsertOrUpdate(UserDTO userDTO)
        {
            if (!InsertNoErrorMessage(userDTO))
            {
                UpdateNoErrorMessage(userDTO);
            }
        }
    }
}

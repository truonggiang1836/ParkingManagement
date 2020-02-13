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
            return Database.ExcuQuery(sql);
        }

        public static DataTable GetID_Name_Function()
        {
            string sql = "select UserCar.UserID, UserCar.NameUser, Functional.FunctionName from UserCar, Functional " +
                "where Functional.FunctionID = UserCar.IDFunct";
            return Database.ExcuQuery(sql);
        }

        public static void Insert(UserDTO userDTO)
        {
            string sql = "insert into UserCar(UserID, Account, Pass, NameUser, SexID, IDFunct, RememberMe) values ('" + userDTO.Id + "', '" + userDTO.Account + "', '" + 
                userDTO.Password + "', '" + userDTO.Name + "', " + userDTO.SexId + ", '" + userDTO.FunctionId + "', " + 0 + ")";
            Database.ExcuNonQuery(sql);
        }

        public static void Update(UserDTO userDTO)
        {
            string sql = "update UserCar set Account ='" + userDTO.Account + "', Pass ='" + userDTO.Password + "', NameUser ='" + userDTO.Name + "', SexID ="
                + userDTO.SexId + ", IDFunct ='" + userDTO.FunctionId + "' where UserID ='" + userDTO.Id + "'";
            Database.ExcuNonQuery(sql);
        }

        public static bool UpdatePassword(string password, string account)
        {
            string sql = "update UserCar set Pass ='" + password + "' where Account ='" + account + "'";
            return Database.ExcuNonQuery(sql);
        }

        public static bool UpdateRememberMe(int isRemember, string account)
        {
            string sql = "update UserCar set RememberMe =" + isRemember + " where Account ='" + account + "'";
            return Database.ExcuNonQuery(sql);
        }

        public static DataTable GetUserByAccount(string account)
        {
            string sql = "select * from UserCar where UserCar.Account = '" + account + "'";
            return Database.ExcuQuery(sql);
        }

        public static DataTable GetUserByID(string id)
        {
            string sql = "select * from UserCar where UserCar.UserID = '" + id + "'";
            return Database.ExcuQuery(sql);
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
            Database.ExcuNonQuery(sql);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkingMangement.Utils
{
    class ApiUtil
    {
        public static string SECRET_KEY = "parkingmanagement";
        public static string HEADER_USER_ID = "User-Id";
        public static string HEADER_AUTHORIZATION = "Authorization";
        public static string PARAM_API_AUTH_DATE = "api_auth_date";
        public static string PARAM_API_AUTH_KEY = "api_auth_key";
        public static string PARAM_ACCOUNT = "account";
        public static string PARAM_PASSWORD = "password";
        public static string PARAM_ID = "id";
        public static string PARAM_STT = "stt";
        public static string PARAM_CODE = "code";
        public static string PARAM_VEHICLE_ID = "vehicle_id";
        public static string PARAM_PC_NAME = "pc_name";
        public static string PARAM_CARD_CODE = "card_code";
        public static string PARAM_CAR_NUMBER = "car_number";
        public static string PARAM_CAR_STT = "car_stt";
        public static string PARAM_CREATED_FROM = "created_from";
        public static string PARAM_CREATED_TO = "created_to";
        public static string PARAM_PAGE = "page";
        public static string PARAM_LIMIT = "limit";
        public static string PARAM_DISABLE = "disable";
        public static string PARAM_DATA = "data";

        public static string BASE_URL = "http://apipm.hoanganhonline.com/public/";
        public static string API_LOGIN = BASE_URL + "admins/login";
        public static string API_ADD_UPDATE_CARD = BASE_URL + "cards/addupdate";
        public static string API_CHECKIN = BASE_URL + "cards/checkin";
        public static string API_CHECKOUT = BASE_URL + "cards/checkout";
        public static string API_ORDERS_LIST = BASE_URL + "orders/list";
        public static string API_ORDERS_BATCH_INSERT = BASE_URL + "orders/batchinsert";

        private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }

        public WebClient getWebClient()
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                if (!Program.CurrentUserID.Equals(""))
                {
                    webClient.Headers.Set(HEADER_USER_ID, Program.CurrentUserID);
                }
                if (!Program.CurrentToken.Equals(""))
                {
                    webClient.Headers.Set(HEADER_AUTHORIZATION, Program.CurrentToken);
                }

                long currentSecond = CurrentTimeMillis() / 1000;
                string apiAuthDate = currentSecond.ToString();
                webClient.QueryString.Add(PARAM_API_AUTH_DATE, apiAuthDate);
                string apiAuthKey = CreateMD5(SECRET_KEY + apiAuthDate);
                webClient.QueryString.Add(PARAM_API_AUTH_KEY, apiAuthKey);
                return webClient;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}

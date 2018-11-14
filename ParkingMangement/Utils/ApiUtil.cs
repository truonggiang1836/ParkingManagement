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
        public static string PARAM_API_AUTH_DATE = "api_auth_date";
        public static string PARAM_API_AUTH_KEY = "api_auth_key";
        public static string PARAM_ACCOUNT = "account";
        public static string PARAM_PASSWORD = "password";


        public static string BASE_URL = "http://apipm.hoanganhonline.com/public/";
        public static string API_LOGIN = BASE_URL + "admins/login";

        private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }

        public static WebClient getWebClient()
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                long currentSecond = CurrentTimeMillis() / 1000;
                string apiAuthDate = currentSecond.ToString();
                webClient.QueryString.Add(PARAM_API_AUTH_DATE, apiAuthDate);
                string apiAuthKey = CreateMD5(SECRET_KEY + apiAuthDate);
                webClient.QueryString.Add(PARAM_API_AUTH_KEY, apiAuthKey);
                return webClient;
            }
            catch (Exception)
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

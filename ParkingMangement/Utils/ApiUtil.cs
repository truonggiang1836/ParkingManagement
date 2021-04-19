using System;
using System.Collections.Generic;
using System.IO;
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
        public static string PARAM_LICENSE_PLATE = "license_plate";
        public static string PARAM_CUSTOMER_NAME = "customer_name";
        public static string PARAM_FEE = "fee";
        public static string PARAM_PHONE = "phone";
        public static string PARAM_APARTMENT = "apartment";
        public static string PARAM_TYPE = "type";
        public static string PARAM_FROM_DATE = "from_date";
        public static string PARAM_TO_DATE = "to_date";
        public static string PARAM_CARD_NUMBER_SPM = "cardnumber";

        public static string PARAM_CAR_NUMBER = "car_number";
        public static string PARAM_CAR_STT = "car_stt";
        public static string PARAM_CREATED_FROM = "created_from";
        public static string PARAM_CREATED_TO = "created_to";
        public static string PARAM_PAGE = "page";
        public static string PARAM_LIMIT = "limit";
        public static string PARAM_DISABLE = "disable";
        public static string PARAM_DATA = "ordersDtos";
        public static string PARAM_PROJECT_ID = "projectId";
        public static string PARAM_KEY = "key";
        public static string PARAM_KEY_VALUE = "0919669444";
        public static string PARAM_SIGNATURE = "signature";
        public static string PARAM_SIGNATURE_VALUE = "cd6a9bd2a175104eed40f0d33a8b4020";      
        public static string PARAM_CARD_NUMBER = "card_number";
        public static string PARAM_STATUS = "status";     

        //public static string BASE_URL = "http://apipm.hoanganhonline.com/public/";
        //public static string BASE_URL = "http://api.spmgroup.vn/public/";
        //public static string BASE_URL = "http://api.spmgroup.vn:8080/parking-apis/";
        //public static string BASE_URL = "http://13.59.183.208:8080/parking-apis/";
        public static string BASE_URL = "https://spmpayment.vn/api/";
        public static string BASE_PI_HOME_URL = @"http://tinh.pihome.asia/api/v1/";

        public static string API_LOGIN = BASE_URL + "admins/login";
        public static string API_ADD_UPDATE_CARD = BASE_URL + "cards/addupdate";
        public static string API_CHECKIN = BASE_URL + "cards/checkin";
        public static string API_CHECKOUT = BASE_URL + "cards/checkout";
        public static string API_ORDERS_LIST = BASE_URL + "orders/list";
        public static string API_ORDERS_BATCH_INSERT = BASE_URL + "orders/batchinsert";
        public static string API_CARDS_BATCH_INSERT = BASE_URL + "cards/batchinsert";
        public static string API_CARDS_BATCH_SYNCS = BASE_URL + "cards/batchsyncs";
        public static string API_MONTHLY_CARDS_BATCH_INSERT = BASE_URL + "monthlycards/batchinsert";
        public static string API_MONTHLY_CARDS_BATCH_SYNCS = BASE_URL + "monthlycards/batchsyncs";
        public static string API_VEHICLE_BATCH_INSERT = BASE_URL + "vehicle/batchinsert";
        public static string API_VEHICLE_BATCH_SYNCS = BASE_URL + "vehicle/batchsyncs";
        public static string API_EMPLOYEE_BATCH_INSERT = BASE_URL + "employee/batchinsert";
        public static string API_EMPLOYEE_BATCH_SYNCS = BASE_URL + "employee/batchsyncs";
        public static string API_FUNCTIONS_BATCH_INSERT = BASE_URL + "functions/batchinsert";
        public static string API_FUNCTIONS_BATCH_SYNCS = BASE_URL + "functions/batchsyncs";
        public static string API_CONFIG_BATCH_INSERT = BASE_URL + "config/batchinsert";
        public static string API_CONFIG_BATCH_SYNCS = BASE_URL + "config/batchsyncs";
        public static string API_BLACK_CAR_BATCH_INSERT = BASE_URL + "back-car/batchinsert";
        public static string API_BLACK_CAR_BATCH_SYNCS = BASE_URL + "back-car/batchsyncs";
        public static string API_PRICE_CONFIG_BATCH_INSERT = BASE_URL + "price-config/batchinsert";
        public static string API_PRICE_CONFIG_BATCH_SYNCS = BASE_URL + "price-config/batchsyncs";

        public static string API_MONTHLY_CARDS_SYNCS_SPM = BASE_URL + "get_v2.php";
        public static string API_MONTHLY_CARDS_SET_SYNC_DONE_SPM = BASE_URL + "set_v2.php";
        public static string API_REVENUE_SYNC_SPM = BASE_URL + "winapp/";

        public static string API_MONTHLY_CARDS_SYNCS_PI_HOME = BASE_PI_HOME_URL + "parking/vehicles";
        public static string API_MONTHLY_CARDS_UPDATE_PI_HOME = BASE_PI_HOME_URL + "parking/vehicles/update";
        public static string API_PARTS_SYNCS_PI_HOME = BASE_PI_HOME_URL + "parking/vehicle-types";

        private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }

        public WebClient getWebClient()
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                //webClient.Headers["Content-Type"] = "raw";
                webClient.Headers.Set("Content-Type", "application/json");
                //webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                //if (!Program.CurrentUserID.Equals(""))
                //{
                //    webClient.Headers.Set(HEADER_USER_ID, Program.CurrentUserID);
                //}
                //if (!Program.CurrentToken.Equals(""))
                //{
                //    webClient.Headers.Set(HEADER_AUTHORIZATION, Program.CurrentToken);
                //}

                //long currentSecond = CurrentTimeMillis() / 1000;
                //string apiAuthDate = currentSecond.ToString();
                //webClient.QueryString.Add(PARAM_API_AUTH_DATE, apiAuthDate);
                //string apiAuthKey = CreateMD5(SECRET_KEY + apiAuthDate);
                //webClient.QueryString.Add(PARAM_API_AUTH_KEY, apiAuthKey);

                webClient.QueryString.Add(ApiUtil.PARAM_KEY, Util.getConfigFile().projectId);
                return webClient;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public WebClient getPostRawWebClient()
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.Headers["Content-Type"] = "raw";
                return webClient;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public WebClient getPiHomeWebClient()
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                WebClient webClient = new WebClient();
                webClient.UseDefaultCredentials = true;
                webClient.Headers.Set("Content-Type", "application/x-www-form-urlencoded");
                //webClient.Encoding = Encoding.UTF8;
                //webClient.Headers["Content-Type"] = "raw";
                //webClient.Headers.Set("Content-Type", "application/json");
                webClient.QueryString.Add(ApiUtil.PARAM_SIGNATURE, Util.getConfigFile().signature);
                return webClient;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
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

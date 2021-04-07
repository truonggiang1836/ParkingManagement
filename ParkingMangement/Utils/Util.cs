using AxAXVLC;
using Newtonsoft.Json;
using ParkingMangement.DAO;
using ParkingMangement.DTO;
using ParkingMangement.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ParkingMangement.Utils
{
    static class Util
    {
        private static Config sConfig = null;

        public static void deleteDirectoryIfEmpty(string startLocation)
        {
            foreach (var directory in Directory.GetDirectories(startLocation))
            {
                deleteDirectoryIfEmpty(directory);
                if (Directory.GetFiles(directory).Length == 0 &&
                    Directory.GetDirectories(directory).Length == 0)
                {
                    try
                    {
                        Directory.Delete(directory, false);
                    } catch (Exception e)
                    {

                    }
                }
            }
        }
        public static string ImageToBase64(string Path)
        {
            using (Image image = Image.FromFile(Path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }

        public static Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        public static Bitmap GetCompressedBitmap(Bitmap bmp, long quality)
        {
            using (var mss = new MemoryStream())
            {
                EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                ImageCodecInfo imageCodec = ImageCodecInfo.GetImageEncoders().FirstOrDefault(o => o.FormatID == ImageFormat.Jpeg.Guid);
                EncoderParameters parameters = new EncoderParameters(1);
                parameters.Param[0] = qualityParam;
                bmp.Save(mss, imageCodec, parameters);
                return new Bitmap (Image.FromStream(mss));
            }
        }

        public static void showConfirmLogoutPopup(Form f)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn đăng xuất không?", "Đăng xuất", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                doLogOut();
                f.Hide();
                var formLogin = new FormLogin();
                formLogin.Closed += (s, args) => f.Close();
                formLogin.Show();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        public static void doLogOut()
        {
            if (Program.CurrentUserID != null)
            {
                Program.EndWorkTime = DateTime.Now;
                WorkDTO workDTO = new WorkDTO();
                workDTO.UserID = Program.CurrentUserID;
                workDTO.TimeStart = Program.StartWorkTime;
                workDTO.TimeEnd = Program.EndWorkTime;
                workDTO.Computer = Environment.MachineName;
                WorkDAO.Insert(workDTO);
            }

            LogUtil.addLogoutLog();
        }

        public static DateTime MillisecondToDateTime(long milliSec)
        {
            DateTime startTime = new DateTime(1970, 1, 1);
            TimeSpan time = TimeSpan.FromMilliseconds(milliSec);
            return startTime.Add(time);
        }

        public static long DateTimeToMillisecond(DateTime date)
        {
            return Convert.ToInt64(date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds);
        }

        public static void CreateFolderIfMissing(string path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
                Directory.CreateDirectory(path);
        }

        public static double getTotalTimeByMinute(DateTime timeStart, DateTime timeEnd)
        {
            TimeSpan duration = timeEnd - timeStart;
            return duration.TotalMinutes;
        }

        public static double getTotalTimeByHour(DateTime timeStart, DateTime timeEnd)
        {
            TimeSpan duration = timeEnd - timeStart;
            return Math.Round(duration.TotalHours, 2);
        }

        public static int getTotalTimeByDay(DateTime timeStart, DateTime timeEnd)
        {
            //if (timeEnd.Year == timeStart.Year)
            //{
            //    return timeEnd.DayOfYear - timeStart.DayOfYear;
            //} else
            //{
            //    TimeSpan duration = timeEnd - timeStart;
            //    return (int)duration.TotalDays;
            //}
            return (int) getTotalTimeByHour(timeStart, timeEnd) / 24;
        }
        public static string getCurrentDateTimeString()
        {
            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            String year = datevalue.Year.ToString();
            String month = datevalue.Month.ToString();
            String day = datevalue.Day.ToString();
            String hour = datevalue.Hour.ToString();
            String minute = datevalue.Minute.ToString();
            String second = datevalue.Second.ToString();
            return year + month + day + "_" + hour + minute + second;
        }

        public static DateTime getDateTimeFromMilliSecond(double milliSec)
        {
            DateTime startTime = new DateTime(1970, 1, 1);
            TimeSpan time = TimeSpan.FromMilliseconds(milliSec);
            return startTime.Add(time);
        }

        public static void setRowNumber(DataGridView dgv, string columnName)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells[columnName].Value = (row.Index + 1).ToString();
                }
            }
        }

        public static string formatNumberAsMoney(long number)
        {
            if (number != 0)
            {
                return string.Format("{0:#,000}", number);
            }
            return "0";
        }

        public static double getMillisecondBetweenTwoDate(DateTime? oldDate, DateTime newDate)
        {
            TimeSpan span = newDate - oldDate.Value;
            double ms = span.TotalMilliseconds;
            return ms;
        }

        public static Config getConfigFile()
        {
            if (sConfig != null)
            {
                return sConfig;
            }
            try
            {
                String filePath = Application.StartupPath + "\\" + Constant.sFileNameConfig;
                if (File.Exists(filePath))
                {
                    string xmlString = File.ReadAllText(filePath);
                    XmlRootAttribute xmlRoot = new XmlRootAttribute();
                    xmlRoot.ElementName = "xml";
                    xmlRoot.IsNullable = true;
                    XmlSerializer serializer = new XmlSerializer(typeof(Config), xmlRoot);
                    using (TextReader reader = new StringReader(xmlString))
                    {
                        sConfig = (Config)serializer.Deserialize(reader);
                        sConfig.cameraUrl1 = sConfig.cameraUrl1.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.cameraUrl2 = sConfig.cameraUrl2.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.cameraUrl3 = sConfig.cameraUrl3.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.cameraUrl4 = sConfig.cameraUrl4.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.rfidIn = sConfig.rfidIn.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.rfidOut = sConfig.rfidOut.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.computerName = sConfig.computerName.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.sqlDataSource = sConfig.sqlDataSource.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.sqlPort = sConfig.sqlPort.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.sqlUsername = sConfig.sqlUsername.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.sqlPassword = sConfig.sqlPassword.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.folderRoot = sConfig.folderRoot.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.comReceiveIn = sConfig.comReceiveIn.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.comReceiveOut = sConfig.comReceiveOut.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.comReaderLeft = sConfig.comReaderLeft.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.comReaderRight = sConfig.comReaderRight.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.comSend = sConfig.comSend.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.comLedLeft = sConfig.comLedLeft.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.comLedRight = sConfig.comLedRight.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.comLostAvailable = sConfig.comLostAvailable.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.signalOpenBarieIn = sConfig.signalOpenBarieIn.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.signalCloseBarieIn = sConfig.signalCloseBarieIn.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.signalOpenBarieOut = sConfig.signalOpenBarieOut.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.signalCloseBarieOut = sConfig.signalCloseBarieOut.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.signalOpenBarieInMotorbike = sConfig.signalOpenBarieInMotorbike.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.signalCloseBarieInMotorbike = sConfig.signalCloseBarieInMotorbike.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.signalOpenBarieOutMotorbike = sConfig.signalOpenBarieOutMotorbike.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.signalCloseBarieOutMotorbike = sConfig.signalCloseBarieOutMotorbike.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        return sConfig;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        public static string EscapeXml(this string s)
        {
            string toxml = s;
            if (!string.IsNullOrEmpty(toxml))
            {
                // replace literal values with entities
                toxml = toxml.Replace("'", "&apos;");
                toxml = toxml.Replace("\"", "&quot;");
                toxml = toxml.Replace(">", "&gt;");
                toxml = toxml.Replace("<", "&lt;");
                toxml = toxml.Replace("&", "&amp;");
            }
            return toxml;
        }

        public static string UnescapeXml(this string s)
        {
            string unxml = s;
            if (!string.IsNullOrEmpty(unxml))
            {
                // replace entities with literal values
                unxml = unxml.Replace("&apos;", "'");
                unxml = unxml.Replace("&quot;", "\"");
                unxml = unxml.Replace("&gt;", ">");
                unxml = unxml.Replace("&lt;", "<");
                unxml = unxml.Replace("&amp;", "&");
            }
            return unxml;
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private static Order getOrderFromData(DataRow dtRow)
        {
            Order order = new Order();
            order.ProjectId = Util.getConfigFile().projectId;
            order.OrderId = dtRow.Field<int>("Identify");
            order.CardSTT = dtRow.Field<string>("SmartCardIdentify");
            order.CardCode = dtRow.Field<string>("ID");
            DateTime checkinDatetime = dtRow.Field<DateTime>("TimeStart");
            //checkinDatetime = checkinDatetime.AddHours(11);
            //order.CheckinTime = checkinDatetime.ToString(Constant.sDateTimeFormatForAPI);
            order.CheckinTime = DateTimeToMillisecond(checkinDatetime);
            if (dtRow.Field<DateTime?>("TimeEnd") != null)
            {
                DateTime checkoutDatetime = dtRow.Field<DateTime>("TimeEnd");
                //checkoutDatetime = checkoutDatetime.AddHours(11);
                //order.CheckoutTime = checkoutDatetime.ToString(Constant.sDateTimeFormatForAPI);
                order.CheckoutTime = DateTimeToMillisecond(checkoutDatetime);
            }
            if (dtRow["Digit"] != DBNull.Value)
            {
                order.CarNumber = dtRow.Field<string>("Digit");
            }
            if (dtRow["DigitIn"] != DBNull.Value)
            {
                order.CarNumberIn = dtRow.Field<string>("DigitIn");
            }
            if (dtRow["DigitOut"] != DBNull.Value)
            {
                order.CarNumberOut = dtRow.Field<string>("DigitOut");
            }

            int adminCheckinId = 0;
            Int32.TryParse(dtRow.Field<string>("IDIn"), out adminCheckinId);
            order.AdminCheckinId = adminCheckinId;

            order.AdminCheckinName = dtRow.Field<string>("UserIn");
            int adminCheckoutId = 0;
            if (dtRow["IDOut"] != DBNull.Value)
            {
                Int32.TryParse(dtRow.Field<string>("IDOut"), out adminCheckoutId);
            }
            order.AdminCheckoutId = adminCheckoutId;

            order.AdminCheckoutName = dtRow.Field<string>("UserOut");

            int monthlyCardId = 0;
            if (dtRow["IDTicketMonth"] != DBNull.Value)
            {
                Int32.TryParse(dtRow.Field<string>("IDTicketMonth"), out monthlyCardId);
            }
            order.MonthlyCardId = monthlyCardId;


            int vehicleId = 0;
            try
            {
                Int32.TryParse(dtRow.Field<string>("IDPart"), out vehicleId);
            }
            catch (Exception)
            {

            }
            order.VehicleId = vehicleId;

            order.VehicleName = dtRow.Field<string>("PartName");
            order.VehicleCode = dtRow.Field<string>("Sign");
            order.IsCardLost = dtRow.Field<int>("IsLostCard");
            order.TotalPrice = dtRow.Field<int>("Cost");
            order.PcName = dtRow.Field<string>("Computer");
            order.Account = dtRow.Field<string>("Account");
            DateTime dateUpdate = dtRow.Field<DateTime>("DateUpdate");
            //dateUpdate = checkinDatetime.AddHours(11);
            order.Created = DateTimeToMillisecond(dateUpdate);
            order.Updated = DateTimeToMillisecond(dateUpdate);
            return order;
        }

        private static bool sendOrderListToServer(DataTable data, bool isCarIn)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return false;
            }
            DataTable dtTable = data;
            List<Order> listOrder = new List<Order>();
            WebClient webClient = (new ApiUtil()).getWebClient();
            string jsonString = "";
            string listId = "";
            long firstId = 0;
            int count = dtTable.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                DataRow dtRow = dtTable.Rows[i];
                Order order = getOrderFromData(dtRow);
                listOrder.Add(order);
                                
                listId += order.OrderId + ",";    
            }
            if (listOrder.Count > 0)
            {
                listId = listId.Remove(listId.Length - 1, 1);
                listId = "(" + listId + ")";
                firstId = listOrder[0].OrderId;

                jsonString = JsonConvert.SerializeObject(listOrder);
                Console.WriteLine(":: " + jsonString);
            } else
            {
                listId = "";
            }    

            try
            {
                if (!jsonString.Equals(""))
                {
                    string result = webClient.UploadString(new Uri(ApiUtil.API_ORDERS_BATCH_INSERT), "POST", jsonString);
                    Console.WriteLine("result_api: " + result);

                    if (result.Equals("") || result.Equals("success"))
                    {
                        if (isCarIn)
                        {
                            WaitSyncCarInDAO.DeleteWhereListId(listId);
                        }
                        else
                        {
                            WaitSyncCarOutDAO.DeleteWhereListId(listId);
                        }
                    } else
                    {
                        updateSyncOrderMessage(firstId, result, isCarIn);
                    }               
                }
                Console.WriteLine("json_api: " + jsonString);
                
                return true;
            }
            catch (Exception e)
            {
                updateSyncOrderMessage(firstId, e.Message, isCarIn);
            }
            return false;
        }

        public static bool sendOldOrderListToServer(DataTable data)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return false;
            }
            DataTable dtTable = data;
            List<Order> listOrder = new List<Order>();
            WebClient webClient = (new ApiUtil()).getWebClient();
            string jsonString = "";
            string listId = "";
            int count = dtTable.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                DataRow dtRow = dtTable.Rows[i];
                Order order = getOrderFromData(dtRow);
                listOrder.Add(order);

                listId += order.OrderId + ",";
            }
            if (listOrder.Count > 0)
            {
                listId = listId.Remove(listId.Length - 1, 1);
                listId = "(" + listId + ")";

                jsonString = JsonConvert.SerializeObject(listOrder);
                Console.WriteLine(":: " + jsonString);
            }
            else
            {
                listId = "";
            }

            try
            {
                if (!jsonString.Equals(""))
                {
                    string result = webClient.UploadString(new Uri(ApiUtil.API_ORDERS_BATCH_INSERT), "POST", jsonString);
                    Console.WriteLine("result_api: " + result);

                    if (result.Equals("") || result.Equals("success"))
                    {
                        CarDAO.UpdateIsSync(listId);
                    }                   
                }
                Console.WriteLine("json_api: " + jsonString);

                return true;
            }
            catch (Exception e)
            {

            }
            return false;
        }

        private static void updateSyncOrderMessage(long identify, string message, bool isCarIn)
        {
            if (isCarIn)
            {
                WaitSyncCarInDAO.UpdateMessage(identify, message);
            }
            else
            {
                WaitSyncCarOutDAO.UpdateMessage(identify, message);
            }
        }

        public static void sendCardListToServer(DataTable data)
        {
            //return;
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            DataTable dtTable = data;
            List<Card> listCard = new List<Card>();
            WebClient webClient = (new ApiUtil()).getWebClient();
            string jsonString = "";
            string listId = "(";
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                DataRow dtRow = dtTable.Rows[i];
                Card card = new Card();
                card.AreaId = 1;
                card.ProjectId = Util.getConfigFile().projectId;
                card.Code = dtRow.Field<string>("Id");
                card.Stt = dtRow.Field<string>("Identify");
                int adminId = 0;
                try
                {
                    Int32.TryParse(Program.CurrentUserID, out adminId);
                }
                catch (Exception)
                {

                }
                card.AdminId = adminId;
                if (dtRow.Field<string>("IsUsing").Equals("1"))
                {
                    card.Disable = 0;
                }
                else
                {
                    card.Disable = 1;
                }
                if (dtRow.Field<int>("IsDeleted") == 1)
                {
                    card.Deleted = 1;
                }
                
                int vehicleId = 0;
                try
                {
                    Int32.TryParse(dtRow.Field<string>("Type"), out vehicleId);
                }
                catch (Exception)
                {

                }
                card.VehicleId = vehicleId;
                //card.Id = 999;
                card.MonthlyCardId = 0;
                DateTime dateUpdate = dtRow.Field<DateTime>("DayUnlimit");
                card.Created = DateTimeToMillisecond(dateUpdate);
                card.Updated = DateTimeToMillisecond(dateUpdate);
                listCard.Add(card);
                
                listId += "'" + card.Code + "',";                

                //if (listCard.Count == 10)
                //{
                //    break;
                //}
            }
            if (listCard.Count > 0)
            {
                listId = listId.Remove(listId.Length - 1, 1);
                listId += ")";

                jsonString = JsonConvert.SerializeObject(listCard);
                Console.WriteLine(":: " + jsonString);
            }
            else
            {
                listId = "";
            }

            try
            {
                //byte[] responsebytes = webClient.UploadValues(ApiUtil.API_ORDERS_BATCH_INSERT, "POST", param);
                if (!jsonString.Equals(""))
                {
                    string result = webClient.UploadString(new Uri(ApiUtil.API_CARDS_BATCH_INSERT), "POST", jsonString);
                    Console.WriteLine("result_api: " + result);
                    if (result.Equals("") || result.Equals("success"))
                    {
                        CardDAO.UpdateIsSync(listId);
                    }
                }
                Console.WriteLine("json_api: " + jsonString);
            }
            catch (Exception e)
            {
                
            }
        }

        public static void sendMonthlyCardListToServer(DataTable data)
        {
            //return;
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            DataTable dtTable = data;
            List<MonthlyCard> listCard = new List<MonthlyCard>();
            WebClient webClient = (new ApiUtil()).getWebClient();
            string jsonString = "";
            string listId = "(";
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                DataRow dtRow = dtTable.Rows[i];
                MonthlyCard monthlyCard = new MonthlyCard();
                monthlyCard.AreaId = 1;
                monthlyCard.ProjectId = Util.getConfigFile().projectId;
                monthlyCard.Address = dtRow.Field<string>("Address");
                int adminId = 0;
                try
                {
                    Int32.TryParse(dtRow.Field<string>("Account"), out adminId);
                }
                catch (Exception)
                {

                }
                monthlyCard.AdminId = adminId;
                monthlyCard.CarNumber = dtRow.Field<string>("Digit");
                monthlyCard.Company = dtRow.Field<string>("Company");
                monthlyCard.CompanyId = 1;
                monthlyCard.CustomerName = dtRow.Field<string>("CustomerName");
                if (dtRow.Field<int>("IsDeleted") == 1)
                {
                    monthlyCard.Deleted = 1;
                }
                    
                monthlyCard.Email = dtRow.Field<string>("Email");


                monthlyCard.Created = DateTimeToMillisecond(DateTime.Now);
                monthlyCard.Updated = DateTimeToMillisecond(DateTime.Now);
                try
                {
                    DateTime startDate = dtRow.Field<DateTime>("RegistrationDate");
                    monthlyCard.StartDate = DateTimeToMillisecond(startDate);
                    DateTime endDate = dtRow.Field<DateTime>("ExpirationDate");
                    monthlyCard.EndDate = DateTimeToMillisecond(endDate);

                    DateTime dateUpdate = dtRow.Field<DateTime>("DayUnlimit");
                    monthlyCard.Created = DateTimeToMillisecond(dateUpdate);
                    monthlyCard.Updated = DateTimeToMillisecond(dateUpdate);
                }
                catch (Exception)
                {

                }
                monthlyCard.CardCode = dtRow.Field<string>("ID");
                monthlyCard.IdNumber = dtRow.Field<string>("CMND");
                int parkingFee = 0;
                try
                {
                    Int32.TryParse(dtRow.Field<string>("ChargesAmount"), out parkingFee);
                }
                catch (Exception)
                {

                }
                monthlyCard.ParkingFee = parkingFee;
                int vehicleId = 0;
                try
                {
                    Int32.TryParse(dtRow.Field<string>("Type"), out vehicleId);
                }
                catch (Exception)
                {

                }
                monthlyCard.VehicleId = vehicleId;

                listCard.Add(monthlyCard);
                listId += "'" + monthlyCard.CardCode + "',";

                //if (listCard.Count == 10)
                //{
                //    break;
                //}
            }

            if (listCard.Count > 0)
            {
                jsonString = JsonConvert.SerializeObject(listCard);
                Console.WriteLine(":: " + jsonString);

                listId = listId.Remove(listId.Length - 1, 1);
                listId += ")";
            } else
            {
                listId = "";
            }
            
            try
            {
                //byte[] responsebytes = webClient.UploadValues(ApiUtil.API_ORDERS_BATCH_INSERT, "POST", param);
                if (!jsonString.Equals(""))
                {
                    string result = webClient.UploadString(new Uri(ApiUtil.API_MONTHLY_CARDS_BATCH_INSERT), "POST", jsonString);
                    Console.WriteLine("result_api: " + result);
                    if (result.Equals("") || result.Equals("success"))
                    {
                        TicketMonthDAO.UpdateIsSync(listId);
                    }
                }
                Console.WriteLine("json_api: " + jsonString);
                //String responseString = Encoding.UTF8.GetString(responsebytes);

                //webClient.UploadData(ApiUtil.API_ORDERS_BATCH_INSERT, "POST", Encoding.Default.GetBytes(jsonString));
            }
            catch (Exception e)
            {

            }
        }

        public static void sendVehicleListToServer(DataTable data)
        {
            //return;
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            DataTable dtTable = data;
            List<Vehicle> listVehicle = new List<Vehicle>();
            WebClient webClient = (new ApiUtil()).getWebClient();
            var param = new System.Collections.Specialized.NameValueCollection();
            string jsonString = "";
            string listId = "(";
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                DataRow dtRow = dtTable.Rows[i];
                Vehicle vehicle = new Vehicle();
                vehicle.ProjectId = Util.getConfigFile().projectId;
                int vehicleId = 0;
                try
                {
                    Int32.TryParse(dtRow.Field<string>("ID"), out vehicleId);
                }
                catch (Exception)
                {

                }
                vehicle.VehicleId = vehicleId;

                int vehicleType = 0;
                try
                {
                    Int32.TryParse(dtRow.Field<string>("TypeID"), out vehicleType);
                }
                catch (Exception)
                {

                }
                vehicle.VehicleType = vehicleType;

                int cardType = 0;
                try
                {
                    Int32.TryParse(dtRow.Field<string>("CardTypeID"), out cardType);
                }
                catch (Exception)
                {

                }
                vehicle.CardType = cardType;

                if (dtRow.Field<int>("IsDeleted") == 1)
                {
                    vehicle.Deleted = 1;
                }
                vehicle.Name = dtRow.Field<string>("PartName");
                vehicle.Code = dtRow.Field<string>("Sign");

                int monthlyCost = 0;
                try
                {
                    Int32.TryParse(dtRow.Field<string>("Amount"), out monthlyCost);
                }
                catch (Exception)
                {

                }
                vehicle.MonthlyCost = monthlyCost;

                listVehicle.Add(vehicle);

                jsonString = JsonConvert.SerializeObject(listVehicle);
                Console.WriteLine(":: " + jsonString);
                string index = (i + 1).ToString();
                param.Add(ApiUtil.PARAM_DATA + index, jsonString);
                listId += "'" + vehicle.Code + "',";
            }
            if (listId.Length > 1)
            {
                listId = listId.Remove(listId.Length - 1, 1);
                listId += ")";
            }
            else
            {
                listId = "";
            }

            try
            {
                if (!jsonString.Equals(""))
                {
                    string result = webClient.UploadString(new Uri(ApiUtil.API_VEHICLE_BATCH_INSERT), "POST", jsonString);
                    Console.WriteLine("result_api: " + result);
                    if (result.Equals("") || result.Equals("success"))
                    {
                        PartDAO.UpdateIsSync(listId);
                    }
                }
                Console.WriteLine("json_api: " + jsonString);
            }
            catch (Exception e)
            {

            }
        }

        public static void sendEmployeeListToServer(DataTable data)
        {
            //return;
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            DataTable dtTable = data;
            List<Emloyee> listEmployee = new List<Emloyee>();
            WebClient webClient = (new ApiUtil()).getWebClient();
            var param = new System.Collections.Specialized.NameValueCollection();
            string jsonString = "";
            string listId = "(";
            int count = dtTable.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                DataRow dtRow = dtTable.Rows[i];
                Emloyee emloyee = new Emloyee();
                emloyee.ProjectId = Util.getConfigFile().projectId;
                if (dtRow.Field<int>("IsDeleted") == 1)
                {
                    emloyee.Deleted = 1;
                }
                emloyee.Code = dtRow.Field<string>("UserID");
                emloyee.Name = dtRow.Field<string>("NameUser");
                emloyee.UserName = dtRow.Field<string>("Account");
                emloyee.Pass = dtRow.Field<string>("Pass");
                emloyee.Sex = dtRow.Field<int>("SexID") + "";
                emloyee.Position = dtRow.Field<string>("IDFunct");
                emloyee.Email = "";
                emloyee.Tel = "";

                listEmployee.Add(emloyee);

                jsonString = JsonConvert.SerializeObject(listEmployee);
                Console.WriteLine(":: " + jsonString);
                string index = (i + 1).ToString();
                param.Add(ApiUtil.PARAM_DATA + index, jsonString);
                listId += "'" + emloyee.Code + "',";
            }
            if (listId.Length > 1)
            {
                listId = listId.Remove(listId.Length - 1, 1);
                listId += ")";
            }
            else
            {
                listId = "";
            }

            try
            {
                if (!jsonString.Equals(""))
                {
                    string result = webClient.UploadString(new Uri(ApiUtil.API_EMPLOYEE_BATCH_INSERT), "POST", jsonString);
                    Console.WriteLine("result_api: " + result);
                    if (result.Equals("") || result.Equals("success"))
                    {
                        UserDAO.UpdateIsSync(listId);
                    }
                }
                Console.WriteLine("json_api: " + jsonString);
            }
            catch (Exception e)
            {

            }
        }

        public static void sendFunctionListToServer(DataTable data)
        {
            //return;
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            DataTable dtTable = data;
            List<Function> listFunction = new List<Function>();
            WebClient webClient = (new ApiUtil()).getWebClient();
            var param = new System.Collections.Specialized.NameValueCollection();
            string jsonString = "";
            string listId = "(";
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                DataRow dtRow = dtTable.Rows[i];
                Function function = new Function();
                function.ProjectId = Util.getConfigFile().projectId;
                function.FunctionId = dtRow.Field<string>("FunctionID");
                function.FunctionName = dtRow.Field<string>("FunctionName");
                function.FunctionSec = dtRow.Field<string>("FunctionSec");

                if (dtRow.Field<int>("IsDeleted") == 1)
                {
                    function.Deleted = 1;
                }
                listFunction.Add(function);

                jsonString = JsonConvert.SerializeObject(listFunction);
                Console.WriteLine(":: " + jsonString);
                string index = (i + 1).ToString();
                param.Add(ApiUtil.PARAM_DATA + index, jsonString);
                listId += "'" + function.FunctionId + "',";
            }
            if (listId.Length > 1)
            {
                listId = listId.Remove(listId.Length - 1, 1);
                listId += ")";
            }
            else
            {
                listId = "";
            }

            try
            {
                if (!jsonString.Equals(""))
                {
                    string result = webClient.UploadString(new Uri(ApiUtil.API_FUNCTIONS_BATCH_INSERT), "POST", jsonString);
                    Console.WriteLine("result_api: " + result);
                    if (result.Equals("") || result.Equals("success"))
                    {
                        FunctionalDAO.UpdateIsSync(listId);
                    }
                }
                Console.WriteLine("json_api: " + jsonString);
            }
            catch (Exception e)
            {

            }
        }

        public static void sendBlackCarListToServer(DataTable data)
        {
            //return;
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            DataTable dtTable = data;
            List<BlackCar> listBlackCar = new List<BlackCar>();
            WebClient webClient = (new ApiUtil()).getWebClient();
            var param = new System.Collections.Specialized.NameValueCollection();
            string jsonString = "";
            string listId = "(";
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                DataRow dtRow = dtTable.Rows[i];
                BlackCar blackCar = new BlackCar();
                if (dtRow.Field<int>("IsDeleted") == 1)
                {
                    blackCar.Deleted = 1;
                }
                blackCar.Digit = dtRow.Field<string>("Digit");
                listBlackCar.Add(blackCar);

                jsonString = JsonConvert.SerializeObject(listBlackCar);
                Console.WriteLine(":: " + jsonString);
                string index = (i + 1).ToString();
                param.Add(ApiUtil.PARAM_DATA + index, jsonString);
                listId += "'" + blackCar.Digit + "',";
            }
            if (listId.Length > 1)
            {
                listId = listId.Remove(listId.Length - 1, 1);
                listId += ")";
            }
            else
            {
                listId = "";
            }

            try
            {
                if (!jsonString.Equals(""))
                {
                    string result = webClient.UploadString(new Uri(ApiUtil.API_BLACK_CAR_BATCH_INSERT), "POST", jsonString);
                    Console.WriteLine("result_api: " + result);
                    if (result.Equals("") || result.Equals("success"))
                    {
                        BlackCarDAO.UpdateIsSync(listId);
                    }
                }
                Console.WriteLine("json_api: " + jsonString);
            }
            catch (Exception e)
            {

            }
        }

        public static void sendPriceConfigListToServer(DataTable data)
        {
            //return;
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            DataTable dtTable = data;
            List<PriceConfig> listPriceConfig = new List<PriceConfig>();
            WebClient webClient = (new ApiUtil()).getWebClient();
            string jsonString = "";
            string listId = "(";
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                DataRow dtRow = dtTable.Rows[i];
                PriceConfig priceConfig = new PriceConfig();
                priceConfig.Code = dtRow.Field<int>("Identify") + "";
                priceConfig.IdPart = dtRow.Field<string>("IDPart");
                priceConfig.ParkingTypeID = dtRow.Field<int>("ParkingTypeID");
                priceConfig.DayCost = dtRow.Field<int>("DayCost");
                priceConfig.NightCost = dtRow.Field<int>("NightCost");
                priceConfig.DayNightCost = dtRow.Field<int>("DayNightCost");
                priceConfig.IntervalBetweenDayNight = dtRow.Field<int>("IntervalBetweenDayNight");
                priceConfig.StartHourNight = dtRow.Field<int>("StartHourNight");
                priceConfig.EndHourNight = dtRow.Field<int>("EndHourNight");
                priceConfig.HourMilestone1 = dtRow.Field<int>("HourMilestone1");
                priceConfig.HourMilestone2 = dtRow.Field<int>("HourMilestone2");
                priceConfig.HourMilestone3 = dtRow.Field<int>("HourMilestone3");
                priceConfig.CostMilestone1 = dtRow.Field<int>("CostMilestone1");
                priceConfig.CostMilestone2 = dtRow.Field<int>("CostMilestone2");
                priceConfig.CostMilestone3 = dtRow.Field<int>("CostMilestone3");
                priceConfig.CostMilestone4 = dtRow.Field<int>("CostMilestone4");
                priceConfig.CostMilestoneNight1 = dtRow.Field<int>("CostMilestoneNight1");
                priceConfig.CostMilestoneNight2 = dtRow.Field<int>("CostMilestoneNight2");
                priceConfig.CostMilestoneNight3 = dtRow.Field<int>("CostMilestoneNight3");
                priceConfig.CostMilestoneNight4 = dtRow.Field<int>("CostMilestoneNight4");
                priceConfig.CycleMilestone3 = dtRow.Field<int>("CycleMilestone3");
                priceConfig.IsAdd = dtRow.Field<string>("IsAdd");
                priceConfig.CycleTicketMonth = dtRow.Field<int>("CycleTicketMonth");
                priceConfig.CostTicketMonth = dtRow.Field<int>("CostTicketMonth");
                priceConfig.MinMinute = dtRow.Field<int>("MinMinute");
                priceConfig.MinCost = dtRow.Field<int>("MinCost");
                priceConfig.Limit = dtRow.Field<int>("Limit");
                priceConfig.ProjectId = Util.getConfigFile().projectId;
                listPriceConfig.Add(priceConfig);

                jsonString = JsonConvert.SerializeObject(listPriceConfig);
                Console.WriteLine(":: " + jsonString);
                string index = (i + 1).ToString();
                listId += "'" + priceConfig.Code + "',";
            }
            if (listId.Length > 1)
            {
                listId = listId.Remove(listId.Length - 1, 1);
                listId += ")";
            }
            else
            {
                listId = "";
            }

            try
            {
                if (!jsonString.Equals(""))
                {
                    string result = webClient.UploadString(new Uri(ApiUtil.API_PRICE_CONFIG_BATCH_INSERT), "POST", jsonString);
                    Console.WriteLine("result_api: " + result);
                    if (result.Equals("") || result.Equals("success"))
                    {
                        ComputerDAO.UpdateIsSync(listId);
                    }
                }
                Console.WriteLine("json_api: " + jsonString);
            }
            catch (Exception e)
            {

            }
        }

        public static void sendConfigToServer()
        {
            //return;
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            List<DisplayConfig> listDisplayConfig = new List<DisplayConfig>();
            WebClient webClient = (new ApiUtil()).getWebClient();
            string jsonString = "";
            DisplayConfig displayConfig = new DisplayConfig();
            displayConfig.ProjectId = Util.getConfigFile().projectId;
            displayConfig.Id = 1;
            displayConfig.LostCard = ConfigDAO.GetLostCard();
            displayConfig.BikeSpace = ConfigDAO.GetBikeSpace();
            displayConfig.CarSpace = ConfigDAO.GetCarSpace();
            displayConfig.TicketLimitDay = ConfigDAO.GetTicketMonthLimit();
            displayConfig.NightLimit = ConfigDAO.GetNightLimit();
            displayConfig.ParkingTypeId = ConfigDAO.GetParkingTypeID();
            displayConfig.ExpiredTicketMonthTypeID = ConfigDAO.GetExpiredTicketMonthTypeID();
            displayConfig.ParkingName = ConfigDAO.GetParkingName();
            displayConfig.CalculationTicketMonth = ConfigDAO.GetCalculationTicketMonth();
            displayConfig.IsAutoLockCard = ConfigDAO.GetIsAutoLockCard();
            displayConfig.LockCardDate = ConfigDAO.GetLockCardDate();

            listDisplayConfig.Add(displayConfig);

            jsonString = JsonConvert.SerializeObject(listDisplayConfig);
            Console.WriteLine(":: " + jsonString);

            try
            {
                if (!jsonString.Equals(""))
                {
                    string result = webClient.UploadString(new Uri(ApiUtil.API_CONFIG_BATCH_INSERT), "POST", jsonString);
                    Console.WriteLine("result_api: " + result);
                }
                Console.WriteLine("json_api: " + jsonString);
            }
            catch (Exception e)
            {

            }
        }

        public static void sendOrderDataToServer()
        {
            //if (Program.sCountConnection > Program.MAX_CONNECTION)
            //{
            //    return;
            //}
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            DataTable dataIn = CarDAO.GetDataInRecentlyForSync();
            DataTable dataOut = CarDAO.GetDataOutRecentlyForSync();
            sendOrderListToServer(dataIn, true);
            sendOrderListToServer(dataOut, false);
        }

        public static void syncCardListFromServer()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            WebClient webClient = (new ApiUtil()).getWebClient();
            var param = new System.Collections.Specialized.NameValueCollection();

            webClient.QueryString.Add(ApiUtil.PARAM_PROJECT_ID, Util.getConfigFile().projectId + "");
            try
            {
                String responseString = webClient.DownloadString(ApiUtil.API_CARDS_BATCH_SYNCS);
                Console.WriteLine(responseString);
                CardDAO.syncFromJson(responseString);
            }
            catch (WebException exception)
            {
                string responseText;
                var responseStream = exception.Response?.GetResponseStream();

                if (responseStream != null)
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
            }
        }

        public static void syncMonthlyCardListFromServer()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            WebClient webClient = (new ApiUtil()).getWebClient();

            webClient.QueryString.Add(ApiUtil.PARAM_PROJECT_ID, Util.getConfigFile().projectId + "");
            try
            {
                String responseString = webClient.DownloadString(ApiUtil.API_MONTHLY_CARDS_BATCH_SYNCS);
                Console.WriteLine(responseString);
                TicketMonthDAO.syncFromJson(responseString);
            }
            catch (WebException exception)
            {
                string responseText;
                var responseStream = exception.Response?.GetResponseStream();

                if (responseStream != null)
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
            }
        }

        public static void syncMonthlyCardListFromSPMServer()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            WebClient webClient = (new ApiUtil()).getWebClient();
            try
            {
                String responseString = webClient.DownloadString(ApiUtil.API_MONTHLY_CARDS_SYNCS_SPM);
                Console.WriteLine(responseString);
                TicketMonthDAO.syncFromSPMJson(responseString);
            }
            catch (WebException exception)
            {
                string responseText;
                var responseStream = exception.Response?.GetResponseStream();

                if (responseStream != null)
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
            }
        }

        public static void syncMonthlyCardListFromPiHomeServer()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            WebClient webClient = (new ApiUtil()).getPiHomeWebClient();
            try
            {
                String responseString = webClient.DownloadString(ApiUtil.API_MONTHLY_CARDS_SYNCS_PI_HOME);
                Console.WriteLine(responseString);
                TicketMonthDAO.syncFromPiHomeJson(responseString);
            }
            catch (WebException exception)
            {
                string responseText;
                var responseStream = exception.Response?.GetResponseStream();

                if (responseStream != null)
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
            }
        }

        public static void syncPartListFromPiHomeServer()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            WebClient webClient = (new ApiUtil()).getPiHomeWebClient();
            try
            {
                String responseString = webClient.DownloadString(ApiUtil.API_PARTS_SYNCS_PI_HOME);
                Console.WriteLine(responseString);
                PartDAO.syncFromPiHomeJson(responseString);
            }
            catch (WebException exception)
            {
                string responseText;
                var responseStream = exception.Response?.GetResponseStream();

                if (responseStream != null)
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
            }
        }

        public static void updateCardToPiHomeServer(TicketMonthDTO ticketMonthDTO)
        {
            WebClient webClient = (new ApiUtil()).getPiHomeWebClient();
            var param = new System.Collections.Specialized.NameValueCollection();
            param.Add(ApiUtil.PARAM_LICENSE_PLATE, ticketMonthDTO.Digit);
            param.Add(ApiUtil.PARAM_CARD_CODE, ticketMonthDTO.Id);
            param.Add(ApiUtil.PARAM_CARD_NUMBER, ticketMonthDTO.CardNumber);
            param.Add(ApiUtil.PARAM_CUSTOMER_NAME, ticketMonthDTO.CustomerName);
            param.Add(ApiUtil.PARAM_FEE, ticketMonthDTO.ChargesAmount);
            param.Add(ApiUtil.PARAM_CUSTOMER_NAME, ticketMonthDTO.CustomerName);
            param.Add(ApiUtil.PARAM_CUSTOMER_NAME, ticketMonthDTO.CustomerName);
            byte[] responsebytes = webClient.UploadValues(ApiUtil.API_MONTHLY_CARDS_UPDATE_PI_HOME, "POST", param);
            string responsebody = Encoding.UTF8.GetString(responsebytes);
            //MessageBox.Show(responsebody);
        }
        public static void WC_DownloadComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString());
            }
            else
            {
                string html = e.Result;
            }
        }

        public static void setSyncDoneMonthlyCardListToSPMServer(string soThe)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            WebClient webClient = (new ApiUtil()).getWebClient();

            webClient.QueryString.Add(ApiUtil.PARAM_CARD_NUMBER_SPM, soThe);
            webClient.QueryString.Add(ApiUtil.PARAM_STATUS, "null");
            try
            {
                String responseString = webClient.DownloadString(ApiUtil.API_MONTHLY_CARDS_SET_SYNC_DONE_SPM);
                Console.WriteLine(responseString);
            }
            catch (WebException exception)
            {
                string responseText;
                var responseStream = exception.Response?.GetResponseStream();

                if (responseStream != null)
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseText = reader.ReadToEnd();
                        MessageBox.Show("api set done fail: " + responseText);
                    }
                }
            }
        }

        public static void setSyncDoneMonthlyCardListToPiHomeServer(string soThe)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            WebClient webClient = (new ApiUtil()).getWebClient();

            webClient.QueryString.Add(ApiUtil.PARAM_CARD_NUMBER, soThe);
            webClient.QueryString.Add(ApiUtil.PARAM_STATUS, "null");
            try
            {
                String responseString = webClient.DownloadString(ApiUtil.API_MONTHLY_CARDS_SET_SYNC_DONE_SPM);
                Console.WriteLine(responseString);
            }
            catch (WebException exception)
            {
                string responseText;
                var responseStream = exception.Response?.GetResponseStream();

                if (responseStream != null)
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseText = reader.ReadToEnd();
                        MessageBox.Show("api set done fail: " + responseText);
                    }
                }
            }
        }

        public static void syncVehicleListFromServer()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            WebClient webClient = (new ApiUtil()).getWebClient();
            var param = new System.Collections.Specialized.NameValueCollection();

            webClient.QueryString.Add(ApiUtil.PARAM_PROJECT_ID, Util.getConfigFile().projectId + "");
            try
            {
                String responseString = webClient.DownloadString(ApiUtil.API_VEHICLE_BATCH_SYNCS);
                Console.WriteLine(responseString);
                PartDAO.syncFromJson(responseString);
            }
            catch (WebException exception)
            {
                string responseText;
                var responseStream = exception.Response?.GetResponseStream();

                if (responseStream != null)
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
            }
        }

        public static void syncEmployeeListFromServer()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            WebClient webClient = (new ApiUtil()).getWebClient();
            var param = new System.Collections.Specialized.NameValueCollection();

            webClient.QueryString.Add(ApiUtil.PARAM_PROJECT_ID, Util.getConfigFile().projectId + "");
            try
            {
                String responseString = webClient.DownloadString(ApiUtil.API_EMPLOYEE_BATCH_SYNCS);
                Console.WriteLine(responseString);
                UserDAO.syncFromJson(responseString);
            }
            catch (WebException exception)
            {
                string responseText;
                var responseStream = exception.Response?.GetResponseStream();

                if (responseStream != null)
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
            }
        }

        public static void syncFunctionListFromServer()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            WebClient webClient = (new ApiUtil()).getWebClient();
            var param = new System.Collections.Specialized.NameValueCollection();

            webClient.QueryString.Add(ApiUtil.PARAM_PROJECT_ID, Util.getConfigFile().projectId + "");
            try
            {
                String responseString = webClient.DownloadString(ApiUtil.API_FUNCTIONS_BATCH_SYNCS);
                Console.WriteLine(responseString);
                FunctionalDAO.syncFromJson(responseString);
            }
            catch (WebException exception)
            {
                string responseText;
                var responseStream = exception.Response?.GetResponseStream();

                if (responseStream != null)
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
            }
        }

        public static void syncBlackCarListFromServer()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            WebClient webClient = (new ApiUtil()).getWebClient();

            try
            {
                String responseString = webClient.DownloadString(ApiUtil.API_BLACK_CAR_BATCH_SYNCS);
                Console.WriteLine(responseString);
                BlackCarDAO.syncFromJson(responseString);
            }
            catch (WebException exception)
            {
                string responseText;
                var responseStream = exception.Response?.GetResponseStream();

                if (responseStream != null)
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
            }
        }

        public static void syncDisplayConfigFromServer()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            WebClient webClient = (new ApiUtil()).getWebClient();

            try
            {
                String responseString = webClient.DownloadString(ApiUtil.API_CONFIG_BATCH_SYNCS);
                Console.WriteLine(responseString);
                ConfigDAO.syncFromJson(responseString);
            }
            catch (WebException exception)
            {
                string responseText;
                var responseStream = exception.Response?.GetResponseStream();

                if (responseStream != null)
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
            }
        }

        public static void syncPriceConfigFromServer()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            WebClient webClient = (new ApiUtil()).getWebClient();

            try
            {
                String responseString = webClient.DownloadString(ApiUtil.API_PRICE_CONFIG_BATCH_SYNCS);
                Console.WriteLine(responseString);
                ComputerDAO.syncFromJson(responseString);
            }
            catch (WebException exception)
            {
                string responseText;
                var responseStream = exception.Response?.GetResponseStream();

                if (responseStream != null)
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
            }
        }

        private static void saveLastOrderToConfig(int lastIdentify)
        {
            try
            {
                String filePath = Application.StartupPath + "\\" + Constant.sFileNameConfig;
                if (File.Exists(filePath))
                {
                    Config config = Util.getConfigFile();
                    config.lastSavedOrder = lastIdentify + "";

                    XmlSerializer xs = new XmlSerializer(typeof(Config));
                    TextWriter txtWriter = new StreamWriter(filePath);
                    xs.Serialize(txtWriter, config);
                    txtWriter.Close();
                }
            }
            catch (Exception e)
            {

            }
        }

        public static string NewestFileofDirectory(string directoryPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            if (directoryInfo == null || !directoryInfo.Exists)
                return null;

            FileInfo[] files = directoryInfo.GetFiles();
            DateTime recentWrite = DateTime.MinValue;
            FileInfo recentFile = null;

            foreach (FileInfo file in files)
            {
                if (file.LastWriteTime > recentWrite)
                {
                    recentWrite = file.LastWriteTime;
                    recentFile = file;
                }
            }
            if (recentFile != null)
            {
                return recentFile.Name;
            }
            return "";
        }

        public static string getFolderPath(string folderName)
        {
            return Application.StartupPath + "\\" + folderName + "\\";
        }

        public static void ShareFolder(string FolderPath, string ShareName, string Description)
        {
            try
            {
                // Create a ManagementClass object

                ManagementClass managementClass = new ManagementClass("Win32_Share");

                // Create ManagementBaseObjects for in and out parameters

                ManagementBaseObject inParams = managementClass.GetMethodParameters("Create");

                ManagementBaseObject outParams;

                // Set the input parameters

                inParams["Description"] = Description;

                inParams["Name"] = ShareName;

                inParams["Path"] = FolderPath;

                inParams["Type"] = 0x0; // Disk Drive

                //Another Type:

                // DISK_DRIVE = 0x0

                // PRINT_QUEUE = 0x1

                // DEVICE = 0x2

                // IPC = 0x3

                // DISK_DRIVE_ADMIN = 0x80000000

                // PRINT_QUEUE_ADMIN = 0x80000001

                // DEVICE_ADMIN = 0x80000002

                // IPC_ADMIN = 0x8000003

                //inParams["MaximumAllowed"] = int maxConnectionsNum;

                // Invoke the method on the ManagementClass object

                outParams = managementClass.InvokeMethod("Create", inParams, null);

                // Check to see if the method invocation was successful

                if ((uint)(outParams.Properties["ReturnValue"].Value) != 0)

                {

                    throw new Exception("Unable to share directory.");

                }

            }
            catch (Exception ex)
            {

            }
        }

        public static Image Resize(Image img, float percent)
        {
            int originalW = img.Width;
            int originalH = img.Height;
            int resizeW = (int) (originalW * percent);
            int resizeH = (int) (originalH * percent);
            Bitmap bmp = new Bitmap(resizeW, resizeH);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.DrawImage(img, 0, 0, resizeW, resizeH);
            graphics.Dispose();
            return bmp;
        }

        public static Image Crop(Image img, float percent)
        {
            int originalW = img.Width;
            int originalH = img.Height;
            int resizeW = (int)(originalW * percent);
            int resizeH = (int)(originalH * percent);
            Bitmap bmp = new Bitmap(resizeW, resizeH);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.DrawImage(img, 0, 0, resizeW, resizeH);
            graphics.Dispose();
            return bmp;
        }

        public static System.Drawing.Image FixedSize(Image image, int Width, int Height, bool needToFill)
        {
            #region calculations
            int sourceWidth = image.Width;
            int sourceHeight = image.Height;
            int sourceX = 0;
            int sourceY = 0;
            double destX = 0;
            double destY = 0;

            double nScale = 0;
            double nScaleW = 0;
            double nScaleH = 0;

            nScaleW = ((double)Width / (double)sourceWidth);
            nScaleH = ((double)Height / (double)sourceHeight);
            if (!needToFill)
            {
                nScale = Math.Min(nScaleH, nScaleW);
            }
            else
            {
                nScale = Math.Max(nScaleH, nScaleW);
                destY = (Height - sourceHeight * nScale) / 2;
                destX = (Width - sourceWidth * nScale) / 2;
            }

            if (nScale > 1)
                nScale = 1;

            int destWidth = (int)Math.Round(sourceWidth * nScale);
            int destHeight = (int)Math.Round(sourceHeight * nScale);
            #endregion

            System.Drawing.Bitmap bmPhoto = null;
            try
            {
                bmPhoto = new System.Drawing.Bitmap(destWidth + (int)Math.Round(2 * destX), destHeight + (int)Math.Round(2 * destY));
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("destWidth:{0}, destX:{1}, destHeight:{2}, desxtY:{3}, Width:{4}, Height:{5}",
                    destWidth, destX, destHeight, destY, Width, Height), ex);
            }
            using (System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto))
            {
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.CompositingQuality = CompositingQuality.HighQuality;
                grPhoto.SmoothingMode = SmoothingMode.HighQuality;

                Rectangle to = new System.Drawing.Rectangle((int)Math.Round(destX), (int)Math.Round(destY), destWidth, destHeight);
                Rectangle from = new System.Drawing.Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
                //Console.WriteLine("From: " + from.ToString());
                //Console.WriteLine("To: " + to.ToString());
                grPhoto.DrawImage(image, to, from, System.Drawing.GraphicsUnit.Pixel);

                return bmPhoto;
            }
        }

        /// <summary> 
        /// Saves an image as a jpeg image, with the given quality 
        /// </summary> 
        /// <param name="path"> Path to which the image would be saved. </param> 
        /// <param name="quality"> An integer from 0 to 100, with 100 being the highest quality. </param> 
        public static void SaveJpeg(string path, Image img, int quality)
        {
            if (quality < 0 || quality > 100)
                throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");

            // Encoder parameter for image quality 
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            // JPEG image codec 
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            img.Save(path, jpegCodec, encoderParams);

            //img.Save(path);
        }

        /// <summary> 
        /// Returns the image codec with the given mime type 
        /// </summary> 
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats 
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec 
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];

            return null;
        }

        public static Bitmap ResizeBitmap(Bitmap originalBitmap, float zoomFactor)
        {
            Size newSize = new Size((int)(originalBitmap.Width * zoomFactor), (int)(originalBitmap.Height * zoomFactor));
            Bitmap bmp = new Bitmap(originalBitmap, newSize);
            return bmp;
        }

        public static Bitmap cropImage(string filePath, float zoomFactor)
        {
            Image img = Image.FromFile(filePath);
            Bitmap bmpImage = new Bitmap(img);
            int width = (int) (bmpImage.Width * zoomFactor);
            int height = (int)(bmpImage.Height * zoomFactor);
            Bitmap bmpCrop = bmpImage.Clone(new Rectangle(0, 0, width, height), bmpImage.PixelFormat);
            //bmpCrop.Save("c:\\hellocrop.jpg");
            return bmpCrop;
        }

        public static Bitmap ResizeImage(Image imgToResize, float ratio)
        {
            try
            {
                var originalWidth = imgToResize.Width;
                var originalHeight = imgToResize.Height;

                //how many units are there to make the original length
                int destinationHeight = (int)(originalHeight * ratio);
                int destinationWidth = (int)(originalWidth * ratio);


                var hScale = Convert.ToInt32(destinationHeight * ratio);
                var wScale = Convert.ToInt32(destinationWidth * ratio);

                //start cropping from the center
                var startX = (originalWidth - wScale) / 2;
                var startY = (originalHeight - hScale) / 2;

                //crop the image from the specified location and size
                var sourceRectangle = new Rectangle(startX, startY, wScale, hScale);

                //the future size of the image
                var bitmap = new Bitmap(destinationWidth, destinationHeight);

                //fill-in the whole bitmap
                var destinationRectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

                //generate the new image
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(imgToResize, destinationRectangle, sourceRectangle, GraphicsUnit.Pixel);
                }

                return bitmap;
            } catch (Exception e)
            {
                return null;
            }
            
        }

        public static void autoLockExpiredCard()
        {
            int currentDay = (int)System.DateTime.Now.Day;
            int lockCardDate = ConfigDAO.GetLockCardDate();
            if (Util.getConfigFile().isUseCostDeposit.Equals("no"))
            {
                CardDAO.lockExpiredCardNoDeposit(lockCardDate);
            }
            else
            {
                if (currentDay >= lockCardDate)
                {
                    CardDAO.lockExpiredCardWithDeposit();
                }                
            }
        }

        public static int MonthDifference(this DateTime lValue, DateTime rValue)
        {
            return (lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year);
        }

        public static int getCostExtendCard(DateTime expirationDate, DateTime newExpirationDate, string monthlyCostString)
        {
            int monthlyCost = 0;
            int payCost = 0;

            try
            {
                monthlyCost = Convert.ToInt32(monthlyCostString);
            }
            catch (Exception)
            {

            }

            int dayCount = (newExpirationDate.Date - expirationDate.Date).Days;
            if (dayCount == 0)
            {
                return 0;
            }

            int monthCount = Util.MonthDifference(newExpirationDate, expirationDate);
            if (expirationDate.Day == 1 && newExpirationDate.Day == 1)
            {
                payCost += monthlyCost * monthCount;
            }
            else
            {
                int pastRemainDays = Util.getDaysInMonth(expirationDate) - expirationDate.Day;

                payCost += monthlyCost * pastRemainDays / 30;
                if (Util.getDaysInMonth(newExpirationDate) == newExpirationDate.Day)
                {
                    payCost += monthlyCost * monthCount;
                }
                else
                {
                    int futureRemainDays = newExpirationDate.Day;
                    payCost += monthlyCost * (monthCount - 1) + monthlyCost * futureRemainDays / 30;
                }
            }
            return payCost;
        }

        public static DateTime getLastDateOfCurrentMonth()
        {
            DateTime now = DateTime.Now;
            DateTime startDate = new DateTime(now.Year, now.Month, 1);
            //DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            DateTime endDate = startDate.AddMonths(1);
            return endDate;
        }

        public static DateTime getLastDateOfCurrentMonth(DateTime date)
        {
            DateTime startDate = new DateTime(date.Year, date.Month, 1);
            //DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            DateTime endDate = startDate.AddMonths(1);
            return endDate;
        }

        public static DateTime getFirstDateOfCurrentMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static int getDaysInMonth(DateTime date)
        {
            return DateTime.DaysInMonth(date.Year, date.Month);
        }

        public static int roundUpVND(int cost)
        {
            int result = ((int) (cost / 1000)) * 1000;
            if (cost % 1000 >= 500)
            {
                result += 1000;
            }
            return result;
        }

        public static string ReadUhfData(SerialPort serial)
        {
            return serial.ReadExisting().Trim().ToUpper();
        }

        public static void playAudio(string audioName)
        {
            string url = Application.StartupPath + "\\audio\\" + audioName;
            if (File.Exists(url))
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(url);
                player.Play();
            }
        }

        private static string Chu(string gNumber)
        {
            string result = "";
            switch (gNumber)
            {
                case "0":
                    result = "không";
                    break;
                case "1":
                    result = "một";
                    break;
                case "2":
                    result = "hai";
                    break;
                case "3":
                    result = "ba";
                    break;
                case "4":
                    result = "bốn";
                    break;
                case "5":
                    result = "năm";
                    break;
                case "6":
                    result = "sáu";
                    break;
                case "7":
                    result = "bảy";
                    break;
                case "8":
                    result = "tám";
                    break;
                case "9":
                    result = "chín";
                    break;
            }
            return result;
        }

        private static string Donvi(string so)
        {
            string Kdonvi = "";

            if (so.Equals("1"))
                Kdonvi = "";
            if (so.Equals("2"))
                Kdonvi = "nghìn";
            if (so.Equals("3"))
                Kdonvi = "triệu";
            if (so.Equals("4"))
                Kdonvi = "tỷ";
            if (so.Equals("5"))
                Kdonvi = "nghìn tỷ";
            if (so.Equals("6"))
                Kdonvi = "triệu tỷ";
            if (so.Equals("7"))
                Kdonvi = "tỷ tỷ";

            return Kdonvi;
        }

        private static string Tach(string tach3)
        {
            string Ktach = "";
            if (tach3.Equals("000"))
                return "";
            if (tach3.Length == 3)
            {
                string tr = tach3.Trim().Substring(0, 1).ToString().Trim();
                string ch = tach3.Trim().Substring(1, 1).ToString().Trim();
                string dv = tach3.Trim().Substring(2, 1).ToString().Trim();
                if (tr.Equals("0") && ch.Equals("0"))
                    Ktach = " không trăm lẻ " + Chu(dv.ToString().Trim()) + " ";
                if (!tr.Equals("0") && ch.Equals("0") && dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm ";
                if (!tr.Equals("0") && ch.Equals("0") && !dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm lẻ " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (tr.Equals("0") && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm mười " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("0"))
                    Ktach = " không trăm mười ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("5"))
                    Ktach = " không trăm mười lăm ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười " + Chu(dv.Trim()).Trim() + " ";

                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười lăm ";
            }

            return Ktach;
        }

        public static string So_sang_chu(double gNum)
        {
            if (gNum == 0)
                return "Không đồng";

            string lso_chu = "";
            string tach_mod = "";
            string tach_conlai = "";
            double Num = Math.Round(gNum, 0);
            string gN = Convert.ToString(Num);
            int m = Convert.ToInt32(gN.Length / 3);
            int mod = gN.Length - m * 3;
            string dau = "[+]";

            // Dau [+ , - ]
            if (gNum < 0)
                dau = "[-]";
            dau = "";

            // Tach hang lon nhat
            if (mod.Equals(1))
                tach_mod = "00" + Convert.ToString(Num.ToString().Trim().Substring(0, 1)).Trim();
            if (mod.Equals(2))
                tach_mod = "0" + Convert.ToString(Num.ToString().Trim().Substring(0, 2)).Trim();
            if (mod.Equals(0))
                tach_mod = "000";
            // Tach hang con lai sau mod :
            if (Num.ToString().Length > 2)
                tach_conlai = Convert.ToString(Num.ToString().Trim().Substring(mod, Num.ToString().Length - mod)).Trim();

            ///don vi hang mod
            int im = m + 1;
            if (mod > 0)
                lso_chu = Tach(tach_mod).ToString().Trim() + " " + Donvi(im.ToString().Trim());
            /// Tach 3 trong tach_conlai

            int i = m;
            int _m = m;
            int j = 1;
            string tach3 = "";
            string tach3_ = "";

            while (i > 0)
            {
                tach3 = tach_conlai.Trim().Substring(0, 3).Trim();
                tach3_ = tach3;
                lso_chu = lso_chu.Trim() + " " + Tach(tach3.Trim()).Trim();
                m = _m + 1 - j;
                if (!tach3_.Equals("000"))
                    lso_chu = lso_chu.Trim() + " " + Donvi(m.ToString().Trim()).Trim();
                tach_conlai = tach_conlai.Trim().Substring(3, tach_conlai.Trim().Length - 3);

                i = i - 1;
                j = j + 1;
            }
            if (lso_chu.Trim().Substring(0, 1).Equals("k"))
                lso_chu = lso_chu.Trim().Substring(10, lso_chu.Trim().Length - 10).Trim();
            if (lso_chu.Trim().Substring(0, 1).Equals("l"))
                lso_chu = lso_chu.Trim().Substring(2, lso_chu.Trim().Length - 2).Trim();
            if (lso_chu.Trim().Length > 0)
                lso_chu = dau.Trim() + " " + lso_chu.Trim().Substring(0, 1).Trim().ToUpper() + lso_chu.Trim().Substring(1, lso_chu.Trim().Length - 1).Trim() + " đồng chẵn.";

            return lso_chu.ToString().Trim();
        }


        public static ArrayList ChuyenSo(string number)
        {
            string[] dv = { "", Constant.ten, Constant.hundred, Constant.thousand, Constant.million, Constant.million /* tỉ */};
            string[] cs = {Constant.number0, Constant.number1, Constant.number2, Constant.number3, Constant.number4,
                Constant.number5, Constant.number6, Constant.number7, Constant.number8, Constant.number9 };
            ArrayList doc = new ArrayList();
            int i, j, k, n, len, found, ddv, rd;

            len = number.Length;
            number += "ss";
            found = 0;
            ddv = 0;
            rd = 0;

            i = 0;
            while (i < len)
            {
                //So chu so o hang dang duyet
                n = (len - i + 2) % 3 + 1;

                //Kiem tra so 0
                found = 0;
                for (j = 0; j < n; j++)
                {
                    if (number[i + j] != '0')
                    {
                        found = 1;
                        break;
                    }
                }

                //Duyet n chu so
                if (found == 1)
                {
                    rd = 1;
                    for (j = 0; j < n; j++)
                    {
                        ddv = 1;
                        switch (number[i + j])
                        {
                            case '0':
                                if (n - j == 3) doc.Add(cs[0]);
                                if (n - j == 2)
                                {
                                    if (number[i + j + 1] != '0') doc.Add(Constant.unitonly);
                                    ddv = 0;
                                }
                                break;
                            case '1':
                                if (n - j == 3) doc.Add(cs[1]);
                                if (n - j == 2)
                                {
                                    doc.Add(Constant.xteen);
                                    ddv = 0;
                                }
                                if (n - j == 1)
                                {
                                    if (i + j == 0) k = 0;
                                    else k = i + j - 1;

                                    if (number[k] != '1' && number[k] != '0')
                                        doc.Add(Constant.number1); // mốt
                                    else
                                        doc.Add(cs[1]);
                                }
                                break;
                            case '5':
                                if (i + j == len - 1)
                                    doc.Add(Constant.fivealt);
                                else
                                    doc.Add(cs[5]);
                                break;
                            default:
                                doc.Add(cs[(int)number[i + j] - 48]);
                                break;
                        }

                        //Doc don vi nho
                        if (ddv == 1)
                        {
                            doc.Add(dv[n - j - 1]);
                        }
                    }
                }


                //Doc don vi lon
                if (len - i - n > 0)
                {
                    if ((len - i - n) % 9 == 0)
                    {
                        if (rd == 1)
                            for (k = 0; k < (len - i - n) / 9; k++)
                                doc.Add(Constant.million); // "tỉ"
                        rd = 0;
                    }
                    else
                        if (found != 0) doc.Add(dv[((len - i - n + 1) % 9) / 3 + 2]);
                }

                i += n;
            }

            if (len == 1)
                if (number[0] == '0' || number[0] == '5') 
                {
                    doc = new ArrayList();
                    doc.Add(cs[(int)number[0] - 48]);
                }
            foreach (String item in doc)
            {
                if (item == "")
                {

                }
            }
            while (doc.Contains(""))
            {
                doc.Remove("");
            }

            doc.Add(Constant.currency);

            return doc;
        }
    }
}

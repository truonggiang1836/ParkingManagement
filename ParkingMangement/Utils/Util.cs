﻿using Newtonsoft.Json;
using ParkingMangement.DAO;
using ParkingMangement.DTO;
using ParkingMangement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Management;
using System.Security.Principal;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ParkingMangement.Utils
{
    static class Util
    {
        private static Config sConfig = null;
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
            if (timeEnd.Year == timeStart.Year)
            {
                return timeEnd.DayOfYear - timeStart.DayOfYear;
            } else
            {
                TimeSpan duration = timeEnd - timeStart;
                return (int)duration.TotalDays;
            }
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
            return string.Format("{0:#,000}", number);
        }

        public static int getMillisecondBetweenTwoDate(DateTime oldDate, DateTime newDate)
        {
            TimeSpan span = newDate - oldDate;
            int ms = (int)span.TotalMilliseconds;
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
                        sConfig.comSend = sConfig.comSend.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.comLedLeft = sConfig.comLedLeft.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        sConfig.comLedRight = sConfig.comLedRight.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
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

        public static void sendOrderListToServer(DataTable data, bool isCarIn)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            DataTable dtTable = data;
            List<Order> listOrder = new List<Order>();
            WebClient webClient = (new ApiUtil()).getWebClient();
            //webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            var param = new System.Collections.Specialized.NameValueCollection();
            string jsonString = "";
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                DataRow dtRow = dtTable.Rows[i];
                Order order = new Order();
                order.AreaId = 1;
                order.ProjectId = 1;
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
                } catch (Exception)
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
                listOrder.Add(order);

                jsonString = JsonConvert.SerializeObject(listOrder);
                Console.WriteLine(":: " + jsonString);
                //string index = (i + 1).ToString();
                //param.Add(ApiUtil.PARAM_DATA + index, jsonString);

                //if (listOrder.Count == 10)
                //{
                //    break;
                //}
            }
            
            try
            {
                //byte[] responsebytes = webClient.UploadValues(ApiUtil.API_ORDERS_BATCH_INSERT, "POST", param);
                if (!jsonString.Equals(""))
                {
                    webClient.UploadString(new Uri(ApiUtil.API_ORDERS_BATCH_INSERT), "POST", jsonString);
                }
                Console.WriteLine("json_api: " + jsonString);
                int x = 0;
                //String responseString = Encoding.UTF8.GetString(responsebytes);

                //webClient.UploadData(ApiUtil.API_ORDERS_BATCH_INSERT, "POST", Encoding.Default.GetBytes(jsonString));
            }
            catch (Exception e)
            {
                int x = 0;
                //MessageBox.Show(e.Message);
            }
        }

        public static void sendCardListToServer(DataTable data)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return;
            }
            DataTable dtTable = data;
            List<Card> listCard = new List<Card>();
            WebClient webClient = (new ApiUtil()).getWebClient();
            //webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            var param = new System.Collections.Specialized.NameValueCollection();
            string jsonString = "";
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                DataRow dtRow = dtTable.Rows[i];
                Card card = new Card();
                card.AreaId = 1;
                card.ProjectId = 1;
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
                } else
                {
                    card.Disable = 1;
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

                jsonString = JsonConvert.SerializeObject(listCard);
                Console.WriteLine(":: " + jsonString);
                string index = (i + 1).ToString();
                param.Add(ApiUtil.PARAM_DATA + index, jsonString);

                //if (listCard.Count == 1)
                //{
                //    break;
                //}
            }

            try
            {
                //byte[] responsebytes = webClient.UploadValues(ApiUtil.API_ORDERS_BATCH_INSERT, "POST", param);
                if (!jsonString.Equals(""))
                {
                    string result = webClient.UploadString(new Uri(ApiUtil.API_CARDS_BATCH_INSERT), "POST", jsonString);
                    Console.WriteLine("result_api: " + result);
                }
                Console.WriteLine("json_api: " + jsonString);
                int x = 0;
                //String responseString = Encoding.UTF8.GetString(responsebytes);

                //webClient.UploadData(ApiUtil.API_ORDERS_BATCH_INSERT, "POST", Encoding.Default.GetBytes(jsonString));
            }
            catch (Exception e)
            {
                int x = 0;
                //MessageBox.Show(e.Message);
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
                //MessageBox.Show(ex.Message, "error!");
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

    }
}

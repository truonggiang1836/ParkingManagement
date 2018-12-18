using Newtonsoft.Json;
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

namespace ParkingMangement.Utils
{
    static class Util
    {
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
            return Convert.ToInt64(date.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds);
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
            TimeSpan duration = timeEnd - timeStart;
            return (int) duration.TotalDays;
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
            return year + month + day + hour + minute + second;
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

        public static string formatNumberAsMoney(int number)
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
                        Config config = (Config)serializer.Deserialize(reader);
                        config.cameraUrl1 = config.cameraUrl1.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        config.cameraUrl2 = config.cameraUrl2.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        config.cameraUrl3 = config.cameraUrl3.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        config.cameraUrl4 = config.cameraUrl4.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        config.rfidIn = config.rfidIn.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        config.rfidOut = config.rfidOut.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        config.ipHost = config.ipHost.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        config.folderRoot = config.folderRoot.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
                        return config;
                    }
                }
            }
            catch (Exception e)
            {

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

        public static void sendOrderListToServer(DataTable data)
        {
            string json = JsonConvert.SerializeObject(data);
            DataTable dtTable = data;
            List<Order> listOrder = new List<Order>();
            foreach (DataRow dtRow in dtTable.Rows)
            {
                Order order = new Order();
                order.AreaId = 1;
                //order.OrderId = dtRow.Field<int>("Identify");
                order.CardCode = dtRow.Field<string>("ID");
                DateTime checkinDatetime = dtRow.Field<DateTime>("TimeStart");
                order.CheckinTime = checkinDatetime.ToString(Constant.sDateTimeFormatForAPI);
                if (dtRow.Field<DateTime?>("TimeEnd") != null)
                {
                    DateTime checkoutDatetime = dtRow.Field<DateTime>("TimeEnd");
                    order.CheckoutTime = checkoutDatetime.ToString(Constant.sDateTimeFormatForAPI);
                }
                order.CarNumber = dtRow.Field<string>("Digit");
                order.CarNumberIn = dtRow.Field<string>("Digit");
                order.CarNumberOut = dtRow.Field<string>("Digit");
                order.AdminCheckinId = dtRow.Field<string>("IDIn");
                order.AdminCheckinName = UserDAO.GetUserNameByID(order.AdminCheckinId);
                order.AdminCheckoutId = dtRow.Field<string>("IDOut");
                order.AdminCheckoutName = UserDAO.GetUserNameByID(order.AdminCheckoutId);
                order.MonthlyCardId = dtRow.Field<string>("IDTicketMonth");
                order.VehicleId = Int32.Parse(dtRow.Field<string>("PartID"));
                order.VehicleName = PartDAO.GetPartNameByPartID(order.VehicleId +"");
                order.VehicleCode = PartDAO.GetSignByPartID(order.VehicleId + "");
                order.IsCardLost = dtRow.Field<int>("IsLostCard");
                order.TotalPrice = dtRow.Field<int>("Cost");
                order.PcName = dtRow.Field<string>("Computer");
                order.Account = dtRow.Field<string>("Account");
                DateTime dateUpdate = dtRow.Field<DateTime>("DateUpdate");
                order.Created = dateUpdate.ToString(Constant.sDateTimeFormatForAPI);
                order.Updated = dateUpdate.ToString(Constant.sDateTimeFormatForAPI);
                listOrder.Add(order);
                if (listOrder.Count == 1)
                {
                    break;
                }
            }
            string jsonString = JsonConvert.SerializeObject(listOrder);
            WebClient webClient = (new ApiUtil()).getWebClient();
            webClient.QueryString.Add(ApiUtil.PARAM_DATA, jsonString);
            try
            {
                String responseString = webClient.DownloadString(ApiUtil.API_ORDERS_BATCH_INSERT);
                int x = 0;
            }
            catch (Exception e)
            {

            }
        }

        public static void ShareFolder(string FolderPath, string ShareName, string Description)
        {
            try
            {
                NTAccount ntAccount = new NTAccount("Everyone");
                SecurityIdentifier oGrpSID = (SecurityIdentifier)ntAccount.Translate(typeof(SecurityIdentifier));
                byte[] utenteSIDArray = new byte[oGrpSID.BinaryLength];
                oGrpSID.GetBinaryForm(utenteSIDArray, 0);
                ManagementObject oGrpTrustee = new ManagementClass(new ManagementPath("Win32_Trustee"), null);
                oGrpTrustee["Name"] = "Everyone";
                oGrpTrustee["SID"] = utenteSIDArray;
                ManagementObject oGrpACE = new ManagementClass(new ManagementPath("Win32_Ace"), null);
                oGrpACE["AccessMask"] = 2032127;//Full access
                oGrpACE["AceFlags"] = AceFlags.ObjectInherit | AceFlags.ContainerInherit; //propagate the AccessMask to the subfolders
                oGrpACE["AceType"] = AceType.AccessAllowed;
                oGrpACE["Trustee"] = oGrpTrustee;             
                ManagementObject oGrpSecurityDescriptor = new ManagementClass(new ManagementPath("Win32_SecurityDescriptor"), null);
                oGrpSecurityDescriptor["ControlFlags"] = 4; //SE_DACL_PRESENT
                oGrpSecurityDescriptor["DACL"] = new object[] { oGrpACE };


                CreateFolderIfMissing(FolderPath);
                // Create a ManagementClass object
                ManagementClass managementClass = new ManagementClass("win32_share");

                // Create ManagementBaseObjects for in and out parameters
                ManagementBaseObject inParams = managementClass.GetMethodParameters("Create");
                ManagementBaseObject outParams;

                // Set the input parameters
                inParams["Description"] = Description;
                inParams["Name"] = ShareName;
                inParams["Path"] = FolderPath;
                inParams["Type"] = 0x0; // Disk Drive
                inParams["MaximumAllowed"] = null;
                inParams["Password"] = null;
                inParams["Access"] = oGrpSecurityDescriptor;

                // Invoke the method on the ManagementClass object
                outParams = managementClass.InvokeMethod("Create", inParams, null);
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
    }
}

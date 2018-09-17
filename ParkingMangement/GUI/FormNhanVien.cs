using ParkingMangement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using ParkingMangement.DAO;
using System.Drawing.Imaging;
using ParkingMangement.DTO;
using ParkingMangement.Model;
using System.Xml.Serialization;
using RawInput_dll;
using System.Diagnostics;
using System.Security;

namespace ParkingMangement.GUI
{
    public partial class FormNhanVien : Form
    {
        private readonly RawInput _rawinput;

        const bool CaptureOnlyInForeground = true;
        private string cardID = "0";
        private string keyboardDeviceName = "";

        //const string cameraUrl = @"rtsp://admin:bmv333999@192.168.1.190:554/cam/realmonitor?channel=1&subtype=0&unicast=true&proto=Onvif";
        const string cameraUrl = @"rtsp://184.72.239.149/vod/mp4:BigBuckBunny_175k.mov";
        private string cameraUrl1 = cameraUrl;
        private string cameraUrl2 = cameraUrl;
        private string cameraUrl3 = cameraUrl;
        private string cameraUrl4 = cameraUrl;

        private string rfidIn = "";
        private string rfidOut = "";

        private string imagePath1;
        private string imagePath2;
        private string imagePath3;
        private string imagePath4;

        public FormNhanVien()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            _rawinput = new RawInput(Handle, CaptureOnlyInForeground);

            //_rawinput.AddMessageFilter();   // Adding a message filter will cause keypresses to be handled
            Win32.DeviceAudit();            // Writes a file DeviceAudit.txt to the current directory

            _rawinput.KeyPressed += OnKeyPressed;
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
            this.ActiveControl = tbRFIDCardID;
            readConfigFile();
            //Random rnd = new Random();
            //cardID = rnd.Next(119, 122) + "";

            Util.CreateFolderIfMissing(Constant.IMAGE_FOLDER);
            loadInfo();
            configVLC();
            loadCamera1VLC();
            loadCamera2VLC();
            loadCamera3VLC();
            loadCamera4VLC();
            //loadCameraVLC();
        }

        private void loadInfo()
        {
            timerCurrentTime.Start();
            labelUserName.Text = UserDAO.GetUserNameByID(Program.CurrentUserID);
        }

        private void FormNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Util.showConfirmLogoutPopup(this);
            } else if (e.KeyCode == Keys.Enter)
            {
                cardID = tbRFIDCardID.Text;
                labelCardID.Text = cardID;
                string x = keyboardDeviceName;
                tbRFIDCardID.Text = "";
                saveImage();
            }
        }

        private void saveImageToFile(Image image, string fileName)
        {
            string path = Constant.IMAGE_FOLDER + fileName;
            image.Save(path, ImageFormat.Jpeg);
        }

        private void saveBitmapToFile(Bitmap bitmap, string fileName)
        {
            string path = Constant.IMAGE_FOLDER + fileName;
            bitmap.Save(path, ImageFormat.Jpeg);
        }

        private void saveImage()
        {
            DataTable dt = CardDAO.GetCardByID(cardID);
            if (dt != null && dt.Rows.Count > 0)
            {
                saveImage1ToFile();
                saveImage2ToFile();
                checkForSaveToDB();
            } else
            {
                MessageBox.Show("Thẻ chưa được thêm vào hệ thống");
            }
        }

        private void timerCurrentTime_Tick(object sender, EventArgs e)
        {
            labelCurrentTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void checkForSaveToDB()
        {
            //if (CarDAO.isCarIn(cardID))
            if (isCarIn())
            {
                pictureBoxImage3.Image = null;
                pictureBoxImage4.Image = null;
                if (KiemTraXeChuaRa())
                {
                    MessageBox.Show("Thẻ này chưa được quẹt đầu ra");
                }
                else
                {
                    insertCarIn();
                }
            } else
            {
                pictureBoxImage1.Image = null;
                pictureBoxImage2.Image = null;
                if (KiemTraXeChuaRa())
                {
                    updateCarOut();
                    loadCarInData();
                } else
                {
                    MessageBox.Show("Thẻ này chưa được quẹt đầu vào");
                }
            }
        }

        private void insertCarIn()
        {
            CarDTO carDTO = new CarDTO();
            carDTO.Id = cardID;
            carDTO.TimeStart = DateTime.Now;
            carDTO.IdIn = Program.CurrentUserID;
            string partID = CardDAO.getPartIDByCardID(cardID);
            carDTO.IdPart = partID;
            carDTO.Images = imagePath1;
            carDTO.Images2 = imagePath2;
            carDTO.Computer = Environment.MachineName;
            carDTO.Account = Program.CurrentUserID;
            carDTO.DateUpdate = DateTime.Now;
            CarDAO.Insert(carDTO);
            labelCost.Text = "-";
        }

        private void updateCarOut()
        {
            int identify = CarDAO.GetIdentifyByID(cardID);
            CarDTO carDTO = new CarDTO();
            carDTO.Identify = identify;
            carDTO.Id = cardID;
            carDTO.TimeEnd = DateTime.Now;
            carDTO.IdOut = Program.CurrentUserID;
            carDTO.Cost = tinhTienGiuXe();

            saveImage3ToFile();
            saveImage4ToFile();

            carDTO.Images3 = imagePath3;
            carDTO.Images4 = imagePath4;

            carDTO.Computer = Environment.MachineName;
            carDTO.Account = Program.CurrentUserID;
            carDTO.DateUpdate = DateTime.Now;
            CarDAO.UpdateCarOut(carDTO);
            labelCost.Text = carDTO.Cost + "";
        }

        private void loadCarInData()
        {
            DataTable dt = CarDAO.GetLastCarByID(cardID);
            if (dt != null)
            {
                string image = dt.Rows[0].Field<string>("Images");
                string imagePath1 = Constant.IMAGE_FOLDER + image;
                if (File.Exists(imagePath1))
                {
                    pictureBoxImage3.Image = Image.FromFile(Constant.IMAGE_FOLDER + image);
                }
                string image2 = dt.Rows[0].Field<string>("Images2");
                string imagePath2 = Constant.IMAGE_FOLDER + image2;
                if (File.Exists(imagePath2))
                {
                    pictureBoxImage4.Image = Image.FromFile(Constant.IMAGE_FOLDER + image2);
                }
                    
                DateTime timeIn = dt.Rows[0].Field<DateTime>("TimeStart");
                labelTimeIn.Text = timeIn.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }

        private bool KiemTraXeChuaRa()
        {
            DataTable dt = CarDAO.GetLastCarByID(cardID);
            if (dt != null && dt.Rows.Count > 0)
            {
                String idIn = dt.Rows[0].Field<String>("IDIn");
                String idOut = dt.Rows[0].Field<String>("IDOut");
                if (!idIn.Equals("") && idOut.Equals(""))
                {
                    return true;
                }
            }
            return false;
        }

        private void loadCamera1VLC()
        {
            String rtspString = cameraUrl1;
            axVLCPlugin1.playlist.add(rtspString, " ", null);
            try
            {
                axVLCPlugin1.playlist.play();
                axVLCPlugin1.BringToFront();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void saveImage1ToFile()
        {
            axVLCPlugin1.playlist.togglePause();
            Bitmap bmpScreenshot = new Bitmap(axVLCPlugin1.ClientRectangle.Width,
                axVLCPlugin1.ClientRectangle.Height);
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            System.Drawing.Size imgSize = new System.Drawing.Size(
                axVLCPlugin1.ClientRectangle.Width,
                axVLCPlugin1.ClientRectangle.Height);
            Point ps = PointToScreen(new Point(axVLCPlugin1.Bounds.X, axVLCPlugin1.Bounds.Y));
            gfxScreenshot.CopyFromScreen(ps.X + 2, ps.Y + 144, 0, 0, imgSize, CopyPixelOperation.SourceCopy);
            axVLCPlugin1.playlist.play();

            //if (CarDAO.isCarIn(cardID))
            if (isCarIn())
            {
                pictureBoxImage1.Image = bmpScreenshot;
                imagePath1 = DateTime.Now.Ticks + ".jpg";
                saveBitmapToFile(bmpScreenshot, imagePath1);
            }
        }

        private void loadCamera2VLC()
        {
            String rtspString = cameraUrl2;
            axVLCPlugin2.playlist.add(rtspString, " ", null);
            try
            {
                axVLCPlugin2.playlist.play();
                axVLCPlugin2.BringToFront();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void saveImage2ToFile()
        {
            axVLCPlugin2.playlist.togglePause();
            Bitmap bmpScreenshot = new Bitmap(axVLCPlugin2.ClientRectangle.Width,
                axVLCPlugin2.ClientRectangle.Height);
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            System.Drawing.Size imgSize = new System.Drawing.Size(
                axVLCPlugin2.ClientRectangle.Width,
                axVLCPlugin2.ClientRectangle.Height);
            Point ps = PointToScreen(new Point(axVLCPlugin2.Bounds.X, axVLCPlugin2.Bounds.Y));
            gfxScreenshot.CopyFromScreen(ps.X + 2, ps.Y + 144, 0, 0, imgSize, CopyPixelOperation.SourceCopy);
            axVLCPlugin2.playlist.play();

            //if (CarDAO.isCarIn(cardID))
            if (isCarIn())
            {
                pictureBoxImage2.Image = bmpScreenshot;
                imagePath2 = DateTime.Now.Ticks + ".jpg";
                saveBitmapToFile(bmpScreenshot, imagePath2);
            }
        }

        private void loadCamera3VLC()
        {
            String rtspString = cameraUrl3;
            axVLCPlugin3.playlist.add(rtspString, " ", null);
            try
            {
                axVLCPlugin3.playlist.play();
                axVLCPlugin3.BringToFront();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void saveImage3ToFile()
        {
            axVLCPlugin3.playlist.togglePause();
            Bitmap bmpScreenshot = new Bitmap(axVLCPlugin3.ClientRectangle.Width,
                axVLCPlugin3.ClientRectangle.Height);
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            System.Drawing.Size imgSize = new System.Drawing.Size(
                axVLCPlugin3.ClientRectangle.Width,
                axVLCPlugin3.ClientRectangle.Height);
            Point ps = PointToScreen(new Point(axVLCPlugin3.Bounds.X, axVLCPlugin3.Bounds.Y));
            gfxScreenshot.CopyFromScreen(ps.X + 2, ps.Y + 144, 0, 0, imgSize, CopyPixelOperation.SourceCopy);
            axVLCPlugin3.playlist.play();

            imagePath3 = DateTime.Now.Ticks + ".jpg";
            saveBitmapToFile(bmpScreenshot, imagePath3);
        }

        private void loadCamera4VLC()
        {
            String rtspString = cameraUrl4;
            axVLCPlugin4.playlist.add(rtspString, " ", null);
            try
            {
                axVLCPlugin4.playlist.play();
                axVLCPlugin4.BringToFront();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void saveImage4ToFile()
        {
            axVLCPlugin4.playlist.togglePause();
            Bitmap bmpScreenshot = new Bitmap(axVLCPlugin4.ClientRectangle.Width,
                axVLCPlugin4.ClientRectangle.Height);
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            System.Drawing.Size imgSize = new System.Drawing.Size(
                axVLCPlugin4.ClientRectangle.Width,
                axVLCPlugin4.ClientRectangle.Height);
            Point ps = PointToScreen(new Point(axVLCPlugin4.Bounds.X, axVLCPlugin4.Bounds.Y));
            gfxScreenshot.CopyFromScreen(ps.X + 2, ps.Y + 144, 0, 0, imgSize, CopyPixelOperation.SourceCopy);
            axVLCPlugin4.playlist.play();

            imagePath4 = DateTime.Now.Ticks + ".jpg";
            saveBitmapToFile(bmpScreenshot, imagePath4);
        }

        private void tbRFIDCardID_Leave(object sender, EventArgs e)
        {
            tbRFIDCardID.Focus();
        }

        public void readConfigFile()
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
                        parseConfigFile(config);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        private void parseConfigFile(Config config)
        {
            cameraUrl1 = config.cameraUrl1;
            cameraUrl2 = config.cameraUrl2;

            cameraUrl3 = config.cameraUrl3;
            cameraUrl4 = config.cameraUrl4;
            rfidIn = config.rfidIn;
            rfidOut = config.rfidOut;
        }

        private void configVLC()
        {
            axVLCPlugin1.video.aspectRatio = "209:253";
            axVLCPlugin2.video.aspectRatio = "209:253";
            axVLCPlugin3.video.aspectRatio = "209:253";
            axVLCPlugin4.video.aspectRatio = "209:253";

            //axVLCPlugin1.video.scale = 0.25f;
            //axVLCPlugin2.video.scale = 0.25f;
            //axVLCPlugin3.video.scale = 0.25f;
            //axVLCPlugin4.video.scale = 0.25f;

            axVLCPlugin1.Toolbar = false;
            axVLCPlugin2.Toolbar = false;
            axVLCPlugin3.Toolbar = false;
            axVLCPlugin4.Toolbar = false;

            axVLCPlugin1.volume = 0;
            axVLCPlugin2.volume = 0;
            axVLCPlugin3.volume = 0;
            axVLCPlugin4.volume = 0;
        }

        private void OnKeyPressed(object sender, RawInputEventArg e)
        {
            String source = e.KeyPressEvent.Source;
            if (e.KeyPressEvent.DeviceName.Equals(rfidIn) || e.KeyPressEvent.DeviceName.Equals(rfidOut))
            {
                keyboardDeviceName = e.KeyPressEvent.DeviceName;
            }
        }

        private void Keyboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            _rawinput.KeyPressed -= OnKeyPressed;
        }

        private static void CurrentDomain_UnhandledException(Object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;

            if (null == ex) return;

            // Log this error. Logging the exception doesn't correct the problem but at least now
            // you may have more insight as to why the exception is being thrown.
            Debug.WriteLine("Unhandled Exception: " + ex.Message);
            Debug.WriteLine("Unhandled Exception: " + ex);
            MessageBox.Show(ex.Message);
        }

        private bool isCarIn()
        {
            if (keyboardDeviceName.Equals(rfidOut))
            {
                return false;
            }
            return true;
        }

        private int tinhTienGiuXe()
        {
            int parkingTypeID = ConfigDAO.GetParkingTypeID();
            switch (parkingTypeID)
            {
                case Constant.LOAI_GIU_XE_MIEN_PHI:
                    return 0;
                case Constant.LOAI_GIU_XE_THEO_CONG_VAN:
                    return tinhGiaTienTheoCongVan();
                case Constant.LOAI_GIU_XE_LUY_TIEN:
                    return tinhGiaTienLuyTien();
                case Constant.LOAI_GIU_XE_TONG_HOP:
                    return tinhGiaTienTongHop();
                default:
                    return tinhGiaTienTheoCongVan();
            }
        }

        private int tinhGiaTienTheoCongVan()
        {
            string partID = CardDAO.getPartIDByCardID(cardID);
            ComputerDTO computerDTO = ComputerDAO.GetDataByPartIDAndParkingTypeID(partID, Constant.LOAI_GIU_XE_THEO_CONG_VAN);
            DataTable dt = CarDAO.GetLastCarByID(cardID);
            if (dt != null)
            {
                DateTime timeIn = dt.Rows[0].Field<DateTime>("TimeStart");
                DateTime timeOut = DateTime.Now;
                double spentTimeByMinute = Util.getTotalTimeByMinute(timeIn, timeOut);
                if (spentTimeByMinute <= computerDTO.MinMinute)
                {
                    return computerDTO.MinCost;
                } else if (timeIn.Hour > computerDTO.EndHourNight && timeOut.Hour < computerDTO.StartHourNight && timeIn.DayOfYear == timeOut.DayOfYear)
                {
                    return computerDTO.DayCost;
                } else if (timeIn.Hour >= computerDTO.StartHourNight && timeOut.Hour <= computerDTO.EndHourNight && timeOut.Date.Day - timeIn.Date.Day >= 1)
                {
                    return computerDTO.NightCost;
                } else if (IsCarInDayOutNightOneDate(timeIn, timeOut, computerDTO) || isCarInNightOutDayOneDate(timeIn, timeOut, computerDTO))
                {
                    if (Util.getTotalTimeByHour(timeIn, timeOut) < computerDTO.IntervalBetweenDayNight)
                    {
                        if (getTotalHourOfDay(timeIn, timeOut, computerDTO) >= getTotalHourOfNight(timeIn, timeOut, computerDTO))
                        {
                            return computerDTO.DayCost;
                        } else
                        {
                            return computerDTO.NightCost;
                        }
                    } else
                    {
                        return computerDTO.DayNightCost;
                    }
                } else
                {
                    if (isCarInDayOutDay(timeIn, timeOut, computerDTO))
                    {
                        return soLuotQuaNgay(timeIn, timeOut, computerDTO) * computerDTO.DayNightCost + computerDTO.DayCost;
                    } else if (isCarInNightOutNight(timeIn, timeOut, computerDTO))
                    {
                        return soLuotQuaNgay(timeIn, timeOut, computerDTO) * computerDTO.DayNightCost + computerDTO.NightCost;
                    } else
                    {
                        return soLuotQuaNgay(timeIn, timeOut, computerDTO) * computerDTO.DayNightCost;
                    }
                }
            }
            return 0;
        }

        private int tinhGiaTienLuyTien()
        {
            string partID = CardDAO.getPartIDByCardID(cardID);
            ComputerDTO computerDTO = ComputerDAO.GetDataByPartIDAndParkingTypeID(partID, Constant.LOAI_GIU_XE_LUY_TIEN);
            DataTable dt = CarDAO.GetLastCarByID(cardID);
            if (dt != null)
            {
                DateTime timeIn = dt.Rows[0].Field<DateTime>("TimeStart");
                DateTime timeOut = DateTime.Now;
                if (Util.getTotalTimeByHour(timeIn, timeOut) <= computerDTO.HourMilestone1)
                {
                    return computerDTO.CostMilestone1;
                } else if (Util.getTotalTimeByHour(timeIn, timeOut) > computerDTO.HourMilestone1 && Util.getTotalTimeByHour(timeIn, timeOut) <= computerDTO.HourMilestone1 + computerDTO.HourMilestone2)
                {
                    return computerDTO.CostMilestone1 + computerDTO.CostMilestone2;
                } else if (computerDTO.IsAdd.Equals(Constant.TINH_TIEN_LUY_TIEN_KHONG_CONG))
                {
                    return computerDTO.CostMilestone1 + computerDTO.CostMilestone2;
                }
                else if (computerDTO.IsAdd.Equals(Constant.TINH_TIEN_LUY_TIEN_CONG_1_MOC))
                {
                    double cost = computerDTO.CostMilestone1 + 
                        (((Util.getTotalTimeByHour(timeIn, timeOut) - computerDTO.HourMilestone1) / computerDTO.CycleMilestone3) + ((Util.getTotalTimeByHour(timeIn, timeOut) - computerDTO.HourMilestone1) % computerDTO.CycleMilestone3)) 
                        * computerDTO.CostMilestone3;
                    return (int) cost;
                }
                else if (computerDTO.IsAdd.Equals(Constant.TINH_TIEN_LUY_TIEN_CONG_2_MOC))
                {
                    double cost = ((Util.getTotalTimeByHour(timeIn, timeOut) / computerDTO.CycleMilestone3) + (Util.getTotalTimeByHour(timeIn, timeOut) % computerDTO.CycleMilestone3))
                        * computerDTO.CostMilestone3;
                    return (int) cost;
                }
            }
            return 0;
        }

        private int tinhGiaTienTongHop()
        {
            string partID = CardDAO.getPartIDByCardID(cardID);
            ComputerDTO computerDTO = ComputerDAO.GetDataByPartIDAndParkingTypeID(partID, Constant.LOAI_GIU_XE_TONG_HOP);
            DataTable dt = CarDAO.GetLastCarByID(cardID);
            if (dt != null)
            {
                DateTime timeIn = dt.Rows[0].Field<DateTime>("TimeStart");
                DateTime timeOut = DateTime.Now;
                if (Util.getTotalTimeByHour(timeIn, timeOut) <= computerDTO.HourMilestone1)
                {
                    return computerDTO.CostMilestone1;
                }
                else if (Util.getTotalTimeByHour(timeIn, timeOut) > computerDTO.HourMilestone1 && Util.getTotalTimeByHour(timeIn, timeOut) <= computerDTO.HourMilestone2)
                {
                    return computerDTO.CostMilestone2;
                }
                else if (computerDTO.IsAdd.Equals(Constant.TINH_TIEN_LUY_TIEN_KHONG_CONG))
                {
                    return computerDTO.CostMilestone1 + computerDTO.CostMilestone2;
                }
                else if (computerDTO.IsAdd.Equals(Constant.TINH_TIEN_LUY_TIEN_CONG_1_MOC))
                {
                    double cost = computerDTO.CostMilestone1 +
                        (((Util.getTotalTimeByHour(timeIn, timeOut) - computerDTO.HourMilestone1) / computerDTO.CycleMilestone3) + ((Util.getTotalTimeByHour(timeIn, timeOut) - computerDTO.HourMilestone1) % computerDTO.CycleMilestone3))
                        * computerDTO.CostMilestone3;
                    return (int)cost;
                }
                else if (computerDTO.IsAdd.Equals(Constant.TINH_TIEN_LUY_TIEN_CONG_2_MOC))
                {
                    double cost = ((Util.getTotalTimeByHour(timeIn, timeOut) / computerDTO.CycleMilestone3) + (Util.getTotalTimeByHour(timeIn, timeOut) % computerDTO.CycleMilestone3))
                        * computerDTO.CostMilestone3;
                    return (int)cost;
                }
            }
            return 0;
        }

        private bool isCarInDayOutDay(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO)
        {
            return (timeIn.Hour >= computerDTO.EndHourNight && timeIn.Hour <= computerDTO.StartHourNight) && (timeOut.Hour >= computerDTO.EndHourNight && timeOut.Hour <= computerDTO.StartHourNight);
        }

        private bool isCarInNightOutNight(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO)
        {
            return (timeIn.Hour >= computerDTO.StartHourNight || timeIn.Hour <= computerDTO.EndHourNight) && (timeOut.Hour >= computerDTO.StartHourNight || timeOut.Hour <= computerDTO.EndHourNight);
        }

        private bool IsCarInDayOutNightOneDate(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO)
        {
            return (timeIn.Hour >= computerDTO.EndHourNight && timeIn.Hour <= computerDTO.StartHourNight) && (timeOut.Hour >= computerDTO.StartHourNight || timeOut.Hour <= computerDTO.EndHourNight) && timeOut.Date.Day - timeIn.Date.Day <= 1;
        }

        private bool isCarInNightOutDayOneDate(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO)
        {
            return (timeIn.Hour >= computerDTO.StartHourNight || timeIn.Hour <= computerDTO.EndHourNight) && (timeOut.Hour >= computerDTO.EndHourNight && timeOut.Hour <= computerDTO.StartHourNight) && timeOut.Date.Day - timeIn.Date.Day <= 1;
        }

        private double getTotalHourOfDay(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO)
        {
            if (IsCarInDayOutNightOneDate(timeIn, timeOut, computerDTO))
            {
                return computerDTO.StartHourNight - timeIn.Hour - (double) timeIn.Date.Minute / 60; 
            } else
            {
                return timeOut.Hour + (double) timeOut.Date.Minute / 60 - computerDTO.EndHourNight;
            }
        }

        private double getTotalHourOfNight(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO)
        {
            if (IsCarInDayOutNightOneDate(timeIn, timeOut, computerDTO))
            {
                if (timeOut.Hour >= computerDTO.StartHourNight && timeOut.Hour < 24)
                {
                    return timeOut.Hour + (double) timeOut.Minute / 60 - computerDTO.StartHourNight;
                } else
                {
                    return timeOut.Hour + (double) timeOut.Minute / 60 + 24 - computerDTO.StartHourNight;
                }
            }
            else
            {
                if (timeIn.Hour >= computerDTO.StartHourNight && timeIn.Hour < 24)
                {
                    return 24 - timeIn.Hour - (double) timeIn.Minute / 60 + computerDTO.EndHourNight;
                }
                else
                {
                    return computerDTO.EndHourNight - timeIn.Hour - (double) timeIn.Minute / 60;
                }
            }
        }

        private int soLuotQuaNgay(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO)
        {
            return Util.getTotalTimeByDay(timeIn, timeOut);
        }
    }
}

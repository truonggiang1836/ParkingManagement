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
using AxAXVLC;
using Newtonsoft.Json.Linq;
using AForge;
using AForge.Imaging;
using AForge.Math;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision.Motion;
using ParkingMangement.TextRecognized;

namespace ParkingMangement.GUI
{
    public partial class FormNhanVien : Form
    {
        private readonly RawInput _rawinput;

        public string CurrentUserID;
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

        private Size oldSize;
        private const float LARGER_FONT_FACTOR = 1.5f;
        private const float SMALLER_FONT_FACTOR = 0.8f;

        private int _lastFormSize;


        //=======class============
        clsImagePlate ImagePlate;
        clsLicensePlate LicensePlate;
        clsNetwork Network;

        public FormNhanVien()
        {
            InitializeComponent();
            //CvInvoke.UseOpenCL = false;
            Control.CheckForIllegalCrossThreadCalls = false;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            _rawinput = new RawInput(Handle, CaptureOnlyInForeground);

            //_rawinput.AddMessageFilter();   // Adding a message filter will cause keypresses to be handled
            //Win32.DeviceAudit();            // Writes a file DeviceAudit.txt to the current directory

            _rawinput.KeyPressed += OnKeyPressed;

            //this.Resize += new EventHandler(Form_Resize);
            _lastFormSize = GetFormArea(this.Size);
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
            Network = new clsNetwork();
            Network.AutoLoadNetworkChar();
            Network.AutoLoadNetworkNum();

            CurrentUserID = Program.CurrentUserID;
            this.BackColor = ColorTranslator.FromHtml("#2e2925");
            this.ActiveControl = tbRFIDCardID;
            labelGetCard.BackColor = ColorTranslator.FromHtml("#51b749");
            labelDateIn.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelDateOut.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelTimeIn.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelTimeOut.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            pictureBoxDigitIn.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            pictureBoxDigitOut.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            pictureBoxDigitRegister.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            pictureBoxCardID.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            pictureBoxCost.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelDigitIn.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelDigitOut.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelDigitRegister.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelCustomerName.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelCardID.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelCostIn.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelCostIn.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelCostOut.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelCostOut.ForeColor = ColorTranslator.FromHtml("#cf9f51");

            labelDigitInHeader.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelDigitOutHeader.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelDigitRegisterHeader.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelCardIDHeader.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelCustomerNameHeader.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelVND1.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelVND2.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelDigitInHeader.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelDigitOutHeader.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelDigitRegisterHeader.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelCardIDHeader.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelCustomerNameHeader.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelVND1.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelVND2.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelDateInHeader.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelDateOutHeader.ForeColor = ColorTranslator.FromHtml("#cf9f51");

            dgvThongKeXeTrongBai.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#d09f52");
            dgvThongKeXeTrongBai.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff");
            dgvThongKeXeTrongBai.EnableHeadersVisualStyles = false;
            dgvThongKeXeTrongBai.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 6.75F, FontStyle.Bold);
            labelComputer.Text = Environment.MachineName;

            dgvThongKeXeTrongBai.DataSource = CarDAO.GetListCarSurvive();


            readConfigFile();
            //Random rnd = new Random();
            //cardID = rnd.Next(119, 122) + "";

            loadInfo();
            configVLC();
            loadCamera1VLC();
            loadCamera2VLC();
            loadCamera3VLC();
            loadCamera4VLC();

            oldSize = base.Size;

            CheckForIllegalCrossThreadCalls = false;
            //loadEmguCvCamera1();
            //loadEmguCvCamera2();
            //loadEmguCvCamera3();
            //loadEmguCvCamera4();
            //imageBox1.Visible = false;
            //imageBox2.Visible = false;
            //imageBox3.Visible = false;
            //imageBox4.Visible = false;
        }

        private void loadInfo()
        {
            timerCurrentTime.Start();
            //labelUserName.Text = UserDAO.GetUserNameByID(Program.CurrentUserID);
            updateCauHinhHienThiXeRaVao();
        }

        private void FormNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Space:
                    //if (tbRFIDCardID.Text.Equals("") && !cardID.Equals("") && KiemTraXeChuaRa())
                    //{
                    //    updateDigitCarIn();
                    //} else
                    //{
                    //    resetData();
                    //}
                    if (!labelDigitIn.Focused)
                    {
                        resetData();
                    }
                    tbRFIDCardID.Focus();
                    break;
                case Keys.F1:
                    //    var formChangePassword = new FormChangePassword();
                    //    formChangePassword.Show();
                    //open_bitmap();
                    break;
                case Keys.F3:
                    var formLogin = new FormLogin();
                    formLogin.formNhanVien = this;
                    formLogin.Show();
                    break;
                case Keys.F4:
                    var formLoginByCard = new FormLoginByCard();
                    formLoginByCard.formNhanVien = this;
                    formLoginByCard.Show();
                    break;
                //case Keys.F5:
                //    openInOutSetting();
                //    break;
                case Keys.F7:
                    openFormQuanLyXeRaVao();
                    break;
                //case Keys.F11:
                //    var formLogout = new FormLogout();
                //    formLogout.formNhanVien = this;
                //    formLogout.Show();
                //    break;
                //case Keys.F12:
                //    var formLogoutByCard = new FormLogOutByCard();
                //    formLogoutByCard.formNhanVien = this;
                //    formLogoutByCard.Show();
                //    break;
            }
        }

        private void openInOutSetting()
        {
            FormInOutSetting formInOutSetting = new FormInOutSetting();
            formInOutSetting.formNhanVien = this;
            formInOutSetting.Show();
        }

        private void openFormQuanLyXeRaVao()
        {
            string functionId = Constant.FUNCTION_ID_NHAN_VIEN;
            string[] listFunctionSec = FunctionalDAO.GetFunctionSecByID(functionId).Split(',');
            if (listFunctionSec.Contains(Constant.NODE_VALUE_XEM_BAO_CAO_F7.ToString()))
            {
                Form formQuanLyXeVaoRa = new FormQuanLyXeVaoRa();
                formQuanLyXeVaoRa.Show();
            }
            else
            {
                MessageBox.Show(Constant.sMessageCanNotSeeReport);
            }
        }

        //private void saveImageToFile(System.Drawing.Image image, string fileName)
        //{
        //    string path = Constant.LOCAL_IMAGE_FOLDER + fileName;
        //    image.Save(path, ImageFormat.Jpeg);
        //}

        private void saveBitmapToFile(Bitmap bitmap, string fileName)
        {
            string sharedPath = Constant.getSharedImageFolder() + fileName;
            //string path = Constant.LOCAL_IMAGE_FOLDER + fileName;
            //bitmap.Save(path, ImageFormat.Jpeg);
            //File.Move(path, sharedPath);
            bitmap.Save(sharedPath, ImageFormat.Jpeg);
        }

        private void saveImage()
        {
            DataTable dtCommonCard = CardDAO.GetCardByID(cardID);
            DataTable dtTicketCard = TicketMonthDAO.GetDataByID(cardID);
            if (dtCommonCard != null && dtCommonCard.Rows.Count > 0)
            {
                if (CardDAO.isUsingByCardID(cardID))
                {
                    if (dtTicketCard != null && dtTicketCard.Rows.Count > 0)
                    {
                        checkForSaveToDB(true);
                    }
                    else
                    {
                        checkForSaveToDB(false);
                    }
                } else
                {
                    MessageBox.Show(Constant.sMessageCardIsLost);
                }
            } else
            {
                MessageBox.Show(Constant.sMessageCardIdNotExist);
            }

            dgvThongKeXeTrongBai.DataSource = CarDAO.GetListCarSurvive();
        }

        private void timerCurrentTime_Tick(object sender, EventArgs e)
        {
            //labelDateOut.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void checkForSaveToDB(bool isTicketCard)
        {
            labelDigitIn.Text = "";
            labelDigitOut.Text = "";
            labelDigitRegister.Text = "";
            labelCustomerName.Text = "-";
            if (isTicketCard)
            {
                labelCustomerName.Text = TicketMonthDAO.GetCustomerNameByID(cardID);
            }
            if (isCarIn())
            {
                if (KiemTraXeChuaRa())
                {
                    if (KiemTraCapNhatXeVao())
                    {
                        updateCarIn(isTicketCard);
                    } else
                    {
                        MessageBox.Show("Thẻ này chưa được quẹt đầu ra");
                    }
                }
                else
                {
                    insertCarIn(isTicketCard);
                }
            } else
            {
                if (KiemTraXeChuaRa())
                {
                    updateCarOut(isTicketCard);
                    loadCarInData();
                } else
                {
                    MessageBox.Show("Thẻ này chưa được quẹt đầu vào");
                }
            }
        }

        private void updateDigitCarIn()
        {
            //cardID = labelCardID.Text;
            string digit = labelDigitIn.Text;
            if (!digit.Equals(""))
            {
                saveImage1ToFile();
                saveImage2ToFile();
                CarDAO.UpdateDigit(cardID, digit, imagePath1, imagePath2);
                labelDigitIn.Text = "";
                pictureBoxImage1.Image = Properties.Resources.ic_logo;
                pictureBoxImage2.Image = Properties.Resources.ic_logo;
                pictureBoxImage3.Image = Properties.Resources.ic_logo;
                pictureBoxImage4.Image = Properties.Resources.ic_logo;
            }
            DataTable dtTicketCard = TicketMonthDAO.GetDataByID(cardID);
            if (dtTicketCard != null && dtTicketCard.Rows.Count > 0)
            {
                updateScreenForCarIn(true);
            } else
            {
                updateScreenForCarIn(false);
            }
        }

        private void insertCarIn(bool isTicketMonthCard)
        {
            saveImage1ToFile();
            saveImage2ToFile();

            CarDTO carDTO = new CarDTO();
            carDTO.Id = cardID;
            carDTO.TimeStart = DateTime.Now;
            carDTO.IdIn = Program.CurrentUserID;
            string partID = CardDAO.getIDByCardID(cardID);
            carDTO.IdPart = partID;
            carDTO.Images = imagePath1;
            carDTO.Images2 = imagePath2;
            carDTO.Computer = Environment.MachineName;
            carDTO.Account = Program.CurrentUserID;
            carDTO.DateUpdate = DateTime.Now;

            if (isTicketMonthCard)
            {
                carDTO.IdTicketMonth = cardID;
                carDTO.Digit = TicketMonthDAO.GetDigitByID(cardID);
            }

            //insertCarInAPI(cardID);
            CarDAO.Insert(carDTO);

            updateScreenForCarIn(isTicketMonthCard);
        }

        private void updateCarIn(bool isTicketMonthCard)
        {
            saveImage1ToFile();
            saveImage2ToFile();

            CarDTO carDTO = new CarDTO();
            int identify = CarDAO.GetLastIdentifyByID(cardID);
            carDTO.Identify = identify;
            carDTO.TimeStart = DateTime.Now;
            carDTO.IdIn = Program.CurrentUserID;
            carDTO.Images = imagePath1;
            carDTO.Images2 = imagePath2;
            carDTO.Computer = Environment.MachineName;
            carDTO.Account = Program.CurrentUserID;
            carDTO.DateUpdate = DateTime.Now;
            string digit = labelDigitIn.Text;
            if (!digit.Equals(""))
            {
                carDTO.Digit = digit;
            }

            if (isTicketMonthCard)
            {
                carDTO.IdTicketMonth = cardID;
                carDTO.Digit = TicketMonthDAO.GetDigitByID(cardID);
            }

            //insertCarInAPI(cardID);
            CarDAO.UpdateCarIn(carDTO);

            updateScreenForCarIn(isTicketMonthCard);
        }

        private void updateScreenForCarIn(bool isTicketMonthCard)
        {
            labelCostIn.Text = "-";
            labelCostOut.Text = "-";
            int inOutType = Util.getConfigFile().inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                labelMoiVao.Text = "";
                labelMoiRa.Text = Constant.sLabelMoiVao;

                pictureBoxImage1.Image = Properties.Resources.ic_logo;
                pictureBoxImage2.Image = Properties.Resources.ic_logo;

                if (isTicketMonthCard)
                {
                    labelDigitRegister.Text = TicketMonthDAO.GetDigitByID(cardID);
                    labelCostIn.Text = "-";
                    labelCostOut.Text = "VE THANG";
                }
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (keyboardDeviceName.Equals(rfidOut))
                {
                    labelMoiVao.Text = "";
                    labelMoiRa.Text = Constant.sLabelMoiVao;

                    pictureBoxImage1.Image = Properties.Resources.ic_logo;
                    pictureBoxImage2.Image = Properties.Resources.ic_logo;

                    if (isTicketMonthCard)
                    {
                        labelDigitRegister.Text = TicketMonthDAO.GetDigitByID(cardID);
                        labelCostIn.Text = "-";
                        labelCostOut.Text = "VE THANG";
                    }
                }
                else
                {
                    labelMoiVao.Text = Constant.sLabelMoiVao;
                    labelMoiRa.Text = "";

                    pictureBoxImage3.Image = Properties.Resources.ic_logo;
                    pictureBoxImage4.Image = Properties.Resources.ic_logo;

                    if (isTicketMonthCard)
                    {
                        labelDigitRegister.Text = TicketMonthDAO.GetDigitByID(cardID);
                        labelCostIn.Text = "VE THANG";
                        labelCostOut.Text = "-";
                    }
                }
            }
            else
            {
                labelMoiVao.Text = Constant.sLabelMoiVao;
                labelMoiRa.Text = "";

                pictureBoxImage3.Image = Properties.Resources.ic_logo;
                pictureBoxImage4.Image = Properties.Resources.ic_logo;

                if (isTicketMonthCard)
                {
                    labelDigitRegister.Text = TicketMonthDAO.GetDigitByID(cardID);
                    labelCostIn.Text = "VE THANG";
                    labelCostOut.Text = "-";
                }
            }

            labelDateIn.Text = DateTime.Now.ToString("dd/MM/yyyy");
            labelTimeIn.Text = DateTime.Now.ToString("HH:mm");
            labelDateOut.Text = "-";
            labelTimeOut.Text = "-";
        }

        private void insertCarInAPI(string cardID)
        {
            WebClient webClient = (new ApiUtil()).getWebClient();
            webClient.QueryString.Add(ApiUtil.PARAM_CODE, cardID);
            webClient.QueryString.Add(ApiUtil.PARAM_PC_NAME, Environment.MachineName);
            try
            {
                String responseString = webClient.DownloadString(ApiUtil.API_CHECKIN);
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
                    }
                }
            }
        }

        private int updateCarOutAPI(string cardID)
        {
            WebClient webClient = (new ApiUtil()).getWebClient();
            webClient.QueryString.Add(ApiUtil.PARAM_CODE, cardID);
            webClient.QueryString.Add(ApiUtil.PARAM_PC_NAME, Environment.MachineName);
            try
            {
                String responseString = webClient.DownloadString(ApiUtil.API_CHECKOUT);
                Console.WriteLine(responseString);
                JObject jObject = JObject.Parse(responseString);
                JToken jUser = jObject["body"];
                return (int)jUser["total_price"];
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
            return -1;
        }

        private void updateCarOut(bool isTicketMonthCard)
        {
            int identify = CarDAO.GetLastIdentifyByID(cardID);
            CarDTO carDTO = new CarDTO();
            carDTO.Identify = identify;
            carDTO.Id = cardID;
            carDTO.TimeEnd = DateTime.Now;
            carDTO.IdOut = Program.CurrentUserID;

            if (isTicketMonthCard)
            {
                carDTO.Cost = 0;
                DateTime expirationDate = TicketMonthDAO.GetExpirationDateByID(cardID);
                if (DateTime.Now.CompareTo(expirationDate) > 0)
                {
                    // vé tháng hết hạn
                    int expiredTicketMonthTypeID = ConfigDAO.GetExpiredTicketMonthTypeID();
                    switch (expiredTicketMonthTypeID)
                    {
                        case Constant.LOAI_HET_HAN_CHI_CANH_BAO_HET_HAN:
                            break;
                        case Constant.LOAI_HET_HAN_TINH_TIEN_NHU_VANG_LAI:
                        default:
                            carDTO.Cost = tinhTienGiuXe();
                            labelCostOut.Text = carDTO.Cost + "";
                            break;
                    }
                    MessageBox.Show("Thẻ tháng đã hết hạn");
                }
            }
            else
            {
                carDTO.Cost = tinhTienGiuXe();
                labelCostOut.Text = carDTO.Cost + "";
            }

            /*
            int cost = updateCarOutAPI(cardID);
            if (cost >= 0)
            {
                // case use API data
                if (cost == 0)
                {
                    isTicketMonthCard = true;
                } else
                {
                    isTicketMonthCard = false;
                }
                carDTO.Cost = cost;
                labelCostOut.Text = carDTO.Cost + "";
            } else
            {
                // case use local data
                if (isTicketMonthCard)
                {
                    carDTO.Cost = 0;
                    DateTime expirationDate = TicketMonthDAO.GetExpirationDateByID(cardID);
                    if (DateTime.Now.CompareTo(expirationDate) > 0)
                    {
                        // vé tháng hết hạn
                        int expiredTicketMonthTypeID = ConfigDAO.GetExpiredTicketMonthTypeID();
                        switch (expiredTicketMonthTypeID)
                        {
                            case Constant.LOAI_HET_HAN_CHI_CANH_BAO_HET_HAN:
                                break;
                            case Constant.LOAI_HET_HAN_TINH_TIEN_NHU_VANG_LAI:
                            default:
                                carDTO.Cost = tinhTienGiuXe();
                                labelCostOut.Text = carDTO.Cost + "";
                                break;
                        }
                        MessageBox.Show("Thẻ tháng đã hết hạn");
                    }
                }
                else
                {
                    carDTO.Cost = tinhTienGiuXe();
                    labelCostOut.Text = carDTO.Cost + "";
                }
            }
            */

            saveImage3ToFile();
            saveImage4ToFile();

            carDTO.Images3 = imagePath3;
            carDTO.Images4 = imagePath4;

            carDTO.Computer = Environment.MachineName;
            carDTO.Account = Program.CurrentUserID;
            carDTO.DateUpdate = DateTime.Now;

            CarDAO.UpdateCarOut(carDTO);
            //new Thread(() =>
            //{
            //    Thread.CurrentThread.IsBackground = true;
            //    /* run your code here */
            //    Util.sendOrderToServer(CarDAO.GetCarByIdentify(identify));
            //}).Start();

            labelCostIn.Text = "-";
            labelCostOut.Text = "-";

            int inOutType = Util.getConfigFile().inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                labelMoiVao.Text = Constant.sLabelMoiRa;
                labelMoiRa.Text = "";

                if (carDTO.Cost != null)
                {
                    labelCostIn.Text = Util.formatNumberAsMoney((int) carDTO.Cost);
                }
                labelCostOut.Text = "-";

                pictureBoxImage3.Image = Properties.Resources.ic_logo;
                pictureBoxImage4.Image = Properties.Resources.ic_logo;

                if (isTicketMonthCard)
                {
                    labelDigitRegister.Text = TicketMonthDAO.GetDigitByID(cardID);
                    labelCostIn.Text = "VE THANG";
                }
            }
            else if (inOutType == ConfigDTO.TYPE_OUT_OUT)
            {
                if (keyboardDeviceName.Equals(rfidIn))
                {
                    labelMoiVao.Text = Constant.sLabelMoiRa;
                    labelMoiRa.Text = "";

                    if (carDTO.Cost != null)
                    {
                        labelCostIn.Text = Util.formatNumberAsMoney((int)carDTO.Cost);
                    }
                    labelCostOut.Text = "-";

                    pictureBoxImage3.Image = Properties.Resources.ic_logo;
                    pictureBoxImage4.Image = Properties.Resources.ic_logo;

                    if (isTicketMonthCard)
                    {
                        labelDigitRegister.Text = TicketMonthDAO.GetDigitByID(cardID);
                        labelCostIn.Text = "VE THANG";
                    }
                } else
                {
                    labelMoiVao.Text = "";
                    labelMoiRa.Text = Constant.sLabelMoiRa;

                    labelCostIn.Text = "-";
                    if (carDTO.Cost != null)
                    {
                        labelCostOut.Text = Util.formatNumberAsMoney((int)carDTO.Cost);
                    }

                    pictureBoxImage1.Image = Properties.Resources.ic_logo;
                    pictureBoxImage2.Image = Properties.Resources.ic_logo;

                    if (isTicketMonthCard)
                    {
                        labelDigitRegister.Text = TicketMonthDAO.GetDigitByID(cardID);
                        labelCostOut.Text = "VE THANG";
                    }
                }
            }
            else
            {
                labelMoiVao.Text = "";
                labelMoiRa.Text = Constant.sLabelMoiRa;

                labelCostIn.Text = "-";
                if (carDTO.Cost != null)
                {
                    labelCostOut.Text = Util.formatNumberAsMoney((int)carDTO.Cost);
                }

                pictureBoxImage1.Image = Properties.Resources.ic_logo;
                pictureBoxImage2.Image = Properties.Resources.ic_logo;

                if (isTicketMonthCard)
                {
                    labelDigitRegister.Text = TicketMonthDAO.GetDigitByID(cardID);
                    labelCostOut.Text = "VE THANG";
                }
            }
        }

        private void loadCarInData()
        {
            DataTable dt = CarDAO.GetLastCarByID(cardID);
            if (dt != null)
            {
                int inOutType = Util.getConfigFile().inOutType;
                string image = dt.Rows[0].Field<string>("Images");
                string imagePath1 = Constant.getSharedImageFolder() + image;
                if (File.Exists(imagePath1))
                {
                    if (inOutType == ConfigDTO.TYPE_OUT_IN)
                    {
                        pictureBoxImage1.Image = System.Drawing.Image.FromFile(imagePath1);
                    }
                    else if (inOutType == ConfigDTO.TYPE_OUT_OUT)
                    {
                        if (keyboardDeviceName.Equals(rfidIn))
                        {
                            pictureBoxImage1.Image = System.Drawing.Image.FromFile(imagePath1);
                        }
                        else
                        {
                            pictureBoxImage3.Image = System.Drawing.Image.FromFile(imagePath1);
                        }
                    }
                    else
                    {
                        pictureBoxImage3.Image = System.Drawing.Image.FromFile(imagePath1);
                    }
                }
                string image2 = dt.Rows[0].Field<string>("Images2");
                string imagePath2 = Constant.getSharedImageFolder() + image2;
                if (File.Exists(imagePath2))
                {
                    if (inOutType == ConfigDTO.TYPE_OUT_IN)
                    {
                        pictureBoxImage2.Image = System.Drawing.Image.FromFile(imagePath2);
                    }
                    else if (inOutType == ConfigDTO.TYPE_OUT_OUT)
                    {
                        if (keyboardDeviceName.Equals(rfidIn))
                        {
                            pictureBoxImage2.Image = System.Drawing.Image.FromFile(imagePath2);
                        }
                        else
                        {
                            pictureBoxImage4.Image = System.Drawing.Image.FromFile(imagePath2);
                        }
                    }
                    else
                    {
                        pictureBoxImage4.Image = System.Drawing.Image.FromFile(imagePath2);
                    }
                }
                    
                DateTime timeIn = dt.Rows[0].Field<DateTime>("TimeStart");
                labelDateIn.Text = timeIn.ToString("dd/MM/yyyy");
                labelTimeIn.Text = timeIn.ToString("HH:mm");
                labelDateOut.Text = DateTime.Now.ToString("dd/MM/yyyy");
                labelTimeOut.Text = DateTime.Now.ToString("HH:mm");

                string digit = dt.Rows[0].Field<string>("Digit");
                labelDigitIn.Text = digit;
            }
        }

        private bool KiemTraXeChuaRa()
        {
            DataTable dt = CarDAO.GetLastCarByID(cardID);
            if (dt != null && dt.Rows.Count > 0)
            {
                String idIn = dt.Rows[0].Field<String>("IDIn");
                String idOut = dt.Rows[0].Field<String>("IDOut");
                if (!idIn.Equals("") && (idOut == null || idOut.Equals("")))
                {
                    return true;
                }
            }
            return false;
        }
        private bool KiemTraCapNhatXeVao()
        {
            DataTable dt = CarDAO.GetLastCarByID(cardID);
            if (dt != null && dt.Rows.Count > 0)
            {
                String idIn = dt.Rows[0].Field<String>("IDIn");
                String idOut = dt.Rows[0].Field<String>("IDOut");
                if (!idIn.Equals("") && (idOut == null || idOut.Equals("")))
                {
                    string lastCardId = CarDAO.GetLastCardID();
                    if (cardID.Equals(lastCardId))
                    {
                        DateTime timeStart = dt.Rows[0].Field<DateTime>("TimeStart");
                        if (Util.getMillisecondBetweenTwoDate(timeStart, DateTime.Now) < 60000)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void loadCamera1VLC()
        {
            String rtspString = cameraUrl1;
            var uri = new Uri(rtspString);
            var convertedURI = uri.AbsoluteUri;
            //axVLCPlugin1.playlist.add(convertedURI);
            axVLCPlugin1.playlist.add(rtspString, "1", "--network-caching=100");
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
            AxVLCPlugin2 axVLCPlugin = axVLCPlugin1;
            PictureBox pictureBox = pictureBoxImage1;
            int inOutType = Util.getConfigFile().inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                axVLCPlugin = axVLCPlugin3;
                pictureBox = pictureBoxImage3;
            } else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (keyboardDeviceName.Equals(rfidOut))
                {
                    axVLCPlugin = axVLCPlugin3;
                    pictureBox = pictureBoxImage3;
                }
            }
            Bitmap bmpScreenshot = getBitMapFromCamera(axVLCPlugin);

            if (isCarIn())
            {
                pictureBox.Image = bmpScreenshot;
                imagePath1 = DateTime.Now.Ticks + ".jpg";
                saveBitmapToFile(bmpScreenshot, imagePath1);
            }
        }

        private void loadCamera2VLC()
        {
            String rtspString = cameraUrl2;
            axVLCPlugin2.playlist.add(rtspString, "2", "--network-caching=100");
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
            AxVLCPlugin2 axVLCPlugin = axVLCPlugin2;
            PictureBox pictureBox = pictureBoxImage2;
            int inOutType = Util.getConfigFile().inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                axVLCPlugin = axVLCPlugin4;
                pictureBox = pictureBoxImage4;
            } else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (keyboardDeviceName.Equals(rfidOut))
                {
                    axVLCPlugin = axVLCPlugin4;
                    pictureBox = pictureBoxImage4;
                }
            }
            Bitmap bmpScreenshot = getBitMapFromCamera(axVLCPlugin);

            if (isCarIn())
            {
                pictureBox.Image = bmpScreenshot;
                imagePath2 = DateTime.Now.Ticks + ".jpg";
                saveBitmapToFile(bmpScreenshot, imagePath2);

                //bmpScreenshot = new Bitmap(Application.StartupPath + "\\anh\\huynh.JPG");
                ImagePlate = new clsImagePlate(bmpScreenshot);
                DisplayNumberPalate(true);
            }
        }

        private void loadCamera3VLC()
        {
            String rtspString = cameraUrl3;
            axVLCPlugin3.playlist.add(rtspString, "3", "--network-caching=100");
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
            AxVLCPlugin2 axVLCPlugin = axVLCPlugin3;
            int inOutType = Util.getConfigFile().inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                axVLCPlugin = axVLCPlugin1;
            } else if (inOutType == ConfigDTO.TYPE_OUT_OUT)
            {
                if (keyboardDeviceName.Equals(rfidIn))
                {
                    axVLCPlugin = axVLCPlugin1;
                }
            }
            Bitmap bmpScreenshot = getBitMapFromCamera(axVLCPlugin);

            imagePath3 = DateTime.Now.Ticks + ".jpg";
            saveBitmapToFile(bmpScreenshot, imagePath3);
        }

        private void loadCamera4VLC()
        {
            String rtspString = cameraUrl4;
            axVLCPlugin4.playlist.add(rtspString, "4", "--network-caching=100");
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
            AxVLCPlugin2 axVLCPlugin = axVLCPlugin4;
            int inOutType = Util.getConfigFile().inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                axVLCPlugin = axVLCPlugin2;
            }
            else if (inOutType == ConfigDTO.TYPE_OUT_OUT)
            {
                if (keyboardDeviceName.Equals(rfidIn))
                {
                    axVLCPlugin = axVLCPlugin2;
                }
            }
            Bitmap bmpScreenshot = getBitMapFromCamera(axVLCPlugin);

            imagePath4 = DateTime.Now.Ticks + ".jpg";
            saveBitmapToFile(bmpScreenshot, imagePath4);

            //bmpScreenshot = new Bitmap(Application.StartupPath + "\\anh\\khue.JPG");
            ImagePlate = new clsImagePlate(bmpScreenshot);
            DisplayNumberPalate(false);
        }

        private Bitmap getBitMapFromCamera(AxVLCPlugin2 axVLCPlugin)
        {
            axVLCPlugin.playlist.togglePause();
            Bitmap bmpScreenshot = new Bitmap(axVLCPlugin.ClientRectangle.Width,
                axVLCPlugin.ClientRectangle.Height);
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            System.Drawing.Size imgSize = new System.Drawing.Size(
                axVLCPlugin.ClientRectangle.Width,
                axVLCPlugin.ClientRectangle.Height);
            System.Drawing.Point ps = axVLCPlugin.PointToScreen(System.Drawing.Point.Empty);
            gfxScreenshot.CopyFromScreen(ps.X, ps.Y, 0, 0, imgSize, CopyPixelOperation.SourceCopy);
            axVLCPlugin.playlist.play();
            return bmpScreenshot;
        }

        private void tbRFIDCardID_Leave(object sender, EventArgs e)
        {
            //tbRFIDCardID.Focus();
        }

        public void readConfigFile()
        {
            //try
            //{
            //    String filePath = Application.StartupPath + "\\" + Constant.sFileNameConfig;
            //    if (File.Exists(filePath))
            //    {
            //        string xmlString = File.ReadAllText(filePath);
            //        XmlRootAttribute xmlRoot = new XmlRootAttribute();
            //        xmlRoot.ElementName = "xml";
            //        xmlRoot.IsNullable = true;
            //        XmlSerializer serializer = new XmlSerializer(typeof(Config), xmlRoot);
            //        using (TextReader reader = new StringReader(xmlString))
            //        {
            //            Config config = (Config)serializer.Deserialize(reader);
            //            parseConfigFile(config);
            //        }
            //    }
            //}
            //catch (Exception e)
            //{

            //}

            cameraUrl1 = Util.getConfigFile().cameraUrl1;
            cameraUrl2 = Util.getConfigFile().cameraUrl2;
            cameraUrl3 = Util.getConfigFile().cameraUrl3;
            cameraUrl4 = Util.getConfigFile().cameraUrl4;
            rfidIn = Util.getConfigFile().rfidIn;
            rfidOut = Util.getConfigFile().rfidOut;
            //cameraUrl1 = ConfigDAO.GetCamera1();
            //cameraUrl2 = ConfigDAO.GetCamera2();
            //cameraUrl3 = ConfigDAO.GetCamera3();
            //cameraUrl4 = ConfigDAO.GetCamera4();
            //rfidIn = ConfigDAO.GetRFID1();
            //rfidOut = ConfigDAO.GetRFID2();
        }

        //private void parseConfigFile(Config config)
        //{
        //    cameraUrl1 = config.cameraUrl1;
        //    cameraUrl2 = config.cameraUrl2;

        //    cameraUrl3 = config.cameraUrl3;
        //    cameraUrl4 = config.cameraUrl4;
        //    rfidIn = config.rfidIn;
        //    rfidOut = config.rfidOut;
        //}

        private void configVLC()
        {
            axVLCPlugin1.video.aspectRatio = "209:253";
            axVLCPlugin2.video.aspectRatio = "209:253";
            axVLCPlugin3.video.aspectRatio = "209:253";
            axVLCPlugin4.video.aspectRatio = "209:253";

            axVLCPlugin1.video.scale = 0.7f;
            axVLCPlugin2.video.scale = 0.7f;
            axVLCPlugin3.video.scale = 0.7f;
            axVLCPlugin4.video.scale = 0.7f;

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
            } else
            {
                keyboardDeviceName = "";
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
            int inOutType = Util.getConfigFile().inOutType;
            switch (inOutType)
            {
                case ConfigDTO.TYPE_IN_IN:
                    return true;
                case ConfigDTO.TYPE_OUT_OUT:
                    return false;
                case ConfigDTO.TYPE_IN_OUT:
                    if (keyboardDeviceName.Equals(rfidOut))
                    {
                        return false;
                    }
                    return true;
                case ConfigDTO.TYPE_OUT_IN:
                    if (keyboardDeviceName.Equals(rfidOut))
                    {
                        return true;
                    }
                    return false;
                default:
                    if (keyboardDeviceName.Equals(rfidOut))
                    {
                        return false;
                    }
                    return true;
            }
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
            string partID = CardDAO.getIDByCardID(cardID);
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
                        return (soLuotQuaNgay(timeIn, timeOut, computerDTO) + 1) * computerDTO.DayNightCost;
                    }
                }
            }
            return 0;
        }

        private int tinhGiaTienLuyTien()
        {
            string partID = CardDAO.getIDByCardID(cardID);
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
            string partID = CardDAO.getIDByCardID(cardID);
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

        public void updateCauHinhHienThiXeRaVao()
        {
            int inOutType = Util.getConfigFile().inOutType;
            switch (inOutType)
            {
                case ConfigDTO.TYPE_IN_IN:
                    labelXeVao.Text = Constant.sLabelXeVao;
                    labelXeRa.Text = Constant.sLabelXeVao;
                    break;
                case ConfigDTO.TYPE_OUT_OUT:
                    labelXeVao.Text = Constant.sLabelXeRa;
                    labelXeRa.Text = Constant.sLabelXeRa;
                    break;
                case ConfigDTO.TYPE_OUT_IN:
                    labelXeVao.Text = Constant.sLabelXeRa;
                    labelXeRa.Text = Constant.sLabelXeVao;
                    break;
                case ConfigDTO.TYPE_IN_OUT:
                default:
                    labelXeVao.Text = Constant.sLabelXeVao;
                    labelXeRa.Text = Constant.sLabelXeRa;
                    break;
            }

            resetData();
        }

        private void resetData()
        {
            labelMoiVao.Text = "";
            labelMoiRa.Text = "";
            labelCardID.Text = "-";
            labelCustomerName.Text = "-";
            labelCostIn.Text = "-";
            labelCostOut.Text = "-";
            labelDateIn.Text = "-";
            labelTimeIn.Text = "-";
            labelDateOut.Text = "-";
            labelTimeOut.Text = "-";
            pictureBoxImage1.Image = Properties.Resources.ic_logo;
            pictureBoxImage2.Image = Properties.Resources.ic_logo;
            pictureBoxImage3.Image = Properties.Resources.ic_logo;
            pictureBoxImage4.Image = Properties.Resources.ic_logo;
            labelDigitIn.Text = "";
            labelDigitOut.Text = "";
        }

        private void pictureBoxChangeLane_Click(object sender, EventArgs e)
        {
            openInOutSetting();
        }

        private void pictureBoxGetCard_Click(object sender, EventArgs e)
        {
            openFormQuanLyXeRaVao();
        }

        private void labelDigitIn_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (!keyboardDeviceName.Equals(rfidIn) && !keyboardDeviceName.Equals(rfidOut))
                    {
                        updateDigitCarIn();
                        tbRFIDCardID.Focus();
                    } else
                    {
                        labelDigitIn.Text = "";
                    }
                    break;
            }
        }

        private void tbRFIDCardID_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Space:
                    cardID = tbRFIDCardID.Text;
                    labelCardID.Text = CardDAO.getIdentifyByCardID(cardID) + "";
                    string x = keyboardDeviceName;
                    tbRFIDCardID.Text = "";
                    if (!cardID.Equals(""))
                    {
                        saveImage();
                    }
                    break;
            }
        }

        private void labelDigitIn_Leave(object sender, EventArgs e)
        {
            tbRFIDCardID.Focus();
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            foreach (Control cnt in this.Controls)
            {
                ResizeAll(cnt, base.Size);
            }
            //Form_Resize();
            oldSize = base.Size;
        }
        private void ResizeAll(Control cnt, Size newSize)
        {
            int iWidth = newSize.Width - oldSize.Width;
            cnt.Left += (cnt.Left * iWidth) / oldSize.Width;
            cnt.Width += (cnt.Width * iWidth) / oldSize.Width;

            int iHeight = newSize.Height - oldSize.Height;
            cnt.Top += (cnt.Top * iHeight) / oldSize.Height;
            cnt.Height += (cnt.Height * iHeight) / oldSize.Height;
            foreach (Control childControl in cnt.Controls)
            {
                ResizeAll(childControl, base.Size);
            }
        }

        private int GetFormArea(Size size)
        {
            return size.Height * size.Width;
        }

        private void Form_Resize()
        {

            var bigger = GetFormArea(this.Size) > _lastFormSize;
            float scaleFactor = bigger ? LARGER_FONT_FACTOR : SMALLER_FONT_FACTOR;

            ResizeFont(this.Controls, scaleFactor);
            _lastFormSize = GetFormArea(this.Size);
        }

        private void ResizeFont(Control.ControlCollection coll, float scaleFactor)
        {
            foreach (Control c in coll)
            {
                if (c.HasChildren)
                {
                    ResizeFont(c.Controls, scaleFactor);
                }
                else
                {
                    //if (c.GetType().ToString() == "System.Windows.Form.Label")
                    if (true)
                    {
                        // scale font
                        c.Font = new Font(c.Font.FontFamily.Name, c.Font.Size * scaleFactor);
                    }
                }
            }
        }

        private void dgvThongKeXeTrongBai_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dgvThongKeXeTrongBai.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvThongKeXeTrongBai.Rows[i].Cells["CountCarSurvive"].Value);
            }
            labelTongXeTrongBaiValue.Text = sum.ToString();
        }

        private void dgvThongKeXeTrongBai_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = dgvThongKeXeTrongBai.Rows[e.RowIndex];
            row.DefaultCellStyle.BackColor = Color.Black;
            row.DefaultCellStyle.ForeColor = Color.White;
        }

        private void dgvThongKeXeTrongBai_SelectionChanged(object sender, EventArgs e)
        {
            dgvThongKeXeTrongBai.ClearSelection();
        }

        private void FormNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }



        private void open_bitmap()
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.InitialDirectory = Application.StartupPath + "\\foreground";
                op.Filter = ("Image files (*.jpg,*.png,*.tif,*.bmp,*.gif)|*.jpg;*.png;*.tif;*.bmp;*.gif|JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|TIF files (*.tif)|*.tif|BMP files (*.bmp)|*.bmp|GIF files (*.gif)|*.gif|All files(*.*)|*.*");
                if (op.ShowDialog() == DialogResult.OK)
                {
                    if (op.FileName != null)
                    {
                        StreamReader bitmap_file_stream = new StreamReader(op.FileName);
                        string bmp_file_name = Path.GetFileName(op.FileName);
                        ImagePlate = new clsImagePlate(new Bitmap(op.FileName));

                        bitmap_file_stream.Close();
                        pictureBoxImage1.Image = ImagePlate.IMAGE;
                        DisplayNumberPalate(true);
                    }

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void DisplayNumberPalate(bool isCarIn)
        {
            //try
            //{
            //    //lay anh bang so
            //    ImagePlate.Get_Plate();
            //    //tao anh bang so
            //    LicensePlate = new clsLicensePlate();
            //    LicensePlate.PLATE = ImagePlate.PLATE;
            //    //cat ky tu
            //    LicensePlate.Split(ImagePlate.Plate_Type);
            //    //recognize
            //    Network.IMAGEARR = LicensePlate.IMAGEARR;
            //    int sum = LicensePlate.getsumcharacter();
            //    Network.recognition(sum, ImagePlate.Plate_Type);
            //    if (isCarIn)
            //    {
            //        labelDigitIn.Text = Network.LICENSETEXT.Trim();
            //    } else
            //    {
            //        labelDigitOut.Text = Network.LICENSETEXT.Trim();
            //    }
            //}
            //catch
            //{
            //    //MessageBox.Show("Not Recognized");
            //}
        }

        //private Capture capture1 = null;
        //private Capture capture2 = null;
        //private Capture capture3 = null;
        //private Capture capture4 = null;
        //private void ProcessFrame1(object sender, EventArgs arg)
        //{
        //    int height = imageBox1.Height;
        //    int width = imageBox1.Width;
        //    Mat frame = new Mat();

        //    capture1.Retrieve(frame, 0);
        //    CvInvoke.Resize(frame, frame, new Size(width, height), 0, 0, Inter.Linear);

        //    imageBox1.Image = frame;
        //}

        //private void ProcessFrame2(object sender, EventArgs arg)
        //{
        //    int height = imageBox2.Height;
        //    int width = imageBox2.Width;
        //    Mat frame = new Mat();

        //    capture2.Retrieve(frame, 0);
        //    CvInvoke.Resize(frame, frame, new Size(width, height), 0, 0, Inter.Linear);

        //    imageBox2.Image = frame;
        //}

        //private void ProcessFrame3(object sender, EventArgs arg)
        //{
        //    int height = imageBox3.Height;
        //    int width = imageBox3.Width;
        //    Mat frame = new Mat();

        //    capture3.Retrieve(frame, 0);
        //    CvInvoke.Resize(frame, frame, new Size(width, height), 0, 0, Inter.Linear);

        //    imageBox3.Image = frame;
        //}

        //private void ProcessFrame4(object sender, EventArgs arg)
        //{
        //    int height = imageBox4.Height;
        //    int width = imageBox4.Width;
        //    Mat frame = new Mat();

        //    capture4.Retrieve(frame, 0);
        //    CvInvoke.Resize(frame, frame, new Size(width, height), 0, 0, Inter.Linear);

        //    imageBox4.Image = frame;
        //}

        //private void loadEmguCvCamera1()
        //{
        //    try
        //    {
        //        capture1 = new Emgu.CV.Capture(cameraUrl1);
        //        capture1.ImageGrabbed += ProcessFrame1;
        //        capture1.Start();
        //    }
        //    catch
        //    {

        //    }
        //}

        //private void loadEmguCvCamera2()
        //{
        //    try
        //    {
        //        capture2 = new Emgu.CV.Capture(cameraUrl2);
        //        capture2.ImageGrabbed += ProcessFrame2;
        //        capture2.Start();
        //    }
        //    catch
        //    {

        //    }
        //}

        //private void loadEmguCvCamera3()
        //{
        //    try
        //    {
        //        capture3 = new Emgu.CV.Capture(cameraUrl3);
        //        capture3.ImageGrabbed += ProcessFrame3;
        //        capture3.Start();
        //    }
        //    catch
        //    {

        //    }
        //}

        //private void loadEmguCvCamera4()
        //{
        //    try
        //    {
        //        capture4 = new Emgu.CV.Capture(cameraUrl4);
        //        capture4.ImageGrabbed += ProcessFrame4;
        //        capture4.Start();
        //    }
        //    catch
        //    {

        //    }
        //}
    }
}

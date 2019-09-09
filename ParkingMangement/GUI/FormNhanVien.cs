﻿using ParkingMangement.Utils;
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
using System.Timers;
using ReaderB;

namespace ParkingMangement.GUI
{
    public partial class FormNhanVien : Form
    {
        private readonly RawInput _rawinput;

        public string CurrentUserID;
        const bool CaptureOnlyInForeground = true;
        private string cardID = "0";
        private string oldUhfCardId = null;
        private string rfidInput = "";
        private string portNameComReceiveInput = null;

        //const string cameraUrl = @"rtsp://admin:bmv333999@192.168.1.190:554/cam/realmonitor?channel=1&subtype=0&unicast=true&proto=Onvif";
        const string cameraUrl = @"rtsp://184.72.239.149/vod/mp4:BigBuckBunny_175k.mov";
        private string cameraUrl1 = cameraUrl;
        private string cameraUrl2 = cameraUrl;
        private string cameraUrl3 = cameraUrl;
        private string cameraUrl4 = cameraUrl;

        private string rfidIn = "";
        private string rfidOut = "";
        private string portNameComReceiveIn = "";
        private string portNameComReceiveOut = "";

        private SerialPort portComReceiveIn;
        private SerialPort portComReceiveOut;

        private string imagePath1;
        private string imagePath2;
        private string imagePath3;
        private string imagePath4;

        private Size oldSize;
        private const float LARGER_FONT_FACTOR = 1.5f;
        private const float SMALLER_FONT_FACTOR = 0.8f;

        private bool isClosedBarie1 = true;
        private bool isClosedBarie2 = true;

        //private bool mIsHasCarInOut = false;

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
            //Network = new clsNetwork();
            //Network.AutoLoadNetworkChar();
            //Network.AutoLoadNetworkNum();

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
            labelPartNameTypeName.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelCostIn.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            //labelCostIn.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelCostOut.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            //labelCostOut.ForeColor = ColorTranslator.FromHtml("#cf9f51");

            labelDigitInHeader.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelDigitOutHeader.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelDigitRegisterHeader.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelCardIDHeader.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelPartNameTypeNameHeader.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelCustomerNameHeader.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelVND1.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelVND2.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelDigitInHeader.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelDigitOutHeader.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelDigitRegisterHeader.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelCardIDHeader.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelPartNameTypeNameHeader.ForeColor = ColorTranslator.FromHtml("#cf9f51");
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
            labelParkingName.Text = ConfigDAO.GetParkingName();

            if (Util.getConfigFile().isUsingUhf.Equals("yes"))
            {
                initUhfTimer();
            }

            updateThongKeXeTrongBaiByTimer();
            if (Program.isHostMachine)
            {
                Program.sendOrderListToServerTimer();
            }

            readConfigFile();
            //Random rnd = new Random();
            //cardID = rnd.Next(119, 122) + "";

            loadInfo();
            configVLC(Util.getConfigFile().ZoomCamera1, Util.getConfigFile().ZoomCamera2, 
                Util.getConfigFile().ZoomCamera3, Util.getConfigFile().ZoomCamera4);
            loadCamera1VLC();
            loadCamera2VLC();
            loadCamera3VLC();
            loadCamera4VLC();

            getDataFromComReceive();

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

            //timerReadUHFData.Enabled = true;
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
                    if (oldUhfCardId != null)
                    {
                        resetData(true);
                    } else
                    {
                        if (!labelDigitIn.Focused)
                        {
                            if (!tbRFIDCardID.Text.Equals(""))
                            {
                                resetData(false);
                            }
                            else
                            {
                                resetData(true);
                            }
                        }
                    }
                    tbRFIDCardID.Focus();
                    break;
                case Keys.F1:
                    //    var formChangePassword = new FormChangePassword();
                    //    formChangePassword.Show();
                    //open_bitmap();
                    changeInOutSetting(true);
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
                case Keys.F5:
                    //    openInOutSetting();
                    openZoomCameraSetting();
                    break;
                case Keys.F7:
                    openFormQuanLyXeRaVao();
                    break;
                case Keys.F8:
                    openBarie1();
                    MessageBox.Show("Barie đã mở");
                    break;
                case Keys.F9:
                    closeBarie1();
                    MessageBox.Show("Barie đã đóng");
                    break;
                case Keys.F10:
                    //if (isClosedBarie1)
                    //{
                    //    openBarie1();
                    //    MessageBox.Show("Barie đã mở");
                    //}
                    //else
                    //{
                    //    closeBarie1();
                    //    MessageBox.Show("Barie đã đóng");
                    //}
                    openBarie2();
                    MessageBox.Show("Barie đã mở");
                    break;
                case Keys.F11:
                    //    var formLogout = new FormLogout();
                    //    formLogout.formNhanVien = this;
                    //    formLogout.Show();
                    //    break;

                    //if (isClosedBarie2)
                    //{
                    //    openBarie2();
                    //    MessageBox.Show("Barie đã mở");
                    //}
                    //else
                    //{
                    //    closeBarie2();
                    //    MessageBox.Show("Barie đã đóng");
                    //}
                    closeBarie2();
                    MessageBox.Show("Barie đã đóng");
                    break;
                case Keys.F12:
                    //    var formLogoutByCard = new FormLogOutByCard();
                    //    formLogoutByCard.formNhanVien = this;
                    //    formLogoutByCard.Show();
                    changeInOutSetting(false);
                    break;
            }
            //tbRFIDCardID.Focus();
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

        private void openZoomCameraSetting()
        {
            FormZoomCameraSetting formZoomCameraSetting = new FormZoomCameraSetting();
            formZoomCameraSetting.formNhanVien = this;
            formZoomCameraSetting.Show();
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
            deleteOldImages();
            Program.isHasCarInOut = true;
            if (!cardID.Equals(""))
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
                    }
                    else
                    {
                        MessageBox.Show(Constant.sMessageCardIsLost);
                    }
                }
                else
                {
                    AutoClosingMessageBox.Show(Constant.sMessageCardIdNotExist, "", 1000);
                }
                dgvThongKeXeTrongBai.DataSource = CarDAO.GetListCarSurvive();
            }
            portNameComReceiveInput = null;
        }

        private void timerCurrentTime_Tick(object sender, EventArgs e)
        {
            //labelDateOut.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void checkForOpenBarie(DataTable dtLastCar)
        {
            //if (!KiemTraXeChuaRa(dtLastCar))
            //{
            //    checkForOpenBarieIn();
            //}
            //else
            //{
            //    checkForOpenBarieOut();
            //}
            if (isCarIn())
            {
                if (!KiemTraXeChuaRa(dtLastCar))
                {
                    checkForOpenBarieIn();
                }
            }
            else
            {
                if (KiemTraXeChuaRa(dtLastCar))
                {
                    checkForOpenBarieOut();
                }
            }
        }

        private void checkForSaveToDB(bool isTicketCard)
        {
            labelDigitIn.Text = "";
            labelDigitOut.Text = "";
            labelDigitRegister.Text = "";
            labelCustomerName.Text = "-";
            labelPartNameTypeName.Text = CardDAO.GetPartName_TypeNameByCartID(cardID);
            if (isTicketCard)
            {
                labelCustomerName.Text = TicketMonthDAO.GetCustomerNameByID(cardID);
            }
            DataTable dtLastCar = CarDAO.GetLastCarByID(cardID);
            checkForOpenBarie(dtLastCar);
            if (isCarIn())
            {
                if (KiemTraXeChuaRa(dtLastCar))
                {
                    if (!KiemTraCapNhatXeVao(dtLastCar))
                    {
                        resetPictureBoxImage1();
                        resetPictureBoxImage2();
                        tbRFIDCardID.Focus();
                        AutoClosingMessageBox.Show("Thẻ này chưa được quẹt đầu ra", "", 1000);
                        return;
                    }
                }

                loadImage1ToPictureBox();
                loadImage2ToPictureBox();
                saveImage1ToFile();
                saveImage2ToFile();
                if (KiemTraXeChuaRa(dtLastCar))
                {
                    if (KiemTraCapNhatXeVao(dtLastCar))
                    {
                        updateCarIn(isTicketCard, dtLastCar);
                    }
                }
                else
                {
                    insertCarIn(isTicketCard);
                }
            } else
            {
                if (KiemTraXeChuaRa(dtLastCar) || KiemTraCapNhatXeRa(dtLastCar))
                {
                    updateCarOut(isTicketCard, dtLastCar, KiemTraCapNhatXeRa(dtLastCar));
                    loadCarInData(dtLastCar);
                } else
                {
                    tbRFIDCardID.Focus();
                    AutoClosingMessageBox.Show("Thẻ này chưa được quẹt đầu vào", "", 1000);
                }
            }
        }

        private void updateDigitCarIn()
        {
            //cardID = labelCardID.Text;
            string digit = labelDigitIn.Text;
            if (!digit.Equals(""))
            {
                //saveImage1ToFile();
                //saveImage2ToFile();
                CarDAO.UpdateDigit(cardID, digit, imagePath1, imagePath2);
                labelDigitIn.Text = "";
                //pictureBoxImage1.Image = Properties.Resources.ic_logo;
                //pictureBoxImage2.Image = Properties.Resources.ic_logo;
                //pictureBoxImage3.Image = Properties.Resources.ic_logo;
                //pictureBoxImage4.Image = Properties.Resources.ic_logo;
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

        private void checkForOpenBarieIn()
        {
            string cardType = CardDAO.GetTypeByID(cardID);
            if (cardType == TypeDTO.TYPE_CAR)
            {
                if (cardID.Equals(oldUhfCardId))
                {
                    DialogResult dialogResult = MessageBox.Show("Đang có xe đi vào dùng thẻ tầm xa. Bạn có đồng ý mở barie?", "Mở barie", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        openBarie1();
                    }
                }
                else
                {
                    openBarie1();
                }
            }
        }

        private void checkForOpenBarieOut()
        {
            string cardType = CardDAO.GetTypeByID(cardID);
            if (cardType == TypeDTO.TYPE_CAR)
            {
                if (cardID.Equals(oldUhfCardId))
                {
                    DialogResult dialogResult = MessageBox.Show("Đang có xe đi ra dùng thẻ tầm xa. Bạn có đồng ý mở barie?", "Mở barie", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        openBarie2();
                    }
                }
                else
                {
                    openBarie2();
                }
            }
        }

        private void insertCarIn(bool isTicketMonthCard)
        {
            //checkForOpenBarieIn();

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

            if (isTicketMonthCard)
            {
                carDTO.IdTicketMonth = cardID;
                carDTO.Digit = TicketMonthDAO.GetDigitByID(cardID);
            }

            //insertCarInAPI(cardID);
            CarDAO.Insert(carDTO);
            updateScreenForCarIn(isTicketMonthCard);
            WaitSyncCarInDAO.Insert(CarDAO.GetLastIdentifyByID(cardID));
        }

        private void updateCarIn(bool isTicketMonthCard, DataTable dtLastCar)
        {
            if (dtLastCar != null && dtLastCar.Rows.Count > 0)
            {
                int identify = dtLastCar.Rows[0].Field<int>("Identify");
                CarDTO carDTO = new CarDTO();
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

                //pictureBoxImage1.Image = Properties.Resources.ic_logo;
                //pictureBoxImage2.Image = Properties.Resources.ic_logo;

                if (isTicketMonthCard)
                {
                    labelDigitRegister.Text = TicketMonthDAO.GetDigitByID(cardID);
                    labelCostIn.Text = "-";
                    if (ConfigDAO.GetCalculationTicketMonth() == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                    {
                        labelCostOut.Text = "VE THANG";
                    }
                }
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (inputIsOutside())
                {
                    labelMoiVao.Text = "";
                    labelMoiRa.Text = Constant.sLabelMoiVao;

                    //pictureBoxImage1.Image = Properties.Resources.ic_logo;
                    //pictureBoxImage2.Image = Properties.Resources.ic_logo;

                    if (isTicketMonthCard)
                    {
                        labelDigitRegister.Text = TicketMonthDAO.GetDigitByID(cardID);
                        labelCostIn.Text = "-";
                        if (ConfigDAO.GetCalculationTicketMonth() == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                        {
                            labelCostOut.Text = "VE THANG";
                        }
                    }
                }
                else
                {
                    labelMoiVao.Text = Constant.sLabelMoiVao;
                    labelMoiRa.Text = "";

                    //pictureBoxImage3.Image = Properties.Resources.ic_logo;
                    //pictureBoxImage4.Image = Properties.Resources.ic_logo;

                    if (isTicketMonthCard)
                    {
                        labelDigitRegister.Text = TicketMonthDAO.GetDigitByID(cardID);
                        if (ConfigDAO.GetCalculationTicketMonth() == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                        {
                            labelCostIn.Text = "VE THANG";
                        }
                        labelCostOut.Text = "-";
                    }
                }
            }
            else
            {
                labelMoiVao.Text = Constant.sLabelMoiVao;
                labelMoiRa.Text = "";

                //pictureBoxImage3.Image = Properties.Resources.ic_logo;
                //pictureBoxImage4.Image = Properties.Resources.ic_logo;

                if (isTicketMonthCard)
                {
                    labelDigitRegister.Text = TicketMonthDAO.GetDigitByID(cardID);
                    if (ConfigDAO.GetCalculationTicketMonth() == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                    {
                        labelCostIn.Text = "VE THANG";
                    }
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

        private void updateCarOut(bool isTicketMonthCard, DataTable dtLastCar, bool isUpdateCarOut)
        {
            if (dtLastCar != null && dtLastCar.Rows.Count > 0)
            {
                DateTime timeIn = dtLastCar.Rows[0].Field<DateTime>("TimeStart");
                labelDateIn.Text = timeIn.ToString("dd/MM/yyyy");
                labelTimeIn.Text = timeIn.ToString("HH:mm");
                labelDateOut.Text = DateTime.Now.ToString("dd/MM/yyyy");
                labelTimeOut.Text = DateTime.Now.ToString("HH:mm");

                string digit = dtLastCar.Rows[0].Field<string>("Digit");
                labelDigitIn.Text = digit;

                int identify = dtLastCar.Rows[0].Field<int>("Identify");
                CarDTO carDTO = new CarDTO();
                carDTO.Identify = identify;
                carDTO.Id = cardID;
                carDTO.TimeEnd = DateTime.Now;
                carDTO.IdOut = Program.CurrentUserID;

                if (isTicketMonthCard)
                {
                    if (ConfigDAO.GetCalculationTicketMonth() == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                    {
                        carDTO.Cost = 0;
                    } else
                    {
                        if (!isUpdateCarOut)
                        {
                            carDTO.Cost = tinhTienGiuXe(dtLastCar);
                        } else
                        {
                            labelCostOut.Text = dtLastCar.Rows[0].Field<int>("Cost") + "";
                        }
                        
                    }

                    DateTime? expirationDate = TicketMonthDAO.GetExpirationDateByID(cardID);
                    int totalDaysLeft = (int) ((DateTime)expirationDate - DateTime.Now).TotalDays;
                    if (expirationDate != null && totalDaysLeft <= 5)
                    {
                        // vé tháng hết hạn
                        if (DateTime.Now.CompareTo(expirationDate) > 0)
                        {
                            int expiredTicketMonthTypeID = ConfigDAO.GetExpiredTicketMonthTypeID();
                            switch (expiredTicketMonthTypeID)
                            {
                                case Constant.LOAI_HET_HAN_CHI_CANH_BAO_HET_HAN:
                                    break;
                                case Constant.LOAI_HET_HAN_TINH_TIEN_NHU_VANG_LAI:
                                default:
                                    carDTO.Cost = tinhTienGiuXe(dtLastCar);
                                    isTicketMonthCard = false;
                                    break;
                            }
                            MessageBox.Show("Thẻ tháng đã hết hạn");
                        } else
                        {
                            string message = "Thẻ tháng còn " + totalDaysLeft + " ngày nữa sẽ hết hạn!";
                            MessageBox.Show(message);
                        }
                    }
                }
                else
                {
                    carDTO.Cost = tinhTienGiuXe(dtLastCar);
                    //labelCostOut.Text = carDTO.Cost + "";
                }

                int inOutType = Util.getConfigFile().inOutType;

                labelCostIn.Text = "-";
                labelCostOut.Text = "-";

                if (inOutType == ConfigDTO.TYPE_OUT_IN)
                {
                    labelMoiVao.Text = Constant.sLabelMoiRa;
                    labelMoiRa.Text = "";

                    if (carDTO.Cost != null)
                    {
                        labelCostIn.Text = Util.formatNumberAsMoney((int)carDTO.Cost);
                    }
                    labelCostOut.Text = "-";

                    //pictureBoxImage3.Image = Properties.Resources.ic_logo;
                    //pictureBoxImage4.Image = Properties.Resources.ic_logo;

                    if (isTicketMonthCard)
                    {
                        labelDigitRegister.Text = TicketMonthDAO.GetDigitByID(cardID);
                        if (ConfigDAO.GetCalculationTicketMonth() == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                        {
                            labelCostIn.Text = "VE THANG";
                        }
                    }
                }
                else if (inOutType == ConfigDTO.TYPE_OUT_OUT)
                {
                    if (inputIsInside())
                    {
                        labelMoiVao.Text = Constant.sLabelMoiRa;
                        labelMoiRa.Text = "";

                        if (carDTO.Cost != null)
                        {
                            labelCostIn.Text = Util.formatNumberAsMoney((int)carDTO.Cost);
                        }
                        labelCostOut.Text = "-";

                        //pictureBoxImage3.Image = Properties.Resources.ic_logo;
                        //pictureBoxImage4.Image = Properties.Resources.ic_logo;

                        if (isTicketMonthCard)
                        {
                            labelDigitRegister.Text = TicketMonthDAO.GetDigitByID(cardID);
                            if (ConfigDAO.GetCalculationTicketMonth() == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                            {
                                labelCostIn.Text = "VE THANG";
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

                        //pictureBoxImage1.Image = Properties.Resources.ic_logo;
                        //pictureBoxImage2.Image = Properties.Resources.ic_logo;

                        if (isTicketMonthCard)
                        {
                            labelDigitRegister.Text = TicketMonthDAO.GetDigitByID(cardID);
                            if (ConfigDAO.GetCalculationTicketMonth() == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                            {
                                labelCostOut.Text = "VE THANG";
                            }
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

                    //pictureBoxImage1.Image = Properties.Resources.ic_logo;
                    //pictureBoxImage2.Image = Properties.Resources.ic_logo;

                    if (isTicketMonthCard)
                    {
                        labelDigitRegister.Text = TicketMonthDAO.GetDigitByID(cardID);
                        if (ConfigDAO.GetCalculationTicketMonth() == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                        {
                            labelCostOut.Text = "VE THANG";
                        }
                    }
                }

                if (!isUpdateCarOut)
                {
                    //checkForOpenBarieOut();
                    saveImage3ToFile();
                    saveImage4ToFile();

                    carDTO.Images3 = imagePath3;
                    carDTO.Images4 = imagePath4;

                    carDTO.Computer = Environment.MachineName;
                    carDTO.Account = Program.CurrentUserID;
                    carDTO.DateUpdate = DateTime.Now;

                    CarDAO.UpdateCarOut(carDTO);
                    WaitSyncCarOutDAO.Insert(identify);
                }
            }
        }

        private void loadCarInData(DataTable dtLastCar)
        {
            if (dtLastCar != null)
            {                    
                int inOutType = Util.getConfigFile().inOutType;
                string image = dtLastCar.Rows[0].Field<string>("Images");
                string imagePath1 = Constant.getSharedImageFolder() + image;
                if (File.Exists(imagePath1))
                {
                    if (inOutType == ConfigDTO.TYPE_OUT_IN)
                    {
                        //pictureBoxImage1.Image = System.Drawing.Image.FromFile(imagePath1);
                        zoomImageShowToPictureBox(imagePath1, pictureBoxImage1);
                    }
                    else if (inOutType == ConfigDTO.TYPE_OUT_OUT)
                    {
                        if (inputIsInside())
                        {
                            //pictureBoxImage1.Image = System.Drawing.Image.FromFile(imagePath1);
                            zoomImageShowToPictureBox(imagePath1, pictureBoxImage1);
                        }
                        else
                        {
                            //pictureBoxImage3.Image = System.Drawing.Image.FromFile(imagePath1);
                            zoomImageShowToPictureBox(imagePath1, pictureBoxImage3);
                        }
                    }
                    else
                    {
                        //pictureBoxImage3.Image = System.Drawing.Image.FromFile(imagePath1);
                        zoomImageShowToPictureBox(imagePath1, pictureBoxImage3);
                    }
                }
                string image2 = dtLastCar.Rows[0].Field<string>("Images2");
                string imagePath2 = Constant.getSharedImageFolder() + image2;
                if (File.Exists(imagePath2))
                {
                    if (inOutType == ConfigDTO.TYPE_OUT_IN)
                    {
                        //pictureBoxImage2.Image = System.Drawing.Image.FromFile(imagePath2);
                        zoomImageShowToPictureBox(imagePath2, pictureBoxImage2);
                    }
                    else if (inOutType == ConfigDTO.TYPE_OUT_OUT)
                    {
                        if (inputIsInside())
                        {
                            //pictureBoxImage2.Image = System.Drawing.Image.FromFile(imagePath2);
                            zoomImageShowToPictureBox(imagePath2, pictureBoxImage2);
                        }
                        else
                        {
                            //pictureBoxImage4.Image = System.Drawing.Image.FromFile(imagePath2);
                            zoomImageShowToPictureBox(imagePath2, pictureBoxImage4);
                        }
                    }
                    else
                    {
                        //pictureBoxImage4.Image = System.Drawing.Image.FromFile(imagePath2);
                        zoomImageShowToPictureBox(imagePath2, pictureBoxImage4);
                    }
                }
            }
        }

        private bool KiemTraXeChuaRa(DataTable dt)
        {
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
        private bool KiemTraCapNhatXeVao(DataTable dtLastCar)
        {
            if (dtLastCar != null && dtLastCar.Rows.Count > 0)
            {
                String idIn = dtLastCar.Rows[0].Field<String>("IDIn");
                String idOut = dtLastCar.Rows[0].Field<String>("IDOut");
                if (!idIn.Equals("") && (idOut == null || idOut.Equals("")))
                {
                    string lastCardId = dtLastCar.Rows[0].Field<string>("ID");
                    if (cardID.Equals(lastCardId))
                    {
                        DateTime timeStart = dtLastCar.Rows[0].Field<DateTime>("TimeStart");
                        if (Util.getMillisecondBetweenTwoDate(timeStart, DateTime.Now) < 60000)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool KiemTraCapNhatXeRa(DataTable dtLastCar)
        {
            if (dtLastCar != null && dtLastCar.Rows.Count > 0)
            {
                String idIn = dtLastCar.Rows[0].Field<String>("IDIn");
                String idOut = dtLastCar.Rows[0].Field<String>("IDOut");
                if (!idIn.Equals("") && !idOut.Equals(""))
                {
                    string lastCardId = dtLastCar.Rows[0].Field<string>("ID");
                    if (cardID.Equals(lastCardId))
                    {
                        DateTime timeEnd = dtLastCar.Rows[0].Field<DateTime>("TimeEnd");
                        if (Util.getMillisecondBetweenTwoDate(timeEnd, DateTime.Now) < 60000)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private string getPathFromSnapshot(AxVLCPlugin2 axVLCPlugin)
        {
            //return @"E:\WORK\GIT\ParkingManagement\ParkingMangement\bin\Debug\ParkingManagement\Images\20190807\33_20190807_200936_637008053763543873.jpg";
            float reduceSizePercent = 0.5f;
            int compressedQuality = 20;

            string path = Constant.getSharedImageFolder() + Constant.getCurrentDateString();
            Directory.CreateDirectory(path);
            Util.ShareFolder(path, "Test Share", "This is a Test Share");
            Directory.SetCurrentDirectory(path);
            try
            {
                axVLCPlugin.video.takeSnapshot();
            } catch (Exception e)
            {

            }
            string originalFileName = Util.NewestFileofDirectory(path);


            //if (isCarIn())
            //{
            //Bitmap bmpScreenshot = getBitMapFromCamera(axVLCPlugin);
            //pictureBox.Image = bmpScreenshot;
            //zoomImageShowToPictureBox(originalFileName, pictureBox);
            //}


            //string compressedFileName = cardID + DateTime.Now.ToString("_yyyyMMdd_HHmmss_") + DateTime.Now.Ticks + ".jpg";
            //FileStream stream = new FileStream(originalFileName, FileMode.Open, FileAccess.Read);
            //System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            //System.Drawing.Image resizeImage = Util.Resize(img, reduceSizePercent);
            //string destImagePath = path + @"\" + compressedFileName;
            //Util.SaveJpeg(destImagePath, img, compressedQuality);
            //img.Dispose();
            //stream.Dispose();
            //File.Delete(originalFileName);
            //return Constant.getCurrentDateString() + @"\" + compressedFileName;
            return Constant.getCurrentDateString() + @"\" + originalFileName;
        }

        private void deleteOldImages()
        {
            string path = Constant.getSharedImageFolder() + Constant.getDateOnLastMonthString();
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

        private void zoomImageShowToPictureBox(string filePath, PictureBox pictureBox)
        {
            float zoomImageRatio = 0.5f;
            if (pictureBox == pictureBoxImage1)
            {
                zoomImageRatio = (float)Util.getConfigFile().ZoomCamera1 / 100;
            }
            else if (pictureBox == pictureBoxImage2)
            {
                zoomImageRatio = (float)Util.getConfigFile().ZoomCamera2 / 100;
            }
            else if (pictureBox == pictureBoxImage3)
            {
                zoomImageRatio = (float)Util.getConfigFile().ZoomCamera3 / 100;
            }
            else if (pictureBox == pictureBoxImage4)
            {
                zoomImageRatio = (float)Util.getConfigFile().ZoomCamera4 / 100;
            }
            zoomImageRatio = 1 - zoomImageRatio * 1.5f;

            //FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            //System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            if (pictureBox != null)
            {
                System.Drawing.Image image = pictureBox.Image;
                System.Drawing.Image img = System.Drawing.Image.FromFile(filePath);
                //pictureBox.Image = Util.ResizeImage(img, zoomImageRatio);
                pictureBox.Image = img;
                if (image != null)
                {
                    image.Dispose();
                }
            }
            //stream.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void resetPictureBoxImage1()
        {
            PictureBox pictureBox = pictureBoxImage1;
            int inOutType = Util.getConfigFile().inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                pictureBox = pictureBoxImage3;
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (inputIsOutside())
                {
                    pictureBox = pictureBoxImage3;
                }
            }

            if (isCarIn())
            {
                pictureBox.Image = Properties.Resources.ic_logo;
            }
        }

        private void resetPictureBoxImage2()
        {
            PictureBox pictureBox = pictureBoxImage2;
            int inOutType = Util.getConfigFile().inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                pictureBox = pictureBoxImage4;
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (inputIsOutside())
                {
                    pictureBox = pictureBoxImage4;
                }
            }

            if (isCarIn())
            {
                pictureBox.Image = Properties.Resources.ic_logo;
            }
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
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (inputIsOutside())
                {
                    axVLCPlugin = axVLCPlugin3;
                    pictureBox = pictureBoxImage3;
                }
            }

            if (isCarIn())
            {
                Bitmap bmpScreenshot = getBitMapFromCamera(axVLCPlugin);
                pictureBox.Image = bmpScreenshot;
                imagePath1 = getPathFromSnapshot(axVLCPlugin);
            }
        }

        private void loadImage1ToPictureBox()
        {
            AxVLCPlugin2 axVLCPlugin = axVLCPlugin1;
            PictureBox pictureBox = pictureBoxImage1;
            int inOutType = Util.getConfigFile().inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                axVLCPlugin = axVLCPlugin3;
                pictureBox = pictureBoxImage3;
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (inputIsOutside())
                {
                    axVLCPlugin = axVLCPlugin3;
                    pictureBox = pictureBoxImage3;
                }
            }

            if (isCarIn())
            {
                Bitmap bmpScreenshot = getBitMapFromCamera(axVLCPlugin);
                pictureBox.Image = bmpScreenshot;
            }
        }

        private void loadCamera2VLC()
        {
            String rtspString = cameraUrl2;
            axVLCPlugin2.playlist.add(rtspString);
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
                if (inputIsOutside())
                {
                    axVLCPlugin = axVLCPlugin4;
                    pictureBox = pictureBoxImage4;
                }
            }

            if (isCarIn())
            {
                imagePath2 = getPathFromSnapshot(axVLCPlugin);
            }
        }

        private void loadImage2ToPictureBox()
        {
            AxVLCPlugin2 axVLCPlugin = axVLCPlugin2;
            PictureBox pictureBox = pictureBoxImage2;
            int inOutType = Util.getConfigFile().inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                axVLCPlugin = axVLCPlugin4;
                pictureBox = pictureBoxImage4;
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (inputIsOutside())
                {
                    axVLCPlugin = axVLCPlugin4;
                    pictureBox = pictureBoxImage4;
                }
            }

            if (isCarIn())
            {
                Bitmap bmpScreenshot = getBitMapFromCamera(axVLCPlugin);
                pictureBox.Image = bmpScreenshot;
            }
        }

        private void loadCamera3VLC()
        {
            String rtspString = cameraUrl3;
            axVLCPlugin3.playlist.add(rtspString);
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
                if (inputIsInside())
                {
                    axVLCPlugin = axVLCPlugin1;
                }
            }
            imagePath3 = getPathFromSnapshot(axVLCPlugin);
        }

        private void loadCamera4VLC()
        {
            String rtspString = cameraUrl4;
            axVLCPlugin4.playlist.add(rtspString);
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
                if (inputIsInside())
                {
                    axVLCPlugin = axVLCPlugin2;
                }
            }
            imagePath4 = getPathFromSnapshot(axVLCPlugin);
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
            portNameComReceiveIn = Util.getConfigFile().comReceiveIn;
            portNameComReceiveOut = Util.getConfigFile().comReceiveOut;
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

        public void configVLC(int value1, int value2, int value3, int value4)
        {
            float zoomValue1 = (float) value1 / 100;
            float zoomValue2 = (float) value2 / 100;
            float zoomValue3 = (float) value3 / 100;
            float zoomValue4 = (float) value4 / 100;
            axVLCPlugin1.video.aspectRatio = "209:253";
            axVLCPlugin2.video.aspectRatio = "209:253";
            axVLCPlugin3.video.aspectRatio = "209:253";
            axVLCPlugin4.video.aspectRatio = "209:253";

            //axVLCPlugin1.video.scale = 0.7f;
            //axVLCPlugin2.video.scale = 0.7f;
            //axVLCPlugin3.video.scale = 0.7f;
            //axVLCPlugin4.video.scale = 0.7f;
            axVLCPlugin1.video.scale = zoomValue1;
            axVLCPlugin2.video.scale = zoomValue2;
            axVLCPlugin3.video.scale = zoomValue3;
            axVLCPlugin4.video.scale = zoomValue4;

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
                rfidInput = e.KeyPressEvent.DeviceName;
            } else
            {
                rfidInput = "";
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
                    if (inputIsOutside())
                    {
                        return false;
                    }
                    return true;
                case ConfigDTO.TYPE_OUT_IN:
                    if (inputIsOutside())
                    {
                        return true;
                    }
                    return false;
                default:
                    if (inputIsOutside())
                    {
                        return false;
                    }
                    return true;
            }
        }

        private int tinhTienGiuXe(DataTable dtLastCar)
        {
            int parkingTypeID = ConfigDAO.GetParkingTypeID();
            switch (parkingTypeID)
            {
                case Constant.LOAI_GIU_XE_MIEN_PHI:
                    return 0;
                case Constant.LOAI_GIU_XE_THEO_CONG_VAN:
                    return tinhGiaTienTheoCongVan(dtLastCar);
                case Constant.LOAI_GIU_XE_LUY_TIEN:
                    return tinhGiaTienLuyTien(dtLastCar);
                case Constant.LOAI_GIU_XE_TONG_HOP:
                    return tinhGiaTienTongHop(dtLastCar);
                default:
                    return tinhGiaTienTheoCongVan(dtLastCar);
            }
        }

        private int tinhGiaTienTheoCongVan(DataTable dtLastCar)
        {
            string partID = CardDAO.getPartIDByCardID(cardID);
            ComputerDTO computerDTO = ComputerDAO.GetDataByPartIDAndParkingTypeID(partID, Constant.LOAI_GIU_XE_THEO_CONG_VAN);
            double limit = (double)computerDTO.Limit / 60; // (hour)
            if (dtLastCar != null)
            {
                DateTime timeIn = dtLastCar.Rows[0].Field<DateTime>("TimeStart");
                DateTime timeOut = DateTime.Now;
                double spentTimeByMinute = Util.getTotalTimeByMinute(timeIn, timeOut);
                if (spentTimeByMinute <= 1)
                {
                    return 0;
                }
                if (spentTimeByMinute <= computerDTO.MinMinute)
                {
                    return computerDTO.MinCost;
                } else if (timeIn.Hour >= computerDTO.EndHourNight && timeOut.Hour < computerDTO.StartHourNight && timeIn.DayOfYear == timeOut.DayOfYear)
                {
                    // vào ngày - ra ngày
                    return computerDTO.DayCost;
                } else if (timeIn.Hour >= computerDTO.StartHourNight && timeOut.Hour < computerDTO.EndHourNight && timeOut.Date.Day - timeIn.Date.Day <= 1)
                {
                    // vào đêm - ra đêm
                    return computerDTO.NightCost;
                } else if (IsCarInDayOutNightOneDate(timeIn, timeOut, computerDTO) || isCarInNightOutDayOneDate(timeIn, timeOut, computerDTO))
                {
                    // vào ngày - ra đêm hoặc vào đêm - ra ngày trong 1 ngày
                    if (Util.getTotalTimeByHour(timeIn, timeOut) <= computerDTO.IntervalBetweenDayNight)
                    {
                        // thời gian trong bãi nhỏ hơn khoảng giao ngày - đêm
                        if (getTotalHourOfDay(timeIn, timeOut, computerDTO) >= getTotalHourOfNight(timeIn, timeOut, computerDTO))
                        {
                            // thời gian ngày lớn hơn đêm
                            if (getTotalHourOfDay(timeIn, timeOut, computerDTO) <= limit)
                            {
                                // thời gian ngày nhỏ hơn giới hạn
                                return computerDTO.DayCost;
                            } else
                            {
                                // thời gian ngày lớn hơn giới hạn
                                return computerDTO.NightCost;
                            }
                        } else
                        {
                            // thời gian ngày nhỏ hơn đêm
                            return computerDTO.NightCost;
                        }
                    } else
                    {
                        // thời gian trong bãi lớn hơn khoảng giao ngày - đêm
                        return computerDTO.DayNightCost;
                    }
                } else
                {
                    // vào - ra trong nhiều ngày
                    if (isCarInDayOutDay(timeIn, timeOut, computerDTO))
                    {
                        // vào ngày - ra ngày
                        if (getTotalHourOfDayWhenOutDay(timeOut, computerDTO) <= limit)
                        {
                            // thời gian ngày nhỏ hơn giới hạn
                            return soLuotQuaNgay(timeIn, timeOut, computerDTO) * computerDTO.DayNightCost;
                        } else
                        {
                            // thời gian ngày lớn hơn giới hạn
                            return soLuotQuaNgay(timeIn, timeOut, computerDTO) * computerDTO.DayNightCost + computerDTO.DayCost;
                        }
                    } else if (isCarInNightOutNight(timeIn, timeOut, computerDTO))
                    {
                        // vào đêm - ra đêm
                        return soLuotQuaNgay(timeIn, timeOut, computerDTO) * computerDTO.DayNightCost + computerDTO.NightCost;
                    } else
                    {
                        // vào ngày - ra đêm hoặc vào đêm - ra ngày
                        return (soLuotQuaNgay(timeIn, timeOut, computerDTO) + 1) * computerDTO.DayNightCost;
                    }
                }
            }
            return 0;
        }

        private int tinhGiaTienLuyTien(DataTable dtLastCar)
        {
            string partID = CardDAO.getPartIDByCardID(cardID);
            ComputerDTO computerDTO = ComputerDAO.GetDataByPartIDAndParkingTypeID(partID, Constant.LOAI_GIU_XE_LUY_TIEN);
            if (dtLastCar != null)
            {
                DateTime timeIn = dtLastCar.Rows[0].Field<DateTime>("TimeStart");
                DateTime timeOut = DateTime.Now;
                double spentTimeByMinute = Util.getTotalTimeByMinute(timeIn, timeOut);
                double spentTimeByHour = Util.getTotalTimeByHour(timeIn, timeOut);
                if (spentTimeByMinute <= 1)
                {
                    return 0;
                }
                if (spentTimeByHour <= computerDTO.HourMilestone1)
                {
                    return computerDTO.CostMilestone1;
                } else if (spentTimeByHour > computerDTO.HourMilestone1 && spentTimeByHour <= computerDTO.HourMilestone1 + computerDTO.HourMilestone2)
                {
                    return computerDTO.CostMilestone1 + computerDTO.CostMilestone2;
                } else
                {
                    if (computerDTO.IsAdd.Equals(Constant.TINH_TIEN_LUY_TIEN_KHONG_CONG))
                    {
                        int temp1 = (int)spentTimeByHour / computerDTO.CycleMilestone3;
                        //int temp2 = (int)spentTimeByHour % computerDTO.CycleMilestone3;
                        int cost = temp1 * computerDTO.CostMilestone3;
                        return cost;
                    }
                    else if (computerDTO.IsAdd.Equals(Constant.TINH_TIEN_LUY_TIEN_CONG_1_MOC))
                    {
                        int temp1 = ((int)spentTimeByHour - computerDTO.HourMilestone1) / computerDTO.CycleMilestone3;
                        //int temp2 = ((int)spentTimeByHour - computerDTO.HourMilestone1) % computerDTO.CycleMilestone3;
                        int cost = computerDTO.CostMilestone1 + temp1 * computerDTO.CostMilestone3;
                        return cost;
                    }
                    else if (computerDTO.IsAdd.Equals(Constant.TINH_TIEN_LUY_TIEN_CONG_2_MOC))
                    {
                        int temp1 = ((int)spentTimeByHour - computerDTO.HourMilestone1 - computerDTO.HourMilestone2) / computerDTO.CycleMilestone3;
                        //int temp2 = ((int)spentTimeByHour - computerDTO.HourMilestone1) % computerDTO.CycleMilestone3;
                        int cost = computerDTO.CostMilestone1 + computerDTO.CostMilestone2 + temp1 * computerDTO.CostMilestone3;
                        return cost;
                    }
                }
            }
            return 0;
        }

        private int tinhGiaTienTongHop(DataTable dtLastCar)
        {
            string partID = CardDAO.getPartIDByCardID(cardID);
            ComputerDTO computerDTO = ComputerDAO.GetDataByPartIDAndParkingTypeID(partID, Constant.LOAI_GIU_XE_TONG_HOP);
            if (dtLastCar != null)
            {
                DateTime timeIn = dtLastCar.Rows[0].Field<DateTime>("TimeStart");
                DateTime timeOut = DateTime.Now;
                double spentTimeByMinute = Util.getTotalTimeByMinute(timeIn, timeOut);
                double spentTimeByHour = Util.getTotalTimeByHour(timeIn, timeOut);
                if (spentTimeByMinute <= 1)
                {
                    return 0;
                }
                if (spentTimeByHour <= computerDTO.HourMilestone1)
                {
                    return computerDTO.CostMilestone1;
                }
                else if (spentTimeByHour > computerDTO.HourMilestone1 && spentTimeByHour <= computerDTO.HourMilestone2)
                {
                    return computerDTO.CostMilestone2;
                }
                else
                {
                    if (computerDTO.IsAdd.Equals(Constant.TINH_TIEN_LUY_TIEN_KHONG_CONG))
                    {
                        int temp1 = (int)spentTimeByHour / computerDTO.CycleMilestone3;
                        //int temp2 = (int)spentTimeByHour % computerDTO.CycleMilestone3;
                        int cost = temp1 * computerDTO.CostMilestone3;
                        return cost;
                    }
                    else if (computerDTO.IsAdd.Equals(Constant.TINH_TIEN_LUY_TIEN_CONG_1_MOC))
                    {
                        int temp1 = ((int) spentTimeByHour - computerDTO.HourMilestone1) / computerDTO.CycleMilestone3;
                        //int temp2 = ((int) spentTimeByHour - computerDTO.HourMilestone1) % computerDTO.CycleMilestone3;
                        int cost = computerDTO.CostMilestone1 + temp1 * computerDTO.CostMilestone3;
                        return cost;
                    }
                    else if (computerDTO.IsAdd.Equals(Constant.TINH_TIEN_LUY_TIEN_CONG_2_MOC))
                    {
                        int temp1 = ((int)spentTimeByHour - computerDTO.HourMilestone1 - computerDTO.HourMilestone2) / computerDTO.CycleMilestone3;
                        //int temp2 = ((int)spentTimeByHour - computerDTO.HourMilestone1) % computerDTO.CycleMilestone3;
                        int cost = computerDTO.CostMilestone1 + computerDTO.CostMilestone2 + temp1 * computerDTO.CostMilestone3;
                        return cost;
                    }
                }
            }
            return 0;
        }

        private bool isCarInDayOutDay(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO)
        {
            return (timeIn.Hour >= computerDTO.EndHourNight && timeIn.Hour < computerDTO.StartHourNight) && (timeOut.Hour >= computerDTO.EndHourNight && timeOut.Hour < computerDTO.StartHourNight);
        }

        private bool isCarInNightOutNight(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO)
        {
            return (timeIn.Hour >= computerDTO.StartHourNight || timeIn.Hour < computerDTO.EndHourNight) && (timeOut.Hour >= computerDTO.StartHourNight || timeOut.Hour < computerDTO.EndHourNight);
        }

        private bool IsCarInDayOutNightOneDate(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO)
        {
            return (timeIn.Hour >= computerDTO.EndHourNight && timeIn.Hour < computerDTO.StartHourNight) && 
                ((timeOut.Hour >= computerDTO.StartHourNight && timeOut.Date.Day == timeIn.Date.Day) || (timeOut.Hour < computerDTO.EndHourNight && timeOut.Date.Day - timeIn.Date.Day == 1));
        }

        private bool isCarInNightOutDayOneDate(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO)
        {
            return (timeOut.Hour >= computerDTO.EndHourNight && timeOut.Hour < computerDTO.StartHourNight) && 
                ((timeIn.Hour >= computerDTO.StartHourNight && timeOut.Date.Day - timeIn.Date.Day == 1) || (timeIn.Hour < computerDTO.EndHourNight && timeOut.Date.Day == timeIn.Date.Day));
        }

        private double getTotalHourOfDay(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO)
        {
            if (IsCarInDayOutNightOneDate(timeIn, timeOut, computerDTO))
            {
                return computerDTO.StartHourNight - timeIn.Hour - (double) timeIn.Minute / 60; 
            } else
            {
                return timeOut.Hour + (double) timeOut.Minute / 60 - computerDTO.EndHourNight;
            }
        }

        private double getTotalHourOfDayWhenOutDay(DateTime timeOut, ComputerDTO computerDTO)
        {
            double value = timeOut.Hour + (double) timeOut.Minute / 60 - computerDTO.EndHourNight;
            return value;
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
            int dayDistant = Util.getTotalTimeByDay(timeIn, timeOut);
            if (computerDTO.IntervalBetweenDayNight == 0)
            {
                computerDTO.IntervalBetweenDayNight = 1;
            }
            int countOfCircle = (int) Util.getTotalTimeByHour(timeIn, timeOut) / computerDTO.IntervalBetweenDayNight;
            return countOfCircle - dayDistant;
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

            resetData(true);
        }

        private void resetData(bool isResetImage)
        {
            oldUhfCardId = null;
            labelMaThe.Text = "";
            labelMoiVao.Text = "";
            labelMoiRa.Text = "";
            labelCardID.Text = "-";
            labelPartNameTypeName.Text = "-";
            labelCustomerName.Text = "-";
            labelCostIn.Text = "-";
            labelCostOut.Text = "-";
            labelDateIn.Text = "-";
            labelTimeIn.Text = "-";
            labelDateOut.Text = "-";
            labelTimeOut.Text = "-";
            if (isResetImage)
            {
                pictureBoxImage1.Image = Properties.Resources.ic_logo;
                pictureBoxImage2.Image = Properties.Resources.ic_logo;
                pictureBoxImage3.Image = Properties.Resources.ic_logo;
                pictureBoxImage4.Image = Properties.Resources.ic_logo;
            }
            labelDigitIn.Text = "";
            labelDigitOut.Text = "-";
            labelDigitRegister.Text = "-";
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
                    if (!inputIsInside() && !inputIsOutside())
                    {
                        updateDigitCarIn();
                        tbRFIDCardID.Focus();
                        tbRFIDCardID.Text = "";
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
                    cardID = tbRFIDCardID.Text.Trim();
                    labelCardID.Text = CardDAO.getIdentifyByCardID(cardID) + "";
                    tbRFIDCardID.Text = "";
                    if (!cardID.Equals(""))
                    {
                        saveImage();
                    }
                    oldUhfCardId = null;
                    break;
            }
        }

        private void labelDigitIn_Leave(object sender, EventArgs e)
        {
            tbRFIDCardID.Focus();
            tbRFIDCardID.Text = "";
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
            int count = 0;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Visible == true)//will not count hidden forms
                    count++;
            }
            if (count == 1)
            {
                Application.Exit();
            }
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

        private void updateThongKeXeTrongBaiByTimer()
        {
            dgvThongKeXeTrongBai.DataSource = CarDAO.GetListCarSurvive();
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 10 * 1000;
            aTimer.Enabled = true;
            aTimer.Start();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Invoke(new MethodInvoker(() => { dgvThongKeXeTrongBai.DataSource = CarDAO.GetListCarSurvive(); }));
        }

        //private void updateDataToServerByTimer()
        //{
        //    System.Timers.Timer aTimer = new System.Timers.Timer();
        //    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventUpdateDataToServer);
        //    aTimer.Interval = 1 * 20 * 1000;
        //    aTimer.Enabled = true;
        //    aTimer.Start();
        //}

        //private void updateOrderToSever()
        //{
        //    if (!mIsHasCarInOut)
        //    {
        //        new Thread(() =>
        //        {
        //            Thread.CurrentThread.IsBackground = true;
        //            Program.updateOrderToSever();
        //        }).Start();
        //    }
        //    mIsHasCarInOut = false;
        //}

        //private void OnTimedEventUpdateDataToServer(object source, ElapsedEventArgs e)
        //{
        //    if (!mIsHasCarInOut)
        //    {
        //        new Thread(() =>
        //        {
        //            Thread.CurrentThread.IsBackground = true;
        //            Program.updateOrderToSever();
        //        }).Start();
        //    }
        //    mIsHasCarInOut = false;
        //}

        private void changeInOutSetting(bool isLeftSide)
        {
            int inOutType = Util.getConfigFile().inOutType;
            int newInOutType = ConfigDTO.TYPE_IN_OUT;
            if (isLeftSide)
            {
                switch (inOutType)
                {
                    case ConfigDTO.TYPE_IN_IN:
                        newInOutType = ConfigDTO.TYPE_OUT_IN;
                        break;
                    case ConfigDTO.TYPE_OUT_OUT:
                        newInOutType = ConfigDTO.TYPE_IN_OUT;
                        break;
                    case ConfigDTO.TYPE_IN_OUT:
                        newInOutType = ConfigDTO.TYPE_OUT_OUT;
                        break;
                    case ConfigDTO.TYPE_OUT_IN:
                        newInOutType = ConfigDTO.TYPE_IN_IN;
                        break;
                }
            }
            else
            {
                switch (inOutType)
                {
                    case ConfigDTO.TYPE_IN_IN:
                        newInOutType = ConfigDTO.TYPE_IN_OUT;
                        break;
                    case ConfigDTO.TYPE_OUT_OUT:
                        newInOutType = ConfigDTO.TYPE_OUT_IN;
                        break;
                    case ConfigDTO.TYPE_IN_OUT:
                        newInOutType = ConfigDTO.TYPE_IN_IN;
                        break;
                    case ConfigDTO.TYPE_OUT_IN:
                        newInOutType = ConfigDTO.TYPE_OUT_OUT;
                        break;
                }
            }
            FormInOutSetting.saveInOutTypeToConfig(newInOutType);
            updateCauHinhHienThiXeRaVao();
        }

        private void openBarie1()
        {
            string data = Util.getConfigFile().signalOpenBarieIn;
            string portName = Util.getConfigFile().comSend;
            writeDataToPort(data, portName);
            isClosedBarie1 = false;
        }

        private void openBarie2()
        {
            string data = Util.getConfigFile().signalOpenBarieOut;
            string portName = Util.getConfigFile().comSend;
            writeDataToPort(data, portName);
            isClosedBarie2 = false;
        }

        private void closeBarie1()
        {
            string data = Util.getConfigFile().signalCloseBarieIn;
            string portName = Util.getConfigFile().comSend;
            writeDataToPort(data, portName);
            isClosedBarie1 = true;
        }

        private void closeBarie2()
        {
            string data = Util.getConfigFile().signalCloseBarieOut;
            string portName = Util.getConfigFile().comSend;
            writeDataToPort(data, portName);
            isClosedBarie2 = true;
        }

        //SerialPort port;
        SerialPort port;
        private void writeDataToPort(string data, string portName)
        {
            try
            {
                if (port == null || !port.IsOpen)
                {
                    port = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
                }
                
                if (!port.IsOpen)
                {
                    port.Open();
                }
                //port.WriteTimeout = 500;
                //port.BaudRate = 9600;
                //port.Parity = Parity.None;
                //port.DataBits = 8;
                //port.StopBits = StopBits.One;
                port.Write(data);
                //port.Close();
                Console.WriteLine(data);
            } catch (Exception e)
            {
                Console.WriteLine("bug: " + e.Message);
            }
        }

        private void getDataFromComReceive()
        {
            try
            {
                portComReceiveIn = new SerialPort(portNameComReceiveIn, 9600, Parity.None, 8, StopBits.One);
                portComReceiveIn.DataReceived += new SerialDataReceivedEventHandler(portComReceiveIn_DataReceived);
                portComReceiveIn.Open();
            } catch (Exception e)
            {

            }
            try
            {
                portComReceiveOut = new SerialPort(portNameComReceiveOut, 57600, Parity.None, 8, StopBits.One);
                portComReceiveOut.DataReceived += new SerialDataReceivedEventHandler(portComReceiveOut_DataReceived);
                portComReceiveOut.Open();
            }
            catch (Exception e)
            {

            }
        }

        private void portComReceiveIn_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //portNameComReceiveInput = portNameComReceiveIn;
            //cardID = portComReceiveIn.ReadExisting();
            //if (!cardID.Equals(""))
            //{
            //    saveImage();
            //}
        }

        private void portComReceiveOut_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //portNameComReceiveInput = portNameComReceiveOut;
            //cardID = portComReceiveOut.ReadExisting();
            //if (!cardID.Equals(""))
            //{
            //    saveImage();
            //}
        }

        private bool inputIsOutside()
        {
            if (portNameComReceiveInput != null)
            {
                bool result = portNameComReceiveInput.Equals(portNameComReceiveOut);
                return result;
            }
            else
            {
                return rfidInput.Equals(rfidOut);
            }
        }

        private bool inputIsInside()
        {
            return !inputIsOutside();
        }

        private void FormNhanVien_Activated(object sender, EventArgs e)
        {
            tbRFIDCardID.Focus();
        }

        private void timerReadUHFData_Tick(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (ActiveForm == this)
            {
                timerReadUHFData.Enabled = false;
                handleUhfData();
                timerReadUHFData.Enabled = true;
            }
        }

        private void handleUhfData()
        {
            int frmcomportindexIn = UHFReader.getComportIndex(Util.getConfigFile().comReceiveIn);
            int frmcomportindexOut = UHFReader.getComportIndex(Util.getConfigFile().comReceiveOut);
            string uhfInCardId = UHFReader.GetUHFData(frmcomportindexIn);
            string newUhfCardId = null;

            if (uhfInCardId != null)
            {
                portNameComReceiveInput = portNameComReceiveIn;
                newUhfCardId = uhfInCardId;
            }
            else
            {
                string uhfOutCardId = UHFReader.GetUHFData(frmcomportindexOut);
                if (uhfOutCardId != null)
                {
                    portNameComReceiveInput = portNameComReceiveOut;
                    newUhfCardId = uhfOutCardId;
                }
            }

            if (newUhfCardId != null)
            {
                labelMaThe.Text = newUhfCardId;
                if (!newUhfCardId.Equals(oldUhfCardId))
                {
                    cardID = newUhfCardId;
                    oldUhfCardId = newUhfCardId;
                    //labelMaThe.Text = cardID;
                    saveImage();
                }
            }
        }

        private void initUhfTimer()
        {
            timerReadUHFData.Enabled = true;
        }

        private void FormNhanVien_Shown(object sender, EventArgs e)
        {
            tbRFIDCardID.Focus();
        }
    }
}

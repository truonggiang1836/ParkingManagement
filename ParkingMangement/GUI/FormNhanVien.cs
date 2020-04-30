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

using System.Timers;
using ReaderB;
using RTSPcamera;

namespace ParkingMangement.GUI
{
    public partial class FormNhanVien : Form
    {
        public readonly RawInput _rawinput;

        public string CurrentUserID;
        const bool CaptureOnlyInForeground = true;
        private string cardID = "0";
        private string oldUhfCardId = null;
        private DateTime oldUhfCardTime;
        private string rfidInput = "";
        private string portNameComReceiveInput = null;
        private string oldPortNameComReceiveInput = "";

        //const string cameraUrl = @"rtsp://admin:bmv333999@192.168.1.190:554/cam/realmonitor?channel=1&subtype=0&unicast=true&proto=Onvif";
        const string cameraUrl = @"rtsp://184.72.239.149/vod/mp4:BigBuckBunny_175k.mov";
        private string cameraUrl1 = cameraUrl;
        private string cameraUrl2 = cameraUrl;
        private string cameraUrl3 = cameraUrl;
        private string cameraUrl4 = cameraUrl;

        private CameraCapture cameraCapture1;
        private CameraCapture cameraCapture2;
        private CameraCapture cameraCapture3;
        private CameraCapture cameraCapture4;

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

        SerialPort leftLedPort;
        SerialPort rightLedPort;
        SerialPort lostAvailablePort;

        private Config mConfig;

        private Size oldSize;

        //private bool mIsHasCarInOut = false;

        private int _lastFormSize;

        public FormNhanVien()
        {
            InitializeComponent();
            _lastFormSize = GetFormArea(this.Size);
            //CvInvoke.UseOpenCL = false;
            Control.CheckForIllegalCrossThreadCalls = false;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            _rawinput = new RawInput(Handle, CaptureOnlyInForeground);

            //_rawinput.AddMessageFilter();   // Adding a message filter will cause keypresses to be handled
            //Win32.DeviceAudit();            // Writes a file DeviceAudit.txt to the current directory

            _rawinput.KeyPressed += OnKeyPressed;   
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
            //Network = new clsNetwork();
            //Network.AutoLoadNetworkChar();
            //Network.AutoLoadNetworkNum();
            oldSize = base.Size;
            mConfig = Util.getConfigFile();
            CurrentUserID = Program.CurrentUserID;
            this.BackColor = ColorTranslator.FromHtml("#2e2925");
            this.ActiveControl = tbRFIDCardID;
            pictureBoxDigitIn.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            pictureBoxDigitOut.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            pictureBoxDigitRegister.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            pictureBoxCardID.BackColor = ColorTranslator.FromHtml("#fcfdfc");

            labelGetCardLeft.BackColor = ColorTranslator.FromHtml("#51b749");
            labelDateInLeft.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelDateOutLeft.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelTimeInLeft.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelTimeOutLeft.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelDigitInLeft.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelDigitOutLeft.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelDigitRegisterLeft.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelCustomerNameLeft.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelCardIDLeft.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelPartNameTypeNameLeft.BackColor = ColorTranslator.FromHtml("#fcfdfc");

            labelGetCardRight.BackColor = ColorTranslator.FromHtml("#51b749");
            labelDateInRight.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelDateOutRight.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelTimeInRight.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelTimeOutRight.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelDigitInRight.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelDigitOutRight.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelDigitRegisterRight.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelCustomerNameRight.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelCardIDRight.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            labelPartNameTypeNameRight.BackColor = ColorTranslator.FromHtml("#fcfdfc");

            labelCostLeft.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            //labelCostIn.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelCostRight.BackColor = ColorTranslator.FromHtml("#fcfdfc");
            //labelCostOut.ForeColor = ColorTranslator.FromHtml("#cf9f51");


            labelDigitInHeaderLeft.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelDigitOutHeaderLeft.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelDigitRegisterHeaderLeft.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelCardIDHeaderLeft.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelPartNameTypeNameHeaderLeft.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelCustomerNameHeaderLeft.BackColor = ColorTranslator.FromHtml("#2e2925");
            //labelVND_HeaderLeft.BackColor = ColorTranslator.FromHtml("#2e2925");

            labelDigitInHeaderLeft.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelDigitOutHeaderLeft.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelDigitRegisterHeaderLeft.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelCardIDHeaderLeft.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelPartNameTypeNameHeaderLeft.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelCustomerNameHeaderLeft.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            //labelVND_HeaderLeft.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelDateInHeaderLeft.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelDateOutHeaderLeft.ForeColor = ColorTranslator.FromHtml("#cf9f51");


            labelDigitInHeaderRight.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelDigitOutHeaderRight.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelDigitRegisterHeaderRight.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelCardIDHeaderRight.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelPartNameTypeNameHeaderRight.BackColor = ColorTranslator.FromHtml("#2e2925");
            labelCustomerNameHeaderRight.BackColor = ColorTranslator.FromHtml("#2e2925");
            //labelVND_HeaderRight.BackColor = ColorTranslator.FromHtml("#2e2925");

            labelDigitInHeaderRight.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelDigitOutHeaderRight.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelDigitRegisterHeaderRight.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelCardIDHeaderRight.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelPartNameTypeNameHeaderRight.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelCustomerNameHeaderRight.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            //labelVND_HeaderRight.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelDateInHeaderRight.ForeColor = ColorTranslator.FromHtml("#cf9f51");
            labelDateOutHeaderRight.ForeColor = ColorTranslator.FromHtml("#cf9f51");

            dgvThongKeXeTrongBai.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#d09f52");
            dgvThongKeXeTrongBai.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff");
            dgvThongKeXeTrongBai.EnableHeadersVisualStyles = false;
            dgvThongKeXeTrongBai.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 6.75F, FontStyle.Bold);
            labelComputer.Text = mConfig.computerName;
            labelParkingName.Text = ConfigDAO.GetParkingName();

            labelNhanVien.Text = UserDAO.GetUserNameByID(Program.CurrentUserID);

            if (mConfig.isUsingUhf.Equals("yes"))
            {
                initUhfTimer();
            }

            updateThongKeXeTrongBaiByTimer();
            readConfigFile();

            loadInfo();
            //loadCameraCapture();
            configVLC(mConfig.ZoomCamera1, mConfig.ZoomCamera2,
                mConfig.ZoomCamera3, mConfig.ZoomCamera4);
            //loadCamera1VLC();
            //loadCamera2VLC();
            //loadCamera2VLC();
            //loadCamera3VLC();
            //loadCamera4VLC();

            getDataFromComReceive();

            

            //CheckForIllegalCrossThreadCalls = false;
            //loadEmguCvCamera1();
            //loadEmguCvCamera2();
            //loadEmguCvCamera3();
            //loadEmguCvCamera4();
            //imageBox1.Visible = false;
            //imageBox2.Visible = false;
            //imageBox3.Visible = false;
            //imageBox4.Visible = false;

            runPythonServer();
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
                case Keys.Escape:
                    resetForm();
                    break;
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
                        resetAllData();
                    }
                    else
                    {
                        if (!labelDigitInLeft.Focused && !labelDigitInRight.Focused)
                        {
                            if (!tbRFIDCardID.Text.Equals(""))
                            {
                                resetDataOneSide(false);
                            }
                            else
                            {
                                resetAllData();
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
                    openBarieInCar();
                    AutoClosingMessageBox.Show("Barie đã mở", "", 500);
                    //MessageBox.Show("Barie đã mở");
                    break;
                case Keys.F9:
                    closeBarieIn();
                    AutoClosingMessageBox.Show("Barie đã đóng", "", 500);
                    //MessageBox.Show("Barie đã đóng");
                    break;
                case Keys.F10:
                    openBarieOutCar();
                    AutoClosingMessageBox.Show("Barie đã mở", "", 500);
                    //MessageBox.Show("Barie đã mở");
                    break;
                case Keys.F11:
                    //    var formLogout = new FormLogout();
                    //    formLogout.formNhanVien = this;
                    //    formLogout.Show();
                    //    break;
                    closeBarieOut();
                    AutoClosingMessageBox.Show("Barie đã đóng", "", 500);
                    //MessageBox.Show("Barie đã đóng");
                    break;
                case Keys.Up:
                    openBarieInMotorbike();
                    AutoClosingMessageBox.Show("Barie đã mở", "", 500);
                    //MessageBox.Show("Barie đã mở");
                    break;
                case Keys.Down:
                    closeBarieInMotorbike();
                    AutoClosingMessageBox.Show("Barie đã đóng", "", 500);
                    //MessageBox.Show("Barie đã đóng");
                    break;
                case Keys.Left:
                    openBarieOutMotorbike();
                    AutoClosingMessageBox.Show("Barie đã mở", "", 500);
                    //MessageBox.Show("Barie đã mở");
                    break;
                case Keys.Right:
                    //    var formLogout = new FormLogout();
                    //    formLogout.formNhanVien = this;
                    //    formLogout.Show();
                    //    break;
                    closeBarieOutMotorbike();
                    AutoClosingMessageBox.Show("Barie đã đóng", "", 500);
                    //MessageBox.Show("Barie đã đóng");
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

        private void saveBitmapToFile(Bitmap bitmap, string filePath, string fileName)
        {
            //string path = Constant.LOCAL_IMAGE_FOLDER + fileName;
            //bitmap.Save(path, ImageFormat.Jpeg);
            //File.Move(path, sharedPath);
            string fileDir = filePath + fileName;
            Directory.CreateDirectory(filePath);
            bitmap.Save(fileDir, ImageFormat.Jpeg);
        }

        private void readCardEvent()
        {
            if (inputIsLeftSide())
            {
                labelCardIDLeft.Text = CardDAO.getIdentifyByCardID(cardID) + "";
            }
            else
            {
                labelCardIDRight.Text = CardDAO.getIdentifyByCardID(cardID) + "";
            }

            //deleteOldImages();
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
                            checkForSaveToDBAsync(true);
                        }
                        else
                        {
                            checkForSaveToDBAsync(false);
                        }
                    }
                    else
                    {
                        MessageBox.Show(Constant.sMessageCardIsLost);
                    }
                }
                else
                {
                    labelError.Text = Constant.sMessageCardIdNotExist;
                    //AutoClosingMessageBox.Show(Constant.sMessageCardIdNotExist, "", 1000);
                }
                Invoke(new MethodInvoker(() => {
                    dgvThongKeXeTrongBai.DataSource = CarDAO.GetListCarSurvive();
                }));
            }
            portNameComReceiveInput = null;
            oldPortNameComReceiveInput = null;
        }

        private void timerCurrentTime_Tick(object sender, EventArgs e)
        {
            //labelDateOut.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void checkForOpenBarie(DataTable dtLastCar, bool isUhfCard)
        {
            string cardType = CardDAO.GetCardTypeByID(cardID);
            if (!inputIsRightSide())
            {
                checkForOpenBarieIn(isUhfCard);
            }
            else
            {
                checkForOpenBarieOut(isUhfCard);
            }
        }

        private bool checkForSaveToDBAsync(bool isTicketCard)
        {
            DataTable dtLastCar = CarDAO.GetLastCarByID(cardID);
            //checkForOpenBarie(dtLastCar, true);

            if (inputIsLeftSide())
            {
                labelDigitInLeft.Text = "";
                labelDigitOutLeft.Text = "";
                labelDigitRegisterLeft.Text = "";
                labelCustomerNameLeft.Text = "-";

                labelPartNameTypeNameLeft.Text = CardDAO.GetPartName_TypeNameByCardID(cardID);
                if (isTicketCard)
                {
                    labelCustomerNameLeft.Text = TicketMonthDAO.GetCustomerNameByID(cardID);
                }
            }
            else
            {
                labelDigitInRight.Text = "";
                labelDigitOutRight.Text = "";
                labelDigitRegisterRight.Text = "";
                labelCustomerNameRight.Text = "-";

                labelPartNameTypeNameRight.Text = CardDAO.GetPartName_TypeNameByCardID(cardID);
                if (isTicketCard)
                {
                    labelCustomerNameRight.Text = TicketMonthDAO.GetCustomerNameByID(cardID);
                }
            }

            string inputDigit = "";
            if (!mConfig.readDigitFolder.Equals(""))
            {
                inputDigit = docBienSo();
            }

            bool isKiemTraXeChuaRa = KiemTraXeChuaRa(dtLastCar);
            bool isKiemTraCapNhatXeVao = KiemTraCapNhatXeVao(dtLastCar);
            bool isKiemTraCapNhatXeRa = KiemTraCapNhatXeRa(dtLastCar);
            if (isCarIn())
            {
                if (isKiemTraXeChuaRa)
                {
                    if (!isKiemTraCapNhatXeVao)
                    {
                        labelError.Text = "Thẻ này chưa được quẹt đầu ra";
                        resetPictureBoxImage1();
                        resetPictureBoxImage2();
                        tbRFIDCardID.Focus();
                        return false;
                    }
                }

                loadImage1ToPictureBox();
                loadImage2ToPictureBox();
                saveImage1ToFile();
                saveImage2ToFile();
                if (isKiemTraXeChuaRa)
                {
                    if (isKiemTraCapNhatXeVao)
                    {
                        updateCarIn(isTicketCard, dtLastCar, inputDigit);
                    }
                }
                else
                {
                    insertCarIn(isTicketCard, inputDigit);
                }
            }
            else
            {
                if (isKiemTraXeChuaRa || isKiemTraCapNhatXeRa)
                {
                    loadCarInData(dtLastCar);
                    updateCarOut(isTicketCard, dtLastCar, isKiemTraCapNhatXeRa, inputDigit);
                }
                else
                {
                    tbRFIDCardID.Focus();
                    labelError.Text = "Thẻ này chưa được quẹt đầu vào";
                    return false;
                }
            }
            bool isUhfCard = false;
            if (oldUhfCardId != null && !oldUhfCardId.Equals(""))
            {
                isUhfCard = true;
            }
            checkForOpenBarie(dtLastCar, isUhfCard);
            return true;
        }

        private void updateDigitCarIn(string digit)
        {
            //cardID = labelCardID.Text;
            if (!digit.Equals(""))
            {
                //saveImage1ToFile();
                //saveImage2ToFile();
                CarDAO.UpdateDigit(cardID, digit, imagePath1, imagePath2);
                labelDigitInRight.Text = "";
                //pictureBoxImage1.Image = Properties.Resources.ic_logo;
                //pictureBoxImage2.Image = Properties.Resources.ic_logo;
                //pictureBoxImage3.Image = Properties.Resources.ic_logo;
                //pictureBoxImage4.Image = Properties.Resources.ic_logo;
            }
            DataTable dtTicketCard = TicketMonthDAO.GetDataByID(cardID);
            if (dtTicketCard != null && dtTicketCard.Rows.Count > 0)
            {
                updateScreenForCarIn(true);
            }
            else
            {
                updateScreenForCarIn(false);
            }
        }

        private void checkForOpenBarieIn(bool isUhfCard)
        {
            string type = CardDAO.GetTypeByID(cardID);
            if (isUhfCard)
            {
                // truong hop quet the tam xa
                if (mConfig.inOutType == ConfigDTO.TYPE_IN_IN || mConfig.inOutType == ConfigDTO.TYPE_OUT_OUT)
                {
                    // lan vao - vao hoac ra - ra thi mo ca 2 barie
                    openBarieOutCar();
                    openBarieInCar();
                }
                else
                {
                    openBarieInCar();
                }
            }
            else
            {
                // truong hop quet the thuong
                if (type == TypeDTO.TYPE_CAR)
                {
                    // truong hop xe oto
                    if (!mConfig.signalOpenBarieIn.Equals(""))
                    {
                        DialogResult dialogResult = MessageBox.Show("Bạn có đồng ý mở barie?", "Mở barie", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            openBarieInCar();
                        }
                    }
                }
                else
                {
                    // truong hop xe may
                    if (!mConfig.signalOpenBarieInMotorbike.Equals(""))
                    {
                        DialogResult dialogResult = MessageBox.Show("Bạn có đồng ý mở barie?", "Mở barie", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            openBarieInMotorbike();
                        }
                    }
                }
            }
        }

        private void checkForOpenBarieOut(bool isUhfCard)
        {
            string type = CardDAO.GetTypeByID(cardID);
            if (isUhfCard)
            {
                // truong hop quet the tam xa
                if (mConfig.inOutType == ConfigDTO.TYPE_IN_IN || mConfig.inOutType == ConfigDTO.TYPE_OUT_OUT)
                {
                    // lan vao - vao hoac ra - ra thi mo ca 2 barie
                    openBarieOutCar();
                    openBarieInCar();
                }
                else
                {
                    openBarieOutCar();
                }
            }
            else
            {
                // truong hop quet the thuong
                if (type == TypeDTO.TYPE_CAR)
                {
                    // truong hop xe oto
                    if (!mConfig.signalOpenBarieOut.Equals(""))
                    {
                        DialogResult dialogResult = MessageBox.Show("Bạn có đồng ý mở barie?", "Mở barie", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            openBarieOutCar();
                        }
                    }
                }
                else
                {
                    // truong hop xe may
                    if (!mConfig.signalOpenBarieOutMotorbike.Equals(""))
                    {
                        DialogResult dialogResult = MessageBox.Show("Bạn có đồng ý mở barie?", "Mở barie", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            openBarieOutMotorbike();
                        }
                    }
                }
            }
        }

        private void insertCarIn(bool isTicketMonthCard, string inputDigit)
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
            if (!inputDigit.Equals(""))
            {
                carDTO.DigitIn = inputDigit;
            }

            if (isTicketMonthCard)
            {
                carDTO.IdTicketMonth = cardID;
                carDTO.Digit = TicketMonthDAO.GetDigitByID(cardID);
            }

            //insertCarInAPI(cardID);
            CarDAO.Insert(carDTO);
            WaitSyncCarInDAO.Insert(CarDAO.GetLastIdentifyByID(cardID));

            updateScreenForCarIn(isTicketMonthCard);

            // send data to server

            //sendOrderDataToServer();
        }

        //private void sendOrderDataToServer()
        //{
        //    if (Program.sCountConnection > Program.MAX_CONNECTION)
        //    {
        //        return;
        //    }
        //    if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
        //    {
        //        return;
        //    }           
        //    try
        //    {                             
        //        new Thread(() =>
        //        {
        //            Thread.CurrentThread.IsBackground = true;
        //            DataTable dataIn = CarDAO.GetDataInRecently();
        //            DataTable dataOut = CarDAO.GetDataOutRecently();
        //            if (Util.sendOrderListToServer(dataIn, true))
        //            {
        //                WaitSyncCarInDAO.DeleteAll();
        //            }

        //            if (Util.sendOrderListToServer(dataOut, true))
        //            {
        //                WaitSyncCarOutDAO.DeleteAll();
        //            }
        //        }).Start();
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}


        private void updateCarIn(bool isTicketMonthCard, DataTable dtLastCar, string inputDigit)
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
                if (!inputDigit.Equals(""))
                {
                    carDTO.DigitIn = inputDigit;
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
            if (inputIsLeftSide())
            {
                labelDateInLeft.Text = DateTime.Now.ToString("dd/MM/yyyy");
                labelTimeInLeft.Text = DateTime.Now.ToString("HH:mm");
                if (isTicketMonthCard)
                {
                    labelDigitRegisterLeft.Text = TicketMonthDAO.GetDigitByID(cardID);
                }
            }
            else
            {
                labelDateInRight.Text = DateTime.Now.ToString("dd/MM/yyyy");
                labelTimeInRight.Text = DateTime.Now.ToString("HH:mm");
                if (isTicketMonthCard)
                {
                    labelDigitRegisterRight.Text = TicketMonthDAO.GetDigitByID(cardID);
                }
            }

            int inOutType = mConfig.inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                labelCostRight.Text = "-";
                labelMoiVao.Text = "";
                labelMoiRa.Text = Constant.sLabelMoiVao;

                //pictureBoxImage1.Image = Properties.Resources.ic_logo;
                //pictureBoxImage2.Image = Properties.Resources.ic_logo;

                if (isTicketMonthCard)
                {
                    if (ConfigDAO.GetCalculationTicketMonth() == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                    {
                        labelCostRight.Text = "VE THANG";
                    }
                }
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (inputIsRightSide())
                {
                    labelCostRight.Text = "-";
                    labelMoiVao.Text = "";
                    labelMoiRa.Text = Constant.sLabelMoiVao;

                    //pictureBoxImage1.Image = Properties.Resources.ic_logo;
                    //pictureBoxImage2.Image = Properties.Resources.ic_logo;

                    if (isTicketMonthCard)
                    {
                        if (ConfigDAO.GetCalculationTicketMonth() == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                        {
                            labelCostRight.Text = "VE THANG";
                        }
                    }
                }
                else
                {
                    labelCostLeft.Text = "-";
                    labelMoiVao.Text = Constant.sLabelMoiVao;
                    labelMoiRa.Text = "";

                    //pictureBoxImage3.Image = Properties.Resources.ic_logo;
                    //pictureBoxImage4.Image = Properties.Resources.ic_logo;

                    if (isTicketMonthCard)
                    {
                        if (ConfigDAO.GetCalculationTicketMonth() == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                        {
                            labelCostLeft.Text = "VE THANG";
                        }
                    }
                }
            }
            else
            {
                labelCostLeft.Text = "-";
                labelMoiVao.Text = Constant.sLabelMoiVao;
                labelMoiRa.Text = "";

                //pictureBoxImage3.Image = Properties.Resources.ic_logo;
                //pictureBoxImage4.Image = Properties.Resources.ic_logo;

                if (isTicketMonthCard)
                {
                    if (ConfigDAO.GetCalculationTicketMonth() == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                    {
                        labelCostLeft.Text = "VE THANG";
                    }
                }
            }
        }

        //private void insertCarInAPI(string cardID)
        //{
        //    WebClient webClient = (new ApiUtil()).getWebClient();
        //    webClient.QueryString.Add(ApiUtil.PARAM_CODE, cardID);
        //    webClient.QueryString.Add(ApiUtil.PARAM_PC_NAME, Environment.MachineName);
        //    try
        //    {
        //        String responseString = webClient.DownloadString(ApiUtil.API_CHECKIN);
        //        Console.WriteLine(responseString);
        //    }
        //    catch (WebException exception)
        //    {
        //        string responseText;
        //        var responseStream = exception.Response?.GetResponseStream();

        //        if (responseStream != null)
        //        {
        //            using (var reader = new StreamReader(responseStream))
        //            {
        //                responseText = reader.ReadToEnd();
        //            }
        //        }
        //    }
        //}

        //private int updateCarOutAPI(string cardID)
        //{
        //    WebClient webClient = (new ApiUtil()).getWebClient();
        //    webClient.QueryString.Add(ApiUtil.PARAM_CODE, cardID);
        //    webClient.QueryString.Add(ApiUtil.PARAM_PC_NAME, Environment.MachineName);
        //    try
        //    {
        //        String responseString = webClient.DownloadString(ApiUtil.API_CHECKOUT);
        //        Console.WriteLine(responseString);
        //        JObject jObject = JObject.Parse(responseString);
        //        JToken jUser = jObject["body"];
        //        return (int)jUser["total_price"];
        //    }
        //    catch (WebException exception)
        //    {
        //        string responseText;
        //        var responseStream = exception.Response?.GetResponseStream();

        //        if (responseStream != null)
        //        {
        //            using (var reader = new StreamReader(responseStream))
        //            {
        //                responseText = reader.ReadToEnd();
        //            }
        //        }
        //    }
        //    return -1;
        //}

        private void updateCarOut(bool isTicketMonthCard, DataTable dtLastCar, bool isUpdateCarOut, string inputDigit)
        {
            if (dtLastCar != null && dtLastCar.Rows.Count > 0)
            {
                DateTime timeIn = dtLastCar.Rows[0].Field<DateTime>("TimeStart");

                string digitIn = dtLastCar.Rows[0].Field<string>("DigitIn");
                if (inputIsLeftSide())
                {
                    labelDigitInLeft.Text = digitIn;
                    labelDateInLeft.Text = timeIn.ToString("dd/MM/yyyy");
                    labelTimeInLeft.Text = timeIn.ToString("HH:mm");
                    labelDateOutLeft.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    labelTimeOutLeft.Text = DateTime.Now.ToString("HH:mm");
                    if (isTicketMonthCard)
                    {
                        labelDigitRegisterLeft.Text = TicketMonthDAO.GetDigitByID(cardID);
                    }
                }
                else
                {
                    labelDigitInRight.Text = digitIn;
                    labelDateInRight.Text = timeIn.ToString("dd/MM/yyyy");
                    labelTimeInRight.Text = timeIn.ToString("HH:mm");
                    labelDateOutRight.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    labelTimeOutRight.Text = DateTime.Now.ToString("HH:mm");
                    if (isTicketMonthCard)
                    {
                        labelDigitRegisterRight.Text = TicketMonthDAO.GetDigitByID(cardID);
                    }
                }

                int identify = dtLastCar.Rows[0].Field<int>("Identify");
                CarDTO carDTO = new CarDTO();
                carDTO.Identify = identify;
                carDTO.Id = cardID;
                carDTO.TimeEnd = DateTime.Now;
                carDTO.IdOut = Program.CurrentUserID;
                if (!inputDigit.Equals(""))
                {
                    carDTO.DigitOut = inputDigit;
                }

                if (isTicketMonthCard)
                {
                    if (ConfigDAO.GetCalculationTicketMonth() == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                    {
                        carDTO.Cost = 0;
                    }
                    else
                    {
                        if (!isUpdateCarOut)
                        {
                            carDTO.Cost = tinhTienGiuXe(dtLastCar);
                        }
                        else
                        {
                            labelCostRight.Text = dtLastCar.Rows[0].Field<int>("Cost") + "";
                        }

                    }

                    DateTime? expirationDate = TicketMonthDAO.GetExpirationDateByID(cardID);
                    int totalDaysLeft = (int)((DateTime)expirationDate - DateTime.Now).TotalDays;
                    if (expirationDate != null && totalDaysLeft <= 5)
                    {
                        if (totalDaysLeft <= 0)
                        {
                            // vé tháng hết hạn
                            int currentDay = (int)System.DateTime.Now.Day;
                            if (currentDay >= ConfigDAO.GetNoticeExpiredDate())
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
                                labelError.Text = "Thẻ tháng đã hết hạn!";
                            }
                        }
                        else
                        {
                            labelError.Text = "Thẻ tháng còn " + totalDaysLeft + " ngày nữa sẽ hết hạn!";
                        }
                    }
                }
                else
                {
                    carDTO.Cost = tinhTienGiuXe(dtLastCar);
                    //labelCostOut.Text = carDTO.Cost + "";
                }

                int inOutType = mConfig.inOutType;

                if (inOutType == ConfigDTO.TYPE_OUT_IN)
                {
                    labelCostLeft.Text = "-";
                    labelMoiVao.Text = Constant.sLabelMoiRa;
                    labelMoiRa.Text = "";

                    if (carDTO.Cost != null)
                    {
                        labelCostLeft.Text = Util.formatNumberAsMoney((int)carDTO.Cost);
                    }

                    //pictureBoxImage3.Image = Properties.Resources.ic_logo;
                    //pictureBoxImage4.Image = Properties.Resources.ic_logo;

                    if (isTicketMonthCard)
                    {
                        if (ConfigDAO.GetCalculationTicketMonth() == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                        {
                            labelCostLeft.Text = "VE THANG";
                        }
                    }
                }
                else if (inOutType == ConfigDTO.TYPE_OUT_OUT)
                {
                    if (inputIsLeftSide())
                    {
                        labelCostLeft.Text = "-";
                        labelMoiVao.Text = Constant.sLabelMoiRa;
                        labelMoiRa.Text = "";

                        if (carDTO.Cost != null)
                        {
                            labelCostLeft.Text = Util.formatNumberAsMoney((int)carDTO.Cost);
                        }

                        //pictureBoxImage3.Image = Properties.Resources.ic_logo;
                        //pictureBoxImage4.Image = Properties.Resources.ic_logo;

                        if (isTicketMonthCard)
                        {
                            if (ConfigDAO.GetCalculationTicketMonth() == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                            {
                                labelCostLeft.Text = "VE THANG";
                            }
                        }
                    }
                    else
                    {
                        labelCostRight.Text = "-";
                        labelMoiVao.Text = "";
                        labelMoiRa.Text = Constant.sLabelMoiRa;

                        if (carDTO.Cost != null)
                        {
                            labelCostRight.Text = Util.formatNumberAsMoney((int)carDTO.Cost);
                        }

                        //pictureBoxImage1.Image = Properties.Resources.ic_logo;
                        //pictureBoxImage2.Image = Properties.Resources.ic_logo;

                        if (isTicketMonthCard)
                        {
                            if (ConfigDAO.GetCalculationTicketMonth() == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                            {
                                labelCostRight.Text = "VE THANG";
                            }
                        }
                    }
                }
                else
                {
                    labelCostRight.Text = "-";
                    labelMoiVao.Text = "";
                    labelMoiRa.Text = Constant.sLabelMoiRa;

                    if (carDTO.Cost != null)
                    {
                        labelCostRight.Text = Util.formatNumberAsMoney((int)carDTO.Cost);
                    }

                    //pictureBoxImage1.Image = Properties.Resources.ic_logo;
                    //pictureBoxImage2.Image = Properties.Resources.ic_logo;

                    if (isTicketMonthCard)
                    {
                        if (ConfigDAO.GetCalculationTicketMonth() == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                        {
                            labelCostRight.Text = "VE THANG";
                        }
                    }
                }

                // show cost to LED
                showCostToLed(carDTO.Cost + "");

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

                    // send data to server
                    WaitSyncCarOutDAO.Insert(identify);
                    //sendOrderDataToServer();
                }
            }
        }

        //private void sendDataOutToServer()
        //{
        //    if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
        //    {
        //        return;
        //    }
        //    try
        //    {
        //        DataTable data = CarDAO.GetDataOutRecently();
        //        new Thread(() =>
        //        {
        //            Thread.CurrentThread.IsBackground = true;
        //            if (Util.sendOrderListToServer(data, false))
        //            {
        //                WaitSyncCarOutDAO.DeleteAll();
        //            }
        //        }).Start();
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}

        private void loadCarInData(DataTable dtLastCar)
        {
            if (dtLastCar != null)
            {
                int inOutType = mConfig.inOutType;
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
                        if (inputIsLeftSide())
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
                        if (inputIsLeftSide())
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

        //private string getPathFromSnapshot(PictureBox pictureBoxCamera)
        //{
        //    //return @"E:\WORK\GIT\ParkingManagement\ParkingMangement\bin\Debug\ParkingManagement\Images\20190807\33_20190807_200936_637008053763543873.jpg";
        //    //float reduceSizePercent = 0.5f;
        //    int compressedQuality = 25;

        //    string path = Constant.getSharedImageFolder() + Constant.getCurrentDateString();
        //    Directory.CreateDirectory(path);
        //    Util.ShareFolder(path, "Test Share", "This is a Test Share");
        //    Directory.SetCurrentDirectory(path);
        //    try
        //    {
        //        pictureBoxCamera.video.takeSnapshot();
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    string originalFileName = Util.NewestFileofDirectory(path);


        //    //if (isCarIn())
        //    //{
        //    //Bitmap bmpScreenshot = getBitMapFromCamera(pictureBoxCamera);
        //    //pictureBox.Image = bmpScreenshot;
        //    //zoomImageShowToPictureBox(originalFileName, pictureBox);
        //    //}

        //    try
        //    {
        //        string compressedFileName = cardID + DateTime.Now.ToString("_yyyyMMdd_HHmmss_") + DateTime.Now.Ticks + ".jpg";
        //        FileStream stream = new FileStream(originalFileName, FileMode.Open, FileAccess.Read);
        //        System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
        //        //System.Drawing.Image resizeImage = Util.Resize(img, reduceSizePercent);
        //        string destImagePath = path + @"\" + compressedFileName;
        //        Util.SaveJpeg(destImagePath, img, compressedQuality);
        //        img.Dispose();
        //        stream.Dispose();
        //        File.Delete(originalFileName);
        //        return Constant.getCurrentDateString() + @"\" + compressedFileName;
        //        //return Constant.getCurrentDateString() + @"\" + originalFileName;
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return "";
        //}
        private string getPathFromSnapshotThumbnail(Bitmap bitmap)
        {
            string path = Constant.getSharedImageFolder() + Constant.getCurrentDateString() + @"\";
            Directory.CreateDirectory(path);
            Util.ShareFolder(path, "Test Share", "This is a Test Share");

            try
            {
                string compressedFileName = cardID + DateTime.Now.ToString("_yyyyMMdd_HHmmss_") + DateTime.Now.Ticks + ".jpg";
                saveBitmapToFile(bitmap, path, compressedFileName);
                return Constant.getCurrentDateString() + @"\" + compressedFileName;
            }
            catch (Exception e)
            {

            }
            return "";
        }

        //private void deleteOldImages()
        //{
        //    string path = Constant.getSharedImageFolder() + Constant.getDateOnLastMonthString();
        //    if (Directory.Exists(path))
        //    {
        //        Directory.Delete(path, true);
        //    }
        //}

        private void zoomImageShowToPictureBox(string filePath, PictureBox pictureBox)
        {
            if (pictureBox != null)
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(filePath);
                try
                {
                    System.Drawing.Image image = pictureBox.Image;
                    if (Constant.IS_NAPSHOT_FULL_IMAGE)
                    {
                        float zoomImageRatio = 0.5f;
                        if (pictureBox == pictureBoxImage1)
                        {
                            zoomImageRatio = (float)mConfig.ZoomCamera1 / 100;
                        }
                        else if (pictureBox == pictureBoxImage2)
                        {
                            zoomImageRatio = (float)mConfig.ZoomCamera2 / 100;
                        }
                        else if (pictureBox == pictureBoxImage3)
                        {
                            zoomImageRatio = (float)mConfig.ZoomCamera3 / 100;
                        }
                        else if (pictureBox == pictureBoxImage4)
                        {
                            zoomImageRatio = (float)mConfig.ZoomCamera4 / 100;
                        }
                        zoomImageRatio = 1 - zoomImageRatio * 1.2f;
                        pictureBox.Image = Util.ResizeImage(img, zoomImageRatio);
                    }
                    else
                    {
                        pictureBox.Image = img;
                    }
                    if (image != null)
                    {
                        image.Dispose();
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void resetPictureBoxImage1()
        {
            PictureBox pictureBox = pictureBoxImage1;
            int inOutType = mConfig.inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                pictureBox = pictureBoxImage3;
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (inputIsRightSide())
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
            int inOutType = mConfig.inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                pictureBox = pictureBoxImage4;
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (inputIsRightSide())
                {
                    pictureBox = pictureBoxImage4;
                }
            }

            if (isCarIn())
            {
                pictureBox.Image = Properties.Resources.ic_logo;
            }
        }

        private void loadCameraCapture()
        {
            pictureBoxCamera1.BackgroundImageLayout = ImageLayout.Center;
            pictureBoxCamera2.BackgroundImageLayout = ImageLayout.Center;
            pictureBoxCamera3.BackgroundImageLayout = ImageLayout.Center;
            pictureBoxCamera4.BackgroundImageLayout = ImageLayout.Center;
            if (!cameraUrl1.Equals(""))
            {
                cameraCapture1 = new CameraCapture(cameraUrl1, pictureBoxCamera1);
                cameraCapture2 = new CameraCapture(cameraUrl2, pictureBoxCamera2);
                cameraCapture3 = new CameraCapture(cameraUrl3, pictureBoxCamera3);
                cameraCapture4 = new CameraCapture(cameraUrl4, pictureBoxCamera4);
                cameraCapture1.Start();
                cameraCapture2.Start();
                cameraCapture3.Start();
                cameraCapture4.Start();
            }            
            pictureBoxImage1.BringToFront();
            pictureBoxImage2.BringToFront();
            pictureBoxImage3.BringToFront();
            pictureBoxImage4.BringToFront();
        }

        //private void loadCamera1VLC()
        //{
        //    String rtspString = cameraUrl1;
        //    var uri = new Uri(rtspString);
        //    var convertedURI = uri.AbsoluteUri;
        //    //pictureBoxCamera1.playlist.add(convertedURI);
        //    pictureBoxCamera1.playlist.add(rtspString, "1", "--network-caching=100");
        //    try
        //    {
        //        pictureBoxCamera1.playlist.play();
        //        pictureBoxCamera1.BringToFront();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        private void saveImage1ToFile()
        {
            PictureBox pictureBoxCamera = pictureBoxCamera1;
            PictureBox pictureBox = pictureBoxImage1;
            int inOutType = mConfig.inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                pictureBoxCamera = pictureBoxCamera3;
                pictureBox = pictureBoxImage3;
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (inputIsRightSide())
                {
                    pictureBoxCamera = pictureBoxCamera3;
                    pictureBox = pictureBoxImage3;
                }
            }

            if (isCarIn())
            {
                Bitmap bmpScreenshot = getBitMapFromCamera(pictureBoxCamera);
                pictureBox.Image = bmpScreenshot;
                imagePath1 = getPathFromSnapshotThumbnail(bmpScreenshot);
            }
        }

        private void loadImage1ToPictureBox()
        {
            PictureBox pictureBoxCamera = pictureBoxCamera1;
            PictureBox pictureBox = pictureBoxImage1;
            int inOutType = mConfig.inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                pictureBoxCamera = pictureBoxCamera3;
                pictureBox = pictureBoxImage3;
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (inputIsRightSide())
                {
                    pictureBoxCamera = pictureBoxCamera3;
                    pictureBox = pictureBoxImage3;
                }
            }

            if (isCarIn())
            {
                Bitmap bmpScreenshot = getBitMapFromCamera(pictureBoxCamera);
                pictureBox.Image = bmpScreenshot;
            }
        }

        //private void loadCamera2VLC()
        //{
        //    String rtspString = cameraUrl2;
        //    PictureBox.playlist.add(rtspString);
        //    try
        //    {
        //        PictureBox.playlist.play();
        //        PictureBox.BringToFront();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        private void saveImage2ToFile()
        {
            PictureBox pictureBoxCamera = pictureBoxCamera2;
            PictureBox pictureBox = pictureBoxImage2;
            int inOutType = mConfig.inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                pictureBoxCamera = pictureBoxCamera4;
                pictureBox = pictureBoxImage4;
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (inputIsRightSide())
                {
                    pictureBoxCamera = pictureBoxCamera4;
                    pictureBox = pictureBoxImage4;
                }
            }

            if (isCarIn())
            {
                Bitmap bmpScreenshot = getBitMapFromCamera(pictureBoxCamera);
                pictureBox.Image = bmpScreenshot;
                imagePath2 = getPathFromSnapshotThumbnail(bmpScreenshot);
            }
        }

        private void loadImage2ToPictureBox()
        {
            PictureBox pictureBoxCamera = pictureBoxCamera2;
            PictureBox pictureBox = pictureBoxImage2;
            int inOutType = mConfig.inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                pictureBoxCamera = pictureBoxCamera4;
                pictureBox = pictureBoxImage4;
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (inputIsRightSide())
                {
                    pictureBoxCamera = pictureBoxCamera4;
                    pictureBox = pictureBoxImage4;
                }
            }

            if (isCarIn())
            {
                Bitmap bmpScreenshot = getBitMapFromCamera(pictureBoxCamera);
                pictureBox.Image = bmpScreenshot;
            }
        }

        //private void loadCamera3VLC()
        //{
        //    String rtspString = cameraUrl3;
        //    pictureBoxCamera3.playlist.add(rtspString);
        //    try
        //    {
        //        pictureBoxCamera3.playlist.play();
        //        pictureBoxCamera3.BringToFront();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        private void saveImage3ToFile()
        {
            PictureBox pictureBoxCamera = pictureBoxCamera3;
            int inOutType = mConfig.inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                pictureBoxCamera = pictureBoxCamera1;
            }
            else if (inOutType == ConfigDTO.TYPE_OUT_OUT)
            {
                if (inputIsLeftSide())
                {
                    pictureBoxCamera = pictureBoxCamera1;
                }
            }
            Bitmap bmpScreenshot = getBitMapFromCamera(pictureBoxCamera);
            imagePath3 = getPathFromSnapshotThumbnail(bmpScreenshot);
        }

        //private void loadCamera4VLC()
        //{
        //    String rtspString = cameraUrl4;
        //    pictureBoxCamera4.playlist.add(rtspString);
        //    try
        //    {
        //        pictureBoxCamera4.playlist.play();
        //        pictureBoxCamera4.BringToFront();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        private void saveImage4ToFile()
        {
            PictureBox pictureBoxCamera = pictureBoxCamera4;
            int inOutType = mConfig.inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                pictureBoxCamera = pictureBoxCamera2;
            }
            else if (inOutType == ConfigDTO.TYPE_OUT_OUT)
            {
                if (inputIsLeftSide())
                {
                    pictureBoxCamera = pictureBoxCamera2;
                }
            }
            Bitmap bmpScreenshot = getBitMapFromCamera(pictureBoxCamera);
            imagePath4 = getPathFromSnapshotThumbnail(bmpScreenshot);
        }

        private Bitmap getBitMapFromCamera(PictureBox pictureBoxCamera)
        {
            //pictureBoxCamera.playlist.togglePause();
            Bitmap bmpScreenshot = new Bitmap(pictureBoxCamera.ClientRectangle.Width,
                pictureBoxCamera.ClientRectangle.Height);
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            System.Drawing.Size imgSize = new System.Drawing.Size(
                pictureBoxCamera.ClientRectangle.Width,
                pictureBoxCamera.ClientRectangle.Height);
            System.Drawing.Point ps = pictureBoxCamera.PointToScreen(System.Drawing.Point.Empty);
            gfxScreenshot.CopyFromScreen(ps.X, ps.Y, 0, 0, imgSize, CopyPixelOperation.SourceCopy);
            //pictureBoxCamera.playlist.play();
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

            cameraUrl1 = mConfig.cameraUrl1;
            cameraUrl2 = mConfig.cameraUrl2;
            cameraUrl3 = mConfig.cameraUrl3;
            cameraUrl4 = mConfig.cameraUrl4;
            rfidIn = mConfig.rfidIn;
            rfidOut = mConfig.rfidOut;
            portNameComReceiveIn = mConfig.comReceiveIn;
            portNameComReceiveOut = mConfig.comReceiveOut;
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
            float zoomValue1 = (float)value1 / 100;
            float zoomValue2 = (float)value2 / 100;
            float zoomValue3 = (float)value3 / 100;
            float zoomValue4 = (float)value4 / 100;
            //pictureBoxCamera1.video.aspectRatio = "209:253";
            //PictureBox.video.aspectRatio = "209:253";
            //pictureBoxCamera3.video.aspectRatio = "209:253";
            //pictureBoxCamera4.video.aspectRatio = "209:253";

            //pictureBoxCamera1.video.scale = 0.7f;
            //PictureBox.video.scale = 0.7f;
            //pictureBoxCamera3.video.scale = 0.7f;
            //pictureBoxCamera4.video.scale = 0.7f;
        }

        private void OnKeyPressed(object sender, RawInputEventArg e)
        {
            String source = e.KeyPressEvent.Source;
            if (e.KeyPressEvent.DeviceName.Equals(rfidIn) || e.KeyPressEvent.DeviceName.Equals(rfidOut))
            {
                rfidInput = e.KeyPressEvent.DeviceName;
            }
            else
            {
                rfidInput = "";
            }
        }

        private void Keyboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            _rawinput.KeyPressed -= OnKeyPressed;
            //int count = 0;
            //for (int i = 0; i < Application.OpenForms.Count; i++)
            //{
            //    if (Application.OpenForms[i].Visible == true)//will not count hidden forms
            //        count++;
            //}
            //if (count == 1)
            //{
            //    Application.Exit();
            //}
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
            int inOutType = mConfig.inOutType;
            switch (inOutType)
            {
                case ConfigDTO.TYPE_IN_IN:
                    return true;
                case ConfigDTO.TYPE_OUT_OUT:
                    return false;
                case ConfigDTO.TYPE_IN_OUT:
                    if (inputIsRightSide())
                    {
                        return false;
                    }
                    return true;
                case ConfigDTO.TYPE_OUT_IN:
                    if (inputIsRightSide())
                    {
                        return true;
                    }
                    return false;
                default:
                    if (inputIsRightSide())
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
                case Constant.LOAI_GIU_XE_TONG_HOP_THEO_NGAY_DEM:
                    return tinhGiaTienTongHopTheoNgayDem(dtLastCar);
                default:
                    return tinhGiaTienTheoCongVan(dtLastCar);
            }
        }

        private int tinhGiaTienTheoCongVan(DataTable dtLastCar)
        {
            string partID = CardDAO.getPartIDByCardID(cardID);
            ComputerDTO computerDTO = ComputerDAO.GetDataByPartIDAndParkingTypeID(partID, Constant.LOAI_GIU_XE_THEO_CONG_VAN);         
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
                } else
                {
                    return getCostTinhTienCongVan(timeIn, timeOut, computerDTO);
                }

            }
            return 0;
        }

        private int getCostTinhTienCongVan(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO)
        {
            double spentTimeByHour = Util.getTotalTimeByHour(timeIn, timeOut);
            double limit = (double)computerDTO.Limit / 60; // (hour)

            if (timeIn.Hour >= computerDTO.EndHourNight && timeOut.Hour < computerDTO.StartHourNight && timeIn.DayOfYear == timeOut.DayOfYear)
            {
                // vào ngày - ra ngày
                return computerDTO.DayCost;
            }
            else if (spentTimeByHour <= 24)
            {
                //trong 1 ngày
                if (((timeIn.Hour >= computerDTO.StartHourNight && timeOut.Hour < 24) || (timeIn.Hour >= 0 && timeOut.Hour < computerDTO.EndHourNight)
                    || (timeIn.Hour >= computerDTO.StartHourNight && timeOut.Hour < computerDTO.EndHourNight)))
                {
                    // vào đêm - ra đêm
                    return computerDTO.NightCost;
                }
                else
                {
                    // vào ngày - ra đêm hoặc vào đêm - ra ngày
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
                            }
                            else
                            {
                                // thời gian ngày lớn hơn giới hạn
                                return computerDTO.NightCost;
                            }
                        }
                        else
                        {
                            // thời gian ngày nhỏ hơn đêm
                            return computerDTO.NightCost;
                        }
                    }
                    else
                    {
                        // thời gian trong bãi lớn hơn khoảng giao ngày - đêm
                        return computerDTO.DayNightCost;
                    }
                }
            }
            else
            {
                int temp1 = ((int)spentTimeByHour) / 24;
                DateTime newTimeIn = timeIn.AddHours(temp1 * 24);
                int costMilestoneRemain = getCostTinhTienCongVan(newTimeIn, timeOut, computerDTO);
                return costMilestoneRemain + temp1 * computerDTO.DayNightCost;
            }
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
                if (spentTimeByHour < computerDTO.HourMilestone1)
                {
                    return computerDTO.CostMilestone1;
                }
                else if (spentTimeByHour >= computerDTO.HourMilestone1 && spentTimeByHour < computerDTO.HourMilestone1 + computerDTO.HourMilestone2)
                {
                    return computerDTO.CostMilestone1 + computerDTO.CostMilestone2;
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
                if (spentTimeByHour < computerDTO.HourMilestone1)
                {
                    return computerDTO.CostMilestone1;
                }
                else if (spentTimeByHour >= computerDTO.HourMilestone1 && spentTimeByHour < computerDTO.HourMilestone2)
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
                        int temp1 = ((int)spentTimeByHour - computerDTO.HourMilestone1) / computerDTO.CycleMilestone3;
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

        private int tinhGiaTienTongHopTheoNgayDem(DataTable dtLastCar)
        {
            string partID = CardDAO.getPartIDByCardID(cardID);
            ComputerDTO computerDTO = ComputerDAO.GetDataByPartIDAndParkingTypeID(partID, Constant.LOAI_GIU_XE_TONG_HOP_THEO_NGAY_DEM);
            if (dtLastCar != null)
            {
                DateTime timeIn = dtLastCar.Rows[0].Field<DateTime>("TimeStart");
                DateTime timeOut = DateTime.Now;
                double spentTimeByMinute = Util.getTotalTimeByMinute(timeIn, timeOut);
                if (spentTimeByMinute <= 5)
                {
                    return 0;
                }
                if (spentTimeByMinute <= computerDTO.MinMinute)
                {
                    return computerDTO.MinCost;
                }
                else
                {
                    timeIn = timeIn.AddMinutes(computerDTO.MinMinute);

                    return getCostTinhTienTongHop2(timeIn, timeOut, computerDTO);

                }
            }
            return 0;
        }

        private int getCostTinhTienTongHop2(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO)
        {
            double spentTimeByHour = Util.getTotalTimeByHour(timeIn, timeOut);
            double totalHourOfDay = getTotalHourOfDay(timeIn, timeOut, computerDTO);
            double totalHourOfNight = getTotalHourOfNight(timeIn, timeOut, computerDTO);

            if (spentTimeByHour < computerDTO.HourMilestone1)
            {
                // mốc 1
                if (timeIn.Hour >= computerDTO.EndHourNight && timeOut.Hour < computerDTO.StartHourNight && timeIn.DayOfYear == timeOut.DayOfYear)
                {
                    // vào ngày - ra ngày
                    return computerDTO.CostMilestone1;
                }
                //else if (((timeIn.Hour >= computerDTO.StartHourNight && timeIn.Hour <= timeOut.Hour && timeOut.Hour < 24) || (timeIn.Hour >= 0 && timeOut.Hour < computerDTO.EndHourNight)) && Util.getTotalTimeByDay(timeIn, timeOut) <= 1)
                //{
                //    // vào đêm - ra đêm
                //    return computerDTO.CostMilestoneNight1;
                //}
                else
                {
                    if (totalHourOfDay >= totalHourOfNight)
                    {
                        return computerDTO.CostMilestone1;
                    }
                    else
                    {
                        return computerDTO.CostMilestoneNight1;
                    }
                }
            }
            else if (spentTimeByHour >= computerDTO.HourMilestone1 && spentTimeByHour < computerDTO.HourMilestone2)
            {
                // mốc 2
                if (timeIn.Hour >= computerDTO.EndHourNight && timeOut.Hour < computerDTO.StartHourNight && timeIn.DayOfYear == timeOut.DayOfYear)
                {
                    // vào ngày - ra ngày
                    return computerDTO.CostMilestone2;
                }
                //else if (((timeIn.Hour >= computerDTO.StartHourNight && timeOut.Hour < 24) || (timeIn.Hour >= 0 && timeOut.Hour < computerDTO.EndHourNight)) && Util.getTotalTimeByDay(timeIn, timeOut) <= 1)
                //{
                //    // vào đêm - ra đêm
                //    return computerDTO.CostMilestoneNight2;
                //}
                else
                {
                    if (totalHourOfDay >= totalHourOfNight)
                    {
                        return computerDTO.CostMilestone2;
                    }
                    else
                    {
                        return computerDTO.CostMilestoneNight2;
                    }
                }
            }
            else if (spentTimeByHour >= computerDTO.HourMilestone2 && spentTimeByHour < computerDTO.HourMilestone3)
            {
                // mốc 3
                if (timeIn.Hour >= computerDTO.EndHourNight && timeOut.Hour < computerDTO.StartHourNight && timeIn.DayOfYear == timeOut.DayOfYear)
                {
                    // vào ngày - ra ngày
                    return computerDTO.CostMilestone3;
                }
                //else if (((timeIn.Hour >= computerDTO.StartHourNight && timeIn.Hour <= timeOut.Hour && timeOut.Hour < 24) || (timeIn.Hour >= 0 && timeOut.Hour < computerDTO.EndHourNight)) && Util.getTotalTimeByDay(timeIn, timeOut) <= 1)
                //{
                //    // vào đêm - ra đêm
                //    return computerDTO.CostMilestoneNight3;
                //}
                else
                {
                    if (totalHourOfDay >= totalHourOfNight)
                    {
                        return computerDTO.CostMilestone3;
                    }
                    else
                    {
                        return computerDTO.CostMilestoneNight3;
                    }
                }
            }
            else
            {
                // lớn hơn mốc 3
                int cost = 0;
                if (computerDTO.CycleMilestone3 > computerDTO.HourMilestone1)
                {
                    // xe may
                    int temp1 = ((int)spentTimeByHour) / computerDTO.CycleMilestone3;
                    timeIn = timeIn.AddHours(temp1 * computerDTO.CycleMilestone3);
                    cost = computerDTO.CostMilestone4;
                    if (temp1 > 0)
                    {
                        int costMilestoneRemain = getCostTinhTienTongHop2(timeIn, timeOut, computerDTO);
                        cost = costMilestoneRemain + temp1 * computerDTO.CostMilestone4;
                    }
                }
                else
                {
                    // o to
                    spentTimeByHour = spentTimeByHour - computerDTO.HourMilestone1;
                    int temp1 = ((int)spentTimeByHour) / computerDTO.CycleMilestone3;
                    int costMilestoneRemain = computerDTO.CostMilestone1;
                    cost = costMilestoneRemain + (temp1 + 1) * computerDTO.CostMilestone4;
                }

                return cost;
            }
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
                return computerDTO.StartHourNight - timeIn.Hour - (double)timeIn.Minute / 60;
            }
            else
            {
                return timeOut.Hour + (double)timeOut.Minute / 60 - computerDTO.EndHourNight;
            }
        }

        private double getTotalHourOfDayWhenOutDay(DateTime timeOut, ComputerDTO computerDTO)
        {
            double value = timeOut.Hour + (double)timeOut.Minute / 60 - computerDTO.EndHourNight;
            return value;
        }

        private double getTotalHourOfNight(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO)
        {
            if (IsCarInDayOutNightOneDate(timeIn, timeOut, computerDTO))
            {
                if (timeOut.Hour >= computerDTO.StartHourNight && timeOut.Hour < 24)
                {
                    return timeOut.Hour + (double)timeOut.Minute / 60 - computerDTO.StartHourNight;
                }
                else
                {
                    return timeOut.Hour + (double)timeOut.Minute / 60 + 24 - computerDTO.StartHourNight;
                }
            }
            else
            {
                if (timeIn.Hour >= computerDTO.StartHourNight && timeIn.Hour < 24)
                {
                    return 24 - timeIn.Hour - (double)timeIn.Minute / 60 + computerDTO.EndHourNight;
                }
                else
                {
                    return computerDTO.EndHourNight - timeIn.Hour - (double)timeIn.Minute / 60;
                }
            }
        }

        private int soLuotQuaNgay(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO)
        {
            int dayDistant = Util.getTotalTimeByDay(timeIn, timeOut);
            return dayDistant;
            //if (computerDTO.IntervalBetweenDayNight == 0)
            //{
            //    computerDTO.IntervalBetweenDayNight = 1;
            //}
            //int countOfCircle = (int) Util.getTotalTimeByHour(timeIn, timeOut) / computerDTO.IntervalBetweenDayNight;
            //return countOfCircle - dayDistant;
        }

        public void updateCauHinhHienThiXeRaVao()
        {
            mConfig = Util.getConfigFile();
            int inOutType = mConfig.inOutType;
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

            resetAllData();
        }

        private void resetDataOneSide(bool isResetImage)
        {
            oldUhfCardId = null;
            labelError.Text = "";
            labelMoiVao.Text = "";
            labelMoiRa.Text = "";

            if (inputIsLeftSide())
            {
                labelCardIDLeft.Text = "-";
                labelPartNameTypeNameLeft.Text = "-";
                labelCustomerNameLeft.Text = "-";
                labelCostLeft.Text = "-";
                labelDateInLeft.Text = "-";
                labelTimeInLeft.Text = "-";
                labelDateOutLeft.Text = "-";
                labelTimeOutLeft.Text = "-";
                labelDigitInLeft.Text = "";
                labelDigitOutLeft.Text = "-";
                labelDigitRegisterLeft.Text = "-";
            }
            else
            {
                labelCardIDRight.Text = "-";
                labelPartNameTypeNameRight.Text = "-";
                labelCustomerNameRight.Text = "-";
                labelCostRight.Text = "-";
                labelDateInRight.Text = "-";
                labelTimeInRight.Text = "-";
                labelDateOutRight.Text = "-";
                labelTimeOutRight.Text = "-";
                labelDigitInRight.Text = "";
                labelDigitOutRight.Text = "-";
                labelDigitRegisterRight.Text = "-";
            }

            if (isResetImage)
            {
                pictureBoxImage1.Image = Properties.Resources.ic_logo;
                pictureBoxImage2.Image = Properties.Resources.ic_logo;
                pictureBoxImage3.Image = Properties.Resources.ic_logo;
                pictureBoxImage4.Image = Properties.Resources.ic_logo;
            }
        }

        private void resetAllData()
        {
            oldUhfCardId = null;
            labelError.Text = "";
            labelMoiVao.Text = "";
            labelMoiRa.Text = "";

            labelCardIDLeft.Text = "-";
            labelPartNameTypeNameLeft.Text = "-";
            labelCustomerNameLeft.Text = "-";
            labelCostLeft.Text = "-";
            labelDateInLeft.Text = "-";
            labelTimeInLeft.Text = "-";
            labelDateOutLeft.Text = "-";
            labelTimeOutLeft.Text = "-";
            labelDigitInLeft.Text = "";
            labelDigitOutLeft.Text = "-";
            labelDigitRegisterLeft.Text = "-";

            labelCardIDRight.Text = "-";
            labelPartNameTypeNameRight.Text = "-";
            labelCustomerNameRight.Text = "-";
            labelCostRight.Text = "-";
            labelDateInRight.Text = "-";
            labelTimeInRight.Text = "-";
            labelDateOutRight.Text = "-";
            labelTimeOutRight.Text = "-";
            labelDigitInRight.Text = "";
            labelDigitOutRight.Text = "-";
            labelDigitRegisterRight.Text = "-";

            pictureBoxImage1.Image = Properties.Resources.ic_logo;
            pictureBoxImage2.Image = Properties.Resources.ic_logo;
            pictureBoxImage3.Image = Properties.Resources.ic_logo;
            pictureBoxImage4.Image = Properties.Resources.ic_logo;
        }

        private void inputDigitCarInEvent(string digit)
        {
            if (!rfidInput.Equals(rfidIn) && !rfidInput.Equals(rfidOut))
            {
                updateDigitCarIn(digit);
                tbRFIDCardID.Focus();
                tbRFIDCardID.Text = "";
            }
            else
            {
                labelDigitInRight.Text = "";
            }
        }

        private void pictureBoxChangeLane_Click(object sender, EventArgs e)
        {
            openInOutSetting();
        }

        private void pictureBoxGetCard_Click(object sender, EventArgs e)
        {
            openFormQuanLyXeRaVao();
        }

        private void tbRFIDCardID_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Space:
                    labelError.Text = "";
                    cardID = tbRFIDCardID.Text.Trim();
                    tbRFIDCardID.Text = "";
                    if (!cardID.Equals(""))
                    {
                        readCardEvent();
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
            oldSize = base.Size;
        }

        private void ResizeAll(Control cnt, Size newSize)
        {
            float scaleFactor = (float) newSize.Width / oldSize.Width;
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
            return size.Width;
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
                    if (true)
                    {
                        // scale font
                        c.Font = new Font(c.Font.FontFamily, c.Font.Size * scaleFactor, c.Font.Style);
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
            //int count = 0;
            //for (int i = 0; i < Application.OpenForms.Count; i++)
            //{
            //    if (Application.OpenForms[i].Visible == true)//will not count hidden forms
            //        count++;
            //}
            //if (count == 1)
            //{
            //    Application.Exit();
            //}
            Application.Exit();
            System.Environment.Exit(1);
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
            aTimer.Interval = 20 * 1000;
            aTimer.Enabled = true;
            aTimer.Start();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                Invoke(new MethodInvoker(() => {
                    dgvThongKeXeTrongBai.DataSource = CarDAO.GetListCarSurvive();
                    showLostAvailableToLed();
                }));

                //new Thread(() =>
                //{
                //Thread.CurrentThread.IsBackground = true;
                //Util.sendCardListToServer(CardDAO.GetAllDataForSync());
                //Util.sendMonthlyCardListToServer(TicketMonthDAO.GetAllDataForSync());
                //Util.syncCardListFromServer();
                //Util.syncMonthlyCardListFromServer();
                //}).Start();
            }
            catch (Exception)
            {

            }
        }

        private void updateXeRaVaoTimer()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnXeRaVaoTimedEvent);
            aTimer.Interval = 60 * 2 * 1000;
            aTimer.Enabled = true;
            aTimer.Start();
        }

        private void OnXeRaVaoTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                Invoke(new MethodInvoker(() => {
                    // send data to server
                    //sendOrderDataToServer();
                    //WaitSyncCarInDAO.DeleteAll();
                    //WaitSyncCarOutDAO.DeleteAll();
                }));
            }
            catch (Exception)
            {

            }
        }

        private void showLostAvailableToLed()
        {
            string portName = mConfig.comLostAvailable;
            int countBikeEmpty = ConfigDAO.GetBikeSpace() - CarDAO.GetCountCarSurvive(TypeDTO.TYPE_BIKE);
            string dataBike = "@xemay_" + countBikeEmpty.ToString("D" + 4) + "&" + "\r\n";
            writeDataToLostAvailablePort(dataBike, portName);
            Thread.Sleep(1000);
            int countCarEmpty = ConfigDAO.GetCarSpace() - CarDAO.GetCountCarSurvive(TypeDTO.TYPE_CAR);
            string dataCar = "@oto_" + countCarEmpty.ToString("D" + 4) + "&" + "\r\n";
            writeDataToLostAvailablePort(dataCar, portName);
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
            int inOutType = mConfig.inOutType;
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

        private void openBarieInCar()
        {
            openBarieIn();

            string carSignal = mConfig.signalOpenBarieIn;
            string motorBikeSignal = mConfig.signalOpenBarieInMotorbike;
            if (!carSignal.Equals(motorBikeSignal))
            {
                openBarieInMotorbike();
            }
        }

        private void openBarieIn()
        {
            string data = mConfig.signalOpenBarieIn;
            string portName = mConfig.comSend;
            writeDataToPort(data, portName);
        }

        private void openBarieInMotorbike()
        {
            string data = mConfig.signalOpenBarieInMotorbike;
            string portName = mConfig.comSend;
            writeDataToPort(data, portName);
        }

        private void openBarieOut()
        {
            string data = mConfig.signalOpenBarieOut;
            string portName = mConfig.comSend;
            writeDataToPort(data, portName);
        }

        private void openBarieOutCar()
        {
            openBarieOut();

            string carSignal = mConfig.signalOpenBarieOut;
            string motorBikeSignal = mConfig.signalOpenBarieOutMotorbike;
            if (!carSignal.Equals(motorBikeSignal))
            {
                openBarieOutMotorbike();
            }
        }

        private void openBarieOutMotorbike()
        {
            string data = mConfig.signalOpenBarieOutMotorbike;
            string portName = mConfig.comSend;
            writeDataToPort(data, portName);
        }

        private void closeBarieIn()
        {
            string data = mConfig.signalCloseBarieIn;
            string portName = mConfig.comSend;
            writeDataToPort(data, portName);
        }

        private void closeBarieInMotorbike()
        {
            string data = mConfig.signalCloseBarieInMotorbike;
            string portName = mConfig.comSend;
            writeDataToPort(data, portName);
        }

        private void closeBarieOut()
        {
            string data = mConfig.signalCloseBarieOut;
            string portName = mConfig.comSend;
            writeDataToPort(data, portName);
        }

        private void closeBarieOutMotorbike()
        {
            string data = mConfig.signalCloseBarieOutMotorbike;
            string portName = mConfig.comSend;
            writeDataToPort(data, portName);
        }

        private void showCostToLed(string cost)
        {
            string data = "@tien_" + cost + "&";
            string portName = mConfig.comLedLeft;
            if (!mConfig.comLedRight.Equals(""))
            {
                // 2 cổng COM
                if (inputIsLeftSide())
                {
                    portName = mConfig.comLedLeft;
                    writeDataToLeftLedPort(data, portName);
                }
                else
                {
                    portName = mConfig.comLedRight;
                    writeDataToRightLedPort(data, portName);
                }
            }
            else
            {
                // 1 cổng COM
                portName = mConfig.comLedLeft;
                if (inputIsLeftSide())
                {
                    data = "@tien1_" + cost + "&";
                    writeDataToRightLedPort(data, portName);
                }
                else
                {
                    data = "@tien2_" + cost + "&";
                    writeDataToRightLedPort(data, portName);
                }
            }
        }

        //SerialPort port;
        SerialPort port;
        private void writeDataToPort(string data, string portName)
        {
            if (portName.Equals(""))
            {
                return;
            }
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
            }
            catch (Exception e)
            {
                Console.WriteLine("bug: " + e.Message);
            }
        }

        private void writeDataToLeftLedPort(string data, string portName)
        {
            if (portName.Equals(""))
            {
                return;
            }
            try
            {
                if (leftLedPort == null || !leftLedPort.IsOpen)
                {
                    leftLedPort = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
                }

                if (!leftLedPort.IsOpen)
                {
                    leftLedPort.Open();
                }
                leftLedPort.Write(data);
                //port.Close();
                Console.WriteLine(data);
            }
            catch (Exception e)
            {
                Console.WriteLine("bug: " + e.Message);
            }
        }

        private void writeDataToLostAvailablePort(string data, string portName)
        {
            if (portName.Equals(""))
            {
                return;
            }
            try
            {
                if (lostAvailablePort == null || !lostAvailablePort.IsOpen)
                {
                    lostAvailablePort = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
                }

                if (!lostAvailablePort.IsOpen)
                {
                    lostAvailablePort.Open();
                }
                lostAvailablePort.Write(data);
                //port.Close();
                Console.WriteLine(data);
            }
            catch (Exception e)
            {
                Console.WriteLine("bug: " + e.Message);
            }
        }

        private void writeDataToRightLedPort(string data, string portName)
        {
            if (portName.Equals(""))
            {
                return;
            }
            try
            {
                if (rightLedPort == null || !rightLedPort.IsOpen)
                {
                    rightLedPort = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
                }

                if (!rightLedPort.IsOpen)
                {
                    rightLedPort.Open();
                }
                rightLedPort.Write(data);
                //port.Close();
                Console.WriteLine(data);
            }
            catch (Exception e)
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
            }
            catch (Exception e)
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
            //    readCardEvent();
            //}
        }

        private void portComReceiveOut_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //portNameComReceiveInput = portNameComReceiveOut;
            //cardID = portComReceiveOut.ReadExisting();
            //if (!cardID.Equals(""))
            //{
            //    readCardEvent();
            //}
        }

        private bool inputIsRightSide()
        {
            if (portNameComReceiveInput != null)
            {
                bool result = portNameComReceiveInput.Equals(portNameComReceiveOut);
                return result;
            }
            else
            {
                bool result = rfidInput.Equals(rfidOut);
                return result;
            }
        }

        private bool inputIsLeftSide()
        {
            return !inputIsRightSide();
        }

        private void FormNhanVien_Activated(object sender, EventArgs e)
        {
            _rawinput.KeyPressed -= OnKeyPressed;
            _rawinput.KeyPressed += OnKeyPressed;
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
            try
            {
                int frmcomportindexIn = UHFReader.getComportIndex(mConfig.comReceiveIn);
                int frmcomportindexOut = UHFReader.getComportIndex(mConfig.comReceiveOut);
                string uhfInCardId = UHFReader.GetUHFData(frmcomportindexIn);
                string newUhfCardId = null;
                string portName = null;
                if (uhfInCardId != null)
                {
                    portName = portNameComReceiveIn;
                    newUhfCardId = uhfInCardId;
                }
                else
                {
                    string uhfOutCardId = UHFReader.GetUHFData(frmcomportindexOut);
                    if (uhfOutCardId != null)
                    {
                        portName = portNameComReceiveOut;
                        newUhfCardId = uhfOutCardId;
                    }
                }

                if (newUhfCardId != null)
                {
                    int spentTime = Util.getMillisecondBetweenTwoDate(oldUhfCardTime, DateTime.Now);
                    oldUhfCardTime = DateTime.Now;
                    int distant = 3 * 60 * 1000; // 3'
                    if (!newUhfCardId.Equals(oldUhfCardId) || spentTime > distant)
                    {
                        oldUhfCardId = newUhfCardId;
                        //labelError.Text = newUhfCardId;
                        cardID = newUhfCardId;
                        portNameComReceiveInput = portName;

                        readCardEvent();
                    }


                    //if (portNameComReceiveInput != null && portNameComReceiveInput.Equals(oldPortNameComReceiveInput))
                    //{
                    //    if (isCarIn())
                    //    {
                    //        openBarieIn();
                    //    }
                    //    else
                    //    {
                    //        openBarieOut();
                    //    }
                    //}
                    oldPortNameComReceiveInput = portName;
                }
            }
            catch (Exception)
            {

            }
        }

        private void initUhfTimer()
        {
            timerReadUHFData.Enabled = true;
        }

        private void FormNhanVien_Shown(object sender, EventArgs e)
        {
            tbRFIDCardID.Focus();
            loadCameraCapture();
        }

        private void labelDigitInLeft_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    string digit = labelDigitInLeft.Text;
                    inputDigitCarInEvent(digit);
                    break;
            }
        }

        private void labelDigitRight_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    string digit = labelDigitInRight.Text;
                    inputDigitCarInEvent(digit);
                    break;
            }
        }

        private void pictureBoxBarieLeft_Click(object sender, EventArgs e)
        {
            openBarieInCar();
            AutoClosingMessageBox.Show("Barie đã mở", "", 500);
        }

        private void pictureBoxBarieRight_Click(object sender, EventArgs e)
        {
            openBarieOutCar();
            AutoClosingMessageBox.Show("Barie đã mở", "", 500);
        }

        private string uploadCarNumberImage(string fileName, bool isLeftSide, bool isCarIn)
        {
            WebClient webClient = (new ApiUtil()).getWebClient();
            try
            {
                string url = @"http://127.0.0.1:8000/getPlateNumber/" + fileName;
                String responseString = webClient.DownloadString(url);
                Console.WriteLine(responseString);
                JObject jObject = JObject.Parse(responseString);
                string plateNumber = (string)jObject["plateNumber"];
                if (plateNumber.Equals(""))
                {
                    plateNumber = "-";
                }
                if (isLeftSide)
                {
                    if (isCarIn)
                    {
                        labelDigitInLeft.Text = plateNumber;
                    }
                    else
                    {
                        labelDigitOutLeft.Text = plateNumber;
                    }
                }
                else
                {
                    if (isCarIn)
                    {
                        labelDigitInRight.Text = plateNumber;
                    }
                    else
                    {
                        labelDigitOutRight.Text = plateNumber;
                    }
                }

                return plateNumber;
            }
            catch (WebException exception)
            {
                //string responseText;
                //var responseStream = exception.Response?.GetResponseStream();

                //if (responseStream != null)
                //{
                //    using (var reader = new StreamReader(responseStream))
                //    {
                //        responseText = reader.ReadToEnd();
                //        MessageBox.Show(responseText);
                //    }
                //}
            }
            return "";
        }

        //private void testDocBienSo()
        //{
        //    OpenFileDialog openFileDialog1 = new OpenFileDialog
        //    {
        //        InitialDirectory = @"E:\HINH_BIEN_SO\",
        //        Title = "Browse Files",

        //        CheckFileExists = true,
        //        CheckPathExists = true,

        //        DefaultExt = "txt",
        //        Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|All files (*.*)|*.*",
        //        FilterIndex = 2,
        //        RestoreDirectory = true,

        //        ReadOnlyChecked = true,
        //        ShowReadOnly = true
        //    };

        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        string fileName = openFileDialog1.SafeFileName;
        //        uploadCarNumberImage(fileName, true, true);
        //    }
        //}

        private string docBienSo()
        {
            // DocBienSo
            Bitmap bmpScreenshot = null;
            if (inputIsLeftSide())
            {
                bmpScreenshot = getBitMapFromCamera(pictureBoxCamera2);
            }
            else
            {
                bmpScreenshot = getBitMapFromCamera(pictureBoxCamera4);
            }
            string fileName = cardID + DateTime.Now.ToString("_yyyyMMdd_HHmmss_") + DateTime.Now.Ticks + ".jpg";
            saveBitmapToFile(bmpScreenshot, Constant.getCarNumberImageFolder(), fileName);
            bmpScreenshot.Dispose();
            return uploadCarNumberImage(fileName, inputIsLeftSide(), isCarIn());
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //testDocBienSo();
        }

        private void runPythonServer()
        {
            foreach (var process in Process.GetProcessesByName("Python"))
            {
                process.Kill();
            }

            string directory = @"E:\WORK\GIT\DOC BIEN SO XE\GIT\license_plate_recognition\";
            directory = mConfig.readDigitFolder + @"license_plate_recognition\";
            if (Directory.Exists(directory))
            {
                System.Environment.CurrentDirectory = directory;
                Process myProcess = new Process();
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.Arguments = "/c " + "python manage.py runserver";
                myProcess.EnableRaisingEvents = true;
                myProcess.Start();
            }
        }

        private void resetForm()
        {
            string userId = Program.CurrentUserID;
            this.Hide();
            var frm = new FormNhanVien();
            frm.ShowDialog();
            Program.CurrentUserID = userId;
            this.Close();
            this.Dispose();
            GC.Collect();
        }

        private void FormNhanVien_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            float scaleFactor = (float)GetFormArea(control.Size) / (float)_lastFormSize;
            ResizeFont(this.Controls, scaleFactor);
            _lastFormSize = GetFormArea(control.Size);

            foreach (Control cnt in this.Controls)
            {
                ResizeAll(cnt, base.Size);
            }
        }
    }
}

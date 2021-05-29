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
using System.Timers;
using ReaderB;
using System.Collections;
using CameraViewer;
using System.Text.RegularExpressions;
using SimpleLPR3;
using Image = System.Drawing.Image;
using System.Runtime.InteropServices;

namespace ParkingMangement.GUI
{
    public partial class FormNhanVien : Form
    {
        public readonly RawInput _rawinput;

        public string CurrentUserID;
        const bool CaptureOnlyInForeground = true;
        private string mCurrentCardID = "0";

        private DateTime oldUhfCardTime;
        private string rfidInput = "";
        private string portNameComReceiveInput = null;
        private string portNameComReaderInput = null;
        private string oldPortNameComReceiveInput = null;

        //const string cameraUrl = @"rtsp://admin:bmv333999@192.168.1.190:554/cam/realmonitor?channel=1&subtype=0&unicast=true&proto=Onvif";
        const string cameraUrl = @"rtsp://184.72.239.149/vod/mp4:BigBuckBunny_175k.mov";
        private string cameraUrl1 = cameraUrl;
        private string cameraUrl2 = cameraUrl;
        private string cameraUrl3 = cameraUrl;
        private string cameraUrl4 = cameraUrl;

        private string cameraCarUrl1 = cameraUrl;
        private string cameraCarUrl2 = cameraUrl;
        private string cameraCarUrl3 = cameraUrl;
        private string cameraCarUrl4 = cameraUrl;

        private string rfidIn = "";
        private string rfidOut = "";
        private string rfidCarIn = "";
        private string rfidCarOut = "";
        private string portNameComReceiveIn = "";
        private string portNameComReceiveOut = "";
        private string portNameComReaderLeft = "";
        private string portNameComReaderRight = "";
        private string portNameComReaderCarLeft = "";
        private string portNameComReaderCarRight = "";

        //private string imagePath1;
        //private string imagePath2;
        //private string imagePath3;
        //private string imagePath4;

        private int mCount = 0;

        SerialPort leftLedPort;
        SerialPort rightLedPort;
        SerialPort lostAvailablePort;

        private Config mConfig;

        private DataTable mListCarSurvive;
        private BindingSource mBindingSource;
        private bool mIsUseCostDeposit = true;
        private int mNoticeExpiredDate;
        private int mNoticeToBeExpireDate;
        private int mParkingTypeID;
        private int mCalculationTicketMonth;
        private int mExpiredTicketMonthTypeID;
        private int mBikeSpace;
        private int mCarSpace;
        private bool isUhfCard = false;
        private bool mIsUpdatingDB = false;
        private bool mIsFormActive = true;

        private Size oldSize;
        private const float LARGER_FONT_FACTOR = 1.5f;
        private const float SMALLER_FONT_FACTOR = 0.8f;

        //private bool mIsHasCarInOut = false;

        private int _lastFormSize;

        private Configuration config;
        private RunningPool runningPool = new RunningPool();

        Camera camera1;
        Camera camera2;
        Camera camera3;
        Camera camera4;
        //string[] options = {
        //        ":file-caching=0",
        //        ":live-caching=0",
        //        ":sout-mux-caching=0",
        //        ":network-caching=150",
        //        ":clock-jitte=0",
        //        ":clock-synchro=0"};
        string[] options = {
                ":network-caching=200"};

        //=======class============
        clsImagePlate ImagePlate;

        //========== WareLogic Read Digit =========
        struct LPEntry
        {
            public string fileName;
            public string plate;
        }

        ISimpleLPR _lpr;
        IProcessor _proc;
        string _curFile;
        Bitmap _curBitmap;
        List<Candidate> _curCands;

        List<string> files;
        int enumF;

        List<LPEntry> lps;

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

            mConfig = Util.getConfigFile();
            readConfigFile();

            new Thread(() =>
            {
                // Thread.CurrentThread.IsBackground = true;
                loadConfigInfoDB();
                CurrentUserID = Program.CurrentStaffUserID;


                // WareLogic Read Digit
                try
                {
                    EngineSetupParms setupP;
                    setupP.cudaDeviceId = -1; // Use CPU
                    setupP.enableImageProcessingWithGPU = true;
                    setupP.enableClassificationWithGPU = true;
                    setupP.maxConcurrentImageProcessingOps = 0;  // Use the default value.  

                    _lpr = SimpleLPR.Setup(setupP);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Unable to initialize the SimpleLPR library", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    throw;
                }

                files = new List<string>();
                lps = new List<LPEntry>();
            }).Start();
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
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
            labelParkingName.Text = ConfigDAO.GetParkingName(ConfigDAO.GetConfig());

            labelNhanVien.Text = UserDAO.GetUserNameByID(Program.CurrentStaffUserID);

            new Thread(() =>
            {
                // Thread.CurrentThread.IsBackground = true;
                axVLCPlugin1.Visible = false;
                axVLCPlugin2.Visible = false;
                axVLCPlugin3.Visible = false;
                axVLCPlugin4.Visible = false;

                axVLCPluginCar1.Visible = false;
                axVLCPluginCar2.Visible = false;
                axVLCPluginCar3.Visible = false;
                axVLCPluginCar4.Visible = false;

                cameraWindow1.Visible = false;
                cameraWindow2.Visible = false;
                cameraWindow3.Visible = false;
                cameraWindow4.Visible = false;

                if (!Constant.IS_NEW_CAMERA)
                {
                    axVLCPlugin1.Visible = true;
                    axVLCPlugin2.Visible = true;
                    axVLCPlugin3.Visible = true;
                    axVLCPlugin4.Visible = true;

                    configVLC(mConfig.ZoomCamera1, mConfig.ZoomCamera2,
                        mConfig.ZoomCamera3, mConfig.ZoomCamera4);                  

                    loadCameraVLC(axVLCPluginCar1, cameraCarUrl1);
                    loadCameraVLC(axVLCPluginCar2, cameraCarUrl2);
                    loadCameraVLC(axVLCPluginCar3, cameraCarUrl3);
                    loadCameraVLC(axVLCPluginCar4, cameraCarUrl4);

                    loadCameraVLC(axVLCPlugin1, cameraUrl1);
                    loadCameraVLC(axVLCPlugin2, cameraUrl2);
                    loadCameraVLC(axVLCPlugin3, cameraUrl3);
                    loadCameraVLC(axVLCPlugin4, cameraUrl4);
                }
                else
                {
                    cameraWindow1.Visible = true;
                    cameraWindow2.Visible = true;
                    cameraWindow3.Visible = true;
                    cameraWindow4.Visible = true;

                    config = new Configuration(Path.GetDirectoryName(Application.ExecutablePath));
                    config.providers.Load(Path.GetDirectoryName(Application.ExecutablePath));
                    // load cameras tree
                    config.LoadCameras();

                    openCameraWindow();
                }
            }).Start();

            new Thread(() =>
            {
                // Thread.CurrentThread.IsBackground = true;

                updateDataByTimer();
                //resetUhfByTimer();


                loadInfo();

                getDataFromUhfReader();

                oldSize = base.Size;

                CheckForIllegalCrossThreadCalls = false;

                //if (!mConfig.readDigitFolder.Equals(""))
                //{
                //    runPythonServer();
                //}
            }).Start();

            readPegasusReaderCOM();
        }

        private void OnTimedEventTest(object source, ElapsedEventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {
                string cardID = "3113963712";
                if (rfidInput == rfidIn)
                {
                    rfidInput = rfidOut;
                }
                else
                {
                    rfidInput = rfidIn;
                }
                bool isInputLeftSide = inputIsLeftSide(cardID);
                readCardEvent(cardID, isInputLeftSide);
            }));
        }

        private void testReadCard()
        {
            rfidInput = rfidIn;
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventTest);
            aTimer.Interval = 1 * 800;
            aTimer.Enabled = true;
            aTimer.Start();
        }

        

        private void readPegasusReaderCOM()
        {
            if (Program.readerLeftSerialPort != null && Program.readerLeftSerialPort.IsOpen)
            {
                Program.readerLeftSerialPort.DataReceived += new SerialDataReceivedEventHandler(portComReaderLeft_DataReceived);
            }

            if (Program.readerRightSerialPort != null && Program.readerRightSerialPort.IsOpen)
            {
                Program.readerRightSerialPort.DataReceived += new SerialDataReceivedEventHandler(portComReaderRight_DataReceived);
            }

            if (Program.readerCarLeftSerialPort != null && Program.readerCarLeftSerialPort.IsOpen)
            {
                Program.readerCarLeftSerialPort.DataReceived += new SerialDataReceivedEventHandler(portComReaderCarLeft_DataReceived);
            }

            if (Program.readerCarRightSerialPort != null && Program.readerCarRightSerialPort.IsOpen)
            {
                Program.readerCarRightSerialPort.DataReceived += new SerialDataReceivedEventHandler(portComReaderCarRight_DataReceived);
            }
        }

        private void DataReceivedEvent(object sender)
        {
            if (!mIsFormActive && Application.OpenForms.Count > 2)
            {
                return;
            }

            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadLine();
            string cardID = data.Trim();
            cardID = Regex.Replace(cardID, @"[^\u0009\u000A\u000D\u0020-\u007E]", "");
            portNameComReaderInput = sp.PortName;
            Program.oldUhfCardId = "";
            bool isInputLeftSide = inputIsLeftSide(cardID);
            readCardEvent(cardID, isInputLeftSide);
        }

        private void portComReaderLeft_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DataReceivedEvent(sender);
        }

        private void portComReaderRight_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DataReceivedEvent(sender);
        }

        private void portComReaderCarLeft_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DataReceivedEvent(sender);
        }

        private void portComReaderCarRight_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DataReceivedEvent(sender);
        }

        public void openCameraWindow()
        {
            string name1 = "cam1";
            // get camera
            camera1 = config.GetCameraByName(name1);

            // add camera to running pool
            if (runningPool.Add(camera1))
            {
                cameraWindow1.Camera = camera1;
            }

            string name2 = "cam2";
            // get camera
            camera2 = config.GetCameraByName(name2);

            // add camera to running pool
            if (runningPool.Add(camera2))
            {
                cameraWindow2.Camera = camera2;
            }

            string name3 = "cam3";
            // get camera
            camera3 = config.GetCameraByName(name3);

            // add camera to running pool
            if (runningPool.Add(camera3))
            {
                cameraWindow3.Camera = camera3;
            }

            string name4 = "cam4";
            // get camera
            camera4 = config.GetCameraByName(name4);

            // add camera to running pool
            if (runningPool.Add(camera4))
            {
                cameraWindow4.Camera = camera4;
            }
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
                case Keys.Z:
                    //nextFile();
                    //testReadCard();
                    break;
                case Keys.Space:
                    //if (tbRFIDCardID.Text.Equals("") && !cardID.Equals("") && KiemTraXeChuaRa())
                    //{
                    //    updateDigitCarIn();
                    //} else
                    //{
                    //    resetData();
                    //}
                    //Program.closeUhfReader();
                    //Program.initUhfReader();
                    //oldUhfCardTime = DateTime.Now;
                    if (Program.oldUhfCardId != null && !Program.oldUhfCardId.Equals(""))
                    {
                        resetAllData();
                    }
                    else
                    {
                        if (!labelDigitInLeft.Focused && !labelDigitInRight.Focused)
                        {
                            resetAllData();
                        }
                    }
                    tbRFIDCardID.Focus();
                    //readDigitWareLogic();
                    break;
                case Keys.Q:
                    rbLeftSide.Checked = true;
                    tbRFIDCardID.Focus();
                    break;
                case Keys.W:
                    rbRightSide.Checked = true;
                    tbRFIDCardID.Focus();
                    break;
                case Keys.F1:
                    //case Keys.ControlKey:
                    changeInOutSetting(true);
                    break;
                case Keys.F2:
                    openFormTraCuuTheThang();
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
                case Keys.F6:
                    openFormQuanLyXeTon();
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
                    if (!mConfig.signalOpenBarieInMotorbike.Equals(""))
                    {
                        openBarieInMotorbike();
                    }
                    else
                    {
                        openBarieIn();
                    }
                    AutoClosingMessageBox.Show("Barie đã mở", "", 500);
                    //MessageBox.Show("Barie đã mở");
                    break;
                case Keys.Down:
                    closeBarieIn();
                    closeBarieInMotorbike();
                    AutoClosingMessageBox.Show("Barie đã đóng", "", 500);
                    //MessageBox.Show("Barie đã đóng");
                    break;
                case Keys.Left:
                    if (!mConfig.signalOpenBarieOutMotorbike.Equals(""))
                    {
                        openBarieOutMotorbike();
                    }
                    else
                    {
                        openBarieOut();
                    }
                    AutoClosingMessageBox.Show("Barie đã mở", "", 500);
                    //MessageBox.Show("Barie đã mở");
                    break;
                case Keys.Right:
                    //    var formLogout = new FormLogout();
                    //    formLogout.formNhanVien = this;
                    //    formLogout.Show();
                    //    break;
                    closeBarieOut();
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

        private void openFormQuanLyXeTon()
        {
            string functionId = Constant.FUNCTION_ID_NHAN_VIEN;
            string[] listFunctionSec = FunctionalDAO.GetFunctionSecByID(functionId).Split(',');
            if (listFunctionSec.Contains(Constant.NODE_VALUE_XEM_BAO_CAO_F7.ToString()))
            {
                Form formQuanLyXeTon = new FormQuanLyXeTon();
                formQuanLyXeTon.Show();
            }
            else
            {
                MessageBox.Show(Constant.sMessageCanNotSeeReport);
            }
        }

        private void openFormTraCuuTheThang()
        {
            string functionId = Constant.FUNCTION_ID_NHAN_VIEN;
            string[] listFunctionSec = FunctionalDAO.GetFunctionSecByID(functionId).Split(',');
            if (listFunctionSec.Contains(Constant.NODE_VALUE_XEM_BAO_CAO_F7.ToString()))
            {
                Form formTraCuuTheThang = new FormTraCuuTheThang();
                formTraCuuTheThang.Show();
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

        private void setTopVisibleForCamera(AxVLCPlugin2 axVLCPlugin, bool isVisible)
        {
            axVLCPlugin.Visible = isVisible;
            if (isVisible)
            {
                axVLCPlugin.BringToFront();
            } else
            {
                axVLCPlugin.SendToBack();
            }
        }

        private void checkForShowCarCamera(string cardID, bool isInputLeftSide)
        {
            bool isShowLeftCarCam = false;
            bool isShowRightCarCam = false;
            if ((!mConfig.cameraCarUrl1.Equals("") || !mConfig.cameraCarUrl2.Equals("")) && isInputLeftSide)
            {
                if (portNameComReceiveInput != null && mConfig.isUsingUhf.Equals("yes") && (cardID.Length == 53))
                {
                    isShowLeftCarCam = portNameComReceiveInput.Equals(portNameComReceiveIn);
                }
                else if (portNameComReaderInput != null)
                {
                    isShowLeftCarCam = portNameComReaderInput.Equals(portNameComReaderCarLeft);
                }
                else if (!rfidInput.Equals("Global Keyboard"))
                {
                    isShowLeftCarCam = rfidInput.Equals(rfidCarIn);
                }

                setTopVisibleForCamera(axVLCPluginCar1, isShowLeftCarCam);
                setTopVisibleForCamera(axVLCPluginCar2, isShowLeftCarCam);
            }

            if ((!mConfig.cameraCarUrl3.Equals("") || !mConfig.cameraCarUrl4.Equals("")) && !isInputLeftSide)
            {
                if (portNameComReceiveInput != null && mConfig.isUsingUhf.Equals("yes") && (cardID.Length == 53))
                {
                    isShowRightCarCam = portNameComReceiveInput.Equals(portNameComReceiveOut);
                }
                else if (portNameComReaderInput != null)
                {
                    isShowRightCarCam = portNameComReaderInput.Equals(portNameComReaderCarRight);
                }
                else if (!rfidInput.Equals("Global Keyboard"))
                {
                    isShowRightCarCam = rfidInput.Equals(rfidCarOut);
                }

                setTopVisibleForCamera(axVLCPluginCar3, isShowRightCarCam);
                setTopVisibleForCamera(axVLCPluginCar4, isShowRightCarCam);
            }
        }

        Stopwatch _ProcessTimer = new Stopwatch();

        private void readCardEvent(string cardID, bool isInputLeftSide)
        {
            this.BringToFront();
            if (mIsUpdatingDB)
            {
                return;
            }
            _ProcessTimer = new Stopwatch();
            _ProcessTimer.Start();
            checkForShowCarCamera(cardID, isInputLeftSide);
           
            mCurrentCardID = cardID;
            isShowExpiredMessage = false;
            Program.isHasCarInOut = true;

            if (!cardID.Equals(""))
            {
                resetDataOneSide(false, null);
                CardDTO dtCommonCard = CardDAO.GetNotDeletedCardModelByID(cardID);
                if (dtCommonCard != null)
                {
                    TicketMonthDTO dtTicketCard = TicketMonthDAO.GetDTODataByID(cardID);
                    string cardTypeID = PartDAO.GetCardTypeByID(dtCommonCard.Type);
                    if (cardTypeID.Equals(CardTypeDTO.CARD_TYPE_TICKET_MONTH) && dtTicketCard == null)
                    {
                        checkUsingCardForShowError(cardID);
                    }
                    else
                    {
                        if (isInputLeftSide)
                        {
                            labelCardIDLeft.Text = dtCommonCard.Identify + "";
                        }
                        else
                        {
                            labelCardIDRight.Text = dtCommonCard.Identify + "";
                        }

                        checkForSaveToDBAsync(dtCommonCard, dtTicketCard, cardID, isInputLeftSide);
                    }
                }
                else
                {
                    checkUsingCardForShowError(cardID);
                }
                new Thread(() =>
                {
                    // Thread.CurrentThread.IsBackground = true;

                    mListCarSurvive = CarDAO.GetListCarSurvive();
                    Invoke(new MethodInvoker(() =>
                    {
                        dgvThongKeXeTrongBai.DataSource = mListCarSurvive;
                    }));
                }).Start();

            } else
            {
                //mIsUpdatingDB = false;
            }
            portNameComReceiveInput = null;
            portNameComReaderInput = null;
            oldPortNameComReceiveInput = null;            
        }

        private void checkUsingCardForShowError(string cardID)
        {
            if ((cardID.Length == 8 && !isUhfCard) || (cardID.Length == 10 && !isUhfCard) || cardID.Length == 53)
            {
                labelError.Text = Constant.sMessageCardIdNotExist;
                Util.playAudio(Constant.notused);
            }
        }

        private void timerCurrentTime_Tick(object sender, EventArgs e)
        {
            //labelDateOut.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void checkForOpenBarie(DataTable dtLastCar, string cardID, bool isInputLeftSide)
        {
            if (cardID.Length == 53)
            {
                isUhfCard = true;
            }

            if (isInputLeftSide)
            {
                checkForOpenBarieIn(isUhfCard, cardID);
            }
            else
            {
                checkForOpenBarieOut(isUhfCard, cardID);
            }
            isUhfCard = false;
        }

        private bool checkForSaveToDBAsync(CardDTO dtCommonCard, TicketMonthDTO dtTicketCard, string cardID, bool isInputLeftSide)
        {
            bool isTicketCard = dtTicketCard != null;

            if (isInputLeftSide)
            {
                labelDigitRegisterLeft.Text = "";
                labelCustomerNameLeft.Text = "-";

                labelPartNameTypeNameLeft.Text = CardDAO.GetPartName_TypeNameByCardID(cardID);

                if (isTicketCard)
                {
                    labelCustomerNameLeft.Text = dtTicketCard.CustomerName;
                    labelDigitRegisterLeft.Text = dtTicketCard.Digit;
                }
            }
            else
            {
                labelDigitRegisterRight.Text = "";
                labelCustomerNameRight.Text = "-";

                labelPartNameTypeNameRight.Text = CardDAO.GetPartName_TypeNameByCardID(cardID);

                if (isTicketCard)
                {
                    labelCustomerNameRight.Text = dtTicketCard.CustomerName;
                    labelDigitRegisterRight.Text = dtTicketCard.Digit;
                }
            }

            bool isLockedCard = false;
            if (!dtCommonCard.IsUsing.Equals("1"))
            {
                isLockedCard = true;
                Util.playAudio(Constant.locked);
                MessageBox.Show(Constant.sMessageCardIsLost);
                if (isCarIn(cardID, isInputLeftSide))
                {
                    //mIsUpdatingDB = false;
                    return false;
                }
            }
            DataTable dtLastCar = CarDAO.GetLastCarByID(cardID);

            bool isKiemTraXeChuaRa = KiemTraXeChuaRa(dtLastCar);
            bool isKiemTraCapNhatXeVao = KiemTraCapNhatXeVao(dtLastCar, cardID);
            bool isKiemTraCapNhatXeRa = KiemTraCapNhatXeRa(dtLastCar, cardID);
            if (isCarIn(cardID, isInputLeftSide))
            {
                if (isKiemTraXeChuaRa)
                {
                    if (!isKiemTraCapNhatXeVao)
                    {
                        labelError.Text = "Thẻ này chưa được quẹt đầu ra";
                        Program.oldUhfCardId = "";
                        resetPictureBoxImage1(cardID, isInputLeftSide);
                        resetPictureBoxImage2(cardID, isInputLeftSide);
                        tbRFIDCardID.Focus();
                        //mIsUpdatingDB = false;
                        return false;
                    }
                }

                loadImage1ToPictureBox(cardID, isInputLeftSide);
                loadImage2ToPictureBox(cardID, isInputLeftSide);
                string imagePath1 = saveImage1ToFile(cardID, isInputLeftSide);
                string imagePath2 = saveImage2ToFile(cardID, isInputLeftSide);

                if (!isLockedCard)
                {
                    checkExpiredTicket(dtTicketCard, isTicketCard);
                }

                if (isKiemTraXeChuaRa)
                {
                    if (isKiemTraCapNhatXeVao)
                    {
                        string inputDigit = docBienSo(cardID, isInputLeftSide);
                        updateCarIn(dtTicketCard, dtLastCar, inputDigit, cardID, isInputLeftSide, imagePath1, imagePath2);
                    }
                }
                else
                {
                    string inputDigit = docBienSo(cardID, isInputLeftSide);
                    insertCarInAsync(dtCommonCard, dtTicketCard, inputDigit, cardID, isInputLeftSide, imagePath1, imagePath2);
                    _ProcessTimer.Stop();
                    Console.WriteLine("Tape in : " + _ProcessTimer.ElapsedMilliseconds);
                }
            }
            else
            {
                if (isKiemTraXeChuaRa || isKiemTraCapNhatXeRa)
                {
                    loadCarInData(dtLastCar, cardID, isInputLeftSide);
                    if (!isLockedCard)
                    {
                        checkExpiredTicket(dtTicketCard, isTicketCard);
                    }

                    string inputDigit = docBienSo(cardID, isInputLeftSide);
                    updateCarOutAsync(dtTicketCard, dtLastCar, isKiemTraCapNhatXeRa, inputDigit, cardID, isInputLeftSide);
                }
                else
                {
                    tbRFIDCardID.Focus();
                    labelError.Text = "Thẻ này chưa được quẹt đầu vào";
                    Program.oldUhfCardId = "";
                    return false;
                }
            }
            checkForOpenBarie(dtLastCar, cardID, isInputLeftSide);
            return true;
        }

        bool isShowExpiredMessage = false;
        private void checkExpiredTicket(TicketMonthDTO dtTicketCard, bool isTicketCard)
        {
            if (isTicketCard)
            {
                DateTime? expirationDate = dtTicketCard.ExpirationDate;
                double totalDaysLeft = ((DateTime)expirationDate - DateTime.Today).TotalDays;
                if (expirationDate != null)
                {
                    if (totalDaysLeft < 0)
                    {
                        bool isExpired = false;
                        int currentDay = (int)System.DateTime.Now.Day;
                        if (!mIsUseCostDeposit)
                        {
                            // vé tháng đã hết hạn không cọc
                            isExpired = true;
                        }
                        else
                        {
                            if (-totalDaysLeft >= mNoticeToBeExpireDate - 1 && -totalDaysLeft < mNoticeExpiredDate - 1)
                            {
                                // vé tháng sắp hết hạn có cọc
                                isShowExpiredMessage = true;
                                labelError.Text = Constant.sMessageNearExpiredCard;
                                Util.playAudio(Constant.tobeexpired);
                            }
                            else if (-totalDaysLeft >= mNoticeExpiredDate - 1)
                            {
                                // vé tháng đã hết hạn có cọc
                                isExpired = true;
                            }
                        }

                        if (isExpired)
                        {
                            isShowExpiredMessage = true;
                            labelError.Text = Constant.sMessageExpiredCard;
                            Util.playAudio(Constant.expired);
                        }
                    }
                    else if (totalDaysLeft <= 31 - mNoticeToBeExpireDate)
                    {
                        if (!mIsUseCostDeposit)
                        {
                            // vé tháng sắp hết hạn không cọc
                            isShowExpiredMessage = true;
                            labelError.Text = Constant.sMessageNearExpiredCard;
                            Util.playAudio(Constant.tobeexpired);
                        }
                    }
                }
            }
        }

        private void updateDigitCarIn(string digit)
        {
            if (!digit.Equals(""))
            {
                CarDAO.UpdateDigitIn(mCurrentCardID, digit);
                labelDigitInRight.Text = "";
            }
            DataTable dtTicketCard = TicketMonthDAO.GetDataByID(mCurrentCardID);
            bool isInputLeftSide = inputIsLeftSide(mCurrentCardID);
            if (dtTicketCard != null && dtTicketCard.Rows.Count > 0)
            {
                updateScreenForCarIn(true, mCurrentCardID, isInputLeftSide);
            }
            else
            {
                updateScreenForCarIn(false, mCurrentCardID, isInputLeftSide);
            }
        }

        private void checkForOpenBarieIn(bool isUhfCard, string cardID)
        {
            if (mConfig.signalOpenBarieIn.Equals("") && mConfig.signalOpenBarieInMotorbike.Equals(""))
            {
                return;
            }

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

        private void checkForOpenBarieOut(bool isUhfCard, string cardID)
        {
            if (mConfig.signalOpenBarieOut.Equals("") && mConfig.signalOpenBarieOutMotorbike.Equals(""))
            {
                return;
            }

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

        private void insertCarInAsync(CardDTO dtCommonCard, TicketMonthDTO dtTicketCard, string inputDigit, string cardID, bool isInputLeftSide, string imagePath1, string imagePath2)
        {
            bool isTicketMonthCard = dtTicketCard != null;
            //checkForOpenBarieIn();

            CarDTO carDTO = new CarDTO();
            carDTO.Id = cardID;
            carDTO.TimeStart = DateTime.Now;
            carDTO.IdIn = Program.CurrentStaffUserID;
            string partID = dtCommonCard.Type;
            if (dtTicketCard != null)
            {
                partID = dtTicketCard.IdPart;
            }
            carDTO.IdPart = partID;
            carDTO.Images = imagePath1;
            carDTO.Images2 = imagePath2;
            carDTO.Computer = Environment.MachineName;
            carDTO.Account = Program.CurrentStaffUserID;
            carDTO.DateUpdate = DateTime.Now;
            if (!inputDigit.Equals(""))
            {
                carDTO.DigitIn = inputDigit;
            }

            if (isTicketMonthCard)
            {
                carDTO.IdTicketMonth = cardID;
                carDTO.Digit = dtTicketCard.Digit;
            }

            mIsUpdatingDB = true;
            updateScreenForCarIn(isTicketMonthCard, cardID, isInputLeftSide);
            if (!CarDAO.Insert(carDTO))
            {
                mIsUpdatingDB = false;
                resetDataOneSide(true, isInputLeftSide);
                MessageBox.Show(Constant.sMessageCardNotUpdate);
                return;
            }
            mIsUpdatingDB = false;

            // play audio
            if (!isShowExpiredMessage)
            {
                Util.playAudio(Constant.goIn);
            }           

            // send data to server
            //WaitSyncCarInDAO.Insert(CarDAO.GetLastIdentifyByID(cardID));
            //sendOrderDataToServer();
        }

        private void updateCarIn(TicketMonthDTO dtTicketCard, DataTable dtLastCar, string inputDigit, string cardID, bool isInputLeftSide, string imagePath1, string imagePath2)
        {
            bool isTicketMonthCard = dtTicketCard != null;
            if (dtLastCar != null && dtLastCar.Rows.Count > 0)
            {
                int identify = dtLastCar.Rows[0].Field<int>("Identify");
                CarDTO carDTO = new CarDTO();
                carDTO.Identify = identify;
                carDTO.TimeStart = DateTime.Now;
                carDTO.IdIn = Program.CurrentStaffUserID;
                carDTO.Images = imagePath1;
                carDTO.Images2 = imagePath2;
                carDTO.Computer = Environment.MachineName;
                carDTO.Account = Program.CurrentStaffUserID;
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

                mIsUpdatingDB = true;
                if (!CarDAO.UpdateCarIn(carDTO))
                {
                    resetDataOneSide(true, isInputLeftSide);
                    mIsUpdatingDB = false;
                    MessageBox.Show(Constant.sMessageCardNotUpdate);                    
                    return;
                }
                mIsUpdatingDB = false;

                updateScreenForCarIn(isTicketMonthCard, cardID, isInputLeftSide);
            }
        }

        private void updateScreenForCarIn(bool isTicketMonthCard, string cardID, bool isInputLeftSide)
        {
            if (isInputLeftSide)
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
                    if (mCalculationTicketMonth == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                    {
                        labelCostRight.Text = "VE THANG";
                    }
                }
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (!isInputLeftSide)
                {
                    labelCostRight.Text = "-";
                    labelMoiVao.Text = "";
                    labelMoiRa.Text = Constant.sLabelMoiVao;

                    //pictureBoxImage1.Image = Properties.Resources.ic_logo;
                    //pictureBoxImage2.Image = Properties.Resources.ic_logo;

                    if (isTicketMonthCard)
                    {
                        if (mCalculationTicketMonth == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
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
                        if (mCalculationTicketMonth == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
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
                    if (mCalculationTicketMonth == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                    {
                        labelCostLeft.Text = "VE THANG";
                    }
                }
            }
        }

        private void showCostToScreen(CarDTO carDTO, bool isTicketMonthCard, Label labelCost)
        {
            if (isTicketMonthCard && mCalculationTicketMonth == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
            {
                labelCost.Text = "VE THANG";
            }
            else if (carDTO.Cost != null)
            {
                labelCost.Text = Util.formatNumberAsMoney((int)carDTO.Cost);
            }
            else
            {
                labelCost.Text = "-";
            }
        }

        private async Task updateCarOutAsync(TicketMonthDTO dtTicketCard, DataTable dtLastCar, bool isUpdateCarOut, string inputDigit, string cardID, bool isInputLeftSide)
        {
            bool isTicketMonthCard = dtTicketCard != null;
            if (dtLastCar != null && dtLastCar.Rows.Count > 0)
            {
                DateTime timeIn = dtLastCar.Rows[0].Field<DateTime>("TimeStart");
                DateTime timeOut = DateTime.Now;
                if (isUpdateCarOut)
                {
                    timeOut = dtLastCar.Rows[0].Field<DateTime>("TimeEnd");
                }

                string digitIn = dtLastCar.Rows[0].Field<string>("DigitIn");
                string digit = dtLastCar.Rows[0].Field<string>("Digit");
                if (isInputLeftSide)
                {
                    labelDigitInLeft.Text = digitIn;
                    labelDateInLeft.Text = timeIn.ToString("dd/MM/yyyy");
                    labelTimeInLeft.Text = timeIn.ToString("HH:mm");
                    labelDateOutLeft.Text = timeOut.ToString("dd/MM/yyyy");
                    labelTimeOutLeft.Text = timeOut.ToString("HH:mm");
                    if (isTicketMonthCard)
                    {
                        labelDigitRegisterLeft.Text = dtTicketCard.Digit;
                    }
                }
                else
                {
                    labelDigitInRight.Text = digitIn;
                    labelDateInRight.Text = timeIn.ToString("dd/MM/yyyy");
                    labelTimeInRight.Text = timeIn.ToString("HH:mm");
                    labelDateOutRight.Text = timeOut.ToString("dd/MM/yyyy");
                    labelTimeOutRight.Text = timeOut.ToString("HH:mm");
                    if (isTicketMonthCard)
                    {
                        labelDigitRegisterRight.Text = dtTicketCard.Digit;
                    }
                }

                int identify = dtLastCar.Rows[0].Field<int>("Identify");
                CarDTO carDTO = new CarDTO();
                carDTO.Identify = identify;
                carDTO.Id = cardID;
                carDTO.TimeEnd = timeOut;
                carDTO.IdOut = Program.CurrentStaffUserID;
                if (!inputDigit.Equals(""))
                {
                    carDTO.DigitOut = inputDigit;
                }

                if (isTicketMonthCard)
                {
                    // VE THANG
                    if (mCalculationTicketMonth == ConfigDTO.CALCULATION_TICKET_MONTH_NO)
                    {
                        carDTO.Cost = 0;
                    }
                    else
                    {
                        if (!isUpdateCarOut)
                        {
                            carDTO.Cost = tinhTienGiuXe(dtLastCar, cardID);
                        }
                        else
                        {
                            carDTO.Cost = dtLastCar.Rows[0].Field<int>("Cost");
                        }

                    }

                    switch (mExpiredTicketMonthTypeID)
                    {
                        case Constant.LOAI_HET_HAN_CHI_CANH_BAO_HET_HAN:
                            break;
                        case Constant.LOAI_HET_HAN_TINH_TIEN_NHU_VANG_LAI:
                        default:
                            carDTO.Cost = tinhTienGiuXe(dtLastCar, cardID);
                            isTicketMonthCard = false;
                            break;
                    }
                }
                else
                {
                    // VE VANG LAI
                    if (!isUpdateCarOut)
                    {
                        carDTO.Cost = tinhTienGiuXe(dtLastCar, cardID);
                    }
                    else
                    {
                        carDTO.Cost = dtLastCar.Rows[0].Field<int>("Cost");
                    }
                }

                int inOutType = mConfig.inOutType;

                if (inOutType == ConfigDTO.TYPE_OUT_IN)
                {
                    labelCostLeft.Text = "-";
                    labelMoiVao.Text = Constant.sLabelMoiRa;
                    labelMoiRa.Text = "";

                    showCostToScreen(carDTO, isTicketMonthCard, labelCostLeft);
                }
                else if (inOutType == ConfigDTO.TYPE_OUT_OUT)
                {
                    if (isInputLeftSide)
                    {
                        labelCostLeft.Text = "-";
                        labelMoiVao.Text = Constant.sLabelMoiRa;
                        labelMoiRa.Text = "";

                        showCostToScreen(carDTO, isTicketMonthCard, labelCostLeft);
                    }
                    else
                    {
                        labelCostRight.Text = "-";
                        labelMoiVao.Text = "";
                        labelMoiRa.Text = Constant.sLabelMoiRa;

                        showCostToScreen(carDTO, isTicketMonthCard, labelCostRight);
                    }
                }
                else
                {
                    labelCostRight.Text = "-";
                    labelMoiVao.Text = "";
                    labelMoiRa.Text = Constant.sLabelMoiRa;

                    showCostToScreen(carDTO, isTicketMonthCard, labelCostRight);
                }

                // show cost to LED
                showCostToLed(carDTO.Cost + "", isTicketMonthCard, cardID, isInputLeftSide);

                if (!isUpdateCarOut)
                {
                    string imagePath3 = saveImage3ToFile(cardID, isInputLeftSide);
                    string imagePath4 = saveImage4ToFile(cardID, isInputLeftSide);

                    carDTO.Images3 = imagePath3;
                    carDTO.Images4 = imagePath4;
                    carDTO.Computer = Environment.MachineName;
                    carDTO.Account = Program.CurrentStaffUserID;
                    carDTO.DateUpdate = DateTime.Now;                   

                    //await Task.Run(() =>
                    //{
                    //    if (!CarDAO.UpdateCarOut(carDTO))
                    //    {
                    //        resetDataOneSide(true, isInputLeftSide);
                    //        MessageBox.Show(Constant.sMessageCardNotUpdate);
                    //        return;
                    //    }
                    //});

                    mIsUpdatingDB = true;
                    await Task.Run(() =>
                    {                       
                        if (!CarDAO.UpdateCarOut(carDTO))
                        {
                            mIsUpdatingDB = false;
                            resetDataOneSide(true, isInputLeftSide);
                            MessageBox.Show(Constant.sMessageCardNotUpdate);      
                            return;
                        }
                        _ProcessTimer.Stop();
                        Console.WriteLine("Tape out : " + _ProcessTimer.ElapsedMilliseconds);
                        mIsUpdatingDB = false;

                        // play audio
                        string compareInputDigit = inputDigit.Replace("-", "").Replace(".", "").Replace(" ", "");
                        compareInputDigit = compareInputDigit.Substring(Math.Max(0, compareInputDigit.Length - 5));

                        string compareDigitIn = digitIn.Replace("-", "").Replace(".", "").Replace(" ", "");
                        compareDigitIn = compareDigitIn.Substring(Math.Max(0, compareDigitIn.Length - 5));

                        string compareDigit = digit.Replace("-", "").Replace(".", "").Replace(" ", "");
                        compareDigit = compareDigit.Substring(Math.Max(0, compareDigit.Length - 5));

                        if (isTicketMonthCard && !isShowExpiredMessage)
                        {
                            if (compareInputDigit.Length > 0 && (compareInputDigit.Equals(compareDigitIn) || compareInputDigit.Equals(compareDigit)))
                            {
                                //Util.playAudio(Constant.goOut);
                            }
                            else
                            {
                                labelError.Text = "Biển số không khớp hoặc không đọc được!";
                            }
                            Util.playAudio(Constant.goOut);
                        }

                        if (!isTicketMonthCard)
                        {
                            if (compareInputDigit.Length > 0 && compareInputDigit.Equals(compareDigitIn))
                            {
                                playCostToAudio(carDTO.Cost.ToString());
                                Util.playAudio(Constant.goOut);
                            }
                            else
                            {
                                labelError.Text = "Biển số không khớp hoặc không đọc được!";
                                playCostToAudio(carDTO.Cost.ToString());
                            }
                        }
                    });
                } else
                {
                    //mIsUpdatingDB = false;
                }
            } else
            {
                //mIsUpdatingDB = false;
            }  
        }

        private void playCostToAudio(string cost)
        {
            ArrayList numberList = Util.ChuyenSo(cost);
            foreach (string item in numberList)
            {
                Util.playAudio(item);
                Thread.Sleep(700);
            }
        }

        private void loadCarInData(DataTable dtLastCar, string cardID, bool isInputLeftSide)
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
                        if (isInputLeftSide)
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
                        if (isInputLeftSide)
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

        private bool KiemTraXeChuaRa(DataTable dtLastCar)
        {
            if (dtLastCar != null && dtLastCar.Rows.Count > 0)
            {
                DateTime? idIn = dtLastCar.Rows[0].Field<DateTime?>("TimeStart");
                DateTime? idOut = dtLastCar.Rows[0].Field<DateTime?>("TimeEnd");
                if (idIn != null && idOut == null)
                {
                    return true;
                }
            }
            return false;
        }
        private bool KiemTraCapNhatXeVao(DataTable dtLastCar, string cardID)
        {
            if (dtLastCar != null && dtLastCar.Rows.Count > 0)
            {
                DateTime? idIn = dtLastCar.Rows[0].Field<DateTime?>("TimeStart");
                DateTime? idOut = dtLastCar.Rows[0].Field<DateTime?>("TimeEnd");
                if (idIn != null && idOut == null)
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

        private bool KiemTraCapNhatXeRa(DataTable dtLastCar, string cardID)
        {
            if (dtLastCar != null && dtLastCar.Rows.Count > 0)
            {
                DateTime? idIn = dtLastCar.Rows[0].Field<DateTime?>("TimeStart");
                DateTime? idOut = dtLastCar.Rows[0].Field<DateTime?>("TimeEnd");
                if (idIn != null && idOut != null)
                {
                    string lastCardId = dtLastCar.Rows[0].Field<string>("ID");
                    if (cardID.Equals(lastCardId))
                    {
                        double longTime = Util.getMillisecondBetweenTwoDate(idOut, DateTime.Now);
                        if (longTime < 60000)
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
            //float reduceSizePercent = 0.5f;
            int compressedQuality = 25;

            string path = Constant.getSharedImageFolder() + Constant.getCurrentDateString();
            Directory.CreateDirectory(path);
            //Util.ShareFolder(path, "Test Share", "This is a Test Share");
            Directory.SetCurrentDirectory(path);
            try
            {
                axVLCPlugin.video.takeSnapshot();
            }
            catch (Exception e)
            {

            }
            string originalFileName = Util.NewestFileofDirectory(path);


            //if (isCarIn())
            //{
            //Bitmap bmpScreenshot = getBitMapFromCamera(axVLCPlugin);
            //pictureBox.Image = bmpScreenshot;
            //zoomImageShowToPictureBox(originalFileName, pictureBox);
            //}

            try
            {
                string compressedFileName = mCurrentCardID + DateTime.Now.ToString("_yyyyMMdd_HHmmss_") + DateTime.Now.Ticks + ".jpg";
                FileStream stream = new FileStream(originalFileName, FileMode.Open, FileAccess.Read);
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                //System.Drawing.Image resizeImage = Util.Resize(img, reduceSizePercent);
                string destImagePath = path + @"\" + compressedFileName;
                Util.SaveJpeg(destImagePath, img, compressedQuality);
                img.Dispose();
                stream.Dispose();
                File.Delete(originalFileName);
                return Constant.getCurrentDateString() + @"\" + compressedFileName;
                //return Constant.getCurrentDateString() + @"\" + originalFileName;
            }
            catch (Exception e)
            {

            }
            return "";
        }
        private string getPathFromSnapshotThumbnail(Bitmap bitmap, bool isCarIn, int index)
        {
            string path = Constant.getSharedImageFolder() + Constant.getCurrentDateString() + @"\";
            Directory.CreateDirectory(path);

            try
            {
                string lane = "Out";
                if (isCarIn)
                {
                    lane = "In";
                }
                string compressedFileName = mCurrentCardID + DateTime.Now.ToString("_yyyyMMdd_HHmmss_fff_") + lane + index + ".jpg";
                saveBitmapToFile(bitmap, path, compressedFileName);
                return Constant.getCurrentDateString() + @"\" + compressedFileName;
            }
            catch (Exception e)
            {

            }
            return "";
        }

        private void zoomImageShowToPictureBox(string filePath, PictureBox pictureBox)
        {
            if (pictureBox != null && File.Exists(filePath))
            {
                try
                {
                    //System.Drawing.Image img = System.Drawing.Image.FromFile(filePath);
                    byte[] bytes = File.ReadAllBytes(filePath);
                    MemoryStream ms = new MemoryStream(bytes);
                    Image img = Image.FromStream(ms);
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

        private void resetPictureBoxImage1(string cardID, bool isInputLeftSide)
        {
            PictureBox pictureBox = pictureBoxImage1;
            int inOutType = mConfig.inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                pictureBox = pictureBoxImage3;
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (inputIsRightSide(cardID))
                {
                    pictureBox = pictureBoxImage3;
                }
            }

            if (isCarIn(cardID, isInputLeftSide))
            {
                pictureBox.Image = Properties.Resources.ic_logo;
            }
        }

        private void resetPictureBoxImage2(string cardID, bool isInputLeftSide)
        {
            PictureBox pictureBox = pictureBoxImage2;
            int inOutType = mConfig.inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                pictureBox = pictureBoxImage4;
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (inputIsRightSide(cardID))
                {
                    pictureBox = pictureBoxImage4;
                }
            }

            if (isCarIn(cardID, isInputLeftSide))
            {
                pictureBox.Image = Properties.Resources.ic_logo;
            }
        }

        private void loadCameraVLC(AxVLCPlugin2 axVLCPlugin, String cameraUrl)
        {
            if (cameraUrl.Length > 0)
            {
                try
                {
                    axVLCPlugin.playlist.add(cameraUrl, "1", options);
                    axVLCPlugin.playlist.play();
                    axVLCPlugin.BringToFront();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private string saveImage1ToFile(string cardID, bool isInputLeftSide)
        {
            AxVLCPlugin2 axVLCPlugin = axVLCPlugin1;
            PictureBox pictureBox = pictureBoxImage1;
            int inOutType = mConfig.inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                axVLCPlugin = axVLCPlugin3;
                pictureBox = pictureBoxImage3;
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (!isInputLeftSide)
                {
                    axVLCPlugin = axVLCPlugin3;
                    pictureBox = pictureBoxImage3;
                }
            }

            string imagePath1 = "";
            if (isCarIn(cardID, isInputLeftSide))
            {
                Invoke((MethodInvoker)(delegate ()
                {
                    Bitmap bmpScreenshot = getBitMapFromCamera(axVLCPlugin);
                    pictureBox.Image = bmpScreenshot;

                    if (Constant.IS_NAPSHOT_FULL_IMAGE)
                    {
                        imagePath1 = getPathFromSnapshot(axVLCPlugin);
                    }
                    else
                    {
                        imagePath1 = getPathFromSnapshotThumbnail(bmpScreenshot, true, 1);
                    }                   
                }));
            }
            return imagePath1;
        }

        private void loadImage1ToPictureBox(string cardID, bool isInputLeftSide)
        {
            AxVLCPlugin2 axVLCPlugin = axVLCPlugin1;
            PictureBox pictureBox = pictureBoxImage1;
            int inOutType = mConfig.inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                axVLCPlugin = axVLCPlugin3;
                pictureBox = pictureBoxImage3;
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (!isInputLeftSide)
                {
                    axVLCPlugin = axVLCPlugin3;
                    pictureBox = pictureBoxImage3;
                }
            }

            if (isCarIn(cardID, isInputLeftSide))
            {
                Invoke((MethodInvoker)(delegate ()
                {
                    Bitmap bmpScreenshot = getBitMapFromCamera(axVLCPlugin);
                    pictureBox.Image = bmpScreenshot;
                }));
            }
        }

        private void loadCamera2VLC()
        {
            String rtspString = cameraUrl2;
            axVLCPlugin2.playlist.add(rtspString, "1", options);
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

        private string saveImage2ToFile(string cardID, bool isInputLeftSide)
        {
            AxVLCPlugin2 axVLCPlugin = axVLCPlugin2;
            PictureBox pictureBox = pictureBoxImage2;
            int inOutType = mConfig.inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                axVLCPlugin = axVLCPlugin4;
                pictureBox = pictureBoxImage4;
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (!isInputLeftSide)
                {
                    axVLCPlugin = axVLCPlugin4;
                    pictureBox = pictureBoxImage4;
                }
            }

            string imagePath2 = "";
            if (isCarIn(cardID, isInputLeftSide))
            {
                //imagePath2 = getPathFromSnapshot(axVLCPlugin);
                if (Constant.IS_NAPSHOT_FULL_IMAGE)
                {
                    imagePath2 = getPathFromSnapshot(axVLCPlugin);
                }
                else
                {
                    Bitmap bmpScreenshot = getBitMapFromCamera(axVLCPlugin);
                    imagePath2 = getPathFromSnapshotThumbnail(bmpScreenshot, true, 2);
                }
            }
            return imagePath2;
        }

        private void loadImage2ToPictureBox(string cardID, bool isInputLeftSide)
        {
            AxVLCPlugin2 axVLCPlugin = axVLCPlugin2;
            PictureBox pictureBox = pictureBoxImage2;
            int inOutType = mConfig.inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                axVLCPlugin = axVLCPlugin4;
                pictureBox = pictureBoxImage4;
            }
            else if (inOutType == ConfigDTO.TYPE_IN_IN)
            {
                if (!isInputLeftSide)
                {
                    axVLCPlugin = axVLCPlugin4;
                    pictureBox = pictureBoxImage4;
                }
            }

            if (isCarIn(cardID, isInputLeftSide))
            {
                Invoke((MethodInvoker)(delegate ()
                {
                    Bitmap bmpScreenshot = getBitMapFromCamera(axVLCPlugin);
                    pictureBox.Image = bmpScreenshot;
                }));
            }
        }

        private void loadCamera3VLC()
        {
            String rtspString = cameraUrl3;
            axVLCPlugin3.playlist.add(rtspString, "1", options);
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

        private string saveImage3ToFile(string cardID, bool isInputLeftSide)
        {
            AxVLCPlugin2 axVLCPlugin = axVLCPlugin3;
            int inOutType = mConfig.inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                axVLCPlugin = axVLCPlugin1;
            }
            else if (inOutType == ConfigDTO.TYPE_OUT_OUT)
            {
                if (isInputLeftSide)
                {
                    axVLCPlugin = axVLCPlugin1;
                }
            }
            string imagePath3;
            if (Constant.IS_NAPSHOT_FULL_IMAGE)
            {
                imagePath3 = getPathFromSnapshot(axVLCPlugin);
            }
            else
            {
                Bitmap bmpScreenshot = getBitMapFromCamera(axVLCPlugin);
                imagePath3 = getPathFromSnapshotThumbnail(bmpScreenshot, false, 1);
            }
            return imagePath3;
        }

        private void loadCamera4VLC()
        {
            String rtspString = cameraUrl4;
            axVLCPlugin4.playlist.add(rtspString, "1", options);
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

        private string saveImage4ToFile(string cardID, bool isInputLeftSide)
        {
            AxVLCPlugin2 axVLCPlugin = axVLCPlugin4;
            int inOutType = mConfig.inOutType;
            if (inOutType == ConfigDTO.TYPE_OUT_IN)
            {
                axVLCPlugin = axVLCPlugin2;
            }
            else if (inOutType == ConfigDTO.TYPE_OUT_OUT)
            {
                if (isInputLeftSide)
                {
                    axVLCPlugin = axVLCPlugin2;
                }
            }
            string imagePath4;
            if (Constant.IS_NAPSHOT_FULL_IMAGE)
            {
                imagePath4 = getPathFromSnapshot(axVLCPlugin);
            }
            else
            {
                Bitmap bmpScreenshot = getBitMapFromCamera(axVLCPlugin);
                imagePath4 = getPathFromSnapshotThumbnail(bmpScreenshot, false, 2);
            }
            return imagePath4;
        }

        private Bitmap getBitMapFromCamera(AxVLCPlugin2 axVLCPlugin)
        {
            //axVLCPlugin.playlist.togglePause();
            Bitmap bmpScreenshot = new Bitmap(axVLCPlugin.ClientRectangle.Width,
                axVLCPlugin.ClientRectangle.Height);
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            System.Drawing.Size imgSize = new System.Drawing.Size(
                axVLCPlugin.ClientRectangle.Width,
                axVLCPlugin.ClientRectangle.Height);
            System.Drawing.Point ps = axVLCPlugin.PointToScreen(System.Drawing.Point.Empty);
            gfxScreenshot.CopyFromScreen(ps.X, ps.Y, 0, 0, imgSize, CopyPixelOperation.SourceCopy);
            //axVLCPlugin.playlist.play();
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

            cameraCarUrl1 = mConfig.cameraCarUrl1;
            cameraCarUrl2 = mConfig.cameraCarUrl2;
            cameraCarUrl3 = mConfig.cameraCarUrl3;
            cameraCarUrl4 = mConfig.cameraCarUrl4;

            rfidIn = mConfig.rfidIn;
            rfidOut = mConfig.rfidOut;
            rfidCarIn = mConfig.rfidCarIn;
            rfidCarOut = mConfig.rfidCarOut;
            portNameComReceiveIn = mConfig.comReceiveIn;
            portNameComReceiveOut = mConfig.comReceiveOut;
            portNameComReaderLeft = mConfig.comReaderLeft;
            portNameComReaderRight = mConfig.comReaderRight;
            portNameComReaderCarLeft = mConfig.comReaderCarLeft;
            portNameComReaderCarRight = mConfig.comReaderCarRight;
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

        public void configVLC(float value1, float value2, float value3, float value4)
        {
            float zoomValue1 = (float)value1 / 100;
            float zoomValue2 = (float)value2 / 100;
            float zoomValue3 = (float)value3 / 100;
            float zoomValue4 = (float)value4 / 100;
            //axVLCPlugin1.video.aspectRatio = "209:253";
            //axVLCPlugin2.video.aspectRatio = "209:253";
            //axVLCPlugin3.video.aspectRatio = "209:253";
            //axVLCPlugin4.video.aspectRatio = "209:253";

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
            axVLCPluginCar1.volume = 0;
            axVLCPluginCar2.volume = 0;
            axVLCPluginCar3.volume = 0;
            axVLCPluginCar4.volume = 0;
        }

        private void OnKeyPressed(object sender, RawInputEventArg e)
        {
            if (e.KeyPressEvent.DeviceName.Equals(rfidIn) || e.KeyPressEvent.DeviceName.Equals(rfidOut) ||
                e.KeyPressEvent.DeviceName.Equals(rfidCarIn) || e.KeyPressEvent.DeviceName.Equals(rfidCarOut))
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

        private bool isCarIn(string cardID, bool isInputLeftSide)
        {
            int inOutType = mConfig.inOutType;
            switch (inOutType)
            {
                case ConfigDTO.TYPE_IN_IN:
                    return true;
                case ConfigDTO.TYPE_OUT_OUT:
                    return false;
                case ConfigDTO.TYPE_IN_OUT:
                    if (!isInputLeftSide)
                    {
                        return false;
                    }
                    return true;
                case ConfigDTO.TYPE_OUT_IN:
                    if (!isInputLeftSide)
                    {
                        return true;
                    }
                    return false;
                default:
                    if (!isInputLeftSide)
                    {
                        return false;
                    }
                    return true;
            }
        }

        private int tinhTienGiuXe(DataTable dtLastCar, string cardID)
        {
            switch (mParkingTypeID)
            {
                case Constant.LOAI_GIU_XE_MIEN_PHI:
                    return 0;
                case Constant.LOAI_GIU_XE_THEO_CONG_VAN:
                    return tinhGiaTienTheoCongVan(dtLastCar, cardID);
                case Constant.LOAI_GIU_XE_LUY_TIEN:
                    return tinhGiaTienLuyTien(dtLastCar, cardID);
                case Constant.LOAI_GIU_XE_TONG_HOP:
                    return tinhGiaTienTongHop(dtLastCar, cardID);
                case Constant.LOAI_GIU_XE_TONG_HOP_THEO_NGAY_DEM:
                    return tinhGiaTienTongHopTheoNgayDem(dtLastCar, cardID);
                default:
                    return tinhGiaTienTheoCongVan(dtLastCar, cardID);
            }
        }

        private int tinhGiaTienTheoCongVan(DataTable dtLastCar, string cardID)
        {
            string partID = CardDAO.getPartIDByCardID(cardID);
            ComputerDTO computerDTO = ComputerDAO.GetDataByPartIDAndParkingTypeID(partID, Constant.LOAI_GIU_XE_THEO_CONG_VAN);
            if (dtLastCar != null)
            {
                DateTime timeIn = dtLastCar.Rows[0].Field<DateTime>("TimeStart");
                DateTime timeOut = DateTime.Now;
                double spentTimeByMinute = Util.getTotalTimeByMinute(timeIn, timeOut);
                if (spentTimeByMinute <= 5) // 5'
                {
                    return 0;
                }
                if (spentTimeByMinute <= computerDTO.MinMinute)
                {
                    return computerDTO.MinCost;
                }
                else
                {
                    return getCostTinhTienCongVan(timeIn, timeOut, computerDTO, cardID);
                }

            }
            return 0;
        }

        private int getNightCostTheoCongVan(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO, string cardID)
        {
            if (mConfig.projectId.Equals(Constant.API_KEY_BV_HOAN_MY_THU_DUC) && timeOut.Hour < 21 && Util.getTotalTimeByHour(timeIn, timeOut) < 2)
            {
                // case BV HOAN MY THU DUC
                // before 21h
                // total time < 2h
                string type = CardDAO.GetTypeByID(cardID);
                if (type == TypeDTO.TYPE_CAR)
                {
                    // Xe oto
                    if (Util.getTotalTimeByHour(timeIn, timeOut) < 1)
                    {
                        // < 1h
                        return computerDTO.NightCost - 20000;
                    }
                    else
                    {
                        // 1h ~ 2h
                        return computerDTO.NightCost - 10000;
                    }
                } else
                {
                    return computerDTO.NightCost;
                }
            }
            else
            {
                return computerDTO.NightCost;
            }
        }

        private int getCostTinhTienCongVan(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO, string cardID)
        {
            double spentTimeByHour = Util.getTotalTimeByHour(timeIn, timeOut);
            double limit = (double)computerDTO.Limit / 60; // (hour)
            int dayCost = computerDTO.DayCost;
            if (mConfig.computerName.Equals("ADMIN-BACHKHOA"))
            {
                if (timeIn.Date.DayOfWeek == DayOfWeek.Sunday || timeOut.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    dayCost = computerDTO.NightCost;
                }
            }

            if (timeIn.Hour >= computerDTO.EndHourNight && timeOut.Hour < computerDTO.StartHourNight && timeIn.DayOfYear == timeOut.DayOfYear)
            {
                // vào ngày - ra ngày
                return dayCost;
            }
            else if (spentTimeByHour <= 24)
            {
                //trong 1 ngày
                if ((timeIn.Hour >= computerDTO.StartHourNight && timeOut.Hour < 24 && timeIn.DayOfYear == timeOut.DayOfYear)
                    || (timeIn.Hour >= 0 && timeOut.Hour < computerDTO.EndHourNight && timeIn.DayOfYear == timeOut.DayOfYear)
                    || (timeIn.Hour >= computerDTO.StartHourNight && timeOut.Hour < computerDTO.EndHourNight))
                {
                    // vào đêm - ra đêm trong 1 ca
                    if (Util.getTotalTimeByHour(timeIn, timeOut) <= computerDTO.IntervalBetweenDayNight)
                    {
                        // thời gian trong bãi nhỏ hơn khoảng giao ngày - đêm
                        return getNightCostTheoCongVan(timeIn, timeOut, computerDTO, cardID);
                    }
                    else
                    {
                        // thời gian trong bãi lớn hơn khoảng giao ngày - đêm
                        return computerDTO.DayNightCost;
                    }
                }
                else
                {
                    // vào ngày - ra đêm hoặc vào đêm - ra ngày hoặc vào ngày - ra ngày hoặc vào đêm - ra đêm trong nhiều ca
                    if (Util.getTotalTimeByHour(timeIn, timeOut) <= computerDTO.IntervalBetweenDayNight)
                    {
                        // thời gian trong bãi nhỏ hơn khoảng giao ngày - đêm
                        if (timeIn.Hour < computerDTO.StartHourNight && timeOut.Hour >= computerDTO.EndHourNight && Util.getTotalTimeByDay(timeIn.Date, timeOut.Date) == 1) {
                            // thời gian đêm trọn khung giờ
                            return getNightCostTheoCongVan(timeIn, timeOut, computerDTO, cardID);
                        } else if (getTotalHourOfDay(timeIn, timeOut, computerDTO) >= getTotalHourOfNight(timeIn, timeOut, computerDTO))
                        {
                            // thời gian ngày lớn hơn đêm
                            if (getTotalHourOfDay(timeIn, timeOut, computerDTO) <= limit)
                            {
                                // thời gian ngày nhỏ hơn giới hạn
                                return dayCost;
                            }
                            else
                            {
                                // thời gian ngày lớn hơn giới hạn
                                return getNightCostTheoCongVan(timeIn, timeOut, computerDTO, cardID);
                            }
                        }
                        else
                        {
                            // thời gian ngày nhỏ hơn đêm
                            return getNightCostTheoCongVan(timeIn, timeOut, computerDTO, cardID);
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
                int costMilestoneRemain = getCostTinhTienCongVan(newTimeIn, timeOut, computerDTO, cardID);
                return costMilestoneRemain + temp1 * computerDTO.DayNightCost;
            }
        }

        private int tinhGiaTienLuyTien(DataTable dtLastCar, string cardID)
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

        private int tinhGiaTienTongHop(DataTable dtLastCar, string cardID)
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

        private int tinhGiaTienTongHopTheoNgayDem(DataTable dtLastCar, string cardID)
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
            if (mConfig.isIncludeMinMinute.Equals("no"))
            {
                timeIn.AddMinutes(computerDTO.MinMinute);
            }

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
                else if (((timeIn.Hour >= computerDTO.StartHourNight && timeIn.Hour <= timeOut.Hour && timeOut.Hour < 24) || (timeIn.Hour >= 0 && timeOut.Hour < computerDTO.EndHourNight)) && Util.getTotalTimeByDay(timeIn, timeOut) <= 1)
                {
                    // vào đêm - ra đêm
                    return computerDTO.CostMilestoneNight1;
                }
                else
                {
                    //if (totalHourOfDay >= totalHourOfNight)
                    //{
                    //    return computerDTO.CostMilestone1;
                    //}
                    //else
                    //{
                    //    return computerDTO.CostMilestoneNight1;
                    //}
                    return computerDTO.CostMilestoneNight1;
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
                else if (((timeIn.Hour >= computerDTO.StartHourNight && timeOut.Hour < 24) || (timeIn.Hour >= 0 && timeOut.Hour < computerDTO.EndHourNight)) && Util.getTotalTimeByDay(timeIn, timeOut) <= 1)
                {
                    // vào đêm - ra đêm
                    return computerDTO.CostMilestoneNight2;
                }
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
                else if (((timeIn.Hour >= computerDTO.StartHourNight && timeIn.Hour <= timeOut.Hour && timeOut.Hour < 24) || (timeIn.Hour >= 0 && timeOut.Hour < computerDTO.EndHourNight)) && Util.getTotalTimeByDay(timeIn, timeOut) <= 1)
                {
                    // vào đêm - ra đêm
                    return computerDTO.CostMilestoneNight3;
                }
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
                    // chu ky 24h
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
                    // chu ky nho danh cho o to
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
                ((timeOut.Hour >= computerDTO.StartHourNight && timeOut.Date.Day == timeIn.Date.Day) || (timeOut.Hour < computerDTO.EndHourNight && Util.getTotalTimeByHour(timeIn, timeOut) < 24));
        }

        private bool isCarInNightOutDayOneDate(DateTime timeIn, DateTime timeOut, ComputerDTO computerDTO)
        {
            return (timeOut.Hour >= computerDTO.EndHourNight && timeOut.Hour < computerDTO.StartHourNight) &&
                ((timeIn.Hour >= computerDTO.StartHourNight && Util.getTotalTimeByHour(timeIn, timeOut) < 24) || (timeIn.Hour < computerDTO.EndHourNight && timeOut.Date.Day == timeIn.Date.Day));
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

                    if (mConfig.readDigitLeftLane.Equals("2"))
                    {
                        labelXeVaoNguoi.Text = Constant.sLabelXeVaoNguoi;
                        labelXeVaoBienSo.Text = Constant.sLabelXeVaoBienSo;
                    }
                    else
                    {
                        labelXeVaoNguoi.Text = Constant.sLabelXeVaoBienSo;
                        labelXeVaoBienSo.Text = Constant.sLabelXeVaoNguoi;
                    }

                    if (mConfig.readDigitRightLane.Equals("4"))
                    {
                        labelXeRaNguoi.Text = Constant.sLabelXeVaoNguoi;
                        labelXeRaBienSo.Text = Constant.sLabelXeVaoBienSo;
                    }
                    else
                    {
                        labelXeRaNguoi.Text = Constant.sLabelXeVaoBienSo;
                        labelXeRaBienSo.Text = Constant.sLabelXeVaoNguoi;
                    }

                    break;
                case ConfigDTO.TYPE_OUT_OUT:
                    labelXeVao.Text = Constant.sLabelXeRa;
                    labelXeRa.Text = Constant.sLabelXeRa;

                    if (mConfig.readDigitLeftLane.Equals("2"))
                    {
                        labelXeVaoNguoi.Text = Constant.sLabelXeRaNguoi;
                        labelXeVaoBienSo.Text = Constant.sLabelXeRaBienSo;
                    }
                    else
                    {
                        labelXeVaoNguoi.Text = Constant.sLabelXeRaBienSo;
                        labelXeVaoBienSo.Text = Constant.sLabelXeRaNguoi;
                    }

                    if (mConfig.readDigitRightLane.Equals("4"))
                    {
                        labelXeRaNguoi.Text = Constant.sLabelXeRaNguoi;
                        labelXeRaBienSo.Text = Constant.sLabelXeRaBienSo;
                    }
                    else
                    {
                        labelXeRaNguoi.Text = Constant.sLabelXeRaBienSo;
                        labelXeRaBienSo.Text = Constant.sLabelXeRaNguoi;
                    }

                    break;
                case ConfigDTO.TYPE_OUT_IN:
                    labelXeVao.Text = Constant.sLabelXeRa;
                    labelXeRa.Text = Constant.sLabelXeVao;

                    if (mConfig.readDigitLeftLane.Equals("2"))
                    {
                        labelXeVaoNguoi.Text = Constant.sLabelXeRaNguoi;
                        labelXeVaoBienSo.Text = Constant.sLabelXeRaBienSo;
                    }
                    else
                    {
                        labelXeVaoNguoi.Text = Constant.sLabelXeRaBienSo;
                        labelXeVaoBienSo.Text = Constant.sLabelXeRaNguoi;
                    }

                    if (mConfig.readDigitRightLane.Equals("4"))
                    {
                        labelXeRaNguoi.Text = Constant.sLabelXeVaoNguoi;
                        labelXeRaBienSo.Text = Constant.sLabelXeVaoBienSo;
                    }
                    else
                    {
                        labelXeRaNguoi.Text = Constant.sLabelXeVaoBienSo;
                        labelXeRaBienSo.Text = Constant.sLabelXeVaoNguoi;
                    }

                    break;
                case ConfigDTO.TYPE_IN_OUT:
                default:
                    labelXeVao.Text = Constant.sLabelXeVao;
                    labelXeRa.Text = Constant.sLabelXeRa;

                    if (mConfig.readDigitLeftLane.Equals("2"))
                    {
                        labelXeVaoNguoi.Text = Constant.sLabelXeVaoNguoi;
                        labelXeVaoBienSo.Text = Constant.sLabelXeVaoBienSo;
                    }
                    else
                    {
                        labelXeVaoNguoi.Text = Constant.sLabelXeVaoBienSo;
                        labelXeVaoBienSo.Text = Constant.sLabelXeVaoNguoi;
                    }

                    if (mConfig.readDigitRightLane.Equals("4"))
                    {
                        labelXeRaNguoi.Text = Constant.sLabelXeRaNguoi;
                        labelXeRaBienSo.Text = Constant.sLabelXeRaBienSo;
                    }
                    else
                    {
                        labelXeRaNguoi.Text = Constant.sLabelXeRaBienSo;
                        labelXeRaBienSo.Text = Constant.sLabelXeRaNguoi;
                    }
                    break;
            }

            resetAllData();
        }

        private void resetDataOneSide(bool isResetImage, Boolean? isInputLeftSide)
        {
            //Program.oldUhfCardId = "";
            labelError.Text = "";
            labelMoiVao.Text = "";
            labelMoiRa.Text = "";

            if (isInputLeftSide == null)
            {
                isInputLeftSide = inputIsLeftSide(mCurrentCardID);
            }

            if ((bool) isInputLeftSide)
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
            //Program.oldUhfCardId = "";
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

        private void tbRFIDCardID_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    Program.oldUhfCardId = "";
                    Program.newUhfCardId = "";
                    labelError.Text = "";                   
                    string cardID = tbRFIDCardID.Text.Trim();
                    tbRFIDCardID.Text = "";

                    if (!cardID.Equals(""))
                    {
                        bool isInputLeftSide = inputIsLeftSide(cardID);                       
                        readCardEvent(cardID, isInputLeftSide);
                    }
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

            if (mCount > 0)
            {
                foreach (Control cnt in this.Controls)
                {
                    ResizeAll(cnt, base.Size);
                }
            }

            //Form_Resize();
            oldSize = base.Size;
            mCount++;
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
        //    catch(
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

        private void updateDataByTimer()
        {
            mBindingSource = new BindingSource();
            mListCarSurvive = CarDAO.GetListCarSurvive();
            dgvThongKeXeTrongBai.DataSource = mListCarSurvive;
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 30 * 1000;
            aTimer.Enabled = true;
            aTimer.Start();

            checkAndUpdateLostAvailable();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Force garbage collection.
            GC.Collect();
            // Wait for all finalizers to complete before continuing.
            GC.WaitForPendingFinalizers();

            loadConfigInfoDB();
            checkAndUpdateLostAvailable();
        }

        private void checkAndUpdateLostAvailable()
        {
            try
            {
                new Thread(() =>
                {
                    mListCarSurvive = CarDAO.GetListCarSurvive();
                    Invoke(new MethodInvoker(() =>
                    {
                        mBindingSource.DataSource = mListCarSurvive;
                        if (mConfig.comLostAvailable.Length > 0)
                        {
                            showLostAvailableToLed();
                        }                     
                    }));
                }).Start();
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
            foreach (DataRow row in mListCarSurvive.Rows)
            {
                int countEmpty = int.TryParse(row["CountCarEmpty"].ToString(), out countEmpty) ? countEmpty : 0;
                if (countEmpty < 0)
                {
                    countEmpty = 0;
                }
                string data;

                if (row["TypeID"].ToString() == TypeDTO.TYPE_BIKE)
                {               
                    //string data = "@xemay_" + countBikeEmpty.ToString("D" + 4) + "&" + "\r\n";
                    data = "@xemay_" + countEmpty.ToString() + "&";
                    
                } else
                {
                    data = "@oto_" + countEmpty.ToString() + "&";
                }

                writeDataToLostAvailablePort(data, portName);
                Thread.Sleep(1000);
            }


            
            //string exceptPartSignBike = null;
            //if (mConfig.projectId.Equals(Constant.API_KEY_GREEN_HILLS))
            //{
            //    exceptPartSignBike = "XeMayLuotTrenG";
            //}

            //int countBikeEmpty = mBikeSpace - CarDAO.GetCountCarSurvive(TypeDTO.TYPE_BIKE, exceptPartSignBike);
            //if (countBikeEmpty < 0)
            //{
            //    countBikeEmpty = 0;
            //}
            ////string dataBike = "@xemay_" + countBikeEmpty.ToString("D" + 4) + "&" + "\r\n";
            //string dataBike = "@xemay_" + countBikeEmpty.ToString() + "&";
            //writeDataToLostAvailablePort(dataBike, portName);

            //Thread.Sleep(1000);
            //string exceptPartSignCar = null;
            //if (mConfig.projectId.Equals(Constant.API_KEY_GREEN_HILLS))
            //{
            //    exceptPartSignCar = "OTOLuotTrenG";
            //}

            //int countCarEmpty = mCarSpace - CarDAO.GetCountCarSurvive(TypeDTO.TYPE_CAR, exceptPartSignCar);
            //if (countCarEmpty < 0)
            //{
            //    countCarEmpty = 0;
            //}
            ////string dataCar = "@oto_" + countCarEmpty.ToString("D" + 4) + "&" + "\r\n";
            //string dataCar = "@oto_" + countCarEmpty.ToString() + "&";
            //writeDataToLostAvailablePort(dataCar, portName);
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
        //            // Thread.CurrentThread.IsBackground = true;
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
        //            // Thread.CurrentThread.IsBackground = true;
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
            //Program.oldUhfCardId = "";
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

        private void showCostToLed(string cost, bool isTicketMonthCard, string cardID, bool isInputLeftSide)
        {
            if (mConfig.comLedLeft.Equals("") && mConfig.comLedRight.Equals(""))
            {
                return;
            }

            if (cost == "0" && !isTicketMonthCard)
            {
                cost = "0000";
            }

            string data = "@tien_" + cost + "&";
            string portName = mConfig.comLedLeft;
            if (!mConfig.comLedRight.Equals(""))
            {
                // 2 cổng COM
                if (isInputLeftSide)
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
                if (isInputLeftSide)
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

        private void getDataFromUhfReader()
        {
            if (Program.portComLeftUhf != null && Program.portComLeftUhf.IsOpen)
            {
                Program.portComLeftUhf.DataReceived += new SerialDataReceivedEventHandler(portComReceiveIn_DataReceived);
            }

            if (Program.portComRightUhf != null && Program.portComRightUhf.IsOpen)
            {
                Program.portComRightUhf.DataReceived += new SerialDataReceivedEventHandler(portComReceiveOut_DataReceived);
            }
        }

        private void portComReceiveIn_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            portNameComReceiveInput = portNameComReceiveIn;
            //Program.newUhfCardId = Util.ReadUhfData(Program.portComLeftUhf);
            if (!Program.newUhfCardId.Equals(""))
            {
                checkForReadUhfCard();
            }
        }

        private void portComReceiveOut_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            portNameComReceiveInput = portNameComReceiveOut;
            //Program.newUhfCardId = Util.ReadUhfData(Program.portComRightUhf);
            if (!Program.newUhfCardId.Equals(""))
            {
                checkForReadUhfCard();
            }
        }

        private void checkForReadUhfCard()
        {
            // noi chuoi ma UHF
            //if (Program.newUhfCardId.Length == 20 && !Program.oldUhfCardId.Equals(""))
            //{
            //    Program.newUhfCardId = Program.oldUhfCardId + " " + Program.newUhfCardId;
            //    Console.WriteLine("Combine UHF: " + Program.newUhfCardId);
            //}
            if (Program.newUhfCardId.Length == 53)
            {
                handleUhfData();
                Program.oldUhfCardId = Program.newUhfCardId;
            }
        }

        private void handleUhfData()
        {
            try
            {
                //OLD UHF READER
                //int frmcomportindexIn = mUHFReader.getComportIndex(mConfig.comReceiveIn);
                //int frmcomportindexOut = mUHFReader.getComportIndex(mConfig.comReceiveOut);
                //uhfInCardId = mUHFReader.GetUHFData(frmcomportindexIn);
                //string newUhfCardId = null;
                //string portName = null;
                //if (uhfInCardId != null)
                //{
                //    portName = portNameComReceiveIn;
                //    newUhfCardId = uhfInCardId;
                //}
                //else
                //{
                //    string uhfOutCardId = mUHFReader.GetUHFData(frmcomportindexOut);
                //    if (uhfOutCardId != null)
                //    {
                //        portName = portNameComReceiveOut;
                //        newUhfCardId = uhfOutCardId;
                //    }
                //}

                //labelError.Text = Program.newUhfCardId;

                Console.WriteLine("UHF: " + Program.newUhfCardId);
                if (Program.newUhfCardId != null)
                {
                    double spentTime = Util.getMillisecondBetweenTwoDate(oldUhfCardTime, DateTime.Now);
                    oldUhfCardTime = DateTime.Now;
                    int distant = 1 * 30 * 1000; // 30s
                    if ((Program.newUhfCardId.Length == 53 && !Program.newUhfCardId.Equals(Program.oldUhfCardId)) || Program.oldUhfCardId == "" || spentTime > distant)
                    {
                        //labelError.Text = newUhfCardId;
                        string cardID = Program.newUhfCardId;
                        //portNameComReceiveInput = portName;

                        bool isInputLeftSide = inputIsLeftSide(cardID);
                        readCardEvent(cardID, isInputLeftSide);
                        timerReadUHFData.Stop();
                        timerReadUHFData.Start();
                    }

                    oldPortNameComReceiveInput = portNameComReceiveInput;
                }
            }
            catch (Exception)
            {

            }
        }

        private bool inputIsCarLane()
        {
            if (portNameComReaderInput != null)
            {
                bool result = portNameComReaderInput.Equals(portNameComReaderCarLeft) || portNameComReaderInput.Equals(portNameComReaderCarRight);
                return result;
            }
            else if (!rfidInput.Equals("Global Keyboard"))
            {
                bool result = rfidInput.Equals(rfidCarIn) || rfidInput.Equals(rfidCarOut);
                return result;
            }
            else
            {
                return false;
            }
        }

        private bool inputIsRightSide(string cardID)
        {
            if (portNameComReceiveInput != null && mConfig.isUsingUhf.Equals("yes") && (cardID.Length == 53))
            {
                bool result = portNameComReceiveInput.Equals(portNameComReceiveOut);
                return result;
            }
            else if (portNameComReaderInput != null)
            {
                bool result = portNameComReaderInput.Equals(portNameComReaderRight) || portNameComReaderInput.Equals(portNameComReaderCarRight);
                return result;
            }
            else if (!rfidInput.Equals("Global Keyboard"))
            {
                if (rfidInput.Equals(""))
                {
                    return false;
                }
                else
                {
                    bool result = rfidInput.Equals(rfidOut) || rfidInput.Equals(rfidCarOut);
                    return result;
                }
            }
            else
            {
                if (rbRightSide.Checked)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                //bool result = rfidInput.Equals(rfidOut);
                //return result;
            }
        }

        private bool inputIsLeftSide(string cardID)
        {
            return !inputIsRightSide(cardID);
        }

        private void FormNhanVien_Activated(object sender, EventArgs e)
        {
            mIsFormActive = true;
            _rawinput.KeyPressed -= OnKeyPressed;
            _rawinput.KeyPressed += OnKeyPressed;
            tbRFIDCardID.Focus();
        }

        private void timerReadUHFData_Tick(object sender, EventArgs e)
        {
            //GC.Collect();
            //GC.WaitForPendingFinalizers();
            //if (ActiveForm == this)
            //{
            //    timerReadUHFData.Enabled = false;
            //    handleUhfData();
            //    timerReadUHFData.Enabled = true;
            //}
        }

        private void initUhfTimer()
        {
            timerReadUHFData.Enabled = true;
        }

        private void FormNhanVien_Shown(object sender, EventArgs e)
        {
            tbRFIDCardID.Focus();
            AutoClosingMessageBox.Show("", "", 300);
        }

        private void labelDigitInLeft_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    string digit = labelDigitInLeft.Text;
                    inputDigitCarInEvent(digit);
                    labelDigitInLeft.Text = "";
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
                    labelDigitInRight.Text = "";
                    break;
            }
        }

        private void pictureBoxBarieLeft_Click(object sender, EventArgs e)
        {
            tbRFIDCardID.Focus();
            openBarieInCar();
            AutoClosingMessageBox.Show("Barie đã mở", "", 500);
        }

        private void pictureBoxBarieRight_Click(object sender, EventArgs e)
        {
            tbRFIDCardID.Focus();
            openBarieOutCar();
            AutoClosingMessageBox.Show("Barie đã mở", "", 500);
        }

        private string uploadCarNumberImage(string fileName, bool isLeftSide, bool isCarIn)
        {
            WebClient webClient = (new ApiUtil()).getWebClient();
            try
            {
                string pythonServerUrl = Util.getConfigFile().pythonServerUrl;
                //string url = @"http://127.0.0.1:8000/getPlateNumber?imagepath=" + fileName;
                string url = pythonServerUrl + "?imagepath=" + fileName;
                String responseString = webClient.DownloadString(url);
                string plateNumber = responseString;
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

        private void testDocBienSo()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"E:\HINH_BIEN_SO\",
                Title = "Browse Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.SafeFileName;
                uploadCarNumberImage(fileName, true, true);
            }
        }

        private string docBienSo(string cardID, bool isInputLeftSide)
        {
            // DocBienSo
            string type = CardDAO.GetTypeByID(cardID);
            AxVLCPlugin2 axVLCPlugin;
            if (isInputLeftSide)
            {
                if (mConfig.readDigitLeftLane.Equals("2"))
                {
                    if (type == TypeDTO.TYPE_BIKE || inputIsCarLane())
                    {
                        axVLCPlugin = axVLCPlugin2;
                    }
                    else
                    {
                        axVLCPlugin = axVLCPlugin1;
                    }
                }
                else
                {
                    if (type == TypeDTO.TYPE_BIKE || inputIsCarLane())
                    {
                        axVLCPlugin = axVLCPlugin1;
                    }
                    else
                    {
                        axVLCPlugin = axVLCPlugin2;
                    };
                }
            }
            else
            {
                if (mConfig.readDigitRightLane.Equals("4"))
                {
                    if (type == TypeDTO.TYPE_BIKE || inputIsCarLane())
                    {
                        axVLCPlugin = axVLCPlugin4;
                    }
                    else
                    {
                        axVLCPlugin = axVLCPlugin3;
                    }
                }
                else
                {
                    if (type == TypeDTO.TYPE_BIKE || inputIsCarLane())
                    {
                        axVLCPlugin = axVLCPlugin3;
                    }
                    else
                    {
                        axVLCPlugin = axVLCPlugin4;
                    }
                }
            }
            Bitmap bmpScreenshot = getBitMapFromCamera(axVLCPlugin);

            string fileName = cardID + DateTime.Now.ToString("_yyyyMMdd_HHmmss_") + DateTime.Now.Ticks + ".jpg";
            saveBitmapToFile(bmpScreenshot, Util.getFolderPath(mConfig.readDigitFolder), fileName);
            //string plateNumber = uploadCarNumberImage(filePath, inputIsLeftSide(), isCarIn());

            string plateNumber = readDigitWareLogic();
            bmpScreenshot.Dispose();

            DirectoryInfo di = new DirectoryInfo(Util.getFolderPath(mConfig.readDigitFolder));
            try
            {
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }
            catch (Exception)
            {

            }

            if (isInputLeftSide)
            {
                labelDigitInLeft.Text = "";
                labelDigitOutLeft.Text = "";

                if (isCarIn(cardID, isInputLeftSide))
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
                labelDigitInRight.Text = "";
                labelDigitOutRight.Text = "";

                if (isCarIn(cardID, isInputLeftSide))
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

        private string readDigitWareLogic()
        {
            string productKeyPath = Application.StartupPath + "\\license\\key_plate_number.xml";
            string inputFolderPath = Util.getFolderPath(mConfig.readDigitFolder);
            Util.CreateFolderIfMissing(inputFolderPath);

            try
            {
                if (_proc == null)
                {
                    if (productKeyPath.Length > 0 && File.Exists(productKeyPath))
                        _lpr.set_productKey(productKeyPath);
                    _proc = _lpr.createProcessor();
                    _proc.plateRegionDetectionEnabled = true;
                }
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show(this, ex.Message, "Unable to create processor object", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            if (_proc != null)
            {
                lps.Clear();
                files.Clear();

                System.IO.DirectoryInfo dInfo = new System.IO.DirectoryInfo(inputFolderPath);
                foreach (System.IO.FileInfo f in dInfo.GetFiles("*.*", System.IO.SearchOption.AllDirectories))
                {
                    if (f.Extension.ToLower() == ".jpg" || f.Extension.ToLower() == ".tif" ||
                         f.Extension.ToLower() == ".png" || f.Extension.ToLower() == ".bmp")
                    {
                        files.Add(f.FullName);
                    }
                }

                string selectedCountry = "Vietnam";
                if (files.Count > 0)
                {
                    for (uint i = 0; i < _lpr.numSupportedCountries; ++i)
                    {
                        string sCountry = _lpr.get_countryCode(i);
                        _lpr.set_countryWeight(sCountry, sCountry == selectedCountry ? 1.0f : 0.0f);
                    }

                    enumF = 0;

                    _lpr.realizeCountryWeights();
                    Cursor.Current = Cursors.Default;

                    if (enumF < files.Count)
                    {
                        _curFile = files[0];
                        return analyzeCurrentFile();
                    }
                }
            }
            return "";
        }

        private string analyzeCurrentFile()
        {
            Cursor.Current = Cursors.WaitCursor;
            _curCands = null;

            try
            {
                using (FileStream fs = new FileStream(_curFile, FileMode.Open, FileAccess.Read))
                {
                    using (Image imTmp = Image.FromStream(fs, true, true))
                    {

                        _curBitmap = new Bitmap((Bitmap)imTmp);
                    }
                }

                _curCands = _proc.analyze(_curBitmap);

                //drawImage();
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show(this, ex.Message, "Analyze method failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            Cursor.Current = Cursors.Default;

            CountryMatch bestMatch;
            bestMatch.confidence = -1.0f;
            bestMatch.text = "";

            if (_curCands != null && _curCands.Count > 0)
            {
                for (int i = 0; i < _curCands.Count; ++i)
                {
                    if (_curCands[i].matches.Count > 1)
                    {
                        if (_curCands[i].matches[0].confidence > bestMatch.confidence)
                            bestMatch = _curCands[i].matches[0];
                    }
                }
            }

            string digit = "";
            if (bestMatch.confidence > 0)
            {
                digit = bestMatch.text.Replace(".", "");
            }
            return digit;
        }

        private void nextFile()
        {
            if (enumF < files.Count)
            {
                _curFile = files[enumF++];

                analyzeCurrentFile();
            }
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

            //string directory = @"E:\WORK\GIT\DOC BIEN SO XE\GIT\license_plate_recognition\";
            //directory = @"D:\\DOC BIEN SO XE\Detect number plate\";
            string directory = Util.getConfigFile().pythonFolder;
            if (Directory.Exists(directory))
            {
                System.Environment.CurrentDirectory = directory;
                Process myProcess = new Process();
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "cmd.exe";
                //myProcess.StartInfo.Arguments = "/c " + "python release_v3.py runserver";
                myProcess.StartInfo.Arguments = "/c " + "python " + Util.getConfigFile().pythonRunFile + " runserver";
                myProcess.EnableRaisingEvents = true;
                myProcess.Start();
            }
        }

        private void resetForm()
        {
            string userId = Program.CurrentStaffUserID;
            this.Hide();
            var frm = new FormNhanVien();
            frm.ShowDialog();
            Program.CurrentStaffUserID = userId;
            this.Close();
            this.Dispose();
            GC.Collect();
        }

        private void loadConfigInfoDB()
        {
            DataTable dtConfig = ConfigDAO.GetConfig();
            mParkingTypeID = ConfigDAO.GetParkingTypeID(dtConfig);
            mIsUseCostDeposit = ConfigDAO.GetIsUseCostDeposit(dtConfig) == ConfigDTO.USE_COST_DEPOSIT_YES;
            mNoticeExpiredDate = ConfigDAO.GetNoticeExpiredDate(dtConfig);
            mNoticeToBeExpireDate = ConfigDAO.GetNoticeToBeExpireDate(dtConfig);
            mCalculationTicketMonth = ConfigDAO.GetCalculationTicketMonth(dtConfig);
            mExpiredTicketMonthTypeID = ConfigDAO.GetExpiredTicketMonthTypeID(dtConfig);
            mBikeSpace = ConfigDAO.GetBikeSpace(dtConfig);
            mCarSpace = ConfigDAO.GetCarSpace(dtConfig);
        }

        private void pictureBoxChangeLaneLeft_Click(object sender, EventArgs e)
        {
            tbRFIDCardID.Focus();
            changeInOutSetting(true);
        }

        private void pictureBoxChangeLaneRight_Click(object sender, EventArgs e)
        {
            tbRFIDCardID.Focus();
            changeInOutSetting(false);
        }

        private void rbLeftSide_CheckedChanged(object sender, EventArgs e)
        {
            tbRFIDCardID.Focus();
        }

        private void rbRightSide_CheckedChanged(object sender, EventArgs e)
        {
            tbRFIDCardID.Focus();
        }

        private void axVLCPlugin1_Enter(object sender, EventArgs e)
        {

        }

        private void btnOpenHistory_Click(object sender, EventArgs e)
        {
            openFormQuanLyXeRaVao();
        }

        private void btnOpenHistory2_Click(object sender, EventArgs e)
        {
            openFormQuanLyXeRaVao();
        }

        private void labelGetCardLeft_Click(object sender, EventArgs e)
        {
            openFormQuanLyXeRaVao();
        }

        private void labelGetCardRight_Click(object sender, EventArgs e)
        {
            openFormQuanLyXeRaVao();
        }

        private void pictureBoxChangeLeftCamera_Click(object sender, EventArgs e)
        {
            if (!cameraCarUrl1.Equals("") || !cameraCarUrl2.Equals(""))
            {
                bool isVisible = !axVLCPluginCar1.Visible;
                setTopVisibleForCamera(axVLCPluginCar1, isVisible);
                setTopVisibleForCamera(axVLCPluginCar2, isVisible);
            }
        }

        private void pictureBoxChangeRightCamera_Click(object sender, EventArgs e)
        {
            if (!cameraCarUrl3.Equals("") || !cameraCarUrl4.Equals(""))
            {
                bool isVisible = !axVLCPluginCar3.Visible;
                setTopVisibleForCamera(axVLCPluginCar3, isVisible);
                setTopVisibleForCamera(axVLCPluginCar4, isVisible);
            }
        }

        private void FormNhanVien_Deactivate(object sender, EventArgs e)
        {
            mIsFormActive = false;
        }
    }
}

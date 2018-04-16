using LibUsbDotNet;
using LibUsbDotNet.Main;
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
using Emgu.CV;
using Emgu.CV.Structure;
using ParkingMangement.DAO;
using AForge.Video;
using System.Drawing.Imaging;
using ParkingMangement.DTO;

namespace ParkingMangement.GUI
{
    public partial class FormNhanVien : Form
    {
        private Byte[] buffer;
        private int total = 0;
        private int read;
        const string cardID = "111";
        const string cameraUrl = "http://192.168.1.115:4747/video";
        private string cameraUrl1 = "http://asma-cam.ne.oregonstate.edu/mjpg/video.mjpg";
        private string cameraUrl2 = cameraUrl;
        private string cameraUrl3 = cameraUrl;
        private string cameraUrl4 = cameraUrl;

        private string imagePath1;
        private string imagePath2;
        private string imagePath3;
        private string imagePath4;

        private Capture _capture;
        private bool _isSaveCamera1ToFile;
        private bool _isSaveCamera2ToFile;

        private SerialPort serialPort;

        public static UsbDevice MyUsbDevice;

        public static UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(1234, 1);

        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
            //loadInfo();
            //loadCamera();
            loadAforge();
            //loadData();
            //readCard();
            //writeCard();
        }

        private void loadInfo()
        {
            timerCurrentTime.Start();
            labelUserName.Text = UserDAO.GetUserNameByID(Program.CurrentUserID);
        }

        private void readCard()
        {
            serialPort = new SerialPort("COM1");// if u r not used Serial Port Tool
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            //serialPort.Handshake = Handshake.None;

            //serialPort.ReadTimeout = 2000;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(Fun_DataReceived);

            serialPort.Open();
            Console.WriteLine("Press any key to continue...");
            Console.WriteLine();
            serialPort.Close();
        }
        //Delegate for the Reading the Tag while RFID Card come to the Range.
        string data = string.Empty;
        private delegate void SetTextDeleg(string text);
        void Fun_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Thread.Sleep(500);
            //data = serialPort.ReadLine();
            //this.BeginInvoke(new SetTextDeleg(Fun_IsDataReceived), new object[] { data });
            SerialPort sp = (SerialPort)sender;
            string indata = serialPort.ReadExisting();
            MessageBox.Show("Data Received:");
            MessageBox.Show(indata);
        }
        private void Fun_IsDataReceived(string data)
        {
            labelCardID.Text = data.Trim();
        }

        private string writeCard()
        {
            try
            {
                System.IO.Ports.SerialPort Serial1 = new System.IO.Ports.SerialPort("COM1", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                //Serial1.DtrEnable = true;
                //Serial1.RtsEnable = true;
                //Serial1.ReadTimeout = 3000;

                var MessageBufferRequest = new byte[8] { 1, 3, 0, 28, 0, 1, 69, 204 };
                var MessageBufferReply = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                int BufferLength = 8;

                if (!Serial1.IsOpen)
                {
                    Serial1.Open();
                }

                try
                {
                    Serial1.Write(MessageBufferRequest, 0, BufferLength);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return "";
                }

                System.Threading.Thread.Sleep(100);

                Serial1.Read(MessageBufferReply, 0, 7);

                return MessageBufferReply[3].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return "";
            }
        }

        private void FormNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Util.showConfirmLogoutPopup(this);
            } else if (e.KeyCode == Keys.Enter)
            {
                saveImage();
            }
        }

        //private void loadCamera()
        //{
        //    try
        //    {
        //        _capture = new Emgu.CV.Capture("rtsp://admin:bmv333999@192.168.1.190:888/cgi-bin/snapshot.cgi?1");
        //        _capture = new Emgu.CV.Capture(cameraUrl);
        //        _capture = new Emgu.CV.Capture("http://asma-cam.ne.oregonstate.edu/mjpg/video.mjpg");
        //        _capture = new Emgu.CV.Capture(0);
        //        Application.Idle += ProcessFrame;
        //    }
        //    catch (NullReferenceException excpt)
        //    {
        //        MessageBox.Show(excpt.Message);
        //    }
        //}

        //private void ProcessFrame(object sender, EventArgs arg)
        //{
        //    imageBoxCamera1.Image = _capture.QueryFrame();
        //    if (_isSaveToFile)
        //    {
        //        imageBoxPicture1.Image = _capture.QueryFrame();
        //        if (imageBoxPicture1.Image != null)
        //        {
        //            string path = Constant.IMAGE_FOLDER + DateTime.Now.Ticks + ".jpg";
        //            _capture.QueryFrame().Save(path);
        //        }
        //        _isSaveToFile = !_isSaveToFile;
        //    }
        //}

        private void loadAforge()
        {
            MJPEGStream videoSource1 = new MJPEGStream(cameraUrl1);
            //MJPEGStream videoSource = new MJPEGStream("http://asma-cam.ne.oregonstate.edu/mjpg/video.mjpg");
            videoSource1.NewFrame += video_NewFrame1;
            videoSource1.Start();

            MJPEGStream videoSource2 = new MJPEGStream(cameraUrl2);
            videoSource2.NewFrame += video_NewFrame2;
            videoSource2.Start();

            //MJPEGStream videoSource3 = new MJPEGStream(cameraUrl3);
            //videoSource3.NewFrame += video_NewFrame3;
            //videoSource3.Start();

            //MJPEGStream videoSource4 = new MJPEGStream(cameraUrl4);
            //videoSource4.NewFrame += video_NewFrame4;
            //videoSource4.Start();
        }

        public void video_NewFrame1(object sender, NewFrameEventArgs eventArgs)
        {
            //do processing here
            Bitmap bitmap = (Bitmap) eventArgs.Frame.Clone();
            pictureBoxCamera1.Image = bitmap;

            object lockObject = new object();
            lock (lockObject)
            {
                if (_isSaveCamera1ToFile)
                {
                    pictureBoxImage1.Image = bitmap;
                    if (pictureBoxCamera1.Image != null)
                    {
                        Image img = this.pictureBoxCamera1.Image;
                        Image imgclone = (Image)img.Clone();
                        imagePath1 = DateTime.Now.Ticks + ".jpg";
                        string path = Constant.IMAGE_FOLDER + imagePath1;
                        imgclone.Save(path, ImageFormat.Jpeg);
                    }
                    _isSaveCamera1ToFile = !_isSaveCamera1ToFile;

                    if (!_isSaveCamera2ToFile)
                    {
                        checkForSaveToDB();
                    }
                }
            }
        }

        public void video_NewFrame2(object sender, NewFrameEventArgs eventArgs)
        {
            //do processing here
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBoxCamera2.Image = bitmap;

            object lockObject = new object();
            lock (lockObject)
            {
                if (_isSaveCamera2ToFile)
                {
                    pictureBoxImage2.Image = bitmap;
                    if (pictureBoxCamera2.Image != null)
                    {
                        Image img = this.pictureBoxCamera2.Image;
                        Image imgclone = (Image)img.Clone();
                        imagePath2 = DateTime.Now.Ticks + ".jpg";
                        string path = Constant.IMAGE_FOLDER + imagePath2;
                        imgclone.Save(path, ImageFormat.Jpeg);
                    }
                    _isSaveCamera2ToFile = !_isSaveCamera2ToFile;

                    if (!_isSaveCamera1ToFile)
                    {
                        checkForSaveToDB();
                    }
                }
            }
        }

        public void video_NewFrame3(object sender, NewFrameEventArgs eventArgs)
        {
            //do processing here
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBoxCamera3.Image = bitmap;
        }

        public void video_NewFrame4(object sender, NewFrameEventArgs eventArgs)
        {
            //do processing here
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBoxCamera4.Image = bitmap;
        }

        private void saveImage()
        {
            _isSaveCamera1ToFile = !_isSaveCamera1ToFile;
            _isSaveCamera2ToFile = !_isSaveCamera2ToFile;
        }

        private void timerCurrentTime_Tick(object sender, EventArgs e)
        {
            labelCurrentTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void checkForSaveToDB()
        {
            if (CarDAO.isCarOut(cardID))
            {
                insertCarIn();
            }
        }

        private void insertCarIn()
        {
            CarDTO carDTO = new CarDTO();
            carDTO.Id = cardID;
            carDTO.TimeStart = DateTime.Now;
            carDTO.IdIn = Program.CurrentUserID;
            carDTO.Images = imagePath1;
            carDTO.Images2 = imagePath2;
            carDTO.Computer = Environment.MachineName;
            carDTO.Account = Program.CurrentUserID;
            carDTO.DateUpdate = DateTime.Now;
            CarDAO.Insert(carDTO);
        }

        private void updateCarOut()
        {

        }
    }
}

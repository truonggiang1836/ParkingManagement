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

        private string cardID = "0";
        
        const string cameraUrl = "http://192.168.1.115:4747/video";
        private string cameraUrl1 = @"rtsp://192.168.1.190:554/cam/realmonitor?channel=4&subtype=0&unicast=true&proto=Onvif";
        private string cameraUrl2 = @"http://camera1.mairie-brest.fr/mjpg/video.mjpg?resolution=400x300";
        private string cameraUrl3 = @"http://webcam.st-malo.com/axis-cgi/mjpg/video.cgi?resolution=352x288";
        private string cameraUrl4 = @"http://webcam.st-malo.com/axis-cgi/mjpg/video.cgi?resolution=352x288";

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
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
            this.ActiveControl = tbRFIDCardID;
            Random rnd = new Random();
            //cardID = rnd.Next(119, 122) + "";

            loadInfo();
            //loadCamera();
            //loadAforge();
            //loadData();
            //readCard();
            //writeCard();
            loadCamera1VLC();
            loadCamera2VLC();
            loadCamera3VLC();
            loadCamera4VLC();

            //readRFIDcard();
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
                cardID = tbRFIDCardID.Text;
                labelCardID.Text = cardID;
                tbRFIDCardID.Text = "";
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
            videoSource1.Login = "admin";
            videoSource1.Password = "bmv333999";
            videoSource1.NewFrame += video_NewFrame1;
            videoSource1.Start();
        }

        public void video_NewFrame1(object sender, NewFrameEventArgs eventArgs)
        {
            //do processing here
            //Bitmap bitmap = (Bitmap) eventArgs.Frame.Clone();
            //pictureBoxCamera1.Image = bitmap;

            //object lockObject = new object();
            //lock (lockObject)
            //{
            //    if (_isSaveCamera1ToFile)
            //    {
            //        if (CarDAO.isCarIn(cardID))
            //        {
            //            pictureBoxImage1.Image = bitmap;
            //            if (pictureBoxCamera1.Image != null)
            //            {
            //                Image img = this.pictureBoxCamera1.Image;
            //                Image imgclone = (Image)img.Clone();
            //                imagePath1 = DateTime.Now.Ticks + ".jpg";
            //                saveImageToFile(imgclone, imagePath1);
            //            }
            //        }
                    
            //        _isSaveCamera1ToFile = !_isSaveCamera1ToFile;

            //        if (!_isSaveCamera2ToFile)
            //        {
            //            checkForSaveToDB();
            //        }
            //    }
            //}
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
            saveImage1ToFile();
            saveImage2ToFile();
            checkForSaveToDB();
        }

        private void timerCurrentTime_Tick(object sender, EventArgs e)
        {
            labelCurrentTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void checkForSaveToDB()
        {
            if (CarDAO.isCarIn(cardID))
            {
                insertCarIn();
            } else
            {
                updateCarOut();
                loadCarInData();
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
        }

        private void updateCarOut()
        {
            int identify = CarDAO.GetIdentifyByID(cardID);
            CarDTO carDTO = new CarDTO();
            carDTO.Identify = identify;
            carDTO.Id = cardID;
            carDTO.TimeEnd = DateTime.Now;
            carDTO.IdOut = Program.CurrentUserID;
            carDTO.Cost = 5000;

            saveImage3ToFile();
            saveImage4ToFile();

            carDTO.Images3 = imagePath3;
            carDTO.Images4 = imagePath4;

            carDTO.Computer = Environment.MachineName;
            carDTO.Account = Program.CurrentUserID;
            carDTO.DateUpdate = DateTime.Now;
            CarDAO.UpdateCarOut(carDTO);
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

        private void loadCamera1VLC()
        {
            //String rtspString = cameraUrl1;
            String rtspString = cameraUrl3;
            axVLCPlugin1.playlist.add(rtspString, " ", ":no-overlay");
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

            if (CarDAO.isCarIn(cardID))
            {
                pictureBoxImage1.Image = bmpScreenshot;
                imagePath1 = DateTime.Now.Ticks + ".jpg";
                saveBitmapToFile(bmpScreenshot, imagePath1);
            }
        }

        private void loadCamera2VLC()
        {
            //String rtspString = cameraUrl1;
            String rtspString = cameraUrl3;
            axVLCPlugin2.playlist.add(rtspString, " ", ":no-overlay");
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

            if (CarDAO.isCarIn(cardID))
            {
                pictureBoxImage2.Image = bmpScreenshot;
                imagePath2 = DateTime.Now.Ticks + ".jpg";
                saveBitmapToFile(bmpScreenshot, imagePath2);
            }
        }

        private void loadCamera3VLC()
        {
            //String rtspString = cameraUrl1;
            String rtspString = cameraUrl3;
            axVLCPlugin3.playlist.add(rtspString, " ", ":no-overlay");
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
            //String rtspString = cameraUrl1;
            String rtspString = cameraUrl3;
            axVLCPlugin4.playlist.add(rtspString, " ", ":no-overlay");
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
    }
}

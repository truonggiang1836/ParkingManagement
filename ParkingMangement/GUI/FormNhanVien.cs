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

namespace ParkingMangement.GUI
{
    public partial class FormNhanVien : Form
    {
        private Byte[] buffer;
        private int total = 0;
        private int read;


        private Capture _capture;
        private bool _isSaveToFile;

        private SerialPort serialPort;

        public static UsbDevice MyUsbDevice;

        public static UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(1234, 1);

        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
            loadCamera();
            //loadAforge();
            //loadData();
            //readCard();
        }

        private void readCard()
        {
            serialPort = new SerialPort();// if u r not used Serial Port Tool
            serialPort.PortName = "COM3";
            serialPort.BaudRate = 6646;
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.Open();
            serialPort.ReadTimeout = 2000;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(Fun_DataReceived);
            serialPort.Close();
        }
        //Delegate for the Reading the Tag while RFID Card come to the Range.
        string data = string.Empty;
        private delegate void SetTextDeleg(string text);
        void Fun_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);
            data = serialPort.ReadLine();
            this.BeginInvoke(new SetTextDeleg(Fun_IsDataReceived), new object[] { data });
        }
        private void Fun_IsDataReceived(string data)
        {
            labelCardID.Text = data.Trim();
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

        private void loadCamera()
        {
            CvInvoke.UseOpenCL = false;
            try
            {
                _capture = new Emgu.CV.Capture("rtsp://admin:bmv333999@192.168.1.190:888/Streaming/Channels/101");
                //_capture = new Emgu.CV.Capture("http://admin:bmv333999@192.168.1.190:888");
                //_capture = new Emgu.CV.Capture("http://asma-cam.ne.oregonstate.edu/mjpg/video.mjpg");
                //_capture = new Emgu.CV.Capture(0);
                Application.Idle += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            imageBoxCamera1.Image = _capture.QueryFrame();
            if (_isSaveToFile)
            {
                imageBoxPicture1.Image = _capture.QueryFrame();
                if (imageBoxPicture1.Image != null)
                {
                    imageBoxCamera1.Image.Save(Constant.IMAGE_FOLDER + DateTime.Now.Ticks + ".jpg");
                }
                _isSaveToFile = !_isSaveToFile;
            }
        }

        //private void loadAforge()
        //{

        //    MJPEGStream videoSource = new MJPEGStream("http://admin:bmv333999@192.168.1.190:888");
        //    //videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
        //    videoSource.Start();

        //    // Link to IP Cam feed
        //    var sourceURL = "http://192.168.1.190:888";
        //    //var sourceURL = "http://88.53.197.250/axis-cgi/mjpg/video.cgi?resolution=320×240";           

        //    stream = new MJPEGStream(sourceURL);
        //    stream.Login = "admin";
        //    stream.Password = "bmv333999";
        //    stream.NewFrame += video_NewFrame;

        //    stream.Start();

        //    buffer = new byte[100000];


        //    // Create HTTP request
        //    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(sourceURL);

        //    // Provide credentials for connection
        //    req.Credentials = new NetworkCredential("admin", "bmv333999");

        //    // Get response
        //    WebResponse resp = req.GetResponse();

        //    // Get response stream
        //    Stream streamer = resp.GetResponseStream();

        //    // Read data from stream
        //    while ((read = streamer.Read(buffer, total, 1000)) != 0)
        //    {
        //        total = total + read;
        //    }
        //}

        //public void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        //{
        //    //do processing here
        //    Bitmap bmp = (Bitmap)Bitmap.FromStream(
        //            new MemoryStream(buffer, 0, total));

        //    pictureBox4.Image = bmp;
        //}

        private void saveImage()
        {
            _isSaveToFile = !_isSaveToFile;
            //imageBoxCamera1.Image = _capture.QueryFrame();
        }

        private void loadData()
        {
            string sourceURL = "http://asma-cam.ne.oregonstate.edu/mjpg/video.mjpg";
            byte[] buffer = new byte[1280 * 800];
            int read, total = 0;
            // create HTTP request
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(sourceURL);
            //req.Credentials = new NetworkCredential("admin", "bmv333999");
            // get response
            WebResponse resp = req.GetResponse();
            // get response stream
            Stream stream = resp.GetResponseStream();
            // read data from stream
            while ((read = stream.Read(buffer, total, 1000)) != 0)
            {
                total += read;
            }
            // get bitmap
            Bitmap bmp = (Bitmap)Bitmap.FromStream(
                          new MemoryStream(buffer, 0, total));
            //Bitmap bmp = new Bitmap(stream);

            pictureBox4.Image = bmp;

            //string url = "http://192.168.1.190";
            //byte[] response = null;
            //using (var webClient = new WebClient())
            //{
            //    webClient.Credentials = new NetworkCredential("admin", "bmv333999");
            //    response = webClient.DownloadData("http://192.168.1.190:888");
            //    string localFilename = @"E:\tofile.jpg";
            //    webClient.DownloadFile("http://192.168.1.190:888", localFilename);
            //    MemoryStream imgStream = new MemoryStream(webClient.DownloadData(url));
            //    Image img = new System.Drawing.Bitmap(imgStream);
            //    pictureBox4.Image = img;
            //}

        }
    }
}

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
            readCard();
            //writeCard();
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

        private void loadCamera()
        {
            CvInvoke.UseOpenCL = false;
            try
            {
                //_capture = new Emgu.CV.Capture("rtsp://admin:bmv333999@192.168.1.190:888/cgi-bin/snapshot.cgi?1");
                //_capture = new Emgu.CV.Capture("http://113.176.92.125:81");
                _capture = new Emgu.CV.Capture("http://asma-cam.ne.oregonstate.edu/mjpg/video.mjpg");
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
                    string path = Constant.IMAGE_FOLDER + DateTime.Now.Ticks + ".jpg";
                    _capture.QueryFrame().Save(path);
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
            string sourceURL = "http://192.168.1.190:888/jpg/image.jpg";
            byte[] buffer = new byte[100000];
            int read, total = 0;
            // create HTTP request
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(sourceURL);
            req.Credentials = new NetworkCredential("admin", "bmv333999");
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

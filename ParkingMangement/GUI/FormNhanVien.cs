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

namespace ParkingMangement.GUI
{
    public partial class FormNhanVien : Form
    {
        private string cardID = "0";

        const string cameraUrl = @"rtsp://admin:bmv333999@192.168.1.190:554/cam/realmonitor?channel=1&subtype=0&unicast=true&proto=Onvif";
        //const string cameraUrl = @"http://webcam.st-malo.com/axis-cgi/mjpg/video.cgi?resolution=352x288";
        private string cameraUrl1 = cameraUrl;
        private string cameraUrl2 = cameraUrl;
        private string cameraUrl3 = cameraUrl;
        private string cameraUrl4 = cameraUrl;

        private string imagePath1;
        private string imagePath2;
        private string imagePath3;
        private string imagePath4;

        public FormNhanVien()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
            this.ActiveControl = tbRFIDCardID;
            readConfigFile();
            //Random rnd = new Random();
            //cardID = rnd.Next(119, 122) + "";

            loadInfo();
            configVLC();
            loadCamera1VLC();
            //loadCamera2VLC();
            loadCamera3VLC();
            //loadCamera4VLC();
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

            if (CarDAO.isCarIn(cardID))
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

            if (CarDAO.isCarIn(cardID))
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
            cameraUrl3 = config.cameraUrl3;
        }

        private void configVLC()
        {
            axVLCPlugin1.video.aspectRatio = "209:253";
            axVLCPlugin2.video.aspectRatio = "209:253";
            axVLCPlugin3.video.aspectRatio = "209:253";
            axVLCPlugin4.video.aspectRatio = "209:253";
            axVLCPlugin1.video.scale = 0.25f;
            axVLCPlugin2.video.scale = 0.25f;
            axVLCPlugin3.video.scale = 0.25f;
            axVLCPlugin4.video.scale = 0.25f;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using Emgu.CV;
using System;
using Emgu.CV.Structure;

namespace ParkingMangement.Utils
{
    /// <summary>
    /// Create Camera Capture
    /// </summary>
    public class CameraCapture
    {
        private readonly VideoCapture videoCapture;
        private readonly PictureBox previewBox;
        private Bitmap image;

        /// <summary>
        /// Create Camera Capture
        /// </summary>
        /// <param name="url">Address of camera</param>
        /// <param name="pictureBox">pictureBox to preview</param>
        public CameraCapture(string url, PictureBox pictureBox)
        {
            videoCapture = new VideoCapture(url);
            videoCapture.ImageGrabbed += VideoCapture_ImageGrabbed;

            previewBox = pictureBox;
            //previewBox.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        /// <summary>
        /// Start to Streaming
        /// </summary>
        public void Start()
        {
            if (videoCapture.IsOpened == true)
            { videoCapture.Start(); }


        }

        /// <summary>
        /// Stop to Streaming
        /// </summary>
        public void Stop()
        {
            videoCapture.Stop();
        }

        private void VideoCapture_ImageGrabbed(object sender, EventArgs e)
        {
            CaptureTo(previewBox);
        }
        /// <summary>
        /// Save a image to PictureBOx
        /// </summary>
        /// <param name="captureBox"></param>
        [HandleProcessCorruptedStateExceptions()]
        public void CaptureTo(PictureBox captureBox)
        {

            try
            {
                Mat m = new Mat();
                videoCapture.Retrieve(m);
                //Mat m = videoCapture.QueryFrame();
                //CvInvoke.Resize(m, m, captureBox.Size);
                image = m.ToImage<Bgr, byte>().ToBitmap();
                captureBox.Image = image;
                //image.Save("c.jpg");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

        }
    }
}

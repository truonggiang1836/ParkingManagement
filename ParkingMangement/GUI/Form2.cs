using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Resources;
using System.Reflection;
using ReaderB;
using System.IO.Ports;
using System.IO;
using RTSPcamera;

namespace ParkingMangement.GUI
{
    public partial class Form2 : Form
    {
        private byte fComAdr = 0xff; //the current ComAdr
        //private byte fBaud;
        private int fCmdRet = 30; //response for execute the commands
        //private int fOpenComIndex; //comport no.
        private byte[] fOperEPC = new byte[36];
        private byte[] fPassWord = new byte[4];
        private byte[] fOperID_6B = new byte[8];
        ArrayList list = new ArrayList();
        private int frmcomportindex;
        private bool ComOpen = false;
        private Timer timer1;
        //string url = "rtsp://wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov";
        //string url = "http://mirrors.standaloneinstaller.com/video-sample/Panasonic_HDC_TM_700_P_50i.mp4";
        string url = "rtsp://admin:spm888999@192.168.1.111:554/cam/realmonitor?channel=1&amp;subtype=0&amp;unicast=true";
        string url2 = "rtsp://admin:spm888999@192.168.1.108:554/cam/realmonitor?channel=1&amp;subtype=0&amp;unicast=true";
        string url3 = "rtsp://admin:spm888999@192.168.1.109:554/cam/realmonitor?channel=1&amp;subtype=0&amp;unicast=true";
        string url4 = "rtsp://admin:spm888999@192.168.1.110:554/cam/realmonitor?channel=1&amp;subtype=0&amp;unicast=true";
        private CameraCapture cameraCapture;
        private CameraCapture cameraCapture2;
        private CameraCapture cameraCapture3;
        private CameraCapture cameraCapture4;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cameraCapture = new CameraCapture(url, pictureBox1);
            cameraCapture.Start();
            cameraCapture2 = new CameraCapture(url2, pictureBox2);
            cameraCapture2.Start();
            cameraCapture3 = new CameraCapture(url3, pictureBox3);
            cameraCapture3.Start();
            cameraCapture4 = new CameraCapture(url4, pictureBox4);
            cameraCapture4.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //openComPort();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

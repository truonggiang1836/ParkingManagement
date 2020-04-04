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
        string url = "http://mirrors.standaloneinstaller.com/video-sample/Panasonic_HDC_TM_700_P_50i.mp4";
        //string url = "rtsp://admin:spm888999@192.168.1.105:554/cam/realmonitor?channel=1&amp;subtype=0&amp;unicast=true";
        private CameraCapture cameraCapture;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cameraCapture = new CameraCapture(url, pictureBox1);
            cameraCapture.Start();
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

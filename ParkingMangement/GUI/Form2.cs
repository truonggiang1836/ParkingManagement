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
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //fOpenComIndex = -1;
            fComAdr = 0;
            //fBaud = 5;
            timer1 = new Timer();
            timer1.Enabled = true;
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string portName = "COM9";
            openComPort(portName);
            //openComPort();
        }

        public void openComPort(string portName)
        {
            int fOpenComIndex = -1;
            byte fBaud = 5;
            int port = 0;
            int openresult, i;
            openresult = 30;
            string temp;
            Cursor = Cursors.WaitCursor;
            byte fComAdr = Convert.ToByte("FF", 16); // $FF;
            try
            {
                temp = portName;
                temp = temp.Trim();
                port = Convert.ToInt32(temp.Substring(3, temp.Length - 3));
                for (i = 6; i >= 0; i--)
                {
                    fBaud = Convert.ToByte(i);
                    if (fBaud == 3)
                        continue;
                    openresult = StaticClassReaderB.OpenComPort(port, ref fComAdr, fBaud, ref frmcomportindex);
                    fOpenComIndex = frmcomportindex;
                    if (openresult == 0x35)
                    {
                        MessageBox.Show("COM Opened", "Information");
                        return;
                    }
                    if (openresult == 0)
                    {
                        ComOpen = true;
                        if ((fCmdRet == 0x35) || (fCmdRet == 0x30))
                        {
                            ComOpen = false;
                            MessageBox.Show("Serial Communication Error or Occupied", "Information");
                            StaticClassReaderB.CloseSpecComPort(frmcomportindex);
                            return;
                        }
                        break;
                    }

                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            if ((fOpenComIndex != -1) & (openresult != 0X35) & (openresult != 0X30))
            {
                ComOpen = true;
            }
            if ((fOpenComIndex == -1) && (openresult == 0x30))
                MessageBox.Show("Serial Communication Error", "Information");

            //setParameter();
        }

        private void setParameter()
        {
            byte[] Parameter = new byte[6];
            Parameter[0] = 1;
            Parameter[1] = 2;
            Parameter[2] = 5;
            Parameter[3] = 2;
            Parameter[4] = 1;
            Parameter[5] = (byte) 2; // single tag query time (s)
            fCmdRet = StaticClassReaderB.SetWorkMode(ref fComAdr, Parameter, frmcomportindex);
        }

        private void GetData()
        {
            byte[] ScanModeData = new byte[40960];
            int ValidDatalength, i;
            string temp, temps;
            ValidDatalength = 0;
            fCmdRet = StaticClassReaderB.ReadActiveModeData(ScanModeData, ref ValidDatalength, frmcomportindex);
            if (fCmdRet == 0)
            {
                temp = "";
                temps = ByteArrayToHexString(ScanModeData);
                for (i = 0; i < ValidDatalength; i++)
                {
                    temp = temp + temps.Substring(i * 2, 2) + " ";
                }
                if (ValidDatalength > 0)
                    textBox1.Text = temp;
            }

        }

        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetData();
        }
    }
}

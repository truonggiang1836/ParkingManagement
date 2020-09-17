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
using ParkingMangement.Model;

namespace ParkingMangement.Utils
{
    class UHFReader
    {
        private int fCmdRet = 30; //response for execute the commands
        private byte fComAdr = 0xff; //the current ComAdr
        private byte[] fOperEPC = new byte[36];
        private byte[] fPassWord = new byte[4];
        private byte[] fOperID_6B = new byte[8];
        ArrayList list = new ArrayList();
        private int frmcomportindex;    
        private bool ComOpen = false;
        private Timer timer1;
        public string cardID = "";

        public UHFReader()
        {
            //timer1 = new Timer();
            //timer1.Enabled = true;
            //timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }

        private void setParameter()
        {
            byte[] Parameter = new byte[6];
            Parameter[0] = 1;
            Parameter[1] = 2;
            Parameter[2] = 5;
            Parameter[3] = 2;
            Parameter[4] = 1;
            Parameter[5] = (byte) Util.getConfigFile().uhfQueryTime; // single tag query time (s)
            fCmdRet = StaticClassReaderB.SetWorkMode(ref fComAdr, Parameter, frmcomportindex);
        }

        public int getComportIndex(string portName)
        {
            return Convert.ToInt32(portName.Substring(3, portName.Length - 3));
        }

        //public void openComPort(string portName, bool isShowError)
        //{
        //    frmcomportindex = Convert.ToInt32(portName.Substring(3, portName.Length - 3));
        //    StaticClassReaderB.CloseSpecComPort(frmcomportindex);

        //    int fOpenComIndex = -1;
        //    byte fBaud = 5;
        //    int port = 0;
        //    int openresult, i;
        //    openresult = 30;
        //    string temp;
        //    byte fComAdr = Convert.ToByte("FF", 16); // $FF;
        //    try
        //    {
        //        temp = portName;
        //        temp = temp.Trim();
        //        port = Convert.ToInt32(temp.Substring(3, temp.Length - 3));
        //        for (i = 6; i >= 0; i--)
        //        {
        //            fBaud = Convert.ToByte(i);
        //            if (fBaud == 3)
        //                continue;
        //            openresult = StaticClassReaderB.OpenComPort(port, ref fComAdr, fBaud, ref frmcomportindex);
        //            fOpenComIndex = frmcomportindex;
        //            if (openresult == 0x35)
        //            {
        //                //MessageBox.Show("COM Opened", "Information");
        //                return;
        //            }
        //            if (openresult == 0)
        //            {
        //                ComOpen = true;
        //                if ((fCmdRet == 0x35) || (fCmdRet == 0x30))
        //                {
        //                    ComOpen = false;
        //                    if (isShowError)
        //                    {
        //                        MessageBox.Show("Không thể kết nối với đầu đọc tầm xa! Vui lòng tắt hết cửa sổ phần mềm rồi mở lại!");
        //                    }
                           
        //                    StaticClassReaderB.CloseSpecComPort(frmcomportindex);
        //                    return;
        //                }
        //                break;
        //            }

        //        }
        //    }
        //    finally
        //    {
                
        //    }

        //    if ((fOpenComIndex != -1) & (openresult != 0X35) & (openresult != 0X30))
        //    {
        //        ComOpen = true;
        //    }
        //    if ((fOpenComIndex == -1) && (openresult == 0x30))
        //    {
        //        if (isShowError)
        //        {
        //            MessageBox.Show("Không thể kết nối với đầu đọc tầm xa! Vui lòng tắt hết cửa sổ phần mềm rồi mở lại!");
        //        }
        //        StaticClassReaderB.CloseSpecComPort(frmcomportindex);
        //    }

        //    setParameter();
        //}

        SerialPort port;
        public void openComPort(string portName, bool isShowError)
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
            }
            catch (Exception e)
            {
                MessageBox.Show("Không thể kết nối với đầu đọc tầm xa! Vui lòng tắt hết cửa sổ phần mềm rồi mở lại!");
            }
        }

        public void closeComPort(string portName)
        {
            frmcomportindex = Convert.ToInt32(portName.Substring(3, portName.Length - 3));
            StaticClassReaderB.CloseSpecComPort(frmcomportindex);
        }

        private static void UHF_Port_OnReceiveData(object sender,
                                   SerialDataReceivedEventArgs e)
        {
            SerialPort spL = (SerialPort)sender;
            byte[] buf = new byte[spL.BytesToRead];
            spL.Read(buf, 0, buf.Length);
            foreach (Byte b in buf)
            {
                Console.Write(b.ToString());
            }
            Console.WriteLine();
        }

        public string GetUHFData(int frmcomportindex)
        {
            byte[] ScanModeData = new byte[40960];
            int ValidDatalength, i;
            string temp, temps;
            ValidDatalength = 0;
            int fCmdRet = StaticClassReaderB.ReadActiveModeData(ScanModeData, ref ValidDatalength, frmcomportindex);
            
            if (fCmdRet == 0)
            {
                Console.WriteLine("fCmdRet_" +fCmdRet + "");
                temp = "";
                temps = ByteArrayToHexString(ScanModeData);
                for (i = 0; i < ValidDatalength; i++)
                {
                    temp = temp + temps.Substring(i * 2, 2) + " ";
                }
                Console.WriteLine("ValidDatalength_" + ValidDatalength + "");
                if (ValidDatalength > 0 && ValidDatalength <= 18)
                {
                    Console.WriteLine("data_" + temp.Trim() + "");
                    return temp.Trim();
                }
            }
            return null;
        }

        public string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}

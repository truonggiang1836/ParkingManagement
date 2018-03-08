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

namespace ParkingMangement.GUI
{
    public partial class FormNhanVien : Form
    {
        private SerialPort serialPort;

        public static UsbDevice MyUsbDevice;

        public static UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(1234, 1);

        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
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
            }
        }
    }
}

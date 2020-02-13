using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingMangement.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private SerialPort port = new SerialPort("COM8", 9600, Parity.None, 8, StopBits.One);
        string buffer = "";

        private void SerialPortProgram()
        {
            Console.WriteLine("Incoming Data:");
            // Attach a method to be called when there
            // is data waiting in the port's buffer 
            port.NewLine = Environment.NewLine;
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            // Begin communications 
            port.Open();
            // Enter an application loop to keep this thread alive 
            Console.ReadLine();
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Show all the incoming data in the port's buffer
            port = (SerialPort)sender;
            string incoming = port.ReadExisting().ToString();
            Console.WriteLine(incoming);
            port.Write("Display this!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SerialPortProgram();
        }

        private void DoUpDate(object s, EventArgs e)
        {
            buffer += port.ReadLine();
            textBox1.Text = buffer;
        }

        

    }
}

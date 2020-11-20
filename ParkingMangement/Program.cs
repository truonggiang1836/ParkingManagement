using ParkingMangement.DAO;
using ParkingMangement.GUI;
using ParkingMangement.Model;
using ParkingMangement.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ParkingMangement
{
    static class Program
    {
        public static DateTime StartWorkTime;
        public static DateTime EndWorkTime;
        public static string CurrentUserID = "";
        public static string CurrentToken = "";
        public static bool isHostMachine = false;
        public static bool isHasCarInOut = false;
        public static UHFReader uhfInReader;
        public static UHFReader uhfOutReader;

        public static string oldUhfCardId = "";
        public static string firstUhfCardId = "";
        public static string newUhfCardId = "";

        public static SerialPort portComLeftUhf;
        public static SerialPort portComRightUhf;
        public static int sCountConnection = 0;
        public static int MAX_CONNECTION = 5;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            initUhfReader();

            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            
            if (Constant.IS_SYNC_DATA_APP)
            {
                Application.Run(new FormSyncData());
            } else
            {
                Application.Run(new FormLogin());
            }
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Util.doLogOut();
        }

        private static void initData()
        {
            //if (!Constant.IS_SYNC_DATA_APP)
            //{
            //    if (Util.getConfigFile().isUsingUhf.Equals("yes"))
            //    {
            //        uhfInReader = new UHFReader();
            //        uhfInReader.openComPort(Util.getConfigFile().comReceiveIn, true);
            //        uhfOutReader = new UHFReader();
            //        uhfOutReader.openComPort(Util.getConfigFile().comReceiveOut, true);
            //    }
            //}
            
            //Util.sendPriceConfigListToServer(ComputerDAO.GetAllDataForSync());
        }

        public static void initUhfReader()
        {
            string comLeftUhfName = Util.getConfigFile().comReceiveIn;
            string comRightUhfName = Util.getConfigFile().comReceiveOut;
            bool isUsingUhf = Util.getConfigFile().isUsingUhf.Equals("yes");

            if (!comLeftUhfName.Equals("") && isUsingUhf)
            {
                try
                {
                    if (portComLeftUhf == null || !portComLeftUhf.IsOpen)
                    {
                        portComLeftUhf = new SerialPort(comLeftUhfName, 115200, Parity.None, 8, StopBits.One); // 115200
                        portComLeftUhf.ReadTimeout = 800;
                    }

                    if (!portComLeftUhf.IsOpen)
                    {
                        portComLeftUhf.Open();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Không thể kết nối với đầu đọc tầm xa! Vui lòng tắt hết cửa sổ phần mềm rồi mở lại!");
                }
            }

            if (!comRightUhfName.Equals("") && isUsingUhf)
            {
                try
                {
                    if (portComRightUhf == null || !portComRightUhf.IsOpen)
                    {
                        portComRightUhf = new SerialPort(comRightUhfName, 115200, Parity.None, 8, StopBits.One);
                        portComRightUhf.ReadTimeout = 800;
                    }

                    if (!portComRightUhf.IsOpen)
                    {
                        portComRightUhf.Open();
                    }
                }
                catch (Exception e)
                {

                }
            }

            getDataFromUhfReader();
        }

        public static void closeUhfReader()
        {
            string comLeftUhfName = Util.getConfigFile().comReceiveIn;
            string comRightUhfName = Util.getConfigFile().comReceiveOut;
            bool isUsingUhf = Util.getConfigFile().isUsingUhf.Equals("yes");

            if (!comLeftUhfName.Equals("") && isUsingUhf)
            {
                try
                {
                    if (portComLeftUhf != null && portComLeftUhf.IsOpen)
                    {
                        portComLeftUhf.Close();
                    }
                }
                catch (Exception e)
                {

                }
            }

            if (!comRightUhfName.Equals("") && isUsingUhf)
            {
                try
                {
                    if (portComRightUhf != null && portComRightUhf.IsOpen)
                    {
                        portComRightUhf.Close();
                    }
                }
                catch (Exception e)
                {

                }
            }
        }

        private static void getDataFromUhfReader()
        {
            if (Program.portComLeftUhf != null && Program.portComLeftUhf.IsOpen)
            {
                Program.portComLeftUhf.DataReceived += portComReceiveIn_DataReceived;
            }

            if (Program.portComRightUhf != null && Program.portComRightUhf.IsOpen)
            {
                Program.portComRightUhf.DataReceived += portComReceiveOut_DataReceived;
            }
        }

        private static void portComReceiveIn_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Program.newUhfCardId = Util.ReadUhfData(Program.portComLeftUhf);
            Console.WriteLine("UHF: " + Program.newUhfCardId);
            combineUhfCardId();
        }

        private static void portComReceiveOut_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Program.newUhfCardId = Util.ReadUhfData(Program.portComRightUhf);
            Console.WriteLine("UHF: " + Program.newUhfCardId);
            combineUhfCardId();
        }

        private static void combineUhfCardId()
        {
            // noi chuoi ma UHF
            if (Program.newUhfCardId.Length == 32)
            {
                Program.firstUhfCardId = Program.newUhfCardId;
            }

            if (Program.newUhfCardId.Length == 20)
            {
                Program.newUhfCardId = Program.firstUhfCardId + " " + Program.newUhfCardId;
                Console.WriteLine("Combine UHF: " + Program.newUhfCardId);
            }
        }
    }
}

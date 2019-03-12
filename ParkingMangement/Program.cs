using ParkingMangement.DAO;
using ParkingMangement.GUI;
using ParkingMangement.Model;
using ParkingMangement.Utils;
using System;
using System.Collections.Generic;
using System.IO;
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

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string pcName = Environment.MachineName;
            if (Util.getConfigFile() != null && pcName.Equals(Util.getConfigFile().ipHost))
            {
                isHostMachine = true;
                //Util.ShareFolder(Constant.LOCAL_ROOT_FOLDER, Constant.FOLDER_NAME_PARKING_MANAGEMENT, "");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Application.Run(new FormLogin());
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Util.doLogOut();
        }

        public static void sendOrderListToServer()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                updateOrderToSever();

                System.Timers.Timer aTimer = new System.Timers.Timer();
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                aTimer.Interval = 30 * 60 * 1000;
                aTimer.Enabled = true;
                aTimer.Start();
            }).Start();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                updateOrderToSever();
            }).Start();
        }

        private static void updateOrderToSever()
        {
            if (isHostMachine)
            {
                string lastSavedIdentifyString = Util.getConfigFile().lastSavedOrder;
                if (!string.IsNullOrEmpty(lastSavedIdentifyString))
                {
                    int lastSavedIdentify = Int32.Parse(lastSavedIdentifyString);
                    Util.sendOrderListToServer(CarDAO.GetDataRecently(lastSavedIdentify));
                }
            }
        }
    }
}

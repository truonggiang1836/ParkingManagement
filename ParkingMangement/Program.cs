using ParkingMangement.DAO;
using ParkingMangement.GUI;
using ParkingMangement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

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
            string currentIP = Util.GetLocalIPAddress();
            if (Util.getConfigFile() != null && currentIP.Equals(Util.getConfigFile().ipHost))
            {
                isHostMachine = true;
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
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 10000;
            aTimer.Enabled = true;
            aTimer.Start();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Util.sendOrderListToServer(CarDAO.GetAllDataWithoutSetUserName());
        }
    }
}

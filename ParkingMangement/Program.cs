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
        public static bool isHasCarInOut = false;
        public static UHFReader uhfInReader;
        public static UHFReader uhfOutReader;
        public static int sCountConnection = 0;
        public static int MAX_CONNECTION = 5;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string pcName = Environment.MachineName;
            if (Util.getConfigFile() != null && pcName.Equals(Util.getConfigFile().computerName))
            {
                isHostMachine = true;
                //Util.ShareFolder(Constant.LOCAL_ROOT_FOLDER, Constant.FOLDER_NAME_PARKING_MANAGEMENT, "");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            initData();

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
            if (!Constant.IS_SYNC_DATA_APP)
            {
                if (Util.getConfigFile().isUsingUhf.Equals("yes"))
                {
                    uhfInReader = new UHFReader();
                    uhfInReader.openComPort(Util.getConfigFile().comReceiveIn);
                    uhfOutReader = new UHFReader();
                    uhfOutReader.openComPort(Util.getConfigFile().comReceiveOut);
                }
            }

            Util.autoLockExpiredCard();
        }
    }
}

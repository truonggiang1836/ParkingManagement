using ParkingMangement.DAO;
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
using System.Timers;
using System.Windows.Forms;

namespace ParkingMangement.GUI
{
    public partial class FormSyncData : Form
    {
        public FormSyncData()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
            Hide();

            syncOrderData();
            syncCardData();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.
            Opacity = 0;
            base.OnLoad(e);
        }

        private void OnTimedEventRevenueData(object source, ElapsedEventArgs e)
        {
            doSyncRevenueData();
        }

        private void doSyncRevenueData()
        {
            try
            {
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    Util.syncRevenueToSPMServer();
                }).Start();
            }
            catch (Exception)
            {

            }
        }

        private void OnTimedEventCardData(object source, ElapsedEventArgs e)
        {
            doSyncOtherData();
        }

        private void doSyncOtherData()
        {
            try
            {
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    //Util.sendCardListToServer(CardDAO.GetAllDataForSync());
                    //Util.sendMonthlyCardListToServer(TicketMonthDAO.GetAllDataForSync());
                    //Util.sendVehicleListToServer(PartDAO.GetAllDataForSync());
                    //Util.sendEmployeeListToServer(UserDAO.GetAllDataForSync());
                    //Util.sendFunctionListToServer(FunctionalDAO.GetAllDataForSync());
                    //Util.sendBlackCarListToServer(BlackCarDAO.GetAllDataForSync());
                    //Util.sendConfigToServer();
                    //Util.sendPriceConfigListToServer(ComputerDAO.GetAllDataForSync());

                    Util.syncMonthlyCardListFromSPMServer();

                    if (!Util.getConfigFile().signature.Equals(""))
                    {
                        Util.syncMonthlyCardListFromPiHomeServer();
                        //Util.syncPartListFromPiHomeServer();
                        //Util.updateCardToPiHomeServer();
                    }                  
                }).Start();
            }
            catch (Exception)
            {

            }
        }

        private void syncOrderData()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventRevenueData);
            aTimer.Interval = Constant.SYNC_REVENUE_PERIOD_MINUTE * 60 * 1000; // 15'
            aTimer.Enabled = true;
            aTimer.Start();

            doSyncRevenueData();
        }

        private void syncCardData()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventCardData);
            aTimer.Interval = 1 * 60 * 1000; //1'
            aTimer.Enabled = true;
            aTimer.Start();

            doSyncOtherData();
        }
    }
}

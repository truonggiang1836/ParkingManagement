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
            Hide();
            syncOrderData();
            syncCardData();         
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    //Util.sendOrderDataToServer();
                    //Util.sendOldOrderListToServer(CarDAO.GetAllDataForSync());
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
                }).Start();
            }
            catch (Exception)
            {

            }
        }

        private void syncOrderData()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 20 * 1000;
            aTimer.Enabled = true;
            aTimer.Start();
        }

        private void syncCardData()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventCardData);
            aTimer.Interval = 5 * 60 * 1000; //5'
            aTimer.Enabled = true;
            aTimer.Start();

            doSyncOtherData();
        }
    }
}

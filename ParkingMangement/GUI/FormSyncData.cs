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
            syncData();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    //Util.sendOrderDataToServer();
                    //Util.sendCardListToServer(CardDAO.GetAllDataForSync());
                    //Util.sendMonthlyCardListToServer(TicketMonthDAO.GetAllDataForSync());
                    //Util.sendVehicleListToServer(PartDAO.GetAllDataForSync());
                    //Util.syncCardListFromServer();
                    //Util.syncMonthlyCardListFromServer();
                    Util.syncVehicleListFromServer();
                }).Start();
            }
            catch (Exception)
            {

            }
        }

        private void syncData()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 10 * 1000;
            aTimer.Enabled = true;
            aTimer.Start();            
        }
    }
}

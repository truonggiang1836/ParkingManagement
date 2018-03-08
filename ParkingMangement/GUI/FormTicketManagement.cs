using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingMangement.GUI
{
    public partial class FormTicketManagement : Form
    {
        public FormVehicleManagement formVehicleManagement;
        public FormTicketManagement()
        {
            InitializeComponent();
        }

        private void btnEditTicket_Click(object sender, EventArgs e)
        {
            FormEditTicket f = new FormEditTicket();
            f.Show();
        }

        private void btnStaffManagement_Click(object sender, EventArgs e)
        {
            this.Close();
            formVehicleManagement.Close();
        }

        private void labelVehicleManagement_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

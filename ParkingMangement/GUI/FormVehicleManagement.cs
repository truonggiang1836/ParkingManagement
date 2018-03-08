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
    public partial class FormVehicleManagement : Form
    {
        public FormVehicleManagement()
        {
            InitializeComponent();
        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            FormEditVehicle f = new FormEditVehicle();
            f.Show();
        }

        private void labelTicketManagement_Click(object sender, EventArgs e)
        {
            FormTicketManagement f = new FormTicketManagement();
            f.formVehicleManagement = this;
            f.Show();
        }

        private void btnStaffManagement_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

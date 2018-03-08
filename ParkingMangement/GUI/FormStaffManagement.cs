using ParkingMangement.DAO;
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
    public partial class FormStaffManagement : Form
    {
        public FormStaffManagement()
        {
            InitializeComponent();
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            FormEditStaff f = new FormEditStaff();
            f.Show();
        }

        private void btnSystemManagement_Click(object sender, EventArgs e)
        {
            FormVehicleManagement f = new FormVehicleManagement();
            f.Show();
        }

        private void FormStaffManagement_Load(object sender, EventArgs e)
        {
            DataTable dt = UserDAO.GetAllData();
            dgvUserList.DataSource = dt;
        }
    }
}

using ParkingMangement.DAO;
using ParkingMangement.Utils;
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
    public partial class FormLogOutByCard : Form
    {
        public FormNhanVien formNhanVien;
        public FormLogOutByCard()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !tbUserID.Text.Equals(null))
            {
                string userId = tbUserID.Text;
                DataTable dt = UserDAO.GetUserByID(userId);
                if (dt != null && dt.Rows.Count > 0 && userId.Equals(Program.CurrentUserID))
                {
                    logoutDone();
                }
                else
                {
                    labelError.Text = "Thông tin không chính xác";
                }
            }
        }

        private void logoutDone()
        {
            this.Hide();
            Form f = new FormLogin();
            f.Closed += (s, args) => this.Close();

            if (formNhanVien != null)
            {
                formNhanVien.Hide();
                Util.doLogOut();
                f.Closed += (s, args) => formNhanVien.Close();
            }
            f.Show();
        }
    }
}

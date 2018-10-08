using ParkingMangement.DAO;
using ParkingMangement.DTO;
using ParkingMangement.GUI;
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
    public partial class FormLogout : Form
    {
        public FormNhanVien formNhanVien;
        public FormLogout()
        {
            InitializeComponent();
        }

        private void FormLogout_Load(object sender, EventArgs e)
        {
            initView();
        }

        private void initView()
        {
            //this.WindowState = FormWindowState.Maximized;
            // no smaller than design time size
            this.MinimumSize = new Size(this.Width, this.Height);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void logout()
        {
            string userInAccount = UserDAO.GetAccountByID(Program.CurrentUserID);
            string account = tbAccount.Text;
            string pass = tbPassword.Text;
            DataTable data = UserDAO.GetUserByAccount(account);
            if (data.Rows.Count > 0 && data.Rows[0].Field<string>("Pass") == pass && userInAccount.Equals(account))
            {
                logoutDone();
            }
            else
            {
                labelError.Text = "Thông tin không chính xác";
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            logout();
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    logout();
                    break;
            }
        }
    }
}

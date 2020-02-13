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
    public partial class FormChangePassword : Form
    {
        public FormNhanVien formNhanVien;
        public FormChangePassword()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            changePassword();
        }

        private void changePassword()
        {
            string userInAccount = UserDAO.GetAccountByID(Program.CurrentUserID);
            string account = tbAccount.Text;
            string pass = tbPassword.Text;
            string newPass = tbNewPassword.Text;
            string confirmNewPass = tbConfirmNewPassword.Text;
            DataTable data = UserDAO.GetUserByAccount(account);
            bool isUpdatePasswordSuccess = UserDAO.UpdatePassword(newPass, account);
            if (data.Rows.Count > 0 && data.Rows[0].Field<string>("Pass") == pass && isUpdatePasswordSuccess && userInAccount.Equals(account) && newPass.Equals(confirmNewPass))
            {
                changePasswordDone();
            }
            else
            {
                labelError.Text = "Thông tin không chính xác";
            }
        }

        private void changePasswordDone()
        {
            MessageBox.Show(Constant.sMessageUpdatePasswordSuccess);
            this.Close();
        }

        private void tbConfirmNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    changePassword();
                    break;
            }
        }
    }
}

using ParkingMangement.DAO;
using ParkingMangement.DTO;
using ParkingMangement.GUI;
using ParkingMangement.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingMangement
{
    public partial class FormLogin : Form
    {
        public FormNhanVien formNhanVien;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
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
            this.ActiveControl = labelError;
            labelError.Text = "";

            tbAccount.Text = Constant.sHintTextUsername;
            tbAccount.GotFocus +=  new EventHandler(RemoveHintTextUsername);
            tbAccount.LostFocus += new EventHandler(AddHintTextUsername);

            tbPassword.Text = Constant.sHintTextPassword;
            tbPassword.GotFocus += new EventHandler(RemoveHintTextPassword);
            tbPassword.LostFocus += new EventHandler(AddHintTextPassword);
        }

        private void login()
        {
            string account = tbAccount.Text;
            string pass = tbPassword.Text;
            int rememberMe = cbRememberMe.Checked ? 1 : 0;
            DataTable data = UserDAO.GetUserByAccount(account);
            if (data.Rows.Count > 0 && data.Rows[0].Field<string>("Pass") == pass)
            {
                loginDone(data);
                UserDAO.UpdateRememberMe(rememberMe, account);
            } else
            {
                labelError.Text = "Thông tin không chính xác";
            }
        }

        private void loginDone(DataTable data)
        {
            this.Hide();
            Program.StartWorkTime = DateTime.Now;                     

            Form f = null;
            string userId = data.Rows[0].Field<string>("UserID");
            Program.CurrentUserID = userId;
            if (data.Rows[0].Field<string>("IDFunct") != Constant.FUNCTION_ID_NHAN_VIEN)
            {
                f = new FormQuanLy();
                ((FormQuanLy)f).formNhanVien = this.formNhanVien;
                Program.CurrentManagerUserID = userId;
            } else
            {
                f = new FormNhanVien();
                Program.CurrentStaffUserID = userId;
            }

            if (formNhanVien != null)
            {
                if (f.GetType() == typeof(FormQuanLy))
                {
                    f.FormClosing += new FormClosingEventHandler(FormQuanLy_FormClosing);
                }
                else
                {
                    formNhanVien.Hide();
                    Util.doLogOut();
                    f.FormClosing += new FormClosingEventHandler(FormNhanVien_FormClosing);
                }
                f.Show();
            }
            else
            {
                f.ShowDialog();
            }

            LogUtil.addLoginLog();
        }     

        void FormQuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
            if (formNhanVien != null)
            {
                Program.CurrentStaffUserID = formNhanVien.CurrentUserID;
            }
        }

        void FormNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
            if (formNhanVien != null)
            {
                formNhanVien.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    login();
                    break;
            }
        }

        public void RemoveHintTextUsername(object sender, EventArgs e)
        {
            tbAccount.Text = "";
        }

        public void AddHintTextUsername(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAccount.Text))
            {
                tbAccount.Text = Constant.sHintTextUsername;
            } else
            {
                string password = UserDAO.GetPasswordByAccount(tbAccount.Text);
                int rememberMe = UserDAO.GetRememberByAccount(tbAccount.Text);
                if (rememberMe == 1)
                {
                    tbPassword.Text = password;
                }
                cbRememberMe.Checked = rememberMe == 1;
            }
        }

        public void RemoveHintTextPassword(object sender, EventArgs e)
        {
            string password = UserDAO.GetPasswordByAccount(tbAccount.Text);
            if (password.Equals("") || tbPassword.Text.Equals(Constant.sHintTextPassword))
            {
                tbPassword.Text = "";
            }
        }

        public void AddHintTextPassword(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPassword.Text))
                tbPassword.Text = Constant.sHintTextPassword;
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void tbAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !tbAccount.Text.Equals(null))
            {
                DataTable dt = UserDAO.GetUserByID(tbAccount.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    loginDone(dt);
                }
                else
                {
                    labelError.Text = "Thông tin không chính xác";
                }
            }
        }
    }
}

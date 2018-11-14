using ParkingMangement.DAO;
using ParkingMangement.DTO;
using ParkingMangement.GUI;
using ParkingMangement.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
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
        }

        private void login()
        {
            string account = tbAccount.Text;
            string pass = tbPassword.Text;
            DataTable data = UserDAO.GetUserByAccount(account);
            if (data.Rows.Count > 0 && data.Rows[0].Field<string>("Pass") == pass)
            {
                loginDone(data);
            } else
            {
                labelError.Text = "Thông tin không chính xác";
            }

            loginAPIAsync(account, pass);
        }

        private void loginAPIAsync(string account, string pass)
        {
            WebClient webClient = ApiUtil.getWebClient();
            webClient.QueryString.Add(ApiUtil.PARAM_ACCOUNT, account);
            webClient.QueryString.Add(ApiUtil.PARAM_PASSWORD, pass);
            try
            {
                String responseString = webClient.DownloadString(ApiUtil.API_LOGIN);
                MessageBox.Show(responseString);
            } catch (Exception e)
            {
                
            }
        }

        private void loginDone(DataTable data)
        {
            this.Hide();
            Program.StartWorkTime = DateTime.Now;
            Program.CurrentUserID = data.Rows[0].Field<string>("UserID");
            Form f = new FormQuanLy();
            if (data.Rows[0].Field<string>("IDFunct") == Constant.FUNCTION_ID_NHAN_VIEN)
            {
                f = new FormNhanVien();
            }

            if (formNhanVien != null)
            {
                if (f.GetType() == typeof(FormQuanLy))
                {
                    f.FormClosing += new FormClosingEventHandler(FormQuanLy_FormClosing);
                } else
                {
                    formNhanVien.Hide();
                    Util.doLogOut();
                    f.FormClosing += new FormClosingEventHandler(FormNhanVien_FormClosing);
                }
            }

            f.Show();
            
            LogUtil.addLoginLog();
        }

        void FormQuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
            if (formNhanVien != null)
            {
                Program.CurrentUserID = formNhanVien.CurrentUserID;
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
    }
}

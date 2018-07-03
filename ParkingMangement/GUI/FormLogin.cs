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

namespace ParkingMangement
{
    public partial class FormLogin : Form
    {
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
        }

        private void addLoginLog()
        {
            LogUtil.addLog(Constant.LOG_TYPE_LOGIN, "");
        }

        private void loginDone(DataTable data)
        {
            Program.StartWorkTime = DateTime.Now;
            Program.CurrentUserID = data.Rows[0].Field<string>("UserID");
            this.Hide();
            Form f = new FormQuanLy();
            if (data.Rows[0].Field<string>("IDFunct") == Constant.FUNCTION_ID_NHAN_VIEN)
            {
                f = new FormNhanVien();
            }
            f.Closed += (s, args) => this.Close();
            f.Show();

            addLoginLog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

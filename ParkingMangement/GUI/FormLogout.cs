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
            string account = tbAccount.Text;
            string pass = tbPassword.Text;
            DataTable data = UserDAO.GetUserByAccount(account);
            if (data.Rows.Count > 0 && data.Rows[0].Field<string>("Pass") == pass)
            {
                logoutDone(data);
            }
            else
            {
                labelError.Text = "Thông tin không chính xác";
            }
        }

        private void addLoginLog()
        {
            LogDTO logDTO = new LogDTO();
            logDTO.LogTypeID = Constant.LOG_TYPE_LOGIN;
            logDTO.Account = Program.CurrentUserID;
            logDTO.ProcessDate = DateTime.Now;
            logDTO.Computer = Environment.MachineName;
            LogUtil.addLog(logDTO);
        }

        private void logoutDone(DataTable data)
        {
 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }
    }
}

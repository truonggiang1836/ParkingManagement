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
    public partial class FormLoginByCard : Form
    {
        public FormNhanVien formNhanVien;
        public FormLoginByCard()
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
                DataTable dt = UserDAO.GetUserByID(tbUserID.Text);
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

        private void loginDone(DataTable data)
        {
            this.Hide();
            Program.StartWorkTime = DateTime.Now;
            Program.CurrentUserID = data.Rows[0].Field<string>("UserID");
            Form f = new FormNhanVien();
            if (data.Rows[0].Field<string>("IDFunct") != Constant.FUNCTION_ID_NHAN_VIEN)
            {
                f = new FormQuanLy();
                ((FormQuanLy)f).formNhanVien = this.formNhanVien;
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
            }

            f.ShowDialog();

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
    }
}

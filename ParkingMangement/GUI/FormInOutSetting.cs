using ParkingMangement.DAO;
using ParkingMangement.DTO;
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
    public partial class FormInOutSetting : Form
    {
        public FormInOutSetting()
        {
            InitializeComponent();
        }

        private void FormInOutSetting_Load(object sender, EventArgs e)
        {
            loadConfig();
        }

        private void loadConfig()
        {
            int inOutType = ConfigDAO.GetInOutType();
            switch (inOutType)
            {
                case ConfigDTO.TYPE_IN_IN:
                    rbIn_In.Checked = true;
                    break;
                case ConfigDTO.TYPE_OUT_OUT:
                    rbOut_Out.Checked = true;
                    break;
                case ConfigDTO.TYPE_IN_OUT:
                    rbIn_Out.Checked = true;
                    break;
                case ConfigDTO.TYPE_OUT_IN:
                    rbOut_In.Checked = true;
                    break;
                default:
                    rbIn_Out.Checked = true;
                    break;
            }
        }

        private void saveConfig()
        {
            int inOutType = ConfigDAO.GetInOutType();
            if (rbIn_In.Checked)
            {
                inOutType = ConfigDTO.TYPE_IN_IN;
            } else if (rbOut_Out.Checked)
            {
                inOutType = ConfigDTO.TYPE_OUT_OUT;
            } else if (rbIn_Out.Checked)
            {
                inOutType = ConfigDTO.TYPE_IN_OUT;
            } else if (rbOut_In.Checked)
            {
                inOutType = ConfigDTO.TYPE_OUT_IN;
            }
            if (ConfigDAO.SetInOutType(inOutType))
            {
                MessageBox.Show(Constant.sMessageUpdateSuccess);
                this.Close();
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            saveConfig();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

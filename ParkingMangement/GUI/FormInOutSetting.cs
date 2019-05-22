using ParkingMangement.DAO;
using ParkingMangement.DTO;
using ParkingMangement.Model;
using ParkingMangement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ParkingMangement.GUI
{
    public partial class FormInOutSetting : Form
    {
        public FormNhanVien formNhanVien;
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
            int inOutType = Util.getConfigFile().inOutType;
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
            int inOutType = Util.getConfigFile().inOutType;
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
            if (saveInOutTypeToConfig(inOutType))
            {
                //MessageBox.Show(Constant.sMessageUpdateSuccess);
                this.Close();
            }
        }

        private static bool saveInOutTypeToConfig(int inOutType)
        {
            try
            {
                String filePath = Application.StartupPath + "\\" + Constant.sFileNameConfig;
                if (File.Exists(filePath))
                {
                    Config config = Util.getConfigFile();
                    config.inOutType = inOutType;

                    XmlSerializer xs = new XmlSerializer(typeof(Config));
                    TextWriter txtWriter = new StreamWriter(filePath);
                    xs.Serialize(txtWriter, config);
                    txtWriter.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                
            }
            return false;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            saveConfig();
            if (formNhanVien != null)
            {
                formNhanVien.updateCauHinhHienThiXeRaVao();
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

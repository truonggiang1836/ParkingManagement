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
    public partial class FormZoomCameraSetting : Form
    {
        public FormNhanVien formNhanVien;
        private List<int> listZoomValue = new List<int>();
        public FormZoomCameraSetting()
        {
            InitializeComponent();
        }

        private void FormZoomCameraSetting_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i = i + 5)
            {
                int value = i;
                listZoomValue.Add(value);
                cbZoomValue.Items.Add(value);
            }
            cbZoomValue.SelectedIndex = listZoomValue.IndexOf(Util.getConfigFile().zoomCameraValue);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (formNhanVien != null)
            {
                int value = listZoomValue[cbZoomValue.SelectedIndex];
                saveZoomCameraValueToConfig(value);
                formNhanVien.configVLC(value);
            }
        }

        private static bool saveZoomCameraValueToConfig(int value)
        {
            try
            {
                String filePath = Application.StartupPath + "\\" + Constant.sFileNameConfig;
                if (File.Exists(filePath))
                {
                    Config config = Util.getConfigFile();
                    config.zoomCameraValue = value;

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
    }
}

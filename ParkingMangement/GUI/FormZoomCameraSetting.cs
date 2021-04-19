using CameraViewer;
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
        private List<float> listZoomValue = new List<float>();
        public FormZoomCameraSetting()
        {
            InitializeComponent();
        }

        private void FormZoomCameraSetting_Load(object sender, EventArgs e)
        {
            //int maxZoom = 100;
            
            for (int i = 1; i <= 20; i = i + 1)
            {
                float value = (float) i * 5;
                listZoomValue.Add(value);
                cbZoomValue1.Items.Add(value);
                cbZoomValue2.Items.Add(value);
                cbZoomValue3.Items.Add(value);
                cbZoomValue4.Items.Add(value);
            }

            if (!Constant.IS_NEW_CAMERA)
            {
                Config config = Util.getConfigFile();
                cbZoomValue1.SelectedIndex = listZoomValue.IndexOf(config.ZoomCamera1);
                cbZoomValue2.SelectedIndex = listZoomValue.IndexOf(config.ZoomCamera2);
                cbZoomValue3.SelectedIndex = listZoomValue.IndexOf(config.ZoomCamera3);
                cbZoomValue4.SelectedIndex = listZoomValue.IndexOf(config.ZoomCamera4);
            }
            else
            {
                Configuration configuration = new Configuration(Path.GetDirectoryName(Application.ExecutablePath));
                cbZoomValue1.SelectedIndex = listZoomValue.IndexOf(configuration.GetZoomCamera("cam1"));
                cbZoomValue2.SelectedIndex = listZoomValue.IndexOf(configuration.GetZoomCamera("cam2"));
                cbZoomValue3.SelectedIndex = listZoomValue.IndexOf(configuration.GetZoomCamera("cam3"));
                cbZoomValue4.SelectedIndex = listZoomValue.IndexOf(configuration.GetZoomCamera("cam4"));
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            float value1 = listZoomValue[cbZoomValue1.SelectedIndex];
            float value2 = listZoomValue[cbZoomValue2.SelectedIndex];
            float value3 = listZoomValue[cbZoomValue3.SelectedIndex];
            float value4 = listZoomValue[cbZoomValue4.SelectedIndex];
            saveZoomCameraValueToConfig(value1, value2, value3, value4);

            if (!Constant.IS_NEW_CAMERA)
            {
                if (formNhanVien != null)
                {
                    formNhanVien.configVLC(value1, value2, value3, value4);
                }               
            }
            else
            {
                this.Close();
            }
        }

        private static bool saveZoomCameraValueToConfig(float value1, float value2, float value3, float value4)
        {
            try
            {
                if (!Constant.IS_NEW_CAMERA)
                {
                    String filePath = Application.StartupPath + "\\" + Constant.sFileNameConfig;
                    if (File.Exists(filePath))
                    {
                        Config config = Util.getConfigFile();
                        config.ZoomCamera1 = value1;
                        config.ZoomCamera2 = value2;
                        config.ZoomCamera3 = value3;
                        config.ZoomCamera4 = value4;

                        XmlSerializer xs = new XmlSerializer(typeof(Config));
                        TextWriter txtWriter = new StreamWriter(filePath);
                        xs.Serialize(txtWriter, config);
                        txtWriter.Close();
                    }
                }
                else
                {
                    Configuration configuration = new Configuration(Path.GetDirectoryName(Application.ExecutablePath));
                    configuration.SaveZoomCamera("cam1", value1);
                    configuration.SaveZoomCamera("cam2", value2);
                    configuration.SaveZoomCamera("cam3", value3);
                    configuration.SaveZoomCamera("cam4", value4);
                }
                return true;
            }
            catch (Exception e)
            {

            }
            return false;
        }
    }
}

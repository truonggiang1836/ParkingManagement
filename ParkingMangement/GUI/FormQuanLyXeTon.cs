using Newtonsoft.Json;
using ParkingMangement.DAO;
using ParkingMangement.DTO;
using ParkingMangement.Model;
using ParkingMangement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingMangement.GUI
{
    public partial class FormQuanLyXeTon : Form
    {
        private Timer timerReadUHFData;
        private UHFReader mUHFReader;
        private PrintDocument printDocument1 = new PrintDocument();
        Bitmap memoryImage;
        public FormQuanLyXeTon()
        {
            InitializeComponent();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void printDocument1_PrintPage(System.Object sender,
               System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void FormQuanLyXeTon_Load(object sender, EventArgs e)
        {
            FormQuanLy.loadUserDataToComboBox(comboBoxNhanVienVao);
            FormQuanLy.loadUserDataToComboBox(comboBoxNhanVienRa);

            FormQuanLy.setFormatTimeForDateTimePicker(dateTimePickerCarTimeIn);
            FormQuanLy.setFormatTimeForDateTimePicker(dateTimePickerCarTimeOut);
            FormQuanLy.setFormatDateForDateTimePicker(dateTimePickerCarDateIn);
            FormQuanLy.setFormatDateForDateTimePicker(dateTimePickerCarDateOut);
            loadPartDataWithFieldAllToComboBox(comboBoxTruyVanLoaiXe);
            loadTatCaXeTon();

            mUHFReader = new UHFReader();
            if (Util.getConfigFile().isUsingUhf.Equals("yes"))
            {
                initUhfTimer();
            }
        }

        private void loadPartDataWithFieldAllToComboBox(ComboBox cb)
        {
            DataTable dt = PartDAO.GetAllData();
            DataRow dr = dt.NewRow();
            dr["PartName"] = "Tất cả";
            dt.Rows.InsertAt(dr, 0);
            cb.DataSource = dt;
            cb.DisplayMember = "PartName";
            cb.ValueMember = "ID";
        }

        private CarDTO getCarModel()
        {
            CarDTO carDTO = new CarDTO();
            if (comboBoxTruyVanLoaiXe.SelectedIndex > 0)
            {
                DataRow dataRow = ((DataRowView)comboBoxTruyVanLoaiXe.SelectedItem).Row;
                carDTO.IdPart = Convert.ToString(dataRow["ID"]);
            }
            DateTime startDate = dateTimePickerCarDateIn.Value;
            DateTime startTime = dateTimePickerCarTimeIn.Value;
            startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startTime.Hour, startTime.Minute, 0);
            carDTO.TimeStart = startDate;
            DateTime endDate = dateTimePickerCarDateOut.Value;
            DateTime endTime = dateTimePickerCarTimeOut.Value;
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, endTime.Hour, endTime.Minute, 59);
            carDTO.TimeEnd = endDate;
            try
            {
                carDTO.CardIdentify = tbCarIdentifySearch.Text;
            }
            catch (Exception e)
            {

            }
            carDTO.Digit = tbCarDigitSearch.Text;
            carDTO.Id = tbCarIDSearch.Text;
            if (comboBoxNhanVienVao.SelectedIndex > 0)
            {
                DataRow dataRow = ((DataRowView)comboBoxNhanVienVao.SelectedItem).Row;
                carDTO.IdIn = Convert.ToString(dataRow["UserID"]);
            }
            if (comboBoxNhanVienRa.SelectedIndex > 0)
            {
                DataRow dataRow = ((DataRowView)comboBoxNhanVienRa.SelectedItem).Row;
                carDTO.IdOut = Convert.ToString(dataRow["UserID"]);
            }
            return carDTO;
        }

        private void searchXeTon()
        {
            CarDTO carDTO = getCarModel();

            DataTable data = CarDAO.searchXeTon(carDTO);
            dgvCarList.DataSource = data;

            dgvCarList.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void loadTatCaXeTon()
        {
            DataTable data = CarDAO.searchXeTon(null);
            dgvCarList.DataSource = data;

            dgvCarList.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void dgvCarList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = e.RowIndex;
            int Count = dgvCarList.RowCount;
            if (Index < Count - 1)
            {
                loadCarInfoFromDataGridViewRow(Index);
            }
        }

        private void loadCarInfoFromDataGridViewRow(int Index)
        {
            if (Index < 0)
            {
                return;
            }
            string identify = Convert.ToString(dgvCarList.Rows[Index].Cells["CarLogIdentify"].Value);
            if (!string.IsNullOrEmpty(identify))
            {
                tbCarLogIdentify.Text = identify;
            }

            pictureBoxCarLogImage1.Image = null;
            pictureBoxCarLogImage3.Image = null;
            pictureBoxCarLogImage2.Image = null;
            pictureBoxCarLogImage4.Image = null;
            string image1 = Convert.ToString(dgvCarList.Rows[Index].Cells["CarLogImages"].Value);
            if (!string.IsNullOrEmpty(image1))
            {
                string filePath = Constant.getSharedImageFolder() + image1;
                if (File.Exists(filePath))
                {
                    pictureBoxCarLogImage1.Image = Image.FromFile(filePath);
                }
            }
            string image2 = Convert.ToString(dgvCarList.Rows[Index].Cells["CarLogImages2"].Value);
            if (!string.IsNullOrEmpty(image2))
            {
                string filePath = Constant.getSharedImageFolder() + image2;
                if (File.Exists(filePath))
                {
                    pictureBoxCarLogImage3.Image = Image.FromFile(filePath);
                }
            }
            string image3 = Convert.ToString(dgvCarList.Rows[Index].Cells["CarLogImages3"].Value);
            if (!string.IsNullOrEmpty(image3))
            {
                string filePath = Constant.getSharedImageFolder() + image3;
                if (File.Exists(filePath))
                {
                    pictureBoxCarLogImage2.Image = Image.FromFile(filePath);
                }
            }
            string image4 = Convert.ToString(dgvCarList.Rows[Index].Cells["CarLogImages4"].Value);
            if (!string.IsNullOrEmpty(image4))
            {
                string filePath = Constant.getSharedImageFolder() + image4;
                if (File.Exists(filePath))
                {
                    pictureBoxCarLogImage4.Image = Image.FromFile(filePath);
                }
            }
        }

        private void btnXemDanhSachXeTon_Click(object sender, EventArgs e)
        {
            searchXeTon();

            //CaptureScreen();
            //PrintDialog printDlg = new PrintDialog();
            //printDlg.Document = printDocument1;
            //printDlg.AllowSelection = true;
            //printDlg.AllowSomePages = true;
            ////Call ShowDialog  
            //if (printDlg.ShowDialog() == DialogResult.OK) printDocument1.Print();
        }      

        private void dgvCarList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Util.setRowNumber(dgvCarList, "STT_CarList");
        }

        private void pictureBoxCarLogImage1_Click(object sender, EventArgs e)
        {
            FormImageDetail f = new FormImageDetail(pictureBoxCarLogImage1.Image);
            f.Show();
        }

        private void pictureBoxCarLogImage2_Click(object sender, EventArgs e)
        {
            FormImageDetail f = new FormImageDetail(pictureBoxCarLogImage2.Image);
            f.Show();
        }

        private void pictureBoxCarLogImage3_Click(object sender, EventArgs e)
        {
            FormImageDetail f = new FormImageDetail(pictureBoxCarLogImage3.Image);
            f.Show();
        }

        private void pictureBoxCarLogImage4_Click(object sender, EventArgs e)
        {
            FormImageDetail f = new FormImageDetail(pictureBoxCarLogImage4.Image);
            f.Show();
        }

        private void timerReadUHFData_Tick(object sender, EventArgs e)
        {
            int frmcomportindexIn = mUHFReader.getComportIndex(Util.getConfigFile().comReceiveIn);
            int frmcomportindexOut = mUHFReader.getComportIndex(Util.getConfigFile().comReceiveOut);
            string uhfInCardId = mUHFReader.GetUHFData(frmcomportindexIn);
            string uhfOutCardId = mUHFReader.GetUHFData(frmcomportindexOut);
            string uhfCardId = uhfInCardId;
            if (uhfCardId == null)
            {
                uhfCardId = uhfOutCardId;
            }

            if (uhfCardId != null)
            {
                TextBox focusedTextbox = null;
                if (tbCarIDSearch.Focused)
                {
                    focusedTextbox = tbCarIDSearch;
                }
                if (focusedTextbox != null)
                {
                    focusedTextbox.Text = uhfCardId;
                }
            }
        }

        private void initUhfTimer()
        {
            timerReadUHFData = new Timer();
            timerReadUHFData.Enabled = true;
            timerReadUHFData.Tick += new System.EventHandler(this.timerReadUHFData_Tick);
        }

        private void FormQuanLyXeVaoRa_FormClosing(object sender, FormClosingEventArgs e)
        {
            int count = 0;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Visible == true)//will not count hidden forms
                    count++;
            }
            if (count == 1)
            {
                Application.Exit();
            }
        }

        private void btnXemTatCaXeTon_Click(object sender, EventArgs e)
        {
            loadTatCaXeTon();
        }

        private void addEventReadPegasusReaderCOM()
        {
            if (Program.readerLeftSerialPort != null && Program.readerLeftSerialPort.IsOpen)
            {
                Program.readerLeftSerialPort.DataReceived += portComReader_DataReceived;
            }

            if (Program.readerRightSerialPort != null && Program.readerRightSerialPort.IsOpen)
            {
                Program.readerRightSerialPort.DataReceived += portComReader_DataReceived;
            }

            if (Program.readerCarLeftSerialPort != null && Program.readerCarLeftSerialPort.IsOpen)
            {
                Program.readerCarLeftSerialPort.DataReceived += portComReader_DataReceived;
            }

            if (Program.readerCarRightSerialPort != null && Program.readerCarRightSerialPort.IsOpen)
            {
                Program.readerCarRightSerialPort.DataReceived += portComReader_DataReceived;
            }
        }

        private void removeEventReadPegasusReaderCOM()
        {
            if (Program.readerLeftSerialPort != null && Program.readerLeftSerialPort.IsOpen)
            {
                Program.readerLeftSerialPort.DataReceived -= portComReader_DataReceived;
            }

            if (Program.readerRightSerialPort != null && Program.readerRightSerialPort.IsOpen)
            {
                Program.readerRightSerialPort.DataReceived -= portComReader_DataReceived;
            }

            if (Program.readerCarLeftSerialPort != null && Program.readerCarLeftSerialPort.IsOpen)
            {
                Program.readerCarLeftSerialPort.DataReceived -= portComReader_DataReceived;
            }

            if (Program.readerCarRightSerialPort != null && Program.readerCarRightSerialPort.IsOpen)
            {
                Program.readerCarRightSerialPort.DataReceived -= portComReader_DataReceived;
            }
        }

        private void portComReader_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadLine();
            Console.WriteLine(data);
            string cardID = data.Trim();
            cardID = Regex.Replace(cardID, @"[^\u0009\u000A\u000D\u0020-\u007E]", "");

            handleReceiveComReaderData(cardID);
        }

        public void handleReceiveComReaderData(string uhfCardId)
        {
            Invoke(new MethodInvoker(() =>
            {
                if (uhfCardId != null && !uhfCardId.Equals(""))
                {
                    if (tbCarIDSearch.Focused)
                    {
                        tbCarIDSearch.Text = uhfCardId;
                    }
                }
            }));
        }

        private void FormQuanLyXeTon_Activated(object sender, EventArgs e)
        {
            addEventReadPegasusReaderCOM();
        }

        private void FormQuanLyXeTon_Deactivate(object sender, EventArgs e)
        {
            removeEventReadPegasusReaderCOM();
        }
    }
}

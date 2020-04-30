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
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingMangement.GUI
{
    public partial class FormQuanLyXeVaoRa : Form
    {
        private bool isXemDanhSachXeTon = false;
        private Timer timerReadUHFData;
        public FormQuanLyXeVaoRa()
        {
            InitializeComponent();
        }

        private void FormQuanLyXeVaoRa_Load(object sender, EventArgs e)
        {
            FormQuanLy.loadUserDataToComboBox(comboBoxNhanVienVao);
            FormQuanLy.loadUserDataToComboBox(comboBoxNhanVienRa);

            FormQuanLy.setFormatTimeForDateTimePicker(dateTimePickerCarTimeIn);
            FormQuanLy.setFormatTimeForDateTimePicker(dateTimePickerCarTimeOut);
            FormQuanLy.setFormatDateForDateTimePicker(dateTimePickerCarDateIn);
            FormQuanLy.setFormatDateForDateTimePicker(dateTimePickerCarDateOut);
            loadPartDataWithFieldAllToComboBox(comboBoxTruyVanLoaiXe);

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

        private void btnSearchCar_Click(object sender, EventArgs e)
        {
            isXemDanhSachXeTon = false;
            searchCar();
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
                carDTO.CardIdentify = Convert.ToInt32(tbCarIdentifySearch.Text);
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

        private void searchCar()
        {
            CarDTO carDTO = getCarModel();

            DataTable data = CarDAO.searchAllData(carDTO);
            dgvCarList.DataSource = data;

            dgvCarList.DefaultCellStyle.ForeColor = Color.Black;
            foreach (DataGridViewRow row in dgvCarList.Rows)
            {
                int isLostCard = Convert.ToInt32(dgvCarList.Rows[row.Index].Cells["CarLogIsLostCard"].Value);
                if (isLostCard > 0)
                {
                    foreach (DataGridViewColumn col in dgvCarList.Columns)
                    {
                        dgvCarList[col.Index, row.Index].Style.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void searchXeTon()
        {
            CarDTO carDTO = getCarModel();

            DataTable data = CarDAO.searchXeTon(carDTO);
            dgvCarList.DataSource = data;

            dgvCarList.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void searchMatThe()
        {
            CarDTO carDTO = getCarModel();

            DataTable data = CarDAO.searchMatThe(carDTO);
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
            isXemDanhSachXeTon = true;
            searchXeTon();
        }

        private void btnSaveLostCard_Click(object sender, EventArgs e)
        {
            saveLostCard();
        }

        private void saveLostCard()
        {
            string functionId = Constant.FUNCTION_ID_NHAN_VIEN;
            string[] listFunctionSec = FunctionalDAO.GetFunctionSecByID(functionId).Split(',');
            if (!listFunctionSec.Contains(Constant.NODE_VALUE_LUU_MAT_THE.ToString()))
            {
                MessageBox.Show(Constant.sMessageCanNotSaveLostCard);
                return;
            }

            if (!string.IsNullOrWhiteSpace(tbCarLogIdentify.Text))
            {
                int identify = Convert.ToInt32(tbCarLogIdentify.Text);
                if (CarDAO.isCarOutByIdentify(identify))
                {
                    MessageBox.Show(Constant.sMessageXeDaRaKhoiBai);
                    return;
                }
                CarDTO carDTO = new CarDTO();
                carDTO.Identify = identify;
                carDTO.TimeEnd = DateTime.Now;
                carDTO.IdOut = Program.CurrentUserID;
                carDTO.Cost = 0;
                carDTO.IsLostCard = ConfigDAO.GetLostCard();
                carDTO.Computer = Environment.MachineName;
                carDTO.Account = Program.CurrentUserID;
                carDTO.DateUpdate = DateTime.Now;
                carDTO.DateLostCard = DateTime.Now;
                DialogResult result = MessageBox.Show(Constant.sMessageConfirmSaveLostCard, Constant.sLabelAlert, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (CarDAO.UpdateLostCard(carDTO))
                    {
                        MessageBox.Show(Constant.sMessageUpdateSuccess);
                        if (isXemDanhSachXeTon)
                        {
                            searchXeTon();
                        }
                        else
                        {
                            searchCar();
                        }
                    }
                    else
                    {
                        MessageBox.Show(Constant.sMessageCommonError);
                    }
                }
            }
        }

        private void btnExportDanhSachXe_Click(object sender, EventArgs e)
        {
            isXemDanhSachXeTon = false;
            searchMatThe();
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
            int frmcomportindexIn = UHFReader.getComportIndex(Util.getConfigFile().comReceiveIn);
            int frmcomportindexOut = UHFReader.getComportIndex(Util.getConfigFile().comReceiveOut);
            string uhfInCardId = UHFReader.GetUHFData(frmcomportindexIn);
            string uhfOutCardId = UHFReader.GetUHFData(frmcomportindexOut);
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
    }
}

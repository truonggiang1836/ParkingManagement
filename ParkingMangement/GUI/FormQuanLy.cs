using CameraViewer;
using ClosedXML.Excel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParkingMangement.DAO;
using ParkingMangement.DTO;
using ParkingMangement.Model;
using ParkingMangement.Utils;
using RawInput_dll;
using ReaderB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ParkingMangement.GUI
{
    public partial class FormQuanLy : Form
    {
        public FormNhanVien formNhanVien;
        const int EXPORT_SALE_NOT_YET_SEARCH = 0;
        const int EXPORT_SALE_SEARCH_CONDITION = 1;
        const int EXPORT_SALE_SEARCH_ALL = 2;

        private string[] listFunctionQuanLyNhanSu = { "1", "2" };
        private string[] listFunctionQuanLyDoanhThu = { "3", "4" };
        private string[] listFunctionQuanLyTheLoaiXe = { "5", "6", "23", "7" };
        private string[] listFunctionQuanLyVeThang = { "8", "9", "10", "11", "24", "12", 
            Constant.NODE_VALUE_TIM_VE_THANG.ToString(), Constant.NODE_VALUE_BAO_CAO_CONG_NO.ToString() };
        private string[] listFunctionQuanLyHeThong = { "13", "14", "15", "16" };
        private string[] listFunctionQuanLyXe = { "17", "18", "19", "20" };
        private string[] listFunctionQuanLyPhieuThuChi = { Constant.NODE_VALUE_IN_PHIEU_THU_CHI.ToString(), 
            Constant.NODE_VALUE_IN_PHIEU_THONG_BAO_PHI.ToString(), Constant.NODE_VALUE_LICH_SU_PHIEU_THU_CHI.ToString() };

        private RawInput _rawinput;
        const bool CaptureOnlyInForeground = true;
        private ComputerDTO mComputerDTO;
        private int mExportSaleType = EXPORT_SALE_NOT_YET_SEARCH;
        private System.Windows.Forms.Timer timerReadUHFData;
        private Config mConfig;
        private Size oldSize;
        private int _lastFormSize;
        private UHFReader mUHFReader;
        private PrintDocument printDocument1 = new PrintDocument();
        private Bitmap memoryImage;
        private int mPrintReceiptCost = 0;
        public FormQuanLy()
        {
            InitializeComponent();
            _lastFormSize = GetFormArea(this.Size);
          
        }

        private void FormQuanLy_Load(object sender, EventArgs e)
        {
            mConfig = Util.getConfigFile();
            if (formNhanVien != null && formNhanVien._rawinput != null)
            {
                _rawinput = formNhanVien._rawinput;
            }
            else
            {
                _rawinput = new RawInput(Handle, CaptureOnlyInForeground);
            }
            _rawinput.KeyPressed += OnKeyPressed;

            loadUserInfoTab();
            checkShowHideAllTabPage();
            labelKetQuaTaoThe.Text = "";

            //mUHFReader = new UHFReader();
            //if (mConfig.isUsingUhf.Equals("yes"))
            //{
            //    initUhfTimer();
            //}
            getDataFromUhfReader();

            tbCardIDCreate.GotFocus += textBox_Enter;

            readPegasusReaderCOM();
        }

        void textBox_Enter(object sender, EventArgs e)
        {
            focusedTextbox = (TextBox)sender;
        }

        private void FormQuanLy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Util.showConfirmLogoutPopup(this);
            }
        }

        /*
        User data
        */

        private void loadUserInfoTab()
        {
            panelChinhSuaNhanVien.Enabled = false;
            btnUpdateUser.Text = Constant.sButtonEdit;
            loadUserList();
            loadSexDataToComboBox(cbUserSexCreate);
            loadSexDataToComboBox(cbUserSexEdit);
            loadFunctionalDataToComboBox(cbUserFunctionCreate);
            loadFunctionalDataToComboBox(cbUserFunctionEdit);

            int Index = dgvUserList.CurrentRow.Index;
            loadUserInfoFromDataGridViewRow(Index);
        }

        private void loadUserList()
        {
            dgvUserList.DataSource = UserDAO.GetAllData();
            dgvUserList2.DataSource = UserDAO.GetID_Name_Function();
        }

        private void loadSexDataToComboBox(ComboBox cb)
        {
            cb.DataSource = SexDAO.GetAllData();
            cb.DisplayMember = "SexName";
            cb.ValueMember = "SexID";
        }

        private void loadFunctionalDataToComboBox(ComboBox cb)
        {
            cb.DataSource = FunctionalDAO.GetAllData();
            cb.DisplayMember = "FunctionName";
            cb.ValueMember = "FunctionID";
        }

        private bool checkCreateUserData()
        {
            if (string.IsNullOrWhiteSpace(tbUserIDCreate.Text))
            {
                MessageBox.Show(Constant.sMessageUserIdNullError);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbUserNameCreate.Text))
            {
                MessageBox.Show(Constant.sMessageUserNameNullError);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbUserAccountCreate.Text))
            {
                MessageBox.Show(Constant.sMessageAccountNullError);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbUserPassCreate.Text))
            {
                MessageBox.Show(Constant.sMessagePasswordNullError);
                return false;
            }
            if (!tbUserPassCreate.Text.Equals(tbUserConfirmPassCreate.Text))
            {
                MessageBox.Show(Constant.sMessageConfirmPasswordError);
                return false;
            }
            return true;
        }

        private bool checkUpdateUserData()
        {
            if (string.IsNullOrWhiteSpace(tbUserNameEdit.Text))
            {
                MessageBox.Show(Constant.sMessageUserNameNullError);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbUserAccountEdit.Text))
            {
                MessageBox.Show(Constant.sMessageAccountNullError);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbUserPassEdit.Text))
            {
                MessageBox.Show(Constant.sMessagePasswordNullError);
                return false;
            }
            if (!tbUserPassEdit.Text.Equals(tbUserConfirmPassEdit.Text))
            {
                MessageBox.Show(Constant.sMessageConfirmPasswordError);
                return false;
            }
            return true;
        }

        private void createUser()
        {
            UserDTO userDTO = new UserDTO();
            userDTO.Id = tbUserIDCreate.Text.Trim();
            userDTO.Name = tbUserNameCreate.Text.Trim();
            userDTO.Account = tbUserAccountCreate.Text.Trim();
            userDTO.Password = tbUserPassCreate.Text.Trim();

            DataRow functionDataRow = ((DataRowView)cbUserFunctionCreate.SelectedItem).Row;
            userDTO.FunctionId = functionDataRow["FunctionID"].ToString();

            DataRow sexDataRow = ((DataRowView)cbUserSexCreate.SelectedItem).Row;
            userDTO.SexId = Convert.ToInt32(sexDataRow["SexID"]);

            UserDAO.Insert(userDTO);
            LogUtil.addLogTaoMoiNhanVien(userDTO);
            loadUserList();
        }

        private void updateUser()
        {
            UserDTO oldUserDTO = UserDAO.GetUserModelByID(tbUserIDEdit.Text.Trim());
            UserDTO userDTO = new UserDTO();
            userDTO.Id = tbUserIDEdit.Text.Trim();
            userDTO.Name = tbUserNameEdit.Text.Trim();
            userDTO.Account = tbUserAccountEdit.Text.Trim();
            userDTO.Password = tbUserPassEdit.Text.Trim();

            DataRow functionDataRow = ((DataRowView)cbUserFunctionEdit.SelectedItem).Row;
            userDTO.FunctionId = functionDataRow["FunctionID"].ToString();

            DataRow sexDataRow = ((DataRowView)cbUserSexEdit.SelectedItem).Row;
            userDTO.SexId = Convert.ToInt32(sexDataRow["SexID"]);

            UserDAO.Update(userDTO);
            LogUtil.addLogChinhSuaNhanVien(oldUserDTO, userDTO);
            loadUserList();
        }

        private void loadUserInfoFromDataGridViewRow(int Index)
        {
            if (Index < 0)
            {
                return;
            }
            string id = Convert.ToString(dgvUserList.Rows[Index].Cells["ID"].Value);
            tbUserIDEdit.Text = id;
            string account = Convert.ToString(dgvUserList.Rows[Index].Cells["Account"].Value);
            tbUserAccountEdit.Text = account;
            string pass = Convert.ToString(dgvUserList.Rows[Index].Cells["Pass"].Value);
            tbUserPassEdit.Text = pass;
            string nameUser = Convert.ToString(dgvUserList.Rows[Index].Cells["NameUser"].Value);
            tbUserNameEdit.Text = nameUser;
            string sexName = Convert.ToString(dgvUserList.Rows[Index].Cells["SexName"].Value);
            cbUserSexEdit.Text = sexName;
            string functionName = Convert.ToString(dgvUserList.Rows[Index].Cells["FunctionName"].Value);
            cbUserFunctionEdit.Text = functionName;
        }

        private void clearInputUserInfo()
        {
            tbUserIDCreate.Text = "";
            tbUserAccountCreate.Text = "";
            tbUserPassCreate.Text = "";
            tbUserNameCreate.Text = "";
            cbUserSexCreate.SelectedIndex = 0;
            cbUserFunctionCreate.SelectedIndex = 0;
        }

        private void loadWorkList()
        {
            dgvWorkList.DataSource = WorkDAO.GetAllData();
        }

        private void searchWork()
        {
            if (radioButtonWorkDate.Checked)
            {
                DateTime startDate = dateTimePickerWorkAssignDate.Value.Date;
                startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
                DateTime endDate = dateTimePickerWorkAssignDate.Value.Date;
                endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
                dgvWorkList.DataSource = WorkDAO.GetDataByMultiDate(startDate, endDate);
            }
            else if (radioButtonWorkMultiDate.Checked)
            {
                DateTime startDate = dateTimePickerWorkAssignStartDate.Value.Date;
                startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
                DateTime endDate = dateTimePickerWorkAssignEndDate.Value.Date;
                endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
                dgvWorkList.DataSource = WorkDAO.GetDataByMultiDate(startDate, endDate);
            }
        }

        private void btnWorkSearch_Click(object sender, EventArgs e)
        {
            searchWork();
        }

        private void btnWorkAll_Click(object sender, EventArgs e)
        {
            loadWorkList();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (checkCreateUserData())
            {
                createUser();
            }
        }

        private void dgvUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = e.RowIndex;
            int Count = dgvUserList.Rows.Count;
            if (Index < Count)
            {
                loadUserInfoFromDataGridViewRow(Index);
            }
        }

        private void btnCancelCreateUser_Click(object sender, EventArgs e)
        {
            clearInputUserInfo();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (panelChinhSuaNhanVien.Enabled)
            {
                if (checkUpdateUserData())
                {
                    updateUser();
                    panelChinhSuaNhanVien.Enabled = false;
                    btnUpdateUser.Text = Constant.sButtonEdit;
                }
            }
            else
            {
                panelChinhSuaNhanVien.Enabled = true;
                btnUpdateUser.Text = Constant.sButtonUpdate;
            }
        }

        private void btnCancelUpdateUser_Click(object sender, EventArgs e)
        {
            int Index = dgvUserList.CurrentRow.Index;
            loadUserInfoFromDataGridViewRow(Index);
        }

        private void tabQuanLyNhanSu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabQuanLyNhanSu.SelectedTab == tabQuanLyNhanSu.TabPages["tabPageDoBangChamCong"])
            {
                //loadWorkList();
            }
        }

        private void dgvUserList_MouseClick(object sender, MouseEventArgs ev)
        {
            if (ev.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                MenuItem menuItem = new MenuItem(Constant.sButtonDelete);
                int currentRow = dgvUserList.HitTest(ev.X, ev.Y).RowIndex;
                menuItem.Click += new EventHandler((s, e) => Delete_User_Click(s, e, currentRow));
                m.MenuItems.Add(menuItem);

                m.Show(dgvUserList, new Point(ev.X, ev.Y));
            }
        }

        void Delete_User_Click(Object sender, System.EventArgs e, int currentRow)
        {
            showConfirmDeleteUser(currentRow);
        }

        private void showConfirmDeleteUser(int currentRow)
        {
            DialogResult dialogResult = MessageBox.Show(Constant.sMessageConfirmDelete, Constant.sTitleDelete, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                deleteUser(currentRow);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void deleteUser(int currentRow)
        {
            string userID = Convert.ToString(dgvUserList.Rows[currentRow].Cells["ID"].Value);
            UserDAO.Delete(userID);
            LogUtil.addLogXoaNhanVien(userID);
            loadUserList();
        }

        /*
         * Revenue management
         */

        private void loadSaleReportData()
        {
            DataTable data = CarDAO.GetTotalCost(null, null, null, null, CarDAO.ALL_TICKET);
            dgvThongKeDoanhThu.DataSource = data;
        }

        private void searchSaleReport()
        {
            string userInID = null;
            string userOutID = null;
            int ticketType = CarDAO.ALL_TICKET;
            if (cbNhanVienVaoReport.SelectedIndex > 0)
            {
                DataRow dataRow = ((DataRowView)cbNhanVienVaoReport.SelectedItem).Row;
                userInID = Convert.ToString(dataRow["UserID"]);
            }
            if (cbNhanVienRaReport.SelectedIndex > 0)
            {
                DataRow dataRow = ((DataRowView)cbNhanVienRaReport.SelectedItem).Row;
                userOutID = Convert.ToString(dataRow["UserID"]);
            }

            DateTime startDateReport = DateTime.Now;
            DateTime endDateReport = DateTime.Now;
            if (rbOneDateSaleReport.Checked)
            {
                DateTime timeReport = dtDateSaleReport.Value;
                startDateReport = new DateTime(timeReport.Year, timeReport.Month, timeReport.Day, 0, 0, 0);
                endDateReport = new DateTime(timeReport.Year, timeReport.Month, timeReport.Day, 23, 59, 59);

            }
            if (rbMultiDateSaleReport.Checked)
            {
                startDateReport = dtStartDateSaleReport.Value;
                DateTime startTimeReport = dtStartTimeSaleReport.Value;
                startDateReport = new DateTime(startDateReport.Year, startDateReport.Month, startDateReport.Day, startTimeReport.Hour, startTimeReport.Minute, 0);
                endDateReport = dtEndDateSaleReport.Value;
                DateTime endTimeReport = dtEndTimeSaleReport.Value;
                endDateReport = new DateTime(endDateReport.Year, endDateReport.Month, endDateReport.Day, endTimeReport.Hour, endTimeReport.Minute, 0);
            }

            if (rbAllTicketSaleReport.Checked)
            {
                ticketType = CarDAO.ALL_TICKET;
            }
            else if (rbCommonTicketSaleReport.Checked)
            {
                ticketType = CarDAO.COMMON_TICKET;
            }
            else if (rbMonthTicketSaleReport.Checked)
            {
                ticketType = CarDAO.MONTH_TICKET;
            }
            dgvThongKeDoanhThu.DataSource = CarDAO.GetTotalCost(startDateReport, endDateReport, userInID, userOutID, ticketType);
            //string json = Util.getRevenueData(startDateReport, endDateReport, userOutID);
            //Util.syncRevenueToSPMServer(json);
        }

        private void btnAllSaleReport_Click(object sender, EventArgs e)
        {
            loadSaleReportData();
            mExportSaleType = EXPORT_SALE_SEARCH_ALL;
        }

        private void btnSearchSaleReport_Click(object sender, EventArgs e)
        {
            searchSaleReport();
            mExportSaleType = EXPORT_SALE_SEARCH_CONDITION;
        }

        private void tabQuanLyDoanhThu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabQuanLyDoanhThu.SelectedTab == tabQuanLyDoanhThu.TabPages["tabPageThongKeDoanhThu"])
            {
                setFormatDateForDateTimePicker(dtDateSaleReport);
                setFormatDateForDateTimePicker(dtStartDateSaleReport);
                setFormatDateForDateTimePicker(dtEndDateSaleReport);
            }
            else if (tabQuanLyDoanhThu.SelectedTab == tabQuanLyDoanhThu.TabPages["tabPageCongThucTinhTienTheoCongVan"])
            {
                loadPartDataToComboBox(cbLoaiXeTinhTienCongVan);
                loadDataTinhTienTheoCongVan();
            }
            else if (tabQuanLyDoanhThu.SelectedTab == tabQuanLyDoanhThu.TabPages["tabPageCongThucTinhTienLuyTien"])
            {
                loadPartDataToComboBox(cbLoaiXeTinhTienLuyTien);
                loadDataTinhTienLuyTien();
            }
            else if (tabQuanLyDoanhThu.SelectedTab == tabQuanLyDoanhThu.TabPages["tabPageCongThucTongHop"])
            {
                loadPartDataToComboBox(cbLoaiXeTinhTienTongHop);
                loadDataTinhTienTongHop();
            }
            else if (tabQuanLyDoanhThu.SelectedTab == tabQuanLyDoanhThu.TabPages["tabPageCongThucTongHop2"])
            {
                loadPartDataToComboBox(cbLoaiXeTinhTienTongHop2);
                loadDataTinhTienTongHopTheoNgayDem();
            }
        }

        private void loadDataTinhTienTheoCongVan()
        {
            DataRow partDataRow = ((DataRowView)cbLoaiXeTinhTienCongVan.SelectedItem).Row;
            string partID = Convert.ToString(partDataRow["ID"]);
            mComputerDTO = ComputerDAO.GetDataByPartIDAndParkingTypeID(partID, Constant.LOAI_GIU_XE_THEO_CONG_VAN);
            mComputerDTO.PartID = partID;
            mComputerDTO.ParkingTypeID = Constant.LOAI_GIU_XE_THEO_CONG_VAN;

            numericTinhTienCongVanStartHourNight.Value = mComputerDTO.StartHourNight;
            numericTinhTienCongVanEndHourNight.Value = mComputerDTO.EndHourNight;
            trackBarTinhTienCongVanIntervalBetweenDayNight.Value = mComputerDTO.IntervalBetweenDayNight;
            labelIntervalBetweenDayNight.Text = mComputerDTO.IntervalBetweenDayNight + "";
            numericTinhTienCongVanDayCost.Value = mComputerDTO.DayCost;
            numericTinhTienCongVanNightCost.Value = mComputerDTO.NightCost;
            numericTinhTienCongVanDayNightCost.Value = mComputerDTO.DayNightCost;
            trackBarTinhTienCongVanCycleTicketMonth.Value = mComputerDTO.CycleTicketMonth;
            labelTinhTienCongVanCycleTicketMonth.Text = mComputerDTO.CycleTicketMonth + "";
            numericTinhTienCongVanCostTicketMonth.Value = mComputerDTO.CostTicketMonth;
            numericTinhTienCongVanMinTime.Value = mComputerDTO.MinMinute;
            numericTinhTienCongVanMinCost.Value = mComputerDTO.MinCost;
            numericTinhTienCongVanLimit.Value = mComputerDTO.Limit;
        }

        private void updateTinhTienTheoCongVan()
        {
            if (mComputerDTO != null)
            {
                ComputerDTO oldComputerDTO = (ComputerDTO) mComputerDTO.Clone();
                mComputerDTO.StartHourNight = (int)numericTinhTienCongVanStartHourNight.Value;
                mComputerDTO.EndHourNight = (int)numericTinhTienCongVanEndHourNight.Value;

                mComputerDTO.IntervalBetweenDayNight = trackBarTinhTienCongVanIntervalBetweenDayNight.Value;
                mComputerDTO.DayCost = (int)numericTinhTienCongVanDayCost.Value;
                mComputerDTO.NightCost = (int)numericTinhTienCongVanNightCost.Value;
                mComputerDTO.DayNightCost = (int)numericTinhTienCongVanDayNightCost.Value;

                mComputerDTO.CycleTicketMonth = trackBarTinhTienCongVanCycleTicketMonth.Value;
                mComputerDTO.CostTicketMonth = (int)numericTinhTienCongVanCostTicketMonth.Value;
                mComputerDTO.MinMinute = (int)numericTinhTienCongVanMinTime.Value;
                mComputerDTO.MinCost = (int)numericTinhTienCongVanMinCost.Value;
                mComputerDTO.Limit = (int)numericTinhTienCongVanLimit.Value;

                if (mComputerDTO.StartHourNight <= mComputerDTO.EndHourNight)
                {
                    MessageBox.Show("Thời gian bắt đầu phải lớn hơn thời gian kết thúc tính đêm");
                    return;
                }

                if (ComputerDAO.IsHasData(mComputerDTO.PartID, Constant.LOAI_GIU_XE_THEO_CONG_VAN))
                {
                    if (ComputerDAO.Update(mComputerDTO))
                    {
                        MessageBox.Show(Constant.sMessageUpdateSuccess);
                        panelTinhTienCongVan.Enabled = false;
                        LogUtil.addLogChinhSuaGiaTienGuiXe(oldComputerDTO, mComputerDTO, Constant.LOAI_GIU_XE_THEO_CONG_VAN);
                    }
                }
                else
                {
                    if (ComputerDAO.Insert(mComputerDTO))
                    {
                        MessageBox.Show(Constant.sMessageUpdateSuccess);
                        panelTinhTienCongVan.Enabled = false;
                    }
                }
            }
        }

        private void loadDataTinhTienLuyTien()
        {
            DataRow partDataRow = ((DataRowView)cbLoaiXeTinhTienLuyTien.SelectedItem).Row;
            string partID = Convert.ToString(partDataRow["ID"]);
            mComputerDTO = ComputerDAO.GetDataByPartIDAndParkingTypeID(partID, Constant.LOAI_GIU_XE_LUY_TIEN);
            mComputerDTO.PartID = partID;
            mComputerDTO.ParkingTypeID = Constant.LOAI_GIU_XE_LUY_TIEN;

            numericTinhTienLuyTienHourMilestone1.Value = mComputerDTO.HourMilestone1;
            numericTinhTienLuyTienCostMilestone1.Value = mComputerDTO.CostMilestone1;
            numericTinhTienLuyTienHourMilestone2.Value = mComputerDTO.HourMilestone2;
            numericTinhTienLuyTienCostMilestone2.Value = mComputerDTO.CostMilestone2;

            trackBarTinhTienLuyTienCycleMilestone3.Value = mComputerDTO.CycleMilestone3;
            labelTinhTienLuyTienCycleMilestone3.Text = mComputerDTO.CycleMilestone3 + "";
            numericTinhTienLuyTienCostMilestone3.Value = mComputerDTO.CostMilestone3;

            trackBarTinhTienLuyTienCycleTicketMonth.Value = mComputerDTO.CycleTicketMonth;
            labelTinhTienLuyTienCycleTicketMonth.Text = mComputerDTO.CycleTicketMonth + "";
            numericTinhTienLuyTienCostTicketMonth.Value = mComputerDTO.CostTicketMonth;

            if (mComputerDTO.IsAdd.Equals(Constant.TINH_TIEN_LUY_TIEN_KHONG_CONG))
            {
                radioTinhTienLuyTienNoAdd.Checked = true;
            }
            else if (mComputerDTO.IsAdd.Equals(Constant.TINH_TIEN_LUY_TIEN_CONG_1_MOC))
            {
                radioTinhTienLuyTienAdd1Milestone.Checked = true;
            }
            else if (mComputerDTO.IsAdd.Equals(Constant.TINH_TIEN_LUY_TIEN_CONG_2_MOC))
            {
                radioTinhTienLuyTienAdd2Milestone.Checked = true;
            }
        }

        private void updateTinhTienLuyTien()
        {
            if (mComputerDTO != null)
            {
                ComputerDTO oldComputerDTO = (ComputerDTO) mComputerDTO.Clone();
                mComputerDTO.HourMilestone1 = (int)numericTinhTienLuyTienHourMilestone1.Value;
                mComputerDTO.CostMilestone1 = (int)numericTinhTienLuyTienCostMilestone1.Value;
                mComputerDTO.HourMilestone2 = (int)numericTinhTienLuyTienHourMilestone2.Value;
                mComputerDTO.CostMilestone2 = (int)numericTinhTienLuyTienCostMilestone2.Value;

                mComputerDTO.CycleMilestone3 = trackBarTinhTienLuyTienCycleMilestone3.Value;
                mComputerDTO.CostMilestone3 = (int)numericTinhTienLuyTienCostMilestone3.Value;

                mComputerDTO.CycleTicketMonth = trackBarTinhTienLuyTienCycleTicketMonth.Value;
                mComputerDTO.CostTicketMonth = (int)numericTinhTienLuyTienCostTicketMonth.Value;

                if (radioTinhTienLuyTienNoAdd.Checked)
                {
                    mComputerDTO.IsAdd = Constant.TINH_TIEN_LUY_TIEN_KHONG_CONG;
                }
                else if (radioTinhTienLuyTienAdd1Milestone.Checked)
                {
                    mComputerDTO.IsAdd = Constant.TINH_TIEN_LUY_TIEN_CONG_1_MOC;
                }
                else if (radioTinhTienLuyTienAdd2Milestone.Checked)
                {
                    mComputerDTO.IsAdd = Constant.TINH_TIEN_LUY_TIEN_CONG_2_MOC;
                }

                if (mComputerDTO.HourMilestone1 >= mComputerDTO.HourMilestone2)
                {
                    MessageBox.Show("Thời gian mốc 2 phải lớn hơn thời gian mốc 1");
                    return;
                }

                if (ComputerDAO.IsHasData(mComputerDTO.PartID, Constant.LOAI_GIU_XE_LUY_TIEN))
                {
                    if (ComputerDAO.Update(mComputerDTO))
                    {
                        MessageBox.Show(Constant.sMessageUpdateSuccess);
                        panelTinhTienLuyTien.Enabled = false;
                        LogUtil.addLogChinhSuaGiaTienGuiXe(oldComputerDTO, mComputerDTO, Constant.LOAI_GIU_XE_LUY_TIEN);
                    }
                }
                else
                {
                    if (ComputerDAO.Insert(mComputerDTO))
                    {
                        MessageBox.Show(Constant.sMessageUpdateSuccess);
                        panelTinhTienLuyTien.Enabled = false;
                    }
                }
            }
        }

        private void loadDataTinhTienTongHop()
        {
            DataRow partDataRow = ((DataRowView)cbLoaiXeTinhTienTongHop.SelectedItem).Row;
            string partID = Convert.ToString(partDataRow["ID"]);
            mComputerDTO = ComputerDAO.GetDataByPartIDAndParkingTypeID(partID, Constant.LOAI_GIU_XE_TONG_HOP);
            mComputerDTO.PartID = partID;
            mComputerDTO.ParkingTypeID = Constant.LOAI_GIU_XE_TONG_HOP;

            numericTinhTienTongHopStartHourNight.Value = mComputerDTO.StartHourNight;
            numericTinhTienTongHopEndHourNight.Value = mComputerDTO.EndHourNight;
            numericTinhTienTongHopNightCost.Value = mComputerDTO.NightCost;

            numericTinhTienTongHopHourMilestone1.Value = mComputerDTO.HourMilestone1;
            numericTinhTienTongHopCostMilestone1.Value = mComputerDTO.CostMilestone1;
            numericTinhTienTongHopHourMilestone2.Value = mComputerDTO.HourMilestone2;
            numericTinhTienTongHopCostMilestone2.Value = mComputerDTO.CostMilestone2;

            trackBarTinhTienTongHopCycleMilestone3.Value = mComputerDTO.CycleMilestone3;
            labelTinhTienTongHopCycleMilestone3.Text = mComputerDTO.CycleMilestone3 + "";
            numericTinhTienTongHopCostMilestone3.Value = mComputerDTO.CostMilestone3;

            trackBarTinhTienTongHopCycleTicketMonth.Value = mComputerDTO.CycleTicketMonth;
            labelTinhTienTongHopCycleTicketMonth.Text = mComputerDTO.CycleTicketMonth + "";
            numericTinhTienTongHopCostTicketMonth.Value = mComputerDTO.CostTicketMonth;

            if (mComputerDTO.IsAdd.Equals(Constant.TINH_TIEN_LUY_TIEN_KHONG_CONG))
            {
                radioTinhTienTongHopNoAdd.Checked = true;
            }
            else if (mComputerDTO.IsAdd.Equals(Constant.TINH_TIEN_LUY_TIEN_CONG_1_MOC))
            {
                radioTinhTienTongHopAdd1Milestone.Checked = true;
            }
            else if (mComputerDTO.IsAdd.Equals(Constant.TINH_TIEN_LUY_TIEN_CONG_2_MOC))
            {
                radioTinhTienTongHopAdd2Milestone.Checked = true;
            }
        }

        private void updateTinhTienTongHop()
        {
            if (mComputerDTO != null)
            {
                ComputerDTO oldComputerDTO = (ComputerDTO)mComputerDTO.Clone();
                mComputerDTO.StartHourNight = (int)numericTinhTienTongHopStartHourNight.Value;
                mComputerDTO.EndHourNight = (int)numericTinhTienTongHopEndHourNight.Value;
                mComputerDTO.NightCost = (int)numericTinhTienTongHopNightCost.Value;

                mComputerDTO.HourMilestone1 = (int)numericTinhTienTongHopHourMilestone1.Value;
                mComputerDTO.CostMilestone1 = (int)numericTinhTienTongHopCostMilestone1.Value;
                mComputerDTO.HourMilestone2 = (int)numericTinhTienTongHopHourMilestone2.Value;
                mComputerDTO.CostMilestone2 = (int)numericTinhTienTongHopCostMilestone2.Value;

                mComputerDTO.CycleMilestone3 = trackBarTinhTienTongHopCycleMilestone3.Value;
                mComputerDTO.CostMilestone3 = (int)numericTinhTienTongHopCostMilestone3.Value;

                mComputerDTO.CycleTicketMonth = trackBarTinhTienTongHopCycleTicketMonth.Value;
                mComputerDTO.CostTicketMonth = (int)numericTinhTienTongHopCostTicketMonth.Value;

                if (radioTinhTienTongHopNoAdd.Checked)
                {
                    mComputerDTO.IsAdd = Constant.TINH_TIEN_LUY_TIEN_KHONG_CONG;
                }
                else if (radioTinhTienTongHopAdd1Milestone.Checked)
                {
                    mComputerDTO.IsAdd = Constant.TINH_TIEN_LUY_TIEN_CONG_1_MOC;
                }
                else if (radioTinhTienTongHopAdd2Milestone.Checked)
                {
                    mComputerDTO.IsAdd = Constant.TINH_TIEN_LUY_TIEN_CONG_2_MOC;
                }

                if (mComputerDTO.StartHourNight <= mComputerDTO.EndHourNight)
                {
                    MessageBox.Show("Thời gian bắt đầu phải lớn hơn thời gian kết thúc tính đêm");
                    return;
                }
                if (mComputerDTO.HourMilestone1 >= mComputerDTO.HourMilestone2)
                {
                    MessageBox.Show("Thời gian mốc 2 phải lớn hơn thời gian mốc 1");
                    return;
                }

                if (ComputerDAO.IsHasData(mComputerDTO.PartID, Constant.LOAI_GIU_XE_TONG_HOP))
                {
                    if (ComputerDAO.Update(mComputerDTO))
                    {
                        MessageBox.Show(Constant.sMessageUpdateSuccess);
                        panelTinhTienTongHop.Enabled = false;
                        LogUtil.addLogChinhSuaGiaTienGuiXe(oldComputerDTO, mComputerDTO, Constant.LOAI_GIU_XE_TONG_HOP);
                    }
                }
                else
                {
                    if (ComputerDAO.Insert(mComputerDTO))
                    {
                        MessageBox.Show(Constant.sMessageUpdateSuccess);
                        panelTinhTienTongHop.Enabled = false;
                    }
                }
            }
        }

        private void loadDataTinhTienTongHopTheoNgayDem()
        {
            DataRow partDataRow = ((DataRowView)cbLoaiXeTinhTienTongHop2.SelectedItem).Row;
            string partID = Convert.ToString(partDataRow["ID"]);
            mComputerDTO = ComputerDAO.GetDataByPartIDAndParkingTypeID(partID, Constant.LOAI_GIU_XE_TONG_HOP_THEO_NGAY_DEM);
            mComputerDTO.PartID = partID;
            mComputerDTO.ParkingTypeID = Constant.LOAI_GIU_XE_TONG_HOP_THEO_NGAY_DEM;

            numericTinhTienTongHop2StartHourNight.Value = mComputerDTO.StartHourNight;
            numericTinhTienTongHop2EndHourNight.Value = mComputerDTO.EndHourNight;

            numericTinhTienTongHop2HourMilestone1Day.Value = mComputerDTO.HourMilestone1;
            numericTinhTienTongHop2CostMilestone1Day.Value = mComputerDTO.CostMilestone1;
            numericTinhTienTongHop2HourMilestone2Day.Value = mComputerDTO.HourMilestone2;
            numericTinhTienTongHop2CostMilestone2Day.Value = mComputerDTO.CostMilestone2;
            numericTinhTienTongHop2HourMilestone3Day.Value = mComputerDTO.HourMilestone3;
            numericTinhTienTongHop2CostMilestone3Day.Value = mComputerDTO.CostMilestone3;
            numericTinhTienTongHop2CostMilestone4Day.Value = mComputerDTO.CostMilestone4;

            numericTinhTienTongHop2CostMilestone1Night.Value = mComputerDTO.CostMilestoneNight1;
            numericTinhTienTongHop2CostMilestone2Night.Value = mComputerDTO.CostMilestoneNight2;
            numericTinhTienTongHop2CostMilestone3Night.Value = mComputerDTO.CostMilestoneNight3;
            numericTinhTienTongHop2CostMilestone4Night.Value = mComputerDTO.CostMilestoneNight4;

            trackBarTinhTienTongHop2CycleMilestone.Value = mComputerDTO.CycleMilestone3;
            labelTinhTienTongHop2CycleMilestone.Text = mComputerDTO.CycleMilestone3 + "";
            numericTinhTienTongHop2CostMilestone4Day.Value = mComputerDTO.CostMilestone4;

            numericTinhTienTongHop2MinTime.Value = mComputerDTO.MinMinute;
            numericTinhTienTongHop2MinCost.Value = mComputerDTO.MinCost;
        }

        private void updateTinhTienTongHopTheoNgayDem()
        {
            if (mComputerDTO != null)
            {
                ComputerDTO oldComputerDTO = (ComputerDTO)mComputerDTO.Clone();
                mComputerDTO.StartHourNight = (int)numericTinhTienTongHop2StartHourNight.Value;
                mComputerDTO.EndHourNight = (int)numericTinhTienTongHop2EndHourNight.Value;

                mComputerDTO.HourMilestone1 = (int)numericTinhTienTongHop2HourMilestone1Day.Value;
                mComputerDTO.CostMilestone1 = (int)numericTinhTienTongHop2CostMilestone1Day.Value;
                mComputerDTO.HourMilestone2 = (int)numericTinhTienTongHop2HourMilestone2Day.Value;
                mComputerDTO.CostMilestone2 = (int)numericTinhTienTongHop2CostMilestone2Day.Value;
                mComputerDTO.HourMilestone3 = (int)numericTinhTienTongHop2HourMilestone3Day.Value;
                mComputerDTO.CostMilestone3 = (int)numericTinhTienTongHop2CostMilestone3Day.Value;
                mComputerDTO.CostMilestone4 = (int)numericTinhTienTongHop2CostMilestone4Day.Value;

                mComputerDTO.CostMilestoneNight1 = (int)numericTinhTienTongHop2CostMilestone1Night.Value;
                mComputerDTO.CostMilestoneNight2 = (int)numericTinhTienTongHop2CostMilestone2Night.Value;
                mComputerDTO.CostMilestoneNight3 = (int)numericTinhTienTongHop2CostMilestone3Night.Value;
                mComputerDTO.CostMilestoneNight4 = (int)numericTinhTienTongHop2CostMilestone4Night.Value;

                mComputerDTO.MinMinute = (int)numericTinhTienTongHop2MinTime.Value;
                mComputerDTO.MinCost = (int)numericTinhTienTongHop2MinCost.Value;

                mComputerDTO.CycleMilestone3 = trackBarTinhTienTongHop2CycleMilestone.Value;
                mComputerDTO.IsAdd = "";

                if (mComputerDTO.StartHourNight <= mComputerDTO.EndHourNight)
                {
                    MessageBox.Show("Thời gian bắt đầu phải lớn hơn thời gian kết thúc tính đêm");
                    return;
                }
                if (mComputerDTO.HourMilestone1 > mComputerDTO.HourMilestone2)
                {
                    MessageBox.Show("Thời gian mốc 2 phải lớn hơn thời gian mốc 1");
                    return;
                }
                if (mComputerDTO.HourMilestone2 > mComputerDTO.HourMilestone3)
                {
                    MessageBox.Show("Thời gian mốc 3 phải lớn hơn thời gian mốc 2");
                    return;
                }

                if (ComputerDAO.IsHasData(mComputerDTO.PartID, Constant.LOAI_GIU_XE_TONG_HOP_THEO_NGAY_DEM))
                {
                    if (ComputerDAO.Update(mComputerDTO))
                    {
                        MessageBox.Show(Constant.sMessageUpdateSuccess);
                        panelTinhTienTongHop2.Enabled = false;
                        LogUtil.addLogChinhSuaGiaTienGuiXe(oldComputerDTO, mComputerDTO, Constant.LOAI_GIU_XE_TONG_HOP_THEO_NGAY_DEM);
                    }
                }
                else
                {
                    if (ComputerDAO.Insert(mComputerDTO))
                    {
                        MessageBox.Show(Constant.sMessageUpdateSuccess);
                        panelTinhTienTongHop2.Enabled = false;
                    }
                }
            }
        }

        private void cbLoaiXeTinhTienCongVan_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDataTinhTienTheoCongVan();
        }

        private void trackBarIntervalBetweenDayNight_ValueChanged(object sender, EventArgs e)
        {
            labelIntervalBetweenDayNight.Text = trackBarTinhTienCongVanIntervalBetweenDayNight.Value + "";
        }

        private void trackBarCycleTicketMonth_ValueChanged(object sender, EventArgs e)
        {
            labelTinhTienCongVanCycleTicketMonth.Text = trackBarTinhTienCongVanCycleTicketMonth.Value + "";
        }

        private void btnCapNhatTinhTienCongVan_Click(object sender, EventArgs e)
        {
            updateTinhTienTheoCongVan();
        }

        private void btnChinhSuaTinhTienCongVan_Click(object sender, EventArgs e)
        {
            panelTinhTienCongVan.Enabled = true;
        }

        private void btnHuyTinhTienCongVan_Click(object sender, EventArgs e)
        {
            loadDataTinhTienTheoCongVan();
            panelTinhTienCongVan.Enabled = false;
        }

        private void cbLoaiXeTinhTienLuyTien_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDataTinhTienLuyTien();
        }

        private void cbLoaiXeTinhTienTongHop_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDataTinhTienTongHop();
        }

        private void trackBarTinhTienLuyTienCycleMilestone3_ValueChanged(object sender, EventArgs e)
        {
            labelTinhTienLuyTienCycleMilestone3.Text = trackBarTinhTienLuyTienCycleMilestone3.Value + "";
        }

        private void trackBarTinhTienLuyTienCycleTicketMonth_ValueChanged(object sender, EventArgs e)
        {
            labelTinhTienLuyTienCycleTicketMonth.Text = trackBarTinhTienLuyTienCycleTicketMonth.Value + "";
        }

        private void btnChinhSuaTinhTienLuyTien_Click(object sender, EventArgs e)
        {
            panelTinhTienLuyTien.Enabled = true;
        }

        private void btnCapNhatTinhTienLuyTien_Click(object sender, EventArgs e)
        {
            updateTinhTienLuyTien();
        }

        private void btnHuyTinhTienLuyTien_Click(object sender, EventArgs e)
        {
            loadDataTinhTienLuyTien();
            panelTinhTienLuyTien.Enabled = false;
        }

        private void btnChinhSuaTinhTienTongHop_Click(object sender, EventArgs e)
        {
            panelTinhTienTongHop.Enabled = true;
        }

        private void btnCapNhatTinhTienTongHop_Click(object sender, EventArgs e)
        {
            updateTinhTienTongHop();
        }

        private void btnHuyTinhTienTongHop_Click(object sender, EventArgs e)
        {
            loadDataTinhTienTongHop();
            panelTinhTienTongHop.Enabled = false;
        }

        private void trackBarTinhTienTongHopCycleTicketMonth_ValueChanged(object sender, EventArgs e)
        {
            labelTinhTienTongHopCycleTicketMonth.Text = trackBarTinhTienTongHopCycleTicketMonth.Value + "";
        }

        /*
         * Part data
         */

        private void loadPartList()
        {
            dgvPartList.DataSource = PartDAO.GetAllData();
            int Index = dgvPartList.CurrentRow.Index;
            loadPartInfoFromDataGridViewRow(Index);
        }

        private bool checkCreatePartData()
        {
            if (string.IsNullOrWhiteSpace(tbPartIdCreate.Text))
            {
                MessageBox.Show(Constant.sMessagePartIdNullError);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbPartNameCreate.Text))
            {
                MessageBox.Show(Constant.sMessagePartNameNullError);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbPartAmountCreate.Text))
            {
                MessageBox.Show(Constant.sMessagePartAmountNullError);
                return false;
            }
            return true;
        }

        private bool checkUpdatePartData()
        {
            if (string.IsNullOrWhiteSpace(tbPartNameEdit.Text))
            {
                MessageBox.Show(Constant.sMessagePartNameNullError);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbPartAmountEdit.Text))
            {
                MessageBox.Show(Constant.sMessagePartAmountNullError);
                return false;
            }
            return true;
        }

        private void createPart()
        {
            PartDTO partDTO = new PartDTO();
            partDTO.ID = tbPartIdCreate.Text;
            DataRow typeNameDataRow = ((DataRowView)cbTypeNameCreate.SelectedItem).Row;
            partDTO.TypeID = Convert.ToString(typeNameDataRow["TypeID"]);

            DataRow cardTypeDataRow = ((DataRowView)cbCardTypeNameCreate.SelectedItem).Row;
            partDTO.CardTypeID = Convert.ToString(cardTypeDataRow["CardTypeID"]);

            partDTO.Name = tbPartNameCreate.Text;
            partDTO.Sign = tbPartSignCreate.Text;
            partDTO.Amount = int.Parse(tbPartAmountCreate.Text);
            PartDAO.Insert(partDTO);

            loadPartList();
            LogUtil.addLogTaoMoiLoaiXe(partDTO);
        }

        private void updatePart()
        {
            PartDTO partDTO = new PartDTO();
            partDTO.ID = tbPartIdEdit.Text;
            partDTO.Name = tbPartNameEdit.Text;
            partDTO.Sign = tbPartSignEdit.Text;
            partDTO.Amount = int.Parse(tbPartAmountEdit.Text);
            DataRow typeNameDataRow = ((DataRowView)cbTypeNameEdit.SelectedItem).Row;
            partDTO.TypeID = Convert.ToString(typeNameDataRow["TypeID"]);
            DataRow cardTypeNameDataRow = ((DataRowView)cbCardTypeNameEdit.SelectedItem).Row;
            partDTO.CardTypeID = Convert.ToString(cardTypeNameDataRow["CardTypeID"]);
            partDTO.IsSync = "0";

            PartDAO.Update(partDTO);
            loadPartList();
        }

        private void loadPartInfoFromDataGridViewRow(int Index)
        {
            if (Index < 0)
            {
                return;
            }
            string id = Convert.ToString(dgvPartList.Rows[Index].Cells["PartID"].Value);
            tbPartIdEdit.Text = id;
            string partName = Convert.ToString(dgvPartList.Rows[Index].Cells["PartName"].Value);
            tbPartNameEdit.Text = partName;
            string sign = Convert.ToString(dgvPartList.Rows[Index].Cells["Sign"].Value);
            tbPartSignEdit.Text = sign;
            string amount = Convert.ToString(dgvPartList.Rows[Index].Cells["Amount"].Value);
            tbPartAmountEdit.Text = amount;
            string typeName = Convert.ToString(dgvPartList.Rows[Index].Cells["TypeName"].Value);
            cbTypeNameEdit.Text = typeName;
            string cardTypeName = Convert.ToString(dgvPartList.Rows[Index].Cells["CardTypeName_CreatePart"].Value);
            cbCardTypeNameEdit.Text = cardTypeName;
        }

        private void clearInputPartInfo()
        {
            tbPartIdCreate.Text = "";
            tbPartNameCreate.Text = "";
            tbPartSignCreate.Text = "";
            tbPartAmountCreate.Text = "";
        }

        private void tabCardManagement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabQuanLyThe_LoaiXe.SelectedTab == tabQuanLyThe_LoaiXe.TabPages["tabPageQuanLyLoaiXe"])
            {
                loadPartList();
                panelChinhSuaLoaiXe.Enabled = false;
                btnUpdatePart.Text = Constant.sButtonEdit;
            }
            else if (tabQuanLyThe_LoaiXe.SelectedTab == tabQuanLyThe_LoaiXe.TabPages["tabPageKhoaThe"])
            {
                searchCardToLock();
            }
            else if (tabQuanLyThe_LoaiXe.SelectedTab == tabQuanLyThe_LoaiXe.TabPages["tabPageKichHoatThe"])
            {
                searchLostCard();
            }
        }

        private void btnCreatePart_Click(object sender, EventArgs e)
        {
            if (checkCreatePartData())
            {
                createPart();
            }
        }

        private void btnCancelCreatePart_Click(object sender, EventArgs e)
        {
            clearInputPartInfo();
        }

        private void btnUpdatePart_Click(object sender, EventArgs e)
        {
            if (panelChinhSuaLoaiXe.Enabled)
            {
                if (checkUpdatePartData())
                {
                    updatePart();
                    panelChinhSuaLoaiXe.Enabled = false;
                    btnUpdatePart.Text = Constant.sButtonEdit;
                }
            }
            else
            {
                panelChinhSuaLoaiXe.Enabled = true;
                btnUpdatePart.Text = Constant.sButtonUpdate;
            }
        }

        private void btnCancelUpdatePart_Click(object sender, EventArgs e)
        {
            int Index = dgvPartList.CurrentRow.Index;
            loadPartInfoFromDataGridViewRow(Index);
        }

        private void dgvPartList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = e.RowIndex;
            int Count = dgvPartList.Rows.Count;
            if (Index < Count)
            {
                loadPartInfoFromDataGridViewRow(Index);
            }
        }

        /*
        Card data
        */

        private void loadCardList()
        {
            DataTable data = CardDAO.GetAllData();
            if (data != null)
            {
                for (int row = 0; row < data.Rows.Count; row++)
                {
                    if (data.Rows[row].Field<string>("IsUsing") == "1")
                    {
                        data.Rows[row].SetField("IsUsing", Constant.sLabelCardUsing);
                    }
                    else
                    {
                        data.Rows[row].SetField("IsUsing", Constant.sLabelCardNotUsing);
                    }
                }

                dgvCardList.DataSource = data;
            }
        }

        private void loadLostCardList()
        {
            dgvActiveCardList.ReadOnly = false;
            DataTable data = CardDAO.GetLostCardData();
            if (data != null)
            {
                dgvActiveCardList.DataSource = data;
            }
        }

        private void loadCardStatistic()
        {
            DataTable data = CardDAO.GetDataGroupByType();
            int notUsingCardCount = CardDAO.GetNotUsingCardCount();
            int usingCardCount = CardDAO.GetUsingCardCount();
            int total = notUsingCardCount + usingCardCount;

            DataRow rowAllCard = data.NewRow();
            rowAllCard.SetField("PartName", "Tổng thẻ");
            rowAllCard.SetField("IsUsing", "Dùng & Không");
            rowAllCard.SetField("SumCard", total);
            data.Rows.InsertAt(rowAllCard, 0);

            DataRow rowNotUsingCard = data.NewRow();
            rowNotUsingCard.SetField("PartName", "Tổng thẻ không dùng");
            rowNotUsingCard.SetField("IsUsing", Constant.sLabelCardNotUsing);
            rowNotUsingCard.SetField("SumCard", notUsingCardCount);
            data.Rows.InsertAt(rowNotUsingCard, 1);

            DataRow rowUsingCard = data.NewRow();
            rowUsingCard.SetField("PartName", "Tổng thẻ đang dùng");
            rowUsingCard.SetField("IsUsing", Constant.sLabelCardUsing);
            rowUsingCard.SetField("SumCard", usingCardCount);
            data.Rows.InsertAt(rowUsingCard, 2);

            dgvCardStatistic.DataSource = data;
        }

        private void loadPartDataToComboBox(ComboBox cb)
        {
            DataTable dt = PartDAO.GetAllData();
            cb.DataSource = dt;
            cb.DisplayMember = "PartName";
            cb.ValueMember = "ID";
        }

        private void loadTicketCommonPartDataToComboBox(ComboBox cb)
        {
            DataTable dt = PartDAO.GetAllTicketCommonData();
            cb.DataSource = dt;
            cb.DisplayMember = "PartName";
            cb.ValueMember = "ID";
        }

        private void loadTypeDataToComboBox(ComboBox cb)
        {
            DataTable dt = TypeDAO.GetAllData();
            cb.DataSource = dt;
            cb.DisplayMember = "TypeName";
            cb.ValueMember = "TypeID";
        }

        private void loadCardTypeDataToComboBox(ComboBox cb)
        {
            DataTable dt = CardTypeDAO.GetAllData();
            cb.DataSource = dt;
            cb.DisplayMember = "CardTypeName";
            cb.ValueMember = "CardTypeID";
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

        private bool checkCreateCardData()
        {
            if (string.IsNullOrWhiteSpace(tbCardIDCreate.Text))
            {
                labelKetQuaTaoThe.Text = Constant.sMessageCardIdNullError;
                return false;
            }
            try
            {
                string cardIdentify = tbCardIdentifyCreate.Text.Trim();
                CardDTO cardDTO = CardDAO.GetCardModelByIdentify(cardIdentify);
                if (cardDTO != null)
                {
                    if (cardDTO.IsDeleted == "0")
                    {
                        labelKetQuaTaoThe.Text = Constant.sMessageCardIdentifyExisted;
                        return false;
                    }              
                }
            }
            catch (Exception e)
            {
                labelKetQuaTaoThe.Text = "Số thẻ không hợp lệ";
                return false;
            }
            return true;
        }

        private void createCard()
        {
            CardDTO cardDTO = new CardDTO();
            try
            {
                cardDTO.Identify = tbCardIdentifyCreate.Text.Trim();
            }
            catch (Exception e)
            {

            }
            cardDTO.Id = tbCardIDCreate.Text.Trim();

            DataRow partDataRow = ((DataRowView)cbPartNameCreate.SelectedItem).Row;
            string partID = Convert.ToString(partDataRow["ID"]);
            cardDTO.Type = partID;

            string isUsing = "0";
            if (cbIsUsingCreate.Checked)
            {
                isUsing = "1";
            }
            cardDTO.IsUsing = isUsing;
            cardDTO.DayUnlimit = DateTime.Now;
            //cardDTO.SystemId = createCardAPI(cardDTO);
            cardDTO.SystemId = cardDTO.Id;

            CardDTO checkCardDTO = CardDAO.GetCardModelByID(cardDTO.Id);
            if (checkCardDTO != null)
            {
                labelKetQuaTaoThe.Text = Constant.sMessageCardIdExisted;
                return;
            }
            
            if (CardDAO.Insert(cardDTO))
            {
                loadCardList();
                labelKetQuaTaoThe.Text = "Tạo thẻ thành công!";
                cardDTO.Identify = CardDAO.getIdentifyByCardID(cardDTO.Id);
                LogUtil.addLogTaoMoiThe(cardDTO);
                autoFillCardIdentify();
            }
            else
            {
                labelKetQuaTaoThe.Text = "Thẻ đã tồn tại!";
            }
        }

        private void autoFillCardIdentify()
        {
            try
            {
                string cardIdentify = CardDAO.GetLastCardIdentify();
                int identify = Int32.Parse(cardIdentify);
                tbCardIdentifyCreate.Text = identify + 1 + "";
            } catch (Exception)
            {

            }
        }

        private string createCardAPI(CardDTO cardDTO)
        {
            WebClient webClient = (new ApiUtil()).getWebClient();
            webClient.QueryString.Add(ApiUtil.PARAM_STT, cardDTO.Identify + "");
            webClient.QueryString.Add(ApiUtil.PARAM_CODE, cardDTO.Id);
            webClient.QueryString.Add(ApiUtil.PARAM_VEHICLE_ID, cardDTO.Type + "");
            try
            {
                String responseString = webClient.DownloadString(ApiUtil.API_ADD_UPDATE_CARD);
                JObject jObject = JObject.Parse(responseString);
                string cardId = (string)jObject["body"];
                return cardId;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private bool checkUpdateCardData()
        {
            if (string.IsNullOrWhiteSpace(tbCardIDEdit.Text))
            {
                MessageBox.Show(Constant.sMessageCardIdNullError);
                return false;
            }

            DataRow cardTypeDataRow = ((DataRowView)cbCardTypeNameEdit.SelectedItem).Row;
            string cardTypeID = Convert.ToString(cardTypeDataRow["CardTypeID"]);
            DataTable dt = TicketMonthDAO.GetDataByID(tbCardIDEdit.Text);
            if (dt != null && dt.Rows.Count > 0 && cardTypeID == CardTypeDTO.CARD_TYPE_TICKET_COMMON)
            {
                MessageBox.Show("Không thể thay đổi loại vé do thẻ này đã được đăng ký vé tháng");
                return false;
            }
            return true;
        }

        private void updateCard()
        {
            CardDTO cardDTO = new CardDTO();
            try
            {
                cardDTO.Identify = tbCardIdentifyEdit.Text.Trim();
            }
            catch (Exception e)
            {

            }
            cardDTO.Id = tbCardIDEdit.Text.Trim();

            DataRow partDataRow = ((DataRowView)cbPartNameEdit.SelectedItem).Row;
            string partID = Convert.ToString(partDataRow["ID"]);

            cardDTO.Type = partID;

            string isUsing = "0";
            if (cbIsUsingEdit.Checked)
            {
                isUsing = "1";
            }
            cardDTO.IsUsing = isUsing;
            cardDTO.IsSync = "0";
            cardDTO.DayUnlimit = DateTime.Now;

            CardDAO.Update(cardDTO);
            loadCardList();
            loadCardStatistic();
        }

        private void searchCard()
        {
            string key = tbCardSearch.Text;
            DataTable data = CardDAO.SearchData(key);
            for (int row = 0; row < data.Rows.Count; row++)
            {
                if (data.Rows[row].Field<string>("IsUsing") == "1")
                {
                    data.Rows[row].SetField("IsUsing", Constant.sLabelCardUsing);
                }
                else
                {
                    data.Rows[row].SetField("IsUsing", Constant.sLabelCardNotUsing);
                }

            }
            dgvCardList.DataSource = data;
        }

        private void searchCardToLock()
        {
            string key = tbLockCardSearch.Text;
            DataTable data = CardDAO.SearchUsingCardData(key);            
            dgvLockCardList.DataSource = data;
        }

        private void searchLostCard()
        {
            string key = tbLostCardSearch.Text;
            if (key.Equals(""))
            {
                loadLostCardList();
            }
            else
            {
                DataTable data = CardDAO.SearchLostCardData(key);
                dgvActiveCardList.DataSource = data;
            }
        }

        private void loadCardInfoFromDataGridViewRow(int Index)
        {
            if (Index < 0)
            {
                return;
            }
            string identify = Convert.ToString(dgvCardList.Rows[Index].Cells["Identify"].Value);
            tbCardIdentifyEdit.Text = identify;
            string id = Convert.ToString(dgvCardList.Rows[Index].Cells["CardID"].Value);
            tbCardIDEdit.Text = id;
            string isUsing = Convert.ToString(dgvCardList.Rows[Index].Cells["IsUsing"].Value);
            if (isUsing == Constant.sLabelCardUsing)
            {
                cbIsUsingEdit.Checked = true;
            }
            else
            {
                cbIsUsingEdit.Checked = false;
            }
            string partName = Convert.ToString(dgvCardList.Rows[Index].Cells["CardPartName"].Value);
            cbPartNameEdit.Text = partName;          
        }

        private void tabQuanLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabQuanLy.SelectedTab == tabQuanLy.TabPages["tabPageQuanLyDoanhThu"])
            {
                setFormatTimeForDateTimePicker(dtStartTimeSaleReport);
                setFormatTimeForDateTimePicker(dtEndTimeSaleReport);
                setFormatDateForDateTimePicker(dtDateSaleReport);
                setFormatDateForDateTimePicker(dtStartDateSaleReport);
                setFormatDateForDateTimePicker(dtEndDateSaleReport);

                loadUserDataToComboBox(cbNhanVienVaoReport);
                loadUserDataToComboBox(cbNhanVienRaReport);

                //loadSaleReportData();
            }
            else if (tabQuanLy.SelectedTab == tabQuanLy.TabPages["tabPageQuanLyTheXeLoaiXe"])
            {
                loadCardList();
                autoFillCardIdentify();
                loadPartDataToComboBox(cbPartNameCreate);
                loadPartDataToComboBox(cbPartNameEdit);
                loadTypeDataToComboBox(cbTypeNameCreate);
                loadTypeDataToComboBox(cbTypeNameEdit);
                loadCardTypeDataToComboBox(cbCardTypeNameCreate);
                loadCardTypeDataToComboBox(cbCardTypeNameEdit);

                loadCardStatistic();

                if (dgvCardList.DataSource != null && dgvCardList.CurrentRow != null)
                {
                    int Index = dgvCardList.CurrentRow.Index;
                    loadCardInfoFromDataGridViewRow(Index);
                }
            }
            else if (tabQuanLy.SelectedTab == tabQuanLy.TabPages["tabPageQuanLyXeRaVao"])
            {
                loadBlackCarList();
                loadConfig();
            }
            else if (tabQuanLy.SelectedTab == tabQuanLy.TabPages["tabPageQuanLyVeThang"])
            {
                loadPartDataToComboBox(cbTicketMonthPartCreate);
                loadPartDataToComboBox(cbTicketMonthPartEdit);
                loadTabPageTicketLog();
                loadTicketMonthData();
                setFormatDateForDateTimePicker(dtTicketLogRegistrationDateSearch);
                setFormatDateForDateTimePicker(dtTicketLogExpirationDateSearch);
                dtTicketLogRegistrationDateSearch.Value = DateTime.Now.AddMonths(-1);

                btnPrintReceipt.Enabled = false;
                btnPrintTransferCost.Enabled = false;
                btnPrintFeeNotice.Enabled = false;

                string functionId = UserDAO.GetFunctionIDByUserID(Program.CurrentManagerUserID);
                string[] listFunctionSec = FunctionalDAO.GetFunctionSecByID(functionId).Split(',');

                if (!functionId.Equals("Ad"))
                {
                    btnTicketMonthEdit.Enabled = false;
                    tbTicketMonthKeyWordSearch.Enabled = false;

                    if (listFunctionSec.Contains(Constant.NODE_VALUE_CAP_NHAT_THONG_TIN_VE_THANG.ToString()))
                    {
                        btnTicketMonthEdit.Enabled = true;
                    }
                    else
                    {
                        tabControlTaoMoiTheThang.TabPages.Remove(tabPageTaoTheThang);
                    }

                    if (listFunctionSec.Contains(Constant.NODE_VALUE_TIM_VE_THANG.ToString()))
                    {
                        tbTicketMonthKeyWordSearch.Enabled = true;
                    }
                }
            }
            else if (tabQuanLy.SelectedTab == tabQuanLy.TabPages["tabPageQuanLyHeThong"])
            {
                addDataToRFIDComboBox();
                loadCauHinhHienThiData();
                hienCauHinhKetNoiTuConfig();
            } else if (tabQuanLy.SelectedTab == tabQuanLy.TabPages["tabPageQuanLyPhieuThuChi"])
            {
                string functionId = UserDAO.GetFunctionIDByUserID(Program.CurrentManagerUserID);
                string[] listFunctionSec = FunctionalDAO.GetFunctionSecByID(functionId).Split(',');

                if (!functionId.Equals("Ad"))
                {
                    btnPrintReceipt.Enabled = false;
                    btnPrintTransferCost.Enabled = false;
                    btnPrintFeeNotice.Enabled = false;

                    if (listFunctionSec.Contains(Constant.NODE_VALUE_IN_PHIEU_THU_CHI.ToString()))
                    {
                        btnPrintReceipt.Enabled = true;
                        btnPrintTransferCost.Enabled = true;
                    }

                    if (listFunctionSec.Contains(Constant.NODE_VALUE_IN_PHIEU_THONG_BAO_PHI.ToString()))
                    {
                        btnPrintFeeNotice.Enabled = true;
                    }
                }
            }
        }

        private void btnCardCreate_Click(object sender, EventArgs e)
        {
            if (checkCreateCardData())
            {
                createCard();
                loadCardStatistic();
                tbCardIDCreate.Text = "";
            }
        }

        private void btnCardEdit_Click(object sender, EventArgs e)
        {
            if (panelChinhSuaTheXe.Enabled)
            {
                if (checkUpdateCardData())
                {
                    updateCard();
                    loadCardStatistic();
                    panelChinhSuaTheXe.Enabled = false;
                    btnCardEdit.Text = Constant.sButtonEdit;
                }
            }
            else
            {
                panelChinhSuaTheXe.Enabled = true;
                btnCardEdit.Text = Constant.sButtonUpdate;
            }
        }

        private void dgvCardList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = e.RowIndex;
            int Count = dgvCardList.Rows.Count;
            if (Index < Count)
            {
                loadCardInfoFromDataGridViewRow(Index);
            }

            if (e.RowIndex < 0) return;
            //var dataGridView = (DataGridView)sender;
            //var cell = dataGridView["SelectCard", e.RowIndex];
            //if (cell.Value == null)
            //{
            //    cell.Value = false;
            //}
            //cell.Value = !(bool)cell.Value;
        }

        private void tbCardSearch_TextChanged(object sender, EventArgs e)
        {
            searchCard();
        }

        /*
        Ticket Month data
        */

        private void loadTabPageTicketLog()
        {
            loadTicketLogTypeData();
            loadPartDataWithFieldAllToComboBox(cbPartNameTicketLogSearch);
        }

        private void loadTicketLogData()
        {
            DataTable data = TicketLogDAO.GetAllData();
            dgvTicketLogList.DataSource = data;

            if (data != null && data.Rows.Count > 0)
            {
                loadTicketLogInfoFromDataGridViewRow(0);
            }
        }

        private void searchTicketMonthData()
        {
            string key = tbTicketMonthKeyWordSearch.Text;
            dgvTicketMonthList.DataSource = TicketMonthDAO.searchData(key);
        }

        private void searchNearExpiredTicketMonthData()
        {
            string key = tbRenewTicketMonthKeyWordSearch.Text;
            if (!string.IsNullOrWhiteSpace(tbRenewTicketMonthDaysRemainingSearch.Text))
            {
                int daysRemaining = 0;
                if (int.TryParse(tbRenewTicketMonthDaysRemainingSearch.Text, out daysRemaining))
                {

                }
                else
                {
                    MessageBox.Show(Constant.sMessageInvalidError);
                    return;
                }
                dgvRenewTicketMonthList.DataSource = TicketMonthDAO.searchNearExpiredTicketData(key, daysRemaining);
            }
            else
            {
                dgvRenewTicketMonthList.DataSource = TicketMonthDAO.searchNearExpiredTicketData(key, null);
            }
            setColorForRenewTicketMonthList();
        }

        private async Task searchDebtReportTicketMonthDataAsync()
        {
            progressBarDebtReport.Show();

            string key = tbDebtReportKeyWordSearch.Text;
            if (!string.IsNullOrWhiteSpace(tbDebtReportDaysRemainingSearch.Text))
            {
                int daysRemaining = 0;
                if (int.TryParse(tbDebtReportDaysRemainingSearch.Text, out daysRemaining))
                {

                }
                else
                {
                    MessageBox.Show(Constant.sMessageInvalidError);
                    return;
                }
                var data = await TicketMonthDAO.SearchDebtReportTicketData(key, daysRemaining);
                dgvDebtReport.DataSource = data;
            }
            else
            {
                var data = await TicketMonthDAO.SearchDebtReportTicketData(key, null);
                dgvDebtReport.DataSource = data;
            }
            setColorForDebtReportTicketMonthList();

            progressBarDebtReport.Hide();
        }

        private void setColorForRenewTicketMonthList()
        {
            dgvRenewTicketMonthList.DefaultCellStyle.ForeColor = Color.Black;
            foreach (DataGridViewRow row in dgvRenewTicketMonthList.Rows)
            {
                int daysRemaining = Convert.ToInt32(dgvRenewTicketMonthList.Rows[row.Index].Cells["RenewDaysRemaining"].Value);
                if (daysRemaining <= 0)
                {
                    foreach (DataGridViewColumn col in dgvRenewTicketMonthList.Columns)
                    {
                        dgvRenewTicketMonthList[col.Index, row.Index].Style.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void setColorForDebtReportTicketMonthList()
        {
            dgvDebtReport.DefaultCellStyle.ForeColor = Color.Black;
            foreach (DataGridViewRow row in dgvDebtReport.Rows)
            {
                int daysRemaining = Convert.ToInt32(dgvDebtReport.Rows[row.Index].Cells["DebtDaysRemaining"].Value);
                if (daysRemaining <= 0)
                {
                    foreach (DataGridViewColumn col in dgvDebtReport.Columns)
                    {
                        dgvDebtReport[col.Index, row.Index].Style.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void searchTicketLogData()
        {
            string key = tbTicketLogKeyWordSearch.Text;
            string ticketLogID = null;
            if (cbTicketLogNameSearch.SelectedIndex > 0)
            {
                DataRow ticketLoDataRow = ((DataRowView)cbTicketLogNameSearch.SelectedItem).Row;
                ticketLogID = Convert.ToString(ticketLoDataRow["LogTypeID"]);
            }
            string partID = null;
            if (cbPartNameTicketLogSearch.SelectedIndex > 0)
            {
                DataRow partDataRow = ((DataRowView)cbPartNameTicketLogSearch.SelectedItem).Row;
                partID = Convert.ToString(partDataRow["ID"]);
            }
            DateTime registrationDate = dtTicketLogRegistrationDateSearch.Value;
            registrationDate = new DateTime(registrationDate.Year, registrationDate.Month, registrationDate.Day, 0, 0, 0);
            DateTime expirationDate = dtTicketLogExpirationDateSearch.Value;
            expirationDate = new DateTime(expirationDate.Year, expirationDate.Month, expirationDate.Day, 23, 59, 59);

            DataTable data = TicketLogDAO.searchData(key, ticketLogID, partID, registrationDate, expirationDate);
            dgvTicketLogList.DataSource = data;
        }

        private void loadTicketMonthData()
        {
            DataTable data = TicketMonthDAO.GetAllData();
            dgvTicketMonthList.DataSource = data;

            if (data != null && data.Rows.Count > 0)
            {
                loadTicketMonthInfoFromDataGridViewRow(0);
            }
        }

        private void tabQuanLyVeThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabQuanLyVeThang.SelectedTab == tabQuanLyVeThang.TabPages["tabPageXemNhatKyVeThang"])
            {
                loadTicketLogData();
            }
            else if (tabQuanLyVeThang.SelectedTab == tabQuanLyVeThang.TabPages["tabPageTaoMoiVeThang"])
            {
                panelChinhSuaVeThang.Enabled = false;
                btnTicketMonthEdit.Text = Constant.sButtonEdit;
                loadTicketMonthData();
               
                clearInputTicketMonthInfo();
                setFormatDateForDateTimePicker(dateTimePickerTicketMonthRegistrationDateCreate);
                setFormatDateForDateTimePicker(dateTimePickerTicketMonthExpirationDateCreate);
                setFormatDateForDateTimePicker(dateTimePickerTicketMonthRegistrationDateEdit);
                setFormatDateForDateTimePicker(dateTimePickerTicketMonthExpirationDateEdit);

                string functionID = UserDAO.GetFunctionIDByUserID(Program.CurrentManagerUserID);
                if (functionID.Equals(Constant.FUNCTION_ID_ADMIN))
                {
                    dateTimePickerTicketMonthRegistrationDateCreate.Enabled = true;
                    dateTimePickerTicketMonthRegistrationDateEdit.Enabled = true;
                    dateTimePickerTicketMonthExpirationDateCreate.Enabled = true;
                    dateTimePickerTicketMonthExpirationDateEdit.Enabled = true;
                }
            }
            else if (tabQuanLyVeThang.SelectedTab == tabQuanLyVeThang.TabPages["tabPageGiaHanVeThang"])
            {
                searchNearExpiredTicketMonthData();
                setFormatDateForDateTimePicker(dtRenewDate);
                setFormatDateForDateTimePicker(dtRenewExpirationDate);
                dtRenewExpirationDate.Value = Util.getLastDateOfCurrentMonth();
            }
            else if (tabQuanLyVeThang.SelectedTab == tabQuanLyVeThang.TabPages["tabPageMatVeThang"])
            {
                searchLostTicketMonth();
            }
            else if (tabQuanLyVeThang.SelectedTab == tabQuanLyVeThang.TabPages["tabPageKhoaVeThang"])
            {
                searchBlockTicketMonth();
            }
            else if (tabQuanLyVeThang.SelectedTab == tabQuanLyVeThang.TabPages["tabPageKichHoatVeThang"])
            {
                searchActiveTicketMonth();
            }
            else if (tabQuanLyVeThang.SelectedTab == tabQuanLyVeThang.TabPages["tabPageBaoCaoCongNo"])
            {
                searchDebtReportTicketMonthDataAsync();
            }
        }
        private void addTicketLog(int logTypeID, TicketMonthDTO ticketMonthDTO)
        {
            TicketLogDTO ticketLogDTO = new TicketLogDTO(logTypeID, ticketMonthDTO);
            TicketLogDAO.Insert(ticketLogDTO);
        }

        private void addTicketMonth()
        {
            TicketMonthDTO ticketMonthDTO = new TicketMonthDTO();

            ticketMonthDTO.CardIdentify = Convert.ToString(tbTicketMonthIdentifyCreate.Text);
            ticketMonthDTO.Id = tbTicketMonthIDCreate.Text;
            ticketMonthDTO.ProcessDate = DateTime.Now;
            ticketMonthDTO.Digit = tbTicketMonthDigitCreate.Text;
            ticketMonthDTO.CustomerName = tbTicketMonthCustomerNameCreate.Text;
            ticketMonthDTO.Cmnd = tbTicketMonthCMNDCreate.Text;
            ticketMonthDTO.Company = tbTicketMonthCompanyCreate.Text;
            ticketMonthDTO.Note = tbTicketMonthNoteCreate.Text;
            ticketMonthDTO.Email = tbTicketMonthEmailCreate.Text;
            ticketMonthDTO.Phone = tbTicketMonthPhoneCreate.Text;
            ticketMonthDTO.Address = tbTicketMonthAddressCreate.Text;
            ticketMonthDTO.CarKind = tbTicketMonthCarKindCreate.Text;

            DataRow dataRow = ((DataRowView)cbTicketMonthPartCreate.SelectedItem).Row;
            CardDTO cardDTO = CardDAO.GetCardModelByID(ticketMonthDTO.Id);
            ticketMonthDTO.IdPart = cardDTO.Type;

            ticketMonthDTO.Account = Program.CurrentManagerUserID;
            ticketMonthDTO.RegistrationDate = dateTimePickerTicketMonthRegistrationDateCreate.Value.Date;
            ticketMonthDTO.ExpirationDate = dateTimePickerTicketMonthExpirationDateCreate.Value.Date;
            ticketMonthDTO.ChargesAmount = tbTicketMonthChargesAmountCreate.Text;
            ticketMonthDTO.Status = 0;
            ticketMonthDTO.DayUnlimit = DateTime.Now;

            string cardIdentify = tbTicketMonthIdentifyCreate.Text;
            if (!cardDTO.Identify.Equals(cardIdentify))
            {
                CardDAO.UpdateIdentify(cardIdentify, ticketMonthDTO.Id);
            }

            CardDAO.UpdateIsUsing("1", ticketMonthDTO.Id);
            
            if (TicketMonthDAO.Insert(ticketMonthDTO))
            {
                clearInputTicketMonthInfo();
                loadTicketMonthData();

                addTicketLog(Constant.LOG_TYPE_CREATE_TICKET_MONTH, ticketMonthDTO);
                MessageBox.Show("Tạo thẻ thành công!");
            }
            
        }

        private void updateTicketMonth()
        {
            string cardIdentify = tbTicketMonthIdentifyEdit.Text;

            TicketMonthDTO ticketMonthDTO = new TicketMonthDTO();
            ticketMonthDTO.CardIdentify = cardIdentify;
            ticketMonthDTO.Id = tbTicketMonthIDEdit.Text;
            ticketMonthDTO.ProcessDate = DateTime.Now;
            ticketMonthDTO.Digit = tbTicketMonthDigitEdit.Text;
            ticketMonthDTO.CustomerName = tbTicketMonthCustomerNameEdit.Text;
            ticketMonthDTO.Cmnd = tbTicketMonthCMNDEdit.Text;
            ticketMonthDTO.Company = tbTicketMonthCompanyEdit.Text;
            ticketMonthDTO.Email = tbTicketMonthEmailEdit.Text;
            ticketMonthDTO.Phone = tbTicketMonthPhoneEdit.Text;
            ticketMonthDTO.Address = tbTicketMonthAddressEdit.Text;
            ticketMonthDTO.CarKind = tbTicketMonthCarKindEdit.Text;
            ticketMonthDTO.Note = tbTicketMonthNoteEdit.Text;

            DataRow dataRow = ((DataRowView)cbTicketMonthPartEdit.SelectedItem).Row;
            CardDTO oldCardDTO = CardDAO.GetCardModelByID(ticketMonthDTO.Id);
            ticketMonthDTO.IdPart = oldCardDTO.Type;

            ticketMonthDTO.Account = Program.CurrentManagerUserID;
            ticketMonthDTO.RegistrationDate = dateTimePickerTicketMonthRegistrationDateEdit.Value;
            ticketMonthDTO.ExpirationDate = dateTimePickerTicketMonthExpirationDateEdit.Value;
            ticketMonthDTO.ChargesAmount = tbTicketMonthChargesAmountEdit.Text;
            ticketMonthDTO.Status = 0;
            ticketMonthDTO.DayUnlimit = DateTime.Now;

            CardDTO newCardDTO = CardDAO.GetCardModelByIdentify(cardIdentify);
            string oldIdentify = oldCardDTO.Identify;
            if (newCardDTO != null && !cardIdentify.Equals(oldIdentify))
            {
                MessageBox.Show(Constant.sMessageCardIdentifyExisted);
            }
            else
            {
                CardDAO.UpdateIdentify(cardIdentify, ticketMonthDTO.Id);
                if (TicketMonthDAO.Update(ticketMonthDTO))
                {
                    loadTicketMonthData();

                    addTicketLog(Constant.LOG_TYPE_UPDATE_TICKET_MONTH, ticketMonthDTO);
                    MessageBox.Show("Cập nhật thẻ thành công!");
                }
            }
        }

        private void clearInputTicketMonthInfo()
        {
            tbTicketMonthIdentifyCreate.Text = "";
            tbTicketMonthIDCreate.Text = "";
            tbTicketMonthDigitCreate.Text = "";
            tbTicketMonthCustomerNameCreate.Text = "";
            tbTicketMonthCMNDCreate.Text = "";
            tbTicketMonthCompanyCreate.Text = "";
            tbTicketMonthNoteCreate.Text = "";
            tbTicketMonthEmailCreate.Text = "";
            tbTicketMonthAddressCreate.Text = "";
            tbTicketMonthCarKindCreate.Text = "";

            cbTicketMonthPartCreate.SelectedIndex = 0;

            dateTimePickerTicketMonthRegistrationDateCreate.Value = DateTime.Now;
            dateTimePickerTicketMonthExpirationDateCreate.Value = DateTime.Now;
            tbTicketMonthChargesAmountCreate.Text = "";
        }

        private bool checkCreateTicketMonthData()
        {
            if (string.IsNullOrWhiteSpace(tbTicketMonthIdentifyCreate.Text))
            {
                MessageBox.Show(Constant.sMessageTicketMonthIdentifyNullError);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbTicketMonthIDCreate.Text))
            {
                MessageBox.Show(Constant.sMessageTicketMonthIdNullError);
                return false;
            }
            CardDTO cardDTO = CardDAO.GetCardModelByID(tbTicketMonthIDCreate.Text);
            if (cardDTO == null)
            {
                MessageBox.Show(Constant.sMessageCardIdNotExist);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbTicketMonthDigitCreate.Text))
            {
                MessageBox.Show(Constant.sMessageTicketMonthDigitNullError);
                return false;
            }
            DataTable dtByDigit = TicketMonthDAO.GetDataByDigit(tbTicketMonthDigitCreate.Text);
            if (dtByDigit != null && dtByDigit.Rows.Count > 0)
            {
                MessageBox.Show(Constant.sMessageDigitExisted);
                return false;
            }
            return true;
        }

        private bool checkUpdateTicketMonthData()
        {
            if (string.IsNullOrWhiteSpace(tbTicketMonthIdentifyEdit.Text))
            {
                MessageBox.Show(Constant.sMessageTicketMonthIdentifyNullError);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbTicketMonthDigitEdit.Text))
            {
                MessageBox.Show(Constant.sMessageTicketMonthDigitNullError);
                return false;
            }
            return true;
        }

        private void loadTicketMonthInfoFromDataGridViewRow(int Index)
        {
            if (Index < 0)
            {
                return;
            }
            string identify = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["TicketMonthIdentify"].Value);
            tbTicketMonthIdentifyEdit.Text = identify;
            string id = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["TicketMonthID"].Value);
            tbTicketMonthIDEdit.Text = id;
            string digit = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["Digit"].Value);
            tbTicketMonthDigitEdit.Text = digit;
            string customerName = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["CustomerName"].Value);
            tbTicketMonthCustomerNameEdit.Text = customerName;
            string cmnd = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["CMND"].Value);
            tbTicketMonthCMNDEdit.Text = cmnd;
            string company = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["Company"].Value);
            tbTicketMonthCompanyEdit.Text = company;
            string note = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["Note"].Value);
            tbTicketMonthNoteEdit.Text = note;
            string email = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["Email"].Value);
            tbTicketMonthEmailEdit.Text = email;
            string phone = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["Phone"].Value);
            tbTicketMonthPhoneEdit.Text = phone;
            string address = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["Address"].Value);
            tbTicketMonthAddressEdit.Text = address;
            string carKind = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["CarKind"].Value);
            tbTicketMonthCarKindEdit.Text = carKind;
            string chargesAmount = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["ChargesAmount"].Value);
            tbTicketMonthChargesAmountEdit.Text = chargesAmount;
            string partName = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["TicketMonthPartName"].Value);
            cbTicketMonthPartEdit.Text = partName;
            if (!string.IsNullOrEmpty(dgvTicketMonthList.Rows[Index].Cells["RegistrationDate"].Value.ToString()))
            {
                DateTime registrationDate = Convert.ToDateTime(dgvTicketMonthList.Rows[Index].Cells["RegistrationDate"].Value);
                dateTimePickerTicketMonthRegistrationDateEdit.Value = registrationDate;
            }
            if (!string.IsNullOrEmpty(dgvTicketMonthList.Rows[Index].Cells["ExpirationDate"].Value.ToString()))
            {
                DateTime expirationDate = Convert.ToDateTime(dgvTicketMonthList.Rows[Index].Cells["ExpirationDate"].Value);
                dateTimePickerTicketMonthExpirationDateEdit.Value = expirationDate;
            }
            string isUsing = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["TicketMonthIsUsing"].Value);
            tbTicketMonthIsUsing.Text = isUsing;
        }

        private void loadTicketLogTypeData()
        {
            DataTable dt = LogTypeDAO.GetTicketLog();
            DataRow dr = dt.NewRow();
            dr["LogTypeName"] = "Tất cả";
            dt.Rows.InsertAt(dr, 0);
            cbTicketLogNameSearch.DataSource = dt;
            cbTicketLogNameSearch.DisplayMember = "LogTypeName";
            cbTicketLogNameSearch.ValueMember = "LogTypeID";
        }

        private void loadTicketLogInfoFromDataGridViewRow(int Index)
        {
            if (Index < 0)
            {
                return;
            }
            string processType = Convert.ToString(dgvTicketLogList.Rows[Index].Cells["LogTypeName"].Value);
            tbTicketLogProcessType.Text = processType;
            string processDate = Convert.ToString(dgvTicketLogList.Rows[Index].Cells["ProcessDate"].Value);
            tbTicketLogProcessDate.Text = processDate;
            string nameUser = Convert.ToString(dgvTicketLogList.Rows[Index].Cells["NameUser_Log"].Value);
            tbTicketLogNameUser.Text = nameUser;
            string ticketMonthID = Convert.ToString(dgvTicketLogList.Rows[Index].Cells["TicketMonthID_Log"].Value);
            tbTicketLogTicketMonthID.Text = ticketMonthID;
            string digit = Convert.ToString(dgvTicketLogList.Rows[Index].Cells["Digit_Log"].Value);
            tbTicketLogDigit.Text = digit;
            string customerName = Convert.ToString(dgvTicketLogList.Rows[Index].Cells["CustomerName_Log"].Value);
            tbTicketLogCustomerName.Text = customerName;
            string cmnd = Convert.ToString(dgvTicketLogList.Rows[Index].Cells["CMND_Log"].Value);
            tbTicketLogCMND.Text = cmnd;
            string company = Convert.ToString(dgvTicketLogList.Rows[Index].Cells["CompanyName_Log"].Value);
            tbTicketLogCompany.Text = company;
            string email = Convert.ToString(dgvTicketLogList.Rows[Index].Cells["Email_Log"].Value);
            tbTicketLogEmail.Text = email;
            string address = Convert.ToString(dgvTicketLogList.Rows[Index].Cells["Address_Log"].Value);
            tbTicketLogAddress.Text = address;
            string carKind = Convert.ToString(dgvTicketLogList.Rows[Index].Cells["CarKind_Log"].Value);
            tbTicketLogCarKind.Text = carKind;
            string partName = Convert.ToString(dgvTicketLogList.Rows[Index].Cells["PartName_Log"].Value);
            tbTicketLogPartName.Text = partName;
            string registrationDate = Convert.ToString(dgvTicketLogList.Rows[Index].Cells["RegistrationDate_Log"].Value);
            tbTicketLogRegistrationDate.Text = registrationDate;
            string expirationDate = Convert.ToString(dgvTicketLogList.Rows[Index].Cells["ExpirationDate_Log"].Value);
            tbTicketLogExpirationDate.Text = expirationDate;
        }

        private void searchLostTicketMonth()
        {
            string key = tbLostTicketMonthKeyWordSearch.Text;
            DataTable data = TicketMonthDAO.searchLostTicketData(key);
            dgvLostTicketMonthList.DataSource = data;
            if (data != null && data.Rows.Count > 0)
            {
                loadLostTicketMonthInfoFromDataGridViewRow(0);
            }
        }

        private void searchActiveTicketMonth()
        {
            string key = tbActiveTicketMonthKeyWordSearch.Text;
                       
            if (!string.IsNullOrWhiteSpace(tbAciveTicketMonthDaysRemainingSearch.Text))
            {
                int daysRemaining = 0;
                if (int.TryParse(tbAciveTicketMonthDaysRemainingSearch.Text, out daysRemaining))
                {

                }
                else
                {
                    MessageBox.Show(Constant.sMessageInvalidError);
                    return;
                }
                dgvActiveTicketMonthList.DataSource = TicketMonthDAO.searchActiveTicketData(key, daysRemaining);
            }
            else
            {
                dgvActiveTicketMonthList.DataSource = TicketMonthDAO.searchActiveTicketData(key, null);
            }
        }

        private void searchBlockTicketMonth()
        {
            string key = tbBlockTicketMonthKeyWordSearch.Text;

            if (!string.IsNullOrWhiteSpace(tbAciveTicketMonthDaysRemainingSearch.Text))
            {
                int daysRemaining = 0;
                if (int.TryParse(tbBlockTicketMonthDaysRemainingSearch.Text, out daysRemaining))
                {

                }
                else
                {
                    MessageBox.Show(Constant.sMessageInvalidError);
                    return;
                }
                dgvBlockTicketMonthList.DataSource = TicketMonthDAO.searchBlockTicketData(key, daysRemaining);
            }
            else
            {
                dgvBlockTicketMonthList.DataSource = TicketMonthDAO.searchBlockTicketData(key, null);
            }
        }

        private void deleteTicketMonth()
        {
            foreach (DataGridViewRow row in dgvTicketMonthList.Rows)
            {
                DataGridViewCheckBoxCell checkCell = row.Cells["SelectTicketMonth"] as DataGridViewCheckBoxCell;
                object value = checkCell.Value;
                if (value != null && (Boolean)value)
                {
                    string cardId = Convert.ToString(row.Cells["TicketMonthID"].Value);
                    addDeleteTicketMonthToLog(row.Index);
                    if (TicketMonthDAO.Delete(cardId))
                    {
                        //string cardIdentify = CardDAO.getIdentifyByCardID(cardId);
                        //LogUtil.addLogXoaThe(cardIdentify, cardId);
                        //CardDAO.Delete(cardId);
                        CarDAO.DeleteCarNotOut(cardId);
                    }
                }
            }
            loadTicketMonthData();
        }

        private void addDeleteTicketMonthToLog(int Index)
        {
            string id = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["TicketMonthID"].Value);
            DataTable data = TicketMonthDAO.GetDataByID(id);
            TicketMonthDTO ticketMonthDTO = new TicketMonthDTO();
            string cardIdentify = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["TicketMonthIdentify"].Value);
            ticketMonthDTO.Id = id;
            ticketMonthDTO.CardIdentify = cardIdentify;
            ticketMonthDTO.ProcessDate = DateTime.Now;
            string digit = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["Digit"].Value);
            ticketMonthDTO.Digit = digit;
            string customerName = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["CustomerName"].Value);
            ticketMonthDTO.CustomerName = customerName;
            string cmnd = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["CMND"].Value);
            ticketMonthDTO.Cmnd = cmnd;
            string company = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["Company"].Value);
            ticketMonthDTO.Company = company;
            string email = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["Email"].Value);
            ticketMonthDTO.Email = email;
            string address = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["Address"].Value);
            ticketMonthDTO.Address = address;
            string carKind = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["CarKind"].Value);
            ticketMonthDTO.CarKind = carKind;
            string chargesAmount = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["ChargesAmount"].Value);
            ticketMonthDTO.ChargesAmount = chargesAmount;
            if (data.Rows.Count > 0)
            {
                string partId = data.Rows[0].Field<String>("IDPart");
                ticketMonthDTO.IdPart = partId;
            }
            if (!string.IsNullOrEmpty(dgvTicketMonthList.Rows[Index].Cells["RegistrationDate"].Value.ToString()))
            {
                DateTime registrationDate = Convert.ToDateTime(dgvTicketMonthList.Rows[Index].Cells["RegistrationDate"].Value);
                ticketMonthDTO.RegistrationDate = registrationDate;
            }
            if (!string.IsNullOrEmpty(dgvTicketMonthList.Rows[Index].Cells["ExpirationDate"].Value.ToString()))
            {
                DateTime expirationDate = Convert.ToDateTime(dgvTicketMonthList.Rows[Index].Cells["ExpirationDate"].Value);
                ticketMonthDTO.ExpirationDate = expirationDate;
            }
            ticketMonthDTO.Account = Program.CurrentManagerUserID;
            addTicketLog(Constant.LOG_TYPE_DELETE_TICKET_MONTH, ticketMonthDTO);
        }

        private void showConfirmDeleteTicketMonth()
        {
            DialogResult dialogResult = MessageBox.Show(Constant.sMessageConfirmDelete, Constant.sTitleDelete, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                deleteTicketMonth();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void loadLostTicketMonthInfoFromDataGridViewRow(int Index)
        {
            if (Index < 0)
            {
                return;
            }
            string ticketMonthIdentify = Convert.ToString(dgvLostTicketMonthList.Rows[Index].Cells["LostTicketMonthIdentify"].Value);
            tbTicketMonthIdentify.Text = ticketMonthIdentify;
            string identify = Convert.ToString(dgvLostTicketMonthList.Rows[Index].Cells["LostCardIdentify"].Value);
            tbLostTicketMonthCardIdentify.Text = identify;
            string id = Convert.ToString(dgvLostTicketMonthList.Rows[Index].Cells["LostCardID"].Value);
            tbLostTicketMonthID.Text = id;
        }

        private void btnTicketMonthCreate_Click(object sender, EventArgs e)
        {
            if (checkCreateTicketMonthData())
            {
                addTicketMonth();
            }
        }

        private void btnTicketMonthEdit_Click(object sender, EventArgs e)
        {
            if (panelChinhSuaVeThang.Enabled)
            {
                if (checkUpdateTicketMonthData())
                {
                    updateTicketMonth();
                    panelChinhSuaVeThang.Enabled = false;
                    btnTicketMonthEdit.Text = Constant.sButtonEdit;
                }
            }
            else
            {
                panelChinhSuaVeThang.Enabled = true;
                btnTicketMonthEdit.Text = Constant.sButtonUpdate;
            }
        }

        private void btnTicketMonthCancelCreate_Click(object sender, EventArgs e)
        {
            clearInputTicketMonthInfo();
        }

        private void btnTicketMonthCancelEdit_Click(object sender, EventArgs e)
        {
            int Index = dgvTicketMonthList.CurrentRow.Index;
            loadTicketMonthInfoFromDataGridViewRow(Index);
        }

        private void dgvTicketMonthList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = e.RowIndex;
            int Count = dgvTicketMonthList.Rows.Count;
            if (Index < Count)
            {
                loadTicketMonthInfoFromDataGridViewRow(Index);
            }

            if (e.RowIndex < 0) return;
            //var dataGridView = (DataGridView)sender;
            //var cell = dataGridView["SelectTicketMonth", e.RowIndex];
            //if (cell.Value == null)
            //{
            //    cell.Value = false;
            //}
            //cell.Value = !(bool)cell.Value;
        }

        private void dgvTicketMonthList_MouseClick(object sender, MouseEventArgs ev)
        {
            if (ev.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                MenuItem menuItem = new MenuItem(Constant.sButtonDelete);
                int currentRow = dgvTicketMonthList.HitTest(ev.X, ev.Y).RowIndex;
                menuItem.Click += new EventHandler((s, e) => Delete_TicketMonth_Click(s, e, currentRow));
                m.MenuItems.Add(menuItem);

                m.Show(dgvTicketMonthList, new Point(ev.X, ev.Y));
            }
        }

        void Delete_TicketMonth_Click(Object sender, System.EventArgs e, int currentRow)
        {
            checkForDeleteTicketMonth();
        }

        private void checkForDeleteTicketMonth()
        {
            if (!isChosenTicketMonth())
            {
                MessageBox.Show(Constant.sMessageNoChooseDataError);
                return;
            }
            showConfirmDeleteTicketMonth();
        }

        private void dgvTicketLogList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = dgvTicketLogList.CurrentRow.Index;
            loadTicketLogInfoFromDataGridViewRow(Index);
        }

        private void btnShowAllTicketLog_Click(object sender, EventArgs e)
        {
            loadTicketLogData();
        }

        private void btnSearchTicketLog_Click(object sender, EventArgs e)
        {
            searchTicketLogData();
        }

        private void tbTicketMonthKeyWordSearch_TextChanged(object sender, EventArgs e)
        {
            searchTicketMonthData();
        }

        private void btnNearExpiredTicketMonthSearch_Click(object sender, EventArgs e)
        {
            searchNearExpiredTicketMonthData();
        }

        private void btnLostTicketMonthSearch_Click(object sender, EventArgs e)
        {
            searchLostTicketMonth();
        }

        private void dgvLostTicketMonthList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = e.RowIndex;
            int Count = dgvLostTicketMonthList.Rows.Count;
            if (Index < Count)
            {
                loadLostTicketMonthInfoFromDataGridViewRow(Index);
            }
        }

        private void upDateLostTicketMonth()
        {
            if (string.IsNullOrWhiteSpace(tbLostTicketMonthID.Text))
            {
                MessageBox.Show(Constant.sMessageTicketMonthIdNullError);
                return;
            }
            int identify = Convert.ToInt32(tbTicketMonthIdentify.Text);
            string id = tbLostTicketMonthID.Text;
            if (TicketMonthDAO.updateTicketByID(id, identify))
            {
                searchLostTicketMonth();
                MessageBox.Show(Constant.sMessageUpdateSuccess);
            }
        }

        private bool checkUpdateTicketMonthID(string ticketMonthID)
        {
            if (string.IsNullOrWhiteSpace(ticketMonthID))
            {
                MessageBox.Show(Constant.sMessageTicketMonthIdNullError);
                return false;
            }
            DataTable dtCard = CardDAO.GetNotDeletedCardByID(ticketMonthID);
            if (dtCard == null || dtCard.Rows.Count == 0)
            {
                MessageBox.Show(Constant.sMessageCardIdNotExist);
                return false;
            }
            if (!CardDAO.isUsingByCardID(ticketMonthID))
            {
                MessageBox.Show(Constant.sMessageCardIsLost);
                return false;
            }
            return true;
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
            pictureBoxCarLogImage2.Image = null;
            pictureBoxCarLogImage3.Image = null;
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
                    pictureBoxCarLogImage2.Image = Image.FromFile(filePath);
                }
            }
            string image3 = Convert.ToString(dgvCarList.Rows[Index].Cells["CarLogImages3"].Value);
            if (!string.IsNullOrEmpty(image3))
            {
                string filePath = Constant.getSharedImageFolder() + image3;
                if (File.Exists(filePath))
                {
                    pictureBoxCarLogImage3.Image = Image.FromFile(filePath);
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

        private void dgvCarList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = e.RowIndex;
            int Count = dgvCarList.RowCount;
            if (Index < Count)
            {
                loadCarInfoFromDataGridViewRow(Index);
            }
        }

        /*
        Car data
        */

        private void loadBlackCarList()
        {
            DataTable data = BlackCarDAO.GetAllData();
            dgvBlackCarList.DataSource = data;
        }

        private void loadConfig()
        {
            DataTable dtConfig = ConfigDAO.GetConfig();
            tbBikeSpace.Text = ConfigDAO.GetBikeSpace(dtConfig).ToString();
            tbCarSpace.Text = ConfigDAO.GetCarSpace(dtConfig).ToString();
            tbTicketLimitDay.Text = ConfigDAO.GetTicketMonthLimit(dtConfig).ToString();
            tbNightLimit.Text = ConfigDAO.GetNightLimit(dtConfig).ToString();
        }

        private void addBlackCar()
        {
            string digit = tbBlackCarDigit.Text;
            BlackCarDAO.Insert(digit);
        }

        private void loadCarList()
        {
            DataTable data = CarDAO.GetAllData();
            dgvCarList.DataSource = data;
            if (data != null && data.Rows.Count > 0)
            {
                loadCarInfoFromDataGridViewRow(0);
            }
        }

        private void loadCarTicketMonthList()
        {
            DataTable data = CarDAO.GetAllTicketMonthData();
            dgvCarTicketMonthList.DataSource = data;
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

            if (data != null)
            {
                //Util.sendOrderListToServer(CarDAO.searchAllDataWithoutSetUserName(carDTO));
            }
        }

        private void searchCarByCondition(DateTime startDate, DateTime endDate, string userInId, string userOutId, int ticketType)
        {
            CarDTO carDTO = new CarDTO();
            carDTO.TimeStart = startDate;
            carDTO.TimeEnd = endDate;

            DataTable data = CarDAO.searchAllData(carDTO, userInId, userOutId, ticketType);
            dgvCarList.DataSource = data;
        }

        private void searchCarByConditionThongKeDoanhThu(DateTime startDate, DateTime endDate, string userInId, string userOutId, int ticketType)
        {
            CarDTO carDTO = new CarDTO();
            carDTO.TimeStart = startDate;
            carDTO.TimeEnd = endDate;

            DataTable data = CarDAO.searchAllDataThongKeDoanhThu(carDTO, userInId, userOutId, ticketType);
            dgvCarList.DataSource = data;
        }

        private void searchCarTicketMonth()
        {
            CarDTO carDTO = new CarDTO();
            DateTime startDate = dateTimePickerCarTicketMonthDateIn.Value;
            DateTime startTime = dateTimePickerCarTicketMonthTimeIn.Value;
            startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startTime.Hour, startTime.Minute, 0);
            carDTO.TimeStart = startDate;
            DateTime endDate = dateTimePickerCarTicketMonthDateOut.Value;
            DateTime endTime = dateTimePickerCarTicketMonthTimeOut.Value;
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, endTime.Hour, endTime.Minute, 0);
            carDTO.TimeEnd = endDate;

            TicketMonthDTO ticketMonthDTO = new TicketMonthDTO();
            ticketMonthDTO.CustomerName = tbCustomerName.Text;
            ticketMonthDTO.Company = tbCompany.Text;

            DataTable data = CarDAO.searchTicketMonthData(carDTO, ticketMonthDTO);
            dgvCarTicketMonthList.DataSource = data;
        }

        public static void loadUserDataToComboBox(ComboBox cb)
        {
            DataTable dt = UserDAO.GetAllData();
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr["NameUser"] = "Tất cả";
                dt.Rows.InsertAt(dr, 0);
                cb.DataSource = dt;
                cb.DisplayMember = "NameUser";
                cb.ValueMember = "UserID";
            }
        }

        public static void setFormatTimeForDateTimePicker(DateTimePicker dateTimePicker)
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "HH:mm"; // Only use hours and minutes
            dateTimePicker.ShowUpDown = true;
        }

        public static void setFormatDateForDateTimePicker(DateTimePicker dateTimePicker)
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dd-MM-yyyy";
            dateTimePicker.ShowUpDown = true;
        }

        private void tabQuanLyXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabQuanLyXe.SelectedTab == tabQuanLyXe.TabPages["tabPageTraCuuVaoRa"])
            {
                //loadCarList();
                loadUserDataToComboBox(comboBoxNhanVienVao);
                loadUserDataToComboBox(comboBoxNhanVienRa);
                loadPartDataWithFieldAllToComboBox(comboBoxTruyVanLoaiXe);

                setFormatTimeForDateTimePicker(dateTimePickerCarTimeIn);
                setFormatTimeForDateTimePicker(dateTimePickerCarTimeOut);
                setFormatDateForDateTimePicker(dateTimePickerCarDateIn);
                setFormatDateForDateTimePicker(dateTimePickerCarDateOut);

            }
            else if (tabQuanLyXe.SelectedTab == tabQuanLyXe.TabPages["tabPageTraCuuVaoRaVeThang"])
            {
                //loadCarTicketMonthList();

                dateTimePickerCarTicketMonthTimeIn.Format = DateTimePickerFormat.Custom;
                dateTimePickerCarTicketMonthTimeIn.CustomFormat = "HH:mm"; // Only use hours and minutes
                dateTimePickerCarTicketMonthTimeIn.ShowUpDown = true;
                dateTimePickerCarTicketMonthTimeOut.Format = DateTimePickerFormat.Custom;
                dateTimePickerCarTicketMonthTimeOut.CustomFormat = "HH:mm"; // Only use hours and minutes
                dateTimePickerCarTicketMonthTimeOut.ShowUpDown = true;
                setFormatDateForDateTimePicker(dateTimePickerCarTicketMonthDateIn);
                setFormatDateForDateTimePicker(dateTimePickerCarTicketMonthDateOut);
            }
        }

        private void btnSearchCar_Click(object sender, EventArgs e)
        {
            searchCar();
        }

        private void btnSearchCarTicketMonth_Click(object sender, EventArgs e)
        {
            searchCarTicketMonth();
        }

        private void btnAddBlackCar_Click(object sender, EventArgs e)
        {
            addBlackCar();
            loadBlackCarList();
        }

        void Delete_BlackCar_Click(Object sender, System.EventArgs e, int currentRow)
        {
            showConfirmDeleteBlackCar(currentRow);
        }

        private void deleteBlackCar(int currentRow)
        {
            int identify = Convert.ToInt32(dgvBlackCarList.Rows[currentRow].Cells["BlackCarIdentify"].Value);
            BlackCarDAO.Delete(identify);
            loadBlackCarList();
        }

        private void showConfirmDeleteBlackCar(int currentRow)
        {
            DialogResult dialogResult = MessageBox.Show(Constant.sMessageConfirmDelete, Constant.sTitleDelete, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                deleteBlackCar(currentRow);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void dgvBlackCarList_MouseClick(object sender, MouseEventArgs ev)
        {
            if (ev.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                MenuItem menuItem = new MenuItem(Constant.sButtonDelete);
                int currentRow = dgvBlackCarList.HitTest(ev.X, ev.Y).RowIndex;
                menuItem.Click += new EventHandler((s, e) => Delete_BlackCar_Click(s, e, currentRow));
                m.MenuItems.Add(menuItem);

                m.Show(dgvBlackCarList, new Point(ev.X, ev.Y));

            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            saveConfig();
        }

        private void saveConfig()
        {
            ConfigDTO configDTO = new ConfigDTO();
            int totalSpace = -1;
            if (int.TryParse(tbBikeSpace.Text, out totalSpace))
            {
                if (totalSpace >= 0)
                {
                    configDTO.BikeSpace = totalSpace;
                }
                else
                {
                    MessageBox.Show(Constant.sMessageInvalidError);
                    return;
                }
            }
            else
            {
                MessageBox.Show(Constant.sMessageInvalidError);
                return;
            }

            int ticketSpace = -1;
            if (int.TryParse(tbCarSpace.Text, out ticketSpace))
            {
                if (ticketSpace >= 0)
                {
                    configDTO.CarSpace = ticketSpace;
                }
                else
                {
                    MessageBox.Show(Constant.sMessageInvalidError);
                    return;
                }
            }
            else
            {
                MessageBox.Show(Constant.sMessageInvalidError);
                return;
            }

            ConfigDAO.UpdateXeTon(configDTO);
        }

        private bool isChosenRenewTicketMonthData()
        {
            foreach (DataGridViewRow row in dgvRenewTicketMonthList.Rows)
            {
                bool isChoose = Convert.ToBoolean(row.Cells["RenewIsChosen"].Value);
                if (isChoose)
                {
                    return true;
                }
            }
            return false;
        }

        private bool isChosenReceiptData()
        {
            foreach (DataGridViewRow row in dgvPrintReceipt.Rows)
            {
                bool isChoose = Convert.ToBoolean(row.Cells["ReceiptIsChosen"].Value);
                if (isChoose)
                {
                    return true;
                }
            }
            return false;
        }

        private int getCountReceiptIsChosen()
        {
            int count = 0;
            foreach (DataGridViewRow row in dgvPrintReceipt.Rows)
            {
                bool isChoose = Convert.ToBoolean(row.Cells["ReceiptIsChosen"].Value);
                if (isChoose)
                {
                    count++;
                }
            }
            return count;
        }

        private void btnRenewByExpirationDate_Click(object sender, EventArgs e)
        {
            if (!isChosenRenewTicketMonthData())
            {
                MessageBox.Show(Constant.sMessageNoChooseDataError);
                return;
            }
            DateTime expirationDate = dtRenewExpirationDate.Value.Date;
            foreach (DataGridViewRow row in dgvRenewTicketMonthList.Rows)
            {
                bool isChoose = Convert.ToBoolean(row.Cells["RenewIsChosen"].Value);
                string id = Convert.ToString(row.Cells["RenewTicketMonthID"].Value);
                if (isChoose)
                {
                    TicketMonthDAO.updateTicketByExpirationDate(expirationDate, id);
                }
            }
            searchNearExpiredTicketMonthData();
        }

        private void btnRenewByPlusDate_Click(object sender, EventArgs e)
        {
            if (!isChosenRenewTicketMonthData())
            {
                MessageBox.Show(Constant.sMessageNoChooseDataError);
                return;
            }
            int plusDate = 0;
            if (int.TryParse(tbRenewPlusDate.Text, out plusDate))
            {
                if (plusDate <= 0)
                {
                    MessageBox.Show(Constant.sMessageRenewPlusDateInvalidError);
                    return;
                }
            }
            else
            {
                MessageBox.Show(Constant.sMessageRenewPlusDateInvalidError);
                return;
            }
            foreach (DataGridViewRow row in dgvRenewTicketMonthList.Rows)
            {
                bool isChoose = Convert.ToBoolean(row.Cells["RenewIsChosen"].Value);
                string id = Convert.ToString(row.Cells["RenewTicketMonthID"].Value);
                DateTime expirationDate = Convert.ToDateTime(row.Cells["RenewExpirationDate"].Value);
                expirationDate = expirationDate.AddDays(plusDate);
                if (isChoose)
                {
                    TicketMonthDAO.updateTicketByExpirationDate(expirationDate, id);
                }
            }
            searchNearExpiredTicketMonthData();
        }

        private void btnSaveLostCard_Click(object sender, EventArgs e)
        {
            saveLostCard();
        }

        private void saveLostCard()
        {
            string functionId = UserDAO.GetFunctionIDByUserID(Program.CurrentManagerUserID);
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
                carDTO.IdOut = Program.CurrentManagerUserID;
                carDTO.Cost = 0;
                carDTO.IsLostCard = ConfigDAO.GetLostCard(ConfigDAO.GetConfig());
                carDTO.Computer = Environment.MachineName;
                carDTO.Account = Program.CurrentManagerUserID;
                carDTO.DateUpdate = DateTime.Now;
                carDTO.DateLostCard = DateTime.Now;
                DialogResult result = MessageBox.Show(Constant.sMessageConfirmSaveLostCard, Constant.sLabelAlert, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (CarDAO.UpdateLostCard(carDTO))
                    {
                        MessageBox.Show(Constant.sMessageUpdateSuccess);
                        searchCar();
                    }
                    else
                    {
                        MessageBox.Show(Constant.sMessageCommonError);
                    }
                }
            }
        }

        private void btnLostTicketMonthUpdate_Click(object sender, EventArgs e)
        {
            if (checkUpdateTicketMonthID(tbLostTicketMonthID.Text))
            {
                upDateLostTicketMonth();
            }
        }

        /*
         *System management
         */

        private void btnLuuCauHinhHienThi_Click(object sender, EventArgs e)
        {
            saveCauHinhHienThi();
            //new Thread(() =>
            //    {
            //        Thread.CurrentThread.IsBackground = true;
            //        Util.sendConfigToServer();
            //    }).Start();
        }

        private void loadCauHinhHienThiData()
        {
            DataTable dtConfig = ConfigDAO.GetConfig();
            int parkingTypeID = ConfigDAO.GetParkingTypeID(dtConfig);
            switch (parkingTypeID)
            {
                case Constant.LOAI_GIU_XE_MIEN_PHI:
                    rbGiuXeMienPhi.Checked = true;
                    break;
                case Constant.LOAI_GIU_XE_THEO_CONG_VAN:
                    rbGiuXeTheoCongVan.Checked = true;
                    break;
                case Constant.LOAI_GIU_XE_LUY_TIEN:
                    rbGiuXeLuyTien.Checked = true;
                    break;
                case Constant.LOAI_GIU_XE_TONG_HOP:
                    rbGiuXeTongHop.Checked = true;
                    break;
                case Constant.LOAI_GIU_XE_TONG_HOP_THEO_NGAY_DEM:
                    rbGiuXeTongHop2.Checked = true;
                    break;
                default:
                    rbGiuXeTheoCongVan.Checked = true;
                    break;
            }
            int calculationTicketMonthType = ConfigDAO.GetCalculationTicketMonth(dtConfig);
            checkBoxTinhTienVeThang.Checked = calculationTicketMonthType == ConfigDTO.CALCULATION_TICKET_MONTH_YES;

            tbParkingName.Text = ConfigDAO.GetParkingName(dtConfig);
            tbLostCard.Text = ConfigDAO.GetLostCard(dtConfig).ToString();
            tbBikeSpace2.Text = ConfigDAO.GetBikeSpace(dtConfig).ToString();
            tbCarSpace2.Text = ConfigDAO.GetCarSpace(dtConfig).ToString();
            tbTicketLimitDay2.Text = ConfigDAO.GetTicketMonthLimit(dtConfig).ToString();
            tbNightLimit2.Text = ConfigDAO.GetNightLimit(dtConfig).ToString();
            tbNoticeFeeContent.Text = ConfigDAO.GetNoticeFeeContent(dtConfig);
            numericEndHourNightShift.Value = ConfigDAO.GetEndHourNightShift(dtConfig);
            numericStartHourNightShift.Value = ConfigDAO.GetStartHourNightShift(dtConfig);

            loadQuyenNhanVien();

            int expiredTicketMonthTypeID = ConfigDAO.GetExpiredTicketMonthTypeID(dtConfig);
            switch (expiredTicketMonthTypeID)
            {
                case Constant.LOAI_HET_HAN_TINH_TIEN_NHU_VANG_LAI:
                    rbTinhTienNhuVangLai.Checked = true;
                    break;              
                case Constant.LOAI_HET_HAN_CHI_CANH_BAO_HET_HAN:
                default:
                    rbChiCanhBaoHetHan.Checked = true;
                    break;
            }
            
            int isAutoLockCard = ConfigDAO.GetIsAutoLockCard(dtConfig);
            cbTuDongKhoaThe.Checked = isAutoLockCard == ConfigDTO.AUTO_LOCK_CARD_YES;
            tbLockCardDate.Text = ConfigDAO.GetLockCardDate(dtConfig) + "";
            tbNoticeToBeExpireDate.Text = ConfigDAO.GetNoticeToBeExpireDate(dtConfig) + "";

            int isUseCostDeposit = ConfigDAO.GetIsUseCostDeposit(dtConfig);
            cbTinhPhiCocThe.Checked = isUseCostDeposit == ConfigDTO.USE_COST_DEPOSIT_YES;
            tbNoticeExpiredDate.Text = ConfigDAO.GetNoticeExpiredDate(dtConfig) + "";

            checkShowHideLockCardDate();
            checkShowHideNoticeExpiredDate();
        }

        private void loadQuyenNhanVien()
        {
            string functionId = Constant.FUNCTION_ID_NHAN_VIEN;
            string[] listFunctionSec = FunctionalDAO.GetFunctionSecByID(functionId).Split(',');
            if (listFunctionSec.Contains(Constant.NODE_VALUE_LUU_MAT_THE.ToString()))
            {
                cbSaveLostCardAccess.Checked = true;
            }
            else
            {
                cbSaveLostCardAccess.Checked = false;
            }
            if (listFunctionSec.Contains(Constant.NODE_VALUE_XEM_BAO_CAO_F7.ToString()))
            {
                cbSeeReportAccess.Checked = true;
            }
            else
            {
                cbSeeReportAccess.Checked = false;
            }
        }

        private void saveCauHinhHienThi()
        {
            int parkingTypeID = Constant.LOAI_GIU_XE_THEO_CONG_VAN;
            if (rbGiuXeMienPhi.Checked)
            {
                parkingTypeID = Constant.LOAI_GIU_XE_MIEN_PHI;
            }
            else if (rbGiuXeTheoCongVan.Checked)
            {
                parkingTypeID = Constant.LOAI_GIU_XE_THEO_CONG_VAN;
            }
            else if (rbGiuXeLuyTien.Checked)
            {
                parkingTypeID = Constant.LOAI_GIU_XE_LUY_TIEN;
            }
            else if (rbGiuXeTongHop.Checked)
            {
                parkingTypeID = Constant.LOAI_GIU_XE_TONG_HOP;
            }
            else if (rbGiuXeTongHop2.Checked)
            {
                parkingTypeID = Constant.LOAI_GIU_XE_TONG_HOP_THEO_NGAY_DEM;
            }

            int calculationTicketMonth = ConfigDTO.CALCULATION_TICKET_MONTH_NO;
            if (checkBoxTinhTienVeThang.Checked)
            {
                calculationTicketMonth = ConfigDTO.CALCULATION_TICKET_MONTH_YES;
            }

            int expiredTicketMonthTypeID = Constant.LOAI_HET_HAN_TINH_TIEN_NHU_VANG_LAI;
            if (rbTinhTienNhuVangLai.Checked)
            {
                expiredTicketMonthTypeID = Constant.LOAI_HET_HAN_TINH_TIEN_NHU_VANG_LAI;
            }
            else if (rbChiCanhBaoHetHan.Checked)
            {
                expiredTicketMonthTypeID = Constant.LOAI_HET_HAN_CHI_CANH_BAO_HET_HAN;
            }

            ConfigDTO configDTO = new ConfigDTO();
            configDTO.ParkingTypeId = parkingTypeID;
            configDTO.CalculationTicketMonth = calculationTicketMonth;
            configDTO.ExpiredTicketMonthTypeID = expiredTicketMonthTypeID;

            int lostCard;
            if (int.TryParse(tbLostCard.Text, out lostCard))
            {
                if (lostCard >= 0)
                {
                    configDTO.LostCard = lostCard;
                }
                else
                {
                    MessageBox.Show(Constant.sMessageInvalidError);
                    return;
                }
            }
            else
            {
                MessageBox.Show(Constant.sMessageInvalidError);
                return;
            }

            int totalSpace = -1;
            if (int.TryParse(tbBikeSpace2.Text, out totalSpace))
            {
                if (totalSpace >= 0)
                {
                    configDTO.BikeSpace = totalSpace;
                }
                else
                {
                    MessageBox.Show(Constant.sMessageInvalidError);
                    return;
                }
            }
            else
            {
                MessageBox.Show(Constant.sMessageInvalidError);
                return;
            }

            int ticketSpace = -1;
            if (int.TryParse(tbCarSpace2.Text, out ticketSpace))
            {
                if (ticketSpace >= 0)
                {
                    configDTO.CarSpace = ticketSpace;
                }
                else
                {
                    MessageBox.Show(Constant.sMessageInvalidError);
                    return;
                }
            }
            else
            {
                MessageBox.Show(Constant.sMessageInvalidError);
                return;
            }


            int ticketLimitDay = -1;
            if (int.TryParse(tbTicketLimitDay2.Text, out ticketLimitDay))
            {
                if (ticketLimitDay >= 0)
                {
                    configDTO.TicketLimitDay = ticketLimitDay;
                }
                else
                {
                    MessageBox.Show(Constant.sMessageInvalidError);
                    return;
                }
            }
            else
            {
                MessageBox.Show(Constant.sMessageInvalidError);
                return;
            }


            int nightLimit = -1;
            if (int.TryParse(tbNightLimit2.Text, out nightLimit))
            {
                if (nightLimit >= 0)
                {
                    configDTO.NightLimit = nightLimit;
                }
                else
                {
                    MessageBox.Show(Constant.sMessageInvalidError);
                    return;
                }
            }
            else
            {
                MessageBox.Show(Constant.sMessageInvalidError);
                return;
            }

            configDTO.ParkingName = tbParkingName.Text;

            int isAuToLockCard = ConfigDTO.AUTO_LOCK_CARD_NO;
            if (cbTuDongKhoaThe.Checked)
            {
                isAuToLockCard = ConfigDTO.AUTO_LOCK_CARD_YES;
            }
            configDTO.IsAutoLockCard = isAuToLockCard;

            int isUseCostDeposit = ConfigDTO.USE_COST_DEPOSIT_NO;
            if (cbTinhPhiCocThe.Checked)
            {
                isUseCostDeposit = ConfigDTO.USE_COST_DEPOSIT_YES;
            }
            configDTO.IsUseCostDeposit = isUseCostDeposit;

            int lockCardDate = 5;
            if (int.TryParse(tbLockCardDate.Text, out lockCardDate))
            {
                if (lockCardDate < 1 || lockCardDate > 28)
                {
                    MessageBox.Show(Constant.sMessageInvalidError);
                    return;
                }
            }
            configDTO.LockCardDate = lockCardDate;

            int noticeExpiredDate = 25;
            if (int.TryParse(tbNoticeExpiredDate.Text, out noticeExpiredDate))
            {
                if (noticeExpiredDate < 1 || noticeExpiredDate > 28)
                {
                    MessageBox.Show(Constant.sMessageInvalidError);
                    return;
                }
            }
            configDTO.NoticeExpiredDate = noticeExpiredDate;

            int noticeToBeExpireDate = 20;
            if (int.TryParse(tbNoticeToBeExpireDate.Text, out noticeToBeExpireDate))
            {
                if (noticeToBeExpireDate < 1 || noticeToBeExpireDate > 28)
                {
                    MessageBox.Show(Constant.sMessageInvalidError);
                    return;
                }
            }
            configDTO.NoticeToBeExpireDate = noticeToBeExpireDate;

            configDTO.NoticeFeeContent = tbNoticeFeeContent.Text;
            configDTO.StartHourNightShift = (int) numericStartHourNightShift.Value;
            configDTO.EndHourNightShift = (int) numericEndHourNightShift.Value;

            if (ConfigDAO.UpdateCauHinhHienThi(configDTO))
            {
                MessageBox.Show(Constant.sMessageUpdateSuccess);
            }

            saveQuyenNhanVien();
        }

        private void saveQuyenNhanVien()
        {
            string functionId = Constant.FUNCTION_ID_NHAN_VIEN;
            string[] listFunctionSec = FunctionalDAO.GetFunctionSecByID(functionId).Split(',');
            var list = new List<string>(listFunctionSec);
            if (listFunctionSec.Contains(Constant.NODE_VALUE_LUU_MAT_THE.ToString()))
            {
                list.Remove(Constant.NODE_VALUE_LUU_MAT_THE.ToString());
            }
            if (cbSaveLostCardAccess.Checked)
            {
                list.Add(Constant.NODE_VALUE_LUU_MAT_THE.ToString());
            }

            if (listFunctionSec.Contains(Constant.NODE_VALUE_XEM_BAO_CAO_F7.ToString()))
            {
                list.Remove(Constant.NODE_VALUE_XEM_BAO_CAO_F7.ToString());
            }
            if (cbSeeReportAccess.Checked)
            {
                list.Add(Constant.NODE_VALUE_XEM_BAO_CAO_F7.ToString());
            }
            listFunctionSec = list.ToArray();
            String functionSec = string.Join(",", listFunctionSec);
            FunctionalDAO.UpdateFunctionSec(functionSec, functionId);
        }

        private void loadCarListForCashManagement()
        {
            DataTable dt = CarDAO.GetAllDataForCashManagement();
            dgvCashManagementList.DataSource = dt;
        }

        private void loadUserAcessData()
        {
            cbUserFunctionAccessSetting.DataSource = FunctionalDAO.GetAllDataWithoutAdmin();
            cbUserFunctionAccessSetting.DisplayMember = "FunctionName";
            cbUserFunctionAccessSetting.ValueMember = "FunctionID";
            DataRow functionDataRow = ((DataRowView)cbUserFunctionAccessSetting.SelectedItem).Row;
            string functionID = functionDataRow["FunctionID"].ToString();
            loadUserAcessDataFromFunctionID(functionID);
        }

        private void saveUserAccessData()
        {
            string listNodeID = "";
            foreach (TreeNode node in treeViewPhanQuyenTruyCap.Nodes)
            {
                // child node
                if (node.Nodes.Count > 0)
                {
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        if (childNode.Checked)
                        {
                            listNodeID += childNode.Name.Replace(Constant.NODE_NAME, "") + ",";
                        }
                    }
                }
                else
                {
                    // parent node
                    if (node.Checked)
                    {
                        listNodeID += node.Name.Replace(Constant.NODE_NAME, "") + ",";
                    }
                }
            }
            listNodeID = listNodeID.Remove(listNodeID.Length - 1);

            DataRow functionDataRow = ((DataRowView)cbUserFunctionAccessSetting.SelectedItem).Row;
            string functionId = functionDataRow["FunctionID"].ToString();
            FunctionalDAO.UpdateFunctionSec(listNodeID, functionId);
            MessageBox.Show("Cập nhật thành công");
        }

        private void loadLogList()
        {
            dgvLogList.DataSource = LogDAO.GetAllData();
        }

        private void searchLog()
        {
            string key = tbLogSearchKeyWord.Text;
            DataRow dataRow = ((DataRowView)cbLogType.SelectedItem).Row;
            string logTypeID = dataRow["LogTypeID"].ToString();
            DateTime startTime = dtLogSearchStartTime.Value;
            startTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 0, 0, 0);
            DateTime endTime = dtLogSearchEndTime.Value;
            endTime = new DateTime(endTime.Year, endTime.Month, endTime.Day, 23, 59, 59);
            dgvLogList.DataSource = LogDAO.SearchData(key, logTypeID, startTime, endTime);
        }

        private void cbUserFunctionAccessSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow functionDataRow = ((DataRowView)cbUserFunctionAccessSetting.SelectedItem).Row;
            string functionID = functionDataRow["FunctionID"].ToString();
            loadUserAcessDataFromFunctionID(functionID);
        }

        private void tabQuanLyHeThong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabQuanLyHeThong.SelectedTab == tabQuanLyHeThong.TabPages["tabPageCauHinhCoBan"])
            {
                loadCauHinhHienThiData();
            }
            else if (tabQuanLyHeThong.SelectedTab == tabQuanLyHeThong.TabPages["tabPageQuanLyThuTienXe"])
            {
                //loadCarListForCashManagement
                setFormatDateForDateTimePicker(dtCashManagementStartDate);
                setFormatDateForDateTimePicker(dtCashManagementEndDate);
            }
            else if (tabQuanLyHeThong.SelectedTab == tabQuanLyHeThong.TabPages["tabPagePhanQuyenTruyCap"])
            {
                loadUserAcessData();
            }
            else if (tabQuanLyHeThong.SelectedTab == tabQuanLyHeThong.TabPages["tabPageNhatKyHeThong"])
            {
                //loadLogList();
                loadLogTypeDataWithAllToComboBox(cbLogType);
                setFormatDateForDateTimePicker(dtLogSearchStartTime);
                setFormatDateForDateTimePicker(dtLogSearchEndTime);
            }
        }

        private void btnSaveUserAccess_Click(object sender, EventArgs e)
        {
            saveUserAccessData();
            checkShowHideAllTabPage();
        }

        private void loadUserAcessDataFromFunctionID(string functionID)
        {
            foreach (TreeNode treeNode in treeViewPhanQuyenTruyCap.Nodes)
            {
                treeNode.Checked = false;
                foreach (TreeNode childTreeNode in treeNode.Nodes)
                {
                    childTreeNode.Checked = false;
                }
            }
            string[] listFunctionSec = FunctionalDAO.GetFunctionSecByID(functionID).Split(',');
            foreach (string nodeID in listFunctionSec)
            {
                string nodeName = Constant.NODE_NAME + nodeID;
                if (treeViewPhanQuyenTruyCap.Nodes.Find(nodeName, true) != null && treeViewPhanQuyenTruyCap.Nodes.Find(nodeName, true).Length > 0)
                {
                    TreeNode treeNode = treeViewPhanQuyenTruyCap.Nodes.Find(nodeName, true)[0];
                    if (treeNode != null)
                    {
                        treeNode.Checked = true;
                    }
                }
            }
            if (checkTickParentNodeWhenLoadData(listFunctionSec, listFunctionQuanLyNhanSu))
            {
                treeViewPhanQuyenTruyCap.Nodes.Find("NodeQuanLyNhanSu", true)[0].Checked = true;
            }
            if (checkTickParentNodeWhenLoadData(listFunctionSec, listFunctionQuanLyDoanhThu))
            {
                treeViewPhanQuyenTruyCap.Nodes.Find("NodeQuanLyDoanhThu", true)[0].Checked = true;
            }
            if (checkTickParentNodeWhenLoadData(listFunctionSec, listFunctionQuanLyTheLoaiXe))
            {
                treeViewPhanQuyenTruyCap.Nodes.Find("NodeQuanLyTheLoaiXe", true)[0].Checked = true;
            }
            if (checkTickParentNodeWhenLoadData(listFunctionSec, listFunctionQuanLyVeThang))
            {
                treeViewPhanQuyenTruyCap.Nodes.Find("NodeQuanLyVeThang", true)[0].Checked = true;
            }
            if (checkTickParentNodeWhenLoadData(listFunctionSec, listFunctionQuanLyHeThong))
            {
                treeViewPhanQuyenTruyCap.Nodes.Find("NodeQuanLyHeThong", true)[0].Checked = true;
            }
            if (checkTickParentNodeWhenLoadData(listFunctionSec, listFunctionQuanLyXe))
            {
                treeViewPhanQuyenTruyCap.Nodes.Find("NodeQuanLyXe", true)[0].Checked = true;
            }
            if (checkTickParentNodeWhenLoadData(listFunctionSec, listFunctionQuanLyPhieuThuChi))
            {
                treeViewPhanQuyenTruyCap.Nodes.Find("NodeQuanLyPhieuThuChi", true)[0].Checked = true;
            }
        }

        private bool checkTickParentNodeWhenLoadData(string[] listAllFunctionSelect, string[] listFunctionTarget)
        {
            foreach (string functionId in listFunctionTarget)
            {
                if (!listAllFunctionSelect.Contains(functionId))
                {
                    return false;
                }
            }
            return true;
        }

        //private bool checkTickParentNodeWhenUserCheck(string[] listFunctionTarget)
        //{
        //    foreach (string functionId in listFunctionTarget)
        //    {
        //        string nodeName = Constant.NODE_NAME + functionId;
        //        TreeNode treeNode = treeViewPhanQuyenTruyCap.Nodes.Find(nodeName, true)[0];
        //        if (treeNode != null)
        //        {
        //            if (!treeNode.Checked)
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}

        //private void tickParentNodeWhenUserCheck()
        //{
        //    if (checkTickParentNodeWhenUserCheck(listFunctionQuanLyNhanSu))
        //    {
        //        TreeNode treeNode = treeViewPhanQuyenTruyCap.Nodes.Find("NodeQuanLyNhanSu", true)[0];
        //        treeNode.Checked = true;
        //    }
        //    if (checkTickParentNodeWhenUserCheck(listFunctionQuanLyDoanhThu))
        //    {
        //        treeViewPhanQuyenTruyCap.Nodes.Find("NodeQuanLyDoanhThu", true)[0].Checked = true;
        //    }
        //    if (checkTickParentNodeWhenUserCheck(listFunctionQuanLyTheLoaiXe))
        //    {
        //        treeViewPhanQuyenTruyCap.Nodes.Find("NodeQuanLyTheLoaiXe", true)[0].Checked = true;
        //    }
        //    if (checkTickParentNodeWhenUserCheck(listFunctionQuanLyVeThang))
        //    {
        //        treeViewPhanQuyenTruyCap.Nodes.Find("NodeQuanLyVeThang", true)[0].Checked = true;
        //    }
        //    if (checkTickParentNodeWhenUserCheck(listFunctionQuanLyHeThong))
        //    {
        //        treeViewPhanQuyenTruyCap.Nodes.Find("NodeQuanLyHeThong", true)[0].Checked = true;
        //    }
        //    if (checkTickParentNodeWhenUserCheck(listFunctionQuanLyXe))
        //    {
        //        treeViewPhanQuyenTruyCap.Nodes.Find("NodeQuanLyXe", true)[0].Checked = true;
        //    }
        //}

        private void SelectParents(TreeNode node, Boolean isChecked)
        {
            var parent = node.Parent;

            if (parent == null)
                return;

            if (isChecked)
            {
                parent.Checked = true; // we should always check parent
                SelectParents(parent, true);
            }
            else
            {
                if (parent.Nodes.Cast<TreeNode>().Any(n => n.Checked))
                    return; // do not uncheck parent if there other checked nodes

                SelectParents(parent, false); // otherwise uncheck parent
            }
        }

        private void checkShowHideAllTabPage()
        {
            string functionID = UserDAO.GetFunctionIDByUserID(Program.CurrentManagerUserID);
            if (functionID.Equals(Constant.FUNCTION_ID_ADMIN))
            {
                return;
            }
            string[] listFunctionSec = FunctionalDAO.GetFunctionSecByID(functionID).Split(',');

            int countTabQuanLyNhanSu = 0;
            countTabQuanLyNhanSu += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_THONG_TIN_NHAN_SU, tabPageThongTinNhanSu, tabQuanLyNhanSu);
            countTabQuanLyNhanSu += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_DO_BANG_CHAM_CONG, tabPageDoBangChamCong, tabQuanLyNhanSu);
            if (countTabQuanLyNhanSu == 0)
            {
                tabQuanLy.TabPages.Remove(tabPageQuanLyNhanSu);
            }

            int countTabQuanLyDoanhThu = 0;
            countTabQuanLyDoanhThu += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_XEM_THONG_KE, tabPageThongKeDoanhThu, tabQuanLyDoanhThu);
            countTabQuanLyDoanhThu += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_DIEU_CHINH_CONG_THUC_TINH_TIEN, tabPageCongThucTinhTienTheoCongVan, tabQuanLyDoanhThu);
            countTabQuanLyDoanhThu += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_DIEU_CHINH_CONG_THUC_TINH_TIEN, tabPageCongThucTinhTienLuyTien, tabQuanLyDoanhThu);
            countTabQuanLyDoanhThu += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_DIEU_CHINH_CONG_THUC_TINH_TIEN, tabPageCongThucTongHop, tabQuanLyDoanhThu);
            countTabQuanLyDoanhThu += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_DIEU_CHINH_CONG_THUC_TINH_TIEN, tabPageCongThucTongHop2, tabQuanLyDoanhThu);
            if (countTabQuanLyDoanhThu == 0)
            {
                tabQuanLy.TabPages.Remove(tabPageQuanLyDoanhThu);
            }

            int countTabQuanLyTheXeLoaiXe = 0;
            countTabQuanLyTheXeLoaiXe += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_QUAN_LY_THE_XE, tabPageQuanLyTheXe, tabQuanLyThe_LoaiXe);
            countTabQuanLyTheXeLoaiXe += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_QUAN_LY_LOAI_XE, tabPageQuanLyLoaiXe, tabQuanLyThe_LoaiXe);
            countTabQuanLyTheXeLoaiXe += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_KHOA_THE, tabPageKhoaThe, tabQuanLyThe_LoaiXe);
            countTabQuanLyTheXeLoaiXe += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_KICH_HOAT_THE, tabPageKichHoatThe, tabQuanLyThe_LoaiXe);
            if (countTabQuanLyTheXeLoaiXe == 0)
            {
                tabQuanLy.TabPages.Remove(tabPageQuanLyTheXeLoaiXe);
            }

            int countTabQuanLyVeThang = 0;
            countTabQuanLyVeThang += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_NHAT_KY_VE_THANG, tabPageXemNhatKyVeThang, tabQuanLyVeThang);
            countTabQuanLyVeThang += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_CAP_NHAT_THONG_TIN_VE_THANG, 
                Constant.NODE_VALUE_TIM_VE_THANG, tabPageTaoMoiVeThang, tabQuanLyVeThang);
            countTabQuanLyVeThang += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_GIA_HAN_VE_THANG, tabPageGiaHanVeThang, tabQuanLyVeThang);
            countTabQuanLyVeThang += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_MAT_THE_THANG, tabPageMatVeThang, tabQuanLyVeThang);
            countTabQuanLyVeThang += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_KHOA_VE_THANG, tabPageKhoaVeThang, tabQuanLyVeThang);
            countTabQuanLyVeThang += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_KICH_HOAT_VE_THANG, tabPageKichHoatVeThang, tabQuanLyVeThang);
            countTabQuanLyVeThang += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_BAO_CAO_CONG_NO, tabPageBaoCaoCongNo, tabQuanLyVeThang);
            if (countTabQuanLyVeThang == 0)
            {
                tabQuanLy.TabPages.Remove(tabPageQuanLyVeThang);
            }

            int countTabQuanLyHeThong = 0;
            countTabQuanLyHeThong += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_CAU_HINH_CO_BAN, tabPageCauHinhCoBan, tabQuanLyHeThong);
            countTabQuanLyHeThong += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_QUAN_LY_TIEN_THU, tabPageQuanLyThuTienXe, tabQuanLyHeThong);
            countTabQuanLyHeThong += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_PHAN_QUYEN_TRUY_CAP, tabPagePhanQuyenTruyCap, tabQuanLyHeThong);
            countTabQuanLyHeThong += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_NHAT_KY_HE_THONG, tabPageNhatKyHeThong, tabQuanLyHeThong);
            if (countTabQuanLyHeThong == 0)
            {
                tabQuanLy.TabPages.Remove(tabPageQuanLyHeThong);
            }

            int countTabQuanLyXe = 0;
            countTabQuanLyXe += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_THIET_LAP_RA_VAO, tabPageThietLapRaVao, tabQuanLyXe);
            countTabQuanLyXe += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_TRA_CUU_VAO_RA, tabPageTraCuuVaoRa, tabQuanLyXe);
            countTabQuanLyXe += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_TRA_CUU_VAO_RA_VE_THANG, tabPageTraCuuVaoRaVeThang, tabQuanLyXe);
            countTabQuanLyXe += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_XEM_HOP_DEN, tabPageXemHopDen, tabQuanLyXe);
            if (countTabQuanLyXe == 0)
            {
                tabQuanLy.TabPages.Remove(tabPageQuanLyXeRaVao);
            }

            int countTabQuanLyPhieuThuChi = 0;
            countTabQuanLyPhieuThuChi += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_IN_PHIEU_THU_CHI, 
                Constant.NODE_VALUE_IN_PHIEU_THONG_BAO_PHI, tabPageInPhieuThuChi, tabQuanLyPhieuThuChi);
            countTabQuanLyPhieuThuChi += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_LICH_SU_PHIEU_THU_CHI, tabPageLichSuPhieuThuChi, tabQuanLyPhieuThuChi);
            countTabQuanLyPhieuThuChi += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_LICH_SU_PHIEU_THU_CHI, tabPageChiTietPhieuThuChi, tabQuanLyPhieuThuChi);
            if (countTabQuanLyPhieuThuChi == 0)
            {
                tabQuanLy.TabPages.Remove(tabPageQuanLyPhieuThuChi);
            }
        }
        private int checkShowTabPage(string[] listFunctionSec, int nodeValue, TabPage tabPage, TabControl tabControl)
        {
            (tabPage as TabPage).Enabled = true;
            if (Array.IndexOf(listFunctionSec, nodeValue + "") == -1)
            {
                (tabPage as TabPage).Enabled = false;
                (tabPage as TabPage).Hide();
                tabControl.TabPages.Remove(tabPage);
                return 0;
            }
            return 1;
        }

        private int checkShowTabPage(string[] listFunctionSec, int nodeValue1, int nodeValue2, TabPage tabPage, TabControl tabControl)
        {
            (tabPage as TabPage).Enabled = true;
            if (Array.IndexOf(listFunctionSec, nodeValue1 + "") == -1 && Array.IndexOf(listFunctionSec, nodeValue2 + "") == -1)
            {
                (tabPage as TabPage).Enabled = false;
                (tabPage as TabPage).Hide();
                tabControl.TabPages.Remove(tabPage);
                return 0;
            }
            return 1;
        }

        private void treeViewPhanQuyenTruyCap_AfterCheck(object sender, TreeViewEventArgs e)
        {
            checkTreeViewNode(e.Node, e.Node.Checked);
        }

        private void checkTreeViewNode(TreeNode node, Boolean isChecked)
        {
            foreach (TreeNode item in node.Nodes)
            {
                item.Checked = isChecked;
                if (item.Nodes.Count > 0)
                {
                    checkTreeViewNode(item, isChecked);
                }
            }
        }

        private void loadLogInfoFromDataGridViewRow(int Index)
        {
            if (Index < 0)
            {
                return;
            }
            string logType = Convert.ToString(dgvLogList.Rows[Index].Cells["CommonLogTypeName"].Value);
            labelLogType.Text = logType;
            string processDate = Convert.ToString(dgvLogList.Rows[Index].Cells["CommonLogProcessDate"].Value);
            labelLogProcessDate.Text = processDate;
            string account = Convert.ToString(dgvLogList.Rows[Index].Cells["CommonLogNameUser"].Value);
            labelLogUserName.Text = account;
            string computer = Convert.ToString(dgvLogList.Rows[Index].Cells["CommonLogComputer"].Value);
            labelLogComputer.Text = computer;
            string note = Convert.ToString(dgvLogList.Rows[Index].Cells["CommonLogNote"].Value);
            tbLogNote.Text = note;
        }

        private void dgvLogList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = e.RowIndex;
            int Count = dgvLogList.Rows.Count;
            if (Index < Count)
            {
                loadLogInfoFromDataGridViewRow(Index);
            }
        }

        private void loadLogTypeDataWithAllToComboBox(ComboBox cb)
        {
            DataTable dt = LogTypeDAO.GetAllData();
            DataRow dr = dt.NewRow();
            dr["LogTypeName"] = "Tất cả";
            dt.Rows.InsertAt(dr, 0);
            cb.DataSource = dt;
            cb.DisplayMember = "LogTypeName";
            cb.ValueMember = "LogTypeID";
        }

        private void btnLogSearch_Click(object sender, EventArgs e)
        {
            searchLog();
        }

        private void tbLogShowAllData_Click(object sender, EventArgs e)
        {
            loadLogList();
        }

        //private void exportToExcel(DataGridView dataGridView, Microsoft.Office.Interop.Excel._Worksheet worksheet, int cellRowIndex, int cellColumnIndex)
        //{
        //    int originalCellColumnIndex = cellColumnIndex;
        //    //Loop through each row and read value from each column. 
        //    for (int i = 0; i < dataGridView.Columns.Count; i++)
        //    {
        //        if (dataGridView.Columns[i].Visible && dataGridView.Columns[i].CellType == typeof(DataGridViewTextBoxCell))
        //        {
        //            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView.Columns[i].HeaderText;
        //            Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[cellRowIndex, cellColumnIndex];
        //            setColerForRange(range);
        //            setAllBorderForRange(range);
        //            cellColumnIndex++;
        //        }
        //    }

        //    cellRowIndex++;
        //    cellColumnIndex = originalCellColumnIndex;
        //    for (int i = 0; i < dataGridView.Rows.Count; i++)
        //    {
        //        for (int j = 0; j < dataGridView.Columns.Count; j++)
        //        {
        //            if (dataGridView.Columns[j].Visible && dataGridView.Columns[j].CellType == typeof(DataGridViewTextBoxCell))
        //            {
        //                Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[cellRowIndex, cellColumnIndex];
        //                worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView.Rows[i].Cells[j].Value.ToString();
        //                setLeftBorderForRange(range);
        //                setRightBorderForRange(range);
        //                if (i == dataGridView.Rows.Count - 1)
        //                {
        //                    setBottomBorderForRange(range);
        //                }
        //                cellColumnIndex++;
        //            }
        //        }
        //        cellColumnIndex = 1;
        //        cellRowIndex++;
        //    }
        //}

        private void exportToExcel(DataGridView dataGridView, IXLWorksheet worksheet, int cellRowIndex, int cellColumnIndex, string fileName)
        {
            worksheet.Columns().AdjustToContents();
            worksheet.Rows().AdjustToContents();

            int originalCellColumnIndex = cellColumnIndex;
            //Loop through each row and read value from each column. 
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                if (dataGridView.Columns[i].Visible && dataGridView.Columns[i].CellType == typeof(DataGridViewTextBoxCell))
                {                   
                    IXLCell cell = worksheet.Cell(cellRowIndex, cellColumnIndex);
                    cell.Value = dataGridView.Columns[i].HeaderText;
                    setColerForRange(cell);
                    setAllBorderForRange(cell);
                    cellColumnIndex++;
                }
            }

            cellRowIndex++;
            cellColumnIndex = originalCellColumnIndex;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    if (dataGridView.Columns[j].Visible && dataGridView.Columns[j].CellType == typeof(DataGridViewTextBoxCell))
                    {                                              
                        IXLCell cell = worksheet.Cell(cellRowIndex, cellColumnIndex);
                        cell.Style.NumberFormat.Format = "@";
                        cell.Value = dataGridView.Rows[i].Cells[j].Value.ToString();
                        setAllBorderForRange(cell);
                        cellColumnIndex++;
                    }
                }
                cellColumnIndex = 1;
                cellRowIndex++;
            }

            //Getting the location and file name of the excel to save from user. 
            if (fileName != null)
            {                
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.InitialDirectory = Environment.CurrentDirectory;
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FilterIndex = 2;
                saveDialog.FileName = fileName + "_" + Util.getCurrentDateTimeString();

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    worksheet.Workbook.SaveAs(saveDialog.FileName);
                    DialogResult result = MessageBox.Show(Constant.sMessageExportExcelSuccess, "", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        Process.Start(saveDialog.FileName);
                    }
                }
            }            
        }

        private void exportDanhSachXeToExcel()
        {          
            try
            {
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Danh sách xe ra vào");

                //Loop through each row and read value from each column.
                string fileName = "Export_danhsach_xe_ravao";
                exportToExcel(dgvCarList, worksheet, 1, 1, fileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void exportDanhSachXeThangToExcel()
        {
            try
            {
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Danh sách xe tháng");

                //Loop through each row and read value from each column.
                string fileName = "Export_danhsach_xethang";
                exportToExcel(dgvCarTicketMonthList, worksheet, 1, 1, fileName);            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void exportBangChamCongToExcel()
        {
            try
            {
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Danh sách chấm công");

                //Loop through each row and read value from each column.
                string fileName = "Export_cham_cong";
                exportToExcel(dgvWorkList, worksheet, 1, 1, fileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void exportDoanhThuTongQuatToExcel()
        {
            try
            {
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Doanh thu tổng quát");

                string fileName = "Export_thongke_doanhthu_tongquat";
                exportToExcel(dgvThongKeDoanhThu, worksheet, 1, 1, fileName);

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.InitialDirectory = Environment.CurrentDirectory;
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FilterIndex = 2;
                saveDialog.FileName = "Export_thongke_doanhthu_tongquat_" + Util.getCurrentDateTimeString();

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show(Constant.sMessageExportExcelSuccess);
                    Process.Start(saveDialog.FileName);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void exportDoanhSachTheXeToExcel()
        {
            try
            {
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Danh sách thẻ xe");

                exportToExcel(dgvCardStatistic, worksheet, 1, 1, null);
                int cellRowIndex = dgvCardStatistic.Rows.Count + 3;
                string fileName = "Export_danhsach_thexe";
                exportToExcel(dgvCardList, worksheet, cellRowIndex, 1, fileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void exportNhatKyVeThangToExcel()
        {
            try
            {
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Nhật ký vé tháng");

                string fileName = "Export_nhatky_vethang";
                exportToExcel(dgvTicketLogList, worksheet, 1, 1, fileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void exportDanhSachTheHetHanToExcel()
        {
            try
            {
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Danh sách thẻ hết hạn");

                string fileName = "Export_danhsach_the_hethan";
                exportToExcel(dgvRenewTicketMonthList, worksheet, 1, 1, fileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void exportNhatKyHeThongToExcel()
        {
            try
            {
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Nhật ký hệ thống");

                string fileName = "Export_nhatky_hethong";
                exportToExcel(dgvLogList, worksheet, 1, 1, fileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void exportDanhSachKhoaTheThangToExcel()
        {
            try
            {
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Danh sách khóa thẻ tháng");

                string fileName = "Export_danhsach_khoa_thethang";
                exportToExcel(dgvBlockTicketMonthList, worksheet, 1, 1, fileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void exportDanhSachKichHoatTheThangToExcel()
        {
            try
            {
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Danh sách kích hoạt thẻ tháng");

                string fileName = "Export_danhsach_kichhoat_thethang";
                exportToExcel(dgvActiveTicketMonthList, worksheet, 1, 1, fileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void exportDanhSachBaoCaoCongNoToExcel()
        {
            try
            {
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Danh sách công nợ");

                string fileName = "Export_danhsach_congno";
                exportToExcel(dgvDebtReport, worksheet, 1, 1, fileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        //private void exportDoanhThuChiTietToExcel()
        //{
        //    // Creating a Excel object. 
        //    Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
        //    Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
        //    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

        //    try
        //    {

        //        worksheet = workbook.ActiveSheet;
        //        worksheet.Name = "Doanh thu chi tiết";

        //        //Loop through each row and read value from each column. 
        //        exportToExcel(dgvThongKeDoanhThu, worksheet, 1, 1);
        //        int cellRowIndex = dgvThongKeDoanhThu.Rows.Count + 3;
        //        exportToExcel(dgvCarList, worksheet, cellRowIndex, 1);

        //        excel.Columns.AutoFit();

        //        //Getting the location and file name of the excel to save from user. 
        //        SaveFileDialog saveDialog = new SaveFileDialog();
        //        saveDialog.InitialDirectory = Environment.CurrentDirectory;
        //        saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
        //        saveDialog.FilterIndex = 2;
        //        saveDialog.FileName = "Export_thongke_doanhthu_chitiet_" + Util.getCurrentDateTimeString();

        //        if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        {
        //            workbook.SaveAs(saveDialog.FileName);
        //            MessageBox.Show(Constant.sMessageExportExcelSuccess);
        //            Process.Start(saveDialog.FileName);
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        excel.Quit();
        //        workbook = null;
        //        excel = null;
        //    }
        //}

        private void exportDoanhThuChiTietToExcel()
        {
            try
            {
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Doanh thu chi tiết");

                //Loop through each row and read value from each column. 
                exportToExcel(dgvThongKeDoanhThu, worksheet, 1, 1, null);
                int cellRowIndex = dgvThongKeDoanhThu.Rows.Count + 3;
                string fileName = "Export_thongke_doanhthu_chitiet";
                exportToExcel(dgvCarList, worksheet, cellRowIndex, 1, fileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void exportDanhSachTheThangToExcel()
        {            
            try
            {
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Danh sách thẻ tháng");

                string fileName = "Export_danhsach_thethang";
                exportToExcel(dgvTicketMonthList, worksheet, 1, 1, fileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void setLeftBorderForRange(Microsoft.Office.Interop.Excel.Range range)
        {
            range.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
        }

        private void setRightBorderForRange(Microsoft.Office.Interop.Excel.Range range)
        {
            range.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
        }

        private void setTopBorderForRange(Microsoft.Office.Interop.Excel.Range range)
        {
            range.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
        }

        private void setBottomBorderForRange(Microsoft.Office.Interop.Excel.Range range)
        {
            range.Borders.get_Item(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
        }

        //private void setAllBorderForRange(Microsoft.Office.Interop.Excel.Range range)
        //{
        //    setLeftBorderForRange(range);
        //    setRightBorderForRange(range);
        //    setTopBorderForRange(range);
        //    setBottomBorderForRange(range);
        //}

        private void setAllBorderForRange(IXLCell cell)
        {
            cell.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
        }        

        //private void setColerForRange(Microsoft.Office.Interop.Excel.Range range)
        //{
        //    range.Font.Color = ColorTranslator.ToOle(Color.Blue);
        //    range.Font.Bold = true;
        //}

        private void setColerForRange(IXLCell range)
        {
            range.Style.Font.FontColor = XLColor.Blue;
            range.Style.Font.Bold = true;
        }

        private void btnExportDoanhThuTongQuat_Click(object sender, EventArgs e)
        {
            if (mExportSaleType == EXPORT_SALE_NOT_YET_SEARCH)
            {
                MessageBox.Show("Chưa có dữ liệu để xuất Excel");
            }
            else
            {
                exportDoanhThuTongQuatToExcel();
            }
        }

        private void btnExportDoanhThuChiTiet_Click(object sender, EventArgs e)
        {
            if (mExportSaleType == EXPORT_SALE_SEARCH_ALL)
            {
                loadCarList();
                exportDoanhThuChiTietToExcel();
            }
            else if (mExportSaleType == EXPORT_SALE_SEARCH_CONDITION)
            {
                string userInID = null;
                string userOutID = null;
                int ticketType = CarDAO.ALL_TICKET;
                if (cbNhanVienVaoReport.SelectedIndex > 0)
                {
                    DataRow dataRow = ((DataRowView)cbNhanVienVaoReport.SelectedItem).Row;
                    userInID = Convert.ToString(dataRow["UserID"]);
                }

                if (cbNhanVienRaReport.SelectedIndex > 0)
                {
                    DataRow dataRow = ((DataRowView)cbNhanVienRaReport.SelectedItem).Row;
                    userOutID = Convert.ToString(dataRow["UserID"]);
                }

                DateTime startDateReport = DateTime.Now;
                DateTime endDateReport = DateTime.Now;
                if (rbOneDateSaleReport.Checked)
                {
                    DateTime timeReport = dtDateSaleReport.Value;
                    startDateReport = new DateTime(timeReport.Year, timeReport.Month, timeReport.Day, 0, 0, 0);
                    endDateReport = new DateTime(timeReport.Year, timeReport.Month, timeReport.Day, 23, 59, 59);

                }
                if (rbMultiDateSaleReport.Checked)
                {
                    startDateReport = dtStartDateSaleReport.Value;
                    DateTime startTimeReport = dtStartTimeSaleReport.Value;
                    startDateReport = new DateTime(startDateReport.Year, startDateReport.Month, startDateReport.Day, startTimeReport.Hour, startTimeReport.Minute, 0);
                    endDateReport = dtEndDateSaleReport.Value;
                    DateTime endTimeReport = dtEndTimeSaleReport.Value;
                    endDateReport = new DateTime(endDateReport.Year, endDateReport.Month, endDateReport.Day, endTimeReport.Hour, endTimeReport.Minute, 0);
                }

                if (rbAllTicketSaleReport.Checked)
                {
                    ticketType = CarDAO.ALL_TICKET;
                }
                else if (rbCommonTicketSaleReport.Checked)
                {
                    ticketType = CarDAO.COMMON_TICKET;
                }
                else if (rbMonthTicketSaleReport.Checked)
                {
                    ticketType = CarDAO.MONTH_TICKET;
                }
                searchCarByConditionThongKeDoanhThu(startDateReport, endDateReport, userInID, userOutID, ticketType);
                exportDoanhThuChiTietToExcel();
            }
            else
            {
                MessageBox.Show("Chưa có dữ liệu để xuất Excel");
            }
        }

        private void btnExportBangChamCong_Click(object sender, EventArgs e)
        {
            exportBangChamCongToExcel();
        }

        private void btnExportDanhSachTheXe_Click(object sender, EventArgs e)
        {
            exportDoanhSachTheXeToExcel();
        }

        private void btnExportNhatKyVeThang_Click(object sender, EventArgs e)
        {
            exportNhatKyVeThangToExcel();
        }

        private void btnExportDanhSachTheHetHan_Click(object sender, EventArgs e)
        {
            exportDanhSachTheHetHanToExcel();
        }

        private void btnExportNhatKyHeThong_Click(object sender, EventArgs e)
        {
            exportNhatKyHeThongToExcel();
        }

        private void btnExportDanhSachXe_Click(object sender, EventArgs e)
        {
            exportDanhSachXeToExcel();
        }

        private void btnExportDanhSachXeThang_Click(object sender, EventArgs e)
        {
            exportDanhSachXeThangToExcel();
        }

        void Delete_Card_Click(Object sender, System.EventArgs e, int currentRow)
        {
            checkForDeleteCard();
        }

        private void checkForDeleteCard()
        {
            if (!isChosenCard())
            {
                MessageBox.Show(Constant.sMessageNoChooseDataError);
                return;
            }
            showConfirmDeleteCard();
        }

        private void showConfirmDeleteCard()
        {
            DialogResult dialogResult = MessageBox.Show(Constant.sMessageConfirmDelete, Constant.sTitleDelete, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                deleteCard();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void deleteCard()
        {
            foreach (DataGridViewRow row in dgvCardList.Rows)
            {
                DataGridViewCheckBoxCell checkCell = row.Cells["SelectCard"] as DataGridViewCheckBoxCell;
                object value = checkCell.Value;
                if (value != null && (Boolean)value)
                {
                    string cardId = Convert.ToString(row.Cells["CardID"].Value);
                    string identify = CardDAO.getIdentifyByCardID(cardId);
                    if (CardDAO.Delete(cardId))
                    {
                        LogUtil.addLogXoaThe(identify, cardId);
                        TicketMonthDAO.Delete(cardId);
                        CarDAO.DeleteCarNotOut(cardId);
                    }
                }
                //if (Convert.ToBoolean(checkCell.Value) == true)
                //{
                //    string cardId = Convert.ToString(row.Cells["CardID"].Value);
                //    CardDAO.Delete(cardId);
                //}
            }
            searchCard();
            loadCardStatistic();
        }

        void Delete_Car_Click(Object sender, System.EventArgs e, int currentRow)
        {
            if (UserDAO.GetFunctionIDByUserID(Program.CurrentManagerUserID) != Constant.FUNCTION_ID_ADMIN)
            {
                MessageBox.Show("Chỉ có admin mới được quyền xóa!");
                return;
            }          

            if (!isChosenCar())
            {
                MessageBox.Show(Constant.sMessageNoChooseDataError);
                return;
            }
            showConfirmDeleteCar();
        }

        private void showConfirmDeleteCar()
        {
            DialogResult dialogResult = MessageBox.Show(Constant.sMessageConfirmDelete, Constant.sTitleDelete, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                deleteCar();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void deleteCar()
        {
            for (int i = dgvCarList.Rows.Count - 1; i >= 0 ; i--)
            {
                DataGridViewRow row = dgvCarList.Rows[i];
                DataGridViewCheckBoxCell checkCell = row.Cells["SelectCar"] as DataGridViewCheckBoxCell;
                object value = checkCell.Value;
                if (value != null && (Boolean)value)
                {
                    int identify = Convert.ToInt32(row.Cells["CarLogIdentify"].Value);
                    if (CarDAO.isCarOutByIdentify(identify))
                    {
                        //MessageBox.Show("Không thể xóa xe đã ra khỏi bãi!");
                        //return;
                    }
                    if (CarDAO.DeleteCar(identify +""))
                    {
                        dgvCarList.Rows.RemoveAt(i);
                    }
                }
            }
            //loadCarList();
        }

        private void showConfirmDeleteAllCard()
        {
            DialogResult dialogResult = MessageBox.Show(Constant.sMessageConfirmDelete, Constant.sTitleDelete, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                deleteAllCard();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void deleteAllCard()
        {
            foreach (DataGridViewRow row in dgvCardList.Rows)
            {
                DataGridViewCheckBoxCell checkCell = row.Cells["SelectCard"] as DataGridViewCheckBoxCell;
                string cardId = Convert.ToString(row.Cells["CardID"].Value);
                string identify = CardDAO.getIdentifyByCardID(cardId);
                if (CardDAO.Delete(cardId))
                {
                    LogUtil.addLogXoaThe(identify, cardId);
                    TicketMonthDAO.Delete(cardId);
                    CarDAO.DeleteCarNotOut(cardId);
                }
            }
            loadCardList();
            loadCardStatistic();
        }

        private void dgvPartList_MouseClick(object sender, MouseEventArgs ev)
        {
            if (ev.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                MenuItem menuItem = new MenuItem(Constant.sButtonDelete);
                int currentRow = dgvPartList.HitTest(ev.X, ev.Y).RowIndex;
                menuItem.Click += new EventHandler((s, e) => Delete_Part_Click(s, e, currentRow));
                m.MenuItems.Add(menuItem);

                m.Show(dgvPartList, new Point(ev.X, ev.Y));
            }
        }

        void Delete_Part_Click(Object sender, System.EventArgs e, int currentRow)
        {
            showConfirmDeletePart(currentRow);
        }

        private void showConfirmDeletePart(int currentRow)
        {
            DialogResult dialogResult = MessageBox.Show(Constant.sMessageConfirmDelete, Constant.sTitleDelete, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                deletePart(currentRow);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void deletePart(int currentRow)
        {
            string partID = Convert.ToString(dgvPartList.Rows[currentRow].Cells["PartID"].Value);
            string partName = PartDAO.GetPartNameByPartID(partID);
            if (CardDAO.GetCardCountByPartId(partID) == 0)
            {
                PartDAO.Delete(partID);
                loadPartList();
                LogUtil.addLogXoaLoaiXe(partID, partName);
            } else
            {
                MessageBox.Show("Không thể xóa vì loại xe này đang được sử dụng cho thông tin thẻ!");
            }
        }

        private void btnExportDanhSachVeThang_Click(object sender, EventArgs e)
        {
            exportDanhSachTheThangToExcel();
        }

        private void addDataToRFIDComboBox()
        {

        }

        private void tbCardIDCreate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !tbCardIDCreate.Text.Equals(null))
            {
                checkAndCreateCard();
            }
        }

        private void checkAndCreateCard()
        {
            if (checkCreateCardData())
            {
                createCard();
                loadCardStatistic();
                tbCardIDCreate.Text = "";
            }
        }

        private void treeViewPhanQuyenTruyCap_AfterSelect(object sender, TreeViewEventArgs e)
        {
            checkTreeViewNode(e.Node, e.Node.Checked);
        }

        private void btnLuuCauHinhKetNoi_Click(object sender, EventArgs e)
        {
            luuCauHinhKetNoiVaoConfig();
        }

        private void luuCauHinhKetNoiVaoConfig()
        {
            try
            {
                String filePath = Application.StartupPath + "\\" + Constant.sFileNameConfig;
                if (File.Exists(filePath))
                {
                    Config config = mConfig;
                    config.cameraUrl1 = tb_camera_url_1.Text;
                    config.cameraUrl2 = tb_camera_url_2.Text;
                    config.cameraUrl3 = tb_camera_url_3.Text;
                    config.cameraUrl4 = tb_camera_url_4.Text;
                    config.rfidIn = Constant.sEncodeStart + tb_rfid_1.Text + Constant.sEncodeEnd;
                    config.rfidOut = Constant.sEncodeStart + tb_rfid_2.Text + Constant.sEncodeEnd;
                    config.computerName = Constant.sEncodeStart + tb_ip_host.Text + Constant.sEncodeEnd;
                    config.folderRoot = Constant.sEncodeStart + tb_folder_root.Text + Constant.sEncodeEnd;
                    config.comReceiveIn = Constant.sEncodeStart + tb_com_receive_in.Text + Constant.sEncodeEnd;
                    config.comReceiveOut = Constant.sEncodeStart + tb_com_receive_out.Text + Constant.sEncodeEnd;
                    config.comReaderLeft = Constant.sEncodeStart + tb_com_reader_left.Text + Constant.sEncodeEnd;
                    config.comReaderRight = Constant.sEncodeStart + tb_com_reader_right.Text + Constant.sEncodeEnd;
                    config.comSend = Constant.sEncodeStart + tb_com_send.Text + Constant.sEncodeEnd;
                    config.signalOpenBarieIn = Constant.sEncodeStart + tb_signal_open_barie_in.Text + Constant.sEncodeEnd;
                    config.signalCloseBarieIn = Constant.sEncodeStart + tb_signal_close_barie_in.Text + Constant.sEncodeEnd;
                    config.signalOpenBarieOut = Constant.sEncodeStart + tb_signal_open_barie_out.Text + Constant.sEncodeEnd;
                    config.signalCloseBarieOut = Constant.sEncodeStart + tb_signal_close_barie_out.Text + Constant.sEncodeEnd;
                    config.signalOpenBarieInMotorbike = Constant.sEncodeStart + tb_signal_open_barie_in_motobike.Text + Constant.sEncodeEnd;
                    config.signalCloseBarieInMotorbike = Constant.sEncodeStart + tb_signal_close_barie_in_motobike.Text + Constant.sEncodeEnd;
                    config.signalOpenBarieOutMotorbike = Constant.sEncodeStart + tb_signal_open_barie_out_motobike.Text + Constant.sEncodeEnd;
                    config.signalCloseBarieOutMotorbike = Constant.sEncodeStart + tb_signal_close_barie_out_motobike.Text + Constant.sEncodeEnd;
                    XmlSerializer xs = new XmlSerializer(typeof(Config));
                    TextWriter txtWriter = new StreamWriter(filePath);
                    xs.Serialize(txtWriter, config);
                    txtWriter.Close();

                    if (Constant.IS_NEW_CAMERA)
                    {
                        Configuration configuration = new Configuration(Path.GetDirectoryName(Application.ExecutablePath));
                        configuration.SaveUrlCamera("cam1", config.cameraUrl1);
                        configuration.SaveUrlCamera("cam2", config.cameraUrl2);
                        configuration.SaveUrlCamera("cam3", config.cameraUrl3);
                        configuration.SaveUrlCamera("cam4", config.cameraUrl4);
                    }

                    this.ActiveControl = null;
                    MessageBox.Show(Constant.sMessageUpdateSuccess);
                }
            }
            catch (Exception e)
            {

            }


            //ConfigDTO configDTO = new ConfigDTO();
            //configDTO.Camera1 = tb_camera_url_1.Text;
            //configDTO.Camera2 = tb_camera_url_2.Text;
            //configDTO.Camera3 = tb_camera_url_3.Text;
            //configDTO.Camera4 = tb_camera_url_4.Text;
            //configDTO.Rfid1 = tb_rfid_1.Text;
            //configDTO.Rfid2 = tb_rfid_2.Text;
            //ConfigDAO.UpdateCauHinhKetNoi(configDTO);
            //this.ActiveControl = null;
            //MessageBox.Show(Constant.sMessageUpdateSuccess);
        }

        private void hienCauHinhKetNoiTuConfig()
        {
            try
            {             
                Config config = mConfig;

                if (!Constant.IS_NEW_CAMERA)
                {
                    tb_camera_url_1.Text = config.cameraUrl1;
                    tb_camera_url_2.Text = config.cameraUrl2;
                    tb_camera_url_3.Text = config.cameraUrl3;
                    tb_camera_url_4.Text = config.cameraUrl4;
                } else
                {
                    Configuration configuration = new Configuration(Path.GetDirectoryName(Application.ExecutablePath));
                    tb_camera_url_1.Text = configuration.GetUrlCamera("cam1");
                    tb_camera_url_2.Text = configuration.GetUrlCamera("cam2");
                    tb_camera_url_3.Text = configuration.GetUrlCamera("cam3");
                    tb_camera_url_4.Text = configuration.GetUrlCamera("cam4");
                }

                tb_rfid_1.Text = config.rfidIn;
                tb_rfid_2.Text = config.rfidOut;
                tb_com_receive_in.Text = config.comReceiveIn;
                tb_com_receive_out.Text = config.comReceiveOut;
                tb_com_reader_left.Text = config.comReaderLeft;
                tb_com_reader_right.Text = config.comReaderRight;
                tb_com_send.Text = config.comSend;
                tb_signal_open_barie_in.Text = config.signalOpenBarieIn;
                tb_signal_close_barie_in.Text = config.signalCloseBarieIn;
                tb_signal_open_barie_out.Text = config.signalOpenBarieOut;
                tb_signal_close_barie_out.Text = config.signalCloseBarieOut;
                tb_signal_open_barie_in_motobike.Text = config.signalOpenBarieInMotorbike;
                tb_signal_close_barie_in_motobike.Text = config.signalCloseBarieInMotorbike;
                tb_signal_open_barie_out_motobike.Text = config.signalOpenBarieOutMotorbike;
                tb_signal_close_barie_out_motobike.Text = config.signalCloseBarieOutMotorbike;
                tb_ip_host.Text = config.computerName;
                tb_folder_root.Text = config.folderRoot;
            }
            catch (Exception e)
            {

            }

            //tb_camera_url_1.Text = ConfigDAO.GetCamera1();
            //tb_camera_url_2.Text = ConfigDAO.GetCamera2();
            //tb_camera_url_3.Text = ConfigDAO.GetCamera3();
            //tb_camera_url_4.Text = ConfigDAO.GetCamera4();
            //tb_rfid_1.Text = ConfigDAO.GetRFID1();
            //tb_rfid_2.Text = ConfigDAO.GetRFID2();
            //tb_ip_host.Text = Util.getConfigFile().ipHost;
            //tb_folder_root.Text = Util.getConfigFile().folderRoot;

        }

        private void OnKeyPressed(object sender, RawInputEventArg e)
        {
            if (tb_rfid_1.Focused)
            {
                tb_rfid_1.Text = e.KeyPressEvent.DeviceName;
                this.ActiveControl = null;
            }
            if (tb_rfid_2.Focused)
            {
                tb_rfid_2.Text = e.KeyPressEvent.DeviceName;
                this.ActiveControl = null;
            }
        }

        private void FormQuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _rawinput.KeyPressed -= OnKeyPressed;
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
            } catch (Exception)
            {

            }
        }

        private void btnKichHoatThe_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvActiveCardList.Rows)
            {
                DataGridViewCheckBoxCell checkCell = row.Cells["SelectLostCard"] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(checkCell.Value))
                {
                    string cardId = Convert.ToString(row.Cells["ColumnLostCardID"].Value);
                    CardDAO.UpdateIsUsing("1", cardId);
                }
            }
            searchLostCard();
        }

        private void btnTimTheBiMat_Click(object sender, EventArgs e)
        {
            searchLostCard();
        }

        private void btnActiveTicketMonthSearch_Click(object sender, EventArgs e)
        {
            searchActiveTicketMonth();
        }

        private void btnActiveTicketMonth_Click(object sender, EventArgs e)
        {
            if (!isChosenActiveTicketMonthData())
            {
                MessageBox.Show(Constant.sMessageNoChooseDataError);
                return;
            }
            foreach (DataGridViewRow row in dgvActiveTicketMonthList.Rows)
            {
                DataGridViewCheckBoxCell checkCell = row.Cells["SelectActiveTicketMonth"] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(checkCell.Value))
                {
                    string cardId = Convert.ToString(row.Cells["ColumnActiveTicketCardID"].Value);
                    CardDAO.UpdateIsUsing("1", cardId);
                    CarDAO.DeleteLostCard(cardId);
                }
            }
            searchActiveTicketMonth();
        }

        private bool isChosenActiveTicketMonthData()
        {
            foreach (DataGridViewRow row in dgvActiveTicketMonthList.Rows)
            {
                bool isChoose = Convert.ToBoolean(row.Cells["SelectActiveTicketMonth"].Value);
                if (isChoose)
                {
                    return true;
                }
            }
            return false;
        }

        private bool isChosenBlockTicketMonthData()
        {
            foreach (DataGridViewRow row in dgvBlockTicketMonthList.Rows)
            {
                bool isChoose = Convert.ToBoolean(row.Cells["SelectBlockTicketMonth"].Value);
                if (isChoose)
                {
                    return true;
                }
            }
            return false;
        }

        private bool isChosenCard()
        {
            foreach (DataGridViewRow row in dgvCardList.Rows)
            {
                bool isChoose = Convert.ToBoolean(row.Cells["SelectCard"].Value);
                if (isChoose)
                {
                    return true;
                }
            }
            return false;
        }

        private bool isChosenCar()
        {
            foreach (DataGridViewRow row in dgvCarList.Rows)
            {
                bool isChoose = Convert.ToBoolean(row.Cells["SelectCar"].Value);
                if (isChoose)
                {
                    return true;
                }
            }
            return false;
        }

        private bool isChosenTicketMonth()
        {
            foreach (DataGridViewRow row in dgvTicketMonthList.Rows)
            {
                bool isChoose = Convert.ToBoolean(row.Cells["SelectTicketMonth"].Value);
                if (isChoose)
                {
                    return true;
                }
            }
            return false;
        }

        private void dgvCardList_MouseClick(object sender, MouseEventArgs ev)
        {
            if (ev.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                MenuItem menuItem = new MenuItem(Constant.sButtonDelete);
                int currentRow = dgvCardList.HitTest(ev.X, ev.Y).RowIndex;
                menuItem.Click += new EventHandler((s, e) => Delete_Card_Click(s, e, currentRow));
                m.MenuItems.Add(menuItem);

                m.Show(dgvCardList, new Point(ev.X, ev.Y));
            }
        }

        private void dgvRenewTicketMonthList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dataGridView = (DataGridView)sender;
            var cell = dataGridView["RenewIsChosen", e.RowIndex];
            if (cell.Value == null)
            {
                cell.Value = false;
            }
            cell.Value = !(bool)cell.Value;
        }

        private void dgvActiveTicketMonthList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dataGridView = (DataGridView)sender;
            var cell = dataGridView["SelectActiveTicketMonth", e.RowIndex];
            if (cell.Value == null)
            {
                cell.Value = false;
            }
            cell.Value = !(bool)cell.Value;
        }

        private void dgvActiveCardList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dataGridView = (DataGridView)sender;
            var cell = dataGridView["SelectLostCard", e.RowIndex];
            if (cell.Value == null)
            {
                cell.Value = false;
            }
            cell.Value = !(bool)cell.Value;
        }

        private void dgvCardList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Util.setRowNumber(dgvCardList, "STT");
        }

        private void dgvTicketMonthList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Util.setRowNumber(dgvTicketMonthList, "STT_TicketMonth");
        }

        private void dgvTicketLogList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Util.setRowNumber(dgvTicketLogList, "TicketLogIdentify");
        }

        private void dgvRenewTicketMonthList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Util.setRowNumber(dgvRenewTicketMonthList, "STT_RenewTicketMonthList");
        }

        private void dgvLostTicketMonthList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Util.setRowNumber(dgvLostTicketMonthList, "STT_LostTicketMonthList");
        }

        private void dgvActiveTicketMonthList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Util.setRowNumber(dgvActiveTicketMonthList, "STT_ActiveTicketMonthList");
        }

        private void dgvCarTicketMonthList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Util.setRowNumber(dgvCarTicketMonthList, "STT_CarTicketMonthList");
        }

        private void dgvWorkList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Util.setRowNumber(dgvWorkList, "STT_WorkList");
        }

        private void dgvCarList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Util.setRowNumber(dgvCarList, "STT_CarList");
        }

        private void dgvLogList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Util.setRowNumber(dgvLogList, "STT_Log");
        }

        private void tbTicketMonthIDCreate_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ticketMonthCardIdLeaveEvent();
                    break;
            }
        }

        private void tbTicketMonthIDCreate_Leave(object sender, EventArgs e)
        {
            ticketMonthCardIdLeaveEvent();
        }

        private void ticketMonthCardIdLeaveEvent()
        {
            string cardId = tbTicketMonthIDCreate.Text;
            if (!cardId.Equals(""))
            {
                CardDTO cardDTO = CardDAO.GetCardModelByID(cardId);
                if (cardDTO == null)
                {
                    MessageBox.Show(Constant.sMessageCardIdNotExist);
                    tbTicketMonthIDCreate.Text = "";
                }
                else
                {
                    string cardTypeID = PartDAO.GetCardTypeByID(cardDTO.Type);
                    if (cardTypeID.Equals(CardTypeDTO.CARD_TYPE_TICKET_COMMON))
                    {
                        MessageBox.Show(Constant.sMessageCardTypeIsNotTicketMonth);
                        tbTicketMonthIDCreate.Text = "";
                    }
                    else
                    {
                        tbTicketMonthIdentifyCreate.Text = cardDTO.Identify + "";
                        string typeName = PartDAO.GetPartNameByPartID(cardDTO.Type);
                        cbTicketMonthPartCreate.Text = typeName;
                        tbTicketMonthChargesAmountCreate.Text = PartDAO.GetAmountByPartID(cardDTO.Type) + "";
                    }
                }
            }
        }

        private void ticketMonthCardIdentifyLeaveEvent()
        {
            if (!tbTicketMonthIdentifyCreate.Text.Equals(""))
            {
                string cardIdentify = tbTicketMonthIdentifyCreate.Text;
                CardDTO cardDTO = CardDAO.GetCardModelByIdentify(cardIdentify);
                if (cardDTO != null)
                {
                    string cardTypeID = PartDAO.GetCardTypeByID(cardDTO.Type);
                    if (cardTypeID.Equals(CardTypeDTO.CARD_TYPE_TICKET_COMMON))
                    {
                        MessageBox.Show(Constant.sMessageCardTypeIsNotTicketMonth);
                        tbTicketMonthIdentifyCreate.Text = "";
                    }
                    else
                    {
                        DataTable dt = TicketMonthDAO.GetDataByIdentify(cardIdentify);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            MessageBox.Show(Constant.sMessageCardIdentifyExisted);
                            tbTicketMonthIdentifyCreate.Text = "";
                        }
                        else
                        {
                            tbTicketMonthIDCreate.Text = cardDTO.Id;
                            string typeName = PartDAO.GetPartNameByPartID(cardDTO.Type);
                            cbTicketMonthPartCreate.Text = typeName;
                            tbTicketMonthChargesAmountCreate.Text = PartDAO.GetAmountByPartID(cardDTO.Type) + "";
                        }
                    }
                }
            }
        }

        private void tbTicketMonthIdentifyCreate_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ticketMonthCardIdentifyLeaveEvent();
                    break;
            }
        }

        private void tbTicketMonthIdentifyCreate_Leave(object sender, EventArgs e)
        {
            ticketMonthCardIdentifyLeaveEvent();
        }

        private void btnExportDanhSachTheXe2_Click(object sender, EventArgs e)
        {
            exportDoanhSachTheXeToExcel();
        }

        private void btnSearchCash_Click(object sender, EventArgs e)
        {
            loadCarListForCashManagement();
        }

        public DataTable ImportDanhSachTheFromExcel(String path)
        {
            System.Data.DataTable dt = null;
            int rowIndex = 1;
            dt = new System.Data.DataTable();
            DataRow row;
            XLWorkbook workBook = new XLWorkbook(path);
            IXLWorksheet workSheet = workBook.Worksheet(1);
            
            
            int temp = 1;
            while (workSheet.Cell(rowIndex, temp).Value.ToString() != "")
            {
                dt.Columns.Add(Convert.ToString(workSheet.Cell(rowIndex, temp).Value));
                temp++;
            }
            rowIndex = Convert.ToInt32(rowIndex) + 2;
            int columnCount = temp;
            try
            {
                temp = 1;
                while (workSheet.Cell(rowIndex, temp).Value.ToString() != "")
                {
                    row = dt.NewRow();
                    for (int i = 1; i < columnCount; i++)
                    {
                        row[i - 1] = Convert.ToString(workSheet.Cell(rowIndex, i).Value);
                    }

                    CardDTO cardDTO = CardDAO.getCardFromDataRow(row);
                    IXLRow range = workSheet.Row(rowIndex);

                    if (CardDAO.GetCardModelByIdentify(cardDTO.Identify) != null)
                    {
                        range.Style.Fill.SetBackgroundColor(XLColor.Red);
                        workSheet.Cell(rowIndex, columnCount).Value = Constant.sMessageCardIdentifyExisted;
                    }
                    else if (!CardDAO.Insert(cardDTO))
                    {
                        range.Style.Fill.SetBackgroundColor(XLColor.Red);
                        workSheet.Cell(rowIndex, columnCount).Value = Constant.sMessageCardIdExisted;
                    }
                    else
                    {
                        range.Style.Fill.SetBackgroundColor(XLColor.Green);
                        workSheet.Cell(rowIndex, columnCount).Value = "OK";
                    }
                    dt.Rows.Add(row);
                    rowIndex = Convert.ToInt32(rowIndex) + 1;
                    temp = 1;
                }             
            } catch (Exception ex)
            {
                workSheet.Cell(rowIndex, columnCount).Value = ex.Message;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = Environment.CurrentDirectory;
            saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveDialog.FilterIndex = 2;
            saveDialog.FileName = "Ketqua_" + Path.GetFileName(path);

            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                workBook.SaveAs(saveDialog.FileName);
                MessageBox.Show(Constant.sMessageImportExcelSuccess);
                loadCardList();
                Process.Start(saveDialog.FileName);
            }
            return dt;
        }

        private void ImportDanhSachTheThangFromExcel(String path)
        {
            System.Data.DataTable dt = null;
            int rowIndex = 1;
            dt = new System.Data.DataTable();
            DataRow row;
            XLWorkbook workBook = new XLWorkbook(path);
            IXLWorksheet workSheet = workBook.Worksheet(1);
            int temp = 1;
            while (workSheet.Cell(rowIndex, temp).Value.ToString() != "")
            {
                dt.Columns.Add(Convert.ToString(workSheet.Cell(rowIndex, temp).Value));
                temp++;
            }
            rowIndex = Convert.ToInt32(rowIndex) + 2;
            int columnCount = temp;
            temp = 1;
            while (workSheet.Cell(rowIndex, temp).Value.ToString() != "")
            {
                try
                {
                    row = dt.NewRow();
                    for (int i = 1; i < columnCount; i++)
                    {
                        if (workSheet.Cell(rowIndex, i).Value.ToString() != "")
                        {
                            row[i - 1] = Convert.ToString(workSheet.Cell(rowIndex, i).Value);
                        }
                        else
                        {
                            row[i - 1] = "";
                        }
                    }

                    TicketMonthDTO ticketMonthDTO = TicketMonthDAO.getTicketMonthFromDataRow(row);
                    ticketMonthDTO.ProcessDate = DateTime.Now;
                    ticketMonthDTO.Account = Program.CurrentManagerUserID;
                    ticketMonthDTO.Status = 0;
                    ticketMonthDTO.DayUnlimit = DateTime.Now;
                    CardDTO cardDTO = CardDAO.GetCardModelByID(ticketMonthDTO.Id);
                    if (cardDTO != null)
                    {
                        ticketMonthDTO.IdPart = cardDTO.Type;
                    }

                    IXLRow range = workSheet.Row(rowIndex);

                    string errorMessage = getErrorMessageImportTheThang(ticketMonthDTO, cardDTO);
                    //string errorMessage = null;
                    if (errorMessage != null)
                    {
                        workSheet.Cell(rowIndex, columnCount).Value = errorMessage;
                        range.Style.Fill.SetBackgroundColor(XLColor.Red);
                    }
                    else
                    {
                        if (!cardDTO.Identify.Equals(ticketMonthDTO.CardIdentify))
                        {
                            CardDAO.UpdateIdentify(ticketMonthDTO.CardIdentify, ticketMonthDTO.Id);
                        }
                        if (TicketMonthDAO.Insert(ticketMonthDTO))
                        {
                            addTicketLog(Constant.LOG_TYPE_CREATE_TICKET_MONTH, ticketMonthDTO);
                            range.Style.Fill.SetBackgroundColor(XLColor.Green);
                            workSheet.Cell(rowIndex, columnCount).Value = "OK";
                        }
                        else
                        {
                            workSheet.Cell(rowIndex, columnCount).Value = Constant.sMessageCardIdExisted;
                            range.Style.Fill.SetBackgroundColor(XLColor.Red);
                        }
                    }
                    dt.Rows.Add(row);
                    rowIndex = Convert.ToInt32(rowIndex) + 1;
                    temp = 1;
                }
                catch (Exception ex)
                {
                    workSheet.Cell(rowIndex, columnCount).Value = ex.Message;
                }
            }
       
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = Environment.CurrentDirectory;
            saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveDialog.FilterIndex = 2;
            saveDialog.FileName = "Ketqua_" + Path.GetFileName(path);

            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                workBook.SaveAs(saveDialog.FileName);
                MessageBox.Show(Constant.sMessageImportExcelSuccess);
                loadTicketMonthData();
                Process.Start(saveDialog.FileName);
            }
        }

        private void UpdateDanhSachTheThangFromExcel(String path)
        {
            System.Data.DataTable dt = null;
            object rowIndex = 1;
            dt = new System.Data.DataTable();
            DataRow row;
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(path, 0, true, 5, "", "", true,
                Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.ActiveSheet;
            int temp = 1;
            while (((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, temp]).Value2 != null)
            {
                String columnName = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, temp]).Value2);
                dt.Columns.Add(columnName);
                temp++;
            }
            rowIndex = Convert.ToInt32(rowIndex) + 2;
            int columnCount = temp;
            temp = 1;

            while (((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, temp]).Value2 != null)
            {
                try
                {
                    row = dt.NewRow();
                    for (int i = 1; i < columnCount; i++)
                    {
                        if (((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, i]).Value2 != null)
                        {
                            row[i - 1] = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[rowIndex, i]).Value2);
                        }
                        else
                        {
                            row[i - 1] = "";
                        }
                    }

                    string digit = row.Field<String>("Digit");
                    string phone = row.Field<String>("Phone");

                    TicketMonthDAO.Update(digit, phone);

                    dt.Rows.Add(row);
                }
                catch (Exception ex)
                {
                    workSheet.Cells[rowIndex, columnCount + 1] = ex.Message;
                }
                rowIndex = Convert.ToInt32(rowIndex) + 1;
                temp = 1;
            }

            MessageBox.Show(Constant.sMessageImportExcelSuccess);

            workBook.Close();
            app.Quit();
        }

        private string getErrorMessageImportTheThang(TicketMonthDTO ticketMonthDTO, CardDTO cardDTO)
        {
            if (string.IsNullOrWhiteSpace(ticketMonthDTO.CardIdentify))
            {
                return Constant.sMessageTicketMonthIdentifyNullError;
            }
            if (string.IsNullOrWhiteSpace(ticketMonthDTO.Id))
            {
                return Constant.sMessageTicketMonthIdNullError;
            }
            if (string.IsNullOrWhiteSpace(ticketMonthDTO.Digit))
            {
                return Constant.sMessageTicketMonthDigitNullError;
            }
            DataTable dtByDigit = TicketMonthDAO.GetDataByDigit(ticketMonthDTO.Digit);
            if (dtByDigit != null && dtByDigit.Rows.Count > 0)
            {
                return Constant.sMessageDigitExisted;
            }
            if (cardDTO == null)
            {
                return Constant.sMessageCardIdNotExist;
            }
            else
            {
                if (!CardDAO.isUsingByCardID(cardDTO.Id))
                {
                    return Constant.sMessageCardIsLost;
                }
                string cardTypeID = PartDAO.GetCardTypeByID(cardDTO.Type);
                if (cardTypeID.Equals(CardTypeDTO.CARD_TYPE_TICKET_COMMON))
                {
                    return Constant.sMessageCardTypeIsNotTicketMonth;
                }
                else
                {
                    DataTable dt = TicketMonthDAO.GetDataByIdentify(ticketMonthDTO.CardIdentify);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        return Constant.sMessageCardIdentifyExisted;
                    }
                }
            }
            return null;
        }

        private void trackBarTinhTienTongHopCycleMilestone3_ValueChanged(object sender, EventArgs e)
        {
            labelTinhTienTongHopCycleMilestone3.Text = trackBarTinhTienTongHopCycleMilestone3.Value + "";
        }

        private void btnImportDanhSachTheXe_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                ImportDanhSachTheFromExcel(path);
            }
        }

        private void btnImportDanhSachVeThang_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                ImportDanhSachTheThangFromExcel(path);
                //UpdateDanhSachTheThangFromExcel(path);
            }
        }

        private void btnDeleteAllCard_Click(object sender, EventArgs e)
        {
            showConfirmDeleteAllCard();
        }

        private void tbLostTicketMonthID_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    lostTicketMonthCardIdLeaveEvent();
                    break;
            }
        }

        private void lostTicketMonthCardIdLeaveEvent()
        {
            string cardId = tbLostTicketMonthID.Text;
            if (!cardId.Equals(""))
            {
                CardDTO cardDTO = CardDAO.GetCardModelByID(cardId);
                if (cardDTO == null)
                {
                    MessageBox.Show(Constant.sMessageCardIdNotExist);
                    tbLostTicketMonthID.Text = "";
                }
                else
                {
                    string cardTypeID = PartDAO.GetCardTypeByID(cardDTO.Type);
                    if (cardTypeID.Equals(CardTypeDTO.CARD_TYPE_TICKET_COMMON))
                    {
                        MessageBox.Show(Constant.sMessageCardTypeIsNotTicketMonth);
                        tbLostTicketMonthID.Text = "";
                    }
                    else
                    {
                        tbLostTicketMonthCardIdentify.Text = cardDTO.Identify + "";
                    }
                }
            }
        }

        private void dgvTicketMonthList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvTicketMonthList.IsCurrentCellDirty)
            {
                dgvTicketMonthList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvRenewTicketMonthList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvRenewTicketMonthList.IsCurrentCellDirty)
            {
                dgvRenewTicketMonthList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvActiveTicketMonthList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvActiveTicketMonthList.IsCurrentCellDirty)
            {
                dgvActiveTicketMonthList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvCardList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCardList.IsCurrentCellDirty)
            {
                dgvCardList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
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

        private void getDataFromUhfReader()
        {
            if (Program.portComLeftUhf != null && Program.portComLeftUhf.IsOpen)
            {
                Program.portComLeftUhf.DataReceived += portComReceiveIn_DataReceived;
            }

            if (Program.portComRightUhf != null && Program.portComRightUhf.IsOpen)
            {
                Program.portComRightUhf.DataReceived += portComReceiveOut_DataReceived;
            }
        }

        private void portComReceiveIn_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {
                if (Program.newUhfCardId.Length == 53)
                {
                    handleReceiveUhfData(Program.newUhfCardId);
                }              
            }));
        }

        private void portComReceiveOut_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {
                if (Program.newUhfCardId.Length == 53)
                {
                    handleReceiveUhfData(Program.newUhfCardId);
                }
            }));
        }

        private TextBox focusedTextbox = null;
        public void handleReceiveUhfData(string uhfCardId)
        {
            Invoke(new MethodInvoker(() =>
            {
                if (uhfCardId != null && !uhfCardId.Equals(""))
                {
                    if (tbCardSearch.Focused)
                    {
                        focusedTextbox = tbCardSearch;
                    }
                    if (tbCardIDCreate.Focused)
                    {
                        focusedTextbox = tbCardIDCreate;
                    }
                    if (tbTicketMonthIDCreate.Focused)
                    {
                        focusedTextbox = tbTicketMonthIDCreate;
                    }
                    if (tbTicketMonthKeyWordSearch.Focused)
                    {
                        focusedTextbox = tbTicketMonthKeyWordSearch;
                    }
                    if (tbRenewTicketMonthKeyWordSearch.Focused)
                    {
                        focusedTextbox = tbRenewTicketMonthKeyWordSearch;
                    }
                    if (tbLostTicketMonthKeyWordSearch.Focused)
                    {
                        focusedTextbox = tbLostTicketMonthKeyWordSearch;
                    }
                    if (tbLostTicketMonthID.Focused)
                    {
                        focusedTextbox = tbLostTicketMonthID;
                    }
                    if (tbActiveTicketMonthKeyWordSearch.Focused)
                    {
                        focusedTextbox = tbActiveTicketMonthKeyWordSearch;
                    }
                    if (tbCarIDSearch.Focused)
                    {
                        focusedTextbox = tbCarIDSearch;
                    }
                    if (tbLostCardSearch.Focused)
                    {
                        focusedTextbox = tbLostCardSearch;
                    }
                    if (tbTicketLogKeyWordSearch.Focused)
                    {
                        focusedTextbox = tbTicketLogKeyWordSearch;
                    }
                    if (focusedTextbox != null)
                    {
                        focusedTextbox.Text = uhfCardId;
                        if (focusedTextbox == tbCardIDCreate)
                        {
                            if (!tbCardIDCreate.Text.Equals(null))
                            {
                                checkAndCreateCard();
                            }
                        }
                    }
                }
            }));
            
        }

        private void timerReadUHFData_Tick(object sender, EventArgs e)
        {
            try
            {
                int frmcomportindexIn = mUHFReader.getComportIndex(mConfig.comReceiveIn);
                int frmcomportindexOut = mUHFReader.getComportIndex(mConfig.comReceiveOut);
                string uhfInCardId = mUHFReader.GetUHFData(frmcomportindexIn);
                string uhfOutCardId = mUHFReader.GetUHFData(frmcomportindexOut);
                //string uhfInCardId = null;

                //byte[] ScanModeData = new byte[40960];
                //int ValidDatalength, i;
                //string temp, temps;
                //ValidDatalength = 0;
                //int frmcomportindex = UHFReader.getComportIndex(Util.getConfigFile().comReceiveIn);
                //int fCmdRet = StaticClassReaderB.ReadActiveModeData(ScanModeData, ref ValidDatalength, frmcomportindex);
                //if (fCmdRet == 0)
                //{
                //    temp = "";
                //    temps = UHFReader.ByteArrayToHexString(ScanModeData);
                //    for (i = 0; i < ValidDatalength; i++)
                //    {
                //        temp = temp + temps.Substring(i * 2, 2) + " ";
                //    }
                //    if (ValidDatalength > 0)
                //    {
                //        uhfInCardId = temp.Trim();
                //    }
                //}

                string uhfCardId = uhfInCardId;
                if (uhfCardId == null)
                {
                    uhfCardId = uhfOutCardId;
                }

                if (uhfCardId != null)
                {
                    TextBox focusedTextbox = null;
                    if (tbCardSearch.Focused)
                    {
                        focusedTextbox = tbCardSearch;
                    }
                    if (tbCardIDCreate.Focused)
                    {
                        focusedTextbox = tbCardIDCreate;
                    }
                    if (tbTicketMonthIDCreate.Focused)
                    {
                        focusedTextbox = tbTicketMonthIDCreate;
                    }
                    if (tbTicketMonthKeyWordSearch.Focused)
                    {
                        focusedTextbox = tbTicketMonthKeyWordSearch;
                    }
                    if (tbRenewTicketMonthKeyWordSearch.Focused)
                    {
                        focusedTextbox = tbRenewTicketMonthKeyWordSearch;
                    }
                    if (tbLostTicketMonthKeyWordSearch.Focused)
                    {
                        focusedTextbox = tbLostTicketMonthKeyWordSearch;
                    }
                    if (tbLostTicketMonthID.Focused)
                    {
                        focusedTextbox = tbLostTicketMonthID;
                    }
                    if (tbActiveTicketMonthKeyWordSearch.Focused)
                    {
                        focusedTextbox = tbActiveTicketMonthKeyWordSearch;
                    }
                    if (tbCarIDSearch.Focused)
                    {
                        focusedTextbox = tbCarIDSearch;
                    }
                    if (tbLostCardSearch.Focused)
                    {
                        focusedTextbox = tbLostCardSearch;
                    }
                    if (tbTicketLogKeyWordSearch.Focused)
                    {
                        focusedTextbox = tbTicketLogKeyWordSearch;
                    }
                    if (focusedTextbox != null)
                    {
                        focusedTextbox.Text = uhfCardId;
                        if (focusedTextbox == tbCardIDCreate)
                        {
                            if (!tbCardIDCreate.Text.Equals(null))
                            {
                                checkAndCreateCard();
                            }
                        }
                    }
                }
            } catch(Exception)
            {

            }            
        }

        private void initUhfTimer()
        {
            timerReadUHFData = new System.Windows.Forms.Timer();
            timerReadUHFData.Enabled = true;
            timerReadUHFData.Tick += new System.EventHandler(this.timerReadUHFData_Tick);
        }

        private void btnChinhSuaTinhTienTongHop2_Click(object sender, EventArgs e)
        {
            panelTinhTienTongHop2.Enabled = true;
        }

        private void btnHuyTinhTienTongHop2_Click(object sender, EventArgs e)
        {
            loadDataTinhTienTongHopTheoNgayDem();
            panelTinhTienTongHop2.Enabled = false;
        }

        private void btnCapNhatTinhTienTongHop2_Click(object sender, EventArgs e)
        {
            updateTinhTienTongHopTheoNgayDem();
        }

        private void cbLoaiXeTinhTienTongHop2_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDataTinhTienTongHopTheoNgayDem();
        }

        private void trackBarTinhTienTongHop2CycleMilestone_ValueChanged(object sender, EventArgs e)
        {
            labelTinhTienTongHop2CycleMilestone.Text = trackBarTinhTienTongHop2CycleMilestone.Value + "";
        }

        private void trackBarTinhTienTongHop2CycleMilestone_Scroll(object sender, EventArgs e)
        {

        }

        private void btnXemDanhSachXeTon_Click(object sender, EventArgs e)
        {
            searchXeTon();
        }

        private void searchXeTon()
        {
            CarDTO carDTO = getCarModel();

            DataTable data = CarDAO.searchXeTon(carDTO);
            dgvCarList.DataSource = data;
        }

        private CarDTO getCarModel()
        {
            CarDTO carDTO = new CarDTO();
            DateTime startDate = dateTimePickerCarDateIn.Value;
            DateTime startTime = dateTimePickerCarTimeIn.Value;
            startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startTime.Hour, startTime.Minute, 0);
            carDTO.TimeStart = startDate;
            DateTime endDate = dateTimePickerCarDateOut.Value;
            DateTime endTime = dateTimePickerCarTimeOut.Value;
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, endTime.Hour, endTime.Minute, 59);
            carDTO.TimeEnd = endDate;
            if (comboBoxTruyVanLoaiXe.SelectedIndex > 0)
            {
                DataRow dataRow = ((DataRowView)comboBoxTruyVanLoaiXe.SelectedItem).Row;
                carDTO.IdPart = Convert.ToString(dataRow["ID"]);
            }
            try
            {
                carDTO.CardIdentify = tbCardIdentifySearchCar.Text;
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

        private void dgvCarList_MouseClick(object sender, MouseEventArgs ev)
        {
            if (ev.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                MenuItem menuItem = new MenuItem(Constant.sButtonDelete);
                int currentRow = dgvCarList.HitTest(ev.X, ev.Y).RowIndex;
                menuItem.Click += new EventHandler((s, e) => Delete_Car_Click(s, e, currentRow));
                m.MenuItems.Add(menuItem);

                m.Show(dgvCarList, new Point(ev.X, ev.Y));
            }
        }

        private void dgvCarList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCarList.IsCurrentCellDirty)
            {
                dgvCarList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tbPartIdCreate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != Convert.ToChar(Keys.Back)
                    && e.KeyChar != Convert.ToChar(Keys.Delete)
                    && e.KeyChar != Convert.ToChar(Keys.Enter))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số!");
                    e.Handled = true;
                }
            }
        }

        private void btnSearchCardToLock_Click(object sender, EventArgs e)
        {
            searchCardToLock();
        }

        private void btnLockCard_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvLockCardList.Rows)
            {
                DataGridViewCheckBoxCell checkCell = row.Cells["SelectLockCard"] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(checkCell.Value))
                {
                    string cardId = Convert.ToString(row.Cells["ColumnLockCardID"].Value);
                    CardDAO.UpdateIsUsing("0", cardId);
                }
            }
            searchCardToLock();
        }

        private void rbTuDongKhoaThe_CheckedChanged(object sender, EventArgs e)
        {
            checkShowHideLockCardDate();
        }

        private void checkShowHideLockCardDate()
        {
            panelLockCardDate.Visible = cbTuDongKhoaThe.Checked;
        }

        private void ResizeAll(Control cnt, Size newSize)
        {
            int iWidth = newSize.Width - oldSize.Width;
            cnt.Left += (cnt.Left * iWidth) / oldSize.Width;
            cnt.Width += (cnt.Width * iWidth) / oldSize.Width;

            int iHeight = newSize.Height - oldSize.Height;
            cnt.Top += (cnt.Top * iHeight) / oldSize.Height;
            cnt.Height += (cnt.Height * iHeight) / oldSize.Height;
            foreach (Control childControl in cnt.Controls)
            {
                ResizeAll(childControl, base.Size);
            }
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            if (WindowState != FormWindowState.Minimized)
            {
                oldSize = base.Size;
            }
        }

        private int GetFormArea(Size size)
        {
            return size.Width;
        }

        private void ResizeFont(Control.ControlCollection coll, float scaleFactor)
        {
            foreach (Control c in coll)
            {
                if (c.HasChildren)
                {
                    ResizeFont(c.Controls, scaleFactor);
                }
                else
                {
                    if (true)
                    {
                        // scale font
                        c.Font = new Font(c.Font.FontFamily, c.Font.Size * scaleFactor, c.Font.Style);
                    }
                }
            }
        }

        private void FormQuanLy_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                Control control = (Control)sender;
                if (_lastFormSize != 0)
                {
                    float scaleFactor = (float)GetFormArea(control.Size) / (float)_lastFormSize;
                    //ResizeFont(this.Controls, scaleFactor);

                    foreach (Control cnt in this.Controls)
                    {
                        //ResizeAll(cnt, base.Size);
                    }
                }
                _lastFormSize = GetFormArea(control.Size);
            }
        }

        private void btnBlockTicketMonthSearch_Click(object sender, EventArgs e)
        {
            searchBlockTicketMonth();
        }

        private void btnBlockTicketMonth_Click(object sender, EventArgs e)
        {
            if (!isChosenBlockTicketMonthData())
            {
                MessageBox.Show(Constant.sMessageNoChooseDataError);
                return;
            }
            foreach (DataGridViewRow row in dgvBlockTicketMonthList.Rows)
            {
                DataGridViewCheckBoxCell checkCell = row.Cells["SelectBlockTicketMonth"] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(checkCell.Value))
                {
                    string cardId = Convert.ToString(row.Cells["ColumnBlockTicketCardID"].Value);
                    CardDAO.UpdateIsUsing("0", cardId);               
                }
            }
            searchBlockTicketMonth();
        }

        private void dgvBlockTicketMonthList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Util.setRowNumber(dgvBlockTicketMonthList, "STT_BlockTicketMonthList");
        }

        private void btnExportDanhSachKhoaTheThang_Click(object sender, EventArgs e)
        {
            exportDanhSachKhoaTheThangToExcel();
        }

        private void btnExportDanhSachKichHoatTheThang_Click(object sender, EventArgs e)
        {
            exportDanhSachKichHoatTheThangToExcel();
        }

        private void btnNearExpiredTicketMonthSelectAll_Click(object sender, EventArgs e)
        {
            if ((string) btnNearExpiredTicketMonthSelectAll.Tag == "")
            {
                foreach (DataGridViewRow row in dgvRenewTicketMonthList.Rows)
                {
                    row.Cells["RenewIsChosen"].Value = true;
                }
                btnNearExpiredTicketMonthSelectAll.Tag = "select";
                btnNearExpiredTicketMonthSelectAll.Text = "BỎ CHỌN";
            } else
            {
                foreach (DataGridViewRow row in dgvRenewTicketMonthList.Rows)
                {
                    row.Cells["RenewIsChosen"].Value = false;
                }
                btnNearExpiredTicketMonthSelectAll.Tag = "";
                btnNearExpiredTicketMonthSelectAll.Text = "CHỌN TẤT CẢ";
            }   
        }

        private void btnCardSelectAll_Click(object sender, EventArgs e)
        {
            if ((string)btnCardSelectAll.Tag == "")
            {
                foreach (DataGridViewRow row in dgvCardList.Rows)
                {
                    row.Cells["SelectCard"].Value = true;
                }
                btnCardSelectAll.Tag = "select";
                btnCardSelectAll.Text = "BỎ CHỌN";
            }
            else
            {
                foreach (DataGridViewRow row in dgvCardList.Rows)
                {
                    row.Cells["SelectCard"].Value = false;
                }
                btnCardSelectAll.Tag = "";
                btnCardSelectAll.Text = "CHỌN TẤT CẢ";
            }
        }

        private void btnCardDelete_Click(object sender, EventArgs e)
        {
            checkForDeleteCard();
        }

        private void btnTicketMonthSelectAll_Click(object sender, EventArgs e)
        {
            if ((string)btnTicketMonthSelectAll.Tag == "")
            {
                foreach (DataGridViewRow row in dgvTicketMonthList.Rows)
                {
                    row.Cells["SelectTicketMonth"].Value = true;
                }
                btnTicketMonthSelectAll.Tag = "select";
                btnTicketMonthSelectAll.Text = "BỎ CHỌN";
            }
            else
            {
                foreach (DataGridViewRow row in dgvTicketMonthList.Rows)
                {
                    row.Cells["SelectTicketMonth"].Value = false;
                }
                btnTicketMonthSelectAll.Tag = "";
                btnTicketMonthSelectAll.Text = "CHỌN TẤT CẢ";
            }
        }

        private void btnTicketMonthDelete_Click(object sender, EventArgs e)
        {
            checkForDeleteTicketMonth();
        }

        private void btSelectAllAciveTicketMonth_Click(object sender, EventArgs e)
        {
            if ((string)btSelectAllAciveTicketMonth.Tag == "")
            {
                foreach (DataGridViewRow row in dgvActiveTicketMonthList.Rows)
                {
                    row.Cells["SelectActiveTicketMonth"].Value = true;
                }
                btSelectAllAciveTicketMonth.Tag = "select";
                btSelectAllAciveTicketMonth.Text = "BỎ CHỌN";
            }
            else
            {
                foreach (DataGridViewRow row in dgvActiveTicketMonthList.Rows)
                {
                    row.Cells["SelectActiveTicketMonth"].Value = false;
                }
                btSelectAllAciveTicketMonth.Tag = "";
                btSelectAllAciveTicketMonth.Text = "CHỌN TẤT CẢ";
            }
        }

        private void btSelectAllBlockTicketMonth_Click(object sender, EventArgs e)
        {
            if ((string)btSelectAllBlockTicketMonth.Tag == "")
            {
                foreach (DataGridViewRow row in dgvBlockTicketMonthList.Rows)
                {
                    row.Cells["SelectBlockTicketMonth"].Value = true;
                }
                btSelectAllBlockTicketMonth.Tag = "select";
                btSelectAllBlockTicketMonth.Text = "BỎ CHỌN";
            }
            else
            {
                foreach (DataGridViewRow row in dgvBlockTicketMonthList.Rows)
                {
                    row.Cells["SelectBlockTicketMonth"].Value = false;
                }
                btSelectAllBlockTicketMonth.Tag = "";
                btSelectAllBlockTicketMonth.Text = "CHỌN TẤT CẢ";
            }
        }

        private void tbPrintReceiptKeyWordSearch_TextChangedAsync(object sender, EventArgs e)
        {
            
        }

        private void searchPrintReceiptData()
        {
            mPrintReceiptCost = 0;
            tbPrintReceiptCost.Text = "";
            string key = tbPrintReceiptKeyWordSearch.Text;
            dgvPrintReceipt.DataSource = TicketMonthDAO.searchPrintReceiptData(key);
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            string title = "PHIẾU THU TIỀN MẶT";
            int receiptType = ReceiptTypeDTO.TYPE_PHIEU_THU_TIEN_MAT;
            if (mPrintReceiptCost < 0)
            {
                title = "PHIẾU CHI TIỀN MẶT";
                receiptType = ReceiptTypeDTO.TYPE_PHIEU_CHI_TIEN_MAT;
            }
            openPrintReceiptForm(title, receiptType);
        }

        private void openPrintReceiptForm(string title, int receiptType)
        {
            if (!isChosenReceiptData())
            {
                MessageBox.Show(Constant.sMessageNoChooseDataError);
                return;
            }
            else if (getCountReceiptIsChosen() > 6)
            {
                MessageBox.Show(Constant.sMessageMaxTicketMonthToPrint);
                return;
            }
            FormInPhieuThu formInPhieuThu = new FormInPhieuThu();
            formInPhieuThu.receiptType = receiptType;
            formInPhieuThu.customerName = tbPrintReceiptCustomerName.Text;
            formInPhieuThu.address = tbPrintReceiptAddress.Text;
            formInPhieuThu.reason = tbPrintReceiptReason.Text;
            formInPhieuThu.cost = mPrintReceiptCost;
            formInPhieuThu.isCostCreateCard = cbCostCreateCard.Checked;
            formInPhieuThu.isRemoveCostCreateCard = rbRemoveCostCreateCard.Checked && cbCostCreateCard.Checked;
            formInPhieuThu.isCostDepositCard = cbCostDeposit.Checked;
            formInPhieuThu.isCostExtendCard = cbCostExtendCard.Checked;
            formInPhieuThu.isVAT = cbVAT.Checked;
       
            formInPhieuThu.data = creatDataForPrintReceipt();
            formInPhieuThu.title = title;

            formInPhieuThu.ShowDialog();
        }

        private void openFeeNoticeForm()
        {
            if (!isChosenReceiptData())
            {
                MessageBox.Show(Constant.sMessageNoChooseDataError);
                return;
            }
            else if (getCountReceiptIsChosen() > 6)
            {
                MessageBox.Show(Constant.sMessageMaxTicketMonthToPrintFeeNotice);
                return;
            }
            FormThongBaoPhi formInPhieuThu = new FormThongBaoPhi();
            formInPhieuThu.customerName = tbPrintReceiptCustomerName.Text;
            formInPhieuThu.address = tbPrintReceiptAddress.Text;
            formInPhieuThu.reason = tbPrintReceiptReason.Text;
            formInPhieuThu.cost = mPrintReceiptCost;
            formInPhieuThu.isCostExtendCard = true;
            formInPhieuThu.isVAT = cbVAT.Checked;
            formInPhieuThu.monthCount = int.Parse(numericMonthExtendCount.Value.ToString());

            formInPhieuThu.data = creatDataForPrintReceipt();

            formInPhieuThu.ShowDialog();
        }

        private DataTable creatDataForPrintReceipt()
        {
            DataTable data = new DataTable();
            data.Columns.Add("Identify", typeof(System.String));
            data.Columns.Add("Digit", typeof(System.String));
            data.Columns.Add("PartName", typeof(System.String));
            data.Columns.Add("CustomerName", typeof(System.String));
            data.Columns.Add("Cost", typeof(System.Int32));
            data.Columns.Add("PrintCost", typeof(System.Int32));
            data.Columns.Add("ExpirationDate", typeof(System.DateTime));
            data.Columns.Add("NewExpirationDate", typeof(System.DateTime));
            data.Columns.Add("ID", typeof(System.String));
            data.Columns.Add("IDPart", typeof(System.String));
            data.Columns.Add("Company", typeof(System.String));
            data.Columns.Add("Address", typeof(System.String));

            for (int i = 0; i < dgvPrintReceipt.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvPrintReceipt.Rows[i].Cells["ReceiptIsChosen"].Value) == true)
                {
                    DataRow row = data.NewRow();
                    row.SetField("Identify", dgvPrintReceipt.Rows[i].Cells["ReceiptIdentify"].Value);
                    row.SetField("Digit", dgvPrintReceipt.Rows[i].Cells["ReceiptDigit"].Value);
                    row.SetField("PartName", dgvPrintReceipt.Rows[i].Cells["ReceiptPartName"].Value);
                    row.SetField("IDPart", dgvPrintReceipt.Rows[i].Cells["ReceiptIDPart"].Value);
                    row.SetField("CustomerName", dgvPrintReceipt.Rows[i].Cells["ReceiptCustomerName"].Value);
                    row.SetField("Cost", dgvPrintReceipt.Rows[i].Cells["ReceiptCost"].Value);
                    int printCost = Convert.ToInt32(dgvPrintReceipt.Rows[i].Cells["ReceiptCost"].Value);
                    if (printCost < 0)
                    {
                        printCost = -printCost;
                    }
                    row.SetField("PrintCost", printCost);
                    row.SetField("ExpirationDate", dgvPrintReceipt.Rows[i].Cells["ReceiptExpirationDate"].Value);
                    row.SetField("NewExpirationDate", dgvPrintReceipt.Rows[i].Cells["ReceiptNewExpirationDate"].Value);
                    row.SetField("ID", dgvPrintReceipt.Rows[i].Cells["ReceiptTicketMonthID"].Value);
                    row.SetField("Company", dgvPrintReceipt.Rows[i].Cells["ReceiptCompany"].Value);
                    row.SetField("Address", dgvPrintReceipt.Rows[i].Cells["ReceiptAddress"].Value);
                    data.Rows.Add(row);
                }
            }
            return data;
        }

        private void printDocument1_PrintPage(System.Object sender,
               System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void dgvPrintReceipt_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Util.setRowNumber(dgvPrintReceipt, "STT_ReceiptTicketMonthList");            
        }

        DateTimePicker oDateTimePicker;
        private void dgvPrintReceipt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = e.RowIndex;
            int Count = dgvPrintReceipt.Rows.Count;
            if (Index < Count)
            {
                loadPrintReceiptInfoFromDataGridViewRow(Index);
            }

            if (e.RowIndex < 0) return;

            if (oDateTimePicker != null)
            {
                oDateTimePicker.Visible = false;
            }
            string currentColumnName = dgvPrintReceipt.Columns[e.ColumnIndex].Name;
            if (currentColumnName == "ReceiptNewExpirationDate")
            {
                //Initialized a new DateTimePicker Control  
                oDateTimePicker = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dgvPrintReceipt.Controls.Add(oDateTimePicker);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker.Format = DateTimePickerFormat.Short;

                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dgvPrintReceipt.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

                // Now make it visible  
                oDateTimePicker.Visible = true;
            }
        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dgvPrintReceipt.CurrentCell.Value = oDateTimePicker.Text.ToString();
        }

        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker.Visible = false;
        }

        private void dgvPrintReceipt_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string currentColumnName = dgvPrintReceipt.Columns[e.ColumnIndex].Name;
            if (currentColumnName == "ReceiptNewExpirationDate" || currentColumnName == "ReceiptIsChosen")
            {
                if (currentColumnName == "ReceiptIsChosen") {
                    calculateNewExpiratedDate();
                }
                calculatePrintReceipCost();
            }
        }

        private void dgvPrintReceipt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPrintReceipt.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void calculatePrintReceipCost()
        {
            int total = 0;
            string reason = "";   
            foreach (DataGridViewRow row in dgvPrintReceipt.Rows)
            {
                DataGridViewCheckBoxCell checkCell = row.Cells["ReceiptIsChosen"] as DataGridViewCheckBoxCell;
                object value = checkCell.Value;

                row.Cells["ReceiptCost"].Value = 0;

                foreach (DataGridViewColumn col in dgvPrintReceipt.Columns)
                {
                    dgvPrintReceipt[col.Index, row.Index].Style.ForeColor = Color.Black;
                }

                if (value != null && (Boolean)value)
                {
                    foreach (DataGridViewColumn col in dgvPrintReceipt.Columns)
                    {
                        dgvPrintReceipt[col.Index, row.Index].Style.ForeColor = Color.Blue;
                    }

                    if (cbCostExtendCard.Checked || cbCostCreateCard.Checked || cbCostDeposit.Checked || cbVAT.Checked)
                    {
                        int payCost = 0;
                        if (cbCostExtendCard.Checked)
                        {
                            DateTime expirationDate = Convert.ToDateTime(row.Cells["ReceiptExpirationDate"].Value);
                            DateTime newExpirationDate = Convert.ToDateTime(row.Cells["ReceiptNewExpirationDate"].Value);
                            string monthlyCostString = row.Cells["ReceiptChargesAmount"].Value.ToString().Replace(".", "").Replace(",", "");
                            int extendCardCost = Util.getCostExtendCard(expirationDate, newExpirationDate, monthlyCostString);
                            if (cbVAT.Checked)
                            {
                                extendCardCost += (int)(extendCardCost * 0.1);
                            }
                            payCost += extendCardCost;
                        }

                        if (cbCostCreateCard.Checked)
                        {
                            if (rbAddCostCreateCard.Checked)
                            {
                                payCost += ConfigDAO.GetLostCard(ConfigDAO.GetConfig());
                            }
                            if (rbRemoveCostCreateCard.Checked)
                            {
                                payCost -= ConfigDAO.GetLostCard(ConfigDAO.GetConfig());
                            }
                        }

                        if (cbCostDeposit.Checked)
                        {
                            int monthlyCost = 0;
                            string monthlyCostString = row.Cells["ReceiptChargesAmount"].Value.ToString().Replace(".", "").Replace(",", "");
                            try
                            {
                                monthlyCost = Convert.ToInt32(monthlyCostString);
                            }
                            catch (Exception)
                            {

                            }
                            if (rbAddCostDeposit.Checked)
                            {
                                payCost += monthlyCost;
                            }
                            if (rbRemoveCostDeposit.Checked)
                            {
                                payCost -= monthlyCost;
                            }
                        }

                        payCost = Util.roundUpVND(payCost);
                        row.Cells["ReceiptCost"].Value = payCost;
                        total += payCost;
                    }
                }
            }
            if (cbCostExtendCard.Checked)
            {
                reason += "Phí gia hạn";
            }
            if (cbCostCreateCard.Checked)
            {
                if (!reason.Equals(""))
                {
                    reason += " + ";
                }
                if (rbAddCostCreateCard.Checked)
                {
                    reason += "Phí làm thẻ";
                } else
                {
                    reason += "Phí hoàn trả thẻ thẻ";
                }
            }
            if (cbCostDeposit.Checked)
            {
                if (!reason.Equals(""))
                {
                    reason += " + ";
                }
                reason += "Phí cọc";
            }
            mPrintReceiptCost = total;
            tbPrintReceiptCost.Text = Util.formatNumberAsMoney(total);
            tbPrintReceiptReason.Text = reason;
        }

        private void calculateNoticeCost()
        {
            int monthCount = Int32.Parse(numericMonthExtendCount.Value.ToString());
            dgvPrintReceipt.Columns["ReceiptNewExpirationDate"].Visible = true;
            foreach (DataGridViewRow row in dgvPrintReceipt.Rows)
            {
                bool isChoose = Convert.ToBoolean(row.Cells["ReceiptIsChosen"].Value);
                if (isChoose)
                {                   
                    row.Cells["ReceiptNewExpirationDate"].Value = Util.getLastDateOfCurrentMonth(DateTime.Now.AddMonths(monthCount - 1));
                }
            }

            int total = 0;
            foreach (DataGridViewRow row in dgvPrintReceipt.Rows)
            {
                DataGridViewCheckBoxCell checkCell = row.Cells["ReceiptIsChosen"] as DataGridViewCheckBoxCell;
                object value = checkCell.Value;

                row.Cells["ReceiptCost"].Value = 0;

                foreach (DataGridViewColumn col in dgvPrintReceipt.Columns)
                {
                    dgvPrintReceipt[col.Index, row.Index].Style.ForeColor = Color.Black;
                }

                if (value != null && (Boolean)value)
                {
                    foreach (DataGridViewColumn col in dgvPrintReceipt.Columns)
                    {
                        dgvPrintReceipt[col.Index, row.Index].Style.ForeColor = Color.Blue;
                    }

                    int payCost = 0;
                    DateTime expirationDate = Convert.ToDateTime(row.Cells["ReceiptExpirationDate"].Value);
                    DateTime newExpirationDate = Convert.ToDateTime(row.Cells["ReceiptNewExpirationDate"].Value);
                    string monthlyCostString = row.Cells["ReceiptChargesAmount"].Value.ToString().Replace(".", "").Replace(",", "");
                    int extendCardCost = Util.getCostExtendCard(expirationDate, newExpirationDate, monthlyCostString);
                    if (cbVAT.Checked)
                    {
                        extendCardCost += (int)(extendCardCost * 0.1);
                    }
                    payCost += extendCardCost;
                    payCost = Util.roundUpVND(payCost);
                    row.Cells["ReceiptCost"].Value = payCost;
                    total += payCost;
                }
            }
            
            mPrintReceiptCost = total;
            tbPrintReceiptCost.Text = Util.formatNumberAsMoney(total);
        }    

        private void loadDataPrintReceipt()
        {
            tbPrintReceiptCustomerName.Text = ConfigDAO.GetParkingName(ConfigDAO.GetConfig());
        }

        private void configReceiptHistory()
        {
            dtReceiptLogBook.Value = DateTime.Now;
            dgv_ReceiptHistory.AutoGenerateColumns = false;
            
            Util.setRowNumber(dgv_ReceiptHistory, "STT_ReceiptLog");

            DataTable dt = ReceiptTypeDAO.GetAllData();
            DataRow dr = dt.NewRow();
            dr["ReceiptTypeName"] = "Tất cả";
            dt.Rows.InsertAt(dr, 0);
            cbReceiptLogType.DataSource = dt;
            cbReceiptLogType.DisplayMember = "ReceiptTypeName";
            cbReceiptLogType.ValueMember = "ReceiptTypeID";
        }

        private string getReasonForReceipt()
        {
            string reason = "";
            if (isChosenReceiptData())
            {
                reason += "Thu phí xe tháng";
            }
            if (cbCostCreateCard.Checked)
            {
                if (!reason.Equals(""))
                {
                    reason += " + ";
                }
                if (rbAddCostCreateCard.Checked)
                {
                    reason += "Thu phí làm thẻ";
                }
                if (rbRemoveCostCreateCard.Checked)
                {
                    reason += "Trả phí làm thẻ";
                }
            }

            if (cbCostDeposit.Checked)
            {
                if (!reason.Equals(""))
                {
                    reason += " + ";
                }
                if (rbAddCostDeposit.Checked)
                {
                    reason += "Thu phí cọc thẻ";
                }
                if (rbRemoveCostDeposit.Checked)
                {
                    reason += "Trả phí cọc thẻ";
                }
            }
            return reason;
        }

        private void tbPrintReceiptCost_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadPrintReceiptInfoFromDataGridViewRow(int Index)
        {
            if (Index < 0)
            {
                return;
            }
            string customerName = Convert.ToString(dgvPrintReceipt.Rows[Index].Cells["ReceiptCustomerName"].Value) + " - " + ConfigDAO.GetParkingName(ConfigDAO.GetConfig());
            tbPrintReceiptCustomerName.Text = customerName;
            string address = Convert.ToString(dgvPrintReceipt.Rows[Index].Cells["ReceiptAddress"].Value);
            string company = Convert.ToString(dgvPrintReceipt.Rows[Index].Cells["ReceiptCompany"].Value);
            if (!company.Equals(""))
            {
                tbPrintReceiptAddress.Text = company;
            } else
            {
                tbPrintReceiptAddress.Text = address;
            }
        }

        private void cbCostCreateCard_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxCostCreateCard.Visible = cbCostCreateCard.Checked;
            calculatePrintReceipCost();
        }

        private void cbVAT_CheckedChanged(object sender, EventArgs e)
        {
            calculatePrintReceipCost();
        }

        private void btnPrintTransferCost_Click(object sender, EventArgs e)
        {
            openPrintReceiptForm("PHIẾU CHUYỂN KHOẢN", ReceiptTypeDTO.TYPE_PHIEU_CHUYEN_KHOAN);
        }

        private void rbAddCostDeposit_CheckedChanged(object sender, EventArgs e)
        {
            calculatePrintReceipCost();
        }

        private void rbRemoveCostDeposit_CheckedChanged(object sender, EventArgs e)
        {
            calculatePrintReceipCost();
        }

        private void rbAddCostCreateCard_CheckedChanged(object sender, EventArgs e)
        {
            calculatePrintReceipCost();
        }

        private void rbRemoveCostCreateCard_CheckedChanged(object sender, EventArgs e)
        {
            calculatePrintReceipCost();
        }

        private void cbCostDeposit_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxCostDeposit.Visible = cbCostDeposit.Checked;
            calculatePrintReceipCost();
        }

        private void cbCostExtendCard_CheckedChanged(object sender, EventArgs e)
        {           
            if (cbCostExtendCard.Checked)
            {
                dgvPrintReceipt.Columns["ReceiptNewExpirationDate"].Visible = true;
            } else
            {
                dgvPrintReceipt.Columns["ReceiptNewExpirationDate"].Visible = false;
            }
            calculatePrintReceipCost();
        }

        private int mReceiptHistoryHeight = 0;
        private void dgv_ReceiptHistory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int total = 0;
            foreach (DataGridViewRow row in dgv_ReceiptHistory.Rows)
            {
                total += Convert.ToInt32(row.Cells["ReceiptLog_Cost"].Value.ToString());
            }
            tbReceiptLogTotalCost.Text = Util.formatNumberAsMoney(total);

            var height = 30;
            foreach (DataGridViewRow dr in dgv_ReceiptHistory.Rows)
            {
                height += dr.Height;
            }

            if (mReceiptHistoryHeight == 0)
            {
                mReceiptHistoryHeight = dgv_ReceiptHistory.Height;
            }
            if (height < mReceiptHistoryHeight)
            {
                dgv_ReceiptHistory.Height = height;

            } else
            {
                dgv_ReceiptHistory.Height = mReceiptHistoryHeight;
            }
            Util.setRowNumber(dgv_ReceiptHistory, "STT_ReceiptLog");
        }

        private ReceiptLogDTO getReceptLogModelForSearch()
        {
            ReceiptLogDTO receiptLogDTO = new ReceiptLogDTO();
            if (cbReceiptLogPrintDate.Checked)
            {
                DateTime startDate = dtReceiptLogStartDate.Value;
                DateTime startTime = dtReceiptLogStartTime.Value;
                startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startTime.Hour, startTime.Minute, 0);
                receiptLogDTO.TimeStart = startDate;
                DateTime endDate = dtReceiptLogEndDate.Value;
                DateTime endTime = dtReceiptLogEndTime.Value;
                endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, endTime.Hour, endTime.Minute, 59);
                receiptLogDTO.TimeEnd = endDate;
            }

            if (cbReceiptLogBook.Checked)
            {
                receiptLogDTO.ReceiptBook = dtReceiptLogBook.Value;
            }

            if (cbReceiptLogType.SelectedIndex > 0)
            {
                DataRow dataRow = ((DataRowView)cbReceiptLogType.SelectedItem).Row;
                receiptLogDTO.ReceiptType = Convert.ToInt32(dataRow["ReceiptTypeID"]);
            }

            receiptLogDTO.CustomerName = tbReceiptLogCustomerName.Text;
            if (!tbReceiptLogNumber.Text.Equals(""))
            {
                receiptLogDTO.ReceiptNumber = Int32.Parse(tbReceiptLogNumber.Text);
            }            
            receiptLogDTO.Address = tbReceiptLogAddress.Text;
            receiptLogDTO.IsCostCreateCard = cbReceiptLogCostCreateCard.Checked ? 1 : 0;
            receiptLogDTO.IsCostExtendCard = cbReceiptLogCostExtendCard.Checked ? 1 : 0;
            receiptLogDTO.IsCostDepositCard = cbReceiptLogCostDeposit.Checked ? 1 : 0;

            return receiptLogDTO;
        }

        private ReceiptLogDetailDTO getReceptLogDetailModelForSearch()
        {
            ReceiptLogDetailDTO receiptLogDetailDTO = new ReceiptLogDetailDTO();
            if (cbReceiptLogDetailPrintDate.Checked)
            {
                DateTime startDate = dtReceiptLogDetailStartDate.Value;
                DateTime startTime = dtReceiptLogDetailStartTime.Value;
                startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startTime.Hour, startTime.Minute, 0);
                receiptLogDetailDTO.TimeStart = startDate;
                DateTime endDate = dtReceiptLogDetailEndDate.Value;
                DateTime endTime = dtReceiptLogDetailEndTime.Value;
                endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, endTime.Hour, endTime.Minute, 59);
                receiptLogDetailDTO.TimeEnd = endDate;
            }

            if (cbReceiptLogDetailBook.Checked)
            {
                receiptLogDetailDTO.ReceiptBook = dtReceiptLogDetailBook.Value;
            }

            if (cbReceiptLogDetailVehicle.SelectedIndex > 0)
            {
                DataRow dataRow = ((DataRowView)cbReceiptLogDetailVehicle.SelectedItem).Row;
                receiptLogDetailDTO.PartID = Convert.ToString(dataRow["ID"]);
            }

            receiptLogDetailDTO.CustomerName = tbReceiptLogDetailCustomerName.Text;
            receiptLogDetailDTO.Address = tbReceiptLogDetailAddress.Text;
            receiptLogDetailDTO.Company = tbReceiptLogDetailCompany.Text;

            receiptLogDetailDTO.CardIdentify = tbReceiptLogDetailCardIdentify.Text;
            receiptLogDetailDTO.CardID = tbReceiptLogDetailCardID.Text;
            receiptLogDetailDTO.Digit = tbReceiptLogDetailDigit.Text;

            receiptLogDetailDTO.IsCostCreateCard = cbReceiptLogDetailCostCreateCard.Checked ? 1 : 0;
            receiptLogDetailDTO.IsCostExtendCard = cbReceiptLogDetailCostExtendCard.Checked ? 1 : 0;
            receiptLogDetailDTO.IsCostDepositCard = cbReceiptLogDetailCostDeposit.Checked ? 1 : 0;

            return receiptLogDetailDTO;
        }

        private void btnReceiptLogSearch_Click(object sender, EventArgs e)
        {
            ReceiptLogDTO receiptLogDTO = getReceptLogModelForSearch();

            DataTable data = ReceiptLogDAO.searchAllData(receiptLogDTO);
            dgv_ReceiptHistory.DataSource = data;
        }

        private void exportDanhSachPhieuThuChiToExcel()
        {
            try
            {
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Danh sách phiếu thu - chi");

                string fileName = "Export_danhsach_phieu_thu_chi";
                exportToExcel(dgv_ReceiptHistory, worksheet, 1, 1, fileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void exportDanhSachChiTietPhieuThuChiToExcel()
        {
            try
            {
                XLWorkbook workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Chi tiết phiếu thu - chi");

                string fileName = "Export_chitiet_phieu_thu_chi";
                exportToExcel(dgvReceiptLogDetail, worksheet, 1, 1, fileName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void btnReceiptLogExportExcel_Click(object sender, EventArgs e)
        {
            exportDanhSachPhieuThuChiToExcel();
        }

        private void tabQuanLyPhieuThuChi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabQuanLyPhieuThuChi.SelectedTab == tabQuanLyPhieuThuChi.TabPages["tabPageChiTietPhieuThuChi"])
            {
                //loadDataReceiptLogDetail();
                dgvReceiptLogDetail.AutoGenerateColumns = false;
                loadPartDataWithFieldAllToComboBox(cbReceiptLogDetailVehicle);
                dtReceiptLogDetailBook.Value = DateTime.Now;
            } else if (tabQuanLyPhieuThuChi.SelectedTab == tabQuanLyPhieuThuChi.TabPages["tabPageInPhieuThu"])
            {
                loadDataPrintReceipt();
            }
            else if (tabQuanLyPhieuThuChi.SelectedTab == tabQuanLyPhieuThuChi.TabPages["tabPageLichSuPhieuThuChi"])
            {
                configReceiptHistory();
                dgv_ReceiptHistory.AutoGenerateColumns = false;
            }
    }

        private void loadDataReceiptLogDetail()
        {
            dgvReceiptLogDetail.AutoGenerateColumns = false;
            if (dgvReceiptLogDetail.Rows.Count == 0)
            {
                DataTable data = ReceiptLogDetailDAO.GetAllData();
                dgvReceiptLogDetail.DataSource = data;
            }           
        }

        private int mReceiptLogDetailHeight = 0;
        private void dgvReceiptLogDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Util.setRowNumber(dgvReceiptLogDetail, "ReceiptLogDetailSTT");
            int total = 0;
            foreach (DataGridViewRow row in dgvReceiptLogDetail.Rows)
            {
                total += Convert.ToInt32(row.Cells["ReceiptLogDetailCost"].Value.ToString());
            }
            tbReceiptLogDetailTotalCost.Text = Util.formatNumberAsMoney(total);

            var height = 42;
            foreach (DataGridViewRow dr in dgvReceiptLogDetail.Rows)
            {
                height += dr.Height;
            }

            if (mReceiptLogDetailHeight == 0)
            {
                mReceiptLogDetailHeight = dgvReceiptLogDetail.Height;
            }
            if (height < mReceiptLogDetailHeight)
            {
                dgvReceiptLogDetail.Height = height;

            }
            else
            {
                dgvReceiptLogDetail.Height = mReceiptLogDetailHeight;
            }
        }

        private void btnReceiptLogDetailSearch_Click(object sender, EventArgs e)
        {
            ReceiptLogDetailDTO receiptLogDetailDTO = getReceptLogDetailModelForSearch();

            DataTable data = ReceiptLogDetailDAO.searchAllData(receiptLogDetailDTO);
            dgvReceiptLogDetail.DataSource = data;
        }

        private void btnReceiptLogDetailExportExcel_Click(object sender, EventArgs e)
        {
            exportDanhSachChiTietPhieuThuChiToExcel();
        }

        private void dgv_ReceiptHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_ReceiptHistory.Columns["ReceiptLog_Detail"].Index && e.RowIndex >= 0)
            {
                int receiptLogID = Convert.ToInt32(dgv_ReceiptHistory.Rows[e.RowIndex].Cells["ReceiptLogID"].Value);
                ReceiptLogDetailDTO receiptLogDetailDTO = new ReceiptLogDetailDTO();
                receiptLogDetailDTO.ReceiptLogID = receiptLogID;

                DataTable data = ReceiptLogDetailDAO.searchAllData(receiptLogDetailDTO);
                dgvReceiptLogDetail.DataSource = data;
                tabQuanLyPhieuThuChi.SelectedTab = tabQuanLyPhieuThuChi.TabPages["tabPageChiTietPhieuThuChi"];
            }
        }

        private void btnCancedReceipt_Click(object sender, EventArgs e)
        {
            tbPrintReceiptKeyWordSearch.Text = "";
            tbPrintReceiptCustomerName.Text = "";
            tbPrintReceiptAddress.Text = "";
            tbPrintReceiptReason.Text = "";
            cbCostExtendCard.Checked = false;
            cbCostDeposit.Checked = false;
            cbCostCreateCard.Checked = false;
            cbVAT.Checked = false;
        }

        private void numericMonthExtendCount_ValueChanged(object sender, EventArgs e)
        {
            calculateNewExpiratedDate();
        }
        private void calculateNewExpiratedDate()
        {
            int monthCount = Int32.Parse(numericMonthExtendCount.Value.ToString());
            foreach (DataGridViewRow row in dgvPrintReceipt.Rows)
            {
                bool isChoose = Convert.ToBoolean(row.Cells["ReceiptIsChosen"].Value);
                if (isChoose)
                {
                    DateTime expirationDate = Convert.ToDateTime(row.Cells["ReceiptExpirationDate"].Value);
                    if (monthCount > 0)
                    {
                        DateTime newTempExpirationDate = expirationDate.AddMonths(monthCount);
                        row.Cells["ReceiptNewExpirationDate"].Value = Util.getLastDateOfCurrentMonth(newTempExpirationDate);
                    }
                    else
                    {
                        row.Cells["ReceiptNewExpirationDate"].Value = Util.getLastDateOfCurrentMonth(expirationDate);
                    }
                }
            }
        }

        private void btnSearchCardPrintReceipt_Click(object sender, EventArgs e)
        {
            searchPrintReceiptData();
        }

        private void btnPrintFeeNotice_Click(object sender, EventArgs e)
        {
            calculateNoticeCost();
            openFeeNoticeForm();
        }

        private void dgvDebtReport_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Util.setRowNumber(dgvDebtReport, "STT_DebtReportTicketMonthList");
        }

        private void btnSearchDebtReport_Click(object sender, EventArgs e)
        {
            searchDebtReportTicketMonthDataAsync();
        }

        private void btnExportDebtReport_Click(object sender, EventArgs e)
        {
            exportDanhSachBaoCaoCongNoToExcel();
        }

        SerialPort readerLeftSerialPort;
        SerialPort readerRightSerialPort;
        private void readPegasusReaderCOM()
        {
            try
            {
                readerLeftSerialPort = new SerialPort(mConfig.comReaderLeft, 9600, Parity.None, 8, StopBits.One);
                readerLeftSerialPort.DataReceived += new SerialDataReceivedEventHandler(portComReaderLeft_DataReceived);
                readerLeftSerialPort.Open();
            }
            catch (Exception e)
            {

            }

            try
            {
                readerRightSerialPort = new SerialPort(mConfig.comReaderRight, 9600, Parity.None, 8, StopBits.One);
                readerRightSerialPort.DataReceived += new SerialDataReceivedEventHandler(portComReaderRight_DataReceived);
                readerRightSerialPort.Open();
            }
            catch (Exception e)
            {

            }
        }

        private void portComReaderLeft_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadLine();
            Console.WriteLine(data);
            string cardID = data.Trim();
            cardID = Regex.Replace(cardID, @"[^\u0009\u000A\u000D\u0020-\u007E]", "");

            handleReceiveUhfData(cardID);
        }

        private void portComReaderRight_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadLine();
            Console.WriteLine(data);
            string cardID = data.Trim();
            cardID = Regex.Replace(cardID, @"[^\u0009\u000A\u000D\u0020-\u007E]", "");

            handleReceiveUhfData(cardID);
        }

        private void label263_Click(object sender, EventArgs e)
        {

        }

        private void cbTinhPhiCocThe_CheckedChanged(object sender, EventArgs e)
        {
            checkShowHideNoticeExpiredDate();
        }

        private void checkShowHideNoticeExpiredDate()
        {
            panelNoticeExpiredDate.Visible = cbTinhPhiCocThe.Checked;
        }
    }
}

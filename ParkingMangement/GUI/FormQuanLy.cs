using Newtonsoft.Json.Linq;
using ParkingMangement.DAO;
using ParkingMangement.DTO;
using ParkingMangement.Model;
using ParkingMangement.Utils;
using RawInput_dll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ParkingMangement.GUI
{
    public partial class FormQuanLy : Form
    {
        private string[] listFunctionQuanLyNhanSu = { "1", "2" };
        private string[] listFunctionQuanLyDoanhThu = { "3", "4" };
        private string[] listFunctionQuanLyTheLoaiXe = { "5", "6", "7" };
        private string[] listFunctionQuanLyVeThang = { "8", "9", "10", "11", "12" };
        private string[] listFunctionQuanLyHeThong = { "13", "14", "15", "16" };
        private string[] listFunctionQuanLyXe = { "17", "18", "19", "20" };

        private readonly RawInput _rawinput;
        const bool CaptureOnlyInForeground = true;
        private ComputerDTO mComputerDTO;
        public FormQuanLy()
        {
            InitializeComponent();
            _rawinput = new RawInput(Handle, CaptureOnlyInForeground);

            //_rawinput.AddMessageFilter();   // Adding a message filter will cause keypresses to be handled
            //Win32.DeviceAudit();            // Writes a file DeviceAudit.txt to the current directory

            _rawinput.KeyPressed += OnKeyPressed;
        }

        private void FormQuanLy_Load(object sender, EventArgs e)
        {
            loadUserInfoTab();
            checkShowHideAllTabPage();
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
            if (Index < Count - 1)
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
            } else
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
            DataTable data = CarDAO.GetTotalCost(null, null, null, CarDAO.ALL_TICKET);
            dgvThongKeDoanhThu.DataSource = data;
        }

        private void searchSaleReport()
        {
            string userID = null;
            int ticketType = CarDAO.ALL_TICKET;
            if (cbNhanVienReport.SelectedIndex > 0)
            {
                DataRow dataRow = ((DataRowView)cbNhanVienReport.SelectedItem).Row;
                userID = Convert.ToString(dataRow["UserID"]);
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
            dgvThongKeDoanhThu.DataSource = CarDAO.GetTotalCost(startDateReport, endDateReport, userID, ticketType);
        }

        private void btnAllSaleReport_Click(object sender, EventArgs e)
        {
            loadSaleReportData();
            loadCarList();
        }

        private void btnSearchSaleReport_Click(object sender, EventArgs e)
        {
            searchSaleReport();

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
            searchCarByDateTime(startDateReport, endDateReport);
        }

        private void tabQuanLyDoanhThu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabQuanLyDoanhThu.SelectedTab == tabQuanLyDoanhThu.TabPages["tabPageThongKeDoanhThu"])
            {
                setFormatDateForDateTimePicker(dtDateSaleReport);
                setFormatDateForDateTimePicker(dtStartDateSaleReport);
                setFormatDateForDateTimePicker(dtEndDateSaleReport);
            } else if (tabQuanLyDoanhThu.SelectedTab == tabQuanLyDoanhThu.TabPages["tabPageCongThucTinhTienTheoCongVan"])
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
        }

        private void loadDataTinhTienTheoCongVan()
        {
            DataRow partDataRow = ((DataRowView)cbLoaiXeTinhTienCongVan.SelectedItem).Row;
            string partID = Convert.ToString(partDataRow["PartID"]);
            mComputerDTO = ComputerDAO.GetDataByPartIDAndParkingTypeID(partID, Constant.LOAI_GIU_XE_THEO_CONG_VAN);
            if (mComputerDTO != null)
            {
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
            }
        }

        private void updateTinhTienTheoCongVan()
        {
            if (mComputerDTO != null)
            {
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

                if (mComputerDTO.StartHourNight <= mComputerDTO.EndHourNight)
                {
                    MessageBox.Show("Thời gian bắt đầu phải lớn hơn thời gian kết thúc tính đêm");
                    return;
                }

                if (ComputerDAO.Update(mComputerDTO))
                {
                    MessageBox.Show(Constant.sMessageUpdateSuccess);
                    panelTinhTienCongVan.Enabled = false;
                }
            }
        }

        private void loadDataTinhTienLuyTien()
        {
            DataRow partDataRow = ((DataRowView)cbLoaiXeTinhTienLuyTien.SelectedItem).Row;
            string partID = Convert.ToString(partDataRow["PartID"]);
            mComputerDTO = ComputerDAO.GetDataByPartIDAndParkingTypeID(partID, Constant.LOAI_GIU_XE_LUY_TIEN);
            if (mComputerDTO != null)
            {
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
        }

        private void updateTinhTienLuyTien()
        {
            if (mComputerDTO != null)
            {
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

                if (ComputerDAO.Update(mComputerDTO))
                {
                    MessageBox.Show(Constant.sMessageUpdateSuccess);
                    panelTinhTienLuyTien.Enabled = false;
                }
            }
        }

        private void loadDataTinhTienTongHop()
        {
            DataRow partDataRow = ((DataRowView)cbLoaiXeTinhTienTongHop.SelectedItem).Row;
            string partID = Convert.ToString(partDataRow["PartID"]);
            mComputerDTO = ComputerDAO.GetDataByPartIDAndParkingTypeID(partID, Constant.LOAI_GIU_XE_TONG_HOP);
            if (mComputerDTO != null)
            {
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
        }

        private void updateTinhTienTongHop()
        {
            if (mComputerDTO != null)
            {
                mComputerDTO.StartHourNight = (int) numericTinhTienTongHopStartHourNight.Value;
                mComputerDTO.EndHourNight = (int) numericTinhTienTongHopEndHourNight.Value;
                mComputerDTO.NightCost = (int) numericTinhTienTongHopNightCost.Value;

                mComputerDTO.HourMilestone1 = (int) numericTinhTienTongHopHourMilestone1.Value;
                mComputerDTO.CostMilestone1 = (int) numericTinhTienTongHopCostMilestone1.Value;
                mComputerDTO.HourMilestone2 = (int) numericTinhTienTongHopHourMilestone2.Value;
                mComputerDTO.CostMilestone2 = (int) numericTinhTienTongHopCostMilestone2.Value;

                mComputerDTO.CycleMilestone3 = trackBarTinhTienTongHopCycleMilestone3.Value;
                mComputerDTO.CostMilestone3 = (int) numericTinhTienTongHopCostMilestone3.Value;

                mComputerDTO.CycleTicketMonth = trackBarTinhTienTongHopCycleTicketMonth.Value;
                mComputerDTO.CostTicketMonth = (int) numericTinhTienTongHopCostTicketMonth.Value;

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

                if (ComputerDAO.Update(mComputerDTO))
                {
                    MessageBox.Show(Constant.sMessageUpdateSuccess);
                    panelTinhTienTongHop.Enabled = false;
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
            dgvPartList.DataSource = PartDAO.GetAllCommonData();
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
            partDTO.Id = tbPartIdCreate.Text;
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
            partDTO.Id = tbPartIdEdit.Text;
            partDTO.Name = tbPartNameEdit.Text;
            partDTO.Sign = tbPartSignEdit.Text;
            partDTO.Amount = int.Parse(tbPartAmountEdit.Text);

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
            } else if (tabQuanLyThe_LoaiXe.SelectedTab == tabQuanLyThe_LoaiXe.TabPages["tabPageKichHoatThe"])
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
            if (Index < Count - 1)
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
                int lastIdentify = 0;
                if (data.Rows.Count > 0)
                {
                    lastIdentify = data.Rows[data.Rows.Count - 1].Field<int>("Identify");
                }                
                tbCardIdentifyCreate.Text = lastIdentify + 1 + "";

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

            DataRow rowAllCard = data.NewRow();
            rowAllCard.SetField("PartName", "Tổng thẻ");
            rowAllCard.SetField("IsUsing", "Dùng & Không");
            rowAllCard.SetField("SumCard", CardDAO.GetCardCount());
            data.Rows.InsertAt(rowAllCard, 0);

            DataRow rowNotUsingCard = data.NewRow();
            rowNotUsingCard.SetField("PartName", "Tổng thẻ không dùng");
            rowNotUsingCard.SetField("IsUsing", Constant.sLabelCardNotUsing);
            rowNotUsingCard.SetField("SumCard", CardDAO.GetNotUsingCardCount());
            data.Rows.InsertAt(rowNotUsingCard, 1);

            DataRow rowUsingCard = data.NewRow();
            rowUsingCard.SetField("PartName", "Tổng thẻ đang dùng");
            rowUsingCard.SetField("IsUsing", Constant.sLabelCardUsing);
            rowUsingCard.SetField("SumCard", CardDAO.GetUsingCardCount());
            data.Rows.InsertAt(rowUsingCard, 2);

            dgvCardStatistic.DataSource = data;
        }

        private void loadPartDataToComboBox(ComboBox cb)
        {
            DataTable dt = PartDAO.GetAllCommonData();
            cb.DataSource = dt;
            cb.DisplayMember = "PartName";
            cb.ValueMember = "PartID";
        }

        private void loadTypeDataToComboBox(ComboBox cb)
        {
            DataTable dt = TypeDAO.GetAllData();
            cb.DataSource = dt;
            cb.DisplayMember = "TypeName";
            cb.ValueMember = "TypeID";
        }

        private void loadPartDataWithFieldAllToComboBox(ComboBox cb)
        {
            DataTable dt = PartDAO.GetAllCommonData();
            DataRow dr = dt.NewRow();
            dr["PartName"] = "Tất cả";
            dt.Rows.InsertAt(dr, 0);
            cb.DataSource = dt;
            cb.DisplayMember = "PartName";
            cb.ValueMember = "PartID";
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
                Convert.ToInt32(tbCardIdentifyCreate.Text.Trim());
            }
            catch (Exception e)
            {
                labelKetQuaTaoThe.Text = "Số thứ tự không hợp lệ";
                return false;
            }
            return true;
        }

        private void createCard()
        {
            CardDTO cardDTO = new CardDTO();
            try
            {
                cardDTO.Identify = Convert.ToInt32(tbCardIdentifyCreate.Text.Trim());
            }
            catch (Exception e)
            {

            }
            cardDTO.Id = tbCardIDCreate.Text.Trim();

            DataRow partDataRow = ((DataRowView)cbPartNameCreate.SelectedItem).Row;
            cardDTO.Type = Convert.ToInt32(partDataRow["PartID"]);

            string isUsing = "0";
            if (cbIsUsingCreate.Checked)
            {
                isUsing = "1";
            }
            cardDTO.IsUsing = isUsing;
            cardDTO.DayUnlimit = DateTime.Now;
            //cardDTO.SystemId = createCardAPI(cardDTO);
            cardDTO.SystemId = cardDTO.Id;

            DataTable dt = CardDAO.GetCardByID(cardDTO.Id);
            if (dt != null && dt.Rows.Count > 0)
            {
                labelKetQuaTaoThe.Text = "Thẻ đã tồn tại!";
                return;
            }
            if (CardDAO.Insert(cardDTO))
            {
                loadCardList();
                labelKetQuaTaoThe.Text = "Tạo thẻ thành công!";
                cardDTO.Identify = CardDAO.getIdentifyByCardID(cardDTO.Id);
                LogUtil.addLogTaoMoiThe(cardDTO);
            } else
            {
                labelKetQuaTaoThe.Text = "Thẻ đã tồn tại!";
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
            try
            {
                int.Parse(tbCardIdentifyEdit.Text.Trim());
            }
            catch (Exception e)
            {
                MessageBox.Show("Số thứ tự không hợp lệ");
                return false;
            }
            return true;
        }

        private void updateCard()
        {
            CardDTO cardDTO = new CardDTO();
            try
            {
                cardDTO.Identify = int.Parse(tbCardIdentifyEdit.Text.Trim());
            }
            catch (Exception e)
            {

            }
            cardDTO.Id = tbCardIDEdit.Text.Trim();

            DataRow partDataRow = ((DataRowView)cbPartNameEdit.SelectedItem).Row;
            cardDTO.Type = Convert.ToInt32(partDataRow["PartID"]);

            string isUsing = "0";
            if (cbIsUsingEdit.Checked)
            {
                isUsing = "1";
            }
            cardDTO.IsUsing = isUsing;
            cardDTO.DayUnlimit = DateTime.Now;

            CardDAO.Update(cardDTO);
            loadCardList();
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

        private void searchLostCard()
        {
            string key = tbLostCardSearch.Text;
            if (key.Equals(""))
            {
                loadLostCardList();
            } else
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
            } else
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

                loadUserDataToComboBox(cbNhanVienReport);

                //loadSaleReportData();
            } else if (tabQuanLy.SelectedTab == tabQuanLy.TabPages["tabPageQuanLyTheXeLoaiXe"])
            {
                loadCardList();
                loadPartDataToComboBox(cbPartNameCreate);
                loadPartDataToComboBox(cbPartNameEdit);
                loadTypeDataToComboBox(cbTypeNameCreate);

                loadCardStatistic();

                if (dgvCardList.DataSource != null && dgvCardList.CurrentRow != null)
                {
                    int Index = dgvCardList.CurrentRow.Index;
                    loadCardInfoFromDataGridViewRow(Index);
                }
            } else if (tabQuanLy.SelectedTab == tabQuanLy.TabPages["tabPageQuanLyXeRaVao"])
            {
                loadBlackCarList();
                loadConfig();
            } else if (tabQuanLy.SelectedTab == tabQuanLy.TabPages["tabPageQuanLyVeThang"])
            {
                loadTabPageTicketLog();
                setFormatDateForDateTimePicker(dtTicketLogRegistrationDateSearch);
                setFormatDateForDateTimePicker(dtTicketLogExpirationDateSearch);
                dtTicketLogExpirationDateSearch.Value = DateTime.Now.AddMonths(1);
            } else if (tabQuanLy.SelectedTab == tabQuanLy.TabPages["tabPageQuanLyHeThong"])
            {
                addDataToRFIDComboBox();
                loadCauHinhHienThiData();
                hienCauHinhKetNoiTuConfig();
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
            if (checkUpdateCardData())
            {
                updateCard();
                loadCardStatistic();
            }
        }

        private void dgvCardList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = e.RowIndex;
            int Count = dgvCardList.Rows.Count;
            if (Index < Count - 1)
            {
                loadCardInfoFromDataGridViewRow(Index);
            }

            if (e.RowIndex < 0) return;
            var dataGridView = (DataGridView)sender;
            var cell = dataGridView["SelectCard", e.RowIndex];
            if (cell.Value == null)
            {
                cell.Value = false;
            }
            cell.Value = !(bool)cell.Value;
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
            loadTicketLogData();
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
            if (!string.IsNullOrWhiteSpace(tbRenewTicketMonthDaysRemainingSearch.Text)) {
                int daysRemaining = 0;
                if (int.TryParse(tbRenewTicketMonthDaysRemainingSearch.Text, out daysRemaining))
                {
                    //if (daysRemaining < 0)
                    //{
                    //    MessageBox.Show(Constant.sMessageInvalidError);
                    //    return;
                    //}
                }
                else
                {
                    MessageBox.Show(Constant.sMessageInvalidError);
                    return;
                }
                dgvRenewTicketMonthList.DataSource = TicketMonthDAO.searchNearExpiredTicketData(key, daysRemaining);
            } else
            {
                dgvRenewTicketMonthList.DataSource = TicketMonthDAO.searchNearExpiredTicketData(key, null);
            }
            
        }

        private void searchTicketLogData()
        {
            string key = tbTicketLogKeyWordSearch.Text;
            string ticketLogID = null;
            if (cbTicketLogNameSearch.SelectedIndex > 0)
            {
                DataRow ticketLoDataRow = ((DataRowView) cbTicketLogNameSearch.SelectedItem).Row;
                ticketLogID = Convert.ToString(ticketLoDataRow["LogTypeID"]);
            }
            string partID = null;
            if (cbPartNameTicketLogSearch.SelectedIndex > 0)
            {
                DataRow partDataRow = ((DataRowView) cbPartNameTicketLogSearch.SelectedItem).Row;
                partID = Convert.ToString(partDataRow["PartID"]);
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
            int lastIdentify = 0;
            if (data != null && data.Rows.Count > 0)
            {
                lastIdentify = data.Rows[data.Rows.Count - 1].Field<int>("Identify");
            }
            tbTicketMonthIdentifyCreate.Text = lastIdentify + 1 + "";

            if (data != null && data.Rows.Count > 0)
            {
                loadTicketMonthInfoFromDataGridViewRow(0);
            }
        }

        private void loadRenewTicketMonthData()
        {
            DataTable data = TicketMonthDAO.GetAllNearExpiredTicketData(DateTime.Now);
            dgvRenewTicketMonthList.DataSource = data;
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
                loadPartDataToComboBox(cbTicketMonthPartCreate);
                loadPartDataToComboBox(cbTicketMonthPartEdit);
                clearInputTicketMonthInfo();
                setFormatDateForDateTimePicker(dateTimePickerTicketMonthRegistrationDateCreate);
                setFormatDateForDateTimePicker(dateTimePickerTicketMonthExpirationDateCreate);
                setFormatDateForDateTimePicker(dateTimePickerTicketMonthRegistrationDateEdit);
                setFormatDateForDateTimePicker(dateTimePickerTicketMonthExpirationDateEdit);
            } else if (tabQuanLyVeThang.SelectedTab == tabQuanLyVeThang.TabPages["tabPageGiaHanVeThang"])
            {
                loadRenewTicketMonthData();
                setFormatDateForDateTimePicker(dtRenewDate);
                setFormatDateForDateTimePicker(dtRenewExpirationDate);
                dtRenewExpirationDate.Value = DateTime.Now.AddMonths(1);
            } else if (tabQuanLyVeThang.SelectedTab == tabQuanLyVeThang.TabPages["tabPageMatVeThang"])
            {
                searchLostTicketMonth();
            } else if (tabQuanLyVeThang.SelectedTab == tabQuanLyVeThang.TabPages["tabPageKichHoatVeThang"])
            {
                searchActiveTicketMonth();
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

            ticketMonthDTO.Identify = Convert.ToInt32(tbTicketMonthIdentifyCreate.Text);
            ticketMonthDTO.Id = tbTicketMonthIDCreate.Text;
            ticketMonthDTO.ProcessDate = DateTime.Now;
            ticketMonthDTO.Digit = tbTicketMonthDigitCreate.Text;
            ticketMonthDTO.CustomerName = tbTicketMonthCustomerNameCreate.Text;
            ticketMonthDTO.Cmnd = tbTicketMonthCMNDCreate.Text;
            ticketMonthDTO.Company = tbTicketMonthCompanyCreate.Text;
            ticketMonthDTO.Email = tbTicketMonthEmailCreate.Text;
            ticketMonthDTO.Address = tbTicketMonthAddressCreate.Text;
            ticketMonthDTO.CarKind = tbTicketMonthCarKindCreate.Text;

            DataRow dataRow = ((DataRowView)cbTicketMonthPartCreate.SelectedItem).Row;
            ticketMonthDTO.IdPart = Convert.ToString(dataRow["PartID"]);

            ticketMonthDTO.Account = Program.CurrentUserID;
            ticketMonthDTO.RegistrationDate = dateTimePickerTicketMonthRegistrationDateCreate.Value.Date;
            ticketMonthDTO.ExpirationDate = dateTimePickerTicketMonthExpirationDateCreate.Value.Date;
            ticketMonthDTO.ChargesAmount = tbTicketMonthChargesAmountCreate.Text;
            ticketMonthDTO.Status = 0;
            ticketMonthDTO.DayUnlimit = DateTime.Now;

            TicketMonthDAO.Insert(ticketMonthDTO);
            clearInputTicketMonthInfo();
            loadTicketMonthData();

            addTicketLog(Constant.LOG_TYPE_CREATE_TICKET_MONTH, ticketMonthDTO);
        }

        private void updateTicketMonth()
        {
            TicketMonthDTO ticketMonthDTO = new TicketMonthDTO();
            ticketMonthDTO.Identify = Convert.ToInt32(tbTicketMonthIdentifyEdit.Text);
            ticketMonthDTO.Id = tbTicketMonthIDEdit.Text;
            ticketMonthDTO.ProcessDate = DateTime.Now;
            ticketMonthDTO.Digit = tbTicketMonthDigitEdit.Text;
            ticketMonthDTO.CustomerName = tbTicketMonthCustomerNameEdit.Text;
            ticketMonthDTO.Cmnd = tbTicketMonthCMNDEdit.Text;
            ticketMonthDTO.Company = tbTicketMonthCompanyEdit.Text;
            ticketMonthDTO.Email = tbTicketMonthEmailEdit.Text;
            ticketMonthDTO.Address = tbTicketMonthAddressEdit.Text;
            ticketMonthDTO.CarKind = tbTicketMonthCarKindEdit.Text;

            DataRow dataRow = ((DataRowView)cbTicketMonthPartEdit.SelectedItem).Row;
            ticketMonthDTO.IdPart = Convert.ToString(dataRow["PartID"]);

            ticketMonthDTO.Account = Program.CurrentUserID;
            ticketMonthDTO.RegistrationDate = dateTimePickerTicketMonthRegistrationDateEdit.Value.Date;
            ticketMonthDTO.ExpirationDate = dateTimePickerTicketMonthExpirationDateEdit.Value.Date;
            ticketMonthDTO.ChargesAmount = tbTicketMonthChargesAmountEdit.Text;
            ticketMonthDTO.Status = 0;
            ticketMonthDTO.DayUnlimit = DateTime.Now;

            TicketMonthDAO.Update(ticketMonthDTO);
            loadTicketMonthData();

            addTicketLog(Constant.LOG_TYPE_UPDATE_TICKET_MONTH, ticketMonthDTO);
        }

        private void clearInputTicketMonthInfo()
        {
            tbTicketMonthIDCreate.Text = "";
            tbTicketMonthDigitCreate.Text = "";
            tbTicketMonthCustomerNameCreate.Text = "";
            tbTicketMonthCMNDCreate.Text = "";
            tbTicketMonthCompanyCreate.Text = "";
            tbTicketMonthEmailCreate.Text = "";
            tbTicketMonthAddressCreate.Text = "";
            tbTicketMonthCarKindCreate.Text = "";

            cbTicketMonthPartCreate.SelectedIndex = 0;

            dateTimePickerTicketMonthRegistrationDateCreate.Value = DateTime.Now;
            dateTimePickerTicketMonthExpirationDateCreate.Value = DateTime.Now.AddMonths(1);
            tbTicketMonthChargesAmountCreate.Text = "";
        }

        private bool checkCreateTicketMonthData()
        {
            if (string.IsNullOrWhiteSpace(tbTicketMonthIDCreate.Text))
            {
                MessageBox.Show(Constant.sMessageTicketMonthIdNullError);
                return false;
            }
            DataTable dtCard = CardDAO.GetCardByID(tbTicketMonthIDCreate.Text);
            if (dtCard == null || dtCard.Rows.Count == 0)
            {
                MessageBox.Show(Constant.sMessageCardIdNotExist);
                return false;
            }
            if (!CardDAO.isUsingByCardID(tbTicketMonthIDCreate.Text))
            {
                MessageBox.Show(Constant.sMessageCardIsLost);
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbTicketMonthDigitCreate.Text))
            {
                MessageBox.Show(Constant.sMessageTicketMonthDigitNullError);
                return false;
            }
            return true;
        }

        private bool checkUpdateTicketMonthData()
        {
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
            string email = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["Email"].Value);
            tbTicketMonthEmailEdit.Text = email;
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
            dgvActiveTicketMonthList.DataSource = TicketMonthDAO.searchActiveTicketData(key);
        }

        private void deleteTicketMonth()
        {
            foreach (DataGridViewRow row in dgvTicketMonthList.Rows)
            {
                DataGridViewCheckBoxCell checkCell = row.Cells["SelectTicketMonth"] as DataGridViewCheckBoxCell;
                object value = checkCell.Value;
                if (value != null && (Boolean)value)
                {
                    string id = Convert.ToString(row.Cells["TicketMonthID"].Value);
                    if (TicketMonthDAO.Delete(id))
                    {
                        addDeleteTicketMonthToLog(row.Index);
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
            int identify = Convert.ToInt32(dgvTicketMonthList.Rows[Index].Cells["TicketMonthIdentify"].Value);
            ticketMonthDTO.Id = id;
            ticketMonthDTO.Identify = identify;
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
            ticketMonthDTO.Account = Program.CurrentUserID;
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
            if (Index < Count - 1)
            {
                loadTicketMonthInfoFromDataGridViewRow(Index);
            }

            if (e.RowIndex < 0) return;
            var dataGridView = (DataGridView)sender;
            var cell = dataGridView["SelectTicketMonth", e.RowIndex];
            if (cell.Value == null)
            {
                cell.Value = false;
            }
            cell.Value = !(bool)cell.Value;
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
            if (Index < Count - 1)
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
            TicketMonthDAO.updateTicketByID(id, identify);
            searchLostTicketMonth();
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
                string filePath = Constant.IMAGE_FOLDER + image1;
                if (File.Exists(filePath))
                {
                    pictureBoxCarLogImage1.Image = Image.FromFile(filePath);
                }
            }
            string image2 = Convert.ToString(dgvCarList.Rows[Index].Cells["CarLogImages2"].Value);
            if (!string.IsNullOrEmpty(image2))
            {
                string filePath = Constant.IMAGE_FOLDER + image2;
                if (File.Exists(filePath))
                {
                    pictureBoxCarLogImage2.Image = Image.FromFile(filePath);
                }
            }
            string image3 = Convert.ToString(dgvCarList.Rows[Index].Cells["CarLogImages3"].Value);
            if (!string.IsNullOrEmpty(image3))
            {
                string filePath = Constant.IMAGE_FOLDER + image3;
                if (File.Exists(filePath))
                {
                    pictureBoxCarLogImage3.Image = Image.FromFile(filePath);
                }
            }
            string image4 = Convert.ToString(dgvCarList.Rows[Index].Cells["CarLogImages4"].Value);
            if (!string.IsNullOrEmpty(image4))
            {
                string filePath = Constant.IMAGE_FOLDER + image4;
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
            if (Index < Count - 1)
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
            tbBikeSpace.Text = ConfigDAO.GetBikeSpace().ToString();
            tbCarSpace.Text = ConfigDAO.GetCarSpace().ToString();
            tbTicketLimitDay.Text = ConfigDAO.GetTicketMonthLimit().ToString();
            tbNightLimit.Text = ConfigDAO.GetNightLimit().ToString();
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
                carDTO.IdPart = Convert.ToString(dataRow["PartID"]);
            }
            try
            {
                carDTO.CardIdentify = Convert.ToInt32(tbCardIdentifySearchCar.Text);
            } catch (Exception e)
            {

            }
            carDTO.Digit = tbCarDigitSearch.Text;
            carDTO.Id = tbCarIDSearch.Text;
            if (comboBoxNhanVienVao.SelectedIndex > 0)
            {
                DataRow dataRow = ((DataRowView) comboBoxNhanVienVao.SelectedItem).Row;
                carDTO.IdIn = Convert.ToString(dataRow["UserID"]);
            }
            if (comboBoxNhanVienRa.SelectedIndex > 0)
            {
                DataRow dataRow = ((DataRowView)comboBoxNhanVienRa.SelectedItem).Row;
                carDTO.IdOut = Convert.ToString(dataRow["UserID"]);
            }

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

        private void searchCarByDateTime(DateTime startDate, DateTime endDate)
        {
            CarDTO carDTO = new CarDTO();
            carDTO.TimeStart = startDate;
            carDTO.TimeEnd = endDate;

            DataTable data = CarDAO.searchAllData(carDTO);
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
            DataRow dr = dt.NewRow();
            dr["NameUser"] = "Tất cả";
            dt.Rows.InsertAt(dr, 0);
            cb.DataSource = dt;
            cb.DisplayMember = "NameUser";
            cb.ValueMember = "UserID";
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

            } else if (tabQuanLyXe.SelectedTab == tabQuanLyXe.TabPages["tabPageTraCuuVaoRaVeThang"])
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
            } else
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
            } else
            {
                MessageBox.Show(Constant.sMessageInvalidError);
                return;
            }


            int ticketLimitDay = -1;
            if (int.TryParse(tbTicketLimitDay.Text, out ticketLimitDay))
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
            } else
            {
                MessageBox.Show(Constant.sMessageInvalidError);
                return;
            }


            int nightLimit = -1;
            if (int.TryParse(tbNightLimit.Text, out nightLimit))
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

            ConfigDAO.UpdateCauHinhHienThi(configDTO);
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
                int identify = Convert.ToInt32(row.Cells["RenewIdentify"].Value);
                if (isChoose)
                {
                    TicketMonthDAO.updateTicketByExpirationDate(expirationDate, identify);
                }
            }
            loadRenewTicketMonthData();
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
            } else
            {
                MessageBox.Show(Constant.sMessageRenewPlusDateInvalidError);
                return;
            }
            foreach (DataGridViewRow row in dgvRenewTicketMonthList.Rows)
            {
                bool isChoose = Convert.ToBoolean(row.Cells["RenewIsChosen"].Value);
                int identify = Convert.ToInt32(row.Cells["RenewIdentify"].Value);
                DateTime expirationDate = Convert.ToDateTime(row.Cells["RenewExpirationDate"].Value);
                expirationDate = expirationDate.AddDays(plusDate);
                if (isChoose)
                {
                    TicketMonthDAO.updateTicketByExpirationDate(expirationDate, identify);
                }
            }
            loadRenewTicketMonthData();
        }

        private void btnSaveLostCard_Click(object sender, EventArgs e)
        {
            saveLostCard();
        }

        private void saveLostCard()
        {
            string functionId = UserDAO.GetFunctionIDByUserID(Program.CurrentUserID);
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
            upDateLostTicketMonth();
        }

        /*
         *System management
         */

        private void btnLuuCauHinhHienThi_Click(object sender, EventArgs e)
        {
            saveCauHinhHienThi();
        }

        private void loadCauHinhHienThiData()
        {
            int parkingTypeID = ConfigDAO.GetParkingTypeID();
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
                default:
                    rbGiuXeTheoCongVan.Checked = true;
                    break;
            }

            tbLostCard.Text = ConfigDAO.GetLostCard().ToString();
            tbBikeSpace2.Text = ConfigDAO.GetBikeSpace().ToString();
            tbCarSpace2.Text = ConfigDAO.GetCarSpace().ToString();
            tbTicketLimitDay2.Text = ConfigDAO.GetTicketMonthLimit().ToString();
            tbNightLimit2.Text = ConfigDAO.GetNightLimit().ToString();

            loadQuyenNhanVien();

            int expiredTicketMonthTypeID = ConfigDAO.GetExpiredTicketMonthTypeID();
            switch (expiredTicketMonthTypeID)
            {
                case Constant.LOAI_HET_HAN_CHI_CANH_BAO_HET_HAN:
                    rbChiCanhBaoHetHan.Checked = true;
                    break;
                case Constant.LOAI_HET_HAN_TINH_TIEN_NHU_VANG_LAI:
                default:
                    rbTinhTienNhuVangLai.Checked = true;
                    break;
            }
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
            } else if (rbGiuXeTheoCongVan.Checked)
            {
                parkingTypeID = Constant.LOAI_GIU_XE_THEO_CONG_VAN;
            } else if (rbGiuXeLuyTien.Checked)
            {
                parkingTypeID = Constant.LOAI_GIU_XE_LUY_TIEN;
            } else if (rbGiuXeTongHop.Checked)
            {
                parkingTypeID = Constant.LOAI_GIU_XE_TONG_HOP;
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
            configDTO.ExpiredTicketMonthTypeID = expiredTicketMonthTypeID;

            int lostCard = -1;
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
            DataRow dataRow = ((DataRowView) cbLogType.SelectedItem).Row;
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
                loadCarListForCashManagement();
                setFormatDateForDateTimePicker(dtCashManagementStartDate);
                setFormatDateForDateTimePicker(dtCashManagementEndDate);
            }
            else if(tabQuanLyHeThong.SelectedTab == tabQuanLyHeThong.TabPages["tabPageQuanLyThuTienXe"])
            {
                loadCarListForCashManagement();
                setFormatDateForDateTimePicker(dtCashManagementStartDate);
                setFormatDateForDateTimePicker(dtCashManagementEndDate);
            } else if (tabQuanLyHeThong.SelectedTab == tabQuanLyHeThong.TabPages["tabPagePhanQuyenTruyCap"])
            {
                loadUserAcessData();
            } else if (tabQuanLyHeThong.SelectedTab == tabQuanLyHeThong.TabPages["tabPageNhatKyHeThong"])
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
            string functionID = UserDAO.GetFunctionIDByUserID(Program.CurrentUserID);
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
            if (countTabQuanLyDoanhThu == 0)
            {
                tabQuanLy.TabPages.Remove(tabPageQuanLyDoanhThu);
            }

            int countTabQuanLyTheXeLoaiXe = 0;
            countTabQuanLyTheXeLoaiXe += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_QUAN_LY_THE_XE, tabPageQuanLyTheXe, tabQuanLyThe_LoaiXe);
            countTabQuanLyTheXeLoaiXe += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_QUAN_LY_LOAI_XE, tabPageQuanLyLoaiXe, tabQuanLyThe_LoaiXe);
            countTabQuanLyTheXeLoaiXe += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_KICH_HOAT_THE, tabPageKichHoatThe, tabQuanLyThe_LoaiXe);
            if (countTabQuanLyTheXeLoaiXe == 0)
            {
                tabQuanLy.TabPages.Remove(tabPageQuanLyTheXeLoaiXe);
            }

            int countTabQuanLyVeThang = 0;
            countTabQuanLyVeThang += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_NHAT_KY_VE_THANG, tabPageXemNhatKyVeThang, tabQuanLyVeThang);
            countTabQuanLyVeThang += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_CAP_NHAT_THONG_TIN_VE_THANG, tabPageTaoMoiVeThang, tabQuanLyVeThang);
            countTabQuanLyVeThang += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_GIA_HAN_VE_THANG, tabPageGiaHanVeThang, tabQuanLyVeThang);
            countTabQuanLyVeThang += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_MAT_THE_THANG, tabPageMatVeThang, tabQuanLyVeThang);
            countTabQuanLyVeThang += checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_KICH_HOAT_VE_THANG, tabPageKichHoatVeThang, tabQuanLyVeThang);
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
            if (Index < Count - 1)
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

        private void exportDanhSachXeToExcel(int cellRowIndex, int cellColumnIndex)
        {
            int firstRowIndex = cellRowIndex;
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Danh sách xe ra vào";

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dgvCarList.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvCarList.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[cellRowIndex, cellColumnIndex];
                        if (cellRowIndex == firstRowIndex)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvCarList.Columns[j].HeaderText;
                            setColerForRange(range);
                            setAllBorderForRange(range);
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvCarList.Rows[i].Cells[j].Value.ToString();
                            setLeftBorderForRange(range);
                            setRightBorderForRange(range);
                            if (i == dgvCarList.Rows.Count - 2)
                            {
                                setBottomBorderForRange(range);
                            }
                        }

                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                excel.Columns.AutoFit();


                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show(Constant.sMessageExportExcelSuccess);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }

        private void exportDanhSachXeThangToExcel(int cellRowIndex, int cellColumnIndex)
        {
            int firstRowIndex = cellRowIndex;
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Danh sách xe ra vào";

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dgvCarTicketMonthList.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvCarTicketMonthList.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[cellRowIndex, cellColumnIndex];
                        if (cellRowIndex == firstRowIndex)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvCarTicketMonthList.Columns[j].HeaderText;
                            setColerForRange(range);
                            setAllBorderForRange(range);
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvCarTicketMonthList.Rows[i].Cells[j].Value.ToString();
                            setLeftBorderForRange(range);
                            setRightBorderForRange(range);
                            if (i == dgvCarTicketMonthList.Rows.Count - 2)
                            {
                                setBottomBorderForRange(range);
                            }
                        }

                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                excel.Columns.AutoFit();


                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show(Constant.sMessageExportExcelSuccess);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }

        private void exportBangChamCongToExcel(int cellRowIndex, int cellColumnIndex)
        {
            int firstRowIndex = cellRowIndex;
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Sheet1";

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dgvWorkList.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvWorkList.Columns.Count; j++)
                    {
                        if (dgvWorkList.Columns[j].Visible)
                        {
                            // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                            Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[cellRowIndex, cellColumnIndex];
                            if (cellRowIndex == firstRowIndex)
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvWorkList.Columns[j].HeaderText;
                                setColerForRange(range);
                                setAllBorderForRange(range);
                            }
                            else
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvWorkList.Rows[i].Cells[j].Value.ToString();
                                setLeftBorderForRange(range);
                                setRightBorderForRange(range);
                                if (i == dgvWorkList.Rows.Count - 2)
                                {
                                    setBottomBorderForRange(range);
                                }
                            }
                            cellColumnIndex++;
                        }
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                excel.Columns.AutoFit();


                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.InitialDirectory = Environment.CurrentDirectory;
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FilterIndex = 2;
                saveDialog.FileName = "Export_cham_cong_" + Util.getCurrentDateTimeString();

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
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }

        private void exportDoanhThuTongQuatToExcel(int cellRowIndex, int cellColumnIndex)
        {
            int firstRowIndex = cellRowIndex;
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Sheet1";

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dgvThongKeDoanhThu.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvThongKeDoanhThu.Columns.Count; j++)
                    {
                        if (dgvThongKeDoanhThu.Columns[j].Visible)
                        {
                            // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                            Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[cellRowIndex, cellColumnIndex];
                            if (cellRowIndex == firstRowIndex)
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvThongKeDoanhThu.Columns[j].HeaderText;
                                setColerForRange(range);
                                setAllBorderForRange(range);
                            }
                            else
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvThongKeDoanhThu.Rows[i].Cells[j].Value.ToString();
                                setLeftBorderForRange(range);
                                setRightBorderForRange(range);
                                if (i == dgvThongKeDoanhThu.Rows.Count - 2)
                                {
                                    setBottomBorderForRange(range);
                                }
                            }
                            cellColumnIndex++;
                        }
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                excel.Columns.AutoFit();


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
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }

        private void exportDoanhSachTheXeToExcel(int cellRowIndex, int cellColumnIndex)
        {
            int firstRowIndex = cellRowIndex;
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Sheet1";

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dgvCardStatistic.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvCardStatistic.Columns.Count; j++)
                    {
                        if (dgvCardStatistic.Columns[j].Visible)
                        {
                            // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                            Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[cellRowIndex, cellColumnIndex];
                            if (cellRowIndex == firstRowIndex)
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvCardStatistic.Columns[j].HeaderText;
                                setColerForRange(range);
                                setAllBorderForRange(range);
                            }
                            else
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvCardStatistic.Rows[i].Cells[j].Value.ToString();
                                setLeftBorderForRange(range);
                                setRightBorderForRange(range);
                                if (i == dgvCardStatistic.Rows.Count - 2)
                                {
                                    setBottomBorderForRange(range);
                                }
                            }
                            cellColumnIndex++;
                        }
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                cellRowIndex = dgvCardStatistic.Rows.Count + 2;
                firstRowIndex = cellRowIndex;
                for (int i = 0; i < dgvCardList.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvCardList.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[cellRowIndex, cellColumnIndex];
                        if (cellRowIndex == firstRowIndex)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvCardList.Columns[j].HeaderText;
                            setColerForRange(range);
                            setAllBorderForRange(range);
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvCardList.Rows[i].Cells[j].Value.ToString();
                            setLeftBorderForRange(range);
                            setRightBorderForRange(range);
                            if (i == dgvCardList.Rows.Count - 2)
                            {
                                setBottomBorderForRange(range);
                            }
                        }

                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                excel.Columns.AutoFit();

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show(Constant.sMessageExportExcelSuccess);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }

        private void exportNhatKyVeThangToExcel(int cellRowIndex, int cellColumnIndex)
        {
            int firstRowIndex = cellRowIndex;
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Sheet1";

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dgvTicketLogList.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvTicketLogList.Columns.Count; j++)
                    {
                        if (dgvTicketLogList.Columns[j].Visible)
                        {
                            // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                            Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[cellRowIndex, cellColumnIndex];
                            if (cellRowIndex == firstRowIndex)
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvTicketLogList.Columns[j].HeaderText;
                                setColerForRange(range);
                                setAllBorderForRange(range);
                            }
                            else
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvTicketLogList.Rows[i].Cells[j].Value.ToString();
                                setLeftBorderForRange(range);
                                setRightBorderForRange(range);
                                if (i == dgvTicketLogList.Rows.Count - 2)
                                {
                                    setBottomBorderForRange(range);
                                }
                            }
                            cellColumnIndex++;
                        }
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                excel.Columns.AutoFit();


                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show(Constant.sMessageExportExcelSuccess);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }

        private void exportDanhSachTheHetHanToExcel(int cellRowIndex, int cellColumnIndex)
        {
            int firstRowIndex = cellRowIndex;
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Sheet1";

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dgvRenewTicketMonthList.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvRenewTicketMonthList.Columns.Count; j++)
                    {
                        if (j == 0)
                        {
                            continue;
                        }
                        if (dgvRenewTicketMonthList.Columns[j].Visible)
                        {
                            // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                            Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[cellRowIndex, cellColumnIndex];
                            if (cellRowIndex == firstRowIndex)
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvRenewTicketMonthList.Columns[j].HeaderText;
                                setColerForRange(range);
                                setAllBorderForRange(range);
                            }
                            else
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvRenewTicketMonthList.Rows[i].Cells[j].Value.ToString();
                                setLeftBorderForRange(range);
                                setRightBorderForRange(range);
                                if (i == dgvRenewTicketMonthList.Rows.Count - 2)
                                {
                                    setBottomBorderForRange(range);
                                }
                            }
                            cellColumnIndex++;
                        }
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                excel.Columns.AutoFit();


                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show(Constant.sMessageExportExcelSuccess);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }

        private void exportNhatKyHeThongToExcel(int cellRowIndex, int cellColumnIndex)
        {
            int firstRowIndex = cellRowIndex;
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Sheet1";

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dgvLogList.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvLogList.Columns.Count; j++)
                    {
                        if (dgvLogList.Columns[j].Visible)
                        {
                            // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                            Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[cellRowIndex, cellColumnIndex];
                            if (cellRowIndex == firstRowIndex)
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvLogList.Columns[j].HeaderText;
                                setColerForRange(range);
                                setAllBorderForRange(range);
                            }
                            else
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvLogList.Rows[i].Cells[j].Value.ToString();
                                setLeftBorderForRange(range);
                                setRightBorderForRange(range);
                                if (i == dgvLogList.Rows.Count - 2)
                                {
                                    setBottomBorderForRange(range);
                                }
                            }
                            cellColumnIndex++;
                        }
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                excel.Columns.AutoFit();


                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show(Constant.sMessageExportExcelSuccess);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }

        private void exportDoanhThuChiTietToExcel(int cellRowIndex, int cellColumnIndex)
        {
            int firstRowIndex = cellRowIndex;
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Sheet1";

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dgvThongKeDoanhThu.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvThongKeDoanhThu.Columns.Count; j++)
                    {
                        if (dgvThongKeDoanhThu.Columns[j].Visible)
                        {
                            // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                            Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[cellRowIndex, cellColumnIndex];
                            if (cellRowIndex == firstRowIndex)
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvThongKeDoanhThu.Columns[j].HeaderText;
                                setColerForRange(range);
                                setAllBorderForRange(range);
                            }
                            else
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvThongKeDoanhThu.Rows[i].Cells[j].Value.ToString();
                                setLeftBorderForRange(range);
                                setRightBorderForRange(range);
                                if (i == dgvThongKeDoanhThu.Rows.Count - 2)
                                {
                                    setBottomBorderForRange(range);
                                }
                            }
                            cellColumnIndex++;
                        }
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                cellRowIndex = dgvThongKeDoanhThu.Rows.Count + 2;
                firstRowIndex = cellRowIndex;
                for (int i = 0; i < dgvCarList.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvCarList.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[cellRowIndex, cellColumnIndex];
                        if (cellRowIndex == firstRowIndex)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvCarList.Columns[j].HeaderText;
                            setColerForRange(range);
                            setAllBorderForRange(range);
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvCarList.Rows[i].Cells[j].Value.ToString();
                            setLeftBorderForRange(range);
                            setRightBorderForRange(range);
                            if (i == dgvCarList.Rows.Count - 2)
                            {
                                setBottomBorderForRange(range);
                            }
                        }

                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                excel.Columns.AutoFit();

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.InitialDirectory = Environment.CurrentDirectory;
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FilterIndex = 2;
                saveDialog.FileName = "Export_thongke_doanhthu_chitiet_" + Util.getCurrentDateTimeString();

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
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }

        private void exportDanhSachTheThangToExcel(int cellRowIndex, int cellColumnIndex)
        {
            int firstRowIndex = cellRowIndex;
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Sheet1";

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dgvTicketMonthList.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvTicketMonthList.Columns.Count; j++)
                    {
                        if (dgvTicketMonthList.Columns[j].Visible)
                        {
                            // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                            Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[cellRowIndex, cellColumnIndex];
                            if (cellRowIndex == firstRowIndex)
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvTicketMonthList.Columns[j].HeaderText;
                                setColerForRange(range);
                                setAllBorderForRange(range);
                            }
                            else
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvTicketMonthList.Rows[i].Cells[j].Value.ToString();
                                setLeftBorderForRange(range);
                                setRightBorderForRange(range);
                                if (i == dgvTicketMonthList.Rows.Count - 2)
                                {
                                    setBottomBorderForRange(range);
                                }
                            }
                            cellColumnIndex++;
                        }
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                excel.Columns.AutoFit();


                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show(Constant.sMessageExportExcelSuccess);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
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

        private void setAllBorderForRange(Microsoft.Office.Interop.Excel.Range range)
        {
            setLeftBorderForRange(range);
            setRightBorderForRange(range);
            setTopBorderForRange(range);
            setBottomBorderForRange(range);
        }

        private void setColerForRange(Microsoft.Office.Interop.Excel.Range range)
        {
            range.Font.Color = ColorTranslator.ToOle(Color.Blue);
            range.Font.Bold = true;
        }

        private void btnExportDoanhThuTongQuat_Click(object sender, EventArgs e)
        {
            exportDoanhThuTongQuatToExcel(1, 1);
        }

        private void btnExportDoanhThuChiTiet_Click(object sender, EventArgs e)
        {
            exportDoanhThuChiTietToExcel(1, 1);
        }

        private void btnExportBangChamCong_Click(object sender, EventArgs e)
        {
            exportBangChamCongToExcel(1, 1);
        }

        private void btnExportDanhSachTheXe_Click(object sender, EventArgs e)
        {
            exportDoanhSachTheXeToExcel(1, 1);
        }

        private void btnExportNhatKyVeThang_Click(object sender, EventArgs e)
        {
            exportNhatKyVeThangToExcel(1, 1);
        }

        private void btnExportDanhSachTheHetHan_Click(object sender, EventArgs e)
        {
            exportDanhSachTheHetHanToExcel(1, 1);
        }

        private void btnExportNhatKyHeThong_Click(object sender, EventArgs e)
        {
            exportNhatKyHeThongToExcel(1, 1);
        }

        private void btnExportDanhSachXe_Click(object sender, EventArgs e)
        {
            exportDanhSachXeToExcel(1, 1);
        }

        private void btnExportDanhSachXeThang_Click(object sender, EventArgs e)
        {
            exportDanhSachXeThangToExcel(1, 1);
        }

        void Delete_Card_Click(Object sender, System.EventArgs e, int currentRow)
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
                    int identify = CardDAO.getIdentifyByCardID(cardId);
                    if (CardDAO.Delete(cardId))
                    {
                        LogUtil.addLogXoaThe(identify, cardId);
                    }
                }
                //if (Convert.ToBoolean(checkCell.Value) == true)
                //{
                //    string cardId = Convert.ToString(row.Cells["CardID"].Value);
                //    CardDAO.Delete(cardId);
                //}
            }
            loadCardList();
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
            PartDAO.Delete(partID);
            loadPartList();
            LogUtil.addLogXoaLoaiXe(partID, partName);
        }

        private void btnExportDanhSachVeThang_Click(object sender, EventArgs e)
        {
            exportDanhSachTheThangToExcel(1, 1);
        }

        private void addDataToRFIDComboBox()
        {

        }

        private void tbCardIDCreate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !tbCardIDCreate.Text.Equals(null))
            {
                if (checkCreateCardData())
                {
                    createCard();
                    loadCardStatistic();
                    tbCardIDCreate.Text = "";
                }
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
            //try
            //{
            //    String filePath = Application.StartupPath + "\\" + Constant.sFileNameConfig;
            //    if (File.Exists(filePath))
            //    {
            //        Config config = new Config();
            //        config.cameraUrl1 = Constant.sEncodeStart + tb_camera_url_1.Text + Constant.sEncodeEnd;
            //        config.cameraUrl2 = Constant.sEncodeStart + tb_camera_url_2.Text + Constant.sEncodeEnd;
            //        config.cameraUrl3 = Constant.sEncodeStart + tb_camera_url_3.Text + Constant.sEncodeEnd;
            //        config.cameraUrl4 = Constant.sEncodeStart + tb_camera_url_4.Text + Constant.sEncodeEnd;
            //        config.rfidIn = Constant.sEncodeStart + tb_rfid_1.Text + Constant.sEncodeEnd;
            //        config.rfidOut = Constant.sEncodeStart + tb_rfid_2.Text + Constant.sEncodeEnd;
            //        XmlSerializer xs = new XmlSerializer(typeof(Config));
            //        TextWriter txtWriter = new StreamWriter(filePath);
            //        xs.Serialize(txtWriter, config);
            //        txtWriter.Close();
            //        this.ActiveControl = null;
            //        MessageBox.Show(Constant.sMessageUpdateSuccess);
            //    }
            //}
            //catch (Exception e)
            //{

            //}
            ConfigDTO configDTO = new ConfigDTO();
            configDTO.Camera1 = tb_camera_url_1.Text;
            configDTO.Camera2 = tb_camera_url_2.Text;
            configDTO.Camera3 = tb_camera_url_3.Text;
            configDTO.Camera4 = tb_camera_url_4.Text;
            configDTO.Rfid1 = tb_rfid_1.Text;
            configDTO.Rfid2 = tb_rfid_2.Text;
            ConfigDAO.UpdateCauHinhKetNoi(configDTO);
            this.ActiveControl = null;
            MessageBox.Show(Constant.sMessageUpdateSuccess);
        }

        private void hienCauHinhKetNoiTuConfig()
        {
            //try
            //{
            //    String filePath = Application.StartupPath + "\\" + Constant.sFileNameConfig;
            //    if (File.Exists(filePath))
            //    {
            //        string xmlString = File.ReadAllText(filePath);
            //        XmlRootAttribute xmlRoot = new XmlRootAttribute();
            //        xmlRoot.ElementName = "xml";
            //        xmlRoot.IsNullable = true;
            //        XmlSerializer serializer = new XmlSerializer(typeof(Config), xmlRoot);
            //        using (TextReader reader = new StringReader(xmlString))
            //        {
            //            Config config = (Config)serializer.Deserialize(reader);
            //            tb_camera_url_1.Text = config.cameraUrl1.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
            //            tb_camera_url_2.Text = config.cameraUrl2.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
            //            tb_camera_url_3.Text = config.cameraUrl3.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
            //            tb_camera_url_4.Text = config.cameraUrl4.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
            //            tb_rfid_1.Text = config.rfidIn.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
            //            tb_rfid_2.Text = config.rfidOut.Replace(Constant.sEncodeStart, "").Replace(Constant.sEncodeEnd, "");
            //        }
            //    }
            //}
            //catch (Exception e)
            //{

            //}
            tb_camera_url_1.Text = ConfigDAO.GetCamera1();
            tb_camera_url_2.Text = ConfigDAO.GetCamera2();
            tb_camera_url_3.Text = ConfigDAO.GetCamera3();
            tb_camera_url_4.Text = ConfigDAO.GetCamera4();
            tb_rfid_1.Text = ConfigDAO.GetRFID1();
            tb_rfid_2.Text = ConfigDAO.GetRFID2();
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
            _rawinput.KeyPressed -= OnKeyPressed;
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
    }
}

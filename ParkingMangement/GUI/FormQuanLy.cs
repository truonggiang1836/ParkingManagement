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
    public partial class FormQuanLy : Form
    {
        public FormQuanLy()
        {
            InitializeComponent();
        }

        private void FormQuanLy_Load(object sender, EventArgs e)
        {
            loadUserInfoTab();
            getFunctionSecOfCurrentUser();
            //(tabQuanLy.TabPages[1] as TabPage).Enabled = false;
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
            loadUserList();
        }

        private void updateUser()
        {
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
            loadUserList();
        }

        private void loadUserInfoFromDataGridViewRow(int Index)
        {
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
            if (checkUpdateUserData())
            {
                updateUser();
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
                loadWorkList();
            }
        }

        private void dgvUserList_MouseClick(object sender, MouseEventArgs ev)
        {
            if (ev.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                MenuItem menuItem = new MenuItem("Xóa");
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
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa không?", "Xóa dữ liệu", MessageBoxButtons.YesNo);
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
            loadUserList();
        }

        /*
         * Revenue statistics
         */

        private void loadRevenueStatisticsData()
        {
            DataTable data = CarDAO.GetTotalCost(null, null, null, CarDAO.ALL_TICKET);
            dgvThongKeDoanhThu.DataSource = data;
        }

        /*
         * Part data
         */

        private void loadPartList()
        {
            dgvPartList.DataSource = PartDAO.GetAllData();
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
            if (string.IsNullOrWhiteSpace(tbPartLimitCreate.Text))
            {
                MessageBox.Show(Constant.sMessagePartLimitNullError);
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
            if (string.IsNullOrWhiteSpace(tbPartLimitEdit.Text))
            {
                MessageBox.Show(Constant.sMessagePartLimitNullError);
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
            partDTO.Limit = int.Parse(tbPartIdCreate.Text);

            PartDAO.Insert(partDTO);
            loadPartList();
        }

        private void updatePart()
        {
            PartDTO partDTO = new PartDTO();
            partDTO.Id = tbPartIdEdit.Text;
            partDTO.Name = tbPartNameEdit.Text;
            partDTO.Sign = tbPartSignEdit.Text;
            partDTO.Amount = int.Parse(tbPartAmountEdit.Text);
            partDTO.Limit = int.Parse(tbPartIdEdit.Text);

            PartDAO.Update(partDTO);
            loadPartList();
        }

        private void loadPartInfoFromDataGridViewRow(int Index)
        {
            string id = Convert.ToString(dgvPartList.Rows[Index].Cells["PartID"].Value);
            tbPartIdEdit.Text = id;
            string partName = Convert.ToString(dgvPartList.Rows[Index].Cells["PartName"].Value);
            tbPartNameEdit.Text = partName;
            string sign = Convert.ToString(dgvPartList.Rows[Index].Cells["Sign"].Value);
            tbPartSignEdit.Text = sign;
            string amount = Convert.ToString(dgvPartList.Rows[Index].Cells["Amount"].Value);
            tbPartAmountEdit.Text = amount;
            string limit = Convert.ToString(dgvPartList.Rows[Index].Cells["Limit"].Value);
            tbPartLimitEdit.Text = limit;
        }

        private void clearInputPartInfo()
        {
            tbPartIdCreate.Text = "";
            tbPartNameCreate.Text = "";
            tbPartSignCreate.Text = "";
            tbPartAmountCreate.Text = "";
            tbPartLimitCreate.Text = "";
        }

        private void tabCardManagement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabQuanLyThe_LoaiXe.SelectedTab == tabQuanLyThe_LoaiXe.TabPages["tabPageQuanLyLoaiXe"])
            {
                loadPartList();
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
            if (checkUpdatePartData())
            {
                updatePart();
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

                int lastIdentify = data.Rows[data.Rows.Count - 1].Field<int>("Identify");
                tbCardIdentifyCreate.Text = lastIdentify + 1 + "";

                dgvCardList.DataSource = data;
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
            DataTable dt = PartDAO.GetAllData();
            cb.DataSource = dt;
            cb.DisplayMember = "PartName";
            cb.ValueMember = "PartID";
        }

        private void loadPartDataWithFieldAllToComboBox(ComboBox cb)
        {
            DataTable dt = PartDAO.GetAllData();
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
                MessageBox.Show(Constant.sMessageCardIdNullError);
                return false;
            }
            return true;
        }

        private void createCard()
        {
            CardDTO cardDTO = new CardDTO();
            cardDTO.Id = tbCardIDCreate.Text.Trim();
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

            CardDAO.Insert(cardDTO);
            loadCardList();
        }

        private bool checkUpdateCardData()
        {
            if (string.IsNullOrWhiteSpace(tbCardIDEdit.Text))
            {
                MessageBox.Show(Constant.sMessageCardIdNullError);
                return false;
            }
            return true;
        }

        private void updateCard()
        {
            CardDTO cardDTO = new CardDTO();
            cardDTO.Identify = int.Parse(tbCardIdentifyEdit.Text.Trim());
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

        private void loadCardInfoFromDataGridViewRow(int Index)
        {
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

                loadUserDataToComboBox(cbNhanVienReport);
                loadRevenueStatisticsData();
            } else if (tabQuanLy.SelectedTab == tabQuanLy.TabPages["tabPageQuanLyTheXeLoaiXe"])
            {
                loadCardList();
                loadPartDataToComboBox(cbPartNameCreate);
                loadPartDataToComboBox(cbPartNameEdit);

                loadCardStatistic();

                if (dgvCardList.DataSource != null)
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
            }
        }

        private void btnCardCreate_Click(object sender, EventArgs e)
        {
            if (checkCreateCardData())
            {
                createCard();
                loadCardStatistic();
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

            if (dgvTicketLogList.Rows.Count > 0)
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
                    if (daysRemaining < 0)
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
                dgvRenewTicketMonthList.DataSource = TicketMonthDAO.searchNearExpiredTictketData(key, daysRemaining);
            } else
            {
                dgvRenewTicketMonthList.DataSource = TicketMonthDAO.searchNearExpiredTictketData(key, null);
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
            if (data != null)
            {
                lastIdentify = data.Rows[data.Rows.Count - 1].Field<int>("Identify");
            }
            tbTicketMonthIdentifyCreate.Text = lastIdentify + 1 + "";

            if (dgvTicketMonthList.Rows.Count > 0)
            {
                loadTicketMonthInfoFromDataGridViewRow(0);
            }
        }

        private void loadRenewTicketMonthData()
        {
            DataTable data = TicketMonthDAO.GetAllNearExpiredTictketData(DateTime.Now);
            dgvRenewTicketMonthList.DataSource = data;
        }

        private void loadLostTicketMonthData()
        {
            DataTable data = TicketMonthDAO.GetAllLostTictketData();
            dgvLostTicketMonthList.DataSource = data;
            if (data != null)
            {
                loadLostTicketMonthInfoFromDataGridViewRow(0);
            }
        }

        private void loadAllTicketMonthData()
        {
            DataTable data = TicketMonthDAO.GetAllLostTictketData();
            dgvAllTicketMonthList.DataSource = data;
        }

        private void tabQuanLyVeThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabQuanLyVeThang.SelectedTab == tabQuanLyVeThang.TabPages["tabPageXemNhatKyVeThang"])
            {
                loadTicketLogData();
            }
            else if (tabQuanLyVeThang.SelectedTab == tabQuanLyVeThang.TabPages["tabPageTaoMoiVeThang"])
            {
                loadTicketMonthData();
                loadPartDataToComboBox(cbTicketMonthPartCreate);
                loadPartDataToComboBox(cbTicketMonthPartEdit);
            } else if (tabQuanLyVeThang.SelectedTab == tabQuanLyVeThang.TabPages["tabPageGiaHanVeThang"])
            {
                loadRenewTicketMonthData();
            } else if (tabQuanLyVeThang.SelectedTab == tabQuanLyVeThang.TabPages["tabPageMatVeThang"])
            {
                loadLostTicketMonthData();
            } else if (tabQuanLyVeThang.SelectedTab == tabQuanLyVeThang.TabPages["tabPageKichHoatVeThang"])
            {
                
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
            dateTimePickerTicketMonthExpirationDateCreate.Value = DateTime.Now;
            tbTicketMonthChargesAmountCreate.Text = "";
        }

        private bool checkCreateTicketMonthData()
        {
            if (string.IsNullOrWhiteSpace(tbTicketMonthIDCreate.Text))
            {
                MessageBox.Show(Constant.sMessageTicketMonthIdNullError);
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
            dgvLostTicketMonthList.DataSource = TicketMonthDAO.searchLostTicketData(key);
        }

        private void deleteTicketMonth(int currentRow)
        {
            int identify = Convert.ToInt32(dgvTicketMonthList.Rows[currentRow].Cells["TicketMonthIdentify"].Value);
            string ticketMonthID = Convert.ToString(dgvTicketMonthList.Rows[currentRow].Cells["TicketMonthID"].Value);
            addDeleteTicketMonthToLog(currentRow);

            TicketMonthDAO.Delete(identify);
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

        private void showConfirmDeleteTicketMonth(int currentRow)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa không?", "Xóa dữ liệu", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                deleteTicketMonth(currentRow);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void loadLostTicketMonthInfoFromDataGridViewRow(int Index)
        {
            string identify = Convert.ToString(dgvLostTicketMonthList.Rows[Index].Cells["LostCardIdentify"].Value);
            tbLostTicketMonthIdentify.Text = identify;
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
            if (checkUpdateTicketMonthData())
            {
                //TicketLogDAO.Insert(ticketLogDTO);
                updateTicketMonth();
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
        }

        private void dgvTicketMonthList_MouseClick(object sender, MouseEventArgs ev)
        {
            if (ev.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                MenuItem menuItem = new MenuItem("Xóa");
                int currentRow = dgvTicketMonthList.HitTest(ev.X, ev.Y).RowIndex;
                menuItem.Click += new EventHandler((s, e) => Delete_TicketMonth_Click(s, e, currentRow));
                m.MenuItems.Add(menuItem);

                m.Show(dgvTicketMonthList, new Point(ev.X, ev.Y));
            }
        }

        void Delete_TicketMonth_Click(Object sender, System.EventArgs e, int currentRow)
        {
            showConfirmDeleteTicketMonth(currentRow);
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
            int identify = Convert.ToInt32(tbLostTicketMonthIdentify.Text);
            string id = tbLostTicketMonthID.Text;
            TicketMonthDAO.updateTictketByID(id, identify);
            loadLostTicketMonthData();
        }

        private void loadCarInfoFromDataGridViewRow(int Index)
        {
            string image1 = Convert.ToString(dgvCarList.Rows[Index].Cells["CarLogImages"].Value);
            if (!string.IsNullOrEmpty(image1))
            {
                pictureBoxCarLogImage1.Image = Image.FromFile(Constant.IMAGE_FOLDER + image1);
            }
            string image2 = Convert.ToString(dgvCarList.Rows[Index].Cells["CarLogImages2"].Value);
            if (!string.IsNullOrEmpty(image2))
            {
                pictureBoxCarLogImage2.Image = Image.FromFile(Constant.IMAGE_FOLDER + image2);
            }
            string image3 = Convert.ToString(dgvCarList.Rows[Index].Cells["CarLogImages3"].Value);
            if (!string.IsNullOrEmpty(image3))
            {
                pictureBoxCarLogImage3.Image = Image.FromFile(Constant.IMAGE_FOLDER + image3);
            }
            string image4 = Convert.ToString(dgvCarList.Rows[Index].Cells["CarLogImages4"].Value);
            if (!string.IsNullOrEmpty(image4))
            {
                pictureBoxCarLogImage4.Image = Image.FromFile(Constant.IMAGE_FOLDER + image4);
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
            tbTotalSpace.Text = ConfigDAO.GetTotalSpace().ToString();
            tbTicketSpace.Text = ConfigDAO.GetTicketMonthSpace().ToString();
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
                carDTO.Identify = Convert.ToInt32(tbCarIdentifySearch.Text);
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

            DataTable data = CarDAO.searchTicketDayData(carDTO);
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

        private void loadUserDataToComboBox(ComboBox cb)
        {
            DataTable dt = UserDAO.GetAllData();
            DataRow dr = dt.NewRow();
            dr["NameUser"] = "Tất cả";
            dt.Rows.InsertAt(dr, 0);
            cb.DataSource = dt;
            cb.DisplayMember = "NameUser";
            cb.ValueMember = "UserID";
        }

        private void setFormatTimeForDateTimePicker(DateTimePicker dateTimePicker)
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "HH:mm"; // Only use hours and minutes
            dateTimePicker.ShowUpDown = true;
        }

        private void tabQuanLyXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabQuanLyXe.SelectedTab == tabQuanLyXe.TabPages["tabPageTraCuuVaoRa"])
            {
                loadCarList();
                loadUserDataToComboBox(comboBoxNhanVienVao);
                loadUserDataToComboBox(comboBoxNhanVienRa);
                loadPartDataWithFieldAllToComboBox(comboBoxTruyVanLoaiXe);

                setFormatTimeForDateTimePicker(dateTimePickerCarTimeIn);
                setFormatTimeForDateTimePicker(dateTimePickerCarTimeOut);
                
            } else if (tabQuanLyXe.SelectedTab == tabQuanLyXe.TabPages["tabPageTraCuuVaoRaVeThang"])
            {
                loadCarTicketMonthList();

                dateTimePickerCarTicketMonthTimeIn.Format = DateTimePickerFormat.Custom;
                dateTimePickerCarTicketMonthTimeIn.CustomFormat = "HH:mm"; // Only use hours and minutes
                dateTimePickerCarTicketMonthTimeIn.ShowUpDown = true;
                dateTimePickerCarTicketMonthTimeOut.Format = DateTimePickerFormat.Custom;
                dateTimePickerCarTicketMonthTimeOut.CustomFormat = "HH:mm"; // Only use hours and minutes
                dateTimePickerCarTicketMonthTimeOut.ShowUpDown = true;
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
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa không?", "Xóa dữ liệu", MessageBoxButtons.YesNo);
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
                MenuItem menuItem = new MenuItem("Xóa");
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
            if (int.TryParse(tbTotalSpace.Text, out totalSpace))
            {
                if (totalSpace >= 0)
                {
                    configDTO.TotalSpace = totalSpace;
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
            if (int.TryParse(tbTicketSpace.Text, out ticketSpace))
            {
                if (ticketSpace >= 0)
                {
                    configDTO.TicketSpace = ticketSpace;
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

            ConfigDAO.Update(configDTO);
        }

        private bool isChosenRenewTicketMonthData()
        {
            foreach (DataGridViewRow row in dgvRenewTicketMonthList.Rows)
            {
                bool isChoose = Convert.ToBoolean(row.Cells["RenewIsChosen"].Value);
                int identify = Convert.ToInt32(row.Cells["RenewIdentify"].Value);
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
                MessageBox.Show(Constant.sMessageNoChooseTicketMonthError);
                return;
            }
            DateTime expirationDate = dtRenewExpirationDate.Value.Date;
            foreach (DataGridViewRow row in dgvRenewTicketMonthList.Rows)
            {
                bool isChoose = Convert.ToBoolean(row.Cells["RenewIsChosen"].Value);
                int identify = Convert.ToInt32(row.Cells["RenewIdentify"].Value);
                if (isChoose)
                {
                    TicketMonthDAO.updateTictketByExpirationDate(expirationDate, identify);
                }
            }
            loadRenewTicketMonthData();
        }

        private void btnRenewByPlusDate_Click(object sender, EventArgs e)
        {
            if (!isChosenRenewTicketMonthData())
            {
                MessageBox.Show(Constant.sMessageNoChooseTicketMonthError);
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
                    TicketMonthDAO.updateTictketByExpirationDate(expirationDate, identify);
                }
            }
            loadRenewTicketMonthData();
        }

        private void btnSaveLostCard_Click(object sender, EventArgs e)
        {

        }

        private void btnLostTicketMonthUpdate_Click(object sender, EventArgs e)
        {
            upDateLostTicketMonth();
        }

        /*
         *System management
         */

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

        private void cbUserFunctionAccessSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow functionDataRow = ((DataRowView)cbUserFunctionAccessSetting.SelectedItem).Row;
            string functionID = functionDataRow["FunctionID"].ToString();
            loadUserAcessDataFromFunctionID(functionID);
        }

        private void cbUserFunctionAccessSetting_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void tabQuanLyHeThong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabQuanLyHeThong.SelectedTab == tabQuanLyHeThong.TabPages["tabPageQuanLyThuTienXe"])
            {
                loadCarListForCashManagement();
            } else if (tabQuanLyHeThong.SelectedTab == tabQuanLyHeThong.TabPages["tabPagePhanQuyenTruyCap"])
            {
                loadUserAcessData();
            }
        }

        private void btnSearchSaleReport_Click(object sender, EventArgs e)
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
            } else if (rbCommonTicketSaleReport.Checked)
            {
                ticketType = CarDAO.COMMON_TICKET;
            } else if (rbMonthTicketSaleReport.Checked)
            {
                ticketType = CarDAO.MONTH_TICKET;
            }
            dgvThongKeDoanhThu.DataSource = CarDAO.GetTotalCost(startDateReport, endDateReport, userID, ticketType);
        }

        private void btnSaveUserAccess_Click(object sender, EventArgs e)
        {
            string listNodeID = "";
            foreach (TreeNode node in treeViewPhanQuyenTruyCap.Nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        if (childNode.Checked)
                        {
                            listNodeID += childNode.Name.Replace(Constant.NODE_NAME, "") + ",";
                        }
                    }
                } else
                {
                    listNodeID += node.Name.Replace(Constant.NODE_NAME, "") + ",";
                } 
            }
            listNodeID = listNodeID.Remove(listNodeID.Length - 1);

            DataRow functionDataRow = ((DataRowView) cbUserFunctionAccessSetting.SelectedItem).Row;
            string functionId = functionDataRow["FunctionID"].ToString();
            FunctionalDAO.UpdateFunctionSec(listNodeID, functionId);
            MessageBox.Show("Cập nhật thành công");
        }

        private void loadUserAcessDataFromFunctionID(string functionID)
        {
            foreach (TreeNode treeNode in treeViewPhanQuyenTruyCap.Nodes)
            {
                treeNode.Checked = false;
            }
            string[] listFunctionSec = FunctionalDAO.GetFunctionSecByID(functionID).Split(',');
            foreach (string nodeID in listFunctionSec)
            {
                string nodeName = Constant.NODE_NAME + nodeID;
                TreeNode treeNode = treeViewPhanQuyenTruyCap.Nodes.Find(nodeName, true)[0];
                if (treeNode != null)
                {
                    treeNode.Checked = true;
                }
            }
        }

        private void getFunctionSecOfCurrentUser()
        {
            string functionID = UserDAO.GetFunctionIDByUserID(Program.CurrentUserID);
            string[] listFunctionSec = FunctionalDAO.GetFunctionSecByID(functionID).Split(',');
            
            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_THONG_TIN_NHAN_SU, tabPageThongTinNhanSu);
            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_DO_BANG_CHAM_CONG, tabPageDoBangChamCong);
            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_DO_BANG_CHAM_CONG, tabPageDoBangChamCong);

            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_XEM_THONG_KE, tabPageThongKeDoanhThu);
            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_DIEU_CHINH_CONG_THUC_TINH_TIEN, tabPageCongThucTinhTienTheoCongVan);
            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_DIEU_CHINH_CONG_THUC_TINH_TIEN, tabPageCongThucTinhTienLuyTien);
            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_DIEU_CHINH_CONG_THUC_TINH_TIEN, tabPageCongThucTongHop);

            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_QUAN_LY_THE_XE, tabPageQuanLyTheXe);
            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_QUAN_LY_LOAI_XE, tabPageQuanLyLoaiXe);
            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_KICH_HOAT_THE, tabPageKichHoatThe);

            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_NHAT_KY_VE_THANG, tabPageXemNhatKyVeThang);
            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_CAP_NHAT_THONG_TIN_VE_THANG, tabPageTaoMoiVeThang);
            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_GIA_HAN_VE_THANG, tabPageGiaHanVeThang);
            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_MAT_THE_THANG, tabPageMatVeThang);
            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_KICH_HOAT_VE_THANG, tabPageKichHoatVeThang);

            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_CAU_HINH_CO_BAN, tabPageCauHinhCoBan);
            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_QUAN_LY_TIEN_THU, tabPageQuanLyThuTienXe);
            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_PHAN_QUYEN_TRUY_CAP, tabPagePhanQuyenTruyCap);
            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_NHAT_KY_HE_THONG, tabPageNhatKyHeThong);

            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_THIET_LAP_RA_VAO, tabPageThietLapRaVao);
            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_TRA_CUU_VAO_RA, tabPageTraCuuVaoRa);
            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_TRA_CUU_VAO_RA_VE_THANG, tabPageTraCuuVaoRaVeThang);
            checkShowTabPage(listFunctionSec, Constant.NODE_VALUE_XEM_HOP_DEN, tabPageXemHopDen);       
        }
        private void checkShowTabPage(string[] listFunctionSec, int nodeValue, TabPage tabPage)
        {
            if (Array.IndexOf(listFunctionSec, nodeValue + "") == -1)
            {

                (tabPage as TabPage).Enabled = false;
            }
        }
    }
}

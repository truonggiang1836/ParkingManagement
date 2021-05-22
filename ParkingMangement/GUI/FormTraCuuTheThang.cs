using ParkingMangement.DAO;
using ParkingMangement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingMangement.GUI
{
    public partial class FormTraCuuTheThang : Form
    {
        public FormTraCuuTheThang()
        {
            InitializeComponent();
        }

        private void tbTicketMonthKeyWordSearch_TextChanged(object sender, EventArgs e)
        {
            searchTicketMonthData();
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
        }

        private void dgvTicketMonthList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvTicketMonthList.IsCurrentCellDirty)
            {
                dgvTicketMonthList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvTicketMonthList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Util.setRowNumber(dgvTicketMonthList, "STT_TicketMonth");
        }

        private void loadTicketMonthInfoFromDataGridViewRow(int Index)
        {
            if (Index < 0)
            {
                return;
            }
            string identify = Convert.ToString(dgvTicketMonthList.Rows[Index].Cells["TicketMonthIdentify"].Value);
            tbTicketMonthIdentifyEdit.Text = identify;
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

        private void searchTicketMonthData()
        {
            string key = tbTicketMonthKeyWordSearch.Text;
            dgvTicketMonthList.DataSource = TicketMonthDAO.searchData(key);
        }

        private void FormTraCuuTheThang_Load(object sender, EventArgs e)
        {
            loadPartDataToComboBox(cbTicketMonthPartEdit);
            dgvTicketMonthList.DataSource = TicketMonthDAO.GetAllData();
        }

        private void loadPartDataToComboBox(ComboBox cb)
        {
            DataTable dt = PartDAO.GetAllData();
            cb.DataSource = dt;
            cb.DisplayMember = "PartName";
            cb.ValueMember = "ID";
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
                    if (tbTicketMonthKeyWordSearch.Focused)
                    {
                        tbTicketMonthKeyWordSearch.Text = uhfCardId;
                    }
                }
            }));
        }

        private void FormTraCuuTheThang_Activated(object sender, EventArgs e)
        {
            addEventReadPegasusReaderCOM();
        }

        private void FormTraCuuTheThang_Deactivate(object sender, EventArgs e)
        {
            removeEventReadPegasusReaderCOM();
        }
    }
}

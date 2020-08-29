using ParkingMangement.DAO;
using ParkingMangement.DTO;
using ParkingMangement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingMangement.GUI
{
    public partial class FormInPhieuThu : Form
    {
        private PrintDocument printDocument1 = new PrintDocument();
        private Bitmap memoryImage;
        public string title = "";
        public string customerName = "";
        public string address = "";
        public string reason = "";
        public int cost = 0;
        public int receiptType = ReceiptTypeDTO.TYPE_PHIEU_THU_TIEN_MAT;
        private int mReceiptNumber = 1;

        public bool isCostExtendCard = false;
        public bool isCostCreateCard = false;
        public bool isCostDepositCard = false;
        public bool isUpdatedDB = false;
        public DataTable data;

        public FormInPhieuThu()
        {
            InitializeComponent();
        }

        private void printReceipt()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = panelPrintReceipt.Size;
            memoryImage = new Bitmap(panelPrintReceipt.Width, panelPrintReceipt.Height);
            panelPrintReceipt.DrawToBitmap(memoryImage, new Rectangle(0, 0, memoryImage.Width, memoryImage.Height));

            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            PrintDialog printDlg = new PrintDialog();
            printDlg.Document = printDocument1;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            //Call ShowDialog  
            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                if (!isUpdatedDB)
                {
                    renewPrintReceiptList();
                    saveToReceiptLog();
                    if (isCostExtendCard)
                    {
                        MessageBox.Show("Đã gia hạn thành công!");
                    }
                }
                printDocument1.Print();
                isUpdatedDB = true;
            }
        }

        private void printDocument1_PrintPage(System.Object sender,
               System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            printReceipt();
        }

        private void FormInPhieuThu_Load(object sender, EventArgs e)
        {
            tbTitle.Text = title;
            tbCustomerName.Text = customerName;
            tbAddress.Text = address;
            tbReason.Text = reason;


            dgvPrintReceipt.Columns["STT_ReceiptTicketMonthList"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrintReceipt.Columns["ReceiptIdentify"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrintReceipt.Columns["ReceiptDigit"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrintReceipt.Columns["ReceiptPartName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrintReceipt.Columns["ReceiptCustomerName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrintReceipt.Columns["ReceiptPrintCost"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrintReceipt.Columns["ReceiptNewExpirationDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvPrintReceipt.Columns["STT_ReceiptTicketMonthList"].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dgvPrintReceipt.Columns["ReceiptIdentify"].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dgvPrintReceipt.Columns["ReceiptDigit"].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dgvPrintReceipt.Columns["ReceiptPartName"].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dgvPrintReceipt.Columns["ReceiptCustomerName"].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dgvPrintReceipt.Columns["ReceiptPrintCost"].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dgvPrintReceipt.Columns["ReceiptNewExpirationDate"].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);


            dgvPrintReceipt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvPrintReceipt.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;


            tbCurrentDate.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            if (cost >= 0)
            {
                tbCost.Text = Util.formatNumberAsMoney(cost);
                tbCostString.Text = Util.So_sang_chu(cost);
            } else
            {
                tbCost.Text = Util.formatNumberAsMoney(-cost);
                tbCostString.Text = Util.So_sang_chu(-cost);
            }
            
            tbBookNo.Text = DateTime.Now.ToString("MM'/'yy");
            if (data.Rows.Count > 0)
            {
                dgvPrintReceipt.DataSource = data;
            } else
            {
                dgvPrintReceipt.Visible = false;
            }

            mReceiptNumber = 1;
            if (ReceiptLogDAO.GetDataByReceiptType(receiptType).Rows.Count > 0)
            {
                if (ReceiptLogDAO.GetLastPrintDate().Year == DateTime.Now.Year &&
                    ReceiptLogDAO.GetLastPrintDate().Month == DateTime.Now.Month)
                {
                    mReceiptNumber = ReceiptLogDAO.GetLastReceiptNumberByReceiptType(receiptType) + 1;
                }
            }
            tbNumber.Text = mReceiptNumber + "";
        }

        private void btnCancelReceippt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPrintReceipt_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var height = 22;
            foreach (DataGridViewRow dr in dgvPrintReceipt.Rows)
            {
                height += dr.Height;
            }

            dgvPrintReceipt.Height = height;

            Util.setRowNumber(dgvPrintReceipt, "STT_ReceiptTicketMonthList");
        }

        private void renewPrintReceiptList()
        {
            foreach (DataGridViewRow row in dgvPrintReceipt.Rows)
            {
                string id = Convert.ToString(row.Cells["ReceiptTicketMonthID"].Value);
                DateTime expirationDate = Convert.ToDateTime(row.Cells["ReceiptNewExpirationDate"].Value);
                TicketMonthDAO.updateTicketByExpirationDate(expirationDate, id);
            }
        }

        private void saveToReceiptLog()
        {
            ReceiptLogDTO receiptLogDTO = new ReceiptLogDTO();
            receiptLogDTO.ReceiptType = receiptType;
            receiptLogDTO.CustomerName = customerName;
            receiptLogDTO.Address = address;
            receiptLogDTO.Reason = reason;
            receiptLogDTO.Cost = cost;
            receiptLogDTO.PrintDate = DateTime.Now;
            receiptLogDTO.ReceiptNumber = mReceiptNumber;
            receiptLogDTO.IsCostCreateCard = isCostCreateCard ? 1 : 0;
            receiptLogDTO.IsCostDepositCard = isCostDepositCard ? 1 : 0;
            receiptLogDTO.IsCostExtendCard = isCostExtendCard ? 1 : 0;
            ReceiptLogDAO.Insert(receiptLogDTO);

            saveToReceiptLogDetail(receiptLogDTO);
        }

        private void saveToReceiptLogDetail(ReceiptLogDTO receiptLogDTO)
        {
            long? receiptLogID = ReceiptLogDAO.GetLastReceiptLogID();
            if (receiptLogID != null)
            {                
                for (int i = 0; i < dgvPrintReceipt.Rows.Count; i++)
                {
                    ReceiptLogDetailDTO receiptLogDetailDTO = new ReceiptLogDetailDTO();
                    receiptLogDetailDTO.ReceiptLogID = receiptLogID;
                    receiptLogDetailDTO.CardIdentify = dgvPrintReceipt.Rows[i].Cells["ReceiptIdentify"].Value.ToString();
                    receiptLogDetailDTO.CardID = dgvPrintReceipt.Rows[i].Cells["ReceiptTicketMonthID"].Value.ToString();
                    receiptLogDetailDTO.Digit = dgvPrintReceipt.Rows[i].Cells["ReceiptDigit"].Value.ToString();
                    receiptLogDetailDTO.PartID = dgvPrintReceipt.Rows[i].Cells["ReceiptIDPart"].Value.ToString();
                    receiptLogDetailDTO.CustomerName = dgvPrintReceipt.Rows[i].Cells["ReceiptCustomerName"].Value.ToString();
                    receiptLogDetailDTO.Cost = Convert.ToInt32(dgvPrintReceipt.Rows[i].Cells["ReceiptCost"].Value.ToString());
                    receiptLogDetailDTO.ExpirationDate = Convert.ToDateTime(dgvPrintReceipt.Rows[i].Cells["ReceiptNewExpirationDate"].Value);
                    receiptLogDetailDTO.PrintDate = receiptLogDTO.PrintDate;
                    receiptLogDetailDTO.Company = dgvPrintReceipt.Rows[i].Cells["ReceiptCompany"].Value.ToString();
                    receiptLogDetailDTO.Address = dgvPrintReceipt.Rows[i].Cells["ReceiptAddress"].Value.ToString();

                    ReceiptLogDetailDAO.Insert(receiptLogDetailDTO);
                }
            }            
        }
    }
}

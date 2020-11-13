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
    public partial class FormThongBaoPhi : Form
    {
        private PrintDocument printDocument1 = new PrintDocument();
        private Bitmap memoryImage;
        public string title = "";
        public string customerName = "";
        public string address = "";
        public string reason = "";
        public int cost = 0;
        public bool isVAT = false;
        public int receiptType = ReceiptTypeDTO.TYPE_PHIEU_THU_TIEN_MAT;
        public int monthCount = 1;
        private int mReceiptNumber = 1;     

        public bool isCostExtendCard = false;
        public bool isCostCreateCard = false;
        public bool isRemoveCostCreateCard = false;
        public bool isCostDepositCard = false;
        public bool isUpdatedDB = false;
        public DataTable data;
        public FormThongBaoPhi()
        {
            InitializeComponent();
        }

        private void FormThongBaoPhi_Load(object sender, EventArgs e)
        {
            tbCustomerName.Text = customerName;
            tbAddress.Text = address;


            dgvPrintReceipt.Columns["STT_ReceiptTicketMonthList"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrintReceipt.Columns["ReceiptIdentify"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrintReceipt.Columns["ReceiptDigit"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrintReceipt.Columns["ReceiptPartName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrintReceipt.Columns["ReceiptCustomerName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrintReceipt.Columns["ReceiptPrintCost"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrintReceipt.Columns["ReceiptExpirationDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrintReceipt.Columns["ReceiptNewExpirationDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvPrintReceipt.Columns["STT_ReceiptTicketMonthList"].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dgvPrintReceipt.Columns["ReceiptIdentify"].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dgvPrintReceipt.Columns["ReceiptDigit"].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dgvPrintReceipt.Columns["ReceiptPartName"].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dgvPrintReceipt.Columns["ReceiptCustomerName"].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dgvPrintReceipt.Columns["ReceiptPrintCost"].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dgvPrintReceipt.Columns["ReceiptExpirationDate"].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            dgvPrintReceipt.Columns["ReceiptNewExpirationDate"].HeaderCell.Style.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);


            dgvPrintReceipt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvPrintReceipt.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            if (isCostExtendCard)
            {
                dgvPrintReceipt.Columns["ReceiptNewExpirationDate"].Visible = true;
            }
            else
            {
                dgvPrintReceipt.Columns["ReceiptNewExpirationDate"].Visible = false;
            }


            tbCurrentDate.Text = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            tbMonthYear.Text = DateTime.Now.AddMonths(monthCount).Month + "/" + DateTime.Now.AddMonths(monthCount).Year;
            string costText = "";
            if (cost >= 0)
            {
                costText = Util.formatNumberAsMoney(cost);
            }
            else
            {
                costText = Util.formatNumberAsMoney(-cost);
            }
            tbIncludeVAT.Visible = isVAT;
            tbCost.Text = costText;

            if (data.Rows.Count > 0)
            {
                dgvPrintReceipt.DataSource = data;
            }
            else
            {
                dgvPrintReceipt.Visible = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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
                printDocument1.Print();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelPrintReceipt_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvPrintReceipt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbMonthYear_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

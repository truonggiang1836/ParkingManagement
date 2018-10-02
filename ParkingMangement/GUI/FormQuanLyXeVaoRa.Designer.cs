namespace ParkingMangement.GUI
{
    partial class FormQuanLyXeVaoRa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCarList = new System.Windows.Forms.DataGridView();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnXemDanhSachXeTon = new System.Windows.Forms.Button();
            this.tbCarLogIdentify = new System.Windows.Forms.TextBox();
            this.dateTimePickerCarTimeOut = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCarTimeIn = new System.Windows.Forms.DateTimePicker();
            this.label45 = new System.Windows.Forms.Label();
            this.comboBoxNhanVienVao = new System.Windows.Forms.ComboBox();
            this.comboBoxNhanVienRa = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.tbCarDigitSearch = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.pictureBoxCarLogImage3 = new System.Windows.Forms.PictureBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.pictureBoxCarLogImage1 = new System.Windows.Forms.PictureBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.pictureBoxCarLogImage4 = new System.Windows.Forms.PictureBox();
            this.btnSearchCar = new System.Windows.Forms.Button();
            this.btnSaveLostCard = new System.Windows.Forms.Button();
            this.btnExportDanhSachXe = new System.Windows.Forms.Button();
            this.tbCarIDSearch = new System.Windows.Forms.TextBox();
            this.tbCarIdentifySearch = new System.Windows.Forms.TextBox();
            this.dateTimePickerCarDateOut = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCarDateIn = new System.Windows.Forms.DateTimePicker();
            this.label40 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.pictureBoxCarLogImage2 = new System.Windows.Forms.PictureBox();
            this.CarLogIdentify = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarLogImages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarLogImages2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarLogImages3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarLogImages4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarLogIsLostCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarList)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarLogImage3)).BeginInit();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarLogImage1)).BeginInit();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarLogImage4)).BeginInit();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarLogImage2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCarList
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCarList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCarList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CarLogIdentify,
            this.CarLogImages,
            this.CarLogImages2,
            this.CarLogImages3,
            this.CarLogImages4,
            this.Column20,
            this.CarID,
            this.Column22,
            this.Column23,
            this.Column24,
            this.Column25,
            this.Column26,
            this.Column27,
            this.Column28,
            this.Column29,
            this.Column30,
            this.CarLogIsLostCard,
            this.Column32,
            this.Column33,
            this.Column34});
            this.dgvCarList.Location = new System.Drawing.Point(7, 365);
            this.dgvCarList.Name = "dgvCarList";
            this.dgvCarList.ReadOnly = true;
            this.dgvCarList.Size = new System.Drawing.Size(1138, 302);
            this.dgvCarList.TabIndex = 3;
            this.dgvCarList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarList_CellClick);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnXemDanhSachXeTon);
            this.panel10.Controls.Add(this.tbCarLogIdentify);
            this.panel10.Controls.Add(this.dateTimePickerCarTimeOut);
            this.panel10.Controls.Add(this.dateTimePickerCarTimeIn);
            this.panel10.Controls.Add(this.label45);
            this.panel10.Controls.Add(this.comboBoxNhanVienVao);
            this.panel10.Controls.Add(this.comboBoxNhanVienRa);
            this.panel10.Controls.Add(this.label44);
            this.panel10.Controls.Add(this.label43);
            this.panel10.Controls.Add(this.label42);
            this.panel10.Controls.Add(this.tbCarDigitSearch);
            this.panel10.Controls.Add(this.label41);
            this.panel10.Controls.Add(this.panel13);
            this.panel10.Controls.Add(this.panel14);
            this.panel10.Controls.Add(this.panel12);
            this.panel10.Controls.Add(this.btnSearchCar);
            this.panel10.Controls.Add(this.btnSaveLostCard);
            this.panel10.Controls.Add(this.btnExportDanhSachXe);
            this.panel10.Controls.Add(this.tbCarIDSearch);
            this.panel10.Controls.Add(this.tbCarIdentifySearch);
            this.panel10.Controls.Add(this.dateTimePickerCarDateOut);
            this.panel10.Controls.Add(this.dateTimePickerCarDateIn);
            this.panel10.Controls.Add(this.label40);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Location = new System.Drawing.Point(7, 7);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1138, 352);
            this.panel10.TabIndex = 2;
            // 
            // btnXemDanhSachXeTon
            // 
            this.btnXemDanhSachXeTon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemDanhSachXeTon.Location = new System.Drawing.Point(16, 267);
            this.btnXemDanhSachXeTon.Name = "btnXemDanhSachXeTon";
            this.btnXemDanhSachXeTon.Size = new System.Drawing.Size(395, 34);
            this.btnXemDanhSachXeTon.TabIndex = 30;
            this.btnXemDanhSachXeTon.Text = "DANH SÁCH XE TỒN";
            this.btnXemDanhSachXeTon.UseVisualStyleBackColor = true;
            this.btnXemDanhSachXeTon.Click += new System.EventHandler(this.btnXemDanhSachXeTon_Click);
            // 
            // tbCarLogIdentify
            // 
            this.tbCarLogIdentify.Location = new System.Drawing.Point(438, 14);
            this.tbCarLogIdentify.Name = "tbCarLogIdentify";
            this.tbCarLogIdentify.Size = new System.Drawing.Size(111, 20);
            this.tbCarLogIdentify.TabIndex = 29;
            this.tbCarLogIdentify.Visible = false;
            // 
            // dateTimePickerCarTimeOut
            // 
            this.dateTimePickerCarTimeOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerCarTimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerCarTimeOut.Location = new System.Drawing.Point(300, 48);
            this.dateTimePickerCarTimeOut.Name = "dateTimePickerCarTimeOut";
            this.dateTimePickerCarTimeOut.Size = new System.Drawing.Size(111, 22);
            this.dateTimePickerCarTimeOut.TabIndex = 28;
            this.dateTimePickerCarTimeOut.Value = new System.DateTime(2018, 9, 27, 23, 59, 0, 0);
            // 
            // dateTimePickerCarTimeIn
            // 
            this.dateTimePickerCarTimeIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerCarTimeIn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerCarTimeIn.Location = new System.Drawing.Point(300, 14);
            this.dateTimePickerCarTimeIn.Name = "dateTimePickerCarTimeIn";
            this.dateTimePickerCarTimeIn.Size = new System.Drawing.Size(111, 22);
            this.dateTimePickerCarTimeIn.TabIndex = 27;
            this.dateTimePickerCarTimeIn.Value = new System.DateTime(2018, 9, 27, 0, 0, 0, 0);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(236, 153);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(49, 16);
            this.label45.TabIndex = 26;
            this.label45.Text = "NV RA";
            // 
            // comboBoxNhanVienVao
            // 
            this.comboBoxNhanVienVao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNhanVienVao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxNhanVienVao.FormattingEnabled = true;
            this.comboBoxNhanVienVao.Location = new System.Drawing.Point(96, 150);
            this.comboBoxNhanVienVao.Name = "comboBoxNhanVienVao";
            this.comboBoxNhanVienVao.Size = new System.Drawing.Size(111, 24);
            this.comboBoxNhanVienVao.TabIndex = 25;
            // 
            // comboBoxNhanVienRa
            // 
            this.comboBoxNhanVienRa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNhanVienRa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxNhanVienRa.FormattingEnabled = true;
            this.comboBoxNhanVienRa.Location = new System.Drawing.Point(300, 150);
            this.comboBoxNhanVienRa.Name = "comboBoxNhanVienRa";
            this.comboBoxNhanVienRa.Size = new System.Drawing.Size(111, 24);
            this.comboBoxNhanVienRa.TabIndex = 24;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(13, 153);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(58, 16);
            this.label44.TabIndex = 23;
            this.label44.Text = "NV VÀO";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(11, 119);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(77, 16);
            this.label43.TabIndex = 22;
            this.label43.Text = "QUÉT THẺ";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(234, 85);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(61, 16);
            this.label42.TabIndex = 21;
            this.label42.Text = "BIỂN SỐ";
            // 
            // tbCarDigitSearch
            // 
            this.tbCarDigitSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCarDigitSearch.Location = new System.Drawing.Point(300, 82);
            this.tbCarDigitSearch.Name = "tbCarDigitSearch";
            this.tbCarDigitSearch.Size = new System.Drawing.Size(111, 22);
            this.tbCarDigitSearch.TabIndex = 20;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(11, 85);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(35, 16);
            this.label41.TabIndex = 19;
            this.label41.Text = "STT";
            // 
            // panel13
            // 
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Controls.Add(this.pictureBoxCarLogImage3);
            this.panel13.Location = new System.Drawing.Point(558, 180);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(284, 168);
            this.panel13.TabIndex = 18;
            // 
            // pictureBoxCarLogImage3
            // 
            this.pictureBoxCarLogImage3.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxCarLogImage3.Name = "pictureBoxCarLogImage3";
            this.pictureBoxCarLogImage3.Size = new System.Drawing.Size(275, 158);
            this.pictureBoxCarLogImage3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCarLogImage3.TabIndex = 1;
            this.pictureBoxCarLogImage3.TabStop = false;
            // 
            // panel14
            // 
            this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel14.Controls.Add(this.pictureBoxCarLogImage1);
            this.panel14.Location = new System.Drawing.Point(558, 7);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(284, 168);
            this.panel14.TabIndex = 17;
            // 
            // pictureBoxCarLogImage1
            // 
            this.pictureBoxCarLogImage1.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxCarLogImage1.Name = "pictureBoxCarLogImage1";
            this.pictureBoxCarLogImage1.Size = new System.Drawing.Size(275, 158);
            this.pictureBoxCarLogImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCarLogImage1.TabIndex = 0;
            this.pictureBoxCarLogImage1.TabStop = false;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.pictureBoxCarLogImage4);
            this.panel12.Location = new System.Drawing.Point(847, 180);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(284, 168);
            this.panel12.TabIndex = 16;
            // 
            // pictureBoxCarLogImage4
            // 
            this.pictureBoxCarLogImage4.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxCarLogImage4.Name = "pictureBoxCarLogImage4";
            this.pictureBoxCarLogImage4.Size = new System.Drawing.Size(275, 158);
            this.pictureBoxCarLogImage4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCarLogImage4.TabIndex = 1;
            this.pictureBoxCarLogImage4.TabStop = false;
            // 
            // btnSearchCar
            // 
            this.btnSearchCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCar.Location = new System.Drawing.Point(16, 187);
            this.btnSearchCar.Name = "btnSearchCar";
            this.btnSearchCar.Size = new System.Drawing.Size(395, 34);
            this.btnSearchCar.TabIndex = 15;
            this.btnSearchCar.Text = "TÌM";
            this.btnSearchCar.UseVisualStyleBackColor = true;
            this.btnSearchCar.Click += new System.EventHandler(this.btnSearchCar_Click);
            // 
            // btnSaveLostCard
            // 
            this.btnSaveLostCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveLostCard.ForeColor = System.Drawing.Color.Red;
            this.btnSaveLostCard.Location = new System.Drawing.Point(16, 307);
            this.btnSaveLostCard.Name = "btnSaveLostCard";
            this.btnSaveLostCard.Size = new System.Drawing.Size(393, 34);
            this.btnSaveLostCard.TabIndex = 14;
            this.btnSaveLostCard.Text = "LƯU MẤT THẺ";
            this.btnSaveLostCard.UseVisualStyleBackColor = true;
            this.btnSaveLostCard.Click += new System.EventHandler(this.btnSaveLostCard_Click);
            // 
            // btnExportDanhSachXe
            // 
            this.btnExportDanhSachXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportDanhSachXe.Location = new System.Drawing.Point(16, 227);
            this.btnExportDanhSachXe.Name = "btnExportDanhSachXe";
            this.btnExportDanhSachXe.Size = new System.Drawing.Size(395, 34);
            this.btnExportDanhSachXe.TabIndex = 13;
            this.btnExportDanhSachXe.Text = "DANH SÁCH MẤT THẺ";
            this.btnExportDanhSachXe.UseVisualStyleBackColor = true;
            this.btnExportDanhSachXe.Click += new System.EventHandler(this.btnExportDanhSachXe_Click);
            // 
            // tbCarIDSearch
            // 
            this.tbCarIDSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCarIDSearch.Location = new System.Drawing.Point(96, 116);
            this.tbCarIDSearch.Name = "tbCarIDSearch";
            this.tbCarIDSearch.Size = new System.Drawing.Size(315, 22);
            this.tbCarIDSearch.TabIndex = 11;
            // 
            // tbCarIdentifySearch
            // 
            this.tbCarIdentifySearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCarIdentifySearch.Location = new System.Drawing.Point(96, 82);
            this.tbCarIdentifySearch.Name = "tbCarIdentifySearch";
            this.tbCarIdentifySearch.Size = new System.Drawing.Size(111, 22);
            this.tbCarIdentifySearch.TabIndex = 10;
            // 
            // dateTimePickerCarDateOut
            // 
            this.dateTimePickerCarDateOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerCarDateOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerCarDateOut.Location = new System.Drawing.Point(96, 48);
            this.dateTimePickerCarDateOut.Name = "dateTimePickerCarDateOut";
            this.dateTimePickerCarDateOut.Size = new System.Drawing.Size(189, 22);
            this.dateTimePickerCarDateOut.TabIndex = 8;
            // 
            // dateTimePickerCarDateIn
            // 
            this.dateTimePickerCarDateIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerCarDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerCarDateIn.Location = new System.Drawing.Point(96, 14);
            this.dateTimePickerCarDateIn.Name = "dateTimePickerCarDateIn";
            this.dateTimePickerCarDateIn.Size = new System.Drawing.Size(189, 22);
            this.dateTimePickerCarDateIn.TabIndex = 6;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(11, 17);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(61, 16);
            this.label40.TabIndex = 5;
            this.label40.Text = "Ngày tìm";
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.pictureBoxCarLogImage2);
            this.panel11.Location = new System.Drawing.Point(847, 7);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(284, 168);
            this.panel11.TabIndex = 0;
            // 
            // pictureBoxCarLogImage2
            // 
            this.pictureBoxCarLogImage2.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxCarLogImage2.Name = "pictureBoxCarLogImage2";
            this.pictureBoxCarLogImage2.Size = new System.Drawing.Size(275, 158);
            this.pictureBoxCarLogImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCarLogImage2.TabIndex = 1;
            this.pictureBoxCarLogImage2.TabStop = false;
            // 
            // CarLogIdentify
            // 
            this.CarLogIdentify.DataPropertyName = "Identify";
            this.CarLogIdentify.HeaderText = "STT";
            this.CarLogIdentify.Name = "CarLogIdentify";
            this.CarLogIdentify.ReadOnly = true;
            // 
            // CarLogImages
            // 
            this.CarLogImages.DataPropertyName = "Images";
            this.CarLogImages.HeaderText = "Images";
            this.CarLogImages.Name = "CarLogImages";
            this.CarLogImages.ReadOnly = true;
            this.CarLogImages.Visible = false;
            // 
            // CarLogImages2
            // 
            this.CarLogImages2.DataPropertyName = "Images2";
            this.CarLogImages2.HeaderText = "Images2";
            this.CarLogImages2.Name = "CarLogImages2";
            this.CarLogImages2.ReadOnly = true;
            this.CarLogImages2.Visible = false;
            // 
            // CarLogImages3
            // 
            this.CarLogImages3.DataPropertyName = "Images3";
            this.CarLogImages3.HeaderText = "Images3";
            this.CarLogImages3.Name = "CarLogImages3";
            this.CarLogImages3.ReadOnly = true;
            this.CarLogImages3.Visible = false;
            // 
            // CarLogImages4
            // 
            this.CarLogImages4.DataPropertyName = "Images4";
            this.CarLogImages4.HeaderText = "Images4";
            this.CarLogImages4.Name = "CarLogImages4";
            this.CarLogImages4.ReadOnly = true;
            this.CarLogImages4.Visible = false;
            // 
            // Column20
            // 
            this.Column20.DataPropertyName = "SmartCardIdentify";
            this.Column20.HeaderText = "STT thẻ";
            this.Column20.Name = "Column20";
            this.Column20.ReadOnly = true;
            // 
            // CarID
            // 
            this.CarID.DataPropertyName = "ID";
            this.CarID.HeaderText = "Mã thẻ";
            this.CarID.Name = "CarID";
            this.CarID.ReadOnly = true;
            // 
            // Column22
            // 
            this.Column22.DataPropertyName = "Sign";
            this.Column22.HeaderText = "Ký hiệu";
            this.Column22.Name = "Column22";
            this.Column22.ReadOnly = true;
            // 
            // Column23
            // 
            this.Column23.DataPropertyName = "Digit";
            this.Column23.HeaderText = "Biển số";
            this.Column23.Name = "Column23";
            this.Column23.ReadOnly = true;
            // 
            // Column24
            // 
            this.Column24.DataPropertyName = "PartName";
            this.Column24.HeaderText = "Loại xe";
            this.Column24.Name = "Column24";
            this.Column24.ReadOnly = true;
            // 
            // Column25
            // 
            this.Column25.DataPropertyName = "TimeStart";
            dataGridViewCellStyle6.Format = "dd-MM-yyyy HH:mm:ss";
            this.Column25.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column25.HeaderText = "Thời gian vào";
            this.Column25.Name = "Column25";
            this.Column25.ReadOnly = true;
            this.Column25.Width = 150;
            // 
            // Column26
            // 
            this.Column26.DataPropertyName = "TimeEnd";
            dataGridViewCellStyle7.Format = "dd-MM-yyyy HH:mm:ss";
            this.Column26.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column26.HeaderText = "Thời gian ra";
            this.Column26.Name = "Column26";
            this.Column26.ReadOnly = true;
            this.Column26.Width = 150;
            // 
            // Column27
            // 
            this.Column27.DataPropertyName = "Cost";
            this.Column27.HeaderText = "Giá tiền";
            this.Column27.Name = "Column27";
            this.Column27.ReadOnly = true;
            // 
            // Column28
            // 
            this.Column28.DataPropertyName = "IDTicketMonth";
            this.Column28.HeaderText = "Thẻ tháng";
            this.Column28.Name = "Column28";
            this.Column28.ReadOnly = true;
            // 
            // Column29
            // 
            this.Column29.DataPropertyName = "IDIn";
            this.Column29.HeaderText = "Người vào";
            this.Column29.Name = "Column29";
            this.Column29.ReadOnly = true;
            // 
            // Column30
            // 
            this.Column30.DataPropertyName = "IDOut";
            this.Column30.HeaderText = "Người ra";
            this.Column30.Name = "Column30";
            this.Column30.ReadOnly = true;
            // 
            // CarLogIsLostCard
            // 
            this.CarLogIsLostCard.DataPropertyName = "IsLostCard";
            this.CarLogIsLostCard.HeaderText = "Mất  thẻ";
            this.CarLogIsLostCard.Name = "CarLogIsLostCard";
            this.CarLogIsLostCard.ReadOnly = true;
            // 
            // Column32
            // 
            this.Column32.DataPropertyName = "Computer";
            this.Column32.HeaderText = "Máy";
            this.Column32.Name = "Column32";
            this.Column32.ReadOnly = true;
            this.Column32.Width = 150;
            // 
            // Column33
            // 
            this.Column33.DataPropertyName = "Account";
            this.Column33.HeaderText = "Tài khoản";
            this.Column33.Name = "Column33";
            this.Column33.ReadOnly = true;
            // 
            // Column34
            // 
            this.Column34.DataPropertyName = "DateUpdate";
            dataGridViewCellStyle8.Format = "dd-MM-yyyy HH:mm:ss";
            this.Column34.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column34.HeaderText = "Ngày xử lý";
            this.Column34.Name = "Column34";
            this.Column34.ReadOnly = true;
            this.Column34.Width = 150;
            // 
            // FormQuanLyXeVaoRa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.dgvCarList);
            this.Controls.Add(this.panel10);
            this.Name = "FormQuanLyXeVaoRa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý xe vào ra";
            this.Load += new System.EventHandler(this.FormQuanLyXeVaoRa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarList)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarLogImage3)).EndInit();
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarLogImage1)).EndInit();
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarLogImage4)).EndInit();
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarLogImage2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCarList;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox tbCarLogIdentify;
        private System.Windows.Forms.DateTimePicker dateTimePickerCarTimeOut;
        private System.Windows.Forms.DateTimePicker dateTimePickerCarTimeIn;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox comboBoxNhanVienVao;
        private System.Windows.Forms.ComboBox comboBoxNhanVienRa;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox tbCarDigitSearch;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.PictureBox pictureBoxCarLogImage3;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.PictureBox pictureBoxCarLogImage1;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.PictureBox pictureBoxCarLogImage4;
        private System.Windows.Forms.Button btnSearchCar;
        private System.Windows.Forms.Button btnSaveLostCard;
        private System.Windows.Forms.Button btnExportDanhSachXe;
        private System.Windows.Forms.TextBox tbCarIDSearch;
        private System.Windows.Forms.TextBox tbCarIdentifySearch;
        private System.Windows.Forms.DateTimePicker dateTimePickerCarDateOut;
        private System.Windows.Forms.DateTimePicker dateTimePickerCarDateIn;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.PictureBox pictureBoxCarLogImage2;
        private System.Windows.Forms.Button btnXemDanhSachXeTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarLogIdentify;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarLogImages;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarLogImages2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarLogImages3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarLogImages4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column26;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column27;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column28;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column29;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column30;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarLogIsLostCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column32;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column33;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column34;
    }
}
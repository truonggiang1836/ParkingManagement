namespace ParkingMangement.GUI
{
    partial class FormInOutSetting
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rbIn_In = new System.Windows.Forms.RadioButton();
            this.btnYes = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbOut_Out = new System.Windows.Forms.RadioButton();
            this.rbIn_Out = new System.Windows.Forms.RadioButton();
            this.rbOut_In = new System.Windows.Forms.RadioButton();
            this.btnNo = new System.Windows.Forms.Button();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Blue;
            this.panel6.Controls.Add(this.label1);
            this.panel6.Location = new System.Drawing.Point(1, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(529, 46);
            this.panel6.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(179, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "THÔNG BÁO";
            // 
            // rbIn_In
            // 
            this.rbIn_In.AutoSize = true;
            this.rbIn_In.Checked = true;
            this.rbIn_In.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIn_In.Location = new System.Drawing.Point(22, 30);
            this.rbIn_In.Name = "rbIn_In";
            this.rbIn_In.Size = new System.Drawing.Size(108, 24);
            this.rbIn_In.TabIndex = 23;
            this.rbIn_In.TabStop = true;
            this.rbIn_In.Text = "VÀO - VÀO";
            this.rbIn_In.UseVisualStyleBackColor = true;
            // 
            // btnYes
            // 
            this.btnYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.Location = new System.Drawing.Point(148, 137);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(101, 37);
            this.btnYes.TabIndex = 22;
            this.btnYes.Text = "YES";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rbOut_In);
            this.panel1.Controls.Add(this.rbIn_Out);
            this.panel1.Controls.Add(this.rbOut_Out);
            this.panel1.Controls.Add(this.rbIn_In);
            this.panel1.Location = new System.Drawing.Point(9, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 75);
            this.panel1.TabIndex = 24;
            // 
            // rbOut_Out
            // 
            this.rbOut_Out.AutoSize = true;
            this.rbOut_Out.Checked = true;
            this.rbOut_Out.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOut_Out.Location = new System.Drawing.Point(150, 30);
            this.rbOut_Out.Name = "rbOut_Out";
            this.rbOut_Out.Size = new System.Drawing.Size(86, 24);
            this.rbOut_Out.TabIndex = 24;
            this.rbOut_Out.TabStop = true;
            this.rbOut_Out.Text = "RA - RA";
            this.rbOut_Out.UseVisualStyleBackColor = true;
            // 
            // rbIn_Out
            // 
            this.rbIn_Out.AutoSize = true;
            this.rbIn_Out.Checked = true;
            this.rbIn_Out.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIn_Out.Location = new System.Drawing.Point(256, 30);
            this.rbIn_Out.Name = "rbIn_Out";
            this.rbIn_Out.Size = new System.Drawing.Size(97, 24);
            this.rbIn_Out.TabIndex = 25;
            this.rbIn_Out.TabStop = true;
            this.rbIn_Out.Text = "VÀO - RA";
            this.rbIn_Out.UseVisualStyleBackColor = true;
            // 
            // rbOut_In
            // 
            this.rbOut_In.AutoSize = true;
            this.rbOut_In.Checked = true;
            this.rbOut_In.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOut_In.Location = new System.Drawing.Point(373, 30);
            this.rbOut_In.Name = "rbOut_In";
            this.rbOut_In.Size = new System.Drawing.Size(97, 24);
            this.rbOut_In.TabIndex = 26;
            this.rbOut_In.TabStop = true;
            this.rbOut_In.Text = "RA - VÀO";
            this.rbOut_In.UseVisualStyleBackColor = true;
            // 
            // btnNo
            // 
            this.btnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.Location = new System.Drawing.Point(258, 137);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(101, 37);
            this.btnNo.TabIndex = 25;
            this.btnNo.Text = "NO";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // FormInOutSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 183);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.panel6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInOutSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormInOutSetting_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbIn_In;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbOut_In;
        private System.Windows.Forms.RadioButton rbIn_Out;
        private System.Windows.Forms.RadioButton rbOut_Out;
        private System.Windows.Forms.Button btnNo;
    }
}
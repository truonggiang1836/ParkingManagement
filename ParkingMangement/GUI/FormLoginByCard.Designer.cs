namespace ParkingMangement.GUI
{
    partial class FormLoginByCard
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
            this.btnExit = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(181, 84);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(143, 32);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labelError
            // 
            this.labelError.BackColor = System.Drawing.Color.Transparent;
            this.labelError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.White;
            this.labelError.Location = new System.Drawing.Point(0, 0);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(450, 37);
            this.labelError.TabIndex = 6;
            this.labelError.Text = "Trạng thái";
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(152, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Đăng nhập bằng thẻ";
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.tbUserID);
            this.panel1.Location = new System.Drawing.Point(15, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 202);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.labelError);
            this.panel2.Location = new System.Drawing.Point(28, 138);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 37);
            this.panel2.TabIndex = 7;
            // 
            // tbUserID
            // 
            this.tbUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserID.Location = new System.Drawing.Point(96, 34);
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.Size = new System.Drawing.Size(306, 26);
            this.tbUserID.TabIndex = 0;
            this.tbUserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbUserID_KeyDown);
            // 
            // FormLoginByCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 283);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Name = "FormLoginByCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLoginByCard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbUserID;
    }
}
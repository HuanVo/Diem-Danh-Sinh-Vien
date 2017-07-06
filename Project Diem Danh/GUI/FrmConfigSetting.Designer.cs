namespace Project_Diem_Danh
{
    partial class FrmConfigSetting
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
            this.grbSettingConnect = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numTimeCard = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numDPort = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numdTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.grbSettingConnect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numdTime)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbSettingConnect
            // 
            this.grbSettingConnect.BackColor = System.Drawing.Color.Transparent;
            this.grbSettingConnect.Controls.Add(this.label6);
            this.grbSettingConnect.Controls.Add(this.numTimeCard);
            this.grbSettingConnect.Controls.Add(this.label7);
            this.grbSettingConnect.Controls.Add(this.label5);
            this.grbSettingConnect.Controls.Add(this.numDPort);
            this.grbSettingConnect.Controls.Add(this.label4);
            this.grbSettingConnect.Controls.Add(this.label3);
            this.grbSettingConnect.Controls.Add(this.numdTime);
            this.grbSettingConnect.Controls.Add(this.label2);
            this.grbSettingConnect.Controls.Add(this.label1);
            this.grbSettingConnect.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbSettingConnect.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbSettingConnect.ForeColor = System.Drawing.Color.White;
            this.grbSettingConnect.Location = new System.Drawing.Point(0, 0);
            this.grbSettingConnect.Name = "grbSettingConnect";
            this.grbSettingConnect.Size = new System.Drawing.Size(574, 204);
            this.grbSettingConnect.TabIndex = 0;
            this.grbSettingConnect.TabStop = false;
            this.grbSettingConnect.Text = "Thiết Lập Chung";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(376, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "(Phút)";
            // 
            // numTimeCard
            // 
            this.numTimeCard.Location = new System.Drawing.Point(286, 136);
            this.numTimeCard.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numTimeCard.Name = "numTimeCard";
            this.numTimeCard.Size = new System.Drawing.Size(83, 23);
            this.numTimeCard.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(30, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(253, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "Khoảng Thời Gian 2 Lần Quét Thẻ Liên Tiếp:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(375, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "(Ví dụ 9999)";
            // 
            // numDPort
            // 
            this.numDPort.Location = new System.Drawing.Point(286, 38);
            this.numDPort.Maximum = new decimal(new int[] {
            64000,
            0,
            0,
            0});
            this.numDPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numDPort.Name = "numDPort";
            this.numDPort.Size = new System.Drawing.Size(83, 23);
            this.numDPort.TabIndex = 7;
            this.numDPort.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(283, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "(Khuyến cáo các cổng phải lớn hơn 1024)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(376, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "(Phút)";
            // 
            // numdTime
            // 
            this.numdTime.Location = new System.Drawing.Point(286, 94);
            this.numdTime.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numdTime.Name = "numdTime";
            this.numdTime.Size = new System.Drawing.Size(83, 23);
            this.numdTime.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(88, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Khoảng Thời Gian Vào Và Rời Lớp:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(153, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cổng Kết Nối Thiết Bị:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(0, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 93);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hot Key";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 329);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 40);
            this.panel1.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.Appearance.BackColor2 = System.Drawing.Color.Blue;
            this.btnSave.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseBorderColor = true;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnSave.Location = new System.Drawing.Point(219, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            this.btnSave.ToolTip = "Lưu cập nhật";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.Appearance.BackColor2 = System.Drawing.Color.Blue;
            this.btnClose.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseBorderColor = true;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnClose.Location = new System.Drawing.Point(300, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Thoát";
            this.btnClose.ToolTip = "Thoát thiết lập, trở về trang chính";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmConfigSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::Project_Diem_Danh.Properties.Resources.Backdround;
            this.ClientSize = new System.Drawing.Size(574, 369);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbSettingConnect);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmConfigSetting";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thiết Lập";
            this.Load += new System.EventHandler(this.FrmConfigSetting_Load);
            this.grbSettingConnect.ResumeLayout(false);
            this.grbSettingConnect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numdTime)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbSettingConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numDPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numdTime;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numTimeCard;
        private System.Windows.Forms.Label label7;
    }
}
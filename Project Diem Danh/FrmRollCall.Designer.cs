namespace Project_Diem_Danh
{
    partial class FrmRollCall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRollCall));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus_lbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnl_footer = new System.Windows.Forms.Panel();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlState = new System.Windows.Forms.Panel();
            this.lbxLogCurent = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnchitiet = new System.Windows.Forms.Button();
            this.txtNoCard = new DevExpress.XtraEditors.TextEdit();
            this.txtIdCoPhep = new DevExpress.XtraEditors.TextEdit();
            this.btnSaveNoCard_Sabbatical = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBithday = new System.Windows.Forms.DateTimePicker();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblID = new System.Windows.Forms.Label();
            this.Address = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.pnl_footer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlState.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoCard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdCoPhep.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus_lbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 518);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(893, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatus_lbl
            // 
            this.toolStripStatus_lbl.Name = "toolStripStatus_lbl";
            this.toolStripStatus_lbl.Size = new System.Drawing.Size(101, 17);
            this.toolStripStatus_lbl.Text = "Tình trạng kết nối";
            // 
            // pnl_footer
            // 
            this.pnl_footer.BackColor = System.Drawing.Color.White;
            this.pnl_footer.Controls.Add(this.progressPanel1);
            this.pnl_footer.Controls.Add(this.btnSaveData);
            this.pnl_footer.Controls.Add(this.btnStop);
            this.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_footer.Location = new System.Drawing.Point(0, 477);
            this.pnl_footer.Name = "pnl_footer";
            this.pnl_footer.Size = new System.Drawing.Size(893, 41);
            this.pnl_footer.TabIndex = 1;
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.progressPanel1.AppearanceCaption.Options.UseFont = true;
            this.progressPanel1.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.progressPanel1.AppearanceDescription.Options.UseFont = true;
            this.progressPanel1.Caption = "Xin Chờ";
            this.progressPanel1.Description = "Đang Thiết Lập Kết Nối.....";
            this.progressPanel1.Location = new System.Drawing.Point(0, 1);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(179, 38);
            this.progressPanel1.TabIndex = 4;
            this.progressPanel1.Text = "progressPanel1";
            // 
            // btnSaveData
            // 
            this.btnSaveData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveData.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveData.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSaveData.FlatAppearance.BorderSize = 0;
            this.btnSaveData.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkOrange;
            this.btnSaveData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(33)))), ((int)(((byte)(122)))));
            this.btnSaveData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnSaveData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveData.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveData.ForeColor = System.Drawing.Color.Black;
            this.btnSaveData.Image = global::Project_Diem_Danh.Properties.Resources.Save_24px;
            this.btnSaveData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveData.Location = new System.Drawing.Point(676, 0);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(115, 41);
            this.btnSaveData.TabIndex = 3;
            this.btnSaveData.Text = "Lưu Dữ Liệu";
            this.btnSaveData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveData.UseVisualStyleBackColor = false;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkOrange;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(33)))), ((int)(((byte)(122)))));
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.Black;
            this.btnStop.Image = global::Project_Diem_Danh.Properties.Resources.Exit_24px;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.Location = new System.Drawing.Point(793, 0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(98, 41);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Kết Thúc";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.pnlState);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(893, 477);
            this.panel2.TabIndex = 2;
            // 
            // pnlState
            // 
            this.pnlState.BackColor = System.Drawing.Color.Transparent;
            this.pnlState.Controls.Add(this.lbxLogCurent);
            this.pnlState.Controls.Add(this.panel1);
            this.pnlState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlState.Location = new System.Drawing.Point(300, 0);
            this.pnlState.Name = "pnlState";
            this.pnlState.Size = new System.Drawing.Size(593, 477);
            this.pnlState.TabIndex = 17;
            // 
            // lbxLogCurent
            // 
            this.lbxLogCurent.AllowColumnReorder = true;
            this.lbxLogCurent.BackColor = System.Drawing.Color.White;
            this.lbxLogCurent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxLogCurent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxLogCurent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxLogCurent.Location = new System.Drawing.Point(0, 0);
            this.lbxLogCurent.Name = "lbxLogCurent";
            this.lbxLogCurent.Size = new System.Drawing.Size(593, 276);
            this.lbxLogCurent.TabIndex = 3;
            this.lbxLogCurent.UseCompatibleStateImageBehavior = false;
            this.lbxLogCurent.View = System.Windows.Forms.View.Details;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnchitiet);
            this.panel1.Controls.Add(this.txtNoCard);
            this.panel1.Controls.Add(this.txtIdCoPhep);
            this.panel1.Controls.Add(this.btnSaveNoCard_Sabbatical);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 276);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 201);
            this.panel1.TabIndex = 1;
            // 
            // btnchitiet
            // 
            this.btnchitiet.FlatAppearance.BorderSize = 0;
            this.btnchitiet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(33)))), ((int)(((byte)(122)))));
            this.btnchitiet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnchitiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnchitiet.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnchitiet.ForeColor = System.Drawing.Color.Blue;
            this.btnchitiet.Location = new System.Drawing.Point(386, 169);
            this.btnchitiet.Name = "btnchitiet";
            this.btnchitiet.Size = new System.Drawing.Size(152, 29);
            this.btnchitiet.TabIndex = 14;
            this.btnchitiet.Text = "Xem hướng dẫn chi tiết";
            this.btnchitiet.UseVisualStyleBackColor = true;
            this.btnchitiet.Click += new System.EventHandler(this.btnchitiet_Click);
            // 
            // txtNoCard
            // 
            this.txtNoCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoCard.EditValue = "";
            this.txtNoCard.Location = new System.Drawing.Point(31, 27);
            this.txtNoCard.Name = "txtNoCard";
            this.txtNoCard.Properties.NullText = "CCCT15B009; CCCT15B010; ...";
            this.txtNoCard.Size = new System.Drawing.Size(527, 20);
            this.txtNoCard.TabIndex = 13;
            // 
            // txtIdCoPhep
            // 
            this.txtIdCoPhep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdCoPhep.EditValue = "";
            this.txtIdCoPhep.Location = new System.Drawing.Point(31, 97);
            this.txtIdCoPhep.Name = "txtIdCoPhep";
            this.txtIdCoPhep.Properties.MaxLength = 1000;
            this.txtIdCoPhep.Properties.NullText = "Ví dụ: CCT15B09 - Bị ốm; CCT15B01 - Bận họp đoàn trường; ...";
            this.txtIdCoPhep.Size = new System.Drawing.Size(527, 20);
            this.txtIdCoPhep.TabIndex = 12;
            // 
            // btnSaveNoCard_Sabbatical
            // 
            this.btnSaveNoCard_Sabbatical.FlatAppearance.BorderSize = 0;
            this.btnSaveNoCard_Sabbatical.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(33)))), ((int)(((byte)(122)))));
            this.btnSaveNoCard_Sabbatical.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnSaveNoCard_Sabbatical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveNoCard_Sabbatical.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNoCard_Sabbatical.ForeColor = System.Drawing.Color.Black;
            this.btnSaveNoCard_Sabbatical.Location = new System.Drawing.Point(34, 144);
            this.btnSaveNoCard_Sabbatical.Name = "btnSaveNoCard_Sabbatical";
            this.btnSaveNoCard_Sabbatical.Size = new System.Drawing.Size(60, 27);
            this.btnSaveNoCard_Sabbatical.TabIndex = 9;
            this.btnSaveNoCard_Sabbatical.Text = "Lưu";
            this.btnSaveNoCard_Sabbatical.UseVisualStyleBackColor = true;
            this.btnSaveNoCard_Sabbatical.Click += new System.EventHandler(this.btnSaveNoCard_Sabbatical_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(28, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(246, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "Nhập mã sinh viên không mang thẻ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(36, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(353, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Lưu ý: Các mã cách nhau bằng dấu chấm phẫy ( ; )";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhập mã sinh viên vắng có phép và lí do:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 477);
            this.panel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.txtBithday);
            this.groupBox1.Controls.Add(this.picImage);
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.Controls.Add(this.Address);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtSex);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtClass);
            this.groupBox1.Controls.Add(this.txtFullName);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 477);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sinh viên";
            // 
            // txtBithday
            // 
            this.txtBithday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtBithday.Location = new System.Drawing.Point(78, 351);
            this.txtBithday.Name = "txtBithday";
            this.txtBithday.Size = new System.Drawing.Size(158, 23);
            this.txtBithday.TabIndex = 23;
            // 
            // picImage
            // 
            this.picImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picImage.BackColor = System.Drawing.Color.Transparent;
            this.picImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Image = global::Project_Diem_Danh.Properties.Resources.VIETHANIT_LOGO;
            this.picImage.Location = new System.Drawing.Point(68, 25);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(168, 184);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 22;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            this.picImage.DoubleClick += new System.EventHandler(this.picImage_DoubleClick);
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblID.BackColor = System.Drawing.Color.Transparent;
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblID.Location = new System.Drawing.Point(78, 213);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(148, 23);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "ID";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Address
            // 
            this.Address.AutoSize = true;
            this.Address.BackColor = System.Drawing.Color.Transparent;
            this.Address.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Address.ForeColor = System.Drawing.Color.White;
            this.Address.Location = new System.Drawing.Point(28, 386);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(42, 14);
            this.Address.TabIndex = 21;
            this.Address.Text = "Địa chỉ";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(78, 383);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(158, 23);
            this.txtAddress.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(17, 323);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 14);
            this.label7.TabIndex = 19;
            this.label7.Text = "Giới Tính";
            // 
            // txtSex
            // 
            this.txtSex.Location = new System.Drawing.Point(78, 320);
            this.txtSex.Name = "txtSex";
            this.txtSex.ReadOnly = true;
            this.txtSex.Size = new System.Drawing.Size(158, 23);
            this.txtSex.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(48, 415);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 14);
            this.label5.TabIndex = 16;
            this.label5.Text = "Lớp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 14);
            this.label4.TabIndex = 15;
            this.label4.Text = "Ngày sinh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "Họ và tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(27, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "Mã SV";
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(78, 412);
            this.txtClass.Name = "txtClass";
            this.txtClass.ReadOnly = true;
            this.txtClass.Size = new System.Drawing.Size(158, 23);
            this.txtClass.TabIndex = 12;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(78, 289);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(158, 23);
            this.txtFullName.TabIndex = 10;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(78, 257);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(158, 23);
            this.txtCode.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(31, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(357, 14);
            this.label9.TabIndex = 15;
            this.label9.Text = "Ví dụ: CCT15B09 - Bị ốm; CCT15B01 - Bận họp đoàn trường; ...";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(28, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(177, 14);
            this.label10.TabIndex = 16;
            this.label10.Text = "CCCT15B009; CCCT15B010; ...";
            // 
            // FrmRollCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::Project_Diem_Danh.Properties.Resources.Backdround;
            this.ClientSize = new System.Drawing.Size(893, 540);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_footer);
            this.Controls.Add(this.statusStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FrmRollCall";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Điểm Danh";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRollCall_FormClosing);
            this.Load += new System.EventHandler(this.RollCall_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnl_footer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlState.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoCard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdCoPhep.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel pnl_footer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_lbl;
        private System.Windows.Forms.Panel pnlState;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSaveNoCard_Sabbatical;
        private System.Windows.Forms.ListView lbxLogCurent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker txtBithday;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label Address;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtCode;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private System.Windows.Forms.Button btnchitiet;
        private DevExpress.XtraEditors.TextEdit txtNoCard;
        private DevExpress.XtraEditors.TextEdit txtIdCoPhep;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}
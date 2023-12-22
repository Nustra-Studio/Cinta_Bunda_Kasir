namespace KasirApp.GUI
{
    partial class MasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.divisiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.barangToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.barangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laporanKartuStokBarangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gudangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.transferAntarGudangToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stockOpnameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postingStockOpnameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penyesuaianToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.laporanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kartuStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penjualanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pOSSMToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.returPOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penjualanPOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supervisorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setGroupUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tambahUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.laporanAktifitasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batalPostingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pOSSMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penyesuaianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferAntarGudangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opnameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returPOSToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.resetStokKeNolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel = new Guna.UI.WinForms.GunaGradient2Panel();
            this.background = new Guna.UI.WinForms.GunaPictureBox();
            this.BackgroundLayer2 = new Guna.UI.WinForms.GunaPictureBox();
            this.menuStrip1.SuspendLayout();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundLayer2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.masterToolStripMenuItem,
            this.gudangToolStripMenuItem,
            this.penjualanToolStripMenuItem,
            this.supervisorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1571, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Click += new System.EventHandler(this.menuStrip1_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.logOutToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(142, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem,
            this.barangToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.divisiToolStripMenuItem,
            this.toolStripSeparator1,
            this.barangToolStripMenuItem1,
            this.toolStripSeparator2});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // divisiToolStripMenuItem
            // 
            this.divisiToolStripMenuItem.Name = "divisiToolStripMenuItem";
            this.divisiToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.divisiToolStripMenuItem.Text = "Kategori";
            this.divisiToolStripMenuItem.Click += new System.EventHandler(this.divisiToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // barangToolStripMenuItem1
            // 
            this.barangToolStripMenuItem1.Name = "barangToolStripMenuItem1";
            this.barangToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.barangToolStripMenuItem1.Text = "Barang ";
            this.barangToolStripMenuItem1.Click += new System.EventHandler(this.barangToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // barangToolStripMenuItem
            // 
            this.barangToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.laporanKartuStokBarangToolStripMenuItem});
            this.barangToolStripMenuItem.Name = "barangToolStripMenuItem";
            this.barangToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.barangToolStripMenuItem.Text = "Laporan";
            // 
            // laporanKartuStokBarangToolStripMenuItem
            // 
            this.laporanKartuStokBarangToolStripMenuItem.Name = "laporanKartuStokBarangToolStripMenuItem";
            this.laporanKartuStokBarangToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
            this.laporanKartuStokBarangToolStripMenuItem.Text = "Laporan Kartu Stok Barang";
            this.laporanKartuStokBarangToolStripMenuItem.Click += new System.EventHandler(this.laporanKartuStokBarangToolStripMenuItem_Click);
            // 
            // gudangToolStripMenuItem
            // 
            this.gudangToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem1,
            this.laporanToolStripMenuItem});
            this.gudangToolStripMenuItem.Name = "gudangToolStripMenuItem";
            this.gudangToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.gudangToolStripMenuItem.Text = "Gudang";
            // 
            // dataToolStripMenuItem1
            // 
            this.dataToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transferAntarGudangToolStripMenuItem1,
            this.stockOpnameToolStripMenuItem,
            this.postingStockOpnameToolStripMenuItem,
            this.penyesuaianToolStripMenuItem2});
            this.dataToolStripMenuItem1.Name = "dataToolStripMenuItem1";
            this.dataToolStripMenuItem1.Size = new System.Drawing.Size(146, 26);
            this.dataToolStripMenuItem1.Text = "Data";
            // 
            // transferAntarGudangToolStripMenuItem1
            // 
            this.transferAntarGudangToolStripMenuItem1.Name = "transferAntarGudangToolStripMenuItem1";
            this.transferAntarGudangToolStripMenuItem1.Size = new System.Drawing.Size(241, 26);
            this.transferAntarGudangToolStripMenuItem1.Text = "Transfer Antar Gudang";
            this.transferAntarGudangToolStripMenuItem1.Click += new System.EventHandler(this.transferAntarGudangToolStripMenuItem1_Click);
            // 
            // stockOpnameToolStripMenuItem
            // 
            this.stockOpnameToolStripMenuItem.Name = "stockOpnameToolStripMenuItem";
            this.stockOpnameToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.stockOpnameToolStripMenuItem.Text = "Stock Opname";
            this.stockOpnameToolStripMenuItem.Click += new System.EventHandler(this.stockOpnameToolStripMenuItem_Click);
            // 
            // postingStockOpnameToolStripMenuItem
            // 
            this.postingStockOpnameToolStripMenuItem.Name = "postingStockOpnameToolStripMenuItem";
            this.postingStockOpnameToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.postingStockOpnameToolStripMenuItem.Text = "Posting Stock Opname";
            this.postingStockOpnameToolStripMenuItem.Click += new System.EventHandler(this.postingStockOpnameToolStripMenuItem_Click);
            // 
            // penyesuaianToolStripMenuItem2
            // 
            this.penyesuaianToolStripMenuItem2.Name = "penyesuaianToolStripMenuItem2";
            this.penyesuaianToolStripMenuItem2.Size = new System.Drawing.Size(241, 26);
            this.penyesuaianToolStripMenuItem2.Text = "Penyesuaian";
            this.penyesuaianToolStripMenuItem2.Click += new System.EventHandler(this.penyesuaianToolStripMenuItem2_Click);
            // 
            // laporanToolStripMenuItem
            // 
            this.laporanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kartuStockToolStripMenuItem});
            this.laporanToolStripMenuItem.Name = "laporanToolStripMenuItem";
            this.laporanToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.laporanToolStripMenuItem.Text = "Laporan";
            // 
            // kartuStockToolStripMenuItem
            // 
            this.kartuStockToolStripMenuItem.Name = "kartuStockToolStripMenuItem";
            this.kartuStockToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.kartuStockToolStripMenuItem.Text = "Kartu Stock";
            this.kartuStockToolStripMenuItem.Click += new System.EventHandler(this.kartuStockToolStripMenuItem_Click);
            // 
            // penjualanToolStripMenuItem
            // 
            this.penjualanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transaksiToolStripMenuItem,
            this.returToolStripMenuItem});
            this.penjualanToolStripMenuItem.Name = "penjualanToolStripMenuItem";
            this.penjualanToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.penjualanToolStripMenuItem.Text = "Penjualan";
            // 
            // transaksiToolStripMenuItem
            // 
            this.transaksiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pOSSMToolStripMenuItem1,
            this.returPOSToolStripMenuItem});
            this.transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            this.transaksiToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.transaksiToolStripMenuItem.Text = "Transaksi ";
            // 
            // pOSSMToolStripMenuItem1
            // 
            this.pOSSMToolStripMenuItem1.Name = "pOSSMToolStripMenuItem1";
            this.pOSSMToolStripMenuItem1.Size = new System.Drawing.Size(158, 26);
            this.pOSSMToolStripMenuItem1.Text = "POS SM";
            this.pOSSMToolStripMenuItem1.Click += new System.EventHandler(this.pOSSMToolStripMenuItem1_Click);
            // 
            // returPOSToolStripMenuItem
            // 
            this.returPOSToolStripMenuItem.Name = "returPOSToolStripMenuItem";
            this.returPOSToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.returPOSToolStripMenuItem.Text = "Retur POS";
            this.returPOSToolStripMenuItem.Click += new System.EventHandler(this.returPOSToolStripMenuItem_Click);
            // 
            // returToolStripMenuItem
            // 
            this.returToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.penjualanPOSToolStripMenuItem});
            this.returToolStripMenuItem.Name = "returToolStripMenuItem";
            this.returToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.returToolStripMenuItem.Text = "Laporan";
            // 
            // penjualanPOSToolStripMenuItem
            // 
            this.penjualanPOSToolStripMenuItem.Name = "penjualanPOSToolStripMenuItem";
            this.penjualanPOSToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.penjualanPOSToolStripMenuItem.Text = "Penjualan POS";
            this.penjualanPOSToolStripMenuItem.Click += new System.EventHandler(this.penjualanPOSToolStripMenuItem_Click);
            // 
            // supervisorToolStripMenuItem
            // 
            this.supervisorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem,
            this.batalPostingToolStripMenuItem,
            this.settingToolStripMenuItem});
            this.supervisorToolStripMenuItem.Name = "supervisorToolStripMenuItem";
            this.supervisorToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.supervisorToolStripMenuItem.Text = "Supervisor";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingDataToolStripMenuItem,
            this.setGroupUserToolStripMenuItem,
            this.tambahUserToolStripMenuItem,
            this.toolStripSeparator4,
            this.laporanAktifitasToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.setupToolStripMenuItem.Text = "Setup";
            // 
            // settingDataToolStripMenuItem
            // 
            this.settingDataToolStripMenuItem.Name = "settingDataToolStripMenuItem";
            this.settingDataToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.settingDataToolStripMenuItem.Text = "Setting Data";
            this.settingDataToolStripMenuItem.Click += new System.EventHandler(this.settingDataToolStripMenuItem_Click);
            // 
            // setGroupUserToolStripMenuItem
            // 
            this.setGroupUserToolStripMenuItem.Name = "setGroupUserToolStripMenuItem";
            this.setGroupUserToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.setGroupUserToolStripMenuItem.Text = "Set Priviledges User";
            this.setGroupUserToolStripMenuItem.Click += new System.EventHandler(this.setGroupUserToolStripMenuItem_Click);
            // 
            // tambahUserToolStripMenuItem
            // 
            this.tambahUserToolStripMenuItem.Name = "tambahUserToolStripMenuItem";
            this.tambahUserToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.tambahUserToolStripMenuItem.Text = "Tambah User";
            this.tambahUserToolStripMenuItem.Click += new System.EventHandler(this.tambahUserToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(221, 6);
            // 
            // laporanAktifitasToolStripMenuItem
            // 
            this.laporanAktifitasToolStripMenuItem.Name = "laporanAktifitasToolStripMenuItem";
            this.laporanAktifitasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.laporanAktifitasToolStripMenuItem.Text = "Laporan Aktifitas";
            this.laporanAktifitasToolStripMenuItem.Click += new System.EventHandler(this.laporanAktifitasToolStripMenuItem_Click);
            // 
            // batalPostingToolStripMenuItem
            // 
            this.batalPostingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pOSSMToolStripMenuItem,
            this.penyesuaianToolStripMenuItem,
            this.transferAntarGudangToolStripMenuItem,
            this.opnameToolStripMenuItem,
            this.returPOSToolStripMenuItem1});
            this.batalPostingToolStripMenuItem.Name = "batalPostingToolStripMenuItem";
            this.batalPostingToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.batalPostingToolStripMenuItem.Text = "Batal Posting";
            // 
            // pOSSMToolStripMenuItem
            // 
            this.pOSSMToolStripMenuItem.Name = "pOSSMToolStripMenuItem";
            this.pOSSMToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.pOSSMToolStripMenuItem.Text = "POS SM";
            this.pOSSMToolStripMenuItem.Click += new System.EventHandler(this.pOSSMToolStripMenuItem_Click);
            // 
            // penyesuaianToolStripMenuItem
            // 
            this.penyesuaianToolStripMenuItem.Name = "penyesuaianToolStripMenuItem";
            this.penyesuaianToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.penyesuaianToolStripMenuItem.Text = "Penyesuaian ";
            this.penyesuaianToolStripMenuItem.Click += new System.EventHandler(this.penyesuaianToolStripMenuItem_Click);
            // 
            // transferAntarGudangToolStripMenuItem
            // 
            this.transferAntarGudangToolStripMenuItem.Name = "transferAntarGudangToolStripMenuItem";
            this.transferAntarGudangToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.transferAntarGudangToolStripMenuItem.Text = "Transfer Antar Gudang";
            this.transferAntarGudangToolStripMenuItem.Click += new System.EventHandler(this.transferAntarGudangToolStripMenuItem_Click);
            // 
            // opnameToolStripMenuItem
            // 
            this.opnameToolStripMenuItem.Name = "opnameToolStripMenuItem";
            this.opnameToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.opnameToolStripMenuItem.Text = "Opname";
            this.opnameToolStripMenuItem.Click += new System.EventHandler(this.opnameToolStripMenuItem_Click_1);
            // 
            // returPOSToolStripMenuItem1
            // 
            this.returPOSToolStripMenuItem1.Name = "returPOSToolStripMenuItem1";
            this.returPOSToolStripMenuItem1.Size = new System.Drawing.Size(240, 26);
            this.returPOSToolStripMenuItem1.Text = "Retur POS";
            this.returPOSToolStripMenuItem1.Click += new System.EventHandler(this.returPOSToolStripMenuItem1_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.resetStokKeNolToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(221, 6);
            // 
            // resetStokKeNolToolStripMenuItem
            // 
            this.resetStokKeNolToolStripMenuItem.Name = "resetStokKeNolToolStripMenuItem";
            this.resetStokKeNolToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.resetStokKeNolToolStripMenuItem.Text = "Reset Stok Ke Nol";
            this.resetStokKeNolToolStripMenuItem.Click += new System.EventHandler(this.resetStokKeNolToolStripMenuItem_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Controls.Add(this.background);
            this.MainPanel.Controls.Add(this.BackgroundLayer2);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.GradientColor1 = System.Drawing.SystemColors.Control;
            this.MainPanel.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(243)))), ((int)(((byte)(189)))));
            this.MainPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.MainPanel.Location = new System.Drawing.Point(0, 28);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1571, 740);
            this.MainPanel.TabIndex = 1;
            // 
            // background
            // 
            this.background.BaseColor = System.Drawing.Color.White;
            this.background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.background.Image = global::KasirApp.Properties.Resources.Wallpaper_Kasir;
            this.background.Location = new System.Drawing.Point(0, 0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(1571, 740);
            this.background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.background.TabIndex = 0;
            this.background.TabStop = false;
            // 
            // BackgroundLayer2
            // 
            this.BackgroundLayer2.BaseColor = System.Drawing.Color.White;
            this.BackgroundLayer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackgroundLayer2.Image = global::KasirApp.Properties.Resources.Wallpaper_Kasir;
            this.BackgroundLayer2.Location = new System.Drawing.Point(0, 0);
            this.BackgroundLayer2.Name = "BackgroundLayer2";
            this.BackgroundLayer2.Size = new System.Drawing.Size(1571, 740);
            this.BackgroundLayer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BackgroundLayer2.TabIndex = 1;
            this.BackgroundLayer2.TabStop = false;
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1571, 768);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MasterForm";
            this.Text = "Cinta Bunda - Master Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MasterForm_FormClosed);
            this.Load += new System.EventHandler(this.MasterForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundLayer2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gudangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penjualanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supervisorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batalPostingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pOSSMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private Guna.UI.WinForms.GunaGradient2Panel MainPanel;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem divisiToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem barangToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem barangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penyesuaianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferAntarGudangToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem resetStokKeNolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setGroupUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem laporanAktifitasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laporanKartuStokBarangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tambahUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem transferAntarGudangToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stockOpnameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postingStockOpnameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penyesuaianToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem laporanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kartuStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transaksiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pOSSMToolStripMenuItem1;
        private Guna.UI.WinForms.GunaPictureBox background;
        private Guna.UI.WinForms.GunaPictureBox BackgroundLayer2;
        private System.Windows.Forms.ToolStripMenuItem returToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returPOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penjualanPOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opnameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returPOSToolStripMenuItem1;
    }
}
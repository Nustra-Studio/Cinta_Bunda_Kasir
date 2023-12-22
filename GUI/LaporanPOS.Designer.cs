
namespace KasirApp.GUI
{
    partial class LaporanPOS
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tgl2 = new Guna.UI.WinForms.GunaDateTimePicker();
            this.tgl1 = new Guna.UI.WinForms.GunaDateTimePicker();
            this.btnBatal = new Guna.UI.WinForms.GunaGradientButton();
            this.btnProses = new Guna.UI.WinForms.GunaGradientButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboKategori = new Guna.UI.WinForms.GunaComboBox();
            this.cboUser = new Guna.UI.WinForms.GunaComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboUser);
            this.groupBox1.Controls.Add(this.cboKategori);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tgl2);
            this.groupBox1.Controls.Add(this.tgl1);
            this.groupBox1.Controls.Add(this.btnBatal);
            this.groupBox1.Controls.Add(this.btnProses);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(549, 515);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "  ";
            // 
            // tgl2
            // 
            this.tgl2.BaseColor = System.Drawing.Color.White;
            this.tgl2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(243)))), ((int)(((byte)(189)))));
            this.tgl2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tgl2.CustomFormat = null;
            this.tgl2.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.tgl2.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(243)))), ((int)(((byte)(189)))));
            this.tgl2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tgl2.ForeColor = System.Drawing.Color.Black;
            this.tgl2.Location = new System.Drawing.Point(312, 320);
            this.tgl2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.tgl2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.tgl2.Name = "tgl2";
            this.tgl2.OnHoverBaseColor = System.Drawing.Color.White;
            this.tgl2.OnHoverBorderColor = System.Drawing.Color.Green;
            this.tgl2.OnHoverForeColor = System.Drawing.Color.Green;
            this.tgl2.OnPressedColor = System.Drawing.Color.Black;
            this.tgl2.Size = new System.Drawing.Size(233, 40);
            this.tgl2.TabIndex = 7;
            this.tgl2.Text = "08 August 2023";
            this.tgl2.Value = new System.DateTime(2023, 8, 8, 21, 37, 14, 572);
            // 
            // tgl1
            // 
            this.tgl1.BaseColor = System.Drawing.Color.White;
            this.tgl1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(243)))), ((int)(((byte)(189)))));
            this.tgl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tgl1.CustomFormat = null;
            this.tgl1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.tgl1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(243)))), ((int)(((byte)(189)))));
            this.tgl1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tgl1.ForeColor = System.Drawing.Color.Black;
            this.tgl1.Location = new System.Drawing.Point(8, 320);
            this.tgl1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.tgl1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.tgl1.Name = "tgl1";
            this.tgl1.OnHoverBaseColor = System.Drawing.Color.White;
            this.tgl1.OnHoverBorderColor = System.Drawing.Color.Green;
            this.tgl1.OnHoverForeColor = System.Drawing.Color.Green;
            this.tgl1.OnPressedColor = System.Drawing.Color.Black;
            this.tgl1.Size = new System.Drawing.Size(236, 40);
            this.tgl1.TabIndex = 2;
            this.tgl1.Text = "08 August 2023";
            this.tgl1.Value = new System.DateTime(2023, 8, 8, 21, 37, 14, 572);
            // 
            // btnBatal
            // 
            this.btnBatal.AnimationHoverSpeed = 0.07F;
            this.btnBatal.AnimationSpeed = 0.03F;
            this.btnBatal.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.btnBatal.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.btnBatal.BorderColor = System.Drawing.Color.Black;
            this.btnBatal.BorderSize = 1;
            this.btnBatal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatal.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBatal.FocusedColor = System.Drawing.Color.Empty;
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBatal.ForeColor = System.Drawing.Color.Black;
            this.btnBatal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBatal.Image = null;
            this.btnBatal.ImageSize = new System.Drawing.Size(20, 20);
            this.btnBatal.Location = new System.Drawing.Point(279, 467);
            this.btnBatal.Margin = new System.Windows.Forms.Padding(4);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.btnBatal.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.btnBatal.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnBatal.OnHoverForeColor = System.Drawing.Color.White;
            this.btnBatal.OnHoverImage = null;
            this.btnBatal.OnPressedColor = System.Drawing.Color.Black;
            this.btnBatal.Size = new System.Drawing.Size(105, 37);
            this.btnBatal.TabIndex = 6;
            this.btnBatal.Text = "Batal";
            this.btnBatal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // btnProses
            // 
            this.btnProses.AnimationHoverSpeed = 0.07F;
            this.btnProses.AnimationSpeed = 0.03F;
            this.btnProses.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.btnProses.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.btnProses.BorderColor = System.Drawing.Color.Black;
            this.btnProses.BorderSize = 1;
            this.btnProses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProses.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnProses.FocusedColor = System.Drawing.Color.Empty;
            this.btnProses.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnProses.ForeColor = System.Drawing.Color.Black;
            this.btnProses.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnProses.Image = null;
            this.btnProses.ImageSize = new System.Drawing.Size(20, 20);
            this.btnProses.Location = new System.Drawing.Point(165, 467);
            this.btnProses.Margin = new System.Windows.Forms.Padding(4);
            this.btnProses.Name = "btnProses";
            this.btnProses.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.btnProses.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.btnProses.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnProses.OnHoverForeColor = System.Drawing.Color.White;
            this.btnProses.OnHoverImage = null;
            this.btnProses.OnPressedColor = System.Drawing.Color.Black;
            this.btnProses.Size = new System.Drawing.Size(105, 37);
            this.btnProses.TabIndex = 6;
            this.btnProses.Text = "Proses";
            this.btnProses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnProses.Click += new System.EventHandler(this.btnProses_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(262, 329);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "s/d";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(242, 293);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Periode";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.Black;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Items.AddRange(new object[] {
            "1.Laporan Point Of Sales Detail",
            "2.Laporan Point Of Sales Harian Detail",
            "3.Laporan Point Of Sales Harian Summary",
            "4.Laporan Point Of Sales per Departement",
            "5.Laporan Point Of Sales per Kasir Detail",
            "6.Laporan Point Of Sales per Kasir Summary",
            "7.Laporan Point Of Sales per Kategori Detail",
            "8.Laporan Point Of Sales per Kategori Summary",
            "9.Laporan Point Of Sales per Kategori Terbanyak",
            "10.Laporan Point Of Sales per Kategori Terbanyak Summary"});
            this.listBox1.Location = new System.Drawing.Point(8, 25);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(537, 254);
            this.listBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 373);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Kategori :";
            // 
            // cboKategori
            // 
            this.cboKategori.BackColor = System.Drawing.Color.Transparent;
            this.cboKategori.BaseColor = System.Drawing.Color.White;
            this.cboKategori.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.cboKategori.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKategori.FocusedColor = System.Drawing.Color.Empty;
            this.cboKategori.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKategori.ForeColor = System.Drawing.Color.Black;
            this.cboKategori.FormattingEnabled = true;
            this.cboKategori.Location = new System.Drawing.Point(112, 371);
            this.cboKategori.Margin = new System.Windows.Forms.Padding(4);
            this.cboKategori.Name = "cboKategori";
            this.cboKategori.OnHoverItemBaseColor = System.Drawing.Color.Lime;
            this.cboKategori.OnHoverItemForeColor = System.Drawing.Color.Black;
            this.cboKategori.Size = new System.Drawing.Size(429, 37);
            this.cboKategori.TabIndex = 9;
            // 
            // cboUser
            // 
            this.cboUser.BackColor = System.Drawing.Color.Transparent;
            this.cboUser.BaseColor = System.Drawing.Color.White;
            this.cboUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.cboUser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUser.FocusedColor = System.Drawing.Color.Empty;
            this.cboUser.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUser.ForeColor = System.Drawing.Color.Black;
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point(112, 416);
            this.cboUser.Margin = new System.Windows.Forms.Padding(4);
            this.cboUser.Name = "cboUser";
            this.cboUser.OnHoverItemBaseColor = System.Drawing.Color.Lime;
            this.cboUser.OnHoverItemForeColor = System.Drawing.Color.Black;
            this.cboUser.Size = new System.Drawing.Size(429, 37);
            this.cboUser.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 421);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "User :";
            // 
            // LaporanPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(555, 521);
            this.Controls.Add(this.groupBox1);
            this.Name = "LaporanPOS";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = " Laporan POS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LaporanPOS_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI.WinForms.GunaDateTimePicker tgl2;
        private Guna.UI.WinForms.GunaDateTimePicker tgl1;
        private Guna.UI.WinForms.GunaGradientButton btnBatal;
        private Guna.UI.WinForms.GunaGradientButton btnProses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaComboBox cboKategori;
        private Guna.UI.WinForms.GunaComboBox cboUser;
        private System.Windows.Forms.Label label4;
    }
}
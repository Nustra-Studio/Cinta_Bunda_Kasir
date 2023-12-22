
namespace KasirApp.GUI.Supervisor
{
    partial class SetGroup
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKode = new Guna.UI.WinForms.GunaTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNama = new Guna.UI.WinForms.GunaTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.chkPenjualan = new System.Windows.Forms.CheckBox();
            this.chkSupervisor = new System.Windows.Forms.CheckBox();
            this.chkGudang = new System.Windows.Forms.CheckBox();
            this.chkMaster = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kode :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama :";
            // 
            // txtKode
            // 
            this.txtKode.BackColor = System.Drawing.SystemColors.Control;
            this.txtKode.BaseColor = System.Drawing.Color.White;
            this.txtKode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.txtKode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKode.FocusedBaseColor = System.Drawing.Color.White;
            this.txtKode.FocusedBorderColor = System.Drawing.Color.Lime;
            this.txtKode.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtKode.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtKode.Location = new System.Drawing.Point(100, 33);
            this.txtKode.Margin = new System.Windows.Forms.Padding(4);
            this.txtKode.Name = "txtKode";
            this.txtKode.PasswordChar = '\0';
            this.txtKode.SelectedText = "";
            this.txtKode.Size = new System.Drawing.Size(213, 37);
            this.txtKode.TabIndex = 0;
            this.txtKode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RaiseKeydown);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.groupBox1.Controls.Add(this.txtNama);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtKode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 137);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Group (Roles Priviledges)";
            // 
            // txtNama
            // 
            this.txtNama.BackColor = System.Drawing.SystemColors.Control;
            this.txtNama.BaseColor = System.Drawing.Color.White;
            this.txtNama.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.txtNama.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNama.FocusedBaseColor = System.Drawing.Color.White;
            this.txtNama.FocusedBorderColor = System.Drawing.Color.Lime;
            this.txtNama.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNama.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNama.Location = new System.Drawing.Point(100, 78);
            this.txtNama.Margin = new System.Windows.Forms.Padding(4);
            this.txtNama.Name = "txtNama";
            this.txtNama.PasswordChar = '\0';
            this.txtNama.SelectedText = "";
            this.txtNama.Size = new System.Drawing.Size(213, 37);
            this.txtNama.TabIndex = 1;
            this.txtNama.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RaiseKeydown);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(12, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 318);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List Akses";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(227)))), ((int)(((byte)(182)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkPenjualan);
            this.panel1.Controls.Add(this.chkSupervisor);
            this.panel1.Controls.Add(this.chkGudang);
            this.panel1.Controls.Add(this.chkMaster);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 297);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(46, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tekan Enter Untuk Menyimpan";
            this.label3.Visible = false;
            // 
            // chkPenjualan
            // 
            this.chkPenjualan.AutoSize = true;
            this.chkPenjualan.Enabled = false;
            this.chkPenjualan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPenjualan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkPenjualan.Location = new System.Drawing.Point(20, 188);
            this.chkPenjualan.Name = "chkPenjualan";
            this.chkPenjualan.Size = new System.Drawing.Size(148, 33);
            this.chkPenjualan.TabIndex = 3;
            this.chkPenjualan.Text = "Penjualan";
            this.chkPenjualan.UseVisualStyleBackColor = true;
            // 
            // chkSupervisor
            // 
            this.chkSupervisor.AutoSize = true;
            this.chkSupervisor.Enabled = false;
            this.chkSupervisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSupervisor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkSupervisor.Location = new System.Drawing.Point(20, 135);
            this.chkSupervisor.Name = "chkSupervisor";
            this.chkSupervisor.Size = new System.Drawing.Size(156, 33);
            this.chkSupervisor.TabIndex = 2;
            this.chkSupervisor.Text = "Supervisor";
            this.chkSupervisor.UseVisualStyleBackColor = true;
            // 
            // chkGudang
            // 
            this.chkGudang.AutoSize = true;
            this.chkGudang.Enabled = false;
            this.chkGudang.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGudang.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkGudang.Location = new System.Drawing.Point(20, 80);
            this.chkGudang.Name = "chkGudang";
            this.chkGudang.Size = new System.Drawing.Size(124, 33);
            this.chkGudang.TabIndex = 1;
            this.chkGudang.Text = "Gudang";
            this.chkGudang.UseVisualStyleBackColor = true;
            // 
            // chkMaster
            // 
            this.chkMaster.AutoSize = true;
            this.chkMaster.Enabled = false;
            this.chkMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMaster.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkMaster.Location = new System.Drawing.Point(20, 26);
            this.chkMaster.Name = "chkMaster";
            this.chkMaster.Size = new System.Drawing.Size(112, 33);
            this.chkMaster.TabIndex = 0;
            this.chkMaster.Text = "Master";
            this.chkMaster.UseVisualStyleBackColor = true;
            // 
            // SetGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(361, 481);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SetGroup";
            this.Text = "SetGroup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetGroup_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaTextBox txtKode;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI.WinForms.GunaTextBox txtNama;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkMaster;
        private System.Windows.Forms.CheckBox chkSupervisor;
        private System.Windows.Forms.CheckBox chkGudang;
        private System.Windows.Forms.CheckBox chkPenjualan;
        private System.Windows.Forms.Label label3;
    }
}
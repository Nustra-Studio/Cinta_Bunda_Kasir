
namespace KasirApp.GUI.SuperAdmin
{
    partial class SettingKoneksi
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEndpoint = new Guna.UI.WinForms.GunaTextBox();
            this.btnProses = new Guna.UI.WinForms.GunaGradientButton();
            this.btnSimpan = new Guna.UI.WinForms.GunaGradientButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServer = new Guna.UI.WinForms.GunaTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.noHp = new Guna.UI.WinForms.GunaTextBox();
            this.txtDatabase = new Guna.UI.WinForms.GunaTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser = new Guna.UI.WinForms.GunaTextBox();
            this.txtPassword = new Guna.UI.WinForms.GunaTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPort = new Guna.UI.WinForms.GunaTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCabang = new Guna.UI.WinForms.GunaTextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtCabang);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtEndpoint);
            this.panel2.Location = new System.Drawing.Point(503, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(485, 176);
            this.panel2.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Endpoint :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(17, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(178, 20);
            this.label12.TabIndex = 10;
            this.label12.Text = "Setting Endpoint API";
            // 
            // txtEndpoint
            // 
            this.txtEndpoint.BackColor = System.Drawing.SystemColors.Control;
            this.txtEndpoint.BaseColor = System.Drawing.Color.White;
            this.txtEndpoint.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.txtEndpoint.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEndpoint.FocusedBaseColor = System.Drawing.Color.White;
            this.txtEndpoint.FocusedBorderColor = System.Drawing.Color.Lime;
            this.txtEndpoint.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEndpoint.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEndpoint.Location = new System.Drawing.Point(114, 54);
            this.txtEndpoint.Name = "txtEndpoint";
            this.txtEndpoint.PasswordChar = '\0';
            this.txtEndpoint.SelectedText = "";
            this.txtEndpoint.Size = new System.Drawing.Size(319, 37);
            this.txtEndpoint.TabIndex = 0;
            // 
            // btnProses
            // 
            this.btnProses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnProses.Location = new System.Drawing.Point(830, 273);
            this.btnProses.Name = "btnProses";
            this.btnProses.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btnProses.OnHoverBaseColor2 = System.Drawing.Color.LightGreen;
            this.btnProses.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnProses.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnProses.OnHoverImage = null;
            this.btnProses.OnPressedColor = System.Drawing.Color.Black;
            this.btnProses.Size = new System.Drawing.Size(158, 43);
            this.btnProses.TabIndex = 1;
            this.btnProses.Text = "Batal";
            this.btnProses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnProses.Click += new System.EventHandler(this.btnProses_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimpan.AnimationHoverSpeed = 0.07F;
            this.btnSimpan.AnimationSpeed = 0.03F;
            this.btnSimpan.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.btnSimpan.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.btnSimpan.BorderColor = System.Drawing.Color.Black;
            this.btnSimpan.BorderSize = 1;
            this.btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimpan.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSimpan.FocusedColor = System.Drawing.Color.Empty;
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSimpan.ForeColor = System.Drawing.Color.Black;
            this.btnSimpan.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnSimpan.Image = null;
            this.btnSimpan.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSimpan.Location = new System.Drawing.Point(655, 273);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btnSimpan.OnHoverBaseColor2 = System.Drawing.Color.LightGreen;
            this.btnSimpan.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSimpan.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnSimpan.OnHoverImage = null;
            this.btnSimpan.OnPressedColor = System.Drawing.Color.Black;
            this.btnSimpan.Size = new System.Drawing.Size(158, 43);
            this.btnSimpan.TabIndex = 0;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Setting Database Local";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(88, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Port :";
            // 
            // txtServer
            // 
            this.txtServer.BackColor = System.Drawing.SystemColors.Control;
            this.txtServer.BaseColor = System.Drawing.Color.White;
            this.txtServer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.txtServer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtServer.FocusedBaseColor = System.Drawing.Color.White;
            this.txtServer.FocusedBorderColor = System.Drawing.Color.Lime;
            this.txtServer.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtServer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtServer.Location = new System.Drawing.Point(140, 54);
            this.txtServer.Name = "txtServer";
            this.txtServer.PasswordChar = '\0';
            this.txtServer.SelectedText = "";
            this.txtServer.Size = new System.Drawing.Size(306, 32);
            this.txtServer.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Database :";
            // 
            // noHp
            // 
            this.noHp.BackColor = System.Drawing.SystemColors.Control;
            this.noHp.BaseColor = System.Drawing.Color.White;
            this.noHp.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.noHp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.noHp.FocusedBaseColor = System.Drawing.Color.White;
            this.noHp.FocusedBorderColor = System.Drawing.Color.Lime;
            this.noHp.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.noHp.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.noHp.Location = new System.Drawing.Point(140, 98);
            this.noHp.Name = "noHp";
            this.noHp.PasswordChar = '\0';
            this.noHp.SelectedText = "";
            this.noHp.Size = new System.Drawing.Size(0, 32);
            this.noHp.TabIndex = 1;
            // 
            // txtDatabase
            // 
            this.txtDatabase.BackColor = System.Drawing.SystemColors.Control;
            this.txtDatabase.BaseColor = System.Drawing.Color.White;
            this.txtDatabase.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.txtDatabase.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDatabase.FocusedBaseColor = System.Drawing.Color.White;
            this.txtDatabase.FocusedBorderColor = System.Drawing.Color.Lime;
            this.txtDatabase.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDatabase.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDatabase.Location = new System.Drawing.Point(140, 144);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.PasswordChar = '\0';
            this.txtDatabase.SelectedText = "";
            this.txtDatabase.Size = new System.Drawing.Size(265, 32);
            this.txtDatabase.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Server :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(84, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "User :";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.SystemColors.Control;
            this.txtUser.BaseColor = System.Drawing.Color.White;
            this.txtUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.FocusedBaseColor = System.Drawing.Color.White;
            this.txtUser.FocusedBorderColor = System.Drawing.Color.Lime;
            this.txtUser.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUser.Location = new System.Drawing.Point(140, 187);
            this.txtUser.Name = "txtUser";
            this.txtUser.PasswordChar = '\0';
            this.txtUser.SelectedText = "";
            this.txtUser.Size = new System.Drawing.Size(306, 32);
            this.txtUser.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtPassword.BaseColor = System.Drawing.Color.White;
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.FocusedBaseColor = System.Drawing.Color.White;
            this.txtPassword.FocusedBorderColor = System.Drawing.Color.Lime;
            this.txtPassword.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPassword.Location = new System.Drawing.Point(140, 230);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '\0';
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(306, 32);
            this.txtPassword.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(49, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Password :";
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.SystemColors.Control;
            this.txtPort.BaseColor = System.Drawing.Color.White;
            this.txtPort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.txtPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPort.FocusedBaseColor = System.Drawing.Color.White;
            this.txtPort.FocusedBorderColor = System.Drawing.Color.Lime;
            this.txtPort.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPort.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPort.Location = new System.Drawing.Point(140, 98);
            this.txtPort.Name = "txtPort";
            this.txtPort.PasswordChar = '\0';
            this.txtPort.SelectedText = "";
            this.txtPort.Size = new System.Drawing.Size(146, 32);
            this.txtPort.TabIndex = 1;
            this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericOnly);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.panel1.Controls.Add(this.txtPort);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDatabase);
            this.panel1.Controls.Add(this.noHp);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtServer);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 304);
            this.panel1.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(35, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Cabang :";
            // 
            // txtCabang
            // 
            this.txtCabang.BackColor = System.Drawing.SystemColors.Control;
            this.txtCabang.BaseColor = System.Drawing.Color.White;
            this.txtCabang.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.txtCabang.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCabang.FocusedBaseColor = System.Drawing.Color.White;
            this.txtCabang.FocusedBorderColor = System.Drawing.Color.Lime;
            this.txtCabang.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCabang.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCabang.Location = new System.Drawing.Point(114, 106);
            this.txtCabang.Name = "txtCabang";
            this.txtCabang.PasswordChar = '\0';
            this.txtCabang.SelectedText = "";
            this.txtCabang.Size = new System.Drawing.Size(319, 37);
            this.txtCabang.TabIndex = 19;
            // 
            // SettingKoneksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 335);
            this.Controls.Add(this.btnProses);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SettingKoneksi";
            this.Text = "SettingKoneksi";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private Guna.UI.WinForms.GunaTextBox txtEndpoint;
        private Guna.UI.WinForms.GunaGradientButton btnProses;
        private Guna.UI.WinForms.GunaGradientButton btnSimpan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaTextBox txtServer;
        private System.Windows.Forms.Label label4;
        private Guna.UI.WinForms.GunaTextBox noHp;
        private Guna.UI.WinForms.GunaTextBox txtDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private Guna.UI.WinForms.GunaTextBox txtUser;
        private Guna.UI.WinForms.GunaTextBox txtPassword;
        private System.Windows.Forms.Label label6;
        private Guna.UI.WinForms.GunaTextBox txtPort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private Guna.UI.WinForms.GunaTextBox txtCabang;
    }
}
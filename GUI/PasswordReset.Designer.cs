﻿
namespace KasirApp.GUI
{
    partial class PasswordReset
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNoHP = new Guna.UI.WinForms.GunaTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaGradientButton2 = new Guna.UI.WinForms.GunaGradientButton();
            this.btnProses = new Guna.UI.WinForms.GunaGradientButton();
            this.txtEmail = new Guna.UI.WinForms.GunaTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.panel1.Controls.Add(this.txtNoHP);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.gunaGradientButton2);
            this.panel1.Controls.Add(this.btnProses);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 333);
            this.panel1.TabIndex = 10;
            // 
            // txtNoHP
            // 
            this.txtNoHP.BackColor = System.Drawing.SystemColors.Control;
            this.txtNoHP.BaseColor = System.Drawing.Color.White;
            this.txtNoHP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.txtNoHP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNoHP.FocusedBaseColor = System.Drawing.Color.White;
            this.txtNoHP.FocusedBorderColor = System.Drawing.Color.Lime;
            this.txtNoHP.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNoHP.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNoHP.Location = new System.Drawing.Point(15, 200);
            this.txtNoHP.Margin = new System.Windows.Forms.Padding(4);
            this.txtNoHP.Name = "txtNoHP";
            this.txtNoHP.PasswordChar = '\0';
            this.txtNoHP.SelectedText = "";
            this.txtNoHP.Size = new System.Drawing.Size(564, 46);
            this.txtNoHP.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(261, 171);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "No Hp : ";
            // 
            // gunaGradientButton2
            // 
            this.gunaGradientButton2.AnimationHoverSpeed = 0.07F;
            this.gunaGradientButton2.AnimationSpeed = 0.03F;
            this.gunaGradientButton2.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.gunaGradientButton2.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.gunaGradientButton2.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton2.BorderSize = 1;
            this.gunaGradientButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaGradientButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientButton2.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaGradientButton2.ForeColor = System.Drawing.Color.Black;
            this.gunaGradientButton2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gunaGradientButton2.Image = null;
            this.gunaGradientButton2.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaGradientButton2.Location = new System.Drawing.Point(303, 267);
            this.gunaGradientButton2.Margin = new System.Windows.Forms.Padding(4);
            this.gunaGradientButton2.Name = "gunaGradientButton2";
            this.gunaGradientButton2.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.gunaGradientButton2.OnHoverBaseColor2 = System.Drawing.Color.LightGreen;
            this.gunaGradientButton2.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton2.OnHoverForeColor = System.Drawing.Color.Black;
            this.gunaGradientButton2.OnHoverImage = null;
            this.gunaGradientButton2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientButton2.Size = new System.Drawing.Size(105, 37);
            this.gunaGradientButton2.TabIndex = 5;
            this.gunaGradientButton2.Text = "Batal";
            this.gunaGradientButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaGradientButton2.Click += new System.EventHandler(this.gunaGradientButton2_Click);
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
            this.btnProses.Location = new System.Drawing.Point(181, 267);
            this.btnProses.Margin = new System.Windows.Forms.Padding(4);
            this.btnProses.Name = "btnProses";
            this.btnProses.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btnProses.OnHoverBaseColor2 = System.Drawing.Color.LightGreen;
            this.btnProses.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnProses.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnProses.OnHoverImage = null;
            this.btnProses.OnPressedColor = System.Drawing.Color.Black;
            this.btnProses.Size = new System.Drawing.Size(105, 37);
            this.btnProses.TabIndex = 4;
            this.btnProses.Text = "Proses";
            this.btnProses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnProses.Click += new System.EventHandler(this.btnProses_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.Control;
            this.txtEmail.BaseColor = System.Drawing.Color.White;
            this.txtEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.FocusedBaseColor = System.Drawing.Color.White;
            this.txtEmail.FocusedBorderColor = System.Drawing.Color.Lime;
            this.txtEmail.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEmail.Location = new System.Drawing.Point(15, 108);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(564, 46);
            this.txtEmail.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(226, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Identitas(KTP) :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(138, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 31);
            this.label2.TabIndex = 10;
            this.label2.Text = "Reset Password Member";
            // 
            // PasswordReset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 353);
            this.Controls.Add(this.panel1);
            this.Name = "PasswordReset";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "PasswordReset";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaGradientButton gunaGradientButton2;
        private Guna.UI.WinForms.GunaGradientButton btnProses;
        private Guna.UI.WinForms.GunaTextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaTextBox txtNoHP;
        private System.Windows.Forms.Label label1;
    }
}
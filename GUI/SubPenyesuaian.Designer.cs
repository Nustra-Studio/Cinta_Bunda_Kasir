
namespace KasirApp.GUI
{
    partial class SubPenyesuaian
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
            this.btnProses = new Guna.UI.WinForms.GunaGradientButton();
            this.txtBarang = new Guna.UI.WinForms.GunaTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStok = new Guna.UI.WinForms.GunaTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBatal = new Guna.UI.WinForms.GunaGradientButton();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.btnProses.Location = new System.Drawing.Point(200, 139);
            this.btnProses.Margin = new System.Windows.Forms.Padding(4);
            this.btnProses.Name = "btnProses";
            this.btnProses.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btnProses.OnHoverBaseColor2 = System.Drawing.Color.Lime;
            this.btnProses.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnProses.OnHoverForeColor = System.Drawing.Color.White;
            this.btnProses.OnHoverImage = null;
            this.btnProses.OnPressedColor = System.Drawing.Color.Black;
            this.btnProses.Size = new System.Drawing.Size(105, 37);
            this.btnProses.TabIndex = 1;
            this.btnProses.Text = "Proses";
            this.btnProses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnProses.Click += new System.EventHandler(this.btnProses_Click);
            this.btnProses.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarang_KeyDown);
            // 
            // txtBarang
            // 
            this.txtBarang.BackColor = System.Drawing.SystemColors.Control;
            this.txtBarang.BaseColor = System.Drawing.Color.White;
            this.txtBarang.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.txtBarang.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBarang.FocusedBaseColor = System.Drawing.Color.White;
            this.txtBarang.FocusedBorderColor = System.Drawing.Color.Lime;
            this.txtBarang.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBarang.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBarang.Location = new System.Drawing.Point(200, 21);
            this.txtBarang.Margin = new System.Windows.Forms.Padding(4);
            this.txtBarang.Name = "txtBarang";
            this.txtBarang.PasswordChar = '\0';
            this.txtBarang.SelectedText = "";
            this.txtBarang.Size = new System.Drawing.Size(337, 37);
            this.txtBarang.TabIndex = 2;
            this.txtBarang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarang_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Barcode Barang : ";
            // 
            // txtStok
            // 
            this.txtStok.BackColor = System.Drawing.SystemColors.Control;
            this.txtStok.BaseColor = System.Drawing.Color.White;
            this.txtStok.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.txtStok.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStok.FocusedBaseColor = System.Drawing.Color.White;
            this.txtStok.FocusedBorderColor = System.Drawing.Color.Lime;
            this.txtStok.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtStok.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtStok.Location = new System.Drawing.Point(200, 66);
            this.txtStok.Margin = new System.Windows.Forms.Padding(4);
            this.txtStok.Name = "txtStok";
            this.txtStok.PasswordChar = '\0';
            this.txtStok.SelectedText = "";
            this.txtStok.Size = new System.Drawing.Size(164, 37);
            this.txtStok.TabIndex = 4;
            this.txtStok.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarang_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Stok : ";
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
            this.btnBatal.Location = new System.Drawing.Point(313, 138);
            this.btnBatal.Margin = new System.Windows.Forms.Padding(4);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btnBatal.OnHoverBaseColor2 = System.Drawing.Color.Lime;
            this.btnBatal.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnBatal.OnHoverForeColor = System.Drawing.Color.White;
            this.btnBatal.OnHoverImage = null;
            this.btnBatal.OnPressedColor = System.Drawing.Color.Black;
            this.btnBatal.Size = new System.Drawing.Size(105, 37);
            this.btnBatal.TabIndex = 6;
            this.btnBatal.Text = "Batal";
            this.btnBatal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            this.btnBatal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarang_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(196, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "F4 - Tampil List Barangs";
            // 
            // SubPenyesuaian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 189);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.txtStok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProses);
            this.Controls.Add(this.txtBarang);
            this.Controls.Add(this.label2);
            this.Name = "SubPenyesuaian";
            this.Text = "SubPenyesuaian";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientButton btnProses;
        private Guna.UI.WinForms.GunaTextBox txtBarang;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaTextBox txtStok;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaGradientButton btnBatal;
        private System.Windows.Forms.Label label3;
    }
}
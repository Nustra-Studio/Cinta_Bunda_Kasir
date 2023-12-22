
namespace KasirApp.GUI
{
    partial class subSatuan
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
            this.btnBatal = new Guna.UI.WinForms.GunaGradientButton();
            this.btnProses = new Guna.UI.WinForms.GunaGradientButton();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNama = new Guna.UI.WinForms.GunaTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.panel1.Controls.Add(this.btnBatal);
            this.panel1.Controls.Add(this.btnProses);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txtNama);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 154);
            this.panel1.TabIndex = 1;
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
            this.btnBatal.Location = new System.Drawing.Point(209, 108);
            this.btnBatal.Margin = new System.Windows.Forms.Padding(4);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btnBatal.OnHoverBaseColor2 = System.Drawing.Color.Lime;
            this.btnBatal.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnBatal.OnHoverForeColor = System.Drawing.Color.White;
            this.btnBatal.OnHoverImage = null;
            this.btnBatal.OnPressedColor = System.Drawing.Color.Black;
            this.btnBatal.Size = new System.Drawing.Size(105, 37);
            this.btnBatal.TabIndex = 3;
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
            this.btnProses.Location = new System.Drawing.Point(89, 108);
            this.btnProses.Margin = new System.Windows.Forms.Padding(4);
            this.btnProses.Name = "btnProses";
            this.btnProses.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btnProses.OnHoverBaseColor2 = System.Drawing.Color.Lime;
            this.btnProses.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnProses.OnHoverForeColor = System.Drawing.Color.White;
            this.btnProses.OnHoverImage = null;
            this.btnProses.OnPressedColor = System.Drawing.Color.Black;
            this.btnProses.Size = new System.Drawing.Size(105, 37);
            this.btnProses.TabIndex = 2;
            this.btnProses.Text = "Proses";
            this.btnProses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnProses.Click += new System.EventHandler(this.btnProses_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(135, 19);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(132, 25);
            this.label18.TabIndex = 9;
            this.label18.Text = "Nama Satuan";
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
            this.txtNama.Location = new System.Drawing.Point(31, 54);
            this.txtNama.Margin = new System.Windows.Forms.Padding(4);
            this.txtNama.Name = "txtNama";
            this.txtNama.PasswordChar = '\0';
            this.txtNama.SelectedText = "";
            this.txtNama.Size = new System.Drawing.Size(337, 46);
            this.txtNama.TabIndex = 8;
            // 
            // subSatuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 164);
            this.Controls.Add(this.panel1);
            this.Name = "subSatuan";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "subSatuan";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaGradientButton btnBatal;
        private Guna.UI.WinForms.GunaGradientButton btnProses;
        private System.Windows.Forms.Label label18;
        private Guna.UI.WinForms.GunaTextBox txtNama;
    }
}
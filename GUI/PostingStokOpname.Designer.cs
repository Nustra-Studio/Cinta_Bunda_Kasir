
namespace KasirApp.GUI
{
    partial class PostingStokOpname
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
            this.tgl = new Guna.UI.WinForms.GunaDateTimePicker();
            this.gunaGradientButton1 = new Guna.UI.WinForms.GunaGradientButton();
            this.btnBatal = new Guna.UI.WinForms.GunaGradientButton();
            this.SuspendLayout();
            // 
            // tgl
            // 
            this.tgl.BaseColor = System.Drawing.Color.White;
            this.tgl.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(243)))), ((int)(((byte)(189)))));
            this.tgl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tgl.CustomFormat = null;
            this.tgl.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.tgl.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(243)))), ((int)(((byte)(189)))));
            this.tgl.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tgl.ForeColor = System.Drawing.Color.Black;
            this.tgl.Location = new System.Drawing.Point(34, 22);
            this.tgl.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.tgl.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.tgl.Name = "tgl";
            this.tgl.OnHoverBaseColor = System.Drawing.Color.White;
            this.tgl.OnHoverBorderColor = System.Drawing.Color.Green;
            this.tgl.OnHoverForeColor = System.Drawing.Color.Green;
            this.tgl.OnPressedColor = System.Drawing.Color.Black;
            this.tgl.Size = new System.Drawing.Size(306, 50);
            this.tgl.TabIndex = 0;
            this.tgl.Text = "08 August 2023";
            this.tgl.Value = new System.DateTime(2023, 8, 8, 21, 37, 14, 572);
            // 
            // gunaGradientButton1
            // 
            this.gunaGradientButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaGradientButton1.AnimationHoverSpeed = 0.07F;
            this.gunaGradientButton1.AnimationSpeed = 0.03F;
            this.gunaGradientButton1.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.gunaGradientButton1.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.gunaGradientButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.BorderSize = 1;
            this.gunaGradientButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaGradientButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaGradientButton1.ForeColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gunaGradientButton1.Image = null;
            this.gunaGradientButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaGradientButton1.Location = new System.Drawing.Point(66, 95);
            this.gunaGradientButton1.Margin = new System.Windows.Forms.Padding(4);
            this.gunaGradientButton1.Name = "gunaGradientButton1";
            this.gunaGradientButton1.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.gunaGradientButton1.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.gunaGradientButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.OnHoverForeColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.OnHoverImage = null;
            this.gunaGradientButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.Size = new System.Drawing.Size(105, 37);
            this.gunaGradientButton1.TabIndex = 12;
            this.gunaGradientButton1.Text = "Posting";
            this.gunaGradientButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaGradientButton1.Click += new System.EventHandler(this.RaiseClickPost);
            // 
            // btnBatal
            // 
            this.btnBatal.AnimationHoverSpeed = 0.07F;
            this.btnBatal.AnimationSpeed = 0.03F;
            this.btnBatal.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnBatal.BaseColor2 = System.Drawing.Color.Red;
            this.btnBatal.BorderColor = System.Drawing.Color.LightGray;
            this.btnBatal.BorderSize = 1;
            this.btnBatal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatal.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBatal.FocusedColor = System.Drawing.Color.Empty;
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBatal.ForeColor = System.Drawing.Color.LightGray;
            this.btnBatal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBatal.Image = null;
            this.btnBatal.ImageSize = new System.Drawing.Size(20, 20);
            this.btnBatal.Location = new System.Drawing.Point(191, 95);
            this.btnBatal.Margin = new System.Windows.Forms.Padding(4);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.OnHoverBaseColor1 = System.Drawing.Color.IndianRed;
            this.btnBatal.OnHoverBaseColor2 = System.Drawing.Color.LightCoral;
            this.btnBatal.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnBatal.OnHoverForeColor = System.Drawing.Color.White;
            this.btnBatal.OnHoverImage = null;
            this.btnBatal.OnPressedColor = System.Drawing.Color.Black;
            this.btnBatal.Size = new System.Drawing.Size(129, 37);
            this.btnBatal.TabIndex = 13;
            this.btnBatal.Text = "Batal";
            this.btnBatal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // PostingStokOpname
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 145);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.gunaGradientButton1);
            this.Controls.Add(this.tgl);
            this.MinimumSize = new System.Drawing.Size(390, 192);
            this.Name = "PostingStokOpname";
            this.Text = "Posting - Stok Opname";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PostingStokOpname_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaDateTimePicker tgl;
        private Guna.UI.WinForms.GunaGradientButton gunaGradientButton1;
        private Guna.UI.WinForms.GunaGradientButton btnBatal;
    }
}
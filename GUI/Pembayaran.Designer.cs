
namespace KasirApp.GUI
{
    partial class Pembayaran
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
            this.txtKembali = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBayar = new Guna.UI.WinForms.GunaGradientButton();
            this.DicMember = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBayarCash = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.panel1.Controls.Add(this.txtKembali);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDiscount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnBayar);
            this.panel1.Controls.Add(this.DicMember);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtSubtotal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtBayarCash);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 272);
            this.panel1.TabIndex = 0;
            // 
            // txtKembali
            // 
            this.txtKembali.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKembali.Location = new System.Drawing.Point(188, 177);
            this.txtKembali.Margin = new System.Windows.Forms.Padding(4);
            this.txtKembali.Name = "txtKembali";
            this.txtKembali.ReadOnly = true;
            this.txtKembali.Size = new System.Drawing.Size(246, 30);
            this.txtKembali.TabIndex = 3;
            this.txtKembali.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBayarCash_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(86, 180);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Kembali :";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(188, 101);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(246, 30);
            this.txtDiscount.TabIndex = 1;
            this.txtDiscount.TextChanged += new System.EventHandler(this.UpdateDataTextChanged);
            this.txtDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBayarCash_KeyDown);
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Numeric);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Discount :";
            // 
            // btnBayar
            // 
            this.btnBayar.AnimationHoverSpeed = 0.07F;
            this.btnBayar.AnimationSpeed = 0.03F;
            this.btnBayar.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.btnBayar.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.btnBayar.BorderColor = System.Drawing.Color.Black;
            this.btnBayar.BorderSize = 1;
            this.btnBayar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBayar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBayar.FocusedColor = System.Drawing.Color.Empty;
            this.btnBayar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBayar.ForeColor = System.Drawing.Color.Black;
            this.btnBayar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBayar.Image = null;
            this.btnBayar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnBayar.Location = new System.Drawing.Point(136, 215);
            this.btnBayar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBayar.Name = "btnBayar";
            this.btnBayar.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btnBayar.OnHoverBaseColor2 = System.Drawing.Color.Lime;
            this.btnBayar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnBayar.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnBayar.OnHoverImage = null;
            this.btnBayar.OnPressedColor = System.Drawing.Color.Black;
            this.btnBayar.Size = new System.Drawing.Size(226, 37);
            this.btnBayar.TabIndex = 4;
            this.btnBayar.Text = "Bayar";
            this.btnBayar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnBayar.Click += new System.EventHandler(this.btnBayar_Click);
            // 
            // DicMember
            // 
            this.DicMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DicMember.Location = new System.Drawing.Point(188, 139);
            this.DicMember.Margin = new System.Windows.Forms.Padding(4);
            this.DicMember.Name = "DicMember";
            this.DicMember.ReadOnly = true;
            this.DicMember.Size = new System.Drawing.Size(246, 30);
            this.DicMember.TabIndex = 2;
            this.DicMember.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBayarCash_KeyDown);
            this.DicMember.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Numeric);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Diskon Member :";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubtotal.Location = new System.Drawing.Point(188, 25);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(246, 30);
            this.txtSubtotal.TabIndex = 5;
            this.txtSubtotal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBayarCash_KeyDown);
            this.txtSubtotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Numeric);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(77, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "SubTotal :";
            // 
            // txtBayarCash
            // 
            this.txtBayarCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBayarCash.Location = new System.Drawing.Point(188, 63);
            this.txtBayarCash.Margin = new System.Windows.Forms.Padding(4);
            this.txtBayarCash.Name = "txtBayarCash";
            this.txtBayarCash.Size = new System.Drawing.Size(246, 30);
            this.txtBayarCash.TabIndex = 0;
            this.txtBayarCash.TextChanged += new System.EventHandler(this.UpdateDataTextChanged);
            this.txtBayarCash.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBayarCash_KeyDown);
            this.txtBayarCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Numeric);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(54, 66);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Bayar Cash :";
            // 
            // Pembayaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(223)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(501, 276);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Pembayaran";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "Pembayaran";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBayarCash;
        private System.Windows.Forms.Label label7;
        private Guna.UI.WinForms.GunaGradientButton btnBayar;
        private System.Windows.Forms.TextBox DicMember;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKembali;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label4;
    }
}
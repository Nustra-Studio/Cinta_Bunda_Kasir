
namespace KasirApp.GUI.Master
{
    partial class frmDepartemen
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
            this.cekDiskon = new System.Windows.Forms.CheckBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtKode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cekDiskon
            // 
            this.cekDiskon.AutoSize = true;
            this.cekDiskon.Enabled = false;
            this.cekDiskon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cekDiskon.Location = new System.Drawing.Point(218, 112);
            this.cekDiskon.Margin = new System.Windows.Forms.Padding(4);
            this.cekDiskon.Name = "cekDiskon";
            this.cekDiskon.Size = new System.Drawing.Size(140, 29);
            this.cekDiskon.TabIndex = 10;
            this.cekDiskon.Text = "Auto Diskon";
            this.cekDiskon.UseVisualStyleBackColor = true;
            this.cekDiskon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.raiseTombol);
            // 
            // txtNama
            // 
            this.txtNama.Enabled = false;
            this.txtNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNama.Location = new System.Drawing.Point(218, 74);
            this.txtNama.Margin = new System.Windows.Forms.Padding(4);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(332, 30);
            this.txtNama.TabIndex = 9;
            this.txtNama.KeyDown += new System.Windows.Forms.KeyEventHandler(this.raiseTombol);
            // 
            // txtKode
            // 
            this.txtKode.Enabled = false;
            this.txtKode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKode.Location = new System.Drawing.Point(218, 23);
            this.txtKode.Margin = new System.Windows.Forms.Padding(4);
            this.txtKode.Name = "txtKode";
            this.txtKode.Size = new System.Drawing.Size(113, 30);
            this.txtKode.TabIndex = 8;
            this.txtKode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.raiseTombol);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(130, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nama : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Kode Departemen :";
            // 
            // frmDepartemen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 163);
            this.Controls.Add(this.cekDiskon);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtKode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "frmDepartemen";
            this.Text = "frmDepartemen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDepartemen_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.raiseTombol);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cekDiskon;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtKode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}
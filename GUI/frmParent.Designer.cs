
namespace KasirApp.GUI
{
    partial class frmParent
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
            this.ParentPanel = new Guna.UI.WinForms.GunaGradient2Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTop = new Guna.UI.WinForms.GunaGradientButton();
            this.btnPrevous = new Guna.UI.WinForms.GunaGradientButton();
            this.btnNext = new Guna.UI.WinForms.GunaGradientButton();
            this.btnBottom = new Guna.UI.WinForms.GunaGradientButton();
            this.btnAdd = new Guna.UI.WinForms.GunaGradientButton();
            this.btnDelete = new Guna.UI.WinForms.GunaGradientButton();
            this.btnFind = new Guna.UI.WinForms.GunaGradientButton();
            this.btnList = new Guna.UI.WinForms.GunaGradientButton();
            this.btnPrint = new Guna.UI.WinForms.GunaGradientButton();
            this.btnExit = new Guna.UI.WinForms.GunaGradientButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ParentPanel
            // 
            this.ParentPanel.BackColor = System.Drawing.Color.Transparent;
            this.ParentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParentPanel.GradientColor1 = System.Drawing.SystemColors.Control;
            this.ParentPanel.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(243)))), ((int)(((byte)(189)))));
            this.ParentPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.ParentPanel.Location = new System.Drawing.Point(0, 68);
            this.ParentPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ParentPanel.Name = "ParentPanel";
            this.ParentPanel.Size = new System.Drawing.Size(1409, 486);
            this.ParentPanel.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.flowLayoutPanel1.Controls.Add(this.btnTop);
            this.flowLayoutPanel1.Controls.Add(this.btnPrevous);
            this.flowLayoutPanel1.Controls.Add(this.btnNext);
            this.flowLayoutPanel1.Controls.Add(this.btnBottom);
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.btnFind);
            this.flowLayoutPanel1.Controls.Add(this.btnList);
            this.flowLayoutPanel1.Controls.Add(this.btnPrint);
            this.flowLayoutPanel1.Controls.Add(this.btnExit);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1409, 68);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnTop
            // 
            this.btnTop.AnimationHoverSpeed = 0.07F;
            this.btnTop.AnimationSpeed = 0.03F;
            this.btnTop.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.btnTop.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.btnTop.BorderColor = System.Drawing.Color.Black;
            this.btnTop.BorderSize = 1;
            this.btnTop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTop.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnTop.FocusedColor = System.Drawing.Color.Empty;
            this.btnTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTop.ForeColor = System.Drawing.Color.Black;
            this.btnTop.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnTop.Image = global::KasirApp.Properties.Resources.up;
            this.btnTop.ImageOffsetX = -2;
            this.btnTop.ImageSize = new System.Drawing.Size(35, 35);
            this.btnTop.Location = new System.Drawing.Point(4, 8);
            this.btnTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTop.Name = "btnTop";
            this.btnTop.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btnTop.OnHoverBaseColor2 = System.Drawing.Color.Lime;
            this.btnTop.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnTop.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnTop.OnHoverImage = null;
            this.btnTop.OnPressedColor = System.Drawing.Color.Black;
            this.btnTop.Size = new System.Drawing.Size(119, 54);
            this.btnTop.TabIndex = 10;
            this.btnTop.Text = "Top";
            this.btnTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnTop.TextOffsetX = 5;
            this.btnTop.Click += new System.EventHandler(this.btnTop_Click);
            // 
            // btnPrevous
            // 
            this.btnPrevous.AnimationHoverSpeed = 0.07F;
            this.btnPrevous.AnimationSpeed = 0.03F;
            this.btnPrevous.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.btnPrevous.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.btnPrevous.BorderColor = System.Drawing.Color.Black;
            this.btnPrevous.BorderSize = 1;
            this.btnPrevous.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevous.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrevous.FocusedColor = System.Drawing.Color.Empty;
            this.btnPrevous.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevous.ForeColor = System.Drawing.Color.Black;
            this.btnPrevous.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnPrevous.Image = global::KasirApp.Properties.Resources.left;
            this.btnPrevous.ImageOffsetX = -2;
            this.btnPrevous.ImageSize = new System.Drawing.Size(35, 35);
            this.btnPrevous.Location = new System.Drawing.Point(131, 8);
            this.btnPrevous.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrevous.Name = "btnPrevous";
            this.btnPrevous.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btnPrevous.OnHoverBaseColor2 = System.Drawing.Color.Lime;
            this.btnPrevous.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnPrevous.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnPrevous.OnHoverImage = null;
            this.btnPrevous.OnPressedColor = System.Drawing.Color.Black;
            this.btnPrevous.Size = new System.Drawing.Size(119, 54);
            this.btnPrevous.TabIndex = 10;
            this.btnPrevous.Text = "Prev";
            this.btnPrevous.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnPrevous.TextOffsetX = 5;
            // 
            // btnNext
            // 
            this.btnNext.AnimationHoverSpeed = 0.07F;
            this.btnNext.AnimationSpeed = 0.03F;
            this.btnNext.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.btnNext.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.btnNext.BorderColor = System.Drawing.Color.Black;
            this.btnNext.BorderSize = 1;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNext.FocusedColor = System.Drawing.Color.Empty;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.Black;
            this.btnNext.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnNext.Image = global::KasirApp.Properties.Resources.right;
            this.btnNext.ImageOffsetX = -2;
            this.btnNext.ImageSize = new System.Drawing.Size(35, 35);
            this.btnNext.Location = new System.Drawing.Point(258, 8);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btnNext.OnHoverBaseColor2 = System.Drawing.Color.Lime;
            this.btnNext.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnNext.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnNext.OnHoverImage = null;
            this.btnNext.OnPressedColor = System.Drawing.Color.Black;
            this.btnNext.Size = new System.Drawing.Size(119, 54);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnNext.TextOffsetX = 5;
            // 
            // btnBottom
            // 
            this.btnBottom.AnimationHoverSpeed = 0.07F;
            this.btnBottom.AnimationSpeed = 0.03F;
            this.btnBottom.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.btnBottom.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.btnBottom.BorderColor = System.Drawing.Color.Black;
            this.btnBottom.BorderSize = 1;
            this.btnBottom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBottom.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBottom.FocusedColor = System.Drawing.Color.Empty;
            this.btnBottom.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnBottom.ForeColor = System.Drawing.Color.Black;
            this.btnBottom.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBottom.Image = global::KasirApp.Properties.Resources.down;
            this.btnBottom.ImageOffsetX = -2;
            this.btnBottom.ImageSize = new System.Drawing.Size(35, 35);
            this.btnBottom.Location = new System.Drawing.Point(385, 8);
            this.btnBottom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBottom.Name = "btnBottom";
            this.btnBottom.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btnBottom.OnHoverBaseColor2 = System.Drawing.Color.Lime;
            this.btnBottom.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnBottom.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnBottom.OnHoverImage = null;
            this.btnBottom.OnPressedColor = System.Drawing.Color.Black;
            this.btnBottom.Size = new System.Drawing.Size(119, 54);
            this.btnBottom.TabIndex = 10;
            this.btnBottom.Text = "Bottom";
            this.btnBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnBottom.TextOffsetX = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.AnimationHoverSpeed = 0.07F;
            this.btnAdd.AnimationSpeed = 0.03F;
            this.btnAdd.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.btnAdd.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.btnAdd.BorderColor = System.Drawing.Color.Black;
            this.btnAdd.BorderSize = 1;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAdd.FocusedColor = System.Drawing.Color.Empty;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAdd.Image = global::KasirApp.Properties.Resources.Plus;
            this.btnAdd.ImageOffsetX = -2;
            this.btnAdd.ImageSize = new System.Drawing.Size(35, 35);
            this.btnAdd.Location = new System.Drawing.Point(512, 8);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btnAdd.OnHoverBaseColor2 = System.Drawing.Color.Lime;
            this.btnAdd.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAdd.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnAdd.OnHoverImage = null;
            this.btnAdd.OnPressedColor = System.Drawing.Color.Black;
            this.btnAdd.Size = new System.Drawing.Size(119, 54);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnAdd.TextOffsetX = 5;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AnimationHoverSpeed = 0.07F;
            this.btnDelete.AnimationSpeed = 0.03F;
            this.btnDelete.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.btnDelete.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.btnDelete.BorderColor = System.Drawing.Color.Black;
            this.btnDelete.BorderSize = 1;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDelete.FocusedColor = System.Drawing.Color.Empty;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnDelete.Image = global::KasirApp.Properties.Resources.bin;
            this.btnDelete.ImageOffsetX = -2;
            this.btnDelete.ImageSize = new System.Drawing.Size(35, 35);
            this.btnDelete.Location = new System.Drawing.Point(639, 8);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btnDelete.OnHoverBaseColor2 = System.Drawing.Color.Lime;
            this.btnDelete.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnDelete.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnDelete.OnHoverImage = null;
            this.btnDelete.OnPressedColor = System.Drawing.Color.Black;
            this.btnDelete.Size = new System.Drawing.Size(119, 54);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnDelete.TextOffsetX = 5;
            // 
            // btnFind
            // 
            this.btnFind.AnimationHoverSpeed = 0.07F;
            this.btnFind.AnimationSpeed = 0.03F;
            this.btnFind.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.btnFind.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.btnFind.BorderColor = System.Drawing.Color.Black;
            this.btnFind.BorderSize = 1;
            this.btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFind.FocusedColor = System.Drawing.Color.Empty;
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.ForeColor = System.Drawing.Color.Black;
            this.btnFind.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnFind.Image = global::KasirApp.Properties.Resources.Search;
            this.btnFind.ImageOffsetX = -2;
            this.btnFind.ImageSize = new System.Drawing.Size(35, 35);
            this.btnFind.Location = new System.Drawing.Point(766, 8);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFind.Name = "btnFind";
            this.btnFind.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btnFind.OnHoverBaseColor2 = System.Drawing.Color.Lime;
            this.btnFind.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnFind.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnFind.OnHoverImage = null;
            this.btnFind.OnPressedColor = System.Drawing.Color.Black;
            this.btnFind.Size = new System.Drawing.Size(119, 54);
            this.btnFind.TabIndex = 11;
            this.btnFind.Text = "Find";
            this.btnFind.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnFind.TextOffsetX = 5;
            // 
            // btnList
            // 
            this.btnList.AnimationHoverSpeed = 0.07F;
            this.btnList.AnimationSpeed = 0.03F;
            this.btnList.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.btnList.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.btnList.BorderColor = System.Drawing.Color.Black;
            this.btnList.BorderSize = 1;
            this.btnList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnList.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnList.FocusedColor = System.Drawing.Color.Empty;
            this.btnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.ForeColor = System.Drawing.Color.Black;
            this.btnList.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnList.Image = global::KasirApp.Properties.Resources.List;
            this.btnList.ImageOffsetX = -2;
            this.btnList.ImageSize = new System.Drawing.Size(35, 35);
            this.btnList.Location = new System.Drawing.Point(893, 8);
            this.btnList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnList.Name = "btnList";
            this.btnList.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btnList.OnHoverBaseColor2 = System.Drawing.Color.Lime;
            this.btnList.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnList.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnList.OnHoverImage = null;
            this.btnList.OnPressedColor = System.Drawing.Color.Black;
            this.btnList.Size = new System.Drawing.Size(119, 54);
            this.btnList.TabIndex = 11;
            this.btnList.Text = "List";
            this.btnList.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnList.TextOffsetX = 5;
            // 
            // btnPrint
            // 
            this.btnPrint.AnimationHoverSpeed = 0.07F;
            this.btnPrint.AnimationSpeed = 0.03F;
            this.btnPrint.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.btnPrint.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.btnPrint.BorderColor = System.Drawing.Color.Black;
            this.btnPrint.BorderSize = 1;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.FocusedColor = System.Drawing.Color.Empty;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnPrint.Image = global::KasirApp.Properties.Resources.Print;
            this.btnPrint.ImageOffsetX = -2;
            this.btnPrint.ImageSize = new System.Drawing.Size(35, 35);
            this.btnPrint.Location = new System.Drawing.Point(1020, 8);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btnPrint.OnHoverBaseColor2 = System.Drawing.Color.Lime;
            this.btnPrint.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnPrint.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnPrint.OnHoverImage = null;
            this.btnPrint.OnPressedColor = System.Drawing.Color.Black;
            this.btnPrint.Size = new System.Drawing.Size(119, 54);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnPrint.TextOffsetX = 5;
            // 
            // btnExit
            // 
            this.btnExit.AnimationHoverSpeed = 0.07F;
            this.btnExit.AnimationSpeed = 0.03F;
            this.btnExit.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(212)))));
            this.btnExit.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(197)))));
            this.btnExit.BorderColor = System.Drawing.Color.Black;
            this.btnExit.BorderSize = 1;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.FocusedColor = System.Drawing.Color.Empty;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnExit.Image = global::KasirApp.Properties.Resources.Exit;
            this.btnExit.ImageOffsetX = -2;
            this.btnExit.ImageSize = new System.Drawing.Size(35, 35);
            this.btnExit.Location = new System.Drawing.Point(1147, 8);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.OnHoverBaseColor1 = System.Drawing.Color.White;
            this.btnExit.OnHoverBaseColor2 = System.Drawing.Color.Lime;
            this.btnExit.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnExit.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnExit.OnHoverImage = null;
            this.btnExit.OnPressedColor = System.Drawing.Color.Black;
            this.btnExit.Size = new System.Drawing.Size(119, 54);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnExit.TextOffsetX = 5;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 554);
            this.Controls.Add(this.ParentPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmParent";
            this.Text = "frmParent";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradient2Panel ParentPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI.WinForms.GunaGradientButton btnTop;
        private Guna.UI.WinForms.GunaGradientButton btnPrevous;
        private Guna.UI.WinForms.GunaGradientButton btnNext;
        private Guna.UI.WinForms.GunaGradientButton btnBottom;
        private Guna.UI.WinForms.GunaGradientButton btnAdd;
        private Guna.UI.WinForms.GunaGradientButton btnDelete;
        private Guna.UI.WinForms.GunaGradientButton btnFind;
        private Guna.UI.WinForms.GunaGradientButton btnList;
        private Guna.UI.WinForms.GunaGradientButton btnPrint;
        private Guna.UI.WinForms.GunaGradientButton btnExit;
    }
}
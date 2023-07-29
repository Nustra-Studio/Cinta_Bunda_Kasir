using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KasirApp.GUI
{
    public partial class frmParent : Form
    {
        public frmParent(Form frm)
        {
            InitializeComponent();
            ShowChild(frm);
        }

        public void ShowChild(Form frm)
        {
            frm.TopLevel = false;
            ParentPanel.Controls.Add(frm);
            frm.Show();
            frm.BringToFront();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}

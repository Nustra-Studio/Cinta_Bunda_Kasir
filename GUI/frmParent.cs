using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KasirApp.View;

namespace KasirApp.GUI
{
    public partial class frmParent : Form
    {
        iParentDock _dock;
        public frmParent(Form frm, iParentDock dck)
        {
            InitializeComponent();
            ShowChild(frm);
            _dock = dck;
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

        private void btnTop_Click(object sender, EventArgs e)
        {
            _dock.top();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _dock.add();
        }
    }
}

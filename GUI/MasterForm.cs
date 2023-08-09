using KasirApp.GUI.Supervisor;
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
using KasirApp.Model;
using KasirApp.GUI.Master;
using KasirApp.Presenter;

namespace KasirApp.GUI
{
    public partial class MasterForm : Form, iMasterForm
    {
        //Fields
        userDataModel _user;

        public void Role(usrRole rl, userDataModel user)
        {
            masterToolStripMenuItem.Visible = rl.Masters.Equals(1) ? true : false;
            gudangToolStripMenuItem.Visible = rl.Gudang.Equals(1) ? true : false;
            penjualanToolStripMenuItem.Visible = rl.Penjualan.Equals(1) ? true : false;
            kasBankToolStripMenuItem.Visible = rl.Kasbank.Equals(1) ? true : false;
            akuntaToolStripMenuItem.Visible = rl.Akuntansi.Equals(1) ? true : false;
            supervisorToolStripMenuItem.Visible = rl.Supervisor.Equals(1) ? true : false;
            _user = user;
        }

        public void refreshMainPanel()
        {
            MainPanel.Controls.Clear();
        }

        public void addForm(Form form)
        {
            if (MainPanel.Controls.Count <= 2)
            {
                MainPanel.Controls.Clear();
                form.TopLevel = false;
                MainPanel.Controls.Add(form);
                form.BringToFront();
                form.Show();
            }
            else 
            {
                return;
            }
        }

        public void FormParent(Form frm, iParentDock dock)
        {
            if (MainPanel.Controls.Count <= 2)
            {
                frmParent prn = new frmParent(frm, dock);
                prn.TopLevel = false;
                MainPanel.Controls.Add(prn);
                prn.FormBorderStyle = FormBorderStyle.None;
                prn.Dock = DockStyle.Fill;
                prn.BringToFront();
                prn.Show();
            }
            else
            {
                return;
            }
        }

        //Constructor
        public MasterForm()
        {
            InitializeComponent();
            logoutState();
            this.WindowState = FormWindowState.Maximized;
        }

        public void logoutState()
        {
            masterToolStripMenuItem.Visible = false;
            gudangToolStripMenuItem.Visible = false;
            penjualanToolStripMenuItem.Visible = false;
            kasBankToolStripMenuItem.Visible = false;
            akuntaToolStripMenuItem.Visible = false;
            supervisorToolStripMenuItem.Visible = false;
        }
      

        public void pOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaksi frm = new Transaksi(_user);
            addForm(frm);
        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {
            
        }

        private void barangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MasterBarang frm = new MasterBarang();
            addForm(frm);
        }

        private void laporanKartuStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan_Kartu_Stock_Barang frm = new Laporan_Kartu_Stock_Barang();
            addForm(frm);
        }

        private void pOSSMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BatalPosting frm = new BatalPosting();
            addForm(frm);
        }

        private void resetStokKeNolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetStokKeNol frm = new ResetStokKeNol();
            addForm(frm);
        }

        private void penyesuaianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PenyesuaianStok frm = new PenyesuaianStok();
            addForm(frm);
        }

        private void settingHargaJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting frm = new Setting();
            addForm(frm);
        }

        private void opnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {

        }

        private void laporanPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new LaporanPOS();
            addForm(frm);
        }

        private void laporanKartuStokBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Laporan_Kartu_Stock_Barang();
            addForm(frm);
        }

        private void transferGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new TransferGudang();
            addForm(frm);
        }

        private void penyesuaianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new PenyesuaianStok();
            addForm(frm);
        }

        private void tambahUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var frm = new MasterUser();
            //FormParent(frm);
        }

        private void returPenjualanPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new ReturPenjualanPos();
            addForm(frm);
        }

        private void settingDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Setting();
            addForm(frm);
        }

        private void MasterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login frm = new Login(this);
            addForm(frm);
        } 

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logoutState();
        }

        private void divisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartemen frm = new frmDepartemen();
            FormParent(frm,frm);
        }

        private void pOSSMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transaksi frm = new Transaksi(_user);
            addForm(frm);
        }

        private void stockOpnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockOpname frm = new StockOpname();
            addForm(frm);
        }

        private void postingStockOpnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PostingStokOpname frm = new PostingStokOpname();
            addForm(frm);
        }
    }
}

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
        public void Role(usrRole rl)
        {
            masterToolStripMenuItem.Visible = rl.Masters.Equals(1) ? true : false;
            gudangToolStripMenuItem.Visible = rl.Gudang.Equals(1) ? true : false;
            penjualanToolStripMenuItem.Visible = rl.Penjualan.Equals(1) ? true : false;
            kasBankToolStripMenuItem.Visible = rl.Kasbank.Equals(1) ? true : false;
            akuntaToolStripMenuItem.Visible = rl.Akuntansi.Equals(1) ? true : false;
            supervisorToolStripMenuItem.Visible = rl.Supervisor.Equals(1) ? true : false;
        }
        public void addForm(Form form)
        {
            form.TopLevel = false;
            MainPanel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }
        public void FormParent(Form frm, iParentDock dock)
        {
            frmParent prn = new frmParent(frm, dock);
            prn.TopLevel = false;
            MainPanel.Controls.Add(prn);
            prn.FormBorderStyle = FormBorderStyle.None;
            prn.Dock = DockStyle.Fill;
            prn.Show();
            prn.BringToFront();
        }

        public MasterForm()
        {
            InitializeComponent();
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
      

        private void pOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaksi frm = new Transaksi();
            addForm(frm);
            //Transaksi frm = new Transaksi();
            //frm.TopLevel = false;
            //frm.Show();
            //MainPanel.Controls.Add(frm);
            //frm.BringToFront();
            //frm.Show();
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
            StockOpname frm = new StockOpname();
            addForm(frm);
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
            logoutState();
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

        
    }
}

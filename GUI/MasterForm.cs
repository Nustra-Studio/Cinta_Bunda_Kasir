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
using KasirApp.Presenter;

namespace KasirApp.GUI
{
    public partial class MasterForm : Form, iMasterForm
    {
        iRole _role;
        public void Role(usrRole rl)
        {
            masterToolStripMenuItem.Visible = rl.Masters.Equals(1) ? true : false;
            gudangToolStripMenuItem.Visible = rl.Gudang.Equals(1) ? true : false;
            penjualanToolStripMenuItem.Visible = rl.Penjualan.Equals(1) ? true : false;
            kasBankToolStripMenuItem.Visible = rl.Kasbank.Equals(1) ? true : false;
            akuntaToolStripMenuItem.Visible = rl.Akuntansi.Equals(1) ? true : false;
            supervisorToolStripMenuItem.Visible = rl.Supervisor.Equals(1) ? true : false;
        }
        public MasterForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        public void RoleSellect()
        {
            
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

        public void addform(Form form)
        {
            form.TopLevel = false;
            MainPanel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void pOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaksi frm = new Transaksi();
            addform(frm);
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
            frm.TopLevel = false;
            frm.Show();
            MainPanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void laporanKartuStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan_Kartu_Stock_Barang frm = new Laporan_Kartu_Stock_Barang();
            frm.TopLevel = false;
            frm.Show();
            MainPanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void pOSSMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BatalPosting frm = new BatalPosting();
            frm.TopLevel = false;
            frm.Show();
            MainPanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void resetStokKeNolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetStokKeNol frm = new ResetStokKeNol();
            frm.TopLevel = false;
            frm.Show();
            MainPanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void penyesuaianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PenyesuaianStok frm = new PenyesuaianStok();
            frm.TopLevel = false;
            frm.Show();
            MainPanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void settingHargaJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting frm = new Setting();
            frm.TopLevel = false;
            frm.Show();
            MainPanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void opnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockOpname frm = new StockOpname();
            frm.TopLevel = false;
            frm.Show();
            MainPanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
            logoutState();
        }

        private void laporanPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new LaporanPOS();
            frm.TopLevel = false;
            frm.Show();
            MainPanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void laporanKartuStokBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Laporan_Kartu_Stock_Barang();
            frm.TopLevel = false;
            frm.Show();
            MainPanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void transferGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new TransferGudang();
            frm.TopLevel = false;
            frm.Show();
            MainPanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void penyesuaianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new PenyesuaianStok();
            frm.TopLevel = false;
            frm.Show();
            MainPanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void tambahUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new MasterUser();
            frm.TopLevel = false;
            frm.Show();
            MainPanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void returPenjualanPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new ReturPenjualanPos();
            frm.TopLevel = false;
            frm.Show();
            MainPanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void settingDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Setting();
            frm.TopLevel = false;
            frm.Show();
            MainPanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void MasterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lg = new Login(this);
            lg.TopLevel = false;
            MainPanel.Controls.Add(lg);
            lg.BringToFront();
            lg.Show();
        } 

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

       
    }
}

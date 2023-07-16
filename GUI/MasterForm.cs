﻿using KasirApp.GUI.Supervisor;
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
    public partial class MasterForm : Form, iMasterForm
    {
        iRole _role;
        public MasterForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        public void Role()
        {
            throw new NotImplementedException();
        }

        public void RoleSellect(string Role)
        {
            if (Role == "admin")
            {
                kasBankToolStripMenuItem.Visible = true;
                akuntaToolStripMenuItem.Visible = true;
                supervisorToolStripMenuItem.Visible = true;
                loginToolStripMenuItem.Enabled = false;
                utilityToolStripMenuItem.Visible = true;
                logOutToolStripMenuItem.Enabled = true;
                kasBankToolStripMenuItem.Visible = true;
            }
            else
            {
                kasBankToolStripMenuItem.Visible = false;
                akuntaToolStripMenuItem.Visible = false;
                supervisorToolStripMenuItem.Visible = false;
                utilityToolStripMenuItem.Visible = true;
                loginToolStripMenuItem.Enabled = false;
                logOutToolStripMenuItem.Enabled = true;
            }
        }

        public void addform(Form form)
        {
            Form frm = new Form();
            frm.TopLevel = false;
            frm.Show();
            MainPanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void pOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaksi frm = new Transaksi();
            frm.TopLevel = false;
            frm.Show();
            MainPanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
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
            kasBankToolStripMenuItem.Visible = false;
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
            Login lg = new Login();
            lg.TopLevel = false;
            MainPanel.Controls.Add(lg);
            lg.BringToFront();
            lg.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.ShowDialog();
        }

        
    }
}

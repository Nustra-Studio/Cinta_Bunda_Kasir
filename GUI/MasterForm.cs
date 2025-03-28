﻿using KasirApp.GUI.Supervisor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KasirApp.View;
using KasirApp.Model;
using KasirApp.GUI.Master;
using KasirApp.Presenter;
using KasirApp.Repository;
using Quartz.Impl;
using Quartz;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using RestSharp;
using Newtonsoft.Json;

namespace KasirApp.GUI
{
    public partial class MasterForm : Form, iMasterForm
    {
        //Fields
        userDataModel _user;
        PrintRepo _print = new PrintRepo();

        public void Role(usrRole rl, userDataModel user)
        {
            masterToolStripMenuItem.Visible = rl.Masters.Equals(1) ? true : false;
            gudangToolStripMenuItem.Visible = rl.Gudang.Equals(1) ? true : false;
            penjualanToolStripMenuItem.Visible = rl.Penjualan.Equals(1) ? true : false;
            supervisorToolStripMenuItem.Visible = rl.Supervisor.Equals(1) ? true : false;
            _user = user;
        }

        public void refreshMainPanel()
        {
            MainPanel.Controls.Clear();
            background.Controls.Clear();
        }

        public void addForm(Form form)
        {
            if (MainPanel.Controls.Count <= 2)
            {
                //MainPanel.Controls.Clear();
                //MainPanel.Controls.Add(form);
                form.TopLevel = false;
                background.Controls.Clear();
                background.Controls.Add(form);
                form.Show();
                form.BringToFront();
            }
            else 
            {
                return;
            }
        }

        public void subForm(Form form)
        {
            //MainPanel.Controls.Add(form);
            form.TopLevel = false;
            background.Controls.Add(form);
            form.Show();
            form.BringToFront();
        }

        public void CloseForm()
        {
            background.Controls.Clear();
            DetailStok frm = new DetailStok();
            frm.TopLevel = false;
            background.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
            frm.BringToFront();
        }

        public void FormParent(Form frm, iParentDock dock)
        {
            if (MainPanel.Controls.Count <= 2)
            {
                frmParent prn = new frmParent(frm, dock,this);
                prn.TopLevel = false;
                //MainPanel.Controls.Add(prn);
                background.Controls.Add(prn);
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
            timer1.Start();
        }

        public void logoutState()
        {
            masterToolStripMenuItem.Visible = false;
            gudangToolStripMenuItem.Visible = false;
            penjualanToolStripMenuItem.Visible = false;
            supervisorToolStripMenuItem.Visible = false;
            background.Controls.Clear();
        }
      

        public void pOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaksi frm = new Transaksi(_user, this);
            addForm(frm);
        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {
            
        }

        private void barangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MasterBarang frm = new MasterBarang(this, _user);
            addForm(frm);
        }

        private void laporanKartuStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Laporan_Kartu_Stock_Barang frm = new Laporan_Kartu_Stock_Barang(this, _user);
            addForm(frm);
        }

        private void pOSSMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            batalPOS frm = new batalPOS(this, _user);
            addForm(frm);
        }

        private void resetStokKeNolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetStokKeNol frm = new ResetStokKeNol(this, _user);
            addForm(frm);
        }

        private void penyesuaianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            batalPenyesuaian frm = new batalPenyesuaian(this, _user);
            addForm(frm);
        }

        private void settingHargaJualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting frm = new Setting(this);
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
            var frm = new LaporanPOS(this);
            addForm(frm);
        }

        private void laporanKartuStokBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Laporan_Kartu_Stock_Barang(this, _user);
            addForm(frm);
        }

        private void transferGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var frm = new TransferGudang();
            //addForm(frm);
        }

        private void penyesuaianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new PenyesuaianStok(this, _user);
            addForm(frm);
        }

        private void tambahUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new MasterUser(_user);
            FormParent(frm, frm);
        }

        private void returPenjualanPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new ReturPenjualanPos();
            addForm(frm);
        }

        private void settingDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Setting(this);
            addForm(frm);
        }

        private void MasterForm_FormClosed(object sender, FormClosedEventArgs e)
        {

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
            var frm = new frmDepartemen();
            FormParent(frm,frm);
        }

        private void pOSSMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transaksi frm = new Transaksi(_user, this);
            addForm(frm);
        }

        private void stockOpnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockOpname frm = new StockOpname(this,_user);
            addForm(frm);
        }

        private void postingStockOpnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PostingStokOpname frm = new PostingStokOpname(this,_user);
            addForm(frm);
        }

        private void transferAntarGudangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TransferGudang frm = new TransferGudang(_user);
            FormParent(frm,frm);
        }

        private void penyesuaianToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PenyesuaianStok frm = new PenyesuaianStok(this, _user);
            FormParent(frm,frm);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            this.Dispose();
        }

        private void returPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pop = new Retur( _user);
            FormParent(pop, pop);
        }

        private void kartuStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Laporan_Kartu_Stock_Barang(this, _user);
            addForm(frm);
        }

        private void setGroupUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new SetGroup(this);
            FormParent(frm, frm);
        }

        private void penjualanPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new LaporanPOS(this);
            addForm(frm);
        }

        private void settingAccGlobalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void transferAntarGudangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new batalTransferGudang(this, _user);
            addForm(frm);
        }

        private void opnameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var frm = new batalOpname(this, _user);
            addForm(frm);
        }

        private void laporanBatalPostingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _print.LaporanBatal();
        }

        private void returPOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frn = new batalRetur(this, _user);
            addForm(frn);
        }

        private void laporanAktifitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new LaporanAktifitas(this);
            addForm(frm);
        }

        private BackgroundWorker bw;
        private void timer1_Tick(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("HH:mm").Trim();
            if (date == "23:04")
            {
                initializeBW();
            }
        }

        public void initializeBW()
        {
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += initializeBackup;
            bw.RunWorkerCompleted += doneBackup;

            bw.RunWorkerAsync();
        }

        Operator op = new Operator();
        public void initializeBackup(object sender, DoWorkEventArgs e)
        {
            string file = $@"{op.CabangConfig().Backup}\backupDBkasir_{DateTime.Now.ToString("HH;mm;ss")}-{DateTime.Now.ToString("dd-MM-yyyy")}.sql";
            //Backup File Ke Lokal
            using (op.Conn)
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = op.Conn;
                        op.KonekDB();
                        mb.ExportToFile(file);
                        op.KonekDB();

                        //Upload Backup Ke server
                        using (var client = new RestClient(op.url + "backup/"))
                        {
                            try
                            {
                                //Console.WriteLine(JsonConvert.SerializeObject(body, Formatting.Indented));
                                var request = new RestRequest("cabang", Method.Post);

                                request.AddQueryParameter("token", _user.token);
                                request.AddQueryParameter("uuid", _user.uuid);

                                request.AddFile("file", file, "multipart/form-data");

                                var response = client.Execute(request);
                                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                                {
                                    Console.WriteLine(response.Content.ToString());
                                }
                                else
                                {
                                    Console.WriteLine(response.Content.ToString());
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.Write(ex.Message.ToString());
                            }
                        }
                    }
                }
            }

           
        }

        public void doneBackup(object sender, RunWorkerCompletedEventArgs e)
        {
            NotifyIcon notify1 = new NotifyIcon();
            notify1.BalloonTipText = "Selesai Backup Database";
            notify1.BalloonTipTitle = "Backup Done";
            notify1.Icon = SystemIcons.Information;
            notify1.Visible = true;
            notify1.ShowBalloonTip(500);

            bw.CancelAsync();
        }
    }
}

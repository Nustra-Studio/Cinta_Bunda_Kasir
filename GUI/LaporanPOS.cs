using KasirApp.Model;
using KasirApp.Report;
using KasirApp.View;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
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
    public partial class LaporanPOS : Form
    {
        string tanggal1;
        string tanggal2;
        MboxOperator mb = new MboxOperator();
        Operator op = new Operator();
        iMasterForm _master;
        //Constructor
        public LaporanPOS(iMasterForm mas)
        {
            InitializeComponent();
            tgl1.Value = DateTime.Now;
            tgl2.Value = DateTime.Now;
            tanggal1 = tgl1.Value.ToString("yyyy-MM-dd 00:00:00");
            tanggal2 = tgl2.Value.ToString("yyyy-MM-dd 23:59:00");
            _master = mas;
            fillCombo();
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            tanggal1 = tgl1.Value.ToString("yyyy/MM/dd 00:00:00");
            tanggal2 = tgl2.Value.ToString("yyyy/MM/dd 23:00:00");

            string kat = cboKategori.Text;
            string user = cboUser.Text;

            string vrpquery = $"AND kategori = '{kat}' AND User = '{user}'";
            string rpquery = $"AND user = '{user}'";

            if (kat == "" && user != "")
            {
                vrpquery = $"AND User = '{user}'";
            }
            else if (kat != "" && user == "")
            {
                vrpquery = $"AND kategori = '{kat}'";
                rpquery = "";
            }
            else if (kat == "" && user == "")
            {
                rpquery = "";
                vrpquery = "";
            }

            if (listBox1.SelectedIndex.ToString() == "0")
            {
                showReport("DetailPOS", "ReportDetail.rdlc", $"SELECT * FROM view_report_penjualan where tanggalTrans BETWEEN '{tanggal1}' AND '{tanggal2}' {rpquery}"); 
            }
            else if (listBox1.SelectedIndex.ToString() == "1")
            {
                showReport("POSdetailHarian", "POSharianDetail.rdlc", $"SELECT nomerTrans, subtotal, barcode, nama, qtyretur, total, status, user, DATE(created_at) as 'created_at' FROM report_penjualan_retur WHERE created_at BETWEEN '{tanggal1}' AND '{tanggal2}' {rpquery}");
            }
            else if (listBox1.SelectedIndex.ToString() == "2")
            {
                showReport("harianSummary", "POSharianSummary.rdlc", $"SELECT SUM(totalBiaya) AS 'total',DATE(tanggalTrans) AS 'tanggalTrans' FROM report_penjualan where tanggalTrans BETWEEN '{tanggal1}' AND '{tanggal2}' {rpquery} GROUP BY DATE(tanggalTrans)");
            }
            else if (listBox1.SelectedIndex.ToString() == "3")
            {
                showReport("POSperKategori", "POSperKategori.rdlc", $"SELECT kategori, SUM(quantity) AS 'quantity', SUM(harga_jual * quantity) AS 'harga_jual',SUM(qtyretur) AS 'qtyretur', SUM(diskonItem) AS 'diskonTotal' , SUM(hargaRetur) AS 'hargaRetur', tanggalTrans FROM view_report_penjualan_retur  where tanggalTrans BETWEEN '{tanggal1}' AND '{tanggal2}' {vrpquery} GROUP BY kategori");
            }
            else if (listBox1.SelectedIndex.ToString() == "4")
            {
                showReport("POSperKasirDetail", "POSperKasirDetail.rdlc", $"SELECT * FROM view_report_penjualan where tanggalTrans BETWEEN '{tanggal1}' AND '{tanggal2}' {vrpquery}");
            }
            else if (listBox1.SelectedIndex.ToString() == "5")
            {
                showReport2source("POSperKasirSummary","POSretur", "POSperKasirSummary.rdlc", $"SELECT SUM(totalBiaya) AS 'totalBiaya', COUNT(id_penjualan) AS 'nomerTrans' , USER AS 'User' FROM report_penjualan where tanggalTrans BETWEEN '{tanggal1}' AND '{tanggal2}' {rpquery} group by User", $"SELECT User, Count(*) AS 'quantity',SUM(total) as 'total' FROM report_retur_pos where updated_at BETWEEN '{tanggal1}' AND '{tanggal2}' {rpquery}");
            }
            else if (listBox1.SelectedIndex.ToString() == "6")
            {
                showReport("POSperKategoriDetail", "POSperKategoriDetail.rdlc", $"SELECT * FROM view_report_penjualan where tanggalTrans BETWEEN '{tanggal1}' AND '{tanggal2}' {vrpquery}");
            }
            else if (listBox1.SelectedIndex.ToString() == "7")
            {
                showReport("kategoriSummary", "POSperKategoriSummary.rdlc", $"SELECT kategori, SUM(quantity) AS 'quantity', SUM(total) AS 'total', tanggalTrans FROM view_report_penjualan where tanggalTrans BETWEEN '{tanggal1}' AND '{tanggal2}' {vrpquery} GROUP BY kategori");
            }
            else if (listBox1.SelectedIndex.ToString() == "8")
            {
                showReport("POSperKategoriTerbanyakDetail", "POSperKategoriTerbanyak Detail.rdlc", $"SELECT * FROM view_report_penjualan where tanggalTrans BETWEEN '{tanggal1}' AND '{tanggal2}'  {vrpquery}");
            }
            else if (listBox1.SelectedIndex.ToString() == "9")
            {
                showReport("POSperKategoriTerbanyakSummary", "POSperKategoriTerbanyakSummary.rdlc", $"SELECT kategori, tanggalTrans, SUM(quantity) AS 'quantity', SUM(diskonItem) AS 'diskonItem', SUM(total) AS 'total' FROM view_report_penjualan where tanggalTrans BETWEEN '{tanggal1}' AND '{tanggal2}' {vrpquery} GROUP BY tanggalTrans,kategori");
            }
        }

        public void fillCombo()
        {
            cboKategori.Items.Clear();
            cboUser.Items.Clear();

            using (var cmd = new MySqlCommand("SELECT * FROM category_barangs", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        cboKategori.Items.Add(rd["name"].ToString());
                    }
                }
            }

            using (var cmd = new MySqlCommand("SELECT * FROM user_cabangs", op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        cboUser.Items.Add(rd["username"].ToString());
                    }
                }
            }
        }

        public void showReport(string sourcename, string filename, string Query)
        {
            tanggal1 = tgl1.Value.ToString("yyyy-MM-dd 00:00:00");
            tanggal2 = tgl2.Value.ToString("yyyy-MM-dd 23:59:00");
            //simple tanggal
            string tgal1 = tgl1.Value.ToString("dd/MMM/yy");
            string tgal2 = tgl2.Value.ToString("dd/MMM/yy");

            var dt = new DataTable();
            //ambil data Detail
            using (var cmd = new MySqlCommand(Query, op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.HasRows)
                    {
                        mb.PeringatanOK("Tidak ada Data");
                        return;
                    }
                    else
                    {
                        dt.Load(rd);
                    }
                }
            }

            //Ambil setting cabang
            var md = op.CabangConfig();

            var param = new ReportParameter[5];
            param[0] = new ReportParameter("Cabang", md.Nama);
            param[1] = new ReportParameter("Alamat", md.Alamat);
            param[2] = new ReportParameter("Tanggal1", tgal1);
            param[3] = new ReportParameter("Tanggal2", tgal2);
            param[4] = new ReportParameter("TanggalToday", DateTime.Now.ToString("dd/MMM/yyyy"));

            var print = new PrintReport();
            var source = new ReportDataSource(sourcename, dt);
            print.LoadReport(op.pathReportPOS(filename), source, param);
        }

        public void showReport2source(string sourcename, string sourcename2, string filename, string Query, string Query2)
        {
            tanggal1 = tgl1.Value.ToString("yyyy-MM-dd 00:00:00");
            tanggal2 = tgl2.Value.ToString("yyyy-MM-dd 23:59:00");
            //simple tanggal
            string tgal1 = tgl1.Value.ToString("dd/MMM/yy");
            string tgal2 = tgl2.Value.ToString("dd/MMM/yy");

            var dt = new DataTable();
            var dt2 = new DataTable();
            //ambil data Detail
            using (var cmd = new MySqlCommand(Query, op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.HasRows)
                    {
                        mb.PeringatanOK("Tidak ada Data");
                        return;
                    }
                    else
                    {
                        dt.Load(rd);
                    }
                }
            }
            
            using (var cmd = new MySqlCommand(Query2, op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.HasRows)
                    {
                        mb.PeringatanOK("Tidak ada Data");
                        return;
                    }
                    else
                    {
                        dt2.Load(rd);
                    }
                }
            }

            //Ambil setting cabang
            var md = op.CabangConfig();

            var param2 = new ReportDataSource[2];
            param2[0] = new ReportDataSource(sourcename, dt);
            param2[1] = new ReportDataSource(sourcename2, dt2);
            
            var param = new ReportParameter[5];
            param[0] = new ReportParameter("Cabang", md.Nama);
            param[1] = new ReportParameter("Alamat", md.Alamat);
            param[2] = new ReportParameter("Tanggal1", tgal1);
            param[3] = new ReportParameter("Tanggal2", tgal2);
            param[4] = new ReportParameter("TanggalToday", DateTime.Now.ToString("dd/MMM/yyyy"));

            var print = new PrintReport();
            print.LoadReport2source(op.pathReportPOS(filename), param2, param);
        }

        private void LaporanPOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            _master.CloseForm();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            _master.CloseForm();
        }
    }
}

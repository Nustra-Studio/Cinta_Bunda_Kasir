﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using KasirApp.Model;
using KasirApp.View;
using KasirApp.Report;
using Microsoft.Reporting.WinForms;

namespace KasirApp.GUI
{
    public partial class Laporan_Kartu_Stock_Barang : Form,iPopUpRecieve
    {
        string tanggal1;
        string tanggal2;
        string status;
        MboxOperator mb = new MboxOperator();
        Operator op = new Operator();
        userDataModel _user;
        iMasterForm _master;
        //Constructor
        public Laporan_Kartu_Stock_Barang(iMasterForm mas, userDataModel user)
        {
            InitializeComponent();
            tgl1.Value = DateTime.Now;
            tgl2.Value = DateTime.Now;
            tanggal1 = tgl1.Value.ToString("yyyy-MM-dd 00:00:00");
            tanggal2 = tgl2.Value.ToString("yyyy-MM-dd 23:59:00");
            _master = mas;
            _user = user;
        }
        public void GetPopUpData(BarangsModel model)
        {
            if (model.Kode == "")
            {

            }
            else if(status == "opname")
            {
                string bcode = model.Nama;
                Console.WriteLine(bcode);
                tanggal1 = tgl1.Value.ToString("dd-MM-yyyy");
                tanggal2 = tgl2.Value.ToString("dd-MM-yyyy");
                showReport2("ReportOpname", "ReportOpname.rdlc", $"SELECT * FROM view_report_opnames WHERE nomerTrans ='{bcode}'");
                op.insertHistoriUser(_user, this.Text, "Cek Report Opname");
            }
            else if(status == "barang")
            {
                string bcode = model.Kode;
                Console.WriteLine(bcode);
                tanggal1 = tgl1.Value.ToString("yyyy-MM-dd 00:00:00");
                tanggal2 = tgl2.Value.ToString("yyyy-MM-dd 23:59:00");
                showReport("StockDetail", "StokDetail.rdlc", $"SELECT * FROM report_stock_detail WHERE barcode='{bcode}' AND updated_at BETWEEN '{tanggal1}' AND '{tanggal2}'");
                op.insertHistoriUser(_user, this.Text, "Cek Report Stok");
            }
        }

        public void showReport2(string sourcename, string filename, string Query)
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
                    if (!rd.Read())
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

            var param = new ReportParameter[3];

            using (var cmd = new MySqlCommand(Query, op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        param[0] = new ReportParameter("Tanggal", rd["updated_at"].ToString());
                        param[1] = new ReportParameter("NomerTrans", rd["nomerTrans"].ToString());
                        param[2] = new ReportParameter("Status", rd["Posted"].ToString() == "1" ? "Posted" : "Void");
                    }
                }
            }

            var print = new PrintReport();
            var source = new ReportDataSource(sourcename, dt);
            print.LoadReport(op.pathReport(filename), source, param);
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

            var param = new ReportParameter[4];
            param[0] = new ReportParameter("Cabang", md.Nama);
            param[1] = new ReportParameter("Alamat", md.Alamat);
            param[2] = new ReportParameter("Tanggal1", tgal1);
            param[3] = new ReportParameter("Tanggal2", tgal2);

            var print = new PrintReport();
            var source = new ReportDataSource(sourcename, dt);
            print.LoadReport(op.pathReport(filename), source, param);
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                var pp = new PopUp(this);
                pp.Show();
                pp.getBarang("");
                status = "barang";
            }
            else if (listBox1.SelectedIndex == 1)
            {
                showReport("Minimum", "StokMinim.rdlc", $"SELECT * FROM barangs WHERE updated_at BETWEEN '{tanggal1}' AND '{tanggal2}' AND stok > 0 AND stok < 3 ");
                op.insertHistoriUser(_user, this.Text, "Cek Report Stok");
            }
            else if (listBox1.SelectedIndex == 2)
            {
                showReport("Minimum", "StokMinus.rdlc", $"SELECT * FROM barangs where updated_at BETWEEN '{tanggal1}' AND '{tanggal2}' And stok <= 0");
                op.insertHistoriUser(_user, this.Text, "Cek Report Stok");
            }
            else if (listBox1.SelectedIndex == 3)
            {
                var pop = new PopUp(this); 
                pop.getDataList("select updated_at as 'Tanggal', nomerTrans,Barcode from view_report_opnames group by nomerTrans", $"select updated_at as 'Tanggal', nomerTrans from view_report_opnames WHERE nomerTrans LIKE ");
                pop.Show();
                status = "opname";
            }
        }

        public void FormClose()
        {
            this.Hide();
            _master.CloseForm();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            FormClose();
        }

        private void Laporan_Kartu_Stock_Barang_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClose();
        }
    }
}

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

namespace KasirApp.GUI.Supervisor
{
    public partial class LaporanAktifitas : Form
    {
        string tanggal1;
        string tanggal2;
        MboxOperator mb = new MboxOperator();
        Operator op = new Operator();
        iMasterForm _master;
        public LaporanAktifitas(iMasterForm mas)
        {
            InitializeComponent();
            tgl1.Value = DateTime.Now;
            tgl2.Value = DateTime.Now;
            tanggal1 = tgl1.Value.ToString("yyyy-MM-dd 00:00:00");
            tanggal2 = tgl2.Value.ToString("yyyy-MM-dd 23:59:00");
            _master = mas;
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            tanggal1 = tgl1.Value.ToString("yyyy/MM/dd 00:00:00");
            tanggal2 = tgl2.Value.ToString("yyyy/MM/dd 23:00:00");

            showReport("historiUser", "AktifitasUser.rdlc", $"SELECT * FROM histori_user where created_at BETWEEN '{tanggal1}' AND '{tanggal2}'");
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
            print.LoadReport(op.pathReport(filename), source, param);
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

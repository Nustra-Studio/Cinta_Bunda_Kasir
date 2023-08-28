using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KasirApp.Model;
using KasirApp.Repository;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;

namespace KasirApp.Report
{
    public partial class PrintReport : Form
    {
        TransaksiModel _trans;
        Operator op = new Operator();

        public PrintReport(TransaksiModel model)
        {
            InitializeComponent();
            //this.Controls.Add(reportViewer1);
            //reportViewer1.Dock = DockStyle.Fill;
            _trans = model;
            
            PrintStruk(_trans);
        }

        public void PrintStruk(TransaksiModel model)
        {
            string mbayar = $"Rp.{model.Harga_jual}";
            string mbali = $"Rp.{model.Harga}";
            string kabeh = model.Total;
            op.KonekDB();
            var da = new MySqlDataAdapter("Select * from histori_penjualan WHERE nomerTrans = '" + model.NomorPJ + "'", op.Conn);
            DsKasir ds = new DsKasir();
            var _repo = new PrintRepo();
            da.Fill(ds, "Dt_Struk");

            ReportDataSource datasource = new ReportDataSource("Struk", ds.Tables[0]);

            var subtotal = new ReportParameter("Subtotal", $"Rp.{kabeh}");//Subtotal
            var diskon = new ReportParameter("Diskon", $"Rp.0");//Subtotal
            var kembali = new ReportParameter("Bayar", mbayar);//Subtotal
            var bayar = new ReportParameter("Kembali", mbali);//Subtotal

            LocalReport struk = new LocalReport();
            struk.ReportPath = Application.StartupPath + "\\Struk.rdlc";
            struk.DataSources.Add(datasource);
            struk.SetParameters(subtotal);
            struk.SetParameters(bayar);
            struk.SetParameters(diskon);
            struk.SetParameters(kembali);
            struk.PrintToPrinter();
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Test", new Font("arial", 12, FontStyle.Regular), Brushes.Black, new Point(10,10));
        }

        private void PrintReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //printPreviewDialog1.Document = printDocument1;

                //printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);

                //printPreviewDialog1.ShowDialog();
            }
        }

        private void PrintReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}

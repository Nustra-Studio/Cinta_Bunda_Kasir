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
using System.IO;

namespace KasirApp.Report
{
    public partial class PrintReport : Form
    {
        Operator op = new Operator();
        public PrintReport()
        {
            InitializeComponent();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
        }

        private void PrintReport_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void PrintReport_Load(object sender, EventArgs e)
        {

        }

        public void LoadReport(string PATH, ReportDataSource source, ReportParameter[] param)
        {
            this.reportViewer1.LocalReport.ReportPath = PATH;
            if (param == null)
            {

            }
            else
            {
                this.reportViewer1.LocalReport.SetParameters(param);
            }
            this.reportViewer1.LocalReport.DataSources.Add(source);
            this.reportViewer1.RefreshReport();

            this.Show();

            this.WindowState = FormWindowState.Maximized;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        public void LoadReport2source(string PATH, ReportDataSource[] source, ReportParameter[] param)
        {
            this.reportViewer1.LocalReport.ReportPath = PATH;
            if (param == null)
            {

            }
            else
            {
                this.reportViewer1.LocalReport.SetParameters(param);
            }
            this.reportViewer1.LocalReport.DataSources.Add(source[1]);
            this.reportViewer1.LocalReport.DataSources.Add(source[2]);
            this.reportViewer1.RefreshReport();

            this.Show();

            this.WindowState = FormWindowState.Maximized;
        }

        //private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        //{
        //    e.Graphics.DrawString(".", new Font("Consolas", 12), new SolidBrush(Color.Black), new Point(12, 453));
        //}
    }
}

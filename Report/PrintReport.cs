using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KasirApp.Report
{
    public partial class PrintReport : Form
    {
        public PrintReport()
        {
            InitializeComponent();
            //this.Controls.Add(reportViewer1);
            //reportViewer1.Dock = DockStyle.Fill;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Test", new Font("arial", 12, FontStyle.Regular), Brushes.Black, new Point(10,10));
        }

        private void PrintReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                printPreviewDialog1.Document = printDocument1;

                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);

                printPreviewDialog1.ShowDialog();
            }
        }
    }
}

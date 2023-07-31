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
    public partial class StockOpname : Form
    {
        public StockOpname()
        {
            InitializeComponent();
            dateTimePicker1.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public void raiseKeyEvent(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                txtNomor.Text = $"POP-{DateTime.Now.ToString("MMdd")} ";
            }
        }

        private void StockOpname_KeyDown(object sender, KeyEventArgs e)
        {
            raiseKeyEvent(e);
        }
    }
}

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
using KasirApp.Repository;

namespace KasirApp.GUI
{
    public partial class subKategori : Form
    {
        iInsert _ins;

        public subKategori(Insert ins)
        {
            InitializeComponent();
            CenterToScreen();
            _ins = ins;
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            var _repo = new subKategoriRepo();
            _repo.InsertData(txtNama.Text.Trim(),txtKategori.Text.Trim());
            txtNama.Text = "";
            _ins.RefreshCombo();
            this.Hide();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtKategori_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

       
    }
}

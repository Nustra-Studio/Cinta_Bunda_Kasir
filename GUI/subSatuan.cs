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
using KasirApp.Model;

namespace KasirApp.GUI
{
    public partial class subSatuan : Form
    {
        Operator op = new Operator();
        userDataModel _user;
        iInsert _ins;
        public subSatuan(iInsert insert, userDataModel user)
        {
            InitializeComponent();
            CenterToScreen();
            _ins = insert;
            _user = user;
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            var _repo = new subSatuanRepo();
            _repo.InsertData(txtNama.Text.Trim());
            op.insertHistoriUser(_user, this.Text, "Masukan Satuan");
            txtNama.Text = "";
            _ins.RefreshCombo();
            this.Hide();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}

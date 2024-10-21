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
using KasirApp.View;
using MySql.Data.MySqlClient;

namespace KasirApp.GUI.Supervisor
{
    public partial class ResetStokKeNol : Form
    {
        iMasterForm _master;
        userDataModel _user;
        MboxOperator mb = new MboxOperator();
        Operator op = new Operator();
        public ResetStokKeNol(iMasterForm mstr, userDataModel user)
        {
            InitializeComponent();
            _master = mstr;
            _user = user;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            _master.CloseForm();
            this.Hide();
            this.Close();
        }

        private void ResetStokKeNol_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            _master.CloseForm();
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            if (mb.PeringatanYesNo("Reset Stock Ke Nol?")==true)
            {
                using (var cmd = new MySqlCommand("UPDATE barangs SET stok='0'", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                    mb.InformasiOK("Stok Ter Reset");
                    op.insertHistoriUser(_user, this.Text, "Reset Stok");
                }
            }
        }
    }
}

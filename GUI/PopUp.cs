using System;
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

namespace KasirApp.GUI
{
    public partial class PopUp : Form
    {
        Operator op = new Operator();
        string select;
        public PopUp()
        {
            InitializeComponent();
        }

        public void getBarang(string text)
        {
            DGV.DataSource = op.getByQuery("SELECT Nama, Barcode, Categori FROM view_barangs_all WHERE Nama LIKE '%" + text + "%' OR Barcode LIKE '%" + text + "%' ");
            gunaGradientButton1.Text = "Proses";
            gunaGradientButton3.Visible = false;
        }

        public void getMember(string text)
        {
            DGV.DataSource = op.getByQuery("SELECT telepon,nama,email from members where nama LIKE '%" + text + "%'");
            gunaGradientButton1.Text = "Tambah";
            gunaGradientButton3.Visible = true;
        }

        public void member()
        {
            DGV.DataSource = op.getByQuery("select telepon,nama,email from members");
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            if (gunaGradientButton1.Text == "Proses")
            {
                Transaksi.instance.tb.Text = select;
                this.Hide();
            }
            else if (gunaGradientButton1.Text == "Tambah")
            {
                Transaksi.instance.tb2.Text = select;
                this.Hide();
            }
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            getBarang(textBox1.Text);
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            AddMember frm = new AddMember(this.member);
            frm.Show();
        }

        public void PopUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                select = DGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}

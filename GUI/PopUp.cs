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
using KasirApp.View;
using KasirApp.Presenter;

namespace KasirApp.GUI
{
    public partial class PopUp : Form,iPopup
    {
        //Fields
        Operator op = new Operator();
        PopUpPresenter _prn;
        iPopUpRecieve _poprec;
        string select;
        //Constructor
        public PopUp(iPopUpRecieve rec)
        {
            InitializeComponent();
            _poprec = rec;
            _prn = new PopUpPresenter(this);
        }

        //Method
        public void DatagridShow(DataTable dt)
        {
            DGV.DataSource = dt;
        }

        public void ShowBarangs(string text)
        {
            DGV.DataSource =  _prn.tampilBarangs(text);
            this.Show();
        }

        public void GetBarangs(BarangsModel md)
        {
            _poprec.GetPopUpData(md);
        }
        
        public void getBarang(string text)
        {
            DGV.DataSource = op.getByQuery("SELECT Nama, Barcode, Categori FROM view_barangs_all WHERE Nama LIKE '%" + text + "%' OR Barcode LIKE '%" + text + "%' ");
            btnMasukan.Text = "Proses";
            gunaGradientButton3.Visible = false;
        }

        public void getMember(string text)
        {
            DGV.DataSource = op.getByQuery("SELECT telepon,nama,email from members where nama LIKE '%" + text + "%'");
            btnMasukan.Text = "Tambah";
            gunaGradientButton3.Visible = true;
        }

        public void member()
        {
            DGV.DataSource = op.getByQuery("select telepon,nama,email from members");
        }
        
        //Raise Events
        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            _prn.getBarangsData(select);
            this.Hide();
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            getBarang(textBox1.Text);
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {

        }

        public void PopUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        //DGV Events
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

        public void RaiseEnterDGV(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _prn.getBarangsData(select);
                this.Hide();
            }
        }
    }
}

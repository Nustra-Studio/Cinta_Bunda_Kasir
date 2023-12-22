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
        string search;
        string search2;
        bool state;
        //Constructor
        public PopUp(iPopUpRecieve rec)
        {
            InitializeComponent();
            _poprec = rec;
            _prn = new PopUpPresenter(this);
            state = false;
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
            if (state == false)
            {
                _poprec.GetPopUpData(md);
            }
            else
            {
                var mdo = new BarangsModel();
                mdo.Nama = select;
                _poprec.GetPopUpData(mdo);
            }
        }
        
        public void getBarang(string text)
        {
            DGV.DataSource = op.getByQuery("SELECT Nama, Barcode, Categori FROM view_barangs_all WHERE Nama LIKE '%" + text + "%' OR Barcode LIKE '%" + text + "%' ");
            btnMasukan.Text = "Proses";
            gunaGradientButton3.Visible = false;
        }

        public void getDataList(string Query, string searchQuery)
        {
            search = searchQuery;
            DGV.DataSource = op.getByQuery(Query);
            btnMasukan.Text = "Proses";
            gunaGradientButton3.Visible = false;
            state = true;
        }

        public void getDataList2Param(string Query, string searchQuery, string param2)
        {
            search = searchQuery;
            search2 = param2;
            state = true;
            DGV.DataSource = op.getByQuery(Query);
            btnMasukan.Text = "Proses";
            gunaGradientButton3.Visible = false;
        }

        public void SearchDataList2Param()
        {
            DGV.DataSource = op.getByQuery($"{search}'%{textBox1.Text}%' OR {search2}'%{textBox1.Text}%'");
        }

        public void SearchDataList()
        {
            DGV.DataSource = op.getByQuery($"{search}'%{textBox1.Text}%'");
        }

        //Raise Events
        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            _prn.getBarangsData(select);
            this.Hide();
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            if (state == false)
            {
                getBarang(textBox1.Text);
            }
            else
            {
                SearchDataList();
            }
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {

        }

        public void PopUp_FormClosed(object sender, FormClosedEventArgs e)
        {

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
                //return;
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

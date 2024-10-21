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
using KasirApp.Presenter;
using KasirApp.Model;

namespace KasirApp.GUI
{
    public partial class SubPenyesuaian : Form,iSubPenyesuaian,iPopUpRecieve
    {
        //Interfaces
        public string nomerTrans { get => strukPAD; set => strukPAD = value; }
        public string barcode { get => txtBarang.Text; set => txtBarang.Text = value; }
        public string nama { get => txtBarang.Text; set => txtBarang.Text = value; }
        public string stok { get => txtStokNow.Text; set => txtStokNow.Text = value; }
        public string stoknew { get => txtStok.Text; set => txtStok.Text = value; }

        //Interface Method
        public void GetPopUpData(BarangsModel model)
        {
            txtBarang.Text = model.Kode;
        }

        //Fields
        iPenyesuaian _peny;
        PenyesuaianPresenter _pres;
        string strukPAD;

        //Constructor
        public SubPenyesuaian(iPenyesuaian pes, string subnomerTrans)
        {
            InitializeComponent();  
            CenterToScreen();
            _peny = pes;
            strukPAD = subnomerTrans;
            _pres = new PenyesuaianPresenter(this, _peny);
        }

        public bool cekItem()
        {
            return _pres.cekBarang();
        }

        public void clearAll()
        {
            txtBarang.Clear();
            txtStokNow.Clear();
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            if (cekItem()==true)
            {
                _pres.addItem();
                _peny.RefreshDGV();
                clearAll();
            }
            else
            {
                PopUp pop = new PopUp(this);
                pop.Show();
                pop.ShowBarangs(nama);
            }
        }

        private void txtBarang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cekItem() == true)
                {
                    txtStokNow.Text =  _pres.getData(nama);
                }
                else
                {
                    PopUp pop = new PopUp(this);
                    pop.Show();
                    pop.ShowBarangs(nama);
                }
            }
            else if (e.KeyCode == Keys.F4)
            {
                PopUp pop = new PopUp(this);
                pop.Show();
                pop.ShowBarangs(nama);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

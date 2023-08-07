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
    public partial class StockOpname : Form, iOpname, iPopUpRecieve
    {
        //Fields
        OpnamePresenter _op;

        //Interface
        public string nomer { get => txtNomor.Text; set => txtNomor.Text = value; }
        public string kode { get => txtKode.Text; set => txtKode.Text = value; }
        public string nama { get => txtNama.Text; set => txtNama.Text = value; }
        
        //Constructor
        public StockOpname()
        {
            InitializeComponent();
            _op = new OpnamePresenter(this);
        }

        //Interface Method
        public void takeNumber(OpnameModel model)
        {
            txtNomor.Text = $"POP-{model.Kode.ToString()}";
        }

        public void GetPopUpData(BarangsModel model)
        {
            txtKode.Text = model.Kode;
            txtNama.Text = model.Nama;
            txtStok.Text = model.Stok; 
        }

        public void raiseKeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                _op.ambilNmr();
            }
            else if (e.KeyCode == Keys.F12)
            {
                PopUp pop = new PopUp(this);
                pop.Show();
                pop.ShowBarangs();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                _op.cekData();
            }
        }

        
    }
}

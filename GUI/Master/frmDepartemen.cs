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

namespace KasirApp.GUI.Master
{
    public partial class frmDepartemen : Form,iParentDock,iDepartemen
    {
        //fields
        DepartemenPresenter _prn;

        //interfaces Dept
        public string kode { get => txtKode.Text; set => txtNama.Text = value; }
        public string nama { get => txtNama.Text; set => txtNama.Text = value; }
        public bool kenaDiskon { get => cekDiskon.Checked ? true : false; set => cekDiskon.Checked = value; }

        //Constructor
        public frmDepartemen()
        {
            InitializeComponent();
            startState();
            _prn = new DepartemenPresenter(this, this);
        }
        
        //Method
        public void startState()
        {
            txtKode.Enabled = false;
            txtNama.Enabled = false;
            cekDiskon.Enabled = false;
        }

        public void clear()
        {
            txtKode.Text = null;
            txtNama.Text = null;
            cekDiskon.Checked = false;
        }

        public void showRd(DepartemenModel model)
        {
            txtKode.Text = model.Kode;
            txtNama.Text = model.Nama;
            cekDiskon.Checked = model.KenaDiskon;
        }

        public void openState()
        {
            txtKode.Enabled = true;
            txtNama.Enabled = true;
            cekDiskon.Enabled = true;
        }

        //Event Args
        public void raiseTombol(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                 _prn.Simpan();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                _prn.atas();
                startState();
            }
        }

        private void frmDepartemen_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit();
        }

        //Interface Field
        public void add()
        {
            clear();
            openState();
        }

        public void top()
        {
            _prn.atas();
        }
        public void next()
        {
            _prn.lanjut();
        }

        public void prev()
        {
            _prn.sebelum();
        }
        public void Bot()
        {
            _prn.bawah();
        }

        public void delete()
        {
            _prn.hapus();
        }

        public void exit()
        {
            return;
        }

        public void list()
        {
            return;
        }

        public void print()
        {
            return;
        }

        public void search()
        {
            return;
        }

       
    }
}

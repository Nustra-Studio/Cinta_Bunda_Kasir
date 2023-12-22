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
    public partial class frmDepartemen : Form,iParentDock,iDepartemen,iPopUpRecieve
    {
        //fields
        DepartemenPresenter _prn;
        bool editState;

        //interfaces Dept
        public string kode { get => txtKode.Text; set => txtNama.Text = value; }
        public string nama { get => txtNama.Text; set => txtNama.Text = value; }
        public bool kenaDiskon { get => cekDiskon.Checked ? true : false; set => cekDiskon.Checked = value; }
        public bool grosir { get => chkGrosir.Checked ? true : false; set => chkGrosir.Checked = value; }

        public void GetPopUpData(BarangsModel model)
        {
            txtKode.Text = model.Nama;
            _prn.showByList();
        }

        //Constructor
        public frmDepartemen()
        {
            InitializeComponent();
            CenterToParent();
            startState();
            _prn = new DepartemenPresenter(this, this);
            Bot();
            editState = false;
        }
        
        //Method
        public void startState()
        {
            txtKode.Enabled = false;
            txtNama.Enabled = false;
            cekDiskon.Enabled = false;
            chkGrosir.Enabled = false;
        }

        public void clear()
        {
            txtKode.Text = null;
            txtNama.Text = null;
            cekDiskon.Checked = false;
            chkGrosir.Enabled = false;
        }

        public void showRd(DepartemenModel model)
        {
            txtKode.Text = model.Kode;
            txtNama.Text = model.Nama;
            cekDiskon.Checked = model.KenaDiskon.Equals(1) ? true : false;
            chkGrosir.Checked = model.IsGrosir.Equals(1) ? true : false;
        }

        public void openState()
        {
            txtKode.Enabled = true;
            txtNama.Enabled = true;
            cekDiskon.Enabled = true;
            chkGrosir.Enabled = true;
        }

        //Event Args
        public void raiseTombol(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && editState == true)
            {
                _prn.EditData();
                editState = false;
            }
            else if (e.KeyCode == Keys.Enter)
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
            startState();
        }
        public void next()
        {
            _prn.lanjut();
            startState();
        }

        public void prev()
        {
            _prn.sebelum();
            startState();
        }

        public void Bot()
        {
            _prn.bawah();
            startState();
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
            var pop = new PopUp(this);
            pop.getDataList2Param("SELECT name AS 'Nama', kode AS 'Kode' FROM category_barangs", "SELECT name AS 'Nama', kode AS 'Kode' FROM category_barangs WHERE Nama LIKE ", "OR kode LIKE");
            pop.Show();
        }

        public void print()
        {
            return;
        }

        public void edit()
        {
            openState();
            txtKode.Enabled = false;
            editState = true;
        }
    }
}

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
            _prn = new DepartemenPresenter(this);
        }
        
        //Method
        public void startState()
        {
            txtKode.Enabled = false;
            txtNama.Enabled = false;
            cekDiskon.Enabled = false;
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
        }

        //Interface Field
        public void add()
        {
            openState();
            _prn.Simpan();
        }

        public void Bot()
        {
            throw new NotImplementedException();
        }

        public void delete()
        {
            throw new NotImplementedException();
        }

        public void exit()
        {
            throw new NotImplementedException();
        }

        public void list()
        {
            throw new NotImplementedException();
        }

        public void next()
        {
            throw new NotImplementedException();
        }

        public void prev()
        {
            throw new NotImplementedException();
        }

        public void print()
        {
            throw new NotImplementedException();
        }

        public void search()
        {
            throw new NotImplementedException();
        }

        public void top()
        {
            openState();
        }
    }
}

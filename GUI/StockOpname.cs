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
        iMasterForm _master;
        userDataModel _user;
        long nomorAwal;
        int beda;
        int status = 0;
        string tgl;
        string select;

        //Fields Interface
        public string nomer { get => txtNomor.Text; set => txtNomor.Text = value; }
        public string kode { get => txtKode.Text; set => txtKode.Text = value; }
        public string nama { get => txtNama.Text; set => txtNama.Text = value; }
        public string stok { get => txtStok.Text; set => txtStok.Text = value; }
        public string perubahan { get => txtQuantity.Text; set => txtQuantity.Text = value; }
        public int selisih { get => beda; set => beda = value; }
        public int posted { get => status; set => status = value; }
        public string tanggal { get => tgl; set => tgl = value; }
        public long numeringKwitansi { get => nomorAwal; set => nomorAwal = value; }
        public string selection { get => select; set => select = value; }
        public string search { get => txtSearch.Text; set => txtSearch.Text = value; }

        //Interfaces Method 
        public void showTable(DataTable dt)
        {
            DGV.Refresh();
            DGV.AutoGenerateColumns = false;
            DGV.DataSource = dt;
        }

        //Constructor
        public StockOpname(iMasterForm mas,userDataModel user)
        {
            InitializeComponent();
            tgl = DateTime.Now.ToString("yyyy/MM/dd");
            _master = mas;
            _user = user;
            _op = new OpnamePresenter(this,_user);
            startState();
        }

        //Interface Method
        public void takeNumber(OpnameModel model)
        {
            txtNomor.Text = $"POP-{model.NumeringKwitansi.ToString()}";
            nomorAwal = model.NumeringKwitansi;
            _op.cekTable();
        }

        public void GetPopUpData(BarangsModel model)
        {
            txtKode.Text = model.Kode;
            txtNama.Text = model.Nama;
            txtStok.Text = model.Stok; 
        }

        public bool cekData()
        {
            return _op.cekData();
        }

        //Limitasi Keyboard
        public void NumericOnly(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //KeyEventArgs
        public void raiseKeyEvent(object sender, KeyEventArgs e)
        {
            if (txtNomor.Focused == true && e.KeyCode == Keys.F10)
            {
                _op.ambilNmr();
                openState();
                txtKode.Focus();
            }
            else if (txtNomor.Focused == true && e.KeyCode == Keys.Enter)
            {
                _op.cekTable();
            }
            else if (e.KeyCode == Keys.Delete && select != "")
            {
                if (_op.DeleteData() == true)
                {
                    _op.cekTable();
                }
            }
        }

        public void raiseEnterKey(object sender, KeyEventArgs e)
        {
            string search = txtKode.Text.ToString();
            if (e.KeyCode == Keys.F12)
            {
                PopUp pop = new PopUp(this);
                pop.ShowBarangs(search);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (cekData() == true && chkDirect.Checked == true)
                {
                    _op.insertDirect();
                    txtKode.Clear();
                }
                else
                {
                    PopUp pop = new PopUp(this);
                    pop.ShowBarangs(search);
                }
            }
            else if (e.KeyCode == Keys.Delete && select != "")
            {
                if (_op.DeleteData()==true)
                {
                    _op.cekTable();
                }
            }
        }

        public void raiseInsertEnter(object sernder, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _op.insertOpname();
                clearTxtBox();
            }
            else if (e.KeyCode == Keys.Delete && select != "")
            {
                if (_op.DeleteData() == true)
                {
                    _op.cekTable();
                }
            }
        }

        //Execute Saat Ketik Keyboard
        public void QuantityValueChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text == null)
            {
                return;
            }
            else
            {
                int stokAwal = txtStok.Text.Equals(string.Empty) ? 0 : Convert.ToInt32(txtStok.Text);
                int quantity = txtQuantity.Text.Equals(string.Empty) ? 0 : Convert.ToInt32(txtQuantity.Text);

                beda = quantity - stokAwal;

                txtSelisih.Text = selisih.ToString();
            }
        }

        //Method View / UI
        private void startState()
        {
            txtKode.Enabled = false;
            txtQuantity.Enabled = false;
            txtSearch.Enabled = false;
        }
        
        private void openState()
        {
            txtKode.Enabled = true;
            txtQuantity.Enabled = true;
            txtSearch.Enabled = true;
            txtNomor.ReadOnly = true;
        }

        private void clearTxtBox()
        {
            txtKode.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtNama.Text = string.Empty;
            txtSearch.Text = string.Empty;
            txtSelisih.Text = string.Empty;
            txtStok.Text = string.Empty;
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                _op.cekTable();
            }
            else
            {
                DGV.DataSource = _op.Search();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtKode.Enabled || txtNomor.Text != "")
            {
                _op.PrintOP();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            _master.CloseForm();
        }

        private void StockOpname_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            _master.CloseForm();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _op.AttemptSyncData();
            this.Cursor = Cursors.Default;  
        }

        private void btnCursor_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _op.Upload();
            this.Cursor = Cursors.Default;
        }
    }
}

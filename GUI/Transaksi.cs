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
using KasirApp.Presenter;
using MySql.Data.MySqlClient;

namespace KasirApp.GUI
{
    public partial class Transaksi : Form, iTransaksi, iPopUpRecieve
    {
        //Fields
        userDataModel _user;
        TransaksiPresenter _prn;
        DataTable _Dt;
        iMasterForm _master;
        string select;
        string pjState;
        string memPhone;
        string namaMem;
        string stateUser;
        int diskon;
        int withDiskon;

        //Interface Fields
        public string randKode { get => txtRandKode.Text; set => txtRandKode.Text = value ; }
        public string barcode { get => txtBarcode.Text; set => txtBarcode.Text = value; }
        public string nomorPJ { get => txtNomorKwitansi.Text; set => txtNomorKwitansi.Text = value; }
        public string state { get => pjState; set => pjState = value; }
        public string qty { get => txtQty.Text; set => txtQty.Text = value; }
        public string selection { get => select; set => select = value; }
        public string noHpMem { get => memPhone; set => memPhone = value; }
        public string NamaMem { get => namaMem; set => namaMem = value; }
        public string diskonTrans { get => txtDiskon.Text; set => txtDiskon.Text = value; }
        public string stateDiskon { get => stateUser; set => stateUser = value; }

        //Interface Method
        public void GetDataBarangs(TransaksiModel md)
        {
            txtQty.Text = md.Quantity;
            txtDiskon.Text = md.Diskon;
            string hj = "";
            string textDiskon = "";

            if (md.Nama == null)
            {
                return;
            }
            else if (md.Diskon != "0")
            {
                if (md.State == "harga_jual")
                {
                    hj = md.Harga_jual;
                }
                else if (md.State == "hpp")
                {
                    hj = md.Harga_pokok;
                }
            }
            else
            {
                if (md.State == "harga_jual")
                {
                    hj = md.Harga_jual;
                }
                else if (md.State == "hpp")
                {
                    hj = md.Harga_pokok;
                }
            }
            int harga = Convert.ToInt32(hj);
            //Format String otomatis tambah koma setelah 3 angka 0
            string withkoma = string.Format("{0:0,0}", harga);
            lblHeader.Text = $"{md.Nama} = Rp.{withkoma} {textDiskon}";
        }

        public void tampilKembali(int kembali)
        {
            if (kembali == 0)
            {
                lblHeader.Text = "Uang Pas! Terimakasih sudah berbelanja";
            }
            else
            {
                //Format String otomatis tambah koma setelah 3 angka 0
                string withkoma = string.Format("{0:0,0}", kembali);
                lblHeader.Text = $"Kembali : Rp.{withkoma}";
            }
        }

        public void TampilGrid(DataTable dt)
        {
            _Dt = dt;
            dgv.DataSource = _Dt;
        }

        public void GetMember(RootMember rootmem)
        {
            txtPoint.Text = rootmem.poin.poin.ToString();
            memPhone = rootmem.member.phone.ToString();
            namaMem = rootmem.member.name;
        }

        public void GetPopUpData(BarangsModel model)
        {
            txtBarcode.Text = model.Nama;
            txtHarga.Text = model.Harga_pokok;
            txtQty.Text = "1";
            txtDiskon.Text = "0";
        }

        public int hitungTotal(string dsc)
        {
            int i = 0;
            int sum = 0;
            int diskonmem = 0;
            diskon = 0;
            if (txtPoint.Text != "" && txtRandKode.Text != "" && checkBox1.Checked == true)
            {
                diskonmem = Convert.ToInt32(txtPoint.Text) * 500;
            }

            if (dsc != "")
            {
                diskon = Convert.ToInt32(dsc);
            }

            foreach (var row in dgv.Rows)
            {
                sum += Convert.ToInt32(dgv.Rows[i].Cells["total"].Value);
                i++;
            }

            //Format String otomatis tambah koma setelah 3 bilangan 0
            withDiskon = sum - diskon - diskonmem;
            string withkoma = string.Format("{0:0,0}", withDiskon);

            lblHeader.Text = $"Subtotal = Rp.{withkoma}";

            return withDiskon;
        }

        //Constructor
        public Transaksi(userDataModel user, iMasterForm form)
        {
            InitializeComponent();
            LoadState();
            _user = user;
            _prn = new TransaksiPresenter(this, _user, this);
            pjState = "harga_jual";
            stateUser = "reguler";
            memPhone = "";
            namaMem = "";
            diskon = 0;
            txtNomorKwitansi.Focus();
            txtNamaUser.Text = user.username.ToString();
            _master = form;
            _prn.UpdateState("reguler");
        }

        //Method
        public void LoadState()
        {
            txtBarcode.Enabled = false;
            txtNomorKwitansi.Focus();
            txtBarcode.Text = string.Empty;
            txtHarga.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtQty.ReadOnly = true;
        }

        public void OpenState()
        {
            txtBarcode.Enabled = true;
            txtBarcode.Focus();
            txtDiskon.ReadOnly = true;
            txtDiskon.Text = string.Empty;
            txtQty.ReadOnly = true;
            txtQty.Text = string.Empty;
        }

        public void ChangeState()
        {
            txtBarcode.Enabled = false;
            txtDiskon.ReadOnly = true;
            txtQty.ReadOnly = true;
        }

        public void clear()
        {
            txtBarcode.Text = string.Empty;
            txtHarga.Text = string.Empty;
        }

        public void ClearAll()
        {
            txtBarcode.Text = string.Empty;
            txtHarga.Text = string.Empty;
            _Dt.Clear();
            txtNomorKwitansi.Text = null;
            lblHeader.Text = "Selamat Datang di \n CINTA BUNDA KEDUNGWARU";
        }

        

        //Limitasi Keyboard
        public void NumericOnly(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //Raise KeyDown
        private void GlobalKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                int nomorKwitansi = _prn.TakeNumber();
                string kwitansi = $"PJC-{nomorKwitansi.ToString()}";
                txtNomorKwitansi.Text = kwitansi;
                _prn.TampilTable();
                OpenState();
            }
            else if (e.KeyCode == Keys.F2)
            {
                ChangeState();
                txtBarcode.Enabled = false;
                txtQty.ReadOnly = false;
                txtQty.Focus();
            }
            else if (e.KeyCode == Keys.F3)
            {
                ChangeState();
                txtBarcode.Enabled = false;
                txtDiskon.ReadOnly = false;
                txtDiskon.Focus();
            }
            else if (e.KeyCode == Keys.F4)
            {
                var pop = new PopUp(this);
                pop.Show();
                pop.ShowBarangs(txtBarcode.Text);
            }
            //Bayar Keydown
            else if (e.KeyCode == Keys.F5)
            {
                hitungTotal("0");
                var model = new TransaksiModel();
                model.NomorPJ = txtNomorKwitansi.Text;
                model.Total = withDiskon.ToString();
                model.Harga = "0";
                if (checkBox1.Checked == true && txtPoint.Text != null)
                {
                    model.State = "checked";
                    model.Harga = txtPoint.Text;
                }
                Pembayaran frm = new Pembayaran(this, _user, this, model);
                _master.subForm(frm);
            }
            //F6 Cek Struk
            else if (e.KeyCode == Keys.F6)
            {

            }
            //F7 Harga Reguler
            else if (e.KeyCode == Keys.F7)
            {
                dgv.Columns["harga"].DataPropertyName = "harga_jual";
                dgv.Columns["harga"].HeaderText = "Harga Jual";
                pjState = "harga_jual";
                stateUser = "reguler";
                _prn.UpdateState(stateUser);
                _prn.TampilTable();
            }
            //F8 Harga Karyawan
            else if (e.KeyCode == Keys.F8)
            {
                dgv.Columns["harga"].DataPropertyName = "hpp";   
                dgv.Columns["harga"].HeaderText = "Harga Pokok(Karyawan)";
                pjState = "hpp";
                stateUser = "karyawan";
                _prn.UpdateState(stateUser);
                _prn.TampilTable();
            }
            //F9 Harga Reseller
            else if (e.KeyCode == Keys.F9)
            {
                dgv.Columns["harga"].DataPropertyName = "harga_jual";   
                dgv.Columns["harga"].HeaderText = "Harga Jual(Reseller)";
                pjState = "harga_jual";
                stateUser = "reseller";
                _prn.UpdateState(stateUser);
                _prn.TampilTable();
            }
            else if(e.KeyCode == Keys.Delete)
            {
                var delmodel = new TransaksiModel();
                delmodel.Barkode = select;
                delmodel.NomorPJ = txtNomorKwitansi.Text;
                _prn.DeleteItem(delmodel);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                //Masukan Ke Grid
                if (txtBarcode.Focused == true)
                {
                    _prn.AttemptInsertGrid();
                    txtQty.Text = "";
                    txtDiskon.Text = "";
                }
                //Update Quantity
                else if (txtQty.Focused == true)
                {
                    _prn.ChangeQty();
                    OpenState();
                }
                //Apply Diskon
                else if (txtDiskon.Focused == true)
                {
                    _prn.ApplyDiskon();
                    OpenState();
                }
            }
        }

        public void RaiseEnterKode(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _prn.GetPoint();
            }
        }

        //RaiseEvent TextBox
        private void RaiseBarcodeChanged(object sender, EventArgs e)
        {
            if (txtBarcode.TextLength >= 12)
            {
                _prn.AttemptInsertGrid();
                txtQty.Text = "";
                txtDiskon.Text = "";
            }
            else
            {
                return;
            }
        }

        //Raise Event DataGridView
        private void RaiseCellClicks(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                select = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                return;
            }
            _prn.getDataByValue();
        }

        //Raise ButtonEvents
        private void RaiseAddemember(object sender, EventArgs e)
        {
            AddMember fra = new AddMember(_user);
            if (fra.IsDisposed)
            {
                _master.subForm(fra);
            }
            else
            {
                _master.subForm(fra);
                fra.BringToFront();
            }
        }
    }
}

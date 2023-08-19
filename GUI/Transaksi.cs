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
        Operator op = new Operator();
        userDataModel _user;
        TransaksiPresenter _prn;
        BarangsModel _curentBRG;
        DataTable _Dt;
        string select;
        string pjState;
        string memPhone;
        string namaMem;
        int diskon;

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

                //int diskonan = Convert.ToInt32(md.Diskon);
                //string diskonp = string.Format("{0:0,0}", diskonan);
                //txtDiskon = $"- Rp.{diskonp}";
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
            _curentBRG = model;
            txtBarcode.Text = model.Kode;
            txtHarga.Text = model.Harga_pokok;
        }

        //Constructor
        public Transaksi(userDataModel user)
        {
            InitializeComponent();
            LoadState();
            _user = user;
            _prn = new TransaksiPresenter(this, _user, this);
            pjState = "harga_jual";
            memPhone = "";
            namaMem = "";
            diskon = 0;
            txtNomorKwitansi.Focus();
            //txtNamaUser.Text = user.username.ToString();
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

        public int hitungTotal()
        {
            int i = 0;
            int sum = 0;

            foreach (var row in dgv.Rows)
            {
                sum += Convert.ToInt32(dgv.Rows[i].Cells[4].Value);
                i++;
            }
            //Format String otomatis tambah koma setelah 3 bilangan 0
            int withDiskon = sum - diskon;
            string withkoma = string.Format("{0:0,0}", withDiskon);

            lblHeader.Text = $"Subtotal = Rp.{withkoma}";

            return withDiskon;
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
                Pembayaran frm = new Pembayaran(this, _user, this, hitungTotal());
                frm.Show();
            }
            //F6 Cek Struk
            else if (e.KeyCode == Keys.F6)
            {

            }
            //F7 Harga Karyawan
            else if (e.KeyCode == Keys.F7)
            {
                dgv.Columns["harga"].DataPropertyName = "harga_jual";
                dgv.Columns["harga"].HeaderText = "Harga Jual";
                pjState = "harga_jual";
                _prn.TampilTable();
            }
            else if (e.KeyCode == Keys.F8)
            {
                dgv.Columns["harga"].DataPropertyName = "hpp";   
                dgv.Columns["harga"].HeaderText = "Harga Pokok";
                pjState = "hpp";
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
                fra.Show();
            }
            else
            {
                fra.Show();
                fra.BringToFront();
            }
        }

        //Print Handler
        public void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Cinta Bunda", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(75,10));

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                e.Graphics.DrawString(dgv.Rows[i].Cells[2].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(80,10));
            }
        }

        public void print()
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Show();
        }

        
    }
}

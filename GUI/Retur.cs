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
    public partial class Retur : Form,iParentDock,iRetur,iPopUpRecieve
    {
        ReturPresenter _pres;
        Operator op = new Operator();
        userDataModel _user;
        public string nomerTrans { get => txtNomer.Text; set => txtNomer.Text = value; }
        public string nama { get => NamaItem; set => NamaItem = value; }
        public string barcode { get => txtBarcode.Text; set => txtBarcode.Text = value; }
        public string qtyreturn { get => txtQuantity.Text ; set => txtQuantity.Text = value; }
        public string harga { get => txtHarga.Text; set => txtHarga.Text = value; }
        public string total { get => txtTotal.Text; set => txtTotal.Text = value; }
        public string maxqty { get => txtMax.Text; set => txtMax.Text = value; }

        string NamaItem;

        //Interface Method
        public void add()
        {
            ClearAll();
            txtNomer.Enabled = true;
            txtNomer.Focus();
            ChkStatus("");
        }

        //Parent Iterface
        public void Bot()
        {
            var model = _pres.Bot();
            if (model != null)
            {
                txtBarcode.Text = model.Barcode;
                txtHarga.Text = model.Harga;
                txtNomer.Text = model.NomerTrans;
                txtQuantity.Text = model.Qty;
                txtMax.Text = model.Satuan;
                txtNama.Text = model.Nama;
                txtTotal.Text = model.Total;
            }
            ChkStatus(model.Status);
        }

        public void delete()
        {
            
        }

        public void edit()
        {
            
        }

        public void exit()
        {

        }

        public void list()
        {
            var pop = new PopUp(this);
            pop.getDataList("SELECT * FROM view_popup_retur", "SELECT * FROM view_popup_retur WHERE nomerTrans LIKE ");
            pop.Show();
        }

        public void next()
        {
            var model = _pres.Next();
            if (model != null)
            {
                txtBarcode.Text = model.Barcode;
                txtHarga.Text = model.Harga;
                txtNama.Text = model.Nama;
                txtNomer.Text = model.NomerTrans;
                txtQuantity.Text = model.Qty;
                txtMax.Text = model.Satuan;
                txtTotal.Text = model.Total;
            }
            ChkStatus(model.Status);
        }

        public void prev()
        {
            var model = _pres.Prev();
            if (model != null)
            {
                txtBarcode.Text = model.Barcode;
                txtHarga.Text = model.Harga;
                txtNomer.Text = model.NomerTrans;
                txtQuantity.Text = model.Qty;
                txtMax.Text = model.Satuan;
                txtNama.Text = model.Nama;
                txtTotal.Text = model.Total;
            ChkStatus(model.Status);
            }
        }

        public void print()
        {
            _pres.printData();
        }

        public void top()
        {
            var model = _pres.Top();
            if (model != null)
            {
                txtBarcode.Text = model.Barcode;
                txtHarga.Text = model.Harga;
                txtNomer.Text = model.NomerTrans;
                txtQuantity.Text = model.Qty;
                txtMax.Text = model.Satuan;
                txtNama.Text = model.Nama;
                txtTotal.Text = model.Total;
            }
            ChkStatus(model.Status);
        }

        //Reciever Interface
        public void GetPopUpData(BarangsModel md)
        {
            txtNomer.Text = md.Nama;
            var model = _pres.tampilData();
            if (model != null)
            {
                txtBarcode.Text = model.Barcode;
                txtHarga.Text = model.Harga;
                txtNomer.Text = model.NomerTrans;
                txtQuantity.Text = model.Qty;
                txtMax.Text = model.Satuan;
                txtNama.Text = model.Nama;
                txtTotal.Text = model.Total;
            }
            ChkStatus(model.Status);
        }

        //Constructor
        public Retur(userDataModel user)
        {
            InitializeComponent();
            CenterToScreen();
            _pres = new ReturPresenter(this);
            tanggal.Value = DateTime.Now;
            _user = user;
            Bot();
        }

        //Event Handler
        public void RaiseKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNomer.Focused == true)
                {
                    var model = _pres.takeList();
                    if (model.Count != 0)
                    {   
                        cboBarcode.Items.Clear();
                        this.Cursor = Cursors.WaitCursor;
                        foreach (var item in model)
                        {
                            cboBarcode.Items.Add($"{item.Nama}");
                        }
                        toggleEnabled();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        //Local Methods
        public void ChkStatus(string status)
        {
            if (status == "posted")
            {
                chkPosted.Checked = true;
                chkVoid.Checked = false;
            }
            else
            {
                chkVoid.Checked = true;
                chkPosted.Checked = false;
            }
        }

        public void ClearAll()
        {
            txtNomer.Clear();
            txtNama.Clear();
            txtBarcode.Clear();
            txtHarga.Clear();
            txtQuantity.Clear();
            txtMax.Clear();
            txtTotal.Clear();
            cboBarcode.Items.Clear();
        }

        public void toggleEnabled()
        {
            if (txtBarcode.Enabled == false)
            {
                txtNomer.Enabled = true;
                txtBarcode.Enabled = true;
                txtHarga.Enabled = true;
                txtNama.Enabled = true;
                txtQuantity.Enabled = true;
                txtMax.Enabled = true;
                txtTotal.Enabled = true;
                btnMasukan.Visible = true;
                btnBatal.Visible = true;
                cboBarcode.Enabled = true;
            }
            else
            {
                txtNomer.Enabled = false;
                txtBarcode.Enabled = false;
                txtHarga.Enabled = false;
                txtNama.Enabled = false;
                txtQuantity.Enabled = false;
                txtMax.Enabled = false;
                txtTotal.Enabled = false;
                btnMasukan.Visible = false;
                btnBatal.Visible = false;
                cboBarcode.Enabled = false;
            }
        }

        private void cboBarcode_Click(object sender, EventArgs e)
        {
            cboBarcode.Location = new Point(115,69);
            cboBarcode.Size = new Size(310, 35);
        }

        private void cboBarcode_Leave(object sender, EventArgs e)
        {
            cboBarcode.Size = new Size(75, 35);
            cboBarcode.Location = new Point(371, 69);
        }

        private void cboBarcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            NamaItem = cboBarcode.Text;
            var model = _pres.takeDetailBarang();
            if (model != null)
            {
                txtBarcode.Text = model.Barcode;
                txtNama.Text = model.Nama;
                txtHarga.Text = model.Harga;
                txtMax.Text = model.Qty;
            }
            cboBarcode.Size = new Size(75, 35);
            cboBarcode.Location = new Point(371, 69);
        }

        private void btnMasukan_Click(object sender, EventArgs e)
        {
            if (_pres.simpanRetur() == true)
            {
                op.insertHistoriUser(_user, this.Text, "Retur Barang");
                ClearAll();
                toggleEnabled();
                Bot();
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            int harga = 0;
            int qty = 0;
            int total = 0;
            if (txtHarga.Text =="" || txtQuantity.Text =="" || txtMax.Text == "")
            {

            }
            else
            {
                harga = Convert.ToInt32(txtHarga.Text);
                qty = Convert.ToInt32(txtQuantity.Text);
                total = harga * qty;
                txtTotal.Text = total.ToString();
            }
        }

        public void NumericOnly(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        
    }
}

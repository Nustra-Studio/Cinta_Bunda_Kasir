using Microsoft.Reporting.WinForms;
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
using KasirApp.Report;

namespace KasirApp.GUI
{
    public partial class Pembayaran : Form
    {
        iTransaksi _trn;
        iPopUpRecieve _rec;
        userDataModel _model;
        TransaksiModel _trans;
        RootMember _mem;
        Operator op = new Operator();
        int diskonmember;
        int kembali;
        int diskon;
        int cash;
        int grandtotal;

        public Pembayaran(iTransaksi trans, userDataModel model, iPopUpRecieve rec, TransaksiModel mod, RootMember rootmem)
        {
            InitializeComponent();
            CenterToParent();
            _trn = trans;
            _rec = rec;
            _model = model;
            _trans = mod;
            _mem = rootmem;
            diskonmember = 0;
            txtSubtotal.Text = $"Rp.{string.Format("{0:0,0}", Convert.ToInt32(_trans.Total))}";
            if (_trans.State == "checked" && rootmem.poin.poin != null && rootmem.poin.poin != "")
            {
                diskonmember = Convert.ToInt32(_mem.poin.poin) * Convert.ToInt32(op.CabangConfig().Valuepoint);
                DicMember.Text = $"Rp.{string.Format("0:0,0", diskonmember)}";//Jumlah Point
            }
        }
        public void FokusControler()
        {
            txtBayarCash.Focus();
        }

        public void ThousandSep()
        {
            if (txtBayarCash.Text != "" && txtBayarCash.TextLength > 3)
            {
                txtBayarCash.Text = string.Format("{0:0,0}", Convert.ToInt32(txtBayarCash.Text));
            }
            else if (txtDiscount.Text != "" && txtDiscount.TextLength > 3)
            {
                txtDiscount.Text = string.Format("{0:0,0}", Convert.ToInt32(txtDiscount.Text));
            }
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            var model = new PembayaranModel();
            model.NomorPJ = _trans.NomorPJ;
            model.Subtotal = _trans.Total;
            model.Diskontotal = diskon.ToString();
            model.Diskonmember = diskonmember.ToString();
            model.Totalbiaya = grandtotal.ToString();
            model.Bayar = txtBayarCash.Text;
            model.Kembali = kembali.ToString();
            model.Status = _trans.State;

            _trn.tampilKembali(kembali);

            var _pres = new TransaksiPresenter(_trn, _model, _rec, _mem);

            if (Convert.ToInt32(kembali) < 0)
            {
                MessageBox.Show("Uang tidak cukup", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _pres.PrintStruk(model, _mem, _model);

                _pres.insertApi(Convert.ToInt32(_trans.Total));

                _trn.FinishPayments();

                op.insertHistoriUser(_model, this.Text, "Pembayaran Transaksi");
                this.Hide();
            }
        }

        private void Numeric(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        public void UpdateDataTextChanged(object sender, EventArgs e)
        {
            if (txtBayarCash.Text == "")
            {
                return;
            }
            else if (txtDiscount.Text == "")
            {
                diskon = 0;
            }
            else if (DicMember.Text == "")
            {
                diskonmember = 0;
            }
            
            if (txtDiscount.Text != "")
            {
                diskon = Convert.ToInt32(txtDiscount.Text);
            }

            //Bayar
            cash = Convert.ToInt32(txtBayarCash.Text);
            grandtotal = (Convert.ToInt32(_trans.Total) - diskon - diskonmember);
            kembali = cash - grandtotal;
            txtKembali.Text = $"Rp.{string.Format("{0:0,0}", kembali)}";
            _trn.hitungTotal(diskon.ToString());
        }

        private void txtBayarCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBayar_Click(sender, e);
            }

            else if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }
    }
}

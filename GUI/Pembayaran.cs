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
        int kembali;
        int totaldiskon;

        public Pembayaran(iTransaksi trans, userDataModel model, iPopUpRecieve rec, TransaksiModel mod)
        {
            InitializeComponent();
            CenterToParent();
            _trn = trans;
            _rec = rec;
            _model = model;
            _trans = mod;
            totaldiskon = 0; 
            if (_trans.State == "checked")
            {
                totaldiskon = Convert.ToInt32(_trans.Harga) * 500;
                DicMember.Text = $"Rp.{totaldiskon}";//Jumlah Point
            }
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            var model = new TransaksiModel();
            model.NomorPJ = _trans.NomorPJ;
            model.Total = _trans.Total;//Subtotal
            model.Harga = kembali.ToString();//Kembali Di Harga
            model.Harga_jual = txtBayarCash.Text;//Bayar di hpp

            _trn.tampilKembali(kembali);

            PrintReport form = new PrintReport(model);

            var _pres = new TransaksiPresenter(_trn, _model, _rec);
            _pres.insertApi(Convert.ToInt32(_trans.Total));
           
            this.Hide();
        }

        private void Numeric(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtBayarCash_TextChanged(object sender, EventArgs e)
        {
            if (txtBayarCash.Text == string.Empty)
            {
                return;
            }
            else
            {
                int cash = Convert.ToInt32(txtBayarCash.Text);
                kembali = cash - Convert.ToInt32(_trans.Total);
                txtKembali.Text = $"Rp.{kembali.ToString()}";
            }
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

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "")
            {
                _trn.hitungTotal("0");
            }
            else
            {
                _trn.hitungTotal(txtDiscount.Text);
            }
        }
    }
}

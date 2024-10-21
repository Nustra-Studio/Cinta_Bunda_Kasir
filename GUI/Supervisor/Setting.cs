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
using KasirApp.Repository;
using KasirApp.Model;

namespace KasirApp.GUI.Supervisor
{
    public partial class Setting : Form, iSetting
    {
        MasterForm _master;

        public Setting(MasterForm master)
        {
            InitializeComponent();
            var _repo = new SettingRepo(this);
            _repo.Set();
            _master = master;
        }

        public void SetValue(SettingModel model)
        {
            txtKaryawan.Text = model.Karyawan;
            txtReseller.Text = model.Reseller; 
            AutoDiskon.Text = model.Autodiskon;
            txtStok.Text = model.StokMinimum;
            txtNama.Text = model.Nama;
            txtAlamat.Text = model.Alamat;
            txtTelp.Text = model.Telp;
            txtBaris1.Text = model.Baris1;
            txtBaris2.Text = model.Baris2;
            txtHeader.Text = model.Header;
            txtValuePoint.Text = model.Valuepoint;
            txtMinimal.Text = model.Minimalcash;
            txtACCkaryawan.Text = model.Karyawanacc;
            txtACCReseller.Text = model.Reselleracc;
            txtBackup.Text = model.Backup;
            txtJeda.Text = model.Jeda;
        }

        public void Numeric(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            var model = new SettingModel();
            model.Karyawan = txtKaryawan.Text;
            model.Reseller = txtReseller.Text;
            model.Autodiskon = AutoDiskon.Text;
            model.StokMinimum = txtStok.Text;
            model.Nama = txtNama.Text;
            model.Alamat = txtAlamat.Text;
            model.Telp = txtTelp.Text;
            model.Baris1 = txtBaris1.Text;
            model.Baris2 = txtBaris2.Text;
            model.Header = txtHeader.Text;
            model.Valuepoint = txtValuePoint.Text;
            model.Minimalcash = txtMinimal.Text;
            model.Karyawanacc = txtACCkaryawan.Text;
            model.Reselleracc = txtACCReseller.Text;
            model.Backup = txtBackup.Text;
            model.Jeda = txtJeda.Text;

            var _repo = new SettingRepo(this);
            _repo.UpdateSetting(model);
            
        }

        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            _master.CloseForm();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            _master.CloseForm();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.Description = "Pilih Folder";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtBackup.Text = fbd.SelectedPath;
            }
        }
    }
}

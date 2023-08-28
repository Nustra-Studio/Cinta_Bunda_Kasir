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
        

        public Setting()
        {
            InitializeComponent();
            var _repo = new SettingRepo(this);
            _repo.Set();
        }

        public void SetValue(SettingModel model)
        {
            txtKaryawan.Text = model.Karyawan;
            txtReseller.Text = model.Reseller;
            AutoDiskon.Text = model.Autodiskon;
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

            var _repo = new SettingRepo(this);
            _repo.UpdateSetting(model);
            
        }
    }
}

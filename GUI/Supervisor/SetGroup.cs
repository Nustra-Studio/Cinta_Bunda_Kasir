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
using KasirApp.Model;
using KasirApp.Presenter;

namespace KasirApp.GUI.Supervisor
{
    public partial class SetGroup : Form,iGroup, iParentDock,iPopUpRecieve
    {
        GroupPresenter _pres;
        MasterForm _master;
        string state;
        public string kode { get => txtKode.Text; set => txtKode.Text = value; }
        public string nama { get => txtNama.Text; set => txtNama.Text = value; }
        public bool master { get => chkMaster.Checked; set => chkMaster.Checked = value; }
        public bool gudang { get => chkGudang.Checked; set => chkGudang.Checked = value; }
        public bool supervisor { get => chkSupervisor.Checked; set => chkSupervisor.Checked = value; }
        public bool penjualan { get => chkPenjualan.Checked; set => chkPenjualan.Checked = value; }

        public void GetPopUpData(BarangsModel model)
        {
            seeCheck(_pres.popupData(model.Nama));
        }

        public void top()
        {
            seeCheck(_pres.top());
            disableState();
        }

        public void next()
        {
            seeCheck(_pres.next());
            disableState();
        }

        public void prev()
        {
            seeCheck(_pres.prev());
            disableState();
        }

        public void Bot()
        {
            seeCheck(_pres.Bot());
            disableState();
        }

        public void add()
        {
            if (chkGudang.Enabled == true)
            {
                MessageBox.Show("Keluar dari mode Edit/ADD terlebih dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                clearAll();
                toggleEnable();
                state = "add";
            }
        }

        public void delete()
        {
            if (chkGudang.Enabled == true)
            {
                MessageBox.Show("Keluar dari mode Edit/ADD terlebih dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (_pres.attemptDelete()==true)
            {
                Bot();
            }
        }

        public void edit()
        {
            if (chkGudang.Enabled == true)
            {
                MessageBox.Show("Keluar dari mode Edit/ADD terlebih dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                toggleEnable();
                state = "edit";
            }
        }

        public void list()
        {
            var pop = new PopUp(this);
            pop.Show();
            pop.getDataList($"SELECT nama as 'Nama', kode as 'Kode' FROM roles", "SELECT nama as 'Nama', kode as 'Kode' FROM roles where kode LIKE ");
        }

        public void print()
        {
            
        }

        public void exit()
        {
            
        }

        //Construcor
        public SetGroup(MasterForm master)
        {
            InitializeComponent();
            _master = master;
            _pres = new GroupPresenter(this);
            CenterToParent();
            toggleEnable();
            state = "none";
            Bot();
        }

        public void seeCheck(GroupModel model)
        {
            txtKode.Text = model.Kode;
            txtNama.Text = model.Nama;
            chkMaster.Checked = model.Masters;
            chkGudang.Checked = model.Gudang;
            chkPenjualan.Checked = model.Penjualan;
            chkSupervisor.Checked = model.Supervisor;
        }

        public void disableState()
        {
            txtKode.Enabled = false;
            txtNama.Enabled = false;
            chkMaster.Enabled = false;
            chkGudang.Enabled = false;
            chkPenjualan.Enabled = false;
            chkSupervisor.Enabled = false;
            label3.Visible = false;
        }


        public void toggleEnable()
        {
            if (txtKode.Enabled == false)
            {
                txtKode.Enabled = true;
                txtNama.Enabled = true;
                chkMaster.Enabled = true;
                chkGudang.Enabled = true;
                chkPenjualan.Enabled = true;
                chkSupervisor.Enabled = true;
                label3.Visible = true;
            }
            else
            {
                txtKode.Enabled = false;
                txtNama.Enabled = false;
                chkMaster.Enabled = false;
                chkGudang.Enabled = false;
                chkPenjualan.Enabled = false;
                chkSupervisor.Enabled = false;
                label3.Visible = false;
            }
        }

        public void clearAll()
        {
            txtKode.Text = "";
            txtNama.Text = "";
            txtKode.Enabled = false;
            txtNama.Enabled = false;
            chkMaster.Checked = false;
            chkGudang.Checked = false;
            chkPenjualan.Checked = false;
            chkSupervisor.Checked = false;
        }

        public void RaiseKeydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (state == "edit")
                {
                    if (_pres.attemptEdit() == true)
                    {
                        toggleEnable();
                        Bot();
                    }
                }
                else if (state == "add")
                {
                    if (_pres.attemptAdd() == true)
                    {
                        toggleEnable();
                        Bot();
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void SetGroup_FormClosing(object sender, FormClosingEventArgs e)
        {
            _master.CloseForm();
        }
    }
}

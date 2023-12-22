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

namespace KasirApp.GUI.Supervisor
{
    public partial class MasterUser : Form,iParentDock,iUser,iPopUpRecieve
    {
        MasterUserPresenter _pres;
        userDataModel _userdata;
        public string login { get => txtLogin.Text; set => txtLogin.Text = value; }
        public string nama { get => txtNama.Text; set => txtNama.Text = value;  }
        public string group { get => cboGroup.Text; set => cboGroup.Text = value; }
        public string password { get => txtPassword.Text; set => txtPassword.Text = value; }

        string status;
        
        //Constructor
        public MasterUser(userDataModel user)
        {
            InitializeComponent();
            CenterToParent();
            _userdata = user;
            _pres = new MasterUserPresenter(this, _userdata);
            closedState();
            populate();
            Bot();
        }

        public void add()
        {
            clear();
            openState();
            status = "add";
        }

        public void Bot()
        {
            ShowData(_pres.Bottom());
        }

        public void delete()
        {
            if (_pres.DeleteUser()==true)
            {
                Bot();
            }
        }

        public void exit()
        {
            return;
        }

        public void list()
        {
            var pop = new PopUp(this);
            pop.getDataList("SELECT * FROM view_user", "SELECT * FROM view_user WHERE username LIKE ");
            pop.Show();
        }

        public void next()
        {
            ShowData(_pres.Next());
        }

        public void prev()
        {
            ShowData(_pres.Prev());
        }

        public void print()
        {
            return;

        }

        public void edit()
        {
            openState();
            status = "edit";
        }

        public void top()
        {
            ShowData(_pres.Top());
        }

        public void GetPopUpData(BarangsModel model)
        {
            ShowData(_pres.tampilList(model.Nama));
        }

        public void clear()
        {
            txtNama.Text = "";
            txtLogin.Text = "";
            cboGroup.Text = "";
        }

        public void closedState()
        {
            lblPW.Visible = false;
            txtNama.Enabled = false;
            txtLogin.Enabled = false;
            txtPassword.Visible = false;
            cboGroup.Enabled = false;
            btnSimpan.Visible = false;
            btnBatal.Visible = false;
        }

        public void openState()
        {
            lblPW.Visible = true;
            txtNama.Enabled = true;
            txtLogin.Enabled = true;
            cboGroup.Enabled = true;
            txtPassword.Visible = true;
            btnSimpan.Visible = true;
            btnBatal.Visible = true;
        }

        public void ShowData(userDataModel user)
        {
            var model = user;
            txtLogin.Text = model.username;
            txtNama.Text = model.api_key;
            cboGroup.Text = model.role;
            closedState();
        }

        public void populate()
        {
            cboGroup.Items.Clear();
            foreach (var item in _pres.fillCombo())
            {
                cboGroup.Items.Add(item);
            }
        }

        public void NumericOnly(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        public void RaiseButton(object sender, EventArgs e)
        {
            if (btnSimpan.Focused == true)
            {
                if (status == "add")
                {
                    if (_pres.addnew() == true)
                    {
                        clear();
                        closedState();
                        Bot();
                    }
                    else
                    {
                        return;
                    }
                }
                else if (status == "edit")
                {
                    if (_pres.editUser() == true)
                    {
                        clear();
                        Bot();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                closedState();
                Bot();
            }
        }

       
    }
}

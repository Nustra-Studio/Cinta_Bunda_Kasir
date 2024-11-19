using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using KasirApp.GUI;
using KasirApp.Model;
using KasirApp.View;
using KasirApp.Presenter;
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using System.Net.NetworkInformation;
using KasirApp.GUI.SuperAdmin;

namespace KasirApp
{
    public partial class Login : Form, iLogin
    {
        public string Username { get { return txtUser.Text; } set { txtUser.Text = value; } }
        public string Password { get { return txtPass.Text; } set { txtPass.Text = value; } }

        public string token { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void hideForm()
        {
            this.Hide();
        }
        public iMasterForm _frm;
        
        public Login(iMasterForm frm)
        {
            InitializeComponent();
            CenterToParent();
            _frm = frm;
            //developementMode();
        }

        public void developementMode()
        {
            txtUser.Text = "supervisor_CB_Ngunut";
            txtPass.Text = "cintabunda123";
        }

        public void showMenu()
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if(txtUser.Text == "user-Superadmin" && txtPass.Text == "$SuperAdmin#321")
            {
                var frm = new SettingKoneksi();
                frm.Show();
            }
            else
            {
                LoginPresenter lp = new LoginPresenter(this, _frm);
                lp.AttemptLogin();
            }
            this.Cursor = Cursors.Default;
        }
    }
}
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

        public Login()
        {
            InitializeComponent();
            CenterToParent();
        }

        public void showMenu()
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            LoginPresenter lp = new LoginPresenter(this);
            lp.AttemptLogin();
        }
    }
}
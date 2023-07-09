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
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using System.Net.NetworkInformation;

namespace KasirApp
{
    public partial class Login : Form,iLogin    
    {
        Koneksi1 con = new Koneksi1();
        string user, pass;
        MasterForm br = new MasterForm();

        public string Username { get { return txtUser.Text; } set { txtUser.Text = value; } }
        public string Password { get { return txtUser.Text; } set { txtUser.Text = value; } }
        public Login()
        {
            InitializeComponent();
            CenterToScreen();
        }

        public bool isNull()
        {
            if (txtUser.Text == string.Empty || txtPass.Text == string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool cekKoneksi()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }


        private void gunaButton1_Click(object sender, EventArgs e)
        {
            user = txtUser.Text;
            pass = txtPass.Text;
            if (isNull()==true)
            {
                MessageBox.Show("Tolong Lengkapi User dan Password", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cekKoneksi()==false)
            {
                MessageBox.Show("Tidak Ada internet", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using (var url = new RestClient(con.url))
                {
                    var request = new RestRequest("login");
                    request.AddParameter("username", user);
                    request.AddParameter("password", pass);

                    RestResponse res = new RestResponse();
                    try
                    {
                        res = url.Post(request);
                        
                        if (res.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var jso = res.Content.ToString();
                            Root fn = JsonConvert.DeserializeObject<Root>(jso);
                            MessageBox.Show("Login BerHasil", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            br.Show();
                            br.RoleSellect(fn.user.role.ToString());
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Password Atau Username Salah",Convert.ToString(res.ErrorMessage));
                    }

                }
            }

        }
    }

        public class Root
        {
            public User user { get; set; }
            public string token { get; set; }
        }

        public class User
        {
            public int id { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string uuid { get; set; }
            public string role { get; set; }
            public string cabang_id { get; set; }
            public string api_key { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }
    }


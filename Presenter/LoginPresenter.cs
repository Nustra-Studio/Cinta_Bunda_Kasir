using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using RestSharp;
using Newtonsoft.Json;
using KasirApp.Model;
using KasirApp.View;
using KasirApp.GUI;

namespace KasirApp.Presenter
{
    class LoginPresenter : iRole
    {
        MboxOperator mb = new MboxOperator();
        Operator op = new Operator();
        iLogin _login;
        iMasterForm _iform;

        //Interface Variable API
        string _role;
        string _token;
        //local db 
        int _id;
        string _uuid;
        string _kode;
        string _nama;
        private int _masters;
        private int _gudang;
        private int _penjualan;
        private int _kasbank;
        private int _akuntansi;
        private int _supervisor;

        //Interface API
        public string Role { get { return _role; } set { _role = value; } }
        public string Token { get { return _token; } set { _token = value; } }
        //LOCAL DB
        public int id { get => _id; set => _id = value; }
        public string uuid { get => _uuid; set => _uuid = value; }
        public string Kode { get => _kode; set => _kode = value; }
        public string nama { get => _nama; set => _nama = value; }
        public int masters { get => _masters; set => _masters = value; }
        public int gudang { get => _gudang; set => _gudang = value; }
        public int penjualan { get => _penjualan; set => _penjualan = value; }
        public int kasbank { get => _kasbank; set => _kasbank = value; }
        public int akuntansi { get => _akuntansi; set => _akuntansi = value; }
        public int supervisor { get => _supervisor; set => _supervisor = value; }

        public LoginPresenter(iLogin lg, iMasterForm frm1)
        {
            _login = lg;
            _iform = frm1;
        }

        public bool isNull()
        {
            if (_login.Username == "" || _login.Password == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CekNetwork()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 5;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AttemptLogin()
        {
            if (CekNetwork() == false)
            {
                mb.PeringatanOK("Tidak Ada Koneksi Internet");
            }
            else if (isNull() == false)
            {
                mb.PeringatanOK("Masukan Username dan Password yang lengkap");
            }
            else
            {
                using (var url = new RestClient(op.url))
                {
                    var request = new RestRequest("login", Method.Post);
                    request.AddParameter("username", _login.Username);
                    request.AddParameter("password", _login.Password);
                    RestResponse res = url.Execute(request);
                    try
                    {
                        if (res.StatusCode == HttpStatusCode.OK)
                        {
                            var jso = res.Content.ToString();
                            Root fn = JsonConvert.DeserializeObject<Root>(jso);

                            mb.InformasiOK("Login sebagai : " + fn.user.role.ToString() + " Berhasil");

                            _login.hideForm();
                            _role = fn.user.role.ToString();
                            _token = fn.token.ToString();

                            var usercl = new userDataModel();
                            usercl.token = _token;
                            usercl.username = fn.user.username.ToString();
                            usercl.role = _role;

                            using (MySqlCommand cmd = new MySqlCommand("select * from roles where nama = @nama", op.Conn))
                            {
                                cmd.Parameters.AddWithValue("@nama", _role);
                                op.KonekDB();
                                using (MySqlDataReader rd = cmd.ExecuteReader())
                                {
                                    while (rd.Read())
                                    {
                                        usrRole user = new usrRole()
                                        {
                                            Id = Convert.ToInt32(rd["id"]),
                                            Uuid = rd["uuid"].ToString(),
                                            Kode1 = rd["kode"].ToString(),
                                            Nama = rd["nama"].ToString(),
                                            Masters = Convert.ToInt32(rd["masters"].ToString()),
                                            Gudang = Convert.ToInt32(rd["Gudang"].ToString()),
                                            Penjualan = Convert.ToInt32(rd["Penjualan"].ToString()),
                                            Kasbank = Convert.ToInt32(rd["KasBank"].ToString()),
                                            Akuntansi = Convert.ToInt32(rd["Akuntansi"].ToString()),
                                            Supervisor = Convert.ToInt32(rd["Supervisor"].ToString()),
                                            Token = _token
                                        };
                                        _iform.Role(user, usercl);
                                    }
                                }
                            }
                        }
                        else if (res.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            var jso = res.Content.ToString();
                            error fn = JsonConvert.DeserializeObject<error>(jso);
                            mb.PeringatanOK(fn.message.ToString());
                        }
                    }
                    catch (Exception)
                    {
                        //mb.PeringatanOK(ex.Message);
                        throw;
                    }
                }
            }
        }
    }
}

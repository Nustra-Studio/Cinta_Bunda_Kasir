﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
        Koneksi1 con = new Koneksi1();

        iLogin _login;
        string _role;
        string _token;

        public string Role { get { return _role; } set { _role = value; } }
        public string Token { get { return _token; } set { _token = value; } }

        public LoginPresenter(iLogin log)
        {
            _login = log;
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

        public string AttemptLogin()
        {
            string token = "";
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
                using (var url = new RestClient(con.url))
                {
                    var request = new RestRequest("login", Method.Post);
                    request.AddParameter("username", _login.Username);
                    request.AddParameter("password", _login.Password);
                    RestResponse res = url.Execute(request);
                    try
                    {
                        if (res.StatusCode == HttpStatusCode.OK)
                        {
                            MasterForm mf = new MasterForm();
                            var jso = res.Content.ToString();
                            Root fn = JsonConvert.DeserializeObject<Root>(jso);

                            mb.InformasiOK("Login sebagai : " + fn.user.role.ToString() + " Berhasil");
                            token = fn.token.ToString();

                            _login.hideForm();
                            _role = fn.user.role.ToString();
                            _token = fn.token.ToString();
                        }
                        else if (res.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            var jso = res.Content.ToString();
                            Root1 fn = JsonConvert.DeserializeObject<Root1>(jso);
                            mb.PeringatanOK(fn.message.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        mb.PeringatanOK(ex.Message);

                    }
                }
            }
            return token;
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

        public class Root1
        {
            public string message { get; set; }
        }
    }
}

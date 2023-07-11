using System;
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
    class LoginPresenter 
    {
        MboxOperator mb = new MboxOperator();
        Koneksi1 con = new Koneksi1();

        iLogin _login;

        public LoginPresenter(iLogin log)
        {
            _login = log;
        }

        public bool cekStatus(HttpStatusCode code)
        {
            int status = (int)code;
            return status >= 200 && status <= 250;
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

                            mb.InformasiOK("Login BerHasil");
                            _login.hideForm();
                            mf.RoleSellect(fn.user.role);
                            mf.Show();
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
        }

        public void hideForm()
        {
            throw new NotImplementedException();
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

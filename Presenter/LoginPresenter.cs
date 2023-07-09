using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Model;
using KasirApp.View;

namespace KasirApp.Presenter
{
    class LoginPresenter
    {
        iLogin _login;

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
            if (isNull() == false)
            {

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    public class MemberModel
    {
        private string token;

        private string nama;
        private string email;
        private string password;
        private string alamat;
        private string phone;

        public string Nama { get => nama; set => nama = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public string Phone { get => phone; set => phone = value; }

        public string Token { get => token; set => token = value; }
    }
}

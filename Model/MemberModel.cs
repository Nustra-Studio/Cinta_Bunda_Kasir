using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    //Local
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

    //API MODEL
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Member
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string kode_akses { get; set; }
        public string alamat { get; set; }
        public string status { get; set; }
        public string random_kode { get; set; }
        public string expait_kode { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class Poin
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string id_member { get; set; }
        public string poin { get; set; }
        public string status { get; set; }
        public object expaid { get; set; }
        public object created_at { get; set; }
        public object updated_at { get; set; }
    }

    public class RootMember
    {
        public Member member { get; set; }
        public Poin poin { get; set; }
    }


}

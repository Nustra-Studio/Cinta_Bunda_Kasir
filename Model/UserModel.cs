using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    //FIELDS
    public class Root
    {
        public User user { get; set; }
        public string token { get; set; }
    }

    public class User
    {
        public int id {
            get;
            set;
        }
        public string username {
            get;
            set;
        }
        public string password {
            get;
            set;
        }
        public string uuid {
            get;
            set;
        }
        public string role {
            get;
            set;
        }
        public string cabang_id {
            get;
            set; 
        }
        public string api_key {
            get; set; 
        }
        public DateTime created_at {
            get; set; 
        }
        public DateTime updated_at {
            get; set;
        }
    }

    public class userDataModel 
    {
        public string token { get; set; }
        public int id
        {
            get;
            set;
        }
        public string username
        {
            get;
            set;
        }
        public string password
        {
            get;
            set;
        }
        public string uuid
        {
            get;
            set;
        }
        public string role
        {
            get;
            set;
        }
        public string cabang_id
        {
            get;
            set;
        }
        public string api_key
        {
            get; set;
        }
        public DateTime created_at
        {
            get; set;
        }
        public DateTime updated_at
        {
            get; set;
        }
    }


    public class usrRole
    {
        private int id;
        private string uuid;
        private string Kode;
        private string nama;
        private string token;
        private int masters;
        private int gudang;
        private int penjualan;
        private int kasbank;
        private int akuntansi;
        private int supervisor;

        //Properties
        public int Id { get { return id; } set { id = value; } }
        public string Uuid { get => uuid; set => uuid = value; }
        public string Kode1 { get => Kode; set => Kode = value; }
        public string Nama { get => nama; set => nama = value; }
        public int Masters { get => masters; set => masters = value; }
        public int Gudang { get => gudang; set => gudang = value; }
        public int Penjualan { get => penjualan; set => penjualan = value; }
        public int Kasbank { get => kasbank; set => kasbank = value; }
        public int Akuntansi { get => akuntansi; set => akuntansi = value; }
        public int Supervisor { get => supervisor; set => supervisor = value; }
        public string Token { get => token; set => token = value; }
    }
}

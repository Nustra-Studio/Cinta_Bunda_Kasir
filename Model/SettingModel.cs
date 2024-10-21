using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KasirApp.Model
{
    public class SettingModel
    {
        string karyawan;
        string reseller;
        string karyawanacc;
        string reselleracc;
        string autodiskon;
        string stokMinimum;
        string nama;
        string alamat;
        string telp;
        string baris1;
        string baris2;
        string baris3;
        string header;
        string valuepoint;
        string minimalcash;
        string backup;
        string server;
        string database;
        string port;
        string user;
        string password;
        string endpoint;
        string cabang;
        string jeda;

        public string Karyawan { get => karyawan; set => karyawan = value; }
        public string Reseller { get => reseller; set => reseller = value; }
        public string Autodiskon { get => autodiskon; set => autodiskon = value; }
        public string StokMinimum { get => stokMinimum; set => stokMinimum = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public string Telp { get => telp; set => telp = value; }
        public string Baris1 { get => baris1; set => baris1 = value; }
        public string Baris2 { get => baris2; set => baris2 = value; }
        public string Baris3 { get => baris3; set => baris3 = value; }
        public string Header { get => header; set => header = value; }
        public string Valuepoint { get => valuepoint; set => valuepoint = value; }
        public string Minimalcash { get => minimalcash; set => minimalcash = value; }
        public string Karyawanacc { get => karyawanacc; set => karyawanacc = value; }
        public string Reselleracc { get => reselleracc; set => reselleracc = value; }
        public string Backup { get => backup; set => backup = value; }

        [JsonPropertyName("server")]
        public string Server { get => server; set => server = value; }
        [JsonPropertyName("database")]
        public string Database { get => database; set => database = value; }
        [JsonPropertyName("port")]
        public string Port { get => port; set => port = value; }
        [JsonPropertyName("user")]
        public string User { get => user; set => user = value; }
        [JsonPropertyName("password")]
        public string Password { get => password; set => password = value; }
        [JsonPropertyName("endpoint")]
        public string Endpoint { get => endpoint; set => endpoint = value; }
        public string Cabang { get => cabang; set => cabang = value; }
        public string Jeda { get => jeda; set => jeda = value; }
    }
}

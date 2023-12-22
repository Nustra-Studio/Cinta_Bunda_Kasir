using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    public class SettingCabangModel
    {
        string nama;
        string alamat;
        string telp;

        public string Nama { get => nama; set => nama = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public string Telp { get => telp; set => telp = value; }
    }
}

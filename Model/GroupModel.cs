using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    public class GroupModel
    {
        string kode;
        string nama;
        bool masters;
        bool gudang;
        bool penjualan;
        bool supervisor;

        public string Kode { get => kode; set => kode = value; }
        public string Nama { get => nama; set => nama = value; }
        public bool Masters { get => masters; set => masters = value; }
        public bool Gudang { get => gudang; set => gudang = value; }
        public bool Penjualan { get => penjualan; set => penjualan = value; }
        public bool Supervisor { get => supervisor; set => supervisor = value; }
    }
}

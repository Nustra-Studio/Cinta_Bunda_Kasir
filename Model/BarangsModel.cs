using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    public class BarangsModel
    {
        private string nama;
        private string kode;
        private string stok;
        private string harga;
        private string harga_jual;
        private string harga_pokok;
        private string harga_grosir;

        public string Nama { get => nama; set => nama = value; }
        public string Kode { get => kode; set => kode = value; }
        public string Stok { get => stok; set => stok = value; }
        public string Harga { get => harga; set => harga = value; }
        public string Harga_jual { get => harga_jual; set => harga_jual = value; }
        public string Harga_pokok { get => harga_pokok; set => harga_pokok = value; }
        public string Harga_grosir { get => harga_grosir; set => harga_grosir = value; }
    }
}

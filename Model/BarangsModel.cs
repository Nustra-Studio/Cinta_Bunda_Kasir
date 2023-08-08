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

        public string Nama { get => nama; set => nama = value; }
        public string Kode { get => kode; set => kode = value; }
        public string Stok { get => stok; set => stok = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    public class TransaksiModel
    {
        private string nomorPJ;
        private string nama;
        private string barkode;
        private string quantity;
        private string harga;
        private string harga_jual;
        private string harga_pokok;
        private string harga_grosir;
        private string tanggal;
        private string id_member;
        private string total;
        private string diskon;
        private string state;

        public string NomorPJ { get => nomorPJ; set => nomorPJ = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Barkode { get => barkode; set => barkode = value; }
        public string Quantity { get => quantity; set => quantity = value; }
        public string Harga { get => harga; set => harga = value; }
        public string Harga_jual { get => harga_jual; set => harga_jual = value; }
        public string Harga_pokok { get => harga_pokok; set => harga_pokok = value; }
        public string Harga_grosir { get => harga_grosir; set => harga_grosir = value; }
        public string Tanggal { get => tanggal; set => tanggal = value; }
        public string Id_member { get => id_member; set => id_member = value; }
        public string Total { get => total; set => total = value; }
        public string Diskon { get => diskon; set => diskon = value; }
        public string State { get => state; set => state = value; }
    }
}

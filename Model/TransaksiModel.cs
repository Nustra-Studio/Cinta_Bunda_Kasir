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
        private string uuid;
        private string idkategori;
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
        private string satuan;
        private string nodiskon;

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
        public string Idkategori { get => idkategori; set => idkategori = value; }
        public string Satuan { get => satuan; set => satuan = value; }
        public string Nodiskon { get => nodiskon; set => nodiskon = value; }
        public string Uuid { get => uuid; set => uuid = value; }
    }
}

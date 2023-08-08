using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    public class OpnameModel
    {
        //Increment Fields
        private int numeringKwitansi;

        //Fields
        private string nomor;
        private string barcode;
        private string nama;
        private string stok;
        private string perubahan;
        private string selisih;
        private int posted;
        private string tanggal;

        public string Nomor { get => nomor; set => nomor = value; }
        public string Barcode { get => barcode; set => barcode = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Stok { get => stok; set => stok = value; }
        public string Perubahan { get => perubahan; set => perubahan = value; }
        public string Selisih { get => selisih; set => selisih = value; }
        public int Posted { get => posted; set => posted = value; }
        public string Tanggal { get => tanggal; set => tanggal = value; }
        public int NumeringKwitansi { get => numeringKwitansi; set => numeringKwitansi = value; }
    }
}

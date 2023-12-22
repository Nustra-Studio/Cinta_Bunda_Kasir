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
        private long numeringKwitansi;

        //Fields
        private string uuid;
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
        public long NumeringKwitansi { get => numeringKwitansi; set => numeringKwitansi = value; }
        public string Uuid { get => uuid; set => uuid = value; }
    }

    public class opnameAPI
    {
        public string barcode { get; set; }
        public string stock { get; set; }
        public string uuid { get; set; }
    }
}

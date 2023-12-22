using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    public class HistoriStokModel
    {
        string nama;
        string barcode;
        string nomerTrans;
        string tanggal;
        string masuk;
        string diskon;
        string harga_jual;
        string keluar;
        string saldo;
        string aktifitas;
        string state;
        string QtyChange;

        public string Nama { get => nama; set => nama = value; }
        public string NomerTrans { get => nomerTrans; set => nomerTrans = value; }
        public string Tanggal { get => tanggal; set => tanggal = value; }
        public string Masuk { get => masuk; set => masuk = value; }
        public string Keluar { get => keluar; set => keluar = value; }
        public string Saldo { get => saldo; set => saldo = value; }
        public string Aktifitas { get => aktifitas; set => aktifitas = value; }
        public string Diskon { get => diskon; set => diskon = value; }
        public string Harga_jual { get => harga_jual; set => harga_jual = value; }
        public string Barcode { get => barcode; set => barcode = value; }
        public string State { get => state; set => state = value; }
        public string QtyChange1 { get => QtyChange; set => QtyChange = value; }
    }
}

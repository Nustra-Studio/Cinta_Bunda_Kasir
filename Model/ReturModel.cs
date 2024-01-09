using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    class ReturModel
    {
        string nomerTrans;
        string idkategori;
        string nama;
        string barcode;
        string diskon;
        string qty;
        string harga;
        string total;
        string satuan;
        string status;
        string maxqty;

        public string NomerTrans { get => nomerTrans; set => nomerTrans = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Barcode { get => barcode; set => barcode = value; }
        public string Qty { get => qty; set => qty = value; }
        public string Harga { get => harga; set => harga = value; }
        public string Total { get => total; set => total = value; }
        public string Satuan { get => satuan; set => satuan = value; }
        public string Status { get => status; set => status = value; }
        public string Maxqty { get => maxqty; set => maxqty = value; }
        public string Idkategori { get => idkategori; set => idkategori = value; }
        public string Diskon { get => diskon; set => diskon = value; }
    }
}

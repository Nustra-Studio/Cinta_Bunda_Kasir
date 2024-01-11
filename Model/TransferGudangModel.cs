using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    public class TransferGudangModel
    {
        public int id { get; set; }
        public string nomerTrans { get; set; }
        public string uuid { get; set; }
        public string category_id { get; set; }
        public string id_supplier { get; set; }
        public string kode_barang { get; set; }
        public object harga { get; set; }
        public string harga_jual { get; set; }
        public object harga_pokok { get; set; }
        public object harga_grosir { get; set; }
        public int stok { get; set; }
        public string keterangan { get; set; }
        public string name { get; set; }
        public string merek_barang { get; set; }
        public object type_barang_id { get; set; }
        public object created_at { get; set; }
        public object updated_at { get; set; }
        public string status { get; set; }
    }

    public class TfGudangAPI
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string category_id { get; set; }
        public string id_supplier { get; set; }
        public string kode_barang { get; set; }
        public string harga { get; set; }
        public string harga_jual { get; set; }
        public string harga_pokok { get; set; }
        public string harga_grosir { get; set; }
        public string stok { get; set; }
        public string keterangan { get; set; }
        public string name { get; set; }
        public string merek_barang { get; set; }
        public string type_barang_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}

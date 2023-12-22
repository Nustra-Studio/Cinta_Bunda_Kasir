using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    public class SuplierModel
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string nama { get; set; }
        public string alamat { get; set; }
        public string telepon { get; set; }
        public string product { get; set; }
        public string keterangan { get; set; }
        public string category_barang_id { get; set; }
        public object created_at { get; set; }
        public object updated_at { get; set; }
    }
}

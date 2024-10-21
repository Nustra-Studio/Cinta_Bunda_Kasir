using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    public class PenyesuaianModel
    {
        public string keterangan { get; set; }
        public string nomerTrans { get; set; }
        public string barcode { get; set; }
        public string nama { get; set; }
        public string sat { get; set; }
        public string selisih { get; set; }
        public string stok { get; set; }
        public string stoknew { get; set; }
        public string harga_jual { get; set; }
        public int status { get; set; }
    }
}

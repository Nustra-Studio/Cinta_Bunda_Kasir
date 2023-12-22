using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{

    class listcabang
    {
        public List<CabangModel> listmodel { get; set; }
    }
    class CabangModel
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string nama { get; set; }
        public string kepala_cabang { get; set; }
        public string telepon { get; set; }
        public string alamat { get; set; }
        public string category_id { get; set; }
        public string keterangan { get; set; }
        public string database { get; set; }
        public object created_at { get; set; }
        public object updated_at { get; set; }
    }
}

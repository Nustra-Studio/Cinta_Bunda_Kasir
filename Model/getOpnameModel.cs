using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    public class getOpname
    {
        public string status {get; set;}
        public List<opnameAPIget> data { get; set; }
    }

    public class opnameAPIget
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string barcode { get; set; }
        public string stock { get; set; }
        public string perubahan { get; set; }
        public string id_toko { get; set; }
        public string status { get; set; }
        public object keterangan { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}

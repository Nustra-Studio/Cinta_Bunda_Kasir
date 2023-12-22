using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.Model
{
    class BatalPostModel
    {
        string nomerTrans;
        string alasan;

        public string NomerTrans { get => nomerTrans; set => nomerTrans = value; }
        public string Alasan { get => alasan; set => alasan = value; }
    }
}

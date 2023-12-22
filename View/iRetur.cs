using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.View
{
    public interface iRetur
    {
        string nomerTrans { get; set; }
        string nama { get; set; }
        string barcode { get; set; }
        string qtyreturn { get; set; }
        string harga { get; set; }
        string total { get; set; }
        string maxqty { get; set; }
    }
}

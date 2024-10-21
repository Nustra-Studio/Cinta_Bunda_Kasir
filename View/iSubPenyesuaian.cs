using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.View
{
    public interface iSubPenyesuaian
    {
        string nomerTrans { get; set; }
        string barcode { get; set; }
        string nama { get; set; }
        string stok { get; set; }
        string stoknew { get; set; }

    }
}

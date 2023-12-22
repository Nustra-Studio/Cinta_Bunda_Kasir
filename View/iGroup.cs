using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.View
{
    public interface iGroup
    {
        string kode { get; set; }
        string nama { get; set; }
        bool master { get; set; }
        bool gudang { get; set; }
        bool supervisor { get; set; }
        bool penjualan { get; set; }
    }
}

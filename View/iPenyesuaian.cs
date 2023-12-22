using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.View
{
    public interface iPenyesuaian
    {
        string nomerPAD { get; set; }
        string keterangan { get; set; }
        void RefreshDGV();
    }
}

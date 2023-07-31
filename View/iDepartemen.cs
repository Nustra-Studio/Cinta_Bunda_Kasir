using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.View
{
    interface iDepartemen
    {
        string kode { get; set; }
        string nama { get; set; }
        bool kenaDiskon { get; set; }
        void startState();
    }
}

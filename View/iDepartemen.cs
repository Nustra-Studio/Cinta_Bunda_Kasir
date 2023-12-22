using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Model;

namespace KasirApp.View
{
    interface iDepartemen
    {
        string kode { get; set; }
        string nama { get; set; }
        bool kenaDiskon { get; set; }
        bool grosir { get; set; }
        void startState();
        void clear();
        void showRd(DepartemenModel model);
    }
}

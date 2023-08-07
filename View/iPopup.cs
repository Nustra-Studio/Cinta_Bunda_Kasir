using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Model;

namespace KasirApp.View
{
    public interface iPopup
    {
        void DatagridShow(DataTable dt);
        void GetBarangs(BarangsModel md); 
    }
}

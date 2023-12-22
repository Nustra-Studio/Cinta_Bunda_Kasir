using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Model;

namespace KasirApp.View
{
    public interface iOpname
    {
        long numeringKwitansi { get; set; }
        string nomer { get; set; }
        string kode { get; set; }
        string nama { get; set; }
        string stok { get; set; }
        string perubahan { get; set; }
        string selection { get; set; }
        string search { get; set; }
        int selisih { get; set; }
        int posted { get; set; }
        string tanggal { get; set; }
        void takeNumber(OpnameModel model);
        void showTable(DataTable dt);
    }
}

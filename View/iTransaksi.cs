using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Model;

namespace KasirApp.View
{
    public interface iTransaksi
    {
        string randKode { get; set; }
        string barcode { get; set; }
        string nomorPJ { get; set; }
        string state { get; set; }
        string qty { get; set; }
        string selection { get; set; }
        string noHpMem { get; set; }
        string NamaMem { get; set; }
        string diskonTrans { get; set; }
        string stateDiskon { get; set; }

        void GetMember(RootMember rootmem);
        void GetDataBarangs(TransaksiModel md);
        void TampilGrid(DataTable dt);
        void clear();
        void ClearAll();
        int hitungTotal(string diskon);
        void tampilKembali(int kembali);
    }
}

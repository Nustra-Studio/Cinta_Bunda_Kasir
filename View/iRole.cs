using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasirApp.View
{
    public interface iRole
    {
        //from API
        string Role { get; set; }
        string Token { get; set; }
        //from local db roles
        int id { get; set; }
        string uuid { get; set; }
        string Kode { get; set; }
        string nama { get; set; }
        int masters { get; set; }
        int gudang { get; set; }
        int penjualan { get; set; }
        int kasbank { get; set; }
        int akuntansi { get; set; }
        int supervisor { get; set; }
    }
}

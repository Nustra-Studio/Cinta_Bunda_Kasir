using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using KasirApp.Model;

namespace KasirApp.Repository
{
    public class PrintRepo
    {
        Operator op = new Operator();

        public MySqlDataAdapter printStruk(TransaksiModel model)
        {
            MySqlDataAdapter da = null;
            using (var cmd = new MySqlCommand("Select * from histori_penjualan WHERE nomerTrans = '" + model.NomorPJ + "'", op.Conn))
            {
                using (var dap = new MySqlDataAdapter())
                {
                    dap.SelectCommand = cmd;
                    da = dap;
                }
            }
            return da;
        }

        public void LaporanBatal()
        {

        }

    }
}

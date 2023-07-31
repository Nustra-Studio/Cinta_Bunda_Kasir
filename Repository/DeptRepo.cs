using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Model;
using MySql.Data.MySqlClient;

namespace KasirApp.Repository
{
    public class DeptRepo
    {
        Operator op = new Operator();
        MboxOperator mb = new MboxOperator();
        public void Insert(DepartemenModel md)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("insert into departemen values(null,md5(@nama),@kode,@nama,@diskon)",op.Conn))
                {
                    cmd.Parameters.AddWithValue("@nama", md.Nama);
                    cmd.Parameters.AddWithValue("@kode", md.Kode);
                    cmd.Parameters.AddWithValue("@diskon", md.KenaDiskon);

                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                    mb.InformasiOK("Data Disimpan!");
                }
            }
            catch (Exception ex)
            {
                mb.InformasiOK(ex.Message.ToString());
            }
        }
    }
}

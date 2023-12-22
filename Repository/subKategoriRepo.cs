using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using KasirApp.Model;

namespace KasirApp.Repository
{
    class subKategoriRepo
    {
        Operator op = new Operator();
        MboxOperator mb = new MboxOperator();

        public subKategoriRepo()
        {

        }

        public bool cekData(string name)
        {
            using (var cmd = new MySqlCommand("Select * from category_barangs where name = @name", op.Conn))
            {
                cmd.Parameters.AddWithValue("@name", name);
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public void InsertData(string nama,string kode)
        {
            if (cekData(nama)==false)
            {
                mb.PeringatanOK("Data sudah ada");
            }
            else if (nama == "")
            {
                mb.PeringatanOK("Data tidak boleh kosong");
            }
            else
            {
                using (var cmd = new MySqlCommand("INSERT INTO category_barangs VALUES (null,MD5(RAND()),@nama,@kode,'0','0',@tanggal,@tanggal)", op.Conn))
                {
                    cmd.Parameters.AddWithValue("@nama", nama);
                    cmd.Parameters.AddWithValue("@kode", nama);
                    cmd.Parameters.AddWithValue("@tanggal", DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));

                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
            }
        }
    }
}

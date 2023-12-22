using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using KasirApp.Model;
using KasirApp.View;

namespace KasirApp.Repository
{
    class subSatuanRepo
    {
        Operator op = new Operator();
        MboxOperator mb = new MboxOperator();

        public bool cekData(string name)
        {
            using (var cmd = new MySqlCommand("Select * from satuan where name = @name", op.Conn))
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

        public void InsertData(string nama)
        {
            if (cekData(nama) == false)
            {
                mb.PeringatanOK("Data sudah ada");
            }
            else if (nama == "")
            {
                mb.PeringatanOK("Data tidak boleh kosong");
            }
            else
            {
                using (var cmd = new MySqlCommand("INSERT INTO satuan VALUES (null,MD5(RAND()),@nama,@tanggal,@tanggal)", op.Conn))
                {
                    cmd.Parameters.AddWithValue("@nama", nama);
                    cmd.Parameters.AddWithValue("@tanggal", DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));

                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
            }

        }
    }
}
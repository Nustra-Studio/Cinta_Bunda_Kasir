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
        //Fields
        Operator op = new Operator();
        MboxOperator mb = new MboxOperator();
        
        int order;
        int batas;

        //Declare Limit
        public int limit()
        {
            batas = 0;
            using (MySqlCommand cmd = new MySqlCommand("select count(*) from departemen",op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        batas = Convert.ToInt32(rd["COUNT(*)"].ToString());
                    }
                }
                op.KonekDB();
            }
            return batas;
        }

        //Method
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
                mb.PeringatanOK(ex.Message.ToString());
            }
        }

        public void Delete(DepartemenModel model)
        {
            try
            {
                if (mb.KonfimasiYesNo("Yakin menghapus?")==false)
                {
                    return;
                }
                else
                {
                    using (MySqlCommand cmd = new MySqlCommand("delete from departemen where kode=@kode",op.Conn))
                    {
                        cmd.Parameters.AddWithValue("@kode", model.Kode);
                        op.KonekDB();
                        cmd.ExecuteNonQuery();
                        op.KonekDB();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DepartemenModel topValue()
        {
            order = 0;
            var model = new DepartemenModel();
            using (MySqlCommand cmd = new MySqlCommand("select * from departemen limit @nomer,1", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomer", order);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        model.Kode = rd["kode"].ToString();
                        model.Nama = rd["nama"].ToString();
                        model.KenaDiskon = rd["kenadiskon"].Equals(true) ? true : false;
                    }
                }
            }
            return model;
        }

        public DepartemenModel nextValue()
        {
            var model = new DepartemenModel();
            if (order >= limit()-1)
            {
                order = limit() - 1;
            }
            else
            {
                order++;
            }
            using (MySqlCommand cmd = new MySqlCommand("select * from departemen limit @nomer,1", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomer", order);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        model.Kode = rd["kode"].ToString();
                        model.Nama = rd["nama"].ToString();
                        model.KenaDiskon = rd["kenadiskon"].Equals(true) ? true : false;
                    }
                }
            }
            return model;
        }

        public DepartemenModel botValue()
        {
            int _batas = limit() - 1;
            order = _batas;
            var model = new DepartemenModel();
            using (MySqlCommand cmd = new MySqlCommand("select * from departemen limit @nomer,1", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomer", _batas);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        model.Kode = rd["kode"].ToString();
                        model.Nama = rd["nama"].ToString();
                        model.KenaDiskon = rd["kenadiskon"].Equals(true) ? true : false;
                    }
                }
            }
            return model;
        }

        public DepartemenModel prevValue()
        {
            if (order <= 0)
            {
                order = 0;
            }
            else
            {
                order--;
            }
            var model = new DepartemenModel();
            using (MySqlCommand cmd = new MySqlCommand("select * from departemen limit @nomer,1", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomer", order);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        model.Kode = rd["kode"].ToString();
                        model.Nama = rd["nama"].ToString();
                        model.KenaDiskon = rd["kenadiskon"].Equals(true) ? true : false;
                    }
                }
            }
            return model;
        }
    }
}

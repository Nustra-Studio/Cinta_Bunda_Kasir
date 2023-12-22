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
            using (MySqlCommand cmd = new MySqlCommand("select count(*) from category_barangs", op.Conn))
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
        public bool Insert(DepartemenModel md)
        {
            bool isExist = false;
            bool status = false;
            try
            {
                using (var cmd = new MySqlCommand($"SELECT * FROM category_barangs WHERE kode='{md.Kode}'", op.Conn))
                {
                    op.KonekDB();
                    using (var rd = cmd.ExecuteReader())
                    {
                        rd.Read();
                        if (rd.HasRows)
                        {
                            isExist = true;
                        }
                    }
                }
                if (isExist == true)
                {
                    mb.PeringatanOK("Kode tersebut Sudah Ada");
                    status = false;
                }
                else
                {
                    using (MySqlCommand cmd = new MySqlCommand("insert into category_barangs values(null,md5(@nama),@nama,@kode,@diskon,@grosir,@tanggal,@tanggal)", op.Conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", md.Nama);
                        cmd.Parameters.AddWithValue("@kode", md.Kode);
                        cmd.Parameters.AddWithValue("@diskon", md.KenaDiskon);
                        cmd.Parameters.AddWithValue("@grosir", md.IsGrosir);
                        cmd.Parameters.AddWithValue("@tanggal", op.myDatetime);

                        op.KonekDB();
                        cmd.ExecuteNonQuery();
                        op.KonekDB();
                        mb.InformasiOK("Data Disimpan!");
                    }
                    status = true;
                }

            }
            catch (Exception ex)
            {
                mb.PeringatanOK(ex.Message.ToString());
            }
            return status;
        }

        public bool edit(DepartemenModel md)
        {
            bool state = false;
            try
            {
                if (mb.PeringatanYesNo("Edit Data?")==true)
                {
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE category_barangs SET name=@nama,diskon=@diskon,grosir=@grosir,updated_at=@tanggal WHERE kode=@kode", op.Conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", md.Nama);
                        cmd.Parameters.AddWithValue("@kode", md.Kode);
                        cmd.Parameters.AddWithValue("@diskon", md.KenaDiskon);
                        cmd.Parameters.AddWithValue("@grosir", md.IsGrosir);
                        cmd.Parameters.AddWithValue("@tanggal", op.myDatetime);

                        op.KonekDB();
                        cmd.ExecuteNonQuery();
                        op.KonekDB();
                        mb.InformasiOK("Data Ter Edit");
                    }
                    state = true;
                }
                else
                {
                    state = false;
                }
            }
            catch (Exception ex)
            {
                mb.PeringatanOK(ex.Message.ToString());
            }
            return state;
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
                    using (MySqlCommand cmd = new MySqlCommand("delete from category_barangs where kode=@kode", op.Conn))
                    {
                        cmd.Parameters.AddWithValue("@kode", model.Kode);
                        op.KonekDB();
                        cmd.ExecuteNonQuery();
                        op.KonekDB();
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        public DepartemenModel showBykode(DepartemenModel model)
        {
            using (var cmd = new MySqlCommand($"SELECT * FROM category_barangs where kode='{model.Kode}'",op.Conn))
            {
                op.KonekDB();
                using (var rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    var md = new DepartemenModel();
                    md.Kode = rd["kode"].ToString();
                    md.Nama = rd["name"].ToString();
                    md.KenaDiskon = Convert.ToInt32(rd["diskon"].ToString());
                    md.IsGrosir = Convert.ToInt32(rd["grosir"].ToString());
                    return md;
                }
            }
        }

        public DepartemenModel topValue()
        {
            order = 0;
            var model = new DepartemenModel();
            using (MySqlCommand cmd = new MySqlCommand("select * from category_barangs limit @nomer,1", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomer", order);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        model.Kode = rd["kode"].ToString();
                        model.Nama = rd["name"].ToString();
                        model.KenaDiskon = Convert.ToInt32(rd["diskon"].ToString());
                        model.IsGrosir = Convert.ToInt32(rd["grosir"].ToString());
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
            using (MySqlCommand cmd = new MySqlCommand("select * from category_barangs limit @nomer,1", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomer", order);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        model.Kode = rd["kode"].ToString();
                        model.Nama = rd["name"].ToString();
                        model.KenaDiskon = Convert.ToInt32(rd["diskon"].ToString());
                        model.IsGrosir = Convert.ToInt32(rd["grosir"].ToString());
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
            using (MySqlCommand cmd = new MySqlCommand("select * from category_barangs limit @nomer,1", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomer", _batas);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        model.Kode = rd["kode"].ToString();
                        model.Nama = rd["name"].ToString();
                        model.KenaDiskon = Convert.ToInt32(rd["diskon"].ToString());
                        model.IsGrosir = Convert.ToInt32(rd["grosir"].ToString());
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
            using (MySqlCommand cmd = new MySqlCommand("select * from category_barangs limit @nomer,1", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomer", order);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        model.Kode = rd["kode"].ToString();
                        model.Nama = rd["name"].ToString();
                        model.KenaDiskon = Convert.ToInt32(rd["diskon"].ToString());
                        model.IsGrosir = Convert.ToInt32(rd["grosir"].ToString());
                    }
                }
            }
            return model;
        }
    }
}

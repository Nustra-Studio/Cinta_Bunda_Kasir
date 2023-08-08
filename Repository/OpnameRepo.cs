using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using KasirApp.Model;
using System.Data;

namespace KasirApp.Repository
{
    public class OpnameRepo
    {
        Operator op = new Operator();

        //Constructor
        public OpnameRepo()
        {

        }

        //MySql Method
        public OpnameModel getNumber()
        {
            var model = new OpnameModel();
            using (MySqlCommand cmd = new MySqlCommand("select POP from numberingkwitansi",op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        model.NumeringKwitansi = Convert.ToInt32(rd["POP"].ToString());
                    }
                }
                op.KonekDB();
            }
            return model;
        }

        //CRUD Method
        public void masukanOpname(OpnameModel model)
        {
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Opnames VALUES(null,md5(RAND()),@nomer,@nama,@barcode,@stok,@perubahan,@selisih,@posted,@tanggal)",op.Conn))
            {
                cmd.Parameters.AddWithValue("nomer", model.Nomor);
                cmd.Parameters.AddWithValue("nama", model.Nama);
                cmd.Parameters.AddWithValue("barcode", model.Barcode);
                cmd.Parameters.AddWithValue("stok", model.Stok);
                cmd.Parameters.AddWithValue("perubahan", model.Perubahan);
                cmd.Parameters.AddWithValue("selisih", model.Selisih);
                cmd.Parameters.AddWithValue("posted", model.Posted);
                cmd.Parameters.AddWithValue("tanggal", model.Tanggal);
                op.KonekDB();
                cmd.ExecuteNonQuery();
                op.KonekDB();
            }
        }

        public DataTable showtable(OpnameModel model)
        {
            DataTable dt = new DataTable();
            using (MySqlCommand cmd = new MySqlCommand("select * from view_opname where nomerTrans=@nomor",op.Conn))
            {
                cmd.Parameters.AddWithValue("nomor", model.Nomor);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    if (!rd.HasRows)
                    {
                        dt = null;
                    }
                    else
                    {
                        dt.Load(rd);
                    }
                }
                op.KonekDB();
            }
            return dt;
        }

        public bool Cek(OpnameModel model)
        {
            bool periksa = false;
            using (MySqlCommand cmd = new MySqlCommand("select Nama from view_barang where Nama Like '%@nama%'",op.Conn))
            {
                cmd.Parameters.AddWithValue("nama", model.Nama);
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        if (rd.HasRows)
                        {
                            periksa = true;
                        }
                        else
                        {
                            periksa = false;
                        }
                    }
                }
            }
            return periksa;
        }
    }
}

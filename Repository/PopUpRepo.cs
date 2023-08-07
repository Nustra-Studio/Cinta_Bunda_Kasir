using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KasirApp.Model;
using KasirApp.Presenter;
using MySql.Data.MySqlClient;
namespace KasirApp.Repository
{
    public class PopUpRepo
    {
        //Fields
        Operator op = new Operator();

        //Costructor
        public PopUpRepo()
        {

        }

        public DataTable Barangs()
        {
            DataTable dt = new DataTable();
            using (MySqlCommand cmd = new MySqlCommand("SELECT Nama, Barcode, Categori FROM view_barangs_all", op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    dt.Load(rd);
                }
                op.KonekDB();
            }
            return dt;
        }

        public BarangsModel AmbildataBarang(string text)
        {
            BarangsModel model = new BarangsModel();
            op.KonekDB();
            using (MySqlCommand cmd = new MySqlCommand("select * from view_barangs_all where Barcode=@kode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@kode", text);
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        model.Nama = rd["Nama"].ToString();
                        model.Kode = rd["Barcode"].ToString();
                        model.Stok = rd["Stok"].ToString();
                    }
                }
            }
            op.KonekDB();
            return model;
        }
    }
}

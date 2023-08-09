using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using KasirApp.Model;

namespace KasirApp.Repository
{
    public class PostingOpnameRepo
    {
        //Fields
        Operator op = new Operator();
        MboxOperator mb = new MboxOperator();
        int nomor;


        //Constructor
        public PostingOpnameRepo()
        {

        }

        //Method
        public void PostOpname(string tnggal)
        {
            if (CekData(tnggal)==false)
            {
                mb.PeringatanOK("Tidak ada yang bisa di Posting Hari ini");
            }
            else
            {
                List<OpnameModel> listOpname = new List<OpnameModel>();    
                using (MySqlCommand cmd = new MySqlCommand("Select * from opnames Where Created_at = '" + tnggal +"' AND Posted = 0", op.Conn))
                {
                    op.KonekDB();
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var model = new OpnameModel();
                            model.Nomor = rd["nomerTrans"].ToString();
                            model.Nama = rd["Nama"].ToString();
                            model.Barcode = rd["Barcode"].ToString();
                            model.Stok = rd["Stok"].ToString();
                            model.Perubahan = rd["Perubahan"].ToString();
                            model.Selisih = rd["Selisih"].ToString();
                            model.Posted = Convert.ToInt32(rd["Posted"].ToString());
                            model.Tanggal = rd["Created_at"].ToString();

                            listOpname.Add(model);
                        }
                    }
                    op.KonekDB();
                }
                UpdateOpname(listOpname);
            }
        }

        private void UpdateOpname(List<OpnameModel> md)
        {
            foreach (var model in md)
            {
                using (MySqlCommand cmd = new MySqlCommand("UPDATE barangs SET stok = @stok WHERE kode_barang = @barcode",op.Conn))
                {
                    cmd.Parameters.AddWithValue("stok", model.Perubahan);
                    cmd.Parameters.AddWithValue("barcode", model.Barcode);

                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
            }
            UpNumberingStatus(md);
        }

        private void UpNumberingStatus(List<OpnameModel> mdl)
        {
            //Update Status Opname
            foreach (var model in mdl)
            {
                using (MySqlCommand cmd = new MySqlCommand("UPDATE opnames SET Posted = 1", op.Conn))
                {
                    op.KonekDB();
                    cmd.ExecuteNonQuery();
                    op.KonekDB();
                }
            }
            //Update Penomoran Kwitansi POP
            using (MySqlCommand cmd = new MySqlCommand("Select POP from numberingkwitansi", op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        nomor = Convert.ToInt32(rd["POP"]);
                    }
                }
                op.KonekDB();
            }
            int update = nomor + 1;
            using (MySqlCommand cmd = new MySqlCommand("UPDATE numberingkwitansi SET POP = @value WHERE POP = @Set", op.Conn))
            {
                cmd.Parameters.AddWithValue("value", update);
                cmd.Parameters.AddWithValue("Set", nomor);

                op.KonekDB();
                cmd.ExecuteNonQuery();
                op.KonekDB();
            }
            mb.InformasiOK("Berhasil Posting Opname");
        }

        //CekData
        public bool CekData(string tnggal)
        {
            using (MySqlCommand cmd = new MySqlCommand("Select * from opnames Where Created_at = '" + tnggal + "' AND Posted = 0", op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        op.KonekDB();
                        return false;
                    }
                }
            }
        }
    }
}

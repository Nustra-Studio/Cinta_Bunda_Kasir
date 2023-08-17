using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using KasirApp.Model;
using MySql.Data.MySqlClient;
using System.Net;
using Newtonsoft.Json;
using System.Data;

namespace KasirApp.Repository
{
    class TransaksiRepo
    {
        //Fields
        MboxOperator mb = new MboxOperator();
        Operator op = new Operator();

        //Constructor
        public TransaksiRepo()
        {

        }

        //Local Method
        public int AmbilNomor()
        {
            int nomor = 0;
            using (MySqlCommand cmd = new MySqlCommand("select PJC from numberingkwitansi", op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        nomor = Convert.ToInt32(rd["PJC"].ToString());
                    }
                }
                op.KonekDB();
            }
            return nomor;
        }

        public bool CekData(TransaksiModel model)
        {
            using (MySqlCommand cmd = new MySqlCommand("select * from barangs where kode_barang = @kode OR name = @kode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@kode", model.Barkode);
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
                        return false;
                    }
                }
            }
        }

        public TransaksiModel AmbilValueRead(TransaksiModel model)
        {
            var md = new TransaksiModel();
            using (MySqlCommand cmd = new MySqlCommand("select * from barangs where kode_barang = @kode OR name = @kode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@kode", model.Barkode);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();

                    //Data AssignMent
                    md.NomorPJ = model.NomorPJ;
                    md.Nama = rd["name"].ToString();
                    md.Barkode = rd["kode_barang"].ToString();
                    md.Quantity = "1";
                    md.Harga_jual = rd["harga_jual"].ToString();
                    md.Harga_pokok = rd["harga_pokok"].ToString();
                    md.Tanggal = DateTime.Now.ToString("yyyy/MM/dd");

                    //Logic
                    int qty = Convert.ToInt32(md.Quantity);
                    int HJ = Convert.ToInt32(md.Harga_jual);
                    int TotalPCS = qty * HJ;
                    md.Total = TotalPCS.ToString();

                }
            }
            return md;
        }

        //Cek Kesamaan pada saat insert
        public void CekRows(TransaksiModel md)
        {
            using (MySqlCommand cmd = new MySqlCommand("select * from histori_penjualan where nomerTrans = @nomer AND barcode = @kode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomer", md.NomorPJ);
                cmd.Parameters.AddWithValue("@kode", md.Barkode);
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        int qty =  Convert.ToInt32(rd["quantity"].ToString()) + 1;
                        int total = qty * Convert.ToInt32(rd[md.State].ToString());
                        using (MySqlCommand com = new MySqlCommand("UPDATE histori_penjualan SET quantity = @Qty,total = @total where nomerTrans = @nomor AND barcode = @kode", op.Conn))
                        {
                            com.Parameters.AddWithValue("nomor", md.NomorPJ);
                            com.Parameters.AddWithValue("kode", md.Barkode);
                            com.Parameters.AddWithValue("Qty", qty);
                            com.Parameters.AddWithValue("total", total);

                            op.KonekDB();
                            rd.Close();
                            com.ExecuteNonQuery();
                            op.KonekDB();
                        }
                    }
                    else
                    {
                        rd.Close();
                        AmbilValue(md);
                    }
                }
            }
        }

        public void AmbilValue(TransaksiModel model)
        {
            var md = new TransaksiModel();
            using (MySqlCommand cmd = new MySqlCommand("select * from barangs where kode_barang = @kode OR name = @kode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@kode", model.Barkode);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();

                    //Data AssignMent
                    md.NomorPJ = model.NomorPJ;
                    md.Nama = rd["name"].ToString();
                    md.Barkode = rd["kode_barang"].ToString();
                    md.Quantity = "1";
                    md.Harga_jual = rd["harga_jual"].ToString();
                    md.Harga_pokok = rd["harga_pokok"].ToString();
                    md.Tanggal = DateTime.Now.ToString("yyyy/MM/dd");

                    //Logic
                    int qty = Convert.ToInt32(md.Quantity);
                    int HJ = Convert.ToInt32(rd[model.State].ToString());
                    int TotalPCS = qty * HJ;
                    md.Total = TotalPCS.ToString();
                }
            }
            insertPJ(md);
        }

        public void insertPJ(TransaksiModel model)
        {
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO histori_penjualan VALUES (null,md5(RAND()), @nomorPJ, @nama, @barcode, @quantity, @HJ, @HPP, @Total, @tanggal, @id_member)", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomorPJ", model.NomorPJ);
                cmd.Parameters.AddWithValue("@nama", model.Nama);
                cmd.Parameters.AddWithValue("@barcode", model.Barkode);
                cmd.Parameters.AddWithValue("@quantity", "1");//insert satu quantity
                cmd.Parameters.AddWithValue("@HJ", model.Harga_jual);
                cmd.Parameters.AddWithValue("@HPP", model.Harga_pokok);
                cmd.Parameters.AddWithValue("@Total", 1 * Convert.ToInt32(model.Total));
                cmd.Parameters.AddWithValue("@tanggal", model.Tanggal);
                cmd.Parameters.AddWithValue("@id_member", model.Id_member);

                op.KonekDB();
                cmd.ExecuteNonQuery();
                op.KonekDB();
            }
        }

        public void UpdateNumberint()
        {
            int nomor = 0;
            using (MySqlCommand cmd = new MySqlCommand("Select PJC from numberingkwitansi", op.Conn))
            {
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        nomor = Convert.ToInt32(rd["PJC"]);
                    }
                }
                op.KonekDB();
            }
            int update = nomor + 1;
            using (MySqlCommand cmd = new MySqlCommand("UPDATE numberingkwitansi SET PJC = @value WHERE PJC = @Set", op.Conn))
            {
                cmd.Parameters.AddWithValue("value", update);
                cmd.Parameters.AddWithValue("Set", nomor);

                op.KonekDB();
                cmd.ExecuteNonQuery();
                op.KonekDB();
            }
        }

        public DataTable SetView(TransaksiModel model)
        {
            UpdateHarga(model);
            var dt = new DataTable();
            using (MySqlCommand cmd = new MySqlCommand("select barcode, nama, quantity, " + model.State + ", total from histori_penjualan where nomerTrans = '" + model.NomorPJ + "' ", op.Conn))
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

        public void UpdateQuantity(TransaksiModel model)
        {
            using (MySqlCommand cmd = new MySqlCommand("select * from histori_penjualan where nomerTrans = @nomor AND barcode = @barcode", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomor", model.NomorPJ);
                cmd.Parameters.AddWithValue("@barcode", model.Barkode);
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    rd.Read();
                    if (rd.HasRows)
                    {
                        int total = Convert.ToInt32(model.Quantity) * Convert.ToInt32(rd[model.State].ToString());
                        using (MySqlCommand com = new MySqlCommand("UPDATE histori_penjualan SET quantity = @Qty,total = @total where nomerTrans = @nomor AND barcode = @kode", op.Conn))
                        {
                            com.Parameters.AddWithValue("nomor", model.NomorPJ);
                            com.Parameters.AddWithValue("kode", model.Barkode);
                            com.Parameters.AddWithValue("Qty", model.Quantity);
                            com.Parameters.AddWithValue("total", total);

                            op.KonekDB();
                            rd.Close();
                            com.ExecuteNonQuery();
                            op.KonekDB();
                        }
                    }
                }
            }
        }

        public void UpdateHarga(TransaksiModel model)
        {
            int HJ = 0;
            var listmodel = new List<TransaksiModel>();
            using (MySqlCommand cmd = new MySqlCommand("select * from histori_penjualan where nomerTrans = @nomor", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomor", model.NomorPJ);
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    op.KonekDB();
                    while (rd.Read())
                    {
                        var md = new TransaksiModel();

                        //Data AssignMent
                        md.NomorPJ = model.NomorPJ;
                        md.Nama = rd["nama"].ToString();
                        md.Barkode = rd["barcode"].ToString();
                        md.Quantity = rd["quantity"].ToString();
                        md.Harga_jual = rd["harga_jual"].ToString();
                        md.Harga = rd[model.State].ToString();
                        md.Harga_pokok = rd["hpp"].ToString();
                        md.Tanggal = DateTime.Now.ToString("yyyy/MM/dd");

                        //Logic
                        int qty = Convert.ToInt32(md.Quantity);
                        HJ = Convert.ToInt32(md.Harga);
                        int TotalPCS = qty * HJ;
                        md.Total = TotalPCS.ToString();

                        listmodel.Add(md);
                    }
                }

                foreach (var md in listmodel)
                {
                    int total = Convert.ToInt32(md.Quantity) * Convert.ToInt32(md.Harga);
                    using (MySqlCommand com = new MySqlCommand("UPDATE histori_penjualan SET " + model.State + " = @harga, total = @total where nomerTrans = @nomor AND barcode = @kode", op.Conn))
                    {
                        com.Parameters.AddWithValue("nomor", model.NomorPJ);
                        com.Parameters.AddWithValue("harga", md.Harga);
                        com.Parameters.AddWithValue("kode", md.Barkode);
                        com.Parameters.AddWithValue("total", total);

                        op.KonekDB();
                        com.ExecuteNonQuery();
                        op.KonekDB();
                    }
                }
            }
        }

        public void Delete(TransaksiModel model)
        {
            using (MySqlCommand com = new MySqlCommand("Delete FROM histori_penjualan where nomerTrans = @nomor AND barcode = @kode", op.Conn))
            {
                com.Parameters.AddWithValue("nomor", model.NomorPJ);
                com.Parameters.AddWithValue("kode", model.Barkode);

                op.KonekDB();
                com.ExecuteNonQuery();
                op.KonekDB();
            }
        }

        //API Method
        public RootMember AmbilPoint(userDataModel model, string kode)
        {
            RootMember mem = new RootMember();
            using (var client = new RestClient($"{op.urlcloud}cabangmember/"))
            {
                var rs = new RestRequest("poin", Method.Get);
                rs.AddParameter("pin", kode);
                rs.AddParameter("token", model.token);

                var response = client.Get(rs);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string json = response.Content.ToString();
                    mem = JsonConvert.DeserializeObject<RootMember>(json);

                    //mb.InformasiOK(response.Content.ToString() + response.StatusCode.ToString());
                }
                else if(response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var jso = response.Content.ToString();
                    apiError err = JsonConvert.DeserializeObject<apiError>(jso);
                    mb.PeringatanOK(err.message.ToString());
                }
            }
            return mem;
        }

        public void insertHistori(userDataModel user, TransaksiModel model, int subtotal)
        {
            //Ambil Data Local
            List<TransaksiModel> listTrans = new List<TransaksiModel>();
            using (MySqlCommand cmd = new MySqlCommand("select * from histori_penjualan where nomerTrans = @nomer", op.Conn))
            {
                cmd.Parameters.AddWithValue("@nomer", model.NomorPJ);
                op.KonekDB();
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var md = new TransaksiModel();

                        //Data AssignMent
                        md.NomorPJ = model.NomorPJ;
                        md.Nama = rd["nama"].ToString();
                        md.Barkode = rd["barcode"].ToString();
                        md.Quantity = rd["quantity"].ToString();
                        md.Harga_jual = rd["harga_jual"].ToString();
                        md.Harga_pokok = rd["hpp"].ToString();
                        md.Tanggal = DateTime.Now.ToString("yyyy/MM/dd");

                        //Logic
                        int qty = Convert.ToInt32(md.Quantity);
                        int HJ = Convert.ToInt32(md.Harga_pokok);
                        int TotalPCS = qty * HJ;
                        md.Total = TotalPCS.ToString();

                        listTrans.Add(md);
                    }

                    using (var client = new RestClient($"{op.urlcloud}cabangmember/"))
                    {
                        var body = new
                        {
                            token = user.token,
                            id_cabang = user.uuid,
                            data = model,
                            subtotal = subtotal
                        };

                        var rs = new RestRequest("transaksi", Method.Post);
                        rs.AddJsonBody(body);

                        var response = client.Post(rs);
                        mb.InformasiOK(response.Content.ToString());
                    }
                    //Update Nomor
                    UpdateNumberint();
                }
            }
        }
    }
}
